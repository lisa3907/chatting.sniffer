/*--------------------------------------------------------------------------------------------------*/
--title         : '모니터링 내역 저장'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_SMTP') DROP TABLE TB_iEIP_MONITOR_SMTP
Go

CREATE TABLE TB_iEIP_MONITOR_SMTP
(
    seqno           decimal(38) IDENTITY(1,1) not null,                 -- 자동 증가 값

    sender          nvarchar(64)            null,                       -- 송신자메일주소
    sendipadrs      nvarchar(32)            null,                       -- 송신자IP주소
    sendport		nvarchar(8)             null,                       -- 송신자Port#

    receivers       nvarchar(1024)          null,                       -- 수신자메일주소
    recvipadrs      nvarchar(32)            null,                       -- 수신자IP주소

    title			nvarchar(1024)          null,                       -- 제목

    sentime         datetime            not null default(getdate()),    -- 송신 일시
    attach			decimal(5)			not null default(0),			-- 첨부갯수
    content         image					null,                       -- 내용
    
    timeout			nvarchar(1)             null,                       -- Is timeout?
    validation		nvarchar(1)             null,                       -- Is correct?
    completed		nvarchar(1)             null,                       -- Is Completed?

    protocol        nvarchar(64)            null,                       -- ESMTP/SMTP
    command         nvarchar(64)            null,                       -- 마지막 전달 명령
    response        nvarchar(64)            null,                       -- 마지막 수신 응답

    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_SMTP ON TB_iEIP_MONITOR_SMTP
(
    seqno
)
Go

/*--------------------------------------------------------------------------------------------------*/
--
/*--------------------------------------------------------------------------------------------------*/