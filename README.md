# 🚗 Vehicle Shooter

![Preview](https://github.com/user-attachments/assets/2955456e-0fa8-4ed4-ae50-6a6d53e329c9)

A 3D mobile game prototype developed in Unity, where players drive and shoot while enemies spawn in waves. This is not a polished product—it's a **learning project** exploring **Clean Architecture**, **SOLID principles**, and Unity development best practices.

> ⚠️ **Disclaimer:** I attempted to apply Clean Architecture principles throughout the project (check the `Scripts/Game/` folder). While the structure might appear formal, it's still experimental—I’m aware I didn’t fully grasp all architectural decisions. This is primarily an exercise in learning.

## 🧠 Learning Objectives

This project helped me explore:

* Clean Architecture in Unity
* Separation of concerns (Application, Presentation, Infrastructure, etc.)
* Interfaces and abstraction layers
* Unity game loops, states, and command/event systems
* Dependency Injection concepts (Installers, etc.)

## 🛠 Features

* Vehicle movement and turret-based shooting
* Basic enemy AI and enemy spawner
* Game state management (menu, gameplay, win/lose)
* Mobile input support
* UI screens: gameplay, menu, result, settings

## 🗂 Project Architecture Overview

```
Assets/
└── Scripts/
    └── Game/
        ├── Application/       # Commands, Events, Presenters, Game States
        │   ├── Abstractions/  # Interfaces (e.g. IAudioService, ISceneLoader)
        │   ├── Commands/      # Game action triggers (WinCommand, etc.)
        │   ├── Events/        # EventBus and game state events
        │   ├── Gameplay/      # Presenters for car, turret, enemies, camera
        │   ├── GameStates/    # State machine logic (GameplayState, etc.)
        │   └── UI/            # UI Presenters and Views interfaces
        ├── Domain/            # (Presumably business rules, not fully shown)
        ├── Infrastructure/    # Services implementation (e.g. Audio, Loading)
        ├── Presentation/      # Visual/UI code
        └── Installers/        # DI bindings setup (e.g., Zenject)
```


## 🚧 Known Gaps & Future Goals

* Clean Architecture is still WIP; some coupling or confusion may exist
* Need better separation between `Presentation` and `Application` logic
* Improve DI consistency and interface usage
* Expand enemy behaviors and add VFX
* Refactor state transitions and event bus handling

## 📱 Platform

* Target: Android
* Unity Version: 2022.x or newer

## 🧪 Getting Started

1. Clone this repo:

   ```bash
   git clone https://github.com/Eugene2424/Vehicle-Shooter.git
   ```
2. Open in Unity (`Unity Hub > Add project`)
3. Load `Scenes/Boot.unity` and hit ▶ Play

## 🤝 Acknowledgements

This project draws on concepts from:

* Clean Architecture by Robert C. Martin
* Zenject (DI framework for Unity)
* Various Unity tutorials on game state management & UI separation
