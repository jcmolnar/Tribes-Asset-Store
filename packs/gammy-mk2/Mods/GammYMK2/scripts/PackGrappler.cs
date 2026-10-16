$InvList[JumperPack] = 1;
$RemoteInvList[JumperPack] = 1;
$ItemMax[larmor, JumperPack] = 1;
$ItemMax[lfemale, JumperPack] = 1;
$ItemMax[Marmor, JumperPack] = 0;
$ItemMax[mfemale, JumperPack] = 0;
$ItemMax[Harmor, JumperPack] = 0;

$InvList[JumpAmmo] = 1;
$RemoteInvList[JumpAmmo] = 1;

$SellAmmo[JumpAmmo] = 5;
$AmmoPackMax[JumpAmmo] = 2;
$AmmoPackItems[7] = JumpAmmo;
$WeaponAmmo[JumpGun] = JumpAmmo;

$ItemMax[larmor, JumpAmmo] = 20;
$ItemMax[lfemale, JumpAmmo] = 20;
$ItemMax[marmor, JumpAmmo] = 0;
$ItemMax[mfemale, JumpAmmo] = 0;
$ItemMax[harmor, JumpAmmo] = 0;
//--------------------------------------
ExplosionData JumpGunExp
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};


ItemData JumpAmmo
{
	description = "Teleport Charge";
	className = "Ammo";
	shapeFile = "endarrow";//mortarammo,endarrow
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};



GrenadeData JumpGunBoltwang
{
   bulletShapeName    = "dirarrows.dts";//grenade.dts
   explosionTag       = JumpGunExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $PlasmaDamageType;//$ShrapnelDamageType

   explosionRadius    = 15;
   kickBackStrength   = 350.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";//smoke.dts
};




//--------------------------------------

ItemImageData JumpGunImage { 
	shapeFile = "rocket"; 
	mountPoint = 0; 
	weaponType = 0; 
	reloadTime = 0; 
	fireTime = 0.5; 
	minEnergy = 5; 
	maxEnergy = 6; 
	//projectileType = JumpGunBolt; 
	accuFire = true; 
	ammoType		= JumpAmmo;
	sfxFire = SoundJetHeavy; 
	sfxActivate = SoundPickUpWeapon;
	//mountOffset = {0.2,-1.2,-1};//{0.065, 0.1, -0.1}
	//mountRotation = {0, -1.57, 0}; //-1.57
	 }; 

ItemData JumpGun { 
	heading = "gTools"; 
	description = "Jacker"; 
	className = "Weapon"; 
	shapeFile = "GrenadeL"; 
	hudIcon = "plasma"; 
	shadowDetailMask = 4; 
	imageType = JumpGunImage; 
	price = 385; 
	showWeaponBar = true; 
	};

function JumpGun::onMount(%player,%imageSlot)
{	bottomprint(Player::getClient(%player), "Teleport Pack. Fly at light speed to a given position!", 10);
	Player::trigger(%player,$BackpackSlot,true);
}

function JumpGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//--------------------------------------

ItemImageData JumperPackImage
{
	shapeFile = "jetPack";//armorPack,discb
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.1, 0 };
  	mountRotation = { -2.57, -3.14, 0};
	firstPerson = false;
};

ItemData JumperPack
{
	description = "Teleport pack";
	shapeFile = "jetPack";//armorPack,plant2,diskb,discb
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = JumperPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = false;
};

function JumperPack::onMount(%player,%item){
		%client = Player::getClient(%player);
		bottomprint(%client, "Teleport Pack, Gets you to a target destination in nano-seconds", 10);
		%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[JumpGun]) && Player::getItemCount(%player,JumpAmmo)) ;
		if(%AmmoCount == 0 && Client::isItemShoppingOn(%client,%item)){	

		buyItem(%client,"JumpAmmo");
		Client::sendMessage(%client,0,"Auto buying Teleport Charges");
		}
	}

function JumperPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == JumpGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function JumperPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[JumpGun]) && Player::getItemCount(%player,JumpAmmo)) ;
	if(%AmmoCount){

		Player::mountItem(%player,JumpGun,$WeaponSlot);
			}
		else
		Client::sendMessage(Player::getClient(%player),0,"No Teleport charges detected. ~waccess_denied.wav");
	}
}

function JumperPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == JumpGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the JumpGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

//--------------------------------------
ExplosionData BuildExp
{
   shapeName = "fusionex.dts";//
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 1;

   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};



GrenadeData BuildShock 
{ 
	bulletShapeName = "breath.dts";
 	explosionTag = BuildExp;
 	collideWithOwner = false;
 	ownerGraceMS = 500;
 	collisionRadius = 0.0;
 	mass = 0.0;
 	elasticity = 0.1;
 	damageClass = 0;
 	damageValue = 0.01;
 	damageType = $NullDamageType;
 	explosionRadius = 10;
 	kickBackStrength = 0.0;
 	maxLevelFlightDist = 1;
 	totalTime = 0.05;
 	liveTime = 0.05;
 	projSpecialTime = 0.05;
 	inheritedVelocityScale = 1.0;
 	smokeName = "breath.dts";
 };

 



function JumpGunImage::onFire(%player,%slot)
{	
	%client = GameBase::getOwnerClient(%player);
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[JumpGun]) && Player::getItemCount(%player,JumpAmmo)) ;
	if(%AmmoCount){
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1000))
		{	%object = getObjectType($los::object);
			if (%object!="Player" && %object !="Flier" && %object !="") 
{
	//Is target near a flag?
	//-----------
 		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$ItemObjectType,$los::position,0,0,0,0); //50 60 50 0
		%num2 = CountObjects(%set,"flag",%num);
		%totalnum = Group::objectCount(%set);
		%enemyflag=0;
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%name = Item::getItemData(%obj);
			//client::sendMessage(Player::getClient(%player),1,"Itemdata: "@ %i @ " " @ %name);
			if(%name == "flag" && (GameBase::getTeam(%obj) != Gamebase::getTeam(%player)))
			{     echo(Client::getName(GameBase::getOwnerClient(%player))@" "@Player::getClient(%player)@" "@%player@" Trying to Jump near flag...");
				Client::sendMessage(Player::getClient(%player),1,"Phase instability at target. ~wError_Message.wav");%enemyflag++;

			}
		}
		deleteObject(%set);
	
if (%enemyflag != 0) return;
//------------------------
			if(!$JumpUsed[%player]) 
			{
	GameBase::startFadeout(%player); 
				//--------------------
				// hack so players dont 
				// end up in walls
                        %obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
					%xpos = getWord($los::position,0);
					%ypos = getWord($los::position,1);
					%zpos = getWord($los::position,2);
					
					//echo($los::normal);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%zpos += 1;//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%zpos -= 3;//ceiling
					}
				else if (Vector::dot($los::normal,"0 0 -1") >= -0.1 || Vector::dot($los::normal,"0 0 -1") <= 0.1 ) {
						//wall

					%xopos = getWord($los::normal,0);
					%yopos = getWord($los::normal,1);
					%xpos = %xpos + %xopos + %xopos;
					%ypos = %ypos + %yopos + %yopos;

					}

				else {
						%rot = Vector::getRotation($los::normal);//other
					}

				}

					$Jumpy++;
				 		if(Player::getMountedItem(%player, 2) == "Smblast")
						{
							Player::dropItem(%player,Player::getMountedItem(%player, 2));
							Client::sendMessage(Player::getClient(%player),1,"You dropped your gun while jumping... NICE JOB.");
						}
//-------------set their position
	GameBase::startFadeout(%player); 
      %player.invulnerable = true;
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
	Item::setVelocity(%client, 0);
      GameBase::setPosition(%player, %xpos@" "@%ypos@" "@%zpos);
	Item::setVelocity(%client, 0);
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
	Player::decItemCount(%player,JumpAmmo);
	playSound(SoundDryFire, GameBase::getPosition(%player));
	playSound(SoundMissileReload, GameBase::getPosition(%player));
				$JumpUsed[%player] = true;
			      %time = 5; //45 30
				schedule("JumpWaitTime(" @ %time @ ", " @ %player @ ");", 1, %player);
			      %Build = 2; //5
		      %weapon = Player::getMountedItem(%player,$WeaponSlot);
		      if(%weapon != -1) {
			      Player::unMountItem(%player,$WeaponSlot);
				bottomprint(%client,"",0);
		      }

	         Client::setControlObject(%client, Client::getObserverCamera(%client));
	         Observer::setOrbitObject(%client, %player, 3, 3, 3);
				schedule("JumpBuildTime(" @ %build @ ", " @ %player @ ");", 1, %player);
		GameBase::startFadein(%player);



}		
			else
			Client::sendMessage(%client,0,"Teleport pack not ready.  ~wError_Message.wav");
			}
			else
			Client::sendMessage(%client,0,"Cannot Teleport there.  ~wError_Message.wav");
		}
		else
		Client::sendMessage(%client,0,"Target exceeds Teleport gun range ~wError_Message.wav");
	}
	else
	Client::sendMessage(%client,0,"You ran out of Teleport charges. ~waccess_denied.wav");
	
}



function JumpWaitTime(%time, %player)
{
	if(%time > 0)
	{
		JumpReset(%player);
	}
	else if(%time == 0)
	{
		JumpReset(%player);
	}
}

function JumpBuildTime(%Build, %player)
{


	%client = GameBase::getOwnerClient(%player);
	if(%Build > 0)
	{
	Item::setVelocity(%client, 0);
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 	
	schedule("JumpBuildTime( " @ %Build -1 @ ", " @ %player @ ");", 1, %player);
	}
	else if(%Build <= 0)
	{
      %player.invulnerable = "";
      Client::setControlObject(%client, %client);
      GameBase::setAutoRepairRate(%player, 0);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	   if(%weapon == -1) {
		remotenextweapon(%client);
	    }



	}
}

function JumpReset(%player)
{
	$JumpUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),3,"Teleport pack ready...");
}
