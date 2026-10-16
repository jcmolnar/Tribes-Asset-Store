//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemImageData HoloPackImage
{
	shapeFile = "larmor";
	mountPoint = 2;
	mountOffset = { 1.5, 0.8, -1.50};
	mass = 1.0;
	firstPerson = false;
};

ItemData HoloPack
{
	description = "Hologram";
	shapeFile = "larmor";
	className = "Backpack";
	heading = $InvHeading[Deployables2];
	imageType = HoloPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 900;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player,%item,$BackpackSlot); }
	else
	{ Player::deployItem(%player,%item); }
}

function HoloPack::onDeploy(%player,%item,%pos)
{
	if(HoloPack::deployShape(%player,%item))
	{ Player::decItemCount(%player,%item); }
}

function HoloPack::deployShape(%player, %item){
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @"hologram"] < $TeamItemMax["hologram"]){
		if(GameBase::getLOSInfo(%player, 3)){
			%obj = getObjectType($los::object);
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
			%num = CountObjects(%set,"Hologram",%num);
			deleteObject(%set);
			if(Vector::dot($los::normal,"0 0 1") > 0.7){
				if(checkDeployArea(%client,$los::position)){
					%rot = GameBase::getRotation(%player);
					%rnd = floor(getRandom() * 10);
					if(%rnd > 6) %fField = newObject("", "StaticShape", Hologram1, true);
					else if((%rnd > 2) && (%rnd < 7)) %fField = newObject("", "StaticShape", Hologram2, true);
					else %fField = newObject("", "StaticShape", Hologram3, true);
					addToSet("MissionCleanup", %fField);
					GameBase::setTeam(%fField, GameBase::getTeam(%player));
					GameBase::setPosition(%fField, $los::position);
					GameBase::setRotation(%fField,%rot);
					Client::sendMessage(%client,0,"Hologram Deployed");
					echo("MSG: ",%client," deployed a Hologram");
					GameBase::startFadeIn(%fField);
					playSound(ForceFieldOpen,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
					return true;
				}
			}
			else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else Client::sendMessage(%client, 0, "Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for "@ %item.description @"s");
	return false;
}