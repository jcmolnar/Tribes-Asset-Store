// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

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

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 12;
//----------------------------------------------------------------------------


function Player::onAdd(%this) 
{ 
	Player::jetpackLoop(%this);
	GameBase::setRechargeRate(%this,8); 
} 

function Player::onRemove(%this)
{
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			%item = newObject("","Item",%type,1,false);
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
// Nothing To See Here MOVE ALONG KTHXBI
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

	if((%checkRate = $Hybrid::JetSmokeRate) == 0)
		%checkRate = 1;
	
	%plyJet = Player::isJetting(%this);
	if(%plyJet)
	{
		$JPrate = 10;
		%vel = Item::getVelocity(%this);
		%JetVel = velToSingle(%vel);
		%armor = Player::getArmor(%client);
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%this);
		%trans2 = "0 0 -1 0 0 0 0 0 -1 " @ vector::Add(getBoxCenter(%this), "-0.5 -0.01 -1.25");
		%trans3 = "0 0 -1 0 0 0 0 0 -1 " @ vector::Add(getBoxCenter(%this), "0.5 -0.01 -1.25");

		//Starting Armor Smoke Effects
                //============================-----
		if(%armor == "HyLight") //===> Hybrid: Talon
		{
			Projectile::spawnProjectile(HyTalonsmoke, %trans, %this, "0 0 -5");
		}
		//============================-----
		else if(%armor == "HyMedium") //===> Hybrid: Predator
		{
			Projectile::spawnProjectile(HyPredatorsmoke, %trans, %this, "0 0 -5");
		}
		//============================-----
		else if(%armor == "HyHeavy") //===> Hybrid: Eagle
		{
			Projectile::spawnProjectile(HyEaglesmoke, %trans2, %this, "0 0 -5");
			Projectile::spawnProjectile(HyEaglesmoke, %trans3, %this, "0 0 -5");
		}
		//============================-----
		else if(%armor == "CyLight") //===> Cybrid: Banshee
		{
			Projectile::spawnProjectile(CyBansheesmoke, %trans, %this, "0 0 -5");
		}
		//============================-----
		else if(%armor == "CyMedium") //===> Cybrid: Adjudicator
		{
			Projectile::spawnProjectile(CyAdjudicatorsmoke, %trans, %this, "0 0 -5");
		}
		//============================-----
		else if(%armor == "CyHeavy") //===> Cybrid: Executioner
		{
			Projectile::spawnProjectile(CyExecutionersmoke, %trans2, %this, "0 0 -5");
			Projectile::spawnProjectile(CyExecutionersmoke, %trans3, %this, "0 0 -5");
		}
		//============================-----
		%nextCheckT = (1/$JPrate)/%checkRate;
		schedule("Player::jetpackloop(" @ %this @ ");", %nextCheckT, %this);
	}
	else
	{
		schedule("Player::jetpackloop(" @ %this @ ");", 0.5/%checkRate, %this);
	}
}

//=====================//
// Hybrid: Talon       //
//=====================//

ExplosionData HyTalonsmokeExp
{
   shapeName = "chainspk.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };

   shiftPosition = True;
};

GrenadeData HyTalonsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = HyTalonsmokeExp;
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
   isVisible          = false;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "chainspk.dts";
};

//=====================//
// Hybrid: Predator    //
//=====================//

ExplosionData HyPredatorsmokeExp
{
   shapeName = "plasmabolt.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 1.0, 0.63, 0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

GrenadeData HyPredatorsmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = HyPredatorsmokeExp;
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
   isVisible          = false;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//=====================//
// Hybrid: Eagle       //
//=====================//

ExplosionData HyEaglesmokeExp
{
   shapeName = "plasmatrail.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 1.63, 0.0 };
   colors[1]  = { 0.0, 1.63, 0.0 };
   colors[2]  = { 0.0, 1.63, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

GrenadeData HyEaglesmoke
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = HyEaglesmokeExp;
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
   isVisible          = false;
   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//=====================//
// Cybrid: Banshee     //
//=====================//

ExplosionData CyBansheesmokeExp
{
   shapeName = "enex.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 1.63, 0.0 };
   colors[1]  = { 0.0, 1.63, 0.0 };
   colors[2]  = { 0.0, 1.63, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

GrenadeData CyBansheesmoke
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = CyBansheesmokeExp;
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
isVisible          = false;
   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};

//=====================//
// Cybrid: Adjudicator //
//=====================//

ExplosionData CyAdjudicatorsmokeExp
{
   shapeName = "fusionbolt.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

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

GrenadeData CyAdjudicatorsmoke
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = CyAdjudicatorsmokeExp;
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
isVisible          = false;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};

//=====================//
// Cybrid: Executioner //
//=====================//

ExplosionData CyExecutionersmokeExp
{
   shapeName = "fusionbolt.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 1.0, 0.63, 0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

GrenadeData CyExecutionersmoke
{
   bulletShapeName    = "paint.dts";
   explosionTag       = CyExecutionersmokeExp;
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
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}


function Weapon::onFire(%player,%special,%Eat,%speed)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%player);
	%armor = Player::getArmor(%player);
	%weap = Player::getMountedItem(%player,$WeaponSlot);
	%ammo = $WeaponAmmo[%weap];
	if(%ammo != "") {
		if(Player::getItemCount(%player,%ammo) < 1)
			return;
	}
	GameBase::getLOSInfo(%player,3000);
	%rot = GameBase::getRotation(%player);
	%targetPos = $los::position;
	%trans = GameBase::getMuzzleTransform(%player);
	%vec0 = getWord(%trans,0);
	%vec1 = getWord(%trans,1);
	%vec2 = getWord(%trans,2);
	%vec3 = getWord(%trans,6);
	%vec4 = getWord(%trans,7);
	%vec5 = getWord(%trans,8);
	%vec6 = getWord(%trans,9);
	%vec7 = getWord(%trans,10);
	%vec8 = getWord(%trans,11);
	%vecX = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
	%rot1 = %vec0@" "@%vec1@" "@%vec2;
	%rot2 = %vec3@" "@%vec4@" "@%vec5;
	%pos1 = %vec6@" "@%vec7@" "@%vec8;
	%rot0 = Vector::getRotAim(%Pos1,%targetPos);
	if(%speed == "")
		%speed = 1;
	%vec = Vector::getFromRot(%rot0,%speed);
	if(%targetPos)
		%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot0@" "@%pos1;
	%type = $WeapProjectile[%weap];
	if(%special != "" && %special != "0")
		%type = %special;
	%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);
	if(getObjectType(%proj) == LaserProjectile && $los::object) {
		%dmgType = $LaserDamageType;
		%value = %type.damageConversion;
		if(GameBase::getEnergy(%player) > %weap.imageType.minEnergy)
			%value *= %weap.imageType.maxEnergy;
		%pos = GameBase::getPosition($los::object);
		%vecI = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
		%mom = "0 0 0";
		GameBase::applyDamage($los::object,%dmgType,%value,%pos,%vecI,%mom,%client);
	}
	if(%ammo != "" && %Eat != False)
		Player::DecItemCount(%player,%ammo);
	else if(%weap.imageType.maxEnergy != "")
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-%weap.imageType.maxEnergy);
	if($FifthElementGuns != 1)
		$los::position = "";
	$los::object = "";
	return %proj;
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%c = player::getClient(%this);
	if(%c.immortal)
	{
		return;
	}

	if (Player::isExposed(%this)) 
	{
      		%damagedClient = Player::getClient(%this);
      		%shooterClient = %object;

		// Check For Team Damage

	      	%shooterId = %object;
	      	%victimId = player::getClient(%this);
	      	%ateam = Client::getTeam(%shooterId); //Shooters Team
	      	%vteam = Client::getTeam(%victimId);  //Victims Team
	      	if(%ateam == %vteam && !$Server::TeamDamageScale && %shooterId != %victimId && !%shooterId.possessed) // You can still hurt yourself from falling  or shooting yourself
	      	{
		    return;
	      	}

	      	// - WorstAim

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			if(%vertPos == "head" && %type == $EnergyDamageType || %type == $FusionDamageType || %type == $PulseDamageType || %type == $RadiationDamageType || %type == $AntiMatterDamageType || %type == $IONDamageType || %type == $BulletDamageType ) {
				if(%armor == "HyHeavy" || %armor == "CyHeavy") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ExplosiveDamageType || %type == $FusionDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
//////////////////////////////////////VX//////////////////////////////////////////////////
	if(%type == $HealDamageType)
	{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	%obj = getObjectType($los::object);
	%name = GameBase::getDataName(%obj);

	%maxRepair = %armor.maxDamage*100000000000;

	//== Get random amount....
	%repair = floor(getRandom() * %maxRepair);

	//== Now make it so that min:0 max:The full health
	%amount = %repair/100000000000;
	%perPercent = %armor.maxDamage / 100;

	if((%amount/%perPercent) < 10)
		%amount = %perPercent*10;

	%percentRepair = %amount / %perPercent;
	//== Now actually repair
	GameBase::repairDamage(%player,%amount);

	GameBase::repairDamage(%obj,0.27);
}

      
		if (%type == $BulletDamageType)	
		{
			if(Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
			    {
if(%vertPos == "head") {
player::blowup(%this);
%value +=2;
bottomprint(%shooterclient, "<f0><jc>]-[ead Shot!<f2> " @ Client::getName(%damagedClient) @ "<F0> 2 Bonus Points!", 3);
bottomprint(%damagedclient, "<f0><jc>You Were ]-[ead Shot Killed By:<f2> " @ Client::getName(%shooterClient) @ "<F0>!", 3);
		       }
                            }
}
		if (%type == $LiLPOOmkiiDamageType)	
{
			if(Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
			    {
if(%vertPos == "head") {
player::blowup(%this);
%value +=2;
bottomprint(%shooterclient, "<f0><jc>]-[ead Shot!<f2> " @ Client::getName(%damagedClient) @ "<F0> 2 Bonus Points!", 3);
bottomprint(%damagedclient, "<f0><jc>You Were ]-[ead Shot Killed By:<f2> " @ Client::getName(%shooterClient) @ "<F0>!", 3);
		       }
                            }
}
		if (%type == $SmokeDamageType)	
{
			Client::sendMessage(%damagedclient,1,"WARNING - Noxious Gas Detected!~werror_message.wav");
			Player::setDamageFlash(%this,1.0); 
}
		if (%type == $FlashDamageType)	
{
			player::setdamageflash(%this,1);
			gamebase::setenergy(%this,0);
			gamebase::setrechargerate(%this,6);
			Client::sendMessage(%damagedclient,3,"Energy systems malfunctioning.");
}
                if (%type == $BeamOfPainDamageType) 
{
			%pooGetweaponItem = Player::getMountedItem(%damagedClient,0);
			%pooGetpackItem = Player::getMountedItem(%damagedClient,1);
			%pooGetflagItem = Player::getMountedItem(%damagedClient,2);
			player::setdamageflash(%this,0.2);
			player::dropitem(%this,%pooGetpackItem);
			player::dropitem(%this,%pooGetweaponItem);
			player::dropitem(%this,%pooGetflagItem);
}

///////////////////////////////////////VX/////////////////////////////////////////////////
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $NuclearDamageType || %type== $ThermalDamageType || %type == $FusionDamageType || %type == $AntiMatterDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $NuclearDamageType || %type== $ThermalDamageType || %type == $FusionDamageType || %type == $AntiMatterDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Freeze(%this)
{
	Player::incItemCount(%this,DeadWeight);
	Player::mountItem(%this,DeadWeight, 4);
	Item::setvelocity(%player,0);
	Client::sendMessage(Player::getClient(%this), 0, "You Stepped On A Freeze Mine!");
	schedule("Player::decItemCount("@ %this @","@ DeadWeight@ ");", 15);
}

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
				if (%count) {
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0) {
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if (%sound) {
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
}

function Player::getHeatFactor(%this)
{
	%client = Player::getClient(%this);
	if (Client::getControlObject(%client) != %this)
		return 1.0;
	if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSinkPack") 
	return 0.0;
   %time = getIntegerTime(true) >> 5;
   %lastTime = Player::lastJetTime(%this) >> 10;

   if ((%lastTime + 1.5) < %time) 
{
      return 0.0;
   } else 
{
      %diff = %time - %lastTime;
      %heat = 1.0 - (%diff / 1.5);
      return %heat;
   }
}

function Player::jump(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{
   if(%client.isFrozen)
   {
	client::sendMessage(%client, 1, "No killing yourself while you're frozen ;)");
	return;
   }

   if(%client.possessed)
   {
	return;
   }

   if(%client.possessing)
   {
	client::sendMessage(%client, 3, "No suicideing while you are possessing someone");
	return;
   }
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
   }
}

$animNumber = 25;	 
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}
function Client::takeControl(%clientId, %objectId)
{
   if(%objectId == -1)
   {
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableTaserTrtB && %name != DeployableTaserTrtC && %name != LaserTurret && %name != LaserTurretB && %name != MiniFlakTurret && %name != MiniSAMTurret && %name != MiniELFTurret && %name != MiniSmokeTurret )
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
   		return;
   }
   if(GameBase::getDamageState(%objectId) == "Enabled") {
   	Client::setControlObject(%clientId, %objectId);
   	Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}



