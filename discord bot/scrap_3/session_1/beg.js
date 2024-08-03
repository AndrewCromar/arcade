const { SlashCommandBuilder } = require("discord.js");
const { users } = require("../../userdata.json");
const fs = require("fs").promises;
const path = require("path");

// Function to get the absolute path to the economy.json file
function getEconomyJsonPath() {
  return path.join(__dirname, "../../userdata.json");
}

// Function to save user data to the file
async function saveUserData() {
  const filePath = getEconomyJsonPath();
  try {
    await fs.writeFile(filePath, JSON.stringify({ users }, null, 2));
  } catch (error) {
    console.error("Error saving user data:", error);
  }
}

module.exports = {
  data: new SlashCommandBuilder()
    .setName("beg")
    .setDescription("Beg for coins."),
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

    const coins = Math.floor(Math.random() * 10) + 1;
    user.balance += coins;

    // Save the updated users array back to economy.json asynchronously
    await saveUserData();

    await interaction.reply(
      `You begged for coins and got: ${coins} coins. Your total balance is now: ${user.balance} coins.`,
    );
  },
};
