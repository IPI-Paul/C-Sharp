Intro to MongoDB with C#

https://m.youtube.com/watch?v=69WBy4MHYUw

This is another helpful video tutorial on how to interact with MongoDb using C#. The tutor does a very good job in explaining and and demonstrating what is required to get up and running with just a few lines of code and the right NuGet packages.

After some tinkering I noticed that I got error breaks when trying to run the NameModel through the LoadRecords function of what was eventually refactored out to MongoCRUD.cs. The problem was that PersonModel.cs had been modified to include an Address Model and a Date of Birth Field. So trying to run the NameModel structure was throwing the error that the Address field could not be found.

With that I added a LoadNames function to MongoCRUD.cs and a constructor to the NameModel.cs class. Following that I added a whole lot of try catch statements to Program.cs along with an extra DisplayHelp.cs and a while statement to keep the window open until you decide to close it.

Using the console to perform operations is not ideal to me, as I prefer to call functions from within Outlook, Excel, Ms Access, Word or with a PowerShell script linked to a Desktop shortcut. In Outlook, being able to select text in an email and use a customized right click menu (built by me in Visual Studio) to call records from a database and either populate the custom properties of that email or generate a web page preview of a chosen report relating to the selected text and displayed in a webbrowser object of a VBA userform is what makes automation processes invaluable!
