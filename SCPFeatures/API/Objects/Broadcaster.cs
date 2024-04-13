using Exiled.API.Features;
using SCPFeatures.API.Enums;

namespace SCPFeatures.API.Objects;

public class Broadcaster
{
    public string Text { get; set; }
    public ushort Duration { get; set; }
    public BroadcasterType Type { get; set; }

    public void Show(Player player)
    {
        if (Text.IsEmpty() || Duration == 0) return;
        
        switch (Type)
        {
            case BroadcasterType.Broadcast: player.Broadcast(Duration, Text); break;
            case BroadcasterType.Hint: player.ShowHint(Text, Duration); break;
        }
    }
}