//--------------------------------------

$SellAmmo[MinenAmmo] = 1;
$AmmoPackMax[MinenAmmo] = 1;
$AmmoPackItems[1] = MinenAmmo;

//-------------------------------------

$TeamItemMax[minenammo] = 5;

//--------------------------------------

$InvList[MinenAmmo] = 1;
$RemoteInvList[MinenAmmo] = 1;

//--------------------------------------
BulletData MineShrapnelBit
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 2.2;
   damageType         = $ShrapnelDamageType;

   aimDeflection      = 73.7;
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;

soundId = SoundWindGust;

};

GrenadeData Minen
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ExplosionDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.01;
   totalTime          = 10.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";

};

GrenadeData Minen1
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 5.0;
   density = 5.0;
   elasticity         = 1.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.01;
   totalTime          = 10.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";

};

GrenadeData Minen2
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 5.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 30.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 10.0;
   liveTime           = 0.8;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";

};

ItemData MinenAmmo
{
   description = "Landmine";
   shapeFile = "discammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

function MinenAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMinen");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData AntipersonelMinen
{
	className = "Mine";
   description = "Landmine";
   shapeFile = "discammo";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 3.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMinen::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMinen::deployCheck(%this);
				}

function AntipersonelMinen::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMinen || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMinen::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMinen::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMinen::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("ExpFire",%trans,%this,0);
		 Projectile::spawnProjectile("ExpFire2",%trans,%this,0);
		 Projectile::spawnProjectile("Burner",%trans,%this,0);
		 Projectile::spawnProjectile("Burner1",%trans,%this,0);
}

function AntipersonelMinen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}