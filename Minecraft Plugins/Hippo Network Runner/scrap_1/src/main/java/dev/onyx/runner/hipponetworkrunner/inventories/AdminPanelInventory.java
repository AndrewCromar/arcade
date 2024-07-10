package dev.onyx.runner.hipponetworkrunner.inventories;

import dev.onyx.runner.hipponetworkrunner.functions.CreateInventoryItem;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

public class AdminPanelInventory implements Listener {

    private final Inventory inventory;
    private final String title = "Admin Menu";


    public AdminPanelInventory() {
        Inventory _inventory = Bukkit.createInventory(null, 9 * 3, title);

        _inventory.setItem(12, new CreateInventoryItem(new ItemStack(Material.GRASS_BLOCK), ChatColor.BLUE + "World Management", ChatColor.GREEN + "Click to open menu.").getItem());
        _inventory.setItem(14, new CreateInventoryItem(new ItemStack(Material.GREEN_WOOL), ChatColor.BLUE + "Speed Selection", ChatColor.GREEN + "Click to open menu.").getItem());
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
            if (slot == 12) { player.openInventory(new WorldManagementInventory().getInventory()); }
            if (slot == 14) { player.openInventory(new SpeedSelectInventory().getInventory()); }
            if (slot == 26) { player.closeInventory(); }
            event.setCancelled(true);
        }
    }
}
