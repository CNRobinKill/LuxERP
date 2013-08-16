USE [LUXERP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[FocusIFocus]
(
	@year	as nvarchar(4) = '2013'
)
AS
BEGIN
declare @s datetime
declare @e datetime

set @s = @year+'-01-01'
set @e = @year+'-12-31'

select m, Focus, IFocus, Focus+IFocus total, ROUND(cast(Focus as float)/cast((Focus+IFocus) as float),4) * 100 FocusPer,
ROUND(cast(IFocus as float)/cast((Focus+IFocus) as float),4) * 100 IFocusPer
from (select m, MAX(case when StoreType='Focus' then n else 0 end) as Focus, MAX(case when StoreType='IFocus' then n else 0 end) as IFocus	
from (select MONTH(EventTime) m, b.StoreType, COUNT(*) n
	  from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
	  where TypeCode not in('9000','9999','8888') and EventTime between @s and @e
	  group by MONTH(EventTime), b.StoreType
	 ) a group by m
	 ) b
 
END