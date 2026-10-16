//all damage tpye death messages and numbering go here
//setDamageScale(DamageType, Normal Player Armors[7], Admin Ultima Armor[1], Vehicles[5], Admin Armors[4]);
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
setDamageScale($ImpactDamageType,     1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Landing:
$LandingDamageType                    = 0;
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
setDamageScale($LandingDamageType,    1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  0.0,0.0,0.0,0.75);
//Bullet:
$BulletDamageType                     = 1;
$deathMsg[$BulletDamageType, 0]       = "%1 ventilates %2 with %3 gun.";
$deathMsg[$BulletDamageType, 1]       = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]       = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]       = "%1 guns down %2.";
setDamageScale($BulletDamageType,     1.0, 1.2, 1.1, 1.0,0.8, 0.6, 0.6,  0.5,  1.0,1.0,1.0,1.0,1.0,  0.1,0.1,1.0,1.0);
//Energy:
$EnergyDamageType                     = 2;
$deathMsg[$EnergyDamageType, 0]       = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]       = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]       = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]       = "%2 ends up on the wrong side of a turret.";
setDamageScale($EnergyDamageType,     1.3, 1.3, 1.15,1.0,0.85,0.7, 0.7,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Plasma:
$PlasmaDamageType                     = 3;
$deathMsg[$PlasmaDamageType, 0]       = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]       = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]       = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]       = "%1 gives %2 a plasma transfusion.";
setDamageScale($PlasmaDamageType,     1.0, 1.0, 0.8, 1.0,0.7, 0.4, 0.4,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Explosion:
$ExplosionDamageType                  = 4;
$deathMsg[$ExplosionDamageType, 0]    = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]    = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]    = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]    = "%2 falls victim to %1's Stormhammer.";
setDamageScale($ExplosionDamageType,  1.2, 1.0, 1.0, 1.0,0.8, 0.6, 0.6,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,0.5);
//Shrapnel:
$ShrapnelDamageType                   = 5;
$deathMsg[$ShrapnelDamageType, 0]     = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]     = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]     = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]     = "%2 never saw it coming from %1.";
setDamageScale($ShrapnelDamageType,   1.2, 1.2, 1.1, 1.0,0.9, 0.8, 0.8,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Laser:
$LaserDamageType                      = 6;
$deathMsg[$LaserDamageType, 0]        = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]        = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]        = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]        = "%2 stayed in %1's crosshairs for too long.";
setDamageScale($LaserDamageType,      0.5, 1.2, 1.1, 1.0,0.8, 0.6, 0.8,  0.5,  1.0,0.5,0.5,1.0,0.5,  1.0,1.0,1.0,1.0);
$HeadVal[$LaserDamageType] = 3;
$HeadVal[Heavy,$LaserDamageType] = 5;
//Mortar:
$MortarDamageType                     = 7;
$deathMsg[$MortarDamageType, 0]       = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]       = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]       = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]       = "%1's mortar takes out %2.";
setDamageScale($MortarDamageType,     1.4, 1.3, 1.15,1.0,0.85,0.7, 0.7,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Blaster:
$BlasterDamageType                    = 8;
$deathMsg[$BlasterDamageType, 0]      = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]      = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]      = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]      = "%2 meets %1's master blaster.";
setDamageScale($BlasterDamageType,    1.3, 1.3, 1.15,1.0,0.85,0.7, 0.7,  0.5,  0.5,0.5,0.5,0.5,0.5,  1.0,1.0,0.5,1.0);
//Electricity:
$ElectricityDamageType                = 9;
$deathMsg[$ElectricityDamageType, 0]  = "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1]  = "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2]  = "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3]  = "%1 short-circuits %2's systems.";
setDamageScale($ElectricityDamageType,1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Crush:
$CrushDamageType                      = 10;
$deathMsg[$CrushDamageType, 0]        = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]        = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]        = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]        = "%2 gets caught in the machinery.";
setDamageScale($CrushDamageType,      1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Debris:
$DebrisDamageType                     = 11;
$deathMsg[$DebrisDamageType, 0]       = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]       = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]       = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]       = "%2 got too close to the exploding stuff.";
setDamageScale($DebrisDamageType,     1.2, 1.2, 1.1, 1.0,0.9, 0.8, 0.8,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Missile:
$MissileDamageType                    = 12;
$deathMsg[$MissileDamageType, 0]      = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]      = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]      = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]      = "%2 feels the burn from a warhead.";
setDamageScale($MissileDamageType,    1.4, 1.0, 1.0, 1.0,0.8, 0.6, 0.7,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Mine:
$MineDamageType                       = 13;
$deathMsg[$MineDamageType, 0]         = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]         = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]         = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]         = "%2 never saw it coming from %1.";
setDamageScale($MineDamageType,       1.2, 1.2, 1.1, 1.0,0.9, 0.8, 0.8,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Phantom:
$PhantomDamageType                    = 14;
$deathMsg[$PhantomDamageType, 0]      = "%2 never saw it coming from %1.";
$deathMsg[$PhantomDamageType, 1]      = "%2 is killed by %1's phantom rocket.";
$deathMsg[$PhantomDamageType, 2]      = "%2 says \"What was that?!\".";
$deathMsg[$PhantomDamageType, 3]      = "%2 got hit by an invisible rocket. Now guess where it hit.";
setDamageScale($PhantomDamageType,    1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Sniper:
$SniperDamageType                     = 15;
$deathMsg[$SniperDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$SniperDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$SniperDamageType, 2]       = "%2 becomes a victim of %1's sniper rifle.";
$deathMsg[$SniperDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
setDamageScale($SniperDamageType,     0.5, 1.2, 1.1, 1.0,0.8, 0.6, 0.8,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
$HeadVal[$SniperDamageType] = 2;
$HeadVal[Heavy,$SniperDamageType] = 3;
//Poison:
$PoisonDamageType                     = 16;
$deathMsg[$PoisonDamageType, 0]       = "%1 poisoned %2.";
$deathMsg[$PoisonDamageType, 1]       = "%2 was poisoned by %1.";
$deathMsg[$PoisonDamageType, 2]       = "%1 gives %2 a lethal injection.";
$deathMsg[$PoisonDamageType, 3]       = "%2 felt the sting of %1.";
setDamageScale($PoisonDamageType,     1.0, 1.2, 1.1, 1.0,0.8, 0.6, 0.8,  0.5,  0.8,0.8,0.8,0.8,0.8,  1.0,1.0,1.0,1.0);
$HeadVal[$PoisonDamageType] = 1.25;
$HeadVal[Heavy,$PoisonDamageType] = 1.5;
//Kamikaze:
$KamikazeDamageType                   = 17;
$deathMsg[$KamikazeDamageType, 0]     = "%1 died for %3 cuase and took %2 along for the ride.";
$deathMsg[$KamikazeDamageType, 1]     = "%2 didn't notice %1 was a bomb!";
$deathMsg[$KamikazeDamageType, 2]     = "%1 defines \"Kamikaze\" for %2.";
$deathMsg[$KamikazeDamageType, 3]     = "%1 shows %2 the way to Hades.";
setDamageScale($KamikazeDamageType,   0.55,0.66,0.83,1.0,1.16,1.32,1.5,  1.0,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Storm:
$StormDamageType                      = 18;
$deathMsg[$StormDamageType, 0]        = "%1 blew %2 away.";
$deathMsg[$StormDamageType, 1]        = "%1 shows %2 how it felt to be dorthy.";
$deathMsg[$StormDamageType, 2]        = "%2 meets %1's perfect storm.";
$deathMsg[$StormDamageType, 3]        = "%2 is tossed around like a rag doll by %1.";
setDamageScale($StormDamageType,      1.3, 1.2, 1.1, 1.0,0.9, 0.8, 0.7,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Gravity:
$GravityDamageType                    = 19;
$deathMsg[$GravityDamageType, 0]      = "%1 teaches %2 a painful lesson in the laws of gravity.";
$deathMsg[$GravityDamageType, 1]      = "%1's implosion mortar sucks %2 into an abyss.";
$deathMsg[$GravityDamageType, 2]      = "%2 is last heard saying \"My brians are going into my feet\".";
$deathMsg[$GravityDamageType, 3]      = "%1 brings %2's world crashing down on him.";
setDamageScale($GravityDamageType,    0.7, 0.8, 0.9, 1.0,1.1, 1.2, 1.3,  0.5,  1.5,1.5,1.5,1.5,1.5,  1.0,1.0,1.0,1.0);
//Fire:
$FireDamageType                       = 20;
$deathMsg[$FireDamageType, 0]         = "%1 burns %2 to a crisp.";
$deathMsg[$FireDamageType, 1]         = "%2 gets torched by %1.";
$deathMsg[$FireDamageType, 2]         = "%1 ask %2 \"Need a light?\".";
$deathMsg[$FireDamageType, 3]         = "%2 is reduced to ash by %1.";
setDamageScale($FireDamageType,       1.2, 1.2, 1.1, 1.0,0.8, 0.6, 0.6,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//EMP:
$EmpDamageType                        = 21;
$deathMsg[$EmpDamageType, 0]          = "%2 gets zapped with %1's EMP gun.";
$deathMsg[$EmpDamageType, 1]          = "%1 gives %2 a nasty jolt.";
$deathMsg[$EmpDamageType, 2]          = "%2 gets a real shock out of meeting %1.";
$deathMsg[$EmpDamageType, 3]          = "%1 short-circuits %2's systems.";
setDamageScale($EMPDamageType,        1.3, 1.3, 1.15,1.0,0.85,0.7, 0.7,  0.5,  0.5,0.5,0.5,0.5,0.5,  1.0,1.0,1.0,1.0);
//Shock:
$ShockDamageType                      = 22;
$deathMsg[$ShockDamageType, 0]        = "%1 returned %2's blast";
$deathMsg[$ShockDamageType, 1]        = "%1 shows %2 how much it all hurts.";
$deathMsg[$ShockDamageType, 2]        = "%1 exact's his sweet revenge upon %2.";
$deathMsg[$ShockDamageType, 3]        = "%1 wanted to return %2's gift.";
setDamageScale($ShockDamageType,      1.25,1.0, 1.0, 1.0,1.0, 1.0, 1.25, 0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Proto:
$ProtoDamageType                      = 23;
$deathMsg[$ProtoDamageType, 0]        = "%2 gets a blast out of %1.";
$deathMsg[$ProtoDamageType, 1]        = "%2 succumbs to %1's Proto Gun.";
$deathMsg[$ProtoDamageType, 2]        = "%1's Proto Gun shows %2 a new world of pain.";
$deathMsg[$ProtoDamageType, 3]        = "%2 meets %1's Proto Gun.";
setDamageScale($ProtoDamageType,      1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,0.0,1.0);
//Null: {should not kill you}
$NullDamageType                       = 24;
setDamageScale($NullDamageType,       0.0, 0.0, 0.0, 0.0,0.0, 0.0, 0.0,  0.0,  0.0,0.0,0.0,0.0,0.0,  0.0,0.0,0.0,0.0);
//Saiyan:
$SaiyanDamageType                     = 25;
$deathMsg[$SaiyanDamageType, 0]       = "%1's energy sends %2 into oblivion.";
$deathMsg[$SaiyanDamageType, 1]       = "%1 blast %2 to pieces.";
$deathMsg[$SaiyanDamageType, 2]       = "%2 gets a feel for %1's power.";
$deathMsg[$SaiyanDamageType, 3]       = "%2 now knows what true power is.";
setDamageScale($SaiyanDamageType,     1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Fusion:
$FusionDamageType = 26;
$deathMsg[$FusionDamageType, 0]      = "%1's Fusion Rifle destroyed %2.";
$deathMsg[$FusionDamageType, 1]      = "%1 blast %2 to pieces.";
$deathMsg[$FusionDamageType, 2]      = "%2 gets blown to bits by %1's Fusion Rifle.";
$deathMsg[$FusionDamageType, 3]      = "%2 was fused by %1.";
setDamageScale($FusionDamageType,     1.3, 1.3, 1.15,1.0,0.85,0.7, 0.7,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Fusion Malfunction:
$FusMalFuncDamageType                 = 27;
$deathMsg[$FusMalFuncDamageType, 0]   = "%2 was to close when %1's Fusion Rifle malfunctioned.";
$deathMsg[$FusMalFuncDamageType, 1]   = "%2 fused with %1.";
$deathMsg[$FusMalFuncDamageType, 2]   = "%2 gets blown to bits by %1's accident.";
$deathMsg[$FusMalFuncDamageType, 3]   = "%2 was destroyed in an accident.";
setDamageScale($FusMalFuncDamageType, 0.55,0.66,0.83,1.0,1.16,1.32,1.5,  1.0,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Apocalypse:
$ApocalypseDamageType                 = 28;
$deathMsg[$ApocalypseDamageType, 0]   = "%2 was to obliterated by %1's Apocalypse.";
$deathMsg[$ApocalypseDamageType, 1]   = "%1 showed %2 the meaning of mass destruction.";
$deathMsg[$ApocalypseDamageType, 2]   = "%2 gets blown to bits by %1.";
$deathMsg[$ApocalypseDamageType, 3]   = "%2 was destroyed by %1.";
setDamageScale($ApocalypseDamageType, 1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.5,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Nanite:
$NaniteDamageType                     = 29;
$deathMsg[$NaniteDamageType, 0]       = "%2 was eaten by %1's tiny robots.";
$deathMsg[$NaniteDamageType, 1]       = "%2 was disasembled by %1's nanites.";
$deathMsg[$NaniteDamageType, 2]       = "%1 sent out his army of nanites upon %2.";
$deathMsg[$NaniteDamageType, 3]       = "%1's nanites devoured %2.";
setDamageScale($NaniteDamageType,     1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  1.0,  1.5,1.5,1.5,1.5,1.5,  1.0,1.0,1.0,1.0);
//No Charge Saiyan:
$NCSaiyanDamageType                   = 30;
$deathMsg[$NCSaiyanDamageType, 0]     = "%1's energy sends %2 into oblivion.";
$deathMsg[$NCSaiyanDamageType, 1]     = "%1 blast %2 to pieces.";
$deathMsg[$NCSaiyanDamageType, 2]     = "%2 gets a feel for %1's power.";
$deathMsg[$NCSaiyanDamageType, 3]     = "%2 now knows what true power is.";
setDamageScale($NCSaiyanDamageType,   1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
//Physical:
$PhysicalDamageType                   = 31;
$deathMsg[$PhysicalDamageType, 0]     = "%1 beat %2 like a red headed step child.";
$deathMsg[$PhysicalDamageType, 1]     = "%2 is beaten to death by %1.";
$deathMsg[$PhysicalDamageType, 2]     = "%2 was victim to %1's vicious beating.";
$deathMsg[$PhysicalDamageType, 3]     = "%1 beat %2 into a bloody pulp.";
setDamageScale($PhysicalDamageType,   2.0, 2.0, 2.0, 2.0,2.0, 2.0, 2.0,  1.0,  1.0,0.5,1.0,2.0,1.0,  2.0,2.0,2.0,2.0);
$HeadVal[$PhysicalDamageType] = 1.5;
$HeadVal[Heavy,$PhysicalDamageType] = 2.0;
//Giga:
$GigaDamageType                       = 32;
$deathMsg[$GigaDamageType, 0]         = "%2 was in the path of %1's Giga Attack.";
$deathMsg[$GigaDamageType, 1]         = "%2 was destroyed by %1's Giga Attack.";
$deathMsg[$GigaDamageType, 2]         = "%1 obliterated %2 with %3 Giga Attack.";
$deathMsg[$GigaDamageType, 3]         = "%1's Giga Attack killed %2.";
setDamageScale($GigaDamageType,       1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,0.0,1.0);
//Flash:
$FlashDamageType                      = 33;
$deathMsg[$FlashDamageType, 0]        = "%1 showed %2 the light.";
$deathMsg[$FlashDamageType, 1]        = "%2 lost sight of %4 goals.";
$deathMsg[$FlashDamageType, 2]        = "%1 flashed %2 to death.";
$deathMsg[$FlashDamageType, 3]        = "%1 killed %2 with %3 flash bang.";
setDamageScale($FlashDamageType,      0.5, 1.0, 1.0, 1.0,1.0, 1.0, 1.25, 0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,0.0,1.0);
//Teleport: {used to determine death massage for over use of Quicksilver beacon or contact}
$TeleDamageType                       = 34;
setDamageScale($TeleDamageType,       0.0, 0.0, 0.0, 0.0,0.0, 0.0, 0.0,  0.0,  0.0,0.0,0.0,0.0,0.0,  0.0,0.0,0.0,0.0);
//Pulse:
$PulseDamageType                      = 35;
$deathMsg[$PulseDamageType, 0]        = "%1 cuts %2 in half with %3 pulse laser.";
$deathMsg[$PulseDamageType, 1]        = "%1 sliced through %2's armor with %3 pulse laser.";
$deathMsg[$PulseDamageType, 2]        = "%1 burned holes in %2 with %3 pulse laser.";
$deathMsg[$PulseDamageType, 3]        = "%2 was singed by %1's pulse laser.";
setDamageScale($PulseDamageType,      1.0, 1.0, 0.8, 0.8,0.8, 1.0, 1.0,  0.5,  1.0,0.5,0.5,1.0,1.0,  1.0,1.0,1.0,1.0);
$HeadVal[$PulseDamageType] = 1.25;
$HeadVal[Heavy,$PulseDamageType] = 1.5;
//Beam:
$BeamDamageType                       = 36;
$deathMsg[$BeamDamageType, 0]         = "%1 punched a hole through %2 with %3 beam cannon.";
$deathMsg[$BeamDamageType, 1]         = "%1's beam cannon decimates %2.";
$deathMsg[$BeamDamageType, 2]         = "%2 learned not to walk towards the light of %1's beam.";
$deathMsg[$BeamDamageType, 3]         = "%2 stayed in %1's crosshairs for too long.";
setDamageScale($BeamDamageType,       1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,0.5,0.5,1.0,0.25, 1.0,1.0,1.0,1.0);
$HeadVal[$BeamDamageType] = 2;
$HeadVal[Heavy,$BeamDamageType] = 3;
//Plobe:
$PlobeDamageType                      = 37;
$deathMsg[$PlobeDamageType, 0]        = "%1 shoved %3 plobe up %2's ass.";
$deathMsg[$PlobeDamageType, 1]        = "%1 gave %2 the royal plobing.";
$deathMsg[$PlobeDamageType, 2]        = "%2 got plobed by %1.";
$deathMsg[$PlobeDamageType, 3]        = "%2 doubted %1's almighty plobe.";
setDamageScale($PlobeDamageType,      1.0, 1.0, 1.0, 1.0,1.0, 1.0, 1.0,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,0.0,1.0);
//Rail:
$RailDamageType                       = 38;
$deathMsg[$RailDamageType, 0]         = "%1 put a rail bolt through %2.";
$deathMsg[$RailDamageType, 1]         = "%1 showed %2 how hyper acceleration works.";
$deathMsg[$RailDamageType, 2]         = "%2 learns the about power of magnets from %1.";
$deathMsg[$RailDamageType, 3]         = "%2 had a hole punched in %4 head courtesy of %1.";
setDamageScale($RailDamageType,       0.7, 0.8, 0.9, 1.0,1.1, 1.2, 1.3,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,1.0,1.0);
$HeadVal[$RailDamageType] = 1.25;
$HeadVal[Heavy,$RailDamageType] = 1.5;
//Plobe:
$FrostDamageType                      = 39;
$deathMsg[$FrostDamageType, 0]        = "%1 gave %2 the cold shoulder.";
$deathMsg[$FrostDamageType, 1]        = "%1 told %2 to chill out.";
$deathMsg[$FrostDamageType, 2]        = "%2 got a lethal case of frost bite from %1.";
$deathMsg[$FrostDamageType, 3]        = "%2 was sent to the Ice Age by %1.";
setDamageScale($FrostDamageType,      1.0, 1.0, 1.0, 1.0,1.0, 0.8, 0.8,  0.5,  1.0,1.0,1.0,1.0,1.0,  1.0,1.0,0.0,1.0);

$numDeathMsgs = 4;
