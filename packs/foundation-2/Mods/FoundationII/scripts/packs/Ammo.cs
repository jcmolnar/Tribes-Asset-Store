//--------------------------------------

addToInv(AmmoPack,1,1);

setArmorItemMax(AmmoPack,1,1,1);
//--------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = $InvCatPacks;
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$MountMSG[AmmoPack] = "<JC><F2>Ammo Pack <F0>- <F1>Allows you to carry more ammo.";

function AmmoPack::onMount(%player, %item)
{
	%player.apdrop = true;
}

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $APINum ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			$NumInAP[%item,%ammoItem] = %numPack;
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	%armor = $ArmorName[Player::getArmor(%player)];
	for(%i = 0; %i < $APINum ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%ammoItem == Beacon && $NumInAP[%item,%ammoItem] > $APBeaconMax[%armor])
			Player::incItemCount(%player,%ammoItem,$APBeaconMax[%armor]);
		else if(%ammoItem == Grenade && $NumInAP[%item,%ammoItem] > $APGrenadeMax[%armor])
			Player::incItemCount(%player,%ammoItem,$APGrenadeMax[%armor]);
		else
			Player::incItemCount(%player,%ammoItem,$NumInAP[%item,%ammoItem]);
	}
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = $ArmorName[Player::getArmor(%player)];
	for(%i = 0; %i < $APINum ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		if(%item == Beacon)
			%maxnum = $APBeaconMax[%armor];
		else if(%item == Grenade)
			%maxnum = $APGrenadeMax[%armor];
		else
			%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum);
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//--------------------------------------
