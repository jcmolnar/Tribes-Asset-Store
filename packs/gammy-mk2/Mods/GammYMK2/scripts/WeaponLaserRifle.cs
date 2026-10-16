//--------------------------------------

$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";

//--------------------------------------

$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;

//--------------------------------------

LaserData sniperLaser
{
   laserBitmapName   = "lightningNew.bmp";
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
	 	if(%clientId != %shooter) Client::sendMessage(%clientId,1,Client::getName(%shooter) @ " hit you with an Electrical Surge!");
	 else
		 Client::sendMessage(%clientId,1,"You hit yourself with an Electrical Surge!");
		 if($empTime[%clientId] == 0)
		 {
			 GameBase::setEnergy(%player,0); 
			 GameBase::setRechargeRate(%player,0);
			 $empTime[%clientId] = 20; //10;
			 checkPlayerEMP(%clientId, %player);
		 }
		 else
			 $empTime[%clientId] = 20;
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
			 schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
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
   heading = "hSnipers Gear";
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
			 $empTimeF[%clientId] = 15; //10;
			 checkPlayerEMP3(%clientId, %player);
		 }
		 else
			 $empTimeF[%clientId] = 15;
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
			 schedule("checkPlayerEMP3(" @ %clientId @ ", " @ %player @ ");",2,%player);
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
		 %drrate = GameBase::getDamageLevel(%player) + 0.25; // 0.05++++++ 
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
			 $empTime4[%clientId] = 40; //10;
			 checkPlayerEMP4(%clientId, %player);
		 }
		 else
			 $empTime4[%clientId] = 40;
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













