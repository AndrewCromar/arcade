package mc.onyxdev.utils.commands;

import org.bukkit.ChatColor;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Player;

public class speedCommand implements CommandExecutor {

    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("speed")) {
            if (!(sender instanceof Player)) {
                sender.sendMessage(ChatColor.RED + "Only players can use this command.");
                return true;
            }

            Player player = (Player) sender;

            if (!player.hasPermission("onyx.player.speed")) {
                player.sendMessage(ChatColor.RED + "You do not have the correct permissions for this command.");
                return true;
            }

            if (args.length != 1) {
                player.sendMessage(ChatColor.YELLOW + "Usage: /speed [<value -1 to 1>, reset]");
                return true;
            }

            if (args[0].equalsIgnoreCase("reset")) {
                // Reset the player's speed to default
                player.setWalkSpeed(0.2f); // Default walk speed
                player.sendMessage(ChatColor.GREEN + "Your speed has been reset.");
                return true;
            }

            try {
                float speed = Float.parseFloat(args[0]);
                if (speed < -1f || speed > 1f) {
                    player.sendMessage(ChatColor.RED + "Speed must be between -1 and 1.");
                    return true;
                }

                player.setWalkSpeed(speed);
                player.sendMessage(ChatColor.GREEN + "Your speed has been set to " + speed + ".");
            } catch (NumberFormatException e) {
                player.sendMessage(ChatColor.RED + "Invalid speed format.");
            }
            return true;
        }
        return false;
    }
}
