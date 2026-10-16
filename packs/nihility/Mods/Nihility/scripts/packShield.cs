//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[ShieldPack] = 1;

$ItemMax[larmor, ShieldPack] = 0;	//Seraph
$ItemMax[lfemale, ShieldPack] = 0;	//Seraph
$ItemMax[earmor, ShieldPack] = 0;	//Slave
$ItemMax[efemale, ShieldPack] = 0;	//Slave
$ItemMax[marmor, ShieldPack] = 0;	//Pawn
$ItemMax[aarmor, ShieldPack] = 0;	//Navigator
$ItemMax[darmor, ShieldPack] = 1;	//Atomizer
$ItemMax[barmor, ShieldPack] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData ShieldPackImage 
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 4;
	maxEnergy = 9;
	sfxFire = SoundShieldOn;
	firstPerson = false;
}; 

ItemData ShieldPack 
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 33;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Barrier field generated...");
	%player.shieldStrength = 0.0162;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Barrier field shut-down...");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
} 
