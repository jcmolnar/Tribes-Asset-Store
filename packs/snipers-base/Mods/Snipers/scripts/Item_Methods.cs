exec(Item_Events);
//-----------------------------------------------
//
//	ITEM METHODS
//
//-----------------------------------------------
// Default Item object methods

function Item::giveItem(%player,%item,%delta) 
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) 
	{
		%client = Player::getClient(%player);
		if (%item.className == Backpack) 
		{
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) 
			{
				Player::incItemCount(%player,%item);
				Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
				return 1;
				}
			}
		else 
		{
		if (%item.className == Weapon) 
		{
			if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) return 0;
		}
		%extraAmmo = 0 ;
		if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") %extraAmmo = $AmmoPackMax[%item];
		%count = Player::getItemCount(%player,%item);
		if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
		if (%delta > 0) 
		{
			Player::incItemCount(%player,%item,%delta);
			if (%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item);
			Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
			return %delta;
			}
		}
	}
  	return 0;
}

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
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
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
	if($matchStarted) 
	{
		if(%item.className != Armor) 
		{
			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
			GameBase::throw(%obj,%player,10,true);
			else
			{
			GameBase::throw(%obj,%player,15,false);
			Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
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