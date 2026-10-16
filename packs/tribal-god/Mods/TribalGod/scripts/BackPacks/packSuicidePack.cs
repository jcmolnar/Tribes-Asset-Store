ItemImageData SuicidePackImage {
	shapeFile = "mineammo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = true;
};

ItemData SuicidePack {
	description = "Suicide DetPack";
	heading = $InvHeading[BackPacks];
	imageType = SuicidePackImage;
	hudIcon = "deployable";
	shapeFile = "mineammo";
	className = "Backpack";
	hiliteOnActive = true;
	showWeaponBar = true;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 450;
	mass = 2.5;
};

function SuicidePack::onUse(%player,%item) {
	if(Player::getMountedItem(%player, $BackpackSlot) != %item){
		Player::mountItem(%player, %item, $BackpackSlot);
	}else{
		Player::deployItem(%player, %item);
	}
}
function SuicidePack::onUnmount(%player, %item){
	if(Player::isDead(%player)){
		return;
	}
	Schedule("deleteObject("@ %item @");", 0.1, %item);
}
function SuicidePack::onDeploy(%player, %item, %pos){
	if(Player::isDead(%player)){
		return;
	}
	if(SuicidePack::deployShape(%player, %item)){
		Player::decItemCount(%player, %item);
	}
}
function SuicidePack::deployShape(%player, %item){
	Player::unmountItem(%player, $BackpackSlot);
	%obj = newObject("","Mine","Suicidebomb2");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj, %player, 3 * %client.throwStrength, false);
	Client::sendMessage(%client, 1, "Det Pack will Self-Destruct in 20 seconds");
	Echo("MSG: "@ %client @" deployed a Suicide Pack");
	%obj.player = %player;
}


$AutoUse[instantHealth] = false;

$ItemMax[larmor, instantHealth]  = 3;
$ItemMax[marmor, instantHealth]  = 5;
$ItemMax[harmor, instantHealth]  = 7;
$ItemMax[lfemale, instantHealth] = 3;
$ItemMax[mfemale, instantHealth] = 5;

ItemData instantHealth {
   description = "Instant Health";
   shapeFile   = "armorKit";
   heading     = $InvHeading[Misc];
   shadowDetailMask = 4;
   price            = 35;
   validateShape    = false;
   validateMaterials = false;
};
function instantHealth::onUse(%player,%item){
	Player::decItemCount(%player, %item);
	GameBase::repairDamage(%player, 0.99);
}
function instantHealth::onCollision(%this, %object){
	if(getObjectType(%object) == "Player" && GameBase::getTeam(%object) == GameBase::getTeam(%this)){
		%client = Player::getClient(%object);
//		Client::sendMessage(%client, 0, "");
		%data = GameBase::getDataName(%object);
		if(%data.maxDamage != "" && %data.maxDamage != -1 && %data.maxDamage != false){
			GameBase::repairDamage(%object, %data.maxDamage);
			return;
		}else{
			GameBase::repairDamage(%object, 10);
			return;
		}
	}
}