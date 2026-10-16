ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player,$BackpackSlot) != %item){ Player::mountItem(%player,%item,$BackpackSlot); }else{ Player::deployItem(%player,%item); } }

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{ if(DeployableAmmoPack::deployShape(%player,%item)){ Player::decItemCount(%player,%item); } }	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if(GameBase::getLOSInfo(%player, 3))
		{
			%Set = newObject("set",SimSet);
			%Mask = $StaticObjectType;
			%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
			for(%i; %i < %num; %i++)
			{
				%thing = Group::getObject(%Set, %i);
				if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				{
					%inbase= true;
					break;
				}
			}
			deleteObject(%Set);
			
			if(%inbase)
			{
				%obj = getObjectType($los::object);
				if (%obj == "SimTerrain" || %obj == "InteriorShape")
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
							addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Ammo Station deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
							echo("MSG: ",%client," deployed an Ammo Station");
							return true;
						}
					}
					else 
					{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); }
				}
				else 
				{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); }
			}
			else
			{ bottomprint(%client, "<jc>Fair play distance exceeded for " @ %item.description @ "s", 3); }
		}
		else 
		{ Client::sendMessage(%client,0,"Deploy position out of range"); }
	}
	else
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); }
	return false;
}