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

- 

## Versions
- Unity 2017.2.0f3
