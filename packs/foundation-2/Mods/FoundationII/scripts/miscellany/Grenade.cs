//--------------------------------------

$SellAmmo[Grenade] = 5;
addAPack(Grenade,1);

addToInv(Grenade,1,1);

setArmorItemMax(Grenade,5,5,5);

//--------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = $InvCatMisc;
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   //validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime()) {
		%armor = $ArmorName[Player::getArmor(%player)];
		eval(%armor @ "::onGrenade(" @ %player @ ", " @ %item @ ");");
	}
}

// Normal Hand Grenade-----------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Hand Grenade";
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

// PORT: restored from Foundation 1 (miscellany\MiscGrenade.cs) / stock mine.cs. Foundation II lost it when
// the mine and grenade scripts were split, while five places still schedule it.
function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
