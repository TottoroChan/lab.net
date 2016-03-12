SELECT first.LastName AS UserName, second.LastName AS Boss
FROM Northwind.Employees first, Northwind.Employees second
WHERE second.EmployeeID = first.ReportsTo

-- Не выводится Fuller, потому что он никому ничего не отправляет


--Запрос для проверки
--SELECT LastName, ReportsTo
--FROM Northwind.Employees; 