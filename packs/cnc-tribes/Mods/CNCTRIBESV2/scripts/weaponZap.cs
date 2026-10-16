//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psy Bolt
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$WeaponAmmo[Zap] = "";
$InvList[Zap] = 1;
$AutoUse[Zap] = True;
$RemoteInvList[Zap] = 1;

addWeapon(Zap);

//=====================================================================//=== Psionic Zap

RocketData ZapBolt
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.55;
  damageType = $PsiDamageType;
  explosionRadius = 20.5;
  kickBackStrength = 150.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 130.0;
  acceleration = 5.0;
  totalTime = 6.5;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 1.20, 1.7, 1.5 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "fusionbolt.dts";
  smokeDist = 1.0;
  soundId = SoundJetHeavy;
};

//=====================================================================//=== Psionic Zap

ItemImageData ZapImage
{
   shapeFile  = "sensor_small";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 1.0;
	fireTime = 1.0;
	minEnergy = 35;
	maxEnergy = 40;

	projectileType = ZapBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Zap
{
   heading = $InvHead[ihPsi];
	description = "Bolt";
	className = "Weapon";
   shapeFile  = "sensor_small";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ZapImage;
	price = 485;
	showWeaponBar = true;
};


function Zap::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Shoots a deadly stream of psionic energy forth, annihilating targets with ease.");
}

function Zap::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == MindPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must concentrate to use Bolt."); }