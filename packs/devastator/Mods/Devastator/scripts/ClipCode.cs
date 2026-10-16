//--------------------------------------------------------------------------------------------------//|
//**************************************<>-|==CLIP==CODE==|-<>**************************************//|____________________________________________
//--------------------------------------------------------------------------------------------------//                                             \
// THIS CODE IS USED TO CREATE THE USE OF AMMO MAGAZINES IN GAME, ANYONE WHO STEALS, OR USES THIS CODE WITHOUT MY PERMISSION WILL BE SHOT AND EATEN |
//_________________________________________________________________________________________________________________________________________________/
// COPYRIGHT 2002 "CT(R)" //|
//------------------------//|
// Ice / FishinSC@aol.com //|
//==========================|

//-The Magazine's Attributes

//>-Defines what Magazine each gun uses
$Clip[AR] = AssaultClip;
$Clip[SP] = PistolClip;
$Clip[SR] = SniperClip;
$Clip[Shotgun1] = ShotgunClip;

//>-Defines the Magazine's size
$ClipSize[AR] = 30;
$ClipSize[SP] = 8;
$ClipSize[SR] = 5;
$ClipSize[Shotgun1] = 2;

//>-Defines how long the gun takes to switch magazines 
$ClipTime[AR] = 2.5;
$ClipTime[SP] = 1.4;
$ClipTime[SR] = 1.9;
$ClipTime[Shotgun1] = 2.5;

ItemData Clip
{
	description = "Clip";
	showInventory = false;
};

function Clip::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		if(%count > 0) {
			%obj = newObject("","Item",%item,1,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Clip::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	%clip = $Clip[%weapon];
	if(%weapon != "") {
		if(Player::getItemCount(%player,%weapon) != 0) {
			if(%Clip != "") {
				if(Player::getItemCount(%player, %Clip) > 0)
					schedule("Reload("@%player@","@%weapon@",$ClipTime["@%weapon@"]);",0.5,%player);
				else
					bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
			}
		}
	}
}

function Reload(%player,%weapon,%RDPer)
{
	%client = Player::getclient(%player);
	$Reloading[%client] = 1;
	//Player::unMountItem(%player, %weapon);
	if(%weapon == Shotgun1) { //-Shotgun Shell Loading Sequence
		schedule("GameBase::playSound("@%player@",SoundPickupHealth,"@0@");",%RDPer*2/3,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupHealth,"@0@");",%RDPer*1/3,%player);
	}
	else if(%weapon == AR) { //-Assault Rifle Clip Swap Sequence
		schedule("GameBase::playSound("@%player@",SoundPDAButtonSoft,"@0@");",%RDPer/3,%player);
		schedule("GameBase::playSound("@%player@",SoundButton3,"@0@");",%RDPer/3+0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundButton4,"@0@");",%RDPer/3+0.2,%player);
		schedule("GameBase::playSound("@%player@",SoundButton5,"@0@");",%RDPer/3+0.3,%player);
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer/3+0.4,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupAmmo,"@0@");",%RDPer*2/3-0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupBackpack,"@0@");",%RDPer*2/3,%player);
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer*2/3+0.1,%player);
	}
	else if(%weapon == SR) { //-Sniper Rifle Clip Swap Sequence
		schedule("GameBase::playSound("@%player@",SoundWeaponSelect,"@0@");",%RDPer/3,%player);
		schedule("GameBase::playSound("@%player@",SoundButton5,"@0@");",%RDPer/3+0.1,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupAmmo,"@0@");",%RDPer/2,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupWeapon,"@0@");",%RDPer/2+0.5,%player);
	}	
	schedule("Player::setAnimation("@%player@"," @21@");", %RDPer-1.13);
	schedule("Player::setItemCount("@%player@"," @%weapon.imageType.ammoType@"," @$ClipSize[%weapon]@");",%RDPer);
	//schedule("Player::MountItem("@%player@ "," @%weapon@ "," @$WeaponSlot@ ");",%RDPer);
	ReloadProgress(%client,%RDPer,-10); //-Start at -10 so that it adds to start at 0
	Player::decItemCount(%player, $Clip[%weapon]);
	schedule("$Reloading["@%client@"] = 0;",%RDPer++);
}

function ReloadProgress(%client,%time,%prog)
{
	if(%prog < 100) {
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%"@%prog+=10,%time/5);
		schedule("ReloadProgress("@%client@","@%time@","@%prog@");",%time/10);
	}
	else
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%100",1);
}

function Weapon::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	if(%player.Station == "") {
		%ammo = %item.imageType.ammoType;
		Player::mountItem(%player,%item,$WeaponSlot);
		Weapon::descriptionMSG(%client,%item);
		if(%ammo < 0 && $Clip[%item] < 0)
			bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
		if(%ammo < 0 && $Clip[%item] > 0)
			Player::useItem(%player,$Clip[%item]);
	}
}

function Weapon::descriptionMSG(%clientId,%item,%type)
{
	%armor = Player::getarmor(%clientId);
	if(%type == "OnBuy" && $ShowWeapBuyMsg[%clientId] == true && $Purchased[%clientId,%item] != true && Player::getitemcount(%clientId,%item) != $ItemMax[%armor, %item]) {
		%ClassName = %item.ClassName;
		if(%classname == Armor) {
			$TotalPurchaseAMR[%clientId] = $WeapBuyMSG[%item];
		}
		else if(%classname == "Weapon" || %classname == "Tool") {
			$TotalPurchaseWPN[%clientId] = $TotalPurchaseWPN[%clientId]@$WeapBuyMSG[%item];
		}
		else if(%classname == "Backpack") {
			$TotalPurchasePCK[%clientId] = $WeapBuyMSG[%item];
		}
		else if(%classname == "HandAmmo" || %item == RepairKit || %item == Antidote) {
			$TotalPurchaseMSC[%clientId] = $TotalPurchaseMSC[%clientId]@$WeapBuyMSG[%item];
		}
		$Purchased[%clientId,%item] = true;
		$PurchaseRun[%clientId]++;
		%CurNum = $PurchaseRun[%clientId];
		$PurchasedIt[%clientId,%CurNum] = %item;
		$PurchaseMax[%clientId] = $PurchaseRun[%clientId];
		$PurchasedClassUsed[%classname] = "\n";
		$TotalPurchaseMSG[%clientId] = $TotalPurchaseAMR[%clientId]@$PurchasedClassUsed[Armor]@$TotalPurchaseWPN[%clientId]@$PurchasedClassUsed[Weapon]@$PurchasedClassUsed[Weapon]@$TotalPurchasePCK[%clientId]@$PurchasedClassUsed[BackPack]@$PurchasedClassUsed[BackPack]@$TotalPurchaseMSC[%clientId]@"\n<f1>Have a Nice Day!";
	}
	else {
		if(!%clientId.ReadingInvReceipt && !$SinglePlayer && $Reloading[%client] != 1 && $ShowWeapMountMsg[%clientId] != false) {
			if($FireModes[%item] == "")
				bottomprint(%clientId,"<jc>"@$WeapMountMSG[%item],3);
			else {
				%CurMode = $WeapMode[%clientId,%item];
				if(%CurMode == "")
					%CurMode = 1;
				bottomprint(%clientId,"<jc>"@$WeapMountMSG[%item,%CurMode],3);
			}
		}
	}
}

function Weapon::ShowOnBuyMSGlist(%clientId)
{
	if($TotalPurchaseMSG[%clientId] != "") {
		%clientId.ReadingInvReceipt = true;
		Centerprint(%clientId,"<jc><f6>Your Purchases:\n\n"@$TotalPurchaseMSG[%clientId], 5);
	}
	Reset::InventoryOnBuyList(%clientId);
	schedule(%clientId@".ReadingInvReceipt = "@false@";",5,%clientId);
}

function Reset::InventoryOnBuyList(%clientId)
{
	for(%i = 0; %i < $PurchaseMax[%clientId]; %i++) {
		if($PurchasedIt[%clientId,%i]) {
			%item = $PurchasedIt[%clientId,%i];
			$Purchase[%clientId,%item] = "";
		}
		else
			return;
	}
	$PurchaseMax[%clientId] = 0;
	$PurchaseRun[%clientId] = 0;
	$TotalPurchaseAMR[%clientId] = "";
	$TotalPurchaseWPN[%clientId] = "";
	$TotalPurchasePCK[%clientId] = "";
	$TotalPurchaseMSC[%clientId] = "";
	$TotalPurchaseMSG[%clientId] = "";
	deleteobject($TotalPurchaseMSG[%clientId]);
	$PurchasedClassUsed[Armor] = "";
	$PurchasedClassUsed[Weapon] = "";
	$PurchasedClassUsed[BackPack] = "";
	$PurchasedClassUsed[HandAmmo] = "";
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	%clip = $Clip[%itemType];
	if(%clip != "") {
		%clipCount = Player::getItemCount(%player,%clip);
		if(%clipCount > 0)
			Player::useItem(%player,%clip);
		else
			bottomprint(Player::getClient(%player), "<jc><f0>Out of Clips!!!", 2);
	}
}

//-The Magazine's Image

ItemData AssaultClip
{
        description = "Assault-Rifle Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 30;
};

ItemData PistolClip
{
        description = "Pistol Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 10;
};

ItemData SniperClip
{
        description = "Sniper-Rifle Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 20;
};

ItemData ShotgunClip
{
        description = "Shotgun Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 25;
};

//-Just the Inventory Stuff
$ItemMax[larmor, AssaultClip] = 1;
$ItemMax[qarmor, AssaultClip] = 2;
$ItemMax[srarmor, AssaultClip] = 1;
$ItemMax[sarmor, AssaultClip] = 8;
$ItemMax[marmor, AssaultClip] = 8;
$ItemMax[parmor, AssaultClip] = 8;
$ItemMax[harmor, AssaultClip] = 8;
$ItemMax[tarmor, AssaultClip] = 8;
$ItemMax[psarmor, AssaultClip] = 8;
$ItemMax[psfemale, AssaultClip] = 8;
$ItemMax[lfemale, AssaultClip] = 1;
$ItemMax[qfemale, AssaultClip] = 2;
$ItemMax[srfemale, AssaultClip] = 1;
$ItemMax[sfemale, AssaultClip] = 8;
$ItemMax[mfemale, AssaultClip] = 8;
$ItemMax[pfemale, AssaultClip] = 8;
$InvList[AssaultClip] = 1;

$ItemMax[larmor, PistolClip] = 3;
$ItemMax[qarmor, PistolClip] = 5;
$ItemMax[srarmor, PistolClip] = 8;
$ItemMax[sarmor, PistolClip] = 5;
$ItemMax[marmor, PistolClip] = 5;
$ItemMax[parmor, PistolClip] = 5;
$ItemMax[harmor, PistolClip] = 5;
$ItemMax[tarmor, PistolClip] = 5;
$ItemMax[psarmor, PistolClip] = 5;
$ItemMax[psfemale, PistolClip] = 5;
$ItemMax[lfemale, PistolClip] = 3;
$ItemMax[qfemale, PistolClip] = 5;
$ItemMax[srfemale, PistolClip] = 8;
$ItemMax[sfemale, PistolClip] = 5;
$ItemMax[mfemale, PistolClip] = 5;
$ItemMax[pfemale, PistolClip] = 5;
$InvList[PistolClip] = 1;

$ItemMax[larmor, SniperClip] = 3;
$ItemMax[qarmor, SniperClip] = 5;
$ItemMax[srarmor, SniperClip] = 10;
$ItemMax[sarmor, SniperClip] = 5;
$ItemMax[marmor, SniperClip] = 5;
$ItemMax[parmor, SniperClip] = 5;
$ItemMax[harmor, SniperClip] = 20;
$ItemMax[tarmor, SniperClip] = 20;
$ItemMax[psarmor, SniperClip] = 20;
$ItemMax[psfemale, SniperClip] = 20;
$ItemMax[lfemale, SniperClip] = 3;
$ItemMax[qfemale, SniperClip] = 5;
$ItemMax[srfemale, SniperClip] = 10;
$ItemMax[sfemale, SniperClip] = 5;
$ItemMax[mfemale, SniperClip] = 5;
$ItemMax[pfemale, SniperClip] = 5;
$InvList[SniperClip] = 1;

$ItemMax[larmor, ShotgunClip] = 3;
$ItemMax[qarmor, ShotgunClip] = 5;
$ItemMax[srarmor, ShotgunClip] = 5;
$ItemMax[sarmor, ShotgunClip] = 10;
$ItemMax[marmor, ShotgunClip] = 5;
$ItemMax[parmor, ShotgunClip] = 5;
$ItemMax[harmor, ShotgunClip] = 20;
$ItemMax[tarmor, ShotgunClip] = 20;
$ItemMax[psarmor, ShotgunClip] = 20;
$ItemMax[psfemale, ShotgunClip] = 20;
$ItemMax[lfemale, ShotgunClip] = 3;
$ItemMax[qfemale, ShotgunClip] = 5;
$ItemMax[srfemale, ShotgunClip] = 5;
$ItemMax[sfemale, ShotgunClip] = 10;
$ItemMax[mfemale, ShotgunClip] = 5;
$ItemMax[pfemale, ShotgunClip] = 5;
$InvList[ShotgunClip] = 1;