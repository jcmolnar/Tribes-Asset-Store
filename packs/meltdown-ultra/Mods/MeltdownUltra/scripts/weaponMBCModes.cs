//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode1(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Mitzi Blast Cannon
//--------------------------------------------------------------------------
     if (Player::getMountedItem(%player, $WeaponSlot) == MBCannon)
     {
           if(%clientId.Cannon >= 11)
               %clientId.Cannon = -1;

          %clientId.Cannon += 1;

      if(%clientId.Cannon == 0)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [1/12]<f2> Standard  -EnergyUse = 10\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 1)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [2/12]<f2> EMP  -EnergyUse = 15\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 2)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Mitzi  -> [3/12]<f2> Mitzi (Booster)  -EnergyUse = 15\", 5);", 0);
      }
           //
      else if(%clientId.Cannon == 3)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Mitzi  -> [4/12]<f2> Mitzi (Booster) X2  -EnergyUse = 100\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 4)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [5/12]<f2> Poisoning effects  -EnergyUse = 25\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 5)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [6/12]<f2> Internal Flaming  -EnergyUse = 25\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 6)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [7/12]<f2> Blue Ray  -EnergyUse = 200\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 7)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [8/12]<f2> Starburst  -EnergyUse = 200\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 8)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [9/12]<f2> Annihilation  -EnergyUse = 200\", 5);", 0);
      }
      else if(%clientId.Cannon == 9)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [10/12]<f2> Swarmer Blast  -EnergyUse = 250\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 10)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [11/12]<f2> Baby Nuke  -EnergyUse = 350\", 5);", 0);
      }
          //
      else if(%clientId.Cannon == 11)
      {
          Client::sendMessage(%clientId,0,"~wturreton1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mitzi  -> [12/12]<f2> Large Nuke  -EnergyUse = 500\", 5);", 0);
      }
      //else
      //    schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Error! (Weapon::InvalidMode) defaulting to Standard.\", 5);", 0);
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
      //}
      }
       //else
       //schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Error! (Weapon::NoModes) No modes availiable to change.\", 5);", 0);
}

