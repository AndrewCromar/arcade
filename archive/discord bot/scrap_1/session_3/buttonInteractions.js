const { Events } = require("discord.js");
const { servers } = require("../config.json");

module.exports = {
  name: Events.InteractionCreate,
  async execute(interaction) {
    const serverInfo = servers.find(
      (server) => server.serverId === interaction.guildId,
    );

    if (!serverInfo) {
      console.error(
        `Server information not found for guildId: ${interaction.guildId}`,
      );
      return;
    }

    const isAdmin = interaction.member.roles.cache.has(serverInfo.adminRoleId);
    const isTodo = interaction.member.roles.cache.has(serverInfo.todoRoleId);

    if (interaction.customId === "todo_markdone") {
      if (!isTodo) {
        return interaction.reply({
          content: "You don't have permission to use this command.",
          ephemeral: true,
        });
      }

      interaction.message.delete();
      interaction.channel.send("~~" + interaction.message.content + "~~");
    }
  },
};
