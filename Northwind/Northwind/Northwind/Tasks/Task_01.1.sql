SELECT OrderId, ShippedDate, ShipVia FROM Northwind.Orders
WHERE ShipVia >= 2 AND
	ShippedDate >= '1998-05-06';

-- Результаты с null не выводятся потому что неизвестно 
-- было это до нужной даты или нет