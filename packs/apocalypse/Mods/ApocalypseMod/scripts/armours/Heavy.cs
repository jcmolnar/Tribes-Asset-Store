//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------

$MaxWeapons[harmor] = 5;

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------

PlayerData harmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 1;
   jetForce = 385;
   jetEnergyDrain = 1.1;

	maxDamage = 1.32;
   maxForwardSpeed = 5.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 4.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 18.0;
	maxEnergy = 110;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 150;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//--------------------------------------

$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorName[harmor] = HeavyArmor;

$APBeaconMax[HeavyArmor] = 3;
$APGrenadeMax[HeavyArmor] = 5;

$ContactMSG[HeavyArmor] = "Steal Energy";
$BeaconMSG[HeavyArmor] = "Electro Magnetic Pulse";
$MineMSG[HeavyArmor] = "Teleport Mine";
$GrenadeMSG[HeavyArmor,1] = "Explosion Mortar";
$GrenadeMSG[HeavyArmor,2] = "Implosion Mortar";

$PunchPower[HeavyArmor] = 1.0;
//--------------------------------------

ItemData HeavyArmor
{
   heading = $InvCatArmors;
	description = "Myrmidon";
	className = "Armor";
	price = 400;
};

//--------------------------------------

function HeavyArmor::onGrenade(%player,%item)
{
	Player::decItemCount(%player,%item);
	%client = Player::getClient(%player);
	if($WeapMode[%client,Mortar] == 1 || $WeapMode[%client,Mortar] < 1 || $WeapMode[%client,Mortar] == "")
		%obj = newObject("","Mine","MortarNade");
	else if($WeapMode[%client,Mortar] == 2 || $WeapMode[%client,Mortar] > $FireModes[Mortar])
		%obj = newObject("","Mine","ImplodeNade");
	addToSet("MissionCleanup", %obj);
//	  Player::setAnimation(%player, 21);
//	  schedule("GameBase::throw(" @ %obj @ "," @ %player @ ",9 * " @ %client.throwStrength @ ",false);",0.8);
	GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
	%player.throwTime = getSimTime() + 0.5;
}

function HeavyArmor::onBeacon(%player,%item)
{
	CheckEMP(%player,%item);
}

function HeavyArmor::onMine(%player,%item)
{
	Player::decItemCount(%player,%item);
	%obj = newObject("","Mine","TeleMine");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam(%obj,GameBase::getTeam(%client));
}

$ENSTEAL = 16;
function HeavyArmor::onContact(%player,%object)
{
	if(TeamCompare(%player,%object) != Same) {
		if($Apocalypse::SlugFest)
			Normal::Punch(%player,%object);
		else {
			%pen = GameBase::getEnergy(%player);
			%oen = GameBase::getEnergy(%object);
			if(%oen >= $ENSTEAL) {
				%pen += $ENSTEAL;
				%oen -= $ENSTEAL;
			}
			else {
				%pen += %oen;
				%oen = 0;
			}
			if(%pen > Player::getArmor(%player).maxEnergy)
				%pen = Player::getArmor(%player).maxEnergy;
			GameBase::setEnergy(%player,%pen);
			GameBase::setEnergy(%object,%oen);
		}
	}
}

function HeavyArmor::onRepair(%player,%item)
{
	if(GameBase::getDamageLevel(%player)) {
		Player::decItemCount(%player,%item);
		GameBase::repairDamage(%player,0.2);
		Repair::checkStatus(%player,5);
	}
}

function CheckEMP(%player,%item)
{
	if(%player.usedbeacon)
		Client::sendMessage(Player::getClient(%player),0, "Electro Magnetic Pulse not ready.");
	else {
		AreaEMP(%player, %item);
		%player.usedbeacon = true;
		schedule("resetBeaconUse(" @ %player @ ");",5);
	}
}

function AreaEMP(%player, %item)
{
	%set = newObject("set",SimSet);
	%pos = GameBase::getPosition(%player);
	%num = containerBoxFillSet(%set, $SimPlayerObjectType, %pos, 50, 50, 50,0);
	for (%i=0; %i<%num; %i++) {
		%object = Group::getObject(%set,%i);
		echo("object: "@%object@" player: "@%player);
		if (%object != %player && TeamCompare(%player,%object) != Same) {
			EMPsystem(%object,%player,15,$EMPDamageType);
		}
	}
	deleteObject(%set);
	Client::sendMessage(Player::getClient(%player),0, "Electro Magnetic Pulse activated.");
	%obj = newObject("","Mine","ShockwaveEffectBomb");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, %pos);
	Player::decItemCount(%player,%item);
}
