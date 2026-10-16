//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------

$MaxWeapons[larmor] = 3;

//----------------------------------------------------------------------------
// Light Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[lfemale] = 3;

//------------------------------------------------------------------
// light armor data:
//------------------------------------------------------------------

PlayerData larmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Light female data:
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
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


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//--------------------------------------

$ArmorType[Male, LightArmor] = larmor;
$ArmorName[larmor] = LightArmor;

$ArmorType[Female, LightArmor] = lfemale;
$ArmorName[lfemale] = LightArmor;

$APBeaconMax[LightArmor] = 3;
$APGrenadeMax[LightArmor] = 5;

$ContactMSG[LightArmor] = "Steal from Enemy";
$BeaconMSG[LightArmor] = "Vehicle Shield";
$MineMSG[LightArmor] = "Poison Gas Mine";
$GrenadeMSG[LightArmor] = "Poison Gas Grenade";

$PunchPower[LightArmor] = 0.6;
//--------------------------------------

ItemData LightArmor
{
   heading = $InvCatArmors;
	description = "Peltast";
	className = "Armor";
	price = 175;
};

//--------------------------------------

function LightArmor::onGrenade(%player,%item)
{
	Player::decItemCount(%player,%item);
	%client = Player::getClient(%player);
	%obj = newObject("","Mine","VenomNade");
	addToSet("MissionCleanup", %obj);
//	  Player::setAnimation(%player, 21);
//	  schedule("GameBase::throw(" @ %obj @ "," @ %player @ ",9 * " @ %client.throwStrength @ ",false);",0.8);
	GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
	%player.throwTime = getSimTime() + 0.5;
}

function LightArmor::onBeacon(%player,%item)
{
	CheckVShield(%player, %item);
}

function LightArmor::onMine(%player,%item)
{
	Player::decItemCount(%player,%item);
	%obj = newObject("","Mine","VenomMine");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam(%obj,GameBase::getTeam(%client));
}

function LightArmor::onContact(%player,%object)
{
	if(TeamCompare(%player,%object) != Same) {
		if($Apocalypse::SlugFest)
			Normal::Punch(%player,%object);
		else
			Thief(%player,%object);
	}
}

function LightArmor::onRepair(%player,%item)
{
	if(GameBase::getDamageLevel(%player)) {
		Player::decItemCount(%player,%item);
		GameBase::repairDamage(%player,0.2);
		Repair::checkStatus(%player,5);
	}
	else if(GameBase::getLOSInfo(%player,3))
	{
		%object = getObjectType($los::object);
		if(%object == "Flier") {
			Player::decItemCount(%player,%item);
			%rate = GameBase::getAutoRepairRate($los::object) + 0.2;
			GameBase::setAutoRepairRate($los::object,%rate);
			schedule("GameBase::setAutoRepairRate("@$los::object@","@0@");",1);
		}
		$los::object = "";
	}
}

function Thief(%player, %object)
{
	%chance = 100;
	if(Player::getItemState(%player,$WeaponSlot) == "Fire")
		%chance -= 25;
	else if(Player::getItemState(%player,$WeaponSlot) == "Reload")
		%chance -= 15;
	%vel = Item::getVelocity(%object);
	if(%vel != "0 0 0")
		%chance -= 10;
	$los::object = "";
	if(GameBase::getLOSInfo(%object,3)) {
		if($los::object == %player)
			%chance -= 50;
	}
	$los::object = "";
	if(GameBase::getLOSInfo(%player,3)) {
		if($los::object != %object)
			%chance -= 25;
	}
	if(%chance > 0)
		Steal(%player,%object,%chance);
}

function Steal(%player,%object,%chance)
{
	%playerID = Player::getClient(%player);
	%objectID = Player::getClient(%object);
	%roll = floor(getRandom() * 100);
	if(%roll < %chance) {
		%sound = false;
		%max = getNumItems();
		for (%i = 0; %i < %max; %i++) {
			%count = Player::getItemCount(%object,%i);
			if(%count) {
				if(getItemData(%i).className != Module)
					%delta = Item::giveItem(%player,getItemData(%i),%count);
				else
					%delta = 0;
				if (%delta > 0) {
					Player::decItemCount(%object,%i,%delta);
					%sound = true;
				}
			}
		}
		if(%sound) {
			Client::sendMessage(%objectID,1, Client::getName(%playerID)@" stole some of your equipment.");
			Client::sendMessage(%playerID,3, "You stole from "@Client::getName(%objectID)@".");
			playSound(SoundPickupItem,GameBase::getPosition(%player));
		}
	}
}

function CheckVShield(%player, %item)
{
	if(%player.usedbeacon)
		Client::sendMessage(Player::getClient(%player),0, "Vehicle shield not ready.");
	else if(%player.vehicle == "") {
		if(GameBase::getLOSInfo(%player,3)) {
			%object = getObjectType($los::object);
			if(%object == "Flier") {
				Client::sendMessage(Player::getClient(%player),0, "Vehicle shield initialized.");
				Player::decItemCount(%player,%item);
				if($los::object.TStime == 0) {
					$los::object.TStime = 45;
					ShieldV(%player,$los::object);
				}
				else
					$los::object.TStime = 45;
			}
			else
				Client::sendMessage(Player::getClient(%player),0, "Nothing in range");
			$los::object = "";
		}
		else
			Client::sendMessage(Player::getClient(%player),0, "Nothing in range");
	}
	else {
		BeginVShield(%player,%item);
		%player.usedbeacon = true;
		schedule("resetBeaconUse(" @ %player @ ");",5);
	}
}

function BeginVShield(%player, %item)
{
	Client::sendMessage(Player::getClient(%player),0, "Vehicle shield initialized.");
	Player::decItemCount(%player,%item);
	if(%player.vehicle.TStime == 0) {
		%player.vehicle.TStime = 45;
		ShieldV(%player,%player.vehicle);
	}
	else
		%player.vehicle.TStime = 45;
}

function ShieldV(%player, %vehicle)
{
	%driver = Client::getOwnedObject(%vehicle.clLastMount);
	if(%player.shieldStrength > 0 && !%player.Shielded && !%player.shtime)
		%player.shieldStrength = 0;
	if(%vehicle.TStime > 0) {
		if(%vehicle.shieldStrength < 0.03)
			%vehicle.shieldStrength = 0.03;
		if(%driver.vehicle == %vehicle && %driver.shieldStrength < 0.03)
			%driver.shieldStrength = 0.03;
		if(%vehicle.TStime >= 1) {
			if(%vehicle.TStime > 4 && %vehicle.TStime <= 5 && %driver.vehicle == %vehicle)
				Client::sendMessage(%vehicle.clLastMount,1, "Warning your vehicle has less then 5 seconds of shield left.");
			schedule("ShieldV("@%driver@","@%vehicle@");",1);
			%vehicle.TStime--;
		}
		else {
			schedule("ShieldV("@%driver@","@%vehicle@");",%vehicle.TStime);
			%vehicle.TStime = 0;
		}
	}
	else {
		%vehicle.shieldStrength = 0;
		if(%driver.vehicle != "") {
			%driver.shieldStrength = 0;
			if(%driver.Shielded)
				%driver.shieldStrength = 0.012;
			else if(%driver.shtime > 0)
				%driver.shielStrength = 0.03;
		}
		%vehicle.TStime = 0;
		if(%driver.vehicle == %vehicle)
			Client::sendMessage(%vehicle.clLastMount,1, "Temporary vehicle shield expired.");
	}
}
