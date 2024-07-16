package mc.onyxdev.utils.commands;

import mc.onyxdev.utils.inventories.adminPanelInventory;
import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.Inventory;

public class adminPanelCommand implements CommandExecutor {
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

            // Create an instance of your admin panel inventory
            Inventory adminInventory = new adminPanelInventory().getInventory();

            // Open the inventory for the player
            player.openInventory(adminInventory);

            return true;
        }
        return false;
    }
}
