package mc.onyxdev.utils.listeners;

import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.block.BlockBreakEvent;

public class blockBreakListener implements Listener {
    @EventHandler
    public void onBlockBreak(BlockBreakEvent event){
        event.getPlayer().sendMessage("Stop greifing the server, ur auto reported.");
    }
}
