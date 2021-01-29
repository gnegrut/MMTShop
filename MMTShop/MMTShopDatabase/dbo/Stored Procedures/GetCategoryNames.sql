-- =============================================
-- Author:		<Author Gheorghita Negrut>
-- Create date: <Create Date 29/01/2021>
-- Description:	<Description The SP returns available category names>
-- =============================================
CREATE PROCEDURE GetCategoryNames 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Name] FROM [dbo].[Category]
END
