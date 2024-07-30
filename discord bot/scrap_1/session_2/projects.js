const { SlashCommandBuilder } = require("discord.js");
const { EmbedBuilder } = require("discord.js");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("projects")
    .setDescription("Sends the projects embeds."),
  async execute(interaction, isAdmin) {
    if (!isAdmin) {
      return interaction.reply({
        content: "You don't have permission to use this command.",
        ephemeral: true,
      });
    }

    const projectsEmbed = new EmbedBuilder()
      .setColor(0x000000)
      .setTitle("Projects")
      .setDescription("Below are all of our the projects.");

    const hellhotelEmbed = new EmbedBuilder()
      .setColor(0xff0000)
      .setTitle("Hell Hotel")
      .setDescription(
        "Hell Hotel is our main project.\n### Hell Hotel is the scariest horror game you will ever play.",
      );

    const juicyEmbed = new EmbedBuilder()
      .setColor(0xffa500)
      .setTitle("Juicy Player Controller")
      .setURL("https://github.com/AndrewCromar/Juicy-Player-Controller")
      .setDescription(
        "Juicy Player Controller is a player controller package for unity.\n### Features:\n- Walking.\n- Running.\n- Crouching.\n- Looking around.\n- Cursor hiding.\n- Fully custom controller tuning.\n- Built in default recommended settings.\n- Helpful error logging.\n- Debug variable in the inspector.\n- Epic logo.\n- Orange flavor (first person).\n- Lemonade flavor (third person).",
      );

    interaction.channel.send({
      embeds: [projectsEmbed, hellhotelEmbed, juicyEmbed],
    });

    return interaction.reply({
      content: "Sent embeds",
      ephemeral: true,
    });
  },
};
