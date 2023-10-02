Create database Rllproject
use Rllproject
-- Create the Admin table 
CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
	Adminname NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
   
    
);
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(255),
	LastName NVARCHAR(255),
    Username NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
   
);
--Create the Recipe table
CREATE TABLE Recipes (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Ingredients NVARCHAR(MAX),
    Category NVARCHAR(MAX),
	SubmissionDate DATETIME,
	ImageURL nvarchar(max)
    
);

INSERT INTO Admin (Adminname, Email, Password )
VALUES ('Hassan', 'mohdhassan7890@gmail.com', 'mh78900');

INSERT INTO Admin (Adminname, Email, Password )
VALUES ('Kishan', 'kumarkishan61196@gmail.com', 'kishan@9116');





INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ('Vegetable Stir-Fry', 'Veg', '1 cup broccoli, 1 cup bell peppers, 1 cup carrots, 1 cup snap peas', 'A delicious and healthy stir-fry loaded with fresh vegetables.', '2023-09-27');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Spinach and Mushroom Quiche', 'Veg', '1 cup spinach, 1 cup mushrooms, 4 eggs, 1 cup cheese', 'A savory quiche perfect for brunch or breakfast.', '2023-09-28');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Roasted Vegetable Salad', 'Veg', '1 cup cherry tomatoes, 1 cup zucchini, 1 cup red onion, 1 cup bell peppers', 'A colorful and flavorful salad with roasted veggies.', '2023-09-29');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Lentil Soup', 'Veg', '1 cup lentils, 1 cup carrots, 1 cup celery, 1 cup onions', 'A hearty and nutritious soup made with lentils and vegetables.', '2023-09-30');

INSERT INTO Recipes (Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Mushroom Risotto', 'Veg', '1 cup Arborio rice, 1 cup mushrooms, 1/2 cup white wine, 4 cups vegetable broth', 'A creamy and flavorful Italian rice dish with mushrooms.', '2023-10-01');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ('Chicken Alfredo Pasta', 'Non-Veg', '8 oz. chicken breast, 2 cups fettuccine pasta, 1 cup heavy cream, 1/2 cup Parmesan cheese', 'Creamy pasta dish with tender chicken and rich Alfredo sauce.', '2023-10-02');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Grilled Salmon with Lemon Butter', 'Non-Veg', '4 salmon fillets, 2 lemons, 2 tablespoons butter, fresh herbs', 'A light and flavorful salmon dish with zesty lemon butter.', '2023-10-03');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Beef Tacos', 'Non-Veg', '1 lb ground beef, taco seasoning, taco shells, lettuce, tomatoes', 'Classic beef tacos with all your favorite toppings.', '2023-10-04');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Shrimp Scampi', 'Non-Veg', '1 lb large shrimp, 4 cloves garlic, 1/2 cup white wine, 2 tablespoons butter', 'Garlicky shrimp served over pasta in a white wine sauce.', '2023-10-05');

INSERT INTO Recipes ( Name, Category, Ingredients, Description, SubmissionDate)
VALUES ( 'Barbecue Ribs', 'Non-Veg', '2 racks of baby back ribs, barbecue sauce, seasoning rub', 'Fall-off-the-bone tender ribs smothered in barbecue sauce.', '2023-10-06');




UPDATE Recipes
SET ImageURL = 'https://buildyourbite.com/wp-content/uploads/2018/06/Vegetable-Stir-Fry-featured-720x540.jpg'
WHERE ID = 1; 


UPDATE Recipes
SET ImageURL = 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.eatingwell.com%2Frecipe%2F278023%2Fspinach-mushroom-quiche%2F&psig=AOvVaw0Q7f2v55SV_TROkFVjxl-u&ust=1695966353090000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMDtqpLNzIEDFQAAAAAdAAAAABAE'
WHERE ID = 2; 


select * from Recipes

select * from Users
