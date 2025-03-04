namespace SoulsBackup;

public static class ConsoleHelpers
{
    private static int Width => Console.WindowWidth;
    private static int Height => Console.WindowHeight;
    private static ConsoleColor ForegroundColor => Console.ForegroundColor;
    
    private static void PrintWithColor(string message, ConsoleColor color = ConsoleColor.White, string decoratorBefore = "", string decoratorAfter = "")
    {
        Console.ForegroundColor = color;
        if(!string.IsNullOrEmpty(decoratorBefore))Console.Write(decoratorBefore);
        Console.WriteLine(message);
        if(!string.IsNullOrEmpty(decoratorAfter))Console.Write(decoratorAfter);
        Console.ResetColor();
    }    
    public static void PrintError(string message) => PrintWithColor(message, ConsoleColor.Red);
    
    public static void PrintWarning(string message) => PrintWithColor(message, ConsoleColor.Yellow);
    
    public static void PrintInfo(string message) => PrintWithColor(message, ConsoleColor.Blue);
    
    public static void PrintSuccess(string message) => PrintWithColor(message, ConsoleColor.Green);
    
    public static void PrintHeader(string message) => PrintWithColor(message, ConsoleColor.Cyan, 
        decoratorBefore: new string('\u07F7', Width/3)+"\n"+new string(' ',Width/3/2-message.Length/2),
        decoratorAfter: new string('\u07E6', Width/3)+'\n');
    
    public static void PrintLine() => PrintWithColor(new string('_',Width/3), ConsoleColor.DarkCyan);
}