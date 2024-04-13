using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;

namespace SCPFeatures.API;

public static class API
{
    private static Config _config => Plugin.Instance.Config;
    
    public static void CheckZombieConversion(Player player, Player? attacker)
    {
        if (attacker is null || attacker.Role.Type != RoleTypeId.Scp0492) return;
        if (_config.ZombieConversionChance < Random.Range(1, 100)) return;
        
        player.DropItems();
        player.Role.Set(RoleTypeId.Scp0492, RoleSpawnFlags.AssignInventory);
    }
}