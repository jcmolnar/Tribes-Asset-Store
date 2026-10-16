echo("Loading Screaming Fist Version");
//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

//*************************************************************************************************************
// SF Addition - Begin - 8/3/99 - 12:00 PM
//*************************************************************************************************************

MineData Giblet
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 0.0;
	className = "Giblet";
   description = "Giblet";
   shapeFile = "giblet";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Giblet::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("deleteObject("@%this@");", 0.6,%this);
}

function Giblet::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}
//--------------------------------------------
//  Reloader

MineData smallTurretFullShell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "smallTurretFullShell";
   description = "Turret Ammo";
   shapeFile = "fullshell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function smallTurretFullShell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 0.5,%this);
}

function smallTurretFullShell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

function smallTurretFullShell::onCollision(%this,%object)
{
	deleteObject(%this);
}

//--------------------------------------------
// Reloader

MineData turretFullShell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "turretFullShell";
   description = "Turret Ammo";
   shapeFile = "bigFullShell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function turretFullShell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 0.5,%this);
}

function turretFullShell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

function turretFullShell::onCollision(%this,%object)
{
	deleteObject(%this);
}
//--------------------------------------------

MineData turretshell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "turretshell";
   description = "turretshell";
   shapeFile = "50cal";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function turretshell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function turretshell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//--------------------------------------------

MineData bigturretshell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "bigturretshell";
   description = "bigturretshell";
   shapeFile = "bigShell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function bigturretshell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function bigturretshell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//--------------------------------------------

MineData mortarshell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "mortarshell";
   description = "mortarshell";
   shapeFile = "mortarShell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function mortarshell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function mortarshell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//--------------------------------------------
// 50 Cal

MineData bigshell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "bigshell";
   description = "bigshell";
   shapeFile = "50cal";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function bigshell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function bigshell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}
//--------------------------------------------

MineData shotgunshell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.25;
	friction = 1.0;
	className = "shotgunshell";
   description = "shotgunshell";
   shapeFile = "sshell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function shotgunshell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function shotgunshell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//--------------------------------------------
MineData shell
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "shell";
   description = "shell";
   shapeFile = "shell";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function shell::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function shell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//--------------------------------------------

MineData IncenDebris
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 1.5;
	className = "IncenDebris";
   description = "IncenDebris";
   shapeFile = "incendebris";
   shadowDetailMask = 4;
   explosionId = debrisIncenExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $MAWIncendiaryRifleDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.2;
	maxDamage = 2;
};

function IncenDebris::onAdd(%this)
{
	IncenDebris::deployCheck(%this);
	schedule("IncenDebris::Detonate("@%this@");", 2.0,%this);
}

function IncenDebris::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
		schedule("IncenDebris::Detonate("@%this@");",0.0,%this);
	else 
		schedule("IncenDebris::deployCheck("@%this@");", 0.1, %this);
}

function IncenDebris::Detonate(%this)
{
	%client = $IncenDebrisClient[%this];
	$IncenDebrisClient[%this] = 0;
	//echo("client - detonate ",%client);
	%data = GameBase::getDataName(%this);
	%pos = GameBase::getPosition(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	GameBase::applyRadiusDamage($MAWIncendiaryRifleDamageType, %pos, 6, 0.2, 50, %client);
}

//---------------------------------------------------------------

MineData RemoteMine
{
	className = "Mine";
   description = "Remote Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 12.5;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.0;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 0.2;
	damageLevel = {1.0, 1.0};
};

function RemoteMine::onAdd(%this)
{
	%this.damage = 0;
	schedule("RemoteMine::deployCheck("@%this@");",0.1, %this);
}

function RemoteMine::deployCheck(%this)
{
	%team = GameBase::getTeam(%this);
	%cl = $MineClient[%this];
	$MineClient[%this] = 0;
	RemoteMine::CheckDet(%this,%cl);
}

function RemoteMine::CheckDet(%this, %cl)
{
	%det = $RemDet[%cl];
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
	}
	if ( %det == TRUE )
	{
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else
		schedule("RemoteMine::CheckDet("@%this@","@%cl@");", 1, %this);
}

function RemoteMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	//echo("%team ",%team);
	//echo($TeamItemCount[GameBase::getTeam(%this) @ "RemMineAmmo"]);
	$TeamItemCount[GameBase::getTeam(%this) @ "RemMineAmmo"]--;
}

function RemoteMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
      	%value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function RemoteMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData ConcGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "ConcGrenade";
   description = "ConcGrenade";
   shapeFile = "concus-grenade";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.1;
	damageType = $FlashDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ConcGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	//echo("%this = ", %this);
	schedule("ConcGrenade::Detonate(" @ %this @ ");",2.0,%this);
}

function ConcGrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ConcGrenade::Flash(%player, %time)
{
	if(%time != 0)
	{
		%flash = Player::getDamageFlash(%player);
		if(%flash <= 0.4)
			Player::setDamageFlash(%player, 1.0);
		%time--;
		schedule("ConcGrenade::Flash("@%player@","@%time@");",0.2, %player);
	}
}
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//----------------------------------------------------------------------------
MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 12.5;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 0.2;
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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
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
	%team = GameBase::getTeam(%this);
	//echo("%team ",%team);
	//echo($TeamItemCount[GameBase::getTeam(%this) @ "MineAmmo"]);
	$TeamItemCount[GameBase::getTeam(%this) @ "MineAmmo"]--;
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

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "hand-grenade";
   shadowDetailMask = 4;
   explosionId = mineExp;
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
	//echo("%this = ", %this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData NBase
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = flashExpLarge;
        explosionRadius = 0.0;
        damageValue = 0.0;
	damageType = $MineDamageType;
        kickBackStrength = 450;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};


MineData NRing1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 50.0;
        damageValue = 1.1;
	damageType = $MineDamageType;
        kickBackStrength = 450;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing4
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.55;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing5
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NCloud1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
MineData NCloud2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
MineData NCloud3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
MineData NCloud4
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
MineData NCloud5
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 15.0;
        damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};


function NBase::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}
function NRing1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}
function NRing2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
function NRing3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.7,%this);
}
function NRing4::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.9,%this);
}
function NRing5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}
function NCloud1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud4::onAdd(%this)
{                                                    
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.2,%this);
}

