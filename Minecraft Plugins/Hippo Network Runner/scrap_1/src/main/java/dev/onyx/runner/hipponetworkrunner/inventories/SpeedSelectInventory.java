package dev.onyx.runner.hipponetworkrunner.inventories;

import dev.onyx.runner.hipponetworkrunner.functions.CreateInventoryItem;
import dev.onyx.runner.hipponetworkrunner.functions.SetPlayerSpeed;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

public class SpeedSelectInventory implements Listener {

    private final Inventory inventory;
    private final String title = "Speed Select";

    public SpeedSelectInventory() {
        Inventory _inventory = Bukkit.createInventory(null, 9 * 3, title);

        _inventory.setItem(11, new CreateInventoryItem(new ItemStack(Material.GREEN_WOOL), ChatColor.BLUE + "Default Speed", ChatColor.GREEN + "Click to select.").getItem());
        _inventory.setItem(13, new CreateInventoryItem(new ItemStack(Material.YELLOW_WOOL), ChatColor.BLUE + "1.5x Speed", ChatColor.GREEN + "Click to select.").getItem());
        _inventory.setItem(15, new CreateInventoryItem(new ItemStack(Material.RED_WOOL), ChatColor.BLUE + "2x Speed", ChatColor.GREEN + "Click to select.").getItem());
        _inventory.setItem(25, new CreateInventoryItem(new ItemStack(Material.ARROW), ChatColor.BLUE + "BACK", ChatColor.GREEN + "Click to go back.").getItem());
        _inventory.setItem(26, new CreateInventoryItem(new ItemStack(Material.BARRIER), ChatColor.BLUE + "CLOSE", ChatColor.GREEN + "Click to close this menu.").getItem());

        inventory = _inventory;
    }

    public Inventory getInventory() {
        return inventory;
    }

    @EventHandler
    public void onInventoryClick(InventoryClickEvent event) {
        Player player = (Player) event.getWhoClicked();
        int slot = event.getSlot();

        if (event.getView().getTitle().equals(title)) {
            if (slot == 11) {
                new SetPlayerSpeed().setSpeed(player, 1f);
                player.sendMessage(ChatColor.GREEN + "Your speed has been set to the default speed.");
            }
            if (slot == 13) {
                new SetPlayerSpeed().setSpeed(player, 1.5f);
                player.sendMessage(ChatColor.GREEN + "Your speed has been set to 1.5x the default speed.");
            }
            if (slot == 15) {
                new SetPlayerSpeed().setSpeed(player, 2f);
                player.sendMessage(ChatColor.GREEN + "Your speed has been set to 2x the default speed.");
            }
            if (slot == 25) { player.openInventory(new AdminPanelInventory().getInventory()); }
            if (slot == 26) { player.closeInventory(); }
            event.setCancelled(true);
        }
    }
}
