--drop procedure [dbo].[spGetDownloadsInfo]

create procedure [dbo].[spGetDownloadsInfo]
as
begin
	
	select	cl.[Name]							as Name,
			IsNull(clStat.TotalDownloads, 0)	as TotalDownloads,
			clStat.LatestDownload				as LatestDownload
	
	from [dbo].[clSourceCodeExample] as cl
	left join
	(
		select	sDownload.[clSourceCodeId]	as clId,
				count(*)					as TotalDownloads,
				max(sDownload.[timeStamp])	as LatestDownload
		from [dbo].[SourceCodeDownload] as sDownload
		group by sDownload.[clSourceCodeId]
	) as clStat on clStat.clId = cl.[Id]
	
	order by cl.[Name]

end