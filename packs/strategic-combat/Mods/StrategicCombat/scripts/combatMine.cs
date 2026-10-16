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
   validateShape = true;
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
   %screen.deployer = %client;
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
   validateShape = true;
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
   %screen.deployer = %client;
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






MineData mdDetPack
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
   elasticity = 0;
   friction = 100;
   className = "Handgrenade";
   description = "Demolition Charge";
   shapeFile = "ammopack";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
   explosionRadius = 2;
   damageValue = 0.2;
   damageType = $DebrisDamageType;
   kickBackStrength = 800;
   triggerRadius = 0;
   maxDamage = 1.4;
};

function mdDetPack::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	DetPackTimer(1.5,%this);
}


// function DetPackCharge::onDestroyed(%this)
// {
// 	$TeamItemCount[ %team @ "Detpack"]--;
// }


function DetpackTimer(%time, %detpack)
{
	if (%time <= 0.1) {
		calcRadiusDamage(%detpack, $ShrapnelDamageType, 2.5, 0.05, 25, 20, 10, 20, 15, 225, 100,%detpack.deployer); 
		calcRadiusDamage(%detpack, $DebrisDamageType, 2.5, 0.05, 25, 10, 5, 20, 15, 225, 100,%detpack.deployer); 
		Mine::Detonate(%detpack);
	} else {
		%pos = GameBase::getPosition(%detpack);
		playSound(SoundMineActivate,%pos);
		%time = %time * 0.75;
		schedule("DetpackTimer("@%time@", "@%detpack@");", %time , %detpack);
	}
}


ItemImageData DetPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.75;
	firstPerson = false;
};

ItemData DetPack
{
	description = "DetPack";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "fBackpacks";
	imageType = DetPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
		bottomprint(Player::getClient(%player), "<jc><f2>The DetPack is a high-yield demolitions charge.", 5);
	} else Player::deployItem(%player,%item);
}

function DetPack::onDeploy(%player,%item,%pos)
{
	if (DetPack::deployShape(%player,%item)) 
		if (!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

function DetPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if ($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3)) {
		if (CheckDeployOn($los::object)) {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			} else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)	%rot = "3.14159 0 0";
				else								%rot = Vector::getRotation($los::normal);
			}

			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set, $ItemObjectType | $SimPlayerObjectType,$los::position,0.5,0.5,0.5,1);
			deleteObject(%set);

			if (!%num) {
				%team = GameBase::getTeam(%player);
				if ($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%rot = GameBase::getRotation(%player);
					%position = $los::position;
	   				%detpack = newObject("DetPack","Mine",mdDetPack);
					addToSet("MissionCleanup", %detpack);
					GameBase::setTeam(%detpack, %team);
					GameBase::setPosition(%detpack,%position);
					GameBase::setRotation(%detpack,%rot);
					%detpack.deployer = %client;
					Gamebase::setMapName(%detpack,"Active DetPack");
					Client::sendMessage(%client,0,"Detpack deployed");
					playSound(SoundDetpackDeploy,$los::position);
					%detpack.disarmed = 0;
					%detpack.team = %team;
					$TeamItemCount[ %team @ "Detpack"]--;
					return true;
				} else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item);
			} else Client::sendMessage(%client,0,"Unable to deploy - item in the way");
		} else Client::sendMessage(%client,0,"Can't deploy on moving objects.");
	} else Client::sendMessage(%client,0,"Deploy position out of range");

	return false;
}


