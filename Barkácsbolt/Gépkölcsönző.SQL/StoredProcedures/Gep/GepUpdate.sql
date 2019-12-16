CREATE PROCEDURE [dbo].[GepUpdate]
	@Id INT,
	@Marka NVARCHAR(255),
	@Modell NVARCHAR(255),
	@Teljesitmeny INT,
	@Suly FLOAT,
	@Mennyiseg int,
	@Ar int,
	@Kep NVARCHAR(255)
AS
BEGIN
UPDATE [dbo].[Gep]
SET
[Marka] = @Marka,
[Modell] = @Modell,
[Teljesitmeny] = @Teljesitmeny,
[Suly] = @Suly,
[Mennyiseg] = @Mennyiseg,
[Ar] = @Ar,
[Kep] = @Kep
WHERE
[dbo].[Gep].[Id] = @Id
END