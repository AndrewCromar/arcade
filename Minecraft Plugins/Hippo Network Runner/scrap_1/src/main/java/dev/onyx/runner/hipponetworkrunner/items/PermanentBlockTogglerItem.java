package dev.onyx.runner.hipponetworkrunner.items;

import dev.onyx.runner.hipponetworkrunner.functions.CreateInventoryItem;
import org.bukkit.Material;
import org.bukkit.inventory.ItemStack;

public class PermanentBlockTogglerItem  {
    ItemStack item;

    public PermanentBlockTogglerItem(){
        item = new CreateInventoryItem(new ItemStack(Material.STICK), "Block Permanence Toggler", "Hit a block to toggle its permanence.").getItem();
    }

    public ItemStack getItem(){ return item; }
}
