
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

function Player::onAdd(%this)
{
	//schedule("$BloodSpawnLag["@%this@"] = False;", 0.5, %this);
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
	//*************************************************************************************************************
	// SF Addition - Begin - 12/18/99 - 6:30PM
	//*************************************************************************************************************
	%cl = GameBase::getOwnerClient(%this);
	//*************************************************************************************************************
	// SF Addition - END
	//*************************************************************************************************************
	
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if(%type == Slayer || %type == FBWRocketLauncher )
			{
				Player::setItemCount(%this, FBWRocketLauncher, 0);
				%type = Slayer;
			}
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5")
				Player::dropItem(%this,%type);
		}
	}
	//Assasination Code - Give Assasins Point
	if($Game::missionType == "Assassination") {
		if(%cl == $Hunted) {
			if($HuntedEscaped != 1) { // ADDED LINE
				for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i)) {
					remoteEval(%i, CP, "<jc><f0>The VIP was assassinated!", 4);
					Player::kill(%i);
				}
				$teamScore[1] += 1;
			}                         // ADDED LINE
		}
	}
	if(%cl != -1)
	{
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
				$turretControlled[%this.vehicle] = FALSE;
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
//-----------------------------------------

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%player=%this;
	%damagedClient = Player::getClient(%this);
	%clientId = %damagedClient;
	%shooterClient = %object;
	%armor = Player::getArmor(%this);

	if (getObjectType(%object) == "Player")
		%shooterClient = Player::getClient(%object);

	if (Player::isDead(%this))
		return;

	if (%shooterClient)
		%damagedClient.lastdamager = %shooterClient; 

	if (Player::isExposed(%this))
	{
		Player::applyImpulse(%this,%mom);
		//======================================================================== Determin Team Damage
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) )
		{
			if (%shooterClient)
			{
				%curTime = getSimTime();

			   if ((%curTime - %this.DamageTime > 1.5 || %this.LastHarm != %shooterClient) && (%type != $GravDamageType) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
			   {
					if(%type != $MineDamageType)
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
			            		%shooterClient.score = (%shooterClient.score -1);
						if ($ScoreOn) bottomprint(%shooterClient, "You harmed your team mate... Score -1 = " @ %shooterClient.score @ " Total Score");
					}
					else
					{
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

		//============================================================== Reaction Damage
		if ($Shifter::Reactions)
		{
			if(%vertPos == "torso")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient,%kick, (%kick/2));
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient, -%kick, (%kick/2));
					if (%kick > 45)
					{
						%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
						Player::unmountItem(%player,$BackpackSlot);
						Player::dropItem(%damagedClient,%item);
					}
				}
			}
			else if (%vertPos == "legs")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 200);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
			}
			else if (%vertPos == "head")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 50);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
			}
		}

		//============================================================== More Damage To Head Shots
		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);
			
			if(%vertPos == "head")
			{
				if (%type == $LaserRifleDamageType || %type == $SniperDamageType || %type == $RaptorDamageType || %type == $FarSightDamageType)
				{
					%value += %value;
				}
				else
				{
					if(%armor == "marmor")
					{ 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						{
							%value += (%value * 0.2);
						}
					}
					else
					{
						%value += (%value * 0.5);
					}
				}
			}
			
			//================================================================ Shield Pack On
			if (%type != -1 && %this.shieldStrength && %type != $HBlasterDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				
				if (%type == $MineDamageType || %type == $DevastDamageType)
					%strength *= 0.75;
	
				%absorb = %energy * %strength;
				
				if (%value < %absorb)
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
			//============================================================ Flash Damage Does EMP Effect
			if( ((%type == $EMPDamageType) || (%type == $EMPDamageType)) )
			{
				Insomniax_startEMP(%damagedClient, %this, 14);
				%emptime = (%value * 10);
				if ($debug) echo ("Emp Time = " @ %emptime);
			}
			
			//======================================================= Life Drain - Poison

			if (((%type == $TranqDamageType)) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) )
			{
				%armor = Player::getArmor(%this);
				if ((%armor != "marmor") && (%armor != "mfemale"))
					Renegades_startBlind(%damagedClient, %this);
			}

			//======================================================= Fusion Damage Catches Player On Fire
			if (((%type == $FlamerDamageType)) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7)
				{
					%armor = Player::getArmor(%this);
					if ( (%armor != "marmor") && (%armor != "mfemale"))
						Renegades_startBurn(%damagedClient, %this);
				}
			}
			//================================================= Body Area Damage Effects

  			if (%value) 
			{
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				%hittolerance = 0.25;
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				//=========================================== Weapons Drop On Sniper Shot

				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $FarSightDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun"))
				{
					Player::dropItem(%this,%weaponType);
					%dlevel = GameBase::getDamageLevel(%this) + 0.05;
					Client::sendMessage(Player::getClient(%shooterClient),0,
					"You shot the " @ %weaponType @ " out of "  @ Client::getName(%damagedClient) @ "'s hand!");
				}
				else
				{
					%value = $DamageScale[%armor, %type] * %value * %friendFire;
					%dlevel = GameBase::getDamageLevel(%this) + %value;
				}

            			%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				
				if(!Player::isDead(%this))
				{ 
					//========================= Check for flag kick on sniper shot - *IX*Savage1
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $RaptorDamageType || %type = $SniperDamageType || %type = $FarSightDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
						DoTheFlagDrop(%this, %shooterClient);

					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else 
				{
					if(%spillOver > 0.5)
					{
						if ($Shifter::AmmoBoom != "False" && %damagedClient != %shooterClient)
						{
							itemfuncs::ammoboom(%this);
						}
						if (%type== $MineDamageType || %type == $DevastDamageType || %type== $SlayerDamageType || %type == $RocketDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType)
						{
							Player::trigger(%this, $WeaponSlot, false);
							%weaponType = Player::getMountedItem(%this,$WeaponSlot);
							if(%weaponType != -1)
								Player::dropItem(%this,%weaponType);
							if (%type == $ElectricityDamageType) 
								playSound(ShockExplosion,GameBase::getPosition(%this));
							Player::blowUp(%this);
						}
					}
					else
					{

						if ((%value > 0.40 && (%type== $MineDamageType || %type== $DevastDamageType || %type == $RocketDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) )
						{
							if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							

						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right") 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
							else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso")
						{
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
	
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;

					Client::onKilled(%damagedClient,%shooterClient, %type, %vertPos, %quadrant);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{return %an[floor(getRandom() * (%num - 0.01))];}
//--------------------------------------------------------
//--------------------------------------------------------
function Player::onCollision(%this, %object)
{
	//************************************************************************************
	//  SF ADDITION FOR LADDERS
	//************************************************************************************
	//if( GameBase::getDataName(%object) == "Ladder" )
	//{
	//	ClimbLadder(%this, %object);
	//}
	//************************************************************************************
	//  SF ADDITION FOR LADDERS - END
	//************************************************************************************
	//************************************************************************************
	//  SF ADDITION FOR BOTS
	//************************************************************************************
	
	if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "true")
	{                                      // Check if player AND colliding player are bots. By Werewolf
		
		%aiId = Player::getClient(%this);			 //==== Get General Varibles
		%aiName = Client::GetName(%aiId);
		%aiTeam = Client::GetTeam(%this);	 
		%objTeam = Client::GetTeam(%object);
		echo("BOT: Collision <" @ %aiName @ " - " @ %aiId @ ">");
		//=============================================================== Class Specific
		
		if(String::findSubStr(%aiName, "Medic") >= 0)          //======= Medic Drops Kit
		{				                       //by EMO1313
			if (%aiTeam == %objTeam)
			{
				//echo("BOT: " @ %aiName @ " Drops Repair Kit");
				Player::dropItem(%aiId, "repairkit");
			}
		}
		
		%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
		%aiLoc = GameBase::getPosition(Client::getOwnedObject(%this));
		%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%this)); 
		//   Vehicle::passengerJump(0,%this,0);  //Crude way to make bots avoid obstacles, or as in this case: other players.
		//============================================================================================================== Attempt Object Move Around
		if(  (GameBase::testPosition(%aiId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
		{	
			//echo("BOT: Colide With Object");
			//&& (getObjectType(%object) != "Player")
			//========================================================================================================= Try to move AI outta the way...
			%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
			%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));		
			%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 			
			%aiRotation = (%aiRotation + 60);
			%Length = 225;
			%Zvalue = $aiRotation;
			
			%aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 			
			%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);			
			%rotZ = (%rotZ + 90);
			
			%velocity = 75;
			
			GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
			
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%aiId),%velocity,%Zvalue);
			Vehicle::passengerJump(0,%aiId,0);		 								 		//Crude way to make players avoid obstacles
			Player::applyImpulse(%aiId, %jumpDir);
		}
		//else
		//	echo ( %aiId @ " Can not avoid...");
		//================================================================================================================== End AI Collision
	}
	else
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
	}
}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	//************************************************************************
	//     SF ADDITION
	//************************************************************************
	if ((Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this))) //Werewolf
		return 1.0;
	//***********************************************************************
	//	%time = getIntegerTime(true) >> 5;
	//	%lastTime = Player::lastJetTime(%this) >> 10;
	//	if ((%lastTime + 1.5) < %time)
	return 0.0;
	//	else
	//	{
	//    	%diff = %time - %lastTime;
	//      	%heat = 1.0 - (%diff / 1.5);
	//      	return %heat;
	//   	}
}

function Player::jump(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%vehicle = Player::getMountObject(%this);
		%this.lastMount = %vehicle;
		
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
		
		// turret controling
		%turret = Player::getMountObject (%this);
		%this.lastMount = %turret;
		
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %turret, 0);
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
		//echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}

	 %player = Client::getOwnedObject(%clientId);
        %name = GameBase::getDataName(%objectId);
        %armor = Player::getArmor(%clientId);
        
        if(Player::getMountedItem(%player,$BackpackSlot) != Laptop && (%armor != "marmor" || %armor != "mfemale" ))
        {
                if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableMini && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats)
                {
                        Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
                        return;
                }
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
//----------------------------------------------------
//============================================================================= EMP Effects

function Insomniax_startEMP(%clientId, %player, %time)
{
	if (Player::isDead(%player))
	 return false;
	Client::sendMessage(%clientId,1,"You were hit with EMP!");
	Player::unmountItem(%player,$WeaponSlot);
	%armor = player::getarmor(%player);

	if (%clientId.emped == "0" || %clientId.emped == "")
	{
		if (%armor == earmor || %armor == efemale)
		{
			GameBase::setEnergy(%player,45);
			GameBase::setRechargeRate(%player,2);
			%clientId.emped= 8;
			checkPlayerEMP(%clientId, %player);
		}
		else
		{
			GameBase::setEnergy(%player,0);
			GameBase::setRechargeRate(%player,0);
			%clientId.emped = 12;
			checkPlayerEMP(%clientId, %player);
		}
	}
	else
	{
		if (%time)
			%clientId.emped = %time;
		else
			%clientId.emped = 14;
	}
}

function checkPlayerEMP(%clientId, %player)
{
	if (Player::isDead(%player))
	 return 0;
	if(%clientId.emped > 0)
	{
		%clientId.emped -= 2;  
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
	else
	{
		%clientId.emped=0;
		Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		GameBase::setRechargeRate(%player,8);
	}			
}

//============================================================================= Poisoning

function Renegades_startBlind(%clientId, %player)
{
	%flag = Player::getMountedItem(%clientId,$FlagSlot);
        Client::sendMessage(%clientId,1,"You have been injected with flesh eating bacteria!");
	if($poisonTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 15;
		checkPlayerBlind(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 15;
	if(%flag == "flag")
       	 DoTheFlagDrop(%player,0);
}


function checkPlayerBlind(%clientId, %player)
{
        if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 2;  
		%drrate = GameBase::getDamageLevel(%player) + 0.12;
			if  (!Player::isDead(%player)) 
			{
			 	%flag = Player::getMountedItem(%clientId,$FlagSlot);
			        if(%flag == "flag")
	                         DoTheFlagDrop(%player,0);
				GameBase::setDamageLevel(%player, %drrate);  
				Player::setDamageFlash(%player,0.75);  
				if  (Player::isDead(%player))
				{
					messageall(0, Client::getName(%clientId) @ " died from a disease.");
					%clientId.scoreDeaths++;
		      		        %clientId.score--;
					Game::refreshClientScore(%clientId);
					$poisonTime[%clientId] = 0;
				}
			}
			else
			{
		
			$poisonTime[%clientId] = 0;
		}
		

		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"The effects of the posion wear off.");
		return;
	}
 }


//============================================================================= Flamer Burn

function Renegades_startBurn(%clientId, %player)
{

	Client::sendMessage(%clientId,1,"You are on fire!");
	
	if($burnTime[%clientId] == 0)
	{
		Player::setDamageFlash(%player,0.50);
		$burnTime[%clientId] = 5;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 7;
}

function checkPlayerBurn(%clientId, %player)
{

	if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 1;  
		%drrate = GameBase::getDamageLevel(%player) + 0.01;
		if  (!Player::isDead(%player)) 
		{
			GameBase::setDamageLevel(%player, %drrate);  
			Player::setDamageFlash(%player,0.50);  
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " was incinerated.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$burnTime[%clientId] = 0;
			}
		}
		else
		{
			$burnTime[%clientId] = 0;
		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",1,%player);
     	}
	else
	{
		Client::sendMessage(%clientId,1,"You stop burning.");
	}			
}

//================================================================================
function ixWeaponDrop(%this, %weapon) { Player::unmountItem(%this,$WeaponSlot);
 if(%weapon == Slayer) 
{ 
Player::setItemCount(%this,"Slayer",0); 
Player::setItemCount(%this,"FBWRocketLauncher",0); 
}
else Player::setItemCount(%this,%weapon,0); 
%obj = newObject("","Item",%weapon,1,false); 
schedule("Item::Pop(" @ %obj @ ");", 
$ItemPopTime, %obj); 
addToSet("MissionCleanup", %obj); 
GameBase::throw(%obj,%this,10,true); } 

//=============================================================================
