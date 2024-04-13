using System;
using Exiled.API.Features;

namespace SCPFeatures;

public class Plugin : Plugin<Config>
{
    public static Plugin Instance { get; private set; } = null!;
    
    public override string Name { get; } = "SCPFeatures";
    public override string Author { get; } = "@misfiy";
    public override Version Version { get; } = new(1, 0, 0);
    public override Version RequiredExiledVersion { get; } = new(8, 0, 0);

    private EventHandler _eventHandler { get; set; } = null!;

    public override void OnEnabled()
    {
        Instance = this;
        _eventHandler = new();
        
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        _eventHandler = null!;
        Instance = null!;
        base.OnDisabled();
    }
}