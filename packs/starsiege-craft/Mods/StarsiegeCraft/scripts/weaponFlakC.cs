//flak cannon
$InvList[Flak] = 1;
$InvList[FlakAmmo] = 1;
$RemoteInvList[Flak] = 1;
$RemoteInvList[FlakAmmo] = 1;
$VehicleInvList[Flak] = 1;
$VehicleInvList[FlakAmmo] = 1;
$AutoUse[Flak] = True;
$SellAmmo[FlakAmmo] = 5;
$WeaponAmmo[Flak] = FlakAmmo;

addWeapon(Flak);
addAmmo(Flak, FlakAmmo, 2);

GrenadeData FlakCannonShell
{
  bulletShapeName = "mortar.dts";
  explosionTag = DebrisExpLarge;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 1.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.4;
  damageType = $MortarDamageType;
  explosionRadius = 25.0;
  kickBackStrength = 100.0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 1.01;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "rsmoke.dts";
};

function FlakCannonShell::onAdd(%this)
{
	schedule("DeployFlak(" @ %this @ " , 5);",1.0,%this);
}

function DeployFlak(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Flak1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4,false);
		%obj = newObject("","Mine","Flak2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,false);
		%obj = newObject("","Mine","Flak3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,false);
		%obj = newObject("","Mine","Flak1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,false);
		%obj = newObject("","Mine","Flak2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-4,false);
		%obj = newObject("","Mine","Flak3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,false);
		%obj = newObject("","Mine","Flak1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2,false);
		%obj = newObject("","Mine","Flak2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-4,false);
		%obj = newObject("","Mine","Flak3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2,false);
		//%count -= 1;
		//schedule("DeployFlak(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

MineData Flak1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Flak";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = DebrisExpSmall;
	explosionRadius = 10.0;
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 20;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Flak1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Flak2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Flak";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = BulletExp0;
	explosionRadius = 10.0;
	damageValue = 0.15;
	damageType = $ExplosionDamageType;
	kickBackStrength = 30;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Flak2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

MineData Flak3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Flak";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = ClawExp;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Flak3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

BulletData FlakBullet
{
  bulletShapeName = "bullet.dts";
  explosionTag = ClawExp;
  randExpCycle = 2;
  collideWithOwner = False;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 0;
  damageValue = 0.15;
  damageType = $ShellDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 10.0;
  muzzleVelocity = 400.0;
  aimDeflection = 0.004;
  totalTime = 30.0;
  liveTime = 2.0;
};

ItemData FlakAmmo
{
  description = "Flak Shells";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "mortarammo";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData FlakImage
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = FlakAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 1.0;
  fireTime = 2.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
};

ItemData Flak
{
  description = "Flak Cannon";
  className = "Weapon";
  shapeFile = "mortargun";
  hudIcon = "mortar";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = FlakImage;
  price = 625;
  showWeaponBar = true;
};

function Flak::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Flak Cannon: <f2>Another Mainstay since the year 2000, this weapon is able to spray superheated shrapnel onto the foes of the Confederacy.");
}

function FlakImage::onFire(%player, %slot) 
{
	 	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Flak]);
		
		 %playerId = Player::getClient(%player);
		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[Flak],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("FlakBullet",%trans,%player,%vel);
		}
}
