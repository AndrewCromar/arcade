package dev.onyx.runner.hipponetworkrunner.inventories;

import dev.onyx.runner.hipponetworkrunner.functions.CreateInventoryItem;
import dev.onyx.runner.hipponetworkrunner.items.PermanentBlockTogglerItem;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

public class WorldManagementInventory implements Listener {

    private final Inventory inventory;
    private final String title = "World Management";

    public WorldManagementInventory() {
        Inventory _inventory = Bukkit.createInventory(null, 9 * 3, title);

        _inventory.setItem(13, new CreateInventoryItem(new ItemStack(Material.STICK), ChatColor.BLUE + "Block Permanence Toggler", ChatColor.GREEN + "Click to get.").getItem());
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
            if (slot == 13) { player.getInventory().addItem(new PermanentBlockTogglerItem().getItem()); }
            if (slot == 25) { player.openInventory(new AdminPanelInventory().getInventory()); }
            if (slot == 26) { player.closeInventory(); }
            event.setCancelled(true);
        }
    }
}
