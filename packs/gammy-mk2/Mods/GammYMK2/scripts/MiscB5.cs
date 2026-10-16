//--------------------------------------

$SellAmmo[BF5] = 5;
$AmmoPackMax[BF5] = 10;
$AmmoPackItems[4] = B5;

//--------------------------------------

$InvList[BF5] = 1;
$RemoteInvList[BF5] = 1;

//--------------------------------------

ItemData BF5
{
   description = "Death Tree";
   shapeFile = "grenade";
   heading = "rTools";
   shadowDetailMask = 4;
   price = 500;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function BF5::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","B5");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,10 + %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData B5
{
   mass = 3;
   drag = 0.0;
   density = 3.0;
	elasticity = 1.85;
	friction = 0.0;
	className = "HandGrenade";
   description = "Death Tree";
   shapeFile = "Tree1";
   shadowDetailMask = 4;
   explosionId = rocketexp;
	explosionRadius = 30.0;
	damageValue = 2.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 90;
};

function B5::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.02;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	
}

//--------------------------------------