create table [dbo].[clSourceCodeExample]
(
	[Id]	tinyint			not null identity(1, 1)	primary key,
	[Name]	nvarchar(255)	not null,

	constraint [AK_clSourceCodeExample_Name] unique ([Name])
)
