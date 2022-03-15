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
    }
}