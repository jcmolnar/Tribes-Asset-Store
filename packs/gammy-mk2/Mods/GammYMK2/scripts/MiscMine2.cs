//--------------------------------------

$SellAmmo[MineAmmo2] = 5;
$AmmoPackMax[MineAmmo2] = 5;
$AmmoPackItems[5] = MineAmmo2;

//--------------------------------------

$TeamItemMax[mineammo2] = 35;

//--------------------------------------

$InvList[MineAmmo2] = 1;
$RemoteInvList[MineAmmo2] = 1;

//--------------------------------------

ItemData MineAmmo2
{
   description = "Enemy Displacer Mine";
   shapeFile = "mineammo";
   heading = "rTools";
   shadowDetailMask = 4;
   price = 30;
	className = "HandAmmo";
};

function MineAmmo2::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine2");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData AntipersonelMine2
{

   className = "Mine";
   description = "Enemy Displacer Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 600;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine2::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine2::deployCheck(%this);
}

function AntipersonelMine2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine2 || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine2::deployCheck(%this)
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
		schedule("AntipersonelMine2::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine2::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo2"]--;
}

function AntipersonelMine2::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
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

//--------------------------------------

$SellAmmo[MineAmmo4] = 5;
$AmmoPackMax[MineAmmo4] = 5;
$AmmoPackItems[5] = MineAmmo4;

//--------------------------------------

$TeamItemMax[mineammo4] = 35;

//--------------------------------------

$InvList[MineAmmo4] = 1;
$RemoteInvList[MineAmmo4] = 1;

//--------------------------------------

ItemData MineAmmo4
{
   description = "Inviso-Mines";
   shapeFile = "mineammo";
   heading = "rTools";
   shadowDetailMask = 4;
   price = 30;
   className = "HandAmmo";
};

function MineAmmo4::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine4");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
		
	}
}

//--------------------------------------

MineData AntipersonelMine4
{	
   className = "Mine";
   description = "Inviso-Mine";
   shapeFile = "Laserhit";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.9;
	damageType = $MineDamageType;
	kickBackStrength = 60;
	triggerRadius = 1.5;
	maxDamage = 10.5;
	shadowDetailMask = 0;
	destroyDamage = 5.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine4::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine2::deployCheck(%this);
}

function AntipersonelMine4::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine2 || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine4::deployCheck(%this)
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
		schedule("AntipersonelMine4::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine4::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo4"]--;
}

function AntipersonelMine4::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
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