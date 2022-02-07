# GalaxyDefender
  A solo side project to develop an enemy wave generation system from scratch using Unity.

# Features
- Customisable wave generator script that can be easily implemented into any project.
- Randomly spawning debris.
- Player save data system.

## Wave Generation System
This system provides developers the ability to edit multiple aspects of their wave generation system such as the amount of enemies that can be instantiated, the rate at which they spawn in, the type of enemy class can be instantiated and providing multiple spawn locations for variation and non-linearity. This system utilises three different enums: Spawning, Waiting and Counting. These states dictate the flow of gameplay.

When starting the first level, the system searches for active enemies on the field, if enemies aren't present the Spawning enum state triggers. The system knows what wave to spawn and instantiates the chosen enemies, how many are instantiated and how fast they appear on the field. Once this routine is complete, the enum state changes to Waiting. In the code, it utilises a simple if statement as if enemies are alive it will continue to wait but if all enemies have been destroyed, it triggers the next enum Counting. This enum state will utilise a float value to pause the enemy wave system to give players some downtime inbetween waves (the float can be increased or decreased to suit the needs of the developer). Once the float time has elapsed, the enum state will revert to the Spwaning stage and the loop will begin once again. 

![Screenshot_46](https://user-images.githubusercontent.com/43742155/152780062-2a1eaf3d-652f-4bf7-bc61-cc03e89d3828.png)

![Screenshot_47](https://user-images.githubusercontent.com/43742155/152780070-b82b6a51-491b-4858-bb5b-f1e051743a47.png)

## Saving Player Progress
The ability to save progress was integral to the game as having multiple levels with no save feature would destroy player morale and willingness to try the game again. To combat this, I utilised PlayerPrefs to save player data with background json files based on completing levels. These levels would appear disabled in the menu but upon completing the first level, the next level will become interactable; allowing players to close the game and come back to it another day with their progress retained. Players can also rease their progress if they wish to, wiping all memory data of that previous level; this also means that previous levels will become disabled again.

![Screenshot_32](https://user-images.githubusercontent.com/43742155/152780142-e2885b7e-60d8-43d8-a063-707a7e97a4e0.png)
