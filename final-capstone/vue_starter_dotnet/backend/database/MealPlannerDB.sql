	
	USE master;
	GO

	IF EXISTS (SELECT * FROM sys.databases where name='MealPlanner')
	DROP DATABASE MealPlanner;
	GO

	CREATE DATABASE MealPlanner;
	GO

	USE MealPlanner
	GO

	BEGIN TRAN

	CREATE TABLE Recipe (
	id integer IDENTITY NOT NULL,
	name nvarchar(64) NOT NULL,
	author nvarchar(64) NOT NULL,
	intructions nvarchar(max) NOT NULL,
	vegan bit NOT NULL,
	vegetarian bit NOT NULL,
	gluten_free bit NOT NULL,
	cook_time_in_mins integer NOT NULL,
	prep_time_in_mins integer NOT NULL,
	serves integer NOT NULL,
	difficulity nvarchar(30) NOT NULL,
	category nvarchar(20) NOT NULL,
	CONSTRAINT pk_recipe_id PRIMARY KEY (id)
	);

	CREATE TABLE Ingredient (
	id integer IDENTITY NOT NULL,
	name nvarchar(30) NOT NULL,
	CONSTRAINT pk_ingredient_id PRIMARY KEY (id)
	); 

	CREATE TABLE Pantry (
	ingredient_id integer NOT NULL,
	username nvarchar(64) NOT NULL,
	unit_of_measurement nvarchar(15) NOT NULL,
	quanitity integer NOT NULL,
	CONSTRAINT pk_pantry_ingredient_id_username PRIMARY KEY (ingredient_id, username)
	);

	CREATE TABLE Meal_Plan (
	recipe_id integer NOT NULL,
	username nvarchar(64) NOT NULL,
	meal_time smallint NOT NULL, --between 0 and 21 
	CONSTRAINT pk_meal_plan_username_meal_time PRIMARY KEY (username, meal_time)
	);

	CREATE TABLE Account (
	username nvarchar(64) NOT NULL,
	password nvarchar(64) NOT NULL,
	display_name nvarchar(64) NOT NULL,
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
	quanitity integer NOT NULL,
	unit_of_measurement nvarchar(15) NOT NULL,
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

		COMMIT TRAN



	BEGIN TRAN

	INSERT INTO Ingredient(name) VALUES ('chicken');

	ROLLBACK TRAN