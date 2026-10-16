exec(hologram);
exec(turret);
//----------------------------------------------------------------------------
//
//	DEPLOYABLES
//
//----------------------------------------------------------------------------

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		}
		else 
		{
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------
//	DEPLOYABLE INVPACK
//----------------------------------------------------------------------------

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
	heading = $InvHead[ihDem];
	shadowDetailMask = 4;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
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

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	 		         		addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else
				{
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------
//	DEPLOYABLE AMMOPACK
//----------------------------------------------------------------------------

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
	heading = $InvHead[ihDem];
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

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
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
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------
//	DEPLOYABLE HOLOGRAM
//----------------------------------------------------------------------------

$InvList[HoloPack] = 1;
$RemoteInvList[HoloPack] = 1;

ItemImageData HoloPackImage
{
	shapeFile = "larmor";
	mountPoint = 2;
    	mountOffset = { 5, -5, 0 };
	mass = 1.0;
	firstPerson = true;
};

ItemData HoloPack
{
	description = "Hologram";
	shapeFile = "larmor";
	className = "Backpack";
	heading = $InvHead[ihDem];
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function HoloPack::onDeploy(%player,%item,%pos) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"])
	{
		hologram(%client);
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
	}
	else
	{
		Client::sendMessage(%client,0,"Hologram generator overloaded.  Try again later");
	}
}

function HoloPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
		    	%set = newObject("holoset",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
			%num = CountObjects(%set,"Hologram",%num);
			deleteObject(%set);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				if(checkDeployArea(%client,$los::position))
				{
					%rot = GameBase::getRotation(%player);
					%rnd = floor(getRandom() * 10);
					if(%rnd > 6)
					   %fField = newObject("","StaticShape",Hologram1,true);
					else
					if((%rnd > 2) && (%rnd < 7))				
					   %fField = newObject("","StaticShape",Hologram2,true);
					else
					   %fField = newObject("","StaticShape",Hologram3,true);

					addToSet("MissionCleanup", %fField);
					GameBase::setTeam(%fField,GameBase::getTeam(%player));
					GameBase::setPosition(%fField,$los::position);
					GameBase::setRotation(%fField,%rot);
					Client::sendMessage(%client,0,"Hologram Deployed");
					GameBase::startFadeIn(%fField);
					playSound(SoundPickupBackpack,$los::position);
					playSound(ForceFieldOpen,$los::position);					
					$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
					return true;
				}
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//----------------------------------------------------------------------------
//	TELEPORT PACK
//----------------------------------------------------------------------------

$InvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 1;
$CanAlwaysTeamDestroy[DeployableTeleport] = 1;

 //-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployTeleporter::Initialize()
{
	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;
}

 //-=-=-=-=-=-=-=- Teleport Pack -=-=-=-=-=-=-=-

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
	heading = $InvHead[ihDem];
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NeedTeleportSimSet()
{
	%teleset = nameToID("MissionCleanup/Teleports");
	if (%teleset == -1)
	{
		newObject(Teleports, SimSet);
		addToSet(MissionCleanup, Teleports);
	}
}

function TeleportPack::onUse(%player,%item)
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

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player, "Teleport Pad", DeployableTeleport, %item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
	}
}

function TeleportPack::deployShape(%player, %name, %shape, %item)
{
	%client = Player::getClient(%player);

	 // Verify item limit
	if ($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] >= $TeamItemMax[DeployableTeleport]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; }

	 // Verify proximity to player
	// GetLOSInfo sets the following globals:
	// 	los::position
	// 	los::normal
	// 	los::object
	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	 // Verify type of deploy location
	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj == "DeployablePlatform") 
	{ Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; }

	 // Verify slope of deploy location
	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 // Make sure nothing is in the way of the deploy
	if (!checkDeployArea(%client,$los::position)) 
	{ return false;	}

	 //
	 // Passed validation, create the object
	 //
	NeedTeleportSimSet();

	 // Set the starting posistion a bit off the ground (for whatever reason)
	%pos = Vector::add($los::position,"0 0 1");

	 // Create teleporter pad
	%objTeleport = newObject("Teleport Pad", "StaticShape", %shape, true);
	%objTeleport.Functional = true;
	GameBase::setPosition(%objTeleport,%pos);
	GameBase::setTeam(%objTeleport,GameBase::getTeam(%player));
	Gamebase::setMapName(%objTeleport,%name);
	addToSet("MissionCleanup/Teleports", %objTeleport);
	addToSet("MissionCleanup", %objTeleport); 

	 // Create teleporter beam
	%beam = newObject("", "StaticShape", ElectricalBeamBig, true);
	GameBase::setPosition(%beam,%pos);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	addToSet("MissionCleanup", %beam);
	%objTeleport.beam1 = %beam;

	 // Wrap things up
	%objTeleport.disabled = false;
	playSound(SoundPickupBackpack, $los::position);
	Client::sendMessage(%client, 0, %item.description @ " deployed");
	reportDeploy(%objTeleport, %client);
	return true;
}

 //=-=-=-=-=- Object =-=-=-=-

StaticShapeData DeployableTeleport
{
	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 0.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};
				
function RemoveBeam(%b)
{
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}				

function DeployableTeleport::Destruct(%this)
{
	//CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);      
	// CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);

	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		 // Applying damage to all teleporters on this team
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		}
        }    
}

function DeployableTeleport::onCollision(%this, %obj)
{
	if (getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }	

	%c = Player::getClient(%obj);

	if (!%this.Functional)
        {
          if (Laptop::IsAvailable(%obj))
            Laptop::Error(%c, "Teleporter fatally malfunctioned and is permanently disabled.");
          else
            Client::SendMessage(%c, 0, "Teleporter malfunction"); 
          return; 
        }

	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if (%this.disabled)
	{ 
          if (Laptop::IsAvailable(%obj))
            Laptop::Error(%c, "Teleporter is recharging.");
          else
            Client::SendMessage(%c,0,"Teleporter is recharging"); 
          return; 
        }

	%phased = false;
	if (%teleTeam != %playerTeam)
	{
          if (Laptop::IsAvailable(%obj))
            %phased = true;
          else
	    { Client::SendMessage(%c,0,"--ACCESS DENIED-- Wrong Team~waccess_denied.wav"); return; }
	}

	if (Player::getArmor(%obj).shapeFile == "harmor")
	{ 
          if (Laptop::IsAvailable(%obj))
            Laptop::Error(%c, "Current armor class is too large to teleport.");
          else
            Client::SendMessage(%c,0,"Cannot teleport this armor class"); 
          return; 
        }

	 //
	 // Teleport operation passed initial validation.
	 //

	 // Find the other pad
	%teleset = nameToID("MissionCleanup/Teleports");	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if (GameBase::getTeam(%o) == %teleTeam && %o != %this)
		{
			if (!%phased)
				Client::SendMessage(%c, 0, "Teleport successful"); 
			else
				Laptop::Output(%c, "Enemy teleport override successful"); 
			GameBase::playSound(%o, ForceFieldOpen, 0);
			GameBase::playSound(%this, ForceFieldOpen, 0);
			GameBase::SetPosition(%obj, GameBase::GetPosition(%o));
			%o.Disabled = true;
			%this.Disabled = true;
			// GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if (floor(getRandom() * 55) == 0)
			{
				if (Laptop::IsAvailable(%obj))
					Laptop::Error(%c,"Teleporter permanently disabled to to malfunction.");
				else
					Client::SendMessage(%c,0,"Teleport malfunction");
				GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
				%this.Functional = false;
			}
			else
			{
				schedule("DeployableTeleport::Reenable("@%o@");",5,%o);
				schedule("DeployableTeleport::Reenable("@%this@");",5,%this);
			}
			return;
		}
	}
        if (Laptop::IsAvailable(%obj))
		Laptop::Error(%c, "No receiving teleport pad has been deployed.");
        else
		Client::SendMessage(%c,0,"No other teleport pad");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

//---------------------------------------------------
//	PORTABLE TREE
//---------------------------------------------------

$InvList[PortableTree] = 1; 
$RemoteInvList[PortableTree] = 1; 
$CanAlwaysTeamDestroy[PortableTree] = 1;

ItemImageData PortableTreeImage 
{ 
	shapeFile = "tree1"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData PortableTree 
{ 
	description = "Portable Tree"; 
	shapeFile = "tree1"; 
	className = "Backpack"; 
	heading = $InvHead[ihDem]; 
	imageType = PortableTreeImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	price = 250; 
	elasticity = 0.2; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function PortableTree::onUse(%player,%item) 
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

function PortableTree::onDeploy(%player,%item,%pos) 
{ 
	if (PortableTree::deployShape(%player,%item)) 
	{ 
		Player::decItemCount(%player,%item); 
	} 
} 

function PortableTree::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,3)) 
		{ 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain") 
			{ 
				%rot = Vector::getRotation($los::normal); 
				if(checkDeployArea(%client,$los::position)) 
				{ 
					%camera = newObject("Camera","Turret",DeployableTree,true); 
					addToSet("MissionCleanup", %camera); 
					GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
					GameBase::setRotation(%camera,%rot); 
					GameBase::setPosition(%camera,$los::position); 
					Gamebase::setMapName(%camera,"Tree#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
					Client::sendMessage(%client,0,"Tree deployed"); 
					playSound(SoundPickupBackpack,$los::position); 
					$TeamItemCount[GameBase::getTeam(%camera) @ "PortableTree"]++; 
					echo("MSG: ",%client," deployed a Tree"); 
					return true; 
					} 
				} 
				else 
				{ 
				Client::sendMessage(%client,0,"Can only deploy on terrain"); 
				} 
			} 
			else 
			{ 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
}

TurretData DeployableTree 
{ 
	maxDamage = 10.0; 
	maxEnergy = 0; 
	dopplerVelocity = 0; 
	pinger = false; 
	castLOS = false; 
	supression = false; 
	visibleToSensor = false; 
	debrisId = defaultDebrisMedium; 
	className = "Turret"; 
	shapeFile = "tree2"; 
	shadowDetailMask = 8; 
	description = "Tree"; 
}; 

function DeployableTree::onAdd(%this) 
{ 
	schedule("DeployableTree::deploy(" @ %this @ ");",1,%this); 
	if (GameBase::getMapName(%this) == "") 
	{ 
		GameBase::setMapName (%this, "Tree"); 
	} 
} 

function DeployableTree::deploy(%this) 
{ 
	GameBase::playSequence(%this,1,"deploy"); 
} 

function DeployableTree::onEndSequence(%this,%thread) 
{ 
	GameBase::setActive(%this,true); 
} 

function DeployableTree::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PortableTree"]--; 
} 

function DeployableTree::onPower(%this,%power,%generator) 
{
} 

function DeployableTree::onEnabled(%this) 
{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
} 

//----------------------------------------------------------------------------
// Remote deploy for items

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
 	        	   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}