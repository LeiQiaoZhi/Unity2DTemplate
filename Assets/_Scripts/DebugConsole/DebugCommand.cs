using System.Collections;

public class DebugCommand
{
    public readonly string CommandName;
    public delegate string DebugAction(DebugConsole debugConsole);

    public readonly DebugAction action;

    // constructor
    public DebugCommand(string name, DebugAction a)
    {
        CommandName = name;
        action = a;
    }

    public string Raise(DebugConsole debugConsole)
    {
        return action.Invoke(debugConsole);
    }
}