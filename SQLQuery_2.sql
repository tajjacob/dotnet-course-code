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
         
DELETE FROM TutorialAppSchema.UserSalary
WHERE UserId BETWEEN 250 AND 750       -- 501 rows deleted, when we use BETWEEN it includes both boundary values

SELECT * FROM TutorialAppSchema.UserSalary
WHERE EXISTS 
(SELECT * FROM TutorialAppSchema.UserJobInfo AS UserJobInfo 
WHERE UserJobInfo.UserId = UserSalary.UserId)
AND UserId <> 7 -- explanation: excluding UserId 7 from the result set
-- Difference between WHERE and WHERE EXISTS
-- WHERE filters based on column values
-- WHERE EXISTS filters based on existence of related records in another table


SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary
-- UNION -- EXPLANATION: UNION removes duplicates
UNION ALL -- EXPLANATION: UNION ALL includes duplicates
SELECT [UserId],
[Salary] FROM TutorialAppSchema.UserSalary

CREATE CLUSTERED INDEX cix_UserSalary_UserId ON TutorialAppSchema.UserSalary (UserId)
-- Explanation: Creating clustered index on UserId column of UserSalary table to improve query performance
-- Note: Clustered index sorts and stores the data rows in the table based on the indexed column

CREATE NONCLUSTERED INDEX ix_UserSalary_Salary ON TutorialAppSchema.UserSalary (Salary)
-- Explanation: Creating non-clustered index on Salary column of UserSalary table to improve query performance
-- Note: Non-clustered index creates a separate structure from the data rows that points to the data rows in the table 

CREATE NONCLUSTERED INDEX ix_UserJobInfo_JobTitle ON TutorialAppSchema.UserJobInfo (JobTitle) INCLUDE (Department)
-- non-clustered index with include explanation: Creating non-clustered index on JobTitle column of UserJobInfo table with Department column included
-- Note: INCLUDE clause adds additional columns to the index to cover more queries 

CREATE NONCLUSTERED INDEX ix_Users_JobTitle 
ON TutorialAppSchema.Users(Active) INCLUDE ([Email], [FirstName], [LastName]) 
WHERE Active = 1
-- filtered index explanation: Creating filtered non-clustered index on Active column of Users table with additional columns Email, FirstName, LastName included
-- Note: Filtered index improves query performance for queries that filter on Active = 1

SELECT ISNULL([UserJobInfo].[Department], 'No Department Listed') AS Department,
SUM([UserSalary].[Salary]) AS Salary,
MIN([UserSalary].[Salary]) AS MinSalary,
MAX([UserSalary].[Salary]) AS MaxSalary,
AVG([UserSalary].[Salary]) AS AvgSalary,
COUNT (*) AS PeopleInDepartment, -- counting number of users in each department
STRING_AGG(Users.UserId, ', ') AS UserIds -- concatenating UserIds in each department. concatenating meaning joining multiple values into a single string with a separator
FROM TutorialAppSchema.Users AS Users
-- INNER JOIN
JOIN TutorialAppSchema.UserSalary AS UserSalary -- join meaning: only those records that have matching UserId in both tables
    ON UserSalary.UserId = Users.UserId 
    LEFT JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo -- left join meaning: all records from left table (Users) and matching records from right table (UserJobInfo)
        ON UserJobInfo.UserId = Users.UserId 
WHERE Users.Active = 1 
GROUP BY [UserJobInfo].[Department]
ORDER BY ISNULL([UserJobInfo].[Department], 'No Department Listed')  DESC -- ordering by Department in descending order, if want to order by Salary use ORDER BY Salary DESC


SELECT [Users].[UserId],
[Users].[FirstName] + ' ' + [Users].[LastName] AS FullName,
[UserJobInfo].[JobTitle],
[UserJobInfo].[Department],
DepartmentAverage.AvgSalary,
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
    -- OUTER APPLY ( -- explanation: OUTER APPLY works like a LEFT JOIN but allows to join with a table-valued function or subquery that can reference columns from the left table
                  CROSS APPLY ( -- explanation: CROSS APPLY works like an INNER JOIN but allows to join with a table-valued function or subquery that can reference columns from the left table
                  SELECT ISNULL([UserJobInfo2].[Department], 'No Department Listed') AS Department,
            AVG([UserSalary2].[Salary]) AS AvgSalary
            FROM TutorialAppSchema.UserSalary AS UserSalary2 -- join meaning: only those records that have matching UserId in both tables
              
                LEFT JOIN TutorialAppSchema.UserJobInfo AS UserJobInfo2 -- left join meaning: all records from left table (Users) and matching records from right table (UserJobInfo)
                    ON UserJobInfo2.UserId = UserSalary2.UserId 
            -- WHERE ISNULL([UserJobInfo2].[Department], 'No Department Listed') = ISNULL([UserJobInfo].[Department], 'No Department Listed') -- explanation: correlating subquery to get average salary for the same department as the outer query
            WHERE [UserJobInfo2].[Department] = [UserJobInfo].[Department]
            GROUP BY [UserJobInfo2].[Department]
    ) AS DepartmentAverage   
WHERE Users.Active = 1 
ORDER BY Users.UserId DESC


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
