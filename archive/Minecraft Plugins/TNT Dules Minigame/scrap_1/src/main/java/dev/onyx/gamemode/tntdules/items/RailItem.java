package dev.onyx.gamemode.tntdules.items;

import dev.onyx.gamemode.tntdules.functions.CreateInventoryItem;
import org.bukkit.Material;
import org.bukkit.inventory.ItemStack;

public class RailItem {
    ItemStack item;

    public RailItem(){
        item = new CreateInventoryItem(new ItemStack(Material.REDSTONE_TORCH), "Rail", "Right click to use.").getItem();
    }

    public ItemStack getItem(){ return item; }
}
