// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
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
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::Slap(%obj, %str)
{
   %rot = GameBase::getRotation(%obj);
   %boostVec = Vector::getFromRot(%rot, 0, %str);
   Player::applyImpulse(%obj,%boostVec);
}

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
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

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
    //Plasmatic Code
    if((%type == $LandingDamageType || %type == $ImpactDamageType) && GameBase::getControlClient(%this) != -1)
    {
      %vel = Item::getVelocity(%this);
      %speed = vector::getdistance(%vel,"0 0 0");

      %this.lastSpeed = %speed;
      %this.lastVel = %vel;
      %this.lastImpact  = getSimTime();
    }
    //Plasmatic Code End

    if(!$LaserTagMode)
        return;

    if(Player::isAiControlled(%this) == true)
        return;
                
    %set = newObject("set",SimSet);
    %radius = $LaserTagNoDmgBeaconRange;
    %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, GameBase::getPosition(%this), %radius, %radius, %radius, 0);
    for(%i = %numItems - 1 ; %i>=0; %i--)
    {
        %obj = Group::getObject(%set, %i);
        if(%obj.IsLTSafeBeacon == true)
            return;
    }
    if (Player::isExposed(%this))
    {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

    if(%type == $LaserTagDamageType)
    {
        if(%vertPos=="head") {
            %value = %value + (%value / 3);
  		}
        else if (%vertPos == "legs") {
            %value = %value - (%value / 3);
  		}

        if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
            %isSameTeam = true;
        else
            %isSameTeam = false;

        if($LaserTagXtra == 1)
            %TeamMode = true;
        else
            %TeamMode = false;

        if(%TeamMode == false)
            %isSameTeam = false;

        if(%isSameTeam == false)
        {
            if (%value) {
                %dlevel = GameBase::getDamageLevel(%this) + %value;
                %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);

				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) {
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
            }

                if(Player::isDead(%this)) //if(%spillOver > 0.5)
                {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);

                        if( Player::isCrouching(%this) )
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
					    Client::onKilled(%damagedClient,%shooterClient, %type);
                }

         }
         return;
    }

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
			//More damage applyed to head shots
			if(%vertPos == "head" && (%type == $LaserDamageType || %type == $LaserTagDamageType)) {
				if(%armor == "harmor") {
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
                %dlevel = GameBase::getDamageLevel(%this) + %value;
                %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) {
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
                if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                    	Player::blowUp(%this);
    					}
    					else
    					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
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
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
    else
    {
        if(getSimTime() - %this.lastImpact < 1 && (getObjectType(%object) == "Player" || getObjectType(%object) == "Flyer"))
        {
            %parent = %object; //Easier...
            %child = %this;

            if(%child.isColliding == true)
            {
                %child.isColliding = false;
                return;
            }

            %parent.isColliding = true; //Make sure the collision doesn't nullify itself...

            // Plasmatic Code
            %Tm = GameBase::GetMass(%child);
            %Om = GameBase::GetMass(%parent);
            
            %m = %tm/%om;   //weight ratio between armors

            %vel1 = vector::multiply(%parent.lastVel,%m@" "@%m@" "@%m);
            %vel2 = vector::multiply(%child.lastVel,%m@" "@%m@" "@%m);
            // Plasmatic Code End

            %pVelocity = %vel1;
            %cVelocity = %vel2;
            
            %pVelX = getWord(%pVelocity, 0);
            %pVelY = getWord(%pVelocity, 1);
            %pVelZ = getWord(%pVelocity, 2);
            
            %cVelX = getWord(%cVelocity, 0);
            %cVelY = getWord(%cVelocity, 1);
            %cVelZ = getWord(%cVelocity, 2);

            //echo("PVX: " @ %pVelX);
            //echo("PVY: " @ %pVelY);
            //echo("PVZ: " @ %pVelZ);
            
            //echo("CVX: " @ %cVelX);
            //echo("CVY: " @ %cVelY);
            //echo("CVZ: " @ %cVelZ);
            
            %pVelVecLen = sqrt(pow(%pVelX, 2) + pow(%pVelY, 2) + pow(%pVelZ, 2));
            %pVelXNorm = %pVelX / %pVelVecLen;
            %pVelYNorm = %pVelY / %pVelVecLen;
            %pVelZNorm = %pVelZ / %pVelVecLen;

            %cVelVecLen = sqrt(pow(%cVelX, 2) + pow(%cVelY, 2) + pow(%cVelZ, 2));
            %cVelXNorm = %cVelX / %cVelVecLen;
            %cVelYNorm = %cVelY / %cVelVecLen;
            %cVelZNorm = %cVelZ / %cVelVecLen;
            
            //echo("PVN: " @ %pVelXNorm @ " " @ %pVelYNorm @ " " @ %pVelZNorm);
            //echo("CVN: " @ %cVelXNorm @ " " @ %cVelYNorm @ " " @ %cVelZNorm);

            //%pSpeed = (Vector::getDistance("0 0 0", %pVelocity) - 1.73205); //Adjust the speed here for inconsistance
            //%cSpeed = (Vector::getDistance("0 0 0", %cVelocity) - 1.73205); //in speed. (0 = 1.73205)
            
            //echo("PS: " @ %pSpeed @ "m/s");
            //echo("CS: " @ %cSpeed @ "m/s");
            
            %pPos = GameBase::getPosition(%parent);
            %cPos = GameBase::getPosition(%child);
            
            %distX = sqrt(pow(getWord(%pPos, 0), 2) + pow(getWord(%cPos, 0), 2));
            %distY = sqrt(pow(getWord(%pPos, 1), 2) + pow(getWord(%cPos, 1), 2));
            %distZ = sqrt(pow(getWord(%pPos, 2), 2) + pow(getWord(%cPos, 2), 2));
            
            //Assume it's two 'spheres' colliding.
            %collisionPlaneNormal = %distX @ " " @ %distY @ " " @ %distZ;
            //%collisionPlaneNormal = Vector::Normalize(Vector::Sub(%pPos, %cPos));

            %cpnX = getWord(%collisionPlaneNormal, 0);
            %cpnY = getWord(%collisionPlaneNormal, 1);
            %cpnZ = getWord(%collisionPlaneNormal, 2);
            
            %coeOfRestit = 0.2; //Coefficient of Restitution: 1 = Perfectly elastic -- 0 = Perfectly plastic
            
            %velDiffX = %pVelX - %cVelX;
            %velDiffY = %pVelY - %cVelY;
            %velDiffZ = %pVelZ - %cVelZ;
            
            %velDiffX *= -(1 + %coeOfRestit);
            %velDiffY *= -(1 + %coeOfRestit);
            %velDiffZ *= -(1 + %coeOfRestit);
            
            %pMass = GameBase::GetMass(%parent);
            %cMass = GameBase::GetMass(%child);
            
            //echo("PM: " @ %pMass);
            //echo("CM: " @ %cMass);
            
            %inversemass = (1 / %pMass) + (1 / %cMass);
            
            %impulseX = Vector::dot(%velDiffX, %cpnX) / Vector::dot(%cpnX, %cpnX * %inversemass);
            %impulseY = Vector::dot(%velDiffY, %cpnY) / Vector::dot(%cpnY, %cpnY * %inversemass);
            %impulseZ = Vector::dot(%velDiffZ, %cpnZ) / Vector::dot(%cpnZ, %cpnZ * %inversemass);
            
            //echo("IX: " @ %impulseX);
            //echo("IY: " @ %impulseY);
            //echo("IZ: " @ %impulseZ);
            
            %pFinalVelocityX = (%pVelX + (%impulseX / %pMass) * %cpnX);
            %pFinalVelocityY = (%pVelY + (%impulseY / %pMass) * %cpnY);
            %pFinalVelocityZ = (%pVelZ + (%impulseZ / %pMass) * %cpnZ);
            
            %cFinalVelocityX = (%cVelX - (%impulseX / %cMass) * %cpnX);
            %cFinalVelocityY = (%cVelY - (%impulseY / %cMass) * %cpnY);
            %cFinalVelocityZ = (%cVelZ - (%impulseZ / %cMass) * %cpnZ);
            
            %pFinalVelocity = %pFinalVelocityX @ " " @ %pFinalVelocityY @ " " @ %pFinalVelocityZ;
            %cFinalVelocity = %cFinalVelocityX @ " " @ %cFinalVelocityY @ " " @ %cFinalVelocityZ;

            //echo("POV: " @ %pVelocity);
            //echo("COV: " @ %cVelocity);
            
            //echo("PFV: " @ %pFinalVelocity);
            //echo("CFV: " @ %cFinalVelocity);
            
            if((Player::getClient(%parent).TransVel == true && Player::getClient(%child).TransVel == true) || Player::isAIControlled(%parent))
            {
                Item::setVelocity(%parent, %pFinalVelocity);
                Item::setVelocity(%child, %cFinalVelocity);
            }
        }
    }
}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	if (Client::getControlObject(%client) != %this)
		return 1.0;

   %time = getIntegerTime(true) >> 5;
   %lastTime = Player::lastJetTime(%this) >> 10;

   if ((%lastTime + 1.5) < %time) {
      return 0.0;
   } else {
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
   // remote control
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
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
