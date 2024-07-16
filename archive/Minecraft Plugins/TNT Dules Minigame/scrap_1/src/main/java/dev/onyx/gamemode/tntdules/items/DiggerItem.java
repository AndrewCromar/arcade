package dev.onyx.gamemode.tntdules.items;

import dev.onyx.gamemode.tntdules.functions.CreateInventoryItem;
import org.bukkit.Material;
import org.bukkit.inventory.ItemStack;

public class DiggerItem {
    ItemStack item;

    public DiggerItem(){
        item = new CreateInventoryItem(new ItemStack(Material.STONE_SHOVEL), "Digger", "Hit a block to use.").getItem();
    }

    public ItemStack getItem(){ return item; }
}
