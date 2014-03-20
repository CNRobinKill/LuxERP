USE [LUXERP]
GO
/****** Object:  StoredProcedure [dbo].[FocusIFocus]    Script Date: 03/20/2014 14:29:03 ******/
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
go

create Procedure [dbo].[DataCatalog]
(
	@year	as nvarchar(4) = '2014'
)
AS
BEGIN
declare @s datetime
declare @e datetime
-- 每年第一周第一天的日期
set @s = DATEADD(day,-1,dateadd(week,datediff(week,0,dateadd(week,0,dateadd(year,datediff(year,0,@year + '-01-01'),0))),0))	

-- 每年最后一周第一天的日期
set @e = DATEADD(day,-1,dateadd(week,datediff(week,0,dateadd(week,51,dateadd(year,datediff(year,0,@year + '-01-01'),0))),0))
set @e = DATEADD(day,7,@e)

print @s
print @e

declare @where as nvarchar(4000)
set @where = ' where EventTime between ''' + convert(nvarchar(10),@s,126) + ''' and ''' + convert(nvarchar(10),@e,126) + ''''

declare	@n as int
declare @sql as nvarchar(4000)
declare @sqlcmd1 as nvarchar(4000)
declare @sqlcmd2 as nvarchar(4000)
declare @sqlcmd3 as nvarchar(4000)
declare @sqlcmd4 as nvarchar(4000)
declare @sqlcmd5 as nvarchar(4000)
declare @sqlcmd6 as nvarchar(4000)
declare @sqlcmd7 as nvarchar(4000)
declare @sqlcmd8 as nvarchar(4000)
declare @sqlcmd9 as nvarchar(4000)
declare @m as nvarchar(10)
set @n = 1
set @sqlcmd1 = ' '
set @sqlcmd2 = ' '
set @sqlcmd3 = ' '
set @sqlcmd4 = ' '
set @sqlcmd5 = ' '
set @sqlcmd6 = ' '
set @sqlcmd7 = ' '
set @sqlcmd8 = ' '
set @sqlcmd9 = ' '
set @sql = 'MAX(case when M+Status+Level=''$FinishLevel 1'' then N else 0 end) as [WK$_FL1],MAX(case when M+Status+Level=''$FinishLevel 2'' then N else 0 end) as [WK$_FL2],MAX(case when M+Status+Level=''$FinishLevel 3'' then N else 0 end) as [WK$_FL3],MAX(case when M+Status+Level=''$FinishVender''  then N else 0 end) as [WK$_FV],MAX(case when M+Status+Level=''$OpenningLevel 1'' then N else 0 end) as [WK$_OL1],MAX(case when M+Status+Level=''$OpenningLevel 2'' then N else 0 end) as [WK$_OL2],MAX(case when M+Status+Level=''$OpenningLevel 3'' then N else 0 end) as [WK$_OL3],MAX(case when M+Status+Level=''$OpenningVender''  then N else 0 end) as [WK$_OV],'

while @n <= 416
begin
	set @m =CAST((@n / 8 + 1) as nvarchar(10))
	if CAST(@m as int) <= 6
		set @sqlcmd1 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 7 and CAST(@m as int) <= 12)
		set @sqlcmd2 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 13 and CAST(@m as int) <= 18)
		set @sqlcmd3 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 19 and CAST(@m as int) <= 24)
		set @sqlcmd4 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 25 and CAST(@m as int) <= 30)
		set @sqlcmd5 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 31 and CAST(@m as int) <= 36)
		set @sqlcmd6 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 37 and CAST(@m as int) <= 42)
		set @sqlcmd7 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 43 and CAST(@m as int) <= 48)
		set @sqlcmd8 += replace(@sql,'$',@m)
	else if (CAST(@m as int) >= 49 and CAST(@m as int) <= 52)
		set @sqlcmd9 += replace(@sql,'$',@m)
		
	set @n = @n + 8
end
set @sqlcmd9 = left(@sqlcmd9,LEN(@sqlcmd9)-1)
declare @cmdS as nvarchar(4000)
declare @cmdE as nvarchar(4000)
set @cmdS = ' select G, TotalOne, PerOne, TypeTwo, TotalTwo, PerTwo, Total,'
set @cmdE = ' from (
	select G, TotalOne, ROUND(CAST(TotalOne as float) / CAST(Total as float),4) * 100 PerOne, TypeTwo, TotalTwo, 
	ROUND(CAST(TotalTwo as float) / CAST(Total as float),4) * 100 PerTwo, Total,COUNT(*) N, cast(M as nvarchar(10)) M, Status, Level
	from (
		select G, COUNT(*) over(partition by G) TotalOne,  TypeTwo, COUNT(*) over(partition by G,TypeTwo) TotalTwo, COUNT(*) over() Total, M, Status, Level
		from (
			select case when datepart(WW,EventTime)= 53 then 1 else datepart(WW,EventTime) end M, case when a.EventState in(''0'',''100'',''200'',''300'') then ''Finish'' else ''Openning'' end as Status,ISNULL(a.ResolvedBy,a.HandingBy) Level, TypeTwo,
			case when TypeTwo in(''开店'',''关店'',''装修'') then ''开关店''
				 when TypeTwo in(''Focus软件'',''Focus硬件'') then ''门店 POS系统''
				 when TypeTwo in(''iPad'',''LED电视墙'',''Traffic Counter'',''考勤机'',''拍照触摸屏'') then ''门店电子设备''
				 when TypeTwo in(''3G'',''ADSL Modem'',''路由器'',''WIFI'',''网络状况'') then ''门店网络''
				 when TypeTwo in(''Email'',''openoffice'',''报表平台'',''报税系统'',''强生系统'') then ''门店应用系统''
				 when TypeTwo in(''电话询问'',''邮件询问'') then ''其他''
				 end as G
			from dbo.tb_EventLogs a 
			left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
			left join dbo.tb_EventTypes c on a.TypeCode=c.TypeCode
			'+@where+'
			) a 
		) b group by G, TotalOne, TypeTwo, TotalTwo, Total, M, Status, Level
	) c group by G, TotalOne, PerOne, TypeTwo, TotalTwo, PerTwo, Total '
	
--print @cmdE
exec (@cmdS+@sqlcmd1+@sqlcmd2+@sqlcmd3+@sqlcmd4+@sqlcmd5+@sqlcmd6+@sqlcmd7+@sqlcmd8+@sqlcmd9+@cmdE)
 
END
go

create Procedure [dbo].[WeekReport]
(
	@year	as nvarchar(4) = '2013',
	@week	as int = 52
)
AS
BEGIN
declare @date datetime
declare @s datetime
declare @e datetime
set @date = getdate()
if YEAR(@date) <> @year
	set @date = @year + '-01-01'

set @s = dateadd(week,datediff(week,0,dateadd(week,@week-1,dateadd(year,datediff(year,0,@date),0))),0)
set @s = DATEADD(day,-1,@s)	 
set @e = DATEADD(day,7,@s)


print @s
print @e
-- 过滤每周的原始数据
select *,case when N=0 then 0 else cast(SubTotal as float)/N  * 100 end as Per from
(select Region, 
Finish_Level1_Focus, Finish_Level1_IFocus, Finish_Level2_Focus, Finish_Level2_IFocus, 
Finish_Level3_Focus, Finish_Level3_IFocus, Finish_Vender_Focus,	Finish_Vender_IFocus,
Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus as SubFinish,  
Opening_Level1_Focus, Opening_Level1_IFocus, Opening_Level2_Focus, Opening_Level2_IFocus, 
Opening_Level3_Focus, Opening_Level3_IFocus, Opening_Vender_Focus, Opening_Vender_IFocus,
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus as SubOpening,  
Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus+  
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus as SubTotal,  
SUM(Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus+  
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus) over() as N
from
(select Region,
MAX(case when Status+Level+StoreType='FinishLevel 1Focus' then M else 0 end) as [Finish_Level1_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 1IFocus' then M else 0 end) as [Finish_Level1_IFocus],
MAX(case when Status+Level+StoreType='FinishLevel 2Focus' then M else 0 end) as [Finish_Level2_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 2IFocus' then M else 0 end) as [Finish_Level2_IFocus],
MAX(case when Status+Level+StoreType='FinishLevel 3Focus' then M else 0 end) as [Finish_Level3_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 3IFocus' then M else 0 end) as [Finish_Level3_IFocus],
MAX(case when Status+Level+StoreType='FinishVenderFocus' then M else 0 end) as [Finish_Vender_Focus],
MAX(case when Status+Level+StoreType='FinishVenderIFocus' then M else 0 end) as [Finish_Vender_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 1Focus' then M else 0 end) as [Opening_Level1_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 1IFocus' then M else 0 end) as [Opening_Level1_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 2Focus' then M else 0 end) as [Opening_Level2_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 2IFocus' then M else 0 end) as [Opening_Level2_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 3Focus' then M else 0 end) as [Opening_Level3_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 3IFocus' then M else 0 end) as [Opening_Level3_IFocus],
MAX(case when Status+Level+StoreType='OpeningVenderFocus' then M else 0 end) as [Opening_Vender_Focus],
MAX(case when Status+Level+StoreType='OpeningVenderIFocus' then M else 0 end) as [Opening_Vender_IFocus]
from
(select distinct * from
 (select *, COUNT(*) over(partition by Region,Status,Level,StoreType) as M 
  from (select b.Region, case when a.EventState in('0','100','200','300') then 'Finish' else 'Opening' end as Status,ISNULL(a.ResolvedBy,a.HandingBy) Level,b.StoreType
	    from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
	    where EventTime between @s and @e
	    ) a
  ) b
 ) c group by c.Region
) d
) e
 
END
go

create Procedure [dbo].[TimeSegment]
(
	@year	as nvarchar(4) = '2014'
)
AS
BEGIN
declare @s datetime
declare @e datetime

-- 每年第一周第一天的日期
set @s = DATEADD(day,-1,dateadd(week,datediff(week,0,dateadd(week,0,dateadd(year,datediff(year,0,@year + '-01-01'),0))),0))	

-- 每年最后一周第一天的日期
set @e = DATEADD(day,-1,dateadd(week,datediff(week,0,dateadd(week,51,dateadd(year,datediff(year,0,@year + '-01-01'),0))),0))
set @e = DATEADD(day,7,@e)

print @s
print @e

select ROUND(CAST(subtotal as float)/CAST((SUM(subtotal) over()) as float), 4) * 100 per, *
from (
	select  T, 
			isnull([1],0)+isnull([2],0)+isnull([3],0)+isnull([4],0)+isnull([5],0)+isnull([6],0)+isnull([7],0)  +
			isnull([8],0)+isnull([9],0)+isnull([10],0)+isnull([11],0)+isnull([12],0)+isnull([13],0)+isnull([14],0) +
			isnull([15],0)+isnull([16],0)+isnull([17],0)+isnull([18],0)+isnull([19],0)+isnull([20],0)+isnull([21],0) +
			isnull([22],0)+isnull([23],0)+isnull([24],0)+isnull([25],0)+isnull([26],0)+isnull([27],0)+isnull([28],0) +
			isnull([29],0)+isnull([30],0)+isnull([31],0)+isnull([32],0)+isnull([33],0)+isnull([34],0)+isnull([35],0) +
			isnull([36],0)+isnull([37],0)+isnull([38],0)+isnull([39],0)+isnull([40],0)+isnull([41],0)+isnull([42],0) +
			isnull([43],0)+isnull([44],0)+isnull([45],0)+isnull([46],0)+isnull([47],0)+isnull([48],0)+isnull([49],0) +
			isnull([50],0)+isnull([51],0)+isnull([52],0) subtotal,		
			isnull([1],0)  [1],  isnull([2],0)  [2],  isnull([3],0)  [3],  isnull([4],0)  [4],  isnull([5],0)  [5],  isnull([6],0)  [6],  isnull([7],0)  [7],
			isnull([8],0)  [8],  isnull([9],0)  [9],  isnull([10],0) [10], isnull([11],0) [11], isnull([12],0) [12], isnull([13],0) [13], isnull([14],0) [14],
			isnull([15],0) [15], isnull([16],0) [16], isnull([17],0) [17], isnull([18],0) [18], isnull([19],0) [19], isnull([20],0) [20], isnull([21],0) [21],
			isnull([22],0) [22], isnull([23],0) [23], isnull([24],0) [24], isnull([25],0) [25], isnull([26],0) [26], isnull([27],0) [27], isnull([28],0) [28],
			isnull([29],0) [29], isnull([30],0) [30], isnull([31],0) [31], isnull([32],0) [32], isnull([33],0) [33], isnull([34],0) [34], isnull([35],0) [35],
			isnull([36],0) [36], isnull([37],0) [37], isnull([38],0) [38], isnull([39],0) [39], isnull([40],0) [40], isnull([41],0) [41], isnull([42],0) [42],
			isnull([43],0) [43], isnull([44],0) [44], isnull([45],0) [45], isnull([46],0) [46], isnull([47],0) [47], isnull([48],0) [48], isnull([49],0) [49],
			isnull([50],0) [50], isnull([51],0) [51], isnull([52],0) [52]
	from (
		select W, T, COUNT(*) N
		from (	
			select case when W=53 then 1 else W end W, HM,
				case when HM between cast('8:30' as datetime) and cast('9:30' as datetime) then 'G830'
					 when HM between cast('9:31' as datetime) and cast('10:30' as datetime) then 'G931'
					 when HM between cast('10:31' as datetime) and cast('11:30' as datetime) then 'G1031'
					 when HM between cast('11:31' as datetime) and cast('12:30' as datetime) then 'G1131'
					 when HM between cast('12:31' as datetime) and cast('13:30' as datetime) then 'G1231'
					 when HM between cast('13:31' as datetime) and cast('14:30' as datetime) then 'G1331'
					 when HM between cast('14:31' as datetime) and cast('15:30' as datetime) then 'G1431'
					 when HM between cast('15:31' as datetime) and cast('16:30' as datetime) then 'G1531'
					 when HM between cast('16:31' as datetime) and cast('17:30' as datetime) then 'G1631'
					 when HM between cast('17:31' as datetime) and cast('18:30' as datetime) then 'G1731'
					 when HM between cast('18:31' as datetime) and cast('19:30' as datetime) then 'G1831'
					 when HM between cast('19:31' as datetime) and cast('20:30' as datetime) then 'G1931'
					 when HM between cast('20:31' as datetime) and cast('21:30' as datetime) then 'G2031'
					 when HM between cast('21:31' as datetime) and cast('22:30' as datetime) then 'G2131'
					 else null end as T
			from (
				  select EventTime, DATEPART(WEEK,EventTime) W, cast(DATENAME(HOUR,EventTime)+':'+DATENAME(MINUTE,EventTime) as datetime) HM
				  from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
				  where TypeCode not in('9000','9999','8888') and EventTime between @s and @e
				 ) a				 
			 ) b group by W,T
	 ) c pivot( MAX(N) for W in([1],  [2],  [3],  [4],  [5],  [6],  [7],  [8],  [9],  [10], 
								[11], [12], [13], [14], [15], [16], [17], [18], [19], [20], 
								[21], [22], [23], [24], [25], [26],	[27], [28], [29], [30],
								[31], [32], [33], [34], [35], [36], [37], [38], [39], [40],
								[41], [42], [43], [44], [45], [46], [47], [48], [49], [50], [51], [52])) pvt
	) d order by cast(right(T,LEN(T)-1) as int)
	
END
go

create Procedure [dbo].[MonthReport]
(
	@year	as nvarchar(4) = '2013',
	@month	as nvarchar(2) = '7'
)
AS
BEGIN
declare @s datetime
declare @e datetime

if @month = '13'
begin
	set @s = @year+'-01-01'
	set @e = @year+'-12-31'
end
else
begin
	set @s = @year + '-' + @month + '-01' 
	set @e = Convert(nvarchar(10),Dateadd(d,-1,DATEADD(m,1,@s)),126)
end


-- 过滤每周的原始数据
select *,case when N=0 then 0 else cast(SubTotal as float)/N  * 100 end as Per from
(select Region, 
Finish_Level1_Focus, Finish_Level1_IFocus, Finish_Level2_Focus, Finish_Level2_IFocus, 
Finish_Level3_Focus, Finish_Level3_IFocus, Finish_Vender_Focus,	Finish_Vender_IFocus,
Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus as SubFinish,  
Opening_Level1_Focus, Opening_Level1_IFocus, Opening_Level2_Focus, Opening_Level2_IFocus, 
Opening_Level3_Focus, Opening_Level3_IFocus, Opening_Vender_Focus, Opening_Vender_IFocus,
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus as SubOpening,  
Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus+  
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus as SubTotal,  
SUM(Finish_Level1_Focus+Finish_Level1_IFocus+Finish_Level2_Focus+Finish_Level2_IFocus+Finish_Level3_Focus+Finish_Level3_IFocus+Finish_Vender_Focus+Finish_Vender_IFocus+  
Opening_Level1_Focus+Opening_Level1_IFocus+Opening_Level2_Focus+Opening_Level2_IFocus+Opening_Level3_Focus+Opening_Level3_IFocus+Opening_Vender_Focus+Opening_Vender_IFocus) over() as N
from
(select Region,
MAX(case when Status+Level+StoreType='FinishLevel 1Focus' then M else 0 end) as [Finish_Level1_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 1IFocus' then M else 0 end) as [Finish_Level1_IFocus],
MAX(case when Status+Level+StoreType='FinishLevel 2Focus' then M else 0 end) as [Finish_Level2_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 2IFocus' then M else 0 end) as [Finish_Level2_IFocus],
MAX(case when Status+Level+StoreType='FinishLevel 3Focus' then M else 0 end) as [Finish_Level3_Focus],
MAX(case when Status+Level+StoreType='FinishLevel 3IFocus' then M else 0 end) as [Finish_Level3_IFocus],
MAX(case when Status+Level+StoreType='FinishVenderFocus' then M else 0 end) as [Finish_Vender_Focus],
MAX(case when Status+Level+StoreType='FinishVenderIFocus' then M else 0 end) as [Finish_Vender_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 1Focus' then M else 0 end) as [Opening_Level1_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 1IFocus' then M else 0 end) as [Opening_Level1_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 2Focus' then M else 0 end) as [Opening_Level2_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 2IFocus' then M else 0 end) as [Opening_Level2_IFocus],
MAX(case when Status+Level+StoreType='OpeningLevel 3Focus' then M else 0 end) as [Opening_Level3_Focus],
MAX(case when Status+Level+StoreType='OpeningLevel 3IFocus' then M else 0 end) as [Opening_Level3_IFocus],
MAX(case when Status+Level+StoreType='OpeningVenderFocus' then M else 0 end) as [Opening_Vender_Focus],
MAX(case when Status+Level+StoreType='OpeningVenderIFocus' then M else 0 end) as [Opening_Vender_IFocus]
from
(select distinct * from
 (select *, COUNT(*) over(partition by Region,Status,Level,StoreType) as M 
  from (select b.Region, case when a.EventState in('0','100','200','300') then 'Finish' else 'Opening' end as Status,ISNULL(a.ResolvedBy,a.HandingBy) Level,b.StoreType
	    from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
	    where EventTime between @s and @e
	    ) a
  ) b
 ) c group by c.Region
) d
) e
 
END
go

create Procedure [dbo].[MonthPercentChart]
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
go

CREATE Procedure [dbo].[MonthPercent]
(
	@year	as nvarchar(4) = '2013'
)
AS
BEGIN
declare @s datetime
declare @e datetime

set @s = @year+'-01-01'
set @e = @year+'-12-31'

select m, Level1, Level2, Level3, Vender, Level1+Level2+Level3+Vender Total, 
       case when Level1+Level2+Level3+Vender=0 then 0 else ROUND(CAST(Level1 as float) / CAST((Level1+Level2+Level3+Vender) as float),4) * 100 end as Level1Per,
       case when Level1+Level2+Level3+Vender=0 then 0 else ROUND(CAST(Level2 as float) / CAST((Level1+Level2+Level3+Vender) as float),4) * 100 end as Level2Per,
       case when Level1+Level2+Level3+Vender=0 then 0 else ROUND(CAST(Level3 as float) / CAST((Level1+Level2+Level3+Vender) as float),4) * 100 end as Level3Per,
       case when Level1+Level2+Level3+Vender=0 then 0 else ROUND(CAST(Vender as float) / CAST((Level1+Level2+Level3+Vender) as float),4) * 100 end as VenderPer
from (select m, MAX(case when Level='Level 1' then n else 0 end) as Level1, MAX(case when Level='Level 2' then n else 0 end) as Level2,
	  MAX(case when Level='Level 3' then n else 0 end) as Level3, MAX(case when Level='Vender' then n else 0 end) as Vender
from (select MONTH(EventTime) m, ISNULL(a.ResolvedBy,a.HandingBy) Level, COUNT(*) n
	  from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
	  where TypeCode not in('9000','9999','8888') and EventTime between @s and @e
	  group by MONTH(EventTime), ISNULL(a.ResolvedBy,a.HandingBy)
	 ) a group by m
	 ) b
 
END