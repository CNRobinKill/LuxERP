USE [LUXERP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter Procedure [dbo].[TimeSegment]
(
	@year	as nvarchar(4) = '2013'
)
AS
BEGIN
declare @s datetime
declare @e datetime

set @s = @year+'-01-01'
set @e = @year+'-12-31'

select  ROUND(CAST(subtotal as float)/CAST((SUM(subtotal) over()) as float), 4) * 100 per, *
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
			select case when W=53 then 52 else W end W, HM,
				case when HM between '08:30' and '09:30' then 'G830'
					 when HM between '09:31' and '10:30' then 'G931'
					 when HM between '10:31' and '11:30' then 'G1031'
					 when HM between '11:31' and '12:30' then 'G1131'
					 when HM between '12:31' and '13:30' then 'G1231'
					 when HM between '13:31' and '14:30' then 'G1331'
					 when HM between '14:31' and '15:30' then 'G1431'
					 when HM between '15:31' and '16:30' then 'G1531'
					 when HM between '16:31' and '17:30' then 'G1631'
					 when HM between '17:31' and '18:30' then 'G1731'
					 when HM between '18:31' and '19:30' then 'G1831'
					 when HM between '19:31' and '20:30' then 'G1931'
					 when HM between '20:31' and '21:30' then 'G2031'
					 when HM between '21:31' and '22:30' then 'G2131'
					 else null end as T
			from (
				  select EventTime, DATEPART(WEEK,EventTime) W, DATENAME(HOUR,EventTime)+':'+DATENAME(MINUTE,EventTime) HM
				  from dbo.tb_EventLogs a left join dbo.tb_Stores b on a.StoreNo = b.StoreNo
				  where TypeCode not in('9000','9999','8888') and EventTime between @s and @e
				 ) a				 
			 ) b group by W,T
	 ) c pivot( MAX(N) for W in([1],  [2],  [3],  [4],  [5],  [6],  [7],  [8],  [9],  [10], 
								[11], [12], [13], [14], [15], [16], [17], [18], [19], [20], 
								[21], [22], [23], [24], [25], [26],	[27], [28], [29], [30],
								[31], [32], [33], [34], [35], [36], [37], [38], [39], [40],
								[41], [42], [43], [44], [45], [46], [47], [48], [49], [50], [51], [52])) pvt
	) d
	
END