-- =============================================
-- Author:		<Author Gheorghita Negrut>
-- Create date: <Create Date 29/01/2021>
-- Description:	<Description The SP returns the featured products based on featured SKU ranges>
-- =============================================
CREATE PROCEDURE [dbo].[GetFeaturedProducts] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		P.ProductId, 
		P.SKU, 
		P.[Name], 
		P.[Description], 
		P.Price,
		FC.[Name] AS 'Category'
	FROM [dbo].[Product] P
	JOIN
	(SELECT C.CategoryId, C.[Name]
	FROM [dbo].[Category] C
	JOIN [dbo].[FeaturedProductRange] FPR ON C.ProductSKURange = FPR.ProductSKURange) FC ON P.CategoryId = FC.CategoryId
	ORDER BY FC.CategoryId, P.SKU
END
