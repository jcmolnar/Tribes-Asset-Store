# NEW Meltdown version 2.16, open source.
# Redid most of scripts and got rid of 
# unneeded crap in other ppl's stuff.
#========================================

// WEAPON FUCTIONS-

function ApplyKickback(%player, %rot, %kick)
{
	%vel = item::getVelocity(%player);
	%x = getWord(%vel, 0);
	%y = getWord(%vel, 1);
	%z = getWord(%vel, 2);
	//echo(%vel);
	if( %x <= 30 && %y <= 30 && %z <= 30 )
	{
		%vec = Vector::getFromRot(%rot, %kick);
		%vec = Vector::neg(%vec);
		Player::applyImpulse(%player,%vec);
	}
}

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
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bEnergy Weapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

AddWeapon(Blaster);

function BlasterImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

    if (!%playerId.Blaster || %playerId.Blaster == 0)
		{
			//Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
            %proj = Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        //ApplyKickback(%player, %rot, 15);
        }
        else if (%playerId.Blaster == 1)
	    {
			//Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
			%vel = EmplacementPack::rotVector( "10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("BlasterBolt2",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "-10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("BlasterBolt2",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 2 10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("BlasterBolt2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        //ApplyKickback(%player, %rot, 20);
       }
       else if (%playerId.Blaster == 2)
	    {
            Projectile::spawnProjectile("BlasterCBolt",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        //ApplyKickback(%player, %rot, 15);
       }
       else
		Player::trigger(%player,$WeaponSlot,false);
}


//--------------------------------------------------------------------------------------------------------
// Ion Cannon
//--------------------------------------------------------------------------------------------------------

ItemImageData IonCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 14; 
	maxEnergy = 15; 
	reloadTime = 0.65;
	fireTime = 0;

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IonCannon
{
	description = "Ion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = IonCannonImage;
	price = 255;
	showWeaponBar = true;
};

function IonCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Player::mountItem(%player,IonChargerA,$ExtraWeaponSlotA);
	Player::mountItem(%player,IonChargerB,$ExtraWeaponSlotB);
	Player::mountItem(%player,IonChargerC,$ExtraWeaponSlotC);
}

function IonCannon::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
}

ItemImageData IonChargerAI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.25 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerA
{
	description = "Ion Charger A";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerAI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData IonChargerBI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0.15, 0, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerB
{
	description = "Ion Charger B";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerBI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


ItemImageData IonChargerCI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.15, 0, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerC
{
	description = "Ion Charger C";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerCI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$InvList[IonCannon] = 1;
$RemoteInvList[IonCannon] = 1;

$ItemMax[larmor, IonCannon] = 0;
$ItemMax[lfemale, IonCannon] = 0;
$ItemMax[marmor, IonCannon] = 1;
$ItemMax[mfemale, IonCannon] = 1;
$ItemMax[harmor, IonCannon] = 1;
$ItemMax[BlastechM, IonCannon] = 0;
$ItemMax[BlastechF, IonCannon] = 0;
$ItemMax[MagIonM, IonCannon] = 1;
$ItemMax[MagIonF, IonCannon] = 1;
$ItemMax[MECH, IonCannon] = 1;

AddWeapon(IonCannon);

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
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData OmegaRifle
{
   description = "Omega Rifle";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bEnergy Weapons";
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

//=========================================================================
AddWeapon(VertigoCannon);

ItemImageData VRLImage 
{
	shapeFile = "grenammo";
	mountPoint = 0;

	weaponType = 0; 
	minEnergy = 1;
	maxEnergy = 10;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 0;
	
	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
};

function VRLImage::onFire(%player,%slot) 
{	
	%enVal  = 10.0;
	%energy = GameBase::getEnergy(%player);
	%energy = %energy - %enVal;
	
    	if (%energy > 0.1)
	{
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		$vertigo = True;

		if($vertigo) 
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
					GameBase::setEnergy(%player,%energy);
					Projectile::spawnProjectile("VertigoRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("VertigoMissile",%trans,%player,%vel,%target);
						GameBase::setEnergy(%player,%energy);
					}
				}
				else
				{	
					Projectile::spawnProjectile("VertigoMissile",%trans,%player,%vel,%target);
					GameBase::setEnergy(%player,%energy);
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
						GameBase::setEnergy(%player,%energy);
						Projectile::spawnProjectile("VertigoRocket",%trans,%player,%vel,$los::object);
					}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("VertigoMissile",%trans,%player,%vel,%target);
							GameBase::setEnergy(%player,%energy);
						}
					}
					else
					{	
						Projectile::spawnProjectile("VertigoMissile",%trans,%player,%vel,%target);
						GameBase::setEnergy(%player,%energy);
					}
				}
				else
				{	
					GameBase::setEnergy(%player,%energy);
					Projectile::spawnProjectile("VertigoRocket",%trans,%player,%vel,$los::object);
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
					GameBase::setEnergy(%player,%energy);
					Projectile::spawnProjectile("VertigoMissile",%trans,%player,%vel,$los::object);
				}
				else
				{	
					GameBase::setEnergy(%player,%energy);
					Projectile::spawnProjectile("VertigoRocket",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				GameBase::setEnergy(%player,%energy);
				Projectile::spawnProjectile("VertigoRocket",%trans,%player,%vel,$los::object);
			}
		}
	}
}

ItemData VertigoCannon
{
	description = "GEP Gun";
	className = "Weapon";
	shapeFile = "grenammo";
	hudIcon = "blaster";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = VRLImage;
	price = 1250;
	showWeaponBar = true;
};

$InvList[VertigoCannon] = 1;
$RemoteInvList[VertigoCannon] = 1;

$ItemMax[larmor, VertigoCannon] = 0;
$ItemMax[lfemale, VertigoCannon] = 0;
$ItemMax[marmor, VertigoCannon] = 1;
$ItemMax[mfemale, VertigoCannon] = 1;
$ItemMax[harmor, VertigoCannon] = 1;
$ItemMax[BlastechM, VertigoCannon] = 0;
$ItemMax[BlastechF, VertigoCannon] = 0;
$ItemMax[MagIonM, VertigoCannon] = 1;
$ItemMax[MagIonF, VertigoCannon] = 1;
$ItemMax[MECH, VertigoCannon] = 1;


//----------------------------------------------------------------------------

ItemImageData ChargerImage
{
	shapeFile = "mortar";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Charger
{
   description = "ELF Cannon";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = ChargerImage;
	showWeaponBar = true;
   price = 1500;
};

function ChargerImage::onActivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,true); 
	Player::trigger(%player,$ExtraWeaponSlotC,true); 
	Player::trigger(%player,$ExtraWeaponSlotD,true); 
}

function ChargerImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,false); 
	Player::trigger(%player,$ExtraWeaponSlotC,false); 
	Player::trigger(%player,$ExtraWeaponSlotD,false); 
}
 
function Charger::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,ExtraCharger,$ExtraWeaponSlotB); 
	Player::mountItem(%player,ExtraCharger2,$ExtraWeaponSlotC); 
	Player::mountItem(%player,ExtraCharger3,$ExtraWeaponSlotD); 
} 

function Charger::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$ExtraWeaponSlotB); 
	Player::unmountItem(%player,$ExtraWeaponSlotC); 
	Player::unmountItem(%player,$ExtraWeaponSlotD); 
} 

ItemImageData ExtraChargerImage
{
	mountOffset = { 0.085, 0, 0.15 };
	mountRotation = { 0, 0.735, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = destructiveCharge;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger
{
   heading = "bWeapons";
	description = "ELF Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraChargerImage;
	price = 85;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger2Image
{
	mountOffset = { -0.085, 0, 0.15 };
	mountRotation = { 0, -0.735, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = destructiveCharge;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger2
{
   heading = "bWeapons";
	description = "ELF Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraCharger2Image;
	price = 85;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger3Image
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = destructiveCharge;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger3
{
   heading = "bWeapons";
	description = "ELF Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraCharger3Image;
	price = 3000;
	showWeaponBar = False;
	showInventory = False;
};

$InvList[Charger] = 1;
$RemoteInvList[Charger] = 1;

$ItemMax[larmor, Charger] = 0;
$ItemMax[lfemale, Charger] = 0;
$ItemMax[marmor, Charger] = 0;
$ItemMax[mfemale, Charger] = 0;
$ItemMax[harmor, Charger] = 1;
$ItemMax[BlastechM, Charger] = 0;
$ItemMax[BlastechF, Charger] = 0;
$ItemMax[MagIonM, Charger] = 0;
$ItemMax[MagIonF, Charger] = 0;
$ItemMax[MECH, Charger] = 0;

AddWeapon(Charger);
//=========================================================================


////////////////////////////////////////////////////////////////////////////////
//  Mitzi Blast Cannon
//
////////////////////////////////////////////////////////////////////////////////

//--------------Large Nuke------------------------
//========================================Nuclear Explosion

function NBase::onAdd(%this) { }

GrenadeData NBaseLight
{
	explosionTag       = NukeWave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
    damageValue        = 5.5;
	damageType         = $NukeDamageType;

	explosionRadius    = 70;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};
function NBaseLight::onAdd(%this) { }

GrenadeData NRing
{
	explosionTag       = LargeShockwave;
    //explosionTag       = ShockwaveTwo;      // Nice looking blue shock wav
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
    damageValue        = 5.5;
	damageType         = $NukeDamageType;

	explosionRadius    = 70;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 1.1;
	liveTime           = 0.1;
	projSpecialTime    = 1.9;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};
function NRing::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",0.2,%this); }

GrenadeData NCloud
{
	explosionTag       = mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
    damageValue        = 5.5;
	damageType         = $NukeDamageType;

	explosionRadius    = 70;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};

//--------------Baby Nuke------------------------

GrenadeData ClusterBombNuke         //Modified by: MegaMan
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 500;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 9;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 60.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};

function ClusterBombNuke::onAdd(%this)
{
	schedule("BombSpread(" @ %this @ ");",5.1,%this);
}

//--------------Swarmer------------------------
BulletData SwarmerRocket
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = flashExpLarge;

   damageClass        = 1;
   damageValue        = 1.0;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 6.0;
   aimDeflection      = 0.015;

   muzzleVelocity     = 155.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//-----------------Starblurst---------------------
BulletData Starblast
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = pbwExp;
   expRandCycle       = 4;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $StarDamageType;

   aimDeflection      = 0.010;
   explosionRadius    = 20.5;
   muzzleVelocity     = 100;
   totalTime          = 40;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
   soundId = SoundJetLight;

};
//-----------------reg mitzi---------------------
RocketData IonShock3
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.50;
   damageType       = $MBDamageType;

   explosionRadius  = 12;  // was 16
   kickBackStrength = 412.0; // was 525

   muzzleVelocity   = 35.0;
   terminalVelocity = 60.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };  //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionbolt.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock4
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_3;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EMPDamageType;

   explosionRadius  = 12;  // was 16
   kickBackStrength = 64.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 60.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5  };   //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock5
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $NullDamageType;

   explosionRadius  = 12;  // was 16
   kickBackStrength = 512.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 60.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };  //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock5x2
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_2;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $NullDamageType;

   explosionRadius  = 16;  // was 16
   kickBackStrength = 1150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };  //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock6
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_4;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $MethaneDamageType;

   explosionRadius  = 12;  // was 16
   kickBackStrength = 0.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 60.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };  //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock7
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = ionExp_5;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $MBHeatDamageType;

   explosionRadius  = 16;  // was 16
   kickBackStrength = 32.0;

   muzzleVelocity   = 45.0;
   terminalVelocity = 60.0;
   acceleration     = 5.0;
   //muzzleVelocity   = 65.0;
   //terminalVelocity = 90.0;
   //acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };  //{ 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 4;

   soundId = SoundELFIdle;
};

RocketData IonShock8
{
   bulletShapeName  = "shockwave.dts";
   explosionTag     = AnnihExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 25;
   damageType       = $PulseDamageType;

   explosionRadius  = 25;
   kickBackStrength = 1024;
   muzzleVelocity   = 50.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 20.0;

   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shockwave.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//========================================================================
RocketData MitziCannonBolt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = ShockwaveFour;
	collisionRadius = 0.0;
	mass = 0.0;

    damageClass      = 1;       // 0 impact, 1, radius
    damageValue      = 25;
    damageType       = $MBDamageType;
	explosionRadius = 7;

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
	trailWidth = 2.0;
	soundId = SoundJetHeavy;
};

RocketData MitziCannonBolt2
{
	bulletShapeName = "enbolt.dts";
	explosionTag = ShockwaveFour;
	collisionRadius = 0.0;
	mass = 0.0;

    damageClass      = 1;       // 0 impact, 1, radius
    damageValue      = 25;
    damageType       = $MBDamageType;
	explosionRadius = 7;

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

RocketData MitziCannonShock
{
	bulletShapeName  = "shield.dts";
	explosionTag     = ShockwaveFour;
	collisionRadius  = 0.0;
	mass             = 0.0;

    damageClass      = 1;       // 0 impact, 1, radius
    damageValue      = 25;
    damageType       = $MBDamageType;
	explosionRadius = 7;

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
	reloadTime = 0.25;
	fireTime = 1;
	
	sfxFire = MitziFireSound;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = MitziReloadSound;
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
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Standard Mitzi Blast");
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
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi EMP Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "2")
	{
		if(Player::getItemCount(%player,MitziCore) > 14)
		{
			Projectile::spawnProjectile("IonShock5",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,15);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Boost");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    else if (%playerId.Cannon == "3")
	{
		if(Player::getItemCount(%player,MitziCore) > 99)
		{
			Projectile::spawnProjectile("IonShock5x2",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,100);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Boost x2");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    else if (%playerId.Cannon == "4")
	{
		if(Player::getItemCount(%player,MitziCore) > 24)
		{
			Projectile::spawnProjectile("IonShock6",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,25);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Area Poisoning Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "5")
	{
		if(Player::getItemCount(%player,MitziCore) > 24)
		{
			Projectile::spawnProjectile("IonShock7",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,25);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Internal Flaming Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
      else if (%playerId.Cannon == "6")
	  {
		if(Player::getItemCount(%player,MitziCore) > 199)
		{
        Projectile::spawnProjectile("MitziCannonBolt",%trans,%player,%vel);
        Projectile::spawnProjectile("MitziCannonBolt",%trans,%player,%vel);
        //
        Projectile::spawnProjectile("MitziCannonBolt2",%trans,%player,%vel);
        Projectile::spawnProjectile("MitziCannonBolt2",%trans,%player,%vel);
        //
        Projectile::spawnProjectile("MitziCannonShock",%trans,%player,%vel);
        Projectile::spawnProjectile("MitziCannonShock",%trans,%player,%vel);
        Player::decItemCount(%player,MitziCore,200);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Blue Ray");
			Player::trigger(%player,$WeaponSlot,false);
		}
     }
     else if (%playerId.Cannon == "7")
	 {
		if(Player::getItemCount(%player,MitziCore) > 199)
		{
			//Projectile::spawnProjectile("IonShock7",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Projectile::spawnProjectile("Starblast",%trans,%player,%vel);
             Player::decItemCount(%player,MitziCore,200);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Starburst");
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
    else if (%playerId.Cannon == "8")
	{
		if(Player::getItemCount(%player,MitziCore) > 199)
		{
			Projectile::spawnProjectile("IonShock8",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,200);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Annihilator Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    else if (%playerId.Cannon == "9")
	{
		if(Player::getItemCount(%player,MitziCore) > 249)
		{
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             // 18 total
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
             Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);

            Player::decItemCount(%player,MitziCore,250);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Swarmer Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    else if (%playerId.Cannon == "10")
	{
		if(Player::getItemCount(%player,MitziCore) > 349)
		{
             Projectile::spawnProjectile("ClusterBomb",%trans,%player,%vel);
             Player::decItemCount(%player,MitziCore,350);
		}
        else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Baby Nuke");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    else if (%playerId.Cannon == "11")
	{
		if(Player::getItemCount(%player,MitziCore) > 499)
		{
             Projectile::spawnProjectile("FgcShell",%trans,%player,%vel);
             Player::decItemCount(%player,MitziCore,500);
             Mitzi::NukeMessage(%player);
        }
        else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Large Nuke");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
    if(!%player.recharge || %player.recharge != true)
	{
		%player.recharge = true;
		MBImage::onCharge(%player);
	}
}

function Mitzi::NukeMessage(%clientId,%player)
{
%playerId = Player::getClient(%player);
%cl = Player::getClient(%player);
%clname = Client::getName(%cl);
MessageAllExcept(%cl, 0, %clname @ "some one fired a large NUKE!~wAAODSFX53.wav");
}

function MBImage::onCharge(%player)
{
    %armor = Player::getArmor(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);

	if(Player::getItemCount(%player,MBCannon) > 0)
	{                                            // added by -Defender
		if(Player::getItemCount(%player,MitziCore) < $ItemChargeMax[%armor, MitziCore])
		{
			Player::incItemCount(%player,MitziCore,1);

            schedule("MBImage::onCharge("@%player@");",0.5,%player);
		}
		else                                          // was   0.5
			%player.recharge = false;
 	}
}


ItemData MBCannon
{
	description = "Mitzi Blast Cannon";
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
$SellAmmo[MitziCore]			= 50;

$InvList[MitziCore] = 1;
$RemoteInvList[MitziCore] = 1;

$ItemMax[harmor, MitziCore] = 50;
$ItemMax[marmor, MitziCore] = 50;
$ItemMax[mfemale, MitziCore] = 50;
$ItemMax[larmor, MitziCore] = 50;
$ItemMax[lfemale, MitziCore] = 50;
$ItemMax[BlastechM, MitziCore] = 50;
$ItemMax[BlastechF, MitziCore] = 50;
$ItemMax[MagIonM, MitziCore] = 50;
$ItemMax[MagIonF, MitziCore] = 50;
$ItemMax[MECH, MitziCore] = 50;

$ItemChargeMax[harmor, MitziCore] = 500;
$ItemChargeMax[marmor, MitziCore] = 50;
$ItemChargeMax[mfemale, MitziCore] = 50;
$ItemChargeMax[larmor, MitziCore] = 50;
$ItemChargeMax[lfemale, MitziCore] = 50;
$ItemChargeMax[BlastechM, MitziCore] = 50;
$ItemChargeMax[BlastechF, MitziCore] = 50;
$ItemChargeMax[MagIonM, MitziCore] = 50;
$ItemChargeMax[MagIonF, MitziCore] = 50;
$ItemChargeMax[MECH, MitziCore] = 75;


//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------


ItemImageData ExtraEnergyImageA 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, 1.57, 0 }; 
	mountOffset = { 0.1, 0, 0.05 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyA 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageA; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageB 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 }; 
	mountOffset = { 0.0, 0, 0 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyB 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageB; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageC
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, -1.57, 0 }; 
	mountOffset = { -0.1, 0, 0.05 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyC 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageC; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData EnergyGunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 0; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData EnergyGun
{ 
	description = "Protron"; 
	className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "blaster"; 
     heading = "bWeapons"; 
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
$ItemMax[harmor, EnergyGun] = 0;
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
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	accuFire = false;

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
				Projectile::spawnProjectile("GaussBullet",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
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

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 2;
	projectileType = GatlingBlasterBolt;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundDryFire;
};

ItemData GatB
{
	description = "Gatling Blaster";
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

//----------------------------------------------------------
BulletData MiniGunBullet
{
   bulletShapeName    = "bullet.dts";
   //explosionTag       = bulletExp0;
   explosionTag       = SmokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $MiniGunDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 768.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
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
   damageType         = $MiniGunDamageType;

   explosionRadius  = 7.5;
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

addweapon(Minigun);
$MinigunSlot=4; 
$AutoUse[Minigun] = True; 
$SellAmmo[MinigunAmmo] = 25; 
$AmmoPackMax[MinigunAmmo] = 50; 
$AmmoPackItems[13] = MinigunAmmo; 
$WeaponAmmo[Minigun] = MinigunAmmo; 

$InvList[Minigun]=1;	
$InvList[MinigunAmmo]=1;
$RemoteInvList[Minigun]=1;		// Some weapons are not available from remote inventory units
$RemoteInvList[MinigunAmmo]=1;

$ItemMax[lfemale,Minigun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,Minigun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,Minigun]=1;	// The maximum Medium Female can carry
$ItemMax[marmor,Minigun]=1;	// The maximum Medium Male can carry
$ItemMax[harmor,Minigun]=0;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, Minigun] = 0;
$ItemMax[BlastechF, Minigun] = 0;
$ItemMax[MagIonM, Minigun] = 1;
$ItemMax[MagIonF, Minigun] = 1;
$ItemMax[MECH, Minigun] = 0;

$ItemMax[lfemale,MinigunAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MinigunAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MinigunAmmo]=150;	// The maximum Medium Female can carry
$ItemMax[marmor,MinigunAmmo]=150;	// The maximum Medium Male can carry
$ItemMax[harmor,MinigunAmmo]=0;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MinigunAmmo] = 0;
$ItemMax[BlastechF, MinigunAmmo] = 0;
$ItemMax[MagIonM, MinigunAmmo] = 150;
$ItemMax[MagIonF, MinigunAmmo] = 150;
$ItemMax[MECH, MinigunAmmo] = 0;

ItemData MinigunAmmo 
{ 
	description = "MiniGun Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.225, 0, 0 };
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MinigunAmmo; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupMinigun; 
	//sfxSpinUp = SoundSpinUp; 
	sfxSpinDown = SoundMiniDown; 
}; 

function MinigunImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[Minigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMinigun[%client]) MDCheckMinigun(%client, %player); 
} 

ItemData Minigun 
{ 
	description = "MiniGun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "cGatling Weapons";
	shadowDetailMask = 4; 
	imageType = MinigunImage; 
	price = 5000; 

	showWeaponBar = true; 
}; 

function Minigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, Minigun2, 0); 
		Item::onDrop(%player,%item); 
	} 
} 

function Minigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,Minigun2,$MinigunSlot); 
} 

function Minigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MinigunSlot); 
} 

ItemImageData Minigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 };
	mountOffset = { 0, 0, 0 };
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MinigunAmmo; 
	projectileType = MinigunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData Minigun2 
{ 
	description = "MiniGun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Minigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Minigun")) 
	{ 
		Player::trigger(%player,$MinigunSlot,true); 
		schedule("MDCheckMinigun(" @ %client @ "," @ %player @ ");",0.05); 
		$MDFiringMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MinigunSlot,false); 
		$MDFiringMinigun[%client] = false; 
	} 
} 

$MMinigunSlotA=4;
$MMinigunSlotB=5;
$MMinigunSlotC=6; 

addweapon(MMinigun);
$AutoUse[MMinigun] = True; 
$SellAmmo[MMinigunAmmo] = 50; 
$AmmoPackMax[MMinigunAmmo] = 75; 
$AmmoPackItems[14] = MMinigunAmmo; 
$WeaponAmmo[MMinigun] = MMinigunAmmo; 

$InvList[MMinigun]=1;	
$InvList[MMinigunAmmo]=1;
//$RemoteInvList[Minigun]=1;		// Some weapons are not available from remote inventory units
$RemoteInvList[MMinigunAmmo]=1;

$ItemMax[lfemale,MMinigun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMinigun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMinigun]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMinigun]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMinigun]=1;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMinigun] = 0;
$ItemMax[BlastechF, MMinigun] = 0;
$ItemMax[MagIonM, MMinigun] = 0;
$ItemMax[MagIonF, MMinigun] = 0;
$ItemMax[MECH, MMinigun] = 1;

$ItemMax[lfemale,MMinigunAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMinigunAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMinigunAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMinigunAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMinigunAmmo]=500;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMinigunAmmo] = 0;
$ItemMax[BlastechF, MMinigunAmmo] = 0;
$ItemMax[MagIonM, MMinigunAmmo] = 0;
$ItemMax[MagIonF, MMinigunAmmo] = 0;
$ItemMax[MECH, MMinigunAmmo] = 500;

ItemData MMinigunAmmo 
{ 
	description = "MMinigun Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MMinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.3051, -0.201, 0.251 }; 
	mountRotation = { 0, 1.501, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupminigun; 
	//sfxSpinUp = SoundSpinUp; 
	sfxSpinDown = SoundMiniDown; 
}; 

function MMinigunImage::onFire(%player, %slot) 

{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MMinigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMMinigun[%client]) MDCheckMMinigun(%client, %player); 
} 

ItemData MMinigun 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "cGatling Weapons";
	shadowDetailMask = 4; 
	imageType = MMinigunImage; 
	price = 7500; 
	showWeaponBar = true; 
}; 

function MMinigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MMinigun2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MMinigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MMinigun2,$MMinigunSlotA); 
	Player::mountItem(%player,MMinigun3,$MMinigunSlotB); 
	Player::mountItem(%player,MMinigun4,$MMinigunSlotC); 
} 

function MMinigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MMinigunSlotA);
	Player::unmountItem(%player,$MMinigunSlotB);	 
	Player::unmountItem(%player,$MMinigunSlotC);
} 

ItemImageData MMinigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.351, 0 }; 
	mountRotation = { 0, 1.01, 0}; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = MiniGunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun2 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MMinigun3Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.351, 0 }; 
	mountRotation = { 0, -1.01, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = ChaingunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun3 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MMinigun4Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 }; 
	mountRotation = { 0, -1.501, 0};  
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = ChaingunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun4 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MMinigun")) 
	{ 
		Player::trigger(%player,$MMinigunSlotA,true);
		Player::trigger(%player,$MMinigunSlotB,true);
		Player::trigger(%player,$MMinigunSlotC,true); 
		schedule("MDCheckMMinigun(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MMinigunSlotA,false); 
		Player::trigger(%player,$MMinigunSlotB,false); 
		Player::trigger(%player,$MMinigunSlotC,false); 
		$MDFiringMMinigun[%client] = false; 
	} 
} 

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
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

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


function GrenadeLauncherImage::onFire(%player, %slot) 
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

    if (!%playerId.GrenadeLauncher || %playerId.GrenadeLauncher == 0)
		{
		        %proj = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
            else if (%playerId.GrenadeLauncher == 1)
			{
		        %proj = Projectile::spawnProjectile("RPG",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);

             }
            else if (%playerId.GrenadeLauncher == 2)
			{
		        %proj = Projectile::spawnProjectile("ImplosionShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],10);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
         }
         else if (%playerId.GrenadeLauncher == 3)
		 {
			Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],3);
			%vel = EmplacementPack::rotVector( "10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "-10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 2 10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 50);
       }
       else
		Player::trigger(%player,$WeaponSlot,false);
}


//--------------------------------------------------------------------------------------------------------
// Mortar 
//--------------------------------------------------------------------------------------------------------

// Extra Aromrs to get a Mortar
$ItemMax[larmor, Mortar] = 1;
$ItemMax[larmor, MortarAmmo] = 3;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, MortarAmmo] = 4;
$ItemMax[lfemale, Mortar] = 1;
$ItemMax[lfemale, MortarAmmo] = 3;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, MortarAmmo] = 4;


ItemData EMPGrenadeAmmo
{
	description = "EMP Mortars";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

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
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

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
				//Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("ImpactMortarShell",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
			else if (%playerId.mortar == 1)
			{
				//Projectile::spawnProjectile("BettyShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("BettyShell",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
			else if (%playerId.mortar == 2)
			{
				//Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
            else if (%playerId.mortar == 3)   //  EMPGrenadeShell
			{
				//Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("EMPGrenadeShell",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
            else if (%playerId.mortar == 4)   //  ImpactMortarShell
			{                                      //  ImpactMortarShell
				//Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);
            }
            else if (%playerId.mortar == 5)   //  smokebomb
			{
				//Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
                %proj = Projectile::spawnProjectile("SmokeBombMortar",%trans,%player,%vel);
                Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
                %rot = GameBase::getRotation(%proj);
	            ApplyKickback(%player, %rot, 50);

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

////////////////////////////////////////////////////////////////////////////////
//  Defenders RunGun
//
////////////////////////////////////////////////////////////////////////////////
//--------------------------------------
//$AutoUse[DefendersRunGun] = True;

$InvList[DefendersRunGun] = 1;
$RemoteInvList[DefendersRunGun] = 1;

$ItemMax[lfemale,DefendersRunGun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,DefendersRunGun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,DefendersRunGun]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,DefendersRunGun]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,DefendersRunGun]=1;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, DefendersRunGun] = 0;
$ItemMax[BlastechF, DefendersRunGun] = 0;
$ItemMax[MagIonM, DefendersRunGun] = 0;
$ItemMax[MagIonF, DefendersRunGun] = 0;
$ItemMax[MECH, DefendersRunGun] = 0;

$DefendersRunGunSlotA=4;
$DefendersRunGunSlotB=5;
$DefendersRunGunSlotC=6;

addweapon(DefendersRunGun);

ItemImageData DefendersRunGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
    //weaponType = 0; // Spinning
    mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 1.501, 0 };
	weaponType = 1;
    //
    reloadTime = 0.8;
    spinUpTime = 0.5;
    spinDownTime = 0.5;
    fireTime = 0.8;
    //  Energy based weapon
    minEnergy = 15;
    maxEnergy = 6;
    //
    accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
    sfxFire = SoundFireDefRunGun;
    //sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickupminigun;
	//sfxSpinUp = SoundSpinUp;
	sfxSpinDown = MachmingunSpinDown;
};

function DefendersRunGunImage::onFire(%player, %slot)

{
	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[DefendersRunGun],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("RunGunRPG",%trans,%player,%vel,%player);
	if(!$MDRunFiringDefendersRunGun[%client]) MDRunCheckDefendersRunGun(%client, %player);
}

ItemData DefendersRunGun
{
	description = "Defenders RunGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = DefendersRunGunImage;
	price = 2500;
	showWeaponBar = true;
};

function DefendersRunGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),1,

		"Must have EnergyPack to use a Defenders RunGun.");
}

function DefendersRunGun::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
	{
		Player::setItemCount(%player, DefendersRunGun2, 0);
		Item::onDrop(%player,%item);
	}
}

function DefendersRunGun::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,DefendersRunGun2,$DefendersRunGunSlotA);
	Player::mountItem(%player,DefendersRunGun3,$DefendersRunGunSlotB);
	Player::mountItem(%player,DefendersRunGun4,$DefendersRunGunSlotC);
}

function DefendersRunGun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$DefendersRunGunSlotA);
	Player::unmountItem(%player,$DefendersRunGunSlotB);
	Player::unmountItem(%player,$DefendersRunGunSlotC);
}

ItemImageData DefendersRunGun2Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
    //weaponType = 0; // Spinning
    mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 1.01, 0};
	weaponType = 1;
    //
    reloadTime = 0.8;
    spinUpTime = 0.5;
    spinDownTime = 0.5;
    fireTime = 0.8;
    //  Energy based weapon
    minEnergy = 15;
    maxEnergy = 6;
    //
	projectileType = RunGunRPG;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
    sfxFire = SoundFireDefRunGun;
    //sfxFire = SoundFirePlasma;
};

ItemData DefendersRunGun2
{
	description = "Defenders RunGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = DefendersRunGun2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData DefendersRunGun3Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
    //weaponType = 0; // Spinning
    mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, -1.01, 0 };
	weaponType = 1;
    //
    reloadTime = 0.8;
    spinUpTime = 0.5;
    spinDownTime = 0.5;
    fireTime = 0.8;
    //  Energy based weapon
    minEnergy = 15;
    maxEnergy = 6;
    //
	projectileType = RunGunRPG;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
    sfxFire = SoundFireDefRunGun;
    //sfxFire = SoundFirePlasma;
};

ItemData DefendersRunGun3
{
	description = "Defenders RunGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = DefendersRunGun3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData DefendersRunGun4Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
    //weaponType = 0; // Spinning
    mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, -1.501, 0};
	weaponType = 1;
    //
    reloadTime = 0.8;
    spinUpTime = 0.5;
    spinDownTime = 0.5;
    fireTime = 0.8;
    //  Energy based weapon
    minEnergy = 15;
    maxEnergy = 6;
    //
	projectileType = RunGunRPG;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
    sfxFire = SoundFireDefRunGun;
    //sfxFire = SoundFirePlasma;
};

ItemData DefendersRunGun4
{
	description = "Defenders RunGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = DefendersRunGun4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

function MDRunCheckDefendersRunGun(%client, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "DefendersRunGun"))
	{
		Player::trigger(%player,$DefendersRunGunSlotA,true);
		Player::trigger(%player,$DefendersRunGunSlotB,true);
		Player::trigger(%player,$DefendersRunGunSlotC,true);
		schedule("MDRunCheckDefendersRunGun(" @ %client @ "," @ %player @ ");",0.1);
		$MDRunFiringDefendersRunGun[%client] = true;
	}
	else
	{
		Player::trigger(%player,$DefendersRunGunSlotA,false);
		Player::trigger(%player,$DefendersRunGunSlotB,false);
		Player::trigger(%player,$DefendersRunGunSlotC,false);
		$MDRunFiringDefendersRunGun[%client] = false;
	}
  }

////////////////////////////////////////////////////////////////////////////////
//  Shotgun
//
////////////////////////////////////////////////////////////////////////////////

$SellAmmo[ShotgunAmmo]			= 50;

$AmmoPackMax[ShotgunAmmo] = 50;
//$AmmoPackItems[10] = ShotgunAmmo;

$InvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;

$InvList[ShotgunAmmo] = 1;

$RemoteInvList[ShotgunAmmo] = 1;

$ItemMax[larmor, Shotgun] = 1;
$ItemMax[lfemale, Shotgun] = 1;
$ItemMax[marmor, Shotgun] = 1;
$ItemMax[mfemale, Shotgun] = 1;
$ItemMax[harmor, Shotgun] = 0;
$ItemMax[BlastechM, Shotgun] = 1;
$ItemMax[BlastechF, Shotgun] = 1;
$ItemMax[MagIonM, Shotgun] = 1;
$ItemMax[MagIonF, Shotgun] = 1;
$ItemMax[MECH, Shotgun] = 0;

$ItemMax[larmor, ShotgunAmmo] = 40;
$ItemMax[lfemale, ShotgunAmmo] = 40;
$ItemMax[marmor, ShotgunAmmo] = 40;
$ItemMax[mfemale, ShotgunAmmo] = 40;
$ItemMax[harmor, ShotgunAmmo] = 0;
$ItemMax[BlastechM, ShotgunAmmo] = 40;
$ItemMax[BlastechF, ShotgunAmmo] = 40;
$ItemMax[MagIonM, ShotgunAmmo] = 50;
$ItemMax[MagIonF, ShotgunAmmo] = 50;
$ItemMax[MECH, ShotgunAmmo] = 0;

ItemData ShotgunAmmo
{
	description = "Shotgun Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
  //heading = "zAmmo";
    heading = "zAmmo";
    shadowDetailMask = 4;
	price = 1;
};

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
    mountPoint = 0;

	ammoType = ShotgunAmmo;
    //projectileType = ShotgunBullet;
    weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 1.1;

	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireShotgun;
	//sfxReload   = SoundMortarReload;

};

ItemData Shotgun
{
    description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
    className = "Weapon";
    heading = "cGatling Weapons";
    //heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = ShotgunImage;
	showWeaponBar = true;
    price = 1000;
};

//$WeaponAmmo[Shotgun] = Shells;

AddWeapon(shotgun);

// onFire code updaated for kickback by -Defender   9-09-2002
function ShotgunImage::onFire(%player, %slot)
{
	Player::decItemCount(%player, ShotgunAmmo, 1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	for(%i=0; %i<16; %i++)
		%proj = Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);

	//ShotgunShellEject(%proj);
	%rot = GameBase::getRotation(%proj);
	ApplyKickback(%player, %rot, 25);
}

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
$SellAmmo[MultiMineAmmo]			= 2;
$AmmoPackMax[MultiMineAmmo]		= 2;

$AmmoPackItems[17] = MultiMineAmmo;

$InvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MultiMineAmmo] = 1;
$RemoteInvList[MultiMineAmmo] = 1;

$ItemMax[harmor, MineLauncher] = 1;
$ItemMax[harmor, MultiMineAmmo] = 10;
$ItemMax[larmor, MineLauncher] = 0;
$ItemMax[larmor, MultiMineAmmo] = 0;
$ItemMax[marmor, MineLauncher] = 1;
$ItemMax[marmor, MultiMineAmmo] = 3;
$ItemMax[lfemale, MineLauncher] = 0;
$ItemMax[lfemale, MultiMineAmmo] = 0;
$ItemMax[mfemale, MineLauncher] = 1;
$ItemMax[mfemale, MultiMineAmmo] = 3;
$ItemMax[BlastechM, MineLauncher] = 0;
$ItemMax[BlastechF, MineLauncher] = 0;
$ItemMax[MagIonM, MineLauncher] = 1;
$ItemMax[MagIonF, MineLauncher] = 1;
$ItemMax[MECH, MineLauncher] = 1;
$ItemMax[BlastechM, MultiMineAmmo] = 0;
$ItemMax[BlastechF, MultiMineAmmo] = 0;
$ItemMax[MagIonM, MultiMineAmmo] = 3;
$ItemMax[MagIonF, MultiMineAmmo] = 3;
$ItemMax[MECH, MultiMineAmmo] = 2;

//--------------------------------------------------------------------------------------------------------
// Implosion Cannon
//--------------------------------------------------------------------------------------------------------

ItemData IMPAmmo
{
	description = "Implosion Shells";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	price = 10;
};

$InvList[IMPAmmo] = 1;
$RemoteInvList[IMPAmmo] = 1;

$SellAmmo[IMPAmmo]			= 2;

$AmmoPackMax[IMPAmmo] = 2;
$AmmoPackItems[30] = IMPAmmo;

ItemImageData ImpImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = IMPAmmo;

	projectileType = ImplosionShell;
	accuFire = false;
	reloadTime = 0.75;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData ImpGun
{
	description = "Implosion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
        imageType = ImpImage;
	price = 7500;
	showWeaponBar = true;
};

addweapon(impgun);

$InvList[ImpGun] = 1;
$RemoteInvList[ImpGun] = 1;

$ItemMax[marmor, ImpGun] = 1;
$ItemMax[mfemale, ImpGun] = 1;
$ItemMax[larmor, ImpGun] = 0;
$ItemMax[lfemale, ImpGun] = 0;
$ItemMax[harmor, ImpGun] = 1;
$ItemMax[BlastechM, ImpGun] = 0;
$ItemMax[BlastechF, ImpGun] = 0;
$ItemMax[MagIonM, ImpGun] = 1;
$ItemMax[MagIonF, ImpGun] = 1;
$ItemMax[MECH, ImpGun] = 1;

$ItemMax[marmor, ImpAmmo] = 4;
$ItemMax[mfemale, ImpAmmo] = 4;
$ItemMax[larmor, ImpAmmo] = 0;
$ItemMax[lfemale, ImpAmmo] = 0;
$ItemMax[harmor, ImpAmmo] = 10;
$ItemMax[BlastechM, ImpAmmo] = 0;
$ItemMax[BlastechF, ImpAmmo] = 0;
$ItemMax[MagIonM, ImpAmmo] = 4;
$ItemMax[MagIonF, ImpAmmo] = 4;
$ItemMax[MECH, ImpAmmo] = 10;

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
	fireTime = 2.0;

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
$ItemMax[BlastechM, BabyNukeMortar] = 0;
$ItemMax[BlastechF, BabyNukeMortar] = 0;
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
    //projectileType = DiscShell;
    accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

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


function DiscLauncherImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

    if (!%playerId.DiscLauncher || %playerId.DiscLauncher == 0)
		{
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
            %proj = Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 35);
        }
		else if (%playerId.DiscLauncher == 1)
		{
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],2);
            %proj = Projectile::spawnProjectile("PowerDiscShell",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 105);
        }
        else if (%playerId.DiscLauncher == 2)
		{
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],5);
            %proj = Projectile::spawnProjectile("PowerDiscShell",%trans,%player,%vel);
            %proj = Projectile::spawnProjectile("PowerDiscShell2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 145);
         }
         else if (%playerId.DiscLauncher == 3)
		 {
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
			%vel = EmplacementPack::rotVector( "10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("DiscShellMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "-10 0 -10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("DiscShellMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 2 10", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("DiscShellMulti",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 105);
       }
       else
		Player::trigger(%player,$WeaponSlot,false);
}

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
	heading = "bWeapons"; 
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
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    Player::decItemCount(%player,TwinFusorAmmo,0.5);
    //Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,%player);
    %proj = Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
    ApplyKickback(%player, %rot, 145);
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
$SellAmmo[TwinFusorAmmo]			= 5;

$InvList[TwinFusor] = 1;
$RemoteInvList[TwinFusor] = 1;
$InvList[TwinFusorAmmo] = 1;
$RemoteInvList[TwinFusorAmmo] = 1;

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

$ItemMax[harmor, TwinFusorAmmo] = 40;
$ItemMax[marmor, TwinFusorAmmo] = 14;
$ItemMax[mfemale, TwinFusorAmmo] = 14;
$ItemMax[larmor, TwinFusorAmmo] = 10;
$ItemMax[lfemale, TwinFusorAmmo] = 10;
$ItemMax[BlastechM, TwinFusorAmmo] = 0;
$ItemMax[BlastechF, TwinFusorAmmo] = 0;
$ItemMax[MagIonM, TwinFusorAmmo] = 14;
$ItemMax[MagIonF, TwinFusorAmmo] = 14;
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

////////////////////////////////////////////////////////////////////////////////
//  MECHSHB
//
////////////////////////////////////////////////////////////////////////////////


$MrpgSlotA=4;
$MrpgSlotB=5;
$MrpgSlotC=6; 

$AutoUse[MrpgLauncher] = True; 
$SellAmmo[MrpgAmmo] = 64; 
$AmmoPackMax[MrpgAmmo] = 64; 
$AmmoPackItems[19] = MrpgAmmo; 
$WeaponAmmo[MrpgLauncher] = MrpgAmmo; 

$InvList[MrpgLauncher]=1;	
$InvList[MrpgAmmo]=1;
$RemoteInvList[MrpgAmmo]=1;

$ItemMax[lfemale,MrpgLauncher] = 0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgLauncher] = 0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgLauncher] = 0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgLauncher] = 0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgLauncher] = 1;	// The maximum Heavy of either sex can carry
$ItemMax[MagIonM, MrpgLauncher] = 0;
$ItemMax[MagIonF, MrpgLauncher] = 0;
$ItemMax[MECH, MrpgLauncher] = 1;
$ItemMax[BlastechF, MrpgLauncher] = 0;
$ItemMax[BlastechM, MrpgLauncher] = 0;

$ItemMax[lfemale,MrpgAmmo] = 0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgAmmo] = 0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgAmmo] = 0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgAmmo] = 0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgAmmo] = 256;	// The maximum Heavy of either sex can carry 
$ItemMax[MagIonM, MrpgAmmo] = 0;
$ItemMax[MagIonF, MrpgAmmo] = 0;
$ItemMax[MECH, MrpgAmmo] = 128;
$ItemMax[BlastechF, MrpgAmmo] = 0;
$ItemMax[BlastechM, MrpgAmmo] = 0;

ItemData MrpgAmmo 
{ 
	description = "Blaster Cartridges"; 
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
	reloadTime = 0.4; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
	ammoType = MrpgAmmo; 
	accuFire = true; 
	sfxFire = SoundPlasmaTurretFire; 
	sfxActivate = SoundPickupminigun; 
	sfxReady = SoundMiniDown; 
}; 

function MrpgLauncherImage::onFire(%player, %slot) 
{ 
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Player::decItemCount(%player,Mrpgammo,1); 

	//Projectile::spawnProjectile("SuperBlaster",%trans,%player,%vel,%player);
    %proj = Projectile::spawnProjectile("SuperBlaster",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
	ApplyKickback(%player, %rot, 50);

    if(!$MDFiringMrpgLauncher[%client]) MDCheckMrpgLauncher(%client, %player);
}

addweapon(mrpgLauncher);

ItemData MrpgLauncher 
{ 
	description = "MECHSHB"; 
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
	projectileType = SuperBlaster; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 

}; 

ItemData MrpgLauncher2 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MrpgLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MrpgLauncher3Image 

{ 
	ammoType = MrpgAmmo; 
	projectileType = SuperBlaster; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 


}; 

ItemData MrpgLauncher3 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MrpgLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData MrpgLauncher4Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = SuperBlaster; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 
	fireTime = 0.1;

}; 

ItemData MrpgLauncher4 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
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
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

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

$ItemMax[larmor, RPMLauncher] = 0;
$ItemMax[lfemale, RPMLauncher] = 0;
$ItemMax[marmor, RPMLauncher] = 0;
$ItemMax[mfemale, RPMLauncher] = 0;
$ItemMax[harmor, RPMLauncher] = 1;
$ItemMax[BlastechF, RPMLauncher] = 0;
$ItemMax[BlastechM, RPMLauncher] = 0;
$ItemMax[MagIonM, RPMLauncher] = 0;
$ItemMax[MagIonF, RPMLauncher] = 0;
$ItemMax[MECH, RPMLauncher] = 1;

//--------------------------------------------------------------------------------------------------------
// Rocket Propelled ElectroMagneticPulse (RPEMP)
//--------------------------------------------------------------------------------------------------------

ItemData RPEMPAmmo
{
	description = "RPEMP Ammo";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RPEMPImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPGrenadeAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

function RPEMPImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPEMPLauncher]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($RPEMPUseMTPack) 
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
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);


			}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
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
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"~wmine_act.wav");
						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
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
					Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					%name = Client::getName(%targetId);
					SendLockWarning(%targetId,0);
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
				Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPEMPLauncher
{
	description = "RPEMP";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPEMPImage; 
	price = 1600;
	showWeaponBar = true;
};

$AutoUse[RPEMPLauncher]			= True;

AddWeapon(rpemplauncher);

$InvList[RPEMPLauncher] = 1;
$RemoteInvList[RPEMPLauncher] = 1;

$ItemMax[larmor, RPEMPLauncher] = 0;
$ItemMax[lfemale, RPEMPLauncher] = 0;
$ItemMax[marmor, RPEMPLauncher] = 0;
$ItemMax[mfemale, RPEMPLauncher] = 0;
$ItemMax[harmor, RPEMPLauncher] = 1;
$ItemMax[BlastechF, RPEMPLauncher] = 0;
$ItemMax[BlastechM, RPEMPLauncher] = 0;
$ItemMax[MagIonM, RPEMPLauncher] = 0;
$ItemMax[MagIonF, RPEMPLauncher] = 0;
$ItemMax[MECH, RPEMPLauncher] = 1;

//=============================================================================================\\

//--------------------
RocketData MRocketMiniRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 14.5;
   kickBackStrength = 120.0; //200.0;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 15;

   soundId = SoundJetHeavy;
};


$MRocketgunSlotA=4;
$MRocketgunSlotB=5;
$MRocketgunSlotC=6; 

addweapon(MECHRocketLauncher);
$InvList[MECHRocketLauncher]			= 1;	
$RemoteInvList[MECHRocketLauncher]		= 1;
$AutoUse[MECHRocketLauncher]			= True;

$WeaponAmmo[MECHRocketLauncher]                  = MissileAmmo;
$AmmoPackMax[MissileAmmo] 		= 8; 
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
	reloadTime = 1.5; 
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
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	Player::decItemCount(%player,$WeaponAmmo[MECHRocketLauncher],0);

	//Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,%player);
    %proj = Projectile::spawnProjectile("MRocketMiniRocket",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
	ApplyKickback(%player, %rot, 150);
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
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
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
	maxEnergy	= 6;
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
	projectileType = MRocketMiniRocket;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
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
// Juggalo Electro-Optical Missile Launcher
//--------------------------------------------------------------------------------------------------------

ItemData JugAmmo
{
	description = "Juggalo Missiles";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData JugLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	ammoType = JugAmmo;
	reloadTime = 0.5;
	fireTime = 5.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData JugLauncher 
{
	description = "Juggalo Laucher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "fear";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = JugLauncherImage;
	price = 15200;
	showWeaponBar = true;
};

function JugLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "<f0>Juggalo Electro-Optical Missile Launcher: <f2>When you fire it, be sure to control it immediately.\n<f1>*WARNING*<f2> Do not fire while in the air or inside a small or enclosed building.");
}

function JugLauncherImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);
    %obj = getObjectType($los::object);

	 if(!%player.vehicle)
	 {
	  %rot = GameBase::getRotation(%client);
	  %posX = getWord(%trans,9);
	  %posY = getWord(%trans,10);
	  %posZ = getWord(%trans,11) + 5.0;
	  %position = %posX@" "@%posY@" "@%posZ;

     %obj = newObject("Juggalo Electro-Optical Missile",flier,EOMissile,true);
      addToSet("MissionCleanup",%obj);
      GameBase::setTeam(%obj,GameBase::getTeam(%this));
	  GameBase::setPosition(%obj,%position);
      GameBase::setRotation(%obj,%rot);
      Gamebase::setMapName(%obj,"Juggalo Electro-Optical Missile");
      GameBase::startFadeIn(%obj);
      Client::setControlObject(%client,%obj);
      %this.vehicle = %obj;
	if(!Player::isDead(%this)) Player::decItemCount(%client,JugAmmo,1);
      %this.lastWeapon = %weapon;
	  Player::unMountItem(%this,$WeaponSlot);
	 }
}

$InvList[JugLauncher] = 1;
$RemoteInvList[JugLauncher] = 1;

$InvList[JugAmmo] = 1;
$RemoteInvList[JugAmmo] = 1;

$SellAmmo[JugAmmo]			= 15;

$AmmoPackMax[JugAmmo] = 15;
$AmmoPackItems[28] = JugAmmo;

$ItemMax[harmor, JugLauncher] = 1;
$ItemMax[larmor, JugLauncher] = 0;
$ItemMax[marmor, JugLauncher] = 0;
$ItemMax[lfemale, JugLauncher] = 0;
$ItemMax[mfemale, JugLauncher] = 0;
$ItemMax[BlastechF, JugLauncher] = 0;
$ItemMax[BlastechM, JugLauncher] = 0;
$ItemMax[MagIonM, JugLauncher] = 0;
$ItemMax[MagIonF, JugLauncher] = 0;
$ItemMax[MECH, JugLauncher] = 1;

$ItemMax[harmor, JugAmmo] = 5;
$ItemMax[larmor, JugAmmo] = 0;
$ItemMax[marmor, JugAmmo] = 0;
$ItemMax[lfemale, JugAmmo] = 0;
$ItemMax[mfemale, JugAmmo] = 0;
$ItemMax[BlastechF, JugAmmo] = 0;
$ItemMax[BlastechM, JugAmmo] = 0;
$ItemMax[MagIonM, JugAmmo] = 0;
$ItemMax[MagIonF, JugAmmo] = 0;
$ItemMax[MECH, JugAmmo] = 3;

addweapon(juglauncher);

//--------------------------------------------------------------------------------------------------------
// Laser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserPistolImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.25;
	minEnergy = 10;
	maxEnergy = 30;

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

$ItemMax[larmor, LaserPistol] = 1;
$ItemMax[marmor, LaserPistol] = 1;
$ItemMax[lfemale, LaserPistol] = 1;
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
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
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
	description = "Laser Rifle";
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
	minEnergy = 10;
	maxEnergy = 80;
      projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 6.5;
	
    sfxFire = SoundPBWFire;
    //sfxFire = SoundPBWBreakSoundBarrier;
	sfxActivate = SoundDryFire;
	sfxReload = SoundPBWcharge;
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

//$WeaponAmmo[LasCannon] = "Beacon";

//$AutoUse[LasCannon]			= True;

//AddWeapon(LasCannon);

//$InvList[LasCannon] = 1;
//$RemoteInvList[LasCannon] = 1;

//$ItemMax[harmor, LasCannon] = 1;
//$ItemMax[marmor, LasCannon] = 0;
//$ItemMax[mfemale, LasCannon] = 0;
//$ItemMax[larmor, LasCannon] = 0;
//$ItemMax[lfemale, LasCannon] = 0;
//$ItemMax[BlastechF, LasCannon] = 0;
//$ItemMax[BlastechM, LasCannon] = 0;
//$ItemMax[MagIonM, LasCannon] = 0;
//$ItemMax[MagIonF, LasCannon] = 0;
//$ItemMax[MECH, LasCannon] = 1;

//ItemImageData LasCannonImage
//{
//	shapeFile = "mortargun";
//	mountPoint = 0;
//	weaponType = 0;
//	accuFire = true;
//	reloadTime = 0.1;
//	fireTime = 0.5;
//	minEnergy = 10;
//	maxEnergy = 140;
//	lightType = 3;
//	lightRadius = 2;
//	lightTime = 1;
//	lightColor = { 1, 0, 0 };
//	mass = 2.5;
//	sfxFire = SoundFireLaser;
//	sfxActivate = SoundPickUpWeapon;
//};

//ItemData LasCannon
//{
//	description = "Death Ray";
//	className = "Weapon";
//	shapeFile = "mortargun";
//	hudIcon = "sniper";
//   	heading = "fBeam Weapons";
//	shadowDetailMask = 4;
//	imageType = LasCannonImage;
//	price = 5000;
//	mass = 2.5;
//	showWeaponBar = true;
//
//};


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
    	damageValue = 0.8; 
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


//--------------------------------------------------------------------------------------------------------
// Poison Dart Rifle
//--------------------------------------------------------------------------------------------------------

ItemData Darts
{
	description = "Poison Darts";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData DartGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Darts;
	//projectileType = PoisonDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData DartGun
{
	description = "Poison Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = DartGunImage;
	price = 300;
	showWeaponBar = true;
};

$SellAmmo[Darts]			= 20;

AddWeapon(dartgun);

function DartGunImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    Player::decItemCount(%player,Darts,1);

    %proj = Projectile::spawnProjectile("PoisonDart",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
    ApplyKickback(%player, %rot, 25);
}

$InvList[DartGun] = 1;
$RemoteInvList[DartGun] = 1;

$AmmoPackMax[Darts] = 30;
$AmmoPackItems[22] = Darts;

$InvList[Darts] = 1;
$RemoteInvList[Darts] = 1;

$ItemMax[larmor, DartGun] = 1;
$ItemMax[lfemale, DartGun] = 1;
$ItemMax[marmor, DartGun] = 1;
$ItemMax[mfemale, DartGun] = 1;
$ItemMax[harmor, DartGun] = 0;
$ItemMax[BlastechF, DartGun] = 1;
$ItemMax[BlastechM, DartGun] = 1;
$ItemMax[MagIonM, DartGun] = 1;
$ItemMax[MagIonF, DartGun] = 1;
$ItemMax[MECH, DartGun] = 0;

$ItemMax[larmor, Darts] = 25;
$ItemMax[lfemale, Darts] = 25;
$ItemMax[marmor, Darts] = 30;
$ItemMax[mfemale, Darts] = 30;
$ItemMax[harmor, Darts] = 0;
$ItemMax[BlastechF, Darts] = 15;
$ItemMax[BlastechM, Darts] = 15;
$ItemMax[MagIonM, Darts] = 20;
$ItemMax[MagIonF, Darts] = 20;
$ItemMax[MECH, Darts] = 0;

ItemData Shells
{
	description = "Shells";
	className = "Ammo";
    heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};


//--------------------------------------------------------------------------------------------------------
// Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData RifleRailGun2Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.15 };

	weaponType = 0; // Single Shot
	ammoType = Shells;
	//projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.5;
};

ItemData RifleRailGun2
{
	description = "MD-1024";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RifleRailGun2Image;
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
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	weaponType = 2; // Single Shot
	projectileType = RailLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 0;
	maxEnergy = 0;

	sfxActivate = SoundPickUpWeapon;
};

ItemData scope
{
	description = "MD-1024";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ScopeImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

function Rifle::onMount(%player,%imageSlot)
{
    Player::mountItem(%player,scope,$ExtraSlot);
	Player::mountItem(%player,RifleRailGun2,$ExtraWeaponSlot);
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
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Shells;
	//projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Rifle
{
	description = "MD-1024";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
    heading = "gRifles";
	shadowDetailMask = 4;
	imageType = RifleImage;
	price = 600;
	showWeaponBar = true;
};

$SellAmmo[Shells]			= 50;

$AmmoPackMax[Shells] = 50;
$AmmoPackItems[23] = Shells;

AddWeapon(rifle);

function RifleImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

    if (!%playerId.Rifle || %playerId.Rifle == 0)
		{
            Player::decItemCount(%player,Shells,1);
            %proj = Projectile::spawnProjectile("RifleBullet",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 25);
        }
        else if (%playerId.Rifle == 1)  // Mase
		{
            Player::decItemCount(%player,Shells,1);
            %proj = Projectile::spawnProjectile("MassBullet",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
            ApplyKickback(%player, %rot, 45);
        }
        else if (%playerId.Rifle == 2)  // HP
		{
            Player::decItemCount(%player,Shells,1);
            %proj = Projectile::spawnProjectile("sniperXBullet",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
            ApplyKickback(%player, %rot, 45);
        }
        else if (%playerId.Rifle == 3)  // EMP
		{
            Player::decItemCount(%player,Shells,1);
            %proj = Projectile::spawnProjectile("RailRound2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
            ApplyKickback(%player, %rot, 45);

	}
	else
		Player::trigger(%player,$WeaponSlot,false);
}

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

$ItemMax[larmor, Shells] = 25;
$ItemMax[lfemale, Shells] = 25;
$ItemMax[marmor, Shells] = 25;
$ItemMax[mfemale, Shells] = 25;
$ItemMax[harmor, Shells] = 50;
$ItemMax[BlastechF, Shells] = 15;
$ItemMax[BlastechM, Shells] = 15;
$ItemMax[MagIonM, Shells] = 25;
$ItemMax[MagIonF, Shells] = 25;
$ItemMax[MECH, Shells] = 25;

//--------------------------------------------------------------------------------------------------------
// Mass Driver
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
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Bolts;
	//projectileType = MassBullet;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;

};

ItemData MassDriver
{
	description = "Mass Driver";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = MassDriverImage;
	price = 1200;
	showWeaponBar = true;
};

$SellAmmo[Bolts]			= 20;
$AmmoPackMax[Bolts] = 7;
$AmmoPackItems[25] = Bolts;

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;

AddWeapon(massdriver);

function MassDriverImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    Player::decItemCount(%player,Bolts,1);

    %proj = Projectile::spawnProjectile("MassBullet",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
    ApplyKickback(%player, %rot, 45);
}

$InvList[Bolts] = 1;
$RemoteInvList[Bolts] = 1;

$ItemMax[larmor, MassDriver] = 1;
$ItemMax[lfemale, MassDriver] = 1;
$ItemMax[marmor, MassDriver] = 1;
$ItemMax[mfemale, MassDriver] = 1;
$ItemMax[harmor, MassDriver] = 1;
$ItemMax[BlastechF, MassDriver] = 1;
$ItemMax[BlastechM, MassDriver] = 1;
$ItemMax[MagIonM, MassDriver] = 0;
$ItemMax[MagIonF, MassDriver] = 0;
$ItemMax[MECH, MassDriver] = 1;

$ItemMax[larmor, Bolts] = 25;
$ItemMax[lfemale, Bolts] = 25;
$ItemMax[marmor, Bolts] = 25;
$ItemMax[mfemale, Bolts] = 25;
$ItemMax[harmor, Bolts] = 30;
$ItemMax[BlastechF, Bolts] = 20;
$ItemMax[BlastechM, Bolts] = 20;
$ItemMax[MagIonM, Bolts] = 0;
$ItemMax[MagIonF, Bolts] = 0;
$ItemMax[MECH, Bolts] = 30;

//--------------------------------------------------------------------------------------------------------
// AAOD SniperX
//--------------------------------------------------------------------------------------------------------

ItemData SXAmmo
{
	description = "HP Shots";
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
	mountRotation = { 0,-1.57, 0 };

	weaponType = 0;
      //projectileType = sniperXBullet;
	ammoType = SXAmmo;
	accuFire = true;
	fireTime = 1.5;
	reloadTime = 0;
	sfxFire = SoundFireSniperX;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AAODSniperX
{
	description = "HP Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
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

function SXImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    Player::decItemCount(%player,SXAmmo,1);

    %proj = Projectile::spawnProjectile("sniperXBullet",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
    ApplyKickback(%player, %rot, 45);
}


$ItemMax[larmor, AAODSniperX] = 1;
$ItemMax[lfemale, AAODSniperX] = 1;
$ItemMax[marmor, AAODSniperX] = 1;
$ItemMax[mfemale, AAODSniperX] = 1;
$ItemMax[harmor, AAODSniperX] = 0;
$ItemMax[BlastechF, AAODSniperX] = 0;
$ItemMax[BlastechM, AAODSniperX] = 0;
$ItemMax[MagIonM, AAODSniperX] = 1;
$ItemMax[MagIonF, AAODSniperX] = 1;
$ItemMax[MECH, AAODSniperX] = 1;

$ItemMax[larmor, SXAmmo] = 25;
$ItemMax[lfemale, SXAmmo] = 25;
$ItemMax[marmor, SXAmmo] = 30;
$ItemMax[mfemale, SXAmmo] = 30;
$ItemMax[harmor, SXAmmo] = 0;
$ItemMax[BlastechF, SXAmmo] = 0;
$ItemMax[BlastechM, SXAmmo] = 0;
$ItemMax[MagIonM, SXAmmo] = 25;
$ItemMax[MagIonF, SXAmmo] = 25;
$ItemMax[MECH, SXAmmo] = 30;

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
	reloadTime = 0.2;
                        
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
// Power Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData ElectricityRifleImage
{
	shapeFile = "disc";
   mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

   weaponType = 2;  // Sustained
	projectileType = PowerCharge;
   minEnergy = 1;

  maxEnergy = 10;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData ElectricityRifle
{
   description = "Power Gun";
	shapeFile = "disc";
	hudIcon = "energyRifle";
   className = "Tool";
   heading = "jTools";
   shadowDetailMask = 4;
   imageType = ElectricityRifleImage;
	showWeaponBar = true;
   price = 500;
};

$InvList[ElectricityRifle] = 1;
$RemoteInvList[ElectricityRifle] = 1;

AddWeapon(ElectricityRifle);

$ItemMax[larmor, ElectricityRifle] = 1;
$ItemMax[lfemale, ElectricityRifle] = 1;
$ItemMax[marmor, ElectricityRifle] = 1;
$ItemMax[mfemale, ElectricityRifle] = 1;
$ItemMax[harmor, ElectricityRifle] = 1;
$ItemMax[BlastechF, ElectricityRifle] = 1;
$ItemMax[BlastechM, ElectricityRifle] = 1;
$ItemMax[MagIonM, ElectricityRifle] = 1;
$ItemMax[MagIonF, ElectricityRifle] = 1;
$ItemMax[MECH, ElectricityRifle] = 1;

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
	//projectileType = reassemblerBolt;
    projectileType = RepairBolt;
    accuFire = true;
	minEnergy = 2;
	maxEnergy = 5;
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

$AutoUse[Reassembler]			= True;

AddWeapon(reassembler);

$InvList[Reassembler] = 1;
$RemoteInvList[Reassembler] = 1;

if ($Meltdown::AllArmorsUseReassembler)
{
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
}
else
{
$ItemMax[larmor, Reassembler] = 0;
$ItemMax[lfemale, Reassembler] = 0;
$ItemMax[marmor, Reassembler] = 1;
$ItemMax[mfemale, Reassembler] = 1;
$ItemMax[harmor, Reassembler] = 0;
$ItemMax[BlastechF, Reassembler] = 0;
$ItemMax[BlastechM, Reassembler] = 0;
$ItemMax[MagIonM, Reassembler] = 1;
$ItemMax[MagIonF, Reassembler] = 1;
$ItemMax[MECH, Reassembler] = 0;
}

//--------------------------------------------------------------------------------------------------------
// RailGun
//--------------------------------------------------------------------------------------------------------

ItemData RailGunAmmo
{
	description = "RailGun";
	className = "Ammo";
	shapeFile = "ammo1";
  //heading = "zAmmo";
    heading = "xAmmunition";
    shadowDetailMask = 4;
	price = 1;
};
ItemImageData RailGunImage
{
	shapeFile = "sniper"; // was paintgun
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RailGunAmmo;
	projectileType = RailRound;
    accuFire = true;
    reloadTime = 0.8;
    fireTime = 0.6;
    lightType = 3;
    lightRadius = 6;
    lightTime = 2;
    lightColor = { 1.0, 0, 0 };
    sfxFire = SoundMissileTurretFire;
    sfxActivate = SoundPickUpWeapon;
    sfxSpinUp = SoundSpinUp;
    sfxSpinDown = SoundSpinDown;
};

ItemData RailGun
{
	description = "RailGun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
    heading = "gRifles";
	shadowDetailMask = 4;
	imageType = RailGunImage;
	price = 600;
	showWeaponBar = true;
};

$InvList[RailGun] = 1;
$RemoteInvList[RailGun] = 1;
$InvList[RailGunAmmo] = 1;
$RemoteInvList[RailGunAmmo] = 1;

AddWeapon(RailGun);

$ItemMax[larmor, RailGun] = 1;
$ItemMax[lfemale, RailGun] = 1;
$ItemMax[marmor, RailGun] = 1;
$ItemMax[mfemale, RailGun] = 1;
$ItemMax[harmor, RailGun] = 1;
$ItemMax[BlastechM, RailGun] = 0;
$ItemMax[BlastechF, RailGun] = 0;
$ItemMax[MagIonM, RailGun] = 1;
$ItemMax[MagIonF, RailGun] = 1;
$ItemMax[MECH, RailGun] = 1;

$ItemMax[larmor, RailGunAmmo] = 25;
$ItemMax[lfemale, RailGunAmmo] = 25;
$ItemMax[marmor, RailGunAmmo] = 25;
$ItemMax[mfemale, RailGunAmmo] = 25;
$ItemMax[harmor, RailGunAmmo] = 50;
$ItemMax[BlastechF, RailGunAmmo] = 15;
$ItemMax[BlastechM, RailGunAmmo] = 15;
$ItemMax[MagIonM, RailGunAmmo] = 25;
$ItemMax[MagIonF, RailGunAmmo] = 25;
$ItemMax[MECH, RailGunAmmo] = 20;


//--------------------------------------------------------------------------------------------------------
// Maser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData MaserI
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ParticleMaser;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.5;
	minEnergy = 40;
	maxEnergy = 80;

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

$ItemMax[larmor, MaserRifle] = 1;
$ItemMax[lfemale, MaserRifle] = 1;
$ItemMax[marmor, MaserRifle] = 1;
$ItemMax[mfemale, MaserRifle] = 1;
$ItemMax[harmor, MaserRifle] = 1;
$ItemMax[BlastechM, MaserRifle] = 1;
$ItemMax[BlastechF, MaserRifle] = 1;
$ItemMax[MagIonM, MaserRifle] = 1;
$ItemMax[MagIonF, MaserRifle] = 1;
$ItemMax[MECH, MaserRifle] = 1;

AddWeapon(MaserRifle);

//----------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------
// Plasma Gun
//--------------------------------------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "zAmmo";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
    //projectileType = "PlasmaBolt2";
    accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

    lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function MassDriverImage::onFire(%player, %slot)
{
    %playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
    Player::decItemCount(%player,Bolts,1);

    %proj = Projectile::spawnProjectile("MassBullet",%trans,%player,%vel);
    %rot = GameBase::getRotation(%proj);
    ApplyKickback(%player, %rot, 25);
}

function PlasmaGunImage::onFire(%player, %slot)
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
     %playerId = Player::getClient(%player);
	 if(%Ammo)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     	 %vel = Item::getVelocity(%player);

		if (!%playerId.Plasma || %playerId.Plasma == 0)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%proj = Projectile::spawnProjectile("PlasmaBolt2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 15);
        }
		else if (%playerId.Plasma == 1)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%proj = Projectile::spawnProjectile("PlasmaBoltRapid",%trans,%player,%vel);
			%proj = Projectile::spawnProjectile("PlasmaBoltRapid2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 15);
        }
		else if (%playerId.Plasma == 2)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%vel = EmplacementPack::rotVector( "15 0 -15", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "-15 0 -15", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 2 15", GameBase::getRotation(%player));
			%proj = Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 15);
        }
        else if (%playerId.Plasma == 3)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);

			%proj = Projectile::spawnProjectile("PlasmaHeatBolt",%trans,%player,%vel);
            %proj = Projectile::spawnProjectile("PlasmaHeatBolt2",%trans,%player,%vel);
            %rot = GameBase::getRotation(%proj);
	        ApplyKickback(%player, %rot, 15);
        }
	}	//=== End standard plasma fire.
}

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "iHeat Effect Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

AddWeapon(PlasmaGun);

//$WeaponAmmo[PlasmaCannon] = "Beacon";

//AddWeapon(plasmacannon);

//$InvList[PlasmaCannon] = 1;
//$RemoteInvList[PlasmaCannon] = 1;

//$ItemMax[harmor, PlasmaCannon] = 1;
//$ItemMax[larmor, PlasmaCannon] = 0;
//$ItemMax[marmor, PlasmaCannon] = 0;
//$ItemMax[lfemale, PlasmaCannon] = 0;
//$ItemMax[mfemale, PlasmaCannon] = 0;
//$ItemMax[BlastechM, PlasmaCannon] = 0;
//$ItemMax[BlastechF, PlasmaCannon] = 0;
//$ItemMax[MagIonM, PlasmaCannon] = 0;
//$ItemMax[MagIonF, PlasmaCannon] = 0;
//$ItemMax[MECH, PlasmaCannon] = 1;

//ItemImageData PlasmaCannonImage
//{
//	shapeFile = "mortargun";
//	mass = 2;
//	mountPoint = 0;
//	mountRotation = { 0, 0, 0 };
//	weaponType = 0;
///	accuFire = true;
//	reloadTime = 0.1;
///	fireTime = 0.5;
//	minEnergy = 10;
//	maxEnergy = 70;
//	lightType = 3;
//	lightRadius = 2;
//	lightTime = 1;
//	lightColor = { 1, 0, 0 };
//	sfxFire = SoundFireMortar;
//	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
//	sfxReady = SoundMortarIdle;
//};

//ItemData PlasmaCannon
//{
//	description = "Plasma Cannon";
//	className = "Weapon";
//	shapeFile = "mortargun";
//	hudIcon = "sniper";
//   	heading = "iHeat Effect Weapons";
//	shadowDetailMask = 4;
//	imageType = PlasmaCannonImage;
//	price = 12800;
//	showWeaponBar = true;
//	mass = 2.5;
//};

function PlasmaCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	
	if (%clientId.plasmacharge)
	{
		%clientId.charging = "";
		%lc = %clientId.plasmacharge;
		
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.39);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.425);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.475);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);		
		}
		
		if (%lc == 15)
		{
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"0\");",0.2);
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"1\");",0.63);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.65);
		}
			%fired.deployer = %client;

		%clientId.plasmacharge = "0";
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** Plasma Cannon uses beacons to charge... ~waccess_denied.wav");
		return;
	}
}

function PlasmaCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	

	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
                BottomPrint (%clientId, "** " @ %time @ " before full charge ", 1);
		%clientId.plasmacharge++;
		return;
	}
	else
	{
		BottomPrint (%clientId, "** Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Plasma Cannon may overload... ETA: 30 seconds"  , 5);
		%clientId.plasmacharge = 15;
		PlasmaCannoner::Detonate(%clientId, 30);
		return;
	}
}

function PlasmaCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);
	
	if (%clientId.plasmacharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else
	{
		%clientId.charging = "";
		%clientId.plasmacharge = "0";
		Player::blowUp(%clientId);
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
  		GameBase::applyDamage(%player, $DebrisDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %clientId);
		return;
	}
	if (%time > 0 && %time < 25)
	{
		bottomprint (%clientId, "<jc>** ETA to overload: " @ %time @ " seconds", 1);
	}
}

RocketData PlasmaCannonBolt
{ 
	bulletShapeName = "plasmaex.dts"; 
	explosionTag = plasmaExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.8; 
	damageType = $PlasmaDamageType;
	explosionRadius = 15; 
	kickBackStrength = 0.0; 
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 45.0;
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.0, 0.05 }; 
	inheritedVelocityScale = 0.0; 
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonBolt2

{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = plasmaExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.5; 
	damageType = $PlasmaDamageType;
	explosionRadius = 10; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 35.0; 
	terminalVelocity = 45.0;
	acceleration = 35; 
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 2.0, 0.0, 0.0 }; 
	inheritedVelocityScale = 0.0; 
	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 180.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock
{
	bulletShapeName  = "plasmabolt.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 140.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock2
{
	bulletShapeName  = "plasmaex.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 65.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 160.0;
	soundId = SoundJetHeavy;
};


function PlasmaConnonShock2Fire(%trans, %player, %vel, %client, %num)
{
	%fired = (Projectile::spawnProjectile(PlasmaCannonShock2, %trans,%player,%vel));
	%fired.deployer = %client;
	
	if (%num == 0)
	{
		$Plasma[0] = %fired;
	}

	if (%num == 1)
	{
		%boom = $Plasma[0];
		$Plasma[%boom] = %fired;
	}
	
}

function PlasmaCannonShock2::OnRemove(%this)
{
	%boom = $Plasma[%this];
	
	if (%boom)
	{
		DeployFrags(%boom, 10, %boom.deployer);
		DeployFrags(%boom, 10, %boom.deployer);	
	}
}

function PlasmaCannonShock2::Blast(%this)
{
	DeployFrags(%this, 10, %this.deployer);
}

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
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;
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
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;
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
	explosionRadius		= 15.0;
	kickBackStrength	= 75.0;
	muzzleVelocity		= 25.0;
	terminalVelocity	= 25.0;
	acceleration		= 1.0;
	totalTime			= 22.0;
	liveTime			= 23.0;
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
	lightRadius = 1;
	lightTime   = 1;
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


//--------------------------------------------------------------------------------------------------------
// Pull Beam
//--------------------------------------------------------------------------------------------------------

$InvList[StrykerChain]			= 1;
$RemoteInvList[StrykerChain]		= 1;

$ItemMax[larmor,StrykerChain]	= 0;
$ItemMax[lfemale,StrykerChain]	= 0;
$ItemMax[marmor,StrykerChain]	= 1;
$ItemMax[mfemale,StrykerChain]	= 1;
$ItemMax[harmor,StrykerChain]	= 1;
$ItemMax[BlastechF, StrykerChain] = 0;
$ItemMax[BlastechM, StrykerChain] = 0;
$ItemMax[MagIonM, StrykerChain] = 1;
$ItemMax[MagIonF, StrykerChain] = 1;
$ItemMax[MECH, StrykerChain] = 1;

ItemImageData Pull
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = tractorCharge;
   minEnergy = 3;
   maxEnergy = 10;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;

   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundSensorPower;
};

ItemData StrykerChain
{
   description = "Pull Beam";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "jTools";
   shadowDetailMask = 4;
   imageType = Pull;
	showWeaponBar = true;
   price = 1500;
};


