//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) // Added team checking for RSP
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

MineData Nukebomb 
{
 	mass = 0.3;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.0;
 	friction = 99.0;
 	className = "Handgrenade";
 	description = "Plastique";
 	shapeFile = "armorPack";
 	shadowDetailMask = 4;
 	explosionId = rocketExp;
 	explosionRadius = 10.0;
 	damageValue = 3.0;
 	damageType = $MortarDamageType;
 	kickBackStrength = 300;
 	triggerRadius = 0.5;
 	maxDamage = 2.0;
 };

function Nukebomb::onAdd(%this) 
{
 	%data = GameBase::getDataName(%this);
 	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

MineData EMPHandGrenade 
{
 	mass = 0.3;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.15;
 	friction = 1.0;
 	className = "Handgrenade";
 	description = "EMPGrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = TeleportExp;
 	explosionRadius = 15.0;
 	damageValue = 0.001;
 	damageType = $EMPDamageType;
 	kickBackStrength = 0;
 	triggerRadius = 0.5;
 	maxDamage = 2.0;
 };

function EMPHandGrenade::onAdd(%this) 
{
 	%data = GameBase::getDataName(%this);
 	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
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
 		if(%rnd > 4) 
		{
 			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
 			Mine::Detonate(%this);
 			return;
 		}
 		else 
		{
 			deleteObject(%this);
 			Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
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

//----------------------------
MineData KamikazeBomb
{
   	mass = 0.3;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   	description = "Kamikaze Bomb";
   	shapeFile = "mortar";
   	shadowDetailMask = 4;
   	explosionId = KamikazeExp;
	explosionRadius = 30.0;
   	damageValue = 10.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

//Minimod Stuff

MineData Nuke1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke1::onAdd(%this)
{
	%this.damage = 0;
	Nuke1::deployCheck(%this);
}

function Nuke1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke1::deployCheck(%this)
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
		schedule("Nuke1::deployCheck(" @ %this @ ");", 3, %this);
}
//------------------
MineData Nuke2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke2::onAdd(%this)
{
	%this.damage = 0;
	Nuke2::deployCheck(%this);
}

function Nuke2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke2::deployCheck(%this)
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
		schedule("Nuke2::deployCheck(" @ %this @ ");", 3, %this);
}
//----------------------
MineData Nuke3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke3::onAdd(%this)
{
	%this.damage = 0;
	Nuke3::deployCheck(%this);
}

function Nuke3::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke3::deployCheck(%this)
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
		schedule("Nuke3::deployCheck(" @ %this @ ");", 3, %this);
}

///-----------------------------------------------
/// description = "Suicide DetPack";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

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
        explosionRadius = 50.0;
        damageValue = 50.0;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 300;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this)
{
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
//------------
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
        explosionRadius = 50.0;
        damageValue = 50.0;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 300;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};

function Suicidebomb2::onAdd(%this)
{
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
                                                        if(%rnd > 4)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(%this);
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

