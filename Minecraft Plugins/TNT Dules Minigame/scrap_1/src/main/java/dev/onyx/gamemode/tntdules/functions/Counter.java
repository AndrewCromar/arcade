package dev.onyx.gamemode.tntdules.functions;

import org.bukkit.plugin.Plugin;
import org.bukkit.scheduler.BukkitRunnable;

public class Counter {
    private Plugin plugin;
    private boolean countDown;
    private boolean finished;
    private int currentCount;

    public Counter(Plugin _plugin, int _currentCount, boolean _countDown) {
        plugin = _plugin;
        countDown = _countDown;
        currentCount = _currentCount;
        startCounter();
    }

    private void startCounter() {
        new BukkitRunnable() {
            @Override
            public void run() {
                if (!finished) {
                    if (countDown) {
                        currentCount--;
                        if (currentCount <= 0) {
                            finished = true;
                            cancel();
                        }
                    } else {
                        currentCount++;
                    }
                }
            }
        }.runTaskTimer(plugin, 0L, 1L);
    }

    public boolean getFinished() {
        return finished;
    }

    public int getCurrentCount() {
        return currentCount;
    }
}
