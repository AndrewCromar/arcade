package dev.onyx.gamemode.tntdules.abilities;

import dev.onyx.gamemode.tntdules.functions.CooldownManager;
import dev.onyx.gamemode.tntdules.functions.Counter;
import dev.onyx.gamemode.tntdules.items.RailItem;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.Particle;
import org.bukkit.Sound;
import org.bukkit.entity.Entity;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerInteractEvent;
import org.bukkit.inventory.ItemStack;
import org.bukkit.plugin.Plugin;
import org.bukkit.plugin.java.JavaPlugin;
import org.bukkit.util.Vector;

public class RailAbility implements Listener {

    Counter counter;
    Plugin plugin;

    public RailAbility(Plugin _plugin) {
        plugin = _plugin;
    }

    @EventHandler
    public void onPlayerRightClick(PlayerInteractEvent event) {
        if (event.getAction().toString().contains("RIGHT")) {
            Player player = event.getPlayer();
            ItemStack itemInHand = player.getInventory().getItemInMainHand();

            if (itemInHand.isSimilar(new RailItem().getItem())) {
                if(counter.getFinished()){
                    counter = new Counter(plugin, 1000, true);

                    // Calculate direction vector based on player's orientation
                    Vector direction = player.getLocation().getDirection();

                    // Spawn red particles in a straight line in the direction the player is facing
                    for (int i = 0; i < 10; i++) { // You can adjust the number of particles
                        player.getWorld().spawnParticle(Particle.REDSTONE, player.getLocation().add(direction.multiply(i)), 1, 0, 0, 0, 1);

                        // Apply damage and knockback to entities hit by the particles
                        for (Entity entity : player.getWorld().getNearbyEntities(player.getLocation(), 1, 1, 1)) {
                            if (entity instanceof Player && !entity.equals(player)) { // Check if it's a player and not the player himself
                                Player target = (Player) entity;
                                target.damage(2); // Adjust damage as needed
                                target.setVelocity(direction.multiply(0.5)); // Adjust knockback strength as needed

                                // Play ding sound when hitting someone
                                player.playSound(player.getLocation(), Sound.BLOCK_NOTE_BLOCK_PLING, 1, 1);
                            }
                        }
                    }
                } else {
                    // Send message to player indicating the ability is on cooldown
                    player.sendMessage(ChatColor.RED + "Rail ability is on cooldown.");
                }
            }
        }
    }
}
