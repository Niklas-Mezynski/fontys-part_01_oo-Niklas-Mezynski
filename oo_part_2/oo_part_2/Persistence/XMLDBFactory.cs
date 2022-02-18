namespace oo_part_2.Persistence;

public class XMLDBFactory : IDbFactory
{

    private IUserPersistence? _persistence;
    public IUserPersistence CreateUserPersistence()
    {
        return _persistence ??= new XMLPersistence();
    }
}