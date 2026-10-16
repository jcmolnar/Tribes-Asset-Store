//--------------------------------------

$SellAmmo[MineAmmo3] = 5;
$AmmoPackMax[MineAmmo3] = 5;
$AmmoPackItems[5] = MineAmmo3;

//--------------------------------------

$TeamItemMax[mineammo3] = 35;

//--------------------------------------

$InvList[MineAmmo3] = 1;
$RemoteInvList[MineAmmo3] = 1;

//--------------------------------------

ItemData MineAmmo3
{
   description = "Proxy Decoy";
   shapeFile = "mineammo";
   heading = "rHaCk's Tools";
   shadowDetailMask = 4;
   price = 100;
	className = "HandAmmo";
};

function MineAmmo3::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine3");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData AntipersonelMine3
{
   mass = 3;
   drag = 0.0;
   density = 3.0;
   elasticity = 0.85;
   friction = 0.0;	
   className = "Mine";
   description = "Proxy Decoy";
   shapeFile = "Larmor";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 2.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine3::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine3::deployCheck(%this);
}

function AntipersonelMine3::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine3 || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine3::deployCheck(%this)
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
		schedule("AntipersonelMine3::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine3::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo3"]--;
}

function AntipersonelMine3::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//--------------------------------------