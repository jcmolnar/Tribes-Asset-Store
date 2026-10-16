$InvList[ClusterBomb] = 1;
$RemoteInvList[ClusterBomb] = 1;
$AutoUse[ClusterBomb] = True;
$WeaponAmmo[ClusterBomb] = "";

addWeapon(ClusterBomb);

ItemImageData ClusterBombImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; 
      minEnergy = 30;
	maxEnergy = 50;//26;++++++++++++++++++++++++++++
//	projectileType = ThisShouldBeUndefined;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.25;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };	

//	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower; //+++++++++++++++++++++++++++++++++++
};

ItemData ClusterBomb
{
	description = "Cluster Bomb";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = ClusterBombImage;
	price = 475;
	showWeaponBar = true;
};

function ClusterBombImage::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 20.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(turretExplosion,GameBase::getPosition(%player));//+++++
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));//++++
	 Player::trigger(%player,$WeaponSlot,false);//+++++
	 Client::sendMessage(Player::getClient(%player), 0,"Not enough energy to fire the Particle Accelerator");
	} 
}

function ClusterBomb::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Cluster Bomb");
}
