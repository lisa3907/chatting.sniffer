/*----------------------------------------------------------------------------------------------------------*/
-- '타이틀   		: '
-- '프로그램명 	 	: '
-- '작성자  		: '
-- '작성일  		: '
-- 'Version 		: '
/*----------------------------------------------------------------------------------------------------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE NAME = 'SP_iEIP_MONITOR_MSGS') DROP PROCEDURE SP_iEIP_MONITOR_MSGS
Go

/*----------------------------------------------------------------------------------------------------------*/
-- 
/*----------------------------------------------------------------------------------------------------------*/
CREATE PROCEDURE SP_iEIP_MONITOR_MSGS
	@frdate datetime,
	@todate datetime
AS
BEGIN
/*------------------------------------------------------------------------------------------------*/
--변수정의
/*------------------------------------------------------------------------------------------------*/
DECLARE @seqno1 decimal(38,0), @sender1 nvarchar(128), @receiver1 nvarchar(128), @content1 nvarchar(4000),
		@seqno2 decimal(38,0), @sender2 nvarchar(128), @receiver2 nvarchar(128), @content2 nvarchar(4000),
		@result decimal(38,0)

/*------------------------------------------------------------------------------------------------*/
--
/*------------------------------------------------------------------------------------------------*/
--BEGIN TRANSACTION

	/*--------------------------------------------------------------------------------------------*/
	--
	/*--------------------------------------------------------------------------------------------*/
	DELETE TB_iEIP_MONITOR_MSGS
	 WHERE ISNULL(sender, '')='' OR ISNULL(receiver, '')=''

	/*--------------------------------------------------------------------------------------------*/
	--
	/*--------------------------------------------------------------------------------------------*/
	DECLARE CR_iEIP_MONITOR_MSGS SCROLL CURSOR FOR
	SELECT	seqno, sender, receiver, content
	  FROM	TB_iEIP_MONITOR_MSGS 
	 WHERE	CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frdate, 121)
	   AND	CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @todate, 121)
	ORDER BY sender, receiver, sentime DESC

	OPEN CR_iEIP_MONITOR_MSGS 

	FETCH NEXT FROM CR_iEIP_MONITOR_MSGS 
		INTO @seqno1, @sender1, @receiver1, @content1

	SET @result = 0
	
	WHILE (@@FETCH_STATUS != -1)
	BEGIN
		FETCH NEXT FROM CR_iEIP_MONITOR_MSGS 
			INTO @seqno2, @sender2, @receiver2, @content2

		IF (@@FETCH_STATUS != -1)
		BEGIN
			IF (@sender1=@sender2 AND @receiver1=@receiver2 AND @content1=@content2)
			BEGIN
				DELETE TB_iEIP_MONITOR_MSGS
				WHERE seqno=@seqno1
			
				SET @result = @result + 1

				FETCH NEXT FROM CR_iEIP_MONITOR_MSGS 
					INTO @seqno1, @sender1, @receiver1, @content1
			END 
			ELSE
			BEGIN
				SET @seqno1 = @seqno2				
				SET @sender1 = @sender2
				SET @receiver1 = @receiver2
				SET @content1 = @content2
			END
		END
	END 
 
	CLOSE	CR_iEIP_MONITOR_MSGS
 	DEALLOCATE CR_iEIP_MONITOR_MSGS

	/*--------------------------------------------------------------------------------------------*/
	--
	/*--------------------------------------------------------------------------------------------*/
	DELETE TB_iEIP_MONITOR_MSGS
	 WHERE CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frdate, 121)
	   AND CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @todate, 121)
	   AND 
		(
			sender in (SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM WHERE inclusion='S')
			OR 
			receiver in ( SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM WHERE inclusion='S')
		)

	/*--------------------------------------------------------------------------------------------*/
	--
	/*--------------------------------------------------------------------------------------------*/
	SELECT @result
	
--COMMIT TRANSACTION
--RETURN(@result)

/*------------------------------------------------------------------------------------------------*/
--
/*------------------------------------------------------------------------------------------------*/
END;

/*------------------------------------------------------------------------------------------------
DECLARE @today datetime, @frday datetime, @result decimal(38,0)
SET @today = '2006-01-01'
SET @frday = getdate()
EXEC @result = SP_iEIP_MONITOR_MSGS @today, @frday
PRINT @result
------------------------------------------------------------------------------------------------*/
