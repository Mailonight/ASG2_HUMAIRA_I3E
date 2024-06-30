# ASG2_HUMAIRA_I3E
 Game Name: D1M3NS111ON
 Done by: Humaira 
 Assignment: Assignment 2, i3E spaceship
# D1M3NS111ON
## Description
D1M3NS111ON is an immersive 3D exploration and puzzle-solving game set in a mysterious and surreal dimension. Players find themselves stranded on an unknown planet after crash-landing their spaceship. As they awaken amidst the wreckage, they must navigate through various terrains and uncover the secrets of the dimension to repair their ship and escape.
## Table of Contents
#### Features
#### Installation Instructions
#### How to Play
#### Controls
#### Credits
#### License
## Key Features:
#### Exploration: 
Traverse through visually distinct areas of the unknown planet, each with its own unique challenges and puzzles.
#### Puzzle Solving: 
Engage in environmental puzzles, interact with objects, and collect items crucial for progressing through the game.
#### Hazards and Challenges: 
Encounter hazardous elements that require careful navigation and problem-solving skills to overcome.
#### Progressive Unlocking: 
Discover hidden passages and unlock access to new areas as you gather collectibles and solve puzzles.
#### Dynamic Soundscapes: 
Immerse yourself in the atmospheric sound design that enhances the otherworldly experience.
#### Interactive UI: 
Utilize a user-friendly interface for managing health, collectibles, and accessing game options seamlessly.
## Basic Features
#### Multiple scenes and areas to explore.
#### Various types of hazards and collectibles.
#### Interactive elements and puzzles.
#### Pause functionality with options to restart levels or return to the main menu.
#### Sound effects and immersive audio.
#### UI elements including health bar and collectible counters.
DIMENS111ON offers a blend of exploration, puzzle-solving, and strategic thinking, providing players with an engaging and visually captivating journey through an enigmatic dimension.
## Installation Instructions
### Prerequisites:
#### Operating System: 
Ensure your Windows laptop is running Windows 10 or higher.
#### Graphics Card: 
Verify that your laptop meets the minimum graphics card requirements for the game.
## Steps to Install DIMENS111ON:
#### Download the Game:
Visit www.D1M3NS111ON.com
Click on the download link for Windows.
Save the installation file to your computer.
#### Install the Game:
Locate the downloaded installation file (typically a .exe file) in your Downloads folder or the location where you saved it.
Double-click the installation file to start the installation process.
Follow the on-screen instructions to install DIMENS111ON. You may need to choose the installation directory or agree to terms and conditions during the process.
#### Run DIMENS111ON:
Once the installation is complete, you can launch the game from the desktop shortcut or from the Start menu.
Double-click the game icon to start DIMENS111ON.
Adjust any in-game settings such as graphics quality, resolution, or controls based on your preferences.
#### Enjoy Playing:
Explore the mysterious dimension, solve puzzles, collect items, and uncover the secrets of the unknown planet.
Refer to the game’s README or in-game help section for additional instructions or controls.
#### Troubleshooting:
If you encounter any issues during installation or while running DIMENS111ON, check the system requirements and ensure your laptop meets them.
Update your graphics drivers and Windows operating system to the latest versions if necessary.
Contact www.D1M3NS111ON.com or d1m3ns111on@gmail.com for further assistance if problems persist.

## How to Play
#### Objective:
#### Gameplay mechanics:
## Controls
Movement: Arrow keys or WASD and Mouse to look around
Interact: E key
Pause: Esc key or click the Pause button located at the top left corner of the screen during gameplay.
## Credits
Starter First person controller assets
Done by Humaira
## License
DIMENS111ON is provided as a school assignment and is not licensed for distribution or commercial use outside of educational purposes.
You are allowed to:
Use: You can use the game for educational purposes within your school or academic institution.
Modify: You are permitted to modify the game as part of your coursework.
Share: You can share the game with your instructors or classmates for evaluation purposes.
Under the following terms:
#### No Commercial Use: The game may not be used for commercial purposes or distributed outside of educational settings without explicit permission.
Attribution: If sharing or presenting the game, credit should be given to the creators and contributors.
This assignment is subject to the academic policies and guidelines of my school. For more details, please refer to the instructions provided by my lecturer.




# Design Documentation
### Initial UI Screen: Check PDF VERSION OF README TO SEE PIC
Below will be the UI Screen for when player is engaged in playing D1M3NS111ON game.
Pause button is interactable:
#### when player pressed on pause button while playing game, player would see:
-Resume option
-Options button
-Exit button



## Game Progress:
#### Features that could not be implemented:
#### Hazard 1: Toxic Gas
I did try to implement a toxic gas by using a script and an empty game object, known as ToxicGasArea. The ToxicGasArea has a box collider component, and isTrigger is ticked. This is to allow the player to be affected by the unknown toxic gas when player stepped into a particular area. However, upon many attempts, I still couldn’t get my player HP to be affected, nor was my player’s screen becoming red to indicate the reduce in player’s HP and at times, player would pause. 
After doing research, I was aware that it could perhaps be the time I set in the scripts, this means that the scripts can’t include a time = 0f otherwise player would automatically pause for no reason. However, even after modifying my scripts it still did not work. Hence I proceeded to do other features to avoid time consuming.
#### HP health system to be affected
HP health system can’t be affected despite various attempts to make it reduce when player experienced a hazard.
#### Quest UI button on the bottom right
Too time consuming especially with many issues faced at the initial stage of the game development

## Issues faced:
#### Gameplay disappear always
#### Player could not move initially:
Fixed it by reimporting all assets, refreshing the unity app, editing the player field in inspectors
#### Creating objects
#### Coding the right mechanism 
Most of the time there are so many issues faced, which would lead to my Unity editor to be jammed and error would occur
#### Constantly restarting the game development
Due to the issues faced
