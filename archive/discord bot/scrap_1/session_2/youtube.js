const { SlashCommandBuilder } = require("discord.js");
const { EmbedBuilder } = require("discord.js");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("youtube")
    .setDescription("Sends the youtube embed."),
  async execute(interaction, isAdmin) {
    if (!isAdmin) {
      return interaction.reply({
        content: "You don't have permission to use this command.",
        ephemeral: true,
      });
    }

    const youtubeEmbed = new EmbedBuilder()
      .setColor(0xff0000)
      .setTitle("Youtube")
      .setURL("https://youtube.com/@ONYXDevelopment/")
      .setDescription(
        "- We will be uploading devlogs, trailers, and sneek-peeks to this channel.\n- We may even stream development to this channel sometimes.",
      );

    interaction.channel.send({ embeds: [youtubeEmbed] });

    return interaction.reply({
      content: "Sent embed.",
      ephemeral: true,
    });
  },
};
