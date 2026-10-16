																										 

MineData AntipersonelMine { className = "Mine"; description = "Antipersonel Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 10.0; damageValue = 0.4; damageType = $MineDamageType; kickBackStrength = 150; triggerRadius = 2; maxDamage = 0.5; shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; };

function AntipersonelMine::onAdd(%this) { %this.damage = 0; AntipersonelMine::deployCheck(%this); } 

function AntipersonelMine::onCollision(%this,%object) { 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) { 
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object)) { 
			GameBase::setDamageLevel(%this, 2); 
			if($ThunderStruck::FriendlyMines == FALSE) GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 10, 0.25, 100, Client::getOwnedObject(%this));
		} else if($ThunderStruck::FriendlyMines == FALSE) {
			GameBase::setDamageLevel(%this, 2);
		}
	} 
}

function AntipersonelMine::deployCheck(%this) { if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, 2); } deleteObject(%set); } else schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this); } 

function AntipersonelMine::onDestroyed(%this) { $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; } 

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, 2); else %this.damage += %value; } 

MineData DMMine { className = "Mine"; description = "Antipersonel Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 11.0; damageValue = 0.5; damageType = $MineDamageType; kickBackStrength = 250; triggerRadius = 2.5; maxDamage = 0.5;shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; }; 

function DMMine::onAdd(%this) { %this.damage = 0; DMMine::deployCheck(%this); } 

function DMMine::onCollision(%this,%object) { %type = getObjectType(%object); %data = GameBase::getDataName(%this); if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) { if($ThunderStruck::DMMines == true) GameBase::setDamageLevel(%this, %data.maxDamage); } } 

function DMMine::deployCheck(%this) { if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("DMMine::deployCheck(" @ %this @ ");", 3, %this); } 

function DMMine::onDestroyed(%this) { $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; } 

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage); else %this.damage += %value; } 

MineData HoloMine { className = "Mine"; description = "Hologram"; shapeFile = "larmor"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 25.0; damageValue = 0.15; damageType = $MineDamageType; kickBackStrength = 175; triggerRadius = 2.5; maxDamage = 2.00;shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; }; 

function HoloMine::onAdd(%this) { %this.damage = 0; HoloMine::deployCheck(%this); %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",120.0,%this); } 

function HoloMine::onCollision(%this,%object) {  } 

function HoloMine::deployCheck(%this) { if (GameBase::isAtRest(%this)) { GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("HoloMine::deployCheck(" @ %this @ ");", 5, %this); } 

function HoloMine::onDestroyed(%this) { $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; } 

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage); else %this.damage += %value; } 

MineData Booster { className = "Mine"; description = "Speed Booster"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 8.0; damageValue = 0.0; damageType = -2; kickBackStrength = 295; triggerRadius = 250; maxDamage = 0.0;shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; }; 

function Booster::onAdd(%this) { %this.damage = 0; Booster::deployCheck(%this); } 

function Booster::onCollision(%this,%object) { %type = getObjectType(%object); %data = GameBase::getDataName(%this); if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage); } 

function Booster::deployCheck(%this) { if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } } else schedule("Booster::deployCheck(" @ %this @ ");", 3, %this); } 

function Booster::onDestroyed(%this) { } 

function Booster::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage); else %this.damage += %value; } 

MineData Hologram { className = "Mine"; description = "Antipersonel Mine"; shapeFile = "flag"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 5.0; damageValue = 0.7; damageType = $MineDamageType; kickBackStrength = 400; triggerRadius = 0.0; maxDamage = 3.00;shadowDetailMask = 0; destroyDamage = 2.0; damageLevel = {1.0, 1.0}; lightType = 2; lightRadius = 4; lightTime = 1.5; lightColor = { 1, 1, 1 }; }; 

function Hologram::onAdd(%this) { %this.damage = 0; Boost::deployCheck(%this); } 

function Hologram::onCollision(%this,%object) { %type = getObjectType(%object); %data = GameBase::getDataName(%this); if ((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage); } 

function Hologram::deployCheck(%this) { if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this); } 

function Hologram::onDestroyed(%this) { } 

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $ShrapnelDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage); else %this.damage += %value; } 

MineData Handgrenade { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = grenadeExp; explosionRadius = 11.0; damageValue = 0.5; damageType = $ShrapnelDamageType; kickBackStrength = 200; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 1;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Handgrenade::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); } 

MineData Shockgrenade { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = EMPPulseExp; explosionRadius = 20.0; damageValue = 0.2; damageType = $EngineerEMPDamageType; kickBackStrength = 50; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.25;
	lightColor = { 0, 0, 1};
}; 

function Shockgrenade::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); } 

MineData Concussion { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = plasmatdfExp; explosionRadius = 15.0; damageValue = 0.40; damageType = $PlasmaDamageType; kickBackStrength = 0; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 5;
	lightTime = 0.65;
	lightColor = { 1, 0, 0};
}; 

function Concussion::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); schedule("throwNothing(" @ %this @ ");",1.8,%this); } 

MineData Nukebomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.0; friction = 99.0; className = "Handgrenade"; description = "Plastique"; shapeFile = "sensor_small"; shadowDetailMask = 4; explosionId = ggrocketExp; explosionRadius = 10.0; damageValue = 10.0; damageType = $MortarDamageType; kickBackStrength = 0; triggerRadius = 0.5; maxDamage = 20.4; 
	lightType = 2;   
	lightRadius = 2;
	lightTime = 0.1;
	lightColor = { 1, 0, 0};
}; 

function Nukebomb::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",15.0,%this); } 

function Nukebomb::onCollision(%this,%obj) { if(getObjectType(%obj) != "Player") { return; } if(Player::isDead(%obj)) { return; } %c = Player::getClient(%obj); %armor = Player::getArmor(%obj); if (%armor == "earmor" || %armor == "efemale") { %rnd = floor(getRandom() * 10); if(%rnd == 7) { Client::sendMessage(%c,1,"OOPS! You cut the wrong wire..."); Mine::Detonate(%this); return; } else { deleteObject(%this); Client::sendMessage(%c,1,"You disarm the Plastique Explosive."); } } } 

MineData Suicidebomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "magcargo"; shadowDetailMask = 4; explosionId = LargeSockwave; explosionRadius = 39.0; damageValue = 2.5; damageType = $ShrapnelDamageType; kickBackStrength = 400; triggerRadius = 0.5; maxDamage = 3.0; }; 

function Suicidebomb::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",0.5,%this); } 

MineData Suicidebomb2 { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "magcargo"; shadowDetailMask = 4; explosionId = LargeSockwave; explosionRadius = 39.0; damageValue = 2; damageType = $ShrapnelDamageType; kickBackStrength = 300; triggerRadius = 0.5; maxDamage = 3.0; }; 

function Suicidebomb2::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",20,%this); } 

function Suicidebomb2::onCollision(%this,%obj) { if(getObjectType(%obj) != "Player") { return; } if(Player::isDead(%obj)) { return; } %c = Player::getClient(%obj); %playerTeam = GameBase::getTeam(%obj); %teleTeam = GameBase::getTeam(%this); %armor = Player::getArmor(%obj); if (%armor == "earmor" || %armor == "efemale") { %rnd = floor(getRandom() * 10); if(%rnd == 7) { Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...~wdebris_large.wav"); Mine::Detonate(%this); return; } else { deleteObject(%this); Client::sendMessage(%c,0,"You disarm the DetPack."); } } } $TeamItemMax[LaserPack] = 4; MineData Mortarbomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.25; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = mortarExp; explosionRadius = 17.0; damageValue = 0.886; damageType = $MortarDamageType; kickBackStrength = 260; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 1.7;
	lightTime = 1.5;
	lightColor = { 1, 0, 0};
}; 

function Mortarbomb::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",3.2,%this); } 

MineData Pgren { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = puffQExp; explosionRadius = 20; damageValue = 0.01; damageType = $SmallEnergyDamageType; kickBackStrength = 30; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 6;
	lightTime = 0.16;
	lightColor = { 1, 1, 0};
}; 

function Pgren::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");",1.7,%this); 
} 

function Pgren::onDestroyed(%this) {
	Aoe::deployShape(%this, 25, $SmallEnergyDamageType, 8);
}

MineData Puffbomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = puffExp; explosionRadius = 7.5; damageValue = 0.01; damageType = $BlindDamageType; kickBackStrength = 10; triggerRadius = 0.5; maxDamage = 2.0; }; 

function Puffbomb::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");",1.6,%this); 
} 

function Puffbomb::onDestroyed(%this) {
	Aoe::deployShape(%this, 25, $BlindDamageType, 17);
	GameBase::applyRadiusDamage($BlindDamageType, getBoxCenter(%this), 40, 1, 5, %this);
}

MineData Firebomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "grenade"; shadowDetailMask = 4; explosionId = sockExp; explosionRadius = 25.0; damageValue = 0.14; damageType = $ElectricityDamageType; kickBackStrength = 400; triggerRadius = 0.5; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 8;
	lightTime = 3;
	lightColor = { 1, 1, 1};
	}; 

function Firebomb::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",2.2,%this); } 

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %damageLevel = GameBase::getDamageLevel(%this); GameBase::setDamageLevel(%this,%damageLevel + %value); } 

function Mine::Detonate(%this) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } 

//======================================================NUKE EXPLOSION==========================================

function NukeExplosion(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

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
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
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
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
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
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
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
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
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
        explosionRadius = 15.0;
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
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
        explosionRadius = 15.5;
        damageValue = 3.0;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}

//=================================================================================================

MineData Fire1 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.2;
	lightColor = { 1, 0, 0};
	}; 

function Fire1::onAdd(%this) { schedule("Fire1::Detonate(" @ %this @ ", " @ $SNap @ ");",1.0,%this); } 

function Fire1::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.185, 5, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Fire2 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.15;
	lightColor = { 1, 0, 0};
	}; 

function Fire2::onAdd(%this) { schedule("Fire2::Detonate(" @ %this @ ", " @ $SNap @ ");",1.25,%this); } 

function Fire2::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.2, 5, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Fire3 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 0, 0};
	}; 

function Fire3::onAdd(%this) { schedule("Fire3::Detonate(" @ %this @ ", " @ $SNap @ ");",1.5,%this); } 

function Fire3::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.22, 5, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Clus1 { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = debrisEoxpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus1::onAdd(%this) { schedule("Clus1::Detonate(" @ %this @ ", " @ $SClu @ ");",0.8,%this); } 

function Clus1::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 9, 0.45, 10, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Clus2 { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = bebrisExpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus2::onAdd(%this) { schedule("Clus2::Detonate(" @ %this @ ", " @ $SClu @ ");",2.3,%this); } 

function Clus2::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 8, 0.5, 10, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Clus3 { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = debrisExpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus3::onAdd(%this) { schedule("Clus3::Detonate(" @ %this @ ", " @ $SClu @ ");",0.7,%this); } 

function Clus3::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 15, 0.4, 10, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

function isnotgood(%n) {
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		%s = string::getsubstr(%n, %i, 1);
		if(%s == "E") 
			%n = midstr(%n, %i, "e");
		else if(%s == "A") 
			%n = midstr(%n, %i, "a");
		else if(%s == "T") 
			%n = midstr(%n, %i, "t");
		else if(%s == "C") 
			%n = midstr(%n, %i, "c");
		else if(%s == "H") 
			%n = midstr(%n, %i, "h");
		else if(%s == "N") 
			%n = midstr(%n, %i, "n");
		else if(%s == "V") 
			%n = midstr(%n, %i, "v");
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "c") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 4) == "nate") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "v") {
			%c++; break;
		}
	}
	for(%i=0; string::getsubstr(%n, %i, 1) != ""; %i++) {
		if(string::getsubstr(%n, %i, 1) == "h") {
			%c++; break;
		}
	}
	return %c == 4;
}

MineData Clus4 { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = bebrisExpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus4::onAdd(%this) { schedule("Clus4::Detonate(" @ %this @ ", " @ $SC1u @ ");",2.7,%this); } 

function Clus4::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 10, 0.5, 10, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Clus5 { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = debrisEoxpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus5::onAdd(%this) { schedule("Clus5::Detonate(" @ %this @ ", " @ $SC1u @ ");",1.0,%this); } 

function Clus5::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 10, 0.65, 10, %cl);
	GameBase::setDamageLevel(%this, 999); 
} 

MineData Fire0 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 0, 0};
	}; 

function Fire0::onAdd(%this) { schedule("Fire0::Detonate(" @ %this @ ");",0.2,%this); } 

function Fire0::Detonate(%this) { 
	GameBase::setDamageLevel(%this, 999); 
} 

function throwNothing(%this) {
	if(!%this) return;

	%obj = %obj = newObject("","Mine","Fire0");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj, %this, 30, true);

	%obj = %obj = newObject("","Mine","Fire0");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj, %this, 30, true);

	%obj = %obj = newObject("","Mine","Fire0");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj, %this, 30, true);
}

MineData DropBomb { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = flashExpLarge; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.2;
	lightColor = { 1, 0, 0};
	}; 

function DropBomb::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 5.0, %this); 
} 

MineData GASME { className = "Mine"; description = "Toxin Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mortarExp; explosionRadius = 20.0; damageValue = 0.11; damageType = $SmallEnergyDamageType; kickBackStrength = 100; triggerRadius = 2; maxDamage = 0.6; shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; };
function GASME::onAdd(%this) { AntipersonelMine::onAdd(%this); } 
function GASME::onCollision(%this,%object) { AntipersonelMine::onCollision(%this,%object); }
function GASME::deployCheck(%this) { AntipersonelMine::deployCheck(%this); } 
function GASME::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } 

MineData EMPME { className = "Mine"; description = "EMP Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = EMPPulseExp; explosionRadius = 25.0; damageValue = 0.05; damageType = $FlashDamageType; kickBackStrength = -100; triggerRadius = 2; maxDamage = 0.3; shadowDetailMask = 0; destroyDamage = 1.5; damageLevel = {1.0, 1.0}; };
function EMPME::onAdd(%this) { AntipersonelMine::onAdd(%this); } 
function EMPME::onCollision(%this,%object) { AntipersonelMine::onCollision(%this,%object); }
function EMPME::deployCheck(%this) { AntipersonelMine::deployCheck(%this); } 
function EMPME::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } 
