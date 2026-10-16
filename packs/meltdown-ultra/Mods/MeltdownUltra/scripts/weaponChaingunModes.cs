//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode5(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Chaingun
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == Chaingun)
      {
           if(%clientId.chaingun >= 1)
               %clientId.chaingun = -1;

          %clientId.chaingun += 1;

      if(%clientId.chaingun == 0)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun  -> [1/2]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.chaingun == 1)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chaingun  -> [2/2]<f2> Gauss Bullet\", 5);", 0);
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

