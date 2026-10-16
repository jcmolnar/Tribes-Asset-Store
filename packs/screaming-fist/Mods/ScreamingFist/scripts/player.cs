echo("Loading Screaming Fist Version");
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
			if( %type == MAWAssRifle || %type == MAWGrenadeLauncher || %type == MAWIncendiaryRifle )
			{
				Player::setItemCount(%this, MAWIncendiaryRifle, 0);
				Player::setItemCount(%this, MAWGrenadeLauncher, 0);
				%type = MAWAssRifle;
			}
			else if(%type == RocketLauncher || %type == FBWRocketLauncher )
			{
				Player::setItemCount(%this, FBWRocketLauncher, 0);
				%type = RocketLauncher;
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

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	//echo("type", %type);
	//echo("object", %object);
	//echo("Data Name", GameBase::getDataName(%object));

	//*************************************************************************************************************
	// SF Addition - Begin - 7/19/99 - 3:30AM
	//*************************************************************************************************************
	if( GameBase::getDataName(%this) == tmount || %type == $OspreyImpactDamageType)
	{
		//echo("tmount");
		return;
	}
	if(%type == $FBWMissleDamageType)
	{
		%object = $FBWClientIDonRemove;
		//echo("%object - Player onDamage ",%object);
		%value = 1.0;
	}
	if(%type == $FlashDamageType)
	{
		Player::setDamageFlash(%this, 1.0);
		schedule("ConcGrenade::Flash("@%this@","@50@");",0,%this);
	}
	//*************************************************************************************************************
	// SF Addition - End
	//*************************************************************************************************************
	if (Player::isExposed(%this)) {
		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;
		//*************************************************************************************************************
		// SF Addition - Begin - 5/7/99 - 12:50AM
		//*************************************************************************************************************
		//if (%value > 0.05)
		//{
		//echo("Spawn Blood");
		//echo("-----------");
		//echo("%mom ",%mom);
		//echo("%this ",%this);
		//echo("%type ",%type);
		//echo("%vec ",%vec);
		//echo("%vertPos ",%vertPos);
		//echo("%pos ",%pos);
		//echo("%value ",%value);
		//echo("%quadrant ",%quadrant);
		//echo("%object ",%object);
		//echo("------------");
		
		//echo("BloodSpawnLag - ", $BloodSpawnLag[%this]);
		
		//	if( $BloodSpawnLag[%this] != True )
		//	{
		//		$BloodSpawnLag[%this] = True;
		
		//		%loopamount = %value * 10;
		//echo("%loopamount ",%loopamount);
		//		if( %loopamount > 5 )
		//			%loopamount = 5;
		
		//		for(%i=1; %i <= %loopamount; %i++)
		//		{
		//echo(%i);
		//			%strength = %value * 7.5;
		//			%flyingGib = newObject("","Mine","Giblet");
		//			addToSet("MissionCleanup", %flyingGib);
		//			GameBase::throw( %flyingGib, %this, %strength, true);
		//		}
		
		//		schedule("$BloodSpawnLag["@%this@"] = False;", 0.5, %this);
		
		//Spawn Proj method
		//Fires "blood" Projectiles
		// Player position
		//%thisPos = getBoxCenter(%this);
		//%NewPosX = 0 + (getWord(%thispos,0));
		//%NewPosY = 0 + (getWord(%thispos,1));
		//%NewPosZ = 0 + (getWord(%thispos,2));
		//echo("%NewPosX ",%NewPosX);
		//echo("%NewPosY ",%NewPosY);
		//echo("%NewPosZ ",%NewPosZ);
		//%Nvec = Vector::normalize(%vec);
		//%trans = Vector::getRotation(%Nvec);
		//echo("%trans ",%trans);
		//%trans1 = getWord(%trans,0);
		//%trans2 = getWord(%trans,1);
		//%trans3 = getWord(%trans,2);
		//%trans4 = getWord(%trans,0);
		//%trans5 = getWord(%trans,1);
		//%trans6 = getWord(%trans,2);
		//%trans7 = getWord(%trans,0);
		//%trans8 = getWord(%trans,1);
		//%trans9 = getWord(%trans,2);
		// Change Transform
		//%Newtrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@
		//	   %trans8 @" "@ %trans9 @" "@ %NewPosX @" "@ %NewPosY @" "@ %NewPosZ; 
		//echo("%Newtrans ",%Newtrans);
		// How fast and in what direction is the Player Moving.
		//%vel = Item::getVelocity(%player);
		//%Newvel = %vel * %value;
		//Spawns Projectile and plays sound
		//Projectile::spawnProjectile("Blood",%Newtrans,%this,%Newvel);
		//	}
		//}
		
		//*************************************************************************************************************
		// SF Addition - End
		//*************************************************************************************************************
		
		Player::applyImpulse(%this,%mom);
		if( $teamplay && %damagedClient != %shooterClient ) {
			if( Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient)  ) {
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
			else
				if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
					%friendFire = $Server::TeamDamageScale;
				else  
					%friendFire = 1.0;	
		}
		else
			if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
				%friendFire = $Server::TeamDamageScale;
			else  
				%friendFire = 1.0;	
			//************************************************************************************
			//  SF ADDITION FOR BOTS
			//************************************************************************************
			if (Player::isAIControlled(%damagedClient) == "true")				//===== Determines if player is A.I. (by EMO1313, added by Werewolf)
			{
				%shooterObj = Client::getControlObject(%shooterClient);
				echo ("AI " @ %damagedClient @ " was shot at by a " @ getObjectType (%shooterObj));
				
				if (getObjectType (%shooterObj) == "Player")				// Is the shooting client a player?
				{
					%shooterpos = GameBase::getPosition(%shooterClient);			//===== Gets Shooters Location & Other Varibles
					%worldLoc = WaypointToWorld ( %shooterpos );
					%aiTeam = Client::GetTeam(%damagedClient);
					%aiName = Client::GetName(%damagedClient);
					%aiId = %damagedclient;
					//echo (%damagedClient @ " Is Damaged - Heading For " @ %shooterpos @ " - " @ %woldloc);
					
					if(String::findSubStr(%aiName, "Guard") >= 0)				//===== Guard Bot Uses Shields
					{
						Player::useItem(%aiId, "beacon") ;
						//echo ("Guard Bot Uses Shields");
					}
					
					AI::HuntTarget(%aiName, %shooterClient, 1);						//===== Send Bot On Its Way
					
					AI::Jump(%aiId,0);				//Do some jumping so we're not standing around like living targets.
					schedule("AI::Jump(" @ %aiId @ ",0);", 2);      //I mean if you were shot at, what would YOU do ?!?
					schedule("AI::Jump(" @ %aiId @ ",0);", 3);
					schedule("AI::Jump(" @ %aiId @ ",0);", 5);
					schedule("AI::Jump(" @ %aiId @ ",0);", 6);
					schedule("AI::Jump(" @ %aiId @ ",1);", 7);
					schedule("AI::Jump(" @ %aiId @ ",0);", 9);
				}
			}
			//End of AI damage stuff
			//*******************************************************************************************
			//*******************************************************************************************
			if (!Player::isDead(%this)) {
				%armor = Player::getArmor(%this);
				//More damage applyed to head shots
				//*************************************************************************************************************
				// SF Addition - Begin - 7/19/99 - 2:50AM
				//*************************************************************************************************************
				if(%vertPos == "head" && %type == $SniperRifleDamageType)
					%value = 2.0;			
				//*************************************************************************************************************
				// SF Additions - End
				//*************************************************************************************************************
				//If Shield Pack is on
				if (%type != -1 && %this.shieldStrength) {
					%energy = GameBase::getEnergy(%this);
					%strength = %this.shieldStrength;
					if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
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
						if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MissileDamageType || %type == $MineDamageType)) { 				
							Player::trigger(%this, $WeaponSlot, false);
							%weaponType = Player::getMountedItem(%this,$WeaponSlot);
							if(%weaponType != -1)
								Player::dropItem(%this,%weaponType);
							Player::blowUp(%this);
						}
						else
						{
							if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type == $MissileDamageType || %type == $MineDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
								if(%quadrant == "front_left" || %quadrant == "front_right") 
									%curDie = $PlayerAnim::DieBlownBack;
								else
									%curDie = $PlayerAnim::DieForward;
							}
							else
								if( Player::isCrouching(%this) ) 
									%curDie = $PlayerAnim::Crouching;							
								else
									if(%vertPos=="head") {
										if(%quadrant == "front_left" || %quadrant == "front_right"	) 
											%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
										else 
											%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
										
									}
									else
										if (%vertPos == "torso") {
											if(%quadrant == "front_left" ) 
												%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
											else
												if(%quadrant == "front_right") 
													%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
												else
													if(%quadrant == "back_left" ) 
														%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
													else
														if(%quadrant == "back_right") 
															%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
										}
										else
											if (%vertPos == "legs") {
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

function Player::onCollision(%this, %object)
{
	//************************************************************************************
	//  SF ADDITION FOR LADDERS
	//************************************************************************************
	if( GameBase::getDataName(%object) == "Ladder" )
	{
		ClimbLadder(%this, %object);
	}
	//************************************************************************************
	//  SF ADDITION FOR LADDERS - END
	//************************************************************************************
	//************************************************************************************
	//  SF ADDITION FOR BOTS
	//************************************************************************************
	
	else if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "true")
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
		//****************************************************************************************
		//   SF Addition for mountable turrets
		//
		//   Ratorasniki - May 19 1999 - 12:43 PM EST
		//
		//   basically telling tribes you can jump into turrets just like vehicles
		//   which is exactly what we want :)
		//   :D
		//
		//   See turret.cs for the rest of the turret code :)
		//**************************************************************************************** 
		%turret = Player::getMountObject (%this);
		%this.lastMount = %turret;
		
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %turret, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this)); 
	}
	//******************************************************************************************
	// SF END
	//******************************************************************************************
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
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret && %name != GRoCTurret)
	{
		if(!GameBase::isPowered(%objectId)) 
		{
			// echo("Turret " @ %objectId @ " not powered.");
			return;
		}
	}
	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
		GameBase::getDataName(%objectId) != DeployableTurret && GameBase::getDataName(%objectId) != GRoCTurret && !$TestCheats) {
		Client::SendMessage(%clientId,0,"Only Deployable Turrets are controllable through here.");
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

