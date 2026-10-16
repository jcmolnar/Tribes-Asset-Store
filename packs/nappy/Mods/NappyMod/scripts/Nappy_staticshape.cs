


function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//messageall(1, "static shape on damage");
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%object) == -1) {
		%name = GameBase::getDataName(%object);
		if(%name.className == "ARMOR") {
			%dValue = %damageLevel;
		}
	}
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
   %this.lastDamageObject = %object;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if (%this.shieldStrength) {
		if(%this.lastDamageTeam == -1)
			%value =0;
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else if (%type == $MortarDamageType)
				%strength *= 0.25;
		else if (%type == $BlasterDamageType)
				%strength *= 2.0;
		%absorb = %energy * %strength;
		if (%value < %absorb) {
			GameBase::setEnergy(%this,%energy - (%value / %strength));
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);
			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);
			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;
			if(GameBase::getDataName(%this) == PulseSensor)
				%zOffset = (%pointZ-%centerPosZ) * 0.5;
			GameBase::activateShield(%this,%sphereVec,%zOffset);
		}
		else {
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else {
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}
















//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                                         DOORS
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}
//____________________________________________________________________________________________


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Blast Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData BlastDoorShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "newdoor5";
   maxDamage = 40.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "Blast Door";
};



function BlastDoorShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}

function BlastDoorShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastDoor"]--;
}

function BlastDoorShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              3x4 Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData doorthreebyfourForceFieldShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "forcefield_3x4";
   maxDamage = 20.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "3x4 Field Door";
};

function doorthreebyfourForceFieldShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}

function doorthreebyfourForceFieldShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorthreebyfourForceField"]--;
}

function doorthreebyfourForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              4x8 Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData doorfourbyeightForceFieldShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "forcefield_4x8";
   maxDamage = 20.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "4x8 Field Door";
};

function doorfourbyeightForceFieldShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}

function doorfourbyeightForceFieldShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyeightForceField"]--;
}

function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              4x14 Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData doorfourbyfourteenForceFieldShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "forcefield_4x14";
   maxDamage = 20.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "4x14 Field Door";
};

function doorfourbyfourteenForceFieldShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}

function doorfourbyfourteenForceFieldShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyfourteenForceField"]--;
}

function doorfourbyfourteenForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              4x17 Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData doorfourbyseventeenForceFieldShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "forcefield_4x17";
   maxDamage = 20.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "4x17 Field Door";
};

function doorfourbyseventeenForceFieldShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}

function doorfourbyseventeenForceFieldShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyseventeenForceField"]--;
}

function doorfourbyseventeenForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              5x5 Field Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData doorfivebyfiveForceFieldShape
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "forcefield_5x5";
   maxDamage = 20.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "5x5 Field Door";
};

function doorfivebyfiveForceFieldShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}


function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfivebyfiveForceField"]--;
}

function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Large Platform Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData LargePlatformDoorShape 
{ 
   className = "PlatformDoor";
   damageSkinData = "objectDamageSkins";
   shapeFile = "elevator16x16_octo"; 
   maxDamage = 45.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true; 
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge; 
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "Large Platform Door";

}; 

function LargePlatformDoorShape::Destruct(%this)
{
	DoorShape::doDamage(%this);
}


function LargePlatformDoorShape::onDestroyed(%this)
{
	DoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargePlatformDoor"]--;
}

function LargePlatformDoorShape::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	DoorShape::openDoor(%this);
	return;
}



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Door Code
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function DoorShape::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function DoorShape::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 600");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DoorShape::closeDoor("@%this@");",4);
}

function DoorShape::closeDoor(%this) 
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 -600");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

//""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
//{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//                                         
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}{}
//____________________________________________________________________________________________




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Blast Wall
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData BlastWall 
{ 
   shapeFile = "newdoor5"; 
   maxDamage = 60.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge;
}; 

function BlastWall::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--; 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel One Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdooroneRShape
{
   shapeFile = "newdoor1_r";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel One Right";
};

function newdooroneRShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdooroneR"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Two Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoortwoRShape
{
   shapeFile = "newdoor2_r";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Two Right";
};

function newdoortwoRShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoortwoR"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Three Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoorthreeRShape
{
   shapeFile = "newdoor3_r";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Three Right";
};

function newdoorthreeRShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoorthreeR"]--;

}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Four Right
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoorfourRShape
{
   shapeFile = "newdoor4_r";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Four Right";
};

function newdoorfourRShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoorfourR"]--;
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel One Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdooroneLShape
{
   shapeFile = "newdoor1_l";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel One Left";
};

function newdooroneLShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdooroneL"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Two Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoortwoLShape
{
   shapeFile = "newdoor2_l";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Two Left";
};

function newdoortwoLShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoortwoL"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Three Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoorthreeLShape
{
   shapeFile = "newdoor3_l";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Three Left";
};

function newdoorthreeLShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoorthreeL"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Panel Four Left
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData newdoorfourLShape
{
   shapeFile = "newdoor4_l";
   debrisId = defaultDebrisLarge;
   maxDamage = 30.0 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Panel Four Left";
};

function newdoorfourLShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "newdoorfourL"]--;
}



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Force Field
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableForceFieldShape 
{ 
   shapeFile = "forcefield_5x5"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 25.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   isTranslucent = true; 
   description = "Force Field"; 
}; 

function DeployableForceFieldShape::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceField"]--; 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Large Force Field
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData LargeForceFieldShape 
{ 
   shapeFile = "forcefield"; 
   debrisId = defaultDebrisLarge; 
   maxDamage = 40.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   isTranslucent = true; 
   description = "Force Field"; 
}; 

function LargeForceFieldShape::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--; 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployablePlatformShape 
{ 
   shapeFile = "elevator6x6thin"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 25.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   isTranslucent = true; 
   description = "Deployable Platform"; 
}; 

function DeployablePlatformShape::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployablePlatform"]--; 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Medium Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData MediumPlatformShape 
{ 
   shapeFile = "elevator_8x8"; 
   maxDamage = 40.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge; 
   isTranslucent = true; 
}; 

function MediumPlatformShape::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "MediumPlatform"]--; 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Large Platform
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData LargePlatformShape 
{ 
   shapeFile = "elevator16x16_octo"; 
   maxDamage = 80.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = true; 
   debrisId = defaultDebrisLarge; 
   explosionId = debrisExpLarge; 
}; 

function LargePlatformShape::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargePlatform"]--; 
} 










StaticShapeData TeleportBeam
{
   shapeFile = "zap_5";
   maxDamage = 10000.0;
   isTranslucent = true;
   description = "Electrical Beam";
   disableCollision = true;
};


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Teleport Pad
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableTeleport 
{ 
   className = "DeployableTeleport"; 
   damageSkinData = "objectDamageSkins"; 
   shapeFile = "flagstand"; 
   maxDamage = 3.75 * $Nappy::StaticShapeStrength; 
   maxEnergy = 200; 
   mapFilter = 2; 
   visibleToSensor = true; 
   explosionId = mortarExp; 
   debrisId = flashDebrisLarge; 
   lightRadius = 12.0; 
   lightType=2; 
   lightColor = {1.0,0.2,0.2}; 
}; 

function RemoveBeam(%b) 
{ 
	deleteObject(%b); 
} 

function DeployableTeleport::Destruct(%this) 
{ } 

function DeployableTeleport::onDestroyed(%this) 
{ 
%team = GameBase::getTeam(%this);
$TeamTeleNum[%team,%this.teleNum] = 0;
	schedule("RemoveBeam("@%this.beam1@");",1); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleportPack"]--; 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this){ 
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this); 
			return; 
		} 
	} 
} 




function DeployableTeleport::onCollision(%this,%obj) 
{ 
	if(getObjectType(%obj) != "Player"){ 
		return; 
	} 
	if(Player::isDead(%obj)){ 
		return; 
	} 
	%c = Player::getClient(%obj); 
	%playerTeam = GameBase::getTeam(%obj); 
	%teleTeam = GameBase::getTeam(%this); 
	if(%teleTeam != %playerTeam){ 
		if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale")) 
			Client::SendMessage(%c,0,"Phased through enemy teleporter"); 
		else{ 
			Client::SendMessage(%c,0,"Wrong Team"); 
			return; 
		} 
	} 
	if(%this.disabled == true){ 
		Client::SendMessage(%c,0,"Teleport Pad is recharging"); 
		return; 
	} 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam && %o.teleNum == %this.teleNum + 1){ 
			if((Player::getArmor(%obj) == "zarmor")){ 
				Client::SendMessage(%c,0,"Cannot teleport in this character class"); 
				return; 
			} 
			else{ 
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true; 
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1);
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			} 
		} 
	} 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam){
			if(%o.teleNum == 0 && (%o.teleNum != %this.teleNum)){
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true; 
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1);
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			}
		} 
	} 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam){
			if(%o.teleNum == 1 && (%o.teleNum != %this.teleNum)){
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true;
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1);
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			}
		} 
	} 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam){
			if(%o.teleNum == 2 && (%o.teleNum != %this.teleNum)){
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true;
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1); 
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			}
		} 
	} 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam){
			if(%o.teleNum == 3 && (%o.teleNum != %this.teleNum)){
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true;
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1); 
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			}
		} 
	} 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){ 
		if(GameBase::getTeam(%o) == %playerteam){
			if(%o.teleNum == 4 && (%o.teleNum != %this.teleNum)){
				GameBase::playSound(%o,ForceFieldOpen,0); 
				GameBase::playSound(%this,ForceFieldOpen,0); 
				//GameBase::SetPosition(%obj,GameBase::GetPosition(%o)); 
				%o.Disabled = true; 
				%this.Disabled = true;
				GameBase::startFadeOut(%obj);
				GameBase::startFadeOut(%o.beam1);
				GameBase::startFadeOut(%this.beam1); 
				schedule("DeployableTeleport::SetPlayerPosition("@%obj@","@%o@");",$Nappy::TeleportTime); 
				schedule("DeployableTeleport::Reenable("@%o@");",$Nappy::TeleportReenableTime); 
				schedule("DeployableTeleport::Reenable("@%this@");",$Nappy::TeleportReenableTime); 
				return; 
			}
		} 
	} 
	Client::SendMessage(%c,0,"No other pad to teleport to"); 
} 

function DeployableTeleport::SetPlayerPosition(%obj,%tele)
{
	GameBase::SetPosition(%obj,GameBase::GetPosition(%tele));
	GameBase::startFadein(%obj);
}


function DeployableTeleport::Reenable(%this) 
{ 
	GameBase::startFadein(%this.beam1); 
	%this.disabled = false; 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Flag Stand
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableFlagStand
{
   description = "Deployable Flag Stand";
   shapeFile = "flagstand";
   debrisId = defaultDebrisSmall;
   maxDamage = 3.0 * $Nappy::StaticShapeStrength;
   shadowDetailMask = 4;
   mapFilter = 4;
   explosionId = debrisExpMedium;
   visibleToSensor = true;
};

function DeployableFlagstand::onDestroyed(%this)
{
	if(%this.carryflag != ""){
		%Team = GameBase::getTeam(%this.carryflag);
		%TeamName = getTeamName(GameBase::getTeam(%this.carryflag));
		teamMessages(0, %Team, "Your team flag was dropped in the field!", "", "", "");
		messageall(2,"The " @ %TeamName @ " flag was dropped in the field!~wflag1.wav");
	}
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "FlagstandPack"]--;
	%flag = %this.carryflag;
	%flag.atflagstand = 0;
	if(%flag != ""){
		%flag.flagstand = "";
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
}



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Spring Pad
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableSpring 
{ 
   shapeFile = "flagstand"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 1.75 * $Nappy::StaticShapeStrength; 
   visibleToSensor = false; 
   isTranslucent = true; 
   description = "Deployable Spring"; 
}; 

function DeployableSpring::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SpringPack"]--; 
} 

function DeployableSpring::onCollision(%this,%obj) 
{ 
	%c = Player::getClient(%obj); 
	if (floor(getRandom() * 30) == 0) { 
		GameBase::playSound(%this, debrisLargeExplosion, 0); 
		Client::SendMessage(%c, 0, "TO THE MOON, ALICE!"); 
		%velocity = 4000; 
		%zVec = 1700; 
		%rnd = floor(getRandom() * 3); 
		if (%rnd == 0) { 
			MessageAll(0,strcat(Nappy::getName(%c), " takes a trip into outer space")); 
		} 
		else if (%rnd == 1) { 
			MessageAll(0,strcat(Nappy::getName(%c), " visits the moon")); 
		} 
		else if (%rnd == 2) { 
			MessageAll(0,strcat(Nappy::getName(%c), " falls off the edge of the earth")); 
		} 
	} 
	else if (floor(getRandom() * 7) == 0) { 
		GameBase::playSound(%this, debrisLargeExplosion, 0); 
		Client::SendMessage(%c, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!"); 
		%velocity = 400; 
		%zVec = 1700; 
	} 
	else { 
		GameBase::playSound(%this, SoundFireMortar, 0); 
		Client::SendMessage(%c, 0, "SPROING!"); 
		%velocity = 200; 
		%zVec = 600; 
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec); 
	Player::applyImpulse(%obj,%jumpDir); 
} 





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Builder Pole
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData BuilderPoleShape 
{ 
   shapeFile = "anten_lrg"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 1.5 * $Nappy::StaticShapeStrength; 
   damageSkinData = "objectDamageSkins"; 
   shadowDetailMask = 16; 
   explosionId = debrisExpMedium; 
   description = "Builder Pole Shape"; 
}; 


function BuilderPoleShape::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BuilderPole"]--; 
} 





//========================================================================
//========================================================================
//========================================================================
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              JAIL STUFF
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
//========================================================================
//========================================================================
//========================================================================




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Capture Pad
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================


StaticShapeData jailpad
{
   shapeFile = "flagstand";
   mountPoint = 2;
   mountOffset = { 0, 0, 0.1 };
   mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
   maxDamage = 1.6 * $Nappy::StaticShapeStrength;
   debrisId = flashDebrisSmall;
};

function jailpad::onCollision(%this,%obj)
{
//messageall(1,"don't touch me");
	if(getObjectType(%obj) != "Player"){
		return;
	}
	if(Player::isDead(%obj)){
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	if(%teleTeam == %playerTeam){
		Client::SendMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
		return;
	}
	%teleset = nameToID("MissionCleanup/jailports");
	%gclient = Nappy::getName(%c);
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){
		%oteam=GameBase::getTeam(%o);
		if(%oteam != %playerTeam){
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
			GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
			schedule("jLargeForceField::jailSesame("@%obj@");",30);
			Client::SendMessage(%c,0,"You are a Prisoner of War for 30 seconds");
		}
	}
	//echo("ADMINMSG: ****" @ %gclient @ " stepped on a jail pad " );
}

function jailpad::Reenable(%this)
{
	%this.disabled = false;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Cell ForceField
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData LLargeForceField
{
   shapeFile = "forcefield";
   debrisId = defaultDebrisLarge;
   maxDamage = 200.00 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Jail Cell";
};

function LLargeForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "jailpack"]--;
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Switch Open
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData JailSwitchOpen
{
   description = "The Jail";
   className = "towerSwitch";
   shapeFile = "tower";
   showInventory = "false";
   visibleToSensor = true;
   mapFilter = 4;
   mapIcon = "M_generator";
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
};

function JailSwitchOpen::onCollision(%this,%obj)
{}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Switch Close
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData JailSwitchClose
{
   description = " The Jail";
   className = "towerSwitch";
   shapeFile = "tower";
   showInventory = "false";
   visibleToSensor = true;
   mapFilter = 4;
   mapIcon = "M_generator";
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
};

function JailSwitchClose::onCollision(%this,%obj)
{}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Cell Door
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData jLargeForceField
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "ForceField";
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "Jail Cell Door";
};

function jLargeForceField::Destruct(%this)
{
	jLargeForceField::doDamage(%this);
}

function jLargeForceField::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function jLargeForceField::onDestroyed(%this)
{
	jLargeForceField::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "jLargeForceField"]--;
}

function jLargeForceField::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	jLargeForceField::openSesame(%this);
	return;
}

function jLargeForceField::openSesame(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("jLargeForceField::closeSesame("@%this@");",4);
}

function jLargeForceField::closeSesame(%this) 
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function jLargeForceField::openSesame(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("jLargeForceField::closeSesame("@%this@");",4);
}

function jLargeForceField::jailSesame(%obj)
{
//messageall(1,"lets get out of here");
	%teleset = nameToID("MissionCleanup/releasepad");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++){
		%oteam = GameBase::getTeam(%o);
		if(%oteam != GameBase::getTeam(%obj)){
			GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
		}
	}

}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Release Pad
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData jailStand
{
   shapeFile = "flagstand";
   debrisId = defaultDebrisSmall;
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
   description = "POW Release Pad";
};

function jailStand::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
}

function jailStand::onCollision(%this,%obj)
{
	Client::SendMessage(%obj,0,"You Have Been Placed In Jail. No Escaping this way! You must wait out your sentence of 30 seconds.");
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Release Pad Top
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData jailStandTop
{
   shapeFile = "flagstand";
   debrisId = defaultDebrisSmall;
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
   description = "POW Release Pad";
};

function jailStandTop::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
}

function jailStandTop::onCollision(%this,%obj)
{
	Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Release Pad Bottom
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData jailStandBottom
{
   shapeFile = "flagstand";
   debrisId = defaultDebrisSmall;
   maxDamage = 200.0 * $Nappy::StaticShapeStrength;
   description = "POW Release Pad";
};

function jailStandBottom::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
}

function jailStandBottom::onCollision(%this,%obj)
{
	Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}



//========================================================================
//========================================================================
//========================================================================
//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              JAIL STUFF
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================
//========================================================================
//========================================================================
//========================================================================





StaticShapeData bLargeForceField
{
   shapeFile = "forcefield";
   debrisId = defaultDebrisLarge;
   maxDamage = 150.00 * $Nappy::StaticShapeStrength;
   visibleToSensor = true;
   isTranslucent = true;
   description = "Remote Base";
};

StaticShapeData bdForceField
{
   className = "LargeForceField";
   damageSkinData = "objectDamageSkins";
   shapeFile = "ForceField";
   maxDamage = 120.0 * $Nappy::StaticShapeStrength;
   maxEnergy = 200;
   mapFilter = 2;
   visibleToSensor = true;
   explosionId = mortarExp;
   debrisId = flashDebrisLarge;
   lightRadius = 12.0;
   lightType=2;
   lightColor = {1.0,0.2,0.2};
   side = "single";
   isTranslucent = true;
   description = "Remote Base Door";
};

function bLargeForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
}

function bdForceField::Destruct(%this)
{
	bdForceField::doDamage(%this);
}

function bdForceField::doDamage(%this) 
{
	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function bdForceField::onDestroyed(%this)
{
	bdForceField::doDamage(%this);
}

function bdForceField::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam){
		return;
	}
	jLargeForceField::openSesame(%this);
	return;
}






//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Tree
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableTree 
{ 
   shapeFile = "tree1"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 40.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = false; 
   isTranslucent = true; 
   description = "Deployable Tree"; 
}; 

function DeployableTree::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Tree 2
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableTree2 
{ 
   shapeFile = "tree2"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 40.0 * $Nappy::StaticShapeStrength; 
   visibleToSensor = false; 
   isTranslucent = true; 
   description = "Deployable Tree"; 
}; 

function DeployableTree2::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Deployable Cactus 2
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData DeployableCactus2 
{ 
   shapeFile = "cactus2"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 8.0 * $Nappy::StaticShapeStrength; 
   description = "Cactus";
   visibleToSensor = true;  
}; 

function DeployableCactus2::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--; 
} 

function DeployableCactus2::onCollision(%this,%obj) 
{ 
	if(getObjectType(%obj) != "Player") { 
		return; 
	} 
	if(Player::isDead(%obj)) { 
		return; 
	} 
	%c = Player::getClient(%obj); 
	%playerTeam = GameBase::getTeam(%obj); 
	%teleTeam = GameBase::getTeam(%this); 
	if(%teleTeam != %playerTeam) { } 
	if(GameBase::getDamageLevel(%obj)) { 
		GameBase::repairDamage(%obj,0.3); 
		GameBase::playSound(%this,ForceFieldOpen,0); 
	} 
$poisonTime[%c] = 0; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              larmor Hologram
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData Hologram1 
{ 
   shapeFile = "larmor"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 0.75 * $Nappy::StaticShapeStrength; 
   description = "Hologram"; 
}; 

function Hologram1::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "HoloPack"]--; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              marmor Hologram
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData Hologram2 
{ 
   shapeFile = "marmor"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 1.10 * $Nappy::StaticShapeStrength; 
   description = "Hologram"; 
}; 

function Hologram2::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "HoloPack"]--; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              harmor Hologram
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData Hologram3 
{ 
   shapeFile = "harmor"; 
   debrisId = defaultDebrisSmall; 
   maxDamage = 1.5 * $Nappy::StaticShapeStrength; 
   description = "Hologram"; 
}; 

function Hologram3::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "HoloPack"]--; 
} 



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Base Alarm
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

StaticShapeData AlarmKit
{
   description = "Base Alarm";
   shapeFile = "sensor_small";
   debrisId = flashDebrisSmall;
   sfxAmbient = SoundBeaconActive;
   maxDamage = 1.0 * $Nappy::StaticShapeStrength;
   mapIcon = "M_marker";
   damageSkinData = "objectDamageSkins";
   visibleToSensor = true;
   triggerRadius = 10.0;
};

function AlarmKit::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if (%type == "Player" && !$pause) {
		$pause = 1;
		schedule("$pause = 0;",10,%this);
		%name = Player::getClient(%object);
		%name = Nappy::getName(%name);
		%team = GameBase::getTeam(%object);
		%itemTeam = GameBase::getTeam(%this);
		if(%team != %itemTeam) {
			TeamMessages(1, %itemTeam,GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name @ "~wLeftMissionArea.wav");
			//echo(GameBase::GetMapName(%this) @ " has been tripped! By: " @ %name);
		}
	}		
}

function AlarmKit::onAdd(%this)
{}
																						 
function AlarmKit::onEnabled(%this)
{}

function AlarmKit::onDisabled(%this)
{}

function AlarmKit::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;
	TeamMessages(1, GameBase::getTeam(%this),GameBase::GetMapName(%this) @  " has been destroyed! ~wLeftMissionArea.wav");
}
