namespace oo_part_1.Entities;

[System.AttributeUsage(System.AttributeTargets.Property)  
]  
public class ConsolePrintAttribute : System.Attribute
{
    string ConsoleOutput;

    public ConsolePrintAttribute(string consoleOutput)
    {
        this.ConsoleOutput = consoleOutput;
    }
    
    public string GetConsoleOutput()  
    {  
        return ConsoleOutput;  
    }
}