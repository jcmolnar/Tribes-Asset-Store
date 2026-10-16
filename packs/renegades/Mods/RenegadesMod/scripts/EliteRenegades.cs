
$MODNAME = "<f2>Renegades_Elite";
$MODDEVELOP = "<f2>RenModWerX";
$Reneg::ModLabel = "Renegades_Elite";
$ItemFavoritesKey = "RenegadesE";
////////////Resets////////////////
$Reneg::BaseOPT = false;
$Reneg::ELITE = false;
$Reneg::ELITE2 = true;
$Reneg::RenX = false;

/////reneg beacon fix////
$Reneg::Beacon = 3;
/////itemfixes
$ItemMax[sarmor, Vulcan] = 0; 
$ItemMax[sfemale, Vulcan] = 0; 
$ItemMax[marmor, MineAmmo] = 0;
$ItemMax[mfemale, MineAmmo] = 0;

ItemData ScoutArmor { heading = "aArmor"; description = "Scout"; className = "Armor"; price = 175; showInventory = true;}; 
ItemData SpArmor { heading = "aArmor"; description = "Spy"; className = "Armor"; price = 175; showInventory = true;}; 
ItemData LightArmor { heading = "aArmor"; description = "Sniper"; className = "Armor"; price = 175; showInventory = true;}; 
ItemData MediumArmor { heading = "aArmor"; description = "Mercenary"; className = "Armor"; price = 250; }; 
ItemData BursterArmor { heading = "aArmor"; description = "Burster"; className = "Armor"; price = 250; showInventory = true;}; 
ItemData EngArmor { heading = "aArmor"; description = "Engineer"; className = "Armor"; price = 250; showInventory = true;}; 
ItemData AlArmor { heading = "aArmor"; description = "Alien"; className = "Armor"; price = 250; showInventory = true;}; 
ItemData DragArmor { heading = "aArmor"; description = "Cyborg"; className = "Armor"; price = 400; showInventory = true;}; 
ItemData HeavyArmor { heading = "aArmor"; description = "Defender"; className = "Armor"; price = 700; showInventory = false;}; 
ItemData ScoutVehicle { description = "Scout"; className = "Vehicle"; heading = "aVehicle"; price = 600; showInventory = true;}; 
ItemData WraithVehicle { description = "Wraith"; className = "Vehicle"; heading = "aVehicle"; price = 600; showInventory = true;}; 
ItemData JetVehicle { description = "Interceptor"; className = "Vehicle"; heading = "aVehicle"; price = 600; showInventory = true;}; 
ItemData LAPCVehicle { description = "BomberLPC"; className = "Vehicle"; heading = "aVehicle"; price = 675; showInventory = true;}; 
ItemData HAPCVehicle { description = "StealthHPC"; className = "Vehicle"; heading = "aVehicle"; price = 875; showInventory = true; }; 
/////////blastwall fix////////////
/////////SPEED BOOST//////////////
ItemImageData TurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData TurretPack { description = "Ion Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = TurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 350; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TurretPack::onDeploy(%player,%item,%pos) { if (TurretPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TurretPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableTurret,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Remote Ion Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Remote Turret"); Client::setOwnedObject(%client,%turret); Client::setOwnedObject(%client,%player); return true; } } else Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

function Armor::SpeedBooster(%player, %item, %power) { %vec = Item::getVelocity(%player); if (%vec == "0 0 0") %vec = "0 10 0"; %vec = Vector::Normalize(%vec); %vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power; Player::applyImpulse(%player, %vec); Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); GameBase::playSound(%player, shockExplosion, 0); Player::decItemCount(%player,%item); }


$InvList[BarragePack] = 0;
$InvList[DeathStarPack] = 0;
$InvList[TrackingTurretPack] = 0;
$InvList[Stinger] = 0;
$InvList[DefenseAlarm] = 0;
$InvList[threebyfourForceFieldPack] = 0; 
$InvList[DoorfivebyfiveForceFieldPack] = 0; 
$InvList[DoorfourbyeightForceFieldPack] = 0;
$InvList[BaseAlarm] = 0;
$InvList[EspPack] = 0;
$RemoteInvList[BarragePack] = 0;
$RemoteInvList[DeathStarPack] = 0;
$RemoteInvList[TrackingTurretPack] = 0;
$RemoteInvList[Stinger] = 0;
$RemoteInvList[DefenseAlarm] = 0;
$RemoteInvList[threebyfourForceFieldPack] = 0; 
$RemoteInvList[DoorfivebyfiveForceFieldPack] = 0; 
$RemoteInvList[DoorfourbyeightForceFieldPack] = 0;
$RemoteInvList[BaseAlarm] = 0;
$RemoteInvList[EspPack] = 0;

////RenX reload shit  Zed
$InvList[TurretBuster] = 0;
$RemoteInvList[TurretBuster] = 0;
$InvList[DVulcan]= 0;
$RemoteInvList[DVulcan]= 0;
$InvList[DRocketLauncher] = 0;
$RemoteInvList[DRocketLauncher] = 0;
$InvList[Stinger] = 0; 
$InvList[StingerAmmo] = 0;
$RemoteInvList[Stinger] = 0; 
$RemoteInvList[StingerAmmo] = 0;

$ItemMax[aarmor, TurretBuster] = 0;
$ItemMax[afemale, TurretBuster] = 0;