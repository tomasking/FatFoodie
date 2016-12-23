CREATE PROCEDURE [dbo].[spRecipeGet]
	@recipeId int	
AS
	SELECT RecipeId, Name FROM Recipe WHERE RecipeId = @recipeId

RETURN 0
