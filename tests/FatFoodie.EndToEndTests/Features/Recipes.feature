Feature: Recipes

Scenario: Returns empty list of recipes if none exist
	When I get all recipes
	Then I should get an empty list of recipes

Scenario: Returns added recipe after I have added one
	When I add a new recipe
	Then I should get the recipe returned

Scenario: Returns an existing recipe
	Given I have added a recipe
	When I get the recipe by Id
	Then I should get the recipe returned

