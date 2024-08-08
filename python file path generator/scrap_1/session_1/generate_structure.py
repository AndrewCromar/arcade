import os
import pyperclip
import subprocess

def generate_structure(root_path, prefix=''):
    structure = []
    if not os.path.isdir(root_path):
        return structure

    items = sorted(os.listdir(root_path))
    for i, item in enumerate(items):
        path = os.path.join(root_path, item)
        connector = '└── ' if i == len(items) - 1 else '├── '
        structure.append(prefix + connector + item)
        if os.path.isdir(path):
            extension = '    ' if i == len(items) - 1 else '│   '
            structure.extend(generate_structure(path, prefix + extension))
    
    return structure

def main():
    root_path = input("Enter the directory path: ").strip()

    # Ask if the user wants to open the structure in Notepad
    open_notepad = input("Open in Notepad? (y/n): ").strip().lower()

    if not os.path.isdir(root_path):
        print("Invalid directory path.")
        return

    # Generate the directory structure
    structure_lines = generate_structure(root_path)
    structure_text = '\n'.join(structure_lines)
    
    # Print the structure
    print("Generated Directory Structure:\n")
    print(structure_text)

    # Copy the structure to clipboard
    pyperclip.copy(structure_text)
    print("The structure has been copied to the clipboard.")

    if open_notepad == 'y':
        with open("structure.txt", "w", encoding="utf-8") as f:
            f.write(structure_text)
        subprocess.run(["notepad.exe", "structure.txt"])

if __name__ == "__main__":
    main()