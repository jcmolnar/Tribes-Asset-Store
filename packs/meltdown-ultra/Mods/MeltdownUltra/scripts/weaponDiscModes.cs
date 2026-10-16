//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode4(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Disc Launcher
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == DiscLauncher)
      {
           if(%clientId.DiscLauncher >= 3)
               %clientId.DiscLauncher = -1;

          %clientId.DiscLauncher += 1;

      if(%clientId.DiscLauncher == 0)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc  -> [1/4]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.DiscLauncher == 1)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc  -> [2/4]<f2> Power Disc\", 5);", 0);
      }
          //
      else if(%clientId.DiscLauncher == 2)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Disc  -> [3/4]<f2> Power Disc Output 2x\", 5);", 0);
      }
          //
      else if(%clientId.DiscLauncher == 3)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disc  -> [4/4]<f2> Disc Shell Multi\", 5);", 0);
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

