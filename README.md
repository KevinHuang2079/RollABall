Level Design 1 - 3D Project
Chapman University
CPSC 244
Kevin Huang


## Mechanics

### 1) Wall Sticking
- A pivotal gameplay mechanic allows the character (ball) to stick to flat walls.
- Death walls (painted black) and lava zones (painted red) reset the character to its spawnpoint upon collision.
- The blue powerup, originally a pickup object, now serves as the sticky buff trigger.

### 2) Movement
- WASD controls empower players to navigate the character through the dynamic game environment.

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
   - The project emphasizes two core mechanics: Wall Sticking and Movement.

### LIMITATIONS:

**USER NOTE:** Sticky walls can only be placed along the world's axes.
- Wall sticking leverages Unity's rigidbody gravity attribute, dynamically turning it on and off.
- The ball is restricted to sticking on flat surfaces of walls aligned with the x, y, or z axis. Essentially, it locks movement in one direction and transfers it to another plane. However, this plane must align with the world axis.
- For example, if the ball moves along the x, z axis on the ground, it will move along the z, y axis when sticking to a left wall, with gravity turned off.

### BUG:

- The Ball's momentum is carried over when moving from ground to wall and persists until resetting by touching the ground again. Begin to stick onto a wall slowly to prevent.

### Changed Scripts from Originating Game:

**Player Control:**
- All movement, including the original ground movement and altered movements when stuck on walls, is handled here.
- Death mechanic resets a player back to their spawnpoint.
- Added trigger statement for touching a sticky powerup and collision enter function for death surfaces.

**Camera Movement:**
- The camera follows the ball but also:
  a) looks left and backs up if it sticks to a wall on the left
  b) looks right and backs up if it sticks to a wall on the right
  c) turns around 180 degrees if it sticks to a wall behind the ball
  d) does not change if it sticks onto a forward-facing wall

### New Scripts:

**STICKY:**
- Manages all altered movements when stuck on a wall.

**Wall Detector:**
- Utilizes 4 raycasts drawn in worldLeft, Forward, Back, and Right to determine the wall's direction.
- Works in tandem with collision detection to decide when to use altered controls and which controls to apply.
