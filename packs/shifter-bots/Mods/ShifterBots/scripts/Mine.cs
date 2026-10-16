
//===============================
//
// Mine Data
//
//===============================

//============================================================================================ Anti-Personel Mine

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
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
	echo("APMine Added");
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
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
		
		deleteObject(%set); //
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

//============================================================================================ Proximity Detection Mine

MineData ProxMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	//shapeFile = "mine";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 20;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ProxMine::onAdd(%this)
{
	echo("Proximity Added");

	%this.damage = 0;
	ProxMine::deployCheck(%this);
}

function ProxMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);

	if ((%type == "Player" || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
	{		
	
		if ($ScreamerDelay == "" || $ScreamerDelay == 0)
		{
			$proxteam = GameBase::getTeam(%this);
	
			$ScreamerDelay = "1";
				
			TeamMessages(1, $proxteam, "Incomming Enemies. ~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav");
			
			schedule("$ScreamerDelay = 0;", 10);
			
			echo ("Alerting Team");
		}

	}		
}

function ProxMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);

		deleteObject(%set); //
	}
	else 
		schedule("ProxMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ProxMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function ProxMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== SubSpace-Cloak Mine

MineData SubspaceMine
{
	className = "Mine";
        description = "Subspace Mine";
        shapeFile = "sensor_small";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function SubspaceMine::onAdd(%this)
{
	echo("SubSpace Mine Added");

	%this.damage = 0;
        SubspaceMine::deployCheck(%this);
}

function SubspaceMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
        GameBase::startFadeOut(%this);
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
	else 
        schedule("SubspaceMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function SubspaceMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        
        if (!(GameBase::getTeam(%object) == GameBase::getTeam(%this)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
        GameBase::setDamageLevel(%this, %data.maxDamage);
}



//==================================================================================================== Mock Repair Pack

MineData HoloMine
{
	className = "Mine";
   description = "Hologram";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 350; //500
	triggerRadius = 2.5; //250
	maxDamage = 2.00;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this)
{
	echo("Holo Mine Added");

	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);

}

function HoloMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		//GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function HoloMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//==================================================================================================== Speed Boost

// Super Speed boost

MineData Booster
{
	className = "Mine";
   description = "Speed Booster";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 300; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Booster::onAdd(%this)
{
	echo("Booster Added");

	%this.damage = 0;
	Booster::deployCheck(%this);
}

function Booster::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Booster::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		//deleteObject(%set); //
	}
	else 
		schedule("Booster::deployCheck(" @ %this @ ");", 3, %this);
}	

function Booster::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Boosert::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== Flag Mine - Decoy

MineData Hologram
{

	className = "Mine";
   description = "Flag";
   shapeFile = "flag";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 5.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 150; //500
	triggerRadius = 2.5; //250 //2.5
	maxDamage = 3.00;//0
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

};

function Hologram::onAdd(%this)
{
	echo("Decoy Mine Added");

	%this.damage = 0;
	Boost::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}	

function Hologram::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $ShrapnelDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== ShockWave Mine

MineData ShockMine
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
   description = "ShockWave Mine";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function ShockMine::onAdd(%this)
{
	
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut(" @ %this @ ");",8.0,%this);

}
function ShockMine::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if (GameBase::getTeam(%this)!= GameBase::getTeam(%obj))
	{
        GameBase::startFadeIn(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
	}
}

function ShockMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//====================================
//
// Grenades
//
//====================================



//==================================================================================================== Standard Grenade

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
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	//damageType = $EnergyDamageType;

	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2.0;
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

//==================================================================================================== TranqGrenade

MineData Tranqgrenade
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
    explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.35;

	damageType = $EnergyDamageType;

	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Tranqgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Tranqgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Tranqgrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

}

//==================================================================================================== EMP Grenade

MineData EMPgrenade
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
    explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.4;
	damageType = $FlashDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function EMPgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function EMPgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $FlashDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== Concussion Grenade

MineData Concussion
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
	explosionRadius = 15.0;
	damageValue = 0.50;
	damageType = $PlasmaDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Concussion::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Concussion::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


// Concussion
MineData Concussion2
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
	explosionRadius = 35.0;
	damageValue = 0.50;
	damageType = $PlasmaDamageType; // burn the victim
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function Concussion2::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Concussion2::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== Plastique

MineData Nukebomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
   description = "Plastique";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = rocketExp;
	explosionRadius = 10.0;
	damageValue = 2.0;
	damageType = $MortarDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Nukebomb::onAdd(%this)
{	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	//Grenade::OnUse(" @ %this @ ");
}

function Nukebomb::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	
		%armor = Player::getArmor(%obj);
   		if (%armor == "earmor" || %armor == "efemale")
		{
			%rnd = floor(getRandom() * 10);
			if(%rnd > 8)
			{	
				Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
				Mine::Detonate(" @ %this @ ");
				return;
			}
			else
			{	
				deleteObject(%this);
				Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
			}
		}
 
  
}

function Nukebomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Nukebomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== Penis Explosion

MineData PenisBlast
{
	className = "Mine";
	description = "Penis";
    shapeFile = "force";
    shadowDetailMask = 4;
    explosionId = LargeShockwave;
    explosionRadius = 5.0;
    damageValue = 0.001;
	damageType = $FlashDamageType;
    kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function PenisBlast::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}



//==================================================================================================== Bot Explosion

MineData BotBlast
{
	className = "Mine";
	description = "Bot Brain";
    shapeFile = "sensor_small";
    shadowDetailMask = 4;
    explosionId = LargeShockwave;
    explosionRadius = 5.0;
    damageValue = 0.001;
	damageType = $FlashDamageType;
    kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function BotBlast::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== CloakBlast

MineData CloakBlast
{
	className = "Mine";
	description = "CloakBlast";
    shapeFile = "force";
    shadowDetailMask = 4;
    explosionId = LargeShockwave;
    explosionRadius = 25.0;
    damageValue = 0.1;
	damageType = $CloakDamageType;
    kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function CloakBlast::onAdd(%this)
{
    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== Nuclear Explosion

MineData NBase
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 25;
        damageValue = 2;
	damageType = $NukeDamageType;
        kickBackStrength = 100;
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
        damageValue = 2.5;
	damageType = $NukeDamageType;
        kickBackStrength = 450;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 1.75;
	damageType = $NukeDamageType;
	kickBackStrength = 250;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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
	damageType = $NukeDamageType;
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


//================================================================================================ Suicide Pack 1 (On Kill)

MineData Suicidebomb
{
    mass = 0.3;
    drag = 1.0;
    density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
    description = "Handgrenade";
    shapeFile = "magcargo";
    shadowDetailMask = 4;
    explosionId = LargeShockwave;
	explosionRadius = 100.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.2;
	maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this)
{        
	schedule("NuclearExplosion(" @ %this @ ");",0.5,%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
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


function NuclearExplosion(%this)
{

				echo(" Nuke Fire" @ Client::setOwnedObject(%this));

                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

	       // Client::setOwnedObject(%client, %turret);
	       // Client::setOwnedObject(%client, %player);
			
				
                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 45.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 75.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//================================================================================================ Suicide Pack 2 On Deploy

MineData Suicidebomb2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "magcargo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 100.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Suicidebomb2::onAdd(%this)
{
	        schedule("NuclearExplosion(" @ %this @ ");",20,%this);
%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20,%this);

}

function Suicidebomb2::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	
%armor = Player::getArmor(%obj);
   		if (%armor == "earmor" || %armor == "efemale")
		{
				%rnd = floor(getRandom() * 10);
				if(%rnd < 3)
				{	
				    Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
					Mine::Detonate(" @ %this @ ");
					return;
				}
				else
				{	
				    deleteObject(%this);
				    Client::sendMessage(%c,1,"You disarm the DetPack.");
				}
		}
   
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

function NuclearExplosion(%this)
{
                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 45.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 60.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 75.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}


//==================================================================================================== Mortar Grenade

MineData Mortarbomb
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
   explosionId = mortarExp;

	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this)
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

//==================================================================================================== Fire Bomb Grenade

MineData Firebomb
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
   explosionId = flashExpLarge;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $ElectricityDamageType;
	kickBackStrength = 650;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
    //  schedule("DeployFrags(" @ %this @ " , 10);",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function DeployFrags(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Frag1");
 		%team = GameBase::getTeam(%this);
            GameBase::setTeam(%obj, %team);
 
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%obj = newObject("","Mine","Frag2");
		%team = GameBase::getTeam(%this);
            GameBase::setTeam(%obj, %team);

 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%obj = newObject("","Mine","Frag3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployFrags(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
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

//==================================================================================================== Frags

MineData Frag1
{
   	
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Frag2
{
   	
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Frag3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

//==================================================================================================== Bomblettes

MineData Bomblet1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Bomblet2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Bomblet3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

