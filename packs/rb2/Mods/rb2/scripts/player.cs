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

$PlayerAnim::Celebration1 = 43;
$PlayerAnim::Celebration2 = 44;
$PlayerAnim::Celebration3 = 45;
$PlayerAnim::Taunt1 = 46;
$PlayerAnim::Taunt1 = 47;
$PlayerAnim::Taunt1 = 47;
$PlayerAnim::Stand = 49;
$PlayerAnim::Wave = 50;
$PlayerAnim::OverHere = 38;
$PlayerAnim::Salute = 42;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 30;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{

	GameBase::setRechargeRate(%this,$rb::energyrechargerate);
	if($rb::civilwarmode == 1)
		GameBase::setRechargeRate(%this,1);
	
}

//Kick any idle players because they're stupid
function player::checkIdle(%cl)
{

	if(%cl.stilldead == 1 && %cl.observerMode == "dead")
	{
	%cl.idletime++;
	schedule("Player::CheckIdle(" @ %cl @ ");",1.0);
	}
	else
	{
	%this.stilldead = 0;
	}

	if (%cl.idletime == 30)
		Client::sendMessage(%cl,1,"Warning - Being idle for too long will auto kick you! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 60)
		Client::sendMessage(%cl,1,"You have been idle for one minute.  Four more minutes and you'll be kicked. ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 120)
		Client::sendMessage(%cl,1,"You have been idle for two minutes.  Three more minutes and you'll be kicked. ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 180)
		Client::sendMessage(%cl,1,"You have been idle for three minutes.  Two more minutes and you'll be kicked. ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 240)
		Client::sendMessage(%cl,1,"You have been idle for four minutes.  One more minute and you'll be kicked. ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 280)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 20 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 290)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 10 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 295)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 5 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 296)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 4 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 297)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 3 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 298)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 2 seconds to spawn in! ~wfemale1.wwatchsh.wav");
	if (%cl.idletime == 299)
		Client::sendMessage(%cl,1,"You have been idle for too long!  You have 1 second to spawn in! ~wfemale1.wwatchsh.wav");

	if (%cl.idletime == 300)
	{
	Client::sendMessage(%cl,1,"You have been idle for too long.  Good bye! ~wfemale1.wwatchsh.wav");
	schedule("Net::kick(" @ %cl @ ", \"You were idle for too long so the server kicked you out.  Next time try playing.\");", 5);
	messageall(1, Client::getName(%cl) @ " is being kicked automatically for being idle over 5 minutes. ~wfemale1.wwatchsh.wav");
	}


	// messageall(1, "idle for " @ %cl.idletime @ " observing " @ %cl.observerMode);
	
}

function Player::onRemove(%this)
{

player::blowUp(%this);
	// Drop anything left at the players pos

	Player::unmountItem(%this,$WeaponSlot);
	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1)
		{
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


	Player::dropItem(%this,$FlagSlot);

	%cl = GameBase::getOwnerClient(%this);
	%cl.badaim = 0;
	%cl.observerMode = "dead";
	%cl.stilldead = 1;
	player::checkIdle(%cl);


	
	%trans = GameBase::getMuzzleTransform(%this);
	%vel = Item::getVelocity(%this);

	// for(%i = 1; %i < 1; %i++)
	// {

	%weaponName = Player::getMountedItem(%this,$WeaponSlot);
	if(%weaponName == flareGun) 
	{
	Player::UnMountItem(%this,$WeaponSlot);
	%rndx = (getRandom() * 5) - 5;
	%rndy = (getRandom() * 5) - 5;
	%rndz =(getRandom() * 25);
	Projectile::spawnProjectile("SpearProj",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);
	}
	// }



	%cl.dead = 1;
	Player::dropItem(%cl,$FlagSlot);
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) 
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) 
		{
			 if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
			 Player::dropItem(%this,%type);
		}
	}

	if(%cl != -1)
	{
		if (%cl.scrambled == 1)
		{
			%cl.scrambled = 0;
			%ShooterId = %cl.flamer;

			$scrambled[%cl] = 0;
			$scrambleTime[%cl] = 0;
			if (Client::getName(%cl.flamer) != "" && Client::getTeam(%cl) != Client::getTeam(%ShooterId))
			{
			MessageAll(0, Client::getName(%ShooterId) @ " toasted " @ Client::getName(%cl));
			%ShooterId.score += 8;
			bottomprint(%ShooterId, "<jc><f2>Kill Worth 8 points.  You now have " @ %ShooterId.score @ " points. \n\n\n\n", 3);
			Game::refreshClientScore(%ShooterId);
			%ShooterId.killspree++;
			echo("GAME: score " @ %ShooterId @ " is at " @ %ShooterId.scoreKills);

			}
			else
			{
			MessageAll(0, Client::getName(%cl) @ " burned to a crisp!");
			}

			if (Client::getName(%cl.flamer) != "" && Client::getTeam(%cl) == Client::getTeam(%ShooterId))
			{

			MessageAll(0, Client::getName(%ShooterId) @ " fried his own teammate, " @ Client::getName(%cl));
			%ShooterId.score -= 30;
			bottomprint(%ShooterId, "<jc><f2>Team Kill Worth -30 points.  You now have " @ %ShooterId.score @ " points. \n\n\n\n", 3);
			Game::refreshClientScore(%ShooterId);

				%ShooterId.teamkills++;
				%killerId = %ShooterId;
				if (%killerId.teamkills == 3)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed twice and can now be killed from the <TAB> menu."), $DeathMessageMask);
				else if (%killerId.teamkills == 5)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed five times and can now be kicked from the <TAB> menu."), $DeathMessageMask);
				else if (%killerId.teamkills >= 6)
					messageAll(0, strcat(Client::getName(%killerId), " has team-killed more than three times and can now be banned from the <TAB> menu."), $DeathMessageMask);
			


			}



		}
		if ($Stormbots::UsingDrone[%cl])
		{
			GameBase::applyDamage(%this.vehicle,$ImpactDamageType,10,GameBase::getPosition(%this.vehicle),"0 0 0","0 0 0",%this.vehicle);
		}
		if(%this.vehicle != "")
		{
			if(%this.driver != "") 
			{
				%this.driver = "";
        	 		Client::setControlObject(Player::getClient(%this), %this);
        	 		Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));

		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 0.1, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
	}
	
	if($rb::gibmode == 1)
		player::blowUp(%this);

			%item = newObject("","Item","RepairPatch",1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));

			%item = newObject("","Item","RepairPatch",1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));

			%item = newObject("","Item","RepairPatch",1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));

}

function Player::tweakout(%this, %count)
{

	if (%count)
	{
		%count--;
		schedule ("Player::Tweakout(" @ %this @ ", " @ %count @ ");",1);
		GameBase::setRotation(%this, "1 -1 1");

	}


}

// Deadtaco - respawn on mouse click - very tough to do

function Player::CheckTrigger(%cl)
{

	if (player::istriggered(%cl, $WeaponSlot))
	{
	messageall(0, "yay");
	}

// schedule("Player::CheckTrigger(" @ %cl @ ");", 0.2);


}





			
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{

	//overcharged players have a chance of having their thrusters overload from damage
	%damagedClient = Player::getClient(%this);

	if(GameBase::getRechargeRate(%this) >=9)
		{

		%rndx = floor(getRandom() * 10);

			if(%rndx == 5)
			{
				 %trans = GameBase::getMuzzleTransform(%this);
				 %vel = Item::getVelocity(%this);

			 for(%i = 1; %i < 10; %i++)
			   {
	
			   %rndx = (getRandom() * 4) - 4;
			   %rndy = (getRandom() * 4) - 4;
			   %rndz =(getRandom() * 15) - 5;
			   Projectile::spawnProjectile("TurretPart",%trans,%this, %rndx @ " " @ %rndy @ " " @ %rndz);

			   }


			%value = 2;
			messageall(0, Client::getName(%damagedClient) @ "'s overcharged thruster was blown up.");
			player::blowUp(%this);

			}

		}



	if (%damagedClient.invulnerable || $invulnerable[%damagedClient])
		return;

 	//if (Player::isExposed(%this)) {
	%shooterClient = %object;

//	echo("Client no. " @ %shooterClient @ " has inflicted damage type " @ %type @ " on " @ Client::getName(%damagedClient));
	echo(Client::getName(%shooterClient) @ " has inflicted damage type " @ %type @ " on " @ Client::getName(%damagedClient));

	Player::applyImpulse(%this,%mom);

	if (%type == 26 && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) != Client::getTeam(%ShooterClient))
	{
		%damagedClient.flamer = %shooterclient;
	}
	else
		%damagedClient.flamer = "";


	if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) 
	{
		if (%shooterClient != -1) 
		{
			%curTime = getSimTime();
			if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && (%damagedClient != %shooterClient) && ($Server::TeamDamageScale > 0)) 
			{
				if(%type != $MineDamageType) 
				{
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
					Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
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

	%shooterObj = Client::getControlObject(%shooterClient);


	if (!Player::isDead(%this))
	{
		%armor = Player::getArmor(%this);
		//More damage applied to head shots
		%values = %value;
		%randx = (getRandom() * %values * 10 * $rb::kickpower) - (getRandom() * %values * 3 * $rb::kickpower);

		if ($spawnprotect[%damagedClient] == true)
			{
			schedule("centerprint(" @ %damagedClient @ ", \"<jc><f1>*** YOU WERE PROTECTED FROM A SPAWN KILL ***\", 2);", 0.55);
			schedule("centerprint(" @ %shooterClient @ ", \"<jc><f8><L14>THAT PLAYER JUST SPAWNED IN YOU SPAWN KILLER!\", 2);", 0.5);
			return 0;
			}

		
//		if($rb::civilwarmode == 1)
//		{
//			if(%type == $ExplosionDamageType)
//				player::blowup(%shooterClient);
//
//			if(%type == $impactdamagetype || %type == $landingdamagetype || %type == $plasmacannondamagetype || %type == $bulletdmgtype29 || %type == $bulletdmgtype35 || %type == 0)
//			{
//				//do nothing.  Its civil war!
//			}
//			else
//			{
//			schedule("centerprint(" @ %shooterClient @ ", \"<jc><f8><L14>A CIVIL WAR IS IN EFFECT!  MUSKETS, PRODS, & LANCES ONLY!\", 5);", 0.5);
//			return 0;
//			}
//		}

		//make the lance a home run hitter
		if (%type != $bulletdmgtype35)
			ixApplyKickback(%this, %randx, %randx);
		else
			ixApplyKickback(%this, %randx*1.5, %randx*1.5);



		//make a sound whenever you shoot someone so you know you got a hit

		if(%shooterClient != %damagedClient)
			Client::sendMessage(%shooterClient,1,"~wenergyexp.wav");

		%CheckHelmet = Player::getMountedItem(%this,$BackpackSlot); // see if player is wearing some sort of protection
		%CheckSuit = Player::getMountedItem(%this,$BackpackSlot); // see if player is wearing some sort of protection

		// Lets see if we were hit by a bullet or by an explosion (or even fire!)...
		// Deadtaco's friendly bullet code...

		
		if(%vertPos != "" && (%type == 37 || %type == 41 || %type == 45 || %type == 51  || %type == 50 || %type == 36 || %type == 38 || %type == 42 || %type == 40 || %type == 43 || %type == 52 || %type == 49 || %type == $bulletdmgtype22 || %type == $bulletdmgtype23  || %type == $bulletdmgtype24 || %type == $bulletdmgtype25  || %type == $bulletdmgtype26  || %type == $bulletdmgtype27  || %type == $bulletdmgtype28  || %type == $bulletdmgtype29  || %type == $bulletdmgtype30  || %type == $bulletdmgtype31  || %type == $bulletdmgtype32))
		   {
			$ProjectileType = "bullet";
		   }
		else if(%vertPos != "" && (%type == 25 || %type == 26))
		   {
			$ProjectileType = "fire";
		   }
		else
		   {
			$ProjectileType = "other";
		   }


		if(%vertPos != "" && (%type == 4 || %type == 5 || %type == 11 || %type == 12  || %type == 15 || %type == 17 || %type == 27 || %type == 30 || %type == 34 || %type == 44 || %type == 48 || %type == 54))
		   {
			$ProjectileType = "explosion";
		   }

		if(%vertPos == "head" && (%type == $BulletDmgType5 || %type == $BulletDmgType2 || %type == $BulletDmgType14 || %type == $BulletDmgType16 || %type == $BulletDmgType15 || %type == $BulletDmgType23 || %type == $BulletDmgType29 || %type == $bulletdmgtype35))
		{

			if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)) 
			{


				if(%CheckHelmet != Helmet) // Lets make sure the player isn't wearing a helmet!				
				{
					// %shooterClient.score += 10;
					schedule("centerprint(" @ %damagedClient @ ", \"<jc><f1>*** You were shot in the head. ***\", 2);", 0.5);
					schedule("centerprint(" @ %shooterClient @ ", \"<jc><f8><L14>YOU GOT A HEAD SHOT!\", 1);", 0.5);
					%shooterClient.scoreheadshots++;
					if(%type == $bulletdmgtype35) 
						player::blowUp(%damagedClient);
					Game::refreshClientScore(%shooterClient);
					%value += (%value * 6.0);
				}
				else
				{
					schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your helmet deflected a head shot. ***\", 2);", 0.5);
					schedule("bottomprint(" @ %shooterClient @ ", \"<jc><f8><L14>Your bullet was deflected by a helmet\", 2);", 0.5);

					Game::refreshClientScore(%shooterClient);
					// %value = (%value * 0.2);
					
				}
			}
		}

		if(%vertPos == "legs" && $ProjectileType == "bullet") //leg shots from bullets do 70% of normal damage
		{
			%value = (%value * 0.7);

		}

		if(%vertPos == "legs" && %type == $BulletDmgType5) //leg shots from bullets do 70% of normal damage
		{
			%value = (%value * 0.5); 
			//LEG SHOTS NOW DO 50% DAMAGE WITH BARRETT SNIPER RIFLE

		}


		if(%vertPos == "head" && %CheckHelmet == "Helmet" && $ProjectileType == "bullet") //Any helmet shots from any gun do 20% of normal damage
		{
			
			%value = (%value * 0.2);
			schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your helmet deflected a head shot. ***\", 2);", 0.5);

		}

		if(%CheckHelmet == "FlakJacket" && $ProjectileType == "explosion") //Check for a flak jacket
		{
			
			%value = (%value * 0.4);
			schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your jacket absorbed some of the explosion. ***\", 2);", 0.1);

		}

		if(%vertPos == "torso" && %CheckHelmet == "KevlarVest" && $ProjectileType == "bullet") //Check for a kevlar vest
		{

			schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your vest protected you against a bullet. ***\", 2);", 0.5);
			schedule("bottomprint(" @ %shooterClient @ ", \"<jc><f8><L14>Your shot was absorbed by a kevlar vest\", 2);", 0.5);

			Game::refreshClientScore(%shooterClient);
 			%value = (%value * 0.4);

		}

		if(%vertPos == "torso" && %CheckHelmet == "KevlarVest" && %type == $BulletDmgType5) //Check for a kevlar vest
		{

			schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your vest protected you against a sniper bullet. ***\", 2);", 0.5);
			schedule("bottomprint(" @ %shooterClient @ ", \"<jc><f8><L14>Your sniper shot was weakened by a kevlar vest\", 2);", 0.5);
			Game::refreshClientScore(%shooterClient);
 			%value = (%value * 0.3);

		}

		if(%CheckSuit == "FireSuit" && $ProjectileType == "fire") //Check for a fire suit
		{
			
			%value = (%value * 0);
			schedule("bottomprint(" @ %damagedClient @ ", \"<jc><f1>*** Your fire suit is protecting you from fire! ***\", 2);", 0.1);

		}

		// messageall(3, "Vert Pos:  " @ %vertPos @ " Quadrant: " @ %quadrant @ " Type: " @ $ProjectileType); //unremark this to see where you are shooting people		
		// messageall(3, "value = " @ %value);

		//If Shield Pack is on
		if (%type != -1 && %this.shieldStrength)
		{
			%energy = GameBase::getEnergy(%this);
			%strength = %this.shieldStrength;
			if (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $BombDamageType)
				%strength *= 0.75;
			else if (%type == $FlameDamageType || %type == $BlasterDamageType)
				%strength *= 0.5;
			else if (%type == $KamikazeDamageType)
				%strength *= 0.0;
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
		if (%type == $EMPDamageType)
			Insomniax_startEMP(%damagedClient, %this, %shooterClient); 
		else if (%type == $PacificationDamageType)
		{
			if(%damagedClient.pacified != 1)
			{
				if(%damagedClient == %shooterClient)
					Client::sendMessage(%damagedClient,1,"You hit yourself with tear gas!");
				else if(Client::getName(%shooterClient) == "")
					Client::sendMessage(%damagedClient,1,"A bot hit you with tear gas!");
				else
					Client::sendMessage(%damagedClient,1,Client::getName(%shooterClient) @ " hit you with tear gas!");
				%weapon = Player::getMountedItem(%this,$WeaponSlot);
				if(%weapon != -1)
				{
					%this.lastWeapon = %weapon;
					Player::unmountItem(%this,$WeaponSlot);
				}
				$pacified[%damagedClient] = 1;
				%damagedClient.pacified = 1;
				schedule("Stormbots_PacifyEnd(" @ %damagedClient @ "," @ %this @ ");", 15, %this);
			}
		}
		else if (%type == $DecloakDamageType)
		{
			%pack = Player::getMountedItem(%this, $BackpackSlot);
			if(Player::isTriggered(%this,$BackpackSlot))
				Player::useItem(%this, %pack);
			if(%this.cloakPack == 1 || %this.cloakBoost == 1 || %this.cloaked >= 1 || %this.cloakdevice >= 1 || %this.cloakGun == 1 || %this.cloakplane == 1)
			{
				%this.cloakPack = 0;
				%this.cloakBoost = 0;
				%this.cloaked = 0;
				%this.cloakdevice = 0;
				%this.cloakGun = 0;
				%this.cloakplane = 0;
				GameBase::playSound(%this,ForceFieldOpen,0);
				GameBase::startFadein(%this);
			}
			if ($Stormbots::UsingDrone[%damagedClient])
			{
				GameBase::applyDamage(%this.vehicle,$ImpactDamageType,10,GameBase::getPosition(%this.vehicle),"0 0 0","0 0 0",%this.vehicle);
				Client::sendMessage(%damagedClient,0,"Communication disrupted - Drone lost");
			}
			Stormbots::startComScramble(%damagedClient, %this);
		}
		else if (%type == $ScramblerDamageType && Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
			Stormbots_startScramble(%damagedClient, %this);

				//reality bites

		else if (%type == $LavaDamageType && Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
			Stormbots_startScramble(%damagedClient, %this);

		else if (%type == $ExplosionDamageType)
			{
				Client::sendMessage(%damagedClient,1,"You were nailed by a concussive blast!");

				%weapon = Player::getMountedItem(%damagedClient,$WeaponSlot);
				Player::setDamageFlash(%damagedClient,10.0);
				if(%weapon == "")
					return false;
				else
					Player::dropItem(%damagedClient,0);
					Player::dropItem(%damagedClient,1);
					Player::dropItem(%damagedClient,2);
					Player::dropItem(%damagedClient,3);
					Player::dropItem(%damagedClient,6);
					Player::dropItem(%damagedClient,%weapon);
			}

		else if (%type == $BulletDmgType18) //Got flashed by a flash grenade
			{
				Client::sendMessage(%damagedClient,1,"You were blinded by a flash grenade!");

				// Player::UnMountItem(%player,7);

				%weapon = Player::getMountedItem(%damagedClient,$FlagSlot);
				if(%weapon == "")
					return false;
				else
					Player::dropItem(%damagedClient,$FlagSlot);
					Player::blinded(%damagedClient, 15);
					// Player::MountItem(%damagedClient,MiragePack,$FlagSlot);
					// schedule("Player::UnMountItem(%damagedClient,7);", 10.0);
				

			}

			
				

		else if (%type == $RepairDamageType)
			GameBase::repairDamage(%this,0.5);
  		if (%value)
  		{
			%value = $DamageScale[%armor, %type] * %value * %friendFire;
			if ($IsDoppelganger[%damagedClient] > 0 && %value > 0.1)
				%value *= 100;
			%dlevel = GameBase::getDamageLevel(%this) + %value;
			%spillOver = %dlevel - %armor.maxDamage;
			GameBase::setDamageLevel(%this,%dlevel);
			%flash = Player::getDamageFlash(%this) + %value * 2;
			if (%flash > 0.75) 
				%flash = 0.75;
			Player::setDamageFlash(%this,%flash);
			//If player not dead then play a random hurt sound
			if(!Player::isDead(%this))
			{ 
				if(%damagedClient.lastDamage < getSimTime()) 
				{
					%sound = radnomItems(3,injure1,injure2,injure3);
					playVoice(%damagedClient,%sound);
					%damagedClient.lastdamage = getSimTime() + 1.5;
				}
			}
			else
			{
				if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type== $BombDamageType|| %type == $RocketDamageType|| %type == $DroneDamageType)) 
				{
		 			Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
					Player::blowUp(%this);
				}
				else
				{
					if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type== $BombDamageType|| %type == $RocketDamageType )) || (Player::getLastContactCount(%this) > 6) ) 
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
				Client::onKilled(%damagedClient,%shooterClient, %type);
			}
		}
	}
//	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Stormbots_PacifyEnd(%clientId,%player)
{
	%clientId.pacified = 0;
	$pacified[%clientId] = 0;
	if(%player.lastWeapon != "")
	{
		Player::useItem(%player,%player.lastWeapon);		 	
		%player.lastWeapon = "";
	}
	Client::sendMessage(%clientId,1,"The effects of the tear gas wear off.");
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Stormbots_startScramble(%clientId,%player)
{
	%clientId.scrambled = 1;
	$scrambled[%clientId] = 1;
	if($scrambleTime[%clientId] <= 0)
	{
		if (%clientId.scrambled != 1)
			Client::sendMessage(%clientId,1,"You're covered in napalm!");
		$scrambleTime[%clientId] = 1;
		checkPlayerScrambled(%clientId, %player);
	}
	else
		$scrambleTime[%clientId] = 1;
}

function checkPlayerScrambled(%clientId, %player)
{
	if($scrambleTime[%clientId] > 0)
	{
		%scrtime = floor(getRandom() * 9.99) + 1;
		%newtime = $scrambleTime[%clientId] - %scrtime;
		$scrambleTime[%clientId] = %newtime;
		%CheckSuit = Player::getMountedItem(%player,$BackpackSlot); // see if player is wearing some sort of protection
		
		if  (!Player::isDead(%player) && %CheckSuit != "FireSuit") 
		{
			Player::dance(%player, %scrtime);
			%t = floor(getRandom() * 99.99);
			if(%t >= 99)
				remoteNextWeapon(%clientId);
			else
				remotePrevWeapon(%clientId);
		}
		else
			$scrambleTime[%clientId] = 0;
		schedule("checkPlayerScrambled(" @ %clientId @ ", " @ %player @ ");",%scrtime,%player);
	}
	else
	{
		%clientId.scrambled = 0;
		$scrambled[%clientId] = 0;
		// Client::sendMessage(%clientId,1,"You've been badly burned.");
	}
}

function Player::dance(%this, %steps)
{
	if(%steps)
	{

%CheckSuit = Player::getMountedItem(%this,$BackpackSlot); // see if player is wearing some sort of protection	

if(%CheckSuit == "FireSuit")
	%steps = -1;	

		%x = getRandom() * 200 - 100;
		%y = getRandom() * 200 - 100;
		%z = getRandom() * 50;
		%t = floor(getRandom() * 99.99);
		if(%t >= 75)
		{
			%z += 200;
//			echo("T-value is " @ %t @ ". Z-value is " @ %z);
		}

		%armor = Player::getArmor(%this);
		if(%armor == "uharmor")
		{
			%x = %x * 2.0;
			%y = %y * 2.0;
			%z = %z * 2.0;
		}
		else if(%armor == "harmor")
		{
			%x = %x * 1.5;
			%y = %y * 1.5;
			%z = %z * 1.5;
		}
		else if(%armor == "hlarmor")
		{
			%x = %x * 0.75;
			%y = %y * 0.75;
			%z = %z * 0.75;
		}

		// Player::applyImpulse(%this, %x @ " " @ %y @ " " @ %z);

		Player::setAnimation(%this, 34);
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("LavaFlame",%trans,%this,%vel);
		Projectile::spawnProjectile("LavaFlame",%trans,%this,%vel);
		 
		schedule("Player::dance(" @ %this @ ", " @ %steps - 1 @ ");", 0.2);
		GameBase::applyDamage(%this,$flamedamagetype,0.05,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}

function Player::blinded(%this, %blindtime)
{

	if(%blindtime)
	{
		%data = GameBase::getDataName(%this);
		%damaged = GameBase::getDamageLevel(%this);

	if((%data.maxDamage/1.05) < %this.damage) 
		%blindtime = -1;
	
	if(Player::isDead(%this))
		%blindtime = -1;	

		if(!Player::isDead(%this))  //make sure a player isn't blinded after respawn
		{
		centerprint(%this, "<jc><f2><l4><jc>\n\n\n\n\f4*************YOU ARE BLIND!***********\n*************YOU ARE BLIND!***********\n*************YOU ARE BLIND!***********\n*************YOU ARE BLIND!***********\n*************YOU ARE BLIND!***********\n*************YOU ARE BLIND!***********\n\n\n\n\n\n\n\n\n\n\n\n\n...man this burns...", 0.8);
	 	Player::setDamageFlash(%this,1);
		schedule("Player::blinded(" @ %this @ ", " @ %blindtime - 1 @ ");", 0.8);
		}
		else
		{
		%blindtime = -1;
		}
		
	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Stormbots::startComScramble(%clientId,%player)
{
	%player.comscramble = 1;
	if($comscrambleTime[%clientId] <= 0)
	{
		Client::sendMessage(%clientId,1,"Communications disrupted!");
		$comscrambleTime[%clientId] = 10;
		checkPlayerComScrambled(%clientId, %player);
	}
	else
		$comscrambleTime[%clientId] = 10;
}

function checkPlayerComScrambled(%clientId, %player)
{
	if($comscrambleTime[%clientId] > 0)
	{
		$comscrambleTime[%clientId] -= 2;
		if (Player::isDead(%player)) 
			$comscrambleTime[%clientId] = 0;
		schedule("checkPlayerComScrambled(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else
	{
		%player.comscramble = 0;
		Client::sendMessage(%clientId,1,"Communications restored!");
	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{

	%Player1 = Player::getClient(%this);
	%Player2 = Player::getClient(%object);
	%aiId = Player::getClient(%this);
	%aiName = Client::GetName(%aiId);
	%aiTeam = Client::GetTeam(%this);	 
	%objTeam = Client::GetTeam(%object);

	if (Player::isAIControlled(%Player1) == "true" && Player::isAIControlled(%Player2) == "true")
	{
		
	}
	else
	{
		if (Player::isDead(%this)) 
		{
			if (getObjectType(%object) == "Player") 
			{
				// Transfer all our items to the player
				%sound = false;
				%max = getNumItems();
				for (%i = 0; %i < %max; %i = %i + 1) 
				{
					%count = Player::getItemCount(%this,%i);
					if (%count) 
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);
						if (%delta > 0) 
						{
							Player::decItemCount(%this,%i,%delta);
							%sound = true;
						}
					}
				}
				if (%sound)
				{
					// Play pickup if we gave him anything
					playSound(SoundPickupItem,GameBase::getPosition(%this));
				}
			}
		}
		else if (Player::getMountedItem(%this,$BackpackSlot) == "TransportPack" && getObjectType(%object) == "Player" && Client::GetTeam(%this) == %objTeam && !Player::isDead(%object) && %Player2.traitor != 1)
		{
			%Player1.buddy = %Player2;
			Client::sendMessage(%Player1,0,"Transport Pack locked to " @ Client::GetName(%Player2));
		}
  	}
}

function Player::getHeatFactor(%this)
{
	if(Player::getMountedItem(%this,$BackpackSlot) == "HeatSink") 
		return 0.0;

	%client = Player::getClient(%this);
	%player = Client::getControlObject(%client);

	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vehicle, which is not always correct
	// but should be OK for now.
	
//	if ((Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this))) //Werewolf
	if (%this.driver == 1)
		return 1.0;

	if(%this.vehicle != "" || %client.passenger == 1)  //Must be a passenger on a vehicle
		return 0.0;

	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if ((%lastTime + 1.5) < %time) 
	{
		return 0.0;
	}
	else
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
//		echo("objectId = " @ %objectId);
		return;
	}

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.vehicle != "")
		return;

	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
//		echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	%name = GameBase::getDataName(%objectId);
//	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableSatchel && %name != DeployableChaingun && %name != DeployableSeeker && %name != DeployableFlak && %name != DeployableConTurret && %name != FlameTurret && %name != DeployablePhaseLok && %name != DeployableMiniPlasma && %name != DeployableAntiMatterTurret)
	if(%name == DeployableAntiMatterTurret || (%name != CameraTurret && %name != FlameTurret && %name != BarrageTurret && (String::findSubStr(%name, "Deployable") < 0)))
	{
		if(!GameBase::isPowered(%objectId)) 
		{
			echo("Turret " @ %objectId @ " not powered.");
			return;
		}
	}
	%player = Client::getOwnedObject(%clientId);
	if(Player::getMountedItem(%player,$BackpackSlot) != Laptop)
	{
		if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret  && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats)
		{
			Client::SendMessage(%clientId,0,"Must be at a Command Station or Laptop to control turrets");
	   		return;
		}
	}
	if(GameBase::getDamageState(%objectId) == "Enabled")
	{
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
		if ($Stormbots::UsingDrone[%clientId])
		{
			GameBase::applyDamage(%ctrlObject,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%ctrlObject);
			if(%ownedObject.lastWeapon != "") 
			{
				Player::useItem(%ownedObject,%ownedObject.lastWeapon);
				%ownedObject.lastWeapon = "";
			}
			$Stormbots::UsingDrone[%clientId] = false;
			%ownedObject.vehicle = "";
		}
	}
}

