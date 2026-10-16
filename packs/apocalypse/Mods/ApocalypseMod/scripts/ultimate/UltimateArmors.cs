//----------------------------------------------------------------------------
// Saiyan Armor
//----------------------------------------------------------------------------

$MaxWeapons[sarmor] = 5;

//----------------------------------------------------------------------------
// Saiyan Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[sfemale] = 5;

//------------------------------------------------------------------
// Saiyan Armor data:
//------------------------------------------------------------------

PlayerData sarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 0.01;
   jetForce = 400;
   jetEnergyDrain = 0.0;

        maxDamage = 1.0;
   maxForwardSpeed = 15.0;
   maxBackwardSpeed = 10.0;
   maxSideSpeed = 10.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 100;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 165;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
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

   jetSound = SoundShieldOn;

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
// Saiyan female data:
//------------------------------------------------------------------

PlayerData sfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 0.01;
   jetForce = 400;
   jetEnergyDrain = 0.0;

        maxDamage = 1.0;
   maxForwardSpeed = 15.0;
   maxBackwardSpeed = 10.0;
   maxSideSpeed = 10.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 100;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 165;
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

   jetSound = SoundShieldOn;

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

$ArmorType[Male, SaiyanArmor] = sarmor;
$ArmorName[sarmor] = SaiyanArmor;

$ArmorType[Female, SaiyanArmor] = sfemale;
$ArmorName[sfemale] = SaiyanArmor;

//--------------------------------------

ItemData SaiyanArmor
{
   heading = $InvCatArmors;
        description = "Saiyan";
        className = "Armor";
        price = 9000;
};

$APBeaconMax[SaiyanArmor] = 0;
$APGrenadeMax[SaiyanArmor] = 0;

$ContactMSG[SaiyanArmor] = "Repair Others";
$BeaconMSG[SaiyanArmor] = "None";
$MineMSG[SaiyanArmor] = "None";
$GrenadeMSG[SaiyanArmor] = "None";

$PunchPower[SaiyanArmor] = 1.5;
//--------------------------------------

function SaiyanArmor::onGrenade(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SaiyanArmor::onBeacon(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SaiyanArmor::onMine(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SaiyanArmor::onContact(%player,%object)
{
        Saiyan::Punch(%player,%object);
}

function SaiyanArmor::onRepair(%player,%item)
{
        if(GameBase::getDamageLevel(%player))
                schedule("Heal("@%player@","@%player@","@%item@");",1.0);
        else
                HealCheck(%player,%item);
}

//----------------------------------------------------------------------------
// Super Saiyan Armor
//----------------------------------------------------------------------------

$MaxWeapons[ssarmor] = 5;

//----------------------------------------------------------------------------
// Super Saiyan Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[ssfemale] = 5;

//------------------------------------------------------------------
// Super Saiyan Armor data:
//------------------------------------------------------------------

PlayerData ssarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "plasmaex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 34;
   minJetEnergy = 0.01;
   jetForce = 400;
   jetEnergyDrain = 0.0;

        maxDamage = 1.0;
   maxForwardSpeed = 30.0;
   maxBackwardSpeed = 20.0;
   maxSideSpeed = 20.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 200;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 180;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
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

   jetSound = SoundShieldOn;

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
// Super Saiyan female data:
//------------------------------------------------------------------

PlayerData ssfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "plasmaex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 34;
   minJetEnergy = 0.01;
   jetForce = 400;
   jetEnergyDrain = 0.0;

        maxDamage = 1.0;
   maxForwardSpeed = 30.0;
   maxBackwardSpeed = 20.0;
   maxSideSpeed = 20.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 200;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 180;
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

   jetSound = SoundShieldOn;

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

$ArmorType[Male, SSaiyanArmor] = ssarmor;
$ArmorName[ssarmor] = SSaiyanArmor;

$ArmorType[Female, SSaiyanArmor] = ssfemale;
$ArmorName[ssfemale] = SSaiyanArmor;

//--------------------------------------

ItemData SSaiyanArmor
{
   heading = $InvCatArmors;
        description = "Super Saiyan";
        className = "Armor";
        price = 9000;
};

$APBeaconMax[SSaiyanArmor] = 0;
$APGrenadeMax[SSaiyanArmor] = 0;

$ContactMSG[SSaiyanArmor] = "Repair Others";
$BeaconMSG[SSaiyanArmor] = "None";
$MineMSG[SSaiyanArmor] = "None";
$GrenadeMSG[SSaiyanArmor] = "None";

$PunchPower[SSaiyanArmor] = 1.5;
//--------------------------------------

function SSaiyanArmor::onGrenade(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SSaiyanArmor::onBeacon(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SSaiyanArmor::onMine(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function SSaiyanArmor::onContact(%player,%object)
{
        Saiyan::Punch(%player,%object);
}

function SSaiyanArmor::onRepair(%player,%item)
{
        if(GameBase::getDamageLevel(%player))
                schedule("Heal("@%player@","@%player@","@%item@");",1.0);
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
                GameBase::setEnergy(%object,%armor.maxEnergy);
                Player::decItemCount(%player,%item);
                if(%objectId != %playerId)
                        Client::sendMessage(%objectId,3,"You have been fully healed by "@Client::getName(%playerId)@".");
        }
        else if(GameBase::getDamageLevel(%player))
        {
                GameBase::setDamageLevel(%player,0);
                GameBase::setEnergy(%player,%armor.maxEnergy);
                Player::player(%object,%armor.maxEnergy);
                Player::decItemCount(%player,%item);
        }
}
//----------------------------------------------------------------------------
// Proto Armor
//----------------------------------------------------------------------------

$MaxWeapons[parmor] = 1;

//------------------------------------------------------------------
// ProtoManX Armor data:
//------------------------------------------------------------------

PlayerData parmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.001;
   maxJetForwardVelocity = 0.001;
   minJetEnergy = 100;
   jetForce = 0;
   jetEnergyDrain = 0;

        maxDamage = 1.0;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 35 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;

        maxEnergy = 60;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 200;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
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
   animData[19] = { "fall", none, 1, true, true, true, false, 3 };

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

   jetSound = false;

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

//--------------------------------------

$ArmorType[Male, ProtoArmor] = parmor;
$ArmorName[parmor] = ProtoArmor;

$ArmorType[Female, ProtoArmor] = parmor;
$ArmorName[parmor] = ProtoArmor;

//--------------------------------------

ItemData ProtoArmor
{
   heading = $InvCatArmors;
        description = "ProtoManX";
        className = "Armor";
        price = 9000;
};

$APBeaconMax[ProtoArmor] = 0;
$APGrenadeMax[ProtoArmor] = 0;

$ContactMSG[ProtoArmor] = "None";
$BeaconMSG[ProtoArmor] = "Dash Boots";
$MineMSG[ProtoArmor] = "None";
$GrenadeMSG[ProtoArmor] = "Giga Attack";

$PunchPower[ProtoArmor] = 0.0;
//--------------------------------------

function ProtoArmor::onGrenade(%player,%item)
{
        CheckGiga(%player,%item);
}

function ProtoArmor::onBeacon(%player,%item)
{
        CheckBooster(%player,%item);
}

function ProtoArmor::onMine(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function ProtoArmor::onContact(%player,%object)
{
        %playerID = Player::getClient(%player);
        Client::sendMessage(%playerID,3, Client::getName(%playerID)@" send player contact special sugestions to TheDrunk007@yahoo.com");
}

function ProtoArmor::onRepair(%player,%item)
{
        TankCheck(%player);
}

//Giga is modified booster from Annihilation mod
function CheckGiga(%player, %item)
{
        %armor = Player::getArmor(%player);
        if(%player.usedbeacon)
                Client::sendMessage(Player::getClient(%player),0, "Giga Attack is not ready");
        else
        {
                GigaBooster(%player, %item, 300);
                %player.usedbeacon = true;
                schedule("resetBeaconUse(" @ %player @ ");",1);
        }
}

function GigaBooster(%player, %item, %power)
{
        %client = Player::getClient(%player);
        %player.giga = true;
        %vel = Vector::getFromRot(GameBase::getRotation(%player),%power);
        Player::applyImpulse(%player, %vel);
        GameBase::PlaySound(%player, SoundPlasmaTurretFire, 2);
        GigaBoom(%player,3);
        if(!%client.isSuperAdmin)
                Player::decItemCount(%player,%item);
        Client::sendMessage(%client,0, "Giga Attack activated");
}

function GigaBoom(%player,%count)
{
        if(%count > 0) {
                %obj = newObject("","Mine","GigaBomb");
                addToSet("MissionCleanup", %obj);
                GameBase::throw(%obj,%player,5,false);
                %count--;
                schedule("GigaBoom("@%player@","@%count@");",0.25,%obj);
        }
        %player.giga = false;
}

function TankCheck(%player)
{
        if(GameBase::getDamageLevel(%player)) {
                %tankcont = Player::getItemCount(%player,PCapsule);
                %damageLvl = GameBase::getDamageLevel(%player);
                if(%damageLvl < %tankcont*0.01) {
                        %tankcont = %damageLvl * 100;
                        GameBase::repairDamage(%player,%damageLvl);
                }
                else {
                        GameBase::repairDamage(%player,%tankcont*0.01);
                }
                Player::decItemCount(%player,PCapsule,%tankcont);
        }
}

$CapVal[RepairKit] = 24;
$CapVal[RepairPatch] = 12;

function FillTank(%this,%object)
{
        if(Player::getItemCount(%object, "PCapsule") < 100) {
                Player::incItemCount(%object,"PCapsule",$CapVal[%this]);
                if(Player::getItemCount(%object, "PCapsule") > 100)
                        Player::setItemCount(%object,"PCapsule",100);
                %item = Item::getItemData(%this);
                Item::playPickupSound(%this);
                Item::respawn(%this);
        }
}

//----------------------------------------------------------------------------
// Discer Armor
//----------------------------------------------------------------------------

$MaxWeapons[darmor] = 10;

//----------------------------------------------------------------------------
// Discer Female Armor
//----------------------------------------------------------------------------

$MaxWeapons[dfemale] = 10;

//------------------------------------------------------------------
// Discer Armor data:
//------------------------------------------------------------------

PlayerData darmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "fusionbolt";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 0.75;
   jetForce = 320;
   jetEnergyDrain = 0.8;

        maxDamage = 1.0;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 35 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;

        maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
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

   jetSound = SoundDiscSpin;

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
// Discer female data:
//------------------------------------------------------------------

PlayerData dfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "fusionbolt";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
        mapFilter = 1;
        mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 0.75;
   jetForce = 320;
   jetEnergyDrain = 0.8;

   canCrouch = false;
        maxDamage = 1.0;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 35 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
        maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
        // firstPerson, chaseCam, thirdPerson, signalThread

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

   jetSound = SoundDiscSpin;

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

$ArmorType[Male, DiscerArmor] = darmor;
$ArmorName[darmor] = DiscerArmor;

$ArmorType[Female, DiscerArmor] = dfemale;
$ArmorName[dfemale] = DiscerArmor;

//--------------------------------------

ItemData DiscerArmor
{
   heading = $InvCatArmors;
        description = "Discer Armor";
        className = "Armor";
        price = 9000;
};

$APBeaconMax[DiscerArmor] = 0;
$APGrenadeMax[DiscerArmor] = 0;

$ContactMSG[DiscerArmor] = "Disc Damage";
$BeaconMSG[DiscerArmor] = "None";
$MineMSG[DiscerArmor] = "None";
$GrenadeMSG[DiscerArmor] = "Throwing Disc";

$PunchPower[DiscerArmor] = 0.65;
//--------------------------------------

function DiscerArmor::onGrenade(%player,%item)
{
        Player::decItemCount(%player,%item);
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        Projectile::spawnProjectile("ThrowingDisc",%trans,%player,%vel);
}

function DiscerArmor::onBeacon(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function DiscerArmor::onMine(%player,%item)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        Client::sendMessage(%client,1,"Nothing for you here.");
}

function DiscerArmor::onContact(%player,%object)
{
        if(TeamCompare(%player,%object) != Same) {
                if($Apocalypse::SlugFest)
                        Normal::Punch(%player,%object);
                else {
                        %value = 0.225;
                        DamageConversion(%object,%player,%value,Player::getArmor(%object),$ExplosionDamageType);
                        if(GameBase::getDamageLevel(%object)+%value < Player::getArmor(%object).maxDamage) {
                                %flash = Player::getDamageFlash(%object) + %value * 2;
                                Player::setDamageFlash(%object,%flash);
                                GameBase::setDamageLevel(%object,GameBase::getDamageLevel(%object) + %value);
                        }
                        else {
                                playNextAnim(%object);
                                Client::onKilled(Player::getClient(%object),Player::getClient(%player),$ExplosionDamageType);
                                Player::kill(%object);
                                return;
                        }
                }
        }
}

function DiscerArmor::onRepair(%player,%item)
{
        if(GameBase::getDamageLevel(%player)) {
                Player::decItemCount(%player,%item);
                GameBase::repairDamage(%player,0.2);
        }
}
