# ScriptablesUnityPdx

This repository contains the code and presentation material used during my talk at Unity PDX on 10/18/2018.

The concepts and ideas if using ScriptableObjects as events, variables and systems were taken from several popular Unity talks, including: 

Richard Fine, Unity Technologies
Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution
https://www.youtube.com/watch?v=6vmRwLYWNRo 

Ryan Hipple, Principal Engineer, Schell Games
Unite Austin 2017 - Game Architecture with Scriptable Objects
https://www.youtube.com/watch?v=raQ3iHhE_Kk

I highly suggest watching those presentations before digging into this code base.

The basic GameEvent and Variable demos are included in the master branch, but the two more complete demos are each in seperate branches.  One for the Meter Game Demo and another for the Wave Game Demo.

#### Meter Game Demo
The Meter Game Demo is a very simplistic game with a single input that when held causes the meter to rise.  The goal is to release the input and stop the meter at, or between, the Good and Perfect lines.  The better you are the faster the meter rises and the closer the lines get.  

The game demonstrates using Models created from Scriptable Events, Scriptable Variables and only a few specific scripts to create a loosely couple game architecture.

#### Wave Game Demo
The Wave Game Demo is not so much an actual game (as you cannot attack and therefore cannot win) as it is a deomonstration of using Scriptables for enemy generation and a wave spawning systems.  

