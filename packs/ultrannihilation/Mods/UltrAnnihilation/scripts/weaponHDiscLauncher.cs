$InvList[HDiscLauncher] = 1;
$MobileInvList[HDiscLauncher] = 1;
$RemoteInvList[HDiscLauncher] = 1;

$InvList[HDiscLauncherAmmo] = 1;
$MobileInvList[HDiscLauncherAmmo] = 1;
$RemoteInvList[HDiscLauncherAmmo] = 1;

$AutoUse[HDiscLauncher] = True;
$WeaponAmmo[HDiscLauncher] = HDiscLauncherAmmo; 
$SellAmmo[HDiscLauncherAmmo] = 5;


addWeapon(HDiscLauncher);
addAmmo(HDiscLauncher,HDiscLauncherAmmo,20);

ItemData HDiscLauncherAmmo
{	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
}; 

ItemData HDiscLauncher1Ammo
{	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
};

ItemData HDiscLauncher2Ammo
{	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
}; 

ItemImageData HDiscLauncher1Image 
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };
	ammoType = HDiscLauncher1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	spinUpTime = 0.2;
	projectileType = HyperDiscShell;
};

ItemData HDiscLauncher1
{	description = "Hyper Spinfusor";
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
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,1.57, 0 };
	ammoType = HDiscLauncher2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	spinUpTime = 0.2;
	projectileType = HyperDiscShell;
};

ItemData HDiscLauncher2
{	description = "Hyper Spinfusor";
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
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = HDiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	// sfxReady = SoundSpinIdle;
};

ItemData HDiscLauncher 
{	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function HDiscLauncherImage::onFire(%player, %slot)
{ 	
	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
	{	%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "HDiscLauncherAmmo", 1);
		%num = Player::getItemCount(%player, "HDiscLauncherAmmo");
		if(%client.hd == 0)
		{	%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "HDiscLauncher1Ammo", 0);
			else 
				Player::setItemCount(%player, "HDiscLauncher1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{	%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "HDiscLauncher2Ammo", 0);
 			else
				Player::setItemCount(%player, "HDiscLauncher2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	} 
}

function HDiscLauncher::onMount(%player,%imageSlot,%item)
{	
	%num = Player::getItemCount(%player, "HDiscLauncherAmmo");
	Player::setItemCount(%player, "HDiscLauncher1Ammo", %num);
	Player::mountItem(%player,HDiscLauncher1,6);
 	Player::setItemCount(%player, "HDiscLauncher2Ammo", %num);
 	Player::mountItem(%player,HDiscLauncher2,7);
	%client = Player::getClient(%player);
	Bottomprint(%client, "Hyper Spinfusor: <f2>This dual barreled disc launcher can unload a score of deadly spinning blades in seconds.");
}

function HDiscLauncher::onUnmount(%player,%imageSlot)
{	
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
}