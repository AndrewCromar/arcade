package dev.onyx.gamemode.tntdules.functions;

import org.bukkit.entity.Player;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public class CooldownManager {
    private final Map<UUID, Map<String, Long>> cooldowns = new HashMap<>();
    private final long defaultCooldown;

    public CooldownManager(long defaultCooldown) {
        this.defaultCooldown = defaultCooldown;
    }

    public void setCooldown(Player player, String abilityKey) {
        UUID playerId = player.getUniqueId();
        cooldowns.putIfAbsent(playerId, new HashMap<>());
        cooldowns.get(playerId).put(abilityKey, System.currentTimeMillis());
    }

    public boolean isOnCooldown(Player player, String abilityKey) {
        UUID playerId = player.getUniqueId();
        if (!cooldowns.containsKey(playerId)) return false;

        Map<String, Long> playerCooldowns = cooldowns.get(playerId);
        if (!playerCooldowns.containsKey(abilityKey)) return false;

        long currentTime = System.currentTimeMillis();
        long lastUsed = playerCooldowns.get(abilityKey);

        return (currentTime - lastUsed) < defaultCooldown;
    }
}
