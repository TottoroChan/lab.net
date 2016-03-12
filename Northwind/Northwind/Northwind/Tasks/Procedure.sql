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
