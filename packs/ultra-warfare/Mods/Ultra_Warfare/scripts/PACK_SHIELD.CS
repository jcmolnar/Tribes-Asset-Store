//================================================================
//shield Pack
//================================================================
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[harmor, ShieldPack] = 1;
//================================================================
$InvList[ShieldPack] = 1;
$RemoteInvList[ShieldPack] = 1;
//================================================================
SoundData SoundShieldOn
{
   wavFileName = "pack_shieldon.wav";
   profile = Profile3dNearLoop;
};
//====================================
ItemImageData ShieldPackImage
{
	shapeFile = "pack_shield";
	mountPoint = 2;
	mountOffset = { 0, 0.0, -0.2 };
	weaponType = 2;  // Sustained
	minEnergy = 5;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "pack_shield";
	className = "Backpack";
   heading = "gUtility Packs";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "packshield";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   //validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.75;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
//================================================================