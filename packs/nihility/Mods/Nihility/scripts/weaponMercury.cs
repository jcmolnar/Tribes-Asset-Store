//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(XHChaingun);
$InvList[XHChaingun] = 1;
$InvList[xgatlingammo] = 1;

$SellAmmo[xgatlingammo] = 20;
$AutoUse[XHChaingun] = True;
$WeaponAmmo[XHChaingun] = xgatlingammo;

$ItemMax[larmor, XHChaingun] = 0;		//Seraph
$ItemMax[lfemale, XHChaingun] = 0;		//Seraph
$ItemMax[earmor, XHChaingun] = 0;		//Slave
$ItemMax[efemale, XHChaingun] = 0;		//Slave
$ItemMax[marmor, XHChaingun] = 0;		//Pawn
$ItemMax[aarmor, XHChaingun] = 0;		//Navigator
$ItemMax[darmor, XHChaingun] = 1;		//Atomizer
$ItemMax[barmor, XHChaingun] = 0;		//Paladin

$ItemMax[larmor, xgatlingammo] = 0;		//Seraph
$ItemMax[lfemale, xgatlingammo] = 0;		//Seraph
$ItemMax[earmor, xgatlingammo] = 0;		//Slave
$ItemMax[efemale, xgatlingammo] = 0;		//Slave
$ItemMax[marmor, xgatlingammo] = 0;		//Pawn
$ItemMax[aarmor, xgatlingammo] = 0;		//Navigator
$ItemMax[darmor, xgatlingammo] = 120;		//Atomizer
$ItemMax[barmor, xgatlingammo] = 0;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ExplosionData rockettExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

//{
//   shapeName = "bluex.dts";
//   soundId   = rocketExplosion;
//
//   faceCamera = true;
//   randomSpin = true;
//   hasLight   = true;
//   lightRange = 8.0;
//
//   timeScale = 1.5;
//
//   timeZero = 0.250;
//   timeOne  = 0.850;
//
//   colors[0]  = { 0.4, 0.4,  1.0 };
//   colors[1]  = { 1.0, 1.0,  1.0 };
//   colors[2]  = { 1.0, 0.95, 1.0 };
//   radFactors = { 0.5, 1.0, 1.0 };
//};

RocketData MortarShellX
{
bulletShapeName = "rocket.dts";//plasmabolt.dts //fusionbolt zap_5  
explosionTag = rockettExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.43;
damageType = $PlasmaDamageType;
explosionRadius = 10.0;
kickBackStrength = 50.0;
muzzleVelocity = 65.0;
terminalVelocity = 2000.0;
acceleration = 0.0;
totalTime = 4.0;
liveTime = 3.7;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.3;
trailType = 1; trailLength = 4000; trailWidth = 0.75;
//trailType = 2;
//trailString = "plasmabolt.dts";
//smokeDist = 5.8;
soundId = SoundJetHeavy; }; 


RocketData MortarShellXX
{ bulletShapeName = "plasmabolt.dts";//plasmabolt.dts
explosionTag = rockettExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.50;
damageType = $PlasmaDamageType;
explosionRadius = 10.0;
kickBackStrength = 50.0;
muzzleVelocity = 65.0;
terminalVelocity = 2000.0;
acceleration = 0.0;
totalTime = 4.0;
liveTime = 3.7;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.3;
trailType = 1; trailLength = 4000; trailWidth = 1;
//trailType = 2;
//trailString = "plasmabolt.dts";
//smokeDist = 5.8;
soundId = SoundJetHeavy; }; 


ItemData xgatlingammo
{
	description = "Mercury Shells";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 11;
};



ItemImageData XHChain1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -0.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };

	 ammoType = xgatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = MortarShellX; //MortarShellX
}; 

ItemData XHChain1 
{ 
	description = "Thumper";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = XHChain1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData XHChain2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -1.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };

	 ammoType = xgatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = MortarShellX; //MortarShellX
}; 

ItemData XHChain2 
{ 
	description = "Thumper";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = XHChain2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData XHChaingunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = xgatlingammo; 
	reloadTime = 0.0;
	fireTime = 0.3;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData XHChaingun
{ 
	description = "Mercury Cannon"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = XHChaingunImage; 
	price = 777; 
	showWeaponBar = true;
}; 

function XHChaingunImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,6);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "xgatlingammo", 0.5);   
		%num = Player::getItemCount(%player, "xgatlingammo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "xgatlingammo", 0);    
			else     
			Player::setItemCount(%player, "xgatlingammo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "xgatlingammo", 0);    
			else     
			Player::setItemCount(%player, "xgatlingammo", %num);    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		}  
	} 
}  

function XHChaingun::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "xgatlingammo");  
	Player::setItemCount(%player, "xgatlingammo", %num);  
	Player::mountItem(%player,XHChain1,4);  
	Player::mountItem(%player,XHChain2,6); 
} 

function XHChaingun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,6); 
}

$AutoUse[XHChaingun]			= True;

AddWeapon(XHChaingun);

$WeaponAmmo[XHChaingun]			= xgatlingammo;
$SellAmmo[xgatlingammo]			= 200;


$InvList[XHChaingun] = 1;
$InvList[xgatlingammo] = 1;



function XHChain2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Mercury Cannon");
}