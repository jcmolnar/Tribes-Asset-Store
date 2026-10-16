//--------------------------------------

$SellAmmo[BF] = 1;
$AmmoPackMax[BF] = 1;
$AmmoPackItems[4] = B1;

$AutoUse[BF] = True;
//--------------------------------------

$InvList[BF] = 1;
$RemoteInvList[BF] = 1;

//--------------------------------------

ItemData BF
{
   description = "The Big One";
   shapeFile = "magcargo";
   heading = "rExtra Equipment";
   shadowDetailMask = 4;
   price = 500;
	className = "Weapon";
   validateShape = true;
   validateMaterials = true;
};



function BF::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","B1");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData B1
{
   mass = 300;
   drag = 1.0;
   density = 3.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "The Big One";
   shapeFile = "MagCargo";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 200.0;
	damageValue = 10;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 9;
};

function B1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",25.0,%this);
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