Schmup1_v1
==========

First 2D game made with Unity :0

Scripts [22]
=====
-> ClickScript
==== Loads the player statistics scene (playerstats) from menu/title scene
==== press enter to trigger
-> ClickToIntro
==== Loads LevelSelect scene from playerstats
==== press enter to trigger
-> CoinPickup
==== Handles coin logic, increases cash, destroys object when triggered
-> EnemyScript
==== Enemy logic + spawning
-> GameOver
==== Loads Lvl1 or 2 based on current scene when the player dies (called in onDestroy in PlayerScript)
-> HealthScript
==== Keeps track of health of enemies + player, destroys attached object when hp < 0, also prevents death from friendly fire
-> HeartHealth
==== Manages heart / life animation
-> LevelSelect1
==== selects level 1 from LevelSelect scene
-> LevelSelect2
==== selects level 2 from LevelSelect scene
-> MenuScript: NEVER USED
==== creates a gui button
-> MoveScript: NEVER USED
==== moves object along one axis
-> PauseScript: NEVER USED | WIP
==== attempt to pause the game from mouse click down
-> PlayerScript
==== Manages player logic, past pos.x > 45, calls winscene1 or winscene2 based on current level
-> PlayerStats
==== Simply displays the player statistics in the playerstats scene
-> RendererExtension
==== used to help with the camera and making the boundaries
-> ReplayLevel
==== Replays level from winscene1, winscene2, losescene1, and losescene2
-> ScoreCounter
==== Stores player data + keeps track of scoring
-> ScrollingScript
==== scrolls object, used in parallax scrolling
-> ShotScript: NEVER USED
==== destroys shots
-> SoundEffectHelper
==== plays sounds
-> SpecialEffectHelper
==== displays explosions
-> TypeWriteScript
==== makes type writer effect for intro info
-> WeaponScript
==== fires and moves bullets (used for player + enemy)