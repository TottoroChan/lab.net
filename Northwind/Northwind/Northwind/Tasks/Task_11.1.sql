SELECT ContactName 
FROM Northwind.Customers
WHERE NOT EXISTS 
(SELECT CustomerID 
FROM Northwind.Orders
WHERE  CustomerID = Customers.CustomerID) 
