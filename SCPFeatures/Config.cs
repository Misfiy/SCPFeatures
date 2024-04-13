using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using PlayerRoles;
using SCPFeatures.API.Enums;
using SCPFeatures.API.Objects;

namespace SCPFeatures;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = true;

    // <--------- Zombie Conversion --------->
    [Description("When zombies should convert, OnHurt / OnDeath")]
    public ZombieConversionType ZombieConversionType { get; set; } = ZombieConversionType.OnDeath;
    [Description("Chance of a zombie convertting a player")]
    public ushort ZombieConversionChance { get; set; } = 50;
    
    // <--------- Bleeding Feature --------->
    [Description("Bleeding")]

    public List<DamageType> BleedingDamageTypes { get; set; } = new()
    {
        DamageType.AK,
        DamageType.Com15,
        DamageType.Com18,
        DamageType.Com45,
        DamageType.Crossvec,
        DamageType.E11Sr,
        DamageType.Firearm,
        DamageType.Fsp9,
        DamageType.Logicer,
        DamageType.Revolver,
        DamageType.Shotgun,
        DamageType.Falldown,
    };
    public List<ItemType> BleedingCures { get; set; } = new()
    {
        ItemType.SCP500,
        ItemType.Medkit,
        ItemType.Painkillers
    };
    public Broadcaster BleedingBroadcast { get; set; } = new()
    {
        Text = "You're bleeding! Use a medical item to get rid of the bleeding!",
        Duration = 5,
        Type = BroadcasterType.Hint
    };
}