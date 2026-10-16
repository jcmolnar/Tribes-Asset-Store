//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------

function changeWeaponMode9(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Blaster
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == Blaster)
      {
           if(%clientId.Blaster >= 2)
               %clientId.Blaster = -1;

          %clientId.Blaster += 1;

      if(%clientId.Blaster == 0)
      {
          Client::sendMessage(%clientId,0,"~wPku_weap.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Blaster  -> [1/3]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.Blaster == 1)
      {
          Client::sendMessage(%clientId,0,"~wPku_weap.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Blaster  -> [2/3]<f2> Multi Blast\", 5);", 0);
      }
         //
      else if(%clientId.Blaster == 2)
      {
          Client::sendMessage(%clientId,0,"~wPku_weap.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Blaster  -> [3/3]<f2> Blue Blast\", 5);", 0);
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

