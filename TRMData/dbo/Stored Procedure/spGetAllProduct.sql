CREATE PROCEDURE [dbo].[spGetAllProduct]
AS
BEGIN
	SELECT Id, ProductName, Description, RetailPrice, QuantityInStock, IsTaxable
	FROM dbo.Product
	ORDER BY ProductName
END
