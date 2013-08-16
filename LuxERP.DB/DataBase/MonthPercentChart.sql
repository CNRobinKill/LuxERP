USE [LUXERP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter Procedure [dbo].[MonthPercentChart]
(
	@year	as nvarchar(4) = '2013'
)
AS
BEGIN
 create table #temp
 (
	m int,
	Level1 int,
	Level2 int,
	Level3 int,
	Vender int,
	Total int,
	Level1Per float,
	Level2Per float,
	Level3Per float,
	VenderPer float
 )
insert into #temp exec dbo.MonthPercent @year
 
select  case when Total=0 then 0 else ROUND(CAST(Level1 as float) / CAST(Total as float), 4) * 100 end as  [Level 1],
		case when Total=0 then 0 else ROUND(CAST(Level2 as float) / CAST(Total as float), 4) * 100 end as  [Level 2],
		case when Total=0 then 0 else ROUND(CAST(Level3 as float) / CAST(Total as float), 4) * 100 end as  [Level 3],
		case when Total=0 then 0 else ROUND(CAST(Vender as float) / CAST(Total as float), 4) * 100 end as  [Vender]
from (		
	select SUM(Level1) Level1, SUM(Level2) Level2,  SUM(Level3) Level3,  SUM(Vender) Vender,  SUM(Total) Total
	from #temp
	) a
 
 
END