const {
  ActionRowBuilder,
  ButtonBuilder,
  ButtonStyle,
  SlashCommandBuilder,
} = require("discord.js");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("todo")
    .setDescription("Create a todo item.")
    .addStringOption((option) =>
      option
        .setName("item")
        .setDescription("The item for your todo list.")
        .setRequired(true),
    ),
  async execute(interaction, isAdmin, isTodo) {
    if (!isTodo) {
      return interaction.reply({
        content: "You don't have permission to use this command.",
        ephemeral: true,
      });
    }

    const todo_button = new ButtonBuilder()
      .setCustomId("todo_markdone")
      .setEmoji("\u2714")
      .setStyle(ButtonStyle.Success);

    const row = new ActionRowBuilder().addComponents(todo_button);

    await interaction.reply({
      content: interaction.options.getString("item"),
      components: [row],
    });
  },
};
