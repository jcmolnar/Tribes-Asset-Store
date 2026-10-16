//--------------------------------------

addToInv(ShieldPack,1,1);

setArmorItemMax(ShieldPack,1,1,1);

//--------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;	 // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = $InvCatPacks;
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   //validateMaterials = true;
};

$MountMSG[ShieldPack] = "<JC><F2>Shield Pack <F0>- <F1>Protects user from some damage.";

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
	%player.Shielded = true;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	if(%player.Shielded) {
		Client::sendMessage(Player::getClient(%player),0,"Shield Off");
		%player.shieldStrength = 0;
		%player.Shielded = false;
		Player::trigger(%player,$BackpackSlot,false);
	}
}

//--------------------------------------
