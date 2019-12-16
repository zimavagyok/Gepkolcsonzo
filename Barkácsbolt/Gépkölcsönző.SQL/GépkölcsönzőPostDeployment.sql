/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*ALTER TABLE 
[dbo].[
ADD CONSTRAINT 
Device__FK_Cascade__Manufacturer
FOREIGN KEY 
(ManufacturerID) 
REFERENCES 
[dbo].[Manufacturer*/

ALTER TABLE
[dbo].[Osszekotes]
ADD CONSTRAINT
Osszekotes_FK_Cascade_Ugyfel
FOREIGN KEY
(UgyfelID)
REFERENCES
[dbo].[Ugyfel].[Id]

ALTER TABLE
[dbo].[Osszekotes]
ADD CONSTRAINT
Osszekotes_FK_Cascade_Gep
FOREIGN KEY
(GepID)
REFERENCES
[dbo].[Gep].[Id]