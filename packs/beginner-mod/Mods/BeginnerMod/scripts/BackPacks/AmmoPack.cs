//-----------------------------------------
// AmmoPack.cs
// Dustin G Bruce
// August 9th, 2003 9:38pm
//-----------------------------------------
createBackPack(AmmoPack, 1, 1, 1, 1, 1);

ItemImageData AmmoPackImage {
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};
ItemData AmmoPack {
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

// Overhauled to work better with my AmmoPack::addAmmo(%item) function.
// Dustin B.
function AmmoPack::onDrop(%player, %item){
	//echo("AmmoPack::onDrop");
	if(!$matchStarted) return;
	%item = Item::onDrop(%player,%item);
	%item.portDropped = 1; // PORT (2026-10-12): a dropped pack carries only the ammo taken off the player below
	for(%i = 0; $AmmoPackItems[%i] != ""; %i = %i +1){
		%numPack = 0;
		%ammoItem = $AmmoPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum){
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player, %ammoItem, %numPack);
		}
		%item.portAmmo[%i] = %numPack;
	}
}
function AmmoPack::onCollision(%this, %object){
	if(getObjectType(%object) == "Player"){
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object, %item, Item::getCount(%this))){
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}
function checkPacksAmmo(%player, %item){
	//echo("checkPacksAmmo");
	for(%i = 0; $AmmoPackItems[%i] != ""; %i = %i +1){
		%ammoItem = $AmmoPackItems[%i];
		%numAdd = $AmmoPackMax[$AmmoPackItems[%i]];
		if(%item.portDropped) %numAdd = %item.portAmmo[%i]; // PORT (2026-10-12): a pack placed by the map still gives the full load
		echo("checkPacksAmmo: %numAdd = "@ %numAdd);
		Player::incItemCount(%player, %ammoItem, %numAdd);
	}						 
}
function fillAmmoPack(%client){
	//echo("fillAmmoPack");
	%player = Client::getOwnedObject(%client);
	for(%i = 0; $AmmoPackItems[%i] != ""; %i = %i +1){
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player, %item, %maxnum);
		if(%maxnum){
			Player::incItemCount(%client, %item, %maxnum);
			teamEnergyBuySell(%player, %item.price * %maxnum * -1);
		}	
	}
}