//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|


ItemImageData TG::BlastFloorImage
{
	shapeFile = "plasmabolt";
	mountPoint = 2; 
	mountOffset = { 0, -0.03, -0.4 }; 
	mass = 1.5; 
	firstPerson = false;
};
ItemData TG::BlastFloorPack
{
	description = "Blast Floor";
	shapeFile   = "display_three";
	className   = "Backpack";
	heading     = $InvHeading[Walls];
	imageType   = TG::BlastFloorImage;
	shadowDetailMask = 4;
	elasticity  = 0.2;
	price       = 500;
	hudIcon     = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function TG::BlastFloorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else{ Player::deployItem(%player,%item); }
}
function TG::BlastFloorPack::onDeploy(%player,%item,%pos)
{
	if(TG::BlastFloorPack::deployShape(%player,%item))
	{ Player::decItemCount(%player,%item); }
}


function TG::BlastFloorPack::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	%playerPOS = GameBase::getPosition(%player);
	%playerROT = GameBase::getRotation(%player);
	
	if($TeamItemCount[%team @"TG::BlastFloorPack"] >= $TeamItemMax[TG::BlastFloorPack])
	{ Client::sendMessage(%client, 0, "Deployable Limit Reached For "@ %item.description @"s."); return false; }
	
	%deploypos = Vector::add(%playerPOS, EmplacementPack::rotVector("0 3 0", %playerROT));
//	if(Vector::dot($los::normal, "0 0 1") < 0.7 )
//	%deploypos = Vector::add(%deploypos, "0 0 0");
	
	%rot = Vector::add(%playerROT, "1.57 0 0");
	%floor = newObject("Blast Floor", "StaticShape", "BlastWallShape", true);
	addToSet("MissionCleanup", %floor);
	GameBase::setTeam(%floor, %team);
	GameBase::setRotation(%floor, %rot);
	GameBase::setPosition(%floor, %deploypos);
	Gamebase::setMapName(%floor, "Blast Floor");
	Client::setOwnedObject(%client, %player);
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[%team @"TG::BlastFloorPack"]++;
	Client::sendMessage(%client, 0, "Blast Floor deployed");
	return true;
}