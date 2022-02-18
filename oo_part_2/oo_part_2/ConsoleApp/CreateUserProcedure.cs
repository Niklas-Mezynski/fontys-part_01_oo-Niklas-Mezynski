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
        Console.Out.WriteLine("What type of user would you like to add?\n" +
                              "1. Student\n" +
                              "2. Lecturer");
        int typeInt;
        while (true)
        {
            typeInt = Helpers.ReadIntFromConsole();
            if (typeInt == 1 || typeInt == 2)
            {
                break;
            }

            Console.Out.WriteLine("Please enter 1 or 2");
        }

        string type = "user";
        switch (typeInt)
        {
            case 1:
                type = "student";
                break;
            case 2:
                type = "lecturer";
                break;
        }

        Console.Out.WriteLine($"Please enter the first name of the {type}");
        var firstName = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the last name of the {type}");
        var lastName = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the email address of the {type}");
        var email = Console.ReadLine();
        Console.Out.WriteLine($"Please enter the nationality of the {type}");
        var nationality = Console.ReadLine();

        switch (typeInt)
        {
            case 1:
                AddStudent(firstName, lastName, email, nationality);
                break;
            case 2:
                AddLecturer(firstName, lastName, email, nationality);
                break;
        }
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