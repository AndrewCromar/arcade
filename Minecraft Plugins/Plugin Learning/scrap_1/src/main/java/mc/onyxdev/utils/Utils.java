package mc.onyxdev.utils;

import mc.onyxdev.utils.commands.speedCommand;
import mc.onyxdev.utils.inventories.adminPanelInventory;
import mc.onyxdev.utils.listeners.blockBreakListener;
import mc.onyxdev.utils.tabcompleters.knockbackStickTabCompleter;
import mc.onyxdev.utils.tabcompleters.speedTabCompleter;
import org.bukkit.plugin.java.JavaPlugin;

public final class Utils extends JavaPlugin {

    @Override
    public void onEnable() {
        // Plugin startup logic
        System.out.println("Plugin enabled.");

        // Register event listeners.
        getServer().getPluginManager().registerEvents(new blockBreakListener(), this);
        getServer().getPluginManager().registerEvents(new adminPanelInventory(), this); // Register the adminPanelInventory listener

        // Register command listeners.
        getCommand("speed").setExecutor(new speedCommand());
        getCommand("knockbackStick").setExecutor(new mc.onyxdev.utils.commands.knockbackStickCommand());
        getCommand("trash").setExecutor(new mc.onyxdev.utils.commands.trashCommand());
        getCommand("adminPanel").setExecutor(new mc.onyxdev.utils.commands.adminPanelCommand());

        // Register tab completers.
        getCommand("speed").setTabCompleter(new speedTabCompleter());
        getCommand("knockbackStick").setTabCompleter(new knockbackStickTabCompleter());
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic
        System.out.println("Plugin disabled.");
    }
}
