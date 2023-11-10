Level Design 1 - 3D Project
Chapman University
CPSC 244
Kevin Huang
## Mechanics

### 1) Wall Sticking
- A key gameplay mechanic allows the character (ball) to stick to flat walls.
- Also has death walls painted in black and lava painted in red that resets character to their spawnpoint.
- The powerup is the pickup object from the original package but recolored blue.

### 2) Movement
- WASD controls enable players to navigate the character through the game environment.

    

## How to Play

1. **Character Movement:**
   - Utilize WASD controls for smooth character movement.

2. **Powerup Interaction:**
   - Touch the blue powerup to activate a sticky buff.
   - The sticky buff persists even after character respawn.

## Important Notes

- **Project Source:**
   - Based on the Unity Tutorial Project: [Roll-a-Ball](https://learn.unity.com/project/roll-a-ball).
   - Source files available on the Unity Asset Store: [Roll-a-Ball Tutorial Complete](https://assetstore.unity.com/packages/essentials/tutorial-projects/roll-a-ball-tutorial-complete-77198).

- **Mechanics Focus:**
   - The project highlights two core mechanics: Wall Sticking and Movement.

***LIMITATIONS:
    *USER NOTE: Sticky walls can only be placed along the world's axes.
        - Wall sticking leverages Unity's rigidbody gravity attribute, dynamically turning it on and off.
        - The ball is restricted to sticking on flat surfaces of walls aligned with the x, y, or z axis. Essentially, it locks movement in one direction and transfers it to another plane. However, this plane must align with the world axis.
        - For example, if the ball moves along the x, z axis on the ground, it will move along the z, y axis when sticking to a left wall, with gravity turned off.
      
    **BUG:
        - The Ball's momentum is carried over when moving from ground to wall and persists until resetting by touching the ground again. 
          Begin to stick onto a wall slowly to prevent.
    
***Changed Scripts from Originating Game
    -** Player Control:
        - ALl of the movement is handled here, including the original movement on the ground, but also the altered movements when stick onto walls.
        - Death mechanic that resets a player back to their spawnpoint. 
        - Added trigger statement for touching a sticky powerup, and collision enter function for death surfaces.
    
    ** Camera Movement:
        - The camera follows the ball but also:
            a) looks left and backs up if it sticks to a wall on the left
            b) looks right and backs up if it sticks to a wall on the right
            c) turns around 180 degrees if it sticks to a wall behind the ball
            d) does not change if it sticks onto a forward facing wall
            
***New scripts
    -** STICKY:
        - Has all the altered movements when stuck on a wall.
    -** Wall Detector:
        - Uses 4 raycasts drawn in worldLeft, Forward, Back, and Right to check what direction the wall is.
          Use this along with collision detecting to know when to use the altered controls and what controls to use. 
          
          
