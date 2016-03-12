--13.1 
EXEC Northwind.GreatestOrders 5, 1998

EXEC Northwind.GreatestOrders 4, 1996

--Проверочный запрос
SELECT OrderID, e.FirstName , ' ', e.LastName AS Person,  Price 
FROM northwind.employees AS e 
INNER JOIN 
( SELECT odmax.EmployeeID, OrderID, MAX(odmax.Price) AS Price 
FROM 
( SELECT o.EmployeeID, od.OrderID AS OrderID, 
SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS Price 
FROM Northwind.[Order Details] AS od 
INNER JOIN Northwind.orders AS o 
ON o.OrderID = od.OrderID 
GROUP BY od.OrderID, o.EmployeeID ) AS odmax 
GROUP BY odmax.EmployeeID, odmax.OrderID) AS max 
ON max.EmployeeID = e.EmployeeID
ORDER BY Person


--13.2
EXEC Northwind.ShippedOrdersDiff 35

EXEC Northwind.ShippedOrdersDiff 4

--13.4
SELECT Northwind.IsBoss(1) AS Boss
SELECT Northwind.IsBoss(2) AS Boss
SELECT Northwind.IsBoss(3) AS Boss
SELECT Northwind.IsBoss(4) AS Boss
SELECT Northwind.IsBoss(5) AS Boss
SELECT Northwind.IsBoss(6) AS Boss
SELECT Northwind.IsBoss(7) AS Boss
SELECT Northwind.IsBoss(8) AS Boss
SELECT Northwind.IsBoss(9) AS Boss

--13.3
EXEC Northwind.SubordinationInfo 2
EXEC Northwind.SubordinationInfo 5
EXEC Northwind.SubordinationInfo 8