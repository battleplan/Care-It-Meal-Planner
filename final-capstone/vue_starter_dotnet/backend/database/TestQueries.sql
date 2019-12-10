	--test stuff

INSERT INTO recipe(name,  instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category) VALUES ('Test Recipe',  
'Step 1: fuck money Step 2: get bitches', 0, 0, 0, 25, 25, 4, 'Advances', 'Asian');

INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (1, 3, 1, 'tablespoon');

DELETE FROM ingredient_recipe WHERE recipe_id = 3
DELETE FROM recipe WHERE Recipe.id = 3