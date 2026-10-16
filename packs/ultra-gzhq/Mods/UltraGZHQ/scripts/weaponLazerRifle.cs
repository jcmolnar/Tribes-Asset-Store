$InvList[LazerRifle] = 1;
$MobileInvList[LazerRifle] = 1;
$RemoteInvList[LazerRifle] = 1;

$AutoUse[LazerRifle] = False;
$WeaponAmmo[LazerRifle] = "";

addWeapon(LazerRifle);

//----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------

ItemImageData FakeLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData FakeLaser
{
	description = "FakeLaser";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = FakeLaserImage;
	showWeaponBar = false;
};

ItemImageData LazerRifleImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.11 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = true;
	projectileType = AssAssinLaser;
	weaponType = 0; // Spinning
 	minEnergy = 20;
      maxEnergy = 15;
      reloadTime = 0.08;

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireLaser;
	sfxReady = SoundEnergyPackOn;
};

ItemData LazerRifle
{
	description = "Lazer Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LazerRifleImage;
	price = 450;
	showWeaponBar = true;
};

function LazerRifle::onMount(%player,%item)
{	

Player::mountItem(%player,FakeLaser,5);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Lazer Rifle: <f2>Mounted");
}

function LazerRifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5);  
}
