
MineData DuelMine
{
   className = "Mine";
   description = "Duel Mine";
   shapeFile = "mine";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
   shadowDetailMask = 4;
   explosionId = mineExp;
   explosionRadius = 10.0;
   damageValue = 0.65 * $Nappy::MineDamage;
   damageType = $MineDamageType;
   kickBackStrength = 150;
   triggerRadius = 2.5;
   maxDamage = 0.5;
   shadowDetailMask = 0;
   destroyDamage = 1.0;
   damageLevel = {1.0, 1.0};

};


function DuelMine::onAdd(%this)
{
	%this.damage = 0;
	DuelMine::deployCheck(%this);
	schedule("Mine::Detonate(" @ %this @ ");", 30.0, %this); 
}

function DuelMine::onCollision(%this,%object)
{
	%owner = Client::getOwnedObject(%this.deployClient);
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == DuelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (%object != %owner)){ 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
}

function DuelMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) {
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
		schedule("DuelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function DuelMine::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function DuelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}



//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________
//____________________________________________________________________________________________

MineData AntiEnemyMine
{
   className = "Mine";
   description = "AntiEnemy Mine";
   shapeFile = "mine";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
   shadowDetailMask = 4;
   explosionId = mineExp;
   explosionRadius = 10.0;
   damageValue = 0.65 * $Nappy::MineDamage;
   damageType = $MineDamageType;
   kickBackStrength = 150;
   triggerRadius = 2.5;
   maxDamage = 0.5;
   shadowDetailMask = 0;
   destroyDamage = 1.0;
   damageLevel = {1.0, 1.0};
};

function AntiEnemyMine::onAdd(%this)
{
	%this.damage = 0;
	AntiEnemyMine::deployCheck(%this);
}

function AntiEnemyMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntiEnemyMine || %data == Vehicle || %type == "Moveable") &&	GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))){ 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
}

function AntiEnemyMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) {
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
		schedule("AntiEnemyMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntiEnemyMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntiEnemyMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Nukebomb - Plastique Explosive
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 2.0 * $Nappy::GrenadeDamage; 
   damageType = $MortarDamageType; 
   kickBackStrength = 300; 
   triggerRadius = 0.5; 
   maxDamage = 2.0; 
}; 

function Nukebomb::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",15.0,%this); 
} 

function Nukebomb::onCollision(%this,%obj) 
{ 
	if(getObjectType(%obj) != "Player"){ 
		return; 
	} 
	if(Player::isDead(%obj)){ 
		return; 
	} 
	%c = Player::getClient(%obj); 
	%armor = Player::getArmor(%obj); 
	if(%armor == "engarmor" || %armor == "engfemale"){ 
		%rnd = floor(getRandom() * 10); 
		if(%rnd > 8){ 
			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire..."); 
			Mine::Detonate(" @ %this @ "); 
			return; 
		} 
		else{ 
			deleteObject(%this); 
			Client::sendMessage(%c,1,"You disarm the Plastique Explosive."); 
		} 
	} 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                             Hologram Mine
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

MineData HoloMine 
{ 
   className = "Mine"; 
   description = "Hologram"; 
   shapeFile = "larmor"; 
   shadowDetailMask = 4; 
   explosionId = mineExp; 
   explosionRadius = 15.0; 
   damageValue = 0.75 * $Nappy::GrenadeDamage; 
   damageType = $MineDamageType; 
   kickBackStrength = 350; 
   triggerRadius = 2.5; 
   maxDamage = 2.00;
   shadowDetailMask = 0; 
   destroyDamage = 1.0; 
   damageLevel = {1.0, 1.0}; 
}; 

function HoloMine::onAdd(%this) 
{ 
	%this.damage = 0; 
	HoloMine::deployCheck(%this); 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this); 
} 

function HoloMine::onCollision(%this,%object) 
{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
		GameBase::setDamageLevel(%this, %data.maxDamage); 
} 

function HoloMine::deployCheck(%this) 
{ 
	if(GameBase::isAtRest(%this)) { 
		GameBase::setActive(%this,true); 
		%set = newObject("set",SimSet); 
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { 
			%data = GameBase::getDataName(%this); 
			GameBase::setDamageLevel(%this, %data.maxDamage); 
		} 
		deleteObject(%set); 
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
	if(%type == $MineDamageType) 
		%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
		%this.damage += %value; 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Shockgrenade
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

MineData Shockgrenade 
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
   explosionId = Shockwave; 
   explosionRadius = 20.0; 
   damageValue = 0.2 * $Nappy::GrenadeDamage; 
   damageType = $ShockDamageType; 
   kickBackStrength = 50; 
   triggerRadius = 0.5; 
   maxDamage = 2.0; 
}; 

function Shockgrenade::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
} 






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Tranqgrenade
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   explosionId = Shockwave; 
   explosionRadius = 10.0; 
   damageValue = 0.15 * $Nappy::GrenadeDamage; 
   damageType = $PoisonDamageType; 
   kickBackStrength = 0; 
   triggerRadius = 0.5; 
   maxDamage = 2.0; 
}; 

function Tranqgrenade::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Concussion
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 0.50 * $Nappy::GrenadeDamage; 
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





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Mortarbomb
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 1.0 * $Nappy::GrenadeDamage; 
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





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Firebomb
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   damageValue = 0.1 * $Nappy::GrenadeDamage; 
   damageType = $ElectricityDamageType; 
   kickBackStrength = 650; 
   triggerRadius = 0.5; 
   maxDamage = 2.0; 
}; 

function Firebomb::onAdd(%this) 
{
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
}


//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}



MineData Booster 
{ 
   className = "Mine"; 
   description = "Speed Booster"; 
   shapeFile = "mine"; 
   shadowDetailMask = 4; 
   explosionId = mineExp; 
   explosionRadius = $Nappy::SpeedBoostRadius; 
   damageValue = 0.0; 
   damageType = $BoostDamageType; 
   kickBackStrength = $Nappy::SpeedBoostStrength; 
   triggerRadius = 250; 
   maxDamage = 0.0;
   shadowDetailMask = 0; 
   destroyDamage = 1.0; 
   damageLevel = {1.0, 1.0}; 
}; 

function Booster::onAdd(%this) 
{ 
	%this.damage = 0; 
	Booster::deployCheck(%this); 
} 

function Booster::onCollision(%this,%object) 
{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage); 
} 

function Booster::deployCheck(%this) 
{ 
	if(GameBase::isAtRest(%this)) { 
		GameBase::playSequence(%this,1,"deploy"); 
		GameBase::setActive(%this,true); 
		%set = newObject("set",SimSet); 
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { 
			%data = GameBase::getDataName(%this); 
			GameBase::setDamageLevel(%this, %data.maxDamage); 
		} 
	} 
	else 
		schedule("Booster::deployCheck(" @ %this @ ");", 3, %this); 
} 

function Booster::onDestroyed(%this) { } 

function Booster::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{ 
	if(%type == $MineDamageType) 
		%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
		%this.damage += %value; 
} 



//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}

MineData BounceMine
{
   mass = 0.6;
   drag = 1.0;
   density = 2.0;
   elasticity = 0.5;
   friction = 1.0;
   className = "Mine";
   description = "AntiEnemy Mine";
   shapeFile = "mine";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
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

function BounceMine::onAdd(%this)
{
	%this.damage = 0;
	BounceMine::deployCheck(%this);
}

function BounceMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == BounceMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function BounceMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) {
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
		schedule("BounceMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function BounceMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function BounceMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Suicidebomb
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   explosionRadius = 70.0; 
   damageValue = 4.0 * $Nappy::BombDamage; 
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
	if(getObjectType(%obj) != "Player") { 
		return; 
	} 
	if(Player::isDead(%obj)) { 
		return; 
	} 
	%c = Player::getClient(%obj); 
	%armor = Player::getArmor(%obj); 
	if(%armor == "engarmor" || %armor == "engfemale") { 
		%rnd = floor(getRandom() * 10); 
		if(%rnd > 7) { 
			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire..."); 
			schedule("Mine::Detonate(" @ %this @ ");",0,%this);
			return; 
		} 
		else { 
			deleteObject(%this); 
			Client::sendMessage(%c,1,"You disarm the DetPack."); 
		} 
	} 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Firebomb2
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

MineData Firebomb2 
{ 
   mass = 0.3; 
   drag = 1.0; 
   density = 2.0; 
   elasticity = 0.15; 
   friction = 1.0; 
   className = "Handgrenade"; 
   description = "Handgrenade"; 
   shapeFile = grenade; 
   shadowDetailMask = 4; 
   explosionId = flashExpLarge; 
   explosionRadius = 30.0; 
   damageValue = 0.1; 
   damageType = $ElectricityDamageType; 
   kickBackStrength = 650; 
   triggerRadius = 0.5; 
   maxDamage = 2.0;
   isVisible = True; 
}; 

function Firebomb2::onAdd(%this) 
{
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
 
}









