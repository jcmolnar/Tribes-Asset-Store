
ItemImageData HMImage 
{
  shapeFile = "rocket";
  mountPoint = 0;
  weaponType = 0;
minEnergy = 0.2;
maxEnergy = 1;
  projectileType = HolyShell;
  accuFire = false;
  reloadTime = 0.5;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundFireDisc;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData HM 
{
  description = "Holy Mortar";
  className = "Weapon";
  shapeFile = "grenadeL";
  hudIcon = "grenade";
  heading = "bweapons";
  shadowDetailMask = 4;
  imageType = HMImage;
  price = 450;
  showWeaponBar = true;
};

ItemImageData WGImage 
{
	shapeFile = "snowplume";
    mountPoint = 0;

	//projectileType = "Undefined";
	weaponType = 0; // Single Shot
	reloadTime = 0.7;
	fireTime = 1.0;
	minEnergy = 0.2;
	maxEnergy = 1;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = "";
	sfxReload   = SoundMortarReload;
   
};

ItemData WG
{
    description = "Tornado";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	heading = "bweapons";
    className = "Weapon";
    shadowDetailMask = 4;
    imageType = WGImage;
	showWeaponBar = true;
    price = 500;
};

function WGImage::onFire(%player, %slot) 
{		
		 	 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %armor = Player::getArmor(%player);
			 %los = GameBase::getLOSInfo(%player,3000);
			 %pos = $los::position;
			 %trans = GameBase::getMuzzleTransform(%player);
		       %vel = Item::getVelocity(%player);
				Projectile::spawnProjectile("bolt1",%trans,%player,%vel);

//
// First Spiral
//
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos @ " " @ %yPos @ " " @ %zPos+4;
					%obj = newObject("","Mine","firstTornado");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+2 @ " " @ %yPos+2 @ " " @ %zPos+8;
					%obj = newObject("","Mine","wind1");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+4 @ " " @ %yPos @ " " @ %zPos+12;
					%obj = newObject("","Mine","wind2");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos @ " " @ %yPos-4 @ " " @ %zPos+16;
					%obj = newObject("","Mine","wind3");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-4 @ " " @ %yPos @ " " @ %zPos+18;
					%obj = newObject("","Mine","wind4");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-2 @ " " @ %yPos+4 @ " " @ %zPos+22;
					%rot = "0 0 0";
					%obj = newObject("","Mine","wind5");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+2 @ " " @ %yPos+6 @ " " @ %zPos+24;
					%obj = newObject("","Mine","wind6");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+6 @ " " @ %yPos+4 @ " " @ %zPos+26;
					%obj = newObject("","Mine","wind7");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+8 @ " " @ %yPos @ " " @ %zPos+28;
					%obj = newObject("","Mine","wind8");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+6 @ " " @ %yPos-4 @ " " @ %zPos+30;
					%obj = newObject("","Mine","wind9");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+2 @ " " @ %yPos-8 @ " " @ %zPos+32;
					%obj = newObject("","Mine","wind10");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos @ " " @ %yPos @ " " @ %zPos+4;
					%obj = newObject("","Mine","firstTornado");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-2 @ " " @ %yPos-2 @ " " @ %zPos+8;
					%obj = newObject("","Mine","wind1");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-4 @ " " @ %yPos @ " " @ %zPos+12;
					%obj = newObject("","Mine","wind2");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos @ " " @ %yPos+4 @ " " @ %zPos+16;
					%obj = newObject("","Mine","wind3");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos+4 @ " " @ %yPos @ " " @ %zPos+18;
					%obj = newObject("","Mine","wind4");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-2 @ " " @ %yPos-4 @ " " @ %zPos+22;
					%obj = newObject("","Mine","wind5");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-2 @ " " @ %yPos-6 @ " " @ %zPos+24;
					%obj = newObject("","Mine","wind6");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-6 @ " " @ %yPos-4 @ " " @ %zPos+26;
					%obj = newObject("","Mine","wind7");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-8 @ " " @ %yPos @ " " @ %zPos+28;
					%obj = newObject("","Mine","wind8");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-6 @ " " @ %yPos+4 @ " " @ %zPos+30;
					%obj = newObject("","Mine","wind9");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);

			%newPos = %xPos-2 @ " " @ %yPos+8 @ " " @ %zPos+32;
					%rot = "0 0 0";
					%obj = newObject("","Mine","wind10");
					Armor::ThrowGrenade(%player, %obj);
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
}

ItemImageData ABImage
{
  shapeFile = "breath";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.0;
  fireTime = 0.2;
  minEnergy = 0.2;
  maxEnergy = 1;
  projectileType = ABBolt;
  accuFire = false;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData AB 
{
  heading = "bweapons";
  description = "Angel Blaster";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = ABImage;
  price = 250;
  showWeaponBar = true;
showInventory = false;
};

ItemImageData QuakeImage 
{
  shapeFile = "mortar";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0.2;
  maxEnergy = 1;
  reloadTime = 0.51;
  fireTime = 1.29;
  minEnergy = 3;
  maxEnergy = 4;
  //projectileType = undefined;
  accuFire = false;
  sfxFire = Soundfiremortar;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Quake 
{
  heading = "bweapons";
  description = "Quake";
  className = "Weapon";
  shapeFile = "mortar";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = QuakeImage;
  price = 350;
  showWeaponBar = true;
  showInventory = false;
};

ItemImageData GodTearImage 
{
  shapeFile = "fusionbolt";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0.2;
  maxEnergy = 1;
  projectileType = GodShell;
  accuFire = false;
  reloadTime = 2;
  fireTime = 1.5;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = bigExplosion4;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = bigExplosion1;
  sfxReady = SoundJetlight;
};

ItemData GodTear 
{
  description = "God Tear";
  className = "Weapon";
  shapeFile = "fusionbolt";
  hudIcon = "mortar";
  heading = "bweapons";
  shadowDetailMask = 4;
  imageType = GodTearImage;
  price = 1025;
  showWeaponBar = true;
showInventory = false;
};

ItemImageData PLAImage 
{
  shapeFile = "mortartrail";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0.2;
  maxEnergy = 1;
  projectileType = putridbomb;
  accuFire = false;
  reloadtime = 2.1;
  fireTime = 0.1;
  sfxFire = SoundPlasmaTurretFire;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
  sfxActivate = SoundPickUpWeapon;
};

ItemData PLA
{
  description = "Plague";
  className = "Weapon";
  shapeFile = "chaingun";
  hudIcon = "disk";
  heading = "bweapons";
  shadowDetailMask = 4;
  imageType = PLAImage;
  price = 725;
  showWeaponBar = true;
showInventory = false;
};

ItemImageData DFAImage
{
   shapeFile = "breath";
   mountPoint = 0;
   mountRotation = {-1.0, 0, 0 };
   mountOffset = {0, 300, 300 };
   weaponType = 2;  // Sustained
   projectileType = LightningCharge;
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };
   sfxReady    = SoundDiscSpin;
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData DFA
{
  className = "Weapon";
  description = "DFA";
  heading = "bweapons";
  hudIcon = "blaster";
  imageType = DFAImage;
  price = 350;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
showInventory = false;
};


ItemImageData FireballImage
{
   shapeFile  = "discb";
	mountPoint = 0;
        mountOffset = 
        {
        0, 0.0, 0 }
        ;
	weaponType = 0; // Single Shot
	reloadTime = 2.0;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 20;

	//projectileType = Undefined;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fireball
{
   heading = "bWeapons";
	description = "Wing Span";
	className = "Weapon";
   shapeFile  = "fusionbolt";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireballImage;
	price = 485;
	showWeaponBar = true;
showInventory = false;
};

function FireballImage::onFire(%player, %slot) 
{
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        %fired = (Projectile::spawnProjectile("FireballShot",%trans,%player,%vel));
				%fired.deployer = %client;
}

ItemImageData ESPImage
{
   shapeFile = "discb";
   mountPoint = 3;
        mountOffset = 
        {
        0, 0.0, 0.0 }
        ;
        mountRotation = 
        {
        0, 0, 0 }
        ;
   weaponType = 2;  // Sustained
   projectileType = ESPShot;
   minEnergy = 15;
   maxEnergy = 0.1;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
   accufire = True;
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.15, 0.15, 4.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData ESP
{
  className = "Weapon";
  description = "ESP";
  heading = "bWeapons";
  hudIcon = "energyRifle";
  imageType = ESPImage;
  price = 600;
  shadowDetailMask = 4;
  shapeFile = "mrtwig";
  showWeaponBar = true;
showInventory = false;
};

function ESP::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, " Grace: <f2> The divine grace of angel's soul only will serve you when you have someone to impress.");
}


ItemImageData freezeImage
{
   shapeFile  = "smoke";
	mountPoint = 0;
        spinUpTime = 0.4;
        spinDownTime = 0.5;
      weaponType = 0;
	projectileType = freezebolt;
	reloadTime = 0.01;  
      fireTime = 0.09; 
	minEnergy = 0.2;
	maxEnergy = 1;

	accuFire = false;
      sfxSpinUp = SoundMortaridle;
	sfxFire = SoundFireFreeze;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Freeze
{
   heading = "bWeapons";
	description = "Freeze";
	className = "Weapon";
   shapeFile  = "chaingun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FreezeImage;
	price = 500;
	showWeaponBar = true;
      showInventory = false;
};

function Freeze::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Freeze Spell, Blasts your foe with freezing cold air.");
}
//----------------------------------------------------------------------------

ItemImageData Flamer2Image
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	projectileType = FlamerBolt;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 1;
	minEnergy = 0.2;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Flamer2
{
	description = "Angle Fire";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "plasmabolt";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Flamer2Image;
	price = 175;
	showWeaponBar = true;
    validateShape = true;
	showInventory = false;
};

function FlamerImage2::onFire(%player, %slot) 
{		
		 	 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %armor = Player::getArmor(%player);
			 %los = GameBase::getLOSInfo(%player,3000);
			 %pos = $los::position;
			 %trans = GameBase::getMuzzleTransform(%player);
		       %vel = Item::getVelocity(%player);
					%fired = (Projectile::spawnProjectile("solarBurst1",%trans,%player,%vel));	%fired.deployer = %client;
					%fired = (Projectile::spawnProjectile("solarBurst2",%trans,%player,%vel));	%fired.deployer = %client;
}
//----------------------------------------------------------------------------

ItemImageData HealImage
{
   shapeFile  = "plasmatrail";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1;
	minEnergy = 0.2;
	maxEnergy = 1;

	projectileType = HealBlast;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Heal
{
   heading = "bWeapons";
	description = "Heal Spell";
	className = "Weapon";
   shapeFile  = "plasmatrail";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HealImage;
	price = 85;
	showWeaponBar = true;
	showInventory = false;
};

function heal::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Forgiveness, Heals anything 100%");
}
//----------------------------------------------------------------------------

ItemImageData ImplodeImage
{
   shapeFile  = "enex";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1;
	minEnergy = 0.2;
	maxEnergy = 1;

	projectileType = ImplodeBlast;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Implode
{
   heading = "bWeapons";
	description = "Implode Spell";
	className = "Weapon";
   shapeFile  = "enex";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ImplodeImage;
	price = 85;
	showWeaponBar = true;
	showInventory = false;
};

function Implode::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Blue Death, The angles trusty side arm, if this cant do it then nothing will.");
}
//---------------------------------------------------------------------------
$UserPrefCoolTime = 0;
$HDRange = 1000;

ItemImageData PhoenixPackImage
{
        shapeFile = "rocket";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 10;
        maxEnergy = 10;
        mountOffset = { 0.2, -0.05, 0.3 };
  		mountRotation = { 1.5, 0, 0 };
		lightType = 3;
        lightRadius = 10;
        lightTime = 10;
        lightColor = { 0.3, 0.1, 0.6 };
        firstPerson = false;
};

ItemData PhoenixPack
{
        description = "War Angel Wings";
        shapeFile = "rocket";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = PhoenixPackImage;
        price = 150;
        hudIcon = "energypack";
        showWeaponBar = false;
		showInventory = false;
        hiliteOnActive = true;
};

ItemImageData PhoenixPack2Image
{
        shapefile = "rocket";
		mountPoint = 2;
		mountOffset = { -0.2, -0.05, 0.3 };
  		mountRotation = { 1.5, 0, 0 };
};

ItemData PhoenixPack2 
{	description = "War Angel Wings"; 
	className = "Backpack"; 
	shapeFile = "rocket"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = PhoenixPack2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
	hiliteOnActive = true;
}; 

ItemImageData PhoenixPack3Image
{
        shapefile = "rocket";
		mountPoint = 2;
		mountOffset = { -0.3, -0.05, 0.3 };
  		mountRotation = { -0.3, 0, -1.2 };
};

ItemData PhoenixPack3 
{	description = "War Angel Wings"; 
	className = "Backpack"; 
	shapeFile = "rocket"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = PhoenixPack3Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
	hiliteOnActive = true;
}; 

ItemImageData PhoenixPack4Image
{
        shapefile = "rocket";
		mountPoint = 2;
		mountOffset = { 0.3, -0.05, 0.3 };
  		mountRotation = { -0.3, 0, 1.2 };
};

ItemData PhoenixPack4 
{	description = "War Angel Wings"; 
	className = "Backpack"; 
	shapeFile = "rocket"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = PhoenixPack4Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
	hiliteOnActive = true;
}; 

function PhoenixPackImage::onActivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        %player = Client::getOwnedObject(%client);
        if (GameBase::getLOSInfo(%player,$HDRange))
        {
                %dest = $los::position;
                if($CoolTime[%client] > 0)
                {
                        //Bottomprint(%client, "<jc><f1>Warning!\n<f2>Hyperdrive not cooled yet.");
                }
                else
                {
                        Hyperdrive(%client,%player,%dest);
                        PhoenixPackImage::onDeactivate(%client,%imageSlot);
                        $CoolTime[%client] = $UserPrefCoolTime;
                        CoolOff(%client,%player);
                }
        }
        else
        {
                Bottomprint(%client, "<jc>Max Flight Distance for Angel Light Speed is <f2>1000m");
                PhoenixPackImage::onDeactivate(%client,%imageSlot);
        }
}

function PhoenixPackImage::onDeactivate(%player,%imageSlot)
{
        Player::trigger(%player,$BackpackSlot,false);
}

function PhoenixPack::onMount(%player,%imageSlot,%item,$ExtraSlotA, $ExtraSlotB, $ExtraSlotC, $ExtraSlotD, $ExtraSlotE, $ExtraSlotF, $ExtraSlotG) 
{	Player::mountItem(%player,PhoenixPack2,$ExtraSlotA);
	Player::mountItem(%player,PhoenixPack3,$ExtraSlotB);
	Player::mountItem(%player,PhoenixPack4,$ExtraSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "<F2>You Have Embodied The Feared <f3>Angel Of Death"); 
}

function PhoenixPack::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$ExtraSlotA);
	Player::unmountItem(%player,$ExtraSlotB);
	Player::unmountItem(%player,$ExtraSlotC);
}

function CoolOff(%client,%player)
{
        if ($CoolTime[%client] > 0)
        {
                $CoolTime[%client] -= 1;
                schedule("CoolOff(" @ %client @ "," @ %player @ ");",1,%player);
        }
        else
        {
                $CoolTime[%client] = 0;
                Bottomprint(%client, "<jc><f2>>>>>>>Wooosh<<<<<<");
        }
}

function Hyperdrive(%client,%player,%dest)
{
      GameBase::setPosition(%client,%dest);
     	//Bottomprint(%client, "<jc><f1>Hyperdrive!\n<jc><f0>Hyperdrive cooling -- wait about 15 seconds.");
}

