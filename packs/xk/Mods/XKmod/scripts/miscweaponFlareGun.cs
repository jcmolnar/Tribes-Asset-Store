//--------------------------------------
//Mini Mods Flare gun
//--------------------------------------

$InvList[FlareGun] = 1;
$InvList[FlareAmmo] = 1;
$RemoteInvList[FlareGun] = 1;
$RemoteInvList[FlareAmmo] = 1;
$AutoUse[FlareGun] = True;
$SellAmmo[FlareAmmo] = 5;
$WeaponAmmo[FlareGun] = FlareAmmo;

addWeapon(FlareGun);
addAmmo(FlareGun, FlareAmmo, 5);

GrenadeData Flare
{
   bulletShapeName = "enbolt.dts";
   explosionTag = FlareExp;
   collideWithOwner = True;
   ownerGraceMS = 250;
   collisionRadius = 0.2;
   mass = 1.0;
   elasticity = 0.45;
   damageClass = 1;       // 0 impact, 1, radius
   damageValue = 0.01;
   damageType = $ShrapnelDamageType;
   explosionRadius = 1;
   kickBackStrength = 0.0;
   maxLevelFlightDist = 150;
   totalTime = 2.5;
   liveTime = 1.0;
   projSpecialTime = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName = "smoke.dts";
};

ItemData FlareAmmo
{
	description = "Flares";
	className = "Ammo";
	shapeFile = "rocket";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FlareGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0;  
	projectileType = Flare; // Sustained//
	AmmoType = FlareAmmo;
	accuFire = true;
	reloadTime = 1.5;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 1.5, 1.5, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlareGun
{
	description = "Flare Gun";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "plasma";
      heading = "bMisc. Weapons";
	shadowDetailMask = 4;
	imageType = FlareGunImage;
	price = 300;
	showWeaponBar = true;
};

function FlareGunImage::onFire(%player, $WeaponSlot)
{ 
	%client = Player::getClient(%player);
	%name = client::getname(%clientId);
	%shooterteam = Client::getTeam(%clientId);
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[FlareGun]);
	if(%AmmoCount)
	{
		%mt = GameBase::GetMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::Spawnprojectile("Flare",%mt,%player,%vel);
		%numPlayers = getNumClients();
		for(%loop = 0; 
		%loop < %numPlayers; %loop++) 
		{ 
		%cl = getClientByIndex(%loop);
		%plteam = Client::Getteam(%clientId);
		if(%plteam == %shooterteam) 
		client::sendmessage(%clientId,3,%name@" has fired a flare.  Heads up!");
		}
		Player::decItemCount(%clientId,$WeaponAmmo[FlareGun],1);
	}
}

function FlareGun::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Flare Gun");
}



  
  
