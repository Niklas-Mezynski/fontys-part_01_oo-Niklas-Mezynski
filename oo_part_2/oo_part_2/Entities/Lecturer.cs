namespace oo_part_1.Entities;

public class Lecturer : ILecturer
{
    public Lecturer(int id, string firstName, string lastName, string emailAddress, string nationality, string phoneNumber, string abbreviation, DateOnly dateStarted)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Nationality = nationality;
        PhoneNumber = phoneNumber;
        Abbreviation = abbreviation;
        DateStarted = dateStarted;
    }

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Nationality { get; set; }
    public string GetOverviewStringRepresentation()
    {
        return $"Lecturer {FirstName} {LastName} [{Id}]";
    }

    public string GetDetailedStringRepresentation()
    {
        return $"Lecturer id: {Id}\n" +
               $"FirstName: {FirstName}\n" +
               $"LastName: {LastName}\n" +
               $"EmailAddress: {EmailAddress}\n" +
               $"Nationality: {Nationality}\n" +
               $"PhoneNumber: {PhoneNumber}\n" +
               $"Abbreviation: {Abbreviation}\n" +
               $"DateStarted: {DateStarted.ToString( "yyyy-MM-dd")}";
    }

    public string PhoneNumber { get; set; }
    public string Abbreviation { get; set; }
    public DateOnly DateStarted { get; set; }
}