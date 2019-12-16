CREATE PROCEDURE [dbo].[GepDelete]
	@Id int
AS
BEGIN
DELETE [dbo].[Gep]
WHERE [dbo].[Gep].[Id] = @Id
END
