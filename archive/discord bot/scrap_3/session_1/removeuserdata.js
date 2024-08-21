const { SlashCommandBuilder } = require("@discordjs/builders");
const { users } = require("../../userdata.json");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("removeuserdata")
    .setDescription("Remove data for a user.")
    .addUserOption((option) =>
      option
        .setName("user")
        .setDescription("The user whose data you want to remove.")
        .setRequired(true),
    ),
  async execute(interaction, isAdmin) {
    if (!isAdmin) {
      return interaction.reply({
        content: "You don't have permission to use this command.",
        ephemeral: true,
      });
    }

    // Extract the user option from the interaction
    const userOption = interaction.options.getUser("user");

    if (!userOption) {
      return interaction.reply({
        content: "Invalid user provided.",
        ephemeral: true,
      });
    }

    // Check if the user has data in the users array
    const existingUserIndex = users.findIndex(
      (u) => u.userId === userOption.id,
    );

    if (existingUserIndex === -1) {
      return interaction.reply({
        content: "No data found for this user.",
        ephemeral: true,
      });
    }

    // Remove data for the user
    users.splice(existingUserIndex, 1);

    // Save the updated users array back to userdata.json
    const fs = require("fs").promises;
    const path = require("path");

    const getUserDataJsonPath = () =>
      path.join(__dirname, "../../userdata.json");

    try {
      await fs.writeFile(
        getUserDataJsonPath(),
        JSON.stringify({ users }, null, 2),
      );
      console.log("User data removed successfully.");
    } catch (error) {
      console.error("Error removing user data:", error);
      return interaction.reply({
        content: "Error removing user data.",
        ephemeral: true,
      });
    }

    return interaction.reply({
      content: `User data removed successfully for ${userOption.username}.`,
      ephemeral: false,
    });
  },
};
