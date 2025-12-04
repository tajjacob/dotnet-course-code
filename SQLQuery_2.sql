USE DotNetCourseDatabase;
GO

SELECT * 
  FROM TutorialAppSchema.Users;

SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[Users].[Email],
[Users].[Gender],
[Users].[Active] 
FROM TutorialAppSchema.Users AS Users
WHERE Users.Active = 1 -- need to put WHERE clause before ORDER BY
ORDER BY Users.UserId DESC

SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[Users].[Email],
[Users].[Gender],
[Users].[Active],
[UserJobInfo].[JobTitle],
[UserJobInfo].[Department] 
FROM TutorialAppSchema.Users AS Users
-- INNER JOIN
LEFT JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo
    ON Users.UserId = UserJobInfo.UserId -- explanation: joining two tables on UserId 
WHERE Users.Active = 1 
ORDER BY Users.UserId DESC

SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[UserJobInfo].[JobTitle],
[UserJobInfo].[Department],
[UserSalary].[UserId],
[UserSalary].[Salary],
[Users].[Email],
[Users].[Gender],
[Users].[Active]
FROM TutorialAppSchema.Users AS Users
-- INNER JOIN
JOIN TutorialAppSchema.UserSalary AS UserSalary -- join meaning: only those records that have matching UserId in both tables
    ON UserSalary.UserId = Users.UserId 
    LEFT JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo -- left join meaning: all records from left table (Users) and matching records from right table (UserJobInfo)
        ON UserJobInfo.UserId = Users.UserId 
WHERE Users.Active = 1 
ORDER BY Users.UserId DESC



DELETE FROM TutorialAppSchema.UserJobInfo
WHERE UserId > 500
         
         
-- SELECT  [UserId]
--         , [FirstName]
--         , [LastName]
--         , [Email]
--         , [Gender]
--         , [Active]
--   FROM  TutorialAppSchema.Users;

-- SELECT  [UserId]
--         , [Salary]
--   FROM  TutorialAppSchema.UserSalary;

-- SELECT  [UserId]
--         , [JobTitle]
--         , [Department]
--   FROM  TutorialAppSchema.UserJobInfo;
