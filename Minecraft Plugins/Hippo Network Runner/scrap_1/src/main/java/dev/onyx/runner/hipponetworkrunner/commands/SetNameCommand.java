package dev.onyx.runner.hipponetworkrunner.commands;

import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

public class SetNameCommand implements CommandExecutor {

    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (!(sender instanceof Player)) {
            sender.sendMessage("This command can only be executed by a player.");
            return true;
        }

        Player player = (Player) sender;

        if (!player.hasPermission("onyx.admin.naming")) {
            player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
            return true;
        }

        if (args.length < 1) {
            player.sendMessage(ChatColor.RED + "Usage: /" + label + " <name>");
            return true;
        }

        StringBuilder nameBuilder = new StringBuilder();
        for (String arg : args) {
            nameBuilder.append(arg).append(" ");
        }
        String newName = ChatColor.translateAlternateColorCodes('&', nameBuilder.toString().trim());

        ItemStack item = player.getInventory().getItemInMainHand();
        if (item == null || item.getType().isAir()) {
            player.sendMessage(ChatColor.YELLOW + "You must be holding an item to use this command.");
            return true;
        }

        ItemMeta meta = item.getItemMeta();
        if (meta == null) {
            player.sendMessage(ChatColor.RED + "Failed to get item metadata.");
            return true;
        }

        meta.setDisplayName(newName);
        item.setItemMeta(meta);
        player.sendMessage(ChatColor.DARK_GREEN + "Item name set to: " + newName);
        return true;
    }
}