$InvList[Fixit] = 1;
$MobileInvList[Fixit] = 1;
$RemoteInvList[Fixit] = 1;

$AutoUse[Fixit] = False;
$FixitSlot = 4;

addWeapon(Fixit);

$FixitSlotA=4;

ItemImageData FixitImage 
{
	shapeFile = "shotgunbolt";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, 0.05, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit 
{
	description = "Builder Repair-Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FixitImage;
	price = 50;
	showWeaponBar = true;
};


//=====================
// Added image by: Arma
//=====================
ItemImageData Fixit3Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0.075, 0, 0.065 };
	mountRotation = { 0, 1.047, 0 };
};

ItemData Fixit3
{
	description = "Fixit3";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = Fixit3Image;
	showWeaponBar = false;
};
//===========================

//=====================
// Added image by: Arma
//=====================
ItemImageData Fixit4Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { -0.075, 0, 0.065 };
	mountRotation = { 0, -1.047, 0 };
};

ItemData Fixit4
{
	description = "Fixit4";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = Fixit4Image;
	showWeaponBar = false;
};
//===========================

ItemImageData FixitImage2 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.065 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 2;
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit2
{
	description = "Super Repair-Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FixitImage2;
	showWeaponBar = true;
	showInventory = false;
	Price = 0;
};

function FixitImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Player::trigger(%player,$FixitSlotA,true);
	if(!$FiringFixit[%client]) CheckFixit(%client, %player); 
}

function Fixit::onDrop(%player,%item) 
{
	%state = Player::getItemState(%player,$WeaponSlot); 
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, Fixit2, 0); 
		Item::onDrop(%player,%item); 
	}
}


function Fixit::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,Fixit2,$FixitSlotA);
	Player::mountItem(%player,Fixit3,6);
	Player::mountItem(%player,Fixit4,7); 
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Super Repair Gun: <f2>Mounted");
}

function Fixit::onUnmount(%player,%imageSlot) 
{
	Player::unmountItem(%player,$FixitSlotA);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function CheckFixit(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Fixit")) 
	{
		Player::trigger(%player,$FixitSlotA,true);
		schedule("CheckFixit(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringFixit[%client] = true; 
	}
	else 
	{
		Player::trigger(%player,$FixitSlotA,false); 
		$FiringFixit[%client] = false; 
	}
}

function ixCheckFixit(%client, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Fixit"))
	{
		Player::trigger(%player,$FixitSlot,true);
		Player::trigger(%player,$Fixit2SlotA,true);
		schedule("ixCheckFixit(" @ %client @ "," @ %player @ ");",0.1);
		$ixFiringFixit[%client] = true;
		$ixFiringFixit2[%client] = true;
	}
	else
	{
		Player::trigger(%player,$FixitSlot,false);
		$ixFiringFixit[%client] = false;
		$ixFiringFixit2[%client] = false;
	}
}
