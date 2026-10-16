$InvList[TankMortar] = 1;
$MobileInvList[TankMortar] = 1;
$RemoteInvList[TankMortar] = 1;

$InvList[TankMortarAmmo] = 1;
$MobileInvList[TankMortarAmmo] = 1;
$RemoteInvList[TankMortarAmmo] = 1;

$AutoUse[TankMortar] = false;
$WeaponAmmo[TankMortar] = TankMortarAmmo;
$SellAmmo[TankMortarAmmo] = 50;

addweapon(TankMortar);
addAmmo(TankMortar, TankMortarAmmo, 50);


ItemData TankMortarAmmo
{
	description = "Heavy Mortars";
	className = "Ammo";
	shapeFile = "ammo2";
   	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData TankMortar1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -0.2, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };
	 ammoType = TankMortarAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = TankMortarShell; 
}; 

ItemData TankMortar1 
{ 
	description = "Heavy Mortar";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = TankMortar1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData TankMortar2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -1.0, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };

	 ammoType = TankMortarAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = TankMortarShell; 
}; 

ItemData TankMortar2 
{ 
	description = "Heavy Mortar2";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = TankMortar2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData TankMortarImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = TankMortarAmmo; 
	reloadTime = 0.0;
	fireTime = 0.3;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData TankMortar
{ 
	description = "Heavy Mortar"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "chain"; 
     	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = TankMortarImage; 
	price = 8000; 
	showWeaponBar = true;
}; 

function TankMortarImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "TankMortarammo", 1);   
		%num = Player::getItemCount(%player, "TankMortarAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "TankMortarAmmo", 0);    
			else     
			Player::setItemCount(%player, "TankMortarAmmo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "TankMortarAmmo", 0);    
			else     
			Player::setItemCount(%player, "TankMortarAmmo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function TankMortar::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "TankMortarammo");  
	Player::setItemCount(%player, "TankMortarAmmo", %num);  
	Player::mountItem(%player,TankMortar1,4);  
	Player::mountItem(%player,TankMortar2,5); 
} 

function TankMortar::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}

function TankMortar2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>Heavy Mortar: <F2>Mounted");
}
