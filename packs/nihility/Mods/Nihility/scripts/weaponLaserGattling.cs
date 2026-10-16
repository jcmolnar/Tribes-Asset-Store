//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Gatling);
$InvList[Gatling] = 1;
$InvList[LaserCell] = 0;


$AutoUse[Gatling] = True;
$WeaponAmmo[Gatling] = "LaserCell";

$ItemMax[larmor, LaserCell] = 0;	//Seraph
$ItemMax[lfemale, LaserCell] = 0;	//Seraph
$ItemMax[earmor, LaserCell] = 0;	//Slave
$ItemMax[efemale, LaserCell] = 0;	//Slave
$ItemMax[marmor, LaserCell] = 0;	//Pawn
$ItemMax[aarmor, LaserCell] = 300;	//Navigator
$ItemMax[darmor, LaserCell] = 0;	//Atomizer
$ItemMax[barmor, LaserCell] = 0;	//Paladin

$ItemMax[larmor, Gatling] = 0;		//Seraph
$ItemMax[lfemale, Gatling] = 0;		//Seraph
$ItemMax[earmor, Gatling] = 0;		//Slave
$ItemMax[efemale, Gatling] = 0;		//Slave
$ItemMax[marmor, Gatling] = 0;		//Pawn
$ItemMax[aarmor, Gatling] = 1;		//Navigator
$ItemMax[darmor, Gatling] = 0;		//Atomizer
$ItemMax[barmor, Gatling] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData LaserCell
{
	description = "Laser Cells";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
	showInventory = false;
};

SoundData SoundLasGat
{	wavFileName = "targetlaser.wav";  
	profile = Profile3dFar;
};



ExplosionData greenExp 
{	shapeName = "paint.dts";
	soundId = ricochet3;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};



RocketData RedShell
{
   bulletShapeName = "shotgunex.dts";
  explosionTag    = blasterExp;//rocketExp;bulletExp1  turretExp
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.04;
   damageType       = $LaserDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.1;
   kickBackStrength = 0.1;
   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 15.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
//   soundId = SoundDiscSpin;
};



RocketData GreenShell
{
   bulletShapeName = "paint.dts";
  explosionTag    = greenExp;//rocketExp;bulletExp1  turretExp
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.08;
   damageType       = $LaserDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.1;
   kickBackStrength = 0.1;
   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 15.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
//   soundId = SoundDiscSpin;
};

RocketData BlueShell
{
   bulletShapeName = "enex.dts";
  explosionTag    = energyExp;//rocketExp;bulletExp1  turretExp
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.12;
   damageType       = $LaserDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.1;
   kickBackStrength = 0.1;
   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 15.0;
   lightColor = { 0.25, 0.25, 0.85 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
//   soundId = SoundDiscSpin;
};

LaserData GatlingLaserBeamRed
{
   laserBitmapName   = "Shotgunbolt.bmp"; //snowplume04   paintpulse
   hitName           = "breath.dts"; //laserhit   paint

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange       = 15.0;
   lightColor         = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData GatlingLaserBeamGreen
{
   laserBitmapName   = "mort0007.bmp"; //snowplume04   paintpulse
   hitName           = "breath.dts"; //laserhit   paint

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange        = 15.0;
   lightColor = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData GatlingLaserBeamBlue
{
   laserBitmapName   = "en10.bmp"; //snowplume04   paintpulse  blue_blink4
   hitName           = "breath.dts"; //laserhit   paint

   damageConversion  = 0.00001;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange       = 15.0;
   lightColor = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
 

ItemImageData GatlingImage 
{
	shapeFile = "breath"; //paintgun
	mountPoint = 0;
	//mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0 , 0, 0 };
	weaponType = 0; // Spinning
//	minEnergy = -20.0;
//	maxEnergy = -19.0;
	ammoType = LaserCell; 
	//projectileType = GatlingLaserBeam;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 1.0, 0.25 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage2 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0 , 0, -0.05 };
	weaponType = 0; // Spinning
	minEnergy = -2.0;
	maxEnergy = -2.0;
	projectileType = GatlingLaserBeamBlue;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage3 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	mountOffset = { 0.035 , 0, 0 };
	weaponType = 0; // Spinning
	minEnergy = -2.0;
	maxEnergy = -2.0;
	projectileType = GatlingLaserBeamGreen;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage4 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, -0.785, 0 };
	mountOffset = { -0.035 , 0, 0 };
	weaponType = 0; // Spinning
	minEnergy = -2.0;
	maxEnergy = -2.0;
	projectileType = GatlingLaserBeamRed;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gatling 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage;
	price = 77;
	showWeaponBar = true;
};

ItemData Gatling2 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage2;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Gatling3 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage3;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Gatling4 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage4;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};


$GatlingSlotA=4;
$GatlingSlotB=7;
$GatlingSlotC=6;



function Gatling::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
	//bottomprint(%client, "<jc><f2>Laser Gatling Gun");

	Player::mountItem(%player,Gatling2,$GatlingSlotA); 
	Player::mountItem(%player,Gatling3,$GatlingSlotB);
	Player::mountItem(%player,Gatling4,$GatlingSlotC);

}

function Gatling::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$GatlingSlotA); 
	Player::unmountItem(%player,$GatlingSlotB); 
	Player::unmountItem(%player,$GatlingSlotC); 
}

//function GatlingImage::onFire(%player, %slot) 
//{
//	LaserGat(%player);
//}

function GatlingImage::onFire(%player, %slot) 
{
	%playerId = Player::getClient(%player);
	//%energy = GameBase::getEnergy(%player);
 	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	if (!%playerId.Gatling || %playerId.Gatling == 0)
	{
		if(Player::getItemCount(%player,LaserCell) > 0)
		{
			Player::trigger(%player, 6, true);
			Red(%player); 
			//Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			Player::decItemCount(%player,LaserCell,1);
		}
		else
		{
			bottomprint(%client, "<jc><f2>energy cells depleted :: recharging :: please wait");
			//Client::sendMessage(Player::getClient(%player),0,"energy cells depleted");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Gatling == 1)
	{
		if(Player::getItemCount(%player,LaserCell) > 1)
		{
			Player::trigger(%player, 7, true);
			Green(%player);
			//Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			Player::decItemCount(%player,LaserCell,2);
		}
		else
		{
			bottomprint(%client, "<jc><f2>energy cells depleted :: recharging :: please wait");
			//Client::sendMessage(Player::getClient(%player),0,"energy cells depleted");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}	
	else if (%playerId.Gatling == 2)
	{
		if(Player::getItemCount(%player,LaserCell) > 2)
		{
			Player::trigger(%player, 4, true);
			Blue(%player); 
			//Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			Player::decItemCount(%player,LaserCell,3);
		}
		else
		{
			bottomprint(%client, "<jc><f2>energy cells depleted :: recharging :: please wait");
			//Client::sendMessage(Player::getClient(%player),0,"energy cells depleted");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}	
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);
		Player::trigger(%player, 7, false);
	if($Recharging[%player] != True)
	{
		$Recharging[%player] = True;
		%guntype = Gatling;
		schedule("Recharge(" @ %player @ ", " @ %guntype @ ");",1,%player);
	}
}

function Recharge(%player,%gunType)
{
	%armor = Player::GetArmor(%player);
	if(%gunType == Gatling && (Player::getItemCount(%player,Gatling) > 0))
	{
		if(Player::getItemCount(%player,LaserCell) < $ItemMax[%armor,LaserCell])
		{
			Player::incItemCount(%player,LaserCell,5);
			schedule("Recharge(" @ %player @ ", " @ %gunType @ ");",1,%player);
		}
		else
			$Recharging[%player] = False;
	}
}

function Gatling::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.Gatling || %client.Gatling == 0)
	{
	        bottomprint(%client, "<jc><f2>Laser Gatling Gun<f1> RED :: 33% Power", 2);
	}
	if (%client.Gatling == 1)
	{
	        bottomprint(%client, "<jc><f2>Laser Gatling Gun<f1> GREEN :: 66% Power", 2);
	}
	if (%client.Gatling == 2)
	{
	        bottomprint(%client, "<jc><f2>Laser Gatling Gun<f1> BLUE :: 100% Power", 2);
	}   
}



//function Gatling::onUse(%player,%item)
//{
//Weapon::onUse(%player,%item);
//bottomprint(Player::getClient(%player), "<jc><f2>Laser Gatling Gun", 2);
//}





function Red(%player)
{ 
	if(GameBase::getLOSInfo(%player,1000)) 
	{
		%object = getObjectType($los::object); 
		%xopos = getWord($los::position,0) ; 
		%yopos = getWord($los::position,1) ; 
		%zopos = getWord($los::position,2) ; 
		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
	}
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 

	%trans1= getWord(%trans,0); 
	%trans2= getWord(%trans,1); 
	%trans3= getWord(%trans,2); 
	%trans4= getWord(%trans,3) ; 
	%trans5= getWord(%trans,4) ; 
	%trans6= getWord(%trans,5) ; 
	%trans7= getWord(%trans,6); 
	%trans8= getWord(%trans,7); 
	%trans9= getWord(%trans,8); 
	%trans10=getWord(%trans,9); 
	%trans11=getWord(%trans,10); 
	%trans12=getWord(%trans,11); 
	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
	//%NewTrans = %trans1 @" "@ %pos; 

	Projectile::spawnProjectile("RedShell", %NewTrans, %player, 0); 
	Projectile::spawnProjectile(%newObj); 
	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
	//schedule("reload(" @ %player @ ");",0.001); 
	//} 
}

function Green(%player)
{ 
	if(GameBase::getLOSInfo(%player,600)) 
	{
		%object = getObjectType($los::object); 
		%xopos = getWord($los::position,0) ; 
		%yopos = getWord($los::position,1) ; 
		%zopos = getWord($los::position,2) ; 
		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
	}
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 

	%trans1= getWord(%trans,0); 
	%trans2= getWord(%trans,1); 
	%trans3= getWord(%trans,2); 
	%trans4= getWord(%trans,3) ; 
	%trans5= getWord(%trans,4) ; 
	%trans6= getWord(%trans,5) ; 
	%trans7= getWord(%trans,6); 
	%trans8= getWord(%trans,7); 
	%trans9= getWord(%trans,8); 
	%trans10=getWord(%trans,9); 
	%trans11=getWord(%trans,10); 
	%trans12=getWord(%trans,11); 
	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
	//%NewTrans = %trans1 @" "@ %pos; 

	Projectile::spawnProjectile("GreenShell", %NewTrans, %player, 0); 
	Projectile::spawnProjectile(%newObj); 
	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
	//schedule("reload(" @ %player @ ");",0.001); 
	//} 
}

function Blue(%player)
{ 
	if(GameBase::getLOSInfo(%player,300)) 
	{
		%object = getObjectType($los::object); 
		%xopos = getWord($los::position,0) ; 
		%yopos = getWord($los::position,1) ; 
		%zopos = getWord($los::position,2) ; 
		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
	}
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 

	%trans1= getWord(%trans,0); 
	%trans2= getWord(%trans,1); 
	%trans3= getWord(%trans,2); 
	%trans4= getWord(%trans,3) ; 
	%trans5= getWord(%trans,4) ; 
	%trans6= getWord(%trans,5) ; 
	%trans7= getWord(%trans,6); 
	%trans8= getWord(%trans,7); 
	%trans9= getWord(%trans,8); 
	%trans10=getWord(%trans,9); 
	%trans11=getWord(%trans,10); 
	%trans12=getWord(%trans,11); 
	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
	//%NewTrans = %trans1 @" "@ %pos; 

	Projectile::spawnProjectile("BlueShell", %NewTrans, %player, 0); 
	Projectile::spawnProjectile(%newObj); 
	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
	//schedule("reload(" @ %player @ ");",0.001); 
	//} 
}






