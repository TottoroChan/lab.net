SELECT c.ContactName, Orders 
FROM Northwind.Customers AS c LEFT OUTER JOIN
(SELECT CustomerID, COUNT(OrderID) AS Orders
FROM Northwind.Orders 
GROUP BY CustomerID
) AS o
ON c.CustomerID  = o.CustomerID
ORDER BY Orders;


--запросы для проверки
--SELECT * FROM Northwind.Customers
--SELECT * FROM Northwind.Orders 