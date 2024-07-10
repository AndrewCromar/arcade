package mc.onyxdev.utils.inventories;

import org.bukkit.Bukkit;
import org.bukkit.inventory.Inventory;

public class trashInventory {

    private final Inventory inventory;

    public trashInventory() {
        inventory = Bukkit.createInventory(null, 9 * 4, "Trash");
    }

    public Inventory getInventory() {
        return inventory;
    }
}
