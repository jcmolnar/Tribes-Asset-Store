$InvList[PhasePack] = 1;
$RemoteInvList[PhasePack] = 1;
//---- Armordata Stuff---///
$ItemMax[larmor, PhasePack] = 1;       
$ItemMax[lfemale, PhasePack] = 1;       
$ItemMax[marmor, PhasePack] = 0;       
$ItemMax[mfemale, PhasePack] = 0;       
$ItemMax[harmor, PhasePack] = 0;       

ItemImageData PhasePackImage 
{	
	shapeFile = "plant2";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, 0, -0.8 };
	lightType = 2;   // Pulsing
	lightRadius = 15;
	lightTime = 0.75;
	lightColor = { 0, 1.0, 0 };
	minEnergy = -30;
	maxEnergy = -12;
	firstPerson = false;
};

ItemData PhasePack 
{	
	description = "Sprout Manuever Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = zSpecial;
	shadowDetailMask = 4;
	imageType = PhasePackImage;
	price = 1750;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PhasePackImage::onActivate(%player,%imageSlot)
{

	%pos = GameBase::getPosition(%player);
	%pos = Vector::add(%pos, "0 0 -2");

	GameBase::setPosition(%player,%pos);
}

function PhasePackImage::onDeactivate(%player,%imageSlot) 
{	
	Client::sendMessage(Player::getClient(%player),0,"Seed Growth is off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
