//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode6(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// GrenadeLauncher
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == GrenadeLauncher)
      {
           if(%clientId.GrenadeLauncher >= 3)
               %clientId.GrenadeLauncher = -1;

          %clientId.GrenadeLauncher += 1;

      if(%clientId.GrenadeLauncher == 0)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade  -> [1/4]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.GrenadeLauncher == 1)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade  -> [2/4]<f2> RPG\", 5);", 0);
      }
      else if(%clientId.GrenadeLauncher == 2)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade  -> [3/4]<f2> Implosion Shell  -AmmoUse = 10.\", 5);", 0);
      }
      else if(%clientId.GrenadeLauncher == 3)
      {
          Client::sendMessage(%clientId,0,"~wdiscreload.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grenade  -> [4/4]<f2> Multi Shell  -AmmoUse = 3.\", 5);", 0);
      }
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
      //}
      }
       //else
       //schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Error! (Weapon::NoModes) No modes availiable to change.\", 5);", 0);
}

