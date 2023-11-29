# Game Programming II Course Long Assignment
<details close> 
  <summary><h2>Project Outline</h2></summary>
  
  <details open> 
    <summary><h4>Gameplay</h4></summary>
    
  - The game consists of a linear map of checkpoints the player must capture to complete the level/game. During the game the player will have 5 minutes to capture the nearest point
  - Timer - (5 minute length placeholder) - If the 5 minutes run out before the player captures the point, the enemies will have 5 minutes to take the players point (enemies will advance towards the players point)
  - Points - captured by being the only team at the point location for 10 seconds
  - Enemies - As the player captures more points, harder enemies will appear
  - If the player is pushed back, the harder enemies will not stop spawning

  </details>

  <details open> 
    <summary><h4>GUI</h4></summary>
    
  - Health, Ammo, Inv - left side health bar, ammo count under health, right side quick inventory (medkit, etc)
  - Marker - checkpoint direction
  - Checkpoint Bar - (colored checkpoints = captured, greyscale = to be captured)
  - Timer - shows time left and current goal (ie: attack/defend)
  </details>

  <details open> 
    <summary><h4>Sound/Effects</h4></summary>
    
  - Movement - Running, jumping, firing, knockout, low health, oneshot - will have sound effects
  - Markers - Hit markers and knockout - effects
  </details>

  <details open> 
    <summary><h4>Backlog</h4></summary>
    
  - Artillery - (pulls up a map that lets you click a location to send a large amount of damage to after delay)
  - Advanced enemy AI - (Enemies basic implementation is just stand around predetermined points, and run towards capture points. New Ai would cause some to shoot from afar, stay together in “squads”, and flank)
  </details>
</details>



## Tutorials
- https://www.youtube.com/@Brackeys

## Timeline
<details open> 
  <summary><h4>Player</h4></summary>
  
  - [X] Collisions
  - [X] Movement
  - [X] Jump, Sprint, Etc
  - [ ] Health and Ammo
  - [ ] Weapon and Firing
  - [ ] Scope aim
  - [ ] Consumeable throw
  - [ ] Health kit
</details>

<details open> 
  <summary><h4>Enemys</h4></summary>
  
  - [ ] Collisions
  - [ ] Movement
  - [ ] AI and Aim RNG
  - [ ] Spawning
</details>

<details open> 
  <summary><h4>Gameplay</h4></summary>
  
  - [ ] Capture points
  - [ ] Spawn locations
  - [ ] Capture and defend timer
  - [ ] Harder Enemys with progression
  - [ ] Weapon Variety
</details>

<details close> 
  <summary><h3>Powershell Directions</h3></summary>
  
  - Install Windows Terminal from microsoft store
  - Run ` winget install JanDeDobbeleer.OhMyPosh `
  - Run ` winget install --id Git.Git -e --source winget `
  - Restart terminal
  - Run ` PowerShellGet\Install-Module posh-git -Scope CurrentUser -Force `
  - Run ` New-Item -path $profile -type file -force `
  - Run ` New-Item -path C:/Code/powershell.json -type file -force `
  - Run ` notepad C:/Code/powershell.json `
  - Paste contents of powersell.json inside this folder
  - Run ` notepad  $PROFILE `
  - Add "oh-my-posh --init --shell pwsh --config C:/Code/powershell.json | Invoke-Expression"
  - Run ` Import-Module posh-git ` and ` Add-PoshGitToProfile `
</details>