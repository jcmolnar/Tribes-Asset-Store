//================================
// Easy Way For Invetory Headings
//================================
$InvHead[ihArm] = "a•¤Armor Suits¤•";        
$InvHead[ihWea] = "b•¤Standard Weapons¤•";
$InvHead[ihEne] = "c•¤Energy Based¤•";
$InvHead[ihBul] = "d•¤Cartridge Based¤•";
$InvHead[ihPls] = "e•¤Plasma Based¤•";
$InvHead[ihExp] = "f•¤Explosive Based¤•";
$InvHead[ihTbp] = "g•¤Tactical Back Packs¤•";
$InvHead[ihEqu] = "h•¤Base/Field Equipment¤•";
$InvHead[ihTur] = "i•¤Deffence Turrets¤•";
$InvHead[ihMis] = "j•¤Misc Devices¤•";
$InvHead[ihAmo] = "x•¤Weapon Ammunition¤•";
//================================
$ExtraWeaponSlotA=4;
$ExtraWeaponSlotB=5;
$ExtraWeaponSlotC=6;
$ExtraWeaponSlotD=7;
//----------------------------------------------------------------------------
function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}
//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Constant
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1.0, 0.63, 0.0 };
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = FALSE;
	shadowDetailMask = 4;
	mapIcon = "M_camera";
	hudIcon = "flaggypoo";
	showWeaponBar = TRUE;

	validateShape = FALSE;

	lightType = 3;   // Constant
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1.0, 0.63, 0.0 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = FALSE;
	shadowDetailMask = 4;
	hudIcon = "flaggypoo";
	showWeaponBar = TRUE;
	validateShape = TRUE;

	lightType = 2;   // Constant
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1.0, 0.63, 0.0 };
};

function Flag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}


function Flag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,true);
} 



//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData SniperArmor
{
   heading = $InvHead[ihArm];
	description = "Tactical Sniper";
	className = "Armor";
	price = 150;
};

ItemData LightArmor
{
   heading = $InvHead[ihArm];
	description = "Battalion Warrior";
	className = "Armor";
	price = 250;
};

ItemData MediumArmor
{
   heading = $InvHead[ihArm];
	description = "Deffencive Engineer";
	className = "Armor";
	price = 350;
};


ItemData HeavyArmor
{
   heading = $InvHead[ihArm];
	description = "Armageddon Mech";
	className = "Armor";
	price = 450;
};

ItemData NewArmor
{
   heading = $InvHead[ihArm];
	description = "Hybrid Destroyer";
	className = "Armor";
	price = 550;
};
//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "BlaZter Scout";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 150;
};

ItemData WarthogVehicle
{
	description = "Fusion Assault Scout";
	classname = "Vehicle";
	heading = "a•¤Vehicles¤•";
	price = 250;
};

ItemData SR71Vehicle
{
	description = "Shredder Scout";
	classname = "Vehicle";
	heading = "a•¤Vehicles¤•";
	price = 350;
};

ItemData EnterpriseVehicle
{
	description = "Napalm Scout";
	className = "Vehicle";
   	heading = "a•¤Vehicles¤•";
	price = 450;
};

ItemData BomberVehicle
{
	description = "Air Strike Scout";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 550;
};

ItemData SpeedBikeVehicle
{
	description = "Plasma Jet-Bike";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 650;
};

ItemData ColossusVehicle
{
	description = "Disc Jet-Bike";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 750;
};

ItemData ArwingVehicle
{
	description = "RPG Jet-Bike";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 850;
};

ItemData LAPCVehicle
{
	description = "Repair Transporter";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 950;
};

ItemData HAPCVehicle
{
	description = "Assault Transporter";
	className = "Vehicle";
   heading = "a•¤Vehicles¤•";
	price = 1050;
};


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	if(%player.Station==""){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else {
				Client::sendMessage(Player::getClient(%player),0,
				strcat(%item.description," has no ammo"));
			}
		}
	}
}

//----------------------------------------------------------------------------
ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}
//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	
//-----------------------=Standard Weapons=--------------------
ItemImageData BlasterImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;
      mountRotation = { 0,-7, 0 };
	mountOffset = { 0, 0, -0.1 };
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = -0.02;
	maxEnergy = -0.02;
	projectileType = BlazterBolt;
	accuFire = true;
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundAmmoStationPower;
};

ItemData Blaster
{
   heading = $InvHead[ihWea];
	description = "BlaZter";
	className = "Weapon";
   shapeFile  = "mortargun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 100;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "BlaZter: <f2>A Modified Blaster.", 3);
}

//-----------------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Ripper Clip";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData Chaingun2Image
{
	shapeFile = "Sniper";  
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Chaingun2
{
	description = "Chaingun2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Chaingun2Image;
	showWeaponBar = false;
};


ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0.05;
	spinUpTime = 0.25;
	spinDownTime = 0;
	fireTime = 0.05;
	ammoType = BulletAmmo;
	//projectileType = RipperChaingunBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;    //60
	lightColor = { 1.0, 0.4, 0.0 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Ripper ChainGun";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "chain";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Ripper ChainGun: <f2>Like The Original ChainGun But With a Few Modifications.", 3);
}

function Chaingun::onMount(%player,%item)
{
	Player::mountItem(%player,Chaingun2,7);
}

function ChaingunImage::onFire(%player, %slot) 
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
   if(%AmmoCount) 
      { 
	   Player::decItemCount(%player,$WeaponAmmo[Chaingun],1); 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   	Projectile::spawnProjectile("RipperChaingunBullet",%trans,%player,%vel);
	   	Projectile::spawnProjectile("RipperChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("RipperChaingunBullet",%trans,%player,%vel);
 	   	Projectile::spawnProjectile("RipperChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("RipperChaingunBullet",%trans,%player,%vel);
                
	} 
   else Client::sendMessage(Player::getClient(%player), 0,"Ripper ChainGun has no ammo."); 
}

function Chaingun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//-------------------------------------------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolts";
   heading = $InvHead[ihAmo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData Plasmagun2Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Plasmagun2
{
	description = "Plasmagun2";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Plasmagun2Image;
	showWeaponBar = false;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	//projectileType = PlasmaCannonBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.63, 0.0 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 150;
	showWeaponBar = true;
};

function PlasmaGun2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Plasma Cannon: <f2>Packs a Bigger Punch Than The Old Plasma Gun.", 3);
}

function PlasmaGun::onMount(%player,%item)
{
	Player::mountItem(%player,plasmagun2,7);
}


function PlasmaGunImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]) >= 1)
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("PlasmaCannonBolt",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)-0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("PlasmaCannonBolt",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)+0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("PlasmaCannonBolt",%transform,%player,%velocity); 
	GameBase::setRotation(%player, %rot);
	Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
	}

if (Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]) > 0 && Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]) < 1) 
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("PlasmaCannonBolt",%transform,%player,%velocity);
	Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
	}

}


function PlasmaGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//-------------------------------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Bio Grenades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{ 
        shapeFile = "grenadeL";
        mountPoint = 0;
        mountrotation = { 0, 3, 0 };
        weaponType = 0;
        ammoType = GrenadeAmmo;
        //projectileType = BioGrenadeShell1&BioGrenadeShell2;
        accuFire = false;
        reloadTime = 0.5;
        fireTime = 0;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.0, 50, 0.0 };
        sfxFire = SoundMortarTurretFire;
        sfxActivate = SoundChainTurretOn;
        sfxReady = SoundGeneratorPower;
};

ItemData GrenadeLauncher
{
	description = "Bio Grenader";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 175;
	showWeaponBar = true;
};

function GrenadeLauncherImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("BioGrenadeShell1",%trans,%player,%vel);
	Projectile::spawnProjectile("BioGrenadeShell2",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
}

function GrenadeLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Bio Grenade: <f2>A Grenade Full Of Toxic Chemicals & Poisons.", 3);
}

//------------------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Split Mortar Shells";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	//projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Split Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 200;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Split Mortar: <f2>Long Range Mortar That Splits Into 3 Shells.", 3);
}

function MortarImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,MortarAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,MortarAmmo);

 		%newObj = Projectile::spawnProjectile("MortarShell", %trans, %this, %vel);
		schedule("TossMFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitMFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitMFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("MortarSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 3; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("MortarFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	//%rnd = (floor(getRandom()*20)/80);
		//schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
//function SetMines(%newobj,%this){
//
//	if (GameBase::getPosition(%newObj)){
//		%Pos = GameBase::getPosition(%newobj); 
//   		%vel = Item::getVelocity(%newobj);
//		%Mine = newObject("","Mine","antipersonelMine");
//		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
// 		addToSet("MissionCleanup", %Mine);
//      	GameBase::throw(%Mine,%this,-1,true);
//		GameBase::setPosition(%Mine, %pos);
//		Item::setVelocity(%Mine, %vel);
//	deleteobject(%newObj);
//	}
//}

//-----------------------------------------------------------------------------------------------------------

ItemData DiscLauncherAmmo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 20;
}; 

ItemImageData DiscLauncher1Image 
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	ammoType = DiscLauncherAmmo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData DiscLauncher1
{	description = "Dual StormHammer";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncher1Image;
	price = 225;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData DiscLauncher2Image
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,1.57, 0 };
	ammoType = DiscLauncherAmmo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData DiscLauncher2
{	description = "Dual StormHammer";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncher2Image;
	price = 225;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData DiscLauncherImage
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = DiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher 
{	description = "Dual StormHammer";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 225;
	showWeaponBar = true;
};


function DiscLauncherImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,6);  
	%state2 = Player::getItemState(%player,7);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "DiscLauncherAmmo", 0.5);   
		%num = Player::getItemCount(%player, "DiscLauncherAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "DiscLauncherAmmo", 0);    
			else     
			Player::setItemCount(%player, "DiscLauncherAmmo", %num);    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "DiscLauncherAmmo", 0);    
			else     
			Player::setItemCount(%player, "DiscLauncherAmmo", %num);    
			Player::trigger(%player,7,true);    
			Player::trigger(%player,7,false);   
		}  
	} 
} 

function DiscLauncher::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "DiscLauncherAmmo");  
	Player::setItemCount(%player, "DiscLauncherAmmo", %num);  
	Player::mountItem(%player,DiscLauncher1,6);  
	Player::mountItem(%player,DiscLauncher2,7); 
} 

function DiscLauncher1::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
        Bottomprint(%client, "Dual StormHammer: <f2>This dual barreled discer packs a hell of a punch.");
}

function DiscLauncher::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,6);  
	Player::unmountItem(%player,7); 
}

//-------------------------------------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 50;
	maxEnergy = 2;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaserX;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Lazer-eX";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 250;
	showWeaponBar = true;
};

function LaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Lazer-eX: <f2>High powered Long Range Sniper Rifle.", 3);
}

//----------------------------------------------------------------------------------------

ItemImageData ChargerImage
{
	shapeFile = "fusionbolt";
   mountPoint = 0;
   mountOffset = { 0, 1.0, 0 }; //-  left-right, back-front, up-down
   mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
   weaponType = 2;  // Sustained
	
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFFire;
};

ItemData Charger
{
   description = "Electron Flux Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = ChargerImage;
	showWeaponBar = true;
   price = 275;
};

function ChargerImage::onActivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,true); 
	Player::trigger(%player,$ExtraWeaponSlotC,true); 
	Player::trigger(%player,$ExtraWeaponSlotD,true); 
}

function ChargerImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,false); 
	Player::trigger(%player,$ExtraWeaponSlotC,false); 
	Player::trigger(%player,$ExtraWeaponSlotD,false); 
}
 
function Charger::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,ExtraCharger,$ExtraWeaponSlotB); 
	Player::mountItem(%player,ExtraCharger2,$ExtraWeaponSlotC); 
	Player::mountItem(%player,ExtraCharger3,$ExtraWeaponSlotD); 
} 

function Charger::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$ExtraWeaponSlotB); 
	Player::unmountItem(%player,$ExtraWeaponSlotC); 
	Player::unmountItem(%player,$ExtraWeaponSlotD); 
} 

ItemImageData ExtraChargerImage
{
	mountOffset = { 0.085, 0, 0.15 };
	mountRotation = { 0, 0.735, 0 };
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = FluxCharge2;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger
{
   description = "Electron Flux Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = ExtraChargerImage;
   price = 275;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger2Image
{
	mountOffset = { -0.085, 0, 0.15 };
	mountRotation = { 0, -0.735, 0 };
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = FluxCharge3;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger2
{
   description = "Electron Flux Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = ExtraCharger2Image;
   price = 275;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger3Image
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = FluxCharge1;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger3
{
   description = "Electron Flux Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = ExtraCharger3Image;
   price = 275;
	showWeaponBar = False;
	showInventory = False;
};


function ExtraCharger3::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Electron Flux Cannon: <f2>An ELF Wiht Multiple Beams, Each With It's Own Function", 3);
}

//----------------------------------=Standard Weapons End=---------------------------------------------------------



//----------------------------------=Energy Based Weapons=---------------------------------------------------------
ItemImageData FusionRifleImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 7, 0 };//1.57
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = -0.02;
	maxEnergy = -0.02;
	projectileType = FuzionRifleBullet;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FusionRifle
{
   heading = $InvHead[ihEne];
	description = "Fuzion Blast Rifle";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FusionRifleImage;
	price = 100;
	showWeaponBar = true;
};

function FusionRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Fuzion Blast Rifle: <f2>Shoots a Fast Contained Bolt Of Electricity That Burst Into Flames On Contact.", 3);
}

//--------------------------------------------------------------------------------------------------------------

ItemImageData ShockRfileImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 0.3;
	minEnergy = 0.06;
	maxEnergy = 0.06;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 5.2 };	

	sfxFire     = Mitzi1;
	sfxActivate = SoundGrogFire;
	sfxSpinUp = SoundSpinUpDisc;
	sfxReady    = SoundmortarIdle;
};

ItemData ShockRfile
{
	description = "Shock Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = ShockRfileImage;
	price = 125;
	showWeaponBar = true;
};

function ShockRfile::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Shock Rifle: <f2>A Sniper Rifle With The Combined Technology Of Laser Fire And Blaster Fire.", 3);
}

function ShockRfileImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 35.0;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("ShockLaser",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("ShockRocket",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}

//---------------------------------------------------------------------------------------------------------------

ItemImageData RadiationRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = RadiationLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 20;
	maxEnergy = 30;
	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 2.0, 2.0, 0.0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RadiationRifle
{
	description = "Radiation Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = RadiationRifleImage;
	price = 150;
	showWeaponBar = true;
};

function RadiationRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Radiation Rifle: <f2>You tend to glow after useing this.", 3);
}

//-----------------------------------------------------------------------------------------------

ItemImageData DiscoRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = DiscoLaser;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 1.0;
	minEnergy = 25;
	maxEnergy = 25;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DiscoRifle
{
	description = "Disco Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = DiscoRifleImage;
	price = 175;
	showWeaponBar = true;
};

function DiscoRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Disco Rifle: <f2>This weapon has 3 Uses,It can be like a Range finder,A Flash Light and a true killer.", 3);
}

//-----------------------------------------------------------------------------------------------------------

ItemImageData GatLaserImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
      mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 7, 0 }; 

	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = GatLaserBeam;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData GatLaser
{
	description = "Lazer Gat";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "reticle";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = GatLaserImage;
	price = 200;
	showWeaponBar = true;
};

function GatLaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Lazer Gat: <f2>Fast and furious.", 3);
}

//--------------------------------------------------------------------------------------------------

ItemImageData GrazerCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.3, 0 };
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 2.0;
	spinDownTime = 0;
	fireTime = 0.001;
	minEnergy  = 10;
	maxEnergy = 15;  // Energy used/sec for sustained weapons
	projectileType = GrazerLaser;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 3, 0 };
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundTeleportPower;
	sfxSpinDown = SoundTeleportPower;
};

ItemData GrazerCannon
{
   description = "Grazer Cannon";
	shapeFile = "mortargun";
	hudIcon = "reticle";
   className = "Weapon";
   heading = $InvHead[ihEne];
   shadowDetailMask = 4;
   imageType = GrazerCannonImage;
	showWeaponBar = true;
   price = 225;
};

function GrazerCannon::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,GrazerCannonT,5); 
	Player::mountItem(%player,GrazerCannonL,6); 
	Player::mountItem(%player,GrazerCannonR,7); 
}

function GrazerCannonT::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Grazer Cannon: <f2>All other lasers dont compair to this wicked beast", 3);
}

function GrazerCannon::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5); 
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7); 
}

ItemImageData GrazerCannonTImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0.2 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GrazerCannonT
{
	description = "Grazer Cannon Top";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrazerCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData GrazerCannonLImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, -2.0934, 0 };
	mountOffset = { -0.1, 0, 0.05};
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GrazerCannonL
{
	description = "Grazer Cannon Left";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrazerCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData GrazerCannonRImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 2.0934, 0 };
	mountOffset = { 0.1, 0, 0.05 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GrazerCannonR
{
	description = "Grazer Cannon Right";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "chain";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrazerCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

//------------------------------------------------------------------------------------------
ItemImageData HybridLaser1Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser1
{
	description = "HybridLaser1";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = HybridLaser1Image;
	showWeaponBar = false;
};

ItemImageData HybridLaser2Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser2
{
	description = "HybridLaser2";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = HybridLaser2Image;
	showWeaponBar = false;
};


ItemImageData HybridLaser3Image
{
	shapeFile = "GrenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser3
{
	description = "HybridLaser3";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = HybridLaser3Image;
	showWeaponBar = false;
};

ItemImageData HybridLaserImage
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.3;
	accuFire = true;
	projectiletype = HybridBeam;
	minEnergy = 70;
	maxEnergy = 10; 
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireLaser;
      sfxreload   = SoundMortarReload;
	sfxActivate = SoundMortarTurretOff;
};

ItemData HybridLaser
{
	description = "Hybrid Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "reticle";
	heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = HybridLaserImage;
	price = 250;
	showWeaponBar = true;
};

function HybridLaser1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Laser: <f2>A New Weapon To the Hybrid Family.The King of Lasers.", 3);
}

function HybridLaser::onMount(%player,%item)
{
	Player::mountItem(%player, HybridLaser1, 4);
	Player::mountItem(%player, HybridLaser2, 5);
	Player::mountItem(%player, HybridLaser3, 6);
}

function HybridLaser::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
}

//----------------------------------------------------------------------------------------------------------

ItemImageData GrapplingImage
{
   shapeFile = "mortargun";
   mountPoint = 0;
   weaponType = 2;  // Sustained
   projectileType = GrapplingBeam;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;	
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Grappling
{
  className = "Weapon";
  description = "Energy Hook";
  heading = $InvHead[ihEne];
  hudIcon = "energypack";
  imageType = GrapplingImage;
  price = 275;
  shadowDetailMask = 4;
  shapeFile = "mortargun";
  showWeaponBar = true;
};

function Grappling::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Energy Hook: <f2>More of a Tool then it is a weapon.", 3);
}

//-------------------------------------------------------------------------------

ItemImageData QuakeBlasterImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; 
      minEnergy = 25;
	maxEnergy = 40;
	projectileType = QuakeBlast;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundGeneratorPower; 
};

ItemData QuakeBlaster
{
	description = "Quake Blaster";
	className = "Weapon";
	shapeFile = "grenadeL";
 	hudIcon = "ammopack";
      heading = $InvHead[ihEne];
 	shadowDetailMask = 4;
	imageType = QuakeBlasterImage;
	price = 300;
	showWeaponBar = true;
};

function QuakeBlaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Quake Blaster: <f2>Make the ground shake and enemies fly!.", 3);
}



//------------------------------------------------------------------------------------------

ItemData HellStormAmmo
{
	description = "Hell Shell";
   heading = $InvHead[ihAmo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData HellStormImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HellStormAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HellStorm
{
	description = "Hell Storm";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = HellStormImage;
	price = 325;
	showWeaponBar = true;
};

function RechargeHellStormAmmo(%player)
{
	//echo("Recharging ammo for HellStorm");
	%armor = Player::GetArmor(%player);
	if(Player::getItemCount(%player,HellStorm) > 0)
	{
		if(Player::getItemCount(%player,HellStormAmmo) < $ItemMax[%armor,HellStormAmmo])
		{
			Player::incItemCount(%player,HellStormAmmo,1);
		}
		else
			$HellStormRecharging[%player] = False;
	}
}

function FireHellStorm(%player)
{
	if($FiringHellStorm[%player] == True)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("HellStormCloud",%trans,%player,%vel);
	}
	
	if($HellStormFired[%player] < 2)
	{
		$HellStormFired[%player]++;
		schedule("FireHellStorm(" @ %player @ ");", 0.2);
	}
}

function HellStormImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("HellStormCloud",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[HellStorm],1);

	$FiringHellStorm[%player] = True;
	$HellStormFired[%player] = 1;

	schedule("FireHellStorm(" @ %player @ ");", 0.2);

	schedule("RechargeHellStormAmmo(" @ %player @ ");", 2.5);
}

function HellStorm::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Hell Storm: <f2>Shoots a Storm of Flamable Gases.", 3);
}

//----------------------------------------------------------------------------

ItemImageData FusionCannonImage
{
	shapeFile = "mortargun";
	projectileType = FusionCannonShell;
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.5;
	minEnergy = 10;
	maxEnergy = 20;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMissileTurretOff;
	sfxReady = SoundlaserIdle;
};

ItemData FusionCannon
{
	description = "Fusion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   heading = $InvHead[ihEne];
	shadowDetailMask = 4;
	imageType = FusionCannonImage;
	price = 350;
	showWeaponBar = true;
};

function FusionCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Fusion Cannon: <f2>Another Weapon That Harnesses The Power Of Raw Fusion.", 3);
}

//----------------------------------------------------------------------------------------------------------

ItemImageData MultiCannonImage
{
	shapeFile = "mortargun";
   mountPoint = 0;

   weaponType = 0;  // Sustained
   reloadTime = 0;
   fireTime = 0;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData MultiCannon
{
   description = "Multi-Cannon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   className = "Weapon";
   heading = $InvHead[ihEne];
   shadowDetailMask = 4;
   imageType = MulticannonImage;
	showWeaponBar = true;
   price = 375;
   validateShape = false;
};
function MultiCannonImage::onFire(%player,%slot)
{
	if($canFireUS[%player] == "") { $canFireUS[%player] = true; }
	
	if($canFireUS[%player])
	{
		%armor = Player::getArmor(%player);
		if(%armor == "narmor") { %cMax = 200; }
		else if(%armor == "harmor" || %armor == "harmor") { %cMax = 175; }	
		else if(%armor == "marmor" || %armor == "mfemale") { %cMax = 150; }
		else if(%armor == "larmor" || %armor == "lfemale") { %cMax = 125; }
		else if(%armor == "sarmor" || %armor == "sarmor") { %cMax = 100; }		
		doFire(%player, 0, %cMax);
		$canFireUS[%player] = false;
	}
}
function doFire(%player,%chargeRate,%cMax)
{	
	if(%chargeRate < %cMax)
	{
		if(Player::getItemCount(%player,MCChargerPack) == 1)
			%chargeRate += 1.5;	 
		else
			%chargeRate += 0.25;
		bottomprint(player::getClient(%player), "<JC><f3> ...:::(<F1>Multi Charge<F3>):::... <f2>"@%chargeRate@"<f1> %", 0.3);
	}
	else if(%chargeRate >= %cMax)
	{
		bottomprint(player::getClient(%player), "<JC><f3> ...:::(<F1>Multi Charge<F3>):::... <f2>"@%cMax@"<f1> % <F3>...:::]<f1>Armor Max<F2>[:::...", 0.5);
		%chargeRate = %cMax;
	}
	
	if(Player::getItemState(%player,$weaponslot) != "Fire")
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		for(%i=0; %i < 5; %i++) 
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			if(%chargeRate < 25)
				Projectile::spawnProjectile("MC00",%trans,%player,%vel);
			else if(%chargeRate < 50)
				Projectile::spawnProjectile("MC01",%trans,%player,%vel);
			else if(%chargeRate < 75)
				Projectile::spawnProjectile("MC02",%trans,%player,%vel);
			else if(%chargeRate < 100)
				Projectile::spawnProjectile("MC03",%trans,%player,%vel);
			else if(%chargeRate < 125)
				Projectile::spawnProjectile("MC04",%trans,%player,%vel);
			else if(%chargeRate < 150)
				Projectile::spawnProjectile("MC05",%trans,%player,%vel);
			else if(%chargeRate < 175)
				Projectile::spawnProjectile("MC06",%trans,%player,%vel);
			else
				Projectile::spawnProjectile("MCMega",%trans,%player,%vel);
		}
		$canFireUS[%player] = true;	
	}
	else
		schedule("doFire("@%player@","@%chargeRate@","@%cMax@");",0.04);
}

function MultiCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Multi-Cannon: <f2>This Weapon Pulls Atoms From The Air And Charges Them To There Max And Fires Them In A Hail Storm Of Fury.", 3);
}

//-------------------------=End of Energy Based Weapons=------------------------

ItemData GlockAmmo
{
	description = "Glock Clips";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 10;
};


ItemImageData Glock3Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Glock3
{
	description = "Glock3";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Glock3Image;
	showWeaponBar = false;
};

ItemImageData Glock2Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, -0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Glock2
{
	description = "Glock2";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = Glock2Image;
	showWeaponBar = false;
};

ItemImageData GlockImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single shot
	reloadTime = 0.1;
	fireTime = 0.2;
	ammoType = GlockAmmo;
	projectileType = GlockBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Glock
{
	description = "Glock-9";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "sniper";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = GlockImage;
	price = 100;
	showWeaponBar = true;
};


function Glock::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "Glock-9: <f2>Shoots a High Cal. Armor Piercing Bullet.", 3);
}

function Glock::onMount(%player,%item)
{
	Player::mountItem(%player,Glock2,7);
	Player::mountItem(%player,Glock3,6);
}

function Glock::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

//----------------------------------------------------------------------------
ItemData WTShotgunAmmo
{
	description = "WT BuckShot Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData WTShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // SingleShot
	reloadTime = 0.3;
	fireTime = 0.2;
	ammoType = WTShotgunAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData WTShotgun
{
	description = "WT.12G";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disc";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = WTShotgunImage;
	price = 125;
	showWeaponBar = true;
};

function WTShotgunImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 15; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("WT12GPellet",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[WTShotgun],1);
}

function WTShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "WT.12G: <f2>WT = (White Trash) A Powerful and Fast Double Barreled Killer.", 3);
}

//-------------------------------------------------------------------------------------------------------------

ItemData ParticalShotgunAmmo
{
	description = "Particle Shells";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ParticalShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ParticalShotgunAmmo;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.5;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData ParticalShotgun
{
	description = "Partical Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "blaster";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = ParticalShotgunImage;
	price = 150;
	showWeaponBar = true;
};

function ParticalShotgunImage::onFire(%player,%slot)
{

	for(%i = 0; %i < 4; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ParticalPellet1",%trans,%player,%vel);
		Projectile::spawnProjectile("ParticalPellet2",%trans,%player,%vel);
		Projectile::spawnProjectile("ParticalPellet3",%trans,%player,%vel);
	}

	Player::decItemCount(%player,$WeaponAmmo[ParticalShotgun],1);
}

function ParticalShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Partical Shotgun: <f2>Powerfull Bullets That Can Rip Through Any Armor In a Hurry", 3);
}

//-----------------------------------------------------------------------------------------------------------------

ItemData SXHAmmo
{
	description = "SXH5000-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SightShooterImage
{
   shapeFile  = "breath";
	mountPoint = 0;
	mountOffset = { 0, -0.2, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 2; // Sustained
	projectileType = SXH5000Laser;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	reloadTime = 0;
	fireTime = 0.2;
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 0.25, 1.25 };
	
};

ItemData SightShooter
{
   heading = "bEnergy Weapons";
	description = "targetLaser";
	className = "Tool";
   shapeFile  = "breath";
	hudIcon = "energyRifle";
	shadowDetailMask = 4;
	imageType = SightShooterImage;
	price = 0;
	showWeaponBar = false; 
	showInventory = false;
};

ItemImageData Scope1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Scope1
{
	description = "Scope1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Scope1Image;
	showWeaponBar = false;
};


ItemImageData SXHImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0.55;
	fireTime = 0.02;
	ammoType = SXHAmmo;
	projectileType = SXHBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SXH
{
	description = "SXH-5000w/Scope";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "sniper";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = SXHImage;
	price = 175;
	showWeaponBar = true;
};

function SightShooter::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "SXH-5000: <f2>Semi-Automatic Sniper Rilfe, Great For Taking Out Hovering Heavies", 3);
}
function SXH::onMount(%player,%item)
{
	Player::mountItem(%player,Sightshooter,5);
	Player::trigger(%player,5,true);
    	Player::mountItem(%player,Scope1,6);
}

function SXH::onUnMount(%player,%item)
{
	Player::unmountItem(%player,5);
	Player::trigger(%player,5,false);
	Player::unmountItem(%player,6);
}



//----------------------------------------------------------------------------------------------------------------

ItemData HavocAmmo
{
	description = "HaVoC-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SScopeImage
{
	shapeFile = "bullet";
	mountPoint = 0; 
	mountOffset = { 0, 1.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.10 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SScope
{
	description = "Scope";
	className = "Weapon";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	imageType = SScopeImage;
	showWeaponBar = false;
};

ItemImageData Havoc2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { -0.02, -0.04, -0.02 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.57, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Havoc2
{
	description = "Havoc2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = Havoc2Image;
	showWeaponBar = false;
};

ItemImageData HavocImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.1, -0.08 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;
	ammoType = HavocAmmo;
	projectileType = HaVoCBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Havoc
{
	description = "HaVoC Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = HavocImage;
	price = 200;
	showWeaponBar = true;
};


function Havoc2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "HaVoC Sniper: <f2>The Most Advanced Sniper rifle Ever To Exist.", 3);
}

function Havoc::onMount(%player,%item)
{
	Player::mountItem(%player,Havoc2,4);
	Player::mountItem(%player,SScope,5);
}

function Havoc::onUnMount(%player,%item)
{
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
}

//------------------------------------------------------------------------------------------------

ItemData HybridRailAmmo
{
	description = "Hybrid Rail Spikes";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData HybridRailImage
{
	shapeFile = "sniper"; 
	mountPoint = 0;
        minEnergy = 30;
	maxEnergy = 60;
	weaponType = 0; 
	ammoType = HybridRailAmmo;
//	projectileType = ThisShouldBeUndefined;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 2.0;
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0.0, 0, 0}; 
	lightType = 3;  
	lightRadius = 8;
	lightTime = 2;
	lightColor = {0.05, 0.25, 0.45}; 
	sfxFire = SoundFireHybridRailGun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundHybridRailReload;
};

ItemData HybridRail
{
	description = "Hybrid RailGun";
	className = "Weapon";
	shapeFile = "sniper"; 
	hudIcon = "targetlaser";
  heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = HybridRailImage;
	price = 225;
	showWeaponBar = true;
};

function HybridRail::onUse(%player,%item,%slot,%timeSlice,%enDrainPerSec)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "Hybrid RailGun: <f2>Great modified RailGun", 3);
}

function HybridRailImage::onFire(%player,%slot)
 {
   %enVal  = 25.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[HybridRail]);
   if (%energy > 20.0) 
{
		 playSound(SoundFireHybridRailGun,GameBase::getPosition(%player));//+++++
		 Player::decItemCount(%player,$WeaponAmmo[HybridRail],1);
		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("HybridRailSpike",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 0,"Not enough energy to fire Hybrid Rail");
	}
 }

//-------------------------------------------------------------------------------------------------------

$MinigunSlot=4; 

ItemData MinigunAmmo 
{ 
	description = "Mini-Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,-3.11, 0 };
	mountOffset = { 0.225, 0, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = MinigunAmmo;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

function MinigunImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[Minigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$FiringMinigun[%client]) CheckMinigun(%client, %player); 
} 

ItemData Minigun 
{ 
	description = "Minigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = $InvHead[ihBul];
	shadowDetailMask = 4; 
	imageType = MinigunImage; 
	price = 250; 
	showWeaponBar = true; 
}; 

function Minigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, Minigun2, 0); 
		Item::onDrop(%player,%item); 
	} 
} 

function Minigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,Minigun2,$MinigunSlot); 
} 

function Minigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MinigunSlot); 
} 

ItemImageData Minigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,3.11, 0 };
	mountOffset = { 0, 0, 0 };
 	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = MinigunAmmo;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Minigun2 
{ 
	description = "Minigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = $InvHead[ihWea]; 
	shadowDetailMask = 4; 
	imageType = Minigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

$MinigunSlot=4; 

function CheckMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Minigun")) 
	{ 
		Player::trigger(%player,$MinigunSlot,true); 
		schedule("CheckMinigun(" @ %client @ "," @ %player @ ");",0.05); 
		$FiringMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MinigunSlot,false); 
		$FiringMinigun[%client] = false; 
	} 
} 

function Minigun2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Minigun: <f2>Double ChainGun");
}

//-------------------------------------------------------------------------------------------------------------

ItemData ShardGunAmmo
{
	description = "Shard Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ShardGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = ShardGunAmmo;
	projectileType = Shard;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData ShardGun
{
	description = "Shard ChainGun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = ShardGunImage;
	price = 275;
	showWeaponBar = true;
};

function ShardGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Shard ChainGun: <f2>A Very Fast and Furious Killer.", 3);
}

//-------------------------------------------------------------------------------------------

ItemData DFMIYAAmmo
{
	description = "DFMIYA-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData DFMIYAImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0.1;
	//spinUpTime = 0;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = DFMIYAAmmo;
	projectileType = DFMIYABullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData DFMIYA
{
	description = "D.F.M.I.Y.A";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "ammopack";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = DFMIYAImage;
	price = 300;
	showWeaponBar = true;
};

function DFMIYA::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "D.F.M.I.Y.A: <f2>This ChainGun Is The King Of Kings,Top 'o' The Line Destruction", 3);
}

//----------------------------------------------------------------------------------------------------------------

ItemData DestroyerAmmo
{
	description = "Destroyer Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData DestroyerImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = DestroyerAmmo;
	projectileType = DestroyerBullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = bigExplosion4;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};


ItemData Destroyer
{
	description = "Destroyer Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = DestroyerImage;
	price = 325;
	showWeaponBar = true;
};

function Destroyer::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Destroyer Chaingun: <f2>This Weapon Has a Fast Fire Rate and Is Able To Eat Through Anything In Its Way", 3);
}


//----------------------------------------------------------------------------

ItemData ARPGAmmo
{
	description = "ARPG-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ARPGImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0.5;
	accuFire = false;
	fireTime = 0.25;
	ammoType = ARPGAmmo;
	//projectileType = ARPGShell;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireAssaultChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData ARPG
{
	description = "ARPG";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = ARPGImage;
	price = 350;
	showWeaponBar = true;
};

function ARPG::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "ARPG <F2>Used to clear deep enemy lines.", 3);Weapon::onUse(%player,%item);
}


function ARPGImage::onFire(%player, %slot) 
{	
	Player::decItemCount(%player,$WeaponAmmo[ARPG],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
        for(%i=0; %i < 5; %i += 1) {
	Projectile::spawnProjectile("ARPGShell",%trans,%player,%vel);
}


	}
//---------------------------------------------------------------------------------------------------------------------------------------


ItemData HybridChainAmmo 
{	description = "Hybrid-Chain Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 12;
};

ItemImageData HybridChainImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = HybridChainAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData HybridChain 
{	description = "Hybrid Chain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihBul];
	shadowDetailMask = 4;
	imageType = HybridChainImage;
	price = 375;
	showWeaponBar = true;
};


ItemImageData HybridChain2Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 3, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = HybridChainAmmo;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain2 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData HybridChain3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = HybridChainAmmo;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain3 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData HybridChain4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, 3, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = HybridChainAmmo;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain4 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$HybridChainSlotA=4;
$HybridChainSlotB=7;
$HybridChainSlotC=6;

function HybridChain::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	Player::mountItem(%player,HybridChain2,$HybridChainSlotA);
	Player::mountItem(%player,HybridChain3,$HybridChainSlotB);
	Player::mountItem(%player,HybridChain4,$HybridChainSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Chaingun: <f2>Made Only For The Hybrid, For Obvious Reasons");
}

function HybridChain::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$HybridChainSlotA);
	Player::unmountItem(%player,$HybridChainSlotB);	 
	Player::unmountItem(%player,$HybridChainSlotC);
}

function CheckHybridChain(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridChain")) 
	{	Player::trigger(%player,$HybridChainSlot,true);
		schedule("CheckHybridChain(" @ %client @ "," @ %player @ ");",0.05);
		$FiringHybridChain[%client] = true;
	}
	else
	{	Player::trigger(%player,$HybridChainSlot,false);
		$FiringHybridChain[%client] = false;
	}
}

function HybridChainImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[HybridChain],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("HybridChainBullet",%trans,%player,%vel,%player);
	if(!$FiringHybridChain[%client]) 
		CheckHybridChain(%client, %player);
}

function HybridChain::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridChain2, 0);
		Item::onDrop(%player,%item);
	}
}

function CheckHybridChain(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridChain")) 
	{	Player::trigger(%player,$HybridChainSlotA,true);
		Player::trigger(%player,$HybridChainSlotB,true);
		Player::trigger(%player,$HybridChainSlotC,true);
		schedule("CheckHybridChain(" @ %client @ "," @ %player @ ");",0.1);
		$FiringHybridChain[%client] = true;
	}
	else 
	{	Player::trigger(%player,$HybridChainSlotA,false);
		Player::trigger(%player,$HybridChainSlotB,false);
		Player::trigger(%player,$HybridChainSlotC,false);
		$FiringHybridChain[%client] = false;
	}
}

//-------------------------=End Cartridge Based Weapons=---------------------------

//-------------------------=Start Plasma Based Weapons=----------------------------

ItemImageData PlasmaBlasterImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;
      mountRotation = { 0, -1.80, 0 };//3.60
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.5;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = PlasmaBlasterBolt;
	accuFire = true;
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundFirePlasma;
};

ItemData PlasmaBlaster
{
   heading = $InvHead[ihPls];
	description = "Plasma Blaster";
	className = "Weapon";
   shapeFile  = "mortargun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PlasmaBlasterImage;
	price = 100;
	showWeaponBar = true;
};

function PlasmaBlaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Plasma Blaster: <f2>Plasma Has Evolved!", 3);
}

//------------------------------------------------------------------------------

ItemData BlazeAmmo
{
	description = "Blaze Thrower Gas";
   heading = $InvHead[ihAmo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData BlazeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
mountRotation = { 0, -3.08, 0 };//3.60
	weaponType = 0;
	ammoType = BlazeAmmo;
	accuFire = false;
	reloadTime = 0.0001;
	fireTime = 0.0001;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaze
{
	description = "Blaze Thrower";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = BlazeImage;
	price = 125;
	showWeaponBar = true;
};

function BlazeImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("BlazeBullet1",%trans,%player,%vel);
	Projectile::spawnProjectile("BlazeBullet2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Blaze],1);
}

function Blaze::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Blaze Thrower: <f2>Basic Flame Thrower.", 3);
}

//----------------------------------------------------------------------------------------------

ItemData PlasmaGatAmmo
{
	description = "Plasma Gat Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData PlasmaGatImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 3;
	fireTime = 0.1;
	ammoType = PlasmaGatAmmo;
	projectileType = PlasmaGatBullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundFireGluon;
	sfxSpinDown = SoundFireGluon;
};

ItemData PlasmaGat
{
	description = "Plasma Gat";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = PlasmaGatImage;
	price = 150;
	showWeaponBar = true;
};

function PlasmaGat::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Plasma Gat: <f2>Rapid Fire Heated Balls Of Hot Plasma.", 3);
}

//--------------------------------------------------------------------------------------------

ItemImageData MeltLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };//3.60
	weaponType = 0; // Single Shot
	projectileType = MeltBeam;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 50;
	maxEnergy = 2;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundFirePlasma;
};

ItemImageData Melt2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.08, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Melt2
{
	description = "Melt2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Melt2Image;
	showWeaponBar = false;
};

ItemData MeltLaser
{
	description = "Melt Laser";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = MeltLaserImage;
	price = 175;
	showWeaponBar = true;
};

function Melt2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Melt Laser: <f2>Plasma Has Many Forms, It Has Been In All Fields Except Laser Form Until Now.", 3);
}

function MeltLaser::onMount(%player,%item)
{
	Player::mountItem(%player,Melt2,7);
}

function MeltLaser::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//-----------------------------------------------------------------------------------------------------------------

ItemData SAStealthAmmo
{
	description = "Saturnine-Ammo";
   heading = $InvHead[ihAmo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SAStealthImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.1, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = SAStealthAmmo;
	//projectileType = SAStealthBullet;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 1.4;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SAStealth
{
	description = "Saturnine Stealth";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = SAStealthImage;
	price = 200;
	showWeaponBar = true;
};

function Glock2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Saturnine Stealth: <f2>A Semi-auto Sniper Rifle, Once Fired it will shoot 6 bullets at one time.", 3);
}


function SAStealthImage::onFire(%this,%slot)
{
  %client = Player::getClient(%this);
  schedule("SAStealthFire("@%this@","@8@");",0.01,%this);
  if(!Player::isDead(%this)) Player::decItemCount(%client,SAStealthAmmo,1);
}

function SAStealthFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(SAStealthBullet,%trans,%this,%vel);
  %repeat--;
  schedule("SAStealthFire("@%this@","@%repeat@");",0.12,%this);
}


function SAStealth::onMount(%player,%item)
{
	Player::mountItem(%player,Glock2,7);
}

function SAStealth::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//----------------------------------------------------------------------------------------------------------------

ItemData NapalmLauncherAmmo
{
	description = "Napalm [L] Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
}; 

ItemImageData NapalmLauncherImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = NapalmLauncherAmmo;
	//projectileType = ;
	accuFire = false;
	mountRotation = { 0, 1.57, 0 };
	//mountOffset = {-0.065, 0, 0.07}; 
	reloadTime = 0.75;
	fireTime = 2.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = bigExplosion3; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData NapalmLauncher 
{
	description = "Napalm Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
	heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = NapalmLauncherImage;
	price = 225;
	showWeaponBar = true;
};

function NapalmLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Naplam Launcher: <f2>Sends a Grenade Filled With Plasma At Your Foe.", 3);
}

function NapalmLauncherImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,NapalmLauncherAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,NapalmLauncherAmmo);

 		%newObj = Projectile::spawnProjectile("NapShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("NapSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("NapFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	//%rnd = (floor(getRandom()*20)/80);
		//schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}


//-------------------------------------------------------------------------------------------------------------

ItemData NapalmRocketAmmo
{
	description = "Napalm [R] Ammo";
   heading = $InvHead[ihAmo];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData NapalmRocketImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = NapalmRocketAmmo;
	projectileType = NapalmRocketShell;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData NapalmRocket
{
	description = "Napalm Rocket";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = $InvHead[ihPls];
	shadowDetailMask = 4;
	imageType = NapalmRocketImage;
	price = 250;
	showWeaponBar = true;
};

function NapalmRocket::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Napalm Rocket: <f2>A Very High Powered Rocket.", 3);
}

//---------------------------------------------------------------------------------------------

//////////////////
$MagmaSlotA=4;
$MagmaSlotB=7;
$MagmaSlotC=6; 

ItemData MagmaAmmo 
{	description = "Magma Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4; 
	price = 12; 
}; 

ItemImageData MagmaImage 
{	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0, 0 }; 
	mountRotation = { 0, -7, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = MagmaAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData Magma 
{	description = "Magma Cannon"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "Plasma"; 
	heading = $InvHead[ihPls];
	shadowDetailMask = 4; 
	imageType = MagmaImage; 
	price = 275; 
	showWeaponBar = true; 
};


ItemImageData Magma3Image 
{	ammoType = MagmaAmmo; 
	projectileType = MagmaRocket; 
	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 7, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData Magma3 
{	description = "Magma"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "Plasma"; 
	shadowDetailMask = 4; 
	imageType = Magma3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 

function Magma::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{ 
	Player::mountItem(%player,Magma3,$MagmaSlotB); 
	%client = Player::getclient(%player);
	bottomprint(%client, "Magma Cannon: <f2>Launches Dual White Hot Plasma WarHeads.", 3);
}

function Magma::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$MagmaSlotA);
	Player::unmountItem(%player,$MagmaSlotB);	 
	Player::unmountItem(%player,$MagmaSlotC);
}

function MagmaImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,MagmaAmmo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MagmaRocket",%trans,%player,%vel,%player); 
	if(!$FiringMagma[%client]) 
		CheckMagma(%client, %player); 
}

function Magma::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, Magma2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckMagma(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Magma")) 
	{	Player::trigger(%player,$MagmaSlotA,true);
		Player::trigger(%player,$MagmaSlotB,true);
		Player::trigger(%player,$MagmaSlotC,true); 
		schedule("CheckMagma(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringMagma[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$MagmaSlotA,false); 
		Player::trigger(%player,$MagmaSlotB,false); 
		Player::trigger(%player,$MagmaSlotC,false); 
		$FiringMagma[%client] = false; 
	} 
}


//------------------------------------=End Plasma Based weapons=------------------------

//------------------------------------=Start Explosive Weapons=-------------------------

ItemData ShockWaveCAmmo 
{ 
	description = "ShockWave Shell"; 
	className = "Ammo"; 
	heading = $InvHead[ihAmo];
	shapeFile = "mortarammo"; 
	shadowDetailMask = 4; 
	price = 50; 
}; 

ItemImageData ShockWaveCImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	weaponType = 0; 
	ammoType = ShockWaveCAmmo; 
	projectileType = ShockWaveShell; 
	accuFire = false; 
	reloadTime = 0.5; 
	fireTime = 2.0; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.25, 0.25, 1.0 }; 
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload; 
	sfxReady = SoundLaserIdle; 
}; 

ItemData ShockWaveC
{ 
	description = "ShockWave Mortar"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihExp];
	shadowDetailMask = 4; 
	imageType = ShockWaveCImage; 
	price = 100; 
	showWeaponBar = true; 
}; 

function ShockWaveC::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "ShockWave Mortar:<f2> Shoots a shell with a negivite charge.", 3);
}

//------------------------------------------------------------------------

ItemData NitroAmmo
{
	description = "Nitro Grenades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData NitroImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = NitroAmmo;
	projectileType = NitroShell;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Nitro
{
	description = "Nitro Grenader";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "grenade";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = NitroImage;
	price = 125;
	showWeaponBar = true;
};

function Nitro::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Nitro Grenader: <f2>Lobbs Grenades filled with Nitro at your enemy.", 3);
}

//--------------------------------------------------------------------------------------------------------

ItemData FireMortarAmmo
{
	description = "Fire Mortar Shells";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FireMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FireMortarAmmo;
	projectileType = FireMortarShell;
	accuFire = false;
	reloadTime = 0.25;
	fireTime = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = bigExplosion3;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData FireMortar
{
	description = "Fire Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = FireMortarImage;
	price = 150;
	showWeaponBar = true;
};

function FireMortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "<JC>Fire Mortar: <f2>!*!*!*!WARNING!*!*!*!\n<JC>Very Large Heat Wave Radius.", 3);
}

//------------------------------------------------------------------------------------------------------

ItemData ContactMortarAmmo
{
	description = "Contact Shells";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ContactMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ContactMortarAmmo;
	projectileType = ContactMortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ContactMortar
{
	description = "Contact Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = ContactMortarImage;
	price = 175;
	showWeaponBar = true;
};

function ContactMortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Contact Mortar: <f2>Explodes on Contact.", 3);
}

//--------------------------------------------------------------------------------

ItemData AirRaidAmmo
{
	description = "Air Raid Shells";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AirRaidImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = AirRaidAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AirRaid
{
	description = "Air Raid";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = AirRaidImage;
	price = 200;
	showWeaponBar = true;
};

function AirRaidImage::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
        Projectile::spawnProjectile("AirRaid1",%trans,%player,%vel-15);
        Projectile::spawnProjectile("AirRaid1",%trans,%player,%vel);
	Projectile::spawnProjectile("AirRaid1",%trans,%player,%vel+15);
	Projectile::spawnProjectile("AirRaid2",%trans,%player,%vel-15);
	Projectile::spawnProjectile("AirRaid2",%trans,%player,%vel);
	Projectile::spawnProjectile("AirRaid2",%trans,%player,%vel+15);
	Projectile::spawnProjectile("AirRaid3",%trans,%player,%vel-15);
	Projectile::spawnProjectile("AirRaid3",%trans,%player,%vel);
	Projectile::spawnProjectile("AirRaid3",%trans,%player,%vel+15);
	Player::decItemCount(%player,$WeaponAmmo[AirRaid],1);
}

function AirRaid::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Air Raid: <f2>This Weapon Fires 3 Rows of 3 High powered Mortars with a Blast Radius Of 100m This Makes You a One Man Bomber.", 3);
}

//---------------------------------------------------------------------------------------------------------------

ItemData TimeBombAmmo
{
	description = "Time Bombs";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TimeBombImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = TimeBombAmmo;
	//projectileType = TimeBombShell;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData TimeBomb
{
	description = "Time Bomb Lobber";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "mortar";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = TimeBombImage;
	price = 225;
	showWeaponBar = true;
};

function TimeBomb::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Time Bomb Lobber: <f2>Drops Mortars that explode after 10 seconds after the time of the drop.", 3);
}

function TimeBombImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("TimeBombShell1",%trans,%player,%vel);
	Projectile::spawnProjectile("TimeBombShell2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[TimeBomb],1);
}
//--------------------------------------------------------------------------------------------



ItemData AtomicBombAmmo
{
	description = "Atomic Bomb Shell";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData AtomicCoreImage
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.22 };
	mountRotation = { 0,  1.57, 1.57}; 
};

ItemData AtomicCore
{
	description = "Atomic Core";
	className = "Weapon";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	imageType = AtomicCoreImage;
	showWeaponBar = false;
	showInventory = false;
};


ItemImageData AtomicBombImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
        mountOffset = { 0, 0, -0.2};
	weaponType = 0; // Single Shot
	accuFire = true;
	ammoType = AtomicBombAmmo;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = bigExplosion1;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
	sfxReload = SoundMortarReload;
	
};

ItemData AtomicBomb
{
	description = "Atomic Bomb";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = AtomicBombImage;
	price = 250;
	showWeaponBar = true;
};

function AtomicCore::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Atomic Bomb: <f2>Harness The Power Of The Atom and Use It To Obliterate Your Enemies.", 3);
}

function AtomicBomb::onMount(%player,%item)
{
	Player::mountItem(%player, AtomicCore, 7);
}

function AtomicBomb::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 7);
}

function AtomicBombImage::onFire(%player, %slot) 
{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AtomicBomb]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[AtomicBomb],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

			Projectile::spawnProjectile("ClusterBomb",%trans,%player,%vel);
}
	else
		Client::sendMessage(Player::getClient(%player), 2,"Oops. screwed ya!");

}


//------------------------------------------------------------------------------------------------------------

ItemData ClashRocketAmmo
{
	description = "Clash Missiles";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ClashRocketImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0; // Single Shot
	ammoType = ClashRocketAmmo;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.63, 0.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData ClashRocket
{
	description = "Clash Missile Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = ClashRocketImage;
	price = 275;
	showWeaponBar = true;
};

function ClashRocketImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ClashRocket1",%trans,%player,%vel);
	Projectile::spawnProjectile("ClashRocket2",%trans,%player,%vel);
        
	Player::decItemCount(%player,$WeaponAmmo[ClashRocket],1);
}

function ClashRocket::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Clash Missile Launcher: <f2>A Missile Launcher for Light Armors Only.", 3);
}

//----------------------------------------------------------------------------

ItemImageData ETTR2Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0, -0.45, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ETTR2
{
	description = "ETTR2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = ETTR2Image;
	showWeaponBar = false;
};


ItemData ETTRAmmo
{	description = "ETTR Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData ETTRImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.03, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0};  
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	ammoType = ETTRAmmo;
	accuFire = true;
	sfxFire	= floatMineExplosion;
	sfxActivate = SoundTeleportPower;
	sfxReload = SoundMortarReload;
	sfxReady = SoundTeleportPower;
};

ItemData ETTR
{	heading = $InvHead[ihExp];
	description = "ETTR Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "sniper";
	shadowDetailMask = 4;
	imageType = ETTRImage;
	price = 300;
	showWeaponBar = true;
};

function ETTR::onMount(%player,%item)
{
	Player::mountItem(%player,ETTR2,7);
}

function ETTR::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function ETTR2::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "ETTR: <f2>Or Electric Terror Tracking Rocket Fires a Rocket With a Electric Pulse Seeking System.");
}

function ETTRImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ETTR]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   		%gay = Client::getName(%cl);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($DiskerUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl = Player::GetClient(%target);	 
				%jam = CheckTargetJamming(%target);
				if(%jam == 1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
					Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,1,%tpos);
					
					if(%target)
					{	
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>" @ %name, 10);
					}
				}
				else
				{	
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,0,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
						Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,12,%tpos);
						%playername = Client::getName(%player);
						if(%target)
						{	
							Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						      Client::sendMessage(%client,0,"~wmine_act.wav");
						      Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
					Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);	
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier") 
				{	
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
					%name = Client::getName(%targetId);	
                              		centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);
				}
				else if(%object == "Turret" || %object =="Sensor")
				{	
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
					
                              		centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);
				}
				else
  				{
				
				Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			}

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[ETTR],0);
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** ETTR Out of Ammo!! ** ~waccess_denied.wav");
}

//----------------------------------------------------------------------------

ItemData SludgeAmmo
{
	description = "Sludge Canister";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SludgeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = SludgeAmmo;
	projectileType = SludgeShell;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.0;
	spinUpTime = 0.25;
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Sludge
{
	description = "Sludge Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disk";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = SludgeImage;
	price = 325;
	showWeaponBar = true;
};

function Sludge::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Sludge Launcher: <f2>This Weapon Like The Bio Grenade Launcher is Based off of Toxic Waste & Posions.", 3);
}

//------------------------------------------------------------------------------------------

ItemData SalvoAmmo
{
	description = "Salvo Ammo";
	className = "Ammo";
   heading = $InvHead[ihAmo];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SalvoImage 
{ 
       shapeFile = "grenadeL"; 
       mountPoint = 0;   
       mountRotation = { 0, 0.785, 0 }; 
       weaponType = 0; 
       ammoType = SalvoAmmo; 
       //projectileType = ThisShouldBeUndefined; 
       accuFire = true; 
       reloadTime = 1.5; 
       fireTime = 0.8; 
       lightType = 3; 
       lightRadius = 3; 
       lightTime = 1; 
       lightColor = { 1, 1, 1 }; 
       //sfxFire = SoundSalvoLaunch; 
       sfxActivate = SoundMortarTurretTurn; 
       sfxReload = SoundMortarTurretOn;
       sfxReady = SoundMineActivate; 
};

ItemData Salvo
{
	description = "Triple Salvo";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "ammopack";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = SalvoImage;
	price = 350;
	showWeaponBar = true;
};

function SalvoImage::onFire(%player, %slot) 
{ 
	GameBase::playSound(%player, SoundSalvoLaunch, 0);
	schedule("Salvo::fireRockets(" @ %player @ ",3);",0.05,%player);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.05);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.10);
}

function Salvo::fireRockets(%player,%count)
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Salvo]);
   if(%AmmoCount) 
	{
   	   %client = GameBase::getControlClient(%player);
   	   if(Player::getItemCount(%player,SalvoAmmo)) 
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("SalvoRocket",%trans,%player,%vel);  
		%count--;
		}
	   if(%count && Player::getItemCount(%player,SalvoAmmo))
	   schedule("Salvo::fireRockets(" @ %player @ "," @ %count @ ");",0.2,%player);
	   Player::decItemCount(%player,$WeaponAmmo[Salvo],1);
	} 
   else Client::sendMessage(Player::getClient(%player), 0,"***Out of Salvo Rockets***.~wAccess_Denied.wav");
}

function Salvo::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Triple Salvo: <f2>Launches 3 Fire WarHead Missiles At One Time.", 3);
}

//------------------------------------------------------------------------------------------------

ItemImageData AnarchyCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountRotation = { 0, 0.99, 0 };//1.57
      mountOffset = {-0.065, 0, 0.07};
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 1.5;
	minEnergy = 3.0;
	maxEnergy = 5.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };	
	sfxFire     = Soundwindgust;
	sfxActivate = SoundJetHeavy;
	sfxSpinUp = SoundSpinUpDisc;
	sfxReload    = SoundMortarReload;
};

ItemData AnarchyCannon
{
	description = "Anarchy Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = AnarchyCannonImage;
	price = 375;
	showWeaponBar = true;
};

function AnarchyCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Anarchy Cannon: <f2>Devloped When Hybrid Mod Was Ruled By The .:(Anarchy):. Clan in Early 1998, This Weapon delivers Lazer Guided Chaos With a Splash Of Taste.", 3);
}
function AnarchyCannonImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("AnarchyLaser",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("AnarchyRocket1",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("AnarchyRocket2",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}

//-------------------------------------------------------------------------------------------------

ItemData CMineAmmo 
{
	description = "CMine"; 
	shapeFile = "mineammo";  
	shadowDetailMask = 4; 
	price = 10; 
	className = "HandAmmo"; 
}; 

function CMineAmmo::onUse(%player,%item)
{
        if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","antipersonelMine2");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
            GameBase::setTeam (%obj,GameBase::getTeam (%client));//
                }
        }
}

ItemData ClaymoreAmmo 
{ 
	description = "Claymore Ammo"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4; 
	price = 7; 
};

ItemImageData Claymore1Image
{
	shapeFile = "MortarAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Claymore1
{
	description = "Claymore1";
	className = "Weapon";
	shapeFile = "MortarAmmo";
	shadowDetailMask = 4;
	imageType = Claymore1Image;
	showWeaponBar = false;
};

ItemImageData Claymore2Image
{
	shapeFile = "MortarAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Claymore2
{
	description = "Claymore2";
	className = "Weapon";
	shapeFile = "MortarAmmo";
	shadowDetailMask = 4;
	imageType = Claymore2Image;
	showWeaponBar = false;
};


ItemImageData ClaymoreImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 1.0;
      AmmoType = ClaymoreAmmo;
	//projectileType = ;
	minEnergy = 10;
	maxEnergy = 20;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1.75, 0.25, 3.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Claymore
{
	description = "Claymore Evolved";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   	heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = ClaymoreImage;
	price = 400;
	showWeaponBar = true;
};

function Claymore::onMount(%player,%item)
{
	Player::mountItem(%player,Claymore1,6);
	Player::mountItem(%player,Claymore2,7);
}

function Claymore::onUnMount(%player,%item)
{
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function ClaymoreImage::onFire(%this) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,ClaymoreAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,ClaymoreAmmo);

 		%newObj = Projectile::spawnProjectile("MinerShell", %trans, %this, %vel);
		schedule("TossMines(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitMines(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("ClaymoreSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("MineFloaters", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	%rnd = (floor(getRandom()*20)/80);
		schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
function SetMines(%newobj,%this){

	if (GameBase::getPosition(%newObj)){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%Mine = newObject("","Mine","AntipersonelMine2");
		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
 		addToSet("MissionCleanup", %Mine);
      	GameBase::throw(%Mine,%this,-1,true);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);
	deleteobject(%newObj);
	}
}

function Claymore1::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Claymore Evolved: <f2>Launches a single shell that lays Anti-Personel mines over a 50m radius.", 3);
}
//-------------------------------------------------------------------------------------------------------------

ItemData HybridMortarammo
{
	description = "Hybrid Mortar Shells";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData HybridMortar1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -0.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };
	 ammoType = HybridMortarammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = HybridShell; 
}; 

ItemData HybridMortar1 
{ 
	description = "HybridMortar";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = HybridMortar1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HybridMortar2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -1.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };

	 ammoType = HybridMortarammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = HybridShell; 
}; 

ItemData HybridMortar2 
{ 
	description = "HybridMortar";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = HybridMortar2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HybridMortarImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = HybridMortarammo; 
	reloadTime = 0.0;
	fireTime = 0.3;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData HybridMortar
{ 
	description = "Hybrid Dual Mortar"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "mortar"; 
     heading = $InvHead[ihExp];
	shadowDetailMask = 4; 
	imageType = HybridMortarImage; 
	price = 1000; 
	showWeaponBar = true;
}; 

function HybridMortarImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "HybridMortarammo", 0.5);   
		%num = Player::getItemCount(%player, "HybridMortarammo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "HybridMortarammo", 0);    
			else     
			Player::setItemCount(%player, "HybridMortarammo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "HybridMortarammo", 0);    
			else     
			Player::setItemCount(%player, "HybridMortarammo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function HybridMortar::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "HybridMortarammo");  
	Player::setItemCount(%player, "HybridMortarammo", %num);  
	Player::mountItem(%player,HybridMortar1,4);  
	Player::mountItem(%player,HybridMortar2,5); 
} 

function HybridMortar::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}

function HybridMortar2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Hybrid Dual Mortar: <F2>Wicked Dual Mortar Action." ,3);
}

//-------------------------------------------------------------------------------

ItemData HybridCannonAmmo
{	description = "Hybrid Cannon Shell";
	className = "Ammo";
	heading = $InvHead[ihAmo];
	shapeFile = "mrtwig";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData HybridCannonImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = HybridCannonAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket; //SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundBeaconActive;
};

ItemData HybridCannon 
{	description = "Hybrid Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
  	heading = $InvHead[ihExp];
	shadowDetailMask = 4;
	imageType = HybridCannonImage; 
	price = 1250;
	showWeaponBar = true;
};

function HybridCannon::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Cannon: <f2>A very Deadly Hybrid Weapon,Only a Hybrid could Handle This Much Power." ,3);
}
function HybridCannonImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[HybridCannon]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{	//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Player::decItemCount(%player,$WeaponAmmo[HybridCannon],1);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
                Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
	}
	else
	{	Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Hybrid Cannon");
	}
}

//-----------------------------------------------------------------------------------

$HybridRocketLauncherSlotA=4;
$HybridRocketLauncherSlotB=7;
$HybridRocketLauncherSlotC=6; 

ItemData HybridRocketLauncherAmmo
{	description = "Hybrid Dual Missiles";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData HybridRocketLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = HybridRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData HybridRocketLauncher 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihExp];
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncherImage; 
	price = 1500; 
	showWeaponBar = true; 
}; 

ItemImageData HybridRocketLauncher2Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = HybridRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};	

ItemData HybridRocketLauncher2 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData HybridRocketLauncher3Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = HybridRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData HybridRocketLauncher3 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData HybridRocketLauncher4Image 
{	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = HybridRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData HybridRocketLauncher4 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

//  Begin HybridRocketLauncher New Fire Function By: Armagedon
                     
function HybridRocketLauncherImage::onFire(%player, %slot) 
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[HybridRocketLauncher]);
	if(%AmmoCount)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		// ------- Second Projectile Placement --------
		
		%pos=gamebase::getposition(%player);
		%rot=gamebase::getrotation(%player);
		%vec=Vector::getFromRot(%rot);
		
		%vec1=getWord(%vec,0);
		%vec2=getWord(%vec,1);
		
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=getWord(%trans,3);
		%pos5=getWord(%trans,4);
		%pos6=getWord(%trans,5);
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9) + %vec2;
		%pos11=getWord(%trans,10) - %vec1;
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
		// ----- End of Second Projectile Placement -----
		
		if(GameBase::getLOSInfo(%player,1500))
		{	
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("HybridMissile",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("HybridMissile",%trans2,%player,%vel,$los::object);
				Client::sendMessage(%client,3,"Missile lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"!*!*!WARNING!*!*! Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
				if(!$FiringHybridRocketLauncher[%client]) 
					CheckHybridRocketLauncher(%client, %player);
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[HybridRocketLauncher],2);
			}
			else
			{
				Projectile::spawnProjectile("HybridRocket",%trans,%player,%vel,%target);
				Projectile::spawnProjectile("HybridRocket",%trans2,%player,%vel,%target);
				if(!$FiringHybridRocketLauncher[%client]) 
					CheckHybridRocketLauncher(%client, %player); 
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[HybridRocketLauncher],2);
			}
		}
		else
		{
			Projectile::spawnProjectile("HybridRocket",%trans,%player,%vel,%target);
			Projectile::spawnProjectile("HybridRocket",%trans2,%player,%vel,%target);
			if(!$FiringHybridRocketLauncher[%client]) 
				CheckHybridRocketLauncher(%client, %player); 
			//GiveKickBack(%player, 125, 1);
			Player::decItemCount(%player,$WeaponAmmo[HybridRocketLauncher],2);
		}
	}
	else
		Client::sendMessage(%client,0,"Hybrid Dual Missile Launcher is out of ammo.~waccess_denied.wav");
}

function HybridRocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function HybridRocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,HybridRocketLauncher2,$HybridRocketLauncherSlotA); 
	Player::mountItem(%player,HybridRocketLauncher3,$HybridRocketLauncherSlotB); 
	Player::mountItem(%player,HybridRocketLauncher4,$HybridRocketLauncherSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Dual Launcher: <f2>This Dual Launcher Also Has a Heat Sink Device For Added Destruction." ,3);  
}

function HybridRocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$HybridRocketLauncherSlotA);
	Player::unmountItem(%player,$HybridRocketLauncherSlotB);	 
	Player::unmountItem(%player,$HybridRocketLauncherSlotC);
}

function CheckHybridRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridRocketLauncher")) 
	{	Player::trigger(%player,$HybridRocketLauncherSlotA,true);
		Player::trigger(%player,$HybridRocketLauncherSlotB,true);
		Player::trigger(%player,$HybridRocketLauncherSlotC,true);
		schedule("CheckHybridRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringHybridRocketLauncher[%client] = true;
	} 
	else 
	{	Player::trigger(%player,$HybridRocketLauncherSlotA,false); 
		Player::trigger(%player,$HybridRocketLauncherSlotB,false); 
		Player::trigger(%player,$HybridRocketLauncherSlotC,false); 
		$FiringHybridRocketLauncher[%client] = false; 
	} 
}

//------------------------------------------------


$HybridQuadSlotA=4;
$HybridQuadSlotB=7;
$HybridQuadSlotC=6; 

ItemData HybridQuadAmmo 
{	description = "Hybrid Quad RPGs"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = $InvHead[ihAmo];
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData HybridQuadLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = HybridQuadAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData HybridQuadLauncher 
{	description = "Hybrid Quad RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, 1.1, 0}; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihExp];
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncherImage; 
	price = 1750; 
	showWeaponBar = true; 
};

ItemImageData HybridQuadLauncher2Image 
{	ammoType = HybridQuadAmmo; 
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher2 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData HybridQuadLauncher3Image 
{	ammoType = HybridQuadAmmo; 
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher3 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData HybridQuadLauncher4Image 
{	ammoType = HybridQuadAmmo; 
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher4 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$HybridQuadSlotA=4;
$HybridQuadSlotB=7;
$HybridQuadSlotC=6;

function HybridQuadLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,HybridQuadLauncher2,$HybridQuadSlotA); 
	Player::mountItem(%player,HybridQuadLauncher3,$HybridQuadSlotB); 
	Player::mountItem(%player,HybridQuadLauncher4,$HybridQuadSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Quad RPG: <f2>Launches 4 RPG Missiles At One Time, Mass Destruction With Some Flare.");
}

function HybridQuadLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$HybridQuadSlotA);
	Player::unmountItem(%player,$HybridQuadSlotB);	 
	Player::unmountItem(%player,$HybridQuadSlotC);
}

function HybridQuadLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,HybridQuadammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("HybridRPG",%trans,%player,%vel,%player); 
	if(!$FiringHybridQuadLauncher[%client]) 
		CheckHybridQuadLauncher(%client, %player); 
}

function HybridQuadLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridQuadLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckHybridQuadLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridQuadLauncher")) 
	{	Player::trigger(%player,$HybridQuadSlotA,true);
		Player::trigger(%player,$HybridQuadSlotB,true);
		Player::trigger(%player,$HybridQuadSlotC,true); 
		schedule("CheckHybridQuadLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringHybridQuadLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$HybridQuadSlotA,false); 
		Player::trigger(%player,$HybridQuadSlotB,false); 
		Player::trigger(%player,$HybridQuadSlotC,false); 
		$FiringHybridQuadLauncher[%client] = false; 
	} 
}

//-------------------=End Explosive Based Weapons=----------------------------



//-------------------=End Weapons Data Blocks=--------------------------------



//----------------------------------------------------------------------------
//             ----------=Start Backpacks=---------
//----------------------------------------------------------------------------
ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}
//===============================================================================

ItemImageData EnergyPackImage
{
	shapeFile = "jetpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
        mountRotation = { 0, -3.10, 0};
	minEnergy = -6;
 	maxEnergy = -10;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Enerjhizer Pack";
	shapeFile = "jetpack";
	className = "Backpack";
   heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}
//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------
ItemImageData ShieldPackImage
{
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shield";
	className = "Backpack";
   heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),3,":Shield Pack • On:");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),3,":Shield Pack • Off:");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
//----------------------------------------------------------------------------

ItemImageData StealthShieldPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 6;
  maxEnergy = 9;
  sfxFire = SoundShieldOn;
  firstPerson = false;
};

ItemData StealthShieldPack 
{
  description = "Stealth Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihTbp];
  shadowDetailMask = 4;
  imageType = StealthShieldPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};
function StealthShieldPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),3,":Stealth Pack • On:");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
  GameBase::startFadeout(%player); 

}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),3,":Stealth Pack • Off:");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
  GameBase::startFadein(%player);

}

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = $InvHead[ihTbp];
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 7 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}
//---------------------------------------------------------

ItemImageData XTremePackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	minEnergy = -15; // This is where it negates the armors jet drain. By in creasing its recharge rate.
 	maxEnergy = -20; // This is where it negates the armors jet drain. By in creasing its recharge rate.
	firstPerson = false;
};

ItemData XTremePack
{
	description = "Jet Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = XTremePackImage;
	price = 550;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function XTremePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function XTremePack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function XTremePack::onUnmount(%player,%item)
{
	Player::unmountItem(%player,$WeaponSlot);
}
//----------------------------------------------------------------------------
ItemImageData AntiGravPackImage
{
	shapeFile = "sensor_small";
	mountRotation = { 11, 0, 0 };
	mountOffset = { 0, -0.10, 0.05 };
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData AntiGravPack 
{
	description = "Mech Stealth/Grav Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = AntiGravPackImage;
	price = 400;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AntiGravPack::onMount(%player,%item) 
{
}

function AntiGravPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),3,":Mech Anti-Gravity/Stealth Pack • On:");
        %player.shieldStrength = 0.012;
	%clientId = Player::getClient(%player);
        %rate = Player::getSensorSupression(%player) + 20;
        Player::setSensorSupression(%player,%rate);
        GameBase::startFadeout(%player); 
	$antigrav[%clientId] = 1;
	Arms_AntiGrav(%clientId, %player);
}

function AntiGravPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),3,":Mech Anti-Gravity/Stealth Pack • Off:");
	Player::trigger(%player,$BackpackSlot,false);
        %player.shieldStrength = 0;
	%clientId = Player::getClient(%player);
        %rate = Player::getSensorSupression(%player) - 20;
        Player::setSensorSupression(%player,%rate);
        GameBase::startFadein(%player);
	$antigrav[%clientId] = 0;
}


//---------------------------------------------------

ItemImageData MCChargerPackImage 
{	
	shapeFile = "mortargun";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	minEnergy = -10;
	maxEnergy = -5;
	firstPerson = false;
};

ItemData MCChargerPack 
{	
	description = "Multi Charger";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = $InvHead[ihTbp];
	shadowDetailMask = 4;
	imageType = MCChargerPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MCChargerPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function MCChargerPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function MCChargerPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == MultiCannon) 
		Player::unmountItem(%player,$WeaponSlot);
}


//############################
// Weight pack
//############################
ItemData Weight
{				
	description = "";
	className = "Tool";
	showInventory = false;
};

function Weight::onDrop(%player, %item){}
function Weight::onUse(%player, %item){}

ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 90000.0;
};

ItemData DeadWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DeadWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = 90000.0;
	showInventory = false;
};
//############################
//----------------------------------------------------------------------------
// P-Inv Code By: Armagedon (cus hes koo)
//============================================================================
ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = $InvHead[ihEqu];
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 10000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	 		         addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}
//+++++++++++Force Fields & Dep Bases++++++++++++++++
//----------------------------------------------------------------------------

function deployAirBase::Initialize()
{	
	$TeamItemCount[0 @ AirBasePack] = 0;
	$TeamItemCount[1 @ AirBasePack] = 0;
	$TeamItemCount[2 @ AirBasePack] = 0;
	$TeamItemCount[3 @ AirBasePack] = 0;
	$TeamItemCount[4 @ AirBasePack] = 0;
	$TeamItemCount[5 @ AirBasePack] = 0;
	$TeamItemCount[6 @ AirBasePack] = 0;
	$TeamItemCount[7 @ AirBasePack] = 0;
}

ItemImageData AirBasePackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData AirBasePack
{	
	description = "Sky Base";
	shapeFile = "Discammo";
	className = "Backpack";
	heading = $InvHead[ihEqu];
	imageType = AirBasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 10000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData AirBaseForceFieldLarge
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Sky Base";
};

StaticShapeData AirBaseForceFieldSmall
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Mod By: Armagedon";
};

function AirBasePack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AirBasePack::onDeploy(%player,%item,%pos)
{	if(AirBasePack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateAirBaseSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/AirBase" @ %team);
	if(%teleset == -1)
	{
		newObject("AirBase" @ %team,SimSet);
		addToSet("MissionCleanup","AirBase" @ %team);
	}
}

function AirBasePack::deployshape(%player,%item)
{
	%name = "Air Base";
	%team = GameBase::getTeam(%player);

	%client = Player::getClient(%player);

	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy A Sky Base is Already In-Use");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%flag = $teamFlag[%team];
	%flagpos = gamebase::getPosition(%flag);

	if(Vector::getDistance(%flagpos, %playerpos) < 50)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	CreateAirBaseSimSet(%team);
	
//	echo(%playerpos);
	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 300;
	%playerpos = %posX@" "@%posY@" "@%posZ;
	//%playerpos = "0 0 0";

	// Tower Floor
	%object = newObject("Air Base","InteriorShape", "BEMfloatingPad.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5 -5 0");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
//	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Tower Roof
	%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	addToSet(MissionCleanup, %object);
	%pos = Vector::add(%playerpos, "0 0 38");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 3.14159 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "5.8746 0 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small1","StaticShape",AirBaseForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5.75 2.05 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "0 5.8746 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small","StaticShape",AirBaseForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "2.03 -5.75 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	%object = newObject("Vehicle Station","StaticShape",VehicleStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-3.60177 3.95522 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Vehicle Station");
	
	%object = newObject("Vehicle Pad","StaticShape",VehiclePad,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-10.6862 -11.1697 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 -0 2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Vehicle Pad");
	
	%object = newObject("Inventory Station","StaticShape",InventoryStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "3.69689 -3.64708 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Inventory Station");
	
	%object = newObject("Command Station","StaticShape",CommandStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "4.25588 4.13451 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Command Station");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-7.49755 1.43987 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -1.5707963";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Solar Panel");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "1.58014 -7.45512 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Solar Panel 2");

	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed a Sky Base");
	Client::sendMessage(%client,0,%item.description @ " Built 300 meters up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
}
//----------------------------------------------------------------------------
ItemImageData RemoteBaseImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData RemoteBase 
	{ 
	description = "Remote Base"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = $InvHead[ihEqu];
	imageType = RemoteBaseImage; 
	shadowDetailMask = 4; 
	mass = 0.5; 
	elasticity = 0.2; 
	price = 8000; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RemoteBase::onUse(%player,%item) 
	{
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 25 || Vector::getDistance(%deplpos, %teamposb) < 25 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function RemoteBase::onDeploy(%player,%item,%pos) 
	{ 
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	if (RemoteBase::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RemoteBase"]++;
	} 
	} 

function RemoteBase::deployShape(%player,%item) 
	{ 
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	%client = Player::getClient(%player);
	%playpos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,20)) 
	{ 
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain" || %obj == "Large Platform") 
	{ 
	if(Vector::GetDistance(%playpos,$los::position) > 9 ) 
	{
	%base = newObject("Remotebase",InteriorShape,"bunker4.dis",false);
	%base.basebackwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseleftwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baserightwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseturret = newObject("Remotebase","Turret",PlasmaTurret,false);
	%base.basesolar = newObject("Remotebase","StaticShape",SolarPanel,false);
	%base.basestation = newObject("Remotebase","StaticShape",InventoryStation,false);
	%base.basedoor = newObject("Remotebase","Staticshape",DoorForceFieldShape,true);
	%base.basedoor.objParent = %base;
	%base.basebackwall.objParent = %base;
	%base.baseleftwall.objParent = %base;
	%base.baserightwall.objParent = %base;
	%base.baseturret.objParent = %base;
	%base.basesolar.objParent = %base;
	%base.basestation.objParent = %base;
	addToSet("MissionCleanup", %base);
	addToSet("MissionCleanup", %base.basebackwall);
	addToSet("MissionCleanup", %base.baseleftwall);
	addToSet("MissionCleanup", %base.baserightwall);
	addToSet("MissionCleanup", %base.baseturret);
	addToSet("MissionCleanup", %base.basesolar);
	addToSet("MissionCleanup", %base.basedoor);
	addToSet("MissionCleanup", %base.basestation);
	GameBase::setTeam(%base,GameBase::getTeam(%player));
	GameBase::setPosition(%base,$los::position);
	GameBase::setRotation(%base,"0 0 0");
	%pos = Vector::add($los::position, "0 5.875 0");
	GameBase::setRotation(%base.basebackwall,"0 0 0");
	GameBase::setPosition(%base.basebackwall,%pos);
	GameBase::setTeam(%base.basebackwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -5.875 0");
	GameBase::setRotation(%base.basedoor,"0 0 0");
	GameBase::setPosition(%base.basedoor,%pos);
	GameBase::setTeam(%base.basedoor,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "-5.875 0 0");
	GameBase::setRotation(%base.baseleftwall,"0 0 4.7125");
	GameBase::setPosition(%base.baseleftwall,%pos);
	GameBase::setTeam(%base.baseleftwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "5.875 0 0");
	GameBase::setRotation(%base.baserightwall,"0 0 4.7125");
	GameBase::setPosition(%base.baserightwall,%pos);
	GameBase::setTeam(%base.baserightwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 0.2 9.77");
	GameBase::setRotation(%base.baseturret,"0 0 0");
	GameBase::setPosition(%base.baseturret,%pos);
	GameBase::setTeam(%base.baseturret,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -0.2 9.50");
	GameBase::setRotation(%base.basesolar,"0 0 0");
	GameBase::setPosition(%base.basesolar,%pos);
	GameBase::setTeam(%base.basesolar,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 3 1");
	GameBase::setRotation(%base.basestation,"0 0 0");
	GameBase::setPosition(%base.basestation,%pos);
	GameBase::setTeam(%base.basestation,GameBase::getTeam(%player));
	$TeamItemCount[GameBase::getTeam(%sensor) @ "RemoteBase"]++;
	Gamebase::setMapName(%base,"Remote Base " @ Client::getName(%client));
	Client::setOwnedObject(%client, %base);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Remote base deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Remote Base"); 
	return true; 
	}
	else 
	Client::sendMessage(%client,0,"You are too close to the deploy position."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only be deployed on terrain."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

///-----------------------------------------------
ItemImageData BlastDoorpackImage
{
        //shapeFile = "newdoor5";
        shapeFile = "ammo2";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.25, 0, 0 };
        mountRotation = { 1.57, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastDoorpack
{
        description = "Blast Door";
        //shapeFile = "newdoor5";
        shapeFile = "ammo2";//AmmoPack
        className = "Backpack";
        heading = $InvHead[ihEqu];
        imageType = BlastDoorpackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastDoorpack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function BlastDoorpack::onDeploy(%player,%item,%pos)
{
        if (BlastDoorpack::deployShape(%player,%item) && !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastDoorpack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastDoorpack","StaticShape",BlastDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumBlastDoor++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Blast Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorpack"]++;
						    $BigBlue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast Door");
                                        return true;

                        }
                       else   {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Too far away.");

                        }

         }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
StaticShapeData BlastDoorShape
{
className = "newdoor5";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "[Blast Door]";
};

function BlastDoorShape::Destruct(%this)
      {BlastDoorShape::doDamage(%this);}

function BlastDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BlastDoorShape::onDestroyed(%this)
{	BlastDoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastDoor"]--;
}

function BlastDoorShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
	return;
}
		%c = Player::getClient(%obj);
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		if(%fieldTeam != %playerTeam)
		{return;}
			BlastDoorShape::openDoor(%this);return;
}

function BlastDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",SoundPlasmaTurretTurn,0);",0.10);
schedule("BlastDoorShape::closeDoor("@%this@");",0.8);
}

function BlastDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",SoundPlasmaTurretOff,0);",0.10);

}
///-----------------------------------------------
ItemImageData platImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData plat
{
        description = "Blast Floor";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
         heading = $InvHead[ihEqu];
        imageType = platImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function plat::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function plat::onDeploy(%player,%item,%pos)
{
        if (plat::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function plat::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %prot = GameBase::getRotation(%player);
					  %xRot = getWord(%prot,0);
					  %yRot = getWord(%prot,1);
					  %zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						%rot = GameBase::getRotation(%player);//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
					}
					else {
						%rot = GameBase::getRotation(%player);//other
					}
				}

                                        %camera = newObject("plat","StaticShape",platShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Floor#"@ $totalNumPlat++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Blast Floor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "plat"]++;$Plat++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast Floor");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData platShape
{
        shapeFile = "elevator16X16_octo";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = defaultDebrisLarge;
        maxDamage = 25.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Blast Floor";
};

function platShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "plat"]--;

}
//----------------------------------------------------------------------------


ItemImageData plat2Image
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData plat2
{
        description = "Blast Hatch";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
         heading = $InvHead[ihEqu];
        imageType = plat2Image;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function plat2::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function plat2::onDeploy(%player,%item,%pos)
{
        if (plat2::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function plat2::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %prot = GameBase::getRotation(%player);
					  %xRot = getWord(%prot,0);
					  %yRot = getWord(%prot,1);
					  %zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						%rot = GameBase::getRotation(%player);//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
					}
					else {
						%rot = GameBase::getRotation(%player);//other
					}
				}

                                        %camera = newObject("plat2","StaticShape",plat2Shape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Hatch#"@ $totalNumPlat2++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Blast Hatch deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "plat2"]++;$Plat2++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast Hatch");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}



//----------------------------------------------------------------------------

ItemImageData lgbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData lgbForceFieldPack
{
        description = "4x14 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihEqu];
        imageType = lgbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function lgbForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function lgbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (lgbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function lgbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("lgbForceFieldPack","StaticShape",lgbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "lgbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medaForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medaForceFieldPack
{
        description = "4x8 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihEqu];
        imageType = medaForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medaForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function medaForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medaForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medaForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medaForceFieldPack","StaticShape",medaForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medaForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medbForceFieldPack
{
        description = "5x5 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihEqu];
        imageType = medbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medbForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function medbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medbForceFieldPack","StaticShape",medbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medcForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medcForceFieldPack
{
        description = "3x4 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihEqu];
        imageType = medcForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medcForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function medcForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medcForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medcForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {
                

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medcForceFieldPack","StaticShape",medcForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medcForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
//+++++++++++++Turrets++++++++++++++++++
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Fusion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


//////////////////////////////////////////////////////////////////////
//function already exists above
//////////////////////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////
function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Fusion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Fusion Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Fusion Turret");
								//	Remote turrets - kill points to player that deploy them
								//Client::setOwnedObject(%client, %turret); 
								//Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
//--------------------------------------
ItemImageData LaserTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function LaserTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					
					
					
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Laser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretPack"]++;
					echo("MSG: ",%client," deployed a Laser Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
               }
	}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//----------------------------------------------------------------------------
																			
ItemImageData MaliceTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MaliceTurretPack
{
	description = "Chain Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MaliceTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MaliceTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MaliceTurretPack::onDeploy(%player,%item,%pos)
{
	if (MaliceTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MaliceTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",MaliceTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Chain Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Chain Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MaliceTurretPack"]++;
					echo("MSG: ",%client," deployed a Chain Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//-----------------------------
ItemImageData LaserTurretBPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretBPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretBPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretBPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretBPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretBPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function LaserTurretBPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",LaserTurretB,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Plasma Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Plasma Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretBPack"]++;
					echo("MSG: ",%client," deployed a Plasma Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//=====================================
ItemImageData ARPGTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ARPGTurretPack
{
	description = "ARPG Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = ARPGTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ARPGTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ARPGTurretPack::onDeploy(%player,%item,%pos)
{
	if (ARPGTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function ARPGTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",ARPGTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"ARPG Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ARPG Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "ARPGTurretPack"]++;
					echo("MSG: ",%client," deployed a ARPG Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

ItemImageData MiniFlakTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniFlakTurretPack
{
	description = "Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniFlakTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniFlakTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniFlakTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniFlakTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

//////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
///////////////////////////////////////////

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniFlakTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					
					
					
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",MiniFlakTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Flak Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Flak Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniFlakTurretPack"]++;
					echo("MSG: ",%client," deployed a Flak Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
               }
	}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//----------------------------------------------------------------------------

ItemImageData MiniSAMTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniSAMTurretPack
{
	description = "Missile Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniSAMTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniSAMTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniSAMTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniSAMTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

//////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
///////////////////////////////////////////

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniSAMTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					
					
					
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",MiniSAMTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Missile Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Missile Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniSAMTurretPack"]++;
					echo("MSG: ",%client," deployed a Missile Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
               }
	}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//----------------------------------------------------------------------------
//-------------|Electric Web By: Biohazard|----- Thanks!
ItemImageData ElectricWebImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };//1.57
	firstPerson = false;
};

ItemData ElectricWeb
{
	description = "Electric Web";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = $InvHead[ihTur];
	imageType = ElectricWebImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectricWeb::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ElectricWeb::onDeploy(%player,%item,%pos)
{
	if (ElectricWeb::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ElectricWeb::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                %playerPos = GameBase::getPosition(%player);
                %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
                %rot = Vector::add(GameBase::getRotation(%player), "0 1.57 1.57");
                %inv = newObject("Electric Web","Turret","PlasmaDoorTurr",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Electric Web" @  Client::getName(%client));
                Client::setOwnedObject(%client, %inv); 
                Client::setOwnedObject(%client, %player);
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "ElectricWeb"]++;
                Client::sendMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
      
        }

}
//----------------------------------------------------------------------------
ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = $InvHead[ihEqu];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//--------------------------------------------------------
ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = $InvHead[ihEqu];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}
//----------------------------------------------------------------------------
ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = $InvHead[ihEqu];
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}
//----------------------------------------------------------------------------
ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Spy Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = $InvHead[ihEqu];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//----------------------------------------------------------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}
//----------------------------------------------------------------------------
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if (MineAmmo::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MineAmmo::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Cloak/Health Node");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Cloak/Health Node deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}
//----------------------------------------------------------------------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   //validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	Item::setvelocity(%player,0);
      client::sendmessage(player::getclient(%player),0,"Air Break Applied.~wLand_On_Ground.wav");
	Player::decItemCount(%player,%item);
}
//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "force";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item) 
{
	if($matchStarted && %player.throwTime < getSimTime()) 
	{
		GameBase::playSound(%player, SoundThrowItem,0);
		%armor = Player::getArmor(%player);
		eval(%armor @ "::onBeacon(" @ %player @ ");");
                Player::decItemCount(%player,%item);
	}
}

//----------------------------------------------------------------------------
function Item::deployShape(%player,%name,%shape,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%sensor = newObject("","Sensor",%shape,true); 
	addToSet("MissionCleanup", %sensor); 
	GameBase::setTeam(%sensor,GameBase::getTeam(%player)); 
	GameBase::setPosition(%sensor,$los::position); 
	Gamebase::setMapName(%sensor,%name); 
	Client::sendMessage(%client,0,%item.description @ " deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a ",%name); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can cnot be deployed on players!"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); 
	return false; 
	} 
//----------------------------------------------------------------------------
function checkDeployArea(%client,%pos) {return 1;} 

function CountObjects(%set,%name,%num) 
	{ 
	%count = 0; 
	for(%i=0;%i<%num;%i++) 
	{ 
	%obj=Group::getObject(%set,%i); 
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
	%count++; 
	} 
	return %count; 
	}
//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}
//----------------------------------------------------------------------------
function checkMax(%clientId,%armor)
{
	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%clientId,"Weapon");

	if (%numweapon > $MaxWeapons[%armor])
	{
		%weaponflag = %numweapon - $MaxWeapons[%armor];
	}

	%max = getNumItems();
	for (%i = 1; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];

		if(%maxnum != "" && %item.className != Armor)
		{
			%numsell = 0;
			%count = Player::getItemCount(%clientId,%item);
			if(%count > %maxnum)
			{
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
						Client::sendMessage(%clientId,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%clientId),(%item.price * %numsell));
				Player::setItemCount(%clientId, %item, %count - %numsell);
				updateBuyingList(%clientId);
			}
		}
	}
}

//============================================================================
function checkPlayerCash(%clientId)
{
	%team = Client::getTeam(%clientId);	
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%clientId.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
			if(%clientId.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %clientId.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

//============================================================================
function recountitem(%itemname)
{
	echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}
//==============================================================
function Mission::reinitData()
{
	recountitem("MiniSmokeTurretPack");
	recountitem("MiniSAMTurretPack");
	recountitem("MiniFlakTurretPack");
	recountitem("ARPGTurretPack");
	recountitem("MaliceTurretPack");
	recountitem("LaserTurretPack");
	recountitem("LaserTurretBPack");
	recountitem("DeployableAmmoPack");
	recountitem("DeployableInvPack");
	recountitem("TurretPack");
	recountitem("CameraPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("PulseSensorPack");
	recountitem("MotionSensorPack");
	recountitem("ScoutVehicle");
	recountitem("LAPCVehicle");
	recountitem("HAPCVehicle");
	recountitem("Beacon");
	recountitem("mineammo");
	recountitem("BlastDoorPack");
	recountitem("plat");
	recountitem("plat2");
	recountitem("RemoteBase");
	recountitem("medaForceFieldPack");
	recountitem("medbForceFieldPack");
	recountitem("medcForceFieldPack");
	recountitem("lgbForceFieldPack");
	recountitem("ElectricWeb");
	recountitem("BomberVehicle");
	recountitem("SR71Vehicle");
	recountitem("EnterpriseVehicle");
	recountitem("WarthogVehicle");
	recountitem("SpeedBikeVehicle");
	recountitem("ColossusVehicle");
	recountitem("ArwingVehicle");


	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
