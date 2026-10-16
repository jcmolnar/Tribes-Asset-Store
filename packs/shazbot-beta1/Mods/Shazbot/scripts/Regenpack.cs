$ItemMax[harmor, RegenerationPack] = 1;

$InvList[RegenerationPack] = 1;
$RemoteInvList[RegenerationPack] = 1;

AddItem(RegenerationPack);

ItemImageData RegenerationPackImage 
{	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RegenerationPack 
{	description = "Regenration Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RegenerationPackImage;
	price = 275;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RegenerationPack::OnMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	
	bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);
	Player::trigger(%player,$BackpackSlot,true);
}
 
function Regeneration::onUnmount(%player,%item)
{	
}

function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
	%player.regen = true;
	schedule("checkRegeneration(" @ %player @ ");",0.1,%player);
}

function RegenerationPackImage::onDeactivate(%player,%item)
{	
	%player.regen = false;
}

function checkRegeneration(%player, %switch)
{	
	if(%player.regen == false)
		return;
	if(Player::isDead(%player))
		return;
	if(Player::getMountedItem(%player,$BackpackSlot) != "RegenerationPack")
		return;
	
	%dlev = GameBase::getDamageLevel(%player);
	%armor = Player::getArmor(%player);
	if(%armor == "harmor")
	{
		GameBase::setDamageLevel(%player, %dlev+0.475);
	}
	else
	{
		GameBase::setDamageLevel(%player, %dlev-0.0275);
	}
	schedule("checkRegeneration(" @ %player @ ");",1,%player);
}

function RegenerationPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}
