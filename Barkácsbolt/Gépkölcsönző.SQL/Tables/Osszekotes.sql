CREATE TABLE [dbo].[Osszekotes]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[UgyfelID] INT NOT NULL,
	[GepID] INT NOT NULL,
	[Datum] DateTime NOT NULL,
	[Meddig] DateTime NOT NULL,
	[Darab] INT NOT NULL,
	[TeljesAr] INT NOT NULL
)
