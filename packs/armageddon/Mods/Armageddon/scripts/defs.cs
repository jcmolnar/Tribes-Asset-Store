function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0>Damage per shot: 0.1\nFire Rate: 0.3 seconds", $DisplayTime);
}
function RSniper::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>This is a revolutionary new way to repair items.\nThe splash repairs all items in the game, and you can use it like a sniper!<f0>\n Help your friends in need or repair your turrets from far away..its up to you!", $DisplayTime);
}
function OmegaRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>This gun transfers the targets life-force to you... as well as acting like a tractor beam.", $DisplayTime);
}
function DisarmRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ " - <f0>Effectively removes the target's weapon when they are hit.", $DisplayTime);
}

function Charger::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>This is one of my favourite weapons.\n <f0>Fires 3 different beams - each causing havoc and destruction!", $DisplayTime);
}
function MaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>One of the best sniper rifles in the game.\n <f0>It's beam stikes fear into the enemy!", $DisplayTime);
}

function MMminigun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Welcome to the MECH Annihilator.. <f0>Destruction follows this beast around!", $DisplayTime);
}

function IonCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0>This is the Ion Cann0n :- Electrical Type Damage, Just like Star Wars...\n <f1> w00 h00!", $DisplayTime);
}

function AssaultR::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0> Well this powerful sniper sure packs a punch!!!", $DisplayTime);
}

function MBCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>this is THE deffinative Meltdown weapon.\n <f0>If you dont like it then don't play Meltdown!!\n Try the TAB menu for the weapon options.", $DisplayTime);
}

function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1> The new Hyper-Chaingun for MELTDOWN v W00.. packs more punch than ever before.", $DisplayTime);
}

function GatB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>The GATLER is the new incarnation of the gatling blaster... and it needs no introduction.", $DisplayTime);
}

function Gauss::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>w00 h00! My own Gauss Gun... aren't I lucky???!!!", $DisplayTime);
}
function Gauss2::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>w00 h00! My own Gauss Gun... aren't I lucky???!!!", $DisplayTime);
}

function MiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "Super Fast Hyper-Chaingun with options in the Tab menu.", $DisplayTime);
}

function MMiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>With this baby you will not be lacking in firepower!!!", $DisplayTime);
}

function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f2> The new Super-*nade:- Exclusive to Meltdown v w00... more powerful than ever!", $DisplayTime);
}

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1> Go down the traditional route with this powerful weapon!", $DisplayTime);
}

function ImpactMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>THE IRON FIST :-<f1>This baby packs some serious firepower.. each shot launches a Mini-Nuke", $DisplayTime);
}

function EMPGrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 2.5 seconds\nSpecial Ability: EMP slowly drains your energy. When out of energy, it uses health.", $DisplayTime);
}

function MineLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1> This handy weapon launches a projectile which spawns 9 mines in a box formation.\n<f0> BUT watch out these mines are not team sensitive!", $DisplayTime);
}

function IMPGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>What can I say... the 'BLACK OPS' Cannon is the very essense of firepower!", $DisplayTime);
}

function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1>This Traditional Tribal War Weapon is hyped-up and ready to fire!", $DisplayTime);
}

function TwinFusor::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Similar to the disc launcher but fires 2x the amount of projectiles!", $DisplayTime);
}

function AODStinger::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1>The Missile Launcher...need I say more??\nSpecial Ability: Any enemy NEAR your crosshair is programmed into the missile and it seeks to them.", $DisplayTime);
}

function MRPGLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Kabutsuchi\n<f1> With a name like that what is there to do but try it!!", $DisplayTime);
}

function MechRocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1>Fires 2 missiles at once... and boy do they sting when you are hit!!", $DisplayTime);
}

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n- <f0>Try this baby out for power!!", $DisplayTime);
}

function Rifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0>The 60mm Railgun....w0w!", $DisplayTime);
}

function AAODSniperX::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f1>- The HP Sniper Rifle... deadly for those Heavies... and check out its personal friend the HP Turret!!\n<f0>Special Ability: The heavier the armor plating, the more damage this weapon does.", $DisplayTime);
}

function PlasmaGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f0>The Plasma Sword is simple, easy to use and downright deadly!!!", $DisplayTime);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "\n<f0>Damage per shot: 8\nFire Rate: N/A", $DisplayTime);
}

function EctoPlasm::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "<f0> is the most dangerous weapon in the game... It annihilates EVERYTHING\n<f2> DO NOT USE INDOORS", $DisplayTime);
}
function PBW::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ "<f1> This is and old favourite from MD 2.15... back by popular demand and better than ever!!", $DisplayTime);
}
function Blade::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " -<f1> Oh No! Q's angry and you DON'T want to feel his wrath\n<f0> I suggest you don't use indoors as the blast radius is quite large!", $DisplayTime);
}