package dev.onyx.gamemode.tntdules.inventories;

import dev.onyx.gamemode.tntdules.functions.CreateInventoryItem;
import dev.onyx.gamemode.tntdules.items.PlatformItem;
import dev.onyx.gamemode.tntdules.items.RailItem;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

public class AllItemInventory implements Listener {

    private final Inventory inventory;
    private final String title = "All TNT Dules Items";

    public AllItemInventory() {
        Inventory _inventory = Bukkit.createInventory(null, 9 * 3, title);

        _inventory.setItem(0, new PlatformItem().getItem());
        _inventory.setItem(1, new RailItem().getItem());
        _inventory.setItem(26, new CreateInventoryItem(new ItemStack(Material.BARRIER), "&9CLOSE", "&aClick to close this menu.").getItem());

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
            if (slot == 0) { player.getInventory().addItem(new PlatformItem().getItem()); }
            if (slot == 1) { player.getInventory().addItem(new RailItem().getItem()); }
            if (slot == 26) { player.closeInventory(); }
            event.setCancelled(true);
        }
    }
}
