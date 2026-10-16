//=-=-=-=-=- Teleporter =-=-=-=-=-//
StaticShapeData DeployableTeleport
{
    className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 20;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = mortarExp;
    debrisId = flashDebrisLarge;

	lightRadius = 1;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};
	
function RemoveBeam(%b)
{ deleteObject(%b); }		

function DeployableTeleport::Reenable(%this)
{ %this.disabled = false; }		

function DeployableTeleport::Destruct(%this)
{}
														 
function DeployableTeleport::onDestroyed(%this)
{
	Schedule("RemoveBeam("@ %this.beam1 @");", 1);
	//CalcRadiusDamage(%this,$DebrisDamageType, 20, 0.1, 25, 20, 3, 3, 0.1, 200, 100);
	
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o, $DebrisDamageType, 20, GameBase::getPosition(%o), "0 0 0", "0 0 0", %this);
			return;
		}
	}
}

function DeployableTeleport::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }
	
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	
	if(%teleTeam != %playerTeam)
	{ Client::SendMessage(%c, 0, "Wrong team"); return; }
	
	if(%this.disabled == true)
	{ Client::SendMessage(%c, 0, "Teleport Pad is recharging"); return; }
	
	%teleset = nameToID("MissionCleanup/Teleports");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{
			if(Player::getArmor(%obj) == "harmor" || Player::getArmor(%obj) == "marmor")
			{ Client::SendMessage(%c, 0, "Cannot teleport in this Armor class"); return; }
			else
			{
				GameBase::playSound(%o, ForceFieldOpen, 0);
				GameBase::playSound(%this, ForceFieldOpen, 0);
				GameBase::SetPosition(%obj, GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				// GameBase::applyDamage(%obj, $CrushDamageType, 0.15, GameBase::getPosition(%o), "0 0 0", "0 0 0", %this);
				
				if(floor(getRandom() * 55) == 0)
				{
					if(!%c.isGodAdmin)
					{
						Client::SendMessage(%c, 0, "Teleport phased your molecular structure wrong");
						GameBase::applyDamage(%obj, $CrushDamageType, 0.15,GameBase::getPosition(%o), "0 0 0", "0 0 0", %this);
					}
					else
					{
						schedule("DeployableTeleport::Reenable("@ %o @");", 5);
						schedule("DeployableTeleport::Reenable("@ %this @");", 5);
					}
				}
				else
				{
					schedule("DeployableTeleport::Reenable("@ %o @");", 5);
					schedule("DeployableTeleport::Reenable("@ %this @");", 5);
				}
				return;
			}
		}
	}
	Client::SendMessage(%c, 0, "No other pad to teleport to");
}

ItemImageData TeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    heading = $InvHeading[Deployables];
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function TeleportPack::onDeploy(%player,%item,%pos)
{ if(teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)){ Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @"DeployableTeleport"]++; } }

function CreateteleportSimSet()
{ %teleset = nameToID("MissionCleanup/Teleports"); if(%teleset == -1){ newObject("Teleports", SimSet); addToSet("MissionCleanup", "Teleports"); } }

// Re-Coded to fix a few problems i've noticed [TG]-X-Ecutioner || Dustin B :)
function TeleportPack::deployShape(%player, %name, %shape, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"] >= $TeamItemMax[TeleportPack])
	{
		Client::sendMessage(%client, 0, "The limit is "@ $TeamItemMax[DeployableTeleport] @", and your tryin to use more!");
		%Slapdir = Vector::getFromRot(GameBase::getRotation(%player), -175, 4);
		%pack = Player::getMountedItem(%player, 1);
		Schedule("CenterPrint("@ %client @", \"<jc><f2>You Just Got Bitch Slapped!\", 7);", 1.5);
		Player::dropitem(%player,%pack);
		// to make sure we don't get the item thrown at us we will 
		// drop the pack, then 1.5 secs later slap the bnatch
		Schedule("Player::ApplyImpulse("@ %player @", "@ %Slapdir @");", 1.5);
		return false;
	}
	
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }
	
	%Set = newObject("set",SimSet);
	%Mask = $StaticObjectType;
	%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
	for(%i; %i < %num; %i++)
	{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
			%inbase = true;
			break;
		}
	}
	deleteObject(%Set);
	
	if(!%inbase)
	{ BottomPrint(%client, "<jc><f1> Fair play distance exceeded for <f2>"@ %item.description @"s", 3); }
	
	%obj = getObjectType($los::object); 
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape")
	{ Client::sendMessage(%client, 0, "Can only deploy on terrain or buildings");  return false; }     
	
	if(Vector::dot($los::normal,"0 0 1") < 0.7)
	{ Client::sendMessage(%client, 0, "Can Only Deploy On Flat Surfaces."); return false; }
	
	%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
	CreateteleportSimSet();
	addToSet("MissionCleanup/Teleports", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 0 1");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	
	%beam = newObject("","StaticShape", ElectricalBeamBig, true);
	addToSet("MissionCleanup", %beam);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	GameBase::setPosition(%beam,%pos);
	%sensor.beam1 = %beam;
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	Client::sendMessage(%client,0,%item.description @ " deployed");
	return true;
}