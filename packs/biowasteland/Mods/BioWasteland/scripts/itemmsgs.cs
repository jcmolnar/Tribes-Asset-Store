//Additions
function JailGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Jailer's Gun", 2);
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] <1) bottomprint(Player::getClient(%player), "<jc><f2>Using Jailer's Gun: NO JAIL AVAILABLE", 2);
}

function MiniPlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using  Mini Plasma Cannon", 2);
}

//End Additions

function Blaster::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Blaster", 2);
}

function PlasmaGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	bottomprint(%client, "<jc><f2>Using Plasma Gun - Standard", 2);
	if (%client.Plasma == 1)
	{
		bottomprint(%client, "<jc><f2>Using Plasma Gun - Rapid Fire", 2);
	}
	if (%client.Plasma == 2)
	{
		bottomprint(%client, "<jc><f2>Using Plasma Gun - Spread Fire", 2);
	}     
}


function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
}

function LasCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Cannon", 2);
}


function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Twin Fuser", 2);
}

function Fists::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Brass Knuckles", 2);
}

function GrenadeLauncher::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
      Weapon::onUse(%player,%item);
	bottomprint(%client, "<jc><f2>Using Grenade Launcher - Armor's Default Shell", 2);
	if (%client.grenl == "0")
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Standard Shell", 2);
	else if (%client.grenl == 1)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - EMP Shell", 2);
	else if (%client.grenl == 2)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Peace Maker", 2);
	else if (%client.grenl == 3)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Toxin Shell", 2);
	else if (%client.grenl == 4)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Concussion Shell", 2);
	else if (%client.grenl == 5)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Mine Shell", 2);
	else if (%client.grenl == 6)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Plastique Shell", 2);
	else if (%client.grenl == 7)
		bottomprint(%client, "<jc><f2>Using Grenade Launcher - Tracker Shell", 2);
}

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Rifle", 2);
}

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Translocator", 2);
}

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	if (%client.mortar == 1)
		bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	if (%client.mortar == 2)
		bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	if (%client.mortar == 3)
		bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	%armor = Player::getArmor(%player);
	if (%armor == "aarmor" || %armor == "afemale")
		bottomprint(%client, "<jc><f2>Using Stealth's EMP Mortar Launcher", 2);
}

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Targeting Light", 2);
}

function HyperB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Hyper Blaster", 2);
}

function RocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
      bottomprint(%client, "<jc><f2>Using Rocket Launcher - Stinger Mode", 2);
	if (%client.rocket == 1)
	{
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - Locking Mode", 2);
	}
	if (%client.rocket == 2)
	{
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - Grounder Mode", 2);
	}
	if (%client.rocket == 3)
	{
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - WireGuided Mode", 2);
	}
}

function SniperRifle2::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	bottomprint(%client, "<jc><f2>Using Sniper Rifle", 2);
	if ($Wasteland::NoSniping)
	{
		Player::dropItem(%client,%item);
		systemMessage(%client,1,"No sniping on this server");
	}
}

function Equalizer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
}

function BoomStick::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Boom Stick", 2);
}

function TranqGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = Player::getClient(%player);
	bottomprint(%client, "<jc><f2>Using Pneumatic Rifle - Set to Poison-Tipped Dart", 2);
	if (%client.snipe == 1)
	{
	        bottomprint(%client, "<jc><f2>Using Pneumatic Rifle - Set to Hot-Tip Round", 2);
	}
	if (%client.snipe == 2)
	{
	        bottomprint(%client, "<jc><f2>Using Pneumatic Rifle - Set to EMP Round", 2);
	}
}

function Silencer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Magnum", 2);
}

function ConCun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shockwave Cannon", 2);
}

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Railgun", 2);
}

function Vulcan::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Vulcan", 2);
}

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Flame Thrower", 2);
}

function SMML::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shoulder Mounted Missle Launcher. \n<f1>Tap trigger quickly so as to not trigger the missile too!", 4);
}

function Volter::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Volter", 2);
}

function GravGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Grav Gun", 2);
}

function FixIt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer's Repair Gun", 2);
}
function HackIt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer's 2-in-1 Gun", 2);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon", 2);
}

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shotgun", 2);
}

function SortieGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using AirStrike Targeting Laser.", 7);
}
