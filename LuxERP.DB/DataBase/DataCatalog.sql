USE [LUXERP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter Procedure [dbo].[DataCatalog]
(
	@year	as nvarchar(4) = '2013'
)
AS
BEGIN
declare @s datetime
declare @e datetime
set @s = @year + '-01-01' 
set @e = @year + '-12-31' 

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
			select case when datepart(WW,EventTime)= 53 then 52 else datepart(WW,EventTime) end M, case when a.EventState in(''0'',''100'',''200'',''300'') then ''Finish'' else ''Opening'' end as Status,ISNULL(a.ResolvedBy,a.HandingBy) Level, TypeTwo,
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
	
print @cmdE
exec (@cmdS+@sqlcmd1+@sqlcmd2+@sqlcmd3+@sqlcmd4+@sqlcmd5+@sqlcmd6+@sqlcmd7+@sqlcmd8+@sqlcmd9+@cmdE)
 
END