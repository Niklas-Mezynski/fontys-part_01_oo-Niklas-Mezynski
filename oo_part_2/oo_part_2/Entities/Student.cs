namespace oo_part_1.Entities;

[Serializable]
public class Student : IStudent
{
    private Student()
    {
    }

    public Student(int id, string firstName, string lastName, string emailAddress, string nationality,
        string studyProgram, string cohort, string @class)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Nationality = nationality;
        StudyProgram = studyProgram;
        Cohort = cohort;
        Class = @class;
    }

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Nationality { get; set; }

    public string GetOverviewStringRepresentation()
    {
        return $"Student {FirstName} {LastName} [{Id}]";
    }

    public string GetDetailedStringRepresentation()
    {
        return $"Student id: {Id}\n" +
               $"FirstName: {FirstName}\n" +
               $"LastName: {LastName}\n" +
               $"EmailAddress: {EmailAddress}\n" +
               $"Nationality: {Nationality}\n" +
               $"StudyProgram: {StudyProgram}\n" +
               $"Cohort: {Cohort}\n" +
               $"Class: {Class}";
    }

    [ConsolePrint("Please enter the students study program")]
    public string StudyProgram { get; set; }
    [ConsolePrint("Please enter the students cohort")]
    public string Cohort { get; set; }
    [ConsolePrint("Please enter the students class")]
    public string Class { get; set; }
}