package mc.onyxdev.utils.commands;

import mc.onyxdev.utils.inventories.trashInventory;
import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.Inventory;

public class trashCommand implements CommandExecutor {
    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("trash")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            // Create an instance of your admin panel inventory
            Inventory trashInventory = new trashInventory().getInventory();

            // Open the inventory for the player
            player.openInventory(trashInventory);

            return true;
        }
        return false;
    }
}
