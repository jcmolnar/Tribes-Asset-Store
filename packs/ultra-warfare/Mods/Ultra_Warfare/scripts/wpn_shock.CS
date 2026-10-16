//================================================================
//Shocklance
//================================================================
$AutoUse[SoulSucker] = False;
//===============================================
$InvList[SoulSucker] = 1;
$RemoteInvList[SoulSucker] = 1;
//================================================================
$DamageScale[larmor, $ShockDamageType] = 1.0;
$DamageScale[lfemale, $ShockDamageType] = 1.0;
$DamageScale[marmor, $ShockDamageType] = 1.0;
$DamageScale[mfemale, $ShockDamageType] = 1.0;
$DamageScale[harmor, $ShockDamageType] = 1.0;

$ItemMax[larmor, SoulSucker] = 1;
$ItemMax[lfemale, SoulSucker] = 1;
$ItemMax[marmor, SoulSucker] = 1;
$ItemMax[mfemale, SoulSucker] = 1;
$ItemMax[harmor, SoulSucker] = 1;
//================================================================
SoundData SoundWPNShock
{
   wavFileName = "wpn_Shock.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNShockAct
{
   wavFileName = "wpn_Shock_act.wav";
   profile = Profile3dNear;
};
//================================================================
function StopSuck(%shooterId){
	%shooterId.lock = false;//echo("falsied");
	Player::trigger(%shooterId, $WeaponSlot, false);
	}

function LaserSearch::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%player = Client::getOwnedObject(%shooterId);
%energy = GameBase::getEnergy(%player);
%object = getObjectType(%target); 
//GameBase::setEnergy(%player,(%energy-10));
if (%energy < 20 && (!$build ||%object == "Player" )) {
		Player::trigger(%shooterId, $WeaponSlot, false);
		//GameBase::playSound( %shooterId,SoundSoul,0);
		return;}
//Player::trigger(%shooterId, $WeaponSlot, true);
//%shooterId.lock = true;
GameBase::playSound(%shooterId,SoundCrash,0);
if ($build && %object != "Player" ) GameBase::setEnergy(%player,(%energy+15));
if (!$build) schedule("Player::trigger(%shooterId, $WeaponSlot, false);", 2);
if (!$build) schedule("StopSuck(%shooterId);", 2);

if(%object == "Player" || %object == "Flier") { 
laserWarning(%shooterId, %target, %object);}

if (!$build ||%object == "Player" )  GameBase::setEnergy(%player,(%energy-50));
if ($build && %object != "Player" )GameBase::applyDamage(%target, $ShockDamageType, 50, %pos, %vec, %mom, %shooterId);

   GameBase::applyDamage(%target, $ShockDamageType, 2, %pos, %vec, %mom, %shooterId);


}

LightningData LaserSearch
 {
	bitmapName       = "proj_shock.bmp"; //lightningNew.bmp
   	boltLength       = 50.0;
   	coneAngle        = 15.0;
   	damagePerSec = 10;
   	energyDrainPerSec = 250;
   	segmentDivisions = 0;
   	numSegments = 1;
   	beamWidth = 0.25;
   	updateTime   = 30;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   	lightRange = 3.0;
   	lightColor = { 0.5, 0.5, 0.5 };
   	isVisible = false;//false


};
//================================================================
ItemImageData SoulSuckerImage
{
	shapeFile = "wpn_shocklance";
   mountPoint = 0;

   weaponType = 2;  // 2continuous 0singleshot 1spinning
   projectileType = LaserSearch;//lightningcharge
   minEnergy = 50;
   maxEnergy = 150;  // Energy used/sec for sustained weapons 11
   reloadTime = 1;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundWPNShockAct;
   sfxFire     = SoundWPNShock;
  

};

ItemData SoulSucker
{
	description = "ShockLance";
	className = "Weapon";
	shapeFile = "wpn_shocklance";
	hudIcon = "soul";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SoulSuckerImage;
	price = 0;
	showWeaponBar = true;
   //validateShape = true;
   //validateMaterials = true;
};

ItemImageData Laser1Image { shapeFile = "wpn_shocklance"; mountPoint = 0; weaponType = 0; reloadTime = 0.45; accuFire = true; fireTime = 0.45; }; 

ItemData Laser1 { heading = "bWeapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "wpn_shocklance"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = Laser1Image; price = 125; showWeaponBar = false; showInventory = false; }; 

function SoulSucker::onMount(%player, %slot) {	
	Player::mountItem(%player, Laser1, 6); 
}
function SoulSucker::onUnmount(%player, %slot) { 
	Player::unmountItem(%player, 6); 
}


function laserWarning(%clientId, %target, %targetType) { 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName;
		//echo(%msg); 
	Client::sendMessage(%clientId,0,"Target Aquired: " @ %msg @ "~wwpn_shock_acq.wav");
	if(%targetType == Flier || (Player::getArmor(%target)) != "") {
		Client::sendMessage(%targetId,0, %name @ " Hit you with a soul sucker!~wmsg_error.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_shock_miss.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_shock_miss.wav\");", 1.0); 


	}
} 
//================================================================
//echo("Shocklance Loaded");