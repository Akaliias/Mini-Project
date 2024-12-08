# **PI3DW \- MiniProject Report**

Project Name: Steal Stuff  
Name: Victor Alexander Stuestøl Andersen  
Student Number: 20234379  
Link to Project: [https://github.com/Akaliias/Mini-Project](https://github.com/Akaliias/Mini-Project)

# **Overview of the game:** 

The idea behind this game is a simple first person stealth game. Using WASD movement the player can sneak around to try and steal things whilst avoiding the guards that patrol around the area. Furthermore the player has access to telekinesis to help manipulate objects to steal stuff easier. As well as make sound to manipulate the guards to investigate an area. 

The main inspirations for this idea were games like Skyrim, Dishonored and Thief which all feature stealth gameplay. Skyrim and Dishonored also feature magic which can aid the player in stealth which is seen here with the inclusion of Telekinesis. 

## **Features:**

**Stealth** \- Player will be spotted when whitin enemies field of view and will promptly be chased and killed if caught.  
**Telekinesis**\- Use Telekinesis to maniplulate objects to distract and easily steal stuff. Has limited range.  
**Stealing** \- Player can interact with items to steal them adding to the total money.   
**Sound Manipulation** \- Dropped objects make sound that enemies will investigate. Use this to your advantage. 

## **Controls:** 

### **Movement:**

WASD \- Move left, right, forwards and back  
SHIFT \- Sprint  
SPACE \- Jump  
C \- Crouch

### **Interaction**

LMB \- Use Telekinesis  
RMB \- Use Zoom  
SCROLL WHEEL UP \- Push object (Telekenisis)  
SCROLL WHEEL DOWN \- Pull object (Telekenisis)   
E \- Interact

# **Components from list implemented**

* An interactive camera the user can move using WASD and the mouse.  
* Character that user can move with WASD, objects that can be interacted with through input using telekinesis with LMB and scrolling up and down on the mouse wheel.   
* Objects in 3D world that can be interacted with through colliding with, moving, pushing and pulling using telekinesis.   
* Character in 3D world controlled by script to move, using enemy to patrol and chase the player.   
* Materials that have different values such as different base color, smoothness, metallic. Directional moon light and global illumination, spotlight coming from fire effects.   
* Physics interaction through rigidbodies for all objects that are telekinesis able.   
* GUI displaying results through a text field.   
* Enemies navigate using NavMesh path finding.   
* Level was created using ProBuilder together with models and textures.   
* Animation on enemy character.   
* Particle system for rainfall and splash/ripple effect. 

# **Project Parts:** 

## **Scripts**

- **EnemyBehavior** script is responsible for controlling enemy Patrol, Chase and sound investigation states.  
- **Telekinesis** script allows the player to pick up, move and drop objects.   
- **PlayerHealth** script handles the player’s health, such as taking damage and player death.   
- **Interact** script allows the player to interact with item, picking them up and adding the corresponding money value to the UI.   
- **Item** script represents the items the player can pickup. It handles the money value and sound emission.  
- **UIManager** script handles the UI elements related to the player’s total money, by Initializing, adding and updating the UI element.  

## **Player & Enemy object**

- **Player** object is mostly from the Unity Assets Store with some modifications to the movement. As well as adding telekinesis, interaction and health.   
- **Enemy** object is controlled by the EnemyBehavior script and features the model and animation from Mixamo. 

## **Models, Textures & Animations**

- **3D Models** all come from the FAB Quixel megascans pack with the exception of the Enemy model which comes from Mixamo.  
- **Textures** all come from the FAB Quixel megascans pack with the exception of the Treasure coins which comes from Unity Assets Store.   
- **Animation** comes from Mixamo. 

## **Lighting & Particle System**

- **The realistic Lighting** effect was made with the help of a YouTube guide. Consists of a Directional Moon Light and Global Volume for volumetric fog and clouds, shadows, screen space reflection and global illumination.  
- **Particle system** for the rain effect was made with the help of a YouTube guide. Consists of a simple particle system that upon collision spawns another that creates the splash/ripple effect. 

## **Level**

- **The Level** was constructed using probuilder together with 3D models to make the environment. 

# **Time Mangement:**

| TASK | ESTIMATED TIME (Hrs) |
| :---- | :---- |
| Setting up Unity Project and Github Repository | 0.5  |
| Research and conceptualization of the game idea | 1 |
| Scripts | 2  |
| Level | 4 |
| Particle Systems | 1 |
| Finding 3D models and setting up | 2 |
| Finding textures and setting up | 2 |
| Finding 3D character model and setting up | 1 |
| Finding animation and setting up  | 1 |
| UI elements  | 0.5 |
| Lighting | 1 |
| Troubleshooting bugs and problems | 2 |
| Code documentation  | 1 |
| Making readme file | 0.5 |
| **Total** | **19.5** |

# **Resources:** 

* Scripts made with the help and assistance of AI (Github CoPilot, ChatGPT, Gemini)  
    
* 3D Models and Textures acquired from Quixel:  
  * [https://www.fab.com/sellers/Quixel](https://www.fab.com/sellers/Quixel)  
* Enemy model and animation acquired from Mixamo:  
  * [https://www.mixamo.com/\#/](https://www.mixamo.com/#/)  
* FPS Controller acquired from:   
  * [https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884](https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884)  
* Fire VFX acquired from:   
  * [https://assetstore.unity.com/packages/vfx/free-fire-vfx-hdrp-239742](https://assetstore.unity.com/packages/vfx/free-fire-vfx-hdrp-239742)  
* Treasure Coins:   
  * [https://assetstore.unity.com/packages/2d/textures-materials/metals/basic-treasure-coins-26609](https://assetstore.unity.com/packages/2d/textures-materials/metals/basic-treasure-coins-26609)  
* Rain particle system:   
  * [https://www.youtube.com/watch?v=SrWrUN56UWU](https://www.youtube.com/watch?v=SrWrUN56UWU)  
* Lighting system:   
  * [https://www.youtube.com/watch?v=vnzt3aRTd5o](https://www.youtube.com/watch?v=vnzt3aRTd5o)

