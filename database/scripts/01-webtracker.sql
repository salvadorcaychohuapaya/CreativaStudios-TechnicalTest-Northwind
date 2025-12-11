-- =============================================
-- WebTracker Table
-- Author: Salvador Caycho
-- =============================================

USE Northwind;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'WebTracker')
BEGIN
    CREATE TABLE dbo.WebTracker (
        Id INT IDENTITY(1,1) NOT NULL,
        URLRequest NVARCHAR(2000) NOT NULL,
        SourceIp NVARCHAR(50) NOT NULL,
        TimeOfAction DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        CONSTRAINT PK_WebTracker PRIMARY KEY CLUSTERED (Id ASC)
    );

    CREATE NONCLUSTERED INDEX IX_WebTracker_TimeOfAction 
        ON dbo.WebTracker(TimeOfAction DESC);
    
    CREATE NONCLUSTERED INDEX IX_WebTracker_SourceIp 
        ON dbo.WebTracker(SourceIp);
END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_InsertWebTracker')
    DROP PROCEDURE dbo.sp_InsertWebTracker;
GO

CREATE PROCEDURE dbo.sp_InsertWebTracker
    @URLRequest NVARCHAR(2000),
    @SourceIp NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.WebTracker (URLRequest, SourceIp, TimeOfAction)
    VALUES (@URLRequest, @SourceIp, GETDATE());
    
    RETURN SCOPE_IDENTITY();
END
GO

INSERT INTO dbo.WebTracker (URLRequest, SourceIp)
VALUES ('/system/init', '127.0.0.1');
GO