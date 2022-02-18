using oo_part_2.Persistence;

namespace oo_part_1.Entities;

public class UsersOverviewProcedure
{
    private IUserPersistence _persistence;

    public UsersOverviewProcedure(IUserPersistence _persistence)
    {
        this._persistence = _persistence;
        Description = "This procedure gives an overview of all users stored.";
    }

    public string Description { get; set; }

    internal void startProcedure()
    {
        Console.Out.WriteLine("Here are all the users stored in the database");
        foreach (IUser user in _persistence.GetAllUsers())
        {
            Console.Out.WriteLine(user.GetOverviewStringRepresentation());
        }
    }
}