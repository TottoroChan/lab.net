SELECT DISTINCT ContactName, Country FROM NorthWind.Customers
WHERE SUBSTRING(Country,1,1) BETWEEN 'B' AND 'G'
ORDER BY Country;