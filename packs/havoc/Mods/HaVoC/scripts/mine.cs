
MineData AntipersonelMine { className = "Mine"; description = "Antipersonel Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 10.0; damageValue = 0.38; damageType = $MineDamageType; kickBackStrength = 150; triggerRadius = 2; maxDamage = 0.5; shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; };

function AntipersonelMine::onAdd(%this) {
	%this.damage = 0;
	schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
} 

function AntipersonelMine::onCollision(%this,%object) { 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%object); 
	if ((%type == "Player" || %data == AntipersonelMine || %data == FireMine || %data == StickMine || %data == StickFireMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) { 
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object)) { 
			Mine::Detonate(%this);
			if($HaVoC::FriendlyMines == FALSE) GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 10, 0.25, 100, Client::getOwnedObject(%this));
		} else if($HaVoC::FriendlyMines == FALSE) {
			Mine::Detonate(%this);
		}
	} 
}

function AntipersonelMine::deployCheck(%this) {
   if (GameBase::isAtRest(%this)) {
      GameBase::playSequence(%this,1,"deploy");
      GameBase::setActive(%this,true);

      %set = newObject("set",SimSet);
      %num = containerBoxFillSet(%set, $StaticObjectType | $MineObjectType, GameBase::getPosition(%this), 1, 1, 1, 0);
      for(%i=0; %i < %num; %i++) {
         %obj = Group::getObject(%set, %i);
         if ( %obj != %this ) {
            %data = GameBase::getDataName( Group::getObject(%set, %i) );
            if ( %data == "AntipersonelMine" || %data == "DMMine" || %data == "FireMine" || %data == "GASME" || %data == "EMPME" || %data == "StickFireMine" || %data == "StickMine" ) {
               Mine::Detonate(%this);
               break;
            }
         }
      }
      deleteObject(%set);
   } else
      schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
} 

function AntipersonelMine::onDestroyed(%this) { $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; } 

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) Mine::Detonate(%this); else %this.damage += %value; } 

MineData DMMine { className = "Mine"; description = "Antipersonel Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mineExp; explosionRadius = 11.0; damageValue = 0.5; damageType = $MineDamageType; kickBackStrength = 250; triggerRadius = 2.5; maxDamage = 0.5;shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; }; 

function DMMine::onAdd(%this) { %this.damage = 0; AntipersonelMine::deployCheck(%this); } 

function DMMine::onCollision(%this,%object) { %type = getObjectType(%object); %data = GameBase::getDataName(%this); if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable" || %data == FireMine ) && GameBase::isActive(%this) ) { if($HaVoC::DMMines == true) Mine::Detonate(%this); } } 

function DMMine::onDestroyed(%this) { $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; } 

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { if (%type == $MineDamageType) %value = %value * 0.25; %data = GameBase::getDataName(%this); if((%data.maxDamage/1.5) < %this.damage+%value) Mine::Detonate(%this); else %this.damage += %value; } 

MineData Nukebomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.0; friction = 99.0; className = "Handgrenade"; description = "Plastique"; shapeFile = "sensor_small"; shadowDetailMask = 4; explosionId = ggrocketExp; explosionRadius = 10.0; damageValue = 2.0; damageType = $MortarDamageType; kickBackStrength = 300; triggerRadius = 0.5; maxDamage = 2.4; 
	lightType = 2;   
	lightRadius = 2;
	lightTime = 0.1;
	lightColor = { 1, 0, 0};
}; 

function Nukebomb::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");", 15.0, %this); } 

function Nukebomb::onCollision(%this,%obj) {
   if( getObjectType(%obj) != "Player" )
      return;
   if( Player::isDead(%obj) )
      return;
   %c = Player::getClient(%obj);
   %armor = Player::getArmor(%obj);
   if (%armor == "earmor" || %armor == "efemale") {
      %rnd = floor(getRandom() * 10);
      if(%rnd > 6) {
         Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
         Mine::Detonate(%this);
         return;
      } else {
         deleteObject(%this);
         Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
      }
   }
} 

function Nukebomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { 
	if (%type == $MortarDamageType) %value = %value * 0.25; 
	if(%this.damage + %value > 2.3) {
		if(floor(getRandom() * 30) == 10) {
			Mine::Detonate(%this); 
			return;
		}
		if(floor(getRandom() * 10) < 5)
			GameBase::applyRadiusDamage($MortarDamageType, %pos, 20, 0.5, 200, %object);
		else
			GameBase::applyRadiusDamage($MortarDamageType, %pos, 20, 0.1, 200, %object);
		GameBase::setPosition(%this, "0 0 -6000");
	} else 
		%this.damage += %value; 
}

MineData Suicidebomb { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "magcargo"; shadowDetailMask = 4; explosionId = LargeSockwave; explosionRadius = 57.0; damageValue = 2.85; damageType = $ShrapnelDamageType; kickBackStrength = 500; triggerRadius = 0.5; maxDamage = 3.0; }; 

function Suicidebomb::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",0.5,%this); } 

MineData Suicidebomb2 { mass = 0.3; drag = 1.0; density = 2.0; elasticity = 0.15; friction = 1.0; className = "Handgrenade"; description = "Handgrenade"; shapeFile = "magcargo"; shadowDetailMask = 4; explosionId = LargeSockwave; explosionRadius = 47.0; damageValue = 2.65; damageType = $ShrapnelDamageType; kickBackStrength = 400; triggerRadius = 0.5; maxDamage = 3.0; }; 

function Suicidebomb2::onAdd(%this) { %data = GameBase::getDataName(%this); schedule("Mine::Detonate(" @ %this @ ");",20,%this); } 

function Suicidebomb2::onCollision(%this,%obj) { if(getObjectType(%obj) != "Player") { return; } if(Player::isDead(%obj)) { return; } %c = Player::getClient(%obj); %playerTeam = GameBase::getTeam(%obj); %teleTeam = GameBase::getTeam(%this); %armor = Player::getArmor(%obj); if (%armor == "earmor" || %armor == "efemale") { %rnd = floor(getRandom() * 10); if(%rnd > 6) { Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...~wdebris_large.wav"); Mine::Detonate(%this); return; } else { deleteObject(%this); Client::sendMessage(%c,0,"You disarm the DetPack."); } } } $TeamItemMax[LaserPack] = 4; 

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
	if (%type == $MineDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	%damageLevel = GameBase::getDamageLevel(%this);
	if ( %damageLevel + %value >= %data.maxDamage )
		Mine::Detonate(%this);
	else
		GameBase::setDamageLevel(%this,%damageLevel + %value);
} 

function Mine::Detonate(%this) {
	%data = GameBase::getDataName(%this);
	if ( %data == FireMine ) throwNothing(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
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
	Mine::Detonate(%this);
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
	Mine::Detonate(%this);
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
	Mine::Detonate(%this);
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
	Mine::Detonate(%this);
} 

MineData FlareGren {  mass = 0.7; drag = 0.5; density = 0.1; elasticity = 0.35; friction = 0.4; className = "Mine"; description = "Flares"; shapeFile = "plasmabolt"; shadowDetailMask = 4; explosionId = noExp; explosionRadius = 0.01; damageValue = 0.01; damageType = $NullDamageType; kickBackStrength = 0; triggerRadius = 3; maxDamage = 0.3;
	lightType = 2;
	lightRadius = 9;
	lightTime = 0.4;
	lightColor = { 1, 0, 0}; };

function FlareGren::onAdd(%this) {
	schedule("FlareGren::goAway(" @ %this @ ");", 0.25, %this);
} 

function FlareGren::goAway(%this) {
	GameBase::startFadeOut(%this);
   if ( !%this.hit )
   	schedule("Mine::Detonate(" @ %this @ ");", 2.5, %this);
}

function FlareGren::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
   if( %this.damage + %value < GameBase::getDataName(%this).maxDamage ) {
      %this.damage += %value;
      return;
   }

   %this.hit = true;
   if ( %this.recievedLocksFrom != "" ) {
      GameBase::startFadeOut(%this);
      schedule("transferMissileLocks(" @ %this @ ", " @ %this.recievedLocksFrom @ ");", 0.75);
      schedule("deleteObject(" @ %this @ ");", 0.76);
      %this.playerWhoThrew.lastThrownFlare = "";
   } else
      deleteObject(%this);
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
	Mine::Detonate(%this);
} 

MineData Fire0 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 0, 0};
	}; 

function Fire0::onAdd(%this) { schedule("Fire0::Detonate(" @ %this @ ");",0.2,%this); } 

function Fire0::Detonate(%this) { 
	Mine::Detonate(%this);
} 

function throwNothing(%this) {
   if (!%this) return;
   %pos = GameBase::getPosition(%this);
   for (%i=-3.14; %i < 3.14; %i+=1.4)
      for (%ii=-3.14; %ii < 3.14; %ii+=1.4)
         spawnProj("FireGrenProj", %i @" 0 " @ %ii, %pos, "0 0 0", 2048);
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

MineData GASME { className = "Mine"; description = "Toxin Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = mortarExp; explosionRadius = 24.0; damageValue = 0.11; damageType = $SmallEnergyDamageType; kickBackStrength = 100; triggerRadius = 2; maxDamage = 0.6; shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; };
function GASME::onAdd(%this) { AntipersonelMine::onAdd(%this); } 
function GASME::onCollision(%this,%object) { AntipersonelMine::onCollision(%this,%object); }
function GASME::deployCheck(%this) { AntipersonelMine::deployCheck(%this); } 
function GASME::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } 

MineData EMPME { className = "Mine"; description = "EMP Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = EMPPulseExp; explosionRadius = 32.0; damageValue = 0.05; damageType = $FlashDamageType; kickBackStrength = -100; triggerRadius = 2; maxDamage = 0.3; shadowDetailMask = 0; destroyDamage = 1.5; damageLevel = {1.0, 1.0}; };
function EMPME::onAdd(%this) { AntipersonelMine::onAdd(%this); } 
function EMPME::onCollision(%this,%object) { AntipersonelMine::onCollision(%this,%object); }
function EMPME::deployCheck(%this) { AntipersonelMine::deployCheck(%this); } 
function EMPME::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } 


MineData Fire1 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = $NullDamageType; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; lightType = 2; lightRadius = 4; lightTime = 0.2; lightColor = { 1, 0, 0}; };

function Fire1::onAdd(%this) { schedule("Fire1::Detonate(" @ %this @ ", " @ $SNap @ ");",1.0,%this); }

function Fire1::Detonate(%this, %cl) {
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.185, 5, %cl);
   spawnProj("Napalm1", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
   spawnProj("Napalm1", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
   spawnProj("Napalm2", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
	Mine::Detonate(%this);
}

MineData Fire2 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = $NullDamageType; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; lightType = 2; lightRadius = 4; lightTime = 0.15; lightColor = { 1, 0, 0}; };

function Fire2::onAdd(%this) { schedule("Fire2::Detonate(" @ %this @ ", " @ $SNap @ ");",1.25,%this); }

function Fire2::Detonate(%this, %cl) {
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.2, 5, %cl);
   spawnProj("Napalm1", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
   spawnProj("Napalm1", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
	Mine::Detonate(%this);
}

MineData Fire3 { className = "Mine"; description = "Handgrenade"; shapeFile = "breath"; shadowDetailMask = 4; explosionId = plasmadfExp; explosionRadius = 0; damageValue = 0; damageType = $NullDamageType; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; lightType = 2; lightRadius = 4; lightTime = 0.1; lightColor = { 1, 0, 0}; };

function Fire3::onAdd(%this) { schedule("Fire3::Detonate(" @ %this @ ", " @ $SNap @ ");",1.5,%this); }

function Fire3::Detonate(%this, %cl) {
	GameBase::applyRadiusDamage($PlasmaDamageType, getBoxCenter(%this), 7, 0.22, 5, %cl);
   spawnProj("Napalm2", ( 1.57 + (0.5 - getRandom()) ) @ " 0 0", GameBase::getPosition(%this), "0 0 0", 2048);
	Mine::Detonate(%this);
}

MineData FireMine { className = "Mine"; description = "Plasma Mine"; shapeFile = "mine"; shadowDetailMask = 4; explosionId = plasmatdfExp; explosionRadius = 14.0; damageValue = 0.32; damageType = $PlasmaDamageType; kickBackStrength = 100; triggerRadius = 2; maxDamage = 0.5; shadowDetailMask = 0; destroyDamage = 1.0; damageLevel = {1.0, 1.0}; };
function FireMine::onAdd(%this) { AntipersonelMine::onAdd(%this); } 
function FireMine::onCollision(%this,%object) { AntipersonelMine::onCollision(%this,%object); }
function FireMine::deployCheck(%this) { AntipersonelMine::deployCheck(%this); } 
function FireMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); } 
