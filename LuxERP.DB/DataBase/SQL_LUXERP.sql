/*****************************
** Copyright IWOOO, Inc. 2013
** All Rights Reserved.
** 数据库部署脚本
** 2013-06-15
******************************/
use master
go

if exists(select * from sys.sysdatabases where name = 'LUXERP')
	drop database LUXERP
go

declare @device_directory nvarchar(520)
select @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', lower(filename)) - 1)
from sys.sysaltfiles where dbid = 1 and fileid = 1

execute (N'create database LUXERP 
	on primary (name = N''LUXERP'', filename = N''' + @device_directory + N'luxerp.mdf'')
	log on (name = ''LUXERP_log'', filename = N''' + @device_directory + N'luxerp.ldf'')')
go

--set quoted_identifier on
--go

use LUXERP
go
-- 0xf = 3 table
-- 0xf = 4 procedure
-- 0xf = 2 view
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.sp_GetSolutionByID') and sysstat & 0xf = 4)
--	drop procedure dbo.sp_GetSolutionByID
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.sp_UpdateSolution') and sysstat & 0xf = 4)
--	drop procedure dbo.sp_UpdateSolution
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_EventTypes') and sysstat & 0xf = 3)
--	drop table dbo.tb_EventTypes
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_EventLogs') and sysstat & 0xf = 3)
--	drop table dbo.tb_EventLogs
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_EventSteps') and sysstat & 0xf = 3)
--	drop table dbo.tb_EventSteps
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Solutions') and sysstat & 0xf = 3)
--	drop table dbo.tb_Solutions
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Stores') and sysstat & 0xf = 3)
--	drop table dbo.tb_Stores
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_AddStocks') and sysstat & 0xf = 3)
--	drop table dbo.tb_AddStocks
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_OutStockDemands') and sysstat & 0xf = 3)
--	drop table dbo.tb_OutStockDemands
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Stocks') and sysstat & 0xf = 3)
--	drop table dbo.tb_Stocks
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_OutStocks') and sysstat & 0xf = 3)
--	drop table dbo.tb_OutStocks
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_AllotStocks') and sysstat & 0xf = 3)
--	drop table dbo.tb_AllotStocks
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Express') and sysstat & 0xf = 3)
--	drop table dbo.tb_Express
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_SceneSteps') and sysstat & 0xf = 3)
--	drop table dbo.tb_SceneSteps
--go
----if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_States') and sysstat & 0xf = 3)
----	drop table dbo.tb_States
----go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Machings') and sysstat & 0xf = 3)
--	drop table dbo.tb_Machings
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Brands') and sysstat & 0xf = 3)
--	drop table dbo.tb_Brands
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Models') and sysstat & 0xf = 3)
--	drop table dbo.tb_Models
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Parameters') and sysstat & 0xf = 3)
--	drop table dbo.tb_Parameters
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_Suppliers') and sysstat & 0xf = 3)
--	drop table dbo.tb_Suppliers
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_TypeOnes') and sysstat & 0xf = 3)
--	drop table dbo.tb_TypeOnes
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_TypeTwos') and sysstat & 0xf = 3)
--	drop table dbo.tb_TypeTwos
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_TypeThrees') and sysstat & 0xf = 3)
--	drop table dbo.tb_TypeThrees
--go
--if exists(select * from sys.sysobjects where id = OBJECT_ID('dbo.tb_TypeFours') and sysstat & 0xf = 3)
--	drop table dbo.tb_TypeFours
--go

--事件类型
create table tb_EventTypes
(
	TypeCode	nvarchar(500) not null primary key,
	TypeOne		nvarchar(500),
	TypeTwo		nvarchar(500),
	TypeThree	nvarchar(500),
	TypeFour	nvarchar(500),
	EventLevel	nvarchar(500)
)

-- 店铺
create table tb_Stores
(
	StoreNo			nvarchar(500) not null primary key,
	TopStore		nvarchar(500),
	StoreType		nvarchar(500),
	Region			nvarchar(500),
	Rating			nvarchar(500),
	StoreName		nvarchar(500),
	City			nvarchar(500),
	StoreAddress	nvarchar(500),
	StoreTel		nvarchar(500),
	ContractArea	nvarchar(500),
	OpeingDate		date,
	StoreState		nvarchar(500)
)

-- 事件记录
create table tb_EventLogs
(
    ID				int identity,
	EventNo			nvarchar(500) not null primary key,
	EventTime		datetime,
	StoreNo			nvarchar(500),
	TypeCode		nvarchar(500),
	EventDescribe	nvarchar(500),
	ToResolvedTime	datetime,
	EventState		nvarchar(500),
	ResolvedTime	datetime,
	ResolvedBy		nvarchar(500),
	LogBy			nvarchar(500),
	HandingBy		nvarchar(500),
	OutStockPic		nvarchar(500),
	ScenePic		nvarchar(500)
)

-- 事件步骤
create table tb_EventSteps
(
	ID				int identity primary key,
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	StepDescribe	nvarchar(500),
	StepTime		datetime,
	StepState		nvarchar(500),
	StepBy			nvarchar(500)
)

-- 解决方案
create table tb_Solutions
(
	TypeCode		nvarchar(500) references dbo.tb_EventTypes(TypeCode),
	Content			text
)

-- 入库历史
create table tb_AddStocks
(
	ID				int not null primary key identity,
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	WarehouseNo		nvarchar(500),
	Maching			nvarchar(500),
	Brand			nvarchar(500),
	Model			nvarchar(500),
	SerialNo		nvarchar(500),
	Parameter		nvarchar(500),
	EpcTags			nvarchar(500),
	SapNo			nvarchar(500),
	PurchaseDate	datetime,
	GuaranteeTime	datetime,
	RepairsNo		nvarchar(500),
	Supplier		nvarchar(500),
	AddStockDate	datetime,
	Operator		nvarchar(500)	
)

-- 出库需求
create table tb_OutStockDemands
(
	DemandNo		int not null primary key identity,
	EventNo			nvarchar(500),
	Maching			nvarchar(500),
	Brand			nvarchar(500),
	Model			nvarchar(500),
	Parameter		nvarchar(500)
)

-- 库存
create table tb_Stocks
(
	ID					int not null primary key identity,
	EventNo				nvarchar(500),
	DemandNo			int,
	WarehouseStoreNo	nvarchar(500),
	Maching				nvarchar(500),
	Brand				nvarchar(500),
	Model				nvarchar(500),
	SerialNo			nvarchar(500),
	Parameter			nvarchar(500),
	EpcTags				nvarchar(500),
	SapNo				nvarchar(500),
	PurchaseDate		datetime,
	GuaranteeTime		datetime,
	RepairsNo			nvarchar(500),
	Supplier			nvarchar(500),
	AddStockDate		datetime,
	OutStockDate		datetime,
	Operator			nvarchar(500),
	StockType			nvarchar(500),
	MachingState		nvarchar(500)
)

-- 废损库
create table tb_ScrapStocks
(
	ID					int not null primary key identity,
	WarehouseNo			nvarchar(500),
	Maching				nvarchar(500),
	Brand				nvarchar(500),
	Model				nvarchar(500),
	SerialNo			nvarchar(500),
	Parameter			nvarchar(500),
	EpcTags				nvarchar(500),
	PurchaseDate		datetime,
	GuaranteeTime		datetime,
	RepairsNo			nvarchar(500),
	Supplier			nvarchar(500),
	AddScrapStockDate	datetime,
	Operator			nvarchar(500),
	LastWarehouseNo		nvarchar(500),
	ScrapReason			nvarchar(500)
)

-- 出库历史
create table tb_OutStocks
(
	ID				int not null primary key identity,
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	WarehouseNo		nvarchar(500),
	StoreNo			nvarchar(500),
	Maching			nvarchar(500),
	Brand			nvarchar(500),
	Model			nvarchar(500),
	SerialNo		nvarchar(500),
	Parameter		nvarchar(500),
	EpcTags			nvarchar(500),
	SapNo			nvarchar(500),
	PurchaseDate	datetime,
	GuaranteeTime	datetime,
	RepairsNo		nvarchar(500),
	Supplier		nvarchar(500),
	OutStockDate	datetime,
	Operator		nvarchar(500),
	OutStocksState	nvarchar(500)
)

-- 调拨历史
create table tb_AllotStocks
(
	ID					int not null primary key identity,
	EventNo				nvarchar(500) references dbo.tb_EventLogs(EventNo),
	WarehouseStoreNoA	nvarchar(500),
	WarehouseStoreNoB	nvarchar(500),
	Maching				nvarchar(500),
	Brand				nvarchar(500),
	Model				nvarchar(500),
	SerialNo			nvarchar(500),
	Parameter			nvarchar(500),
	AllotStockDate		datetime,
	Operator			nvarchar(500),
	AllotStockState		nvarchar(500)
)

-- 快递信息
create table tb_Express
(
	ID				int not null primary key identity,
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	ExpressCo		nvarchar(500),
	ExpressNo		nvarchar(500),
	GetOrSend		int,
	ExpressState	int
)

---- 上门状态
create table tb_SceneState
(
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	SceneState		nvarchar(500)
)

-- 预约工程师
create table tb_AppointEngineers
(
	ID				int not null primary key identity,
	EventNo			nvarchar(500) references dbo.tb_EventLogs(EventNo),
	Name			nvarchar(500),
	Phone			nvarchar(500),
	Email			nvarchar(500),
	SceneTime		datetime,
	AppointState	nvarchar(500)
	
)

---- 状态表
--create table tb_States
--(
--	StateNo			nvarchar(500) not null primary key,
--	StateName		nvarchar(500),
--	StateDateDiff	nvarchar(500),
--	StateNote		nvarchar(500)	
--)

-- 服务历史
create table tb_HistoryService
(
	EventNo				nvarchar(500),
	Maching				nvarchar(500),
	Brand				nvarchar(500),
	Model				nvarchar(500),
	SerialNo			nvarchar(500),
	Parameter			nvarchar(500),
	PurchaseDate		datetime,
	Supplier			nvarchar(500),
	ServiceDate			datetime
)

-- 人员信息
create table tb_People
(
	Position			nvarchar(500),
	Name				nvarchar(500),
	Sex					nvarchar(500),
	Phone				nvarchar(500),
	Email				nvarchar(500)
)

-- 设备基础信息
create table tb_Facility
(
	ID					int identity(1,1) not null,
	Maching				nvarchar(500),
	Brand				nvarchar(500),
	Model				nvarchar(500),
	Parameter			nvarchar(500)
)

-- 机器名称
create table tb_Machings
(
	ID		int identity(1,1) not null,
	Maching nvarchar(500)
)

-- 品牌
create table tb_Brands
(
	ID		int identity(1,1) not null,
	Brand	nvarchar(500)
)

-- 型号
create table tb_Models
(
	ID		int identity(1,1) not null,
	Model	nvarchar(500)
)

-- 配置参数
create table tb_Parameters
(
	ID		int identity(1,1) not null,
	Parameter	nvarchar(500)
)

-- 供应
create table tb_Suppliers
(
	ID		int identity(1,1) not null,
	Supplier	nvarchar(500)
)

-- 类型1
create table tb_TypeOnes
(
	ID			int identity(1,1) not null,
	TypeOne		nvarchar(500)
)

-- 类型2
create table tb_TypeTwos
(
	ID			int identity(1,1) not null,
	TypeTwo		nvarchar(500)
)

-- 类型3
create table tb_TypeThrees
(
	ID			int identity(1,1) not null,
	TypeThree	nvarchar(500)
)

-- 类型4
create table tb_TypeFours
(
	ID			int identity(1,1) not null,
	TypeFour	nvarchar(500)
)

-- 解决人/组织
create table tb_Solver
(
	ID			int identity(1,1) not null,
	Solver		nvarchar(500),
	SMTP		nvarchar(500),
	Email		nvarchar(500),
	EPassword	nvarchar(500),
	Note		nvarchar(500)
)

-- 快递公司
create table tb_ExpressCo
(
	ID			int identity(1,1) not null,
	ExpressCo	nvarchar(500)
)

-- 事件状态
create table tb_EventState
(
	StateID			int primary key,
	StateName		nvarchar(500),
	StateDay		int
)

-- 系统用户
create table tb_SystemUser
(
	UserName		nvarchar(500) primary key,
	[Password]		nvarchar(500),
	CreateTime		datetime,
	LastLogOnTime	datetime,
	UserState		int,
	UserIP			nvarchar(500)
)

-- 权限
create table tb_Permission
(
	UserName			nvarchar(500) references dbo.tb_SystemUser(UserName),
	[Admin]				int,
	[Index]				int,
	UpdateSolution		int,
	EventQuery			int,
	CreateEvent			int,
	ReportFormsEvent	int,
	AddStock			int,
	StockQuery			int,
	OutStockQuery		int,
	AllotStockQuery		int,
	AddStockQuery		int,
	AlterStore			int,
	EventTypes			int,
	FacilityManage		int,
	PeopleManage		int,
	SynthesisManage		int,
	EventState			int,
	InitialStores		int,
	InitialStocks		int,
	[ScrapStocks]		int
)

-- 上门类型
create table tb_SceneType
(
	TypeName				nvarchar(500) primary key,
	BaseToken				float,
	ComputingMethod			nvarchar(500)
)

-- 时段倍率
create table tb_MultiplyingPowerType
(
	TypeName				nvarchar(500) primary key,
	MultiplyingPower		float
)

-- 区域信息
create table tb_AreaInfo
(
	AreaName				nvarchar(500) primary key,
	AreaAliss				nvarchar(500),
	AreaManager				nvarchar(500),
	ManagerPhone			nvarchar(500),
	ManagerEmail			nvarchar(500)
)

-- 上门服务商
create table tb_SceneServiceProvider
(
	ServiceProvider			nvarchar(500) primary key,
	Phone					nvarchar(500),
	ServiceArea				nvarchar(500),
	RemainToken				float
)

-- Token统计
create table tb_Token
(
	ID						int identity(1,1) not null,
	EventNo					nvarchar(500),
	TimeStart				datetime,
	TimeEnd					datetime,
	SceneType				nvarchar(500),
	BaseToken				float,
	MultiplyingPower		float,
	ServiceProvider			nvarchar(500)
)

	

-- 存储过程
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***************************TypeOne***************************/
/**Add**/
Create Procedure [dbo].[AddTypeOne]
(
	@typeOne  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeOne from tb_TypeOnes where TypeOne='''+@typeOne+''') insert into tb_TypeOnes(TypeOne) values('''+@typeOne+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetTypeOne]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeOne from tb_TypeOnes order by TypeOne'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelTypeOne]
(
	@typeOne  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_TypeOnes where TypeOne ='''+@typeOne+''''
print @sql
EXEC(@sql)
Go
/***************************TypeOne***************************/

/***************************TypeTwo***************************/
/**Add**/
Create Procedure [dbo].[AddTypeTwo]
(
	@typeTwo  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeTwo from tb_TypeTwos where TypeTwo='''+@typeTwo+''') insert into tb_TypeTwos(TypeTwo) values('''+@typeTwo+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetTypeTwo]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeTwo from tb_TypeTwos order by TypeTwo'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelTypeTwo]
(
	@typeTwo  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_TypeTwos where TypeTwo ='''+@typeTwo+''''
print @sql
EXEC(@sql)
Go
/***************************TypeTwo***************************/

/***************************TypeThree***************************/
/**Add**/
Create Procedure [dbo].[AddTypeThree]
(
	@typeThree  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeThree from tb_TypeThrees where TypeThree='''+@typeThree+''') insert into tb_TypeThrees(TypeThree) values('''+@typeThree+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetTypeThree]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeThree from tb_TypeThrees order by TypeThree'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelTypeThree]
(
	@typeThree  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_TypeThrees where TypeThree ='''+@typeThree+''''
print @sql
EXEC(@sql)
Go
/***************************TypeThree***************************/

/***************************TypeFour***************************/
/**Add**/
Create Procedure [dbo].[AddTypeFour]
(
	@typeFour  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeFour from tb_TypeFours where TypeFour='''+@typeFour+''') insert into tb_TypeFours(TypeFour) values('''+@typeFour+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetTypeFour]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeFour from tb_TypeFours order by TypeFour'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelTypeFour]
(
	@typeFour  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_TypeFours where TypeFour ='''+@typeFour+''''
print @sql
EXEC(@sql)
Go
/***************************TypeFour***************************/

/***************************Solver***************************/
insert into tb_Solver(Solver,SMTP,Email,EPassword,Note) values('库存管理员',NULL,NULL,NULL,NULL)
Go
/**Add**/
Create Procedure [dbo].[AddSolver]
(
	@solver  nvarchar(500)
)
as
begin
if not exists(select Solver from tb_Solver where Solver=@solver) insert into tb_Solver(Solver,SMTP,Email,EPassword,Note) values(@solver,NULL,NULL,NULL,NULL)
end
Go
/**Get**/
Create Procedure [dbo].[GetAllSolver]

AS
begin
select Solver,SMTP,Email,EPassword,Note from tb_Solver order by Solver
end
Go
Create Procedure [dbo].[GetSolverByEventType]
(
	@typeCode	nvarchar(500)
)
AS
declare @email1		nvarchar(500)
declare @email2		nvarchar(500)
declare @solver1	nvarchar(500)
declare @solver2	nvarchar(500)
declare	@smtp		nvarchar(500)
declare	@ePassword	nvarchar(500)
declare @note		nvarchar(500)
declare @eventName	nvarchar(500)
begin
select top 1 @solver1=Solver, @email1=Email, @smtp=SMTP, @ePassword=EPassword from tb_Solver where SMTP<>'' and SMTP is not null and EPassword <> '' and EPassword is not null
select @solver2=EventLevel from tb_EventTypes where TypeCode=@typeCode
select @note=Note from tb_Solver where Solver=@solver2
select @email2=Email from tb_Solver where Solver=@note
select @eventName=TypeOne+'-'+TypeTwo+'-'+TypeThree+'-'+TypeFour from tb_EventTypes where TypeCode=@typeCode
select @email1,@smtp,@ePassword,@email2,@note,@solver2,@eventName from tb_Solver
end
Go
Create Procedure [dbo].[GetSolverChangeHandingBy]
(
	@handingBy	nvarchar(500),
	@typeCode	nvarchar(500)
)
AS
declare @email1		nvarchar(500)
declare @email2		nvarchar(500)
declare @solver1	nvarchar(500)
declare	@smtp		nvarchar(500)
declare	@ePassword	nvarchar(500)
declare @note		nvarchar(500)
declare @eventName	nvarchar(500)
begin
select top 1 @solver1=Solver, @email1=Email, @smtp=SMTP, @ePassword=EPassword from tb_Solver where SMTP<>'' and SMTP is not null and EPassword <> '' and EPassword is not null
select @note=Note from tb_Solver where Solver=@handingBy
select @email2=Email from tb_Solver where Solver=@note
select @eventName=TypeOne+'-'+TypeTwo+'-'+TypeThree+'-'+TypeFour from tb_EventTypes where TypeCode=@typeCode
select @email1,@smtp,@ePassword,@email2,@note,@eventName from tb_Solver
end
Go
Create Procedure [dbo].[GetSolver]

AS
begin
select Solver from tb_Solver where Solver<>'库存管理员' order by Solver 
end
Go

Create Procedure [dbo].[GetStockIn]
(
	@stockInSolver	nvarchar(500)
)
AS
declare @email1		nvarchar(500)
declare @email2		nvarchar(500)
declare @solver1	nvarchar(500)
declare	@smtp		nvarchar(500)
declare	@ePassword	nvarchar(500)
declare @note		nvarchar(500)

begin
select top 1 @solver1=Solver, @email1=Email, @smtp=SMTP, @ePassword=EPassword from tb_Solver where SMTP<>'' and SMTP is not null and EPassword <> '' and EPassword is not null
select @note=Note from tb_Solver where Solver=@stockInSolver
select @email2=Email from tb_Solver where Solver=@note
select @email1,@smtp,@ePassword,@email2,@note from tb_Solver
end
Go
/**Update**/
Create Procedure [dbo].[UpdateSolver]
(
	@solver		nvarchar(500),
	@smtp		nvarchar(500),
	@email		nvarchar(500),
	@epassword  nvarchar(500),
	@note		nvarchar(500)
)
AS
begin
Update tb_Solver set SMTP=@smtp, Email=@email, EPassword=@epassword ,Note=@note where Solver=@solver
end
Go
/**Del**/
Create Procedure [dbo].[DelSolver]
(
	@solver  nvarchar(500)
)
AS
begin	
delete from tb_Solver where Solver =@solver
end
Go
/***************************Solver***************************/

/***************************EventState***************************/
insert tb_EventState(StateID,StateName,StateDay) values(99,'处理中',0)
insert tb_EventState(StateID,StateName,StateDay) values(0,'已完成',0)
insert tb_EventState(StateID,StateName,StateDay) values(100,'完成开店',0)
insert tb_EventState(StateID,StateName,StateDay) values(200,'完成关店',0)
insert tb_EventState(StateID,StateName,StateDay) values(300,'完成装修',0)
insert tb_EventState(StateID,StateName,StateDay) values(999,'预开店',0)
insert tb_EventState(StateID,StateName,StateDay) values(998,'需装修',0)
insert tb_EventState(StateID,StateName,StateDay) values(997,'预关店',0)
insert tb_EventState(StateID,StateName,StateDay) values(900,'营业中',0)
Go
/**Add**/
Create Procedure [dbo].[AddEventState]
(
	@stateName		nvarchar(500),
	@stateDay		int,
	@stateType		nvarchar(500)
)
as
begin
declare @min int
if @stateType='1'
begin
	if (select COUNT(StateID) from tb_EventState where StateID>=101 and StateID<=199) >0
	begin
		select @min=MIN(StateID)-1 from tb_EventState where StateID>=101 and StateID<=199
	end
	else
	begin
		set @min=199
	end
insert into tb_EventState(StateID,StateName,StateDay) values(@min,@stateName,@stateDay)
end
if @stateType='2'
begin
	if (select COUNT(StateID) from tb_EventState where StateID>=201 and StateID<=299) >0
	begin
		select @min=MIN(StateID)-1 from tb_EventState where StateID>=201 and StateID<=299
	end
	else
	begin
		set @min=299
	end
insert into tb_EventState(StateID,StateName,StateDay) values(@min,@stateName,@stateDay)
end
if @stateType='3'
begin
	if (select COUNT(StateID) from tb_EventState where StateID>=301 and StateID<=399) >0
	begin
		select @min=MIN(StateID)-1 from tb_EventState where StateID>=301 and StateID<=399
	end
	else
	begin
		set @min=399
	end
insert into tb_EventState(StateID,StateName,StateDay) values(@min,@stateName,@stateDay)
end
end
Go
/**Get**/
Create Procedure [dbo].[GetEventState]
(
	@stateType		nvarchar(500)
)
AS
begin
if @stateType='1'
select row_number()over(order by StateID desc) as RowNum,StateID,StateName,StateDay from tb_EventState where StateID>=100 and StateID<=199 order by StateID desc
if @stateType='2'
select row_number()over(order by StateID desc) as RowNum,StateID,StateName,StateDay from tb_EventState where StateID>=200 and StateID<=299 order by StateID desc
if @stateType='3'
select row_number()over(order by StateID desc) as RowNum,StateID,StateName,StateDay from tb_EventState where StateID>=300 and StateID<=399 order by StateID desc
end
Go
Create Procedure [dbo].[GetEventStateByStateID]
(
	@stateType		nvarchar(500),
	@stateID		int
)
AS
begin
if @stateType='0'
select StateID,StateName,StateDay from tb_EventState where StateID>=0 and StateID<=@stateID order by StateID desc
if @stateType='1'
select StateID,StateName,StateDay from tb_EventState where StateID>=100 and StateID<=@stateID order by StateID desc
if @stateType='2'
select StateID,StateName,StateDay from tb_EventState where StateID>=200 and StateID<=@stateID order by StateID desc
if @stateType='3'
select StateID,StateName,StateDay from tb_EventState where StateID>=300 and StateID<=@stateID order by StateID desc
end
Go
Create Procedure [dbo].[GetMinEventState]
(
	@stateType		nvarchar(500)
)
AS
begin
if @stateType='1'
select min(StateID) from tb_EventState where StateID>=101 and StateID<=199
if @stateType='2'
select min(StateID) from tb_EventState where StateID>=201 and StateID<=299
if @stateType='3'
select min(StateID) from tb_EventState where StateID>=301 and StateID<=399
end
Go
/**Del**/
Create Procedure [dbo].[DelEventState]
(
	@stateType		nvarchar(500),
	@stateID		int
)
AS
begin
declare @count int
declare @n	   int
set @n=0
delete from tb_EventState where StateID=@stateID
if @stateType='1'
begin
if @stateID <> 199
begin
select @count=COUNT(StateID) from tb_EventState where StateID>=101 and StateID<=@stateID
while @n<@count
begin
update tb_EventState set StateID=@stateID-@n where StateID=@stateID-@n-1
set @n=@n+1
end
end
end
if @stateType='2'
begin
if @stateID <> 299
begin
select @count=COUNT(StateID) from tb_EventState where StateID>=201 and StateID<=@stateID
while @n<@count
begin
update tb_EventState set StateID=@stateID-@n where StateID=@stateID-@n-1
set @n=@n+1
end
end
end
if @stateType='3'
begin
if @stateID <> 399
begin
select @count=COUNT(StateID) from tb_EventState where StateID>=301 and StateID<=@stateID
while @n<@count
begin
update tb_EventState set StateID=@stateID-@n where StateID=@stateID-@n-1
set @n=@n+1
end
end
end
end
Go
/**Uptate**/
Create Procedure UpdateEventStateByStateID
(
	@stateID		int,
	@stateName		nvarchar(500),
	@stateDay		int
)
as
begin
	update tb_EventState set StateName=@stateName,StateDay=@stateDay where StateID = @stateID
end
go
/**ChangeUp**/
Create Procedure [dbo].[ChangeUpEventState]
(
	@stateID  int
)
AS
begin
if @stateID<>199 and @stateID<>299 and @stateID<>399
begin
update tb_EventState set StateID=9999 where StateID=@stateID+1
update tb_EventState set StateID=@stateID+1 where StateID=@stateID
update tb_EventState set StateID=@stateID where StateID=9999
end
end
Go
/**ChangeDown**/
Create Procedure [dbo].[ChangeDownEventState]
(
	@stateID  int
)
AS
begin
if @stateID<>101 and @stateID<>201 and @stateID<>301
begin
update tb_EventState set StateID=9999 where StateID=@stateID-1
update tb_EventState set StateID=@stateID-1 where StateID=@stateID
update tb_EventState set StateID=@stateID where StateID=9999
end
end
Go
/***************************EventState***************************/

/***************************ExpressCo***************************/
/**Add**/
Create Procedure [dbo].[AddExpressCo]
(
	@expressCo  nvarchar(500)
)
as
begin
if not exists(select ExpressCo from tb_ExpressCo where ExpressCo=@expressCo) insert into tb_ExpressCo(ExpressCo) values(@expressCo)
end
Go
/**Get**/
Create Procedure [dbo].[GetExpressCo]

AS
begin
select ExpressCo from tb_ExpressCo order by ExpressCo
end
Go
/**Del**/
Create Procedure [dbo].[DelExpressCo]
(
	@expressCo  nvarchar(500)
)
AS
begin	
delete from tb_ExpressCo where ExpressCo =@expressCo
end
Go
/***************************ExpressCo***************************/

/***************************EventTypes***************************/
/**Add**/

--固定值类型插入
go
declare @lv nvarchar(50)
select @lv=(select Solver from tb_Solver where SMTP is not null and SMTP <>'' and EPassword is not null and EPassword <>'')
if not exists(select TypeCode from tb_EventTypes where TypeCode='9999') insert into tb_EventTypes(TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel) values('9999','开店','开店','开店','开店',@lv)
if not exists(select TypeCode from tb_EventTypes where TypeCode='9000') insert into tb_EventTypes(TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel) values('9000','关店','关店','关店','关店',@lv)
if not exists(select TypeCode from tb_EventTypes where TypeCode='8888') insert into tb_EventTypes(TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel) values('8888','店铺装修','店铺装修','店铺装修','店铺装修',@lv)
if not exists(select TypeCode from tb_EventTypes where TypeCode='0000') insert into tb_EventTypes(TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel) values('0000','未处理','未处理','未处理','未处理',@lv)

go
Create Procedure [dbo].[AddEventTypes]
(
	@typeCode	nvarchar(500),
	@typeOne	nvarchar(500),
	@typeTwo	nvarchar(500),
	@typeThree  nvarchar(500),
	@typeFour	nvarchar(500),
	@eventLevel	nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeCode from tb_EventTypes where TypeCode='''+@typeCode+''') insert into tb_EventTypes(TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel) values('''+@typeCode+''','''+@typeOne+''','''+@typeTwo+''','''+@typeThree+''','''+@typeFour+''','''+@eventLevel+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetEventTypes]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeCode,TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel, row_number() over(partition by left(TypeCode,3) order by cast(right(TypeCode,len(TypeCode)-3) as float)) from tb_EventTypes where TypeCode not in(''9999'',''9000'',''8888'',''0000'')'
EXEC(@sql)
Go
Create Procedure [dbo].[GetEventTypesByTypeCode]
(
	@typeCode		nvarchar (50)
)

AS
begin	
select TypeOne,TypeTwo,TypeThree,TypeFour,EventLevel from tb_EventTypes where TypeCode= @typeCode
end
Go
Create Procedure [dbo].[GetEventLevelByTypeCode]
(
	@typeCode		nvarchar (50)
)

AS
declare @lv nvarchar(50)
begin
select @lv=(select Solver from tb_Solver where SMTP is not null and SMTP <>'' and EPassword is not null and EPassword <>'')
update tb_EventTypes set EventLevel=@lv where TypeCode in('9999','9000','8888','0000')	
select EventLevel from tb_EventTypes where TypeCode= @typeCode
end
Go
/**Del**/
Create Procedure [dbo].[DelEventTypes]
(
	@typeCode  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_EventTypes where TypeCode ='''+@typeCode+''''
print @sql
EXEC(@sql)
Go
/***************************EventTypes***************************/

/***************************People***************************/
/**Add**/
Create Procedure [dbo].[AddPeople]
(
	@position	nvarchar(500),
	@name		nvarchar(500),
	@sex		nvarchar(500),
	@phone		nvarchar(500),
	@email		nvarchar(500)
)
AS
begin
	if not exists(select Name from tb_People where Name=@name) insert into tb_People(Position,Name,Sex,Phone,Email) values(@position,@name,@sex,@phone,@email)
end
Go
/**Get**/
Create Procedure [dbo].[GetPeople]

AS
begin
select Name,Position,Sex,Phone,Email from tb_People order by Name
end
Go
Create Procedure [dbo].[GetNameByPosition]
(
	@position		nvarchar (50)
)

AS
begin	
select Name from tb_People where Position=@position order by Name
end
Go
/**Del**/
Create Procedure [dbo].[DelPeople]
(
	@name  nvarchar(500)
)
as
begin
delete from tb_People where Name =@name
end
Go
/***************************People***************************/

/***************************Solutions***************************/
/**Add**/
create proc dbo.sp_AddSolution
(
	@TypeCode nvarchar(500)=''
)
as
begin
	if not exists(select TypeCode from tb_Solutions where TypeCode=@TypeCode) insert into tb_Solutions(TypeCode) values(@TypeCode)
end
go
/**Get**/
create proc dbo.sp_GetSolutionByID
(
	@TypeCode nvarchar(500) = ''
)
as
begin
	declare @sql   nvarchar(4000)
	declare @where nvarchar(4000)
	
	set @TypeCode = RTRIM(LTRIM(@TypeCode))
	set @where = ' where 1=1 '
if @TypeCode<>'' and @TypeCode<>' '
	set @where = @where + ' and TypeCode=''' + @TypeCode + ''''
else
	set @where = ' where 1<>1 '

set @sql = 'select Content from dbo.tb_Solutions ' + @where + ''

if exists(select TypeCode from dbo.tb_Solutions where TypeCode = @TypeCode)
	exec sp_executesql @sql
else
	select '解决方案还没建立，请勿修改！！！'
end
go
/**Uptate**/
create proc dbo.sp_UpdateSolution
(
	@TypeCode nvarchar(500) = '',
	@Content text = ''
)
as
begin
	update dbo.tb_Solutions set Content = @Content where TypeCode = @TypeCode
end
go
/**Del**/
Create Procedure [dbo].[sp_DelSolution]
(
	@TypeCode  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Solutions where TypeCode ='''+@TypeCode+''''
print @sql
EXEC(@sql)
Go
/***************************Solutions***************************/

/***************************EventLogs***************************/
/**Add**/
Create Procedure [dbo].[AddEventLogs]
(
	@eventNo		nvarchar(500),
	@eventTime		nvarchar(500),
	@storeNo		nvarchar(500),
	@typeCode		nvarchar(500),
	@eventDescribe	nvarchar(500),
	@toResolvedTime	nvarchar(500),
	@eventState		nvarchar(500),
	@logBy			nvarchar(500)
)
AS
DECLARE	 @sql					nvarchar(3000)
DECLARE  @eventDateTime			datetime
DECLARE  @toResolvedDateTime	datetime
DECLARE	 @handingBy				nvarchar(500)
	SET @eventDateTime = cast(@eventTime as datetime)
	
	if(@typeCode='0000')
	begin
		select @handingBy=(select Solver from tb_Solver where SMTP is not null and SMTP <>'' and EPassword is not null and EPassword <>'')
	end
	else
	begin
		select @handingBy=EventLevel from tb_EventTypes where TypeCode=@typeCode
	end
IF @toResolvedTime <> ''
BEGIN
	SET @toResolvedDateTime = cast(@toResolvedTime as datetime)
END
ELSE
BEGIN
	SET @toResolvedDateTime = null
END
BEGIN
	if exists(select TypeCode from tb_EventTypes where TypeCode = @typeCode)
	begin
	if exists(select StoreNo from tb_Stores where StoreNo = @storeNo) 
	insert into tb_EventLogs(EventNo,EventTime,StoreNo,TypeCode,EventDescribe,ToResolvedTime,EventState,LogBy,HandingBy) values(@eventNo,@eventDateTime,@storeNo,@typeCode,@eventDescribe,@toResolvedDateTime,@eventState,@logBy,@handingBy)
	end
END
Go
/**Get**/
create Procedure [dbo].[GetEventLogsByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
begin	
select EventNo,EventTime,StoreNo,TypeCode,EventDescribe,convert(nvarchar(10),ToResolvedTime,111) ToResolvedTime,EventState,LogBy,ResolvedBy,ResolvedTime from tb_EventLogs where EventNo = @eventNo
end
Go
create Procedure [dbo].[GetPic]
(
	@eventNo		nvarchar(500),
	@picNo			nvarchar(500)
)
AS
begin
if @picNo='0'
select OutStockPic from tb_EventLogs where EventNo = @eventNo
if @picNo='1'
select ScenePic from tb_EventLogs where EventNo = @eventNo
end
Go
CREATE Procedure [dbo].[GetUsers]
AS
Begin
DECLARE	 @sql	 nvarchar (2000)	
SET @sql = 'select distinct LogBy from tb_EventLogs'
EXEC(@sql)
End
Go
create Procedure [dbo].[GetTopTenEventLogsByStoreNo]
(
	@storeNo		nvarchar(500)
)
AS
begin	
select top 10 EventNo,EventTime,StoreNo,TypeCode,EventDescribe,ResolvedBy,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy from tb_EventLogs left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID where StoreNo = @storeNo order by EventTime desc
end
Go
create Procedure [dbo].[GetEventLogsInNormalEvent]
(
	@eventTimeA		nvarchar(500),
	@eventTimeB		nvarchar(500),
	@storeNo		nvarchar(500),
	@typeCode		nvarchar(500),
	@eventState		nvarchar(500)
)
AS
DECLARE  @where   nvarchar(500)
DECLARE  @sql   nvarchar(1000)
	
	
	SET @where=' where 1=1 '
if @eventTimeA<>''
begin
	SET @where=@where+' and EventTime >= '''+@eventTimeA+''''
end
if @eventTimeB<>''
begin
	SET @where=@where+' and EventTime <= '''+@eventTimeB+''''
end
if @storeNo<>''
begin
	SET @where=@where+' and StoreNo= '''+@storeNo+''''
end
if @typeCode<>''
begin
	if @typeCode<>'9999' and @typeCode<>'9000' and @typeCode<>'8888'
	begin
		SET @where=@where+' and TypeCode= '''+@typeCode+''' '
	end
	if @typeCode='9999'
	begin
		SET @where=@where+' and TypeCode= ''9999'' '
	end
	if @typeCode='9000'
	begin	
		SET @where=@where+' and TypeCode= ''9000'' '
	end
	if @typeCode='8888'
	begin
		SET @where=@where+' and TypeCode= ''8888'' '	
	end
end
else
begin
	SET @where=@where+' and TypeCode<> ''9999'' and TypeCode<> ''9000'' and TypeCode<> ''8888'' '
end
if @eventState<>''
begin
	SET @where=@where+' and EventState= '''+@eventState+''''
end

set @sql='select EventNo,EventTime,StoreNo,TypeCode,EventDescribe,ResolvedBy,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy from tb_EventLogs left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID '+ @where +' order by EventTime desc'
EXEC(@sql)
Go
create Procedure [dbo].[GetHandingByByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
begin	
select HandingBy from tb_EventLogs where EventNo = @eventNo
end
Go
/**Update**/
Create Procedure UpdateEventState
(
	@eventState nvarchar(500),
	@eventNo	nvarchar(500)
)
as
begin
	update tb_EventLogs set EventState=@eventState where EventNo=@eventNo
end
go
Create Procedure UpdateUpLoadPic
(
	@eventNo		nvarchar(500),
	@outStockPic	nvarchar(500),
	@scenePic		nvarchar(500)
)
as
begin
if @outStockPic<>'' and @outStockPic<>'Clean'
begin
	update tb_EventLogs set OutStockPic=@outStockPic where EventNo=@eventNo
end
if @scenePic<>'' and @scenePic<>'Clean'
begin
	update tb_EventLogs set ScenePic=@scenePic where EventNo=@eventNo
end
if @outStockPic='Clean'
begin
	update tb_EventLogs set OutStockPic=NULL where EventNo=@eventNo
end
if @scenePic='Clean'
begin
	update tb_EventLogs set ScenePic=NULL where EventNo=@eventNo
end
end
go
Create Procedure UpdateEventStateByShutUpShop
(
	@storeNo		nvarchar(500),
	@stepDescribe	nvarchar(500),
	@stepTime		nvarchar(500),
	@stepState		nvarchar(500),
	@stepBy			nvarchar(500)
)
as
declare @count		int
declare @eventNo	nvarchar(500)
begin

	select @eventNo=(select top 1 EventNo from tb_EventLogs where StoreNo=@storeNo and EventState='99') 
	while @eventNo is not null
	begin
	update tb_EventLogs set EventState='0' where StoreNo=@storeNo and EventNo=@eventNo
	insert into tb_EventSteps(EventNo,StepDescribe,StepTime,StepState,StepBy) values(@eventNo,@stepDescribe,@stepTime,@stepState,@stepBy)
	select @eventNo=(select top 1 EventNo from tb_EventLogs where StoreNo=@storeNo and EventState='99') 
	end
	delete from tb_Stores where StoreNo=@storeNo
end
go
Create Procedure UpdateResolvedByAndTime
(
	@resolvedBy nvarchar(500),
	@resolvedTime nvarchar(500),
	@eventNo	nvarchar(500)
)
as
if @resolvedTime=''
begin
 set @resolvedTime = null
end
if @resolvedBy=''
begin
 set @resolvedBy = null
end
begin
	update tb_EventLogs set ResolvedBy=@resolvedBy,ResolvedTime=@resolvedTime where EventNo = @eventNo
end
go
Create Procedure UpdateTypeCode
(
	@typeCode	nvarchar(500),
	@eventNo	nvarchar(500)
)
as
begin
	if exists(select TypeCode from tb_EventTypes where TypeCode=@typeCode) update tb_EventLogs set TypeCode=@typeCode where EventNo = @eventNo
end
go
Create Procedure UpdateHandingBy
(
	@handingBy	nvarchar(500),
	@eventNo	nvarchar(500)
)
as
begin
if exists(select HandingBy from tb_EventLogs where EventNo=@eventNo and HandingBy is null)
begin
	update tb_EventLogs set HandingBy=@handingBy where EventNo=@eventNo
end
else
begin
	update tb_EventLogs set HandingBy=@handingBy where EventNo=@eventNo and HandingBy<>@handingBy
end
end
go
Create Procedure UpdateToResolvedTime
(
	@toResolvedTime nvarchar(500),
	@eventNo	nvarchar(500)
)
as
begin
	update tb_EventLogs set ToResolvedTime=@toResolvedTime where EventNo=@eventNo
end
go
/***************************EventLogs***************************/

/***************************EventSteps***************************/
/**Add**/
Create Procedure [dbo].[AddEventSteps]
(
	@eventNo		nvarchar(500),
	@stepDescribe	nvarchar(500),
	@stepTime		nvarchar(500),
	@stepState		nvarchar(500),
	@stepBy			nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)
DECLARE  @stepDateTime   datetime
SET @stepDateTime = cast(@stepTime as datetime)
BEGIN
	if exists(select EventNo from tb_EventLogs where EventNo=@eventNo) insert into tb_EventSteps(EventNo,StepDescribe,StepTime,StepState,StepBy) values(@eventNo,@stepDescribe,@stepDateTime,@stepState,@stepBy)
END
Go
/**Get**/
Create Procedure [dbo].[GetEventStepsByEventNo]
(		
	@eventNo		nvarchar(500)
)
AS
begin	
select ID,StepTime,StepDescribe,StepBy,case StepState when 0 then '已处理' else '未处理' end as StepState from tb_EventSteps where EventNo = @eventNo order by ID
end
Go
/**Uptate**/
Create Procedure UpdateEventSteps
(
	@id				int,
	@stepDescribe	nvarchar(500),
	@stepState		nvarchar(500)
)
as
begin
	update tb_EventSteps set StepDescribe=@stepDescribe, StepState=@stepState where ID = @id
end
go
/***************************EventSteps***************************/

/***************************Stores***************************/
/*Add*/
create proc dbo.AddStores
(
	@storeNo		nvarchar(500),
    @topStore		nvarchar(500),
    @storeType		nvarchar(500),
    @region			nvarchar(500),
    @rating			nvarchar(500),
    @storeName		nvarchar(500),
    @city			nvarchar(500),
    @storeAddress	nvarchar(500),
    @storeTel		nvarchar(500),
    @contractArea	nvarchar(500),
    @opeingDate		nvarchar(500),
    @storeState		nvarchar(500)
)
as
begin
if @opeingDate =''
	set @opeingDate=NULL
if not exists(select StoreNo from dbo.tb_Stores where StoreNo=@storeNo)
insert into dbo.tb_Stores 
select @storeNo, @topStore, @storeType, @region, @rating, @storeName, @city, @storeAddress,
	   @storeTel, @contractArea, @opeingDate, @storeState 

end
go
/**Get**/
Create Procedure [dbo].[GetRegionByStoreNo]
(
	@storeNo		nvarchar(500)
)

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select Region from tb_Stores where StoreNo='''+@storeNo+''''
print @sql
EXEC(@sql)
Go
Create Procedure [dbo].[GetStoresByStoreNo]
(
	@storeNo		nvarchar(500)
)
AS
begin	
select StoreNo,TopStore,StoreType,Region,Rating,StoreName,City,StoreAddress,StoreTel,ContractArea,OpeingDate,StateName as StoreState from tb_Stores left join tb_EventState on tb_Stores.StoreState=tb_EventState.StateID where StoreNo = @storeNo
end
Go
create proc dbo.GetStores
(
	@storeNo	nvarchar(500),
	@topStore	nvarchar(500),
	@storeType	nvarchar(500),
	@region		nvarchar(500),
	@rating		nvarchar(500),
	@opeingDateF nvarchar(500),
	@opeingDateT nvarchar(500),
	@storeState nvarchar(500)
)
as
begin
declare @sql nvarchar(4000)
declare @where nvarchar(4000)

set @storeNo = RTRIM(LTRIM(@storeNo))
set @topStore = RTRIM(LTRIM(@topStore))
set @storeType = RTRIM(LTRIM(@storeType))
set @region = RTRIM(LTRIM(@region))
set @rating = RTRIM(LTRIM(@rating))
set @storeState = RTRIM(LTRIM(@storeState))

if @opeingDateF<>''
	set @opeingDateF = CONVERT(nvarchar(10),@opeingDateF,127)
if @opeingDateT<>''
	set @opeingDateT = CONVERT(nvarchar(10),@opeingDateT,127)
	
set @where = ' where 1=1 '
if @storeNo<>''
	set @where = @where + ' and StoreNo ='''+@storeNo+''''
if @topStore<>''
	set @where = @where + ' and TopStore ='''+@topStore+''''
if @storeType<>''
	set @where = @where + ' and StoreType ='''+@storeType+''''
if @region<>''
	set @where = @where + ' and Region ='''+@region+''''
if @rating<>''
	set @where = @where + ' and Rating ='''+@rating+''''
if @opeingDateF<>''
	set @where = @where + ' and OpeingDate >='''+@opeingDateF+''''
if @opeingDateT<>''
	set @where = @where + ' and OpeingDate <='''+@opeingDateT+''''
if @storeState<>''
begin
	set @storeState = replace(@storeState,',',''',''')
	set @where = @where + ' and StoreState in ('''+@storeState+''')'
end
	
set @sql = ' select StoreNo,TopStore,StoreType,Region,Rating,StoreName,City,StoreAddress,StoreTel,ContractArea,
   convert(nvarchar(10),OpeingDate,127) OpeingDate,StateName as StoreState from dbo.tb_Stores left join tb_EventState on tb_Stores.StoreState=tb_EventState.StateID' + @where + ''
exec sp_executesql @sql
end
go

/**Del**/
Create Procedure [dbo].[DelStores]
(
	@storeNo  nvarchar(500)
)
AS
begin
delete from tb_Stores where StoreNo=@storeNo
end
Go
/**Update**/
create proc dbo.UpdateStores
(
	@storeNo		nvarchar(500),
    @topStore		nvarchar(500),
    @storeType		nvarchar(500),
    @region			nvarchar(500),
    @rating			nvarchar(500),
    @storeName		nvarchar(500),
    @city			nvarchar(500),
    @storeAddress	nvarchar(500),
    @storeTel		nvarchar(500),
    @contractArea	nvarchar(500),
    @opeingDate		nvarchar(500),
    @storeState		nvarchar(500)
)
as
begin
declare @sql nvarchar(2000)
declare @set nvarchar(3000)
declare @n   int
set @set=''
if ltrim(rtrim(@storeNo))<>''
 set @set=@set+' StoreNo='''+@storeNo+''', '
if ltrim(rtrim(@topStore))<>''
 set @set=@set+' TopStore='''+@topStore+''', '
if ltrim(rtrim(@storeType))<>''
 set @set=@set+' StoreType='''+@storeType+''', '
if ltrim(rtrim(@region))<>''
 set @set=@set+' Region='''+@region+''', '
if ltrim(rtrim(@rating))<>''
 set @set=@set+' Rating='''+@rating+''', '
if ltrim(rtrim(@storeName))<>''
 set @set=@set+' StoreName='''+@storeName+''', '
if ltrim(rtrim(@city))<>''
 set @set=@set+' City='''+@city+''', '
if ltrim(rtrim(@storeAddress))<>''
 set @set=@set+' StoreAddress='''+@storeAddress+''', '
if ltrim(rtrim(@storeTel))<>''
 set @set=@set+' StoreTel='''+@storeTel+''', '
if ltrim(rtrim(@contractArea))<>''
 set @set=@set+' ContractArea='''+@contractArea+''', '
if ltrim(rtrim(@opeingDate))<>''
 set @set=@set+' OpeingDate='''+@opeingDate+''', '
if ltrim(rtrim(@storeState))<>''
begin
 set @set=@set+' StoreState='''+@storeState+''' '
end
else
begin
	set @n = len(@set)
	set @set=substring(@set,1,@n-1)
end
if @storeState='997'
begin	
	set @sql = ' update dbo.tb_Stores set '+@set+' 
				 where StoreNo ='''+@storeNo+''' and StoreState<>'''+@storeState+''' and StoreState<>''999'' ' 
end
else
begin
	set @sql = ' update dbo.tb_Stores set '+@set+' 
				 where StoreNo ='''+@storeNo+''' ' 
end
          
exec sp_executesql @sql
end
go
/***************************Stores***************************/

/***************************Facility***************************/
/**Add**/
Create Procedure [dbo].[AddFacility]
(
	@maching	nvarchar(500),
	@brand		nvarchar(500),
	@model		nvarchar(500),
	@parameter	nvarchar(500)
	
)
AS
DECLARE	 @sql	 nvarchar (2000)
if	@maching <>'' and @brand <>'' and @model <>'' and @parameter <>''
begin
SET @sql = 'if not exists(select Maching from tb_Facility where Maching='''+@maching+''' and Brand='''+@brand+''' and Model='''+@model+''' and Parameter='''+@parameter+''') 
			insert into tb_Facility(Maching,Brand,Model,Parameter) values('''+@maching+''','''+@brand+''','''+@model+''','''+@parameter+''')'
print @sql
EXEC(@sql)
end
Go
/**Get**/
Create Procedure [dbo].[GetMachingFromFacility]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select distinct Maching from tb_Facility order by Maching'
print @sql
EXEC(@sql)
Go
Create Procedure [dbo].[GetBrandFromFacility]
(
	@maching	nvarchar(500)
	
)
AS
DECLARE	 @sql	 nvarchar(3000)
if	@maching <>''
begin
SET @sql = 'select distinct Brand from tb_Facility  where Maching='''+@maching+''' order by Brand'
print @sql
EXEC(@sql)
end
Go
Create Procedure [dbo].[GetModelFromFacility]
(
	@maching	nvarchar(500),
	@brand		nvarchar(500)
	
)
AS
DECLARE	 @sql	 nvarchar(3000)	
if	@maching <>'' and @brand <>''
begin
SET @sql = 'select distinct Model from tb_Facility  where Maching='''+@maching+''' and Brand='''+@brand+''' order by Model'
print @sql
EXEC(@sql)
end
Go
Create Procedure [dbo].[GetParameterFromFacility]
(
	@maching	nvarchar(500),
	@brand		nvarchar(500),
	@model		nvarchar(500)	
)
AS
DECLARE	 @sql	 nvarchar(3000)
if	@maching <>'' and @brand <>'' and @model <>''
begin
SET @sql = 'select distinct Parameter from tb_Facility  where Maching='''+@maching+''' and Brand='''+@brand+''' and Model='''+@model+''' order by Parameter'
print @sql
EXEC(@sql)
end
Go
/**Del**/
Create Procedure [dbo].[DelFacility]
(
	@maching	nvarchar(500),
	@brand		nvarchar(500),
	@model		nvarchar(500),
	@parameter	nvarchar(500)
	
)
AS
DECLARE	 @sql	 nvarchar (2000)
if	@maching <>'' and @brand <>'' and @model <>'' and @parameter <>''
begin
SET @sql = 'delete from tb_Facility where Maching='''+@maching+''' and Brand='''+@brand+''' and Model='''+@model+''' and Parameter='''+@parameter+''' '
print @sql
EXEC(@sql)
end
Go
/***************************Facility***************************/

/***************************Maching***************************/
/**Add**/
create Procedure [dbo].[AddMaching]
(
	@maching  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select maching from tb_Machings where maching='''+@maching+''') insert into tb_Machings(maching) values('''+@maching+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetMaching]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select maching from tb_Machings order by maching'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelMaching]
(
	@maching  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Machings where maching ='''+@maching+''''
print @sql
EXEC(@sql)
Go
/***************************Maching***************************/

/***************************Brand***************************/
/**Add**/
create Procedure [dbo].[AddBrand]
(
	@brand  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select brand from tb_Brands where brand='''+@brand+''') insert into tb_Brands(brand) values('''+@brand+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetBrand]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select brand from tb_Brands order by brand'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelBrand]
(
	@brand  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Brands where brand ='''+@brand+''''
print @sql
EXEC(@sql)
Go
/***************************Brand***************************/

/***************************Model***************************/
/**Add**/
create Procedure [dbo].[AddModel]
(
	@model  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select model from tb_Models where model='''+@model+''') insert into tb_Models(model) values('''+@model+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetModel]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select model from tb_Models order by model'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelModel]
(
	@model  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Models where model ='''+@model+''''
print @sql
EXEC(@sql)
Go
/***************************Model***************************/

/***************************Parameter***************************/
/**Add**/
create Procedure [dbo].[AddParameter]
(
	@parameter  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select parameter from tb_Parameters where parameter='''+@parameter+''') insert into tb_Parameters(parameter) values('''+@parameter+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetParameter]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select parameter from tb_Parameters order by parameter'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelParameter]
(
	@parameter  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Parameters where parameter ='''+@parameter+''''
print @sql
EXEC(@sql)
Go
/***************************Parameter***************************/

/***************************Supplier***************************/
/**Add**/
Create Procedure [dbo].[AddSupplier]
(
	@supplier nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select supplier from tb_Suppliers where supplier='''+@supplier+''') insert into tb_Suppliers(supplier) values('''+@supplier+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetSupplier]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select supplier from tb_Suppliers order by supplier'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelSupplier]
(
	@supplier  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_Suppliers where supplier ='''+@supplier+''''
print @sql
EXEC(@sql)
Go
/***************************Supplier***************************/

/***************************OutStockDemands***************************/
/**Add**/
Create Procedure [dbo].[AddOutStockDemands]
(
	@eventNo		nvarchar(500),
	@maching		nvarchar(500),
	@brand			nvarchar(500),
	@model			nvarchar(500),
	@parameter		nvarchar(500)
)
AS
BEGIN
 insert into tb_OutStockDemands(EventNo,Maching,Brand,Model,Parameter) values(@eventNo,@maching,@brand,@model,@parameter)
END
Go
/**Get**/
Create Procedure [dbo].[GetOutStockDemandsByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select  DemandNo,EventNo,Maching,Brand,Model,Parameter from tb_OutStockDemands where EventNo=@eventNo order by Maching
END
Go
Create Procedure [dbo].[GetNoMatchingByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select DemandNo,EventNo,Maching,Brand,Model,Parameter from tb_OutStockDemands where EventNo=@eventNo and DemandNo not in(select DemandNo from tb_Stocks where DemandNo is not null) order by Maching
END
Go
/**Del**/
Create Procedure [dbo].[DelOutStockDemands]
(
	@demandNo	int
)
AS
BEGIN
 delete from tb_OutStockDemands where DemandNo=@demandNo
 update tb_Stocks set EventNo=NULL,DemandNo=NULL where DemandNo=@demandNo
END
Go
/**Update**/
Create Procedure [dbo].[UptateOutStockDemands]
(
	@eventNo	nvarchar(500),
	@demandNo	int,
	@id			int
)
AS
BEGIN
 update tb_Stocks set EventNo=NULL,DemandNo=NULL where DemandNo=@demandNo
 update tb_Stocks set EventNo=@eventNo,DemandNo=@demandNo where ID=@id
END
Go

/***************************OutStockDemands***************************/

/***************************AddStocks***************************/
Create Procedure [dbo].[GetAddStocks]
(
	@warehouseNo			nvarchar(500),
	@maching				nvarchar(500),
	@brand					nvarchar(500),
	@model					nvarchar(500),
	@parameter				nvarchar(500),
	@supplier				nvarchar(500),
	@addStockDateA			nvarchar(500),
	@addStockDateB			nvarchar(500)
)
AS
begin
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '

if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @addStockDateA<>''
	set @where=@where+' and AddStockDate >= '''+@addStockDateA+''' '
if @addStockDateB<>''
	set @where=@where+' and AddStockDate <= '''+@addStockDateB+''' '


set @sql='select ID,WarehouseNo,Maching,Brand,Model,Parameter,SerialNo,EpcTags,SapNo,convert(varchar(20),PurchaseDate,111) as PurchaseDate,convert(varchar(20),GuaranteeTime,111) as GuaranteeTime,RepairsNo,Supplier,convert(varchar(20),AddStockDate,111) as AddStockDate from tb_AddStocks '+@where 
exec sp_executesql @sql
end
go
/***************************AddStocks***************************/

/***************************Stocks***************************/
/**Add**/
Create proc dbo.AddStocks
(

      @WarehouseStoreNo		nvarchar(500),
      @Maching				nvarchar(500),
      @Brand				nvarchar(500),
      @Model				nvarchar(500),
      @SerialNo				nvarchar(500),
      @Parameter			nvarchar(500),
      @EpcTags				nvarchar(500),
      @SapNo				nvarchar(500),
      @PurchaseDate			nvarchar(500),
      @GuaranteeTime		nvarchar(500),
      @RepairsNo			nvarchar(500),
      @Supplier				nvarchar(500),
      @AddStockDate			nvarchar(500),
      @OutStockDate			nvarchar(500),     
      @Operator				nvarchar(500),
      @StockType			nvarchar(500),
      @MachingState			nvarchar(500)
)
as
begin
if @AddStockDate=''
	set @AddStockDate=NULL
if @OutStockDate=''
	set @OutStockDate=NULL
--declare @sql nvarchar(4000)
--if not exists(select WarehouseStoreNo from dbo.tb_Stocks where WarehouseStoreNo = '''+@WarehouseStoreNo+''')
if not exists(select Maching from dbo.tb_Stocks where Maching = @Maching and SerialNo = @SerialNo)
insert tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
		values(@WarehouseStoreNo,@Maching,@Brand,@Model,@SerialNo,@Parameter,@EpcTags,@SapNo,@PurchaseDate,@GuaranteeTime,@RepairsNo,@Supplier,@AddStockDate,@OutStockDate,@Operator,@StockType,@MachingState)
--set @sql = ' if not exists(select Maching from dbo.tb_Stocks where Maching = '''+@Maching+''' and SerialNo = '''+@SerialNo+''')
--			insert into dbo.tb_Stocks
--			select null,null,'''+@WarehouseStoreNo+''','''+@Maching+''','''+@Brand+''',
--			 '''+@Model+''','''+@SerialNo+''','''+@Parameter+''','''+@EpcTags+''','''+@SapNo+''',
--			 '''+@PurchaseDate+''','''+@GuaranteeTime+''','''+@RepairsNo+''','''+@Supplier+''','''+@AddStockDate+''',
--			 '''+@Operator+''','''+@StockType+''','''+@MachingState+''' '

--exec sp_executesql @sql	
end
go
CREATE proc dbo.AddStocksCommitHistory
(
      @WarehouseStoreNo		nvarchar(500),
      @Maching				nvarchar(500),
      @Brand				nvarchar(500),
      @Model				nvarchar(500),
      @SerialNo				nvarchar(500),
      @Parameter			nvarchar(500),
      @EpcTags				nvarchar(500),
      @SapNo				nvarchar(500),
      @PurchaseDate			nvarchar(500),
      @GuaranteeTime		nvarchar(500),
      @RepairsNo			nvarchar(500),
      @Supplier				nvarchar(500),
      @AddStockDate			nvarchar(500),
      @Operator				nvarchar(500),
      @StockType			nvarchar(500),
      @MachingState			nvarchar(500)
      
)
as
begin
--declare @sql nvarchar(4000)

if not exists(select Maching from dbo.tb_Stocks where Maching = @Maching and SerialNo = @SerialNo)
begin
insert tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,Operator,StockType,MachingState)
		values(@WarehouseStoreNo,@Maching,@Brand,@Model,@SerialNo,@Parameter,@EpcTags,@SapNo,@PurchaseDate,@GuaranteeTime,@RepairsNo,@Supplier,@AddStockDate,@Operator,@StockType,@MachingState)
--set @sql = ' if not exists(select Maching from dbo.tb_Stocks where Maching = '''+@Maching+''' and SerialNo = '''+@SerialNo+''')
--			insert into dbo.tb_Stocks
--			select null,null,'''+@WarehouseStoreNo+''','''+@Maching+''','''+@Brand+''',
--			 '''+@Model+''','''+@SerialNo+''','''+@Parameter+''','''+@EpcTags+''','''+@SapNo+''',
--			 '''+@PurchaseDate+''','''+@GuaranteeTime+''','''+@RepairsNo+''','''+@Supplier+''','''+@AddStockDate+''',
--			 '''+@Operator+''','''+@StockType+''','''+@MachingState+''' '
			 
--exec sp_executesql @sql	

insert tb_AddStocks(WarehouseNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,Operator)
values(@WarehouseStoreNo,@Maching,@Brand,@Model,@SerialNo,@Parameter,@EpcTags,@SapNo,@PurchaseDate,@GuaranteeTime,@RepairsNo,@Supplier,@AddStockDate,@Operator)
end
end
go
/**Get**/
Create Procedure [dbo].[GetStocks]
(
	@eventNo				nvarchar(500),
	@warehouseStoreNo		nvarchar(500),
	@maching				nvarchar(500),
	@brand					nvarchar(500),
	@model					nvarchar(500),
	@parameter				nvarchar(500),
	@supplier				nvarchar(500),
	@addStockDateA			nvarchar(500),
	@addStockDateB			nvarchar(500),
	@outStockDateA			nvarchar(500),
	@outStockDateB			nvarchar(500),
	@stockType				nvarchar(500),
	@machingState			nvarchar(500)
)
AS
begin
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @eventNo<>''
begin
 if @eventNo='0'
	begin
		set @where=@where+' and tb_Stocks.EventNo is null '
	end
	else
	begin
		set @where=@where+' and tb_Stocks.EventNo = '''+@eventNo+''' '
	end
end
if @warehouseStoreNo<>''
	set @where=@where+' and tb_Stocks.WarehouseStoreNo = '''+@warehouseStoreNo+''' '
if @maching<>''
	set @where=@where+' and tb_Stocks.Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and tb_Stocks.Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and tb_Stocks.Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and tb_Stocks.Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and tb_Stocks.Supplier = '''+@supplier+''' '
if @addStockDateA<>''
	set @where=@where+' and tb_Stocks.AddStockDate >= '''+@addStockDateA+''' '
if @addStockDateB<>''
	set @where=@where+' and tb_Stocks.AddStockDate <= '''+@addStockDateB+''' '
if @outStockDateA<>''
	set @where=@where+' and tb_Stocks.OutStockDate >= '''+@outStockDateA+''' '
if @outStockDateB<>''
	set @where=@where+' and tb_Stocks.OutStockDate <= '''+@outStockDateB+''' '
if @stockType<>''
	set @where=@where+' and tb_Stocks.StockType = '''+@stockType+''' '
if @machingState<>''
	set @where=@where+' and tb_Stocks.MachingState = '''+@machingState+''' '
set @sql='SELECT * FROM (
select tb_Stocks.ID,tb_Stocks.EventNo,tb_Stocks.DemandNo,tb_Stocks.WarehouseStoreNo,tb_Stocks.Maching,tb_Stocks.Brand,tb_Stocks.Model,
tb_Stocks.Parameter,tb_Stocks.SerialNo,tb_Stocks.EpcTags,tb_Stocks.SapNo,convert(varchar(20),tb_Stocks.PurchaseDate,111) as PurchaseDate,
convert(varchar(20),tb_Stocks.GuaranteeTime,111) as GuaranteeTime,tb_Stocks.RepairsNo,tb_Stocks.Supplier,
convert(varchar(20),tb_Stocks.AddStockDate,111) as AddStockDate,convert(varchar(20),tb_Stocks.OutStockDate,111) as OutStockDate,convert(varchar(20),tb_OutStocks.OutStockDate,111) as OutStockDateT,
tb_OutStocks.EventNo as EventNoT, ROW_NUMBER() OVER(PARTITION BY tb_Stocks.SerialNo ORDER BY tb_OutStocks.OutStockDate DESC) N
from tb_Stocks left join tb_OutStocks on tb_Stocks.SerialNo=tb_OutStocks.SerialNo 
'+@where+'
) A WHERE A.N = 1 ' 
exec sp_executesql @sql
end
go
Create Procedure [dbo].[GetStocksInID]
(
	@idTemp nvarchar(100)
)
AS
declare @temp nvarchar(500)
declare @sql nvarchar(1000)
declare @n int

begin
begin
	set @n = len(@idTemp)
	set @temp=substring(@idTemp,1,@n-1)
end
set @sql='select ID,DemandNo,WarehouseStoreNo,Maching,Brand,Model,Parameter,SerialNo,EpcTags,SapNo,convert(varchar(20),PurchaseDate,111) as PurchaseDate,convert(varchar(20),GuaranteeTime,111) as GuaranteeTime,RepairsNo,Supplier,convert(varchar(20),AddStockDate,111) as AddStockDate,convert(varchar(20),OutStockDate,111) as OutStockDate from tb_Stocks where ID in ('+@idTemp+')' 
print(@sql)
exec(@sql)
end
go
Create Procedure [dbo].[DelStocksToScrapInID]
(
	@idTemp				nvarchar(100),
	@addScrapStockDate	nvarchar(500),
	@operator			nvarchar(500),
	@scrapReason		nvarchar(500)
)
AS
declare @temp nvarchar(500)
declare @sql nvarchar(1000)
declare @n int

begin
begin
	--set @n = len(@idTemp)
	--if @n>1
	--begin
	--	set @temp=substring(@idTemp,1,@n-1)
	--end
	--else
	--begin
		set @temp=@idTemp
	--end
end
set @sql='insert into tb_ScrapStocks(WarehouseNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddScrapStockDate,Operator,LastWarehouseNo,ScrapReason)
 select WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,'''+@addScrapStockDate+''','''+@operator+''',WarehouseStoreNo,'''+@scrapReason+'''
 from tb_Stocks where ID in ('+@temp+') 
 delete from tb_Stocks where ID in ('+@temp+')'
print(@sql)
exec(@sql)
end
go

/**Mutual**/
Create Procedure [dbo].[UpdateStocksMutualOutStockDemands]
(
	@eventNo	nvarchar(500),
	@temp		nvarchar(500)
)
AS
begin
select a.DemandNo into #Temp from (select DemandNo from tb_OutStockDemands where EventNo=@eventNo and DemandNo not in(select DemandNo from tb_Stocks where DemandNo is not null))a
declare @demandNo int
declare @num int
declare @count int
set @num=0
set @count = (select count(DemandNo) from #Temp)
while @num<@count
begin
set @num=@num+1
;with rownum_cte as
(
	select  DemandNo,row_number()over(order by DemandNo)as Rownum from #Temp
)
select @demandNo=DemandNo from rownum_cte where Rownum=@num

if @temp='0'
begin
with upd_cte as
(
	select top 1 a.EventNo,a.DemandNo
	from tb_Stocks a,tb_OutStockDemands b 
	where a.Maching=b.Maching and a.Brand=b.Brand and a.Model=b.Model and a.Parameter=b.Parameter and b.DemandNo=@demandNo and a.DemandNo is null and a.StockType='0' and MachingState=0 
	order by a.PurchaseDate
)
update upd_cte set EventNo=@eventNo,DemandNo=@demandNo
end
else
begin
with upd_cte as
(
	select top 1 a.EventNo,a.DemandNo
	from tb_Stocks a,tb_OutStockDemands b 
	where a.Maching=b.Maching and a.Brand=b.Brand and a.Model=b.Model and a.Parameter=b.Parameter and b.DemandNo=@demandNo and a.DemandNo is null and a.StockType='0'  
	order by a.PurchaseDate
)
update upd_cte set EventNo=@eventNo,DemandNo=@demandNo
end
end
drop table #Temp
end
Go
Create Procedure [dbo].[UpdateStocksMutualFacilityAllot]
(
	@eventNo	nvarchar(500),
	@rowID		nvarchar(500)
)
as
declare @sql	nvarchar(1000)
begin
	set @sql='update tb_Stocks set EventNo='''+@eventNo+''' where ID in('+@rowID+')'
end
exec sp_executesql @sql
go
/**Del**/
Create Procedure [dbo].[DelStocksMutualFacilityAllot]
(
	@eventNo	nvarchar(500)
)
as
begin
	update tb_Stocks set EventNo=null where EventNo=@eventNo and StockType='1'
end
go
Create Procedure [dbo].[DelStocksBack]
(
	@eventNo	nvarchar(500)
)
as
begin
	update tb_Stocks set EventNo=null,DemandNo=null where EventNo=@eventNo
end
go
Create Procedure [dbo].[DelStocks]
(
	@id	nvarchar(500)
)
as
begin
	delete tb_Stocks where ID=@id
end
go
/***************************Stocks***************************/

/***************************Express***************************/
/**Add**/
Create Procedure [dbo].[AddExpress]
(
	@eventNo		nvarchar(500),
	@expressCo		nvarchar(500),
	@expressNo		nvarchar(500),
	@getOrSend		int,
	@expressState	int
)
AS
BEGIN
 insert into tb_Express(EventNo,ExpressCo,ExpressNo,GetOrSend,ExpressState) values(@eventNo,@expressCo,@expressNo,@getOrSend,@expressState)
END
Go
/**Get**/
Create Procedure [dbo].[GetExpressByEventNo]
(
	@eventNo		nvarchar(500),
	@getOrSend		int
)
AS
BEGIN
 select ID,ExpressCo,ExpressNo,ExpressState from tb_Express where EventNo=@eventNo and GetOrSend=@getOrSend order by ID
END
Go
/**Uptate**/
Create Procedure UpdateExpressState
(
	@id int,
	@expressState nvarchar(500)
)
as
begin
	update tb_Express set ExpressState=@expressState where ID = @id
end
go
/***************************Express***************************/

/***************************OutStocks***************************/
/**Add**/
CREATE Procedure [dbo].[AddAllOutStocksFromStocks]
(
	@eventNo		nvarchar(500),
	@storeNo		nvarchar(500),
	@outStockDate	nvarchar(500),
	@operator		nvarchar(500),
	@outStocksState	nvarchar(500)
)
AS
BEGIN
--declare		@num		int
--declare		@count	int
--set @count = (select count(EventNo) from tb_Stocks where EventNo=@eventNo)
--set @num=0
--while @num<@count
--begin
-- set @num=@num+1
 insert into tb_OutStocks(EventNo,WarehouseNo,StoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,OutStockDate,Operator,OutStocksState) 
 select EventNo,WarehouseStoreNo,@storeNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,@outStockDate,@operator,@outStocksState  
 from tb_Stocks where EventNo=@eventNo and StockType='0'
--end
 update tb_Stocks set EventNo=NULL,DemandNo=NULL,WarehouseStoreNo=@storeNo,StockType='1',OutStockDate=@outStockDate where EventNo=@eventNo
END
Go
Create Procedure [dbo].[AddOutStocksFromStocks]
(
	@id				nvarchar(500),
	@storeNo		nvarchar(500),
	@outStockDate	nvarchar(500),
	@operator		nvarchar(500),
	@outStocksState	nvarchar(500),
	@scrapReason	nvarchar(500)
)
AS
BEGIN
 insert into tb_OutStocks(EventNo,WarehouseNo,StoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,OutStockDate,Operator,OutStocksState) 
 select EventNo,WarehouseStoreNo,@storeNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,@outStockDate,@operator,@outStocksState 
 from tb_Stocks where ID=@id 
 insert into tb_ScrapStocks(WarehouseNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddScrapStockDate,Operator,LastWarehouseNo,ScrapReason)
 select WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,@outStockDate,@operator,WarehouseStoreNo,@scrapReason
 from tb_Stocks where ID=@id 
 delete from tb_Stocks where ID=@id
END
Go
/**Get**/
Create Procedure [dbo].[GetOutStocks]
(
	@eventNo		nvarchar(500)
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @eventNo<>''
begin
	set @where=@where+' and EventNo = '''+@eventNo+''' order by Maching '
end
else
begin
	set @where=@where+' order by OutStockDate desc '
end
set @sql = 'select EventNo,WarehouseNo,StoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,convert(varchar(20),PurchaseDate,111) as PurchaseDate,convert(varchar(20),GuaranteeTime,111) as GuaranteeTime,RepairsNo,Supplier,convert(varchar(20),OutStockDate,111) as OutStockDate,Operator,OutStocksState 
 from tb_OutStocks' + @where
exec sp_executesql @sql
Go
Create Procedure [dbo].[GetCountOutStocksState]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select COUNT(OutStocksState) from tb_OutStocks where EventNo=@eventNo and OutStocksState='1'
END
Go
/***************************OutStocks***************************/

/***************************AllotStocks***************************/
/**Add**/
Create Procedure [dbo].[AddAllAllotStocksFromStocks]
(
	@eventNo				nvarchar(500),
	@warehouseStoreNoB		nvarchar(500),
	@allotStockDate			nvarchar(500),
	@operator				nvarchar(500),
	@allotStockState		nvarchar(500)
)
AS
BEGIN
--declare		@num		int
--declare		@count	int
--set @count = (select count(EventNo) from tb_Stocks where EventNo=@eventNo)
--set @num=0
--while @num<@count
--begin
-- set @num=@num+1
 insert into tb_AllotStocks(EventNo,WarehouseStoreNoA,WarehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,AllotStockDate,Operator,AllotStockState) 
 select EventNo,WarehouseStoreNo,@warehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,@allotStockDate,@operator,@allotStockState   
 from tb_Stocks where EventNo=@eventNo and StockType='1'
--end
 update tb_Stocks set EventNo=NULL,WarehouseStoreNo=@warehouseStoreNoB,StockType='0',MachingState='1' where EventNo=@eventNo
END
Go
Create Procedure [dbo].[AddAllotStocksFromStocks]
(
	@id						nvarchar(500),
	@warehouseStoreNoB		nvarchar(500),
	@allotStockDate			nvarchar(500),
	@operator				nvarchar(500),
	@allotStockState		nvarchar(500),
	@scrapReason			nvarchar(500)
)
AS
BEGIN
 insert into tb_AllotStocks(EventNo,WarehouseStoreNoA,WarehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,AllotStockDate,Operator,AllotStockState) 
 select EventNo,WarehouseStoreNo,@warehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,@allotStockDate,@operator,@allotStockState   
 from tb_Stocks where ID=@id 
 insert into tb_ScrapStocks(WarehouseNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddScrapStockDate,Operator,LastWarehouseNo,ScrapReason)
 select @warehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,@allotStockDate,@operator,WarehouseStoreNo,@scrapReason
 from tb_Stocks where ID=@id  
 delete from tb_Stocks where ID=@id
END
Go
/**Get**/
Create Procedure [dbo].[GetAllotStocks]
(
	@eventNo		nvarchar(500)
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @eventNo<>''
begin
	set @where=@where+' and EventNo = '''+@eventNo+''' order by Maching '
end
else
begin
	set @where=@where+' order by AllotStockDate desc '
end
set @sql = 'select EventNo,WarehouseStoreNoA,WarehouseStoreNoB,Maching,Brand,Model,SerialNo,Parameter,convert(varchar(20),AllotStockDate,111) as AllotStockDate,Operator,AllotStockState 
 from tb_AllotStocks' + @where
exec sp_executesql @sql
Go
Create Procedure [dbo].[GetCountAllotStocksState]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select COUNT(AllotStockState) from tb_AllotStocks where EventNo=@eventNo and AllotStockState='1'
END
Go
/***************************AllotStocks***************************/

/***************************AppointEngineers***************************/	
/**Add**/
create Procedure [dbo].[AddAppointEngineers]
(
	@eventNo		nvarchar(500),
	@name			nvarchar(500),
	@appointState	nvarchar(500)
	
)
AS
BEGIN
 declare @phonevalue	nvarchar(500)
 declare @email			nvarchar(500)
 select @phonevalue=Phone,@email=Email from tb_People where Name=@name
 insert into tb_AppointEngineers(EventNo,Name,Phone,Email,SceneTime,AppointState) values(@eventNo,@name,@phonevalue,@email,NULL,@appointState)
END
Go
/**Get**/
Create Procedure [dbo].[GetAppointEngineersByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select ID,Name,Phone,Email,SceneTime,AppointState from tb_AppointEngineers where EventNo=@eventNo order by ID
END
Go
Create Procedure [dbo].[GetEmailFromEngineers]
(
	@eventNo	nvarchar(500)
)
AS
declare @email1		nvarchar(500)
declare @email2		nvarchar(500)
declare @solver1	nvarchar(500)
declare	@smtp		nvarchar(500)
declare	@ePassword	nvarchar(500)
declare @name		nvarchar(500)
declare @typeCode	nvarchar(500)
declare @eventName	nvarchar(500)
declare @sceneTime	nvarchar(500)
begin
select top 1 @solver1=Solver, @email1=Email, @smtp=SMTP, @ePassword=EPassword from tb_Solver where SMTP<>'' and SMTP is not null and EPassword <> '' and EPassword is not null
select top 1 @name=Name,@email2=Email,@sceneTime=convert(varchar(20),SceneTime,120) from tb_AppointEngineers where AppointState='2' and EventNo=@eventNo order by ID desc
select @typeCode=TypeCode from tb_EventLogs where EventNo=@eventNo
select @eventName=TypeOne+'-'+TypeTwo+'-'+TypeThree+'-'+TypeFour from tb_EventTypes where TypeCode=@typeCode
select @email1,@smtp,@ePassword,@name,@email2,@eventName,@sceneTime,@typeCode from tb_AppointEngineers
end
Go
/**Uptate**/
Create Procedure UpdateAppointState
(
	@id int,
	@appointState	nvarchar(500),
	@sceneTime		nvarchar(500)
)
as
begin
if @sceneTime=''
begin
set @sceneTime=NULL
end
	update tb_AppointEngineers set AppointState=@appointState,SceneTime=@sceneTime where ID = @id
end
go
/***************************AppointEngineers***************************/

/***************************SceneState***************************/
/**Add**/
Create Procedure [dbo].[AddSceneState]
(
	@eventNo		nvarchar(500),
	@sceneState		nvarchar(500)
)
AS
BEGIN
 insert into tb_SceneState(EventNo,SceneState) values(@eventNo,@sceneState)
END
Go
/**Get**/
Create Procedure [dbo].[GetSceneStateByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select SceneState from tb_SceneState where EventNo=@eventNo
END
Go
/**Uptate**/
Create Procedure UpdateSceneState
(
	@eventNo		nvarchar(500),
	@sceneState		nvarchar(500)
)
as
begin
	update tb_SceneState set SceneState=@sceneState where EventNo = @eventNo
end
go
/***************************AppointEngineers***************************/

/***************************HistoryService***************************/
/**Add**/
Create Procedure [dbo].[AddHistoryServiceFromStocks]
(
	@eventNo				nvarchar(500),
	@serviceDate			nvarchar(500)
)
AS
BEGIN
--declare		@num		int
--declare		@count		int
--set @count = (select count(EventNo) from tb_Stocks where EventNo=@eventNo)
--set @num=0
--while @num<@count
--begin
-- set @num=@num+1
 insert into tb_HistoryService(EventNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,Supplier,ServiceDate) 
 select EventNo,Maching,Brand,Model,SerialNo,Parameter,PurchaseDate,Supplier,@serviceDate from tb_Stocks where EventNo=@eventNo
--end
 update tb_Stocks set EventNo=NULL where EventNo=@eventNo
END
Go
/**Get**/
Create Procedure [dbo].[GetHistoryServiceByEventNo]
(
	@eventNo		nvarchar(500)
)
AS
BEGIN
 select EventNo,Maching,Brand,Model,SerialNo,Parameter,convert(varchar(20),PurchaseDate,111)as PurchaseDate,Supplier,convert(varchar(20),ServiceDate,111)as ServiceDate from tb_HistoryService where EventNo=@eventNo
END
Go
/***************************HistoryService***************************/

/***************************Paging***************************/
Create PROCEDURE [dbo].[GetPageOfRecords]
  @pageSize int = 3,           --分页大小
  @currentPage int = 2 ,            --第几页
  @columns nvarchar(4000) = '', --需要得到的字段 
  @tableName nvarchar(4000) = '',      --需要查询的表    
  @condition nvarchar(4000) = '',--查询条件, 不用加where关键字
  @ascColumn nvarchar(4000) = '', --排序的字段名 (即 order by column asc/desc)
  @bitOrderType bit = 0,        --排序的类型 (0为升序,1为降序)
  @pkColumn nvarchar(500) = ''    --主键名称

AS
BEGIN                                                                                   
DECLARE @strTemp varchar(300)
DECLARE @strSql varchar(5000)                            
DECLARE @strOrderType varchar(1000)              

IF @bitOrderType = 1 
  BEGIN
    SET @strOrderType = ' ORDER BY '+@ascColumn+' DESC'
    SET @strTemp = '<(SELECT min'
  END
ELSE    
  BEGIN
    SET @strOrderType = ' ORDER BY '+@ascColumn+' ASC'
    SET @strTemp = '>(SELECT max'
  END

IF @currentPage = 1
  BEGIN
    IF @condition <> ''
      SET @strSql = 'SELECT TOP '+STR(@pageSize)+' '+@columns+' FROM '+@tableName+' WHERE '+@condition+@strOrderType
    ELSE
      SET @strSql = 'SELECT TOP '+STR(@pageSize)+' '+@columns+' FROM '+@tableName+@strOrderType
  END
ELSE        
  BEGIN
    IF @condition <>''
      SET @strSql = 'SELECT TOP '+STR(@pageSize)+' '+@columns+' FROM '+@tableName+ ' WHERE '+@condition+' AND '+@pkColumn+@strTemp+'('+@pkColumn+')'+' FROM (SELECT TOP '+STR((@currentPage-1)*@pageSize)+
      ' '+@pkColumn+' FROM '+@tableName+' where '+@condition+@strOrderType+') AS TabTemp)'+@strOrderType
    ELSE
      SET @strSql = 'SELECT TOP '+STR(@pageSize)+' '+@columns+' FROM '+@tableName+
      ' WHERE '+@pkColumn+@strTemp+'('+@pkColumn+')'+' FROM (SELECT TOP '+STR((@currentPage-1)*@pageSize)+' '+@pkColumn+
      ' FROM '+@tableName+@strOrderType+') AS TabTemp)'+@strOrderType
  END

print @strSql
EXEC (@strSql)
END  
Go
Create Procedure [dbo].[GetAllotStocksPaged]
(
	@eventNo				nvarchar(500)='',
	@storeNoA				nvarchar(500)='',
	@storeNoB				nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',
	@serialNo				nvarchar(500)='',	
	@parameter				nvarchar(500)='',	
	@allotStockDateA		nvarchar(500)='',
	@allotStockDateB		nvarchar(500)='',
	@operator				nvarchar(500)='',
	@allotStockState		nvarchar(500)='',
	@pageSize				int = 3,
	@pageIndex				int = 2
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' 1=1 '
if @eventNo<>''
	set @where=@where+' and EventNo = '''+@eventNo+''' '
if @storeNoA<>''
	set @where=@where+' and WarehouseStoreNoA = '''+@storeNoA+''' '
if @storeNoB<>''
	set @where=@where+' and WarehouseStoreNoB = '''+@storeNoB+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @serialNo<>''
	set @where=@where+' and SerialNo =	'''+@serialNo+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @allotStockDateA<>''
	set @where=@where+' and AllotStockDate >= '''+@allotStockDateA+''' '
if @allotStockDateB<>''
	set @where=@where+' and AllotStockDate <= '''+@allotStockDateB+''' '
if @operator<>''
	set @where=@where+' and Operator =	'''+@operator+''' '
if @allotStockState<>''
	set @where=@where+' and AllotStockState = '''+@allotStockState+''' '	

	
set @sql = ' ID,EventNo
      ,WarehouseStoreNoA
      ,WarehouseStoreNoB
      ,Maching
      ,Brand
      ,Model
      ,SerialNo
      ,Parameter
      ,convert(varchar(20),AllotStockDate,111) AllotStockDate
      ,Operator
      ,case AllotStockState when 0 then ''正常'' else ''异常'' end as AllotStockState'
      
exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_AllotStocks', @where, 'ID', 1, 'ID'
Go
Create Procedure [dbo].[GetAllotStocksTotal]
(
	@eventNo				nvarchar(500)='',
	@storeNoA				nvarchar(500)='',
	@storeNoB				nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',
	@serialNo				nvarchar(500)='',	
	@parameter				nvarchar(500)='',	
	@allotStockDateA		nvarchar(500)='',
	@allotStockDateB		nvarchar(500)='',
	@operator				nvarchar(500)='',
	@allotStockState		nvarchar(500)=''
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @eventNo<>''
	set @where=@where+' and EventNo = '''+@eventNo+''' '
if @storeNoA<>''
	set @where=@where+' and WarehouseStoreNoA = '''+@storeNoA+''' '
if @storeNoB<>''
	set @where=@where+' and WarehouseStoreNoB = '''+@storeNoB+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @serialNo<>''
	set @where=@where+' and SerialNo =	'''+@serialNo+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @allotStockDateA<>''
	set @where=@where+' and AllotStockDate >= '''+@allotStockDateA+''' '
if @allotStockDateB<>''
	set @where=@where+' and AllotStockDate <= '''+@allotStockDateB+''' '
if @operator<>''
	set @where=@where+' and Operator =	'''+@operator+''' '
if @allotStockState<>''
	set @where=@where+' and AllotStockState = '''+@allotStockState+''' '	

	
set @sql = 'select ID,EventNo
      ,WarehouseStoreNoA
      ,WarehouseStoreNoB
      ,Maching
      ,Brand
      ,Model
      ,SerialNo
      ,Parameter
      ,convert(varchar(20),AllotStockDate,111) AllotStockDate
      ,Operator
      ,case AllotStockState when 0 then ''正常'' else ''异常'' end as AllotStockState
 from tb_AllotStocks' + @where
exec sp_executesql @sql
Go
Create Procedure [dbo].[GetStocksPaged]
(	
	@warehouseStoreNo		nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@addStockDateA			nvarchar(500)='',
	@addStockDateB			nvarchar(500)='',	
	@machingState			nvarchar(500)='',
	@pageSize				int = 3,
	@pageIndex				int = 1
)
AS
begin
declare @where nvarchar(2000)
declare @sql nvarchar(2000)
set @where=' 1=1 and StockType=0 '
if @warehouseStoreNo<>''
	set @where=@where+' and WarehouseStoreNo = '''+@warehouseStoreNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @addStockDateA<>''
	set @where=@where+' and AddStockDate >= '''+@addStockDateA+''' '
if @addStockDateB<>''
	set @where=@where+' and AddStockDate <= '''+@addStockDateB+''' '
if @machingState<>''
	set @where=@where+' and MachingState = '''+@machingState+''' '
	
set @sql=' ID, WarehouseStoreNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags, SapNo, convert(varchar(20),PurchaseDate,111) as PurchaseDate,
convert(varchar(20),GuaranteeTime,111) as GuaranteeTime, RepairsNo, Supplier, convert(varchar(20),AddStockDate,111) as AddStockDate,
convert(varchar(20),OutStockDate,111) as OutStockDate '

exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_Stocks', @where, 'ID', 1, 'ID'
end
Go

Create Procedure [dbo].[GetAddStocksPaged]
(	
	@warehouseNo			nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@addStockDateA			nvarchar(500)='',
	@addStockDateB			nvarchar(500)='',
	@pageSize				int = 3,
	@pageIndex				int = 1
)
AS
begin
declare @where nvarchar(2000)
declare @sql nvarchar(2000)
set @where=' 1=1 '
if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @addStockDateA<>''
	set @where=@where+' and AddStockDate >= '''+@addStockDateA+''' '
if @addStockDateB<>''
	set @where=@where+' and AddStockDate <= '''+@addStockDateB+''' '

	
set @sql=' ID, WarehouseNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags, SapNo, convert(varchar(20),PurchaseDate,111) as PurchaseDate,
convert(varchar(20),GuaranteeTime,111) as GuaranteeTime, RepairsNo, Supplier, convert(varchar(20),AddStockDate,111) as AddStockDate '

exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_AddStocks', @where, 'ID', 1, 'ID'
end
Go

Create Procedure [dbo].[GetOutStocksTotal]
(
	@eventNo				nvarchar(500)='',
	@warehouseNo			nvarchar(500)='',
	@storeNo				nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',	
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@outStockDateA			nvarchar(500)='',
	@outStockDateB			nvarchar(500)='',
	@outStocksState			nvarchar(500)=''
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @eventNo<>''
	set @where=@where+' and EventNo = '''+@eventNo+''' '
if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @storeNo<>''
	set @where=@where+' and StoreNo = '''+@storeNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @outStockDateA<>''
	set @where=@where+' and OutStockDate >= '''+@outStockDateA+''' '
if @outStockDateB<>''
	set @where=@where+' and OutStockDate <= '''+@outStockDateB+''' '
if @outStocksState<>''
	set @where=@where+' and OutStocksState <= '''+@outStocksState+''' '
		

	
set @sql = 'select ID, EventNo, WarehouseNo, StoreNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags, SapNo, convert(varchar(20),PurchaseDate,111) as PurchaseDate,
convert(varchar(20),GuaranteeTime,111) as GuaranteeTime, RepairsNo, Supplier, convert(varchar(20),OutStockDate,111) as OutStockDate,case OutStocksState when 0 then ''正常'' else ''异常'' end as OutStocksState 
 from tb_OutStocks' + @where
exec sp_executesql @sql
Go
Create Procedure [dbo].[GetOutStocksPaged]
(	
	@eventNo				nvarchar(500)='',
	@warehouseNo			nvarchar(500)='',
	@storeNo				nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',	
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@outStockDateA			nvarchar(500)='',
	@outStockDateB			nvarchar(500)='',
	@outStocksState			nvarchar(500)='',
	@pageSize				int = 3,
	@pageIndex				int = 1
)
AS
begin
declare @where nvarchar(2000)
declare @sql nvarchar(2000)
set @where=' 1=1 '
if @eventNo<>''
	set @where=@where+' and EventNo = '''+@eventNo+''' '
if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @storeNo<>''
	set @where=@where+' and StoreNo = '''+@storeNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @outStockDateA<>''
	set @where=@where+' and OutStockDate >= '''+@outStockDateA+''' '
if @outStockDateB<>''
	set @where=@where+' and OutStockDate <= '''+@outStockDateB+''' '
if @outStocksState<>''
	set @where=@where+' and OutStocksState <= '''+@outStocksState+''' '
	
set @sql='ID, EventNo, WarehouseNo, StoreNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags, SapNo, convert(varchar(20),PurchaseDate,111) as PurchaseDate,
convert(varchar(20),GuaranteeTime,111) as GuaranteeTime, RepairsNo, Supplier, convert(varchar(20),OutStockDate,111) as OutStockDate,case OutStocksState when 0 then ''正常'' else ''异常'' end as OutStocksState  '

exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_OutStocks', @where, 'ID', 1, 'ID'
end
Go
Create Procedure [dbo].[GetEventLogsTotal]
(
	@eventTimeA		nvarchar(50)='',
	@eventTimeB		nvarchar(50)='',
	@storeNo		nvarchar(50)='',
	@typeCode		nvarchar(50)='',
	@eventState		nvarchar(50)='',
	@eventNo		nvarchar(50)='',
	@user			nvarchar(50)=''
)
AS
begin
DECLARE  @where   nvarchar(500)
DECLARE  @sql   nvarchar(1000)
	
	
	SET @where=' where 1=1 '
if @eventTimeA<>''
begin
	SET @where=@where+' and EventTime >= '''+@eventTimeA+''''
end
if @eventTimeB<>''
begin
	SET @where=@where+' and EventTime <= '''+@eventTimeB+''''
end
if @storeNo<>''
begin
	SET @where=@where+' and StoreNo= '''+@storeNo+''''
end
if @typeCode<>''
begin
	if @typeCode<>'9999' and @typeCode<>'9000' and @typeCode<>'8888'
	begin
		SET @where=@where+' and TypeCode= '''+@typeCode+''' '
	end
	if @typeCode='9999'
	begin
		SET @where=@where+' and TypeCode= ''9999'' '
	end
	if @typeCode='9000'
	begin	
		SET @where=@where+' and TypeCode= ''9000'' '
	end
	if @typeCode='8888'
	begin
		SET @where=@where+' and TypeCode= ''8888'' '	
	end
end
else
begin
	SET @where=@where+' and TypeCode<> ''9999'' and TypeCode<> ''9000'' and TypeCode<> ''8888'' '
end
if @eventState<>''
begin
	SET @where=@where+' and EventState= '''+@eventState+''''
end
if @eventNo<>''
begin
	SET @where=@where+' and EventNo= '''+@eventNo+''''
end
if @user<>''
begin
	SET @where=@where+' and LogBy= '''+@user+''''
end

set @sql='select row_number() over(order by EventTime desc) N, EventNo,EventTime,StoreNo,TypeCode,EventDescribe,ResolvedBy,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy from tb_EventLogs left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID '+ @where +' order by EventTime desc '
exec sp_executesql @sql
end

Go
Create Procedure [dbo].[GetEventLogsPaged]
(
	@eventTimeA		nvarchar(50)='',
	@eventTimeB		nvarchar(50)='',
	@storeNo		nvarchar(50)='',
	@typeCode		nvarchar(50)='',
	@eventState		nvarchar(50)='',
	@eventNo		nvarchar(50)='',
	@user			nvarchar(50)='',
	@pageSize		int = 30,
	@pageIndex		int = 2
)
AS
begin
DECLARE  @where   nvarchar(500)
DECLARE  @sql   nvarchar(1000)
declare  @n		nvarchar(100)
set @n = Cast((@pageIndex - 1) * @pageSize as nvarchar(100))
	
	
	SET @where='  1=1 '
if @eventTimeA<>''
begin
	SET @where=@where+' and EventTime >= '''+@eventTimeA+''''
end
if @eventTimeB<>''
begin
	SET @where=@where+' and EventTime <= '''+@eventTimeB+''''
end
if @storeNo<>''
begin
	SET @where=@where+' and StoreNo= '''+@storeNo+''''
end
if @typeCode<>''
begin
	if @typeCode<>'9999' and @typeCode<>'9000' and @typeCode<>'8888'
	begin
		SET @where=@where+' and TypeCode= '''+@typeCode+''' '
	end
	if @typeCode='9999'
	begin
		SET @where=@where+' and TypeCode= ''9999'' '
	end
	if @typeCode='9000'
	begin	
		SET @where=@where+' and TypeCode= ''9000'' '
	end
	if @typeCode='8888'
	begin
		SET @where=@where+' and TypeCode= ''8888'' '	
	end
end
else
begin
	SET @where=@where+' and TypeCode<> ''9999'' and TypeCode<> ''9000'' and TypeCode<> ''8888'' '
end
if @eventState<>''
begin
	SET @where=@where+' and EventState= '''+@eventState+''''
end
if @eventNo<>''
begin
	SET @where=@where+' and EventNo= '''+@eventNo+''''
end
if @user<>''
begin
	SET @where=@where+' and LogBy= '''+@user+''''
end

set @sql=' (row_number() over(order by EventTime desc)) + cast('+@n+' as int) N, EventNo,EventTime,StoreNo,TypeCode,EventDescribe,ResolvedBy,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy '

exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_EventLogs left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID', @where, 'EventTime', 1, 'EventTime'
end

Go
----------
Create Procedure [dbo].[GetScrapStocksTotal]
(
	@warehouseNo			nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',	
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@addScrapStockDateA		nvarchar(500)='',
	@addScrapStockDateB		nvarchar(500)=''
)
AS
declare @where nvarchar(300)
declare @sql nvarchar(1000)
set @where=' where 1=1 '
if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @addScrapStockDateA<>''
	set @where=@where+' and AddScrapStockDate >= '''+@addScrapStockDateA+''' '
if @addScrapStockDateB<>''
	set @where=@where+' and AddScrapStockDate <= '''+@addScrapStockDateB+''' '	

	
set @sql = 'select ID, WarehouseNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags,
RepairsNo, Supplier, convert(varchar(20),AddScrapStockDate,111) as AddScrapStockDate,Operator,LastWarehouseNo,ScrapReason
 from tb_ScrapStocks' + @where
exec sp_executesql @sql
Go
Create Procedure [dbo].[GetScrapStocksPaged]
(	
	@warehouseNo			nvarchar(500)='',
	@maching				nvarchar(500)='',
	@brand					nvarchar(500)='',
	@model					nvarchar(500)='',	
	@parameter				nvarchar(500)='',
	@supplier				nvarchar(500)='',
	@addScrapStockDateA		nvarchar(500)='',
	@addScrapStockDateB		nvarchar(500)='',	
	@pageSize				int = 3,
	@pageIndex				int = 1
)
AS
begin
declare @where nvarchar(1000)
declare @sql nvarchar(2000)
set @where=' 1=1 '
if @warehouseNo<>''
	set @where=@where+' and WarehouseNo = '''+@warehouseNo+''' '
if @maching<>''
	set @where=@where+' and Maching = '''+@maching+''' '
if @brand<>''
	set @where=@where+' and Brand = '''+@brand+''' '
if @model<>''
	set @where=@where+' and Model =	'''+@model+''' '
if @parameter<>''
	set @where=@where+' and Parameter = '''+@parameter+''' '
if @supplier<>''
	set @where=@where+' and Supplier = '''+@supplier+''' '
if @addScrapStockDateA<>''
	set @where=@where+' and AddScrapStockDate >= '''+@addScrapStockDateA+''' '
if @addScrapStockDateB<>''
	set @where=@where+' and AddScrapStockDate <= '''+@addScrapStockDateB+''' '
	
set @sql='ID, WarehouseNo, Maching, Brand, Model, Parameter, SerialNo, EpcTags,
RepairsNo, Supplier, convert(varchar(20),AddScrapStockDate,111) as AddScrapStockDate,Operator,LastWarehouseNo,ScrapReason '

exec dbo.GetPageOfRecords @pageSize, @pageIndex, @sql, 'dbo.tb_ScrapStocks', @where, 'ID', 1, 'ID'
end
Go
/***************************Paging***************************/

/***************************IndexCount***************************/
Create Procedure [dbo].[CountNormalEventLog]

AS
BEGIN
 select count(EventNo) from tb_EventLogs where EventState='99'
END
Go
Create Procedure [dbo].[CountSetUpShopEventLog]

AS
BEGIN
 select count(EventNo) from tb_EventLogs where EventState>='101' and EventState<='199'
END
Go
Create Procedure [dbo].[CountShutUpShopEventLog]

AS
BEGIN
 select count(EventNo) from tb_EventLogs where EventState>='201' and EventState<='299'
END
Go
Create Procedure [dbo].[CountStoreRenovationEventLog]

AS
BEGIN
 select count(EventNo) from tb_EventLogs where EventState>='301' and EventState<='399'
END
Go
Create Procedure [dbo].[GetUrgentNormalEventLog]
(
	@temp	nvarchar(500),
	@logBy	nvarchar(500)
)
AS
BEGIN
declare		@handingBy	nvarchar(500)
select @handingBy=Solver from tb_Solver where SMTP is not null and SMTP<>'' and Email is not null and Email<>'' and EPassword is not null and EPassword<>''

if @temp='0'
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID  
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo 
	where EventState<>'0' and LogBy=@logBy and HandingBy=@handingBy) tm where tm.rn=1  
	order by tm.EventTime desc 
END
if @temp='1'
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID  
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo 
	where EventState<>'0' and LogBy<>@logBy and HandingBy=@handingBy) tm where tm.rn=1  
	order by tm.EventTime desc 
END
if @temp='2'
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID  
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo 
	where EventState<>'0'  and HandingBy<>@handingBy) tm where tm.rn=1  
	order by tm.EventTime desc 
END
END
Go
Create Procedure [dbo].[GetUrgentSetUpShopEventLog]

AS
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID 
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo 
	where TypeCode='9999' and EventState<>'100' and tb_EventState.StateDay >= DATEDIFF(dd,getdate(),convert(nvarchar(10),tb_EventLogs.ToResolvedTime,127)) ) tm where tm.rn=1 
	order by EventTime desc
END
Go
Create Procedure [dbo].[GetUrgentShutUpShopEventLog]

AS
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID 
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo 
	where TypeCode='9000' and EventState<>'200' and tb_EventState.StateDay >= DATEDIFF(dd,getdate(),convert(nvarchar(10),tb_EventLogs.ToResolvedTime,127)) ) tm where tm.rn=1 
	order by EventTime desc
END
Go
Create Procedure [dbo].[GetUrgentStoreRenovationEventLog]

AS
BEGIN
	select * from (select tb_EventLogs.EventNo,EventTime,StoreNo,TypeCode,EventDescribe,convert(nvarchar(10),ToResolvedTime,127) ToResolvedTime,StateName as EventState,LogBy,StepDescribe,row_number() over (partition by tb_EventLogs.EventNo order by tb_EventSteps.ID desc) as rn 
	from tb_EventLogs 
	left join tb_EventState on tb_EventLogs.EventState=tb_EventState.StateID 
	left join tb_EventSteps on tb_EventLogs.EventNo=tb_EventSteps.EventNo
	where TypeCode='8888' and EventState<>'300' and tb_EventState.StateDay >= DATEDIFF(dd,getdate(),convert(nvarchar(10),tb_EventLogs.ToResolvedTime,127)) ) tm where tm.rn=1
	order by EventTime desc
END
Go

/***************************IndexCount***************************/

/***************************SceneType***************************/
/**Add**/
Create Procedure [dbo].[AddSceneType]
(
	@typeName				nvarchar(500),
	@baseToken				nvarchar(500),
	@computingMethod		nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeName from tb_SceneType where TypeName='''+@typeName+''') insert into tb_SceneType(TypeName,BaseToken,ComputingMethod) values('''+@typeName+''','''+@baseToken+''','''+@computingMethod+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetSceneType]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeName,BaseToken,ComputingMethod from tb_SceneType order by TypeName'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelSceneType]
(
	@typeName  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_SceneType where TypeName ='''+@typeName+''''
print @sql
EXEC(@sql)
Go
/***************************SceneType***************************/


/***************************MultiplyingPowerType***************************/
/**Add**/
Create Procedure [dbo].[AddMultiplyingPowerType]
(
	@typeName					nvarchar(500),
	@multiplyingPower			nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select TypeName from tb_MultiplyingPowerType where TypeName='''+@typeName+''') insert into tb_MultiplyingPowerType(TypeName,MultiplyingPower) values('''+@typeName+''','''+@multiplyingPower+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetMultiplyingPowerType]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select TypeName,MultiplyingPower from tb_MultiplyingPowerType order by TypeName'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelMultiplyingPowerType]
(
	@typeName  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_MultiplyingPowerType where TypeName ='''+@typeName+''''
print @sql
EXEC(@sql)
Go
/***************************MultiplyingPowerType***************************/


/***************************AreaInfo***************************/
/**Add**/
Create Procedure [dbo].[AddAreaInfo]
(
	@areaName					nvarchar(500),
	@areaAliss					nvarchar(500),
	@areaManager				nvarchar(500),
	@managerPhone				nvarchar(500),
	@managerEmail				nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select AreaName from tb_AreaInfo where AreaName='''+@areaName+''') insert into tb_AreaInfo(AreaName,AreaAliss,AreaManager,ManagerPhone,ManagerEmail) values('''+@areaName+''','''+@areaAliss+''','''+@areaManager+''','''+@managerPhone+''','''+@managerEmail+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetAreaInfo]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select AreaName,AreaAliss,AreaManager,ManagerPhone,ManagerEmail from tb_AreaInfo order by AreaName'
print @sql
EXEC(@sql)
Go
Create Procedure [dbo].[GetAreaAliss]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select AreaAliss from tb_AreaInfo order by AreaAliss'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelAreaInfo]
(
	@areaName  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_AreaInfo where AreaName ='''+@areaName+''''
print @sql
EXEC(@sql)
Go
/**Update**/
Create Procedure [dbo].[UpdateAreaInfo]
(
	@areaName					nvarchar(500),
	@areaAliss					nvarchar(500),
	@areaManager				nvarchar(500),
	@managerPhone				nvarchar(500),
	@managerEmail				nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'update tb_AreaInfo set AreaAliss='''+@areaAliss+''',AreaManager='''+@areaManager+''',ManagerPhone='''+@managerPhone+''',ManagerEmail='''+@managerEmail+''' where AreaName ='''+@areaName+''''
print @sql
EXEC(@sql)
Go
/***************************AreaInfo***************************/


/***************************SceneServiceProvider***************************/
/**Add**/
Create Procedure [dbo].[AddSceneServiceProvider]
(
	@serviceProvider			nvarchar(500),
	@phone						nvarchar(500),
	@serviceArea				nvarchar(500),
	@remainToken				nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'if not exists(select ServiceProvider from tb_SceneServiceProvider where ServiceProvider='''+@serviceProvider+''') insert into tb_SceneServiceProvider(ServiceProvider,Phone,ServiceArea,RemainToken) values('''+@serviceProvider+''','''+@phone+''','''+@serviceArea+''','''+@remainToken+''')'
print @sql
EXEC(@sql)
Go
/**Get**/
Create Procedure [dbo].[GetSceneServiceProvider]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select ServiceProvider,Phone,ServiceArea,RemainToken from tb_SceneServiceProvider order by ServiceProvider'
print @sql
EXEC(@sql)
Go
Create Procedure [dbo].[GetServiceProvider]

AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'select ServiceProvider from tb_SceneServiceProvider order by ServiceProvider'
print @sql
EXEC(@sql)
Go
/**Del**/
Create Procedure [dbo].[DelSceneServiceProvider]
(
	@serviceProvider  nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)	
SET @sql = 'delete from tb_SceneServiceProvider where ServiceProvider ='''+@serviceProvider+''''
print @sql
EXEC(@sql)
Go
/**Update**/
Create Procedure [dbo].[UpdateSceneServiceProvider]
(
	@serviceProvider			nvarchar(500),
	@phone						nvarchar(500),
	@serviceArea				nvarchar(500)
)
AS
DECLARE	 @sql	 nvarchar(3000)
SET @sql = 'update tb_SceneServiceProvider set Phone ='''+@phone+''',ServiceArea ='''+@serviceArea+''' where ServiceProvider ='''+@serviceProvider+''''
print @sql
EXEC(@sql)
Go
/***************************SceneServiceProvider***************************/


/***************************SystemUser***************************/
insert into tb_SystemUser(UserName,[Password],CreateTime,UserState) values('SystemAdmin','SystemAdmin',GETDATE(),1)
insert into tb_Permission(UserName,[Admin],[Index],UpdateSolution,EventQuery,CreateEvent,ReportFormsEvent,AddStock,StockQuery,OutStockQuery,AllotStockQuery,AddStockQuery,AlterStore,EventTypes,FacilityManage,PeopleManage,SynthesisManage,EventState,InitialStores,InitialStocks,[ScrapStocks])values('SystemAdmin',1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)
Go
/**Add**/
Create Procedure [dbo].[AddSystemUser]
(
	@userName		nvarchar(500),
	@password		nvarchar(500),
	@createTime		datetime
)
as
begin
if not exists(select UserName from tb_SystemUser where UserName=@userName)
begin 
insert into tb_SystemUser(UserName,[Password],CreateTime,UserState) values(@userName,@password,@createTime,0)
insert into tb_Permission(UserName,[Admin],[Index],UpdateSolution,EventQuery,CreateEvent,ReportFormsEvent,AddStock,StockQuery,OutStockQuery,AllotStockQuery,AddStockQuery,AlterStore,EventTypes,FacilityManage,PeopleManage,SynthesisManage,EventState,InitialStores,InitialStocks,[ScrapStocks])
						values(@userName,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)
end
end
Go
/**Get**/
Create Procedure [dbo].[GetSystemUser]

AS
begin
select row_number()over(order by UserName) as RowNum,UserName,[Password],convert(nvarchar(10),CreateTime,127) as CreateTime,convert(nvarchar(10),LastLogOnTime,127) as LastLogOnTime,case UserState when 0 then '禁用中' else '已启用' end as UserState from tb_SystemUser where UserName<>'SystemAdmin' order by UserName
end
Go
Create Procedure [dbo].[GetCheckSystemUserPassword]
(
	@userName		nvarchar(500),
	@password		nvarchar(500)
)
AS
begin
select count(UserName) from tb_SystemUser where UserName =@userName	and [Password]=@password and UserState=1
end
Go
Create Procedure [dbo].[GetUserIP]
(
	@userName			nvarchar(500),
	@userIP				nvarchar(500)
)
AS
begin
select UserIP from tb_SystemUser where UserName = @userName and UserIP=@userIP
end
Go
/**Del**/
Create Procedure [dbo].[DelSystemUser]
(
	@userName  nvarchar(500)
)
AS
begin
delete from tb_Permission where UserName =@userName	
delete from tb_SystemUser where UserName =@userName
end
Go
/**Update**/
Create Procedure [dbo].[UpdateSystemUserByUserName]
(
	@userName		nvarchar(500),
	@password		nvarchar(500)
)
AS
begin
update tb_SystemUser set [Password]=@password where UserName =@userName
end
Go
Create Procedure [dbo].[UpdateUserStateByUserName]
(
	@userName		nvarchar(500),
	@userState		int
)
AS
begin
update tb_SystemUser set UserState=@userState where UserName =@userName
end
Go
Create Procedure [dbo].[UpdateLogOnByUserName]
(
	@userName			nvarchar(500),
	@userIP				nvarchar(500)
)
AS
begin
update tb_SystemUser set LastLogOnTime=GETDATE(),UserIP=@userIP where UserName =@userName
end
Go
/***************************SystemUser***************************/

/***************************Permission***************************/
/**Get**/
Create Procedure [dbo].[GetOnePermission]
(
	@userName			nvarchar(500),
	@temp				nvarchar(500)
)
AS
declare @field nvarchar(500)
declare @sql nvarchar(1000)
begin
if @temp='0'
set @field='[Index]'
if @temp='1'
set @field='UpdateSolution'
if @temp='2'
set @field='EventQuery'
if @temp='3'
set @field='CreateEvent'
if @temp='4'
set @field='ReportFormsEvent'
if @temp='5'
set @field='AddStock'
if @temp='6'
set @field='StockQuery'
if @temp='7'
set @field='OutStockQuery'
if @temp='8'
set @field='AllotStockQuery'
if @temp='9'
set @field='AddStockQuery'
if @temp='10'
set @field='AlterStore'
if @temp='11'
set @field='EventTypes'
if @temp='12'
set @field='FacilityManage'
if @temp='13'
set @field='PeopleManage'
if @temp='14'
set @field='SynthesisManage'
if @temp='15'
set @field='EventState'
if @temp='16'
set @field='InitialStores'
if @temp='17'
set @field='InitialStocks'
if @temp='18'
set @field='[Admin]'
if @temp='19'
set @field='[ScrapStocks]'

	
set @sql ='select '+@field+' 
from tb_Permission where UserName = '''+@userName+''' '

exec(@sql)
end
Go
Create Procedure [dbo].[GetPermission]
(
	@userName			nvarchar(500)
)
AS
declare @sql nvarchar(2000)
begin
 set @sql=' select UserName,[Index],UpdateSolution,EventQuery,CreateEvent,ReportFormsEvent,AddStock,StockQuery,OutStockQuery,AllotStockQuery,AddStockQuery,AlterStore,EventTypes,FacilityManage,PeopleManage,SynthesisManage,EventState,InitialStores,InitialStocks,[Admin],[ScrapStocks] 
from tb_Permission where UserName = '''+@userName+''''
exec(@sql)
end
Go
/**Update**/
Create Procedure [dbo].[UpdatePermissionByUserName]
(
	@userName			nvarchar(500),
	@index				int,
	@updateSolution		int,
	@eventQuery			int,
	@createEvent		int,
	@reportFormsEvent	int,
	@addStock			int,
	@stockQuery			int,
	@outStockQuery		int,
	@allotStockQuery	int,
	@addStockQuery		int,
	@alterStore			int,
	@eventTypes			int,
	@facilityManage		int,
	@peopleManage		int,
	@synthesisManage	int,
	@eventState			int,
	@initialStores		int,
	@initialStocks		int,
	@scrapStocks		int
)
AS
begin
update tb_Permission set [Index]=@index,UpdateSolution=@updateSolution,EventQuery=@eventQuery,CreateEvent=@createEvent,
						ReportFormsEvent=@reportFormsEvent,AddStock=@addStock,StockQuery=@stockQuery,OutStockQuery=@outStockQuery,
						AllotStockQuery=@allotStockQuery,AddStockQuery=@addStockQuery,AlterStore=@alterStore,EventTypes=@eventTypes,
						FacilityManage=@facilityManage,PeopleManage=@peopleManage,SynthesisManage=@synthesisManage,EventState=@eventState,
						InitialStores=@initialStores,InitialStocks=@initialStocks,[ScrapStocks]=@scrapStocks where UserName =@userName
end
Go
/***************************Permission***************************/



-------Testing-------

--insert into tb_Stores(StoreNo,TopStore,StoreType,Region,Rating,StoreName,City,StoreAddress,StoreTel,ContractArea,OpeingDate,StoreState)	values('6100','Yes','Focus','BJ','AAA','Fine','TJ','TJ','123456','90',cast('2012-12-20 10:20' as datetime),'998')
--insert into tb_Machings(Maching)values('笔记本')
--insert into tb_Machings(Maching)values('打印机')
--insert into tb_Brands(Brand)values('戴尔')
--insert into tb_Brands(Brand)values('CANNON')
--insert into tb_Models(Model)values('H4440')
--insert into tb_Models(Model)values('Ho000')
--insert into tb_Parameters(Parameter)values('2G')
--insert into tb_Parameters(Parameter)values('XG')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','戴尔','H4440','ECT100301','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','戴尔','H4440','ECT100311','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','戴尔','H4440','ECT100321','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','宏基','H4440','NCC100301','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','戴尔','M5110','ECM100301','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','打印机','CANNON','Ho000','ECM100351','XG',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','0')
--insert into tb_Stocks(WarehouseStoreNo,Maching,Brand,Model,SerialNo,Parameter,EpcTags,SapNo,PurchaseDate,GuaranteeTime,RepairsNo,Supplier,AddStockDate,OutStockDate,Operator,StockType,MachingState)
--values('000001','笔记本','戴尔','H4440','ECT100400','2G',NULL,NULL,'2013-10-20','2013-10-20','123456','戴尔','2013-10-20','2013-10-20','当前用户','0','1')

--go


--select a.DemandNo into #Temp from (select DemandNo from tb_OutStockDemands where DemandNo not in(select DemandNo from tb_Stocks where DemandNo is not null))a
--declare @demandNo int
--declare @num int
--declare @count int
--set @num=0
--set @count = (select count(DemandNo) from #Temp)
--while @num<@count
--begin
--set @num=@num+1
--;with rownum_cte as
--(
--	select  DemandNo,row_number()over(order by DemandNo)as Rownum from #Temp
--)
--select @demandNo=DemandNo from rownum_cte where Rownum=@num

--;with upd_cte as
--(
--	select top 1 a.EventNo,a.DemandNo
--	from tb_Stocks a,tb_OutStockDemands b 
--	where a.Maching=b.Maching and a.Brand=b.Brand and a.Model=b.Model and a.Parameter=b.Parameter and b.DemandNo=@demandNo and a.DemandNo is null and a.StockType='0'
--	order by a.PurchaseDate
--)
--update upd_cte set EventNo='BJ20130427094457',DemandNo=@demandNo
--end
--drop table #Temp