//Experimental summon Protoss lightning call gun, Toss, H
$InvList[MagmaLift] = 1;
$RemoteInvList[MagmaLift] = 1;
$AutoUse[MagmaLift] = True;
$VehicleInvList[MagmaLift] = 1;
$InvList[MagmaLiftAmmo] = 1;
$RemoteInvList[MagmaLiftAmmo] = 1;
$VehicleInvList[MagmaLiftAmmo] = 1;
$SellAmmo[MagmaLiftAmmo] = 10;
$WeaponAmmo[MagmaLift] = MagmaLiftAmmo;

addWeapon(MagmaLift);
addAmmo(MagmaLift, MagmaLiftAmmo, 10);

LaserData MagmaLiftBolt
{
   laserBitmapName   = "forcefield.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.0;
   baseDamageType    = $PsiDamageType;
   beamTime          = 1.0;
   detachFromShooter = true;
};

BulletData MagmaLiftRocket 
{
  bulletShapeName = "mortar.dts";
  explosionTag  = turretExp;
  damageClass = 1;
  damageValue = 0.5;
  damageType = $DeathDamageType;
  explosionRadius = 10.0;
  muzzleVelocity = 800.0;
  totalTime = 0.4;
  liveTime = 0.4;
  inheritedVelocityScale = 0.0;
  isVisible = False;
};

MineData Meteor
{ 
	mass = 0.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.0; 
	friction = 99.0; 
	className = "Handgrenade"; 
	description = "Man"; 
	shapeFile = "zap"; 
	shadowDetailMask = 4; 
	explosionId = largeShockwave; 
	explosionRadius = 25.0; 
	damageValue = 2.0; 
	damageType = $DeathDamageType; 
	kickBackStrength = -300; 
	triggerRadius = 5; 
	maxDamage = 0.1; 
}; 

function Meteor::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",3.25,%this); 
}

ItemData MagmaLiftAmmo 
{
  description = "Seismic Charges";
  className = "Ammo";
  shapeFile = "force";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData MagmaLiftImage
{
   shapeFile  = "mortar";
	mountPoint = 0;

      weaponType = 0; // Single Shot
	projectileType = "Undefined";
	reloadTime = 3.0;
	fireTime = 2.0;
        ammoType = MagmaLiftAmmo;

	accuFire = false;

	sfxFire = SoundTeleport;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MagmaLift
{
   heading = $InvHead[ihWet];
	description = "Lightning Call";
	className = "Weapon";
   shapeFile  = "mortar";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = MagmaLiftImage;
	price = 800;
	showWeaponBar = true;
};

function MagmaLift::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psychic Lightning Call: <f2>Uses the Protoss' Psionic energies to create a large grouping of protons at a location, which forces down a large shock of electrons from the atmosphere. Both the protons and electrons charge deal damage to players");
}

function MagmaLiftImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[MagmaLift]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[MagmaLift],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("MagmaLiftRocket",%trans,%player,%vel);
                        Projectile::spawnProjectile("MagmaLiftBolt",%trans,%player,%vel);
		if(GameBase::getLOSInfo(%player,3000))
		{
			%newpos = $los::position;
			 %man = newObject("","Mine","Meteor"); 
			 addToSet("MissionCleanup", %man); 
			 %loc = $los::position;
			 %loc = Vector::add(%loc, "0 0 100");
			 GameBase::setPosition(%man, %loc);
		}
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");
}
