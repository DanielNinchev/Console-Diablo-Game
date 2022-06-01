#Console Diablo Game

This is my first big project, written entirely on C#. It's purpose is to exercise my OOP skills. The app has some unfixed bugs and it's not entirely finished. I used Entity Framework Core in this project.

Console Diablo is a console game, based on Diablo 2. Basically, after running the app and creating an account you start by creating a new character (Amazon, Assassin & Barbarian are the only characters that work properly at the moment). With your character you fight monsters who give you experience and drop items when they die. By increasing your experience you level up and develop your stats and skills to get stronger. The stronger you get, the stronger skills you can develop and the stronger monsters you fight. The stronger monsters you fight, the stronger items you get after they die. 

##CURRENT PROJECT STATUS
Since this project was mainly for exercising purposes, the solutions of some problems could be done differently, but in some cases I chose the longer / harder way just for the exercise. There are bugs in the game - some buttons do not work yet (exit, multiplayer, fight boss, some back buttons, etc.). The item shop is not yet finished and the Druid, Necromancer, Paladin and Sorceress do not work properly yet. Some of the character skills may still have some bugs. 

##GAME FEATURES
- Account:
You can create an account and log out / log in. Each account is saved in the database and can have many characters and unique account name and password.

- Character:
Each character can have one account and has a gear (the items that he wears on himself), an inventory (the items that he carries with himself but do not affect him), and 12 skills (unique for each character type). Characters can fight in Single Player (Multiplayer is not available at the moment) against monsters and gain experience after each kill.

- Monster:
Monsters are not saved in the database. They are created for each character based on his level. There are 5 ranks of monsters (created as enumerations) - Ordinary, Strong, Champion, Legendary and Boss. Each one of them has different unique abilities. As the character level gets higher, the monster gets stronger and changes it's rank. Stronger monsters drop stronger items. The monster is not saved into the database after it dies. It spawns with random rank and damage type and with stats, based on the character level.

- Item:
Items can be dropped from monsters or bought from the shop. Each item can have many bonuses. The item's class gets higher as the monster rank gets higher. The higher-class items have more bonuses and greater sell value. Items can be weapons or defensive equipment. Weapons can give damage bonus, special bonus against certain type of monsters, higher chance of critical hit, different accuracy, etc., while the defensive equipment (Shields, Armors and Helmets) can give defense, resistance, life, mana, chance to block (for shields only), etc. Items have space points can be picked in the inventory of the character after the monster dies (if there is enough space in the inventory). Each item has a randomly generated name and a description, visualized on the console.

- Gear:
Each character has one gear and each gear has one character. The gear can have many items. Assassins and Barbarians can hold at maximum 2 weapons in their hands, or 1 weapon and 1 shield, while the other characters can have only 1 weapon and 1 shield. Each character can wear only 1 armor and 1 helmet.

- Inventory:
Each character has one inventory and each inventory has one character. The inventory can have many items. Each inventory has maximum capacity of 60 points. The items in the inventory do not affect the character.

- Skills:
Each skill has one character and each character type has 12 unique skills. Skills and stats (strength, dexterity, vitality, energy) can be developed after leveling up. There are passive skills (which affect the character all the time after being developed and their changes are saved in the database), aura skills (which affect the character only when the skill is active and their effect can last for several rounds) and active skills (which affect the character only for the current round when activated). The aura skills and the active skills cost mana. Each character type has it's own skill tree, visualized on the console. Some skills require other skills to be developed first, or the character to reach a certain level in order to be developed. Not all skills work properly at the moment (there are a few bugs). Skills are saved in the database.

- Bonuses:
Each bonus has an item and each item can have many bonuses. Bonuses have values and descriptions and are saved in the database.

##GAME CONTROLS
- Up arrow - moves to the upper option;
- Down arrow - moves to the option below;
- Left arrow - moves to the left option;
- Right arrow - moves to the right option;
- ESC - works always as a Back button (some Back buttons don't work, so better use ESC);
- Enter:
  1) marks an input field in order to write something; 
  2) unmarks the written input field in order to finish typing; 
  3) chooses an option;

##SCREENSHOTS
![image](https://user-images.githubusercontent.com/64807656/171395057-3eba2a62-c04b-4a2b-8004-69cad04a7499.png)
![image](https://user-images.githubusercontent.com/64807656/171395121-6e07d41d-f756-4fa2-a186-679f781d9634.png)
![image](https://user-images.githubusercontent.com/64807656/171394701-d24d8630-b42f-4a0a-9ec8-04e88da8f3e1.png) 
![image](https://user-images.githubusercontent.com/64807656/171390721-d44e209b-db18-402f-b250-95fa27fd004f.png)
![image](https://user-images.githubusercontent.com/64807656/171390828-449f30ad-562e-4866-8433-affed2346665.png)
![image](https://user-images.githubusercontent.com/64807656/171390895-b0ae3a05-0616-46c4-b139-d48addf1c81a.png)
![image](https://user-images.githubusercontent.com/64807656/171391226-0f36b53f-56a1-4394-ad39-0a586c87dbe0.png)
![image](https://user-images.githubusercontent.com/64807656/171391309-a4e53f9f-8514-4370-935e-721a0264a2f1.png)
![image](https://user-images.githubusercontent.com/64807656/171391562-e2ffdf69-3d54-428b-89f1-dc1f8e54d8cd.png)
![image](https://user-images.githubusercontent.com/64807656/171391492-a40efdd5-b5ef-4556-9e8b-09b11504b08e.png)
![image](https://user-images.githubusercontent.com/64807656/171391900-aafbd080-5cf1-43e7-a822-69fb44f22e16.png)
![image](https://user-images.githubusercontent.com/64807656/171391680-8455178a-f1a4-40d1-ad01-864f0714d471.png)
![image](https://user-images.githubusercontent.com/64807656/171393055-021f4516-d873-4eca-a0a0-d95bcee17d52.png)
![image](https://user-images.githubusercontent.com/64807656/171393239-316bcaab-9466-4fd5-965d-ab02453ec7e6.png)
![image](https://user-images.githubusercontent.com/64807656/171393298-698cbaef-a0b2-41a8-abd0-33cedc27f0b3.png)
![image](https://user-images.githubusercontent.com/64807656/171393362-87bddbc4-82dd-4ada-90e2-2addecd7a52c.png)
![image](https://user-images.githubusercontent.com/64807656/171394227-39b95803-44b5-4366-a9dd-9e4d8b81d1b3.png)












