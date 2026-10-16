//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 500;
   minSpeed = -20;
	lift = 1;
	maxAlt = 500;
	maxVertical = 180;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 3;
	groundDamageScale = 1.0;

	//projectileType = BrawlerShot;
	//reloadDelay = 0.01;
	repairRate = 0.5;
	//fireSound = SoundMayhemAssaultRifle;
	damageSound = SoundFlierCrash;
	ramDamage = 0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundElevatorBlocked2;
	moveSound = SoundElevatorRun2;

	visibleDriver = false;
	driverPose = 22;
	description = "Scout";
};

FlierData MercJet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 500;
   minSpeed = -20;
	lift = 1;
	maxAlt = 500;
	maxVertical = 180;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 3;
	groundDamageScale = 1.0;

	//projectileType = BrawlerShot;
	//reloadDelay = 0.01;
	repairRate = 0.5;
	//fireSound = SoundMayhemAssaultRifle;
	damageSound = SoundFlierCrash;
	ramDamage = 0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "MercJet";
};

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 500;
   minSpeed = -1;
	lift = 1;
	maxAlt = 500;
	maxVertical = 6;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 2;

	groundDamageScale = 0.50;
        
      //projectileType = StingerRocket;//FlierRocket;
	//reloadDelay = 0.03;
	//fireSound = SoundDryFire;
        
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireFlierRocket;
	//reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundMissileTurretOn;
	dismountSound = SoundMissileTurretOn;
	idleSound = SoundStarIdle;
	moveSound = SoundStarFly;

	visibleDriver = false;
	driverPose = 23;
	description = "LPC";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1;
   maxPitch = 1;
   maxSpeed = 300;								   
   minSpeed = -1;
	lift = 1;
	maxAlt = 2;
	maxVertical = 1;
	maxDamage = 6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 3;

	groundDamageScale = 0;
        
      //projectileType = FlierRocket;
	//reloadDelay = 8.0;
	//fireSound = Bigexplosion1;
        
	repairRate = 0;
	ramDamage = 0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 23;
	description = "HPC";
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $LiLRocketDamageType]        = 1.0;
$DamageScale[Scout, $empDamageType]        = 1.0;
$DamageScale[Scout, $LiLPOOmkiiDamageType]        = 1.0;
$DamageScale[Scout, $SmokeDamageType]        = 1.0;
$DamageScale[Scout, $MiniELFDamageType]        = 1.0;
$DamageScale[Scout, $BeamOfPainDamageType]        = 1.0;
$DamageScale[Scout, $FlashDamageType]        = 1.0;
//+++++++++++++++++++++++++++++++++
//Weapon Data
//+++++++++++++++++++++++++++++++++
$numWeaps[Scout] = 3;
$VProj[Scout,0] = "BrawlerShot"; 
$VProj[Scout,1] = "BrawlerRocket"; 
$VProj[Scout,2] = "BrawlerMortar";
$VDelay[Scout,0] = 0.0; 
$VDelay[Scout,1] = 0.2; 
$VDelay[Scout,2] = 0.6;
//+++++++++++++++++++++++++++++++++

$DamageScale[MercJet, $ImpactDamageType] = 1.0;
$DamageScale[MercJet, $BulletDamageType] = 1.0;
$DamageScale[MercJet, $PlasmaDamageType] = 1.0;
$DamageScale[MercJet, $EnergyDamageType] = 1.0;
$DamageScale[MercJet, $ExplosionDamageType] = 1.0;
$DamageScale[MercJet, $ShrapnelDamageType] = 1.0;
$DamageScale[MercJet, $DebrisDamageType] = 1.0;
$DamageScale[MercJet, $MissileDamageType] = 1.0;
$DamageScale[MercJet, $LaserDamageType] = 1.0;
$DamageScale[MercJet, $MortarDamageType] = 1.0;
$DamageScale[MercJet, $BlasterDamageType] = 0.5;
$DamageScale[MercJet, $ElectricityDamageType] = 1.0;
$DamageScale[MercJet, $MineDamageType]        = 1.0;
$DamageScale[MercJet, $LiLRocketDamageType]        = 1.0;
$DamageScale[MercJet, $empDamageType]        = 1.0;
$DamageScale[MercJet, $LiLPOOmkiiDamageType]        = 1.0;
$DamageScale[MercJet, $SmokeDamageType]        = 1.0;
$DamageScale[MercJet, $MiniELFDamageType]        = 1.0;
$DamageScale[MercJet, $BeamOfPainDamageType]        = 1.0;
$DamageScale[MercJet, $FlashDamageType]        = 1.0;
//+++++++++++++++++++++++++++++++++
//Weapon Data
//+++++++++++++++++++++++++++++++++
$numWeaps[MercJet] = 4;
$VProj[MercJet,0] = "MercChaingun"; 
$VProj[MercJet,1] = "MercGrenadeLauncher"; 
$VProj[MercJet,2] = "MercDiscLauncher";
$VProj[MercJet,3] = "MercFlameThrower";
$VDelay[MercJet,0] = 0.0; 
$VDelay[MercJet,1] = 0.3; 
$VDelay[MercJet,2] = 0.1;
$VDelay[MercJet,3] = 0.1;
//+++++++++++++++++++++++++++++++++

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $LiLRocketDamageType]        = 1.0;
$DamageScale[LAPC, $empDamageType]        = 1.0;
$DamageScale[LAPC, $LiLPOOmkiiDamageType]        = 1.0;
$DamageScale[LAPC, $SmokeDamageType]        = 1.0;
$DamageScale[lapc, $MiniELFDamageType]        = 1.0;
$DamageScale[lapc, $BeamOfPainDamageType]        = 1.0;
$DamageScale[lapc, $FlashDamageType]        = 1.0;
//+++++++++++++++++++++++++++++++++
//Weapon Data
//+++++++++++++++++++++++++++++++++
$numWeaps[LAPC] = 4;
$VProj[LAPC,0] = "StarAssault"; 
$VProj[LAPC,1] = "StarFury"; 
$VProj[LAPC,2] = "StarBomb"; 	
$VProj[LAPC,3] = "StarMortar"; 	
$VDelay[LAPC,0] = 0.01; 
$VDelay[LAPC,1] = 0.01;
$VDelay[LAPC,2] = 0.2;	
$VDelay[LAPC,3] = 0.3;		 
//+++++++++++++++++++++++++++++++++

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $LiLRocketDamageType]        = 1.0;
$DamageScale[HAPC, $empDamageType]        = 1.0;
$DamageScale[HAPC, $LiLPOOmkiiDamageType]        = 1.0;
$DamageScale[HAPC, $SmokeDamageType]        = 1.0;
$DamageScale[hapc, $MiniELFDamageType]        = 1.0;
$DamageScale[hapc, $BeamOfPainDamageType]        = 1.0;
$DamageScale[hapc, $FlashDamageType]        = 1.0;
//+++++++++++++++++++++++++++++++++
//Weapon Data
//+++++++++++++++++++++++++++++++++
$numWeaps[HAPC] = 4;
$VProj[HAPC,0] = "HeavyChaingun"; 
$VProj[HAPC,1] = "HeavyGrenade"; 
$VProj[HAPC,2] = "HeavyBazooka"; 	
$VProj[HAPC,3] = "HeavyRocket"; 			
$VDelay[HAPC,0] = 0; 
$VDelay[HAPC,1] = 0.05;
$VDelay[HAPC,2] = 0.07;
$VDelay[HAPC,3] = 0.3; 	
//++++++++++++++++++++++++++++++++++++
//More Fancy Pantcy Code lol..
//++++++++++++++++++++++++++++++++++++
%vOffset[Scout] = "0 0 0";
%vOffset[LAPC] = "0 0 0";
%vOffset[HAPC] = "0 0 0";
//++++++++++++++++++++++++++++++++++++
//Sounds and messages
//++++++++++++++++++++++++++++++++++++
// -- Standard Vehicle weaps
$VDesc[BrawlerShot] = "<F2>Brawler Shot: <f3>Standard Assault Shell.";
$VDesc[BrawlerRocket] = "<F2>Brawler Rocket: <f3>Standard Assault Rocket.";
$VDesc[BrawlerMortar] = "<F2>Brawler Mortar: <f3>Standard Assault Mortar.";

$VDesc[MercChaingun] = "<F2>Merc Chaingun: <f3>Standard Mercenary Chaingun.";
$VDesc[MercGrenadeLauncher] = "<F2>Merc Grenade Launcher: <f3>Standard Mercenary Explosive.";
$VDesc[MercDiscLauncher] = "<F2>Merc Disc Launcher: <f3>Standard Mercenary Energy Disc.";
$VDesc[MercFlameThrower] = "<F2>Merc Flame Thrower: <f3>Standard Mercenary Flame Thrower.";

$VDesc[StarAssault] = "<F2>Star Assault: <f3>Standard Astrial Rounds.";
$VDesc[StarFury] = "<F2>Star Fury: <f3>Standard Astrial Spread Rounds.";
$VDesc[StarBomb] = "<F2>Star Bomb: <f3>Standard Astrial Air Raid Bomb.";
$VDesc[StarMortar] = "<F2>Star Mortar: <f3>Standard Astrial Mortar.";

$VDesc[HeavyChaingun] = "<F2>Heavy Chaingun: <f3>Advanced Chaingun Rounds.";
$VDesc[HeavyGrenade] = "<F2>Heavy Grenade: <f3>Advanced Grenades.";
$VDesc[HeavyBazooka] = "<F2>Heavy Bazooka: <f3>Advanced High Velocity Mortar.";
$VDesc[HeavyRocket] = "<F2>Heavy Rocket: <f3>Advanced Death-Head Rocket.";

$WSound[BrawlerShot] = SoundMayhemAssaultRifle;
$WSound[BrawlerRocket] = SoundFireSeeking;
$WSound[BrawlerMortar] = SoundFireMortar;

$WSound[MercChaingun] = SoundFireChaingun2;
$WSound[MercGrenadeLauncher] = SoundFireGrenade;
$WSound[MercDiscLauncher] = SoundFireDisc;
$WSound[MercFlameThrower] = SoundJetHeavy2;

$WSound[StarAssault] = SoundRemoteTurretFire;
$WSound[StarFury] = bigExplosion4;
$WSound[StarBomb] = SoundFireMortar;
$WSound[StarMortar] = SoundFireGrenade;

$WSound[HeavyChaingun] = bigExplosion3;
$WSound[HeavyGrenade] = bigExplosion2;
$WSound[HeavyBazooka] = bigExplosion1;
$WSound[HeavyRocket] = bigExplosion4;
//----------------------------------------------------------------------------
//===============================
//Vehicle Functions Advanced
//===============================
for(%x=1; %x<31; %x++) 
{
	$myProj[%x] = "";
	$myDelay[%x] = "";
}
function Vehicle::onFire(%this, %slot)
{
	%client = Player::getClient(GameBase::getControlClient(%this));
	%client -= 2048;
	if($myProj[%client] == "")
	{
		$myProj[%client] = "swordHit";
		$myDelay[%client] = 0.5;
	}
	if($canFire[%this] == "") { $canFire[%this] = true; }
	if($canFire[%this])
	{
		//echo("Client: "@%client@" Delay: "@$myDelay[%client]@" Proj: "@$myProj[%client]);
		$canFire[%this] = false;	
		%trans = GameBase::getMuzzleTransform(%this);
		%trans4 = Vector::getFromRot(GameBase::getRotation(%this),5);
		%trans = Transform::Add(%trans,"0 0 0 0 0 0 0 0 0 "@%trans4);
		%trans = Transform::Add(%trans,"0 0 0 0 0 0 0 0 0 0 0 2");
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile($myProj[%client], %trans, %this, %vel);
		
		if($WSound[$myProj[%client]] != "") GameBase::playSound(%this,$WSound[$myProj[%client]],0);
		else GameBase::playSound(%this,getWord($optWeap[$myProj[%client]],7),0);
		
		schedule("$canFire["@%this@"] = true;",$myDelay[%client]);
	}
		
}
function Transform::Add(%trans, %ad)
{// Original Code by TartLoaf; 5/10/02.
	%ntrans = "";
	for(%z=0; %z<12; %z++)
		%t[%z] = getWord(%trans,%z)+getWord(%ad,%z);
		
	for(%q=0; %q<11; %q++)
		%ntrans = %ntrans@%t[%q]@" ";
		
	%ntrans = %ntrans@%t[11];
	return %ntrans;
}



function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}
function Vehicle::onCollision (%this, %object)   // also does mounting functions.
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
		      %vteam = client::getTeam(%this);
		      %pteam = client::getTeam(%client);
				if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
					{
						%cli = getManagerId();
						$arr[%cli] = 0;
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
						regNewWeapons(%client, %cli, GameBase::getDataName(Client::getControlObject(%cl)));
						bottomPrint(%client,"  You are now piloting [ "@GameBase::getDataName(%this).description@" ]\n  <f5>Default Vehicle Weapons:\n  "@buildWeaponList(GameBase::getDataName(%this),%cli));
						
					}
				else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != MercJet) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
			}
	}

}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 370;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 300;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 340;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
				if(Player::getMountedItem(%pl,$weaponslot) == PGun)
					Player::unMountItem(%pl, $weaponslot);
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	
	//if(GameBase::getDamageLevel(%this) >= $smokeDmg[GameBase::getDataName(%this)] && !(%this.onfire))
	//	Plasmafire(%this);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
} 
function getPrevVWeap(%cl)                                                                               
{                 
	%client = getManagerId();      
	if($extraNumWeaps[%client] == "") { $extraNumWeaps[%client] = 0; }
	$numW[%client] = $numWeaps[GameBase::getDataName(Client::getControlObject(%cl))] + $extraNumWeaps[%client];
	regNewWeapons(%cl, %client, GameBase::getDataName(Client::getControlObject(%cl)));                                                                                                         
	%cli = %cl-2048;
	if($arr[%client] == "") { $arr[%client] = 0; }
	
	if($arr[%client] == 0) // condition to cycle prev.
		$arr[%client] = $numW[%client];		                                                                                  

	if($arr[%client] >= $numWeaps[GameBase::getDataName(Client::getControlObject(%cl))]) 		                                                                             
	{// use extra bought weapos                                                              
		$myProj[%cli] = $BVProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                              
		$myDelay[%cli] = $BVDelay[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];
		%proj = $BVProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                 
	}
	else
	{// use normal rotation	                                                                             
        	%proj = $VProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                                                                   
		$myProj[%cli] = $VProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                              
		$myDelay[%cli] = $VDelay[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];
	}       
	$arr[%client]++;           
	if($VDesc[%proj] == "") {  $arr[%client] = 0;  getPrevVWeap(%cl); }                                                                                                      
       	bottomPrint(%cl, "  Weapon: "@$VDesc[%proj]);
}                                                                                                            
function getNextVWeap(%cl)                                                                               
{           
	%client = getManagerId();      
	if($extraNumWeaps[%client] == "") { $extraNumWeaps[%client] = 0; }
	$numW[%client] = $numWeaps[GameBase::getDataName(Client::getControlObject(%cl))] + $extraNumWeaps[%client];
	regNewWeapons(%cl, %client, GameBase::getDataName(Client::getControlObject(%cl)));                                                                                                         

	if($arr[%client] == "") { $arr[%client] = 0; }
	
	if($arr[%client] == $numW[%client]) // condition to cycle next
		$arr[%client] = 0;		                                                                                  
	%cli = %cl-2048;
	if($arr[%client] >= $numWeaps[GameBase::getDataName(Client::getControlObject(%cl))]) 		                                                                             
	{// use extra bought weapos                                                              
		$myProj[%cli] = $BVProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                              
		$myDelay[%cli] = $BVDelay[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];
		%proj = $BVProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                 
	}
	else
	{// use normal rotation	                                                                             
        	%proj = $VProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                                                                   
		$myProj[%cli] = $VProj[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];                                                              
		$myDelay[%cli] = $VDelay[GameBase::getDataName(Client::getControlObject(%cl)),$arr[%client]];
	}       
	$arr[%client]++;   
	if($VDesc[%proj] == "") {  $arr[%client] = 0;  getNextVWeap(%cl); }                                                                                                                    
       	bottomPrint(%cl, "  Weapon: "@$VDesc[%proj]);    
}                             
function regNewWeapons(%cl, %client, %vName)
{
	if(Player::getArmor(%cl) != varmor)
	{
		$extraVehWeaps[%client] = 0;
		$extraNumWeaps[%client] = 0;
		return;
	}
	$extraVehWeaps[%client] = 0;
	// builds usuable weap. list..
	%weaponList = "PowerMortar WootChain Puffy Flamors PlobeGun SymFire FenderBender MiniBombs FragWind PlobeEssence DivineWind";
	%startLength = $numWeaps[%vName];
	for(%b=0; %b < 11; %b++) 
	{// works.
		%cweapon = getWord(%weaponList,%b);
		if(isVUsable(%cl, %cweapon, %vName) == 3)
		{
			$list[%client,%b] = %cweapon;
			$BVProj[%vName,%startLength] = %cweapon;
			$BVDelay[%vName,%startLength] = getWord($OptWeap[%cweapon],1);
			$extraVehWeaps[%client] += 1;
			%startLength++;
		}
	}
	$extraNumWeaps[%client] = $extraVehWeaps[%client]; // number of extras.
	return;
	
}
function isVUsable(%client,%weap, %vName)
{
	if(Player::getItemCount(%client,"x"@%weap) == 1)
	{
		%checkNum = getWord($OptWeap[%weap],0);
		for(%i=2; %i <= %checkNum+1; %i++)
		{
			if(getWord($OptWeap[%weap],%i) == %vName)
				return 3;
		}
	}
	return 2;

}
function buildWeaponList(%vName,%client)
{// this function is a retard...
	%list = "";
	$numW[%client] = $numWeaps[%vName] + $extraNumWeaps[%client];
	for(%i=0; %i <= $numWeaps[%vName]; %i++)
	{
		$myList[%client, %i] = $VProj[%vName,%i];
		%list = %list@$myList[%client, %i]@" ";
		
	}
	//Extra weapons dont work atm.
	return %list;
}
function Plasmafire(%this)
{// thanks to plas.
	return;
	//if(!isObject(%this)) return;
	//%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::Add(getBoxCenter(%this), "0.5 -0.01 -1.25");
	//%vel = Item::getVelocity(%this);
	//if(GameBase::getDamageLevel(%this) >= $smokeDmg[GameBase::getDataName(%this)])
	//{
	//	Projectile::spawnProjectile("mageFlyFlame", %trans, %this, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	//	schedule("PlasmaFire("@%this@");",0.5);
	//}
}
//=======================================================================
