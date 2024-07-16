package dev.onyx.runner.hipponetworkrunner;

import dev.onyx.runner.hipponetworkrunner.commands.*;
import dev.onyx.runner.hipponetworkrunner.inventories.AdminPanelInventory;
import dev.onyx.runner.hipponetworkrunner.inventories.SpeedSelectInventory;
import dev.onyx.runner.hipponetworkrunner.inventories.TrashInventory;
import dev.onyx.runner.hipponetworkrunner.inventories.WorldManagementInventory;
import dev.onyx.runner.hipponetworkrunner.listeners.BlockListener;
import org.bukkit.plugin.java.JavaPlugin;

public final class HippoNetworkRunner extends JavaPlugin {

    @Override
    public void onEnable() {
        // Plugin startup logic

        System.out.println("[ONYX] HNR plugin enabled.");

        // Register event listeners.
        getServer().getPluginManager().registerEvents(new BlockListener(), this);
        getServer().getPluginManager().registerEvents(new AdminPanelInventory(), this);
        getServer().getPluginManager().registerEvents(new WorldManagementInventory(), this);
        getServer().getPluginManager().registerEvents(new SpeedSelectInventory(), this);
        getServer().getPluginManager().registerEvents(new TrashInventory(), this);

        // Register command listeners.
        getCommand("adminPanel").setExecutor(new AdminPanelCommand());
        getCommand("setName").setExecutor(new SetNameCommand());
        getCommand("hnrversion").setExecutor(new HNRVersionCommand());
        getCommand("trash").setExecutor(new TrashCommand());
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic
        System.out.println("[ONYX] HippoNetworkRunner plugin disabled.");
    }
}
