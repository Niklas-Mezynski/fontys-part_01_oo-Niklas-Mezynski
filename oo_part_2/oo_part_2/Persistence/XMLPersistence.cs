using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using oo_part_1.Entities;

namespace oo_part_2.Persistence;

public class XMLPersistence : IUserPersistence
{
    private string xmlFilePath;
    private List<IUser> usersInCache;
    private int currentId;

    public XMLPersistence()
    {        
        var currentDirectory = Directory.GetCurrentDirectory();
        this.xmlFilePath = currentDirectory + "\\..\\..\\..\\Persistence\\XMLFiles\\Users.xml";
        this.usersInCache = LoadUsersToCache();
        this.currentId = CalculateCurrentMaxId();
    }

    public bool AddUser(IUser user)
    {
        usersInCache.Add(user);

        var properties = user.GetType().GetProperties();
        
        XElement root = XElement.Load(xmlFilePath);

        var xmlUserProps = new List<XElement>();
        foreach (var property in properties)
        {
            xmlUserProps.Add(new XElement(property.Name, property.GetValue(user)));
        }

        root.Add(new XElement(user.GetType().Name, xmlUserProps));
        root.Save(new StreamWriter(xmlFilePath));
        return true;
    }

    public List<IUser> GetAllUsers()
    {
        return usersInCache;
    }

    public IUser? GetUserById(int id)
    {
        return usersInCache.Find(user => user.Id == id);
    }

    public int GetNextId()
    {
        currentId++;
        return currentId;
    }

    private List<IUser> LoadUsersToCache()
    {
        //Load the XML File
        XElement root = XElement.Load(xmlFilePath);
        var users = new List<IUser>();
        
        //Read out XMLElements for each user type
        foreach (var userType in Helpers.userTypes)
        {
            //Getting all XML Elements of the specific user type
            var xmlUsers = from xmlUser in root.Elements(userType.Name)
                select xmlUser;

            foreach (var xmlUser in xmlUsers)
            {
                //Reading the fields of the user and storing them in a list
                var properties = userType.GetProperties();
                Object[] userFields = new Object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    //Checking if a type conversion needs to be performed
                    var userFieldString = xmlUser.Element(properties[i].Name).Value;
                    if (properties[i].PropertyType != typeof(string))
                    {
                        userFields[i] = Helpers.typeParser[properties[i].PropertyType].Invoke(userFieldString);
                    }
                    else
                    {
                        userFields[i] = userFieldString;
                    }

                }
                
                //Getting the correct constructor
                var constructorInfo = userType.GetConstructors().First(info => info.GetParameters().Length == userFields.Length);
                
                //Constructing the user object
                var user = constructorInfo.Invoke(userFields);
                users.Add((IUser)user);
            }
        }

        users.Sort((u1, u2) => u1.Id - u2.Id);
        return users;
    }

    private int CalculateCurrentMaxId()
    {
        var maxBy = usersInCache.MaxBy(user => user.Id);
        if (maxBy == null)
        {
            return 0;
        }

        return maxBy.Id;
    }
}