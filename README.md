# Steampunk capture the point FPS


## Progress
- 0.0.0: created unity project
- 0.0.9: created player controller, guns, basic enemy AI

#### Timeline
  - [X] Movement
  - [X] Jump, Sprint, Crouch
  - [ ] Health and Ammo
  - [ ] Weapon and Firing
  - [ ] Scope aim
  - [ ] Consumeable throw
  - [ ] Health kit
  
  - [ ] AI and Aim RNG
  
  - [ ] Capture points
  - [ ] Spawn locations
  - [ ] Capture and defend timer
  - [ ] Harder Enemys with progression
  - [ ] Weapon Variety


## File Structure
- **Based on [Unitys Guidlines](https://unity.com/how-to/organizing-your-project)**
- Folders should not include spaces
- organize files by username
- Folder names should follow PascelCase and attempt to be a single word
- Empty folders require a `.keep` file to avoid errors with git
- Avoid underscores, spaces, and hyphens, naming assets should follow PascelCase
- Create new scenes when working on a new focus
```
GP2_fpsProject
└── [...] 
   └── Assets
      ├── USERNAME
      │  ├── Art
      │  │  ├── Materials
      │  │  ├── Models
      │  │  └── Textures
      │  ├── Audio
      │  │  ├── Music
      │  │  └── Sound
      │  ├── Code
      │  │  ├── Scripts
      │  │  └── Shaders
      │  ├── Docs
      │  └── Level
      │  │  ├── Prefabs
      │  │  ├── Scenes
      │  │  └── UI
      │  └── External
      └── Thirdparty
```

## Formatting
Code should be formatted with [C Sharpier](https://csharpier.com/)

#### Variables
- Camel Case (variableName)
- getter-setters should use Pascal Case (VaraibleName)
- booleans should start with "is", "can", or "should"
- keycodes should start with "key"
- vector3s should start with "center", "position", or "direction"

#### Functions
- Pascal Case (FunctionName)
- Functions that return a value should start with "Get"
- Functions that take an input should start with "Set"
- Functions that change global variables should start with "Apply"
- Functions that have conditions should start with "Handle"

#### Constants
- Upper Snake Case (CONSTAINT_NAME)


## Resources
#### Channels
- [Brackeyes](https://www.youtube.com/@brackeys)
- [Welton King](https://www.youtube.com/@welton.king.v)
- [Mina Pecheux](https://www.youtube.com/@minapecheux)
- [Comp-3 Interactive](https://www.youtube.com/@comp3interactive)
- [Llam Academy](https://www.youtube.com/@LlamAcademy)

#### Tutorials
- [Advanced Coding For Big Projects](https://youtu.be/dLCLqEkbGEQ)
- [FPS Controller](https://youtu.be/2FTDa14nryI)
- [Guns From Scratch](https://www.youtube.com/playlist?list=PLllNmP7eq6TQJjgKJ6FKcNFfRREe_L6to)
- [Projectiles](https://youtu.be/gEldXRstNHE)
- [Behaviour Tree](https://youtu.be/aR6wt5BlE-E)
- [Random Enemy Spawn Positions](https://youtu.be/ydjpNNA5804)


## Project Outline

#### Gameplay
  - The game consists of a linear map of checkpoints the player must capture to complete the level/game. During the game the player will have 5 minutes to capture the nearest point
  - Timer - (5 minute length placeholder) - If the 5 minutes run out before the player captures the point, the enemies will have 5 minutes to take the players point (enemies will advance towards the players point)
  - Points - captured by being the only team at the point location for 10 seconds
  - Enemies - As the player captures more points, harder enemies will appear
  - If the player is pushed back, the harder enemies will not stop spawning

#### GUI
  - Health, Ammo, Inv - left side health bar, ammo count under health, right side quick inventory (medkit, etc)
  - Marker - checkpoint direction
  - Checkpoint Bar - (colored checkpoints = captured, greyscale = to be captured)
  - Timer - shows time left and current goal (ie: attack/defend)

#### Sound/Effects
  - Movement - Running, jumping, firing, knockout, low health, oneshot - will have sound effects
  - Markers - Hit markers and knockout - effects

#### Backlog
  - Artillery - (pulls up a map that lets you click a location to send a large amount of damage to after delay)
  - Advanced enemy AI - (Enemies basic implementation is just stand around predetermined points, and run towards capture points. New Ai would cause some to shoot from afar, stay together in “squads”, and flank)


## How to use git/github

<details close> 
  <summary>Powershell Directions</summary>
  
  - Install Windows Terminal from microsoft store
  - Install a nerd font (https://www.nerdfonts.com/font-downloads)
  - Run ` winget install JanDeDobbeleer.OhMyPosh `
  - Run ` winget install --id Git.Git -e --source winget `
  - Restart terminal
  - Run ` PowerShellGet\Install-Module posh-git -Scope CurrentUser -Force `
  - Run ` New-Item -path $profile -type file -force `
  - Run ` New-Item -path C:/Code/powershell.json -type file -force `
  - Run ` notepad C:/Code/powershell.json `
  - Paste contents of powersell.json inside this file
  - Run ` notepad  $PROFILE `
  - Add "oh-my-posh --init --shell pwsh --config C:/Code/powershell.json | Invoke-Expression"
  - Run ` Import-Module posh-git ` and ` Add-PoshGitToProfile `
</details>

<details close> 
  <summary>Git Setup Directions</summary>
  
  - Setup your git run ` git config --global user.email "YOUR EMAIL" ` and ` git config --global user.name "YOUR NAME" `
  - Create a ` GitHub ` folder in Documents
  - Run ` cd ~/Documents/GitHub `
  - Run ` git clone https://github.com/googl267/GP2_fpsProject.git `
  - Run ` cd GP2_fpsProject.git `
  - Run ` git remote set-url origin https://github.com/googl267/GP2_fpsProject.git `
  - Run ` git checkout testing `
  - Run ` git pull `
</details>

<details open> 
  <summary>Using Git</summary>
  
  - Make sure your in your project directory on the right branch
  - To sync run ` git pull `
  - To commit run ` git add -A; git commit -m "YOUR MESSAGE"; git push origin [branch] `
</details>
