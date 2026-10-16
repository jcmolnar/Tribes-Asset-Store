//all damage tpye death messages and numbering go here
//setDamageScale(DamageType, Normal Player Armors[3] Vehicles[3]);
//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
# Damage Types
#
//Suicide: -2
// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]                       = "%1 ends it all.";
$deathMsg[-2,1]                       = "%1 takes %2 own life.";
$deathMsg[-2,2]                       = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]                       = "%1 decides to see what the afterlife is like.";
//Impact:
$ImpactDamageType                     = -1;
$deathMsg[$ImpactDamageType, 0]       = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]       = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]       = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]       = "%1 says, 'Hey %2, you scratched my paint job!'";
setDamageScale($ImpactDamageType,     1.0,1.0,1.0, 1.0,1.0,1.0, 0.0);
//Landing:
$LandingDamageType                    = 0;
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
setDamageScale($LandingDamageType,    1.0,1.0,1.0, 1.0,1.0,1.0, 0.0);
//Bullet:
$BulletDamageType                     = 1;
$deathMsg[$BulletDamageType, 0]       = "%1 ventilates %2 with %3 gun.";
$deathMsg[$BulletDamageType, 1]       = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]       = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]       = "%1 guns down %2.";
setDamageScale($BulletDamageType,     1.2,1.0,0.6, 1.0,1.0,1.0, 0.0);
//Energy:
$EnergyDamageType                     = 2;
$deathMsg[$EnergyDamageType, 0]       = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]       = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]       = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]       = "%2 ends up on the wrong side of a turret.";
setDamageScale($EnergyDamageType,     1.3,1.0,0.7, 1.0,1.0,1.0, 0.0);
//Plasma:
$PlasmaDamageType                     = 3;
$deathMsg[$PlasmaDamageType, 0]       = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]       = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]       = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]       = "%1 gives %2 a plasma transfusion.";
setDamageScale($PlasmaDamageType,     1.0,1.0,0.4, 1.0,1.0,1.0, 0.25);
//Explosion:
$ExplosionDamageType                  = 4;
$deathMsg[$ExplosionDamageType, 0]    = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]    = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]    = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]    = "%2 falls victim to %1's Stormhammer.";
setDamageScale($ExplosionDamageType,  1.0,1.0,0.6, 1.0,1.0,1.0, 0.25);
//Shrapnel:
$ShrapnelDamageType                   = 5;
$deathMsg[$ShrapnelDamageType, 0]     = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]     = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]     = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]     = "%2 never saw it coming from %1.";
setDamageScale($ShrapnelDamageType,   1.2,1.0,0.8, 1.0,1.0,1.0, 1.0);
//Laser:
$LaserDamageType                      = 6;
$deathMsg[$LaserDamageType, 0]        = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]        = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]        = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]        = "%2 stayed in %1's crosshairs for too long.";
setDamageScale($LaserDamageType,      1.2,1.0,0.6, 1.0,0.5,0.5, 0.0);
$HeadVal[$LaserDamageType] = 3;
$HeadVal[Heavy,$LaserDamageType] = 5;
//Mortar:
$MortarDamageType                     = 7;
$deathMsg[$MortarDamageType, 0]       = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]       = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]       = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]       = "%1's mortar takes out %2.";
setDamageScale($MortarDamageType,     1.3,1.0,0.7, 1.0,1.0,1.0, 1.0);
//Blaster:
$BlasterDamageType                    = 8;
$deathMsg[$BlasterDamageType, 0]      = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]      = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]      = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]      = "%2 meets %1's master blaster.";
setDamageScale($BlasterDamageType,    1.3,1.0,0.7, 0.5,0.5,0.5, 0.0);
//Electricity:
$ElectricityDamageType                = 9;
$deathMsg[$ElectricityDamageType, 0]  = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1]  = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2]  = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3]  = "%1 short-circuits %2's systems.";
setDamageScale($ElectricityDamageType,1.0,1.0,1.0, 1.0,1.0,1.0, 0.0);
//Crush:
$CrushDamageType                      = 10;
$deathMsg[$CrushDamageType, 0]        = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]        = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]        = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]        = "%2 gets caught in the machinery.";
setDamageScale($CrushDamageType,      1.0,1.0,1.0, 1.0,1.0,1.0, 0.0);
//Debris:
$DebrisDamageType                     = 11;
$deathMsg[$DebrisDamageType, 0]       = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]       = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]       = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]       = "%2 got too close to the exploding stuff.";
setDamageScale($DebrisDamageType,     1.2,1.0,0.8, 1.0,1.0,1.0, 1.0);
//Missile:
$MissileDamageType                    = 12;
$deathMsg[$MissileDamageType, 0]      = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]      = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]      = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]      = "%2 feels the burn from a warhead.";
setDamageScale($MissileDamageType,    1.0,1.0,0.6, 1.0,1.0,1.0, 1.0);
//Mine:
$MineDamageType                       = 13;
$deathMsg[$MineDamageType, 0]         = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]         = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]         = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]         = "%2 never saw it coming from %1.";
setDamageScale($MineDamageType,       1.2,1.0,0.8, 1.0,1.0,1.0, 1.0);
//Poison:
$PoisonDamageType                     = 14;
$deathMsg[$PoisonDamageType, 0]       = "%1 poisoned %2.";
$deathMsg[$PoisonDamageType, 1]       = "%2 was poisoned by %1.";
$deathMsg[$PoisonDamageType, 2]       = "%1 gives %2 a lethal injection.";
$deathMsg[$PoisonDamageType, 3]       = "%2 felt the sting of %1.";
setDamageScale($PoisonDamageType,     1.2,1.0,0.6, 0.8,0.8,0.8, 0.0);
$HeadVal[$PoisonDamageType] = 1.25;
$HeadVal[Heavy,$PoisonDamageType] = 1.5;
//Fire:
$FireDamageType                       = 15;
$deathMsg[$FireDamageType, 0]         = "%1 burns %2 to a crisp.";
$deathMsg[$FireDamageType, 1]         = "%2 gets torched by %1.";
$deathMsg[$FireDamageType, 2]         = "%1 ask %2 \"Need a light?\".";
$deathMsg[$FireDamageType, 3]         = "%2 is reduced to ash by %1.";
setDamageScale($FireDamageType,       1.2,1.0,0.6, 1.0,1.0,1.0, 0.25);
//EMP:
$EmpDamageType                        = 16;
$deathMsg[$EmpDamageType, 0]          = "%2 gets zapped with %1's EMP gun.";
$deathMsg[$EmpDamageType, 1]          = "%1 gives %2 a nasty jolt.";
$deathMsg[$EmpDamageType, 2]          = "%2 gets a real shock out of meeting %1.";
$deathMsg[$EmpDamageType, 3]          = "%1 short-circuits %2's systems.";
setDamageScale($EMPDamageType,        1.3,1.0,0.7, 0.5,0.5,0.5, 0.0);
//Flash:
$FlashDamageType                      = 17;
$deathMsg[$FlashDamageType, 0]        = "%1 showed %2 the light.";
$deathMsg[$FlashDamageType, 1]        = "%2 lost sight of %4 goals.";
$deathMsg[$FlashDamageType, 2]        = "%1 flashed %2 to death.";
$deathMsg[$FlashDamageType, 3]        = "%1 killed %2 with %3 flash bang.";
setDamageScale($FlashDamageType,      1.0,1.0,1.0, 1.0,1.0,1.0, 0.0);
//Null: {should not kill you}
$NullDamageType                       = 18;
$deathMsg[$NullDamageType, 0]         = "This mods creator doesn't know how %2 died.";
$deathMsg[$NullDamageType, 1]         = "This mods creator doesn't know how %2 died.";
$deathMsg[$NullDamageType, 2]         = "This mods creator doesn't know how %2 died.";
$deathMsg[$NullDamageType, 3]         = "This mods creator doesn't know how %2 died.";
setDamageScale($NullDamageType,       0.0,0.0,0.0, 0.0,0.0,0.0, 0.0);

$numDeathMsgs = 4;
