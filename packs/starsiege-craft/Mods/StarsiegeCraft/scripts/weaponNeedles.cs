//needle spines, zurg, M
$WeaponAmmo[Zap] = "";
$InvList[Zap] = 1;
$AutoUse[Zap] = True;
$RemoteInvList[Zap] = 1;
$VehicleInvList[Zap] = 1;

addWeapon(Zap);

//=====================================================================//=== Psionic Zap

BulletData ZapBolt
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = clawexp;
   aimDeflection      = 0.004;
   damageClass        = 0;
   damageValue        = 0.1;
   baseDamageType     = $PsiDamageType;

   muzzleVelocity     = 400.0;
   totalTime          = 2.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = false;
};

//=====================================================================//=== Psionic Zap

ItemImageData ZapImage
{
   shapeFile  = "snowplume";
	mountPoint = 0;
        spinUpTime = 0.4;
        spinDownTime = 1.5;
      weaponType = 1;
	projectileType = ZapBolt;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 0.2;
	maxEnergy = 1;

	accuFire = false;
        sfxSpinUp = SoundJetLight;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Zap
{
   heading = $InvHead[ihPsi];
	description = "Needle Spines";
	className = "Weapon";
   shapeFile  = "sensor_small";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ZapImage;
	price = 700;
	showWeaponBar = true;
};

function Zap::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Needle Spines: <f2>Zerg mutations has allowed them to rapidly fire these spines that can puncture PlasSteel Terran armors.");
}
