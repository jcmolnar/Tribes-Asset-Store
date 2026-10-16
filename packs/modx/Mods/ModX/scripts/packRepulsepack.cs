//---------------------------------------------------
//	REPULSE PACK
//---------------------------------------------------

ItemImageData RepulsePackImage 
{
	shapeFile = "sensor_small";
	mountRotation = { 11, 0, 0 };
	mountOffset = { 0, -0.10, 0.05 };
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	//sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData RepulsePack
{
	description = "Repulse Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = RepulsePackImage;
	price = 650;
	hudIcon = "plasma";
	showWeaponBar = true;
	//hiliteOnActive = true;
};

$RepulsePackPower = 2048;
$RepulsePackPowerLow = 368;

function RepulsePackImage::onActivate(%player,%imageSlot)
{
    %clientId = Player::getclient(%player);
    Player::trigger(%player,%imageslot,false);
    %set = newObject("set",SimSet);
    %ppos = GameBase::getPosition(%player);
    %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 20, 20, 20,0);
    for (%i=0; %i<%num; %i++)
    {
      %oply = Group::getObject(%set,%i);
      if (%oply != %player)
      { 
        %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
        if (%clientId.isAdmin == true)
            %vec = (getWord(%vec, 0) * $RepulsePackPowerLow) @ " " @ (getWord(%vec, 1) * $RepulsePackPowerLow) @ " " @ (getWord(%vec, 2) * $RepulsePackPowerLow);
        if (%clientId.isSuperadmin == true)
            %vec = (getWord(%vec, 0) * $RepulsePackPower) @ " " @ (getWord(%vec, 1) * $RepulsePackPower) @ " " @ (getWord(%vec, 2) * $RepulsePackPower);
        Player::applyImpulse(%oply, %vec);
      }
    }
    deleteObject(%set);
    Client::sendMessage(Player::getClient(%player),1, "Repulse Pack: Used");
    //GameBase::playSound(%player, SoundFireMortar, 0);
    Player::decItemCount(%player,%item);
}

function RepulsePackImage::onDeactivate(%player,%imageSlot) 
{

}
