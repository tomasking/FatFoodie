CREATE PROCEDURE [dbo].[spRecipeDelete]
	@RecipeId int
AS
BEGIN

	DELETE FROM Recipe WHERE RecipeId = @RecipeId
	
END