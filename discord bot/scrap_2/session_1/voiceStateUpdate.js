const { Events, ChannelType } = require("discord.js");
const { servers } = require("../config.json");
const generatedVcsData = require("../generated_vcs.json");
const fs = require("fs");

module.exports = {
    name: Events.VoiceStateUpdate,
    async execute(oldState, newState, client) {
        if (newState.member.user.bot) return;

        const serverInfo = servers.find(
            (server) => server.serverId === newState.guild.id,
        );
        if (!serverInfo) return;

        if (newState.channelId !== oldState.channelId) {
            if (newState.channelId === serverInfo.generateVcChannel) {
                const parentCategory = newState.guild.channels.cache.get(
                    serverInfo.generatedVcParent,
                );

                const newChannel = await newState.guild.channels.create({
                    name: `${newState.member.user.username}'s Channel`,
                    type: ChannelType.GuildVoice,
                    parent: parentCategory,
                });

                newState.member.voice.setChannel(newChannel);

                generatedVcsData.generatedVcs.push({ id: newChannel.id });

                fs.writeFileSync(
                    "./generated_vcs.json",
                    JSON.stringify(generatedVcsData, null, 2),
                );
            } else if (oldState.channelId) {
                const index = generatedVcsData.generatedVcs.findIndex(
                    (vc) => vc.id === oldState.channelId,
                );

                if (index !== -1) {
                    const channel = newState.guild.channels.cache.get(
                        oldState.channelId,
                    );
                    if (channel && channel.members.size === 0) {
                        channel.delete();
                        generatedVcsData.generatedVcs.splice(index, 1);
                        fs.writeFileSync(
                            "./generated_vcs.json",
                            JSON.stringify(generatedVcsData, null, 2),
                        );
                    }
                }
            }
        }
    },
};
