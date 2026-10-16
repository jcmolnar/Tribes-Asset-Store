//=========================================================================================
//                                DOUBLE PLASMA
//=========================================================================================
RocketData PlasmaRocket
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 4;
	damageClass = 0;
	damageValue = 10.0;
	damageType = $PlasmaDamageType;
	explosionRadius = 4;
	kickBackStrength = 5;
	muzzleVelocity = 600;
	terminalVelocity = 570;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 35;
	soundId = SoundJetLight;
};

ItemData DoublePlasmaAmmo {
	description = "Double Plasma Bolt";
    heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DoublePlasmaImage {
	shapeFile = "plasma"; 
	mountPoint = 0;  
	mountOffset = { -0.75, 0, 0 };
	weaponType = 0; 
	reloadTime = 0.03; 
	fireTime = 0.03;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = DoublePlasmaAmmo; 
	accuFire = true; 
	sfxFire = SoundFirePlasma; 
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData DoublePlasma {
	description = "Double Plasma"; 
	className = "Weapon"; 
	shapeFile = "plasma";  
	mountOffset = { -0.75, 0, 0 };
	hudIcon	= "sensorjamerpack";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4; 
	imageType = DoublePlasmaImage; 
	price = 2500; 
	showWeaponBar = true; 
}; 

ItemImageData DoublePlasma2Image {
	shapeFile = "plasma"; 
	mountPoint = 0;  
	weaponType = 0; 
	reloadTime = 0.03; 
	fireTime = 0.03;
	ammoType = DoublePlasmaAmmo; 
	accuFire = true; 
	sfxFire = SoundFirePlasma; 
	minEnergy = 5;	
	maxEnergy = 6;
};	

ItemData DoublePlasma2 {
	description = "Double Plasma"; 
	className = "Weapon"; 
	shapeFile = "plasma"; 
	shadowDetailMask = 4; 
	imageType = DoublePlasma2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 


function DoublePlasma::onDrop(%player,%item){
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload"){
		Player::setItemCount(%player, DoublePlasma2, 0); 
		Item::onDrop(%player, %item); 
	}
}

function DoublePlasma::onMount(%player,%item){	
	if($debug) Echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	Schedule("DoublePlas::CheckMounted("@ %player @", "@ %item @");", 1);
}

function DoublePlas::CheckMounted(%player, %item){
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%client,0) == DoublePlasma){
		Player::mountItem(%player, DoublePlasma2, $XtraSlotA);
		Client::sendMessage(%client, 0, "~wammo_activate.wav");
		Client::sendMessage(%client, 0, "~wturreton1.wav");
	}
	else return false;
}

function DoublePlasma::onUnmount(%player,%imageSlot) 
{ Player::unmountItem(%player, $XtraSlotA); }

function CheckDoublePlasma(%client, %player){
	if(Player::isTriggered(%player, $WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "DoublePlasma")){
		Player::trigger(%player, $XtraSlotA, true);
		schedule("CheckDoublePlasma("@ %client @", "@ %player @");", 0.1); 
		$FiringDoublePlasma[%client] = true;
	}else{
		Player::trigger(%player, $XtraSlotA,false);  
		$FiringDoublePlasma[%client] = false; 
	}
}

function DoublePlasmaImage::onFire(%player, %slot){		
	if($debug) echo("?? EVENT fire "@ Player::getMountedItem(%player, 0) @" player "@ %player @" cl# "@ Player::getclient(%player));		
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[DoublePlasma]);
	%client = GameBase::getOwnerClient(%player);
	if(!%AmmoCount){
		Client::sendMessage(%client, 3, "Double Plasma is out of ammo.~waccess_denied.wav");
		return;
	}
	%clientName = Player::getClient(%player);
	%clientId = Client::getName(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
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
	Projectile::spawnProjectile("PlasmaRocket",%trans,%player,%vel,%target);
	Projectile::spawnProjectile("PlasmaRocket",%trans2,%player,%vel,%target);
	if(!$FiringDoublePlasma[%client]) CheckDoublePlasma(%client, %player);
	if($TG::InfiniteAmmo:DoublePlasma != true) Player::decItemCount(%player, $WeaponAmmo[DoublePlasma], 2);
}