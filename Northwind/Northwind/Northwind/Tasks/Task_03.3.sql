SELECT DISTINCT ContactName, Country FROM NorthWind.Customers
WHERE SUBSTRING(Country,1,1) >= 'B' AND SUBSTRING(Country,1,1) <= 'G'
ORDER BY Country;