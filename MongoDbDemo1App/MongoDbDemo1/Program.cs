// See https://aka.ms/new-console-template for more information

MongoCRUD db = new MongoCRUD("AddressBook");
DisplayHelp help = new DisplayHelp();
bool repeat = true;
help.show();

while (repeat)
{
  Console.WriteLine(":>");
  var example = Console.ReadLine();
  if (example != null)
  {
    if (example.Equals("tim orig"))
    {
      db.InsertRecord("Users", new NameModel(firstName: "Tim", lastName: "Corey")); 
    }
    else if (example.Equals("tim new"))
    {
      db.InsertRecord("Users", new PersonModel { FirstName = "Tim", LastName = "Corey" });
    }
    else if (example.Equals("mary orig"))
    {
      db.InsertRecord("Users", new NameModel(firstName: "Mary", lastName: "Jones")); 
    }
    else if (example.Equals("mary new"))
    {
      db.InsertRecord("Users", new PersonModel { FirstName = "Mary", LastName = "Jones" });
    }
    else if (example.Equals("joe"))
    {
      PersonModel person = new PersonModel
      {
        FirstName = "Joe",
        LastName = "Smith",
        PrimaryAddress = new AddressModel
        {
          StreetAddress = "101 Oak Street",
          City = "Scranton",
          State = "PA",
          ZipCode = "18512"
        }
      };
      db.InsertRecord("Users", person);
    }
    else if (example.Equals("get users"))
    {
      var recs = db.LoadRecords<PersonModel>("Users");
      var i = 0;

      foreach (var rec in recs)
      {
        Console.WriteLine($"{ i }) { rec.Id }: { rec.FirstName } { rec.LastName }");

        if (rec.PrimaryAddress != null)
        {
          Console.WriteLine(rec.PrimaryAddress.City);
        }
        ++i;
      }
    }
    else if (example.Contains("show "))
    {
      var recs = db.LoadRecords<PersonModel>("Users");
      var idx = Convert.ToInt32(example.Replace("show ", "").Trim());

      try
      {
        var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid(recs[idx].Id.ToString()));
        Console.WriteLine($"{ idx }) { oneRec.Id }: { oneRec.FirstName } { oneRec.LastName }");
      }
      catch (Exception)
      {
        Console.WriteLine("The Record Number given is out of scope. You can run get users to see record numbers!");
      }
    }
    else if (example.Contains("update dob "))
    {
      var recs = db.LoadRecords<PersonModel>("Users");
      var idx = Convert.ToInt32(example.Replace("update dob ", "").Trim());

      try
      {
        var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid(recs[idx].Id.ToString()));
        var FullName = $"{ oneRec.FirstName } { oneRec.LastName }";
        oneRec.DateOfBirth = new DateTime(1982, 10, 31, 0, 0, 0, DateTimeKind.Utc);
        db.UpsertRecord("Users", oneRec.Id, oneRec);
        Console.WriteLine($"The date of birth for { FullName } has been updated to { oneRec.DateOfBirth }!");
      }
      catch (Exception)
      {
        Console.WriteLine("The Record Number given is out of scope. You can run get users to see record numbers!");
      }
    }
    else if (example.Contains("delete "))
    {
      var recs = db.LoadRecords<PersonModel>("Users");
      var idx = Convert.ToInt32(example.Replace("delete ", "").Trim());

      try
      {
        var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid(recs[idx].Id.ToString()));
        var FullName = $"{ oneRec.FirstName } { oneRec.LastName }";
        db.DeleteRecord<PersonModel>("Users", oneRec.Id);
        Console.WriteLine($"Record Number { idx } for { FullName } has been deleted!");
      }
      catch (Exception)
      {
        Console.WriteLine("The Record Number given is out of scope. You can run get users to see record numbers!");
      }
    }
    else if (example.Contains("names"))
    {
      var recs = new List<NameModel>();
        try
      {
        recs = db.LoadRecords<NameModel>("Users");
        Console.WriteLine("Using LoadRecords");
        Console.WriteLine();
      }
      catch (Exception)
      {
        recs = db.LoadNames<NameModel>("Users");
        Console.WriteLine("Using LoadNames");
        Console.WriteLine();
      }

      var i = 0;
      foreach (var rec in recs)
      {
        Console.WriteLine($"{ i }) { rec.FirstName } { rec.LastName }");
        ++i;
      }
    }
    else if (example.Contains("help"))
    {
      help.show();
    }
    else if (example.Contains("exit"))
    {
      repeat = false;
    }
  }
}
