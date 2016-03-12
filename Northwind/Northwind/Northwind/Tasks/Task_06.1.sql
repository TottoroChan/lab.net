SELECT DATEPART(yyyy,ShippedDate) AS Year, COUNT(OrderID) AS Total
FROM Northwind.Orders
GROUP BY  DATEPART(yyyy, ShippedDate);