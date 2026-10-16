//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[GhostPack] = 1;

$ItemMax[larmor, GhostPack] = 1;	//Seraph
$ItemMax[lfemale, GhostPack] = 1;	//Seraph
$ItemMax[earmor, GhostPack] = 0;	//Slave
$ItemMax[efemale, GhostPack] = 0;	//Slave
$ItemMax[marmor, GhostPack] = 0;	//Pawn
$ItemMax[aarmor, GhostPack] = 0;	//Navigator
$ItemMax[darmor, GhostPack] = 0;	//Atomizer
$ItemMax[barmor, GhostPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


//Ghost Pack coding by Plasmatic ----- CHECK OUT SEX MOD!
//Most of this is Plasmatic's code - check with him before using it
//Go to www.zerovoid.net forums ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//edited by Auto


ItemData GhostFloorArmor
{
	heading = "aArmor";
        description = "Floor";
        className = "Armor";
        price = 175;
	showInventory = false;               
};

ItemData GhostArmor
{
	heading = "aArmor";
        description = "Walls";
        className = "Armor";
        price = 175;
	showInventory = false;               
};

ItemImageData GhostPackImage
{
        shapeFile = "breath";
        weaponType = 2; // Sustained

        mountPoint = 2;
//        mountOffset = { 0.07, 0.1, 0 };
//        mountRotation = { 0.7, 0, 0.65 };

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack2Image
{
        shapeFile = "armorkit";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { 0.1, 0, -0.25 };
        //mountRotation = { -0.6, 0, 0};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack3Image
{
        shapeFile = "armorkit";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { -0.1, 0, -0.25 };
        //mountRotation = { -0.6, 0, 0};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack4Image
{
        shapeFile = "armorkit";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { 0.15, 0, -0.25 };
        //mountRotation = { -0.6, 0, 0};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack5Image
{
        shapeFile = "armorkit";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { -0.15, 0, -0.25 };
        //mountRotation = { -0.6, 0, 0};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack6Image
{
        shapeFile = "repairgun";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { 0, -0.17, 0.27 };
        mountRotation = { 0.785, 3.14, 3.14};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack7Image
{
        shapeFile = "repairgun";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { 0, -0.17, 0.07 };
        mountRotation = { -0.785, 0, 3.14};

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

//ItemImageData GhostPackImage
//{
//        shapeFile = "breath";
//        weaponType = 2; // Sustained
//
//        mountPoint = 2;
////        mountOffset = { 0.07, 0.1, 0 };
////        mountRotation = { 0.7, 0, 0.65 };
//
//        minEnergy = 2.5;
//        maxEnergy = 2.5;
//        firstPerson = false;
//};
//
//ItemImageData GhostPack2Image
//{
//        shapeFile = "grenammo";
//        weaponType = 2; // Sustained
//
//        mountPoint = 2;
//        mountOffset = { 0.07, 0.1, 0 };
//        mountRotation = { 0.9, 0, 0.65 };
//
//        minEnergy = 2.5;
//        maxEnergy = 2.5;
//        firstPerson = false;
//};
//
//ItemImageData GhostPack3Image
//{
//        shapeFile = "grenammo";
//        weaponType = 2; // Sustained
//
//        mountPoint = 2;
//        mountOffset = { -0.07, 0.1, 0 };
//        mountRotation = { 0.9, 0, -0.65 };
//
//        minEnergy = 2.5;
//        maxEnergy = 2.5;
//        firstPerson = false;
//};
//
//ItemImageData GhostPack4Image
//{
//        shapeFile = "grenammo";
//        weaponType = 2; // Sustained
//
//        mountPoint = 2;
//        mountOffset = { 0, 0.1, 0 };
//        mountRotation = { 0.9, 0, 0};
//
//        minEnergy = 2.5;
//        maxEnergy = 2.5;
//        firstPerson = false;
//};

ItemData GhostPack
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPackImage;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

ItemData GhostPack2
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack2Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

ItemData GhostPack3
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack3Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

ItemData GhostPack4
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack4Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

ItemData GhostPack5
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack5Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

ItemData GhostPack6
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack6Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

ItemData GhostPack7
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack7Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

$GhostPackSlotA=4;
$GhostPackSlotB=7;
$GhostPackSlotC=6;


function GhostPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function GhostPack::onMount(%player,%item)
{
        //%player.shieldStrength = -0.052;
	Player::mountItem(%player,GhostPack2,$GhostPackSlotA);
	Player::mountItem(%player,GhostPack3,$GhostPackSlotB);


       // bottomprint(Player::getClient(%player), "<f1>Wraith Pack: <f2>**WARNING**<f0> Play nice Casper. <f2>**WARNING**<f1> ||BY Plasmatica||", 10);
}

function GhostPack::onUnmount(%player,%item)
{        

        Player::unmountItem(%player,$GhostPackSlotA);
	Player::unmountItem(%player,$GhostPackSlotB);
	Player::unmountItem(%player,$GhostPackSlotC);

        //%player.shieldStrength = 0.0;
}

function GhostPack::onUse(%player,%item, %slot)
{
%playerId = Player::getClient(%player);
%client = GameBase::getOwnerClient(%player);
if (Player::getMountedItem(%player,$BackpackSlot) != %item)
{
	
	if (!%client.GhostPack || %client.GhostPack == 0)
	{
	        bottomprint(%client, "<f1>Wraith Pack: <f2>**WARNING**<f0> Wall Mode <f2>**WARNING**<f1>", 2);
	}
	if (%client.GhostPack == 1)
	{
	        bottomprint(%client, "<f1>Wraith Pack: <f2>**WARNING**<f0> Floor Mode <f2>**WARNING**<f1>", 2);
	}
        Player::mountItem(%player,%item,$BackpackSlot);
        //bottomprint(Player::getClient(%player), "<f1>Wraith Pack: <f2>**WARNING**<f0> Play nice Casper. <f2>**WARNING**<f1> ||BY Plasmatic||", 10);
}
else
{
	if (!%player.ghoster)
	{
		%player.ghoster = true;
		 Player::trigger(%player,$BackpackSlot,true);
                schedule("Casper(" @ %player @ ");", 1);
                Client::sendMessage(Player::getClient(%player), 1, "Wraith Pack Activated");
                %c = Player::getClient(%player);
                %armor = Player::getArmor(%client);
                if (!%playerId.Ghostpack || %playerId.Ghostpack == 0)
		{
			bottomprint(Player::getClient(%player), "<jc><f2>Original, walk through wall, code by Plasmatic", 2);
			Player::unmountItem(%player,$GhostPackSlotA);
			Player::unmountItem(%player,$GhostPackSlotB);
			Player::mountItem(%player,GhostPack4,$GhostPackSlotA);
			Player::mountItem(%player,GhostPack5,$GhostPackSlotB);
			Player::mountItem(%player,GhostPack6,$GhostPackSlotC);
			Player::trigger(%player, 6, true);        		
			%energy = GameBase::getEnergy(%player);//<<<<<<<<<<<<<<<<<<<<<
			//%energy -= 6;
			%buyarmor = $ArmorType[Client::getGender(%client), GhostArmor];
               		 Player::setArmor(%client,%buyarmor);
                	Player::setItemCount(%client, $ArmorName[%armor], 0);
                	Player::setItemCount(%client, GhostArmor, 1);	
                	GameBase::setEnergy(%player,%energy);//<<<<<<<<<<<<<<<<<<<<<
		}
		else if (%playerId.Ghostpack == 1)
		{
			bottomprint(Player::getClient(%player), "<jc><f2>Original, walk through wall, code by Plasmatic", 2);
			Player::unmountItem(%player,$GhostPackSlotA);
			Player::unmountItem(%player,$GhostPackSlotB);
			Player::mountItem(%player,GhostPack4,$GhostPackSlotA);
			Player::mountItem(%player,GhostPack5,$GhostPackSlotB);
			Player::mountItem(%player,GhostPack7,$GhostPackSlotC);
			Player::trigger(%player, 6, true);
			%energy = GameBase::getEnergy(%player);//<<<<<<<<<<<<<<<<<<<<<
			//%energy -= 6;
			%buyarmorfloor = $ArmorType[Client::getGender(%client), GhostFloorArmor];
                	Player::setArmor(%client,%buyarmorfloor);
               	 	Player::setItemCount(%client, $ArmorName[%armor], 0);
                	Player::setItemCount(%client, GhostFloorArmor, 1);
               		GameBase::setEnergy(%player,%energy);//<<<<<<<<<<<<<<<<<<<<<	
		}
        }
        else
        {
		Player::unmountItem(%player,$GhostPackSlotA);
		Player::unmountItem(%player,$GhostPackSlotB);
		Player::unmountItem(%player,$GhostPackSlotC);
		Player::mountItem(%player,GhostPack2,$GhostPackSlotA);
		Player::mountItem(%player,GhostPack3,$GhostPackSlotB);
		Player::trigger(%player, 6, false);  
        	%energy = GameBase::getEnergy(%player);//<<<<<<<<<<<<<<<<<<<<<
		//%energy -= 6;
        	%player.Ghoster = false;
        	Player::trigger(%player,$BackpackSlot,false);
        	%c = Player::getClient(%player);
        	gamebase::setautorepairrate(client::getownedobject(%c), 0.0);
                Client::sendMessage(Player::getClient(%player), 1, "Wraith Pack Deactivated");
        	%armor = Player::getArmor(%client);
      		%buyarmor = $ArmorType[Client::getGender(%client), lightArmor];
        	Player::setArmor(%client,%buyarmor);
        	Player::setItemCount(%client, $ArmorName[%armor], 0);
        	Player::setItemCount(%client, lightArmor, 1); 
                GameBase::setEnergy(%player,%energy);//<<<<<<<<<<<<<<<<<<<<<	
        }
}
}


function Casper (%player)
{
	if (%player.ghoster)
	{
		Player::setDamageFlash(%player,0.2);
                %c = Player::getClient(%player);
                %name = Client::getName(%c);
                %dlevel = GameBase::getDamageLevel(%player) + 0.03;
                GameBase::setDamageLevel(%player,%dlevel);
                if(Player::isDead(%player))
                {
                	//GameBase::setPosition(%client,"0 0 10000");
                	Messageall(0,%name@" is truly a ghost now");
                	playNextAnim(%player);
                	%player.Ghoster = false;
                }
                schedule("Casper(" @ %player @ ");", 1);
	}
}

//-----------------------