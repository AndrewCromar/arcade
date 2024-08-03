const { SlashCommandBuilder } = require("discord.js");
const { users } = require("../../userdata.json");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("balance")
    .setDescription("Check your coin balance."),
  async execute(interaction) {
    const userId = interaction.user.id;
    const user = users.find((u) => u.userId === userId);

    if (!user) {
      return interaction.reply({
        content:
          "Can't find data for you. Contact an admin to initialize your account.",
        ephemeral: true, // Send the message as ephemeral
      });
    }

    const balance = user.balance;

    await interaction.reply(`Your current balance is: ${balance} coins.`);
  },
};
