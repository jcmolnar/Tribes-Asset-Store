//Warning!! This has been copied from the AAOD with their permission! 
//DO NOT COPY THIS unless you, too have permission.
//They will know if you did.....
//INH*DynaBlade
//Thanks, Valya[AAOD]

function SendLockWarning(%targetId,%type)
{
	if(%targetId)
	{	if(%type==0)
			Client::sendMessage(%targetId,0,"");
		else if(%type==1)
			Client::sendMessage(%targetId,0,"");
		else if(%type==2)
			Client::sendMessage(%targetId,0,"");
		
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wmislock.wav\");",0.1);
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
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,1024,1024,1024,0);
	}
	else if(%option==2)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,1024,1024,1024,0);
	}
	else if(%option==3)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,1024,1024,-1024,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,1024,1024,1024,0);
	
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

	projectileType = BlasterBolt;
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

//=============================================================================================

ItemImageData HyperB1Image 
{ 
	 shapeFile = "energygun"; 
	mountPoint = 0; 
	mountOffset = { -0.65, 0, 0 };
	weaponType = 0;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.3;
	projectileType = BlasterBolt; 
}; 

ItemData HyperB1
{ 
	description = "Enforcers";
	 className = "Weapon"; 
	shapeFile = "energygun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HyperB1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HyperB2Image 
{
	 shapeFile = "energygun"; 
	mountPoint = 0; 
	weaponType = 0;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.3;
	projectileType = BlasterBolt; 
}; 

ItemData HyperB2 
{ 
	description = "Enforcers";
	 className = "Weapon"; 
	shapeFile = "energygun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HyperB2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HyperBImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	reloadTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	fireTime = 0.3;
	sfxFire = SoundFireBlaster; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData HyperB
{ 
	description = "Enforcers"; 
	className = "Weapon"; 
	shapeFile = "energygun"; 
	hudIcon = "chain"; 
   heading = "bEnergy Weapons";
	shadowDetailMask = 4; 
	imageType = HyperBImage; 
	price = 200; 
	showWeaponBar = true;
}; 

function HyperBImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function HyperB::onMount(%player,%imageSlot) 
{  
	Player::mountItem(%player,HyperB1,4);  
	Player::mountItem(%player,HyperB2,5); 
} 

function HyperB::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}

$AutoUse[HyperB]			= True;

AddWeapon(HyperB);

$InvList[HyperB] = 1;
$RemoteInvList[HyperB] = 1;

$ItemMax[harmor, HyperB] = 0;
$ItemMax[marmor, HyperB] = 1;
$ItemMax[mfemale, HyperB] = 1;
$ItemMax[larmor, HyperB] = 0;
$ItemMax[lfemale, HyperB] = 0;
$ItemMax[BlastechM, HyperB] = 0;
$ItemMax[BlastechF, HyperB] = 0;
$ItemMax[MagIonM, HyperB] = 1;
$ItemMax[MagIonF, HyperB] = 1;
$ItemMax[MECH, HyperB] = 0;


ItemData gatlingammo
{
	description = "Quantum Cartridges";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

$AmmoPackMax[gatlingammo] = 500;
$AmmoPackItems[9] = gatlingammo;

ItemImageData HChain1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { -1.28, 0, 0 };
	 ammoType = gatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.25;
	projectileType = SuperBlaster; 
}; 

ItemData HChain1 
{ 
	description = "Super Hyper Blaster";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HChain1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HChain2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 };

	mountOffset = { 0, 0, 0 };
	 ammoType = gatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.25;
	projectileType = SuperBlaster; 
}; 

ItemData HChain2 
{ 
	description = "Super Hyper Blaster";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HChain2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HChaingunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = gatlingammo; 
	reloadTime = 0;
	fireTime = 0.5;
	sfxFire = SoundPlasmaTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData HChaingun
{ 
	description = "Super Hyper Blaster"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HChaingunImage; 
	price = 5000; 
	showWeaponBar = true;
}; 

function HChaingunImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "gatlingammo", 0.5);   
		%num = Player::getItemCount(%player, "gatlingammo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "gatlingammo", 0);    
			else     
			Player::setItemCount(%player, "gatlingammo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "gatlingammo", 0);    
			else     
			Player::setItemCount(%player, "gatlingammo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function HChaingun::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "gatlingammo");  
	Player::setItemCount(%player, "gatlingammo", %num);  
	Player::mountItem(%player,HChain1,4);  
	Player::mountItem(%player,HChain2,5); 
} 

function HChaingun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}

$AutoUse[HChaingun]			= True;

AddWeapon(hchaingun);

$WeaponAmmo[HChaingun]			= gatlingammo;
$SellAmmo[gatlingammo]			= 500;
$AmmoPackMax[gatlingammo]		= 500;

$InvList[HChaingun] = 1;
$RemoteInvList[HChaingun] = 1;

$InvList[gatlingammo] = 1;
$RemoteInvList[gatlingammo] = 1;

$ItemMax[harmor, HChaingun] = 1;
$ItemMax[marmor, HChaingun] = 0;
$ItemMax[mfemale, HChaingun] = 0;
$ItemMax[larmor, HChaingun] = 0;
$ItemMax[lfemale, HChaingun] = 0;
$ItemMax[BlastechM, HChaingun] = 0;
$ItemMax[BlastechF, HChaingun] = 0;
$ItemMax[MagIonM, HChaingun] = 0;
$ItemMax[MagIonF, HChaingun] = 0;
$ItemMax[MECH, HChaingun] = 1;

$ItemMax[harmor, gatlingammo] = 250;
$ItemMax[marmor, gatlingammo] = 0;
$ItemMax[mfemale, gatlingammo] = 0;
$ItemMax[larmor, gatlingammo] = 0;
$ItemMax[lfemale, gatlingammo] = 0;
$ItemMax[BlastechM, gatlingammo] = 0;
$ItemMax[BlastechF, gatlingammo] = 0;
$ItemMax[MagIonM, gatlingammo] = 0;
$ItemMax[MagIonF, gatlingammo] = 0;
$ItemMax[MECH, gatlingammo] = 500;

//=========================================================================
AddWeapon(ptcannon);

ItemImageData PTCImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; 
	minEnergy = 5;
	maxEnergy = 15;
      projectileType = PTCBolt;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 0;
	
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PTCannon
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "blaster";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = PTCImage;
	price = 800;
	showWeaponBar = true;
};

$InvList[PTCannon] = 1;
$RemoteInvList[PTCannon] = 1;

$ItemMax[larmor, PTCannon] = 0;
$ItemMax[lfemale, PTCannon] = 0;
$ItemMax[marmor, PTCannon] = 1;
$ItemMax[mfemale, PTCannon] = 1;
$ItemMax[harmor, PTCannon] = 1;
$ItemMax[BlastechM, PTCannon] = 0;
$ItemMax[BlastechF, PTCannon] = 0;
$ItemMax[MagIonM, PTCannon] = 0;
$ItemMax[MagIonF, PTCannon] = 0;
$ItemMax[MECH, PTCannon] = 1;

//=========================================================================

ItemImageData MBImage 
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0; 
	minEnergy = 10;
	maxEnergy = 50;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1;
	
	sfxFire = CapturedTower;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
};

function MBImage::onFire(%player, %slot) 
{
	 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
			
			if (%playerId.Cannon == 0)
			{
				Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			}
			else if (%playerId.Cannon == 1)
			{
				Projectile::spawnProjectile("IonShock4",%trans,%player,%vel);
			}
			else if (%playerId.Cannon == "2")
			{
				Projectile::spawnProjectile("IonShock5",%trans,%player,%vel);
			}
			else if (%playerId.Cannon == "3")
			{
				Projectile::spawnProjectile("IonShock6",%trans,%player,%vel);
			}
			else if (%playerId.Cannon == "4")
			{
				Projectile::spawnProjectile("IonShock7",%trans,%player,%vel);
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

$ItemMax[larmor, MBCannon] = 0;
$ItemMax[lfemale, MBCannon] = 0;
$ItemMax[marmor, MBCannon] = 1;
$ItemMax[mfemale, MBCannon] = 1;
$ItemMax[harmor, MBCannon] = 1;
$ItemMax[BlastechM, MBCannon] = 0;
$ItemMax[BlastechF, MBCannon] = 0;
$ItemMax[MagIonM, MBCannon] = 1;
$ItemMax[MagIonF, MBCannon] = 1;
$ItemMax[MECH, MBCannon] = 1;

//--------------------------------------------------------------------------------------------------------
// Fusion Cannon
//--------------------------------------------------------------------------------------------------------

ItemImageData FCBS
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 1.5;

	projectileType = ChargedFusionBolt;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFCBSFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = ForceFieldOpen;
	sfxSpinDown = ForceFieldClose;
};

ItemData FusionCannon
{
	description = "Fusion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "chain";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FCBS;
	price = 5000;
	showWeaponBar = true;
};

AddWeapon(fusioncannon);

$InvList[FusionCannon] = 1;
$RemoteInvList[FusionCannon] = 1;

$ItemMax[harmor, FusionCannon] = 1;
$ItemMax[marmor, FusionCannon] = 1;
$ItemMax[mfemale, FusionCannon] = 1;
$ItemMax[larmor, FusionCannon] = 0;
$ItemMax[lfemale, FusionCannon] = 0;
$ItemMax[BlastechM, FusionCannon] = 0;
$ItemMax[BlastechF, FusionCannon] = 0;
$ItemMax[MagIonM, FusionCannon] = 1;
$ItemMax[MagIonF, FusionCannon] = 1;
$ItemMax[MECH, FusionCannon] = 1;

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
	projectileType = ChaingunBullet;
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
	maxEnergy = 1;
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

//--------------------------------------------------------------------------------------------------------
// Plasma Chaingun
//--------------------------------------------------------------------------------------------------------

ItemImageData ChainsmaGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	minEnergy = 20;
	maxEnergy = 10;
	reloadTime = 0;
	spinUpTime = 0.75;
	spinDownTime = 4;
	fireTime = 0.2;


	projectileType = Plasmabolt2;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFirePlasma2;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData ChainsmaGun
{
	description = "Plasma Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChainsmaGunImage;
	price = 600;
	showWeaponBar = true;
};

AddWeapon(ChainsmaGun);

$InvList[ChainsmaGun] = 1;
$RemoteInvList[ChainsmaGun] = 1;

$ItemMax[larmor, ChainsmaGun] = 0;
$ItemMax[lfemale, ChainsmaGun] = 0;
$ItemMax[marmor, ChainsmaGun] = 1;
$ItemMax[mfemale, ChainsmaGun] = 1;
$ItemMax[harmor, ChainsmaGun] = 1;
$ItemMax[BlastechM, ChainsmaGun] = 0;
$ItemMax[BlastechF, ChainsmaGun] = 0;
$ItemMax[MagIonM, ChainsmaGun] = 1;
$ItemMax[MagIonF, ChainsmaGun] = 1;
$ItemMax[MECH, ChainsmaGun] = 1;

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
	fireTime = 0.2;

	ammoType = GaussAmmo;
	projectileType = GaussBullet;
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

ItemData Gauss
{
	description = "Gauss Gun";
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

$SellAmmo[GaussAmmo]			= 50;

$AmmoPackMax[GaussAmmo] = 50;
$AmmoPackItems[10] = GaussAmmo;

$InvList[Gauss] = 1;
$RemoteInvList[Gauss] = 1;

$InvList[GaussAmmo] = 1;
$RemoteInvList[GaussAmmo] = 1;

$ItemMax[larmor, Gauss] = 0;
$ItemMax[lfemale, Gauss] = 0;
$ItemMax[marmor, Gauss] = 1;
$ItemMax[mfemale, Gauss] = 1;
$ItemMax[harmor, Gauss] = 0;
$ItemMax[BlastechM, Gauss] = 0;
$ItemMax[BlastechF, Gauss] = 0;
$ItemMax[MagIonM, Gauss] = 1;
$ItemMax[MagIonF, Gauss] = 1;
$ItemMax[MECH, Gauss] = 1;

$ItemMax[larmor, GaussAmmo] = 0;
$ItemMax[lfemale, GaussAmmo] = 0;
$ItemMax[marmor, GaussAmmo] = 100;
$ItemMax[mfemale, GaussAmmo] = 100;
$ItemMax[harmor, GaussAmmo] = 0;
$ItemMax[BlastechM, GaussAmmo] = 0;
$ItemMax[BlastechF, GaussAmmo] = 0;
$ItemMax[MagIonM, GaussAmmo] = 100;
$ItemMax[MagIonF, GaussAmmo] = 100;
$ItemMax[MECH, GaussAmmo] = 500;

//--------------------------------------------------------------------------------------------------------
// Laser Gatling Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserGatlingImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Spinning
	minEnergy = 0.5;
	maxEnergy = 0.5;
	projectileType = GatlingLaserBeam;
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

ItemData LaserGatling
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserGatlingImage;
	price = 700;
	showWeaponBar = true;
};

AddWeapon(LaserGatling);

$InvList[LaserGatling] = 1;
$RemoteInvList[LaserGatling] = 1;

$ItemMax[larmor, LaserGatling] = 0;
$ItemMax[lfemale, LaserGatling] = 0;
$ItemMax[marmor, LaserGatling] = 1;
$ItemMax[mfemale, LaserGatling] = 1;
$ItemMax[harmor, LaserGatling] = 1;
$ItemMax[BlastechM, LaserGatling] = 0;
$ItemMax[BlastechF, LaserGatling] = 0;
$ItemMax[MagIonM, LaserGatling] = 1;
$ItemMax[MagIonF, LaserGatling] = 1;
$ItemMax[MECH, LaserGatling] = 1;

//--------------------------------------------------------------------------------------------------------
// AutoCannon (ATC)
//--------------------------------------------------------------------------------------------------------

ItemData ATCAmmo
{
	description = "Cannon Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ATCImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 6;
	fireTime = 0.2;

	ammoType = ATCAmmo;
	projectileType = MiniMissile;
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

ItemData ATC
{
	description = "Auto-Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = ATCImage;
	price = 1500;
	showWeaponBar = true;
};

AddWeapon(ATC);

$SellAmmo[ATCAmmo]			= 100;
$AmmoPackMax[ATCAmmo]		= 100;

$AmmoPackMax[ATCAmmo] = 50;
$AmmoPackItems[11] = ATCAmmo;

$InvList[ATC] = 1;
$RemoteInvList[ATC] = 1;

$InvList[ATCAmmo] = 1;
$RemoteInvList[ATCAmmo] = 1;

$ItemMax[larmor, ATC] = 0;
$ItemMax[lfemale, ATC] = 0;
$ItemMax[marmor, ATC] = 1;
$ItemMax[mfemale, ATC] = 1;
$ItemMax[harmor, ATC] = 1;
$ItemMax[BlastechM, ATC] = 0;
$ItemMax[BlastechF, ATC] = 0;
$ItemMax[MagIonM, ATC] = 1;
$ItemMax[MagIonF, ATC] = 1;
$ItemMax[MECH, ATC] = 1;

$ItemMax[larmor, ATCAmmo] = 0;
$ItemMax[lfemale, ATCAmmo] = 0;
$ItemMax[marmor, ATCAmmo] = 175;
$ItemMax[mfemale, ATCAmmo] = 175;
$ItemMax[harmor, ATCAmmo] = 250;
$ItemMax[BlastechM, ATCAmmo] = 0;
$ItemMax[BlastechF, ATCAmmo] = 0;
$ItemMax[MagIonM, ATCAmmo] = 175;
$ItemMax[MagIonF, ATCAmmo] = 175;
$ItemMax[MECH, ATCAmmo] = 500;

//----------------------------------------------------------------------------
BulletData MiniGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

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
   damageType         = $BulletDamageType;

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
$AmmoPackMax[MinigunAmmo] = 150; 
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
$ItemMax[mfemale,MinigunAmmo]=250;	// The maximum Medium Female can carry
$ItemMax[marmor,MinigunAmmo]=250;	// The maximum Medium Male can carry
$ItemMax[harmor,MinigunAmmo]=0;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MinigunAmmo] = 0;
$ItemMax[BlastechF, MinigunAmmo] = 0;
$ItemMax[MagIonM, MinigunAmmo] = 250;
$ItemMax[MagIonF, MinigunAmmo] = 250;
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
$SellAmmo[MMinigunAmmo] = 500; 
$AmmoPackMax[MMinigunAmmo] = 250; 
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
$ItemMax[harmor,MMinigunAmmo]=250;	// The maximum Heavy of either sex can carry
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
	projectileType = GrenadeShell;
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
	projectileType = MortarShell;
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
$SellAmmo[ImpactAmmo]			= 10;
$AmmoPackMax[ImpactAmmo]		= 60;

$AmmoPackMax[ImpactAmmo] = 60;
$AmmoPackItems[15] = ImpactAmmo;

$InvList[ImpactMortar] = 1;
$RemoteInvList[ImpactMortar] = 1;

$InvList[ImpactAmmo] = 1;
$RemoteInvList[ImpactAmmo] = 1;

$ItemMax[harmor, ImpactMortar] = 1;
$ItemMax[harmor, ImpactAmmo] = 50;
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
$ItemMax[MECH, ImpactAmmo] = 50;

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

//-----------------------------------------------------------------
// EMP Grenade Launcher
//----------------------------------------------------------------------------

ItemData EMPGrenadeAmmo
{
	description = "EMP Mortars";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData EMPGrenadeLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPGrenadeAmmo;
	projectileType = EMPGrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

ItemData EMPGrenadeLauncher
{
	description = "EMP Mortar Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sensorjamerpack";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = EMPGrenadeLauncherImage;
	price = 475;
	showWeaponBar = true;
};

AddWeapon(EMPGrenadeLauncher);

$ItemMax[BlastechM, EMPGrenadeLauncher] = 0;
$ItemMax[BlastechF, EMPGrenadeLauncher] = 0;
$ItemMax[MagIonM, EMPGrenadeLauncher] = 1;
$ItemMax[MagIonF, EMPGrenadeLauncher] = 1;
$ItemMax[MECH, EMPGrenadeLauncher] = 1;

$ItemMax[BlastechM, EMPGrenadeAmmo] = 0;
$ItemMax[BlastechF, EMPGrenadeAmmo] = 0;
$ItemMax[MagIonM, EMPGrenadeAmmo] = 250;
$ItemMax[MagIonF, EMPGrenadeAmmo] = 250;
$ItemMax[MECH, EMPGrenadeAmmo] = 150;

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
$SellAmmo[MultiMineAmmo]			= 50;
$AmmoPackMax[MultiMineAmmo]		= 50;

$AmmoPackMax[MultiMineAmmo] = 5;
$AmmoPackItems[17] = MultiMineAmmo;

$InvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MultiMineAmmo] = 1;
$RemoteInvList[MultiMineAmmo] = 1;

$ItemMax[harmor, MineLauncher] = 10;
$ItemMax[harmor, MultiMineAmmo] = 50;
$ItemMax[larmor, MineLauncher] = 0;
$ItemMax[larmor, MultiMineAmmo] = 0;
$ItemMax[marmor, MineLauncher] = 10;
$ItemMax[marmor, MultiMineAmmo] = 30;
$ItemMax[lfemale, MineLauncher] = 0;
$ItemMax[lfemale, MultiMineAmmo] = 0;
$ItemMax[mfemale, MineLauncher] = 1;
$ItemMax[mfemale, MultiMineAmmo] = 30;
$ItemMax[BlastechM, MineLauncher] = 0;
$ItemMax[BlastechF, MineLauncher] = 0;
$ItemMax[MagIonM, MineLauncher] = 1;
$ItemMax[MagIonF, MineLauncher] = 1;
$ItemMax[MECH, MineLauncher] = 1;
$ItemMax[BlastechM, MultiMineAmmo] = 0;
$ItemMax[BlastechF, MultiMineAmmo] = 0;
$ItemMax[MagIonM, MultiMineAmmo] = 30;
$ItemMax[MagIonF, MultiMineAmmo] = 30;
$ItemMax[MECH, MultiMineAmmo] = 20;

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

$SellAmmo[IMPAmmo]			= 5;

$AmmoPackMax[IMPAmmo] = 5;
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

$ItemMax[marmor, ImpAmmo] = 20;
$ItemMax[mfemale, ImpAmmo] = 20;
$ItemMax[larmor, ImpAmmo] = 0;
$ItemMax[lfemale, ImpAmmo] = 0;
$ItemMax[harmor, ImpAmmo] = 50;
$ItemMax[BlastechM, ImpAmmo] = 0;
$ItemMax[BlastechF, ImpAmmo] = 0;
$ItemMax[MagIonM, ImpAmmo] = 20;
$ItemMax[MagIonF, ImpAmmo] = 20;
$ItemMax[MECH, ImpAmmo] = 100;

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
$ItemMax[larmor, BabyNukeMortar] = 1;
$ItemMax[lfemale, BabyNukeMortar] = 1;
$ItemMax[marmor, BabyNukeMortar] = 1;
$ItemMax[mfemale, BabyNukeMortar] = 1;
$ItemMax[BlastechM, BabyNukeMortar] = 1;
$ItemMax[BlastechF, BabyNukeMortar] = 1;
$ItemMax[MagIonM, BabyNukeMortar] = 1;
$ItemMax[MagIonF, BabyNukeMortar] = 1;
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
	fireTime = 1.25;
	spinUpTime = 0.25;

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
//==============================================================================================
$AutoUse[HDiscLauncher]			= True;

AddWeapon(hdisclauncher);

$WeaponAmmo[HDiscLauncher]			= DualDiscs;
$SellAmmo[DualDiscs]			= 500;
$AmmoPackMax[DualDiscs]		= 250;

$AmmoPackMax[DualDiscs] = 250;
$AmmoPackItems[18] = DualDiscs;

$InvList[HDiscLauncher] = 1;
$RemoteInvList[HDiscLauncher] = 1;

$InvList[DualDiscs] = 1;
$RemoteInvList[DualDiscs] = 1;

$ItemMax[harmor, HDiscLauncher] = 1;
$ItemMax[marmor, HDiscLauncher] = 1;
$ItemMax[mfemale, HDiscLauncher] = 1;
$ItemMax[larmor, HDiscLauncher] = 0;
$ItemMax[lfemale, HDiscLauncher] = 0;
$ItemMax[BlastechM, HDiscLauncher] = 0;
$ItemMax[BlastechF, HDiscLauncher] = 0;
$ItemMax[MagIonM, HDiscLauncher] = 1;
$ItemMax[MagIonF, HDiscLauncher] = 1;
$ItemMax[MECH, HDiscLauncher] = 1;
$ItemMax[harmor, DualDiscs] = 250;
$ItemMax[marmor, DualDiscs] = 150;
$ItemMax[mfemale, DualDiscs] = 150;
$ItemMax[larmor, DualDiscs] = 0;
$ItemMax[lfemale, DualDiscs] = 0;
$ItemMax[BlastechM, DualDiscs] = 0;
$ItemMax[BlastechF, DualDiscs] = 0;
$ItemMax[MagIonM, DualDiscs] = 150;
$ItemMax[MagIonF, DualDiscs] = 150;
$ItemMax[MECH, DualDiscs] = 500;

ItemData DualDiscs
{
	description = "Dual Discs";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData HDisc1Image 
{ 
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 }; 
	mountOffset = { 0.1, 0, 0 };
	ammoType = DualDiscs; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = DiscShell;
}; 

ItemData HDisc1 
{ 
	description = "Dual Disc Launcher";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HDisc1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HDisc2Image 
{
	 shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.03, 0, 0 };
	 ammoType = DualDiscs; 
	weaponType = 3; 
	accuFire = true; 

	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = DiscShell; 
}; 

ItemData HDisc2 
{ 
	description = "Dual Disc Launcher";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HDisc2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HDiscLauncherImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 3; 
	ammoType = DualDiscs; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxFire = SoundFireDisc; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDiscReload; 
	sfxReady = SoundDiscSpin; 
}; 

ItemData HDiscLauncher 
{ 
	description = "Dual Disc Launcher"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
   heading = "eLaunchers"; 
	shadowDetailMask = 4; 
	imageType = HDiscLauncherImage; 
	price = 2500; 
	showWeaponBar = true; 
}; 

function HDiscLauncherImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,6);  
	%state2 = Player::getItemState(%player,7);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "DualDiscs", 0.5);   
		%num = Player::getItemCount(%player, "DualDiscs");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "DualDiscs", 0);    
			else     
			Player::setItemCount(%player, "DualDiscs", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		} 
		else 
		{    

			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "DualDiscs", 0);    
			else     
			Player::setItemCount(%player, "DualDiscs", %num);    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		}  
	} 
} 

function HDiscLauncher::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "DualDiscs");  
	Player::setItemCount(%player, "DualDiscs", %num);  
	Player::mountItem(%player,HDisc1,5);  
	Player::mountItem(%player,HDisc2,6); 
} 

function HDiscLauncher::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,5);  
	Player::unmountItem(%player,6); 
}

#-----------------------------------------------------------------#
# Missile Launcher Script by Valya[AAOD], Z_Dog and Mega Man 1024 #
#-----------------------------------------------------------------#

$RRocketgunSlotA=4;
AddWeapon(aodstinger);
$InvList[AODStinger]			= 1;	
$RemoteInvList[AODStinger]		= 1;
$AutoUse[AODStinger]			= True;
$WeaponAmmo[AODStinger]			= MissileAmmo;
$InvList[MissileAmmo]			= 1;
$RemoteInvList[MissileAmmo]		= 1;
$SellAmmo[MissileAmmo]			= 5;

$ItemMax[larmor,AODStinger]		= 1;
$ItemMax[lfemale,AODStinger]	= 1;
$ItemMax[marmor,AODStinger]		= 1;
$ItemMax[mfemale,AODStinger]	= 1;
$ItemMax[harmor,AODStinger]		= 1;
$ItemMax[MagIonM, AODStinger] = 1;
$ItemMax[MagIonF, AODStinger] = 1;
$ItemMax[MECH, AODStinger] = 1;
$ItemMax[BlastechF, AODStinger] = 1;
$ItemMax[BlastechM, AODStinger] = 1;

$ItemMax[larmor,MissileAmmo]	= 125;
$ItemMax[lfemale,MissileAmmo]	= 125;
$ItemMax[marmor,MissileAmmo]	= 250;
$ItemMax[mfemale,MissileAmmo]	= 250;
$ItemMax[harmor,MissileAmmo]	= 350;
$ItemMax[MagIonM, MissileAmmo] = 250;
$ItemMax[MagIonF, MissileAmmo] = 250;
$ItemMax[MECH, MissileAmmo] = 500;
$ItemMax[BlastechF, MissileAmmo] = 125;
$ItemMax[BlastechM, MissileAmmo] = 125;

SeekingMissileData AAODM1
{	bulletShapeName  = "Rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 0.5;
	damageClass      = 1;       
	damageValue      = 0.65;
	damageType       = $MissileDamageType;
	explosionRadius  = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity   = 50.0;
	terminalVelocity = 100.0;
	acceleration     = 1.0;
	totalTime        = 8.0;
	liveTime         = 9.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType		= 2;      
	trailString		= "mortartrail.dts";
	smokeDist		= 2;
	soundId			= SoundJetHeavy;
	seekingTurningRadius    = 2.5;
};

SeekingMissileData AAODM2
{	bulletShapeName  = "Rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 1.0;
	damageClass      = 1;       
	damageValue      = 0.50;
	damageType       = $MissileDamageType;
	explosionRadius  = 7.5;
	kickBackStrength = 175.0;
	muzzleVelocity   = 75.0;
	terminalVelocity = 150.0;
	acceleration     = 5.0;
	totalTime        = 6.0;
	liveTime         = 7.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType		= 2;                
	trailString		= "rsmoke.dts";
	smokeDist		= 20;
	soundId			= SoundJetHeavy;
};

RocketData AAODRocket
{	bulletShapeName  = "rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 1;
	damageValue      = 0.65;
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
{	   heading = "eLaunchers";
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
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if (%pack=="TargPack") 
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
						%name = Client::getName(%target);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						Client::sendMessage(%client,0,"~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));

					}
				}
				else
				{	
					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					%name = Client::getName(%target);
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
							%name = Client::getName(%target);
							if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
							Client::sendMessage(%client,0,"~wmine_act.wav");
							playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						}
					}
					else
					{	
						Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						%name = Client::getName(%target);
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
					Projectile::spawnProjectile("AAODM2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					%name = Client::getName(%targetId);
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
	accuFire = false;
	reloadTime = 0.9;
	fireTime = 0.5;

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
#		if ($RPGUseMTPack) 
		if (%pack=="TargPack") 
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

$AutoUse[RPGLauncher]			= True;

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
$SellAmmo[MrpgAmmo] = 160; 
$AmmoPackMax[MrpgAmmo] = 20; 
$AmmoPackItems[19] = MrpgAmmo; 
$WeaponAmmo[MrpgLauncher] = MrpgAmmo; 

$InvList[MrpgLauncher]=1;	
$InvList[MrpgAmmo]=1;
$RemoteInvList[MrpgAmmo]=1;

$ItemMax[lfemale,MrpgLauncher]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgLauncher]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgLauncher]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgLauncher]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgLauncher]=1;	// The maximum Heavy of either sex can carry
$ItemMax[MagIonM, MrpgLauncher] = 0;
$ItemMax[MagIonF, MrpgLauncher] = 0;
$ItemMax[MECH, MrpgLauncher] = 1;
$ItemMax[BlastechF, MrpgLauncher] = 0;
$ItemMax[BlastechM, MrpgLauncher] = 0;

$ItemMax[lfemale,MrpgAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgAmmo]=250;	// The maximum Heavy of either sex can carry (10 shots)
$ItemMax[MagIonM, MrpgAmmo] = 0;
$ItemMax[MagIonF, MrpgAmmo] = 0;
$ItemMax[MECH, MrpgAmmo] = 500;
$ItemMax[BlastechF, MrpgAmmo] = 0;
$ItemMax[BlastechM, MrpgAmmo] = 0;

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
	reloadTime = 1.5; 
	fireTime = 0.1;
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
	reloadTime = 1.0; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
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
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
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
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
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
#		if ($RPMUseMTPack)
		if (%pack=="TargPack") 
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
#		if ($RPEMPUseMTPack) 
		if (%pack=="TargPack") 
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
$ItemMax[marmor, RPEMPLauncher] = 1;
$ItemMax[mfemale, RPEMPLauncher] = 1;
$ItemMax[harmor, RPEMPLauncher] = 1;
$ItemMax[BlastechF, RPEMPLauncher] = 0;
$ItemMax[BlastechM, RPEMPLauncher] = 0;
$ItemMax[MagIonM, RPEMPLauncher] = 1;
$ItemMax[MagIonF, RPEMPLauncher] = 1;
$ItemMax[MECH, RPEMPLauncher] = 1;

//--------------------------------------------------------------------------------------------------------
// Ecstacy Cannon
//--------------------------------------------------------------------------------------------------------

ItemData Pies
{
	description = "Ecstacy Shots";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mrtwig";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData PieI
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Pies;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxActivate = SoundEcstacyOn;
	sfxReload = SoundEcstacyReload;
	sfxReady = SoundConIdle;
};

function PieI::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PoontangPie]);
	 %armor = Player::getArmor(%player);
	 %playerId = Player::getClient(%player);
	 %client = GameBase::getOwnerClient(%player);
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
       %weapon = Player::getMountedItem(%client,$WeaponSlot);

	 if(%Ammo) 
	 {
		if (%playerId.Pie == 2)
		{
			%weapon = Player::getMountedItem(%client,$WeaponSlot);
			%obj = getObjectType($los::object);
			 if(!%player.vehicle)
			{
	  			%rot = GameBase::getRotation(%client);
	  			%posX = getWord(%trans,9);
	  			%posY = getWord(%trans,10);
	  			%posZ = getWord(%trans,11) + 3.0;
	  			%position = %posX@" "@%posY@" "@%posZ;
	   
      			%obj = newObject("Concussion Missile",flier,ProbeDroid,true);
      			addToSet("MissionCleanup",%obj);
      			GameBase::setTeam(%obj,GameBase::getTeam(%this));
				GameBase::setPosition(%obj,%position);
      			GameBase::setRotation(%obj,%rot);
      			Gamebase::setMapName(%obj,"Concussion Electro-Optical Missile");
      			GameBase::startFadeIn(%obj);
      			Client::setControlObject(%client,%obj);
      			%this.vehicle = %obj;
      			if(!Player::isDead(%this)) Player::decItemCount(%client,Pies,10);
      			%this.lastWeapon = %weapon;
	 			 Player::unMountItem(%this,$WeaponSlot);
			}
		}
	if (%playerId.Pie == 1)
	{
		Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);

		if(GameBase::getLOSInfo(%player,1024))
		{
			%object = getObjectType($los::object);
			%targetId = GameBase::getOwnerClient($los::object);
	
	            if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape")
			{			 
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				%armor = Player::getArmor(%object);
				playSound(SoundFireCulex, GameBase::getPosition(%player));	
				Client::sendMessage(%client,0,"~wmine_act.wav");
				Projectile::spawnProjectile("Culexx",%trans,%player,%vel,$los::object);
			}
                  else 
			{
				 playSound(SoundFireCulex, GameBase::getPosition(%player));
				 Projectile::spawnProjectile("Culex",%trans,%player,%vel,%player);
			}
		} 
		else
		{
			playSound(SoundFireCulex, GameBase::getPosition(%player));
			Projectile::spawnProjectile("Culex",%trans,%player,%vel,%player);
		}
      }
      else if (%playerId.Pie == 0)
	{
		if ($Ecstacy::onFireNoPack) 
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
					Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					}
				}
				else
				{	
					Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,1);
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
						Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,$los::object);
					}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"~wmine_act.wav");
							playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						}
					}
					else
					{	
						Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					}

			}
				else

			{	
					Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,$los::object);
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
					Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
					%name = Client::getName(%targetId);
					SendLockWarning(%targetId,0);
					Client::sendMessage(%client,0,"~wmine_act.wav");
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,$los::object);
				}
			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[PoontangPie],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,$los::object);
			}
		   }
		}
		else if (%playerId.Pie == 3)
		{
				playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
				Player::decItemCount(%player,$WeaponAmmo[PoontangPie],10);

				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("EcstacyShot",%trans,%player,%vel,%player);

		}
	}
	else
	{	
		Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Ecstacy Cannon");
	}
}

ItemData PoontangPie  //PoontangPie was added for flavor and body.... or was it....
{
	description = "Ecstacy Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = PieI; 
	price = 2000;
	showWeaponBar = true;
};

$AutoUse[PoontangPie]			= True;

AddWeapon(PoontangPie);

$InvList[PoontangPie] = 1;
$RemoteInvList[PoontangPie] = 1;

$InvList[Pies] = 1;
$RemoteInvList[Pies] = 1;
$SellAmmo[Pies]			= 10;

$AmmoPackMax[Pies] = 25;
$AmmoPackItems[20] = Pies;

$ItemMax[larmor, PoontangPie] = 0;
$ItemMax[lfemale, PoontangPie] = 0;
$ItemMax[marmor, PoontangPie] = 1;
$ItemMax[mfemale, PoontangPie] = 1;
$ItemMax[harmor, PoontangPie] = 1;
$ItemMax[BlastechF, PoontangPie] = 0;
$ItemMax[BlastechM, PoontangPie] = 0;
$ItemMax[MagIonM, PoontangPie] = 1;
$ItemMax[MagIonF, PoontangPie] = 1;

$ItemMax[MECH, PoontangPie] = 1;

$ItemMax[larmor, Pies] = 0;
$ItemMax[lfemale, Pies] = 0;
$ItemMax[marmor, Pies] = 75;
$ItemMax[mfemale, Pies] = 75;
$ItemMax[harmor, Pies] = 100;
$ItemMax[BlastechF, Pies] = 0;
$ItemMax[BlastechM, Pies] = 0;
$ItemMax[MagIonM, Pies] = 75;
$ItemMax[MagIonF, Pies] = 75;
$ItemMax[MECH, Pies] = 500;

//=============================================================================================\\

$MRocketgunSlotA=4;
$MRocketgunSlotB=5;
$MRocketgunSlotC=6; 

addweapon(MECHRocketLauncher);
$InvList[MECHRocketLauncher]			= 1;	
$RemoteInvList[MECHRocketLauncher]		= 1;
$AutoUse[MECHRocketLauncher]			= True;
$WeaponAmmo[MECHRocketLauncher]			= MissileAmmo;
$AmmoPackMax[MissileAmmo] 		= 25; 
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
	projectileType = AAODRocket; 
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

ItemData JugLauncher // god I love energy weapons!!!
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

$ItemMax[harmor, JugAmmo] = 150;
$ItemMax[larmor, JugAmmo] = 0;
$ItemMax[marmor, JugAmmo] = 0;
$ItemMax[lfemale, JugAmmo] = 0;
$ItemMax[mfemale, JugAmmo] = 0;
$ItemMax[BlastechF, JugAmmo] = 0;
$ItemMax[BlastechM, JugAmmo] = 0;
$ItemMax[MagIonM, JugAmmo] = 0;
$ItemMax[MagIonF, JugAmmo] = 0;
$ItemMax[MECH, JugAmmo] = 300;

addweapon(juglauncher);

//--------------------------------------------------------------------------------------------------------
// Scouter Electro-Optical Rocket Launcher
//--------------------------------------------------------------------------------------------------------

ItemImageData ScoLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData ScoLauncher 
{
	description = "Scouter Laucher";
	className = "Tool";
	shapeFile = "grenadel";
	hudIcon = "fear";
   heading = "jTools";
	shadowDetailMask = 4;
	imageType = ScoLauncherImage;
	price = 5000;
	showWeaponBar = true;
};

function ScoLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "<f0>Scouter Electro-Optical Rocket Launcher: <f2>When you fire it, be sure to control it immediately.\n<f1>*WARNING*<f2> Do not fire while in the air or inside a small or enclosed area.");
}

function ScoLauncherImage::onFire(%this,%slot)
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
	   
      %obj = newObject("Scouter Electro-Optical Missile",flier,ScouterMissile,true);
      addToSet("MissionCleanup",%obj);
      GameBase::setTeam(%obj,GameBase::getTeam(%this));
	  GameBase::setPosition(%obj,%position);
      GameBase::setRotation(%obj,%rot);
      Gamebase::setMapName(%obj,"Scouter Electro-Optical Missile");
      GameBase::startFadeIn(%obj);
      Client::setControlObject(%client,%obj);
      %this.vehicle = %obj;
      %this.lastWeapon = %weapon;
	  Player::unMountItem(%this,$WeaponSlot);
	 }
}

addweapon(scolauncher);

$InvList[ScoLauncher] = 1;
$RemoteInvList[ScoLauncher] = 1;

$ItemMax[larmor, ScoLauncher] = 1;
$ItemMax[marmor, ScoLauncher] = 1;
$ItemMax[lfemale, ScoLauncher] = 1;
$ItemMax[mfemale, ScoLauncher] = 1;
$ItemMax[harmor, ScoLauncher] = 0;
$ItemMax[BlastechF, ScoLauncher] = 1;
$ItemMax[BlastechM, ScoLauncher] = 1;
$ItemMax[MagIonM, ScoLauncher] = 1;
$ItemMax[MagIonF, ScoLauncher] = 1;
$ItemMax[MECH, ScoLauncher] = 0;

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
	description = "Gundam Death Ray";
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
		Client::sendMessage(%clientId,1,"** Gundam Death Ray uses Beacons to charge...~waccess_denied.wav");
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
		BottomPrint (%clientId, "** Gundam Internal CPU: " @ %time @ " before full charge ", 5);
		%clientId.lascharge++;
		return;
	}
	else
	{
		BottomPrint (%clientId, "** Gundam Internal CPU: Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Gundam Death Ray may overload... ETA: 15 seconds"  , 5);
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
		bottomprint (%clientId, "<jc>** Gundam Internal CPU: ETA to overload: " @ %time @ " seconds");	}
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
	projectileType = PoisonDart;
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

$ItemMax[larmor, Darts] = 150;
$ItemMax[lfemale, Darts] = 150;
$ItemMax[marmor, Darts] = 300;
$ItemMax[mfemale, Darts] = 300;
$ItemMax[harmor, Darts] = 0;
$ItemMax[BlastechF, Darts] = 150;
$ItemMax[BlastechM, Darts] = 150;
$ItemMax[MagIonM, Darts] = 300;
$ItemMax[MagIonF, Darts] = 300;
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

$SellAmmo[Shells]			= 500;

$AmmoPackMax[Shells] = 500;
$AmmoPackItems[23] = Shells;


$InvList[Shells] = 1;
$RemoteInvList[Shells] = 1;

$ItemMax[larmor, Shells] = 75;
$ItemMax[lfemale, Shells] = 75;
$ItemMax[marmor, Shells] = 250;
$ItemMax[mfemale, Shells] = 250;
$ItemMax[harmor, Shells] = 400;
$ItemMax[BlastechF, Shells] = 75;
$ItemMax[BlastechM, Shells] = 75;
$ItemMax[MagIonM, Shells] = 250;
$ItemMax[MagIonF, Shells] = 250;
$ItemMax[MECH, Shells] = 500;

//--------------------------------------------------------------------------------------------------------
// Stubber Rifle
//--------------------------------------------------------------------------------------------------------

//--------------------------------------
BulletData StubberBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.256;
   damageType         = $SniperDamageType;

   explosionRadius  = 7;
   kickBackStrength = 0;

   aimDeflection      = 0.0025;
   muzzleVelocity     = 999.0;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

};

ItemData StubberShells
{
	description = "Stubber Shells";
	className = "Ammo";
    heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData StubberI
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = StubberShells;
	projectileType = StubberBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2125;


lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = BigExplosion4;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Stubber
{
	description = "Stubber";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "fear";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = StubberI;
	price = 900;
	showWeaponBar = true;
};

$SellAmmo[StubberShells]			= 50;
$AmmoPackMax[StubberShells] = 75;
$AmmoPackItems[24] = StubberShells;

AddWeapon(Stubber);

$InvList[StubberShells] = 1;
$RemoteInvList[StubberShells] = 1;

$InvList[Stubber] = 1;
$RemoteInvList[Stubber] = 1;

$ItemMax[larmor, Stubber] = 1;
$ItemMax[lfemale, Stubber] = 1;
$ItemMax[marmor, Stubber] = 1;
$ItemMax[mfemale, Stubber] = 1;
$ItemMax[harmor, Stubber] = 1;
$ItemMax[BlastechF, Stubber] = 1;
$ItemMax[BlastechM, Stubber] = 1;
$ItemMax[MagIonM, Stubber] = 1;
$ItemMax[MagIonF, Stubber] = 1;
$ItemMax[MECH, Stubber] = 1;

$ItemMax[larmor, StubberShells] = 150;
$ItemMax[lfemale, StubberShells] = 150;
$ItemMax[marmor, StubberShells] = 300;
$ItemMax[mfemale, StubberShells] = 300;
$ItemMax[harmor, StubberShells] = 250;
$ItemMax[BlastechF, StubberShells] = 150;
$ItemMax[BlastechM, StubberShells] = 150;
$ItemMax[MagIonM, StubberShells] = 300;
$ItemMax[MagIonF, StubberShells] = 300;
$ItemMax[MECH, StubberShells] = 500;

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
	projectileType = MassBullet;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0;

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
$AmmoPackMax[Bolts] = 20;
$AmmoPackItems[25] = Bolts;

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;

AddWeapon(massdriver);

$InvList[Bolts] = 1;
$RemoteInvList[Bolts] = 1;

$ItemMax[larmor, MassDriver] = 1;
$ItemMax[lfemale, MassDriver] = 1;
$ItemMax[marmor, MassDriver] = 0;
$ItemMax[mfemale, MassDriver] = 0;
$ItemMax[harmor, MassDriver] = 1;
$ItemMax[BlastechF, MassDriver] = 1;
$ItemMax[BlastechM, MassDriver] = 1;
$ItemMax[MagIonM, MassDriver] = 0;
$ItemMax[MagIonF, MassDriver] = 0;
$ItemMax[MECH, MassDriver] = 1;

$ItemMax[larmor, Bolts] = 150;
$ItemMax[lfemale, Bolts] = 150;
$ItemMax[marmor, Bolts] = 0;
$ItemMax[mfemale, Bolts] = 0;
$ItemMax[harmor, Bolts] = 250;
$ItemMax[BlastechF, Bolts] = 150;
$ItemMax[BlastechM, Bolts] = 150;
$ItemMax[MagIonM, Bolts] = 0;
$ItemMax[MagIonF, Bolts] = 0;
$ItemMax[MECH, Bolts] = 500;

//--------------------------------------------------------------------------------------------------------
// AAOD SniperX
//--------------------------------------------------------------------------------------------------------

ItemImageData SXImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };

	weaponType = 0; 
      projectileType = sniperXBullet;
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

AddWeapon(aaodsniperx);

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
   className = "Tool";
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
	projectileType = reassemblerBolt;
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

//--------------------------------------------------------------------------------------------------------
// Swarmer
//--------------------------------------------------------------------------------------------------------

ItemData SwarmerAmmo
{
	description = "Swarmer Rack";
	className = "Ammo";
	shapeFile = "mortarammo";

  heading = "zAmmo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SwarmerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Swarmer
{
	description = "Swarmer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "hSpread Wapons";
	shadowDetailMask = 4;
	imageType = SwarmerImage;
	price = 16384;
	showWeaponBar = true;
};

AddWeapon(Swarmer);

function Swarmer::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Player::mountItem(%player,ExtraSwarmerA,$ExtraWeaponSlotA);
	Player::mountItem(%player,ExtraSwarmerB,$ExtraWeaponSlotB);
	Player::mountItem(%player,ExtraSwarmerC,$ExtraWeaponSlotC);
}

function Swarmer::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);

	Player::unmountItem(%player,$ExtraWeaponSlotC);
}

function SwarmerImage::onFire(%player,%slot)
{
	%rawCharge = Player::getItemCount(%player,SwarmerAmmo);
	%charge = %rawCharge *= 0.2;
	if(%charge > 0)
	{
		for(%i=1; %i<%charge; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("SwarmerRocket",%trans,%player,%vel);
		}
		Player::setItemCount(%player,SwarmerAmmo,0);
		if($SwarmerRecharging[%player] != True)
		{
			$SwarmerRecharging[%player] = True;
			%guntype = Swarmer;
			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.075,%player);
		}
	}
		else Client::sendMessage(Player::getClient(%player),0,"Swarmer is out of energy.");
}


ItemImageData SwarmerImageA
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.25 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerA
{
	description = "Swarmer";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageA;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


ItemImageData SwarmerImageB
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0.15, 0, 0 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerB
{
	description = "Swarmer";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageB;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


ItemImageData SwarmerImageC
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.15, 0, 0 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerC
{
	description = "Swarmer";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageC;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


function RechargeAmmo(%player,%gunType)
{
	%armor = Player::GetArmor(%player);
	if(%gunType == Swarmer && (Player::getItemCount(%player,Swarmer) > 0))
	{
		if(Player::getItemCount(%player,SwarmerAmmo) < $ItemMax[%armor,SwarmerAmmo])
		{

		Player::incItemCount(%player,SwarmerAmmo,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",0.1,%player);
		}
		else
			$SwarmerRecharging[%player] = False;
	}
}

function THResuply(%player)
{
	Station::itemsToResupply(%player);
	schedule("THResuply(" @ %player @ ");",0.5,%this);
}

$SellAmmo[SwarmerAmmo] = 15;
$AmmoPackMax[SwarmerAmmo] = 15;
$AmmoPackItems[26] = SwarmerAmmo;
$WeaponAmmo[Swarmer] = SwarmerAmmo;

$InvList[Swarmer] = 1;
$RemoteInvList[Swarmer] = 1;
$InvList[SwarmerAmmo] = 1;
$RemoteInvList[SwarmerAmmo] = 1;

$ItemMax[harmor, Swarmer] = 1;
$ItemMax[larmor, Swarmer] = 0;
$ItemMax[marmor, Swarmer] = 0;
$ItemMax[lfemale, Swarmer] = 0;
$ItemMax[mfemale, Swarmer] = 0;
$ItemMax[BlastechF, Swarmer] = 0;
$ItemMax[BlastechM, Swarmer] = 0;
$ItemMax[MagIonM, Swarmer] = 0;
$ItemMax[MagIonF, Swarmer] = 0;
$ItemMax[MECH, Swarmer] = 1;

$ItemMax[harmor, SwarmerAmmo] = 250;
$ItemMax[larmor, SwarmerAmmo] = 0;
$ItemMax[marmor, SwarmerAmmo] = 0;
$ItemMax[lfemale, SwarmerAmmo] = 0;
$ItemMax[mfemale, SwarmerAmmo] = 0;
$ItemMax[BlastechF, SwarmerAmmo] = 0;
$ItemMax[BlastechM, SwarmerAmmo] = 0;
$ItemMax[MagIonM, SwarmerAmmo] = 0;
$ItemMax[MagIonF, SwarmerAmmo] = 0;
$ItemMax[MECH, SwarmerAmmo] = 500;

//--------------------------------------------------------------------------------------------------------
// Shotgun
//--------------------------------------------------------------------------------------------------------

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
    mountPoint = 0;

	ammoType = Shells;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.97;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFirePistol;
	sfxReload   = SoundMortarReload;
   
};

ItemData Shotgun
{
    description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
    className = "Weapon";
   heading = "hSpread Weapons";
    shadowDetailMask = 4;
    imageType = ShotgunImage;
	showWeaponBar = true;
    price = 1000;
};

$WeaponAmmo[Shotgun] = Shells;

AddWeapon(shotgun);

function ShotgunImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);

}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shotgun Shells");

}

$InvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;

$ItemMax[larmor, Shotgun] = 1;
$ItemMax[lfemale, Shotgun] = 1;
$ItemMax[marmor, Shotgun] = 1;
$ItemMax[mfemale, Shotgun] = 1;
$ItemMax[harmor, Shotgun] = 1;
$ItemMax[BlastechF, Shotgun] = 1;
$ItemMax[BlastechM, Shotgun] = 1;
$ItemMax[MagIonM, Shotgun] = 1;
$ItemMax[MagIonF, Shotgun] = 1;
$ItemMax[MECH, Shotgun] = 1;

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
	projectileType = PlasmaBolt;
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

$WeaponAmmo[PlasmaCannon] = "Beacon";

AddWeapon(plasmacannon);

$InvList[PlasmaCannon] = 1;
$RemoteInvList[PlasmaCannon] = 1;

$ItemMax[harmor, PlasmaCannon] = 1;
$ItemMax[larmor, PlasmaCannon] = 0;
$ItemMax[marmor, PlasmaCannon] = 0;
$ItemMax[lfemale, PlasmaCannon] = 0;
$ItemMax[mfemale, PlasmaCannon] = 0;
$ItemMax[BlastechM, PlasmaCannon] = 0;
$ItemMax[BlastechF, PlasmaCannon] = 0;
$ItemMax[MagIonM, PlasmaCannon] = 0;
$ItemMax[MagIonF, PlasmaCannon] = 0;
$ItemMax[MECH, PlasmaCannon] = 1;

ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 70;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData PlasmaCannon
{
	description = "Gundam Super Plasma";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "iHeat Effect Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 12800;
	showWeaponBar = true;
	mass = 2.5;
};

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
		Client::sendMessage(%clientId,1,"** Gundam Super Plasma uses beacons to charge... ~waccess_denied.wav");
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
                BottomPrint (%clientId, "** Gundam Internal CPU: " @ %time @ " before full charge ", 5);
		%clientId.plasmacharge++;
		return;
	}
	else
	{
		BottomPrint (%clientId, "** Gundam Internal CPU: Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Gundam Super Plasma may overload... ETA: 30 seconds"  , 5);
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
  		GameBase::applyDamage(%player, $PlasmaDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %clientId);
		return;
	}
	if (%time > 0 && %time < 25)
	{
		bottomprint (%clientId, "<jc>** Gundam Internal CPU: ETA to overload: " @ %time @ " seconds");
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

//--------------------------------------------------------------------------------------------------------
// Flamer
//--------------------------------------------------------------------------------------------------------

ItemImageData FlamerI
{
	shapeFile = "shotgun";
    mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxenergy = 1;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	#sfxFire     = "";
   
};

ItemData Flamer
{
    description = "Flamer";
	shapeFile = "shotgun";
	hudIcon = "blaster";
    className = "Weapon";
   heading = "iHeat Effect Weapons";
    shadowDetailMask = 4;
    imageType = FlamerI;
	showWeaponBar = true;
    price = 2500;
};

AddWeapon(Flamer);

function FlamerI::onFire(%player, %slot) 
{
	 %client = GameBase::getOwnerClient(%player);
	 %trans = GameBase::getMuzzleTransform(%player);
       %vel = Item::getVelocity(%player);
       Projectile::spawnProjectile("Flamesz",%trans,%player,%vel);
}

$InvList[Flamer] = 1;
$RemoteInvList[Flamer] = 1;

$ItemMax[larmor, Flamer] = 1;
$ItemMax[lfemale, Flamer] = 1;
$ItemMax[marmor, Flamer] = 1;
$ItemMax[mfemale, Flamer] = 1;
$ItemMax[harmor, Flamer] = 1;
$ItemMax[BlastechF, Flamer] = 1;
$ItemMax[BlastechM, Flamer] = 1;
$ItemMax[MagIonM, Flamer] = 1;
$ItemMax[MagIonF, Flamer] = 1;
$ItemMax[MECH, Flamer] = 1;

//-----------------------------------
// Beacon Gun Script
//-----------------------------------
$InvList[AODBeaconGun]			= 1;
$RemoteInvList[AODBeaconGun]	= 1;		
$AutoUse[AODBeaconGun]			= True;
$WeaponAmmo[AODBeaconGun]		= BeaconAmmo;
$InvList[BeaconAmmo]			= 1;	
$RemoteInvList[BeaconAmmo]		= 1;
$SellAmmo[BeaconAmmo]			= 5;
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

$ItemMax[larmor,BeaconAmmo]		=5;
$ItemMax[lfemale,BeaconAmmo]	=5;
$ItemMax[marmor,BeaconAmmo]		=10;
$ItemMax[mfemale,BeaconAmmo]	=10;
$ItemMax[harmor,BeaconAmmo]		=0;
$ItemMax[BlastechF, BeaconAmmo] = 5;
$ItemMax[BlastechM, BeaconAmmo] = 5;
$ItemMax[MagIonM, BeaconAmmo] = 10;
$ItemMax[MagIonF, BeaconAmmo] = 10;
$ItemMax[MECH, BeaconAmmo] = 0;

$AmmoPackMax[BeaconAmmo] = 5;
$AmmoPackItems[28] = BeaconAmmo;

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

// Secondary Item Definitions... Ammo containers etc.

ItemData BeaconAmmo
{	description		= "Beacon Ammo";
	classname		= "Ammo";
	shapeFile		= "sensor_small";		
	heading			= "zAmmo";
	shadowDetailMask = 4;
	price			= 50;
};

//***************************************************
// Item Image Definitions
//***************************************************

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
	ammoType		= BeaconAmmo;
	accuFire		= true;
	sfxActivate		= SoundPickUpWeapon;
};

ItemData AODBeaconGun
{	heading				= "jTools";
	description			= "Beacon Gun";
	classname			= "Tool";
	shapeFile			= "PaintGun";
	hudIcon				= "mortar";	
	shadowDetailMask	= 4;
	imageType			= AODBeaconGunImage;	
	price				= 450;				
	showWeaponBar		= true;	
};

function DeployRBeacon(%player)
{	// if($trace) echo( $ver@"|DeployRbeacon  ");
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
	{	Client::sendMessage(%client,0,"** Out of Beacon Ammo!! ** ~waccess_denied.wav");}
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
$AutoUse[TargetingLaser]			= True;

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

ItemImageData Pull
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = tractorCharge;
   minEnergy = 3;

   maxEnergy = 3;  // Energy used/sec for sustained weapons
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
   className = "Tool";
   heading = "jTools";
   shadowDetailMask = 4;
   imageType = Pull;
	showWeaponBar = true;
   price = 1500;
};

AddWeapon(StrykerChain);

$InvList[StrykerChain]			= 1;
$RemoteInvList[StrykerChain]		= 1;		
$AutoUse[StrykerChain]			= True;

$ItemMax[larmor,StrykerChain]	= 1;
$ItemMax[lfemale,StrykerChain]	= 1;
$ItemMax[marmor,StrykerChain]	= 1;
$ItemMax[mfemale,StrykerChain]	= 1;
$ItemMax[harmor,StrykerChain]	= 1;
$ItemMax[BlastechF, StrykerChain] = 1;
$ItemMax[BlastechM, StrykerChain] = 1;
$ItemMax[MagIonM, StrykerChain] = 1;
$ItemMax[MagIonF, StrykerChain] = 1;
$ItemMax[MECH, StrykerChain] = 1;
