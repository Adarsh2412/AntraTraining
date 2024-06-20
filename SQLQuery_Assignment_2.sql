USE AdventureWorks2019
GO

-- How many products can you find in the Production.Product table?

SELECT COUNT(ProductID)
FROM Production.Product

--Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductID)
FROM Production.Product
WHERE ProductSubcategoryID is NOT NULL

--How many Products reside in each SubCategory? Write a query to display the results with the following titles.

-- ProductSubcategoryID CountedProducts

SELECT ProductSubcategoryID, COUNT(*) as CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID is NOT NULL
GROUP BY ProductSubcategoryID

--How many products that do not have a product subcategory.

SELECT count(*)
From Production.Product
where ProductSubcategoryID is NULL

--Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT SUM(Quantity)
FROM Production.ProductInventory

--Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

            --   ProductID    TheSum

SELECT productID, sum(Quantity) as TheSum
from Production.ProductInventory
where LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

--Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

        -- Shelf      ProductID    TheSum

SELECT Shelf, productID, sum(Quantity) as TheSum
from Production.ProductInventory
where LocationID = 40
GROUP BY ProductID, Shelf
HAVING SUM(Quantity) < 100

--Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT avg(Quantity)
FROM Production.ProductInventory
where LocationID = 10

-- Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

    -- ProductID   Shelf      TheAvg

SELECT Shelf, productID, avg(Quantity) as TheAvg
from Production.ProductInventory
GROUP BY ProductID, Shelf

--  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

    -- ProductID   Shelf      TheAvg

SELECT Shelf, productID, avg(Quantity) as TheAvg
from Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf

--List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

    -- Color                        Class              TheCount          AvgPrice

SELECT Color,Class,COUNT(*) as TheCount, avg(ListPrice) as AvgPrice
FROM Production.Product
WHERE Color is not NULL AND Class is not NULL
GROUP BY Color, Class

--Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

    -- Country                        Province

SELECT cr.Name as Country, sp.Name as Province
from Person.CountryRegion as cr
join Person. StateProvince as sp 
on cr.CountryRegionCode = sp.CountryRegionCode


--Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--Country                        Province

SELECT cr.Name as Country, sp.Name as Province
from Person.CountryRegion as cr
join Person. StateProvince as sp 
on cr.CountryRegionCode = sp.CountryRegionCode
where cr.Name in ('Germany','Canada')
ORDER BY Country


USE Northwind
GO

--List all Products that has been sold at least once in last 27 years.

SELECT DISTINCT p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(year, -27, GETDATE())

--List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 c.PostalCode, COUNT(od.OrderID) AS OrderCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.PostalCode
ORDER BY COUNT(od.OrderID) DESC

--  List top 5 locations (Zip Code) where the products sold most in last 27 years

SELECT TOP 5 c.PostalCode, COUNT(od.OrderID) AS OrderCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.OrderDate >= DATEADD(year, -27, GETDATE())
GROUP BY c.PostalCode
ORDER BY COUNT(od.OrderID) DESC

-- List all city names and number of customers in that city.     


SELECT c.City, COUNT(c.CustomerID) AS CustomerCount
FROM Customers c
GROUP BY c.City

--List city names which have more than 2 customers, and number of customers in that city

SELECT c.City, COUNT(c.CustomerID) AS CustomerCount
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2

-- List the names of customers who placed orders after 1/1/98 with order date.

SELECT DISTINCT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

-- List the names of all customers with most recent order dates

SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

--  Display the names of all customers  along with the  count of products they bought

SELECT c.ContactName, COUNT(od.ProductID) AS ProductCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName

-- Display the customer ids who bought more than 100 Products with count of products.

SELECT c.CustomerID, COUNT(od.ProductID) AS ProductCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100

-- List all of the possible ways that suppliers can ship their products. Display the results as below

--     Supplier Company Name                Shipping Company Name

SELECT s.CompanyName AS SupplierCompanyName, sh.CompanyName AS ShippingCompanyName
FROM Suppliers s
CROSS JOIN Shippers sh
ORDER BY s.CompanyName, sh.CompanyName

-- Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate

-- Displays pairs of employees who have the same job title.

SELECT e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' ' + e2.LastName AS Employee2, e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID
ORDER BY e1.Title, Employee1, Employee2

-- Display all the Managers who have more than 2 employees reporting to them.

SELECT e1.FirstName + ' ' + e1.LastName AS ManagerName, COUNT(e2.EmployeeID) AS ReportCount
FROM Employees e1
JOIN Employees e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.FirstName, e1.LastName
HAVING COUNT(e2.EmployeeID) > 2

-- Display the customers and suppliers by city. The results should have the following columns

-- City

-- Name

-- Contact Name,

-- Type (Customer or Supplier)

SELECT c.City, c.CompanyName, c.ContactName, 'Customer' AS Type
FROM Customers c
UNION
SELECT s.City, s.CompanyName, s.ContactName, 'Supplier' AS Type
FROM Suppliers s
ORDER BY City, CompanyName