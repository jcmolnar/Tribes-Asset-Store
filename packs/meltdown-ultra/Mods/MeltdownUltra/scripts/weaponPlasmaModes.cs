//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode3(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Plasma Gun
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == PlasmaGun)
      {
           if(%clientId.Plasma >= 3)
               %clientId.Plasma = -1;

          %clientId.Plasma += 1;

      if(%clientId.Plasma == 0)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma  -> [1/4]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.Plasma == 1)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma  -> [2/4]<f2> Rapid-Bold\", 5);", 0);
      }
          //
      else if(%clientId.Plasma == 2)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientid @ ", \"<jc><f1>Plasma  -> [3/4]<f2> Multi-Bold\", 5);", 0);
      }
          //
      else if(%clientId.Plasma == 3)
      {
          Client::sendMessage(%clientId,0,"~wflameon.wav");
          //Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plasma  -> [4/4]<f2> Plasma-Burn\", 5);", 0);
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

