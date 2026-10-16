//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.1;
	damageType = $MineDamageType;
	kickBackStrength = 950;
	triggerRadius = 2.5;
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

//----------------------------------------------------------------------------


MineData Handgrenade
{
   mass = 1.3;
   drag = 4.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

StaticShapeData needleThrower
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "discammo";
	maxDamage = 0.1;
	maxEnergy = 200;

	castLOS = true;
	supression = false;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

$DamageScale[needleThrower, $BulletDamageType] = 0;

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Handgrenade::Detonate(" @ %this @ ");",1.0,%this);
}

function Handgrenade::Detonate(%this)
{
	%clientId = %this.thrower;
	%this.thrower = "";
	%thisPos = gamebase::getposition(%this);
	spawnNeedleThrower(%clientId, %thisPos);
	Mine::Detonate(%this);
}

function spawnNeedleThrower(%clientId, %pos)
{
	%player = Client::getOwnedObject(%clientId);
	%beacon = newObject("Needle Thrower", "StaticShape", "needleThrower", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%pos);
	Gamebase::setMapName(%beacon,"Needle Thrower");
	%time = getBalancedNum(5);
	if(%time < 5)
		%time = 5;
   	spawnNeedleThrower::throwThings(%clientId, %beacon, %time);
}

function spawnNeedleThrower::throwThings(%clientId, %this, %count)
{
	%player = Client::getOwnedObject(%clientId);
	if(%count > 0)
	{
		%pos = gamebase::getposition(%this);
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%rot = getRandom()*-200@" "@getRandom()*-200@" "@getRandom()*-200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 -0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%pos = gamebase::getposition(%this);
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%rot = getRandom()*-200@" "@getRandom()*-200@" "@getRandom()*-200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 -0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);
		%pos = gamebase::getposition(%this);
		
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%rot = getRandom()*-200@" "@getRandom()*-200@" "@getRandom()*-200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 -0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);
		%pos = gamebase::getposition(%this);
		
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%rot = getRandom()*-200@" "@getRandom()*-200@" "@getRandom()*-200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 -0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%pos = gamebase::getposition(%this);
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);

		%pos = gamebase::getposition(%this);
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("crazy", %trans1, %player, %rot, %player);
				schedule("spawnNeedleThrower::throwThings(\""@%clientId@"\","@%this@","@%count-2@");",0.3,%this);	// PORT: quoted, the thrower is empty for cluster-shell grenades
	}
	else
		schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}