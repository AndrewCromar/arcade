package mc.onyxdev.utils.inventories;

import org.bukkit.Bukkit;
import org.bukkit.inventory.Inventory;

public class playerListInventory {

    private final Inventory inventory;

    public playerListInventory() {
        inventory = Bukkit.createInventory(null, 9 * 3, "Player List");
    }

    public Inventory getInventory() {
        return inventory;
    }
}
