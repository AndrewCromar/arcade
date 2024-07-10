package mc.onyxdev.utils.inventories;

import org.bukkit.Bukkit;
import org.bukkit.Material;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.inventory.InventoryClickEvent;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

public class adminPanelInventory implements Listener {

    private final Inventory inventory;

    public adminPanelInventory() {
        inventory = Bukkit.createInventory(null, 9 * 3, "Admin Panel");

        // Add items to the inventory using inventory.addItem() method
        // Example:
        ItemStack playerHead = new ItemStack(Material.PLAYER_HEAD);
        ItemMeta meta = playerHead.getItemMeta();
        meta.setDisplayName("Player List");
        playerHead.setItemMeta(meta);
        inventory.setItem(13, playerHead);
    }

    public Inventory getInventory() {
        return inventory;
    }

    @EventHandler
    public void onInventoryClick(InventoryClickEvent event) {

        if (event.getClickedInventory() == null) return;

        if (event.getClickedInventory().equals(new adminPanelInventory())) {
            if (event.getCurrentItem().getType() == Material.PLAYER_HEAD) {
                Player player = (Player) event.getWhoClicked();
                player.sendMessage("YOU CLICK THE HEAD");
                player.closeInventory();
                playerListInventory _playerListInventory = new playerListInventory();
                player.openInventory(_playerListInventory.getInventory());
            }
        }
    }
}
