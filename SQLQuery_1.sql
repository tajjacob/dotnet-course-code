-- Section 3: SQL BASICS

CREATE DATABASE DotNetCourseDatabase 
GO 

USE DotNetCourseDatabase
GO

CREATE SCHEMA TutorialAppSchema
GO

CREATE TABLE TutorialAppSchema.Computer
(
    -- TableId INT IDENTITY(Starting, Increment By)
    ComputerId INT IDENTITY(1,1) PRIMARY KEY -- use to make the value always unique
    -- , Motherboard CHAR(10) -- 'x'
    -- , Motherboard VARCHAR(10) -- 'x' unicode
    , Motherboard NVARCHAR(50) -- 'x' nonunicode
    , CPUCore INT 
    , HasWifi BIT -- like boolean, 1 or 0.
    , HasLTE BIT
    , ReleaseDate DATETIME
    , Price DECIMAL(18, 4)
    , videoCard NVARCHAR(50)

)
GO

ALTER TABLE TutorialAppSchema.Computer
ADD ReleaseDate DATETIME;

SELECT [ComputerId],
    [Motherboard],
    ISNULL([CPUCore], 4),
    [HasWifi],
    [HasLTE],
    [Price],
    [videoCard],
    [ReleaseDate] FROM TutorialAppSchema.Computer 
    ORDER BY HasWifi, ReleaseDate DESC
    -- ORDER BY ReleaseDate DESC
    --WHERE 1 = 1


-- SET IDENTITY_INSERT TutorialAppSchema.Computer ON    

INSERT INTO TutorialAppSchema.Computer (
    [Motherboard],
    [CPUCore],
    [HasWifi],
    [HasLTE],
    [Price],
    [videoCard],
    [ReleaseDate]
) VALUES (
    'Sample-Motherboard2',
    null,
    1,
    0,
    500,
    'Sample-VideoCard2',
    '2025-10-18'
)

-- DELETE FROM TutorialAppSchema.Computer WHERE ComputerId = 1 -- delete row with ComputerId == 1

-- UPDATE TutorialAppSchema.Computer SET CPUCore = 14 WHERE ComputerId = 2
UPDATE TutorialAppSchema.Computer SET CPUCore = 14 WHERE ReleaseDate < '2025-10-17'

