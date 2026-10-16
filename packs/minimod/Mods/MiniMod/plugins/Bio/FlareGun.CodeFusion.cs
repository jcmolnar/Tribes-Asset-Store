// Flare Gun by [BIO]iCE.! and [BIO]EvilBastard (uses a Tool Slot) 

MiniMod::MonitorFile(start, "FlareGun.CodeFusion.cs", "Flare Gun Plugin");

SoundData SoundFlare
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

ExplosionData FlareExp
{
   shapeName = "tumult_large.dts";
   soundId = SoundFlare;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 100.0;

   timeScale = 60.0;

   timeZero = 0.0;
   timeOne  = 60.0;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 0.5, 0.5, 0.5 };
   colors[2]  = { 0.05, 0.05, 0.05 };
   radFactors = { 0.0, 0.0, 1.0 };
};


GrenadeData Flare
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = FlareExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.5;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

$WeaponAmmo[FlareGun] = FlareAmmo;

$SellAmmo[FlareAmmo] = 5;

MiniMod::WeaponCycle(Blaster, FlareGun, PlasmaGun);

ItemData FlareAmmo
{
	description = "Flares";
	className = "Ammo";
	shapeFile = "rocket";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData FlareGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0; // Sustained
	// projectileType = Flare;
	AmmoType = FlareAmmo;
	accuFire = true;
	reloadTime = 1.5;
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 1, 1, 1 };
	sfxFire     = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlareGun
{
	description   = "Flare Gun";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FlareGunImage;
	price         = 300;
	showWeaponBar = true;
};

function FlareGunImage::onFire(%player, $WeaponSlot)
{ 
  %client = Player::getClient(%player);
  %name = client::getname(%client);
  %shooterteam = Client::getTeam(%client);
  %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[FlareGun]);
  if(%AmmoCount)
  {
  	%mt = GameBase::GetMuzzleTransform(%player);
    %vel = Item::getVelocity(%player);
    Projectile::Spawnprojectile("Flare",%mt,%player,%vel);
	%numPlayers = getNumClients();
	for(%loop = 0; %loop < %numPlayers; %loop++) 
	{ 
		%pl = getClientByIndex(%loop);
		%plteam = Client::Getteam(%pl);
		if(%plteam == %shooterteam) 
			client::sendmessage(%pl,3,%name@" has fired a flare.  Heads up!");
	}
	Player::decItemCount(%player,$WeaponAmmo[FlareGun],1);
  }
}

function FlareGun::OnMount(%player,%imageslot)
{
  client::SendMessage(Player::GetClient(%player),0,"Flare Gun armed.");
}

$InvList[FlareGun] = 1;
$InvList[FlareAmmo] = 1;
$RemoteInvList[FlareGun] = 1;
$RemoteInvList[FlareAmmo] = 1;

MiniMod::MonitorFile(stop, "FlareGun.CodeFusion.cs", "Flare Gun Plugin");
