/*--------------------------------------------------------------------------------------------------*/
--title         : '사용자 그룹 정보'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_GROUP') DROP TABLE TB_iEIP_MONITOR_GROUP
Go

CREATE TABLE TB_iEIP_MONITOR_GROUP
(
    mailadrs        nvarchar(64)        not null,                       -- 메일주소
    groupid         nvarchar(64)        not null,                       -- 그룹아디
    
    grpname         nvarchar(64)            null,                       -- 그룹명
    detect          datetime            not null default(getdate()),    -- 발견일시
    
    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_GROUP ON TB_iEIP_MONITOR_GROUP
(
    mailadrs, groupid
)
Go

/*--------------------------------------------------------------------------------------------------*/
--title         : '사용자 정보 저장'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_USRS') DROP TABLE TB_iEIP_MONITOR_USRS
Go

CREATE TABLE TB_iEIP_MONITOR_USRS
(
    mailadrs        nvarchar(64)        not null,                       -- 메일주소
    
    userid          nvarchar(64)            null,                       -- 사용자아디
    name            nvarchar(32)            null,                       -- 성명
    nick            nvarchar(128)           null,                       -- 별명
    
    password        nvarchar(32)            null,                       -- 암호

    company         nvarchar(64)            null,                       -- 소속회사
    depart          nvarchar(64)            null,                       -- 소속부서
    empid           nvarchar(32)            null,                       -- 사번
    empmail         nvarchar(64)            null,                       -- 회사메일
    phone           nvarchar(32)            null,                       -- 전화번호

    gender          nvarchar(1)         not null default('M'),          -- 성별
    ipadrs          nvarchar(32)            null,                       -- IP주소

    detect          datetime            not null default(getdate()),    -- 발견일시
    
    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_USRS ON TB_iEIP_MONITOR_USRS
(
    mailadrs
)
Go

/*--------------------------------------------------------------------------------------------------*/
--title         : '사용자 친구 정보'
--
--Description   : 
--
--Author        : 
--Date          : 
--NickName      : 
--Version       : 
/*--------------------------------------------------------------------------------------------------*/
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_BUDDY') DROP TABLE TB_iEIP_MONITOR_BUDDY
Go

CREATE TABLE TB_iEIP_MONITOR_BUDDY
(
    mailadrs        nvarchar(64)        not null,                       -- 메일주소
    buddymail       nvarchar(64)        not null,                       -- 친구주소
    
    buddyid         nvarchar(64)            null,                       -- 사용자아디
    buddynick       nvarchar(128)           null,                       -- 별명

    groupid         nvarchar(64)            null,                       -- 그룹아디

    presence        decimal(4)              null,                       -- FL(1), AL(2), BL(4), RL(8)
    detect          datetime            not null default(getdate()),    -- 발견일시
    
    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_BUDDY ON TB_iEIP_MONITOR_BUDDY
(
    mailadrs, buddymail
)
Go

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
If EXISTS (SELECT * FROM sysobjects WHERE name = 'TB_iEIP_MONITOR_MSGS') DROP TABLE TB_iEIP_MONITOR_MSGS
Go

CREATE TABLE TB_iEIP_MONITOR_MSGS
(
    seqno           decimal(38) IDENTITY(1,1) not null,                 -- 자동 증가 값

    sender          nvarchar(64)            null,                       -- 송신자메일주소
    sendipadrs      nvarchar(32)            null,                       -- 송신자IP주소
    sendport        int                     null,                       -- 송신포트번호
    sendernick      nvarchar(128)           null,                       -- 송신자별명
    
    receiver        nvarchar(64)            null,                       -- 수신자메일주소
    recvipadrs      nvarchar(32)            null,                       -- 수신자IP주소
    recvport        int                     null,                       -- 포트번호

    sentime         datetime            not null default(getdate()),    -- 송신 일시
    content         nvarchar(4000)          null,                       -- 내용
    
    attach          image                   null,                       -- 파일전달

    sfid            datetime            not null default(getdate()),    -- create
    slmd            datetime            not null default(getdate())     -- update
)
Go

CREATE UNIQUE CLUSTERED INDEX IX_iEIP_MONITOR_MSGS ON TB_iEIP_MONITOR_MSGS
(
    seqno
)
Go

/*--------------------------------------------------------------------------------------------------*/
--
/*--------------------------------------------------------------------------------------------------*/