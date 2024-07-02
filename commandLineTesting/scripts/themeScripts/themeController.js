let currentActiveThemeId; // Initialize currentActiveThemeId

function ThemeCommandClicked(command) {
    SetThemeHREF(command.details.toLowerCase());
    localStorage.setItem("theme", command.details.toLowerCase());

    if (currentActiveThemeId !== undefined) {
        const previousActiveCommand = commands.find(cmd => cmd.id === currentActiveThemeId);
        if (previousActiveCommand) {
            previousActiveCommand.isActive = false;
        }
    }

    command.isActive = true;

    currentActiveThemeId = command.id;

    ForceReloadResults();
}

function ThemeCommandMouseEnter(command) {
    SetThemeHREF(command.details.toLowerCase());
}

function ThemeCommandMouseExit(command) {
    SetThemeHREF(localStorage.getItem("theme"));
}

function SetThemeHREF(theme) {
    document.getElementById("currentTheme").href = `../themes/${theme}.css`;
}

function GenerateThemeCommands(){
    const themesData = GetThemes().themes;
    
    themesData.forEach(themeData => {
        let newThemeCommand = MakeCommand("Theme", themeData.name, (themeData.name == localStorage.getItem("theme")), true, [themeData.colors[0], themeData.colors[1], themeData.colors[2], themeData.colors[3]]).SetExecutions(ThemeCommandClicked, ThemeCommandMouseEnter, ThemeCommandMouseExit);
    
        if (newThemeCommand.isActive) { 
            currentActiveThemeId = newThemeCommand.id;
        }
    });
}

addEventListener("DOMContentLoaded", (event) => { 
    GenerateThemeCommands();
    SetThemeHREF(localStorage.getItem("theme")); 
});
