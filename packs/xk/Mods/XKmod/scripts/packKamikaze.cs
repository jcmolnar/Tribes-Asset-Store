$InvList[KamikazePack] = 1;
$RemoteInvList[KamikazePack] = 1;

//RSP Globals
$KamikazeIsActive[0] = "false";
// End

//-------------------------------------
// Kamikaze Pack - RSP - HR
//-------------------------------------
ItemImageData KamikazePackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;
	sfxFire = SoundJammerOn;
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
	weaponType = 2;  // Sustained
    	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
	lightType = 2;   // Pulsing
	lightRadius = 6;
	lightTime = 1.5;
	lightColor = { 0.75, 0.15, 0.15 };
};

ItemData KamikazePack
{
	description = "Kamikaze Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
  	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = KamikazePackImage;
	price = 300;
	hudIcon = "grenade";
	showWeaponBar = true;
	hiliteOnActive = true;
	//lightType = 2;   // Pulsing
	//lightRadius = 8;
	//lightTime = 1.5;
	//lightColor = { 0.75, 0.15, 0.15 };
};

function KamikazePackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Kamikaze Pack Initialized. 30 seconds till detonation!");
	$KamikazeIsActive[%player] = "true";
	KamikazePackCount(30, %player);
}

function KamikazePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	$KamikazeIsActive[%player] = "false";
}

function KamikazePack::onDrop(%player,%item)
{
	if($matchStarted) {
		if($KamikazeIsActive[%player]) {
			$KamikazeIsActive[%player] = "false";
		
			Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack dropped. Countdown terminated!");
		}

		Item::onDrop(%player,%item);
	}
}

function KamikazePackCount(%count, %player)
{
	if(!$matchStarted) return;

	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted != KamikazePack){
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack not located. Countdown terminated!");
		$KamikazeIsActive[%player] = false;
		return;
	}
		
	if(%count && $KamikazeIsActive[%player]) {
		if(%count == 15)
			Client::sendMessage(Player::getClient(%player),1,"15");
		if(%count == 5)
			Client::sendMessage(Player::getClient(%player),1,"5");
		if(%count == 4)
			Client::sendMessage(Player::getClient(%player),1,"4");
		if(%count == 3)
			Client::sendMessage(Player::getClient(%player),1,"3");
		if(%count == 2)
			Client::sendMessage(Player::getClient(%player),1,"2");
		if(%count == 1)
			Client::sendMessage(Player::getClient(%player),1,"1");

		%count -= 1;
		schedule("KamikazePackCount('" @ %count @ "','" @ %player @ "');", 1);
	}
	else if($KamikazeIsActive[%player])
	{
		if($KamikazeIsActive[%player]) {
			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,5,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-5,false);
		}
		$KamikazeIsActive[%player] = "false";
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack deactivated. Countdown terminated!");
	}
}
