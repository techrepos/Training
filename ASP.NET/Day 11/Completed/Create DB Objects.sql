

/****** Object: Table [dbo].[Employee] Script Date: 3/3/2021 10:25:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Employee];


GO
CREATE TABLE [dbo].[Employee] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [LastName]     VARCHAR (50)  NOT NULL,
    [EmailAddress] VARCHAR (100) NULL,
    [WorkLocation] VARCHAR (50)  NULL,
    [HomeAddress]  VARCHAR (50)  NULL,
    [Country]      VARCHAR (50)  NULL
);



/****** Object: SqlProcedure [dbo].[CreateEmployee] Script Date: 3/3/2021 10:26:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[CreateEmployee];


GO

CREATE PROC dbo.CreateEmployee(
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@EmailAddress VARCHAR(100),
@Country VARCHAR(50),
@WorkLocation VARCHAR(50),
@HomeAddress VARCHAR(50),
@EmployeeId INT OUTPUT
)
AS

BEGIN
	
	INSERT Employee(FirstName, LastName, EmailAddress, Country, WorkLocation, HomeAddress)
	VALUES(@FirstName, @LastName, @EmailAddress, @Country, @WorkLocation, @HomeAddress)

	SET @EmployeeId = SCOPE_IDENTITY();



END


GO

/****** Object: SqlProcedure [dbo].[GetEmployees] Script Date: 3/3/2021 10:26:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetEmployees];


GO
CREATE PROC dbo.GetEmployees
(
	@EmployeeId INT = NULL
)
AS
BEGIN
	SELECT Id, FirstName, LastName, EmailAddress , Country, WorkLocation, HomeAddress
	FROM Employee
	WHERE @EmployeeId IS NULL OR Id = @EmployeeId
END
GO