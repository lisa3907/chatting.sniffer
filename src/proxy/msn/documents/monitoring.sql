/*
UPDATE TB_iEIP_MONITOR_USRS
SET name=y.name, company=y.company, depart=y.depart, empid=y.empid, empmail=y.empmail, phone=y.phone, gender=y.gender
FROM TB_iEIP_MONITOR_USRS x,
(
	SELECT b.mailadrs, a.* FROM 
	(
		SELECT SUBSTRING(EMailWnTh,1, CHARINDEX('@', EMailWnTh)-1) as mail,
			TjdAud as name, 'odinsoft' as company, ThThrQnTjAud as depart, 
			DlsTkZhEm as empid, EMailWnTh as empmail, WjsGhkQjsGh as phone, 
			CASE WHEN TjdQuf='PAY03001' THEN 'M' ELSE 'F' END as gender
		FROM COMSV1.iERPR52010.dbo.TB_iPAY_EMPLOYEE00 
		WHERE CHARINDEX('@', EMailWnTh) > 1
	) a,
	(
		SELECT SUBSTRING(mailadrs,1, CHARINDEX('@', mailadrs)-1) as mail, mailadrs
		FROM TB_iEIP_MONITOR_USRS 
		WHERE CHARINDEX('@', mailadrs) > 1
	) b
	WHERE a.mail = b.mail
) y
WHERE x.mailadrs=y.mailadrs

UPDATE TB_iEIP_MONITOR_USRS
SET name=y.name, company=y.company, depart=y.depart, empid=y.empid, empmail=y.empmail, phone=y.phone, gender=y.gender
FROM TB_iEIP_MONITOR_USRS x,
(
	SELECT a.mailadrs, b.TjdAud as name, 'odinsoft' as company, b.ThThrQnTjAud as depart, 
		b.DlsTkZhEm as empid, b.EMailWnTh as empmail, b.WjsGhkQjsGh as phone, 
		CASE WHEN b.TjdQuf='PAY03001' THEN 'M' ELSE 'F' END as gender
	FROM TB_iEIP_MONITOR_USRS a, COMSV1.iERPR52010.dbo.TB_iPAY_EMPLOYEE00 b
	WHERE ISNULL(a.empid,'')='' AND ISNULL(a.name,'')!=''
	  AND a.name=b.TjdAud
) y
WHERE x.mailadrs=y.mailadrs

SELECT * FROM TB_iEIP_MONITOR_USRS
SELECT * FROM TB_iEIP_MONITOR_BUDDY
SELECT * FROM TB_iEIP_MONITOR_GROUP

SELECT b.name, a.*, b.nick FROM
(
	SELECT buddymail, count(*) as norec
	FROM TB_iEIP_MONITOR_BUDDY
	GROUP BY buddymail
) a, TB_iEIP_MONITOR_USRS b
WHERE a.norec > 1 AND a.buddymail=b.mailadrs
ORDER BY a.norec DESC

SELECT sentime, seqno, sender, receiver, content
FROM TB_iEIP_MONITOR_MSGS
WHERE content like '%%'
ORDER BY seqno DESC

SELECT sentime, sendipadrs, sender, sendernick, recvipadrs, receiver, content
FROM TB_iEIP_MONITOR_MSGS
WHERE CONVERT(nvarchar(10), sentime, 121)='2006-07-13'
ORDER BY seqno DESC

SELECT * FROM
(
	SELECT sender, receiver, COUNT(*) as norec
	FROM TB_iEIP_MONITOR_MSGS
	WHERE CONVERT(nvarchar(10), sentime, 121)>=CONVERT(nvarchar(10), getdate(), 121) 
	GROUP BY sender, receiver
) x
ORDER BY norec DESC
*/

SELECT x.seqno, x.sentime, x.sendername, x.sendernick, x.depart,
	x.sender, x.content, y.receiver, y.recvname, y.nick, y.depart
FROM
(
	SELECT a.seqno as seqno, a.sender, b.name as sendername, a.sendernick, b.depart, a.sentime, content
	FROM TB_iEIP_MONITOR_MSGS a, TB_iEIP_MONITOR_USRS b
	WHERE a.sender=b.mailadrs
) x,
(
	SELECT a.seqno as seqno, a.receiver, b.name as recvname, b.nick, b.depart
	FROM TB_iEIP_MONITOR_MSGS a, TB_iEIP_MONITOR_USRS b
	WHERE a.receiver=b.mailadrs
) y
WHERE x.seqno=y.seqno
AND CONVERT(nvarchar(10), x.sentime, 121)>=CONVERT(nvarchar(10), getdate()-3, 121) 
ORDER BY x.sentime
