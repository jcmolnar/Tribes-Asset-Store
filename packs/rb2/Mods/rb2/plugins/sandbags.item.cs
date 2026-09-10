//Sand bags by Deadtaco

$TeamItemMax[SandBag] = 100;
$ItemMax[hlarmor, SandbagPack] = 0;
$ItemMax[hlfemale, SandbagPack] = 0;
$ItemMax[larmor, SandbagPack] = 0;
$ItemMax[lfemale, SandbagPack] = 0;
$ItemMax[earmor, SandbagPack] = 1;
$ItemMax[efemale, SandbagPack] = 1;
$ItemMax[marmor, SandbagPack] = 0;
$ItemMax[mfemale, SandbagPack] = 0;
$ItemMax[harmor, SandbagPack] = 0;
$ItemMax[uharmor, SandbagPack] = 0;
$HelpMessage[SandbagPack] = "Sandbags to hide behind."; 
$InvList[SandbagPack] = 1;
$RemoteInvList[SandbagPack] = 1;


ItemImageData SandbagPackImage
{
	shapeFile = "AmmoPack";
	Sandbag = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData SandbagPack
{
	description = "Sand Bag";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "hField Deployment";
	imageType = SandbagPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SandbagPack::onUse(%player,%item)
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

function SandbagPack::onDeploy(%player,%item,%pos)
{
	if (Sandbag::deployShape(%player,%item))
	{
		// Player::decItemCount(%player,%item); 
	}
}


// Sandbags by DeadTaco

function Sandbag::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "SandBag"] < $TeamItemMax[Sandbag])
	{
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
    		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,3,3,3,0);
		%num = CountObjects(%set,"DeployableSeeker",%num);
		deleteObject(%set);
		if(0 == %num) 
		{
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "SandbagShape" || GameBase::getDataName($los::object) == "OutpostWall" || GameBase::getDataName($los::object) == "SniperPerchPlatform") 
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

					%camera = newObject("Sandbag","StaticShape",SandbagShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					%offset = "-0.0 1.1 0.0";
					%myrot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					%xRot = getWord(%prot,0);
					%yRot = getWord(%prot,1);


					GameBase::setRotation(%camera,%xrot @ " 0 " @ %zrot);
					// GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Sandbag" @ Client::getName(%client));
					$los::object.buddy = %camera;
					
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Sandbag"]++;
					// echo("MSG: ",%client," deployed a sandbag.");
					return true;
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain, buildings, or other sandbags");
		}
		else
			Client::sendMessage(%client,0,"Sandbag can't blockwwwwww a claymore");
	}
	else
	Client::sendMessage(%client,0,"Position out of range.");
	}
			else
			Client::sendMessage(%client,0,"We're out of sand.");
        return false;
}


//---------------------------------------------static shape information---------------------------------------


StaticShapeData SandbagShape
{
        shapeFile = "mineammo";
        debrisId = defaultDebrisLarge;
        maxDamage = 100.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Sandbag";
};

function SandbagShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;

	if(%type == $BulletDmgType9)
	{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,"0 0 10");
	}

	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function SandbagShape::onDestroyed(%this)
{

	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "Sandbag"]--;

}

function SandbagShape::onCollision(%this,%obj)
{
 

}