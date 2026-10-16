$InvList[AmmoPack] = 1;
$RemoteInvList[AmmoPack] = 1;

$AmmoPackMulti = 0.5;

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Extra Memory";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[iEnha];
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if ($matchStarted) 
	{
		%item = Item::onDrop(%player,%item);
		%armor = Player::getArmor(%player);
		for (%i = 0; %i < $AmmoCount; %i++)
		{
			%ammo = $Ammo_Ammo[%i];
			%maxnum = $ItemMax[%armor, %ammo];
			%numPack = 0;
			%count = Player::getItemCount(%player, %ammo);
			if(%count > %maxnum) 
			{
				%numPack = %count - %maxnum;
				Player::decItemCount(%player, %ammo, %numPack);
			}
// Set the amount that is thrown with the pack
			$Item_Ammo[%item, %i] = %numPack;
		}
	}
}

function AmmoPack::onRemove(%this)
{
// Flush out the settings array (to conserve memory hopefully)
	for (%i = 0; %i < $AmmoCount; %i++) $Item_Ammo[%this, %i] = "";  
}

function AmmoPack::onCollision(%this, %object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object, %item);
		if (Item::giveItem(%object, %item, Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	%armor = Player::getArmor(%player);
	for (%i = 0; %i < $AmmoCount; %i++)
	{
		%packAmmo = $Item_Ammo[%item, %i];
		%ammo = $Ammo_Ammo[%i];
		%maxnum = $ItemMax[%armor, %ammo];
		%maxnum += floor(%maxnum * $AmmoPackMult);
		%count = Player::getItemCount(%player, %ammo);
		if(%count + %packAmmo > %maxnum) %packAmmo = %maxnum - %count + %packAmmo;
		Player::setItemCount(%player, %ammo, %packammo + %count);
	}
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	for (%i = 0; %i < $AmmoCount; %i++)
	{
		if($Ammo_Weapon[%i] != "HandAmmo")
		{
			if(!Player::getItemCount(%client, $Ammo_Weapon[%i])) continue;
		}
		%ammo = $Ammo_Ammo[%i];
		%extraAmmo = floor($ItemMax[%armor, %ammo] * $AmmoPackMulti);
		%extraAmmo += floor(%extraAmmo * %client.ammom);
		if (%extraAmmo) %delta = checkResources(%player, %ammo, %extraAmmo);
		if (%delta) 
		{
			teamEnergyBuySell(%player, %ammo.price * %delta * -1);
			Player::incItemCount(%client, %ammo, %delta);
		}
	}
}

function spawnFillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	for (%i = 0; %i < $AmmoCount; %i++)
	{
		if($Ammo_Weapon[%i] != "HandAmmo")
		{
			if(!Player::getItemCount(%client, $Ammo_Weapon[%i])) continue;
		}
		%ammo = $Ammo_Ammo[%i];
		%max = $ItemMax[%armor, %ammo];
		%extraAmmo = floor(%max * $AmmoPackMulti);
		%extraAmmo += floor(%extraAmmmo * %client.ammom);
		if (%extraAmmo) Player::setItemCount(%client, %ammo, %extraAmmo + %max);
	}
}