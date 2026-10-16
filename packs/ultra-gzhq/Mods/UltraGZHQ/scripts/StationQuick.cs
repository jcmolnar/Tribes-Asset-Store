//=========================
// new inventory methods here.. -plasmatic
// modifications in buyitem and remotebuyfavorites

function AddItem(%Item){
	//damn Dynamix for creating Functions within the .exe and not showing them to me... -plasmatic
	$Item += 1;
	$Itemlist[$Item] = %Item;
}

function QuickInv(%client)
{
	if($build || $UltraGZHQ::QuickInv || %Client.InvConnect)
	{
		%player = Client::getOwnedObject(%client);
		setupQuickShoppingList(%client);
		updateQuickBuyingList(%client);	
		//Client::sendMessage(%client,3,"::Connecting to Inventory System::");
	}
	
}


function QuickInvOff(%client)
{
	%player = Client::getOwnedObject(%client);
	Client::clearItemShopping(%client);
}

// function modified for annihilation from my sex mod code -plasmatic
function setupQuickShoppingList(%client,%station,%ListType)
{
	if($build || $UltraGZHQ::QuickInv || %Client.InvConnect)
	{	
		Client::clearItemShopping(%client);
		%armor = Player::getarmor(%client);
		%max = getNumItems();
		GameBase::playSound(%client, Sensor_Deploy, 0);
		for(%i = 0; %i < %max; %i = %i + 1) 
		{
			%item = $Itemlist[%i];
			if(%item != "") 
				{
				if($UltraGZHQ::ShoppingList)
				{
					if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && $ItemMax[%armor,%item] > 0) 
						Client::setItemShopping(%client, %item);
					else if(%item.className == Armor && !%station.dontSell[%item])
						Client::setItemShopping(%client, %item);
				}
				else
				{
					if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
						Client::setItemShopping(%client, %item);
					else if(%item.className == Armor && !%station.dontSell[%item])
						Client::setItemShopping(%client, %item);
				}
			}
		}
	}
}

// modified for annihilation mod from my sex mod code -plasmaic
function updateQuickBuyingList(%client)
{
	
	Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station);
	%energy = $TeamEnergy[Client::getTeam(%client)];
	Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);	
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	if($build || $UltraGZHQ::QuickInv || %Client.InvConnect)
	{
		for(%i = 0; %i < %max; %i++) 
		{
			%item = $Itemlist[%i];
			if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client,%item)) 
			{
				%extraAmmo = 0;
				if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
					%extraAmmo = $AmmoPackMax[%item];
				if($ItemMax[%armor, %item] != "" && $ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item)) 
				{
					if(%energy >= %item.price ) 
					{
						if($ItemMax[%armor,%item] > 0)
						{
							if(%item.className == Weapon) 
							{
								if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor]) 
									Client::setItemBuying(%client, %item);
							}
							else 
							{ 
								if($TeamItemMax[%item] != "") 
								{
									if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] || $build)
										Client::setItemBuying(%client, %item);
								}
								else
									Client::setItemBuying(%client, %item);
							}
						}
					}
				}
			}
			else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%item)) 
				Client::setItemBuying(%client, %item);
			else if(%item.className == Vehicle && ($TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] || $build) && Client::isItemShoppingOn(%client,%item))
				Client::setItemBuying(%client, %item);
		}
	}
}
