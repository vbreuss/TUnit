using TUnit.Core.Logging;

namespace TUnit.Core;

public class GlobalContext : Context
{
    public new static GlobalContext Current { get; } = new();
    
    private GlobalContext()
    {
    }

    internal ILogger GlobalLogger { get; set; } = new NullLogger();
    
    public string? TestFilter { get; internal set; }
}