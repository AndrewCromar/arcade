const { SlashCommandBuilder } = require("@discordjs/builders");
const { users } = require("../../userdata.json");

module.exports = {
  data: new SlashCommandBuilder()
    .setName("adduserdata")
    .setDescription("Add data for a user.")
    .addUserOption((option) =>
      option
        .setName("user")
        .setDescription("The user whose data you want to add.")
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

    // Check if the user already has data in the users array
    const existingUser = users.find((u) => u.userId === userOption.id);

    if (existingUser) {
      return interaction.reply({
        content: "Data already exists for this user.",
        ephemeral: true,
      });
    }

    // Add data for the new user
    users.push({
      userId: userOption.id,
      balance: 0,
    });

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
      console.log("User data saved successfully.");
    } catch (error) {
      console.error("Error saving user data:", error);
      return interaction.reply({
        content: "Error saving user data.",
        ephemeral: true,
      });
    }

    return interaction.reply({
      content: `User data added successfully for ${userOption.username}.`,
      ephemeral: false,
    });
  },
};
