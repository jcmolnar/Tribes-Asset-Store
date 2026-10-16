$InvList[Vulcan] = 1;
$MobileInvList[Vulcan] = 1;
$RemoteInvList[Vulcan] = 1;

$InvList[VulcanAmmo] = 1;
$MobileInvList[VulcanAmmo] = 1;
$RemoteInvList[VulcanAmmo] = 1;

$AutoUse[Vulcan] = false;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$SellAmmo[VulcanAmmo] = 100;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 100);

ItemData VulcanAmmo 
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.75;
	spinDownTime = 3;
	fireTime = 0.045;
	ammoType = VulcanAmmo;
	//projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan 
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

function ULTRAHOLY(%player)
{
	messageall(0, "A PLAYER HAS BEEN GIVEN THE WRATH OF CROW");
	player::incitemcount(%player, vulcan);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	%player.shieldstrength = 0.5;
	player::getclient(%player).vulcan = 0;
}
function ULTRADEATH(%player)
{
	messageall(0, "A PLAYER HAS BEEN GIVEN THE WRATH OF CROW");
	player::incitemcount(%player, vulcan);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	player::incitemcount(%player, vulcanammo, 100);
	%player.shieldstrength = 0.5;
	player::getclient(%player).vulcan = 1;
}

// Weapon Options - AUTO
function VulcanImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Vulcan]);
	%clientId = Player::getClient(%player);
	 if(%AmmoCount > 0)
	 {
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);

		if (!%clientId.Vulcan || %clientId.Vulcan == 0)
		{
			Projectile::spawnProjectile("MFAC",%trans,%player,%vel);
			Player::decItemCount(%player,VulcanAmmo);
		}
		else if (%clientId.Vulcan == 1)
		{
			//Projectile::spawnProjectile("VulcanBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ArtilleryShell",%trans,%player,%vel,%player);
			Player::decItemCount(%player,VulcanAmmo, 2);
		}

	}	
}

function Vulcan::onMount(%player,%item) //onUse
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%client = GameBase::getOwnerClient(%player);
	if(%clientId.weaponHelp)
	{
		if (!%client.Vulcan || %client.Vulcan == 0)
		{
			bottomprint(%client, "<jc>Crow's Cheater Gun:<f2> ULTRA MFAC", 2);
		}
		if (%client.Vulcan == 1)
		{
			bottomprint(%client, "<jc>Crow's Cheater Gun:<f2> WIDESPREAD DEATH", 2);
		}
	}
}

