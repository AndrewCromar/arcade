package mc.onyxdev.utils.commands;

import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.enchantments.Enchantment;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

import java.util.Collections;

public class knockbackStickCommand implements CommandExecutor {

    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("knockbackStick") || command.getName().equalsIgnoreCase("kbs")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            if (!player.hasPermission("onyx.items.knockbackstick")) {
                player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
                return true;
            }

            if (args.length != 1) {
                player.sendMessage(ChatColor.YELLOW + "Usage: /knockbackStick <knockbacklvl>");
                return true;
            }

            try {
                int knockbackLevel = Integer.parseInt(args[0]);

                // Create knockback stick
                ItemStack knockbackStick = new ItemStack(Material.STICK);
                ItemMeta meta = knockbackStick.getItemMeta();
                meta.setDisplayName("Knockback Stick");
                // Enchant the stick with Knockback
                meta.addEnchant(Enchantment.KNOCKBACK, knockbackLevel, true);
                knockbackStick.setItemMeta(meta);

                // Give knockback stick to the player
                player.getInventory().addItem(knockbackStick);
                player.sendMessage(ChatColor.GREEN + "You've received a knockback stick with level " + knockbackLevel + ".");
            } catch (NumberFormatException e) {
                player.sendMessage(ChatColor.RED + "Invalid knockback level format.");
            }
            return true;
        }
        return false;
    }
}
