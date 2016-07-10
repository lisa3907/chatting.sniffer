/*--------------------------------------------------------------------------------------------------*/
--title         : '胶圃 皋老 林家 历厘'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_SMTP_SPAM') DROP TABLE TB_iEIP_MONITOR_SMTP_SPAM
Go

CREATE TABLE TB_iEIP_MONITOR_SMTP_SPAM
(
    sender          nvarchar(64)        not null,                       -- 价脚磊皋老林家
	
    sendipadrs      nvarchar(32)            null,                       -- 价脚磊IP林家

	typeofsender	nvarchar(1)			not null default('M'),			-- 林家屈怕(M:mail, D:domain)
	inclusion		nvarchar(1)			not null default('S'),			-- 胶圃林家('S'), 蜡瓤茄 林家('V')

    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_SMTP_SPAM ON TB_iEIP_MONITOR_SMTP_SPAM
(
    sender
)
Go

/*--------------------------------------------------------------------------------------------------*/
--
/*--------------------------------------------------------------------------------------------------*/