import os
import json
import re

# Get the directory where the script is located
script_dir = os.path.dirname(os.path.realpath(__file__))

# Define the paths relative to the script directory
json_file_path = os.path.join(script_dir, "themes.js")
css_folder_path = os.path.join(script_dir, "../../themes")

# Function to extract specific color codes from a CSS file
def extract_colors_from_css(file_path):
    with open(file_path, 'r') as file:
        css_content = file.read()
    
    # Regular expression to find color variables
    colors = {}
    color_vars = {
        "background-color": r'--background-color:\s*(#[0-9a-fA-F]{6}|#[0-9a-fA-F]{3}|rgb\([^)]+\));',
        "accent-color": r'--accent-color:\s*(#[0-9a-fA-F]{6}|#[0-9a-fA-F]{3}|rgb\([^)]+\));',
        "text-color": r'--text-color:\s*(#[0-9a-fA-F]{6}|#[0-9a-fA-F]{3}|rgb\([^)]+\));',
        "secondary-background-color": r'--secondary-background-color:\s*(#[0-9a-fA-F]{6}|#[0-9a-fA-F]{3}|rgb\([^)]+\));'
    }

    for var, pattern in color_vars.items():
        match = re.search(pattern, css_content)
        if match:
            colors[var] = match.group(1).strip()

    return colors

# Initialize the data structure
data = {
    "themes": []
}

# Read all CSS files in the folder
for css_file in os.listdir(css_folder_path):
    if css_file.endswith('.css'):
        file_path = os.path.join(css_folder_path, css_file)
        colors = extract_colors_from_css(file_path)
        # Use the file name without extension as the theme name
        theme_name = os.path.splitext(css_file)[0]
        data["themes"].append({
            "name": theme_name,
            "colors": [
                colors.get("background-color", ""),
                colors.get("accent-color", ""),
                colors.get("text-color", ""),
                colors.get("secondary-background-color", "")
            ]
        })

# Write the data to the JS file
with open(json_file_path, 'w') as js_file:
    js_file.write("function GetThemes() {\n")
    js_file.write("    return ")
    json.dump(data, js_file, indent=4)
    js_file.write(";\n}")
    
print(f"JavaScript function has been written to {json_file_path}")
