USE Northwind
GO

-- List all cities that have both Employees and Customers.

SELECT DISTINCT City
FROM Employees
WHERE City IN (SELECT DISTINCT City FROM Customers)

-- List all cities that have Customers but no Employee.

-- a.      Use sub-query

-- b.      Do not use sub-query

SELECT DISTINCT City
FROM Customers
WHERE City NOT IN (SELECT DISTINCT City FROM Employees)

SELECT DISTINCT C.City
FROM Customers C
LEFT JOIN Employees E ON C.City = E.City
WHERE E.City IS NULL

-- List all products and their total order quantities throughout all orders.

SELECT P.ProductName, SUM(OD.Quantity) AS TotalQuantity
FROM [Order Details] OD
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY P.ProductName

-- List all Customer Cities and total products ordered by that city

SELECT C.City, SUM(OD.Quantity) AS TotalProductsOrdered
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY C.City

-- List all Customer Cities that have at least two customers.

-- a.      Use union

-- b.      Use sub-query and no union

SELECT City
FROM (
    SELECT City, COUNT(CustomerID) AS CustomerCount
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >= 2
) AS CustomerCities
UNION
SELECT City
FROM (
    SELECT City
    FROM Customers
    GROUP BY City
    HAVING COUNT(CustomerID) >= 2
) AS CustomerCities

SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2

-- List all Customer Cities that have ordered at least two different kinds of products.

SELECT C.City
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
JOIN [Order Details] OD ON O.OrderID = OD.OrderID
GROUP BY C.City
HAVING COUNT(DISTINCT OD.ProductID) >= 2

-- List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT C.CustomerID, C.CompanyName
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
WHERE O.ShipCity <> C.City

-- List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

WITH ProductQuantities AS (
    SELECT P.ProductID, P.ProductName, AVG(OD.UnitPrice) AS AvgPrice, SUM(OD.Quantity) AS TotalQuantity
    FROM [Order Details] OD
    JOIN Products P ON OD.ProductID = P.ProductID
    GROUP BY P.ProductID, P.ProductName
),
TopProducts AS (
    SELECT TOP 5 ProductID, ProductName, AvgPrice, TotalQuantity
    FROM ProductQuantities
    ORDER BY TotalQuantity DESC
),
CityQuantities AS (
    SELECT O.CustomerID, C.City, OD.ProductID, SUM(OD.Quantity) AS CityTotalQuantity
    FROM Orders O
    JOIN Customers C ON O.CustomerID = C.CustomerID
    JOIN [Order Details] OD ON O.OrderID = OD.OrderID
    GROUP BY O.CustomerID, C.City, OD.ProductID
)
SELECT TP.ProductName, TP.AvgPrice, CQ.City, TP.TotalQuantity
FROM TopProducts TP
JOIN CityQuantities CQ ON TP.ProductID = CQ.ProductID
ORDER BY TP.TotalQuantity DESC

-- List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

-- b.      Do not use sub-query

SELECT DISTINCT City
FROM Employees
WHERE City NOT IN (SELECT DISTINCT ShipCity FROM Orders)

SELECT DISTINCT E.City
FROM Employees E
LEFT JOIN Orders O ON E.City = O.ShipCity
WHERE O.ShipCity IS NULL

-- List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH EmployeeOrderCount AS (
    SELECT E.City, COUNT(O.OrderID) AS OrderCount
    FROM Employees E
    JOIN Orders O ON E.EmployeeID = O.EmployeeID
    GROUP BY E.City
),
CustomerOrderQuantity AS (
    SELECT C.City, SUM(OD.Quantity) AS TotalQuantity
    FROM Orders O
    JOIN Customers C ON O.CustomerID = C.CustomerID
    JOIN [Order Details] OD ON O.OrderID = OD.OrderID
    GROUP BY C.City
)
SELECT EOC.City
FROM EmployeeOrderCount EOC
JOIN CustomerOrderQuantity COQ ON EOC.City = COQ.City
ORDER BY EOC.OrderCount DESC, COQ.TotalQuantity DESC



-- How do you remove the duplicates record of a table?

-- First we need to decide which columns we are checking for duplicates. Lets say we take column1, column2, column3 here. Then this works. But we need to make sure that what we are deleting is correct, so its best to first use SELECT instead of DELETE to verify the data.

-- WITH CTE AS (
--     SELECT *,
--            ROW_NUMBER() OVER (PARTITION BY column1, column2, column3 ORDER BY (SELECT NULL)) AS rn
--     FROM YourTable
-- )
-- DELETE FROM CTE
-- WHERE rn > 1;