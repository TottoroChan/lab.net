SELECT OrderId, ShippedDate = 
CASE   
	WHEN ShippedDate IS null THEN 'Not Shipped'
END
FROM Northwind.Orders
WHERE ShippedDate IS null;