# CastleFarmer (In development)
A game about game balancing

There are two bases located at both ends of the map, both bases automatically spawn combat units and the units attacks the enemies automatically.
Player needs to control nothing but a variety of variables that would affect how the game developes.
For example, a player will be able to change: 
    1. The unit spawn interval of each base
    2. Unit health
    3. Unit movement speed
    4. Projectile damage
    5. Rate of fire of weapon
    6. Shell velocity of the projectile
    etc.

The goal is to either achieve a certain degree of balance (keep both bases alive for n seconds) or the opposite (eliminate one of the bases in n seconds)
The flag capture system is introduced so that another goal could be to achieve a flag score of a:b within n seconds.

There are random elements in the game that were designed to add to the game more dynamics, the best example would be the "fall back" mechanism of the combat units: they don't just stand there and shoot, instead they "retreat" after firing the first shot, keep going backwards for a random number of seconds and then move forward and return to the combat state.
