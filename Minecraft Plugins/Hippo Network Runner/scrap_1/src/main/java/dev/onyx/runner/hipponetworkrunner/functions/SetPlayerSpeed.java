package dev.onyx.runner.hipponetworkrunner.functions;

import org.bukkit.entity.Player;

public class SetPlayerSpeed {
    public void setSpeed(Player player, float speed){
        if(speed == 1){
            player.setWalkSpeed(0.2f);
            player.setFlySpeed(0.1f);
        }
        if(speed == 1.5){
            player.setWalkSpeed(0.6f);
            player.setFlySpeed(0.45f);
        }
        if(speed == 2){
            player.setWalkSpeed(1f);
            player.setFlySpeed(1f);
        }
    }
}
