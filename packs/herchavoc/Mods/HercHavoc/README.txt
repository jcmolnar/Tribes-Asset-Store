=============================================================================
 HERC HAVOC  --  authentic Starsiege HERCs for Tribes 1.5 Modern Client
=============================================================================

The Starsiege HERCs at Starsiege's own scale. Speeds, projectile velocities,
weapon ranges, blast radii and masses are imported 1:1 from the Starsiege
data files -- a Knight's Apocalypse walks at 88 km/h, a Heavy Autocannon
round flies at 350 m/s and reaches 500 m. Health and damage are Starsiege's
numbers divided by 100. (Mech Mayhem, the arcade take on the same HERCs,
still ships as its own mod.)


-----------------------------------------------------------------------------
 PLAYING
-----------------------------------------------------------------------------

YOUR HERC
  - Every HERC spawns in its Starsiege DEFAULT configuration: its own
    weapons, reactor, engine and shield generator. Prometheus carries 2
    Quantum Guns, 2 MFACs and 2 Heavy Blast Cannons.
  - Combat Value counts the whole HERC -- chassis, weapons and internals.
  - Classes by tonnage: light (<=35 t), medium (<=50 t), heavy (<=70 t),
    assault. Bosses: Prometheus, Harabec's Apocalypse, Caanon's Basilisk.

REACTOR (no heat, no shutdown)
  - Your energy bar is your reactor's battery; it recharges at the reactor's
    output. Every weapon draws its Starsiege charge per shot. Run dry and you
    simply cannot fire until it recovers.

SHIELDS AND ARMOUR
  - Shields by class: light 21, medium 26, heavy 31, assault 39, boss 47.
    They recharge constantly at your shield generator's rate.
  - Every HERC wears Quad-Bonded Metaplas armour; bosses wear Quicksilver
    nano armour, which slowly repairs itself.
  - Damage follows Starsiege: each weapon has its own effect against
    shields and armour. EMP shreds shields; autocannons are better against
    bare armour; a Blink Gun ignores shields entirely.
  - Heavy hits push you back (Starsiege projectile mass).

FIRING
  - Hold the trigger and your whole rack fires in relay, each weapon at its
    own rate. Next/prev weapon changes which weapon leads.
  - MINES go on the mine key, like Tribes mines. They are optional: pick
    Proximity or Arachnitron under "Mine pack" in the TAB menu. As in
    Starsiege the pack takes a hardpoint, so it replaces your last gun, and
    that gun's size (S/M/L) decides the pack. "No mines" restores the gun.

MOVEMENT
  - No jets on any HERC. Sidestep is capped at half your forward speed.
  - HERCs under 50 tons can DASH with the jump key (a stand-in for
    Starsiege's planned Pogo Thruster).
  - Leg damage cripples you (-40% speed).

LAST STAND
  - Human-faction T5+ HERCs eject their pilot on the killing blow.


-----------------------------------------------------------------------------
 HOSTING
-----------------------------------------------------------------------------

  - Pick Herc Havoc in the Mods menu, host any of its missions.
  - Bots: set $Server::BotBrain = 1 -- the mod ships its own bot roster.
  - Server prefs for this mod live in config\HercHavoc\ServerPrefs.cs.
  - $HH::MaxFlash (default 0.2) caps the red hit flash.
