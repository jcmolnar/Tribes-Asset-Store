
//----------------------------------------------------------------------------
// MINE DYNAMIC DATA
###Ejecting DTS Data

MineData BulletDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTBullet";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function BulletDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function BulletDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//=================================

MineData PlasmaDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTPlasma";
   shapeFile = "plasammo";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function PlasmaDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function PlasmaDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//=================================

MineData GrenadeDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTGrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function GrenadeDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function GrenadeDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//=================================

MineData MortarDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTMortar";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function MortarDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function MortarDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//=================================

MineData DiscDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTDisc";
   shapeFile = "discammo";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function DiscDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function DiscDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}

//=================================

MineData RocketDTSEJCT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "EJCT";
   description = "EJCTRocket";
   shapeFile = "rocket";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function RocketDTSEJCT::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function RocketDTSEJCT::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}
//--------------------------------------

MineData AntipersonelMine2
{
	className = "Mine";
   description = "Antipersonel Mine2";
   shapeFile = "mine";
   validateShape = false;
   validateMaterials = false;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 0.6;
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
		GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); }

function AntipersonelMine2::deployCheck(%this) 
{
	 if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("AntipersonelMine2::deployCheck(" @ %this @ ");", 3, %this); }


function AntipersonelMine2::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "CMineAmmo"]--;
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



MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = shockwave;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 450;
	triggerRadius = 150.0;
	maxDamage = 0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.0001,%this);
}

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == AntipersonelMine || %data == MiniMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		%pickAnim = radnomItems(4, 34, 34, 33, 28);
		Player::setAnimation(%object, %pickAnim);
	}
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


//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.5;
	friction = 0.5;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "Discb";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = -450;
	triggerRadius = 150.0;
	maxDamage = 0;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.0001,%this);
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



//----------------------------------------------------------------------------


MineData Bomba
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = GrenadeExp;
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}


MineData Bombe
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 25.0;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0;
        damageType = $AtomicDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}