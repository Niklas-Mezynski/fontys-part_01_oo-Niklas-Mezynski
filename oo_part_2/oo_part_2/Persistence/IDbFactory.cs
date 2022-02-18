namespace oo_part_2.Persistence;

public interface IDbFactory
{
    public IUserPersistence CreateUserPersistence();
}
