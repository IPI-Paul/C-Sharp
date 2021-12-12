// See https://aka.ms/new-console-template for more information

public class DisplayHelp
{
  public void show()
  {
    Console.WriteLine("Use one of the following commands:");
    Console.WriteLine("   tim - adds the 1st record of the course for 'Tim' to the people table of simple_db");
    Console.WriteLine("   people - Shows all people in the people collection");
    Console.WriteLine("   chore add tim - adds 'Tim' to the user table in choredb ");
    Console.WriteLine("   chore new - Adds a new chore for Tim in the chore_chart table of choredb");
    Console.WriteLine("   chore complete - Updates the DateCompleted for the 1st user in chore_chart and adds a record to chore_history");
    Console.WriteLine("   help - Displays this message");
    Console.WriteLine("   exit - Quits the application");
  }
}