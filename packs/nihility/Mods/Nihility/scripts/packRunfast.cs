//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[RunPack] = 1;

$ItemMax[larmor, RunPack] = 0;	//Seraph
$ItemMax[lfemale, RunPack] = 0;	//Seraph
$ItemMax[earmor, RunPack] = 0;	//Slave
$ItemMax[efemale, RunPack] = 0;	//Slave
$ItemMax[marmor, RunPack] = 1;	//Pawn
$ItemMax[aarmor, RunPack] = 0;	//Navigator
$ItemMax[darmor, RunPack] = 0;	//Atomizer
$ItemMax[barmor, RunPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData RunPackImage2 
{
	shapeFile = "mortarammo";//jetpack
	weaponType = 2;
	mountPoint = 2;
	mountOffset ={ 0.1, 0.02, 0 };
	mountRotation ={ -1.57, 0, 1.57 };
	minEnergy = 1;
	maxEnergy = 5;
	firstPerson = false;
};


ItemData RunPack2 
{
	description = "Molecular Accelerator";
	shapeFile = "mortarammo";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	hudIcon = "energyRifle";
	imageType = RunPackImage2;
	price = 33;
	showWeaponBar = true;
	showWeaponBar = false;
        showInventory = false;   
};

ItemImageData RunPackImage 
{
	shapeFile = "mortarammo";//jetpack
	weaponType = 2;
	mountPoint = 2;
	mountOffset ={ -0.1, 0.02, 0 };
	mountRotation ={ 1.57, 0, 1.57 };
	minEnergy = 20;
	maxEnergy = 20;
	firstPerson = false;
};


ItemData RunPack 
{
	description = "Molecular Accelerator";
	shapeFile = "mortarammo";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RunPackImage;
	price = 33;
	hudIcon = "energyRifle";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$RunPackSlotA = 4;

function RunPack::onMount(%player,%item)
{
	Player::mountItem(%player,RunPack2,$RunPackSlotA);

}

function RunPack::onUnmount(%player,%item)
{
   	Player::unmountItem(%player,$RunPackSlotA);	
}


function RunPackImage::onActivate(%player,%imageSlot,%client)
{

	Client::sendMessage(Player::getClient(%player),0,"Molecular Acceleration Engaged");
	%armor = Player::getArmor(%player); 
	%armor.maxForwardSpeed = %armor.maxForwardSpeed + 50;
	%armor.maxBackwardSpeed = %armor.maxBackwardSpeed + 50;
	%armor.maxSideSpeed = %armor.maxSideSpeed + 50;
}

function RunPackImage::onDeactivate(%player,%imageSlot,%client)
{
	
	Client::sendMessage(Player::getClient(%player),0,"Molecular Acceleration Shut Down");
	%armor = Player::getArmor(%player); 
	%armor.maxForwardSpeed = %armor.maxForwardSpeed - 50;
	%armor.maxBackwardSpeed = %armor.maxBackwardSpeed - 50;
	%armor.maxSideSpeed = %armor.maxSideSpeed - 50;
	
}


