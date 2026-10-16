// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Death" (Anti-matter Turret) from
// the Redneck Slag Pack mod. Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ObeliskOfDeath.ArmorData.cs
//    ObeliskOfDeath.baseProjData.cs
//    ObeliskOfDeath.item.cs
//    ObeliskOfDeath.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    ObeliskOfDeath.station.cs
//    ObeliskOfDeath.turret.cs
//
// to your MiniMod/plugins directory.

$MaxNumAntiMatterTurretsInBox = 1;     //Number of remote turrets allowed in the area
$AntiMatterTurretBoxMaxLength = 75;    //Define Max Length of the area
$AntiMatterTurretBoxMaxWidth =  75;    //Define Max Width of the area
$AntiMatterTurretBoxMaxHeight = 10;    //Define Max Height of the area

$AntiMatterTurretBoxMinLength = 40;	  //Define Min Length from another turret
$AntiMatterTurretBoxMinWidth =  40;	  //Define Min Width from another turret
$AntiMatterTurretBoxMinHeight = 10;    //Define Min Height from another turret

$deathMsg[$AntiMatterDamageType, 0]	="%2 thought anti matter was good for you.";
$deathMsg[$AntiMatterDamageType, 1]	="%2 was obliterated by the small blue orb.";
$deathMsg[$AntiMatterDamageType, 2]	="%2 got a taste of anti matter.";
$deathMsg[$AntiMatterDamageType, 3]	="The anti matter charred %2's butt.";

$RSP::AntiMatterPoleID[0] = 0;
$RSP::AntiMatterTurretID[0] = 0;

$TeamItemMax[AntiMatterTurretPack] = 2;

ItemImageData AntiMatterTurretPackImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.3, -0.45 };
	mountRotation = { 0, 0, 0 };
	mass = 4.0;
	firstPerson = false;
};

ItemData AntiMatterTurretPack
{
	description = "Obelisk of Death";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "dDeployables";
	imageType = AntiMatterTurretPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AntiMatterTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AntiMatterTurretPack::onDeploy(%player,%item,%pos)
{
	if (AntiMatterTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AntiMatterTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AntiMatterTurretBoxMaxLength,$AntiMatterTurretBoxMaxWidth,$AntiMatterTurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableAntiMatterTurret",%num);
				deleteObject(%set);
				if($MaxNumAntiMatterTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AntiMatterTurretBoxMinLength,$AntiMatterTurretBoxMinWidth,$AntiMatterTurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableAntiMatterTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player);
								%turret = newObject("DeployableAntiMatterTurret","Turret",DeployableAntiMatterTurret,true);
								%stand = newObject("AntiMatterStand","StaticShape",AntiMatterStand,true);

								$RSP::AntiMatterPoleID[%turret] = %stand;
								$RSP::AntiMatterTurretID[%stand] = %turret;

								addToSet("MissionCleanup", %turret);
								addToSet("MissionCleanup", %stand);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setTeam(%stand,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,Vector::add($los::position, "0 0 14.75"));
								GameBase::setPosition(%stand,$los::position);
								GameBase::setRotation(%turret,%rot);
								GameBase::setRotation(%stand,%rot);
								Gamebase::setMapName(%turret,"Obelisk of Death");
								Client::sendMessage(%client,0,"Obelisk of Death deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AntiMatterTurretPack"]++;
								echo("MSG: ",%client," deployed an Obelisk of Death");
								Client::setOwnedObject(%client, %turret);
								Client::setOwnedObject(%client, %stand);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

	$TeamItemCount[0 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[1 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[2 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[3 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[4 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[5 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[6 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[7 @ AntiMatterTurretPack] = 0;

