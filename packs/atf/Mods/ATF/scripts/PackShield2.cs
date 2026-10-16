//--------------------------------------

$InvList[ShieldPack2] = 1;
$RemoteInvList[ShieldPack2] = 1;

//--------------------------------------

ItemImageData ShieldPackImage2
{
	shapeFile = "Generator_p";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 9;
	maxEnergy = 10;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack2
{
	description = "Shield Generator";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage2;
	price = 475;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage2::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.12;
}

function ShieldPackImage2::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0.012;
}

//--------------------------------------