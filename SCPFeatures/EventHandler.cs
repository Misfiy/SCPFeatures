using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using SCPFeatures.API.Enums;
using static SCPFeatures.API.API;

namespace SCPFeatures;

public class EventHandler
{
    private Config _config => Plugin.Instance.Config;
    
    internal EventHandler()
    {
        switch (_config.ZombieConversionType)
        {
            case ZombieConversionType.OnHurt:
                Exiled.Events.Handlers.Player.Hurt += ZombieHurtingConversion;
                break;
            case ZombieConversionType.OnDeath:
                Exiled.Events.Handlers.Player.Died += ZombieDeathConversion;
                break;
        }

        if (!_config.BleedingDamageTypes.IsEmpty())
        {
            Exiled.Events.Handlers.Player.Hurt += DoBleeding;
            Exiled.Events.Handlers.Player.UsingItemCompleted += DoBleedingCure;
        }
    }

    ~EventHandler()
    {
        switch (_config.ZombieConversionType)
        {
            case ZombieConversionType.OnHurt:
                Exiled.Events.Handlers.Player.Hurt -= ZombieHurtingConversion;
                break;
            case ZombieConversionType.OnDeath:
                Exiled.Events.Handlers.Player.Died -= ZombieDeathConversion;
                break;
        }
        
        if (!_config.BleedingDamageTypes.IsEmpty())
        {
            Exiled.Events.Handlers.Player.Hurt -= DoBleeding;
            Exiled.Events.Handlers.Player.UsingItemCompleted -= DoBleedingCure;
        }
    }

    private void DoBleeding(HurtEventArgs ev)
    {
        if (ev.Player.IsScp || !_config.BleedingDamageTypes.Contains(ev.DamageHandler.Type)) return;

        ev.Player.EnableEffect(EffectType.Bleeding);
    }

    private void DoBleedingCure(UsingItemCompletedEventArgs ev)
    {
        if (!_config.BleedingCures.Contains(ev.Usable.Type)) return;

        ev.Player.DisableEffect(EffectType.Bleeding);
    }
    
    private void ZombieHurtingConversion(HurtEventArgs ev) => CheckZombieConversion(ev.Player, ev.Attacker);
    private void ZombieDeathConversion(DiedEventArgs ev) => CheckZombieConversion(ev.Player, ev.Attacker);
}