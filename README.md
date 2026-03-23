# Data Persistence Education

![C#](https://img.shields.io/badge/language-C%23-239120) ![Unity](https://img.shields.io/badge/engine-Unity-000000?logo=unity)

A Breakout / brick-breaker style game built as part of the Unity Learn **Junior Programmer** learning path. The project focuses on implementing data persistence — saving player names and high scores between sessions using Unity's file system APIs.

## Features

- **Brick Breaker Gameplay** — Classic paddle, ball, and destructible brick layout
- **Data Persistence** — High scores and player names saved to disk with `JsonUtility` + `File.WriteAllText`
- **Scoreboard** — Persistent leaderboard that survives game restarts
- **Multiple Scenes** — Menu scene, gameplay scene, and scoreboard scene with `SceneManager`
- **Game Manager** — Central `GameManager` singleton controlling game state and data flow
- **Death Zone** — Ball out-of-bounds detection and life/restart logic

## Tech Stack

| Layer | Technology |
|---|---|
| Engine | Unity (2021.x+) |
| Language | C# |
| Persistence | `JsonUtility`, `Application.persistentDataPath` |

## Project Structure

```
Assets/
├── Scripts/
│   ├── Ball.cs            # Ball physics and movement
│   ├── Brick.cs           # Brick hit detection and scoring
│   ├── DeathZone.cs       # Out-of-bounds trigger
│   ├── GameManager.cs     # Game state, score, data save/load
│   └── MenuController.cs  # Name entry and scene navigation
├── Scenes/
│   ├── Menu.unity         # Player name entry
│   ├── Game.unity         # Main gameplay
│   └── Scoreboard.unity   # High score display
└── Prefabs/
```

## Getting Started

**Prerequisites**
- Unity 2021.3 LTS or newer
- Unity Hub

**Running the project**
1. Clone the repository
   ```bash
   git clone https://github.com/Oppenheimr/Data-Persistence-Education.git
   ```
2. Open Unity Hub → **Add project from disk** → select the cloned folder
3. Open the `Menu` scene first (to set a player name)
4. Press **Play**

## Author

**Umutcan Bağcı** — [github.com/Oppenheimr](https://github.com/Oppenheimr)

## License

This project is licensed under the [MIT License](LICENSE).
