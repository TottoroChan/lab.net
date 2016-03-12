SELECT LastName + ' ' + FirstName
FROM Northwind.Employees as e
WHERE 150 <=
(Select COUNT(OrderID)
FROM Northwind.Orders as o
WHERE e.EmployeeID = o.EmployeeID)



--Запрос для проверки, выводит список всех продавцов и их продажи
--SELECT c.LastName, Orders 
--FROM Northwind.Employees AS c LEFT OUTER JOIN
--(Select EmployeeID, COUNT(OrderID) as Orders
--FROM Northwind.Orders 
--GROUP BY EmployeeID
--) AS o ON c.EmployeeID  = o.EmployeeID
--ORDER BY Orders;

--SELECT * FROM Northwind.Employees
--SELECT * FROM Northwind.Orders