namespace oo_part_2.Persistence;

public class AbstractDBFactory : IDbFactory
{
    private IDbFactory _factory;

    public AbstractDBFactory()
    {
        //TODO Read from the config file
        _factory = new XMLDBFactory();
    }

    public IUserPersistence CreateUserPersistence()
    {
        return _factory.CreateUserPersistence();
    }
}