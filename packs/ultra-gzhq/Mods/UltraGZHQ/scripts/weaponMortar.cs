$InvList[Mortar] = 1;
$MobileInvList[Mortar] = 1;
$RemoteInvList[Mortar] = 1;

$InvList[MortarAmmo] = 1;
$MobileInvList[MortarAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;

$AutoUse[Mortar] = false;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = MortarAmmo;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 20);

ItemData MortarAmmo 
{	
	description = "Mortar ammo"; 
	className = "Ammo"; 
	shapeFile = "Mortarammo"; 
	heading = $InvHead[ihAmm]; 
	shadowDetailMask = 4; 
	price = 2;
}; 

ItemImageData MortarImage 
{	
	shapeFile = "Mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	//projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.3;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	//sfxFire = SoundFireMortar;	//SoundTurretDeploy;	//SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Mortar 
{	
	description = "Mortar";
	className = "Weapon";
	shapeFile = "Mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 150;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
	{
	if(%clientId.MortarMode == 0)
		bottomprint(%clientId, "<jc>Mortar: <f2>Standard Shell <f1>Loaded", 2);
	else if(%clientId.MortarMode == 1)
		bottomprint(%clientId, "<jc>Mortar: <f2>EMP Shell <f1>Loaded", 2);
	else if(%clientId.MortarMode == 2)
		bottomprint(%clientId, "<jc>Mortar: <f2>Rubber Shell <f1>Loaded", 2);
	}	
}

function MortarImage::onFire(%player, %slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	if(%clientId.MortarMode == 0)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("MortarShell",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			playSound(SoundFireMortar, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Mortar out of ammo.");
			return false;
		}
	}
	else if(%clientId.MortarMode == 1)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("MortarShellEMP",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			playSound(SoundEmpIdle, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Mortar out of ammo.");
			return false;
		}
	}
	else if(%clientId.MortarMode == 2)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("RubberMortarShell",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			playSound(SoundFlagFlap, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Mortar out of ammo.");
			return false;
		}
	}	
}