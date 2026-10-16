//-------------------------------------------
ItemData AirMineAmmo
{
   description = "Ground-Air Mine";
   shapeFile = "mineammo";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

MineData airMine
{
	className = "Mine";
	description = "Ground-Air Mine";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 4.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

FlierData AirMineBob
{
	explosionId = plasmaExp;
	debrisId = flashDebrisMedium;
	className = "Vehicle";
   	shapeFile = "Shield_large";
	mass = 2.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.75;
	maxPitch = 0.75;
	maxSpeed = 0;
	minSpeed = 0;
	lift = 0.75;
	maxAlt = 35;
	maxVertical = 10;
	maxDamage = 0.01;
	damageLevel = {1.0, 1.0};
	damageSound = SoundTankCrash;
	shadowDetailMask = 2;
	description = "Air Mine";
};

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function AirMineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","airMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

function airMine::onAdd(%this)
{
	%this.damage = 0;
	airMine::deployCheck(%this);
}

function airMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AirMine || %data == AntipersonelMine || %data == Vehicle && %data != AirMineBob || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function airMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
		%obj = newObject("","Flier","AirMineBob",true);
		addToSet("MissionCleanup", %obj);
		%position = GameBase::getPosition(%this);
		%NewZ = Vector::add(%position,"0 0 20");
		GameBase::setPosition(%obj, %NewZ);
		$MineBob[%this] = %obj;
		float(%obj);
	}
	else 
		schedule( "airMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function airMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "AirMineAmmo"]--;
	GameBase::setDamageLevel($MineBob[%this],GameBase::getDataName(%this).maxDamage+0.1);
}

function airMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value += 0.5;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function float(%obj)
{
	%position = GameBase::getPosition(%obj);
	%NewZ = Vector::add(%position,"0 0 8.91");
	GameBase::setPosition(%obj, %NewZ);
	schedule( "float(" @ %obj @ ");", 0.5, %obj);
}

//------------------------------------------------

	//$InvList[AirMineAmmo] = 1;
	//$RemoteInvList[AirMineAmmo] = 1;

	$ItemMax[larmor, AirMineAmmo] = 2;
	$ItemMax[marmor, AirMineAmmo] = 2;
	$ItemMax[harmor, AirMineAmmo] = 2;
	$ItemMax[qarmor, AirMineAmmo] = 2;
	$ItemMax[tarmor, AirMineAmmo] = 2;
	$ItemMax[sarmor, AirMineAmmo] = 2;
	$ItemMax[srarmor, AirMineAmmo] = 1;
	$ItemMax[parmor, AirMineAmmo] = 2;
	$ItemMax[lfemale, AirMineAmmo] = 2;
	$ItemMax[mfemale, AirMineAmmo] = 2;
	$ItemMax[qfemale, AirMineAmmo] = 2;
	$ItemMax[sfemale, AirMineAmmo] = 2;
	$ItemMax[srfemale, AirMineAmmo] = 1;
	$ItemMax[pfemale, AirMineAmmo] = 2;
	$ItemMax[psarmor, AirMineAmmo] = 2;
	
	$SellAmmo[AirMineAmmo] = 1;
	$TeamItemMax[AirMineAmmo] = 5;