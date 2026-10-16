//----------------------------------------------------------------------------
// Centurion Armor
//----------------------------------------------------------------------------

$MaxWeapons[carmor] = 4;

//----------------------------------------------------------------------------
// Centurion Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[cfemale] = 4;

//------------------------------------------------------------------
// Centurion armor data:
//------------------------------------------------------------------

PlayerData carmor
{
   className = "Armor";
   shapeFile = "marmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 19.5;
   minJetEnergy = 1;
   jetForce = 278;
   jetEnergyDrain = 0.9;

	maxDamage = 0.83;
   maxForwardSpeed = 9.5;
   maxBackwardSpeed = 8.5;
   maxSideSpeed = 8.5;
   groundForce = 37.5 * 11.0;
   mass = 11.0;
   groundTraction = 3.0;
	maxEnergy = 70;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 92.5;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]	= { "root", none, 1, true, true, true, false, 0 };
   animData[1]	= { "run", none, 1, true, false, true, false, 3 };
   animData[2]	= { "runback", none, 1, true, false, true, false, 3 };
   animData[3]	= { "side left", none, 1, true, false, true, false, 3 };
   animData[4]	= { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundELFIdle;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Centurion female data:
//------------------------------------------------------------------

PlayerData cfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 19.5;
   minJetEnergy = 1;
   jetForce = 278;
   jetEnergyDrain = 0.9;

	maxDamage = 0.83;
   maxForwardSpeed = 9.5;
   maxBackwardSpeed = 8.5;
   maxSideSpeed = 8.5;
   groundForce = 37.5 * 11.0;
   mass = 11.0;
   groundTraction = 3.0;
	maxEnergy = 70;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 92.5;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]	= { "root", none, 1, true, true, true, false, 0 };
   animData[1]	= { "run", none, 1, true, false, true, false, 3 };
   animData[2]	= { "runback", none, 1, true, false, true, false, 3 };
   animData[3]	= { "side left", none, 1, true, false, true, false, 3 };
   animData[4]	= { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };

   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundELFIdle;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//--------------------------------------

$ArmorType[Male, CenturionArmor] = carmor;
$ArmorName[carmor] = CenturionArmor;

$ArmorType[Female, CenturionArmor] = cfemale;
$ArmorName[cfemale] = CenturionArmor;

$APBeaconMax[CenturionArmor] = 4;
$APGrenadeMax[CenturionArmor] = 5;

$ContactMSG[CenturionArmor] = "Reduce Status Effects";
$BeaconMSG[CenturionArmor] = "Rocket Booster";
$MineMSG[CenturionArmor] = "Cloaked Mine";
$GrenadeMSG[CenturionArmor,1] = "Concussion Grenade";
$GrenadeMSG[CenturionArmor,2] = "Napalm Grenade";
$GrenadeMSG[CenturionArmor,3] = "EMP Grenade";

$PunchPower[CenturionArmor] = 0.7;
//--------------------------------------

ItemData CenturionArmor
{
   heading = $InvCatArmors;
	description = "Centurion";
	className = "Armor";
	price = 200;
};

//--------------------------------------

function CenturionArmor::onGrenade(%player,%item)
{
	Player::decItemCount(%player,%item);
	%client = Player::getClient(%player);
	if($WeapMode[%client,GrenadeLauncher] == 1 || $WeapMode[%client,GrenadeLauncher] < 1 || $WeapMode[%client,GrenadeLauncher] == "")
		%obj = newObject("","Mine","Handgrenade");
	else if($WeapMode[%client,GrenadeLauncher] == 2)
		%obj = newObject("","Mine","FireNade");
	else if($WeapMode[%client,GrenadeLauncher] == 3 || $WeapMode[%client,GrenadeLauncher] > $FireModes[GrenadeLauncher])
		%obj = newObject("","Mine","EMPNade");
	addToSet("MissionCleanup", %obj);
//	  Player::setAnimation(%player, 21);
//	  schedule("GameBase::throw(" @ %obj @ "," @ %player @ ",9 * " @ %client.throwStrength @ ",false);",0.8);
	GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
	%player.throwTime = getSimTime() + 0.5;
}

function CenturionArmor::onBeacon(%player,%item)
{
	CheckBooster(%player,%item);
}

function CenturionArmor::onMine(%player,%item)
{
	Player::decItemCount(%player,%item);
	%obj = newObject("","Mine","CloakMine");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam(%obj,GameBase::getTeam(%client));
}

function CenturionArmor::onContact(%player,%object)
{
	if(TeamCompare(%player,%object) == Same) {
		Repair::checkStatus(%object,5);
		GameBase::playSound(%object, SoundPickupHealth, 0);
	}
	else if($Apocalypse::SlugFest)
		Normal::Punch(%player,%object);
}

function CenturionArmor::onRepair(%player,%item)
{
	if(GameBase::getDamageLevel(%player)) {
		Player::decItemCount(%player,%item);
		GameBase::repairDamage(%player,0.2);
		Repair::checkStatus(%player,5);
	}
}

//modified booster from Annihilation mod
function CheckBooster(%player, %item)
{
	if(%player.usedbeacon) {
		if($ArmorName[Player::getArmor(%player)] == ProtoArmor)
			Client::sendMessage(Player::getClient(%player),0, "Dash boots are not ready.");
		else
			Client::sendMessage(Player::getClient(%player),0, "You must wait before using another booster.");
	}
	else
	{
		SpeedBooster(%player, %item, 300);
		%player.usedbeacon = true;
		if($ArmorName[Player::getArmor(%player)] == ProtoArmor)
			schedule("resetBeaconUse(" @ %player @ ");",1);
		else
			schedule("resetBeaconUse(" @ %player @ ");",5);
	}
}

function SpeedBooster(%player,%item,%power)
{
	%vel = Item::getVelocity(%player);
	if(%vel == "0 0 0")
		%vel = Vector::getFromRot(GameBase::getRotation(%player),%power);
	else {
		%vel = Vector::Normalize(%vel);
		%vel = GetWord(%vel, 0) * %power @ " " @ GetWord(%vel, 1) * %power @ " " @ GetWord(%vel, 2) * %power;
	}
	Player::applyImpulse(%player,%vel);
	if($ArmorName[Player::getArmor(%player)] == ProtoArmor) {
		GameBase::playSound(%player, SoundPlasmaTurretFire, 0);
		Client::sendMessage(Player::getClient(%player),0, "Dash boots activated.");
	}
	else {
		GameBase::playSound(%player, SoundFireMortar, 0);
		Client::sendMessage(Player::getClient(%player),0, "Rocket boost activated.");
		Player::decItemCount(%player,%item);
	}
}
