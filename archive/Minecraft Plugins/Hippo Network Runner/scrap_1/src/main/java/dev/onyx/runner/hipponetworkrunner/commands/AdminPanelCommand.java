package dev.onyx.runner.hipponetworkrunner.commands;

import dev.onyx.runner.hipponetworkrunner.inventories.AdminPanelInventory;
import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.Inventory;

public class AdminPanelCommand implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("adminpanel")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            if (!player.hasPermission("onyx.admin.panel")) {
                player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
                return true;
            }

            // Open the inventory for the player
            player.openInventory(new AdminPanelInventory().getInventory());

            return true;
        }
        return false;
    }
}
