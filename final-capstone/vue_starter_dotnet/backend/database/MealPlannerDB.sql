	
	USE master;
	GO

	IF EXISTS (SELECT * FROM sys.databases where name='MealPlanner')
	DROP DATABASE MealPlanner;
	GO

	CREATE DATABASE MealPlanner;
	GO

	USE MealPlanner
	GO

	CREATE TABLE Recipe (
	id integer IDENTITY NOT NULL,
	name nvarchar(64) NOT NULL,
	author nvarchar(64) DEFAULT 'anon',
	instructions nvarchar(max) NOT NULL,
	vegan bit DEFAULT 0,
	vegetarian bit DEFAULT 0,
	gluten_free bit DEFAULT 0,
	cook_time_in_mins integer NOT NULL,
	prep_time_in_mins integer NOT NULL,
	serves integer,
	difficulty nvarchar(30),
	category nvarchar(20) NOT NULL,
	img_url nvarchar(MAX),
	CONSTRAINT pk_recipe_id PRIMARY KEY (id)
	);

	CREATE TABLE Ingredient (
	id integer IDENTITY NOT NULL,
	name nvarchar(100) NOT NULL,
	CONSTRAINT pk_ingredient_id PRIMARY KEY (id)
	); 

	CREATE TABLE Pantry (
	ingredient_id integer NOT NULL,
	username nvarchar(64) NOT NULL,
	unit_of_measurement nvarchar(15) NOT NULL,
	quantity nvarchar(15) NOT NULL,
	CONSTRAINT pk_pantry_ingredient_id_username PRIMARY KEY (ingredient_id, username)
	);

	CREATE TABLE Shopping_List (
	ingredient_id integer NOT NULL,
	username nvarchar(64) NOT NULL,
	unit_of_measurement nvarchar(15) NOT NULL,
	quantity nvarchar(15) NOT NULL,
	CONSTRAINT pk_shopping_list_ingredient_id_username PRIMARY KEY (ingredient_id, username)
	);

	CREATE TABLE Meal_Plan (
	recipe_id integer NOT NULL,
	username nvarchar(64) NOT NULL,
	meal_slot smallint NOT NULL, --between 0 and 5 breakfast, lunch, dinner, snack, Not Specified  
	meal_date Date NOT NULL,
	CONSTRAINT pk_meal_plan_username_meal_date_meal_slot_recipe_id PRIMARY KEY (username, meal_date, meal_slot, recipe_id)
	);

	CREATE TABLE Account (
	id integer IDENTITY,
	username nvarchar(64) NOT NULL,
	password nvarchar(64) NOT NULL,
	display_name nvarchar(64),
	salt varchar(50)	NOT NULL,
	role varchar(50) default('user'),
	CONSTRAINT pk_user_username PRIMARY KEY (username)
	);

	CREATE TABLE user_recipe (
	username nvarchar(64) NOT NULL,
	recipe_id integer NOT NULL,
	favorite bit NOT NULL,
	CONSTRAINT pk_username_recipe_id PRIMARY KEY (recipe_id, username)
	);

	CREATE TABLE ingredient_recipe (
	recipe_id integer NOT NULL,
	ingredient_id INTEGER NOT NULL,
	quantity nvarchar(15) NOT NULL,
	unit_of_measurement nvarchar(15),
	CONSTRAINT pk_ingredient_id__recipe_id PRIMARY KEY (recipe_id, ingredient_id)
	);
	
	-- ADD FOREIGN KEYS

	ALTER TABLE ingredient_recipe
	ADD FOREIGN KEY (recipe_id)
	REFERENCES recipe(id);

	ALTER TABLE ingredient_recipe
	ADD FOREIGN KEY (ingredient_id)
	REFERENCES ingredient(id);

	ALTER TABLE recipe
	ADD FOREIGN KEY (author)
	REFERENCES account(username);

	ALTER TABLE pantry
	ADD FOREIGN KEY (ingredient_id)
	REFERENCES ingredient(id);

	ALTER TABLE pantry
	ADD FOREIGN KEY (username)
	REFERENCES account(username);

	ALTER TABLE Shopping_List
	ADD FOREIGN KEY (ingredient_id)
	REFERENCES ingredient(id);

	ALTER TABLE Shopping_List
	ADD FOREIGN KEY (username)
	REFERENCES account(username);

	ALTER TABLE meal_plan
	ADD FOREIGN KEY (recipe_id)
	REFERENCES recipe(id)

	ALTER TABLE meal_plan
	ADD FOREIGN KEY (username)
	REFERENCES account(username);
	
	ALTER TABLE user_recipe
	ADD FOREIGN KEY (username)
	REFERENCES account(username);

	ALTER TABLE user_recipe
	ADD FOREIGN KEY (recipe_id)
	REFERENCES recipe(id);
	
	SELECT * FROM recipe


	DBCC CHECKIDENT ('recipe', RESEED, 1)
	DBCC CHECKIDENT ('ingredient', RESEED, 1)

	INSERT INTO account(username, password, display_name, salt) VALUES ('anon', '', 'Anonymous User', 'lanzlo')

	INSERT INTO Ingredient(name) VALUES ('extra-virgin olive oil');
	INSERT INTO Ingredient(name) VALUES ('diced onion');
	INSERT INTO Ingredient(name) VALUES ('cloves garlic, minced');
	INSERT INTO Ingredient(name) VALUES ('ground cumin');
	INSERT INTO Ingredient(name) VALUES ('chili powder');
	INSERT INTO Ingredient(name) VALUES ('dried oregano');
	INSERT INTO Ingredient(name) VALUES ('shredded chicken, cooked');
	INSERT INTO Ingredient(name) VALUES ('green enchilada sauce, divided');
	INSERT INTO Ingredient(name) VALUES ('can chopped hatch chile peppers, drained');
	INSERT INTO Ingredient(name) VALUES ('large zucchini, halved lengthwise');
	INSERT INTO Ingredient(name) VALUES ('shredded cheddar-monterey jack cheese blend');
	INSERT INTO Ingredient(name) VALUES ('chopped fresh cilantro');

	INSERT INTO recipe(name,  instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category) VALUES ('Chicken Zucchini Enchiladas',  
'Step 1
Preheat the oven to 350 degrees F (175 degrees C).

Step 2
Heat oil in a large skillet over medium heat. Add onion and cook until soft, about 5 minutes. Add garlic, cumin, chili powder, and oregano. Stir until combined. Add shredded chicken, 1 cup enchilada sauce, and green chiles. Stir until well combined.

Step 3
Slice zucchini into thin, wide sheets using a vegetable peeler or a mandoline. Lay out 3 zucchini slices, slightly overlapping, and place a spoonful of the chicken mixture on top. Roll up and transfer to a baking dish. Repeat with remaining zucchini and chicken mixture.

Step 4
Spread remaining 1/3 cup enchilada sauce over zucchini enchiladas. Sprinkle with Cheddar-Jack cheese blend.

Step 5
Bake in the preheated oven until cheese has melted, about 20 minutes. Garnish with fresh cilantro.', 0, 0, 0, 25, 25, 4, 'Beginner', 'Mexican');

INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (1, 1, 1, 'tablespoon');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity) VALUES (2, 1, 1);
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity) VALUES (3, 1, 2);
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (4, 1, 2, 'teaspoon');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (5, 1, 2, 'teaspoon');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (6, 1, '1/2', 'teaspoon')
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (7, 1, 3, 'cups')
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (8, 1, '1 1/3', 'cups')
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (9, 1, 4, 'ounces')
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity) VALUES (10, 1, 4)
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (11, 1, 1, 'cup')
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES (12, 1, '1/4', 'cup')

-- Recipe #2   https://www.food.com/recipe/jo-mamas-world-famous-spaghetti-22782

    INSERT INTO Ingredient(name) VALUES ('diced tomatoes');
	INSERT INTO Ingredient(name) VALUES ('tomato paste');
	INSERT INTO Ingredient(name) VALUES ('tomato sauce');
	INSERT INTO Ingredient(name) VALUES ('dried basil');
	INSERT INTO Ingredient(name) VALUES ('dried parsley');
	INSERT INTO Ingredient(name) VALUES ('brown sugar');	
	INSERT INTO Ingredient(name) VALUES ('crushed red pepper flakes');
	INSERT INTO Ingredient(name) VALUES ('thin spaghetti');
	INSERT INTO Ingredient(name) VALUES ('italian sausage');



	INSERT INTO recipe(name,  instructions, vegan, vegetarian, gluten_free, cook_time_in_mins, prep_time_in_mins, serves, difficulty, category) VALUES ('Jo Mamas World Famous Spaghetti',  
'In large, heavy stockpot, brown Italian sausage, breaking up as you stir.
    Add onions and continue to cook, stirring occasionally until onions are softened.
    Add garlic, tomatoes, tomato paste, tomato sauce and water.
    Add basil, parsley, brown sugar, salt, crushed red pepper, and black pepper.
    Stir well and barely bring to a boil.
    Stir in red wine.
    Simmer on low, stirring frequently for at least an hour. A longer simmer makes for a better sauce, just be careful not to let it burn!
    Cook spaghetti according to package directions.
    Spoon sauce over drained spaghetti noodles and sprinkle with parmesan cheese.', 0, 0, 0, 60,80, 10, 'Beginner', 'Italian');

INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'diced tomatoes'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 28, 'ounces');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'tomato paste'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 12, 'ounces');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'tomato sauce'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 30, 'ounces');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'dried basil'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 3, 'teaspoons');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'dried parsley'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 2, 'teaspoons');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'brown sugar'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), '1 1/2', 'teaspoons');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'crushed red pepper flakes'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), '1/4', 'teaspoons');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'thin spaghetti'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 1, 'pound');
INSERT INTO ingredient_recipe (ingredient_id, recipe_id, quantity, unit_of_measurement) VALUES ((SELECT id FROM Ingredient WHERE name = 'italian sausage'), (SELECT id FROM recipe WHERE name = 'Jo Mamas World Famous Spaghetti'), 2, 'pounds');


	select * from recipe
	SELECT recipe.*, ingredient.*, ingredient_recipe.quantity, ingredient_recipe.unit_of_measurement FROM recipe
	JOIN ingredient_recipe ON recipe.id = ingredient_recipe.recipe_id
	JOIN Ingredient ON Ingredient.id = ingredient_recipe.ingredient_id
	
	SELECT * FROM ingredient


	select * from account