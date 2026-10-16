$InvList[Vulcan] = 1;			//1
$MobileInvList[Vulcan] = 1;		//1
$RemoteInvList[Vulcan] = 1;		//1

$InvList[VulcanAmmo] = 1;
$MobileInvList[VulcanAmmo] = 1;
$RemoteInvList[VulcanAmmo] = 1;

$AutoUse[Vulcan] = false;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$SellAmmo[VulcanAmmo] = 100;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

ItemData VulcanAmmo 
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};
//=====================
// Added image by: Arma
//=====================
ItemImageData Vulcan2Image
{
	shapeFile = "Sniper";  //30
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Vulcan2
{
	description = "Vulcan2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Vulcan2Image;
	showWeaponBar = false;
};
//===========================
ItemImageData VulcanImage 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.25;
	spinDownTime = 0;
	fireTime = 0.0;
	ammoType = VulcanAmmo;
	//projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;    //60
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan 
{
	description = "ChainGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

function Vulcan::onMount(%player,%item)
{	

Player::mountItem(%player,Vulcan2,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
	{
	if(%clientId.Vulcan == 0)
		bottomprint(%clientId, "<jc>ChainGun: <f2>Chaingun Bullets <f1>Loaded", 2);
	else if(%clientId.Vulcan == 1)
		bottomprint(%clientId, "<jc>ChainGun: <f2>Vulcan Bullets <f1>Loaded", 2);
	else if(%clientId.Vulcan == 2)
		bottomprint(%clientId, "<jc>ChainGun: <f2>Verminator Bullets <f1>Loaded", 2);
	}	
}

function Vulcan::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function VulcanImage::onFire(%player, %slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Vulcan]);
	
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	if(%clientId.Vulcan == 0)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("Chaingunbullet",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Vulcan],1);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Chaingun out of ammo.");
			return false;
		}
	}
	else if(%clientId.Vulcan == 1)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("Vulcanbullet",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Vulcan],2);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Chaingun out of ammo.");//~wdryfire1.wav");
			return false;
		}
	}
	else if(%clientId.Vulcan == 2)
	{
		if(%AmmoCount > 0)
		{
		Projectile::spawnProjectile("Vermbullet",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[Vulcan],1);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Chaingun out of ammo.");//~wdryfire1.wav");
			return false;
		}
	}	
}