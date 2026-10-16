//Laser Rifle, Kaioken, Poison, Fire, EMP, Light scripts.....this file is where i threw all the loose ends and other scripts i had no other place for

//--------------------------------------

$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

//--------------------------------------

$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;

//--------------------------------------

LaserData sniperLaser
{
   laserBitmapName   = "LaserPulse.BMP";
   hitName           = "laserhit.dts";

   damageConversion  = 0.07;
   baseDamageType    = $ShockDamageType;

   beamTime          = 0.6;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};



//--------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
                 mountoffset = { 0, 0, -0.1 };
                 mountrotation = { 0, 1.3, 0 };
	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 35;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

function EMP(%clientId, %player, %shooter) 
	{
	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " hit you with a surge of electricity");
	        else
		 Client::sendMessage(%clientId,1,"You surged yourself with electricity");
		 if($empTime[%clientId] == 0)
		 {
			 GameBase::setEnergy(%player,0); 
			 GameBase::setRechargeRate(%player,0);
			 $empTime[%clientId] = 120; //10;
			 checkPlayerEMP(%clientId, %player);
		 }
		
		 else
			 $empTime[%clientId] = 120;


}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkPlayerEMP(%clientId, %player)
	 {
		 if($empTime[%clientId] > 0)
		 {
			 %transform = GameBase::getMuzzleTransform(%player);
	         %velocity = Item::getVelocity(%player);
	         Projectile::spawnProjectile("ESD",%transform,%player,%velocity); 
			 $empTime[%clientId] -= 2;
			 checkPlayerBlind(%clientId, %player); //+++++++++++++
			 schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",0.1,%player);
		 }
		 else
		 {
			 Client::sendMessage(%clientId,1,"The Surge is now under control.");
			 GameBase::setRechargeRate(%player,8);
		 }
	 } 
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function checkPlayerBlind(%clientId, %player)
 {
	 if($empTime[%clientId] > 0) //+++++++
	 {
		 $empTime[%clientId] -= 2; //-= 2;++++++++++++
		 %drrate = GameBase::getDamageLevel(%player) + 0.01; // 0.05++++++ 
		 if (!Player::isDead(%player))
		 {
			 GameBase::setDamageLevel(%player, %drrate);
			 //Player::setDamageFlash(%player,0.75);
			 if (Player::isDead(%player))
			 {
				 messageall(0, Client::getName(%clientId) @ " could not control the surge in time.");
				 %clientId.scoreDeaths++;
				 %clientId.score--;
				 Game::refreshClientScore(%clientId);
				 $empTime[%clientId] = 0;
				 }
			 }
			 else
			 {
				 $empTime[%clientId] = 0;
			 }
			 schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player);
			 }
			 else
			 { 
//Client::sendMessage(%clientId,1,"something else may go here later :)");//+++++++++++++
//				return; //+++++++
			 }
		 }


ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle."); 
}

//--------------------------------------
function LaserRifle::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The laser Rifle, Now a little improved to stand up against the best armored foes.", 10);Weapon::onUse(%player,%item);
}


function EMP2(%clientId, %player, %shooter) 
	{
	 	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " blinded you.");
		
		if($empTime2[%clientId] == 0)
		 {
			 $empTime2[%clientId] = 50; //10;
			 checkPlayerEMP2(%clientId, %player);
		 }	
                      else
			 $empTime2[%clientId] = 50;
		
 }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkPlayerEMP2(%clientId, %player)
	 {
		 if($empTime2[%clientId] > 0)
		 {
			 Player::setDamageFlash(%player, 1.15); 
			 $empTime2[%clientId] -= 2;
			 checkPlayerBlind2(%clientId, %player); 
			 schedule("checkPlayerEMP2(" @ %clientId @ ", " @ %player @ ");",1,%player); //2
		 }
		 else
		 {
			 Client::sendMessage(%clientId,1,"Visual Sensors are back to normal.");
			 GameBase::setRechargeRate(%player,8);
		 }
	 } 
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function checkPlayerBlind2(%clientId, %player)
 {
	 if($empTime2[%clientId] > 0) //+++++++
	 {
		 $empTime2[%clientId] -= 2; //-= 2;++++++++++++
		 %drrate = GameBase::getDamageLevel(%player); // 0.05++++++ 
		 if (!Player::isDead(%player))
		 {
			 GameBase::setDamageLevel(%player, %drrate);
			 Player::setDamageFlash(%player,1.15);
			 if (Player::isDead(%player))
			 {
				 messageall(0, Client::getName(%clientId) @ " died from an overdose of U.V. Radiation");
				 %clientId.scoreDeaths++;
				 %clientId.score--;
				 Game::refreshClientScore(%clientId);
				 $empTime2[%clientId] = 0;
				 }
			 }
			 else
			 {
				 $empTime2[%clientId] = 0;
	         }
			 schedule("checkPlayerBlind2(" @ %clientId @ ", " @ %player @ ");",1,%player); //5
	  }
		 
 }







function EMP3(%clientId, %player, %shooter) 
	{
	 	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " set you on fire!!");
	        else
		 Client::sendMessage(%clientId,1,"You're on fire!!!");
		 if($empTimeF[%clientId] == 0)
		 {
			 $empTimeF[%clientId] = 100; //10;
			 checkPlayerEMP3(%clientId, %player);
		 }
		 else
			 $empTimeF[%clientId] = 100;
 }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkPlayerEMP3(%clientId, %player)
	 {
		 if($empTimeF[%clientId] > 0)
		 {
			Player::setDamageFlash(%player,1.75); //++++++++++++
			 $empTimeF[%clientId] -= 2;
			%transform = GameBase::getMuzzleTransform(%player);
	         %velocity = Item::getVelocity(%player);
	         Projectile::spawnProjectile("Ackburnies",%transform,%player,%velocity);  
			checkPlayerBlind3(%clientId, %player); //+++++++++++++
			 schedule("checkPlayerEMP3(" @ %clientId @ ", " @ %player @ ");",0.2,%player);
		 }
		 else
		 {
			 Client::sendMessage(%clientId,1,"The fire was put out....");
			 $empTimeF[%clientId] = 0;
		 }
	 } 
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function checkPlayerBlind3(%clientId, %player)
 {
	 if($empTimeF[%clientId] > 0) //+++++++
	 {
		 $empTimeF[%clientId] -= 2; //-= 2;++++++++++++
		 %drrate = GameBase::getDamageLevel(%player) + 0.05; // 0.05++++++ 
		 if (!Player::isDead(%player))
		 {
			 GameBase::setDamageLevel(%player, %drrate);
			 Player::setDamageFlash(%player,1.75);
			 if (Player::isDead(%player))
			 {
				 messageall(0, Client::getName(%clientId) @ " burned down!!");
				 %clientId.scoreDeaths++;
				 %clientId.score--;
				 Game::refreshClientScore(%clientId);
				 $empTimeF[%clientId] = 0;
				 }
			 }
			 else
			 {
				 $empTimeF[%clientId] = 0;
			 }
			 schedule("checkPlayerBlind3(" @ %clientId @ ", " @ %player @ ");",5,%player);
			 }
			 else
			 { 
//Client::sendMessage(%clientId,1,"something else may go here later :)");//+++++++++++++
//				return; //+++++++
			 }
		 }

function EMP4(%clientId, %player, %shooter) 
	{
	 	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " poisoned you");
	 else
		Client::sendMessage(%clientId,1,"you poisoned yourself"); 
		if($empTime4[%clientId] == 0)
		 {
			 $empTime4[%clientId] = 90; //10;
			 checkPlayerEMP4(%clientId, %player);
		 }
		 else
			 $empTime4[%clientId] = 90;
 }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkPlayerEMP4(%clientId, %player)
	 {
		 if($empTime4[%clientId] > 0)
		 {
			 Player::setDamageFlash(%player, 0.20); 
			 $empTime4[%clientId] -= 2;
			 checkPlayerBlind4(%clientId, %player); 
			 schedule("checkPlayerEMP4(" @ %clientId @ ", " @ %player @ ");",1,%player); //2
		 }
		 else
		 {
			$empTime4[%clientId] = 0; 
			Client::sendMessage(%clientId,1," the poison has left your system");
		 }
	 } 
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function checkPlayerBlind4(%clientId, %player)
 {
	 if($empTime4[%clientId] > 0) //+++++++
	 {
		 $empTime4[%clientId] -= 2; //-= 2;++++++++++++
		 %drrate = GameBase::getDamageLevel(%player) + 0.05; // 0.05++++++ 
		 if (!Player::isDead(%player))
		 {
			 GameBase::setDamageLevel(%player, %drrate);
			 Player::setDamageFlash(%player,0.20);
			 if (Player::isDead(%player))
			 {
				 messageall(0, Client::getName(%clientId) @ " died from an overdose of poison");
				 %clientId.scoreDeaths++;
				 %clientId.score--;
				 Game::refreshClientScore(%clientId);
				 $empTime4[%clientId] = 0;
				 }
			 }
			 else
			 {
				 $empTime4[%clientId] = 0;
	         }
			 schedule("checkPlayerBlind4(" @ %clientId @ ", " @ %player @ ");",1,%player); //5
	  }
		 
 }





function EMP5(%clientId, %player, %shooter) 
	{
	 	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " gave you Server God powers");
	 else
		Client::sendMessage(%clientId,1,"you now have Server God powers"); 
		if($empTime5[%clientId] == 0)
		 {
			%energy=GameBase::getEnergy(%player);
			%weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,oarmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
			%armor = Player::getArmor(%player);
			Client::sendMessage(%clientId,0,"God Mode On");
			GameBase::playSound(%player,ForceFieldOpen,0);
			GameBase::startFadeout(%player);
			%rate = Player::getSensorSupression(%player) + 5;
			Player::setSensorSupression(%player,%rate);
			Player::setItemCount(%clientID, ChaingunI,1);
			Player::setItemCount(%clientID, Mortari, 1);
			Player::SetItemCount(%clientID, Chaingun2i, 1);
			Player::SetItemCount(%clientID, BR, 1);
			
			$empTime5[%clientId] = 500; //10;
			 checkPlayerEMP5(%clientId, %player);
		 }
		 else
			 $empTime5[%clientId] = 500;
 }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  function checkPlayerEMP5(%clientId, %player)
	 {
		 if($empTime5[%clientId] > 0)
		 { 
			GameBase::setEnergy(%Player,1000); 
			$empTime5[%clientId] -= 2;
			 checkPlayerBlind5(%clientId, %player); 
			 schedule("checkPlayerEMP5(" @ %clientId @ ", " @ %player @ ");",1,%player); //2
		 }
		 else
		 {
			$empTime5[%clientId] = 0; 
			Client::sendMessage(%clientId,1,"Bye Bye Server Gods powers!!");
			Player::setItemCount(%Player, ChaingunI,0);
			Player::setItemCount(%Player, Mortari, 0);
			Player::SetItemCount(%Player, Chaingun2i, 0);
			Player::SetItemCount(%Player, BR, 0);
			GameBase::playSound(%player,ForceFieldOpen,0);
			GameBase::startFadein(%player);
			%rate = Player::getSensorSupression(%player) - 5;
			Player::setSensorSupression(%player,%rate);
			 %energy=GameBase::getEnergy(%player);
		      %weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,larmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		 }
	 } 
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
function checkPlayerBlind5(%clientId, %player)
 {
	 if($empTime5[%clientId] > 0) //+++++++
	 {
		 $empTime5[%clientId] -= 2; //-= 2;++++++++++++ 
		 if (!Player::isDead(%player))
		 {
			 if (Player::isDead(%player))
			 {
				Client::sendMessage(%clientId,0,"God Mode Off");
				Player::setItemCount(%Player, ChaingunI,0);
				Player::setItemCount(%Player, Mortari, 0);
				Player::SetItemCount(%Player, Chaingun2i, 0);
				Player::SetItemCount(%Player, BR, 0);
				GameBase::playSound(%player,ForceFieldOpen,0);
				GameBase::startFadein(%player);
				%rate = Player::getSensorSupression(%player) - 5;
				Player::setSensorSupression(%player,%rate); 
				messageall(0, Client::getName(%clientId) @ "your powers fade away");
				%energy=GameBase::getEnergy(%player);
		     		%weapon=Player::getMountedItem(%player,$WeaponSlot);
                 		Player::trigger(%player,$WeaponSlot,false);
				Player::unmountItem(%player,$WeaponSlot);
				Player::setArmor(%player,larmor);
                 		schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
				Player::trigger(%player,$WeaponSlot,false);
				GameBase::setEnergy(%player, %energy);
				GameBase::setDamageLevel(%player,%clientId.damagelevel); 
				%clientId.scoreDeaths++;
				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$empTime5[%clientId] = 0;
				 }
			 }
			 else
			 {
				 $empTime5[%clientId] = 0;
	         }
			 schedule("checkPlayerBlind5(" @ %clientId @ ", " @ %player @ ");",1,%player); //5
	  }
		 
 }





//--------------------------------------

$InvList[Kaioken] = 1;
$RemoteInvList[Kaioken] = 1;

//--------------------------------------



//--------------------------------------

$AutoUse[Kaioken] = false;

ItemData Kaioken
{
   description = "Kaioken Ability";
   shapeFile = "PlasmaEx";
   heading = "pArmor Upgrades";
   shadowDetailMask = 4;
   price = 305;
   validateShape = true;
   validateMaterials = true;
};



function Kaioken::onUse(%player,%item)
{
	
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);								
	if (%armor == "Garmor")Kaioken(%clientId, %player, %item);
}


//--------------------------------------
// SUper Saiyan at 80%


function Kaioken(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);
        if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if ($stimTime[%clientId] > 0)
	{
		Client::sendMessage(%clientId,0,"your body could not take the extra power!");
		$StimTime[%clientId]=0;
	}
	else
	{
		if (%armor == "Garmor")
		{
			%energy=GameBase::getEnergy(%player);
			%weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,Karmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
		}	   
		Player::decItemCount(%player, %item);
		Client::sendMessage(%clientId,0,"You used a your Kaioken Technique!");
		$stimTime[%clientId] = 16;
		CheckStim(%clientId, %player);		
	}
}

function OverDoseStim2 (%clientId, %player)
{
		messageall(0, Client::getName(%clientId) @ " Achieved Super Saiyan");
		%energy=GameBase::getEnergy(%player);
			%weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,Oarmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
			Player::DropItem(%Player, Rocketlauncher2s);
			Player::setItemCount(%Player, Rocketlauncher2, 0);
			Player::setItemCount(%Player, FW, 0);
			Player::setItemCount(%Player, FlameGun2, 0);
			Player::setItemCount(%Player, BB2, 0);
			Player::setItemCount(%Player, CometRifle, 0);
			Player::setItemCount(%Player, EnergyPackS, 1);
			Player::setItemCount(%Player, Rocketlauncher2SS, 1);
			Player::setItemCount(%Player, Rocketlauncher2sSS, 1);
			Player::setItemCount(%Player, FWss, 1);
			Player::setItemCount(%Player, FlameGun2SS, 1);
			Player::setItemCount(%Player, BB2SS, 1);
			Player::setItemCount(%Player, CometRifleSS, 1);
			
			Player::MountItem(%Player, EnergyPackS, $BackpackSlot);
			
}


function OverDoseStim (%clientId, %player)
{
		if  (Player::isDead(%player))
			return;
		
		Client::sendMessage(%clientId,0,"died from Kaioken.");
		messageall(0, Client::getName(%clientId) @ " died from Kaioken.");
		$StimTime[%clientId]=0;
		%clientId.ovd=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStim(%clientId, %player)
{
	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	if($debug) echo ("S- " @ %ClientId.ovd @ "");
	if  (Player::isDead(%player))
		return;

	if($StimTime[%clientId] > 0)
	{
		$StimTime[%clientId] -= 2; 
		
		%drrate = GameBase::getDamageLevel(%player) - 0.035;
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 7);
	        bottomprint(%clientId, "<jc><f2>Chances Of Self-Destruct Increased to " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 90);

		if (%rnd > (140 - %clientId.ovd))
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95); 
			return;
		}
		
		if (%clientId.ovd > 79)
		{
			%clientId.ovd = 0;
			OverDoseStim2(%clientId, %player);
			Player::setDamageFlash(%player,0.95); 
			return;
		}
		
		if  (!Player::isDead(%player)) 
		{  
			Player::setDamageFlash(%player,0.35);  
			GameBase::setDamageLevel(%player, %drrate);
			
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " died from his own Kaioken.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$StimTime[%clientId] = 0;
				return;
			}

		}
		else
		{
			$StimTime[%clientId] = 0;
		}
		schedule("CheckStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
   	}
	else
	{
		
		%armor = Player::getArmor(%player);
		
		//if (%armor == "Karmor")
		//{
		Client::sendMessage(%clientId,0,"Kaioken Effect Wears Off.");     
		 %energy=GameBase::getEnergy(%player);
		      %weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,Garmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		//}
	}					
}


//--------------------------------------

$InvList[Bounty] = 1;
$RemoteInvList[Bounty] = 1;

//--------------------------------------

// A little idea I had

//--------------------------------------
$ItemMax[larmor, PhantomC] = 1;
$ItemMax[Warmor, PhantomC] = 0;
$ItemMax[Tarmor, PhantomC] = 0;
$ItemMax[Aarmor, PhantomC] = 0;
$ItemMax[Barmor, PhantomC] = 0;
$ItemMax[Marmor, PhantomC] = 0;
$ItemMax[Harmor, PhantomC] = 0;
$ItemMax[Xarmor, PhantomC] = 0;
$ItemMax[Garmor, PhantomC] = 0;
$ItemMax[Zarmor, PhantomC] = 0;
$ItemMax[Sarmor, PhantomC] = 0;

$InvList[PhantomC] = 1;
$RemoteInvList[PhantomC] = 1;

$AutoUse[PhantomC] = false;

ItemData PhantomC
{
   description = "Phantom Converter";
   shapeFile = "PlasmaEx";
   heading = "pArmor Upgrades";
   shadowDetailMask = 4;
   price = 505;
};



function PhantomC::onUse(%player,%item)
{
	
	%armor = Player::getArmor(%player);
	
	%clientId = Player::getClient(%player);								
	Phantom(%clientId, %player, %item,%armor);
}



//--------------------------------------
// Phantom Fun



function Phantom(%clientId, %player, %item,%armor)
{
	%armor = Player::getArmor(%player);
        if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if ($stimTime[%clientId] > 0)
	{
		Client::sendMessage(%clientId,0,"your body could not take Phantom Conversion");
		$StimTime[%clientId]=0;
	}
	else
	{
		
			%energy=GameBase::getEnergy(%player);
			%weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,Parmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, (%energy+100));
			   
		Player::decItemCount(%player, %item);
		Client::sendMessage(%clientId,0,"You used a your Phantom Converter");
		$stimTime[%clientId] = 16;
		CheckStimP(%clientId, %player,%armor);		
	}
}



function OverDoseStim (%clientId, %player)
{
		if  (Player::isDead(%player))
			return;
		
		Client::sendMessage(%clientId,0,"died from Phantom Conversion.");
		messageall(0, Client::getName(%clientId) @ " died from Phantom Conversion.");
		$StimTime[%clientId]=0;
		%clientId.ovd=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStimP(%clientId, %player,%armor)
{
	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	if($debug) echo ("S- " @ %ClientId.ovd @ "");
	if  (Player::isDead(%player))
		return;

	if($StimTime[%clientId] > 0)
	{
		$StimTime[%clientId] -= 2; 
		
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 7);
	        bottomprint(%clientId, "<jc><f2>Chances Of Self-Destruct Increased to " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 90);

		if (%rnd > (180 - %clientId.ovd))
		{
			
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95); 
			return;
		}
		
		if (%clientId.ovd > 99)
		{
			
			OverDoseStim2(%clientId, %player);
			Player::setDamageFlash(%player,0.95); 
			return;
		}
		
		if  (!Player::isDead(%player)) 
		{  
			Player::setDamageFlash(%player,0.35);  
			GameBase::setDamageLevel(%player, %drrate);
			
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " died from Phantom Conversion.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$StimTime[%clientId] = 0;
				return;
			}

		}
		else
		{
			$StimTime[%clientId] = 0;
		}
		schedule("CheckStimP(" @ %clientId @ ", " @ %player @ ");",2,%player);
   	}
	else
	{
		
		
		
		Client::sendMessage(%clientId,0,"Phantom Effect Wears Off.");     
		 %energy=GameBase::getEnergy(%player);
		      %weapon=Player::getMountedItem(%player,$WeaponSlot);
                  Player::trigger(%player,$WeaponSlot,false);
			Player::unmountItem(%player,$WeaponSlot);
			Player::setArmor(%player,Larmor);
                  schedule("Player::mountItem(" @ %player @ ", " @ %weapon @ ", " @ $WeaponSlot @ ");",0.15,%player);
			Player::trigger(%player,$WeaponSlot,false);
			GameBase::setEnergy(%player, %energy);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		
	}					
}
