SELECT (SELECT LastName+' '+FirstName  
		FROM Northwind.Employees
		WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller',
	COUNT(OrderID) AS 'Amount'
 FROM Northwind.Orders
 GROUP BY EmployeeID
 ORDER BY Amount DESC