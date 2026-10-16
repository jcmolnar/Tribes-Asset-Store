//--------------------------------------

$SellAmmo[BF4] = 5;
$AmmoPackMax[BF4] = 10;
$AmmoPackItems[4] = B4;

//--------------------------------------

$InvList[BF4] = 1;
$RemoteInvList[BF4] = 1;

//--------------------------------------

ItemData BF4
{
   description = "Self-Destruct Mechanism";
   shapeFile = "ammo1";
   heading = "rHaCk's Tools";
   shadowDetailMask = 4;
   price = 1500;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function BF4::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			%client.score-=5;
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","B4");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData B4
{
   mass = 3;
   drag = 1.0;
   density = 3.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "HandGrenade";
   description = "Self-Destruct Mechanism";
   shapeFile = "Laserhit";
   shadowDetailMask = 4;
   explosionId = Mortarexp;
	explosionRadius = 100.0;
	damageValue = 50.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 9;
};

function B4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.01,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 1.02;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	
}

//--------------------------------------