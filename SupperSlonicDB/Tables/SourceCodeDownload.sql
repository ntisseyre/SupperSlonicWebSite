create table [dbo].[SourceCodeDownload]
(
	[Id]				int				not null identity(1, 1)	primary key,
	[clSourceCodeId]	tinyint			not null,
	[timeStamp]			smalldatetime	not null default (dateadd(hour,(-6),getutcdate())),

	constraint [FK_SourceCodeDownload_clSourceCodeId_To_clSourceCodeExample_Id] foreign key ([clSourceCodeId]) references [clSourceCodeExample]([Id])
)
