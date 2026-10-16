//------------------------------------

ItemData TeleBlast
{
        shapeFile = "discb";
        shadowdetailmask = 4;
};

//--------------------------------------

ItemImageData THPackImage
{
	shapeFile = "sensor_small";
	mountPoint  = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 1.2;
	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire     = SoundBeaconUse;
	sfxActivate = SoundDeploySensor;
};

ItemData THPack
{
	description = "Matter Transport Gun";
	shapeFile = "sensor_small";
	className = "Weapon";
	heading = "dTools";
	shadowDetailMask = 4;
	imageType = THPackImage;
	price = 125;
	hudIcon = "compass";
	showWeaponBar = true;
	hiliteOnActive = true;
};

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function THPackImage::onFire(%player,%slot)
{
	%Energy = GameBase::getEnergy(%player);
	if(%Energy == Player::getArmor(%player).maxEnergy) {
		%obj = newObject("","Item","TeleBlast",1,false);
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player,40,false);
		player::setItemCount(%player,Temp,1);
		$TempType = %obj;
		schedule("Player::useItem("@%player@","@Temp@");",2.0); 
		GameBase::setEnergy(%player,0);
	}
}

//---------------------------------------//
//------------INVENTORY-STUFF------------//
//---------------------------------------//

$ItemMax[larmor, THPack] = 1;
$ItemMax[qarmor, THPack] = 1;
$ItemMax[srarmor, THPack] = 1;
$ItemMax[sarmor, THPack] = 1;
$ItemMax[marmor, THPack] = 1;
$ItemMax[parmor, THPack] = 1;

$ItemMax[harmor, THPack] = 1;
$ItemMax[tarmor, THPack] = 1;

$ItemMax[lfemale, THPack] = 1;
$ItemMax[qfemale, TH] = 1;
$ItemMax[srfemale, THPack] = 1;
$ItemMax[sfemale, THPack] = 1;
$ItemMax[mfemale, THPack] = 1;
$ItemMax[pfemale, THPack] = 1;
$InvList[THPack] = 1;
$RemoteInvList[THPack] = 1;
