create table [dbo].[Counters]
(
	[Id]			tinyint			not null	primary key identity(1,1),
	[Name]			nvarchar(255)	not null,
	[Value]			int				not null,
	[TimeStamp]		datetime2		not null
)