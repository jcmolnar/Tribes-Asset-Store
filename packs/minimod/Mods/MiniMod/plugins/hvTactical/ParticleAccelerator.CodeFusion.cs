// This is a MiniMod Plugin.
// This plugin is the Particle Accelerator from the hvTactical mod.
// Ported by PeterT.
MiniMod::MonitorFile(start, "ParticleAccelerator.CodeFusion.cs", "Particle Accelerator Plugin");
MiniMod::WeaponCycle(Blaster, ClusterBomb, PlasmaGun);
MiniMod::Turbo::Class(ClusterBomb, 6);

 BulletData ClusterBombShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = debrisExpSmall;
	 mass = 0.05;
	 bulletHoleIndex = 0;
  collisionRadius    = 15.0;//++++++
	 damageClass = 1;
   explosionRadius    = 8;//5;+++++++++++
   kickBackStrength   = 100.0;//++++++++
	 damageValue = 0.038; //0.05;+++++++++++++++++++
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.01;//++++++++++
	 muzzleVelocity = 300.0;
	 totalTime = 1.0; //0.8;+++++++++++++++++
	 liveTime = 0.05;//++++++++++++++++++++++++++++++++++++++++++++
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
	
	triggerRadius = 5;//+++++++++++
	damageLevel = {1.0, 1.0};//++++
	maxDamage = 1.0;//0++++++++++++

   tracerPercentage   = 100.0; //1.0;++++++++++++++++++++++++++++++++++++++++++++++
	 tracerLength = 30;
   smokeName              = "plasmatrail.dts";
 };
function ClusterBombShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClusterBombShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

$AutoUse[ClusterBomb] = True;//+++++++++++++++++++++++++++++++++++++++++++++++
$WeaponAmmo[ClusterBomb] = "";

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
	description = "Particle Accelerator";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
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

$InvList[ClusterBomb] = 1;
$RemoteInvList[ClusterBomb] = 1;

MiniMod::MonitorFile(stop, "ParticleAccelerator.CodeFusion.cs", "Particle Accelerator Plugin");
