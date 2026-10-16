//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData ClonePackImage {
	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData ClonePack {
	description = "Droid";
	shapeFile = "ammopack";
	className = "Backpack";
	heading   = $InvHeading[oddnend];
	shadowDetailMask = 4;
	imageType = ClonePackImage;
	mass = 0.5;
	price = 400;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ClonePack::onUse(%player,%item)
{ if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function ClonePack::onDeploy(%player,%item,%pos)
{ if(DeployClone(%player, %item, marmor, Player, marmor)) { if(!Player::isDead(%player)){ Player::decItemCount(%player,%item); } } }

function DeployClone(%player, %item, %shape, %data, %name){
	%client = Player::getClient(%player);
	%cName  = Client::getName(%client);
	
	if(%client.droid){
		Client::sendMessage(%client, 0, "You greedy bastard, one clone is enough.");
		Player::decItemCount(%player, %item);
		BuyItem(%player, RepairPack);
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ "ClonePack"] >= $TeamItemMax["ClonePack"]){
		Client::sendMessage(%client, 0, "Maximum number of Clones deployed");
		Player::decItemCount(%player, %item);
		BuyItem(%player, RepairPack);
		return false;
	}
	
	if(GameBase::getLOSInfo(%player, 10)){
		// Just make sure this stays the same as the word below in the ::onDestroyed 
		// function
		%client.DroidType = "Clone";
		
		%client.droid = true;
		%client.guiLock = true;
		%client.inTransition = true;
		Schedule(%client @".inTransition = false;", 10.5);
		
		$DroidType = "Clone Droid";
		%droid = $DroidType;
		%armor = Player::getArmor(%player);
		
		%pos = $los::position;
		%rot = GameBase::getRotation(%player);
		%obj = newObject(marmor, Player, marmor, true);
		
		
		%client.newplayer = %obj;
		%client.oldPlayer = %player;
		
		%client.oldPlayer.shieldStrength = 9999;
		
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj, GameBase::getTeam(%player));
		GameBase::setPosition(%client.newplayer, %pos);
		GameBase::setRotation(%client.newplayer, %rot);
		
		
		GameBase::setDamageLevel(%obj, 0.99);
		GameBase::repairDamage(%obj, 0.99);
		%energy = GameBase::getEnergy(%obj);
		%energy = %energy - 400;
		if (%energy < 0)  %energy = 0;
		GameBase::setEnergy(%obj, %energy);
		GameBase::setRechargeRate(%obj, 42);
		
		Client::setControlObject(%client, Client::getObserverCamera(%client));
		Observer::setOrbitObject(%client, %client.newPlayer, 3, 3, 3);
		
		XBottomPrint(%client, "<jc><f1>"@ Client::getName(%client) @" Droid Status: \nUpload: <f2>%2 <f1>\nDroid Type: <f2>"@ $DroidType @"\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.", 1);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%10 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 0.5);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%15 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 1);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%21 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 2);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%38 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 3);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%45 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 4);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%51 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 4.5);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%63 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1);", 5);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%71 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 6);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%80 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 7);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%82 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 8);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%84 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 8.5);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%91 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 9);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>%99 <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 1.5);", 9.5);
		Schedule("XBottomPrint("@ %client @", \"<jc><f1>"@ escapeString(Client::getName(%client)) @" Droid Status: \\nUpload: <f2>Complete <f1>\\nDroid Type: <f2>"@ $DroidType @"\\n<f1>Press <f2>Ctrl-k <f1>to disable uplink to droid.\", 2);", 10);
		Client::sendMessage(%client, 0, "~wSensor_Deploy.wav");
		
		//Phase2 - Set new player to control
		Schedule("Client::setControlObject("@ %client @", "@ %client.newplayer @");", 10);
		Schedule("Client::setOwnedObject("@ %client @", "@ %client.newplayer @");", 10);
		Schedule("Client::sendMessage("@ %client @", 0, \"~wShell_Click.Wav\");", 10);
		Schedule("Player::MountItem("@ %client.newPlayer @", DoublePlasma2, $DoublePlasmaSlotA);", 10);
		Player::MountItem(%client.newPlayer, DoublePlasma, 0);
		
		//==============================================================
		//           SpawnList For Cloak Droid
		$DroidBuyList[%client, %droid, 0] = TRocketLauncher;
		$DroidBuyList[%client, %droid, 1] = DoublePlasma;
		$DroidBuyList[%client, %droid, 2] = LiLPOOMki;
		$DroidBuyList[%client, %droid, 3] = LiLPOOMkii;
		$DroidBuyList[%client, %droid, 4] = DiscLauncher;
		$DroidBuyList[%client, %droid, 5] = Mortar;
		$DroidBuyList[%client, %droid, 6] = Beacon;
		$DroidBuyList[%client, %droid, 7] = Grenade;
		$DroidBuyList[%client, %droid, 8] = RepairKit;
		$DroidBuyList[%client, %droid, 9] = LiLFFB;
		$DroidBuyList[%client, %droid, 10] = RepairPack;
		
		for(%x = 0; (%droidItem = $DroidBuyList[%client, %droid, %x]) != ""; %x++){
			if(%droidItem.classname == Weapon){
				Player::setItemCount(%client.newPlayer, %droidItem, $ItemMax[%armor, %droidItem]);
				Player::setItemCount(%client.newPlayer, $WeaponAmmo[%droidItem], $ItemMax[%armor, $WeaponAmmo[%droidItem]]);
			}
			else if(%droidItem.classname == BackPack) BuyItem(%client.newPlayer, %droidItem);
			else Player::setItemCount(%client.newPlayer, %droidItem, 999);
		}
		//==============================================================
		Client::sendMessage(%client, 0, %item.description @" deployed");
		$TeamItemCount[GameBase::getTeam(%player) @"ClonePack"]++;
		playSound(SoundPickupBackpack,$los::position);
		return true;
	}
	else
	{
		Client::sendMessage(%client, 0, "No, to far away... deploy closer.");
		return false;
	}
}

function Clone::onDestroyed(%this){
	%player = %this;
	%client = GameBase::getControlClient(%player);
	// Re-Set Client To His Original Body.
	Client::setControlObject(%client,%client.oldPlayer);
	Client::setOwnedObject(%client, %client.oldPlayer);
	%client.droid = false;
	%client.DroidType = "";
	%client.guiLock = false;
	%client.oldPlayer.shieldStrength = 0;
	GameBase::setDamageLevel(%player, 10);
	Schedule("deleteObject("@ %player @");", 5);
	$TeamItemCount[GameBase::getTeam(%player) @"ClonePack"]--;
	Client::sendMessage(%client, 0, "Connection To Your Clone Has Been Lost~wusepack.wav");
	XBottomPrint(%client, "<jc><f1>Connection To Your Clone Has Been Lost", 5);
}