SELECT LastName, TerritoryDescription
FROM Northwind.Employees AS e INNER JOIN Northwind.EmployeeTerritories AS et
ON e.EmployeeID = et.EmployeeID
INNER JOIN Northwind.Territories AS t ON t.TerritoryID = et.TerritoryID
INNER JOIN Northwind.Region AS r ON r.RegionID = t.RegionID
WHERE r.RegionDescription = 'Western';


--Запросы для проверки
--SELECT * FROM Northwind.Employees
--SELECT * FROM Northwind.Region
--SELECT * FROM Northwind.EmployeeTerritories
--SELECT TerritoryDescription, TerritoryID FROM Northwind.Territories
--WHERE RegionID = 2;