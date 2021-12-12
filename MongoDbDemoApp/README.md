Intro to MongoDB with C#

https://m.youtube.com/watch?v=exXavNOqaVo

This is a helpful video tutorial on how to interact with MongoDb using C#. The tutor does a very good job in explaining and and demonstrating what is required to get up and running with just a few lines of code and the right NuGet packages.

To enable choosing which of the functions taught should be run I added an extra DisplayHelp.cs and a while statement to keep the window open until you decide to close it.

Trying to create a PersonDataAccess class in the MongoDataAccess project did not provide access to functions when I tried moving the original database connection for simple_db to it and retrieve the collection from the variable collection in the MongoDbDemo Program.cs file. So I resolved to keeping it in the original file as per the tutorial.
