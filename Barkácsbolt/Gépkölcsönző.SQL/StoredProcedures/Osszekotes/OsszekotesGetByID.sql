CREATE PROCEDURE [dbo].[OsszekotesGetByID]
	
@Id int
AS
BEGIN
SELECT
[dbo].[Osszekotes].[Id],
[dbo].[Osszekotes].[GepID],
[dbo].[Osszekotes].[UgyfelID],
[dbo].[Osszekotes].[Darab],
[dbo].[Osszekotes].[Datum],
[dbo].[Osszekotes].[Meddig],
[dbo].[Osszekotes].[TeljesAr]
FROM
[dbo].[Osszekotes]
where
[dbo].[Osszekotes].[Id] = @Id
END
