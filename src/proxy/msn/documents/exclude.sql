/*--------------------------------------------------------------------------------------------------*/
--title         : '力寇 皋老 林家 历厘'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_MSGS_SPAM') DROP TABLE TB_iEIP_MONITOR_MSGS_SPAM
Go

CREATE TABLE TB_iEIP_MONITOR_MSGS_SPAM
(
    sender          nvarchar(64)        not null,                       -- 价脚磊皋老林家
	inclusion		nvarchar(1)			not null default('S'),			-- 胶圃林家('S'), 蜡瓤茄 林家('V')

    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_MSGS_SPAM ON TB_iEIP_MONITOR_MSGS_SPAM
(
    sender
)
Go

/*--------------------------------------------------------------------------------------------------*/
--
/*--------------------------------------------------------------------------------------------------*/

/*--------------------------------------------------------------------------------------------------
INSERT INTO TB_iEIP_MONITOR_MSGS_SPAM (sender, inclusion) VALUES ( 'lisa3907@msn.com', 'S')
--------------------------------------------------------------------------------------------------*/
