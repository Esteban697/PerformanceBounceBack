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

- In terms of Lighting, the lighting rendering path was turned to the one highly recommended for VR: Forward. The Anti aliasing was enabled turning the MSAA to 4x.
Backed lights
Light probes

- In terms of physics, the Rigidbody.Sleep function was used to make the rigidbodies created for the ground trampolines to be disabled to save resources. A boolean 
was created to prevent from looking for this component in the air trampolines sharing the script.

- Dynamic and Static Batching was enabled. Selecting the "Ground Trampolines" that never move to "Static" for the static batching to work on them and living the
"Air Trampolines" non-Static for the dynamic batching to work on them. The platform and factory was also marked "Static".

- In the Time Manager the Fixed Timestep was changed to 0.011111 as it follow the 90 FPS criteria we are aiming for in the project. Also, the Maxmimum
Timestep Allowed was changed to 0.03333333 because it allows for a quick drop to 30 FPS is something goes out of place. Also, a "TargetFrameRate" script wass created
to fixed a target framerate for the application of 90 FPS.

- The Code Cleanup was implemented by removing some Debug.Log functions that are not usefull for the final release.

The Game keeps a framerate above 100 FPS in the PC it was tested. Hope you enjoy testing in yours!

## Versions
- Unity 2017.2.0f3
-SteamVR SDK v1.2.2

