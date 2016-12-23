CREATE PROCEDURE [dbo].[spRecipeInsert]
	@Name varchar(100)	
AS
BEGIN

	INSERT INTO Recipe(Name) Values(@Name)

	SELECT CAST(SCOPE_IDENTITY() as int)
END