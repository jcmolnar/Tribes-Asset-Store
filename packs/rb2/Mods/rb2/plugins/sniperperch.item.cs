//Gun mount for mounted machineguns

$ItemMax[hlarmor, SniperPerchPack] = 0;
$ItemMax[hlfemale, SniperPerchPack] = 0;
$ItemMax[larmor, SniperPerchPack] = 0;
$ItemMax[lfemale, SniperPerchPack] = 0;
$ItemMax[earmor, SniperPerchPack] = 1;
$ItemMax[efemale, SniperPerchPack] = 1;
$ItemMax[marmor, SniperPerchPack] = 0;
$ItemMax[mfemale, SniperPerchPack] = 0;
$ItemMax[harmor, SniperPerchPack] = 0;
$ItemMax[uharmor, SniperPerchPack] = 0;
$HelpMessage[SniperPerchPack] = "A tower for snipers to snipe from."; 
$InvList[SniperPerchPack] = 1;
$RemoteInvList[SniperPerchPack] = 1;
$TeamItemMax[SniperPerchPlatform] = 4;

ItemImageData SniperPerchPackImage
{
	shapeFile = "flagstand";
	SniperPerchPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 1.52, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData SniperPerchPack
{
	description = "Guard Tower";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "hField Deployment";
	imageType = SniperPerchPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SniperPerchPack::onUse(%player,%item)
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

function SniperPerchPack::onDeploy(%player,%item,%pos)
{
	if (SniperPerchPoint::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item); 
	}
}


// Sniper Perch by DeadTaco

function SniperPerchPoint::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "SniperPerchPlatform"] < $TeamItemMax[SniperPerchPlatform])
	{
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") 
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

					%offset = "0.0 0.0 10.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 1 " @ Client::getName(%client));

					%offset = "9.0 0.0 10.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 2 " @ Client::getName(%client));

					%offset = "9.0 6.0 10.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 3 " @ Client::getName(%client));

					%offset = "0.0 6.0 10.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 4 " @ Client::getName(%client));


					%offset = "4.5 7.0 10.0";
					%camera = newObject("SniperPerchPlatform","StaticShape",SniperPerchPlatform,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"1.55 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Perch Platform " @ Client::getName(%client));

// Second layer of building


					%offset = "0.0 0.0 24.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 1 " @ Client::getName(%client));

					%offset = "9.0 0.0 24.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 2 " @ Client::getName(%client));

					%offset = "9.0 6.0 24.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 3 " @ Client::getName(%client));

					%offset = "0.0 6.0 24.0";
					%camera = newObject("SniperPerchPoint","StaticShape",SniperPerchPointShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"3.14 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Leg 4 " @ Client::getName(%client));


					%offset = "4.5 7.0 24.0";
					%camera = newObject("SniperPerchPlatform","StaticShape",SniperPerchPlatform,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"1.55 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Perch Platform " @ Client::getName(%client));

// SNIPER Tower WallS - FOR PROTECTING THE SNIPER

					%offset = "4.5 7.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));

					%offset = "4.5 -1.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "9 5.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "0.0 5.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "9 1.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "0.0 1.0 24.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));

// Sniper Tower Walls second layer

					%offset = "4.5 7.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));



					%offset = "4.5 -1.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "9 5.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "0.0 5.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "9 1.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));


					%offset = "0.0 1.0 26.0";
					%camera = newObject("SniperPerchWall","StaticShape",SniperPerchWall,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"0 0 1.52");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Tower Wall " @ Client::getName(%client));



					%offset = "4.5 7.0 28.0";
					%camera = newObject("SniperPerchRoof","StaticShape",SniperPerchRoof,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"1.55 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Perch Roof " @ Client::getName(%client));

					%offset = "4.5 0.0 10.0";
					%camera = newObject("SniperPerchRoof","StaticShape",SniperPerchRoof,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,"1.55 0 0");
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Perch Step " @ Client::getName(%client));



					Client::sendMessage(%client,0,"Perch deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SniperPerchPlatform"]++;
					$TeamItemCount[GameBase::getTeam(%camera) @ "SniperPerchPlatform"]++;
					echo("MSG: ",%client," deployed a guard tower.");
					return true;
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	Client::sendMessage(%client,0,"Too many towers already in the field");

        return false;
}


//---------------------------------------------static shape information---------------------------------------

StaticShapeData SniperPerchPointShape
{
        shapeFile = "anten_lrg";
        debrisId = defaultDebrisLarge;
        maxDamage = 1000.0;
        visibleToSensor = true;
        isTranslucent = false;
        description = "Sniper Perch Leg";
};

function SniperPerchPointShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function SniperPerchPointShape::onDestroyed(%this)
{
	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 1);

}

StaticShapeData SniperPerchPlatform
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 1000.0;
        visibleToSensor = true;
        isTranslucent = false;
        description = "Sniper Perch Platform";
};

function SniperPerchPlatform::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function SniperPerchPlatform::onDestroyed(%this)
{
	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	%obj = newObject("","Mine","NukeBomb");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-100.5,false);

	schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 1);

	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "SniperPerchPlatform"]--;

}

StaticShapeData SniperPerchWall
{
        shapeFile = "panel_blue";
        debrisId = defaultDebrisLarge;
        maxDamage = 500.0;
        visibleToSensor = true;
        isTranslucent = false;
        description = "Sniper Perch Platform";
};

function SniperPerchWall::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function SniperPerchWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);

}

StaticShapeData SniperPerchRoof
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 600.0;
        visibleToSensor = true;
        isTranslucent = false;
        description = "Sniper Perch Platform";
};

function SniperPerchRoof::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = 2;
	GameBase::setDamageLevel(%this,%damageLevel + %value * %TDS * $DoorScale[%type]);
}

function SniperPerchRoof::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);

}