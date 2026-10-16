StaticShapeData DefaultBeacon
{
	className = "Mine";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function Beacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}


StaticShapeData ProxyMine
{
	className = "Mine";
   description = "Proximity Mine";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 4.0;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ProxyMine::onAdd(%this)
{
	schedule("GameBase::setActive("@ %this @",true);",4,%this);

}

function ProxyMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	%pos = GameBase::getPosition(%object);
if($Chivalry::FriendMines == "true")
	{
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
		{		
		GameBase::setDamageLevel(%this, %data.maxDamage);
		GameBase::applyRadiusDamage($MineDamageType,%pos,10,0.7,150,%this);
		}
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		GameBase::applyRadiusDamage($MineDamageType,%pos,10,0.7,150,%this);
	}

}

function ProxyMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ProxMine"]--;
	schedule("deleteObject("@ %this @");",1);
	

}

function ProxyMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}