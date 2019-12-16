CREATE PROCEDURE [dbo].[GepAvailable]
	@Id int
AS
BEGIN
SELECT
[dbo].[Gep].[Mennyiseg]
FROM
[dbo].[Gep]
WHERE
[dbo].[Gep].[Id] = @Id
END