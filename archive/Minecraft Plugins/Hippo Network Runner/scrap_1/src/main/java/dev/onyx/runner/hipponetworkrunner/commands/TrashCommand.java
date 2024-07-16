package dev.onyx.runner.hipponetworkrunner.commands;

import dev.onyx.runner.hipponetworkrunner.inventories.TrashInventory;
import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;

public class TrashCommand implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("trash")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            if (!player.hasPermission("onyx.trash")) {
                player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
                return true;
            }

            // Open the inventory for the player
            player.openInventory(new TrashInventory().getInventory());

            return true;
        }
        return false;
    }
}
