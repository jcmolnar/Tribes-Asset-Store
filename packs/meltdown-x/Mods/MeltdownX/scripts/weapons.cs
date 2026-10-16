# NEW Meltdown version 2.16, open source.
# Redid most of scripts and got rid of 
# unneeded crap in other ppl's stuff.
#========================================

function kickback(%object, %kickback) // Kickback
{
	%rot = GameBase::getRotation(%object); 
	%kick = Vector::getFromRot(%rot,%kickback,0);
	Player::applyImpulse(%object,%kick);
}

function useEnergy(%object, %energyUse) // Energy Usage
{
	%energy = GameBase::getEnergy(%object); 
 	%energy -= %energyUse;
	GameBase::setEnergy(%object,%energy);
}

function sin(%theta) // Sine & Cosine functions... useful for 3D Manipulation
{ 
	%sin = (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
	return %sin;
}

function cos(%theta) 
{
	%cos = (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
	return %cos;
}

function newVector(%vec, %scalar) // ?  (One of Valya's functions)
{	
	%nVec  = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %nVec;
}

function GetLOSOffset(%player,%offset)
{	
	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);

	%X1=Getword(%vector,1);
	%Y1=Getword(%vector,2);
	%Z1=Getword(%vector,3);
	
	%X2=Getword(%vector,6);
	%Y2=Getword(%vector,7);
	%Z2=Getword(%vector,8);
	
	%zo1=SIN(%YRot) * %offset;
	%zo2=COS(%XRot) * %offset;
	%l2=COS(%YRot) * %offset;

	%p1=Vector::getFromRot(%rot,%l2,%zo);
	%NewPos=Vector::Add(%Pos,%p1);
	return(%NewPos);
}

function fireWeapon(%object,%projectile,%target,%num,%energyUse,%heatIncrease,%sound,%ammoType,%ammoDecrease,%kickback) // heatIncrease for Eradicator use only!! 
{
	%trans = GameBase::getMuzzleTransform(%object); // Location, Transform, Object Protocols
	%vel = Item::getVelocity(%object); 
	%pos = GameBase::getPosition(%object);
	%client = Player::getClient(%object);

	if(%ammoType != false) 
	{
		if(Player::getItemCount(%object,%ammoType)) // Ammo checking script
		{
			Player::decItemCount(%object,%ammoType,%ammoDecrease);
		}
		else
		{
			Player::trigger(%object,$WeaponSlot,false);
			return false;
		}
	}

	kickback(%object,%kickback); 
	useEnergy(%object,%energyUse);

	if(%object.outArea) // OB check
		GameBase::applyDamage(%object,$DebrisDamageType,10,%pos,"0 0 0","0 0 0",%object);

	if($Eradicator::Authentic) // Using heatIncrease is only for use in Eradicator
		Player::incItemCount(%object,HeatValue,%heatIncrease);

	if(%sound != false) // Plays a sound, if there is one
		playSound(%sound, %pos);

	// Passed Validation.... FIRE!!
	if(%num > 1) // Multiple Weapons fire support
	{
		for(%p; %p < %num + 1; %p++) // Streamlined multiple weapons fire.. hehe
			Projectile::spawnProjectile(%projectile, %trans, %object, %vel, %target);
		
		return true;	
	}
	else if(%num = 1)
	{
		Projectile::spawnProjectile(%projectile, %trans, %object, %vel, %target);
		return true;
	}
	else
	{
		return false; // heh, just in case :)
	}
}

function Meltdown::getFOVInfo(%this,%pos) // derived from my original invention in Meltdown.
{
	%team = GameBase::getTeam(%this);
	%set1 = newObject("set1",SimSet);
	%set2 = newObject("set2",SimSet);
	%VehicleFOV = containerBoxFillSet(%set1,$VehicleObjectType,%pos,$MLRadarSize,$MLRadarSize,$MLRadarSize,0); // Would often move out of range
	%PlayerFOV = containerBoxFillSet(%set2,$SimPlayerObjectType,%pos,$MLRadarSize,$MLRadarSize,$MLRadarSize,0); // Would often move out of range

	if (%VehicleFOV > 0)
	{	
		for (%i=0; %i<%VehicleFOV; %i++)
		{	
			%tgt = Group::getObject(%set1,%i);
			%tgtTeam = GameBase::getTeam(%tgt);

			if(%team != %tgtTeam) 
				%target = %tgt;

			if(%target)
			{	
				%i = %VehicleFOV;
				%VTarg = "true";
			}
			
		}

	}
	if(%VTarg)
	{
		deleteObject(%set1);
		return(%target);
	}

	else if (%PlayerFOV > 0)
	{	
		for (%i=0; %i<%PlayerFOV; %i++)
		{	
                  %tgt = Group::getObject(%set2,%i);
			%tgtTeam = GameBase::getTeam(%tgt);

			if(%team != %tgtTeam) 
				%target = %tgt;

			if(%target)
			{
				%i = %PlayerFOV;
				%PTarg = "true";
			}
		}
	}
	if(%PTarg)
	{
		deleteObject(%set2);
		return(%target);
	}
}

$NWeapons=0;

//	Add Weapon Function.. Designed to Allow the AAODX Weapon Kits to Dump Weapons into this file
//	and basically just insert themselves into the next weapon Prev Weapon Stack

function AddWeapon(%WeaponName)
{	// Create a New Weapon Index
	$Weap[$NWeapons]=%WeaponName;
	%PrevWeapon=$NWeapons-1;
	if(%PrevWeapon<0) %PrevWeapon=0;
	$NextWeapon[$Weap[%PrevWeapon]]=%WeaponName;	// Set the Prev Weapon to The New Weapon
	$NextWeapon[%Weapon]=$Weap[0];					// Set the Next Weapon to the First Weapon
	$PrevWeapon[$Weap[0]]=%WeaponName;
	$PrevWeapon[%WeaponName]=$Weap[%PrevWeapon];
	$NWeapons++;
}

function CheckTargetJamming(%target)
{	// Is Target A Player If not Return a 0
	// If target Wearing a jamming Pack & is it turned on If No Return a 0 If Yes return a 1
	// Does Target have stealth ability if lvl1 then return 1 if lvl 2 return 2 else return 0
	%jamming=0;
	%type=getObjectType(%target);
	if(%type!="PLAYER")
		return(0);

	%pack=Player::getMountedItem(%target,$BackpackSlot);
	// if($trace) echo($ver,"| Target Has Pack =",%pack);
	if (%pack=="SensorJammerPack")
	{	if($trace) echo($ver,"| Target Has Jammer Pack =",%pack);
		if (Player::isTriggered(%target,$BackpackSlot) )
			%jamming=1;
	}
	if (%pack=="CloakingDevice")
	{	if($trace) echo($ver,"| Target Has Cloaking Pack =",%pack);
			%jamming=2;
	}

	return (%jamming);
}

function AquireTarget(%this,%option,%pos)
{	// Options are	0 - Line of Sight Scan
	//				1 - Local Area Scan
	//				2 - Infiltrator Jammed Scan
	//				3 - AAPC Scan

	if($trace) echo($ver,"| Aquiring Target for player ",%this," type of scan ",%option," Position ",%pos);
	%team = GameBase::getTeam(%this);
	%target=0;
	
	%set = newObject("set",SimSet);
	
	if(%option==1)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,512,512,512,0); // Would often move out of range
	}
	else if(%option==2)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,512,512,512,0);
	}
	else if(%option==3)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,512,512,-512,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,512,512,512,0);
	
	// echo(" Number of Objects = ",%tnum);


	if (%tnum>0)
	{	// There are Targets within scan range
		if($traceAll) echo($Ver,"| AODATPack Scan Has Located ",%tnum," Targets.. in a ",%option," Scan");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(%option==2)
			{	echo("Jammed Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team==%tgtTeam)	
					%target=%tgt;
			}
			else
			{	echo("Normal Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team!=%tgtTeam) 
					%target=%tgt;
			}
				
			if(%target)
			{	// if($trace) echo($ver,"| Target Aquisition of ",%target," Target Locked");
				%i=%tnum;
			}
		}
	}
	deleteObject(%set);
	return (%target);
}

//--------------------------------------------------------------------------------------------------------
// Blaster
//--------------------------------------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.8;
	fireTime = 0.35;
	minEnergy = 6;
	maxEnergy = 9;

	projectileType = EMPIRIALFlightRockets;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bEnergy Weapons";
	description = "EMPIRIALTrident 40mm";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

AddWeapon(Blaster);

//--------------------------------------------------------------------------------------------------------
// Omega Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData OmegaRifleImage
{
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = OmegaBolt;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.4;
	FireTime = 0.35;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFirePistol;
};

ItemData OmegaRifle
{
   description = "OmegaRifle";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "fBeam Weapons";
   shadowDetailMask = 4;
   imageType = OmegaRifleImage;
	showWeaponBar = true;
   price = 500;

};

$InvList[OmegaRifle] = 1;
$RemoteInvList[OmegaRifle] = 1;

$ItemMax[larmor, OmegaRifle] = 0;
$ItemMax[lfemale, OmegaRifle] = 0;
$ItemMax[marmor, OmegaRifle] = 1;
$ItemMax[mfemale, OmegaRifle] = 1;
$ItemMax[harmor, OmegaRifle] = 1;
$ItemMax[BlastechM, OmegaRifle] = 0;
$ItemMax[BlastechF, OmegaRifle] = 0;
$ItemMax[MagIonM, OmegaRifle] = 1;
$ItemMax[MagIonF, OmegaRifle] = 1;
$ItemMax[MECH, OmegaRifle] = 1;

AddWeapon(OmegaRifle);

//--------------------------------------------------------------------------------------------------------
// Maser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData MaserI
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperMaser;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 0.4;
	minEnergy = 60;
	maxEnergy = 90;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MaserRifle
{
	description = "Maser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = MaserI;
	price = 1250;
	showWeaponBar = true;
};

$InvList[MaserRifle] = 1;
$RemoteInvList[MaserRifle] = 1;

$ItemMax[larmor, MaserRifle] = 0;
$ItemMax[lfemale, MaserRifle] = 0;
$ItemMax[marmor, MaserRifle] = 1;
$ItemMax[mfemale, MaserRifle] = 1;
$ItemMax[harmor, MaserRifle] = 1;
$ItemMax[BlastechM, MaserRifle] = 0;
$ItemMax[BlastechF, MaserRifle] = 0;
$ItemMax[MagIonM, MaserRifle] = 1;
$ItemMax[MagIonF, MaserRifle] = 1;
$ItemMax[MECH, MaserRifle] = 1;

AddWeapon(MaserRifle);

//=========================================================================//=========================================================================

ItemData MitziCore
{
	description = "MBC Power Charge";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MBImage 
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = MitziCore; 
	accuFire = true;
	reloadTime = 0.45;
	fireTime = 0.45;
	
	sfxFire = CapturedTower;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
};

function MBImage::onFire(%player,%slot)
{
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	if (%playerId.Cannon == 0)
	{
		if(Player::getItemCount(%player,MitziCore) > 9)
		{
			Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,10);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 10 to fire Standard Mitzi Blast-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == 1)
	{
		if(Player::getItemCount(%player,MitziCore) > 14)
		{
			Projectile::spawnProjectile("IonShock4",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,15);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 15 to fire Mitzi EMP Blast-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "2")
	{
		if(Player::getItemCount(%player,MitziCore) > 24)
		{
			Projectile::spawnProjectile("IonShock5",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,25);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 25 to fire Mitzi Boost-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "3")
	{
		if(Player::getItemCount(%player,MitziCore) > 74)
		{
			Projectile::spawnProjectile("IonShock6",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,75);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 75 to fire Mitzi Area Poisoning Blast-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "4")
	{
		if(Player::getItemCount(%player,MitziCore) > 49)
		{
			Projectile::spawnProjectile("IonShock7",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,50);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 50 to fire Mitzi Internal Flaming Blast-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
	else if (%playerId.Cannon == "5")
	{
		if(Player::getItemCount(%player,MitziCore) > 242)
		{
			Projectile::spawnProjectile("IonShock8",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,243);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 243 to fire Mitzi Annihilator-Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}

	if(!%player.recharge || %player.recharge != true)
	{
		%player.recharge = true;
		MBImage::onCharge(%player);
	}
}

function MBImage::onCharge(%player)
{
	%armor = Player::getArmor(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);

	if(Player::getItemCount(%player,MBCannon) > 0)
	{
		if(Player::getItemCount(%player,MitziCore) < $ItemMax[%armor, MitziCore])
		{
			Player::incItemCount(%player,MitziCore,1);

			if(%pack == MitziCharger)
				schedule("MBImage::onCharge("@%player@");",0.25,%player);
			else
				schedule("MBImage::onCharge("@%player@");",0.5,%player);
		}
		else
			%player.recharge = true;
 	}
}

ItemData MBCannon
{
	description = "MBCannon Model:RJ11";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "blaster";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MBImage;
	price = 2000;
	showWeaponBar = true;
};

AddWeapon(mbcannon);

$InvList[MBCannon] = 1;
$RemoteInvList[MBCannon] = 1;

$ItemMax[larmor, MBCannon] = 1;
$ItemMax[lfemale, MBCannon] = 1;
$ItemMax[marmor, MBCannon] = 1;
$ItemMax[mfemale, MBCannon] = 1;
$ItemMax[harmor, MBCannon] = 1;
$ItemMax[BlastechM, MBCannon] = 1;
$ItemMax[BlastechF, MBCannon] = 1;
$ItemMax[MagIonM, MBCannon] = 1;
$ItemMax[MagIonF, MBCannon] = 1;
$ItemMax[MECH, MBCannon] = 1;

$WeaponAmmo[MBCannon]			= MitziCore;
$SellAmmo[MitziCore]			= 487;

$InvList[MitziCore] = 1;
$RemoteInvList[MitziCore] = 1;

$ItemMax[harmor, MitziCore] = 487;
$ItemMax[marmor, MitziCore] = 487;
$ItemMax[mfemale, MitziCore] = 487;
$ItemMax[larmor, MitziCore] = 487;
$ItemMax[lfemale, MitziCore] = 487;
$ItemMax[BlastechM, MitziCore] = 487;
$ItemMax[BlastechF, MitziCore] = 487;
$ItemMax[MagIonM, MitziCore] = 487;
$ItemMax[MagIonF, MitziCore] = 487;
$ItemMax[MECH, MitziCore] = 487;

//------------------------------------------------------------------------------

ItemImageData ExtraEnergyImageA 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountRotation = { 0, 1.57, 0 }; 
	mountOffset = { 0.1, 0, 0.05 };
	minEnergy = 11;
	maxEnergy = 13;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = EMPIRIALMaserObeam;
	sfxFire = SoundDryFire;
}; 

ItemData ExtraEnergyA 
{ 
	description = "LightningXBeam";
	 className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "disk"; 
	heading = "fBeam Weapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageA; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageB 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 }; 
	mountOffset = { 0.0, 0, 0 };
	minEnergy = 11;
	maxEnergy = 13;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = EMPIRIALMaserObeam;
	sfxFire = SoundDryFire;
}; 

ItemData ExtraEnergyB 
{ 
	description = "LightningXBeam";
	 className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "disk"; 
	heading = "fBeam Weapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageB; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageC
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
	mountRotation = { 0, -1.57, 0 }; 
	mountOffset = { -0.1, 0, 0.05 };
	minEnergy = 11;
	maxEnergy = 13;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = EMPIRIALMaserObeam;
	sfxFire = SoundDryFire;
}; 

ItemData ExtraEnergyC 
{ 
	description = "LightningXBeam";
	 className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "disk"; 
	heading = "fBeam Weapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageC; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData EnergyGunImage 
{ 
	shapeFile = "DiscAmmo"; 
	mountPoint = 0.25; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData EnergyGun
{ 
	description = "LightningXBeam"; 
	className = "Weapon"; 
	shapeFile = "DiscAmmo"; 
	hudIcon = "blaster"; 
     heading = "fBeam Weapons"; 
	shadowDetailMask = 4; 
	imageType = EnergyGunImage; 
	price = 3500; 
	showWeaponBar = true; 
}; 

function EnergyGunImage::onFire(%player, %slot) // actually made by MEGA-Man... forgot his name in the credits! oops!
{  
	%state1 = Player::getItemState(%player,5);  
	%state2 = Player::getItemState(%player,6);  
	%state3 = Player::getItemState(%player,7);  

	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload" && %state3 != "Fire" & %state3 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		if(%client.energy == 0) 
		{    
			%client.energy = 1;    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		} 
		else if(%client.energy == 1) 
		{    
			%client.energy = 2;    
			Player::trigger(%player,7,true);    
			Player::trigger(%player,7,false);   
		} 
		else 
		{    
			%client.energy = 0;    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function EnergyGun::onMount(%player,%imageSlot) 
{  
	Player::mountItem(%player,ExtraEnergyA,6);  
	Player::mountItem(%player,ExtraEnergyB,7); 
	Player::mountItem(%player,ExtraEnergyC,5); 
} 

function EnergyGun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,5);  
	Player::unmountItem(%player,6);  
	Player::unmountItem(%player,7); 
}

$InvList[EnergyGun] = 1;
$RemoteInvList[EnergyGun] = 1;

$ItemMax[larmor, EnergyGun] = 1;
$ItemMax[lfemale, EnergyGun] = 1;
$ItemMax[marmor, EnergyGun] = 1;
$ItemMax[mfemale, EnergyGun] = 1;
$ItemMax[harmor, EnergyGun] = 1;
$ItemMax[BlastechM, EnergyGun] = 1;
$ItemMax[BlastechF, EnergyGun] = 1;
$ItemMax[MagIonM, EnergyGun] = 1;
$ItemMax[MagIonF, EnergyGun] = 1;
$ItemMax[MECH, EnergyGun] = 1;

AddWeapon(EnergyGun);

//--------------------------------------------------------------------------------------------------------
// Chain Gun
//--------------------------------------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 1;
	fireTime = 0.1;

	ammoType = BulletAmmo;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

function ChaingunImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.chaingun == 0)
			{
				Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
			}
			else if (%playerId.chaingun == 1)	// lol
			{
				Projectile::spawnProjectile("EMPIRIALRound",%trans,%player,%vel);
				Projectile::spawnProjectile("EMPIRIALRound",%trans,%player,%vel);
				Projectile::spawnProjectile("EMPIRIALRound",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Chaingun],5);
			}
	}
}

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

AddWeapon(ChainGun);

//--------------------------------------------------------------------------------------------------------
// Gatling Blaster
//--------------------------------------------------------------------------------------------------------

ItemImageData GatlingBlasterImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0;  // Spinning
	reloadTime = 0.10;
	fireTime = 0.10;
	minEnergy = 11;
	maxEnergy = 13;
	projectileType = EMPIRIALMaserMbeam;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundDryFire;
};

ItemData GatB
{
	description = "LightBeam AutoBlaster";
	className = "Weapon";
	shapeFile = "chaingun";

	hudIcon = "chaingun";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = GatlingBlasterImage;
	price = 500;
	showWeaponBar = true;
};


AddWeapon(gatb);

$InvList[GatB] = 1;
$RemoteInvList[GatB] = 1;

$ItemMax[larmor, GatB] = 0;
$ItemMax[lfemale, GatB] = 0;
$ItemMax[marmor, GatB] = 1;
$ItemMax[mfemale, GatB] = 1;
$ItemMax[harmor, GatB] = 1;
$ItemMax[BlastechM, GatB] = 0;
$ItemMax[BlastechF, GatB] = 0;
$ItemMax[MagIonM, GatB] = 1;
$ItemMax[MagIonF, GatB] = 1;
$ItemMax[MECH, GatB] = 1;

//--------------------------------------------------------------------------------------------------------
// Gauss Cannon
//--------------------------------------------------------------------------------------------------------

ItemData GaussAmmo
{
	description = "Explosive Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData GaussGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.35;

	ammoType = GaussAmmo;
	projectileType = ShrapnelWad;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Gauss
{
	description = "ShrapnelGatling80mm";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = GaussGunImage;
	price = 650;
	showWeaponBar = true;
};

AddWeapon(Gauss);

$SellAmmo[GaussAmmo]			= 200;

$AmmoPackMax[GaussAmmo] = 200;
$AmmoPackItems[10] = GaussAmmo;

$InvList[Gauss] = 1;
$RemoteInvList[Gauss] = 1;

$InvList[GaussAmmo] = 1;

$RemoteInvList[GaussAmmo] = 1;

$ItemMax[larmor, Gauss] = 0;
$ItemMax[lfemale, Gauss] = 0;
$ItemMax[marmor, Gauss] = 1;
$ItemMax[mfemale, Gauss] = 1;
$ItemMax[harmor, Gauss] = 1;
$ItemMax[BlastechM, Gauss] = 1;
$ItemMax[BlastechF, Gauss] = 1;
$ItemMax[MagIonM, Gauss] = 1;
$ItemMax[MagIonF, Gauss] = 1;
$ItemMax[MECH, Gauss] = 1;

$ItemMax[larmor, GaussAmmo] = 0;
$ItemMax[lfemale, GaussAmmo] = 0;
$ItemMax[marmor, GaussAmmo] = 200;
$ItemMax[mfemale, GaussAmmo] = 200;
$ItemMax[harmor, GaussAmmo] = 200;
$ItemMax[BlastechM, GaussAmmo] = 200;
$ItemMax[BlastechF, GaussAmmo] = 200;
$ItemMax[MagIonM, GaussAmmo] = 200;
$ItemMax[MagIonF, GaussAmmo] = 200;
$ItemMax[MECH, GaussAmmo] = 200;

//---------------------------------------------------------- 
BulletData MiniGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.095;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 799.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 90;
};

//--------------------------------------
RocketData Raygun_ray
{
   bulletShapeName = "tracer.dts";
   explosionTag    = rocketExp;


  collisionRadius = 0.0;

  explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 768.0;
   terminalVelocity = 768.0;
   acceleration     = 0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;

   soundId = SoundJetHeavy;
};

//--------------------------------------------------------------------------------------------------------
// Grenade Launcher
//--------------------------------------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.15;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function GrenadeLauncherImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.grenade == 0)
			{
				Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
			}
			else if (%playerId.grenade == 1)
			{
				Projectile::spawnProjectile("ImpactGrenadeShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
			}
	}
}

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

AddWeapon(GrenadeLauncher);

//--------------------------------------------------------------------------------------------------------
// Mortar 
//--------------------------------------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function MortarImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.mortar == 0)
			{
				Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if (%playerId.mortar == 1)
			{
				Projectile::spawnProjectile("BettyShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if (%playerId.mortar == 2)
			{
				Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
	}
}

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 300;
	showWeaponBar = true;
};
AddWeapon(Mortar);

//--------------------------------------------------------------------------------------------------------
// Impact-Explosive Mortar 
//--------------------------------------------------------------------------------------------------------

$AutoUse[ImpactMortar]			= True;

AddWeapon(ImpactMortar);

$WeaponAmmo[ImpactMortar]			= ImpactAmmo;
$SellAmmo[ImpactAmmo]			= 30;
$AmmoPackMax[ImpactAmmo]		= 30;

$AmmoPackItems[15] = ImpactAmmo;

$InvList[ImpactMortar] = 1;
$RemoteInvList[ImpactMortar] = 1;

$InvList[ImpactAmmo] = 1;
$RemoteInvList[ImpactAmmo] = 1;

$ItemMax[harmor, ImpactMortar] = 1;
$ItemMax[harmor, ImpactAmmo] = 30;
$ItemMax[larmor, ImpactMortar] = 0;
$ItemMax[larmor, ImpactAmmo] = 0;
$ItemMax[marmor, ImpactMortar] = 0;
$ItemMax[marmor, ImpactAmmo] = 0;
$ItemMax[lfemale, ImpactMortar] = 0;
$ItemMax[lfemale, ImpactAmmo] = 0;
$ItemMax[mfemale, ImpactMortar] = 0;
$ItemMax[mfemale, ImpactAmmo] = 0;
$ItemMax[BlastechM, ImpactMortar] = 0;
$ItemMax[BlastechF, ImpactMortar] = 0;
$ItemMax[MagIonM, ImpactMortar] = 0;
$ItemMax[MagIonF, ImpactMortar] = 0;
$ItemMax[MECH, ImpactMortar] = 1;
$ItemMax[BlastechM, ImpactAmmo] = 0;
$ItemMax[BlastechF, ImpactAmmo] = 0;
$ItemMax[MagIonM, ImpactAmmo] = 0;
$ItemMax[MagIonF, ImpactAmmo] = 0;
$ItemMax[MECH, ImpactAmmo] = 30;

ItemData ImpactAmmo
{
	description = "IE Mortar Ammo";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData IMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ImpactAmmo;
	projectileType = ImpactMortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ImpactMortar
{
	description = "Impact Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = IMortarImage;
	price = 350;
	showWeaponBar = true;
};

//--------------------------------------------------------------------------------------------------------
// Mine Launcher
//--------------------------------------------------------------------------------------------------------

ItemData MultiMineAmmo
{
	description = "Spawning Mines";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MineLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = Deploybox;
	accuFire = true;
	ammoType = MultiMineAmmo;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

ItemData MineLauncher
{
	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 1200;
	showWeaponBar = true;
};

AddWeapon(minelauncher);

$AutoUse[MineLauncher]			= True;

$WeaponAmmo[MineLauncher]			= MultiMineAmmo;
$SellAmmo[MultiMineAmmo]			= 5;
$AmmoPackMax[MultiMineAmmo]		= 5;

$AmmoPackItems[17] = MultiMineAmmo;

$InvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MultiMineAmmo] = 1;
$RemoteInvList[MultiMineAmmo] = 1;

$ItemMax[harmor, MineLauncher] = 1;
$ItemMax[harmor, MultiMineAmmo] = 5;
$ItemMax[larmor, MineLauncher] = 0;
$ItemMax[larmor, MultiMineAmmo] = 0;
$ItemMax[marmor, MineLauncher] = 1;
$ItemMax[marmor, MultiMineAmmo] = 3;
$ItemMax[lfemale, MineLauncher] = 0;
$ItemMax[lfemale, MultiMineAmmo] = 0;
$ItemMax[mfemale, MineLauncher] = 1;
$ItemMax[mfemale, MultiMineAmmo] = 5;
$ItemMax[BlastechM, MineLauncher] = 1;
$ItemMax[BlastechF, MineLauncher] = 1;
$ItemMax[MagIonM, MineLauncher] = 1;
$ItemMax[MagIonF, MineLauncher] = 1;
$ItemMax[MECH, MineLauncher] = 1;
$ItemMax[BlastechM, MultiMineAmmo] = 5;
$ItemMax[BlastechF, MultiMineAmmo] = 5;
$ItemMax[MagIonM, MultiMineAmmo] = 5;
$ItemMax[MagIonF, MultiMineAmmo] = 5;
$ItemMax[MECH, MultiMineAmmo] = 2;


//--------------------------------------------------------------------------------------------------------
// Baby-Nuke Launcher
//--------------------------------------------------------------------------------------------------------

ItemImageData BaybNookImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	ammoType = MortarAmmo;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData BabyNukeMortar
{
	description = "FireBomb";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = BayBNookImage;
	price = 32000;
	showWeaponBar = true;
};

$WeaponAmmo[BabyNukeMortar] = BabyNukeMortar;

function BayBNookImage::onFire(%player, %slot) 
{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[BabyNukeMortar]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[BabyNukeMortar],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

			Projectile::spawnProjectile("ClusterBomb",%trans,%player,%vel);
}
	else
		Client::sendMessage(Player::getClient(%player), 1,"Oops. screwed ya!");

}

$AutoUse[BabyNukeMortar]			= True;

AddWeapon(babynukemortar);

$InvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$ItemMax[harmor, BabyNukeMortar] = 1;
$ItemMax[larmor, BabyNukeMortar] = 0;
$ItemMax[lfemale, BabyNukeMortar] = 0;
$ItemMax[marmor, BabyNukeMortar] = 0;
$ItemMax[mfemale, BabyNukeMortar] = 0;
$ItemMax[BlastechM, BabyNukeMortar] = 1;
$ItemMax[BlastechF, BabyNukeMortar] = 1;
$ItemMax[MagIonM, BabyNukeMortar] = 0;
$ItemMax[MagIonF, BabyNukeMortar] = 0;
$ItemMax[MECH, BabyNukeMortar] = 1;

//--------------------------------------------------------------------------------------------------------
// Disc Launcher
//--------------------------------------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.45;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

function DiscLauncherImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[DiscLauncher]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($DiskerUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,1);
					Client::sendMessage(%client,0,"~wmine_act.wav");
				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"~wmine_act.wav");
						}
					}
					else
					{	
						Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier" || %object == "Turret")
				{	
					Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					%name = Client::getName(%targetId);

					SendLockWarning(%targetId,0);
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
				Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

AddWeapon(DiscLauncher);

$DDLSlot = 4;

ItemData TwinFusorAmmo
{
	description = "TwinFusors";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData DDLI2 
{
	 shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.03, 0, 0 };
	 ammoType = TwinFusorAmmo; 
	weaponType = 3; 
	accuFire = true; 

	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;
	projectileType = DiscShell; 
}; 

ItemData DualDisc2 
{ 
	description = "TwinFusor";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = DDLI2; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData DDLI1 
{ 
	shapeFile = "Disc"; 
	mountPoint = 0; 
	weaponType = 3; 
	mountRotation = { 0,-1.57, 0 }; 
	mountOffset = { 0.1, 0, 0 };
	ammoType = TwinFusorAmmo; 
	accuFire = true; 
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDiscReload; 
	sfxReady = SoundDiscSpin; 
}; 

ItemData TwinFusor
{ 
	description = "TwinFusor"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
   heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = DDLI1; 
	price = 3750; 
	showWeaponBar = true; 
}; 

function TwinFusor::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, DualDisc2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function TwinFusor::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,DualDisc2,$DDLSlot); 
} 

function TwinFusor::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$DDLSlot);
} 

function DDLI1::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TwinFusorAmmo,0.5); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,%player); 
	if(!$DualDisc2Activate[%client]) DD2CheckActivate(%client, %player); 
} 

function DD2CheckActivate(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TwinFusor")) 
	{ 
		Player::trigger(%player,$DDLSlot,true);
		schedule("DD2CheckActivate(" @ %client @ "," @ %player @ ");",0.05); 
		$DualDisc2Activate[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$DDLSlot,false); 
		$DualDisc2Activate[%client] = false; 
	} 
} 

AddWeapon(TwinFusor);

$WeaponAmmo[TwinFusor]			= TwinFusorAmmo;
$SellAmmo[TwinFusorAmmo]			= 50;

$InvList[TwinFusor] = 1;
$RemoteInvList[TwinFusor] = 1;
$InvList[TwinFusorAmmo] = 1;
$RemoteInvList[TwinFusorAmmo] = 1;
$UplinkInvList[TwinFusor] = 1;
$UplinkInvList[TwinFusorAmmo] = 1;

$ItemMax[harmor, TwinFusor] = 1;
$ItemMax[marmor, TwinFusor] = 1;
$ItemMax[mfemale, TwinFusor] = 1;
$ItemMax[larmor, TwinFusor] = 1;
$ItemMax[lfemale, TwinFusor] = 1;
$ItemMax[BlastechM, TwinFusor] = 0;
$ItemMax[BlastechF, TwinFusor] = 0;
$ItemMax[MagIonM, TwinFusor] = 1;
$ItemMax[MagIonF, TwinFusor] = 1;
$ItemMax[MECH, TwinFusor] = 1;

$ItemMax[harmor, TwinFusorAmmo] = 30;
$ItemMax[marmor, TwinFusorAmmo] = 50;
$ItemMax[mfemale, TwinFusorAmmo] = 50;
$ItemMax[larmor, TwinFusorAmmo] = 50;
$ItemMax[lfemale, TwinFusorAmmo] = 50;
$ItemMax[BlastechM, TwinFusorAmmo] = 0;
$ItemMax[BlastechF, TwinFusorAmmo] = 0;
$ItemMax[MagIonM, TwinFusorAmmo] = 50;
$ItemMax[MagIonF, TwinFusorAmmo] = 50;
$ItemMax[MECH, TwinFusorAmmo] = 30;

#-----------------------------------------------------------------#
# Missile Launcher Script by Valya[AAOD], Z_Dog and INH*DynaBlade # // I can't believe it's not butter..
#-----------------------------------------------------------------#

# Who did what to make this extrodinary script possible
# INH*DynaBlade: 
# Rewrote most of the scripts and tweaked the missiles
#
# Valya[AAOD]:
# The original designer of the Missile Launcher
#
# Z-Dog:
# Implemented new Graphics Design for Missile Launcher

$RRocketgunSlotA = 4;
AddWeapon(aodstinger);
$InvList[AODStinger]			= 1;	
$RemoteInvList[AODStinger]		= 1;
$AutoUse[AODStinger]			= True;
$WeaponAmmo[AODStinger]			= MissileAmmo;
$InvList[MissileAmmo]			= 1;
$RemoteInvList[MissileAmmo]		= 1;
$SellAmmo[MissileAmmo]			= 5;

$ItemMax[larmor,AODStinger]		= 1;
$ItemMax[lfemale,AODStinger]		= 1;
$ItemMax[marmor,AODStinger]		= 1;
$ItemMax[mfemale,AODStinger]		= 1;
$ItemMax[harmor,AODStinger]		= 1;
$ItemMax[MagIonM, AODStinger] 	= 1;
$ItemMax[MagIonF, AODStinger] 	= 1;
$ItemMax[MECH, AODStinger] 		= 1;
$ItemMax[BlastechF, AODStinger] 	= 1;
$ItemMax[BlastechM, AODStinger] 	= 1;

$ItemMax[larmor,MissileAmmo]		= 7;
$ItemMax[lfemale,MissileAmmo]		= 7;
$ItemMax[marmor,MissileAmmo]		= 14;
$ItemMax[mfemale,MissileAmmo]		= 14;
$ItemMax[harmor,MissileAmmo]		= 20;
$ItemMax[MagIonM, MissileAmmo] 	= 14;
$ItemMax[MagIonF, MissileAmmo] 	= 14;
$ItemMax[MECH, MissileAmmo] 		= 15;
$ItemMax[BlastechF, MissileAmmo] 	= 7;
$ItemMax[BlastechM, MissileAmmo] 	= 7;

RocketData AAODRocket
{	
	bulletShapeName  = "rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 1;
	damageValue      = 0.5;
	damageType       = $MissileDamageType;
	explosionRadius  = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity   = 75.0;
	terminalVelocity = 80.0;
	acceleration     = 5.0;
	totalTime        = 6.0;
	liveTime         = 7.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType   = 2;                
	trailString = "rsmoke.dts";
	smokeDist   = 20;
	soundId = SoundJetHeavy;
};

ItemData MissileAmmo
{	description = "Std Missile Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "zAmmo";
	shadowDetailMask = 4;
	price = 50;
};

//***************************************************
// Item Image Definitions
//***************************************************

ItemImageData AODStingerImage
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 }; 
	mountRotation = { 0, -1.575, 0};    
	weaponType		= 0; 	
	reloadTime		= 1.5;	
	fireTime		= 0.1;	
	minEnergy		= 5;	
	maxEnergy		= 6;	
	ammoType		= MissileAmmo;
	accuFire		= true;	
	sfxFire			= SoundPickUpBackpack;
	sfxActivate		= SoundPickUpWeapon;
	sfxReload		= SoundMissileReload;
	sfxReady		= SoundMissileIdle;
};

ItemData AODStinger
{	   
	heading = "eLaunchers";
	description		= "Missile Launcher";
	classname		= "Weapon";
	shapeFile		= "GrenadeL";
	hudIcon			= "mortar";
	shadowDetailMask = 4;
	imageType		= AODStingerImage;
	price			= 350;
	showWeaponBar	= true;
};

function AODStingerImage::onFire(%player,%slot) 
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AODStinger]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack = Player::getMountedItem(%player,$BackpackSlot);

		if(%pack == "TargPack") 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						Client::sendMessage(%client,0,"~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));

					}
				}
				else
				{	
					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					Client::sendMessage(%client,0,"~wmine_act.wav");
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
					}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
							if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
							Client::sendMessage(%client,0,"~wmine_act.wav");
							playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						}
					}
					else
					{	
						Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						Client::sendMessage(%client,0,"~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier" || %object == "Turret")
				{	
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
				if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

function AODStinger::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, AODStinger2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function AODStinger::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,AODStinger2,$RRocketgunSlotA); 

} 

function AODStinger::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$RRocketgunSlotA);

} 

ItemImageData AODStinger2Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
};	

ItemData AODStinger2 
{ 
	description = "Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = AODStinger2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function mdCheckAODStinger(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "AODStinger")) 
	{ 
		schedule("mdCheckAODStinger(" @ %client @ "," @ %player @ ");",0.01); 
		$mdFiringAODStinger[%client] = true; 
	} 
	else 
	{ 
		$mdFiringAODStinger[%client] = false; 
	} 
} 

//*****************************
// End of Missile Launcher Def
//*****************************

//--------------------------------------------------------------------------------------------------------
// Rocket Propelled Grenade (RPG)
//--------------------------------------------------------------------------------------------------------

ItemImageData RPGImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	accuFire = true;
	reloadTime = 0.35;
	fireTime = 1.00;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function RPGImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPGLauncher]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if ($RPGUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);

		if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,1);
					Client::sendMessage(%client,0,"~wmine_act.wav");
				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"~wmine_act.wav");
						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier" || %object == "Turret")
				{	
					Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,$los::object);
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					%name = Client::getName(%targetId);
					SendLockWarning(%targetId,0);
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPGLauncher
{
	description = "RPG";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPGImage;
	price = 400;
	showWeaponBar = true;
};

$AutoUse[RPGLauncher]			= true;

AddWeapon(rpglauncher);

$InvList[RPGLauncher] = 1;
$RemoteInvList[RPGLauncher] = 1;

$ItemMax[larmor, RPGLauncher] = 1;
$ItemMax[lfemale, RPGLauncher] = 1;
$ItemMax[marmor, RPGLauncher] = 1;
$ItemMax[mfemale, RPGLauncher] = 1;
$ItemMax[harmor, RPGLauncher] = 0;
$ItemMax[BlastechF, RPGLauncher] = 1;
$ItemMax[BlastechM, RPGLauncher] = 1;
$ItemMax[MagIonM, RPGLauncher] = 1;
$ItemMax[MagIonF, RPGLauncher] = 1;
$ItemMax[MECH, RPGLauncher] = 0;

$MrpgSlotA=4;
$MrpgSlotB=5;
$MrpgSlotC=6; 

$AutoUse[MrpgLauncher] = True; 
$SellAmmo[MrpgAmmo] = 150; 
$AmmoPackMax[MrpgAmmo] = 150; 
$AmmoPackItems[15] = MrpgAmmo; 
$WeaponAmmo[MrpgLuancher] = MrpgAmmo; 

$InvList[MrpgLauncher]=1;	
$InvList[MrpgAmmo]=1;
$RemoteInvList[MrpgAmmo]=1;

$ItemMax[lfemale,MrpgLauncher]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgLauncher]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgLauncher]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgLauncher]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgLauncher]=1;	// The maximum Heavy of either sex can carry
$ItemMax[MECH, MrpgLauncher]=1;

$ItemMax[lfemale,MrpgAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgAmmo]=100;	// The maximum Heavy of either sex can carry
$ItemMax[MECH, MrpgAmmo]=150;

ItemData MrpgAmmo 
{ 
	description = "RPGs"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo";
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MrpgLauncherImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 3.5; 
	fireTime = 0.2;
	minEnergy	= 5;	
	maxEnergy	= 6;
	ammoType = MrpgAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickupminigun; 
	sfxReload = SoundSpinUp; 
	sfxReady = SoundMiniDown; 
}; 

function MrpgLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Mrpgammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPG",%trans,%player,%vel,%player); 
	if(!$MDFiringMrpgLauncher[%client]) MDCheckMrpgLauncher(%client, %player); 
} 

addweapon(mrpgLauncher);

ItemData MrpgLauncher 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "chain"; 
	heading = "eLaunchers"; 
	shadowDetailMask = 4; 
	imageType = MrpgLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
}; 

function MrpgLauncher::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MrpgLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MrpgLauncher::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MrpgLauncher2,$MrpgSlotA); 
	Player::mountItem(%player,MrpgLauncher3,$MrpgSlotB); 
	Player::mountItem(%player,MrpgLauncher4,$MrpgSlotC); 
} 

function MrpgLauncher::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MrpgSlotA);
	Player::unmountItem(%player,$MrpgSlotB);	 
	Player::unmountItem(%player,$MrpgSlotC);
} 

ItemImageData MrpgLauncher2Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0; 
	reloadTime = 2.8; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData MrpgLauncher2 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MrpgLauncher3Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.8; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData MrpgLauncher3 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData MrpgLauncher4Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 0.8; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
}; 

ItemData MrpgLauncher4 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMrpgLauncher(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MrpgLauncher")) 
	{ 
		Player::trigger(%player,$MrpgSlotA,true);
		Player::trigger(%player,$MrpgSlotB,true);
		Player::trigger(%player,$MrpgSlotC,true); 
		schedule("MDCheckMrpgLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMrpgLauncher[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MrpgSlotA,false); 
		Player::trigger(%player,$MrpgSlotB,false); 
		Player::trigger(%player,$MrpgSlotC,false); 
		$MDFiringMrpgLauncher[%client] = false; 
	} 
} 
//--------------------------------------------------------------------------------------------------------
// Rocket Propelled Mortar (RPM)
//--------------------------------------------------------------------------------------------------------

ItemImageData RPMImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	accuFire = true;
	reloadTime = 0.45;
	fireTime = 0.45;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RPMImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPMLauncher]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($RPMUseMTPack)
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,1);
					Client::sendMessage(%client,0,"~wmine_act.wav");
				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"~wmine_act.wav");
						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier")
				{	
					Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					%name = Client::getName(%targetId);
					SendLockWarning(%targetId,0);
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
				Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPMLauncher
{
	description = "RPM";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPMImage; 
	price = 800;
	showWeaponBar = true;
};

$AutoUse[RPMLauncher]			= True;

AddWeapon(rpmlauncher);

$InvList[RPMLauncher] = 1;
$RemoteInvList[RPMLauncher] = 1;

$ItemMax[larmor, RPMLauncher] = 1;
$ItemMax[lfemale, RPMLauncher] = 1;
$ItemMax[marmor, RPMLauncher] = 0;
$ItemMax[mfemale, RPMLauncher] = 0;
$ItemMax[harmor, RPMLauncher] = 1;
$ItemMax[BlastechF, RPMLauncher] = 0;
$ItemMax[BlastechM, RPMLauncher] = 0;
$ItemMax[MagIonM, RPMLauncher] = 1;
$ItemMax[MagIonF, RPMLauncher] = 1;
$ItemMax[MECH, RPMLauncher] = 1;

//=============================================================================================\\

$MRocketgunSlotA=4;
$MRocketgunSlotB=5;
$MRocketgunSlotC=6; 

addweapon(MECHRocketLauncher);
$InvList[MECHRocketLauncher]			= 1;	
$RemoteInvList[MECHRocketLauncher]		= 1;
$AutoUse[MECHRocketLauncher]			= True;

$WeaponAmmo[MECHRocketLauncher]                  = MissileAmmo;
$AmmoPackMax[MissileAmmo] 		= 30; 
$AmmoPackItems[21] = MissileAmmo; 

$ItemMax[larmor,MECHRocketLauncher]		= 0;
$ItemMax[lfemale,MECHRocketLauncher]		= 0;
$ItemMax[marmor,MECHRocketLauncher]		= 0;
$ItemMax[mfemale,MECHRocketLauncher]		= 0;
$ItemMax[harmor,MECHRocketLauncher]		= 1;
$ItemMax[BlastechF, MECHRocketLauncher] = 0;
$ItemMax[BlastechM, MECHRocketLauncher] = 0;
$ItemMax[MagIonM, MECHRocketLauncher] = 0;
$ItemMax[MagIonF, MECHRocketLauncher] = 0;
$ItemMax[MECH, MECHRocketLauncher] = 1;

ItemImageData MECHRocketLauncherImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.345, 0.08, 0.004 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 0.5; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickupminigun; 
	sfxReload = SoundSpinUp; 
	sfxReady = SoundMiniDown; 
}; 

//-----------------
//  Begin MECHRocketLauncher Fire Function
//-----------------


function MECHRocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MECHRocketLauncher],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,%player); 
	if(!$MDFiringMECHRocketLauncher[%client]) MDCheckMECHRocketLauncher(%client, %player); 
} 

ItemData MECHRocketLauncher 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.345, 0.08, 0.004 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "mortar"; 
	heading = "eLaunchers"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
}; 

function MECHRocketLauncher::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MECHRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MECHRocketLauncher::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MECHRocketLauncher2,$MRocketgunSlotA); 
	Player::mountItem(%player,MECHRocketLauncher3,$MRocketgunSlotB); 
	Player::mountItem(%player,MECHRocketLauncher4,$MRocketgunSlotC); 
} 

function MECHRocketLauncher::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MRocketgunSlotA);
	Player::unmountItem(%player,$MRocketgunSlotB);	 
	Player::unmountItem(%player,$MRocketgunSlotC);
} 


ItemImageData MECHRocketLauncher2Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.45, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 0.1; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 30;
};	

ItemData MECHRocketLauncher2 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MECHRocketLauncher3Image 
{ 

shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 20;
}; 

ItemData MECHRocketLauncher3 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MECHRocketLauncher4Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 }; 
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	projectileType = AAODRocket; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 30;
}; 

ItemData MECHRocketLauncher4 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMECHRocketLauncher(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MECHRocketLauncher")) 
	{ 
		Player::trigger(%player,$MRocketgunSlotC,true);
		schedule("MDCheckMECHRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMECHRocketLauncher[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MRocketgunSlotC,false); 
		$MDFiringMECHRocketLauncher[%client] = false; 
	} 
} 

//--------------------------------------------------------------------------------------------------------
// Laser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserPistolImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = EMPIRIALPulsebeams;
	accuFire = true;
	reloadTime = 0.35;
	fireTime = 0.35;
	minEnergy = 40;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserPistol
{
	description = "Laser Pistol";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LaserPistolImage;
	price = 100;
	showWeaponBar = true;
};

AddWeapon(LaserPistol);

$InvList[LaserPistol] = 1;
$RemoteInvList[LaserPistol] = 1;

$ItemMax[larmor, LaserPistol] = 0;
$ItemMax[marmor, LaserPistol] = 1;
$ItemMax[lfemale, LaserPistol] = 0;
$ItemMax[mfemale, LaserPistol] = 1;
$ItemMax[harmor, LaserPistol] = 1;
$ItemMax[BlastechF, LaserPistol] = 0;
$ItemMax[BlastechM, LaserPistol] = 0;
$ItemMax[MagIonM, LaserPistol] = 1;
$ItemMax[MagIonF, LaserPistol] = 1;
$ItemMax[MECH, LaserPistol] = 1;

//--------------------------------------------------------------------------------------------------------
// Laser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = EMPIRIALPulsebeams;
	accuFire = true;
	reloadTime = 0.35;
	fireTime = 0.35;
	minEnergy = 50;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "HP Dazer Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

AddWeapon(LaserRifle);

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Reactor)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have Mini Reactor to use HP Dazer Rifle."); 
}

//--------------------------------------------------------------------------------------------------------
// Particle Beam Weapon
//--------------------------------------------------------------------------------------------------------

$AutoUse[PBW]			= True;

AddWeapon(PBW);

$InvList[PBW] = 1;
$RemoteInvList[PBW] = 1;

$ItemMax[harmor, PBW] = 1;
$ItemMax[marmor, PBW] = 1;
$ItemMax[mfemale, PBW] = 1;
$ItemMax[larmor, PBW] = 0;
$ItemMax[lfemale, PBW] = 0;
$ItemMax[BlastechF, PBW] = 0;
$ItemMax[BlastechM, PBW] = 0;
$ItemMax[MagIonM, PBW] = 1;
$ItemMax[MagIonF, PBW] = 1;
$ItemMax[MECH, PBW] = 1;

ItemImageData PBWImage 
{
	shapeFile = "grenammo";
	mountPoint = 0;

	weaponType = 0; 
	minEnergy = 50;
	maxEnergy = 80;
      projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 0.35;
	fireTime = 0.35;
	
	sfxFire = SoundPBWBreakSoundBarrier; 
	sfxActivate = SoundDryFire;
	sfxReload = SoundPBWRecharge;
};

ItemData PBW
{
	description = "Particle Beam (PBW)";
	className = "Weapon";
	shapeFile = "grenammo";
	hudIcon = "blaster";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = PBWImage;
	price = 2500;
	showWeaponBar = true;
};

function PBW::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Accelerator)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have Particle Accelerator to use PBW."); 
}

//======================================================================================

$WeaponAmmo[LasCannon] = "Beacon";

$AutoUse[LasCannon]			= True;

AddWeapon(LasCannon);

$InvList[LasCannon] = 1;
$RemoteInvList[LasCannon] = 1;

$ItemMax[harmor, LasCannon] = 1;
$ItemMax[marmor, LasCannon] = 0;
$ItemMax[mfemale, LasCannon] = 0;
$ItemMax[larmor, LasCannon] = 0;
$ItemMax[lfemale, LasCannon] = 0;
$ItemMax[BlastechF, LasCannon] = 0;
$ItemMax[BlastechM, LasCannon] = 0;
$ItemMax[MagIonM, LasCannon] = 0;
$ItemMax[MagIonF, LasCannon] = 0;
$ItemMax[MECH, LasCannon] = 1;

ItemImageData LasCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	mass = 2.5;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "Death Ray";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 5000;
	mass = 2.5;
	showWeaponBar = true;

};


function LasCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	
	if (%clientId.lascharge)
	{
		%clientId.charging = "";
		%lc = %clientId.lascharge;
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.15);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.4);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.45);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.3);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);		

		}
		
		if (%lc == 15)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(LasCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.375);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);
		}

		%clientId.lascharge = "0";
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** Death Ray uses Beacons to charge...~waccess_denied.wav");
		return;
	}
}


function LasCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, LasCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	
	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
		BottomPrint (%clientId, "** " @ %time @ " before full charge ", 1);
		%clientId.lascharge++;
		return;
	}

	else
	{
		BottomPrint (%clientId, "** Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Death Ray may overload... ETA: 15 seconds"  , 5);
		%clientId.lascharge = 15;
		LasCannoner::Detonate(%clientId, 15);
		return;
	}
}

function LasCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	
	if (%clientId.lascharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else 
	{
		%clientId.charging = "";
		%clientId.lascharge = "0";
		Player::blowUp(%clientId);
			
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
		return;
	}
	if (%time > 0 && %time < 10)
	{
		bottomprint (%clientId, "<jc>** ETA to overload: " @ %time @ " seconds", 1);	
	}
}

LaserData GatlingLaser
{
	laserBitmapName   = "lightningNew.bmp";
	hitName           = "shield.dts";
	damageConversion  = 0.10;
	baseDamageType    = $LaserDamageType;
	beamTime          = 2.5;
	lightRange        = 5.0;
	lightColor        = { 0.01, 0.01, 1.25 };
	detachFromShooter = true;
	hitSoundId        = SoundLaserHit;
};

//========================================================================
RocketData LasCannonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.9; 
	damageType = $LaserDamageType;
	explosionRadius = 6; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 


	terminalVelocity = 3000.0;
	acceleration = 800; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 8.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 2.0; 
	soundId = SoundJetHeavy;
};

RocketData LasCannonBolt2
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.5; 
	damageType = $LaserDamageType;
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 3000.0;
	acceleration = 500; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 1.0; 
	soundId = SoundJetHeavy;
};

RocketData LasCannonShock
{
	bulletShapeName  = "shield.dts";
	explosionTag     = ShockwaveFour;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 1.0;
	damageType       = $LaserDamageType;
	explosionRadius  = 5.0;
	kickBackStrength = 0;
	muzzleVelocity   = 250.0;
	terminalVelocity = 4000.0;

	acceleration     = 500.0;
	totalTime        = 14.0;
	liveTime         = 14.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.1, 1.5 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "shield.dts";
	smokeDist   = 20.0;
	soundId = SoundJetHeavy;
};
//=======================================

//--------------------------------------------------------------------------------------------------------
// 80mm Railgun
//--------------------------------------------------------------------------------------------------------

ItemData RailAmmo 
{
  description = "Railgun Bolt";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData RailgunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = RailAmmo;
  projectileType = RailRound;
  accuFire = true;
  reloadTime = 0.15;
  fireTime = 0.15;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
  description = "80MM Sabbot";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "gRifles";
  shadowDetailMask = 4;
  imageType = RailgunImage;
  price = 1500;
  showWeaponBar = true;
};
    
$SellAmmo[RailAmmo]			= 200;
$AmmoPackMax[RailAmmo]		= 200;

AddWeapon(Railgun);

$InvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$InvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$ItemMax[larmor, Railgun] = 0;
$ItemMax[lfemale, Railgun] = 0;
$ItemMax[marmor, Railgun] = 1;
$ItemMax[mfemale, Railgun] = 1;
$ItemMax[harmor, Railgun] = 0;
$ItemMax[BlastechF, Railgun] = 1;
$ItemMax[BlastechM, Railgun] = 1;
$ItemMax[MagIonM, Railgun] = 1;
$ItemMax[MagIonF, Railgun] = 1;
$ItemMax[MECH, Railgun] = 0;

$ItemMax[larmor, RailAmmo] = 0;
$ItemMax[lfemale, RailAmmo] = 0;
$ItemMax[marmor, RailAmmo] = 200;
$ItemMax[mfemale, RailAmmo] = 200;
$ItemMax[harmor, RailAmmo] = 0;
$ItemMax[BlastechF, RailAmmo] = 200;
$ItemMax[BlastechM, RailAmmo] = 200;
$ItemMax[MagIonM, RailAmmo] = 200;
$ItemMax[MagIonF, RailAmmo] = 200;
$ItemMax[MECH, RailAmmo] = 0;

//--------------------------------------------------------------------------------------------------------
// 60MM Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData RailGun2Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0}; 
	
	weaponType = 0; // Single Shot
	ammoType = Shells;
	projectileType = EMPIRIALMaserHbeam;
	accuFire = true;
	minEnergy = 50;
      maxEnergy = 60;
	reloadTime = 0.25;
	fireTime = 0.45;

      lightType = 3;  // Weapon Fire
      lightRadius = 2;
      lightTime = 1;
      lightColor = { 0.6, 0, 0 };

      sfxActivate = SoundPickUpWeapon;
      sfxFire     = SoundFirePistol;
};

ItemData RailGun2
{
	description = "EMPIRIALMASER LS";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = RailGun2Image;
	price = 200;
	showWeaponBar = true;
	showInventory = false;	
};

function RifleImage::onFire(%player,%imageSlot)
{
	Player::trigger(%player,$ExtraWeaponSlot,true);
	Player::trigger(%player,$ExtraWeaponSlot,false);
}

ItemImageData scopeImage
{
	shapeFile = "discAmmo";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.01 };
	weaponType = 2; // Single Shot
	projectileType = RailLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;

	sfxActivate = SoundPickUpWeapon;
};

ItemData scope
{
	description = "EMPIRIALMASER LS";
	className = "Weapon";
	shapeFile = "discAmmo";
	hudIcon = "targetlaser";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = ScopeImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

function Rifle::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,scope,$ExtraSlot);	
	Player::mountItem(%player,RailGun2,$ExtraWeaponSlot);	
	Player::trigger(%player,$ExtraSlot,true);
}

function Rifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$ExtraSlot);
	Player::unmountItem(%player,$ExtraWeaponSlot);
	Player::trigger(%player,$ExtraSlot,false);
}

ItemImageData RifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = EMPIRIALMaserHbeam;
	accuFire = true;
	minEnergy = 50;
      maxEnergy = 60;
	reloadTime = 0.25;
	fireTime = 0.45;
      lightType = 3;
      lightRadius = 6;
      lightTime = 2;
      lightColor = { 0.6, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
      sfxFire     = SoundFirePistol;
};

ItemData Rifle
{
	description = "EMPIRIALMASER HP-LS";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = RifleImage;
	price = 600;
	showWeaponBar = true;
};

$SellAmmo[Shells]			= 50;

$AmmoPackMax[Shells] = 50;
$AmmoPackItems[23] = Shells;

AddWeapon(rifle);

$InvList[Shells] = 1;
$RemoteInvList[Shells] = 1;

$InvList[Rifle] = 1;
$RemoteInvList[Rifle] = 1;

$ItemMax[larmor, Rifle] = 1;
$ItemMax[lfemale, Rifle] = 1;
$ItemMax[marmor, Rifle] = 1;
$ItemMax[mfemale, Rifle] = 1;
$ItemMax[harmor, Rifle] = 1;
$ItemMax[BlastechF, Rifle] = 1;
$ItemMax[BlastechM, Rifle] = 1;
$ItemMax[MagIonM, Rifle] = 1;
$ItemMax[MagIonF, Rifle] = 1;
$ItemMax[MECH, Rifle] = 1;

$ItemMax[larmor, Shells] = 30;
$ItemMax[lfemale, Shells] = 30;
$ItemMax[marmor, Shells] = 40;
$ItemMax[mfemale, Shells] = 40;
$ItemMax[harmor, Shells] = 40;
$ItemMax[BlastechF, Shells] = 40;
$ItemMax[BlastechM, Shells] = 40;
$ItemMax[MagIonM, Shells] = 40;
$ItemMax[MagIonF, Shells] = 40;
$ItemMax[MECH, Shells] = 40;

function Rifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Reactor)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have Mini Reactor to use EMPIRIALMASER HP-LS."); 
}

//--------------------------------------------------------------------------------------------------------
// Mass Driver 40MM Rifle
//--------------------------------------------------------------------------------------------------------

ItemData Bolts
{
	description = "Mass Driver Bolts";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MassDriverImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SXAmmo;
	projectileType = sniperXBullet;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.15;
      lightType = 3;
      lightRadius = 6;
      lightTime = 2;
      lightColor = { 1.0, 0, 0 };
      sfxFire = SoundMissileTurretFire;
      sfxActivate = SoundPickUpWeapon;
};

ItemData MassDriver
{
	description = "40MM Shrapnel Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "blaster";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MassDriverImage;
	price = 1200;
	showWeaponBar = true;
};

$SellAmmo[SXAmmo]			= 300;
$AmmoPackMax[SXAmmo] = 300;
$AmmoPackItems[25] = SXAmmo;

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;

AddWeapon(massdriver);

$InvList[SXAmmo] = 1;
$RemoteInvList[SXAmmo] = 1;

$ItemMax[larmor, MassDriver] = 1;
$ItemMax[lfemale, MassDriver] = 1;
$ItemMax[marmor, MassDriver] = 1;
$ItemMax[mfemale, MassDriver] = 1;
$ItemMax[harmor, MassDriver] = 0;
$ItemMax[BlastechF, MassDriver] = 1;
$ItemMax[BlastechM, MassDriver] = 1;
$ItemMax[MagIonM, MassDriver] = 1;
$ItemMax[MagIonF, MassDriver] = 1;
$ItemMax[MECH, MassDriver] = 0;

$ItemMax[larmor, SXAmmo] = 300;
$ItemMax[lfemale, SXAmmo] = 300;
$ItemMax[marmor, SXAmmo] = 300;
$ItemMax[mfemale, SXAmmo] = 300;
$ItemMax[harmor, SXAmmo] = 0;
$ItemMax[BlastechF, SXAmmo] = 300;
$ItemMax[BlastechM, SXAmmo] = 300;
$ItemMax[MagIonM, SXAmmo] = 300;
$ItemMax[MagIonF, SXAmmo] = 300;
$ItemMax[MECH, SXAmmo] = 0;

//--------------------------------------------------------------------------------------------------------
// 20mm Sniper Rifle
//--------------------------------------------------------------------------------------------------------

ItemData SniperAmmo 
{
  description = "Sniper Bullet";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SniperRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0; // Single Shot
  ammoType = SniperAmmo;
  projectileType = EMPIRIALMRound;
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.2;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
  description = "20MM Renigade";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "gRifles";

  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 975;
  showWeaponBar = true;
};

$SellAmmo[SniperAmmo]			= 400;
$AmmoPackMax[SniperAmmo]		= 400;

$InvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;

AddWeapon(SniperRifle);

$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[lfemale, SniperRifle] = 1;
$ItemMax[marmor, SniperRifle] = 1;
$ItemMax[mfemale, SniperRifle] = 1;
$ItemMax[harmor, SniperRifle] = 0;
$ItemMax[BlastechF, SniperRifle] = 1;
$ItemMax[BlastechM, SniperRifle] = 1;
$ItemMax[MagIonM, SniperRifle] = 1;
$ItemMax[MagIonF, SniperRifle] = 1;
$ItemMax[MECH, SniperRifle] = 0;

$ItemMax[larmor, SniperAmmo] = 400;
$ItemMax[lfemale, SniperAmmo] = 400;
$ItemMax[marmor, SniperAmmo] = 400;
$ItemMax[mfemale, SniperAmmo] = 400;
$ItemMax[harmor, SniperAmmo] = 0;
$ItemMax[BlastechF, SniperAmmo] = 400;
$ItemMax[BlastechM, SniperAmmo] = 400;
$ItemMax[MagIonM, SniperAmmo] = 400;
$ItemMax[MagIonF, SniperAmmo] = 400;
$ItemMax[MECH, SniperAmmo] = 0;

//--------------------------------------------------------------------------------------------------------
// AAOD SniperX
//--------------------------------------------------------------------------------------------------------

ItemData SXAmmo
{
	description = "MDXDragonbolts";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SXImage 
{
	shapeFile = "sniper";
	mountPoint = 0;

      weaponType = 2;  // Sustained 
      projectileType = EMPIRIALBolt;
	ammoType = SXAmmo;
	accuFire = true;
	fireTime = 0.45;
	reloadTime = 0.20;
	
	sfxFire = SoundELFIdle;
	sfxActivate = SoundDryFire;
};

function SXImage::onFire(%player,%slot)
{
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	if (%playerId.MDX == 0)
	{
		if(Player::getItemCount(%player,SXAmmo) > 5)
		{
			Projectile::spawnProjectile("EMPIRIALBolt",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,6);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 6 to fire Standard EMPIRIALBolt - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.MDX == 1)
	{
		if(Player::getItemCount(%player,SXAmmo) > 7)
		{
			Projectile::spawnProjectile("EMPIRIALBoltExtream",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,8);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 8 to fire EMPIRIALBoltExtream - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.MDX == "2")
	{
		if(Player::getItemCount(%player,SXAmmo) > 9)
		{
			Projectile::spawnProjectile("EMPIRIALBoltBlackDragon",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,10);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 10 to fire EMPIRIALBoltBlackDragon - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.MDX == "3")
	{
		if(Player::getItemCount(%player,SXAmmo) > 19)
		{
			Projectile::spawnProjectile("EMPIRIALBoltPurpleDragon",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,20);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 20 to fire EMPIRIALBoltPurpleDragon - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.MDX == "4")
	{
		if(Player::getItemCount(%player,SXAmmo) > 39)
		{
			Projectile::spawnProjectile("EMPIRIALBoltDragonRound",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,40);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 40 to fire EMPIRIALBoltDragonRound - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
	else if (%playerId.MDX == "5")
	{
		if(Player::getItemCount(%player,SXAmmo) > 42)
		{
			Projectile::spawnProjectile("EMPIRIALBoltDragonRoundM",%trans,%player,%vel);
			Player::decItemCount(%player,SXAmmo,43);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Must Have Charge of 43 to fire EMPIRIALBoltDragonRoundM - Doh!*(0-0)*");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}

	if(!%player.recharge || %player.recharge != true)
	{
		%player.recharge = true;
		SXImage::onCharge(%player);
	}
}

ItemData AAODSniperX
{
	description = "MDX-Dragon";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = SXImage;
	price = 4500;
	showWeaponBar = true;

};

$InvList[AAODSniperX] = 1;
$RemoteInvList[AAODSniperX] = 1;
$InvList[SXAmmo] = 1;
$RemoteInvList[SXAmmo] = 1;

AddWeapon(aaodsniperx);

$ItemMax[larmor, AAODSniperX] = 1;
$ItemMax[lfemale, AAODSniperX] = 1;
$ItemMax[marmor, AAODSniperX] = 1;
$ItemMax[mfemale, AAODSniperX] = 1;
$ItemMax[harmor, AAODSniperX] = 1;
$ItemMax[BlastechF, AAODSniperX] = 1;
$ItemMax[BlastechM, AAODSniperX] = 1;
$ItemMax[MagIonM, AAODSniperX] = 1;
$ItemMax[MagIonF, AAODSniperX] = 1;
$ItemMax[MECH, AAODSniperX] = 1;

$ItemMax[larmor, SXAmmo] = 99999;
$ItemMax[lfemale, SXAmmo] = 99999;
$ItemMax[marmor, SXAmmo] = 99999;
$ItemMax[mfemale, SXAmmo] = 99999;
$ItemMax[harmor, SXAmmo] = 99999;
$ItemMax[BlastechF, SXAmmo] = 99999;
$ItemMax[BlastechM, SXAmmo] = 99999;
$ItemMax[MagIonM, SXAmmo] = 99999;
$ItemMax[MagIonF, SXAmmo] = 99999;
$ItemMax[MECH, SXAmmo] = 99999;

function AAODSniperX::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Reactor)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have Mini Reactor to use MDX-Dragon."); 
}

//--------------------------------------------------------------------------------------------------------
// MDX-Swarm
//--------------------------------------------------------------------------------------------------------

ItemData MDXAmmo
{
	description = "MDX Bolt";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MDXImage 
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot 
      projectileType = EMPIRIALBolt2ExtreamH;
	ammoType = MDXAmmo;
	accuFire = true;
	fireTime = 0.35;
	reloadTime = 0.20;
	
	sfxFire = SoundFirePistol;
	sfxActivate = SoundDryFire;
};

ItemData MDXSniper
{
	description = "MDX-Swarm";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = MDXImage;
	price = 4500;
	showWeaponBar = true;

};

$InvList[MDXSniper] = 1;
$RemoteInvList[MDXSniper] = 1;
$InvList[MDXAmmo] = 1;
$RemoteInvList[MDXAmmo] = 1;

AddWeapon(mdxsniper);

$ItemMax[larmor, MDXSniper] = 1;
$ItemMax[lfemale, MDXSniper] = 1;
$ItemMax[marmor, MDXSniper] = 1;
$ItemMax[mfemale, MDXSniper] = 1;
$ItemMax[harmor, MDXSniper] = 1;
$ItemMax[BlastechF, MDXSniper] = 1;
$ItemMax[BlastechM, MDXSniper] = 1;
$ItemMax[MagIonM, MDXSniper] = 1;
$ItemMax[MagIonF, MDXSniper] = 1;
$ItemMax[MECH, MDXSniper] = 1;

$ItemMax[larmor, MDXAmmo] = 99999;
$ItemMax[lfemale, MDXAmmo] = 99999;
$ItemMax[marmor, MDXAmmo] = 99999;
$ItemMax[mfemale, MDXAmmo] = 99999;
$ItemMax[harmor, MDXAmmo] = 99999;
$ItemMax[BlastechF, MDXAmmo] = 99999;
$ItemMax[BlastechM, MDXAmmo] = 99999;
$ItemMax[MagIonM, MDXAmmo] = 99999;
$ItemMax[MagIonF, MDXAmmo] = 99999;
$ItemMax[MECH, MDXAmmo] = 99999;

//--------------------------------------------------------------------------------------------------------
// MDX-Hammer
//--------------------------------------------------------------------------------------------------------

ItemData HammerRAmmo
{
	description = "HammerBolt";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MDXRImage 
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot 
      projectileType = HammerBolt;
	ammoType = MDXRAmmo;
	accuFire = true;
	fireTime = 0.35;
	reloadTime = 0.20;
	
	sfxFire = SoundFirePistol;
	sfxActivate = SoundDryFire;
};

ItemData MDXRSniper
{
	description = "MDX-Hammer";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = MDXRImage;
	price = 4500;
	showWeaponBar = true;

};

$InvList[MDXRSniper] = 1;
$RemoteInvList[MDXRSniper] = 1;
$InvList[HammerRAmmo] = 1;
$RemoteInvList[HammerRAmmo] = 1;

AddWeapon(mdxrsniper);

$ItemMax[larmor, MDXRSniper] = 1;
$ItemMax[lfemale, MDXRSniper] = 1;
$ItemMax[marmor, MDXRSniper] = 1;
$ItemMax[mfemale, MDXRSniper] = 1;
$ItemMax[harmor, MDXRSniper] = 1;
$ItemMax[BlastechF, MDXRSniper] = 1;
$ItemMax[BlastechM, MDXRSniper] = 1;
$ItemMax[MagIonM, MDXRSniper] = 1;
$ItemMax[MagIonF, MDXRSniper] = 1;
$ItemMax[MECH, MDXRSniper] = 1;

$ItemMax[larmor, HammerRAmmo] = 220;
$ItemMax[lfemale, HammerRAmmo] = 220;
$ItemMax[marmor, HammerRAmmo] = 220;
$ItemMax[mfemale, HammerRAmmo] = 220;
$ItemMax[harmor, HammerRAmmo] = 220;
$ItemMax[BlastechF, HammerRAmmo] = 220;
$ItemMax[BlastechM, HammerRAmmo] = 220;
$ItemMax[MagIonM, HammerRAmmo] = 220;
$ItemMax[MagIonF, HammerRAmmo] = 220;
$ItemMax[MECH, HammerRAmmo] = 220;

//--------------------------------------------------------------------------------------------------------
// MDX-PP47
//--------------------------------------------------------------------------------------------------------

ItemData MDX1Ammo
{
	description = "MDX Charge";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MDX1Image 
{
	shapeFile = "sniper";
	mountPoint = 0;

      weaponType = 2;  // Sustained 
      projectileType = MDXBoltExtream;
	ammoType = MDX1Ammo;
	accuFire = true;
	fireTime = 0.35;
	reloadTime = 0.20;
	
	sfxFire = SoundELFIdle;
	sfxActivate = SoundMissileTurretOn;
};

ItemData MDX1Sniper
{
	description = "MDX-PP47";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = MDX1Image;
	price = 4500;
	showWeaponBar = true;

};

$InvList[MDX1Sniper] = 1;
$RemoteInvList[MDX1Sniper] = 1;
$InvList[MDX1Ammo] = 1;
$RemoteInvList[MDX1Ammo] = 1;

AddWeapon(mdx1sniper);

$ItemMax[larmor, MDX1Sniper] = 1;
$ItemMax[lfemale, MDX1Sniper] = 1;
$ItemMax[marmor, MDX1Sniper] = 1;
$ItemMax[mfemale, MDX1Sniper] = 1;
$ItemMax[harmor, MDX1Sniper] = 1;
$ItemMax[BlastechF, MDX1Sniper] = 1;
$ItemMax[BlastechM, MDX1Sniper] = 1;
$ItemMax[MagIonM, MDX1Sniper] = 1;
$ItemMax[MagIonF, MDX1Sniper] = 1;
$ItemMax[MECH, MDX1Sniper] = 1;

$ItemMax[larmor, MDX1Ammo] = 99999;
$ItemMax[lfemale, MDX1Ammo] = 99999;
$ItemMax[marmor, MDX1Ammo] = 99999;
$ItemMax[mfemale, MDX1Ammo] = 99999;
$ItemMax[harmor, MDX1Ammo] = 99999;
$ItemMax[BlastechF, MDX1Ammo] = 99999;
$ItemMax[BlastechM, MDX1Ammo] = 99999;
$ItemMax[MagIonM, MDX1Ammo] = 99999;
$ItemMax[MagIonF, MDX1Ammo] = 99999;
$ItemMax[MECH, MDX1Ammo] = 99999;

function MDX1Sniper::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Reactor)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have Mini Reactor to use MDX-PP47."); 
}

//--------------------------------------------------------------------------------------------------------
// MDX-PP48
//--------------------------------------------------------------------------------------------------------

ItemData MDX2Ammo
{
	description = "MDXPP48Rounds";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MDX2Image 
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot 
      projectileType = MDXPP48Round;
	ammoType = MDX2Ammo;
	accuFire = true;
	fireTime = 0.35;
	reloadTime = 0.20;
	
	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MDX2Sniper
{
	description = "MDX-PP48";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = MDX2Image;
	price = 4500;
	showWeaponBar = true;

};

$InvList[MDX2Sniper] = 1;
$RemoteInvList[MDX2Sniper] = 1;
$InvList[MDX2Ammo] = 1;
$RemoteInvList[MDX2Ammo] = 1;

AddWeapon(mdx2sniper);

$ItemMax[larmor, MDX2Sniper] = 1;
$ItemMax[lfemale, MDX2Sniper] = 1;
$ItemMax[marmor, MDX2Sniper] = 1;
$ItemMax[mfemale, MDX2Sniper] = 1;
$ItemMax[harmor, MDX2Sniper] = 1;
$ItemMax[BlastechF, MDX2Sniper] = 1;
$ItemMax[BlastechM, MDX2Sniper] = 1;
$ItemMax[MagIonM, MDX2Sniper] = 1;
$ItemMax[MagIonF, MDX2Sniper] = 1;
$ItemMax[MECH, MDX2Sniper] = 1;

$ItemMax[larmor, MDX2Ammo] = 99999;
$ItemMax[lfemale, MDX2Ammo] = 99999;
$ItemMax[marmor, MDX2Ammo] = 99999;
$ItemMax[mfemale, MDX2Ammo] = 99999;
$ItemMax[harmor, MDX2Ammo] = 99999;
$ItemMax[BlastechF, MDX2Ammo] = 99999;
$ItemMax[BlastechM, MDX2Ammo] = 99999;
$ItemMax[MagIonM, MDX2Ammo] = 99999;
$ItemMax[MagIonF, MDX2Ammo] = 99999;
$ItemMax[MECH, MDX2Ammo] = 99999;

//--------------------------------------------------------------------------------------------------------
// MDX-Lightning
//--------------------------------------------------------------------------------------------------------

ItemData MDX3Ammo
{
	description = "MDXLightningCharge";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MDX3Image 
{
	shapeFile = "sniper";
	mountPoint = 0;

      weaponType = 2;  // Sustained 
      projectileType = MDXLightningbolt;
	ammoType = MDX3Ammo;
	accuFire = true;
	fireTime = 0.35;
	reloadTime = 0.20;
	
	sfxFire = Electricity;
	sfxActivate = SoundELFFire;
};

ItemData MDX3Sniper
{
	description = "MDX-Lightning";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MDX3Image;
	price = 4500;
	showWeaponBar = true;

};

$InvList[MDX3Sniper] = 1;
$RemoteInvList[MDX3Sniper] = 1;
$InvList[MDX3Ammo] = 1;
$RemoteInvList[MDX3Ammo] = 1;

AddWeapon(mdxLightningsniper);

$ItemMax[larmor, MDX3Sniper] = 1;
$ItemMax[lfemale, MDX3Sniper] = 1;
$ItemMax[marmor, MDX3Sniper] = 1;
$ItemMax[mfemale, MDX3Sniper] = 1;
$ItemMax[harmor, MDX3Sniper] = 1;
$ItemMax[BlastechF, MDX3Sniper] = 1;
$ItemMax[BlastechM, MDX3Sniper] = 1;
$ItemMax[MagIonM, MDX3Sniper] = 1;
$ItemMax[MagIonF, MDX3Sniper] = 1;
$ItemMax[MECH, MDX3Sniper] = 1;

$ItemMax[larmor, MDX3Ammo] = 26;
$ItemMax[lfemale, MDX3Ammo] = 26;
$ItemMax[marmor, MDX3Ammo] = 26;
$ItemMax[mfemale, MDX3Ammo] = 26;
$ItemMax[harmor, MDX3Ammo] = 26;
$ItemMax[BlastechF, MDX3Ammo] = 26;
$ItemMax[BlastechM, MDX3Ammo] = 26;
$ItemMax[MagIonM, MDX3Ammo] = 26;
$ItemMax[MagIonF, MDX3Ammo] = 26;
$ItemMax[MECH, MDX3Ammo] = 26;

//--------------------------------------------------------------------------------------------------------
// ELF Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
        projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.1;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "jTools";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 500;
};

AddWeapon(EnergyRifle);

//--------------------------------------------------------------------------------------------------------
// Repair Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//--------------------------------------------------------------------------------------------------------
// Repair Gun
//--------------------------------------------------------------------------------------------------------

//=============================================================================================

ItemImageData ReassemblerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = reassemblerBolt;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 7;
	reloadTime = 0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Reassembler
{
	description   = "Reassembler";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   heading = "jTools"; 
	shadowDetailMask = 4;
	imageType     = ReassemblerImage;
	price         = 100;
	showWeaponBar = false;
};

$AutoUse[Reassembler]			= true;

AddWeapon(reassembler);

$InvList[Reassembler] = 1;
$RemoteInvList[Reassembler] = 1;

$ItemMax[larmor, Reassembler] = 1;
$ItemMax[lfemale, Reassembler] = 1;
$ItemMax[marmor, Reassembler] = 1;
$ItemMax[mfemale, Reassembler] = 1;
$ItemMax[harmor, Reassembler] = 1;
$ItemMax[BlastechF, Reassembler] = 1;
$ItemMax[BlastechM, Reassembler] = 1;
$ItemMax[MagIonM, Reassembler] = 1;
$ItemMax[MagIonF, Reassembler] = 1;
$ItemMax[MECH, Reassembler] = 1;

//==================================================================================================== Napalm Frags

MineData Frag1
{
   	mass = 5.0;
   	drag = 0.5;
   	density = 2.0;
	elasticity = 0.15;
	friction = 0.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.9;
	damageType = $PlasmaDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.6;
	maxDamage = 1.9;
};

function Frag1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Frag2
{
   	mass = 5.0;
   	drag = 0.5;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 1.6;
};

function Frag2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Frag3
{
   	mass = 5.0;
   	drag = 0.1;
   	density = 2.0;
	elasticity = 0.25;
	friction = 1.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;

maxDamage = 1.5;
};

function Frag3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

function DeployFrags(%this, %count, %player) 
{
        %cl = Player::getClient(%player);
	%pos = gamebase::getposition(%this);
	%team = GameBase::getTeam(%player);

	for (%i = 0; %i < %count; %i++)
	{
		%frag = "Frag" @ (floor(getRandom()*3)+1);
		%obj = newObject("","Mine", %frag);
		%obj.deployer = %cl;

		if ((floor(getRandom()*4)+1) > 2)
		{
			%dir = 120;			
			GameBase::throw(%obj,%cl,%dir,true);
		}
		else
		{
			%dir = 60;
			GameBase::throw(%obj,%cl,%dir,true);
		}

		addToSet("MissionCleanup", %obj);
		
		GameBase::setPosition(%obj, %pos);
	}

}

//-----------------------------------
// Beacon Gun Script
//-----------------------------------
$InvList[AODBeaconGun]			= 1;
$RemoteInvList[AODBeaconGun]	= 1;		
$AutoUse[AODBeaconGun]			= True;
$WeaponAmmo[AODBeaconGun]		= Beacon;
AddWeapon(AODBeaconGun);

$ItemMax[larmor,AODBeaconGun]	= 1;
$ItemMax[lfemale,AODBeaconGun]	= 0;
$ItemMax[marmor,AODBeaconGun]	= 1;
$ItemMax[mfemale,AODBeaconGun]	= 0;
$ItemMax[harmor,AODBeaconGun]	= 1;
$ItemMax[BlastechF, AODBeaconGun] = 1;
$ItemMax[BlastechM, AODBeaconGun] = 1;
$ItemMax[MagIonM, AODBeaconGun] = 0;
$ItemMax[MagIonF, AODBeaconGun] = 0;
$ItemMax[MECH, AODBeaconGun] = 1;

ExplosionData AODBeaconGunExp
{	shapeName = "shockwave.dts";	
	soundId=  SoundBeaconExplosion;	
	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=9.0;			
	timeZero=0.100;			
	timeOne=0.900;			
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;	
};

RocketData BeaconRocket
{	bulletShapeName		= "sensor_small.dts";
	explosionTag		= AODBeaconGunExp;
	#collideWithOwner	= true;
	#ownerGraceMS		= 750;
	collisionRadius		= 0.0;
	mass				= 1.0;

	damageClass			= 1;    
	damageValue			= 0.10;
	damageType			= $NullDamageType;
	explosionRadius		= 35.0;
	kickBackStrength	= 95.0;
	muzzleVelocity		= 25.0;
	terminalVelocity	= 25.0;
	acceleration		= 1.0;
	totalTime			= 22.0;
	liveTime			= 25.0;
	lightRange			= 5.0;
	lightColor			= { 0.2, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType			= 2;                
	trailString			= "rsmoke.dts";
	smokeDist			= 1.5;
	soundId				= SoundJetHeavy;
};

ItemImageData AODBeaconGunImage
{	shapeFile		= "PaintGun";
	mountPoint		= 0;
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.75, 0};
	weaponType		= 0;
	reloadTime		= 0.75;
	fireTime		= 1.5;
	minEnergy		= 15;	
	maxEnergy		= 50;	
	ammoType		= Beacon;
	accuFire		= true;
	sfxActivate		= SoundPickUpWeapon;
};

ItemData AODBeaconGun
{	heading				= "jTools";
	description			= "Beacon Gun";
	classname			= "Weapon";
	shapeFile			= "PaintGun";
	hudIcon				= "mortar";	
	shadowDetailMask	= 4;
	imageType			= AODBeaconGunImage;	
	price				= 450;				
	showWeaponBar		= true;	
};

function DeployRBeacon(%player)
{	
	%position=$Location;
	%rot=$Rotation;
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	if($traceObj) Echo($Ver,"|Created New Object :",%beacon," Beacon");
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%position);
	Gamebase::setMapName(%beacon,"Target Beacon");
	Beacon::onEnabled(%beacon);
}

function AODBeaconGunImage::onFire(%player,%slot)
{	// if($trace) echo( $ver@"|AODBeaconGunImage::onFire");
	%client = GameBase::getOwnerClient(%player);
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]) && Player::getItemCount(%player,Beacon)) ;
	if(%AmmoCount)
	{	%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,250))
		{	%object = getObjectType($los::object);
			if (%object!="Player" && %object !="Flier" && %object !="") // == "SimTerrain" || %object == "InteriorShape" || %object=="StaticShape") 
			{	// Try to stick it straight up or down, otherwise
				// just use the surface normal
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{	%rot = "0 0 0";}
				else 
				{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{	%rot = "3.14159 0 0";}
					else 
					{	%rot = Vector::getRotation($los::normal);}
				}
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[Beacon] > $TeamItemCount[%team @ Beacon] || $TestCheats) 
				{	%Dist=Vector::getDistance(GameBase::getPosition(%player),$los::position);
					if(%Dist==0)
					{	%tTime=1;}
					else
					{	%tTime=%Dist/25;}

					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("BeaconRocket",%trans,%player,%vel,$los::object);
					playSound(SoundMissileReload, GameBase::getPosition(%player));
					GiveKickBack(%player, 15, 1);
					$Location=$los::position;
					$Rotation=%rot;
					schedule("DeployRBeacon(" @ %player @ " );",%tTime);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					Player::decItemCount(%player,Beacon);
				}
				else
				Client::sendMessage(%client,0,"Deployable Item limit reached! ~Error_Message.wav");
			}
			else
			Client::sendMessage(%client,0,"** Invalid Target - Unable to attach to Object! ** ~wError_Message.wav");
		}
		else
		Client::sendMessage(%client,0,"** Object Out of Range !! ** ~wError_Message.wav");
	}
	else
	{	if (!Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]))
	{	Client::sendMessage(%client,0,"** Out of Beacons!! ** ~waccess_denied.wav");}
	else
	{ 	Client::sendMessage(%client,0,"** Out of Beacons!! ** ~waccess_denied.wav");}
	}

}

//--------------------------------------------------------------------------------------------------------
// Targeting Laser
//--------------------------------------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 3;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "jTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc>The Targeting Laser: <f1>An effective tool used mostly by bots.", 5);
}

$InvList[TargetingLaser]			= 1;
$RemoteInvList[TargetingLaser]		= 1;		

$ItemMax[larmor,TargetingLaser]	= 1;
$ItemMax[lfemale,TargetingLaser]	= 1;
$ItemMax[marmor,TargetingLaser]	= 1;
$ItemMax[mfemale,TargetingLaser]	= 1;
$ItemMax[harmor,TargetingLaser]	= 1;
$ItemMax[BlastechF, TargetingLaser] = 1;
$ItemMax[BlastechM, TargetingLaser] = 1;
$ItemMax[MagIonM, TargetingLaser] = 1;
$ItemMax[MagIonF, TargetingLaser] = 1;
$ItemMax[MECH, TargetingLaser] = 1;

