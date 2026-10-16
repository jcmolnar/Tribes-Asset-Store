$InvList[PhaseDisrupter] = 1;
$MobileInvList[PhaseDisrupter] = 1;
$RemoteInvList[PhaseDisrupter] = 1;

$InvList[PhaseDisrupterAmmo] = 1;
$MobileInvList[PhaseDisrupterAmmo] = 1;
$RemoteInvList[PhaseDisrupterAmmo] = 1;

$AutoUse[PhaseDisrupter] = False;
$SellAmmo[PhaseDisrupterAmmo] = 2;
$WeaponAmmo[PhaseDisrupter] = PhaseDisrupterAmmo;

addWeapon(PhaseDisrupter);
addAmmo(PhaseDisrupter, PhaseDisrupterAmmo, 1);

ItemData PhaseDisrupterAmmo
{
	description = "ArtilleryShell";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 100;
};

ItemImageData PhaseDisrupterImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PhaseDisrupterAmmo;
	accuFire = true;
	reloadTime = 6.0;	//0.3
	fireTime = 8.0;	//0.3
	lightType = 3;  // Weapon Fire
	lightRadius = 12;
	lightTime = 2.5;
	lightColor = { 1.0, 1, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundFireTargetingLaser;
	sfxReady = SoundJammerOn;
};

ItemData PhaseDisrupter
{
	description = "Energy Artillery";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PhaseDisrupterImage;
	price = 900;
	showWeaponBar = true;
};

function PhaseDisrupterImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[PhaseDisrupter]);
	if(%AmmoCount) 
	{
		ArtilleryRevUp(%player, 0);
		Player::decItemCount(%Player, $WeaponAmmo[PhaseDisrupter]);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of ArtilleryShells");
}

function PhaseDisrupter::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Energy Artillery Cannon: <f2>Fires one massive shot six seconds after the trigger is pulled.  Uses its own reactor, so needs no energy.");
}

function ArtilleryRevUp(%player, %time)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ArtilleryEffect",%trans,%player,%vel);
	%time = %time + 1;
	if(%time < 21) schedule("ArtilleryRevUp("@%player@","@%time@");", 0.3);
	else{
		Projectile::spawnProjectile("ArtilleryShell",%trans,%player,%vel,%player);
	}
} 