# Helga Unity Game

## Overview
Helga is a 3D platformer game built with Unity as part of a Unity coursework project. The game challenges players to navigate through a maze-like environment while avoiding obstacles and finding landing pads to progress through different scenes.

## Play the Game
You can play Helga online at [Unity Play](https://play.unity.com/en/games/7299c9bd-3086-4eb0-b5e5-5b32bac6df44/helga).

## Game Description
In Helga, players take control of a flying character navigating through a 3D maze. The primary objectives are:
1. Fly through the maze without colliding with moving obstacles
2. Find and land on designated landing pads to progress to the next level

While the game mechanics are basic, Helga represents a significant achievement as it was built entirely from scratch during a Unity course.

## Scripts Overview
The game is powered by several C# scripts, each handling specific game mechanics and interactions:

### BackgroundMusic.cs
- Ensures background music persists across different scenes
- Uses `DontDestroyOnLoad()` to prevent music restart on scene changes

### CollisionHandler.cs
- Manages player collisions with various objects
- Handles interactions with "Friendly", "Finish", and "Ground" tagged objects
- Triggers audio and visual effects upon collisions
- Manages level transitions, including looping back to the first level after completing the last one

### LoadLevel.cs
- Loads a specified scene after a set delay

### Movement.cs
- Controls player movement (thrust, left/right movement)
- Manages audio and particle effects for player actions
- Uses `AddRelativeForce` for orientation-relative movement
- Handles main engine sound effects and particle systems activation

### Oscillator.cs
- Creates oscillating movement for GameObjects
- Calculates object position based on a sine wave for smooth back-and-forth motion

### QuitApplication.cs
- Allows players to quit the game by pressing the "Escape" key

### SceneChange.cs
- Provides functionality to switch to the "PracticeLevel" scene

## Development Notes
This game was developed as part of a Unity coursework project. While it features basic gameplay, it represents a significant learning experience in game development from scratch.

## Contact Information
For any inquiries or feedback, please contact:
- Email: fotiosmpouris@gmail.com

## Acknowledgments
Special thanks to the Unity course instructors and fellow students who provided support and guidance throughout the development process.
