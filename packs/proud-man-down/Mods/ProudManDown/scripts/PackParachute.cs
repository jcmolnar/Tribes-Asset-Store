//Taken from Delta Force mod with permission.
//--------------------------------------

$InvList[ParachutePack] = 1;
$RemoteInvList[ParachutePack] = 1;

//--------------------------------------


ItemImageData ParachutePackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        maxEnergy = 0;  // Energy used/sec for sustained weapons
        minEnergy = 0;
        sfxFire = SoundFlagPickup;
        mountOffset = { 0, -0.03, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData ParachutePack
{
        description = "Parachute";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "fBackpacks";
        shadowDetailMask = 4;
        imageType = ParachutePackImage;
        price = 100;
        hudIcon = "sensorjamerpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function doPara(%player) 
{
	//echo("doPara() called");
      Player::applyImpulse(%player, "0 0 75");
      if ($ParaActivated[%player] == 1) {
	  	if (Player::getLastContactCount(%player) > 5) {
                	schedule("doPara("@%player@");", 0.48);
		//} else ParachutePackImage::onDeactivate(%player, $BackpackSlot);
		} else hitGround(%player);
	  }
}

function ParachutePackImage::onActivate(%player,%imageSlot)
{
	if($ParaActivated[%player] == 0) {
		%contact = Player::getLastContactCount(%player);
		if(%contact > 11 )
		{
			remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Opened.", 4);
			$ParaActivated[%player] = 1;
			doPara(%player);
		}
		else
		{
			Player::trigger(%player, $BackpackSlot, false);
			remoteEval(Player::getClient(%player), BP, "<f0><jc>You must be falling to open your Parachute!", 4);
		}
	}
}

function ParachutePackImage::onDeactivate(%player,%imageSlot)
{}

function hitGround(%player) {
	$ParaActivated[%player] = 0;
    remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Discarded.", 4);
    Player::trigger(%player,$BackpackSlot,false);
	Player::decItemCount(%player, ParachutePack);
}