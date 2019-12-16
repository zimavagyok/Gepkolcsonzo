CREATE PROCEDURE [dbo].[CreateOsszekotes]
	@UgyfelID int,
	@GepID int,
	@Darab int,
	@Meddig DateTime,
	@TeljesAr int
AS
BEGIN
INSERT INTO [dbo].[Osszekotes]
(
[UgyfelID],[GepID],[Datum],[Darab],[Meddig],[TeljesAr]
)
VALUES
(
@UgyfelID,@GepID,GETDATE(),@Darab,@Meddig,@TeljesAr
)
END