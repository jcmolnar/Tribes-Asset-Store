//Camopack.cs                                      -   Hider Packs

// by cd mod
ItemImageData CamopackImage
{
	shapeFile = "ammoPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	sfxFire = SoundShieldOn; 
	firstPerson = false;
};

ItemData Camopack
{
	description = "Land Camo";
	shapeFile = "cactus2";
	className = "Backpack";
  	heading = eBackpacks;
	shadowDetailMask = 4;
	imageType = CamopackImage;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
    showInventory = true;
};

function Camopack::onMount(%player,%item)
{	
	bottomprint(Player::getClient(%player), "<jc><f2>Camopack:<f1> makes you one with your surroundings\nNo Flag Carrying when activate", 3);
	%clientId = Player::GetClient(%player);
	%clientId.usedCamo = 0;
}

function CamopackImage::onActivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player); 
	%time = getIntegerTime(true) >> 5; // get time
	%delta = %clientId.usedCamo - %time;
	if (%delta > 0)
	{ 
		Client::sendMessage(%clientId, 0, "You must wait " @ %delta @ " seconds before using it again."); 
		CamopackImage::onDeactivate(%player,%imageSlot);
		return; 
	} 
	else
		Hideron(%player,CamopackTree); 
} 

function CamopackImage::onDeactivate(%player,%imageSlot)
{	
	Hideroff(%player);
	Player::trigger(%player,$BackpackSlot,false);
}

function Hideroff(%player) 
{ 
   %clientId = Player::getClient(%player); 
   if(!%clientId.ishiding) return; 
   %time = getIntegerTime(true) >> 5; // Time of occurance
   %clientId.usedcamo = %time + 10; // Change to whatever you want the pack delay to be
   %rate = Player::getSensorSupression(%player) - 3; 
   Player::setSensorSupression(%player,%rate); 
    
   %clientId.ishiding = false; 

   Client::sendMessage(%clientId, 0, "You are done blending in."); 

   Item::setVelocity(%player, %player.oldVel); 
   GameBase::setPosition(%player, $HiderPack::OldPos[%player]); 

   Client::setControlObject(%clientId, %player); 

	// Look for ppl observing this player
	for (%cl = client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl))
		if (%cl.observerTarget == %clientId)
		{
			//messageAll(5, %cl @ " is observing " @ %clientId @ " (From Cactus State) -- Switching to player observation");
			// Make them observe the person now
			Observer::setTargetClient(%cl, %clientId);
		}

    
   // You might wanna put this into a schedule, ie 
   schedule("deleteObject("@ %player.Sub @");", 0, %player.Sub); 
   // If %player.Sub isn't a valid object it will crash tribes, i learned that the hard way. 
   deleteObject(%player.Sub); 
   %player.Sub = "";

   %clientId.guiLock = false; 
   %clientId.Sub = false; 
} 

function Hideron(%player,%as)
{
	%clientId = Player::getClient(%player);
	%clientId.ishiding = True;
	%clientId.usedCamo = "";
	Client::sendMessage(%clientId, 0, "You are one with your environment.");
	%player.oldVel=item::getvelocity(%player);
	if(Player::getMountedItem(%player, $FlagSlot)=="flag")
	{
		%item = Player::getMountedItem(%clientId,$FlagSlot);
		Player::dropItem(%clientId,%item);
		Client::sendMessage(%clientId, 1, "Can't carry flag while Hiding!~werror_message.wav");
	}

	$HiderPack::OldPos[%player] = GameBase::getPosition(%player);
	%xPos = getword($HiderPack::OldPos[%player], 0);
	%yPos = getword($HiderPack::OldPos[%player], 1);
	%Pos = %xPos @" "@ %yPos @" -50000";
	GameBase::setPosition(%player, %Pos);

	%player.Sub = newObject("Player Substitution", "StaticShape", %as, true);
	%clientId.Sub = true;
	%player.Sub.Client = %clientID;
	GameBase::setPosition(%player.Sub, $HiderPack::OldPos[%player]);

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %player.Sub, 3, 3, 3);

	// Look for ppl observing this player
	for (%cl = client::getFirst(); %cl != -1; %cl = Client::GetNext(%cl))
		if (%cl.observerTarget == %clientId)
		{
			//messageAll(5, %cl @ " is observing " @ %clientId @ " (The Cactus) -- Switching to cactus observation");
			// Make them observe the cactus
			Observer::setOrbitObject(%cl, %player.Sub, 3, 3, 3);
		}

	%clientId.guiLock = true;

	Client::sendMessage(%clientId, 0, "Press the 'JUMP KEY' when you want to return!"); 
	//Centerprint(%clientId, "<jc><f0>Press the <f4>JUMP KEY <f0> when you want to return!", 5);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
}

$ItemMax[larmor, Camopack] = 1;
$ItemMax[lfemale, Camopack] = 1;
$InvList[Camopack] = 1;
