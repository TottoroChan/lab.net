USE Northwind;
GO
--13.1
CREATE PROCEDURE Northwind.GreatestOrders
	@top int,
	@year int
AS
BEGIN
SELECT TOP(@top) OrderID, e.FirstName + ' '+ e.LastName AS Person,  Price 
FROM Northwind.Employees AS e 
INNER JOIN 
( SELECT odmax.EmployeeID, OrderID, MAX(odmax.Price) AS Price 
FROM 
( SELECT o.EmployeeID, od.OrderID AS OrderID, 
SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS Price 
FROM Northwind.[Order Details] AS od 
INNER JOIN Northwind.orders AS o 
ON o.OrderID = od.OrderID AND @year = YEAR(OrderDate)
GROUP BY od.OrderID, o.EmployeeID ) AS odmax 
GROUP BY odmax.EmployeeID, odmax.OrderID) AS max 
ON max.EmployeeID = e.EmployeeID
END
GO

--13.2
CREATE PROCEDURE Northwind.ShippedOrdersDiff
	@shippedDelay int
AS
BEGIN
SELECT OrderID, CAST(OrderDate AS DATE) AS OrderDate, CAST(ShippedDate AS DATE) AS ShippedDate,
DAY(ShippedDate - OrderDate) AS ShippedDelay
FROM Northwind.Orders
WHERE DAY(ShippedDate - OrderDate) > @shippedDelay OR DAY(ShippedDate - OrderDate) is null
ORDER BY DAY(ShippedDate - OrderDate)
END
GO

--13.4
CREATE FUNCTION Northwind.IsBoss (@id int)
RETURNS BIT
AS 
BEGIN
DECLARE @flag bit
SELECT @flag = CASE WHEN 
(SELECT COUNT(EmployeeID) FROM Northwind.Employees 
WHERE @id = ReportsTo) = 0 THEN 0 ELSE 1 
END
RETURN(@flag)
END
GO

--13.3
CREATE PROCEDURE Northwind.SubordinationInfo
	@id int
AS
BEGIN
DECLARE @name nvarchar(40)
SET @name = 
(SELECT FirstName +' '+ LastName 
FROM Northwind.Employees
WHERE EmployeeID = @id)
PRINT @name
DECLARE @SubOrdinators int 
SET @SubOrdinators = (SELECT COUNT(EmployeeID)  
FROM Northwind.Employees
WHERE ReportsTo = @id)
PRINT N'---Subordinators---'
DECLARE @Sub int
SET @Sub = 1
DECLARE @SubName nvarchar(40)
WHILE @Sub <= @SubOrdinators
BEGIN    
SET @SubName =
(SELECT TOP(1) FirstName +' '+ LastName 
FROM Northwind.Employees
WHERE EmployeeID IN (SELECT TOP(@Sub) EmployeeID 
FROM  Northwind.Employees
ORDER BY EmployeeID DESC)
ORDER BY EmployeeID ASC)
SET @Sub = @Sub + 1                    
PRINT @SubName
END
END
