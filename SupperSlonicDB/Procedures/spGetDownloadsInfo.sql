--drop procedure [dbo].[spGetDownloadsInfo]

create procedure [dbo].[spGetDownloadsInfo]
as
begin
	select	cl.[Name]					as Name,
			count(*)					as TotalDownloads,
			max(sDownload.[timeStamp])	as LatestDownload

	from [dbo].[clSourceCodeExample] as cl
	inner join [dbo].[SourceCodeDownload] as sDownload on sDownload.[clSourceCodeId] = cl.[Id]
	group by cl.[Name]
end