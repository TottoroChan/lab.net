SELECT OrderId, ShippedDate =
CASE 
	WHEN ShippedDate IS null THEN 'Not Shipped'
	ELSE CONVERT(VARCHAR, ShippedDate, 25)
END FROM Northwind.Orders
WHERE ShippedDate IS null OR ShippedDate > '1998-05-06';