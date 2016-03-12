SELECT ContactName AS Person, 'Customer' AS Type, City
FROM Northwind.Customers 
WHERE EXISTS 
(SELECT City 
FROM Northwind.Employees
WHERE City = Customers.City)
UNION 
SELECT FirstName+' '+LastName AS Person, 'Seller' AS Type, City
FROM Northwind.Employees
WHERE EXISTS 
(SELECT City 
FROM Northwind.Customers
WHERE Employees.City = City)