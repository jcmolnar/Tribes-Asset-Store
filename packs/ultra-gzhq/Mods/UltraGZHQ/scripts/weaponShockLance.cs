//--------------------------------------
// Origional code by Plasmatic
// Please get ahold of me if you want to use this
// ziptiezmail@netscape.net
//--------------------------------------

$AutoUse[ShockLance] = false;
$WeaponAmmo[ShockLance] = "";

//--------------------------------------

$InvList[ShockLance] = 1;
$MobileInvList[ShockLance] = 1;
$RemoteInvList[ShockLance] = 1;


addWeapon(ShockLance);

//--------------------------------------


SoundData SoundCrash
{
   wavFileName = "crash.wav";
   profile = Profile3dFar;
};

SoundData SoundNope
{
   wavFileName = "failpack.wav";
   profile = Profile3dMedium;
};



function SoulBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%player = Client::getOwnedObject(%shooterId);
	%energy = GameBase::getEnergy(%player);
	%object = getObjectType(%target); 

	if (%energy < 0.06) 
		{
		Player::trigger(%shooterId, $WeaponSlot, false);
		if (!%shooterId.SoulMute) 
			{
			%shooterId.SoulMute = 1;
			schedule(%shooterId @ ".SoulMute--;",0.1);
			//GameBase::playSound( %shooterId,SoundNope,0);
			}
		Player::trigger(%shooterId, 0, false);
		return;
		}

	GameBase::playSound(%shooterId,SoundCrash,0);
	%shooterId.SoulMute = 1;
	schedule(%shooterId @ ".SoulMute--;",0.1);
	schedule("Player::trigger("@ %shooterId @", 0, false);", 1);

	if(%object == "Player" || %object == "Flier") 
	{ 
		SoulWarning(%shooterId, %target, %object);
		GameBase::applyDamage(%target, $SoulDamageType, 55.5, %pos, %vec, %mom, %shooterId);	// damages players more.
		if(GameBase::getDamageLevel(%player))
		{
			GameBase::repairDamage(%player, 0.05);	//added bonus for damaging players.
		}
	}
	GameBase::setEnergy(%player,0);
	GameBase::applyDamage(%target, $SoulDamageType, 55.5, %pos, %vec, %mom, %shooterId);	//turrets dont have souls..

}


function ShockLanceImage::onFire(%player, %slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		
	
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%obj = Projectile::spawnProjectile("SoulBolt",%trans,%player,%vel);
	schedule("deleteobject("@%obj@");",0.5);
	schedule("Player::trigger("@%player@", 0, false);",1);
}



ItemImageData ShockLanceImage
{
   shapeFile = "disc";
   mountPoint = 0;
   mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
   mountRotation = { 0, -3.14, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
   weaponType = 0;  
   //projectileType = SoulBolt;
   minEnergy = 0.06; 	
   maxEnergy = 0.06;		
   reloadTime = 0.8;	
   lightType = 3;  
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };
   
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundNope;
};

ItemData ShockLance
{
	description = "ShockLance";
	className = "Weapon";
	shapeFile = "mortar";	//;paintgun";//sniper
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShockLanceImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
 //  validateMaterials = false;
};

function ShockLance::onMount(%player, %slot) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));


	bottomprint(Player::getClient(%player), "<jc>ShockLance: <f2>Mounted", 10);GameBase::playSound( %player,ForceFieldOpen,0);
}


function SoulWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier)
		{
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else  
			%msg = "Vehicle"; 
		} 
		else	%msg = %targetName;

	Client::sendMessage(%clientId,0,"Shock Lock Acquired: " @ %msg @ "~wmine_act.wav");
	if(%targetType == Flier || (Player::getArmor(%target)) != "") {
		Client::sendMessage(%targetId,0, %name @ " Shocked your ass!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0); 
	}
} 



