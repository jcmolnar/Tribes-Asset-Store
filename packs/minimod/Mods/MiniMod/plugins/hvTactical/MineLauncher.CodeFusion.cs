// This is a MiniMod Plugin.
// This plugin is the Mine Launcher from the hvTactical mod.
// Ported by PeterT.

MiniMod::MonitorFile(start, "MineLauncher.CodeFusion.cs", "Mine Launcher Plugin");
MiniMod::Turbo::Class(MineLauncher, 5);
MiniMod::Turbo::Class(MineLauncher, 24);
MiniMod::WeaponCycle(Blaster, MineLauncher, PlasmaGun);

GrenadeData MineShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MineDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function MineShell::onAdd(%this)
{
	schedule("DeployNukes(" @ %this @ " , 5);",1.0,%this);//5++++++
}

function DeployNukes(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Nuke1");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10.0,false);//0++++	
//		%obj = newObject("","Mine","Nuke2");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-15.0,false);
		%obj = newObject("","Mine","Nuke3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20.0,false);
		%count -= 1;
		schedule("DeployNukes(" @ %this @ " , " @ %count @ ");",1.0,%this);//0.5++++++++
	}
}

$AutoUse[MineLauncher] = True;
$SellAmmo[MinelAmmo] = 5;
$WeaponAmmo[MineLauncher] = MinelAmmo;

ItemData MinelAmmo
{
	description = "Mine Launcher Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MinelAmmo;
	projectileType = MineShell; 
	accuFire = false;
	reloadTime = 1.4;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MineLauncher
{
	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 175;
	showWeaponBar = true;
};

$InvList[MineLauncher] = 1;
$InvList[MinelAmmo] = 1;
$RemoteInvList[MineLauncher] = 1;
$RemoteInvList[MinelAmmo] = 1;

MineData Nuke1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke1::onAdd(%this)
{
	%this.damage = 0;
	Nuke1::deployCheck(%this);
}

function Nuke1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke1::deployCheck(" @ %this @ ");", 3, %this);
}
//------------------
MineData Nuke2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke2::onAdd(%this)
{
	%this.damage = 0;
	Nuke2::deployCheck(%this);
}

function Nuke2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke2::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke2::deployCheck(" @ %this @ ");", 3, %this);
}
//----------------------
MineData Nuke3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke3::onAdd(%this)
{
	%this.damage = 0;
	Nuke3::deployCheck(%this);
}

function Nuke3::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke3::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke3::deployCheck(" @ %this @ ");", 3, %this);
}

MiniMod::MonitorFile(stop, "MineLauncher.CodeFusion.cs", "Mine Launcher Plugin");
