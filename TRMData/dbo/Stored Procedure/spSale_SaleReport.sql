CREATE PROCEDURE [dbo].[spSale_SaleReport]
AS
begin
	set nocount on;

	SELECT [S].[SaleDate], [S].[SubTotal], [S].[Tax], [S].[Total], u.FirstName, u.LastName, u.EmailAddress
	from [dbo].[Sale] as S
	inner join [dbo].[User] as U
	on s.CashierId = u.Id
end
