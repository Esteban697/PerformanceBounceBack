# Performance Bounceback Starter Project
### by Esteban Struve

This project focuses on optimizing the VR application for desktop with the strategies taught in the 3rd Term of Udacity's VR developer Nanodegree.
The gameplay consists of a room full of trampolines and balls spawned every 0.5 seconds in the player's reach. The player is intended to grab any of these
spawned balls and through it to score 1 point each time the ball bounces from a trampoline before hitting the ground.

The goal as developer for this project is to reach a steady 90 FPS with the proper optmization strategies. They include:

- The "BallSpawner" script had a defective object pooling implemented without a disabling criteria to reuse the balls. Instead they continue to grow the pool.
So, I modified the script to perform a search for available resources in the pool (if not just add a need ball to the pool) and a "DestroyBall" script.
In this script I implement a check (every 0.5 secs) for the balls in rowling in the floor to be disabled when living the area close to the player and
a 5 second check to disable the balls that have been touched by the player that have gone out of bounds. This kept a pool of 80 balls that have minimal impact
on framerate and performance.

- The "Trampoline" script had a GameObject.Find and a GetComponentInChildren that was in the Update running each frame without needing it. I moved this functions
to Start to be run just once to create the objects to score to add 1 point and particles to appear if the ball hit the trampoline and bounced. This took the impact
of this script to a mere 1% of the CPU Usage in the Unity Profiler from having around 50% before implementing the strategy.

- The "Score" script was modified to have a UpdateScore function called from the "Trampoline" script to update the score only when hitting a trampoline instead of
calling the GetComponentInChildren function every frame in the Update function. Both scoreboards had to be updated every time the score changes.

- In terms of Lighting, the lighting rendering path was turned to the one highly recommended for VR: Forward. The Anti aliasing was enabled turning the MSAA to 8x
in the first 3 graphics qualities. The shadow distance was reduced too 50 keeping the appearance of the shadows very similar. The point lights were baked to save 
in realtime light expense. Also, a 3D grid of light probe groups was added to the player's closer visible area.


- In terms of physics, the Air trampolines were added rigidbodies and the ground trampolines didn't need one. Saving resources to be used only when necessary.

- Dynamic and Static Batching was enabled. Selecting the "Ground Trampolines" that never move to "Static" for the static batching to work on them and living the
"Air Trampolines" non-Static for the dynamic batching to work on them. The platform and factory was also marked "Static". I used a very useful Unity Package to filter
non-static objects in the scene from [this link](http://spreys.com/wp-content/uploads/2017/06/FilterNonStaticObjects.unitypackage)

- In the Time Manager the Fixed Timestep was changed to 0.011111 as it follow the 90 FPS criteria we are aiming for in the project. Also, the Maxmimum
Timestep Allowed was changed to 0.03333333 because it allows for a quick drop to 30 FPS is something goes out of place. Also, a "TargetFrameRate" script wass created
to fixed a target framerate for the application of 90 FPS.

- The Code Cleanup was implemented by removing some Debug.Log functions that are not useful for the final release. Instead of using GameObject.Find the references for
GameManager are set in the Inspector.

The Game keeps a framerate above 120 FPS in the PC it was tested. Hope you enjoy testing in yours!

## Versions
- Unity 2017.2.0f3
-SteamVR SDK v1.2.2

