// Originally From BioWasteLand Mod.

StaticShapeData Portal
{ shapeFile = "plasmawall"; debrisId = defaultDebrisLarge; maxDamage = 200; isTranslucent = true; visibleToSensor = true; description = "Portal"; };

function Portal::onCollision(%this, %obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor  = Player::getArmor(%clientId);
	%data   = GameBase::getDataName(%obj); 
	%thisTeam = GameBase::getTeam(%this);
	%objTeam = GameBase::getTeam(%player);
	
	if(%objTeam != %thisTeam)
	{ return; }
	
	if(%this.activated == true || Player::isDead(%obj))
	{ return; }
	else
	{ GameBase::applyDamage(%player, $TrapDam1, 0.01, GameBase::getPosition(%player), "0 0 0", "0 0 0", %this); }
	return;
}
function Portal::onDestroyed(%this)
{ StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "HolePack"]--; }

ItemImageData HolePackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 3;
	firstPerson = false;
};

ItemData HolePack
{
    description = "Portable Hole";
    shapeFile = "display_three";
    className = "Backpack";
    heading = $InvHeading[Deployables];
    imageType = HolePackImage;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function HolePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}

function HolePack::onDeploy(%player,%item,%pos)
{ if(HolePack::deployShape(%player,%item)){ Player::decItemCount(%player, %item); } }

function HolePack::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if(%client.jailed == true)
	{ Client::sendMessage(%client, 0, "Jail's New AntiHole Coding Will Not Allow That.~wAccess_Deinied.Wav"); return false; }
	
	%object = (deployable(%player, %item, "StaticShape", "Portal", false, false, false, false, false, false, false, 5, true, 25, true, "Portal", "HolePack"));
	if(%object)
	{
		%client = Player::getClient(%player);
		%team = Client::getTeam(%client);
		TeamMessages(0, %team, "Friendly Portal Deployed~welevator2.wav", -2, "Hull Breech!~welevator2.wav", "Hull Breech!~welevator2.wav");
		Client::sendMessage(%client, 0, "Establishing team access: 2 points.");
		%client.score += 2;
		return true;
	}
}