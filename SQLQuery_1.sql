-- -- Section 3: SQL BASICS

-- CREATE DATABASE DotNetCourseDatabase 
-- GO 

-- USE DotNetCourseDatabase
-- GO

-- CREATE SCHEMA TutorialAppSchema
-- GO

-- CREATE TABLE TutorialAppSchema.Computer
-- (
--     -- TableId INT IDENTITY(Starting, Increment By)
--     ComputerId INT IDENTITY(1,1) PRIMARY KEY -- use to make the value always unique
--     , Motherboard NVARCHAR(50) -- NVARCHAR is for Unicode characters
--     , CPUCore INT -- Consider adding a DEFAULT constraint if NULLs should be replaced
--     , HasWifi BIT -- like boolean, 1 or 0.
--     , HasLTE BIT
--     , ReleaseDate DATETIME
--     , Price DECIMAL(18, 4)
--     , VideoCard NVARCHAR(50)

-- )
-- GO

-- SELECT [ComputerId],
--     [Motherboard],
--     -- ISNULL is great for changing NULLs in the output of a SELECT
--     ISNULL([CPUCore], 4),
--     [HasWifi],
--     [HasLTE],
--     [Price],
--     [videoCard],
--     [ReleaseDate] FROM TutorialAppSchema.Computer 
--     ORDER BY HasWifi, ReleaseDate DESC
--     -- ORDER BY ReleaseDate DESC
--     --WHERE 1 = 1


-- USE DotNetCourseDatabase
-- GO

-- -- SET IDENTITY_INSERT TutorialAppSchema.Computer ON    

-- INSERT INTO TutorialAppSchema.Computer (
--     [Motherboard],
--     [CPUCore],
--     [HasWifi],
--     [HasLTE],
--     [Price],
--     [VideoCard],
--     [ReleaseDate]
-- ) VALUES (
--     'Sample-Motherboard2',
--     null,
--     1,
--     0,
--     500,
--     'Sample-VideoCard2',
--     '2025-10-18'
-- )

-- -- DELETE FROM TutorialAppSchema.Computer WHERE ComputerId = 1 -- delete row with ComputerId == 1

-- -- UPDATE TutorialAppSchema.Computer SET CPUCore = 14 WHERE ComputerId = 2
-- UPDATE TutorialAppSchema.Computer SET CPUCore = 14 WHERE ReleaseDate < '2025-10-17'

-- USE DotNetCourseDatabase -- switch to the database 


USE DotNetCourseDatabase
GO

TRUNCATE TABLE TutorialAppSchema.Computer -- removes all rows but keeps the table structure

SELECT * FROM TutorialAppSchema.Computer --WHERE Motherboard = 'Fatz'