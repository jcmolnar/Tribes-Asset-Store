//----------------------------------------------------------------------------
// MINE DYNAMIC DATA
//----------------------------------------------------------------------------

MineData AntipersonelMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
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
	if(getTeam(%this,%object) == Same)
		return;
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && getteam(%this,%object) != Same) 
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
   if(%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData Handgrenade //-Normal Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.8;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.75;
};

MineData Flash //-Flash Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExp;
	explosionRadius = 20.0;
	damageValue = 0.0;
	damageType = $FlashDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 0.75;
};

MineData Frag //-Frag Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

MineData Smoke //-Smoke Screen Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = SmokerExp1;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $SmokeDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.75;
};

MineData Electronic //-Mine Sweeper Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = energyExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineSweeperDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

MineData EMP //-EMP mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $ProtonDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.75;
};

MineData Blast //-Tazer Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $TazerDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0.75;
};

MineData Incendiary //-Incendiary Mode
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $FlameDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

MineData AntiMine //- Effect for killing Mines
{
	className = "Mine";
	description = "AntiMine";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = energyExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineSweeperDamageType;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntiMine::onAdd(%this)
{
	schedule("Mine::Detonate("@%this@");",0.1,%this);
}

function Handgrenade::onAdd(%this)
{
	echo(%this.thrower);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

//--------------------------------------

function Mine::Detonate(%this)
{
	%player = %this.thrower;
	%data = GameBase::getDataName(%this);
	%vel = Item::getVelocity(%this);
	%client = Player::getClient(%player);
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	if(%data == "Handgrenade" && $NadeEllipseObj != "" && $NadeEllipseObj != "Handgrenade") {
		CreateEllipse(%pos,$NadeEllipseObj,$NadeEllipseType,$NadeEllipseLength);
		deleteobject(%this);
	}		
	else if(%data == "flash") {
		
		GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else if(%data == "Frag") {
		GameBase::setDamageLevel(%this,%data.maxDamage);
		%rot = "0 0 0";
		%vec = Vector::getfromrot(%rot);
		%trans = %rot@" "@%vec@" "@%rot@" "@%pos;
		//%proj0 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
		//%proj1 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
		//%proj2 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
		//%proj3 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
		//%proj4 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
		//%proj5 = Projectile::spawnProjectile("FragFlech",%trans,%client,%vel);
	}
	else if(%data == "smoke") {
		GameBase::playSound(%this,SoundGas,0);
		GameBase::playSound(%this,SoundStartGas,1);
		SetSmokers(%pos);
		GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else if(%data == "Electronic") {
		%set = newObject("set",SimSet);
		if(containerBoxFillSet(%set,$MineObjectType,%pos,25,25,25,-25)) {
			if(Group::objectCount(%set) <= 0)
				return;
			for(%i = 0; %i < Group::objectCount(%set); %i++) {
				%mine = Group::getObject(%set,%i);
				%mineType = GameBase::getDataName(%mine);
				%MinePos = GameBase::getPosition(%mine);
				if(getTeam(%client,%mine) != Same && %mineType.className == "Mine") {
					Item::setVelocity(%mine,"0 0 0");
					deleteobject(%mine);
					%client.tempMinesKilled++;
					%obj = newObject("","Mine","AntiMine");
					addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%MinePos);
				}
			}
			if(%client.tempMinesKilled <= 0 || !%client.tempMinesKilled || %client.tempMinesKilled == "")
				%client.tempMinesKilled = 0;
			if(%client.tempMinesKilled != 1)
				%s = "s";
			Client::sendMessage(%client,0,"You Destroyed "@%client.tempMinesKilled@" Enemy Mine"@%s@".");
		}
		GameBase::setDamageLevel(%this,%data.maxDamage);
		schedule(%client@".tempMinesKilled = 0;",3.0,%client);
	}
	else if(%data == "emp") {
		
		GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else if(%data == "blast") {
		
		GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else if(%data == "incendiary") {
		
		GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else
		GameBase::setDamageLevel(%this,%data.maxDamage);
}