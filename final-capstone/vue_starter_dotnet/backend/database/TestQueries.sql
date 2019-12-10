	--test stuff

INSERT INTO recipe(name,  instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category) VALUES ('Test Recipe',  
'Step 1: get a job Step 2: love my homies', 0, 0, 0, 25, 25, 4, 'Advances', 'Asian');

INSERT INTO Ingredient(name) VALUES ('test ing');
INSERT INTO Ingredient(name) VALUES ('test ing 2');


INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (13, 3, 1, 'tablespoon');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (14, 3, 2, 'Cups');

DELETE FROM ingredient_recipe WHERE recipe_id = 2
DELETE FROM recipe WHERE Recipe.id = 3

select * from recipe

-- edit recipe 

DELETE FROM ingredient_recipe where recipe_id = 3 AND ingredient_id = 13

INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (13, 3, 1, 'tablespoon')

UPDATE recipe
SET 
    name = '', 
    instructions = ''
WHERE
    id = 3;



SELECT * FROM recipe
