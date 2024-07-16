package dev.onyx.gamemode.tntdules.abilities;

import dev.onyx.gamemode.tntdules.functions.CooldownManager;
import dev.onyx.gamemode.tntdules.functions.Counter;
import dev.onyx.gamemode.tntdules.items.PlatformItem;
import org.bukkit.Material;
import org.bukkit.block.Block;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerToggleSneakEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.plugin.Plugin;

import java.util.ArrayList;
import java.util.List;

public class PlatformAbility implements Listener {
    Counter counter;
    Plugin plugin;

    public PlatformAbility(Plugin _plugin){
        plugin = _plugin;
    }

    @EventHandler
    public void onPlayerToggleSneak(PlayerToggleSneakEvent event) {
        Player player = event.getPlayer();
        if (event.isSneaking() && counter.getFinished()) {
            Block blockBelowPlayer = player.getLocation().subtract(0, 1, 1).getBlock();
            if (blockBelowPlayer.getType().equals(Material.AIR)) {
                ItemStack platformItem = new PlatformItem().getItem();
                if (hasItem(player, platformItem)) {
                    counter = new Counter(plugin, 1000, true);
                    removeItem(player, platformItem);
                    createPlatform(player);
                }
            }
        }
    }

    private boolean hasItem(Player player, ItemStack item) {
        for (ItemStack stack : player.getInventory().getContents()) {
            if (stack != null && stack.isSimilar(item)) {
                return true;
            }
        }
        return false;
    }

    private void removeItem(Player player, ItemStack item) {
        player.getInventory().removeItem(item);
    }

    private void createPlatform(Player player) {
        List<Block> blocksToCheck = new ArrayList<>();
        blocksToCheck.add(player.getLocation().subtract(-1, 1, 1).getBlock());
        blocksToCheck.add(player.getLocation().subtract(0, 1, 1).getBlock());
        blocksToCheck.add(player.getLocation().subtract(1, 1, 1).getBlock());
        blocksToCheck.add(player.getLocation().subtract(-1, 1, 0).getBlock());
        blocksToCheck.add(player.getLocation().subtract(0, 1, 0).getBlock());
        blocksToCheck.add(player.getLocation().subtract(1, 1, 0).getBlock());
        blocksToCheck.add(player.getLocation().subtract(-1, 1, -1).getBlock());
        blocksToCheck.add(player.getLocation().subtract(0, 1, -1).getBlock());
        blocksToCheck.add(player.getLocation().subtract(1, 1, -1).getBlock());

        for (Block blockBelowPlayer : blocksToCheck) {
            if (blockBelowPlayer.getType().equals(Material.AIR)) {
                blockBelowPlayer.setType(Material.SMOOTH_STONE);
            }
        }
    }
}