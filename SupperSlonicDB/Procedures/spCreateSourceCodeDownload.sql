--drop procedure [dbo].[spCreateSourceCodeDownload]

create procedure [dbo].[spCreateSourceCodeDownload]
(
	@codeName nvarchar(255)
)
as
begin

	insert into [dbo].[SourceCodeDownload] ([clSourceCodeId])
	select [Id] from [dbo].[clSourceCodeExample] where [Name] = @codeName;

end