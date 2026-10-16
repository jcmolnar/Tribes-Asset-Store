//--------------------------------------

$SellAmmo[Grenade] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackItems[4] = Grenade;

//--------------------------------------

$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;

//--------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "vMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			if ($Debug) echo ("Throw Time = " @ %player.throwTime);
			if ($Debug) echo ("Sim   Time = " @ getSimTime());
			%client = Player::getClient(%player);
		
			Player::decItemCount(%player,%item);

			%armor = Player::getArmor(%player);

			if (%armor == "larmor" || %armor == "lfemale")
			{ 
				%obj = newObject("Nade","Mine","HandGrenade");
				bottomprint(%client, "Normal Nade", 10); 
			}		

			if (%armor == "Warmor")	
                        { 
				%obj = newObject("Frisbee","Mine","Grenade2");
				bottomprint(%client, "Frisbee Nade", 10); 
			}			

			if (%armor == "Barmor")
			{ 
				%obj = newObject("Displacer","Mine","Grenade5");
				bottomprint(%client, "Displacer Nade", 10); 
			}
			
			if (%armor == "Sarmor" || %armor == "aarmor")
			{ 
				%obj = newObject("Rocket","Mine","Grenade4");
				bottomprint(%client, "Rocket Nade", 10); 
			}
	
			if (%armor == "Xarmor")
				{ 
				%obj = newObject("Alienuke","Mine","Grenade6");
				bottomprint(%client, "Nuclear Nade", 10); 
			}	
			
			if (%armor == "Marmor" || %armor == "harmor")
				{ 
				%obj = newObject("Alienuke","Mine","Grenade3");
				bottomprint(%client, "Big Nade", 10); 
			}	

 	 	 	addToSet("MissionCleanup", %obj);
			
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);			
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
}

//--------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 1.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 200;
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

//------------------------------------
//--------------------------------------

MineData grenade2
{
   mass = 0.2;
   drag = 0.7;
   density = 2.0;
	elasticity = 0.15;
	friction = 0.4;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Discb";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 2.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 200;
	triggerRadius = 1.5;
	maxDamage = 2;
};

function grenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
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

//------------------------------------
//--------------------------------------

MineData grenade3
{
   mass = 0.2;
   drag = 0.2;
   density = 2.0;
	elasticity = 0.15;
	friction = 0.9;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Mortar";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 10.0;
	damageValue = 2.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function grenade3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
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

//------------------------------------
//--------------------------------------

MineData grenade4
{
   mass = 0.1;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.45;
	friction = 1.0;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Rocket";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 1.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function grenade4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
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

//------------------------------------
//--------------------------------------

MineData grenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Shield_Large";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 40.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 500;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function grenade5::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
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


MineData grenade6
{
   mass = 0.1;
   drag = 0.1;
   density = 1.0;
	elasticity = 0.15;
	friction = 0.1;
	className = "Handgrenade";
   description = "Grenade";
   shapeFile = "Shotgunex";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 100.0;
	damageValue = 0.5;
	damageType = $AlienDamageType;
	kickBackStrength = 50;
	triggerRadius = 1.5;
	maxDamage = 2;
};

function grenade6::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
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