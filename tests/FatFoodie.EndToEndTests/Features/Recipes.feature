Feature: Recipes

Scenario: Returns empty list of recipes if none exist
	When I get all recipes
	Then I should get an empty list of recipes
