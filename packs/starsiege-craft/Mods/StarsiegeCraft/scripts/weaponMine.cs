//mine long range placer, xel naga
$InvList[MineTele] = 1;
$RemoteInvList[MineTele] = 1;
$AutoUse[MineTele] = False;
$VehicleInvList[MineTele] = 1;
//$InvList[MineTeleAmmo] = 1;
//$RemoteInvList[MineTeleAmmo] = 1;
//$VehicleInvList[MineTeleAmmo] = 1;
//$SellAmmo[MineTeleAmmo] = 10;
$WeaponAmmo[MineTele] = MineAmmo;

addWeapon(MineTele);
//addAmmo(MineTele, MineTeleAmmo, 10);

LaserData MineTeleBolt
{
   laserBitmapName   = "fx_lensflare_0.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 1.0;
   detachFromShooter = true;
};

LaserData MineTeleBolt2
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "shockwave_large.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 1.0;
   detachFromShooter = true;
};

BulletData XelDet
{
  bulletShapeName = "mortar.dts";
  explosionTag  = mortarExp;
  damageClass = 1;
  damageValue = 1.6;
  damageType = $MineDamageType;
  explosionRadius = 5.0;
  muzzleVelocity = 1000.0;
  totalTime = 2;
  liveTime = 2;
  inheritedVelocityScale = 0.0;
  isVisible = False;
};

ItemImageData MineTeleImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
        mountRotation = 
        {
        0, -1.57, 0 }
        ;
      weaponType = 0; // Single Shot
	projectileType = "Undefined";
	reloadTime = 2.0;
	fireTime = 1.5;
        ammoType = MineAmmo;

	accuFire = true;

	sfxFire = SoundTeleport;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MineTele
{
   heading = $InvHead[ihXnt];
	description = "Mine Fabrication";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = MineTeleImage;
	price = 500;
	showWeaponBar = true;
};

function MineTele::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Mine Fabrication: <f2>This tool uses Xel Naga technology to create an explosive device at a certain point in space.  However, if an unlucky person or vehicle happens to be there at the time...");
}

function MineTeleImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[MineTele]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[MineTele],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("MineTeleBolt",%trans,%player,%vel);
		if(GameBase::getLOSInfo(%player,3000))
		{
                       %object = getObjectType($los::object);
			if(%object == "Player" || %object == "Flier")
                         {
                         Projectile::spawnProjectile("MineTeleBolt2",%trans,%player,%vel);
                         Projectile::spawnProjectile("XelDet",%trans,%player,%vel);
			 }
			 else
			 {
			 %man = newObject("","Mine","AntipersonelMine"); 
			 addToSet("MissionCleanup", %man); 
			 %loc = $los::position;
                         GameBase::setTeam (%man,GameBase::getTeam (%client));
                         %man.deployer = %client;
			 GameBase::setPosition(%man, %loc);
//                         Client::setOwnedObject(%man, %client);
			 }
		}
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Mines");
}
