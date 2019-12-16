CREATE PROCEDURE [dbo].[GepGetByID]
	@Id int
AS
BEGIN
SELECT
[dbo].[Gep].[Id],
[dbo].[Gep].[Marka],
[dbo].[Gep].[Modell],
[dbo].[Gep].[Teljesitmeny],
[dbo].[Gep].[Suly],
[dbo].[Gep].[Mennyiseg],
[dbo].[Gep].[Ar],
[dbo].[Gep].[Kep]
FROM
[dbo].[Gep]
WHERE 
[dbo].[Gep].[Id] = @Id
END