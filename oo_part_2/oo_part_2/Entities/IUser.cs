namespace oo_part_1.Entities;

public interface IUser
{
    int Id { get; }
    
    string FirstName { get; set; }
    string LastName { get; set; }

    Email EmailAddress { get; set; }

    string Nationality { get; set; }

    string GetOverviewStringRepresentation();
    
    string GetDetailedStringRepresentation();
}