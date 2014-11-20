--drop procedure [dbo].[spIncrementCounter]

create procedure [dbo].[spIncrementCounter]
(
	@counterId	tinyint,
	@value		int = 1
)
as

begin
	
	update [dbo].[Counters]
	set [Value] = [Value] + @value,
		[TimeStamp] = (dateadd(hour,(-6),getutcdate()))
	where [Id] = @counterId
end



