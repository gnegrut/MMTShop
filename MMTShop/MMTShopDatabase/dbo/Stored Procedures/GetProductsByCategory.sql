-- =============================================
-- Author:		<Author Gheorghita Negrut>
-- Create date: <Create 29/01/2021>
-- Description:	<Description The SP returnes the products available for the specified category Id>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductsByCategory]
	@CategoryId SMALLINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT P.ProductId, 
			P.SKU, 
			P.[Name], 
			P.[Description], 
			P.Price, 
			C.[Name] AS 'Category'
	FROM [dbo].[Product] P
	JOIN [dbo].[Category] C ON P.CategoryId = C.CategoryId
	WHERE P.CategoryId = @CategoryId
	ORDER BY SKU
END
