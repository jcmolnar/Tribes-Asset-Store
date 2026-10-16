//--------------------------------------
GrenadeData KamiRocket
{
   bulletShapeName    = "breath.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5.0;
   damageType         = $KamiKazeKDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.001;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
};

//----------------------------------------------------------------------------

ItemImageData SuicidePackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SuicidePack
{
	description = "Suicide Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = SuicidePackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function SuicidePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Detonator)
		Player::unmountItem(%player,$WeaponSlot);
}

function SuicidePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::mountItem(%player,Detonator,$WeaponSlot);
}

function SuicidePack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if(%mounted == Detonator)
			Player::unmountItem(%player,$WeaponSlot);
		else
			Player::mountItem(%player,%mounted,$WeaponSlot);
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------

ItemImageData DetonatorImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 0;  
	//projectileType = kamirocket;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundDryFire;
};

ItemData Detonator
{
	description = "Detonator";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = DetonatorImage;
	showInventory = false;
	price = 125;
	validateShape = true;
};

function Detonator::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Detonator::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

function DetonatorImage::onFire(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	%set = newObject("set",SimSet); 
	%typ = $VehicleObjectType|$MineObjectType|$SimPlayerObjectType; 
	%num = containerBoxFillSet(%set,%typ,GameBase::getPosition(%player),18,18,9,-9); 
	deleteObject(%set);
	if(%num > 0) {
		if(%num == 1)
			%client.SuicideVictims = 0;
		else
			%client.SuicideVictims = %num-1;
	}
	else {
		echo("?");
		%client.SuicideVictims = WTF;
		return;
	}
	Weapon::onFire(%player,"KamiRocket",False);
}

function SuicidePack::onMount(%player,%item)
{
	if(!$SinglePlayer)
		Bottomprint(Player::getClient(%player),"<jc>The Pack will blow up you and your enemies.");
}

//--------------------------------------------------------
	$InvList[SuicidePack] = 1;
	$RemoteInvList[SuicidePack] = 1;

	$ItemMax[larmor, SuicidePack] = 0;
	$ItemMax[marmor, SuicidePack] = 0;
	$ItemMax[harmor, SuicidePack] = 1;
	$ItemMax[qarmor, SuicidePack] = 0;
	$ItemMax[tarmor, SuicidePack] = 0;
	$ItemMax[sarmor, SuicidePack] = 1;
	$ItemMax[srarmor, SuicidePack] = 0;
	$ItemMax[parmor, SuicidePack] = 0;
	$ItemMax[lfemale, SuicidePack] = 0;
	$ItemMax[mfemale, SuicidePack] = 0;
	$ItemMax[qfemale, SuicidePack] = 0;
	$ItemMax[sfemale, SuicidePack] = 1;
	$ItemMax[srfemale, SuicidePack] = 0;
	$ItemMax[pfemale, SuicidePack] = 0;
	$ItemMax[psarmor, SuicidePack] = 1;
	$ItemMax[psfemale, SuicidePack] = 1;
