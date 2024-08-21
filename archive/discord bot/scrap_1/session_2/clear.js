const { SlashCommandBuilder } = require("@discordjs/builders");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("clear")
    .setDescription("Clears the select amount of messages from the channel.")
    .addIntegerOption((option) =>
      option
        .setName("amount")
        .setDescription("The amount of messages to clear.")
        .setMinValue(1)
        .setRequired(true),
    )
    .addBooleanOption((option) =>
      option
        .setName("leavebotmessages")
        .setDescription("Wether or not to leave bot messages."),
    ),
  async execute(interaction, isAdmin) {
    if (!isAdmin) {
      return interaction.reply({
        content: "You don't have permission to use this command.",
        ephemeral: true,
      });
    }

    const amount = interaction.options.getInteger("amount");
    const leavebotmessages =
      interaction.options.getBoolean("leavebotmessages") || false;

    interaction.reply({ content: "Cleared messages.", ephemeral: true });

    await interaction.channel.messages
      .fetch({ limit: amount })
      .then((messages) => {
        const filteredMessages = messages.filter((message) => {
          const messageAgeInDays =
            (Date.now() - message.createdTimestamp) / (1000 * 60 * 60 * 24);

          if (leavebotmessages) {
            // Only delete messages from bots
            return !message.author.bot && messageAgeInDays < 14;
          } else {
            // Delete messages based on the original criteria
            return messageAgeInDays < 14;
          }
        });

        interaction.channel.bulkDelete(filteredMessages);
      });
  },
};
