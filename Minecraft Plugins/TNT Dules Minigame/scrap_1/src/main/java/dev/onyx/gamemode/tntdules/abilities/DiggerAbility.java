package dev.onyx.gamemode.tntdules.abilities;

import dev.onyx.gamemode.tntdules.functions.CooldownManager;
import dev.onyx.gamemode.tntdules.functions.Counter;
import dev.onyx.gamemode.tntdules.items.DiggerItem;
import dev.onyx.gamemode.tntdules.items.RailItem;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.Particle;
import org.bukkit.Sound;
import org.bukkit.block.Block;
import org.bukkit.entity.Entity;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerInteractEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.plugin.Plugin;
import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.util.Vector;
import java.util.ArrayList;
import java.util.List;

public class DiggerAbility implements Listener {

    Counter counter;
    Plugin plugin;

    public DiggerAbility(Plugin _plugin) {
        plugin = _plugin;
    }

    @EventHandler
    public void onPlayerLeftClick(PlayerInteractEvent event) {
        if (event.getAction().toString().contains("LEFT")) {
            Player player = event.getPlayer();
            ItemStack itemInHand = player.getInventory().getItemInMainHand();

            if (itemInHand.isSimilar(new DiggerItem().getItem())) {
                if(counter.getFinished()){
                    counter = new Counter(plugin, 1000, true);

                    Block clickedBlock = event.getClickedBlock();
                    List<Block> blocksToCheck = getBlocksToCheck(clickedBlock);

                    for(Block block : blocksToCheck){
                        if(!block.getType().equals(Material.BEDROCK)){
                            block.setType(Material.AIR);
                        }
                    }
                } else {
                    player.sendMessage(ChatColor.RED + "Digger ability is on cooldown.");
                }
            }
        }
    }

    private List<Block> getBlocksToCheck(Block blockClicked){
        List<Block> blocksToCheck = new ArrayList<>();

        // add blocks inside the 3x3 area around the blockClicked
        int radius = 1; // Change this to the desired radius
        for (int x = -radius; x <= radius; x++) {
            for (int y = -radius; y <= radius; y++) {
                for (int z = -radius; z <= radius; z++) {
                    Block block = blockClicked.getRelative(x, y, z);
                    if (block.getType() != Material.AIR) { // Only add non-air blocks
                        blocksToCheck.add(block);
                    }
                }
            }
        }

        return blocksToCheck;
    }
}
