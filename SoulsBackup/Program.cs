using System.Reflection;
using SoulsBackup;
using static System.Int32;

const string NOT_IMPLEMENTED_YET = "Not implemented yet";

ConsoleHelpers.PrintHeader("SoulsBackup");

var menu = GetMenu();
menu.FirstOrDefault(x => x.Id == 5)!.Action = s => PrintMenu(menu, s);

PrintMenu(menu);
while (true)
{
    ConsoleHelpers.PrintInfo("Enter a command: ");
    var commandWithArguments  = Console.ReadLine();
    
    var command = commandWithArguments?[..commandWithArguments.IndexOf(' ')] ?? "help";
    var arguments = commandWithArguments?[commandWithArguments.IndexOf(' ')..] ?? string.Empty;

    _ = TryParse(command, out var menuItem);
    
    var callback = menu.FirstOrDefault(x => x.Id == menuItem || x.Command == command || x.Shortcut == command)?.Action;
    if (callback == null)
    {
        ConsoleHelpers.PrintError($"Action for {command} is not set, or command is not found");
        ConsoleHelpers.PrintLine();
        continue;
    }
    callback(arguments);
    ConsoleHelpers.PrintLine();
}

static HashSet<MenuItem> GetMenu()
{
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
    return
    [
        new()

        {
            Id = 1, Command = "config",
            Action = Config, Description = "Configure the backup", Shortcut = "c",
            Doc = $"Usage: {assemblyName} config path/to/config\n Shows current configuration settings and let you change them"
        },
        new()
        {
            Id = 2, Command = "list",
            Action = List, Description = "List available backups", Shortcut = "l",
            Doc = $"Usage: {assemblyName} list\n Shows all saved backup snapshots"
        },
        new()
        {
            Id = 3, Command = "backup",
            Action = Backup, Description = "Backup to a snapshot", Shortcut = "b", 
            Doc = $"Usage: {assemblyName} backup <snapshot>\n Saves backup snapshot"
        },
        new()
        {
            Id = 4, Command = "restore",
            Action = Restore, Description = "Restore from the snapshot", Shortcut = "r", 
            Doc = $"Usage: {assemblyName} restore <snapshot>\n Restore saved backup snapshot"
        },
        new()
        {
            Id = 5, Command = "help",
            Action = null, Description = "Print this", Shortcut = "?", 
            Doc = $"Usage: {assemblyName} help\n Shows help text. Can print help for any command in the list"
        },
        new()
        {
            Id = 6, Command = "exit",
            Action = _ => Environment.Exit(0), Description = "Exit the program", Shortcut = "e", 
            Doc = $"Usage: {assemblyName} exit\n ???"
        },
    ];
}

static void  PrintMenu(HashSet<MenuItem> menu, string command = "")
{
    ConsoleHelpers.PrintInfo("Available commands:");
    if (command != "")
    {
        ConsoleHelpers.PrintInfo($"Command: {command}\n{menu.FirstOrDefault(x => x.Command == command)?.Doc}");
    }
    foreach (var menuItem in menu)
    {
        ConsoleHelpers.PrintInfo($"{menuItem.Id} - {menuItem.Command} \t-{menuItem.Shortcut} \t: {menuItem.Description}");
    }
}

static void Config(string _) => ConsoleHelpers.PrintError(NOT_IMPLEMENTED_YET);
static void List(string _) => ConsoleHelpers.PrintError(NOT_IMPLEMENTED_YET);
static void Backup(string snapshotName) => ConsoleHelpers.PrintError(NOT_IMPLEMENTED_YET);
static void Restore(string snapshotName) => ConsoleHelpers.PrintError(NOT_IMPLEMENTED_YET);