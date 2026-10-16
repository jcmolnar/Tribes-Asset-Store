



$PlayerAnim::Crouching = 25; 
$PlayerAnim::DieChest = 26; 
$PlayerAnim::DieHead = 27; 
$PlayerAnim::DieGrabBack = 28; 
$PlayerAnim::DieRightSide = 29; 
$PlayerAnim::DieLeftSide = 30; 
$PlayerAnim::DieLegLeft = 31; 
$PlayerAnim::DieLegRight = 32; 
$PlayerAnim::DieBlownBack = 33; 
$PlayerAnim::DieSpin = 34; 
$PlayerAnim::DieForward = 35; 
$PlayerAnim::DieForwardKneel = 36; 
$PlayerAnim::DieBack = 37; 
$CorpseTimeoutValue = 22; 

function Player::onAdd(%this,%player) 
{ 
GameBase::setRechargeRate(%this,8); 
Player::jetpackLoop(%this);//<<<<<<<<<<<<<<<<
//Player::damageLoop(%this);//<<<<<<<this too...
//Player::dmgfxLoop(%player);
} 

function Player::onRemove(%this) 
{ 
for (%i = 0; %i < 8; %i = %i + 1) 
{ 
%type = Player::getMountedItem(%this,%i); 

if (%type != -1) 
{ 
%item = newObject("","Item",%type,1,false); 
schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item); 
addToSet("MissionCleanup", %item); 
GameBase::setPosition(%item,GameBase::getPosition(%this)); 
} 
} 
} 

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

function velToSingle(%vel, %bool) // Converts 3-vector velocity to a single number
{
	%x = getWord(%vel, 0);
	%y = getWord(%vel, 1);
	%z = getWord(%vel, 2);

	if(%bool)
		return floor(sqrt((%x*%x)+(%y*%y)+(%z*%z)));
	else
		return sqrt((%x*%x)+(%y*%y)+(%z*%z));
}

function Player::jetpackLoop(%this)
{
	if(Player::isDead(%this))
		return;

	%client = Player::getClient(%this);

	if((%checkRate = $NovaMorpher::JetSmokeRate) == 0)
		%checkRate = 1;
	%heat = GameBase::virtual(%this, "getHeatFactor");

	%plyHimSelf = (Client::getControlObject(%client) == Client::getOwnedObject(%client));
	%plyJet = Player::isJetting(%this);
	%plyOvHt = (%heat >= 0.5);
	%plyHtSync = %this.heatSync;
	if(((%plyJet || %plyOvHt) && !%plyHtSync && %plyHimSelf) && $Armor::SpecialSmoke[%armor] != "No Smoke")
	{
		$JPrate = 10;
		%vel = Item::getVelocity(%this);
		%JetVel = velToSingle(%vel);
		%armor = Player::getArmor(%client);
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%this);
		%trans2 = "0 0 -1 0 0 0 0 0 -1 " @ vector::Add(getBoxCenter(%this), "-0.5 -0.01 -1.25");
		%trans3 = "0 0 -1 0 0 0 0 0 -1 " @ vector::Add(getBoxCenter(%this), "0.5 -0.01 -1.25");

		%armor = Player::getArmor(%this);
		%armorShape = %armor.shapeFile;
		%isntHeavy = (%armorShape == "larmor" || %armorShape == "lfemale" || %armorShape == "marmor" || %armorShape == "mfemale");
//if (%armor == "larmor" || %armor == "lfemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "darmor")

		
//		if($Armor::SpecialSmoke[%armor])
//		{
			
			if (%armor == "barmor")//Paladin
			{
				Projectile::spawnProjectile(palsmoke, %trans2, %this, "0 0 -5");
				Projectile::spawnProjectile(palsmoke, %trans3, %this, "0 0 -5");
			}
			else if(%armor == "darmor")//Atomizer
			{
				Projectile::spawnProjectile(atmsmoke, %trans2, %this, "0 0 -5");
				Projectile::spawnProjectile(atmsmoke, %trans3, %this, "0 0 -5");
			}
			else if(%armor == "aarmor")//Navigator
			{
				Projectile::spawnProjectile(navsmoke, %trans2, %this, "0 0 -5");
				Projectile::spawnProjectile(navsmoke, %trans3, %this, "0 0 -5");
			}
			else if(%armor == "earmor" || %armor == "efemale")//Slave
			{
				//Projectile::spawnProjectile(slvsmoke, %trans, %this, "0 0 -5");
				//Projectile::spawnProjectile(thkslvsmoke, %trans, %this, "0 0 -5");
				Projectile::spawnProjectile(brightslvsmoke, %trans, %this, "0 0 -5");
			}
			
			//%smoke = $Armor::SmokeType[%armor];
//			if(%isntHeavy || !$Armor::SmokeUseHeavy)
//			{
//				Projectile::spawnProjectile(%smoke, %trans, %this, "0 0 -5"); //transform, object, velocity vector, <projectile target (seeker)>
//			}
//			else
//			{
//				Projectile::spawnProjectile(%smoke, %trans2, %this, "0 0 -5");
//				Projectile::spawnProjectile(%smoke, %trans3, %this, "0 0 -5");
//			}
//		}
//		else if(%isntHeavy)
//		{
//			Projectile::spawnProjectile(SFXSmokeLight, %trans, %this, "0 0 -5"); //transform, object, velocity vector, <projectile target (seeker)>
//		}
//		else
//		{
//			if(%this.hasBooster)
//				%proj = smokeBooster;
//			else
//				%proj = SFXSmoke;
//
//			Projectile::spawnProjectile(%proj, %trans2, %this, "0 0 -5");
//			Projectile::spawnProjectile(%proj, %trans3, %this, "0 0 -5");
//     		}
		%nextCheckT = (1/$JPrate)/%checkRate;
		schedule("Player::jetpackloop(" @ %this @ ");", %nextCheckT, %this);
	}
	else
	{
		schedule("Player::jetpackloop(" @ %this @ ");", 0.5/%checkRate, %this);
	}
}

//=====================//
//=====================//

ExplosionData palsmokeExp
{
   shapeName = "chainspk.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData palsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = palsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "chainspk.dts";
};

//=====================//
//=====================//

ExplosionData atmsmokeExp
{
   shapeName = "plasmatrail.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData atmsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = atmsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//=====================//
//=====================//

ExplosionData navsmokeExp
{
   shapeName = "shield.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData navsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = navsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "shield.dts";
};

//=====================//
//=====================//

ExplosionData slvsmokeExp
{
   shapeName = "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 5;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData slvsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = slvsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

ExplosionData thkslvsmokeExp
{
   shapeName = "plastrail.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 5;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData thkslvsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = thkslvsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

ExplosionData brightslvsmokeExp
{
   shapeName = "shotgunex.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.5;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData brightslvsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = brightslvsmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};
//=====================//
//=====================//


//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

//function Player::damageLoop(%this)
//{
//	if(Player::isDead(%this))
//		return;
//
//	%client = Player::getClient(%this);
//
//			
//	if (%armor == "marmor")//Pawn
//	{
//		Projectile::spawnProjectile(palsmoke, %trans2, %this, "0 0 -5");
//		Projectile::spawnProjectile(palsmoke, %trans3, %this, "0 0 -5");
//	}
//
//	else
//	{
//		schedule("Player::damageLoop(" @ %this @ ");", 0.5, %this);
//	}
//}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
function Player::onNoAmmo(%player,%imageSlot,%itemType) { } 

function Player::onKilled(%this) { %cl = GameBase::getOwnerClient(%this); %cl.dead = 1; if($AutoRespawn > 0) schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl); if(%this.outArea==1) leaveMissionAreaDamage(%cl); Player::setDamageFlash(%this,0.75); for (%i = 0; %i < 8; %i = %i + 1) { %type = Player::getMountedItem(%this,%i); if (%type != -1) { if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") Player::dropItem(%this,%type); } } if(%cl != -1) { if(%this.vehicle != "") { if(%this.driver != "") { %this.driver = ""; Client::setControlObject(Player::getClient(%this), %this); Player::setMountObject(%this, -1, 0); if(%this.vehicle == "Wraith") { GameBase::startFadein(%this.vehicle); } } else { %this.vehicle.Seat[%this.vehicleSlot-2] = ""; %this.vehicleSlot = ""; } %this.vehicle = ""; } schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this); $lapTime[%cl] = 0; Client::setOwnedObject(%cl, -1); Client::setControlObject(%cl, Client::getObserverCamera(%cl)); Observer::setOrbitObject(%cl, %this, 5, 5, 5); schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this); %cl.observerMode = "dead"; %cl.dieTime = getSimTime(); } } 


function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object,%player)
{
	
	if (Player::isExposed(%this)) { %damagedClient = Player::getClient(%this); %shooterClient = %object; Player::applyImpulse(%this,%mom); if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) { if (%shooterClient != -1) { %curTime = getSimTime(); if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) { if(%type != $MineDamageType) { Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!"); Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!"); } else { Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!"); Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!"); } %this.LastHarm = %shooterClient; %this.DamageStamp = %curTime; } } %friendFire = $Server::TeamDamageScale; } else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) %friendFire = $Server::TeamDamageScale; else %friendFire = 1.0; if (!Player::isDead(%this)) { %armor = Player::getArmor(%this); if((%vertPos == "head") && (%type == $LaserDamageType || %type == $SniperDamageType)) { if(%armor == "harmor") { if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") { %value += (%value * 0.3); } } else { %value += (%value * 0.3); } } if (%type != -1 && %this.shieldStrength) { %energy = GameBase::getEnergy(%this); %strength = %this.shieldStrength; if (%type == $ShrapnelDamageType || %type == $MortarDamageType) %strength *= 0.75; if (%type == $ElectricityDamageType){ %strength *= 0.0; } %absorb = %energy * %strength; if (%value < %absorb) { GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire)); %thisPos = getBoxCenter(%this); %offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2))); GameBase::activateShield(%this,%vec,%offsetZ); %value = 0; } else { GameBase::setEnergy(%this,0); %value = %value - %absorb; } } if( (%type == $FlashDamageType) && ( Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) ) Shock_Damage(%damagedClient, %this); if ((%type == $EnergyDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) ) { %armor = Player::getArmor(%this); if ((%armor != "aarmor") && (%armor != "afemale")) Renegades_startBlind(%damagedClient, %this); } if ((%type == $PlasmaDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))) { %rnd = floor(getRandom() * 10); if(%rnd > 5) { %armor = Player::getArmor(%this); if ( (%armor != "barmor") && (%armor != "bfemale")) Renegades_startBurn(%damagedClient, %this); } } %armor = Player::getArmor(%this); if ( (%type == $EnergyDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Renegades_startBlind(%damagedClient, %this); if ( (%type == $FlashDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Shock_Damage(%damagedClient, %this); if ( (%type == $PlasmaDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Renegades_startBurn(%damagedClient, %this); if (%value) { %armor = Player::getArmor(%this); %hitdamageval = 0.05; if(%armor == "harmor") %hittolerance = 0.25; else %hittolerance = 0.25; %weaponType = Player::getMountedItem(%this,$WeaponSlot); if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack)) { if( ((%type == $LaserDamageType) || (%type == $SniperDamageType) ) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))) { MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!"); Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!"); Player::unmountItem(%this,$BackpackSlot); %obj = newObject("","Mine","Suicidebomb"); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%this,9 * %client.throwStrength,false); } } if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun")) { Player::dropItem(%this,%weaponType); %dlevel = GameBase::getDamageLevel(%this) + 0.05; Client::sendMessage(Player::getClient(%shooterClient),0, "You shot the " @ %weaponType @ " out of " @ Client::getName(%damagedClient) @ "'s hand!"); } else { %value = $DamageScale[%armor, %type] * %value * %friendFire; %dlevel = GameBase::getDamageLevel(%this) + %value; } %spillOver = %dlevel - %armor.maxDamage; GameBase::setDamageLevel(%this,%dlevel); %flash = Player::getDamageFlash(%this) + %value * 2; if (%flash > 0.75) %flash = 0.75; Player::setDamageFlash(%this,%flash); if(!Player::isDead(%this)) { if(%damagedClient.lastDamage < getSimTime()) { %sound = radnomItems(3,injure1,injure2,injure3); playVoice(%damagedClient,%sound); %damagedClient.lastdamage = getSimTime() + 1.5; } } else { if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $ElectricityDamageType) { Player::trigger(%this, $WeaponSlot, false); %weaponType = Player::getMountedItem(%this,$WeaponSlot); if(%weaponType != -1) Player::dropItem(%this,%weaponType); Player::blowUp(%this); } else { if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) { if(%quadrant == "front_left" || %quadrant == "front_right") %curDie = $PlayerAnim::DieBlownBack; else %curDie = $PlayerAnim::DieForward; } else if( Player::isCrouching(%this) ) %curDie = $PlayerAnim::Crouching; else if(%vertPos=="head") { if(%quadrant == "front_left" || %quadrant == "front_right" ) %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack); else %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward); } else if (%vertPos == "torso") { if(%quadrant == "front_left" ) %curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel); else if(%quadrant == "front_right") %curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin); else if(%quadrant == "back_left" ) %curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); else if(%quadrant == "back_right") %curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); } else if (%vertPos == "legs") { if(%quadrant == "front_left" || %quadrant == "back_left") %curDie = $PlayerAnim::DieLegLeft; if(%quadrant == "front_right" || %quadrant == "back_right") %curDie = $PlayerAnim::DieLegRight; } Player::setAnimation(%this, %curDie); }
if(%type == $ImpactDamageType && %object.clLastMount != "")
%shooterClient = %object.clLastMount; Client::onKilled(%damagedClient,%shooterClient, %type);
}
}
}
dmgFX(%player);
}

}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


//++++++++++++++++++++++
function dmgFX(%player)
{
	%armor = Player::getArmor(%player);
	%Dmg = GameBase::getDamageLevel(%player);
	%HP = %armor.maxDamage;
	//%DmgLvl = %Dmg / %HP;
	if(%armor == "larmor")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "lfemale")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "earmor")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "efemale")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "marmor")
	{
		%client = Player::getclient(%player);
       		bottomprint(%client, "<jc><f2>testing...");
		if(%dmg > %HP / 4) fire(%player);
		else if(%dmg > %HP / 8) smoke(%player);
		else if(%dmg > %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "aarmor")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "darmor")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
	if(%armor == "barmor")
	{
		if(%dmg < %HP / 4) fire(%player);
		else if(%dmg < %HP / 8) smoke(%player);
		else if(%dmg < %HP / 10) sparks(%player);
//		if (%DmgLvl > 0.80) fire(%player); 
//		else if (%DmgLvl > 0.50) smoke(%player); 
//		else if (%DmgLvl > 0.20) sparks(%player);
	}
//	else
//	{
//	//schedule("Player::dmgfxLoop(" @ %player @ ");", 0.5, %player);
//	schedule("Player::dmgFX(" @ %player @ ");",0.5); 
//	}
}

function sparks(%player)
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Your spittin sparks!");
	//if(Player::isDead(%player))	return;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	//sparks(%player)
	schedule("sparks(" @ %player @ ");",0.5);
}

function smoke(%player)
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Your smokin!");
	if(Player::isDead(%player))	return;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	schedule("smoke(" @ %player @ ");",0.5);
}

function fire(%player)
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>YOUR ON FIRE!");
	if(Player::isDead(%player))	return;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	schedule("fire(" @ %player @ ");",0.5);
}

ExplosionData AnnihilationFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData AnnihilationFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = AnnihilationFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//++++++++++++++++++++++


//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX



function Player::onRemove(%this) 
{ 
for (%i = 0; %i < 8; %i = %i + 1) 
{ 
%type = Player::getMountedItem(%this,%i); 

if (%type != -1) 
{ 
%item = newObject("","Item",%type,1,false); 
schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item); 
addToSet("MissionCleanup", %item); 
GameBase::setPosition(%item,GameBase::getPosition(%this)); 
} 
} 
} 

function Player::onNoAmmo(%player,%imageSlot,%itemType) { } 

function Player::onKilled(%this) { %cl = GameBase::getOwnerClient(%this); %cl.dead = 1; if($AutoRespawn > 0) schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl); if(%this.outArea==1) leaveMissionAreaDamage(%cl); Player::setDamageFlash(%this,0.75); for (%i = 0; %i < 8; %i = %i + 1) { %type = Player::getMountedItem(%this,%i); if (%type != -1) { if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") Player::dropItem(%this,%type); } } if(%cl != -1) { if(%this.vehicle != "") { if(%this.driver != "") { %this.driver = ""; Client::setControlObject(Player::getClient(%this), %this); Player::setMountObject(%this, -1, 0); if(%this.vehicle == "Wraith") { GameBase::startFadein(%this.vehicle); } } else { %this.vehicle.Seat[%this.vehicleSlot-2] = ""; %this.vehicleSlot = ""; } %this.vehicle = ""; } schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this); $lapTime[%cl] = 0; Client::setOwnedObject(%cl, -1); Client::setControlObject(%cl, Client::getObserverCamera(%cl)); Observer::setOrbitObject(%cl, %this, 5, 5, 5); schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this); %cl.observerMode = "dead"; %cl.dieTime = getSimTime(); } } 

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object) { if (Player::isExposed(%this)) { %damagedClient = Player::getClient(%this); %shooterClient = %object; Player::applyImpulse(%this,%mom); if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) { if (%shooterClient != -1) { %curTime = getSimTime(); if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) { if(%type != $MineDamageType) { Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!"); Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!"); } else { Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!"); Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!"); } %this.LastHarm = %shooterClient; %this.DamageStamp = %curTime; } } %friendFire = $Server::TeamDamageScale; } else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) %friendFire = $Server::TeamDamageScale; else %friendFire = 1.0; if (!Player::isDead(%this)) { %armor = Player::getArmor(%this); if((%vertPos == "head") && (%type == $LaserDamageType || %type == $SniperDamageType)) { if(%armor == "harmor") { if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") { %value += (%value * 0.3); } } else { %value += (%value * 0.3); } } if (%type != -1 && %this.shieldStrength) { %energy = GameBase::getEnergy(%this); %strength = %this.shieldStrength; if (%type == $ShrapnelDamageType || %type == $MortarDamageType) %strength *= 0.75; if (%type == $ElectricityDamageType){ %strength *= 0.0; } %absorb = %energy * %strength; if (%value < %absorb) { GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire)); %thisPos = getBoxCenter(%this); %offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2))); GameBase::activateShield(%this,%vec,%offsetZ); %value = 0; } else { GameBase::setEnergy(%this,0); %value = %value - %absorb; } } if( (%type == $FlashDamageType) && ( Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) ) Shock_Damage(%damagedClient, %this); if ((%type == $EnergyDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) ) { %armor = Player::getArmor(%this); if ((%armor != "aarmor") && (%armor != "afemale")) Renegades_startBlind(%damagedClient, %this); } if ((%type == $PlasmaDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))) { %rnd = floor(getRandom() * 10); if(%rnd > 5) { %armor = Player::getArmor(%this); if ( (%armor != "barmor") && (%armor != "bfemale")) Renegades_startBurn(%damagedClient, %this); } } %armor = Player::getArmor(%this); if ( (%type == $EnergyDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Renegades_startBlind(%damagedClient, %this); if ( (%type == $FlashDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Shock_Damage(%damagedClient, %this); if ( (%type == $PlasmaDamageType) && ((%armor == "dmarmor") || (%armor == "dmfemale"))) Renegades_startBurn(%damagedClient, %this); if (%value) { %armor = Player::getArmor(%this); %hitdamageval = 0.05; if(%armor == "harmor") %hittolerance = 0.25; else %hittolerance = 0.25; %weaponType = Player::getMountedItem(%this,$WeaponSlot); if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack)) { if( ((%type == $LaserDamageType) || (%type == $SniperDamageType) ) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))) { MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!"); Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!"); Player::unmountItem(%this,$BackpackSlot); %obj = newObject("","Mine","Suicidebomb"); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%this,9 * %client.throwStrength,false); } } if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun")) { Player::dropItem(%this,%weaponType); %dlevel = GameBase::getDamageLevel(%this) + 0.05; Client::sendMessage(Player::getClient(%shooterClient),0, "You shot the " @ %weaponType @ " out of " @ Client::getName(%damagedClient) @ "'s hand!"); } else { %value = $DamageScale[%armor, %type] * %value * %friendFire; %dlevel = GameBase::getDamageLevel(%this) + %value; } %spillOver = %dlevel - %armor.maxDamage; GameBase::setDamageLevel(%this,%dlevel); %flash = Player::getDamageFlash(%this) + %value * 2; if (%flash > 0.75) %flash = 0.75; Player::setDamageFlash(%this,%flash); if(!Player::isDead(%this)) { if(%damagedClient.lastDamage < getSimTime()) { %sound = radnomItems(3,injure1,injure2,injure3); playVoice(%damagedClient,%sound); %damagedClient.lastdamage = getSimTime() + 1.5; } } else { if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $ElectricityDamageType) { Player::trigger(%this, $WeaponSlot, false); %weaponType = Player::getMountedItem(%this,$WeaponSlot); if(%weaponType != -1) Player::dropItem(%this,%weaponType); Player::blowUp(%this); } else { if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) { if(%quadrant == "front_left" || %quadrant == "front_right") %curDie = $PlayerAnim::DieBlownBack; else %curDie = $PlayerAnim::DieForward; } else if( Player::isCrouching(%this) ) %curDie = $PlayerAnim::Crouching; else if(%vertPos=="head") { if(%quadrant == "front_left" || %quadrant == "front_right" ) %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack); else %curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward); } else if (%vertPos == "torso") { if(%quadrant == "front_left" ) %curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel); else if(%quadrant == "front_right") %curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin); else if(%quadrant == "back_left" ) %curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); else if(%quadrant == "back_right") %curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel); } else if (%vertPos == "legs") { if(%quadrant == "front_left" || %quadrant == "back_left") %curDie = $PlayerAnim::DieLegLeft; if(%quadrant == "front_right" || %quadrant == "back_right") %curDie = $PlayerAnim::DieLegRight; } Player::setAnimation(%this, %curDie); } if(%type == $ImpactDamageType && %object.clLastMount != "") %shooterClient = %object.clLastMount; Client::onKilled(%damagedClient,%shooterClient, %type); } } } } } 


function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6) { return %an[floor(getRandom() * (%num - 0.01))]; } 

function Player::onCollision(%this,%object) { if (Player::isDead(%this)) { if (getObjectType(%object) == "Player") { %sound = false; %max = getNumItems(); for (%i = 0; %i < %max; %i = %i + 1) { %count = Player::getItemCount(%this,%i); if (%count) { %delta = Item::giveItem(%object,getItemData(%i),%count); if (%delta > 0) { Player::decItemCount(%this,%i,%delta); %sound = true; } } } if (%sound) { playSound(SoundPickupItem,GameBase::getPosition(%this)); } } } if (getObjectType(%object) == "Player") { if (Player::isDead(%object)) { return; } if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { %armor = Player::getArmor(%object); if (%armor == "sarmor" || %armor == "sfemale") { Player::setDamageFlash(%this,1.95); %sound = false; %max = getNumItems(); for (%i = 0; %i < %max; %i = %i + 1) { %count = Player::getItemCount(%this,%i); if (%count) { %delta = Item::giveItem(%object,getItemData(%i),%count); if (%delta > 0) { Player::decItemCount(%this,%i,%delta); %sound = true; } } } if (%sound) { playSound(SoundPickupItem,GameBase::getPosition(%this)); } } } } if (getObjectType(%object) == "Player") { if (Player::isDead(%object)) { return; } if (Player::isDead(%this)) { return; } if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) { %armor = Player::getArmor(%object); if (%armor == "earmor" || %armor == "efemale") { if(GameBase::getDamageLevel(%this)) { GameBase::repairDamage(%this,0.10); GameBase::playSound(%this,ForceFieldOpen,0); } } } } if (getObjectType(%object) == "Player") { if (Player::isDead(%this)) { return; } %cliendId = Player::getClient(%object); %thisId = Player::getClient(%this); if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { %armor = Player::getArmor(%object); if ((%armor == "aarmor") || (%armor == "larmor") || (%armor == "lfemale")) { GameBase::applyDamage(%this,$BlasterDamageType,0.20,GameBase::getPosition(%this),"0 0 0","0 0 0",%object); if(GameBase::getDamageLevel(%object)) { GameBase::repairDamage(%object,0.20); } GameBase::playSound(%this,ForceFieldOpen,0); Client::sendMessage(Player::getClient(%object),1, "You drain " @ Client::getName(%thisId) @ "'s life"); } } } if (getObjectType(%object) == "Player") { %cliendId = Player::getClient(%object); %thisId = Player::getClient(%this); if (Player::isDead(%object)) { return; } if(GameBase::getTeam(%object) != GameBase::getTeam(%this)) { %armor = Player::getArmor(%object); if (%armor == "spyarmor" || %armor == "spyfemale") { } } } } 

function Player::getHeatFactor(%this) { %client = Player::getClient(%this); if (Client::getControlObject(%client) != %this) return 1.0; %time = getIntegerTime(true) >> 5; %lastTime = Player::lastJetTime(%this) >> 10; if ((%lastTime + 1.5) < %time) { return 0.0; } else { %diff = %time - %lastTime; %heat = 1.0 - (%diff / 1.5); return %heat; } } 

function Player::jump(%this,%mom) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %vehicle = Player::getMountObject (%this); %this.lastMount = %vehicle; %this.newMountTime = getSimTime() + 3.0; Player::setMountObject(%this, %vehicle, 0); Player::setMountObject(%this, -1, 0); Player::applyImpulse(%pl,%mom); playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this)); } } 

function remoteKill(%client) { %player = Client::getOwnedObject(%client); if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) { if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) { Player::unmountItem(%player,$BackpackSlot); %obj = newObject("","Mine","Suicidebomb"); addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,9 * %client.throwStrength,false); } else { playNextAnim(%client); Player::kill(%client); Client::onKilled(%client,%client); } } } $animNumber = 25; 

function playNextAnim(%client) { if($animNumber > 36) $animNumber = 25; Player::setAnimation(%client,$animNumber++); } 

function Client::takeControl(%clientId, %objectId) { if(%objectId == -1) { return; } if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)) { return; } if(GameBase::getControlClient(%objectId) != -1) { echo("Ctrl Client = " @ GameBase::getControlClient(%objectId)); return; } %player = Client::getOwnedObject(%clientId); %name = GameBase::getDataName(%objectId); if(Player::getMountedItem(%player,$BackpackSlot) != Laptop) { if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableHolo3 && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats) { Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets"); return; } } if(GameBase::getDamageState(%objectId) == "Enabled") { Client::setControlObject(%clientId, %objectId); Client::setGuiMode(%clientId, $GuiModePlay); } } 

//function Client::takeControl(%clientId, %objectId) { if(%objectId == -1) { return; } if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId)) { return; } if(GameBase::getControlClient(%objectId) != -1) { echo("Ctrl Client = " @ GameBase::getControlClient(%objectId)); return; } %player = Client::getOwnedObject(%clientId); %name = GameBase::getDataName(%objectId); if(Player::getMountedItem(%player,$ToolSlot) != Laptop) { if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableHolo3 && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats) { Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets"); return; } } if(GameBase::getDamageState(%objectId) == "Enabled") { Client::setControlObject(%clientId, %objectId); Client::setGuiMode(%clientId, $GuiModePlay); } } 


function remoteCmdrMountObject(%clientId, %objectIdx) { Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx)); } 

function checkControlUnmount(%clientId) { %ownedObject = Client::getOwnedObject(%clientId); %ctrlObject = Client::getControlObject(%clientId); if(%ownedObject != %ctrlObject) { if(%ownedObject == -1 || %ctrlObject == -1) return; if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject) return; Client::setControlObject(%clientId, %ownedObject); LaptopDrain(%clientId, %ownedObject); } } 

function Shock_Damage(%clientId, %player) 
{ 
Client::sendMessage(%clientId,1,"Your energy systems short-circuted!"); Player::unmountItem(%player,$WeaponSlot); 
if($shockTime[%clientId] == 0) 
{ 
GameBase::setEnergy(%player,0); 
GameBase::setRechargeRate(%player,0); 
$shockTime[%clientId] = 14; 
checkPlayerShock(%clientId, %player); 
} 
else $shockTime[%clientId] = 14; 
} 

function checkPlayerShock(%clientId, %player) 
{ 
if($shockTime[%clientId] > 0) 
{ 
$shockTime[%clientId] -= 2; 
schedule("checkPlayerShock(" @ %clientId @ ", " @ %player @ ");",2,%player); 
} 
else 
{ 
Client::sendMessage(%clientId,1,"Your energy systems are back to normal."); 
GameBase::setRechargeRate(%player,8); 
} 
} 

function Renegades_startBlind(%clientId, %player) 
{ 
Client::sendMessage(%clientId,1,"You are poisoned!"); if($poisonTime[%clientId] == 0) { Player::setDamageFlash(%player,0.75); $poisonTime[%clientId] = 30; checkPlayerBlind(%clientId, %player); } else $poisonTime[%clientId] = 30; } 

function checkPlayerBlind(%clientId, %player) { if($poisonTime[%clientId] > 0) { $poisonTime[%clientId] -= 2; %drrate = GameBase::getDamageLevel(%player) + 0.05; if (!Player::isDead(%player)) { GameBase::setDamageLevel(%player, %drrate); Player::setDamageFlash(%player,0.75); if (Player::isDead(%player)) { messageall(0, Client::getName(%clientId) @ " died from a strange disease."); %clientId.scoreDeaths++; %clientId.score--; Game::refreshClientScore(%clientId); $poisonTime[%clientId] = 0; } } else { $poisonTime[%clientId] = 0; } schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player); } else { Client::sendMessage(%clientId,1,"The effects of the poison wear off."); } } 

function Renegades_startBurn(%clientId, %player) { Client::sendMessage(%clientId,1,"You caught on fire!"); if($burnTime[%clientId] == 0) { Player::setDamageFlash(%player,0.75); $burnTime[%clientId] = 10; checkPlayerBurn(%clientId, %player); } else $burnTime[%clientId] = 10; } 

function checkPlayerBurn(%clientId, %player) { if($burnTime[%clientId] > 0) { $burnTime[%clientId] -= 2; %drrate = GameBase::getDamageLevel(%player) + 0.05; if (!Player::isDead(%player)) { GameBase::setDamageLevel(%player, %drrate); Player::setDamageFlash(%player,0.75); if (Player::isDead(%player)) { messageall(0, Client::getName(%clientId) @ " was incinerated."); %clientId.scoreDeaths++; %clientId.score--; Game::refreshClientScore(%clientId); $burnTime[%clientId] = 0; } } else { $burnTime[%clientId] = 0; } schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,1,"You stop burning."); } } 