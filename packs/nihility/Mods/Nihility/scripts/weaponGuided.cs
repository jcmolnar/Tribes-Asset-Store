//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Guided);
$InvList[Guided] = 1;
$InvList[RocketAmmo] = 1;

$AutoUse[Guided] = True;
$WeaponAmmo[Guided] = RocketAmmo;

$SellAmmo[RocketAmmo] = 10;

$ItemMax[larmor, RocketAmmo] = 0;	//Seraph
$ItemMax[lfemale, RocketAmmo] = 0;	//Seraph
$ItemMax[earmor, RocketAmmo] = 0;	//Slave
$ItemMax[efemale, RocketAmmo] = 0;	//Slave
$ItemMax[marmor, RocketAmmo] = 0;	//Pawn
$ItemMax[aarmor, RocketAmmo] = 0;	//Navigator
$ItemMax[darmor, RocketAmmo] = 10;	//Atomizer
$ItemMax[barmor, RocketAmmo] = 10;	//Paladin

$ItemMax[larmor, Guided] = 0;		//Seraph
$ItemMax[lfemale, Guided] = 0;		//Seraph
$ItemMax[earmor, Guided] = 0;		//Slave
$ItemMax[efemale, Guided] = 0;		//Slave
$ItemMax[marmor, Guided] = 0;		//Pawn
$ItemMax[aarmor, Guided] = 0;		//Navigator
$ItemMax[darmor, Guided] = 1;		//Atomizer
$ItemMax[barmor, Guided] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData RocketAmmo
{
	description = "Rockets";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData StingerImage
{	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0.33, -0.05 }; 
	weaponType = 0; 
	reloadTime = 1.4;
	fireTime = 1.4;
	minEnergy = 7;
	maxEnergy = 8;
	ammoType = RocketAmmo;
	accuFire = true;
	sfxFire	= SoundPickUpBackpack;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMissileReload;
	sfxReady = SoundMissileIdle;
};

ItemImageData StingeriImage
{	shapeFile = "grenadeL";
	mountPoint = 0;
	//mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0, 0, 0.045 }; 
	weaponType = 0; 
	reloadTime = 0.1;
	fireTime = 0.999;
	minEnergy = 7;
	maxEnergy = 8;
	ammoType = RocketAmmo;
	accuFire = true;
	sfxFire	= SoundPickUpBackpack;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMissileReload;
	sfxReady = SoundMissileIdle;
};

ItemImageData StingeriiImage
{	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0, 0, -0.10 }; 
	weaponType = 0; 
	reloadTime = 0.1;
	fireTime = 0.999;
	minEnergy = 7;
	maxEnergy = 8;
	ammoType = RocketAmmo;
	accuFire = true;
	sfxFire	= SoundPickUpBackpack;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMissileReload;
	sfxReady = SoundMissileIdle;
};

ItemData Guidedii
{	heading = "bweapons";
	description = "Guided Missile Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = StingeriiImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Guidedi
{	heading = "bweapons";
	description = "Guided Missile Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = StingeriImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Guided
{	heading = "bweapons";
	description = "Guided Missile Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 77;
	showWeaponBar = true;
};

$GuidedSlotA=4;
$GuidedSlotB=7;


function Guided::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Guided Missile Launcher");

	Player::mountItem(%player,Guidedi,$GuidedSlotA); 
	Player::mountItem(%player,Guidedii,$GuidedSlotB);


}

function Guided::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$GuidedSlotA); 
	Player::unmountItem(%player,$GuidedSlotB); 

}


function StingerImage::onFire(%player,%slot)
{	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Guided]);
	if(%AmmoCount)
	{	%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		//%pack=Player::getMountedItem(%player,$BackpackSlot);
		GameBase::getLOSInfo(%player,1024);  // ??? ,350
		%tpos=($los::position);
		%target=AquireTarget(%player,0,%tpos);
		if(%target)
		{	%targetcl=Player::GetClient(%target);	 
			// if($trace) echo($ver,"| target is ",%target, " Client is ",%client);
			%jam=CheckTargetJamming(%target);
			if(%jam==1)
			{	Player::decItemCount(%player,$WeaponAmmo[Guided],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				//GiveKickBack(%player, 125, 1);  // ??? new 
			}
			//else if(%jam==2)
			//{	%tpos=GameBase::getPosition(%player);
			//	%target=AquireTarget(%player,2,%tpos);
			//	if(%target)
			//	{	Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
			//		Player::decItemCount(%player,$WeaponAmmo[Guided],1);
			//		%name = Client::getName(%target);
			//		SendLockWarning(%TargetCl,2);
			//		Client::sendMessage(%client,0,"** UNKNOWN!! Lock Aquired - " @ %name @ "~wmine_act.wav");
			//		playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
			//		GiveKickBack(%player, 125, 1);  // ??? new
			//	}
			//}
			else
			{	Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
				Player::decItemCount(%player,$WeaponAmmo[Guided],1);
				%name = Client::getName(%target);
				SendLockWarning(%TargetCl,1);
				Client::sendMessage(%client,0,"** Image Lock Aquired - " @ %name @ "~wmine_act.wav");
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				//GiveKickBack(%player, 125, 1);  // ??? new
			}
		}
		else
		{	Client::sendMessage(%client,0,"** No Image Lock (Alternate Scan Engaged)- " @ %name @ "~wmine_act.wav");
			%tpos=GameBase::getPosition(%player);
			%target=AquireTarget(%player,1,%tpos);
			if(%target)
			{	%TargetCl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	Player::decItemCount(%player,$WeaponAmmo[Guided],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
					//GiveKickBack(%player, 125, 1);
				}
				//else if(%jam==2)
				//{	%tpos=GameBase::getPosition(%player);
				//	%target=AquireTarget(%player,2,%tpos);
				//	if(%target)
				//	{	Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
				//		Player::decItemCount(%player,$WeaponAmmo[Guided],1);
				//		%name = Client::getName(%target);
				//		SendLockWarning(%TargetCl,2);
				//		Client::sendMessage(%client,0,"** UNKNOWN!! Lock Aquired - " @ %name @ "~wmine_act.wav");
				//		playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				//	}
				//}
				else
				{	Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[Guided],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,2);
					Client::sendMessage(%client,0,"** Sensor Lock Aquired - " @ %name @ "~wmine_act.wav");
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					//GiveKickBack(%player, 125, 1);
				}
			}
			else
			{	Client::sendMessage(%client,0,"** NO Valid Target Firing Unprogrammed Missile ** " @ %name @ "~wmine_act.wav");
				Player::decItemCount(%player,$WeaponAmmo[Guided],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				//GiveKickBack(%player, 125, 1);
			}
		}			
	}
	else
	Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

function CheckTargetJamming(%target)
{	// Is Target A Player If not Return a 0
	// If target Wearing a jamming Pack & is it turned on If No Return a 0 If Yes return a 1
	%jamming=0;
	%type=getObjectType(%target);
	if(%type!="PLAYER")
		return(0);
	%pack=Player::getMountedItem(%target,$BackpackSlot);
	if (%pack=="SensorJammerPack")
	{	if($trace) echo($ver,"| Target Has Jammer Pack =",%pack);
		if (Player::isTriggered(%target,$BackpackSlot) )
			%jamming=1;
	}
	return (%jamming);
}

function AquireTarget(%this,%option,%pos)
{	// Options are	0 - Line of Sight Scan
	//		1 - Local Area Scan
	//		2 - Infiltrator Jammed Scan
	//		3 - AAPC Scan
	if($trace) 
		echo($ver,"| Aquiring Target for player ",%this," type of scan ",%option," Position ",%pos);
	%team = GameBase::getTeam(%this);
	%target=0;
	%set = newObject("set",SimSet);
	if(%option==1)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,250,250,250,0);
	}
	else if(%option==2)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,250,250,250,0);
	}
	else if(%option==3)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,200,200,-100,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,80,80,80,0);
	if (%tnum>0)
	{	// There are Targets within scan range
		if($traceAll) echo($Ver,"| Optical Scan Has Located ",%tnum," Targets.. in a ",%option," Scan");
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
			{	%i=%tnum;
			}
		}
	}
	deleteObject(%set);
	return (%target);
}