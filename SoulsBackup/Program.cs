using System.Diagnostics.CodeAnalysis;
using SoulsBackup;

ConsoleHelpers.PrintHeader("SoulsBackup");

var menu = GetMenu();
PrintMenu(menu);
while (true)
{
    ConsoleHelpers.PrintInfo("Enter a command: ");
    var commandWithArguments  = Console.ReadLine()?.Split(' ');
    
    var command = commandWithArguments?.FirstOrDefault() ?? "help";
    var argument = commandWithArguments?.Skip(1).FirstOrDefault() ?? string.Empty;
    
    if( int.TryParse(command, out var menuItem) )
    {
        var item = menu.FirstOrDefault(x => x.Id == menuItem);
        item?.Action(string.Empty);
        ConsoleHelpers.PrintLine();
        continue;
    }
    
    menu.FirstOrDefault(x => x.Command == command || x.Shortcut == command)?.Action(argument);
    ConsoleHelpers.PrintLine();
}

static HashSet<MenuItem> GetMenu() => [
    new() { Id = 1, Command = "config", Action = _ => Config(), Description = "Configure the backup", Shortcut = "c" },
    new() { Id = 2,  Command = "list", Action = _ => List(), Description = "List available backups", Shortcut = "l"},
    new() { Id = 3,  Command = "backup", Action = Backup, Description = "Backup to a snapshot", Shortcut = "b" },
    new() { Id = 4,  Command = "restore", Action = Restore, Description = "Restore from the snapshot", Shortcut = "r" },
    new() { Id = 5,  Command = "help", Action = (c) => PrintMenu(GetMenu(),c), Description = "Print this", Shortcut = "?"},
    new() { Id = 6,  Command = "exit", Action = _ => Environment.Exit(0), Description = "Exit the program", Shortcut = "e" },
];

static void  PrintMenu(HashSet<MenuItem> menu,string command = "")
{
    ConsoleHelpers.PrintInfo("Available commands:");
    
    foreach (var menuItem in menu)
    {
        ConsoleHelpers.PrintInfo($"{menuItem.Id} - {menuItem.Command} \t-{menuItem.Shortcut} \t: {menuItem.Description}");
    }
}

static void Config() => ConsoleHelpers.PrintInfo("Not implemented yet");
static void List() => ConsoleHelpers.PrintInfo("Not implemented yet");
static void Backup(string snapshotName) => ConsoleHelpers.PrintInfo("Not implemented yet");
static void Restore(string snapshotName) => ConsoleHelpers.PrintInfo("Not implemented yet");
public record MenuItem
{
    private static int _count = 1;
    public MenuItem()
    {
    }

    [SetsRequiredMembers]
    public MenuItem(string command, Action<string> action, string description = "", string shortcut = "")
    {
        Command = command;
        Action = action;
        Description = description;
        Shortcut = shortcut;
    }

    public int Id { get; init; } = _count++;

    public required string Command { get; init; }
    public required Action<string> Action { get; init; }
    
    public string Description { get; init; } = string.Empty;
    
    public string Shortcut { get; init; } = string.Empty;
}