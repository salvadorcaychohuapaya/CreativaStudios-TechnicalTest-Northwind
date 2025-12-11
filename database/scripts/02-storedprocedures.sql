-- =============================================
-- Stored Procedures GetCustomersByCountry GetOrdersByCustomerId
-- Author: Salvador Caycho
-- =============================================

USE Northwind;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetCustomersByCountry')
    DROP PROCEDURE sp_GetCustomersByCountry;
GO

CREATE PROCEDURE sp_GetCustomersByCountry
    @Country NVARCHAR(50),
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CustomerID, 
        CompanyName, 
        ContactName, 
        Country, 
        Phone, 
        Fax,
        COUNT(*) OVER() AS TotalRecords
    FROM Customers
    WHERE Country = @Country
    ORDER BY ContactName
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetOrdersByCustomerId')
    DROP PROCEDURE sp_GetOrdersByCustomerId;
GO

CREATE PROCEDURE sp_GetOrdersByCustomerId
    @CustomerID NVARCHAR(10),
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        OrderID, 
        CustomerID, 
        OrderDate, 
        ShippedDate,
        COUNT(*) OVER() AS TotalRecords
    FROM Orders
    WHERE CustomerID = @CustomerID
    ORDER BY ShippedDate DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
GO