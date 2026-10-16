$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;


$ArmorType[Male, WWIIsoldier] = soldier;
$ArmorType[Female, WWIIsoldier] = soldier;

$ArmorName[soldier] = WWIIsoldier;

DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};


function remoteUseItem(%client,%type)
{
if($WWII::TraceClients) %client.remotecall++;
	//echo("Use item: " @ %type @ " " @ %item);
if(client::getownedobject(%client).parachute) return;	
%client.throwStrength = 1;

	%item = getItemData(%type);
	if(%item == Beacon) Beacon::onUse(client::getownedobject(%client));
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
if($WWII::TraceClients) %client.remotecall++;
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo) {
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
				
				}
		}
	}
}

function remoteDropItem(%client,%type)
{
if($WWII::TraceClients) %client.remotecall++;
	
}


exec(weaponchange);


function remoteNextWeapon(%client)
{
if($WWII::TraceClients) %client.remotecall++;
	//if(%client.isreloading) return;
	if(!%client.canchangeweapon) return;
	if(%client.frames >= 0) 
		{ 
		if(%client.frames > 10) 
			{
			%client.frames = -1;
			return;
			}
		%client.frames++;
		WWII::ModInfo(%client, %client.frames);
		return;
		} 
	if(client::getownedobject(%client) > 0 && !Player::isDead(client::getownedobject(%client)))
	if(Client::GetOwnedObject(%client).vehicle > 0) Vehicle::SwitchWeapon(%client);
	else WWII::WeaponChange(%client);
		
	
}

function remoteprevweapon(%cl) { remotenextweapon(%cl); }



function Item::giveItem(%player,%item,%delta)
{
	
}


//----------------------------------------------------------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else {
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if (Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else { 
		deleteObject(%this);
	}
}	

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	
}


//----------------------------------------------------------------------------
// Default Inventory methods

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
	//echo("Item used: ",%player," ",%item);
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	
}

function Item::onDeploy(%player,%item,%pos)
{
}


//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}


//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = true;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};


//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData WWIIsoldier
{
   heading = "aArmor";
	description = "Soldier";
	className = "Armor";
	price = 100;
};


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{

BottomPrint(player::getclient(%player), "<jc><f2>" @ %item.description @ "<f0>", 2,ITEMDESC);		
Player::mountItem(%player,%item,$WeaponSlot);	

}


//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
BottomPrint(player::getclient(%player), "<jc><f2>" @ %item.description @ "<f0>", 2,ITEMDESC);	
	Player::mountItem(%player,%item,$ToolSlot);
}



//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	
}	

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}




//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
if($WWII::TraceClients) %clientId.remotecall++;
centerprint(%clientId, "<jc>Fuck you!", 10);
}


//----------------------------------------------------------------------------


function Mission::reinitData()
{
}
