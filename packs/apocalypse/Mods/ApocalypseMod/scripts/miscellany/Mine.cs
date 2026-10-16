//--------------------------------------

$SellAmmo[MineAmmo] = 5;
addAPack(MineAmmo,3);

addToInv(MineAmmo,1,1);

$TeamItemMax[mineammo] = 35;

setArmorItemMax(MineAmmo,3,3,3,3,3,3,3, 9, 1,1,1,1);

//--------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvCatMisc;
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime() && !$Apocalypse::SlugFest) {
		%armor = $ArmorName[Player::getArmor(%player)];
		eval(%armor @ "::onMine(" @ %player @ ", " @ %item @ ");");
	}
}

//Quicksliver Flash Mine----------------
$IsMine[FlashMine] = true;

MineData FlashMine
{
	className = "Mine";
   description = "Flash Bang Mine";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = flashExpLarge;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $FlashDamageType;
	kickBackStrength = 0;
	triggerRadius = 8.0;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FlashMine::onAdd(%this)
{
	%this.damage = 0;
	FlashMine::deployCheck(%this);
}

function FlashMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function FlashMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else
		schedule("FlashMine::deployCheck(" @ %this @ ");", 3, %this);
}

function FlashMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function FlashMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

//Peltast Poison Mine-------------------
$IsMine[VenomMine] = true;

MineData VenomMine
{
	className = "Mine";
   description = "Poison Gas Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $PoisonDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function VenomMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function VenomMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function VenomMine::deployCheck(%this)
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
		schedule("VenomMine::deployCheck(" @ %this @ ");", 3, %this);
}

function VenomMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function VenomMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

//Centurian Cloak Mine-------------------
$IsMine[CloakMine] = true;

MineData CloakMine
{
	className = "Mine";
   description = "Cloak Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.35;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 1.75;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function CloakMine::onAdd(%this)
{
	%this.damage = 0;
	CloakMine::deployCheck(%this);
}

function CloakMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function CloakMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::startFadeout(%this);
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
		schedule("CloakMine::deployCheck(" @ %this @ ");", 3, %this);
}

function CloakMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function CloakMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

//Hoplite Trap Mine---------------------
$IsMine[TrapMine] = true;

MineData TrapMine
{
	className = "Mine";
   description = "Trap Mine";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 150;
	triggerRadius = 3.0;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function TrapMine::onAdd(%this)
{
	%this.damage = 0;
	TrapMine::deployCheck(%this);
}

function TrapMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same) {
		GameBase::setDamageLevel(%this, %data.maxDamage);
		TrapBox::deployShape(%object, 15);
	}
}

function TrapMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::startFadeout(%this);
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
		schedule("TrapMine::deployCheck(" @ %this @ ");", 3, %this);
}

function TrapMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function TrapMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

function TrapBox::deployShape(%player, %time)
{
	%client = Player::getClient(%player);
	%position = GameBase::getPosition(%player);
	if(getObjectType(%player) != "Player") %position = Vector::add(%position, "0 0 -2.4");

	//trap field 1
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "-2.3 0 0");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"0 0 1.57");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);

	//trap field 2
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "2.3 0 0");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"0 0 1.57");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);

	//trap field 3
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "0 -2.3 0");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"0 0 0");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);

	//trap field 4
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "0 2.3 0");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"0 0 0");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);

	//trap field 5
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "0 2.4 4.7");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"1.57 0 0");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);

	//trap field 6
	%objTrapWall = newObject("TrapBox","StaticShape",TrapBox,true);
	%pos = Vector::add(%position, "0 2.4 0.2");
	GameBase::setTeam(%objTrapWall,GameBase::getTeam(%player));
	GameBase::setPosition(%objTrapWall,%pos);
	GameBase::setRotation(%objTrapWall,"1.57 0 0");
	Gamebase::setMapName(%objTrapWall,"Trap Box");
	GameBase::startFadeIn(%objTrapWall);
	addToSet("MissionCleanup", %objTrapWall);
	schedule("GameBase::setDamageLevel(" @ %objTrapWall @ ", 25);", %time);
}

StaticShapeData TrapBox
{
	shapeFile = "forcefield_5x5";
	damageSkinData = "objectDamageSkins";
	maxDamage = 20;
	maxEnergy = 80;
	mapFilter = 2;
	visibleToSensor = false;
	explosionId = debrisExpSmall;
	debrisId = defaultDebrisSmall;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Trap Box";
	shieldShapeName = "shield";
};

function TrapBox::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
}

//Guardian Normal Mine------------------
$IsMine[AntipersonelMine] = true;

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
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
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
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (TeamCompare(%this,%object) != Same))
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

//Myrmidon Teleport Mine---------------------
$IsMine[TeleMine] = true;

MineData TeleMine
{
	className = "Mine";
   description = "Teleport Mine";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 5.0;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function TeleMine::onAdd(%this)
{
	%this.damage = 0;
	TeleMine::deployCheck(%this);
}

function TeleMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same) {
		GameBase::setDamageLevel(%this, %data.maxDamage);
		BaseTele(%object, "");
	}
}

function TeleMine::deployCheck(%this)
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
		schedule("TeleMine::deployCheck(" @ %this @ ");", 3, %this);
}

function TeleMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function TeleMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

//Apocalypse Repulse Mine---------------
$IsMine[RepulseMine] = true;

MineData RepulseMine
{
	className = "Mine";
   description = "Repulse Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 0.25;
	damageType = $StormDamageType;
	kickBackStrength = 350;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function RepulseMine::onAdd(%this)
{
	%this.damage = 0;
	RepulseMine::deployCheck(%this);
}

function RepulseMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || $IsMine[%data] == true || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && TeamCompare(%this,%object) != Same)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function RepulseMine::deployCheck(%this)
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
		schedule("RepulseMine::deployCheck(" @ %this @ ");", 3, %this);
}

function RepulseMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function RepulseMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value)
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else
		%this.damage += %value;
}

