//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//   Modded
//  MPC/Coolant Pack : By HighTechRedneck (?)
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[MPCPack] = 1;
$RemoteInvList[MPCPack] = 1;

// Coolant Pack Pack

ItemImageData MPCPackImage
{
	shapeFile = "shieldPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;

	sfxFire = SoundShieldOn;
	firstPerson = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0, 0.25, 1 };
};

ItemData MPCPack
{
	description = "Coolant Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = MPCPackImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MPCPackImage::onDrop(%player,%item)
{
	if($matchStarted) {
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = false;
		
		if($RSP::MPCOldRate[%player] > 0)
		{
			GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
		}

		Client::sendMessage(Player::getClient(%player),0,"Coolant Pack dropped...");

		Item::onDrop(%player,%item);
	}
}

function MPCPackImage::onActivate(%player,%imageSlot)
{
	if(!$MPCUsed[%player]) {
		Client::sendMessage(Player::getClient(%player),0,"Coolant Pack On...");
		$MPCIsActive[%player] = true;

		$MPCUseTime[%player] = 100;
		$RSP::MPCOldRate[%player] = GameBase::getRechargeRate(%player);
		GameBase::setRechargeRate(%player,40);

		schedule("MPCPackCount(" @ $RSP::MPCPackChargeTime @ ", " @ %player @ ");", 1, %player);
	}
	else {
		Player::trigger(%player,$BackpackSlot,false);
		Client::sendMessage(Player::getClient(%player),0,"Coolant Pack must vent heat first");
		$MPCUsed[%player] = true;
		$MPCIsActive[%player] = false;
	}
}

function MPCPackImage::onDeactivate(%player,%imageSlot)
{
	
	%client = Player::getClient(%player);

	if(!$MPCUsed[%player] && !%client.dead) {
		GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
		Client::sendMessage(Player::getClient(%player),0,"Coolant Pack Off... Venting Heat...");
		Player::trigger(%player,$BackpackSlot,false);
	
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = true;

		if($RSP::MPCCoolAccordingToUse)
		{
			schedule("MPCPackCooling(" @ floor($MPCUseTime[%player] * 2) @ ", " @ %player @ ");", 1, %player);
		}
		else{
			schedule("MPCPackCooling(" @ $RSP::MPCPackCoolingTime @ ", "  @ %player @ ");", 1, %player);
		}
	}
	else {
		GameBase::setEnergy(%player, 0);
		Client::sendMessage(Player::getClient(%player),0,"Coolant Pack is not ready.");
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function MPCPackCount(%count, %player)
{
	if(!$matchStarted) return;

	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted != MPCPack) {
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = false;
		return;
	}
	
	if($MPCIsActive[%player] && !$MPCUsed[%player]) {
		if(%count == floor(($RSP::MPCPackChargeTime / 3) * 2))
			Client::sendMessage(Player::getClient(%player),1,"Coolant Pack heat normal...~wLeftMissionArea.wav");
		else if(%count == floor($RSP::MPCPackChargeTime / 3))
			Client::sendMessage(Player::getClient(%player),1,"Coolant Pack heat nearing critical...~wLeftMissionArea.wav");
		else if(%count == floor($RSP::MPCPackChargeTime / 6)) {
			Client::sendMessage(Player::getClient(%player),1,"Coolant Pack heat containment field shutdown...~wLeftMissionArea.wav");
			leaveMissionAreaDamage(Player::getClient(%player)); //Using this function instead of creating a new one to do the same thing
											 //Damages player due to heat from pack.
		}
		else if(%count < floor($RSP::MPCPackChargeTime / 6) && %count > 0)
			leaveMissionAreaDamage(Player::getClient(%player));
		else if(%count == 0 || %count < 0)
			Player::trigger(%player,$BackpackSlot,false);
		
		$MPCUseTime[%player]++;
		schedule("MPCPackCount( " @ %count - 1 @ ", " @ %player @ ");", 1, %player);
	}
}

function MPCPackCooling(%time, %player)
{
	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted == MPCPack)
	{
		if(%time > 0)
		{
			GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
			Player::trigger(%player,$BackpackSlot,false);
			schedule("MPCPackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
		}
		else if(%time == 0)
		{
			MPCReset(%player);
		}
	}
}

function MPCReset(%player)
{
	$MPCUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),1,"Coolant Pack has vented...");
}

