using System.Reflection;
using oo_part_1.Entities;
using BindingFlags = System.Reflection.BindingFlags;

namespace oo_part_2.Persistence;
using System.Configuration;
public class AbstractDBFactory : IDbFactory
{
    private IDbFactory _factory;

    public AbstractDBFactory()
    {
        //TODO Read from the config file
        string dbFactory = ConfigurationManager.AppSettings["DBFactory"];
        foreach (Type factoryType in Helpers.factoryTypes)
        {
            if (factoryType.Name == dbFactory)
            {
                var constructorInfo = factoryType.GetConstructors().First(info => info.GetParameters().Length == 0);
                _factory = (IDbFactory) constructorInfo.Invoke(Array.Empty<object>());
            }
        }

        if (_factory == null)
        {
            throw new ConfigurationException("Type of DBFactory is invalid");
        }
    }

    public IUserPersistence CreateUserPersistence()
    {
        return _factory.CreateUserPersistence();
    }
}