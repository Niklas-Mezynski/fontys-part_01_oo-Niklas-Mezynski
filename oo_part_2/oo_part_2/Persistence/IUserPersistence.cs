using oo_part_1.Entities;

namespace oo_part_2.Persistence;

public interface IUserPersistence
{
    public bool AddUser(IUser user);
    
    public List<IUser> GetAllUsers();

    public IUser? GetUserById(int id);

    public int GetNextId();
}