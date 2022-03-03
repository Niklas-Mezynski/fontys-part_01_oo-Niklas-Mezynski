namespace oo_part_1.Entities;

public interface IStudent : IUser
{
    string StudyProgram { get; set; }
    string Cohort { get; set; }
    string Class { get; set; }
}