//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
//addWeapon(HDiscLauncher);
//$InvList[HDiscLauncher] = 1;
//$InvList[HDiscLauncherAmmo] = 1;
//
//$SellAmmo[HDiscLauncherAmmo] = 5;
//$SellAmmo[HDiscLauncherAmmo1] = 5;
//$SellAmmo[HDiscLauncherAmmo2] = 5;
//$AutoUse[HDiscLauncher] = True;
//$AutoUse[HDiscLauncher1] = True;
//$AutoUse[HDiscLauncher2] = True;
//$WeaponAmmo[HDiscLauncher] = HDiscLauncherAmmo;
//$WeaponAmmo[HDiscLauncher1] = HDiscLauncherAmmo1;
//$WeaponAmmo[HDiscLauncher2] = HDiscLauncherAmmo2;
//
//$ItemMax[larmor, HDiscLauncher] = 1;	//Seraph
//$ItemMax[lfemale, HDiscLauncher] = 1;	//Seraph
//$ItemMax[earmor, HDiscLauncher] = 1;	//Slave
//$ItemMax[efemale, HDiscLauncher] = 1;	//Slave
//$ItemMax[marmor, HDiscLauncher] = 1;	//Pawn
//$ItemMax[aarmor, HDiscLauncher] = 1;	//Navigator
//$ItemMax[darmor, HDiscLauncher] = 1;	//Atomizer
//$ItemMax[barmor, HDiscLauncher] = 0;	//Paladin
//
//$ItemMax[larmor, HDiscLauncherAmmo] = 25;	//Seraph
//$ItemMax[lfemale, HDiscLauncherAmmo] = 25;	//Seraph
//$ItemMax[earmor, HDiscLauncherAmmo] = 25;	//Slave
//$ItemMax[efemale, HDiscLauncherAmmo] = 25;	//Slave
//$ItemMax[marmor, HDiscLauncherAmmo] = 30;	//Pawn
//$ItemMax[aarmor, HDiscLauncherAmmo] = 30;	//Navigator
//$ItemMax[darmor, HDiscLauncherAmmo] = 35;	//Atomizer
//$ItemMax[barmor, HDiscLauncherAmmo] = 0;	//Paladin
//
//$ItemMax[larmor, HDiscLauncherAmmo1] = 25;	//Seraph
//$ItemMax[lfemale, HDiscLauncherAmmo1] = 25;	//Seraph
//$ItemMax[earmor, HDiscLauncherAmmo1] = 25;	//Slave
//$ItemMax[efemale, HDiscLauncherAmmo1] = 25;	//Slave
//$ItemMax[marmor, HDiscLauncherAmmo1] = 30;	//Pawn
//$ItemMax[aarmor, HDiscLauncherAmmo1] = 30;	//Navigator
//$ItemMax[darmor, HDiscLauncherAmmo1] = 35;	//Atomizer
//$ItemMax[barmor, HDiscLauncherAmmo1] = 0;	//Paladin
//
//$ItemMax[larmor, HDiscLauncherAmmo2] = 25;	//Seraph
//$ItemMax[lfemale, HDiscLauncherAmmo2] = 25;	//Seraph
//$ItemMax[earmor, HDiscLauncherAmmo2] = 25;	//Slave
//$ItemMax[efemale, HDiscLauncherAmmo2] = 25;	//Slave
//$ItemMax[marmor, HDiscLauncherAmmo2] = 30;	//Pawn
//$ItemMax[aarmor, HDiscLauncherAmmo2] = 30;	//Navigator
//$ItemMax[darmor, HDiscLauncherAmmo2] = 35;	//Atomizer
//$ItemMax[barmor, HDiscLauncherAmmo2] = 0;	//Paladin

addWeapon(DiscLauncher);
$InvList[DiscLauncher] = 1;
$InvList[DiscAmmo] = 1;
$SellAmmo[DiscAmmo] = 5;
$AutoUse[DiscLauncher] = True;
$WeaponAmmo[DiscLauncher] = DiscAmmo;


$ItemMax[larmor, DiscLauncher] = 1;	//Seraph
$ItemMax[lfemale, DiscLauncher] = 1;	//Seraph
$ItemMax[earmor, DiscLauncher] = 1;	//Slave
$ItemMax[efemale, DiscLauncher] = 1;	//Slave
$ItemMax[marmor, DiscLauncher] = 1;	//Pawn
$ItemMax[aarmor, DiscLauncher] = 1;	//Navigator
$ItemMax[darmor, DiscLauncher] = 1;	//Atomizer
$ItemMax[barmor, DiscLauncher] = 0;	//Paladin

$ItemMax[larmor, DiscAmmo] = 25;	//Seraph
$ItemMax[lfemale, DiscAmmo] = 25;	//Seraph
$ItemMax[earmor, DiscAmmo] = 25;	//Slave
$ItemMax[efemale, DiscAmmo] = 25;	//Slave
$ItemMax[marmor, DiscAmmo] = 30;	//Pawn
$ItemMax[aarmor, DiscAmmo] = 30;	//Navigator
$ItemMax[darmor, DiscAmmo] = 35;	//Atomizer
$ItemMax[barmor, DiscAmmo] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData DiscLauncherImage 
{
	shapeFile = "disc";
	mountPoint = 0;
	//mountRotation = { 0, 3.1416, 0 };
	weaponType = 3;
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.17;
	fireTime = 0.17;
	spinUpTime = 0.25;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
}; 

ItemData DiscLauncher 
{
	description = "Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 77;
	showWeaponBar = true;
}; 

function DiscLauncher::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
bottomprint(Player::getClient(%player), "<jc><f2>Spinfusor", 2);
}

//function DiscLauncherImage::onfire(%player) 
//{ 
//wang(%player);
//}

//function wang(%player){
//        if(GameBase::getLOSInfo(%player,1000))
//        {        
//                %object = getObjectType($los::object);
//                        
//                %xopos = getWord($los::position,0);
//                %yopos = getWord($los::position,1);
//                %zopos = getWord($los::position,2);
//        %pos = %xopos @" "@ %yopos @" "@ %zopos +20;
//        }        
//
//%trans = GameBase::getMuzzleTransform(%player);
//%vel = Item::getVelocity(%player);
//        for(%i=0; %i < 10; %i += 1) {
//
//                %xrnd = floor(getRandom() *10)/5 -1;
//                %yrnd = floor(getRandom() *10)/5 -1;
//                %zrnd = -1;                //floor(getRandom() *10)/5 -1;
//
////%apos = getBoxCenter(%player);
////echo(%apos);
//
//                %trans1= getWord(%trans,0);
//                %trans2= getWord(%trans,1);
//                %trans3= getWord(%trans,2);
//                %trans4= getWord(%trans,3) + %xrnd;
//                %trans5= getWord(%trans,4) + %yrnd;
//                %trans6= getWord(%trans,5) + %zrnd;
//                %trans7= getWord(%trans,6);
//                %trans8= getWord(%trans,7);
//                %trans9= getWord(%trans,8);
//                %trans10=getWord(%trans,9);
//                %trans11=getWord(%trans,10);
//                %trans12=getWord(%trans,11);
//                
//        %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos;
//
////%trans10 @" "@ %trans11 @" "@ %trans12;
//
//// targetLaser, sniperLaser -freaky, uses mounted weapon trans
//// turretCharge, MortarShell, TurretMissile, FusionBolt ,discshell -works fine
//// SwissBolt
//        Projectile::spawnProjectile("sniperLaser", %NewTrans, %player, %vel);
////        Projectile::spawnProjectile(%newObj);
////        schedule("DeleteLaser(" @ %newObj @ ");", 1.5);
//                        }
//        }
        

//ItemImageData DiscLauncher1Image 
//{
//	shapeFile = "disc";
//	mountPoint = 0;
//	mountRotation = { 0,-1.57, 0 };
//	ammoType = DiscAmmo;
//	weaponType = 3;
//	accuFire = true;
//	reloadTime = 0.085;
//	fireTime = 0.085;
//	spinUpTime = 0.125;
//	projectileType = DiscShell;
//};
//
//ItemData DiscLauncher1
//{
//	description = "Hyper Spinfusor";
//	className = "Weapon";
//	shapeFile = "disc";
//	hudIcon = "disk";
//	heading = $InvHead[ihWea];
//	shadowDetailMask = 4;
//	imageType = HDiscLauncher1Image;
//	price = 250;
//	showWeaponBar = false;
//	showInventory = false;
//};
//
//ItemImageData DiscLauncher2Image
//{
//	shapeFile = "disc";
//	mountPoint = 0;
//	mountRotation = { 0,1.57, 0 };
//	ammoType = DiscAmmo;
//	weaponType = 3;
//	accuFire = true;
//	reloadTime = 0.085;
//	fireTime = 0.085;
//	spinUpTime = 0.125;
//	projectileType = DiscShell;
//};
//
//ItemData DiscLauncher2
//{
//	description = "Hyper Spinfusor";
//	className = "Weapon";
//	shapeFile = "disc";
//	hudIcon = "disk";
//	heading = $InvHead[ihWea];
//	shadowDetailMask = 4;
//	imageType = HDiscLauncher2Image;
//	price = 250;
//	showWeaponBar = false;
//	showInventory = false;
//};
//
//ItemImageData DiscLauncherImage
//{
//	shapeFile = "breath";
//	mountPoint = 3;
//	weaponType = 3;
//	ammoType = DiscAmmo;
//	accuFire = true;
//	reloadTime = 0.1;
//	fireTime = 0.1;
//	spinUpTime = 0.2;
//	sfxFire = SoundFireDisc;
//	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDiscReload;
//	// sfxReady = SoundSpinIdle;
//};
//
//ItemData DiscLauncher 
//{
//	description = "Spinfusor";
//	className = "Weapon";
//	shapeFile = "disc";
//	hudIcon = "disk";
//	heading = "bWeapons";
//	shadowDetailMask = 4;
//	imageType = DiscLauncherImage;
//	price = 77;
//	showWeaponBar = true;
//}; 
//
//function DiscLauncherImage::onFire(%player, %slot)
//{ 	
//	%state1 = Player::getItemState(%player,6);
// 	%state2 = Player::getItemState(%player,7);
// 	if(%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
//	{
//		%client = GameBase::getOwnerClient(%player);
//		Player::decItemCount(%player, "DiscAmmo", 1);
//		%num = Player::getItemCount(%player, "DiscAmmo");
//		if(%client.hd == 0)
//		{
//			%client.hd = 1;
//			if(%num == 1)
//				Player::setItemCount(%player, "DiscAmmo", 0);
//			else 
//				Player::setItemCount(%player, "DiscAmmo", %num);
// 			Player::trigger(%player,6,true);
// 			Player::trigger(%player,6,false);
//	 	}
//		else
//		{
//			%client.hd = 0;
// 			if(%num == 1)
// 				Player::setItemCount(%player, "DiscAmmo", 0);
// 			else
//				Player::setItemCount(%player, "DiscAmmo", %num);
// 			Player::trigger(%player,7,true);
// 			Player::trigger(%player,7,false);
// 		}
// 	}
//}
//
//function DiscLauncher::onMount(%player,%imageSlot,%item)
//{	
//	%num = Player::getItemCount(%player, "DiscAmmo");
//	//Player::setItemCount(%player, "DiscAmmo", %num);
//	Player::mountItem(%player,DiscLauncher1,6);
// 	//Player::setItemCount(%player, "DiscAmmo", %num);
// 	Player::mountItem(%player,DiscLauncher2,7);
//	%clientId = Player::getclient(%player);
//	if(%clientId.weaponHelp)
//		Bottomprint(%clientId, "<jc><f2>Spinfusor");
//}
//
//function DiscLauncher::onUnmount(%player,%imageSlot)
//{	
//	Player::unmountItem(%player,6);
// 	Player::unmountItem(%player,7);
//}
//
//        
//
////function DiscLauncher::onUse(%player,%item)
////{
////Weapon::onUse(%player,%item);
////bottomprint(Player::getClient(%player), "<jc><f2>Spinfusor", 2);
////}


ItemData HDiscLauncherAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemData HDiscLauncher1Ammo
{
	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 1;
	showInventory = false;
};

ItemData HDiscLauncher2Ammo
{
	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 1;
	showInventory = false;
}; 

//===============

ItemImageData HDiscLauncher1Image 
{
	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };
	ammoType = HDiscLauncher1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.765;
	fireTime = 0.065;
	spinUpTime = 0.0;
	projectileType = DiscShell;
};

ItemData HDiscLauncher1
{
	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncher2Image
{
	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,1.57, 0 };
	ammoType = HDiscLauncher2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.765;
	fireTime = 0.065;
	spinUpTime = 0.0;
	projectileType = DiscShell;
};

ItemData HDiscLauncher2
{
	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncherImage
{
	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = HDiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.765;
	fireTime = 0.065;
	spinUpTime = 0.0;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	// sfxReady = SoundSpinIdle;
};

ItemData HDiscLauncher 
{
	description = "Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HDiscLauncherImage;
	price = 77;
	showWeaponBar = true;
};

function HDiscLauncherImage::onFire(%player, %slot)
{ 	
	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if(%state1 != "Fire" && %state1 != "Reload" && %state1 != "Reload" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload" && %state2 != "Reload" && %state2 != "Reload" && %state2 != "Reload")
	{
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "HDiscLauncherAmmo", 1);
		%num = Player::getItemCount(%player, "HDiscLauncherAmmo");
		if(%client.hd == 0)
		{
			%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "HDiscLauncher1Ammo", 0);
			else 
				Player::setItemCount(%player, "HDiscLauncher1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{
			%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "HDiscLauncher2Ammo", 0);
 			else
				Player::setItemCount(%player, "HDiscLauncher2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	}
}


function HDiscLauncher::onMount(%player,%imageSlot,%item,$Weaponslot)
{	
	%num = Player::getItemCount(%player, "HDiscLauncherAmmo");
	Player::setItemCount(%player, "HDiscLauncher1Ammo", %num);
	Player::mountItem(%player,HDiscLauncher1,6);
 	Player::setItemCount(%player, "HDiscLauncher2Ammo", %num);
 	Player::mountItem(%player,HDiscLauncher2,7);
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Spinfusor");
}

function HDiscLauncher::onUnmount(%player,%imageSlot)
{	
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
} 