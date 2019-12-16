CREATE PROCEDURE [dbo].[CreateGep]
	@Marka NVARCHAR(255),
	@Modell NVARCHAR(255),
	@Teljesitmeny INT,
	@Suly FLOAT,
	@Mennyiseg int,
	@Ar INT,
	@Kep NVARCHAR(255)
AS
BEGIN
INSERT INTO [dbo].[Gep]
(
[Marka],[Modell],[Teljesitmeny],[Suly],[Mennyiseg],[Ar],[Kep]
)
VALUES
(
@Marka,@Modell,@Teljesitmeny,@Suly,@Mennyiseg,@Ar,@Kep
)

SELECT CONVERT(int,SCOPE_IDENTITY());
END
