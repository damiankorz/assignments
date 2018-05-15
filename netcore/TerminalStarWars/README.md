Terminal Star Wars
Developed by: Damian Korzeniewski

Terminal Star Wars is a basic role-playing-game (RPG) for the console terminal built and written in C#.

You (the user) will control three Jedi of various skill and rank (Jedi Apprentice, Jedi Knight, Jedi Master). Your mission is to eliminate three computer controled troopers of various skill and rank (Scout Trooper, Heavy Trooper, Shadow Trooper). The game will begin by having the user name the three jedis. The teams and stats will be displayed and the game will randomly generate the player order. The user will be prompted to select specific actions to perform for each jedi he/she controls. The game ends once all players on one side have been eliminated.  

Incomplete: 
- Bug: Once an enemy player has been eliminated, the player still shows in the available enemy players to attack until the round has ended all players have taken a turn.
- Bug: Instances where once all enemy players have been eliminated, if there are still turns left for the opposing side, the turns will carry out for the rest of the round but fail... then a prompt will appear to begin a new game or not. Fix needed to end all remaning turns  once the list of jedi or troopers has reached zero.
- Implement a system for incorrect/empty command line inputs
- Code Refactor(DRY it up) - mutliple areas where codeblocks can be re-written as a reusable function

