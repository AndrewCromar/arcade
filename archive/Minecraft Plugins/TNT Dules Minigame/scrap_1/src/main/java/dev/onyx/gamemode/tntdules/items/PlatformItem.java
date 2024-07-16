package dev.onyx.gamemode.tntdules.items;

import dev.onyx.gamemode.tntdules.functions.CreateInventoryItem;
import org.bukkit.Material;
import org.bukkit.inventory.ItemStack;

public class PlatformItem {
    ItemStack item;

    public PlatformItem(){
        item = new CreateInventoryItem(new ItemStack(Material.SMOOTH_STONE), "Platform", "Crouch to use.").getItem();
    }

    public ItemStack getItem(){ return item; }
}
