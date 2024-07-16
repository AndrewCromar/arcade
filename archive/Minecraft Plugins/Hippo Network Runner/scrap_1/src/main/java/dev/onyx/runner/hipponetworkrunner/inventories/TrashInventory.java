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

public class TrashInventory implements Listener {

    private final Inventory inventory;
    private final String title = "Trash";


    public TrashInventory() {
        Inventory _inventory = Bukkit.createInventory(null, 9 * 3, title);

        _inventory.setItem(26, new CreateInventoryItem(new ItemStack(Material.BARRIER), ChatColor.BLUE + "Trash", ChatColor.RED + "THIS CANNOT BE UNDONE.").getItem());

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
            if (slot == 26) { player.closeInventory(); }
        }
    }
}
