package dev.onyx.runner.hipponetworkrunner.listeners;

import dev.onyx.runner.hipponetworkrunner.items.PermanentBlockTogglerItem;
import org.bukkit.block.Block;
import org.bukkit.configuration.file.FileConfiguration;
import org.bukkit.configuration.file.YamlConfiguration;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.block.BlockBreakEvent;
import org.bukkit.event.player.PlayerInteractEvent;
import org.bukkit.inventory.ItemStack;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class BlockListener implements Listener {
    private Set<String> permanentBlockLocations = new HashSet<>();
    private FileConfiguration config;

    public BlockListener() {
        File configFile = new File("plugins/ONYX/HNR/permanent_blocks.yml");
        config = YamlConfiguration.loadConfiguration(configFile);

        if (config.isList("permanentBlocks")) {
            permanentBlockLocations.addAll(config.getStringList("permanentBlocks"));
        }
    }

    @EventHandler
    public void onBlockBreak(BlockBreakEvent event) {
        Block block = event.getBlock();
        String locationString = block.getLocation().toString();
        if (permanentBlockLocations.contains(locationString)) {
            event.setCancelled(true);
        }
    }

    @EventHandler
    public void onPlayerInteract(PlayerInteractEvent event) {
        Player player = event.getPlayer();
        ItemStack item = event.getItem();
        Block clickedBlock = event.getClickedBlock();

        if (item != null && item.equals(new PermanentBlockTogglerItem().getItem()) && clickedBlock != null) {
            togglePermanent(clickedBlock);
            player.sendMessage("Block permanence toggled.");
        }
    }

    private void togglePermanent(Block block) {
        String locationString = block.getLocation().toString();
        if (permanentBlockLocations.contains(locationString)) {
            permanentBlockLocations.remove(locationString);
        } else {
            permanentBlockLocations.add(locationString);
        }

        config.set("permanentBlocks", new ArrayList<>(permanentBlockLocations));
        try {
            config.save(new File("plugins/ONYX/HNR/permanent_blocks.yml"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
