//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode2(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// Mortar
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == Mortar)
      {
           if(%clientId.mortar >= 5)
               %clientId.mortar = -1;

          %clientId.mortar += 1;

      if(%clientId.mortar == 0)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [1/6]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.mortar == 1)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [2/6]<f2> Bouncing Betty HE\", 5);", 0);
      }
          //
      else if(%clientId.mortar == 2)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [3/6]<f2> Vertigo Bomb AB\", 5);", 0);
      }
          //
      else if(%clientId.mortar == 3)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [4/6]<f2> EMP Shell\", 5);", 0);
      }
          //
      else if(%clientId.mortar == 4)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [5/6]<f2> Standard HE\", 5);", 0);
      }
          //
      else if(%clientId.mortar == 5)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>mortar  -> [6/6]<f2> Smoke Bomb Shell\", 5);", 0);
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

