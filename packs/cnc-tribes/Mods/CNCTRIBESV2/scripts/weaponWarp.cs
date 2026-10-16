//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Fusion Cannon
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Warp] = 1;
$RemoteInvList[Warp] = 1;
$AutoUse[Warp] = False;
$WeaponAmmo[Warp] = "";

addWeapon(Warp);


//=====================================================================//=== Tactical Nuke Shell

RocketData WarpShell2 
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.25;
  damageType = $DeathDamageType;
  explosionRadius = 6;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 2.42;
  liveTime = 2.42;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 50;
  trailWidth = 0.3;
  soundId = SoundJetHeavy;
};

//=====================================================================//=== Fusion Cannon

ItemImageData WarpImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = WarpShell2;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetHeavy;
	sfxReady = SoundJetLight;
};

ItemData Warp
{
	description = "Fusion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    heading = $InvHead[ihWel];
	shadowDetailMask = 4;
	imageType = WarpImage;
	price = 25;
	showWeaponBar = true;
};


function Warp::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fusion Cannon: An advanced form of the fusion gun. Rapid fire and very deadly.");
}
