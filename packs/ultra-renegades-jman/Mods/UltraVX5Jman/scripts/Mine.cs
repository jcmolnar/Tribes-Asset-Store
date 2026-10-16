//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData MineofRevenge
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = FireWorkEXP1;
	explosionRadius = $RevengeRadius;
	damageValue = 10.0;
	damageType = $RevengeDamageType;
	kickBackStrength = 1000;
	triggerRadius = 2;
	maxDamage = 10.0;
};

function MineofRevenge::onAdd(%this)   //This is a mine.
{
      if($RevengeInstantDetonation == 1)
         schedule("Mine::Detonate(" @ %this @ ");", 0.3, %this);
      else
      {
       %this.damage = 0;
	   MineofRevenge::deployCheck(%this);
      }

}

//function MineofRevenge::onAdd(%this)
//{
//	%this.damage = 0;
//	MineofRevenge::deployCheck(%this);
//}

function MineofRevenge::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == MineofRevenge || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MineofRevenge::deployCheck(%this)
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
		schedule("MineofRevenge::deployCheck(" @ %this @ ");", 3, %this);
}	

//function MineofRevenge::onDestroyed(%this)
//{
//	$TeamItemCount[GameBase::getTeam(%this) @ "radiusmineammo"]--;
//}

function MineofRevenge::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

	
//--------------------------------------------
MineData FireWorkBomb1
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "PlasmaTrail";
	shadowDetailMask = 4;
	explosionId = FireWorkEXP1;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

//----------------------------------------------
MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 3;
	damageValue = 0.9;
	damageType = $EMPDamageType;
	kickBackStrength = 350;
	triggerRadius = 2;
	maxDamage = 2;
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
	if (((%type == "Player") || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
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
   shapeFile = "grenade";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = grenadeExp;
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
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //echo("Mine  onDamage");
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	 //echo("Mine  Detonate");
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//-----------------------------------------------------------------------

MineData Flash
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Flashgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = FlashgrenadeExp;
	explosionRadius = 30;
	damageValue = 0.20;
	damageType = $FlashDamageType;
	kickBackStrength = 0.01;
	triggerRadius = 5;
	maxDamage = 2;
};

function Flash::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

////////////////////////////////////////////////////////////////////
//function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
//{
//   if (%type == $MineDamageType)
//      %value = %value * 0.25;
//
//	%damageLevel = GameBase::getDamageLevel(%this);
//	GameBase::setDamageLevel(%this,%damageLevel + %value);
//}
//
//function Mine::Detonate(%this)
//{
//	%data = GameBase::getDataName(%this);
//	GameBase::setDamageLevel(%this, %data.maxDamage);
//}
////////////////////////////////////////////////////////////////////
//-----------------------------------------------------------------------------------

MineData Boost
{
	className = "Handgrenade";
   description = "Beacon";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 500; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	//shadowDetailMask = 0;
	//destroyDamage = 1.0;
	//damageLevel = {1.0, 1.0};
};

function Boost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //echo("Boost  onDamage");
   //if (%type == $MineDamageType)
   //   %value = %value * 0.25;

   //	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,2);
}

//-----------------------------------------------------------------------

//-----------------------------------------------------------------------------------

MineData lilBoost
{
	className = "Mine";
   description = "LiLBoost";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 113; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function lilBoost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //echo("Boost  onDamage");
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

//-----------------------------------------------------------------------

MineData BoostBrake
{
	className = "Mine";
   description = "";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 0; //500//-450
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

//-----------------------------------------------------------------------------------------
MineData RadiusMine
{
	className = "Mine";
   description = "Radius Mine";
   shapeFile = "flag";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = radiusmineexp;
	explosionRadius = 75;
	damageValue = 1;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 15;
	maxDamage = 1;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function RadiusMine::onAdd(%this)
{
	%this.damage = 0;
	RadiusMine::deployCheck(%this);
}

function RadiusMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == RadiusMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function RadiusMine::deployCheck(%this)
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
		schedule("RadiusMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function RadiusMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "radiusmineammo"]--;
}

function RadiusMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//-----------------------------------------------------------
MineData VXGasAttack
{
	className = "Mine";
   description = "VX Gas Attack";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = VXGasAttackExp;
	explosionRadius = 8;
	damageValue = 0.9;
	damageType = $SmokeDamageType;
	kickBackStrength = 0;
	triggerRadius = 4;
	maxDamage = 2;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function VXGasAttack::onAdd(%this)
{
	%this.damage = 0;
	VXGasAttack::deployCheck(%this);
}

function VXGasAttack::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == VXGasAttack || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function VXGasAttack::deployCheck(%this)
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
		schedule("VXGasAttack::deployCheck(" @ %this @ ");", 3, %this);
}	

function VXGasAttack::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "VXGasAttackammo"]--;
}

function VXGasAttack::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $SmokeDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//-----------------------------------------------------------------------