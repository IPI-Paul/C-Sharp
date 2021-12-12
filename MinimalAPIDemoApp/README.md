https://m.youtube.com/watch?v=dwMFg6uxQ0I and https://m.youtube.com/watch?v=5tYSO5mAjXs

Simple C# Data Access with Dapper and SQL - Minimal API Project Part 1 & 2

When trying out the functions of this tutorial I found that the record numbering was jumping by a thousand on adding a new record. So after browsing for solutions I tried adding a stored procedure that changes the database scoped configuration IDENTITY_CACHE to off and called it from the Script.PostDeployment1.sql used to deploy the database.

I am not completely sure if it works, but have not seen the error increment since.

I used insomnia to also test function. I was not too happy, that of the 8gb memory on my current personal dev laptop Visual Studio 2022 was using 92% of my memory to run the App in debug mode. Might be a bug with my laptop as later on response times and load times did improve.
