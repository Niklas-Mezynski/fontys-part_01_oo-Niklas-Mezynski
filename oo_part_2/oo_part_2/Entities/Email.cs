using System.Text.RegularExpressions;

namespace oo_part_1.Entities;

public class Email
{
    public string EmailAddress { get; }

    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public override string ToString()
    {
        return EmailAddress;
    }

    public static Email Parse(string emailAddress)
    {
        var regex = new Regex(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+\.[a-z]+$", RegexOptions.Compiled);
        var match = regex.Match(emailAddress);
        if (match.Success)
        {
            return new Email(emailAddress);
        }
        throw new FormatException("Not a valid email address");
    }
}