package dev.onyx.gamemode.tntdules;

import dev.onyx.gamemode.tntdules.abilities.RailAbility;
import dev.onyx.gamemode.tntdules.abilities.PlatformAbility;
import dev.onyx.gamemode.tntdules.commands.AllItemCommand;
import dev.onyx.gamemode.tntdules.functions.CooldownManager;
import dev.onyx.gamemode.tntdules.inventories.AllItemInventory;
import org.bukkit.plugin.java.JavaPlugin;

public final class TNTDulesGamemode extends JavaPlugin {

    @Override
    public void onEnable() {
        // Plugin startup logic
        System.out.println("[ONYX] TNT plugin enabled.");

        // Initialize some variables.
        CooldownManager cooldownManager = new CooldownManager(1000);

        // Register event listeners.
        getServer().getPluginManager().registerEvents(new PlatformAbility(this), this);
        getServer().getPluginManager().registerEvents(new RailAbility(this), this);
        getServer().getPluginManager().registerEvents(new AllItemInventory(), this);

        // Register command listeners.
        getCommand("allItems").setExecutor(new AllItemCommand());
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic
        System.out.println("[ONYX] TNT plugin disabled.");
    }
}
