//Deadtaco's super cool opening door.  Not perfected yet (it wont crush you yet) but it works.

$TeamItemMax[OpenableDoor] = 10;
$ItemMax[hlarmor, OpenableDoorPack] = 0;
$ItemMax[hlfemale, OpenableDoorPack] = 0;
$ItemMax[larmor, OpenableDoorPack] = 0;
$ItemMax[lfemale, OpenableDoorPack] = 0;
$ItemMax[earmor, OpenableDoorPack] = 1;
$ItemMax[efemale, OpenableDoorPack] = 1;
$ItemMax[marmor, OpenableDoorPack] = 0;
$ItemMax[mfemale, OpenableDoorPack] = 0;
$ItemMax[harmor, OpenableDoorPack] = 0;
$ItemMax[uharmor, OpenableDoorPack] = 0;
$HelpMessage[OpenableDoorPack] = "These doors open only for your team, but can be blown up easily by C4."; 
$InvList[OpenableDoorPack] = 1;
$RemoteInvList[OpenableDoorPack] = 1;


ItemImageData OpenableDoorPackImage
{
	shapeFile = "AmmoPack";
	OpenableDoor = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData OpenableDoorPack
{
	description = "Automatic Door";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "hField Deployment";
	imageType = OpenableDoorPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function OpenableDoorPack::onUse(%player,%item)
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

function OpenableDoorPack::onDeploy(%player,%item,%pos)
{
	if (OpenableDoor::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item); 
	}
}


// Openable Doors by DeadTaco

function OpenableDoor::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "OpenableDoor"] < $TeamItemMax[OpenableDoor])
	{
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "Blastwallshape" || GameBase::getDataName($los::object) == "OutpostWall" || GameBase::getDataName($los::object) == "SniperPerchPlatform" || GameBase::getDataName($los::object) == "OutPostFloor") 
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

					%camera = newObject("OpenableDoor","StaticShape",OpenableDoorShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					%offset = "-0.0 1.1 0.0";
					%myrot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					%xRot = getWord(%prot,0);
					%yRot = getWord(%prot,1);

					%camera.opening = 0;
					GameBase::setRotation(%camera,%xrot @ " 0 " @ %zrot);
					// GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"OpenableDoor" @ Client::getName(%client));
					
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "OpenableDoor"]++;
					// echo("MSG: ",%client," deployed a OpenableDoor.");
					return true;
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain, buildings, or other OpenableDoors");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
			else
			Client::sendMessage(%client,0,"Too many doors deployed.");
        return false;
}


//---------------------------------------------static shape information---------------------------------------

//Deadtaco made a cool door.  Give him money.

StaticShapeData OpenableDoorShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 500.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "OpenableDoor";
	damageSkinData = "objectDamageSkins";
};

function OpenableDoorShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function OpenableDoorShape::onDestroyed(%this)
{

	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "OpenableDoor"]--;

}




function OpenableDoorShape::onCollision(%this,%obj)
{

	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if (%fieldTeam != %playerTeam)
	{
		%rnd = floor(getRandom() * 20);
		if(%rnd > 2)
		{	
		bottomprint(Player::getClient(%OBJ), "<jc><f4>You tried picking the lock but it failed.  Try again.", 1); 
		return false;

		}
	}



	if (%this.opening != 1)
	{
		%prot = GameBase::getPosition(%this);
		%zpos = getWord(%prot,2);
		%this.opening = 1;
		%this.vertical = %zpos;
		OpenableDoorShape::openMeVertical(%this);
	}
}


function OpenableDoorShape::openMeVertical(%this)
{
	%ppos = GameBase::getPosition(%this);
	%xpos = getWord(%ppos,0);
	%ypos = getWord(%ppos,1);

	//elevation to open up the door is %spd
	%spd = 3;   

	playSound(SoundDoorOpen,GameBase::getPosition(%this));

	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.1 * %spd) @ '"' @ ");", 0.1);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.2 * %spd) @ '"' @ ");", 0.2);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.3 * %spd) @ '"' @ ");", 0.3);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.4 * %spd) @ '"' @ ");", 0.4);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.5 * %spd) @ '"' @ ");", 0.5);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.6 * %spd) @ '"' @ ");", 0.6);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.7 * %spd) @ '"' @ ");", 0.7);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.8 * %spd) @ '"' @ ");", 0.8);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.9 * %spd) @ '"' @ ");", 0.9);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (1.0 * %spd) @ '"' @ ");", 1.0);
	schedule("playSound(SoundDoorClose,GameBase::getPosition(" @ %this @ "));", 5.1);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.9 * %spd) @ '"' @ ");", 5.1);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.8 * %spd) @ '"' @ ");", 5.2);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.7 * %spd) @ '"' @ ");", 5.3);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.6 * %spd) @ '"' @ ");", 5.4);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.5 * %spd) @ '"' @ ");", 5.5);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.4 * %spd) @ '"' @ ");", 5.6);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.3 * %spd) @ '"' @ ");", 5.7);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.2 * %spd) @ '"' @ ");", 5.8);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.1 * %spd) @ '"' @ ");", 5.9);
	schedule("GameBase::setPosition(" @ %this @ ", " @ '"' @ %xpos @ " " @ %ypos @ " " @ %this.vertical + (0.0 * %spd) @ '"' @ ");", 6.0);
	schedule(%this @ ".opening = 0;", 6.0);
	


}


