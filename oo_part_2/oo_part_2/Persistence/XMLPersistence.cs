using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        if (user.GetType().IsAssignableFrom(typeof(Student)))
        {
            AddStudent((Student) user);
        }
        else if (user.GetType().IsAssignableFrom(typeof(Lecturer)))
        {
            AddLecturer((Lecturer) user);
        }

        usersInCache.Add(user);
        return true;
    }

    private void AddLecturer(Lecturer lecturer)
    {
        XElement root = XElement.Load(xmlFilePath);
        root.Add(new XElement("Lecturer",
            new XElement("Id", lecturer.Id),
            new XElement("FirstName", lecturer.FirstName),
            new XElement("LastName", lecturer.LastName),
            new XElement("EmailAddress", lecturer.EmailAddress),
            new XElement("Nationality", lecturer.Nationality),
            new XElement("PhoneNumber", lecturer.PhoneNumber),
            new XElement("Abbreviation", lecturer.Abbreviation),
            new XElement("DateStarted", lecturer.DateStarted)
        ));
        root.Save(new StreamWriter(xmlFilePath));
    }

    private void AddStudent(Student student)
    {
        XElement root = XElement.Load(xmlFilePath);
        root.Add(new XElement("Student",
            new XElement("Id", student.Id),
            new XElement("FirstName", student.FirstName),
            new XElement("LastName", student.LastName),
            new XElement("EmailAddress", student.EmailAddress),
            new XElement("Nationality", student.Nationality),
            new XElement("StudyProgram", student.StudyProgram),
            new XElement("Cohort", student.Cohort),
            new XElement("Class", student.Class)
        ));
        root.Save(new StreamWriter(xmlFilePath));
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
        XElement root = XElement.Load(xmlFilePath);
        var users = new List<IUser>();

        var students = from student in root.Elements("Student")
            select student;
        foreach (var element in students)
        {
            var id = element.Element("Id").Value;
            var firstName = element.Element("FirstName").Value;
            var lastName = element.Element("LastName").Value;
            var email = element.Element("EmailAddress").Value;
            var nationality = element.Element("Nationality").Value;
            var studyProgram = element.Element("StudyProgram").Value;
            var cohort = element.Element("Cohort").Value;
            var @class = element.Element("Class").Value;
            var student = new Student(int.Parse(id), firstName, lastName, email, nationality, studyProgram, cohort,
                @class);
            users.Add(student);
        }

        var lecturers = from lecturer in root.Elements("Lecturer")
            select lecturer;
        foreach (var element in lecturers)
        {
            var id = element.Element("Id").Value;
            var firstName = element.Element("FirstName").Value;
            var lastName = element.Element("LastName").Value;
            var email = element.Element("EmailAddress").Value;
            var nationality = element.Element("Nationality").Value;
            var phoneNumber = element.Element("PhoneNumber").Value;
            var abbreviation = element.Element("Abbreviation").Value;
            var dateStarted = element.Element("DateStarted").Value;
            var lecturer = new Lecturer(int.Parse(id), firstName, lastName, email, nationality, phoneNumber,
                abbreviation, DateOnly.Parse(dateStarted));
            users.Add(lecturer);
        }

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