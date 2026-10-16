$ItemMax[armormSniper, Boost] = 0;
$ItemMax[armorfSniper, Boost] = 0;
$ItemMax[armormScout, Boost] = 0;
$ItemMax[armormMercenary, Boost] = 4;
$ItemMax[armorfMercenary, Boost] = 4;
$ItemMax[armormBurster, Boost] = 0;
$ItemMax[armorCyborg, Boost] = 0;
$ItemMax[armorfScout, Boost] = 0;
$ItemMax[armorfBurster, Boost] = 0;
$ItemMax[armormSpy, Boost] = 0;
$ItemMax[armorfSpy, Boost] = 0;
$ItemMax[armormEngineer, Boost] = 0;
$ItemMax[armorfEngineer, Boost] = 0;
$ItemMax[armormAlien, Boost] = 0;
$ItemMax[armorfAlien, Boost] = 0;
$ItemMax[dmarmor, Boost] = 4;
$ItemMax[dmfemale, Boost] = 4;
$ItemMax[armormLoader, Boost] = 0;
$ItemMax[armorfLoader, Boost] = 0;
$ItemMax[armormSprint, Boost] = 0;
$ItemMax[armorfSprint, Boost] = 0;


MineData BoosterMine
{
	className = "Mine";
   description = "BoosterMine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = jumpMineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 500;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function BoosterMine::onAdd(%this)
{
	%this.damage = 0;
	BoosterMine::deployCheck(%this);
}

function BoosterMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == BoosterMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function BoosterMine::deployCheck(%this)
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
		schedule("BoosterMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function BoosterMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "jumpmineammo"]--;
}

function BoosterMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
