namespace oo_part_1.Entities;

public interface ILecturer : IUser
{
    string PhoneNumber { get; set; }

    string Abbreviation { get; set; }

    DateOnly DateStarted { get; set; }
}