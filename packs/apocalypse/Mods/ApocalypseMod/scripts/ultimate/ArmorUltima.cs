//----------------------------------------------------------------------------
// Ultima Armor
//----------------------------------------------------------------------------

$MaxWeapons[uarmor] = 99;

//----------------------------------------------------------------------------
// Ultima Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[ufemale] = 99;

//------------------------------------------------------------------
// Ultima armor data:
//------------------------------------------------------------------

PlayerData uarmor
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
   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 30;
   minJetEnergy = 1;
   jetForce = 250;
   jetEnergyDrain = 0.9;

        maxDamage = 2.0;
   maxForwardSpeed = 20;
   maxBackwardSpeed = 15;
   maxSideSpeed = 15;
   groundForce = 35 * 8.0;
   mass = 10.0;
   groundTraction = 3.0;
        maxEnergy = 200;
   drag = 1.0;
   density = 1.2;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
        // firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
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
// Ultima female data:
//------------------------------------------------------------------

PlayerData ufemale
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
   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 30;
   minJetEnergy = 1;
   jetForce = 250;
   jetEnergyDrain = 0.9;

        maxDamage = 2.0;
   maxForwardSpeed = 20;
   maxBackwardSpeed = 15;
   maxSideSpeed = 15;
   groundForce = 35 * 8.0;
   mass = 10.0;
   groundTraction = 3.0;
        maxEnergy = 200;
   drag = 1.0;
   density = 1.2;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
        // firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
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

$ArmorType[Male, UltimaArmor] = uarmor;
$ArmorName[uarmor] = UltimaArmor;

$ArmorType[Female, UltimaArmor] = ufemale;
$ArmorName[ufemale] = UltimaArmor;

$APBeaconMax[UltimaArmor] = 9;
$APGrenadeMax[UltimaArmor] = 9;

$ContactMSG[UltimaArmor] = "Repair Teammates";
$BeaconMSG[UltimaArmor] = "Change Firing Modes";
$MineMSG[UltimaArmor] = "Ultima Strike";
$GrenadeMSG[UltimaArmor] = "Area Shield and Cloak";

$PunchPower[UltimaArmor] = 0.8;
//--------------------------------------

ItemData UltimaArmor
{
   heading = $InvCatArmors;
        description = "Ultima";
        className = "Armor";
        price = 999;
};

//--------------------------------------

function UltimaArmor::onGrenade(%player,%item)
{
//        Player::decItemCount(%player,%item);
//        %client = Player::getClient(%player);
//        %obj = newObject("","Mine","UltimaNade");
//        addToSet("MissionCleanup", %obj);
//        Player::setAnimation(%player, 21);
//        schedule("GameBase::throw(" @ %obj @ "," @ %player @ ",9 * " @ %client.throwStrength @ ",false);",0.8);
        %set = newObject("set",SimSet);
        %ppos = GameBase::getPosition(%player);
        %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
        Client::sendMessage(Player::getClient(%player),0, "Area Stealth Shield Activated.");
        %obj = newObject("","Mine","EmpEffectBomb2");
        %obj2 = newObject("","Mine","FireEffectBomb2");
        %obj3 = newObject("","Mine","ShockwaveEffectBomb");
        addToSet("MissionCleanup", %obj);
        addToSet("MissionCleanup", %obj2);
        addToSet("MissionCleanup", %obj3);
        GameBase::setPosition(%obj, GameBase::getPosition(%player));
        GameBase::setPosition(%obj2, GameBase::getPosition(%player));
        GameBase::setPosition(%obj3, GameBase::getPosition(%player));
        for (%i=0; %i<%num; %i++) {
                %oply = Group::getObject(%set,%i);
                if(TeamCompare(%player,%oply) == Same || TeamCompare(%player,%oply) == You) {
                        $DCGiven[%oply,$UltimaType] = true;
                        if(%oply.shtime > 0 && %oply.shtime < 15)
                                %oply.shtime = 15;
                        else {
                                %oply.shtime = 15;
                                TempShield(%oply);
                        }
                        if(%oply.cltime > 0 && %oply.cltime < 15)
                                %oply.cltime = 15;
                        else {
                                %oply.cltime = 15;
                                Cloak(%oply);
                        }
                        Client::sendMessage(Player::getClient(%player),0, "You now have 15 seconds of Stealth Shield.");
                }
        }
        deleteObject(%set);
//        GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
//        %player.throwTime = getSimTime() + 0.5;
}

function UltimaArmor::onBeacon(%player,%item)
{
        %handgun = Player::getMountedItem(%player,$WeaponSlot);
        %client = Player::getClient(%player);
        if($FireModes[%handgun] != "" && $FireModes[%handgun] > 1) {
                if($WeapMode[%client,%handgun] == 1 || $WeapMode[%client,%handgun] < 1  || $WeapMode[%client,%handgun] == "")
                        $WeapMode[%client,%handgun] = 2;
                else if($WeapMode[%client,%handgun] < $FireModes[%handgun])
                        $WeapMode[%client,%handgun]++;
                else if($WeapMode[%client,%handgun] >= $FireModes[%handgun])
                        $WeapMode[%client,%handgun] = 1;
                Player::unmountItem(%player,$WeaponSlot);
                Player::unmountItem(%player,$ExtraSlotA);
                Player::unmountItem(%player,$ExtraSlotB);
                Player::mountItem(%player,%handgun,$WeaponSlot);
                printMessage(%player,%handgun);
        }
}

function UltimaArmor::onMine(%player,%item)
{
        %set = newObject("set",SimSet);
        %ppos = GameBase::getPosition(%player);
        %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
        Client::sendMessage(Player::getClient(%player),0, "Ultima Strike Activated.");
        %obj = newObject("","Mine","EmpEffectBomb2");
        %obj2 = newObject("","Mine","FireEffectBomb2");
        %obj3 = newObject("","Mine","ShockwaveEffectBomb");
        addToSet("MissionCleanup", %obj);
        addToSet("MissionCleanup", %obj2);
        addToSet("MissionCleanup", %obj3);
        GameBase::setPosition(%obj, GameBase::getPosition(%player));
        GameBase::setPosition(%obj2, GameBase::getPosition(%player));
        GameBase::setPosition(%obj3, GameBase::getPosition(%player));
        for (%i=0; %i<%num; %i++) {
                %oply = Group::getObject(%set,%i);
                if(TeamCompare(%player,%oply) == Diff) {
                        %rnd = floor(getRandom() * 100);
                        if(%rnd >= 99) {
                                Player::blowUp(%oply);
                                Client::onKilled(Player::getClient(%oply),Player::getClient(%player),$SaiyanDamageType);
                                Player::kill(%oply);
                        }
                        else if(%rnd > 79 && %rnd < 99)
                                Infect(%oply, %player, 5, $PoisonDamageType);
                        else if(%rnd > 60 && %rnd < 80)
                                SetOnFire(%oply, %player, 5, $FireDamageType);
                        else if(%rnd > 41 && %rnd < 61)
                                EMPsystem(%oply, %player, 5, $EmpDamageType);
                        else if(%rnd > 22 && %rnd < 42)
                                Blind(%oply,10);
                        else if(%rnd > 2 && %rnd < 22)
                                Stun(%oply,100);
                        else if(%rnd < 3) {
                                Stun(%oply,100);
                                Blind(%oply,10);
                                EMPsystem(%oply, %player, 5, $SaiyanDamageType);
                        }
                  }
        }
        deleteObject(%set);
//        Player::decItemCount(%player,%item);
//        %obj = newObject("","Mine","AntipersonelMine");
//        addToSet("MissionCleanup", %obj);
//        %client = Player::getClient(%player);
//        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
//        %player.throwTime = getSimTime() + 0.5;
//        GameBase::setTeam(%obj,GameBase::getTeam(%client));
}

function UltimaArmor::onContact(%player,%object)
{
        if(TeamCompare(%player,%object) == Same) {
                GameBase::repairDamage(%object,0.1);
                GameBase::playSound(%object, SoundPickupHealth, 0);
        }
        else if($Apocalypse::SlugFest)
                Normal::Punch(%player,%object);
}

function UltimaArmor::onRepair(%player,%item)
{
        if(GameBase::getDamageLevel(%player)) {
                Player::decItemCount(%player,%item);
                GameBase::setDamageLevel(%player,0);
                Repair::checkStatus(%player,50);
        }
        else
                HealCheck(%player,%item);
}

function HealCheck(%player,%item)
{
        if(GameBase::getLOSInfo(%player,3))
        {
                %object = getObjectType($los::object);
                if(%object == "Player")
                        schedule("Heal("@%player@","@$los::object@","@%item@");",1.25);
                else
                        schedule("Heal("@%player@","@%player@","@%item@");",1.0);
                $los::object = "";
        }
        else
                schedule("Heal("@%player@","@%player@","@%item@");",1.0);
}

function Heal(%player,%object,%item)
{
        %armor = Player::getArmor(%object);
        %objectId = Player::getClient(%object);
        %playerId = Player::getClient(%player);
        if(GameBase::getDamageLevel(%object))
        {
                GameBase::setDamageLevel(%object,0);
                Repair::checkStatus(%player,50);
                Player::decItemCount(%player,%item);
                if(%objectId != %playerId)
                        Client::sendMessage(%objectId,3,"You have been fully healed by "@Client::getName(%playerId)@".");
        }
        else if(GameBase::getDamageLevel(%player))
        {
                GameBase::setDamageLevel(%player,0);
                Repair::checkStatus(%player,50);
                Player::decItemCount(%player,%item);
        }
}

