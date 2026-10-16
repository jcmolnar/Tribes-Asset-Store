//--------------------------------------

$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "";

addToInv(Blaster,1,1);

setArmorItemMax(Blaster,1,1,1,1,1,1,1, 1, 0,0,0,0);

//--------------------------------------
BulletData HBlasterBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;

   damageClass	      = 1;
   damageValue	      = 1.1;
   damageType	      = $BlasterDamageType;
   explosionradius    = 4.0;

   muzzleVelocity     = 200.0;
   totalTime	      = 2.0;
   liveTime	      = 1.125;

   lightRange	      = 3.0;
   lightColor	      = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MBlasterBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = turretExp;

   damageClass	      = 1;
   damageValue	      = 0.8;
   damageType	      = $BlasterDamageType;
   explosionradius    = 3.0;

   muzzleVelocity     = 200.0;
   totalTime	      = 2.0;
   liveTime	      = 1.125;

   lightRange	      = 3.0;
   lightColor	      = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData LBlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = plasmaExp0;

   damageClass	      = 1;
   damageValue	      = 0.5;
   damageType	      = $BlasterDamageType;
   explosionradius    = 2.0;

   muzzleVelocity     = 200.0;
   totalTime	      = 2.0;
   liveTime	      = 1.125;

   lightRange	      = 3.0;
   lightColor	      = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   rotationPeriod = 1.5;
};

//--------------------------------------

BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass	      = 0;
   damageValue	      = 0.125;
   damageType	      = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime	      = 2.0;
   liveTime	      = 1.125;

   lightRange	      = 3.0;
   lightColor	      = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible	      = True;

   rotationPeriod = 1;
};

//----------------------------------------------------------------------------

ItemImageData Blaster2Image
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.0;
	minEnergy = 0;
	maxEnergy = 0;

	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxReady = SoundMortarIdle;
};

ItemData Blaster2
{
   heading = $InvCatWeapons[All];
	description = "Charge Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = Blaster2Image;
	price = 0;
	showWeaponBar = false;
	showinventory = false;
};

ItemImageData BlasterImage
{
   shapeFile  = "breath";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.0;
	minEnergy = 5;
	maxEnergy = 110;

	accuFire = true;

	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = $InvCatWeapons[All];
	description = "Charge Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 100;
	showWeaponBar = true;
};

function BlasterImage::onFire(%player, %slot)
{
	if(%player.ChrgOn == 0) {
		%player.EnChrg = 0;
		%energy = GameBase::getEnergy(%player);
		Blaster::Charge(%player,%energy);
	}
}

//charge coded by ProtoManX
function Blaster::Charge(%player,%energy)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%state == "Fire") {
		%player.ChrgOn = 1;
		if(%energy >= 2 && %player.ChrgLvl < $MaxCharge[$ArmorName[%armor]]) {
			%energy -= 2;
			if(%energy < 0)
				%energy = 0;
			GameBase::setEnergy(%player,%energy);
			%player.EnChrg += 2;
		}
		if(%player.EnChrg > %armor.maxEnergy)
			%player.EnChrg = %armor.maxEnergy;
		if(%player.EnChrg >= 110)
			%player.ChrgLvl = 3;
		else if(%player.EnChrg >= 80)
			%player.ChrgLvl = 2;
		else if(%player.EnChrg >= 60)
			%player.ChrgLvl = 1;
		else
			%player.ChrgLvl = 0;
		%energy = GameBase::getEnergy(%player);
		Bottomprint(%client, "<JC><F1>Charge Level: <F2>" @ %player.ChrgLvl,1);
		schedule("Blaster::Charge(" @ %player @ "," @ %energy @ ");",0.1);
	}
	else {
		%player.ChrgOn = 0;
	//	  %trans = GameBase::getMuzzleTransform(%player);
		%trans = getPerfectTrans(%player);
		%vel = Item::getVelocity(%player);
		Player::trigger(%player,$ExtraSlotA,true);
		Player::trigger(%player,$ExtraSlotA,false);
		if(%player.ChrgLvl == 3)
			Projectile::spawnProjectile("HBlasterBolt",%trans,%player,%vel);
		else if(%player.ChrgLvl == 2)
			Projectile::spawnProjectile("MBlasterBolt",%trans,%player,%vel);
		else if(%player.ChrgLvl == 1)
			Projectile::spawnProjectile("LBlasterBolt",%trans,%player,%vel);
		else
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
	}
}

$MaxCharge[UltimaArmor] = 3;
$MountMSG[Blaster,UltimaArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 3.";
$MaxCharge[ApocalypseArmor] = 3;
$MountMSG[Blaster,ApocalypseArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 3.";
$MaxCharge[HeavyArmor] = 3;
$MountMSG[Blaster,HeavyArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 3.";
$MaxCharge[GuardianArmor] = 2;
$MountMSG[Blaster,GuardianArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 2.";
$MaxCharge[MediumArmor] = 2;
$MountMSG[Blaster,MediumArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 2.";
$MaxCharge[CenturionArmor] = 1;
$MountMSG[Blaster,CenturionArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 1.";
$MaxCharge[LightArmor] = 1;
$MountMSG[Blaster,LightArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 1.";
$MaxCharge[QuicksilverArmor] = 1;
$MountMSG[Blaster,QuicksilverArmor] = "<JC><F2>Charge Blaster <F0>- <F1>armor's maximum charge level is 1.";

function Blaster::onMount(%player,%item)
{
	Player::mountItem(%player,Blaster2,$ExtraSlotA);
}

function Blaster::onUnMount(%player,%item)
{
	Player::unmountItem(%player,$ExtraSlotA);
}

AddWeapon(Blaster);
