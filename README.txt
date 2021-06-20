Unity Kata #8 - Slot machine

What is a slot machine?
The gambling demon one armed bandit features a screen displaying 3 or more 
reels that spin when the game begins.
On the reels, different symbols are displayed. When the reels stop
and any 3 symbols are aligned in a row, the player is rewarded by a custom prize.
Operations vary from machine to machine, this one will let player stop each
reel one by one.

Requirements
 * textures/colors for symbols, count 8
 * reel object
 * configurable interact button
 * start spinning / stop individual spins
 * evaluation => did we win? => score system
 
Flow
 * Starting
 * press interact button
 * reels start spinning
 * press interact button
 * reel 1 stops
 * press interact button
 * reel 2 stops
 * press interact button
 * reel 3 stops
 * wait some seconds
 * show results
 * next cycle
 
Goal
 * functional slot machine prototype
 * practicing clean coding