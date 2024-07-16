package dev.onyx.gamemode.tntdules.functions;

import org.bukkit.ChatColor;
import org.bukkit.inventory.ItemStack;
import org.bukkit.inventory.meta.ItemMeta;

import java.util.ArrayList;
import java.util.List;

public class CreateInventoryItem {
    ItemStack item;

    public CreateInventoryItem(ItemStack _item, String name, String... lore){
        ItemMeta meta = _item.getItemMeta();

        meta.setDisplayName(ChatColor.translateAlternateColorCodes('&', name));

        List<String> lores = new ArrayList<>();
        for(String s : lore){ lores.add(ChatColor.translateAlternateColorCodes('&', s)); }
        meta.setLore(lores);

        _item.setItemMeta(meta);
        item = _item;
    }

    public ItemStack getItem(){ return item; }
}
