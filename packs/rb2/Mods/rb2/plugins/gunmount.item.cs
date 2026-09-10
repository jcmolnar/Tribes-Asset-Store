//Gun mount for mounted machineguns

$ItemMax[hlarmor, MountPack] = 0;
$ItemMax[hlfemale, MountPack] = 0;
$ItemMax[larmor, MountPack] = 0;
$ItemMax[lfemale, MountPack] = 0;
$ItemMax[earmor, MountPack] = 1;
$ItemMax[efemale, MountPack] = 1;
$ItemMax[marmor, MountPack] = 0;
$ItemMax[mfemale, MountPack] = 0;
$ItemMax[harmor, MountPack] = 0;
$ItemMax[uharmor, MountPack] = 0;
$HelpMessage[MountPack] = "A gun mount for heavy machineguns."; 
$InvList[MountPack] = 1;
$RemoteInvList[MountPack] = 1;


ItemImageData MountPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData MountPack
{
	description = "Machinegun Mount";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "fTurrets";
	imageType = MountPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MountPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function MountPack::onDeploy(%player,%item,%pos)
{
	if (MountPoint::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item); 
	}
}


// Gun mount for Machineguns by DeadTaco

function MountPoint::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "MountPointShape" || GameBase::getDataName($los::object) == "OutpostWall" || GameBase::getDataName($los::object) == "SniperPerchPlatform") 
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{
					%rot = "-0.0 0 " @ %zRot;
				}
				else 	
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{
						%rot = "-0.0 0 " @ %zRot;
					}
					else 
					{
						%rot = Vector::getRotation($los::normal);
					}
				}

					%camera = newObject("MountPoint","StaticShape",MountPointShape,true);
					addToSet("MissionCleanup", %camera);
					// player::tacodesign(%player);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"MG Mount" @ Client::getName(%client));
					Client::sendMessage(%client,0,"Mount deployed");
					playSound(SoundPickupBackpack,$los::position);
					// $TeamItemCount[GameBase::getTeam(%camera) @ "MountPoint"]++;
					echo("MSG: ",%client," deployed a machinegun mount.");
					return true;
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain, buildings, or other ramps");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
        return false;
}


//---------------------------------------------static shape information---------------------------------------

StaticShapeData MountPointShape
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisLarge;
        maxDamage = 50.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Machinegun Mount Point";
};

function MountPointShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;

	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale * 2;
	if(%type == 10)
		%TDS = 5000;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function MountPointShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "MountPoint"]--;

}

function player::tacodesign(%this)
{
	%position = Vector::add(gamebase::getposition(%this), "0 0 20");
	// messageall(1, gamebase::getposition(%this) @ " and " @ %position);
	%spacing = 1.7;

%offset[0] = " " @ 0*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[1] = " " @ 1*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[2] = " " @ 2*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[3] = " " @ 3*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[4] = " " @ 4*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[5] = " " @ 7*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[6] = " " @ 12*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[7] = " " @ 13*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[8] = " " @ 16*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[9] = " " @ 17*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[10] = " " @ 18*%spacing @ " " @ 0.0 @ " " @ 52*%spacing @ " ";
%offset[11] = " " @ 2*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[12] = " " @ 6*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[13] = " " @ 8*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[14] = " " @ 11*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[15] = " " @ 15*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[16] = " " @ 19*%spacing @ " " @ 0.0 @ " " @ 51*%spacing @ " ";
%offset[17] = " " @ 2*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[18] = " " @ 6*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[19] = " " @ 8*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[20] = " " @ 11*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[21] = " " @ 15*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[22] = " " @ 19*%spacing @ " " @ 0.0 @ " " @ 50*%spacing @ " ";
%offset[23] = " " @ 2*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[24] = " " @ 5*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[25] = " " @ 6*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[26] = " " @ 7*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[27] = " " @ 8*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[28] = " " @ 9*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[29] = " " @ 11*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[30] = " " @ 15*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[31] = " " @ 19*%spacing @ " " @ 0.0 @ " " @ 49*%spacing @ " ";
%offset[32] = " " @ 2*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[33] = " " @ 5*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[34] = " " @ 9*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[35] = " " @ 12*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[36] = " " @ 13*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[37] = " " @ 16*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[38] = " " @ 17*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";
%offset[39] = " " @ 18*%spacing @ " " @ 0.0 @ " " @ 48*%spacing @ " ";



	 for(%i = 0; %i < 40; %i++)
	 {

	%mgpole = newObject("Machinegun Mount","StaticShape",MountPointShape,true);
	addToSet("MissionCleanup", %mgpole);
	GameBase::setTeam(%mgpole,GameBase::getTeam(%player));
	GameBase::setPosition(%mgpole,Vector::add(%position, %offset[%i]));
	GameBase::setRotation(%mgpole,"1.5 0 0");
	Gamebase::setMapName(%mgpole,"THIS TACO RULES!");

	 }

}
