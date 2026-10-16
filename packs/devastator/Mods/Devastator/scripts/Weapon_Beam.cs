//--------------------------------------

LaserData BeamLaser
{
   laserBitmapName   = "flame.bmp";
   hitname           = "plasmaex.dts";
   damageConversion  = 0.5;
   baseDamageType    = $BeamDamageType;
   beamTime          = 2.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};

ItemImageData Beam1Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam1
{
	description = "Beam1";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = Beam1Image;
	showWeaponBar = false;
};

ItemImageData Beam2Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam2
{
	description = "Beam2";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = Beam2Image;
	showWeaponBar = false;
};

ItemImageData Beam3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam3
{
	description = "Beam3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = Beam3Image;
	showWeaponBar = false;
};

ItemImageData Beam4Image
{
	shapeFile = "GrenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam4
{
	description = "Beam4";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = Beam4Image;
	showWeaponBar = false;
};

ItemImageData BeamPackImage
{
	shapeFile = "discb";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.7;   // Energy used/sec for sustained weapons
	mountOffset = { 0, -0.05, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	firstPerson = false;
};

ItemData BeamPack
{
	description = "Coolant Pack";
	shapeFile = "discb";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = BeamPackImage;
	price = 125;
	hudIcon = "clock";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData BeamImage
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 1.0;
	accuFire = true;
	projectiletype = BeamLaser;
	minEnergy = 60;
	maxEnergy = 60; 
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire     = SoundFireDC2;
	sfxActivate = SoundActivatePDA;
};

ItemData Beam
{
	description = "Beam Cannon";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "chain";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = BeamImage;
	price = 900;
	showWeaponBar = true;
};

function Beam::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == BeamPack)
		Weapon::onUse(%player,%item);
	else if(IsIce(Player::getClient(%player)))
		Weapon::onUse(%player,%item);
	else		
		Client::sendMessage(Player::getClient(%player),0,"Must have a Coolant Pack to use the Beam Cannon."); 
}

function Beam::onMount(%player,%item)
{
	Player::mountItem(%player, Beam1, 4);
	Player::mountItem(%player, Beam2, 5);
	Player::mountItem(%player, Beam3, 6);
	Player::mountItem(%player, Beam4, 7);
}

function Beam::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}

function BeamPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
}

function BeamPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	Bottomprint(Player::getClient(%player), "<jc>The Coolant Pack increases your Heat Sinks.");
}

function BeamPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Beam) 
		Player::unmountItem(%player,$WeaponSlot);
}

function OverHeatBoom(%player)
{
	%sound = radnomItems(6,color6,color7,color2,oops1,dsgst4,oops2);
	playVoice(Player::getClient(%player),%sound);			
	Player::blowUp(%player);
	Player::kill(%player);
}

//--------------------------------------------------------------------------------
// INVENTORY STUFF
//--------------------------------------------------------------------------------

$AutoUse[Beam] = True;
$InvList[Beam] = 1;
$RemoteInvList[Beam] = 1;
$InvList[BeamPack] = 1;
$RemoteInvList[BeamPack] = 1;

$ItemMax[larmor, Beam] = 0;
$ItemMax[larmor, BeamPack] = 0;
$ItemMax[qarmor, Beam] = 0;
$ItemMax[qarmor, BeamPack] = 0;
$ItemMax[sarmor, Beam] = 0;
$ItemMax[sarmor, BeamPack] = 0;
$ItemMax[srarmor, Beam] = 0;
$ItemMax[srarmor, BeamPack] = 0;
$ItemMax[marmor, Beam] = 0;
$ItemMax[marmor, BeamPack] = 0;
$ItemMax[parmor, Beam] = 0;
$ItemMax[parmor, BeamPack] = 0;
$ItemMax[tarmor, Beam] = 0;
$ItemMax[tarmor, BeamPack] = 0;
$ItemMax[harmor, Beam] = 0;
$ItemMax[harmor, BeamPack] = 0;
$ItemMax[lfemale, Beam] = 0;
$ItemMax[lfemale, BeamPack] = 0;
$ItemMax[qfemale, Beam] = 0;
$ItemMax[qfemale, BeamPack] = 0;
$ItemMax[sfemale, Beam] = 0;
$ItemMax[sfemale, BeamPack] = 0;
$ItemMax[srfemale, Beam] = 0;
$ItemMax[srfemale, BeamPack] = 0;
$ItemMax[mfemale, Beam] = 0;
$ItemMax[mfemale, BeamPack] = 0;
$ItemMax[pfemale, Beam] = 0;
$ItemMax[pfemale, BeamPack] = 0;

$InvList[AGPack] = 0;
$RemoteInvList[AGPack] = 0;

$ItemMax[larmor, AGPack] = 0;
$ItemMax[qarmor, AGPack] = 0;
$ItemMax[sarmor, AGPack] = 0;
$ItemMax[srarmor, AGPack] = 0;
$ItemMax[marmor, AGPack] = 0;
$ItemMax[parmor, AGPack] = 1;
$ItemMax[harmor, AGPack] = 0;
$ItemMax[tarmor, AGPack] = 0;
$ItemMax[IceMor, AGPack] = 1;
$ItemMax[lfemale, AGPack] = 0;
$ItemMax[qfemale, AGPack] = 0;
$ItemMax[sfemale, AGPack] = 0;
$ItemMax[srfemale, AGPack] = 0;
$ItemMax[mfemale, AGPack] = 0;
$ItemMax[pfemale, AGPack] = 1;
