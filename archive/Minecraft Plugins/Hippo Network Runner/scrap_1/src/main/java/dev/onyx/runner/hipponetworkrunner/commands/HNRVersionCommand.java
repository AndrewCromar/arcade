package dev.onyx.runner.hipponetworkrunner.commands;

import dev.onyx.runner.hipponetworkrunner.functions.HNRVersion;
import dev.onyx.runner.hipponetworkrunner.inventories.AdminPanelInventory;
import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.Inventory;

public class HNRVersionCommand implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("hnrversion")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            if (!player.hasPermission("onyx.hnr.version")) {
                player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
                return true;
            }

            player.sendMessage(ChatColor.AQUA + "HNR Version: " + HNRVersion.getVersion());

            return true;
        }
        return false;
    }
}
