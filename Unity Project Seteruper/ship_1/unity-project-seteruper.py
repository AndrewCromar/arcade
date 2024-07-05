import os
import shutil

assetFolderPath = input("What is the path to your asset folder? ")

currentDir = os.getcwd()

# List of directories to create
directories = [
    "/ONYX",
    "/ONYX/Utils",
    "/_Project",
    "/_Project/Animating",
    "/_Project/Animating/Animations",
    "/_Project/Animating/Animators",
    "/_Project/Inputs",
    "/_Project/Materials",
    "/_Project/Objects",
    "/_Project/Rendering",
    "/_Project/Scenes",
    "/_Project/Scripts",
    "/_Project/Sprites"
]

# Create directories if they don't exist
for directory in directories:
    dir_path = assetFolderPath + directory
    if not os.path.exists(dir_path):
        os.makedirs(dir_path)
        print("Created directory: " + dir_path)

# Copy the file if it doesn't already exist
src_file = currentDir + "/unity-project-files-seteruper.py"
dst_file = assetFolderPath + "/ONYX/Utils/unity-project-files-seteruper.py"
if not os.path.exists(dst_file):
    shutil.copyfile(src_file, dst_file)
    print("Copied this script to: " + dst_file)