//--------------------------------------

$SellAmmo[MineAmmo] = 5;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackItems[5] = MineAmmo;

//-------------------------------------

$TeamItemMax[mineammo] = 35;

//--------------------------------------

$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;

//--------------------------------------

GrenadeData Betty
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass = 2.3;
   drag = 8.0;
   density = 8.0;
   elasticity         = 3.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.32;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 5.5;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";

};

ItemData MineAmmo
{
   description = "Bouncing Betty";
   shapeFile = "mortar";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData AntipersonelMine
{
	className = "Mine";
   description = "Bouncing Betty";
   shapeFile = "mortar";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = MinenExp;
	explosionRadius = 20.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
				}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
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
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function AntipersonelMine::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("Betty",%trans,%this,0);
}

//--------------------------------------