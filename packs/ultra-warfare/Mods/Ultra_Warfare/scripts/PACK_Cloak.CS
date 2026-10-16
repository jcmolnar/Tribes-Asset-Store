//================================================================
//cloaking device
//================================================================
$ItemMax[larmor, cloakingdevice] = 1;
$ItemMax[lfemale, cloakingdevice] = 1;
$ItemMax[marmor, cloakingdevice] = 0;
$ItemMax[mfemale, cloakingdevice] = 0;
$ItemMax[harmor, cloakingdevice] = 0;
//================================================================
$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;
//================================================================
SoundData SoundCloakOn
{
   wavFileName = "pack_cloakon.wav";
   profile = Profile3dNearLoop;
};
//======================================
ItemImageData CloakingDeviceImage
{
	shapeFile = "pack_cloak";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 5;
	minEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundCloakOn;
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Pack";
	shapeFile = "pack_cloak";
	className = "Backpack";
	heading = "gUtility Packs";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "cloak";
	showWeaponBar = true;
	hiliteOnActive = true;
	
	//validateShape = true;
	//validateMaterials = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if ((%armor != "aarmor") && (%armor != "afemale"))
	{
		GameBase::startFadeout(%player);
		Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
		%rate = Player::getSensorSupression(%player) + 5;
		Player::setSensorSupression(%player,%rate);
	}
	else
	{
		%obj = newObject("","Mine","CloakBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%player), %padd);
		GameBase::setPosition(%obj, %pos);	
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{

	%armor = Player::getArmor(%player);

	 if ((%armor != "carmor") && (%armor != "cfemale"))
	 {
		GameBase::startFadein(%player);
		Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,%rate);
		Player::trigger(%player,$BackpackSlot,false);
	 }
	 else
		Player::trigger(%player,%imageslot,false);

}


//================================================================
