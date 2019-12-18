	
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


INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Easy Garlic Chicken', N'anon', N'Preheat oven to 450°F Line a baking dish or cookie sheet with aluminum foil and lightly coat with cooking spray or lightly brush with oil. In small sauté pan, sauté garlic with the oil until tender. Remove from heat and stir in brown sugar. Add additional herbs and spices as desired. Season chicken with salt and pepper. .Place breasts in a prepared baking dish and cover with the garlic and brown sugar mixture. Bake uncovered for 15-30 minutes, or until juices run clear. Cooking time will depend on the size and thickness of your chicken.', 0, 0, 0, 30, 60, 4, N'Moderate', N'American', N'https://img.sndimg.com/food/image/upload/c_thumb,q_80,w_572,h_322/v1/img/recipes/54/78/z7JaEr9NQw65JddIVLnS_easy%20garlic%20chicken%203.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Pulled Pork (Crock Pot)', N'anon', N'Slice one onion and place in crock pot. Put in the roast and cover with the other onion, sliced. Pour over the ginger ale. Cover and cook on LOW for about 12 hours. See Note2 below regarding amount of time needed! Remove the meat, strain and save the onions, discard all liquid. With two forks, shred the meat, discarding any remaining fat, bones or skin. Most of the fat will have melted away. Return the shredded meat and the onions to the crock pot, stir in the barbecue sauce. Continue to cook for another 4 to 6 hours on LOW. Serve with hamburger buns or rolls and additional barbecue sauce. Any leftovers freeze very well. TIP: freeze ready-made sandwiches - a scoop of meat on a bun, well-wrapped. These make a great quick meal or snack. To reheat, remove wrapping, wrap in a paper towel, and zap 1-2 minute in the microwave. Note: Shoulder or butt are recommended because the meat shreds very well. Other cuts do not shred as readily. It is a fattier cut, but the fat melts away in the cooking and is poured away when you discard the liquid.', 0, 0, 0, 480, 30, 10, N'Easy', N'American', N'https://img.sndimg.com/food/image/upload/c_thumb,q_80,w_568,h_319/v1/img/recipes/13/10/18/ZQJQBHP0QTSKpUuWOcZh-017-pulled-pork.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Soft Snickerdoodle Cookies', N'anon', N'Preheat oven to 350°F. Mix softened butter, 1 1/2 cups sugar, 1tps of vanilla extract and eggs thoroughly in a large bowl. Combine flour, cream of tartar, baking soda and salt in a separate bowl. Blend dry ingredients into butter mixture. Chill dough, and chill an ungreased cookie sheet for about 10-15 minutes in the fridge. Meanwhile, mix 3 tablespoons sugar, and 3 teaspoons cinnamon in a small bowl. Scoop 1 inch globs of dough into the sugar/ cinnamon mixture. Coat by gently rolling balls of dough in the sugar mixture. Place on chilled ungreased cookie sheet, and bake 10 minutes. Remove from pan immediately.', 0, 1, 0, 25, 35, 24, N'Easy', N'Baking', N'https://images.video.snidigital.com/image/upload/w_567,h_319/prod/genius/sni1uss-aakamaihdnetScripps_-_Genius_Kitchen364512181218_4555087_Soft_Snickerdoodle_Cookiesjpg.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Authentic Italian Meatballs', N'anon', N'Mix all ingredients in a large bowl by hand. Use your bare hands for best results. Roll meatballs to about the size of a golf ball. (wet your hands to prevent the meat from sticking to them while rolling the meat balls). Drop raw meatballs into large (I use a stock pot) pot of sauce. (I have an incredible sauce recipe {#92096} I use for my meatballs). Simmer for about 3 hours.', 0, 0, 0, 200, 35, 10, N'Moderate', N'Italian', N'https://img.sndimg.com/food/image/upload/c_thumb,q_80,w_599,h_337/v1/img/recipes/92/09/5/WeEQibHTSfSIv0EFIi52_authentic%20italian%20meatballs_final%202.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Panera Broccoli Cheese Soup', N'anon', N'Sauté onion in butter. Set aside. Cook melted butter and flour using a whisk over medium heat for 3-5 minutes or until you see a noticeable golden brown color in your pan. Slowly add in the chicken stock and whisk again to combine. Simmer contents covered (stirring occasionally) for 20 minutes on medium heat. Add the broccoli, carrots and the sauteed onions, into the pot. Stir, add the milk and half & half. Cook covered over low heat 20-25 minutes but do not bring to a boil. This may cause the milk to curdle. Add salt, pepper & nutmeg. Note: you can purée half of your soup in a blender or with a handheld immersion blender if you choose however it isn''t a requirement. Continue to cook the soup on low heat and slowly add the grated cheese a handful at a time and stir to avoid clumps. Once all the cheese has been added is melted, remove from heat, and serve immediately. Suggestion: serve with crusty bread or in a breadbowl. Refrigerate leftovers after they have cooled and store in a airtight container up to 5 days in the refrigerator.', 0, 0, 0, 70, 20, 4, N'Moderate', N'Copycat', N'https://images.video.snidigital.com/image/upload/w_567,h_319/prod/genius/sni1uss-aakamaihdnetScripps_-_Genius_Kitchen9061005181227_4560249_Broccoli_Cheese_Soupjpg.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Ultimate Chocolate Cake', N'anon', N'Heat the oven to 160C/ fan140C/ gas 3. Butter and line a 20cm round cake tin (7.5cm deep).  Put 200g chopped dark chocolate in a medium pan with 200g butter.  Mix 1 tbsp instant coffee granules into 125ml cold water and pour into the pan.  Warm through over a low heat just until everything is melted – don’t overheat. Or melt in the microwave for about 5 minutes, stirring halfway through.  Mix 85g self-raising flour, 85g plain flour, ¼ tsp bicarbonate of soda, 200g light muscovado sugar, 200g golden caster sugar and 25g cocoa powder, and squash out any lumps.  Beat 3 medium eggs with 75ml buttermilk.  Pour the melted chocolate mixture and the egg mixture into the flour mixture and stir everything to a smooth, quite runny consistency.  Pour this into the tin and bake for 1hr 25 – 1hr 30 mins. If you push a skewer into the centre it should come out clean and the top should feel firm (don’t worry if it cracks a bit).  Leave to cool in the tin (don’t worry if it dips slightly), then turn out onto a wire rack to cool completely. Cut the cold cake horizontally into three.  To make the ganache, put 200g chopped dark chocolate in a bowl.  Pour 300ml double cream into a pan, add 2 tbsp golden caster sugar and heat until it is about to boil.  Take off the heat and pour it over the chocolate. Stir until the chocolate has melted and the mixture is smooth. Cool until it is a little thicker but still pourable.  Sandwich the layers together with just a little of the ganache. Pour the rest over the cake letting it fall down the sides and smooth over any gaps with a palette knife.  Decorate with 50g grated chocolate or 100g chocolate curls. The cake keeps moist and gooey for 3-4 days.', 0, 1, 0, 60, 40, 14, N'Moderate', N'Baking', N'https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe_images/recipe-image-legacy-id--1043451_11.jpg?itok=Z_w2WOYB')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'Chef John''s Perfect Prime Rib', N'anon', N'Place rib roast on a plate and bring to room temperature, about 4 hours. Preheat an oven to 500 degrees F (260 degrees C). Combine butter, pepper, and herbes de Provence in a bowl; mix until well blended. Spread butter mixture evenly over entire roast. Season roast generously with kosher salt. Roast the 4-pound prime rib (see footnote if using a larger and smaller roast) in the preheated oven for 20 minutes. Turn the oven off and, leaving the roast in the oven with the door closed, let the roast sit in the oven for 2 hours. Remove roast from the oven, slice, and serve.', 0, 0, 0, 510, 15, 4, N'Moderate', N'American', N'https://images.media-allrecipes.com/userphotos/560x315/4886145.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'(V) Crispy Buffalo Cauliflower Bites', N'anon', N'Preheat oven to 450°F. Line 2 baking sheets with parchment paper. Combine the brown rice flour, almond flour, tomato paste, garlic powder, onion powder, paprika, parsley, and ⅔ cup of water in a blender. Puree until the batter is smooth and thick. Transfer to a bowl and add the cauliflower florets; toss until the florets are well coated with the batter. Arrange the cauliflower in a single layer on the prepared baking sheets, making sure that the florets do not touch one another. Bake for 20 to 25 minutes, until crisp on the edges. They will not get crispy all over while still in the oven. Remove from the heat and let stand for 3 minutes to crisp up a bit more. Transfer to a bowl and drizzle with the sauce. Serve immediately.', 1, 1, 0, 35, 15, 6, N'Moderate', N'American', N'https://www.forksoverknives.com/wp-content/uploads/fly-images/36447/FOK_Coliflower8384-WP-1140x692-c.jpg')
GO
INSERT [dbo].[Recipe] ([name], [author], [instructions], [vegan], [vegetarian], [gluten_free], [cook_time_in_mins], [prep_time_in_mins], [serves], [difficulty], [category], [img_url]) VALUES (N'(V) Pesto Pasta with White Beans', N'anon', N'Place the cooked spaghetti in a large bowl and add the pesto. Stir well, adding enough of the reserved cooking liquid to achieve a creamy sauce. Add the beans and toss well.', 1, 1, 0, 20, 15, 4, N'Easy', N'Italian', N'https://www.forksoverknives.com/wp-content/uploads/fly-images/22757/Pesto-Pasta-with-White-Beans-300kb-1140x692-c.jpg')
GO

UPDATE Recipe
SET img_url = 'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F5566563.jpg&w=596&h=596&c=sc&poi=face&q=85'
WHERE name = 'Chicken Zucchini Enchiladas'

UPDATE Recipe
SET img_url = 'https://img.sndimg.com/food/image/upload/c_thumb,q_80,w_576,h_324/v1/img/recipes/22/78/2/bMWnCGreSgeji8rnPIAp_JMWFS%204%20-%20final_1%20-%20horizontal.png'
WHERE name = 'Jo Mamas World Famous Spaghetti'


	select * from recipe
	SELECT recipe.*, ingredient.*, ingredient_recipe.quantity, ingredient_recipe.unit_of_measurement FROM recipe
	JOIN ingredient_recipe ON recipe.id = ingredient_recipe.recipe_id
	JOIN Ingredient ON Ingredient.id = ingredient_recipe.ingredient_id
	
	SELECT * FROM ingredient


	select * from account