function QueryCommands(keyWord) {
    if (keyWord.trim() === "") return [];
    
    let keyWords = keyWord.toLowerCase().split(" ");
    let results = [];
    
    commands.forEach(command => {
        let commandTitle = command.title.toLowerCase();
        let commandDetails = command.details.toLowerCase();
        
        if (keyWords.every(word => commandTitle.includes(word) || commandDetails.includes(word))) {
            results.push(command);
        }
    });
    
    return results;
}

document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("commandLineInput").addEventListener("input", OnCommandInputChanged);
});

function ForceReloadResults(){
    const newCommands = QueryCommands(document.getElementById("commandLineInput").value);
    LoadCommands(newCommands);
}

function OnCommandInputChanged(event) {
    const newValue = event.target.value;
    const newCommands = QueryCommands(newValue);
    LoadCommands(newCommands);
}
 
function LoadCommands(commands) {
    const resultsParent = document.getElementsByClassName("commandLineResults")[0];
    resultsParent.innerHTML = "";

    const loadedCommands = commands.map(command => `
        <div class="commandLineCommand" id="command-${command.id}">
            ${command.isTheme ? `<i class="fa-solid fa-palette"></i>` : `<i class="fa-solid fa-ban"></i>`}
            <p>${command.title}</p>
            <i class="fa-solid fa-chevron-right"></i>
            ${command.isActive ? '<i class="fa-solid fa-check"></i>' : '<div class="commandLineCommandSpacer"></div>'}
            <p>${command.details}</p>
            ${command.isTheme ? `
            <div class="themeBubbleContainer" style="background-color: ${command.themeColors[0]};">
                ${command.themeColors.slice(1, 4).map(color => `<div class="themeBubble" style="background-color: ${color};"></div>`).join('')}
            </div>` : ''}
        </div>
    `).join('');

    resultsParent.innerHTML = loadedCommands;

    commands.forEach(command => {
        const commandElement = document.getElementById(`command-${command.id}`);
        if (commandElement) {
            commandElement.addEventListener('mouseenter', function(){ command.MouseEnter(); });
            commandElement.addEventListener('mouseleave', function(){ command.MouseExit(); });
            commandElement.addEventListener('click', function(){ command.Clicked(); });
        }
    });
}