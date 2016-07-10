SELECT * FROM TB_iEIP_MONITOR_SMTP
WHERE content is null
OR ISNULL(sender,'')='' OR ISNULL(receivers,'')=''
OR ISNULL(completed,'')!='T' OR ISNULL(timeout,'')!='F'
OR sender in (SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE typeofsender='M')
OR REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') in 
		(SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE typeofsender='D')

--
DELETE TB_iEIP_MONITOR_SMTP 
WHERE ISNULL(sender,'')='' OR ISNULL(receivers,'')=''
OR ISNULL(completed,'')!='T' OR ISNULL(timeout,'')!='F'
OR content is null
OR sender in (SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE typeofsender='M')
OR REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') in 
		(SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE typeofsender='D')

INSERT INTO TB_iEIP_MONITOR_SMTP_SPAM
(sender, typeofsender) 
VALUES ('house.info', 'D')

SELECT * FROM
(
	SELECT sender, count(*) as norec
	FROM TB_iEIP_MONITOR_SMTP
	GROUP BY sender
) x
ORDER BY x.norec DESC

DELETE TB_iEIP_MONITOR_SMTP 
WHERE sender='FROM:<>'

SELECT * 
FROM
(
	SELECT *, CHARINDEX('@', sender) as indexer
	FROM TB_iEIP_MONITOR_SMTP
) x
WHERE x.indexer < 1


SELECT * 
FROM
(
	SELECT domain, count(*) as norec
	FROM
	(
		SELECT REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') as domain
		FROM TB_iEIP_MONITOR_SMTP
	) x
	GROUP BY domain
) y
ORDER BY norec DESC



SELECT * FROM TB_iEIP_MONITOR_SMTP_SPAM


SELECT * FROM TB_iEIP_MONITOR_SMTP
WHERE REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') in 
		(SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE typeofsender='D')