//Gun mount for mounted machineguns

$ItemMax[hlarmor, KneePack] = 0;
$ItemMax[hlfemale, KneePack] = 0;
$ItemMax[larmor, KneePack] = 1;
$ItemMax[lfemale, KneePack] = 1;
$ItemMax[earmor, KneePack] = 1;
$ItemMax[efemale, KneePack] = 1;
$ItemMax[marmor, KneePack] = 1;
$ItemMax[mfemale, KneePack] = 1;
$ItemMax[harmor, KneePack] = 1;
$ItemMax[uharmor, KneePack] = 1;
$HelpMessage[KneePack] = "A fixed angle mortar that can be rotated to fire at different directions.";
$InvList[KneePack] = 1;
$RemoteInvList[KneePack] = 1;


ItemImageData KneePackImage
{
	shapeFile = "grenadel";
	KneePoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 1.5, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData KneePack
{
	description = "Knee Mortar";
	shapeFile = "grenadel";
	className = "Backpack";
	heading = "fTurrets";
	imageType = KneePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function KneePack::onUse(%player,%item)
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

function KneePack::onDeploy(%player,%item,%pos)
{
	if (KneePoint::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item); //thus infinite walls to build
	}
}


// knee mortar

function KneePoint::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "KneePointShape" || GameBase::getDataName($los::object) == "OutpostWall") 
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

					%camera = newObject("KneePoint","StaticShape",KneePointShape,true);
					addToSet("MissionCleanup", %camera);
					%offset = "1.0 0.0 0.0";
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,Vector::add(%rot, %offset));

					%offset = "0.0 0.0 0.4";
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					%camera.ammoleft = 10;
					Gamebase::setMapName(%camera,"Knee Mortar " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Knee Mortar deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a knee mortar.");
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

StaticShapeData KneePointShape
{
        shapeFile = "grenadel";
        debrisId = defaultDebrisLarge;
        maxDamage = 0.5;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Knee Mortar";
};

function KneePointShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 1;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function KneePointShape::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "KneePoint"]--;

}

function KneePointShape::onCollision(%this,%obj)
{
    %client = Player::getClient(%obj);

    if (%this.ammoleft >= 1 && %this.reloaded == 1)
    {

		%this.ammoleft--;
		%prot = GameBase::getRotation(%obj);
		%zRot = getWord(%prot,2);

		%thisrot = GameBase::getRotation(%this);
		%thisxrot = getWord(%thisrot,0);
		%thisyrot = getWord(%thisrot,1);
		 GameBase::setRotation(%this,%thisxrot @ " " @ %thisyrot @ " " @ %zrot);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("ArtyShell",%trans,%this,"0 0 0");
		 %this.reloaded = 0;
		 playSound(SoundFireMortar,GameBase::getPosition(%this));
     }
    else
    {
    %this.reloaded = 1;
    bottomprint(%client,"<jc> Knee mortar reloaded. Range = 250 feet.  Shots left: " @ %this.ammoleft, 1);
    playSound(SoundPackUse,GameBase::getPosition(%this));
    }

    if (%this.ammoleft <= 0)
    {
    bottomprint(%client,"<jc> This mortar is out of ammo!", 2);	
    %this.reloaded = 0;
    }
}
