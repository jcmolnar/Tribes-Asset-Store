//===============================
// Mine Data
//===============================


// Anti-Personel Mine		- Scout, Goliath
// Proximity Mine		- Engineer
// SubSpace Mine		- Chemeleon
// Mock-Repair Kit		- Assassin
// Speed Boost			- Mercinary
// Flag Mine			- Assassin
// ShockWave			- Arbitor
// Replicator			- Engineer

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
	if (GameBase::isAtRest(%this))
	{
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
	Hologram::deployCheck(%this);	// PORT: was Boost::deployCheck -- no such function; the decoy never armed
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

//==================================================================================================== Replicator

MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = NukeShockwave;
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

function ReplicatorMine::onAdd(%this)
{
	%this.damage = 0.0;
	ReplicatorMine::deployCheck(%this);
}

function ReplicatorMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	
	if (((%type == "Player")  || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //JR 1/31/99
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ReplicatorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		%team = GameBase::getTeam(%this);
		echo(%team @ " in deploy check");

		$TeamItemCount[%team @ "replicatingmine"]++;
		
		if(%this.generation == 0)
			$TeamItemCount[%team @ "originalreplicatingmine"]++;
 	
	 	GameBase::setActive(%this,true);
		
		%set = newObject("set",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine])
		{
			%this.generation = 5;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ReplicatorMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ReplicatorMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	echo(%team @ " in on Destroyed");

	$TeamItemCount[%team @ "replicatingmine"]--;

	if(%this.generation < 4)
		replicateMines(%this, %this.generation+1);
}

function ReplicatorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.3;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function replicateMines(%this, %generation)
{
	%team = GameBase::getTeam(%this);
	echo("Creating generation " @ %generation @ " for team " @ %team);

	%obj = newObject("","Mine","ReplicatorMine");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);

	%obj = newObject("","Mine","ReplicatorMine");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);
}


