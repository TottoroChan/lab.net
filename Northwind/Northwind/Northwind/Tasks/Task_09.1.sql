﻿SELECT CompanyName 
FROM Northwind.Suppliers
WHERE SupplierID IN
(SELECT SupplierID FROM Northwind.Products
WHERE UnitsInStock = 0)

--запросы для проверки
--SELECT * FROM Northwind.Suppliers
--SELECT * FROM Northwind.Products