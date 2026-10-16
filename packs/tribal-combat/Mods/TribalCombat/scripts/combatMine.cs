//******************
//TRIBAL COMBAT MINE
//******************
MineData mdStealthMine
{
	className = "Mine";
    description = "Stealth Mine";
    shapeFile = "mine";
    shadowDetailMask = 4;
    explosionId = mineExp;
	explosionRadius = 8.0;
	damageValue = 0.2;
	damageType = $MineDamageType;
	kickBackStrength = 120;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mdStealthMine::onAdd(%this)
{
	%this.damage = 0;
	mdStealthMine::deployCheck(%this);
	schedule("mdStealthMine::Conceal("@%this@");",8,%this);
}

function mdStealthMine::Conceal(%this)
{
	GameBase::startFadeOut(%this);
}

function mdStealthMine::onCollision(%this,%object)
{
%type = getObjectType(%object);
%data = GameBase::getDataName(%this);
if((%type == "Player" || %data == mdStealthMine || %data == mdAntiArmorMine || 
%data == AntiPersonelMine || %data == Vehicle || %type == "Moveable")
 && GameBase::isActive(%this) && (GameBase::getTeam(%this) != GameBase::getTeam(%object)) )
  GameBase::setDamageLevel(%this, %data.maxDamage);
}

function mdStealthMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	 {
	  GameBase::playSequence(%this,1,"deploy");
	  GameBase::setActive(%this,true);
	  %set = newObject("set",SimSet);
	  if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	  }
	  else schedule("mdStealthMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mdStealthMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "StealthMine"]--;
}

function mdStealthMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //DAMAGE MODE
	if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
	else %value *= $Combat::DamageScale;

    if(%type == $MineDamageType) %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

//****************************
ItemImageData StealthMineImage
{
shapeFile = "mine";
mountPoint = 2;
mountOffset = { 0, -0.03, 0};
mass = 2.0;
firstPerson = false;
};

ItemData StealthMine
{
description = "Stealth Mine";
shapeFile = "mine";
className = "Backpack";
heading = "gDefense";
imageType = StealthMineImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 50;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function StealthMine::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function StealthMine::onDeploy(%player,%item,%pos)
{
if(StealthMine::deployShape(%player,%item)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

function StealthMine::deployShape(%player,%item)
{
%client = Player::getClient(%player);

if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
  if(GameBase::getLOSInfo(%player,3))
  {
   if (Vector::dot($los::normal,"0 0 1") >= 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %position = $los::position;
   %screen = newObject("StealthMine","Mine",mdStealthMine);
   addToSet("MissionCleanup", %screen);
   GameBase::setTeam(%screen,GameBase::getTeam(%player));
   GameBase::setPosition(%screen,%position);
   GameBase::setRotation(%screen,%rot);
   Gamebase::setMapName(%screen,%name);
   Client::sendMessage(%client,0,"Stealth Mine Deployed");
   GameBase::startFadeIn(%screen);
   $TeamItemCount[GameBase::getTeam(%player) @ "StealthMine"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
  }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}

//**********************
MineData mdAntiArmorMine
{
	className = "Mine";
    description = "Anti Armor Mine";
    shapeFile = "sensor_small";
    shadowDetailMask = 4;
    explosionId = mineExp;
	explosionRadius = 6.0;
	damageValue = 2.0;
	damageType = $MineDamageType;
	kickBackStrength = 300;
	triggerRadius = 4.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mdAntiArmorMine::onAdd(%this)
{
	%this.damage = 0;
	mdAntiArmorMine::deployCheck(%this);
}

function mdAntiArmorMine::onCollision(%this,%object)
{
%type = getObjectType(%object);
%data = GameBase::getDataName(%this);
if((%type == "Player" || %data == mdAntiArmorMine || %data == AntiPersonelMine ||
%data == mdStealthMine || %data == Vehicle || %type == "Moveable") && 
GameBase::isActive(%this) && (GameBase::getTeam(%this) != GameBase::getTeam(%object)) )
  GameBase::setDamageLevel(%this, %data.maxDamage);
}

function mdAntiArmorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	 {
	  GameBase::playSequence(%this,1,"deploy");
	  GameBase::setActive(%this,true);
	  %set = newObject("set",SimSet);
	  if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	  }
	  else schedule("mdAntiArmorMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mdAntiArmorMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiArmorMine"]--;
}

function mdAntiArmorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
	if($Combat::DamageMode == "custom") %value = CustomDamageMode(%value,%type);
	else %value *= $Combat::DamageScale;

    if(%type == $MineDamageType) %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

//*****************************
ItemImageData AntiArmorMineImage
{
shapeFile = "sensor_small";
mountPoint = 2;
mountOffset = { 0, -0.03, 0};
mass = 2.0;
firstPerson = false;
};

ItemData AntiArmorMine
{
description = "Anti Armor Mine";
shapeFile = "sensor_small";
className = "Backpack";
heading = "gDefense";
imageType = AntiArmorMineImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 100;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function AntiArmorMine::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::deployItem(%player,%item);
}

function AntiArmorMine::onDeploy(%player,%item,%pos)
{
if(AntiArmorMine::deployShape(%player,%item)) if(!Player::isDead(%player)) Player::decItemCount(%player,%item);
}

function AntiArmorMine::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
 {
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") >= 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %position = $los::position;
   %screen = newObject("AntiArmorMine","Mine",mdAntiArmorMine);
   addToSet("MissionCleanup", %screen);
   GameBase::setTeam(%screen,GameBase::getTeam(%player));
   GameBase::setPosition(%screen,%position);
   GameBase::setRotation(%screen,%rot);
   Gamebase::setMapName(%screen,%name);
   Client::sendMessage(%client,0,"Anti Armor Mine Deployed");
   playSound(SoundPickupBackpack,$los::position);
   GameBase::startFadeIn(%screen);
   $TeamItemCount[GameBase::getTeam(%player) @ "AntiArmorMine"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
  }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}
