# FeedExpenseCalculator
This is the expense calculator for the feed to the zoo in one day
There are 2 types of food: meat and fruit.
Each of these will have a price per kg that will be provided in a text (.txt) file
following the next strict format (with strict format we mean that when processing
the file, it is not needed to protect the system from syntax errors):
=======================================
File: prices.txt
=======================================
Meat=12.56
Fruit=5.60
=======================================
The zoo has 3 different types of animals: carnivores, herbivores and omnivores. The
first only eat meat, the second, only fruit, and the third eat both.
Each animal eats an amount of food that depends on its weight. For each animal
type, there is a rate that determines how much food the animal needs.
The file animals.csv provides information about which animal species can exist in
the zoo, and their rates.
For the omnivore animals, this rate needs to be split into fruits and meat. A
percentage is also given to show how much of that rate must be covered with meat
=======================================
File: animals.csv (strict comma separated format)


There are two files added in the project which species 
Prices : 2 types of food: meat and fruit. This file has been added as price.txt
Animals : The file animals.csv provides information about which animal species can exist in
the zoo, and their rates.

A file (zoo.xml) will tell us the content of our zoo. Then this code has an API which will calculate the amount needed for each animal for his food and then return the total amount needed to be spent for the feed in one day.

Run the project with IIS Express and call the API :
GET: 
http://localhost:62228/api/v1/ExpenseCalculation

this shall return the jasonresult and the value will be the amount spent.
