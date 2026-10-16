//========================================= Plasmatic Mortar ==================================
ItemData plasmatAmmo
{
	description = "Plasmatic Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 7;
}; 

ItemImageData PlasmatImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmatAmmo;
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

ItemData Plasmat 
{
	description = "Plasmatic Fragger";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmatImage;
	price = 420;
	showWeaponBar = true;
};

function PlasmatImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,PlasmatAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,plasmatAmmo);

 		%newObj = Projectile::spawnProjectile("PlasmatShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PlasmatSplit", %trans, %this, %vel);
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
 		%obj = Projectile::spawnProjectile("PlasmatFire", %trans, %this, %vel);
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
//=========================================^|^|^NUKE^|^|^======================================
ItemData NukexAmmo
{
	description = "Nuke Bomb";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "shockwave_large";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData Nuke1xImage
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.22 };
	mountRotation = { 0,  1.57, 1.57}; 
};

ItemData Nuke1x
{
	description = "Nuke Can";
	className = "Weapon";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	imageType = Nuke1xImage;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData NukexImage
{
	shapeFile = "mortargun";
  	mountPoint = 0;
	mountOffset = { 0, 0, -0.2};
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; // Single Shot
	ammoType = NukexAmmo;
      projectiletype = BabyNukeBomb;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 7.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = bigExplosion1;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};

ItemData Nukex
{
	description = "Nuker Blast";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "Mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = NukexImage;
	price = 420;
	showWeaponBar = true;
};

function Nukex::onMount(%player,%item)
{
	Player::mountItem(%player, Nuke1x, 7);
}

function Nukex::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 7);
}
//=============================================================================================
ItemImageData Flame1Image
{
	shapeFile = "plasmatrail";
	mountPoint = 0; 
	mountOffset = { 0, 0.7, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Flame1
{
	description = "Flame1";
	className = "Weapon";
	shapeFile = "plasmatrail";
	shadowDetailMask = 4;
	imageType = Flame1Image;
	showWeaponBar = false;
};

ItemImageData Flame2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.7, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Flame2
{
	description = "Flame2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Flame2Image;
	showWeaponBar = false;
};


ItemImageData FlameImage
{
	shapeFile = "Grenadel";
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.1;
	accuFire = true;
	projectiletype = Plasmabolt4;
	minEnergy = 20;
	maxEnergy = 10; 
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire     = SoundDryFire;
      sfxreload   = SoundMortarReload;
	sfxActivate = SoundMortarTurretOff;
};

ItemData Flame
{
	description = "Flame Thrower";
	className = "Weapon";
	shapeFile = "Grenadel";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlameImage;
	price = 420;
	showWeaponBar = true;
};

function Flame::onMount(%player,%item)
{
	Player::mountItem(%player, Flame1, 5);
	Player::mountItem(%player, Flame2, 6);
}

function Flame::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
}

//=============================================================================================
ItemImageData ParticleBeamWeaponImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 1;
	//projectileType = targetLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	fireTime = 0.001;
	spinUpTime = 0.001;
	spinDownTime = 0.001;
	reloadTime = 2.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	//sfxFire = SoundFireTargetingLaser;
	//sfxActivate = SoundPickUpWeapon;
};

ItemData ParticleBeamWeapon
{
	description = "IX Beam Cannon";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	heading = "bWeapons";
	imageType = ParticleBeamWeaponImage;
	showWeaponBar = true;
	showInventory = true;
	price = 420;
};

ItemImageData ParticleBeamWeaponImage2
{
	shapeFile = "grenadel";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60; //plasmatic
	maxEnergy = -6; //plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , 0 , 0 };
	mountOffset = { -0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
};

ItemData ParticleBeamWeapon2
{
	description = "IX Beam Cannon";
	className = "Weapon";
	shapeFile = "Grenadel";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage2;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage3
{
	shapeFile = "grenadel";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60;	//plasmatic
	maxEnergy = -6;	//plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , 0 , 0 };
	mountOffset = { 0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
};

ItemData ParticleBeamWeapon3
{
	description = "IX Beam Cannon";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage3;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage4
{
	shapeFile = "mortarpack";
	mountPoint = 0;
	mountRotation = { -1.57, 0 , 3.14 };
	mountOffset = { 0 , 0.1 , -0.1 };
	weaponType = 0;
	minEnergy = 70;
	maxEnergy = 120;
	//projectileType = ParticleBeam;
	accuFire = true;
	fireTime = 0.25;
	reloadTime = 0.38;
	sfxFire = SoundPlasmaturretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundFlyerDismount;
};

ItemData ParticleBeamWeapon4
{
	description = "IX Beam Cannon";
	shapeFile = "mortarpack";
	hudIcon = "reticle";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage4;
	showWeaponBar = false;
	showInventory = false;
};

function ParticleBeamWeapon::onMount(%player, %item) 
{
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	Player::mountItem(%player,ParticleBeamWeapon2,4);
	Player::mountItem(%player,ParticleBeamWeapon3,6);
	Player::mountItem(%player,ParticleBeamWeapon4,7);
	%client = Player::getclient(%player);
      Bottomprint(%client, "<jc><f3>]|[<f1> IX Beam Cannon <f3>]|[\n<f3>]|[<f1> R.O.F - <f2>0.1 To 100.0 <f3>]|[  <f3>]|[<f1> D.P.S - <f2>0.1 To 100.0 <f3>]|[  <f3>]|[<F1> Range - <f2>Any <f3>]|[",5);
}

function ParticleBeamWeapon::onUnmount(%player)
{
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function ParticleBeamWeaponImage::onFire(%player) 
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	if(%player.pbeamcharging)
		return;
	%player.pbeamcharge=0;
	ParticleBeamWeapon::onCharge(%player);
}

function reload(%player) 
{
	%player.reloading = "";
	//echo("ready");
	playSound(MortarReload, GameBase::getPosition(%player));
}
function ResetPbeamLock(%ClientId)
{
	%clientId.locksound = "";
}

function ParticleBeamWeapon::onCharge(%player)
{

	if (%player.reloading == "True") return;//plasmatic
	%clientId = GameBase::getOwnerClient(%player);
	if(Player::isTriggered(%player,0))
	{
		%player.pbeamcharging = true;
		if (%player.pbeamcharge < 100)
			%player.pbeamcharge++;
		else
		 	%player.pbeamcharge = 100;
		schedule("ParticleBeamWeapon::onCharge(" @ %player @ ");",0.05);
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-2.5);

		if (%player.pbeamcharge > 60 && GameBase::getLOSInfo(%player,3000) && !%clientId.locksound) {
		%obj = getObjectType($los::object);
		//echo(%obj);
			if(%obj == "Player" || %obj == "Flier"){
				GameBase::playSound(%clientId,SoundMineActivate, 0);
				%clientId.locksound = true;
				schedule("ResetPbeamLock("@%ClientId@");",2);
				}
			else if(%obj != "SimTerrain" && %obj != "InteriorShape"){
				GameBase::playSound(%clientId,soundpackuse, 0);
				%ClientId.locksound = true;
				schedule("ResetPbeamLock("@%ClientId@");",2);
				}
		}
		bottomprint(%clientId, "<jc><f3>]|[ <f2>IX Beam Cannon <f3>]|[ <f1> charged to <f2>"@%player.pbeamcharge@"<f3>%", 0.5);
	}
	if(!Player::isTriggered(%player,0))
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		playSound(SoundFireLaser, GameBase::getPosition(%player));
		Player::trigger(%player, 4, true);
		Player::trigger(%player, 6, true);
		//Player::trigger(%player, 7, true);

//plamatic
	%smack = %player.pbeamcharge / 10;
	if (%smack < 4) playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
	if (%smack >= 4) playSound(SoundPlasmaTurretFire, GameBase::getPosition(%player));
	if (%smack >= 8) playSound(explo3, GameBase::getPosition(%player));


		if (GameBase::getLOSInfo(%player,3000)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			Client::sendMessage(%shooterId,0,"target object type "@%obj@" Damage value "@%value);
			if (%obj != "SimTerrain" || %obj != "InteriorShape") {

				if (%obj=="Player" || %obj =="Flier") %value = %player.pbeamcharge/40;
				else  %value = %player.pbeamcharge/8;
			GameBase::applyDamage($los::object, $SniperDamageType, %value, $los::position, "0 0 0","0 0 0", %clientId);

			}
		}

		%player.pbeamcharge=0;
		%player.pbeamcharging=false;
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);
		//Player::trigger(%player, 7, false);
		%player.reloading = "True";//plasmatic
		schedule("reload(" @ %player @ ");",2.0); //PLASMATIC

	//new kickback- Plasmatic
		%rot=GameBase::getRotation(%player);
		%len = 30;
		%tr= getWord(%trans,5);
		%tr = -%tr;
		%tr = %tr+0.15;
		%up = %tr;
		%out = %tr -1;
	%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
	Player::applyImpulse(%player,%vec);

	}
}

ItemImageData TargetingLaserImage 
{ 
shapeFile = "paintgun"; 
mountPoint = 0; 
weaponType = 2; 
projectileType = targetLaser; 
accuFire = true; 
minEnergy = 5; 
maxEnergy = 15; 
reloadTime = 1.0; 
lightType = 3; 
lightRadius = 1; 
lightTime = 1; 
lightColor = { 0.25, 1, 0.25 }; 
sfxFire = SoundFireTargetingLaser; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData TargetingLaser 
{ 
description = "Targeting Laser"; 
className = "Tool"; 
shapeFile = "paintgun"; 
hudIcon = "targetlaser"; 
heading = "tTools"; 
shadowDetailMask = 4; 
imageType = TargetingLaserImage; 
price = 420; 
showWeaponBar = false; 
}; 

ItemImageData FixitImage 
{ 
shapeFile = "disc"; 
mountPoint = 0;
 	mountRotation = { 0, 3 , 0 };
	mountOffset = { 0 , 0 , 0 };
weaponType = 2; 
projectileType = RepairBolt; 
reloadTime = 2.5;  
minEnergy = 5; 
maxEnergy = 15; 
lightType = 3; 
lightRadius = 1; 
lightTime = 1; 
lightColor = { 0.25, 1, 0.25 }; 
sfxFire = SoundRepairItem; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Fixit 
{ 
description = "Repair-Gun"; 
className = "Tool"; 
shapeFile = "disc"; 
hudIcon = "targetlaser"; 
heading = "tTools"; 
shadowDetailMask = 4; 
imageType = FixitImage; 
price = 420; 
showWeaponBar = false; 
}; 
//===================================
ItemImageData Jail3Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Jail3
{
	description = "Jail3";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Jail3Image;
	showWeaponBar = false;
};

ItemImageData JailGunImage
{
shapeFile = "shotgun";
mountPoint = 0;
mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
weaponType = 2;
projectileType = jailbolt;
minEnergy = 5;
maxEnergy = 8;
reloadTime = 2.0;
lightType = 3;
lightRadius = 2;
lightTime = 1;
lightColor = { 0.25, 0.25, 0.85 };
sfxActivate = SoundPickUpWeapon;
sfxFire = SoundELFIdle;
};

ItemData JailGun
{
heading = "tTool";
description = "Jail-Gun";
className = "Tool";
shapeFile  = "shotgun";
shadowDetailMask = 4;
imageType = JailGunImage;
price = 420;
showWeaponBar = true;
};

function JailGun::onMount(%player,%item)
{
	Player::mountItem(%player,jail3,7);
}

function JailGun::onUnMount(%player,%item)
{		
	Player::unmountItem(%player,7);
}
//=================================
ItemData FlareAmmo
{
	description = "Flare Ammo";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData FImage
{
	shapeFile = "Energygun";
	mountPoint = 0;
	mountRotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	ammoType = FlareAmmo;
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

ItemData F
{
	description = "Emergency Flare";
	className = "Tool";
	shapeFile = "energygun";
	hudIcon = "mortar";
	heading = "tTools";
	shadowDetailMask = 4;
	imageType = FImage;
	price = 420;
	showWeaponBar = true;
};

function FImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, FlareAmmo);
	if(%AmmoCount > 0) {
		projectile::spawnprojectile("FlareShell",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
		%clientName = client::GetName(Player::getClient(%player));
		messageAll(1,%clientName@": *Flare Launched I'm In Need Of Some Assistance*~wmine_act.wav");
		Player::decItemCount(%player,"FlareAmmo",1);
		Player::setDamageFlash(%this,0.4);
		GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player)+(Player::getArmor(%player).maxDamage/10.1));
		if(GameBase::getDamageLevel(%player) >= Player::getArmor(%player).maxDamage)
			OverHeatBoom(%player);
	}
}
//==========================================================
ItemImageData Grapple2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.5, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grapple2 
{
	description = "Grap";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Grapple2Image;
	showWeaponBar = false;
};

ItemImageData Grapple3Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.5, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grapple3 
{
	description = "Grap3";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Grapple3Image;
	showWeaponBar = false;
};

ItemImageData Grapple4Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.5, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grapple4 
{
	description = "Grap4";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Grapple4Image;
	showWeaponBar = false;
};

ItemImageData Grapple5Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.5, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grapple5 
{
	description = "Grap5";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Grapple5Image;
	showWeaponBar = false;
};

ItemImageData GrapImage 
{ 
shapeFile = "grenadel"; 
mountPoint = 0;
mountRotation = { 0, 0, 0 }; 
weaponType = 2; 
reloadTime = 0.2;  
minEnergy = 3; 
maxEnergy = 11; 
projectileType = TractorBeam; 
accuFire = true; 
sfxFire = SoundFirelaser; 
sfxActivate = SoundPickUpWeapon; 
};

ItemData Grap 
{ 
heading = "tTools"; 
description = "Grappling Hook"; 
className = "Tool"; 
shapeFile = "grenadel"; 
hudIcon = "blaster"; 
shadowDetailMask = 4; 
imageType = GrapImage; 
price = 420; 
showWeaponBar = true; 
}; 

function Grap::onMount(%player,%item)
{
      Player::mountItem(%player,Grapple2,4);
	Player::mountItem(%player,Grapple3,5);
      Player::mountItem(%player,Grapple4,6);
	Player::mountItem(%player,Grapple5,7);
}

function Grap::onUnMount(%player,%item)
{
      Player::unmountItem(%player,4);	
	Player::unmountItem(%player,5);
      Player::unmountItem(%player,6);	
	Player::unmountItem(%player,7);
}
//========================================
ItemImageData push2Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData push2 
{
	description = "push";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType  = push2Image;
	showWeaponBar = false;
};

ItemImageData pushImage 
{ 
shapeFile = "repairgun"; 
mountPoint = 0;
mountRotation = { 0, 1.5, 0 }; 
weaponType = 2; 
reloadTime = 0.2;  
minEnergy = 3; 
maxEnergy = 11; 
projectileType = antigravCharge; 
accuFire = true; 
sfxFire = Soundwind1; 
sfxActivate = SoundPickUpWeapon; 
};

ItemData push 
{ 
heading = "tTools"; 
description = "Repulse Beam"; 
className = "Tool"; 
shapeFile = "repairgun"; 
hudIcon = "shotgun"; 
shadowDetailMask = 4; 
imageType = pushImage; 
price = 420; 
showWeaponBar = true; 
}; 

function push::onMount(%player,%item)
{
	Player::mountItem(%player,push2,7);
}

function push::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}


