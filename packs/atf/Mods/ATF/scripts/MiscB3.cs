//--------------------------------------

$SellAmmo[BF3] = 5;
$AmmoPackMax[BF3] = 10;
$AmmoPackItems[10] = B3;

//--------------------------------------

$InvList[BF3] = 1;
$RemoteInvList[BF3] = 1;

//--------------------------------------

ItemData BF3
{
   description = "Plastique Bombs";
   shapeFile = "Ammo1";
   heading = "rHaCk's Tools";
   shadowDetailMask = 4;
   price = 200;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function BF3::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","B3");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData B3
{
   mass = 3;
   drag = 1.0;
   density = 3.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Platique Bomb";
   shapeFile = "Ammo1";
   shadowDetailMask = 4;
   explosionId = FlashExpLarge;
	explosionRadius = 6.0;
	damageValue = 20.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 20;
	triggerRadius = 0.5;
	maxDamage = 9;
};

function B3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
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