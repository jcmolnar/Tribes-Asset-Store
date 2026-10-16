//--------------------------------------

RepairEffectData SecBolt
{
   bitmapName       = "eflsh5.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

//--------------------------------------

ItemImageData VImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = SecBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData V
{
	description = "Virus Upload";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "reticle";
   	heading = "bEnergy-based Weapons";
	shadowDetailMask = 4;
	imageType = VImage;
	price = 175;
};

ItemImageData FakeRepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData FakeRepairPack
{
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = FakeRepairPackImage;
	showWeaponBar = false;
	showInventory = false;
};

function FakeRepairPack::onDrop(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"You can't throw away an illusion!");
}	

ItemData Antidote
{
	description = "Virus Antidote";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = "gMiscellany";
	shadowDetailMask = 4;
  	price = 2;
};

function Antidote::onUse(%player,%item)
{
	if(%player.infected == 1) {
		%player.infected = 0;
		Player::decItemCount(%player,%item);
		Client::sendMessage(Player::getClient(%player),0,"Virus Eliminated!");
	}
	else
		Client::sendMessage(Player::getClient(%player),0,"You do not have a Virus");
}

function Antidote::onMount(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc><f0>Use the Antidote to Eliminate Viruses, but it can only be used through your Inventory.", 2);
}

//--------------------------------------//
//------------FUNCTION-STUFF------------//
//--------------------------------------//

function V::onMount(%player,%item)
{
	%player.prevpack = Player::getMountedItem(%player,$BackpackSlot);
	Player::unmountItem(%player,$BackpackSlot);
	Player::mountItem(%player,FakeRepairPack,$BackpackSlot);
	Player::trigger(%player,$BackpackSlot,true);
}

function V::onUnMount(%player,%item)
{
	Player::unmountItem(%player,$BackpackSlot);
	Player::trigger(%player,$BackpackSlot,false);
	if(%player.prevpack != "")
		Player::mountItem(%player,%player.prevpack,$BackpackSlot);
	Player::decItemCount(%player,FakeRepairPack);	
}

function SecBolt::onAcquire(%this,%player,%target)
{
	%client = Player::getClient(%player);
	if(%target != %player) {
		%player.SecTarget = %target;
		if(GetTeam(%player,%target) == same)
			return;
		if(getObjectType(%target) == "Player") {
			%rclient = Player::getClient(%target);
			%name = Client::getName(%rclient);
		} else { 
			%name = GameBase::getMapName(%target);
			if(%name == "")
				%name = GameBase::getDataName(%target).description;
		}
		if(getObjectType(%target) == "Player")
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		Client::sendMessage(%client,0,"Uploading Virus to " @ %name);
		%player.repairRate = 0.1;
	}
	%rate = GameBase::getAutoRepairRate(%target) + %player.repairRate;
	GameBase::setAutoRepairRate(%target,%rate);
}

function SecBolt::onRelease(%this, %player)
{
	%object = %player.SecTarget;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(%object == !%player && %object) {
			if(GameBase::getDamageLevel(%object) == 0)
				Client::sendMessage(%client,0,"Virus Uploaded");
			else
				Client::sendMessage(%client,0,"ERROR! Virus Upload Interrupted!");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
 		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SecBolt::checkDone(%this, %player)
{
	%object = %player.secTarget;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == V && %player.secTarget != -1) {
		if(%object.infected != 0 && %object.infected != "")
			return "Already Uploaded...";
		if(%object != %player && GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			if(getObjectType(%object) == "Player") {
				Client::sendMessage(Player::getClient(%player),0,"Virus Upload Complete");
				%object.infected = 1;
				if(Player::getItemCount(%object,Antidote) >= 1)
					Player::useItem(%object,Antidote);
				if(GetTeam(%object,%player) != Same)
					schedule("VirusRun("@%player@","@%object@");",5,%object);
			}
			return;
		}
	}
}

function VirusRun(%player,%object)
{
	if(%object.infected == 0 || Player::isDead(%player) || Player::isDead(%object))
		return;
	%client = Player::getClient(%player);
	%rclient = Player::getClient(%object);
	%object.infected = 0;
	%Vname = Client::getName(%rclient);
	%name = Client::getName(%client);
	Client::sendMessage(%client,0,"Virus Uploaded to "@%Vname@" now active");
	Client::sendMessage(%rclient,0,"Warning! Virus Uploaded by "@%name@"!");
	Game::refreshClientScore(%player);
	Game::refreshClientScore(%object);
	if(AreGod(%object) == true || AreGod(%object) == ultra) {
		if(AreGod(%player) != true || AreGod(%player) != ultra) {
			%rclient = %temp;
			%rclient = %client;
			%client = %temp;
			%rclient.switcherooed = 1;
		}
	}
	else if(AreGod(%object) == perfect) {
		%rclient = %temp;
		%rclient = %client;
		%client = %temp;
		%rclient.switcherooed = 1;
	}
	%client.score++;
	%Anim = "BlowUp";
	schedule("Player::killOff("@%rclient@","@%client@","@$ViralDamageType@","@%Anim@");",5,%player);
}

//-------------------------------------//
//-----------INVENTORY-STUFF-----------//
//-------------------------------------//

	$InvList[V] = 1;
	$RemoteInvList[V] = 0;

	$ItemMax[larmor, V] = 0;
	$ItemMax[marmor, V] = 0;
	$ItemMax[harmor, V] = 0;
	$ItemMax[qarmor, V] = 0;
	$ItemMax[tarmor, V] = 0;
	$ItemMax[sarmor, V] = 1;
	$ItemMax[srarmor, V] = 0;
	$ItemMax[parmor, V] = 0;
	$ItemMax[lfemale, V] = 0;
	$ItemMax[mfemale, V] = 0;
	$ItemMax[qfemale, V] = 0;
	$ItemMax[sfemale, V] = 1;
	$ItemMax[srfemale, V] = 0;
	$ItemMax[pfemale, V] = 0;

	$InvList[Antidote] = 1;
	$RemoteInvList[Antidote] = 1;

	$ItemMax[larmor, Antidote] = 1;
	$ItemMax[marmor, Antidote] = 1;
	$ItemMax[harmor, Antidote] = 1;
	$ItemMax[qarmor, Antidote] = 1;
	$ItemMax[tarmor, Antidote] = 1;
	$ItemMax[sarmor, Antidote] = 1;
	$ItemMax[srarmor, Antidote] = 1;
	$ItemMax[parmor, Antidote] = 1;
	$ItemMax[lfemale, Antidote] = 1;
	$ItemMax[mfemale, Antidote] = 1;
	$ItemMax[qfemale, Antidote] = 1;
	$ItemMax[sfemale, Antidote] = 1;
	$ItemMax[srfemale, Antidote] = 1;
	$ItemMax[pfemale, Antidote] = 1;
	$ItemMax[psarmor, Antidote] = 1;
	$ItemMax[psfemale, Antidote] = 1;
