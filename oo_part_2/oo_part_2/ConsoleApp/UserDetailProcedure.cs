using oo_part_2.Persistence;

namespace oo_part_1.Entities;

public class UserDetailProcedure
{
    private IUserPersistence _persistence;

    public UserDetailProcedure(IUserPersistence _persistence)
    {
        this._persistence = _persistence;
        Description = "This procedure prints all details about a user.";
    }

    public string Description { get; set; }

    internal void StartProcedure()
    {
        Console.Out.WriteLine("Please enter the ID of the user you would like to have more details about");
        int id = Helpers.ReadIntFromConsole();
        IUser? user = _persistence.GetUserById(id);
        if (user == null)
        {
            Console.Out.WriteLine("Sorry, the user was not found");
        }
        else
        {
            Console.Out.WriteLine(user.GetDetailedStringRepresentation());
        }
    }
}