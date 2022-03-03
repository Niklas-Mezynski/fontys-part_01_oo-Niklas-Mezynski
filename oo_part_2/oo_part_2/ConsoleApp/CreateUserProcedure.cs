using oo_part_2.Persistence;

namespace oo_part_1.Entities;

public class CreateUserProcedure
{
    private IUserPersistence _persistence;

    public CreateUserProcedure(IUserPersistence _persistence)
    {
        this._persistence = _persistence;
        Description = "This action is there to create a new User by reading the console input.";
    }

    public string Description { get; set; }

    internal void startProcedure()
    {
        var userTypes = Helpers.userTypes.ToArray();

        Console.Out.WriteLine("What type of user would you like to add?");
        //Printing all User types
        for (var i = 0; i < userTypes.Length; i++)
        {
            Console.Out.WriteLine($"{i + 1}. {userTypes[i].Name}");
        }

        //Asking the user to enter a type
        int typeInt;
        while (true)
        {
            typeInt = Helpers.ReadIntFromConsole() - 1;
            if (typeInt < userTypes.Length && typeInt >= 0)
            {
                break;
            }
            Console.Out.WriteLine($"Please enter a number between 1 and {userTypes.Length}");
        }
        Type userTypeToAdd = userTypes[typeInt];
        
        //Asking for all the variables needed
        var properties = userTypeToAdd.GetProperties();
        Object[] userFields = new Object[properties.Length];
        for (var i = 1; i < properties.Length; i++)
        {
            var property = properties[i];
            
            //Checking if there is a custom print for that property (Defined in the attribute)
            ConsolePrintAttribute consolePrintAttribute = null;
            foreach (var customAttribute in System.Attribute.GetCustomAttributes(property))
            {
                if (customAttribute is ConsolePrintAttribute)
                {
                    consolePrintAttribute = (ConsolePrintAttribute) customAttribute;
                }
            }
            if (consolePrintAttribute != null)
            {
                //Using the custom print
                Console.Out.WriteLine(consolePrintAttribute.GetConsoleOutput());
            }
            else
            {
                //Default print
                Console.Out.WriteLine($"Please enter the {userTypeToAdd.Name}'s {property.Name}");
            }

            //Reading the user input
            var userFieldString = Console.ReadLine();
            
            //Checking if a type conversion needs to be performed
            if (property.PropertyType != typeof(string))
            {
                //Type conversion needed
                bool success = false;
                while (!success)
                {
                    try
                    {
                        userFields[i] = Helpers.typeParser[property.PropertyType].Invoke(userFieldString);
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid user input");
                        success = false;
                        userFieldString = Console.ReadLine();
                    }
                }
                
            }
            //Accepting the string value
            else
            {
                userFields[i] = userFieldString;
            }

        }
                
        //Getting the correct constructor
        var constructorInfo = userTypeToAdd.GetConstructors().First(info => info.GetParameters().Length == userFields.Length);
                
        //Constructing the user object and setting the ID
        userFields[0] = _persistence.GetNextId();
        var user = (IUser)constructorInfo.Invoke(userFields);
        
        //Saving the new user
        _persistence.AddUser(user);

        // string type = "user";
        // switch (typeInt)
        // {
        //     case 1:
        //         type = "student";
        //         break;
        //     case 2:
        //         type = "lecturer";
        //         break;
        // }
        //
        // Console.Out.WriteLine($"Please enter the first name of the {type}");
        // var firstName = Console.ReadLine();
        // Console.Out.WriteLine($"Please enter the last name of the {type}");
        // var lastName = Console.ReadLine();
        // Console.Out.WriteLine($"Please enter the email address of the {type}");
        // var email = Console.ReadLine();
        // Console.Out.WriteLine($"Please enter the nationality of the {type}");
        // var nationality = Console.ReadLine();
        //
        // switch (typeInt)
        // {
        //     case 1:
        //         AddStudent(firstName, lastName, email, nationality);
        //         break;
        //     case 2:
        //         AddLecturer(firstName, lastName, email, nationality);
        //         break;
        // }
    }

    private void AddStudent(string? firstName, string? lastName, string? email, string? nationality)
    {
        Console.Out.WriteLine($"Please enter the study program of the student");
        var studyProgram = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the cohort of the student");
        var cohort = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the class of the student");
        var @class = Console.ReadLine();
        if (firstName != null && lastName != null && email != null && nationality != null && studyProgram != null
            && cohort != null && @class != null)
        {
            _persistence.AddUser(new Student(_persistence.GetNextId(), firstName, lastName, email, nationality,
                studyProgram, cohort, @class));
        }
        else
        {
            Console.Out.WriteLine("Something went wrong");
        }
    }

    private void AddLecturer(string? firstName, string? lastName, string? email, string? nationality)
    {
        Console.Out.WriteLine($"Please enter the phone number of the lecturer");
        var phoneNum = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the name abbreviation of the lecturer");
        var abbreviation = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the date, the lecturer started [YYYY-MM-DD]");
        DateOnly dateStarted = Helpers.ReadDateOnlyFromConsole();
        if (firstName != null && lastName != null && email != null && nationality != null && phoneNum != null
            && abbreviation != null)
        {
            if (_persistence.AddUser(new Lecturer(_persistence.GetNextId(), firstName, lastName, email, nationality,
                    phoneNum, abbreviation, dateStarted)))
                return;
        }

        Console.Out.WriteLine("Something went wrong");
    }
}