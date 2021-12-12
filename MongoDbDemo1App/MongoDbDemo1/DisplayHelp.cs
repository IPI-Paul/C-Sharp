// See https://aka.ms/new-console-template for more information

public class DisplayHelp
{
  public void show()
  {
    Console.WriteLine("Use one of the following commands:");
    Console.WriteLine("   tim [orig/new] - adds the 1st record of the course for 'Tim'. orig is the format before PersonModel was changed");
    Console.WriteLine("   mary [orig/new] - adds the 2nd record of the course for 'Mary'. orig is the format before PersonModel was changed");
    Console.WriteLine("   joe - adds the 3rd record 'Joe'");
    Console.WriteLine("   get users - Shows all records");
    Console.WriteLine("   show + record number (from 0 up) - Shows the Id and First and Last Names for that record number");
    Console.WriteLine("   update dob + record number (from 0 up) - Updates the Date Of Birth for that record number");
    Console.WriteLine("   delete + record number (from 0 up) - Deletes the record for that record number");
    Console.WriteLine("   names - Shows the First and Last Names for all records");
    Console.WriteLine("   help - Displays this message");
    Console.WriteLine("   exit - Quits the application");
  }
}