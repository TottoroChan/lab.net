SELECT DISTINCT first.City, first.CustomerID,  second.CustomerID
FROM Northwind.Customers first, Northwind.Customers second
WHERE first.City = second.City
AND first.CustomerID < second.CustomerID;




--запрос для проверки городов, которые встречаются 
--больше 1 раза в таблице покупателей.
--SELECT DISTINCT City
--FROM Northwind.Customers
--GROUP BY City
--HAVING COUNT(City) > 1; 