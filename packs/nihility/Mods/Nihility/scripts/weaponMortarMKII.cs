//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Mortarr);
$InvList[Mortarr] = 1;

$AutoUse[Mortarr] = True;
$WeaponAmmo[Mortarr] = MortarAmmo;

$ItemMax[larmor, Mortarr] = 0;		//Seraph
$ItemMax[lfemale, Mortarr] = 0;		//Seraph
$ItemMax[earmor, Mortarr] = 0;		//Slave
$ItemMax[efemale, Mortarr] = 0;		//Slave
$ItemMax[marmor, Mortarr] = 0;		//Pawn
$ItemMax[aarmor, Mortarr] = 0;		//Navigator
$ItemMax[darmor, Mortarr] = 0;		//Atomizer
$ItemMax[barmor, Mortarr] = 1;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData Mortarr1Image 
{ 
	 shapeFile = "shotgun"; 
	mountPoint = 0;
        mountOffset = { 0, 0.32, 0.32 };
	mountRotation = { 3.14, 3.14, 0 };
	ammoType = MortarAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = MortarShellBlue; //MortarShellX
}; 

ItemData Mortarr1 
{ 
	description = "Thumper";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Mortarr1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData MortarrImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0;
	//mountOffset = { -0.6, -0.7, 0.7 };
	//mountRotation = { 0, 3.14, 0 };
	weaponType = 0; 
	ammoType = MortarAmmo; 
	reloadTime = 0.5;
	fireTime = 2.0;
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
	projectileType = MortarShellBlue; //MortarShellX

}; 

ItemData Mortarr
{ 
	description = "Mortar MKII"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
     	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MortarrImage; 
	price = 777; 
	showWeaponBar = true;
}; 



function Mortarr::onMount(%player,%imageSlot) 
{  
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Mortar MKII");
	//%num = Player::getItemCount(%player, "MortarAmmo");  
	//Player::setItemCount(%player, "MortarAmmo", %num);  
	Player::mountItem(%player,Mortarr1,4);  

} 

function Mortarr::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  

}