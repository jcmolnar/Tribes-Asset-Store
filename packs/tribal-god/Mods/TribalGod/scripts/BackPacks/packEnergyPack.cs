// Energy Pack is now Engineer Pack. -DB

ItemImageData EnergyPackImage {
	shapeFile  = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy  = -1;
 	maxEnergy  = -20;
	firstPerson = false;
};

ItemData EnergyPack {
	description = "Engineer Pack";
	shapeFile = "jetPack";
	className = "Backpack";
    heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
    validateShape = false;
    validateMaterials = false;
};

function EnergyPack::onUse(%player, %item){
	if(Player::getMountedItem(%player, $BackpackSlot) != %item){
		Player::mountItem(%player, %item, $BackpackSlot);
	}else{
		%armor = Player::getArmor(%player);
		if(Player::isTriggered(%player, $BackpackSlot)){
			if(%player.etoggle == 1){
				Player::mountItem(%player, RepairGun, $ToolSlot);
				BottomPrint(Player::getClient(%player), "<jc><f1>Repair Gun");
				%player.etoggle = 0;
				return;
			}else{
				Player::mountItem(%player, HackGun, $ToolSlot);
				BottomPrint(Player::getClient(%player), "<jc><f1>Hack Gun");
				%player.etoggle = 1;
				return;
			}
		}
		Player::trigger(%player, $BackpackSlot);
	}
}
function EnergyPack::onActivate(%player, %imageSlot){
	%client = Player::getClient(%player);
	Client::sendMessage(%client, 0, "Engineer Pack: Enabled~wshieldhit.wav");
	Player::mountItem(%player, RepairGun, $ToolSlot);
	%player.etoggle = 0;
	%player.shieldStrength = 1.0;
	%player.isUnNukable = true;
}
function EnergyPack::onDeactivate(%player, %imageSlot){
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Engineer Pack: Disabled~wturretoff1.wav");
	%player.shieldStrength = 0;
	%player.isUnNukable = false;
}