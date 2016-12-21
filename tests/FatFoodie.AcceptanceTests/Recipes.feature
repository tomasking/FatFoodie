Feature: Recipes
	
Scenario: I can retrieve a recipe list
	Given I have recipes previously saved
	When I get a list of all recipes
	Then all the recipes are returned
