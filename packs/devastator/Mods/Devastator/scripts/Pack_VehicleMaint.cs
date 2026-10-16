$InvList[VehMaint] = 1;
$RemoteInvList[VehMaint] = 0;
$TeamItemMax[VehMaint] = 1;

$ItemMax[larmor, VehMaint] = 0;
$ItemMax[marmor, VehMaint] = 1;
$ItemMax[harmor, VehMaint] = 0;
$ItemMax[qarmor, VehMaint] = 0;
$ItemMax[tarmor, VehMaint] = 0;
$ItemMax[sarmor, VehMaint] = 0;
$ItemMax[srarmor, VehMaint] = 0;
$ItemMax[parmor, VehMaint] = 0;
$ItemMax[psarmor, VehMaint] = 0;
$ItemMax[IceMor, VehMaint] = 1;
$ItemMax[lfemale, VehMaint] = 0;
$ItemMax[mfemale, VehMaint] = 1;
$ItemMax[qarmor, VehMaint] = 0;
$ItemMax[sarmor, VehMaint] = 0;
$ItemMax[srarmor, VehMaint] = 0;
$ItemMax[parmor, VehMaint] = 0;
//----------------------------------------------------------------------------

ItemImageData VehMaintImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData VehMaint 
{ 
	description = "Vehicle Maintenance"; 
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = fDeployables;
	imageType = VehMaintImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2;
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function VehMaint::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function VehMaint::onDeploy(%player,%item,%pos) 
{ 
	if(VehMaint::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item,1);
}
$MaintPadDist = 9;
$MaintPadZDif = 1.5;
$MaintPadRad = 3.5;
$MaintPadRate = 0.025;
function VehMaint::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = $los::object;
			%data = GameBase::getDataName(%obj);
			if(%data == "VehiclePad") {
				%Team = GameBase::getTeam(%player);
				%objTeam = GameBase::getTeam(%obj);
				if(%objTeam == %Team) {
					%bottom = CreateMaint(%obj);
					$TeamMaintenancePad[%Team] = %bottom;
					playSound(SoundPickupBackpack,$los::position);
					playSound(ForceFieldClose,%Place0);
					Client::sendMessage(%client,0,"Maintenance Bay Deployed");
					$TeamItemCount[GameBase::getTeam(%player) @ "VehMaint"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on your team's Vehicle Pad");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on Vehicle Pads");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function VehMaint::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Deploy this on any Vehicle Pad to repair and reload all vehicles that land on it.");
}

function CreateMaint(%obj)
{
	%Team = GameBase::getTeam(%obj);
	%rot = GameBase::getRotation(%obj);
	%pos = GameBase::getPosition(%obj);
	%InitBack = Vector::Add(%rot,"0 0 -3.141592654");
	%InitLeft = Vector::Add(%rot,"0 0 -1.570796327");
	%InitRght = Vector::Add(%rot,"0 0 1.570796327");
	%Place0 = Vector::add(%pos,Vector::getFromRot(%InitBack,$MaintPadDist));
	%PlaceZ = Vector::add(%Place0,"0 0 "@$MaintPadZDif);
	%Place1 = Vector::add(%PlaceZ,Vector::getFromRot(%rot,$MaintPadRad));
	%Place2 = Vector::add(%PlaceZ,Vector::getFromRot(%InitBack,$MaintPadRad));
	%Place3 = Vector::add(%PlaceZ,Vector::getFromRot(%InitLeft,$MaintPadRad));
	%Place4 = Vector::add(%PlaceZ,Vector::getFromRot(%InitRght,$MaintPadRad));
	%colide = newObject("","Mine","MaintMine");
	%bottom = newObject("plasmawall","StaticShape",VehicleMaint,true);
	%angle1 = newObject("plasmawall","StaticShape",VehicleMain1,true);
	%angle2 = newObject("plasmawall","StaticShape",VehicleMain1,true);
	%angle3 = newObject("plasmawall","StaticShape",VehicleMain1,true);
	%angle4 = newObject("plasmawall","StaticShape",VehicleMain1,true);
	addToSet("MissionGroup/Teams/team" @ %team, %colide);
	addToSet("MissionGroup/Teams/team" @ %team, %bottom);
	addToSet("MissionGroup/Teams/team" @ %team, %angle1);
	addToSet("MissionGroup/Teams/team" @ %team, %angle2);
	addToSet("MissionGroup/Teams/team" @ %team, %angle3);
	addToSet("MissionGroup/Teams/team" @ %team, %angle4);
	GameBase::setTeam(%bottom,GameBase::getTeam(%obj));
	GameBase::setPosition(%colide,%Place0);
	GameBase::setPosition(%bottom,%Place0);
	GameBase::setPosition(%angle1,%Place1);
	GameBase::setPosition(%angle2,%Place2);
	GameBase::setPosition(%angle3,%Place3);
	GameBase::setPosition(%angle4,%Place4);
	%rot1 = Vector::Add(%rot,"0.7853981635 0 0");
	%rot2 = Vector::Add(%rot,"-0.7853981635 0 0");
	%rot3 = Vector::Add(%rot,"0 -0.7853981635 0");
	%rot4 = Vector::Add(%rot,"0 0.7853981635 0");
	GameBase::setRotation(%bottom,%rot);
	GameBase::setRotation(%angle1,%rot1);
	GameBase::setRotation(%angle2,%rot2);
	GameBase::setRotation(%angle3,%rot3);
	GameBase::setRotation(%angle4,%rot4);
	Gamebase::setMapName(%bottom,"Vehicle Maintenance Bay");
	GameBase::startFadeIn(%colide);
	GameBase::startFadeIn(%bottom);
	GameBase::startFadeIn(%angle1);
	GameBase::startFadeIn(%angle2);
	GameBase::startFadeIn(%angle3);
	GameBase::startFadeIn(%angle4);
	$MaintPieces[%bottom,1] = %angle1;
	$MaintPieces[%bottom,2] = %angle2;
	$MaintPieces[%bottom,3] = %angle3;
	$MaintPieces[%bottom,4] = %angle4;
	$MaintPieces[%bottom,5] = %colide;
	$MaintPieceMain[%angle1] = %bottom;
	$MaintPieceMain[%angle2] = %bottom;
	$MaintPieceMain[%angle3] = %bottom;
	$MaintPieceMain[%angle4] = %bottom;
	$MaintPieceMain[%colide] = %bottom;
	return %bottom;
}

//------------------------------------

MineData MaintMine
{
	className = "Mine";
	description = "";
	shapeFile = "zap";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 10.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

StaticShapeData MaintLock
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
};

StaticShapeData VehicleMaint
{ 
	shapeFile = "plasmawall"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 1.0; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Vehicle Maintenance Bay"; 
}; 

StaticShapeData VehicleMain1
{ 
	shapeFile = "plasmawall"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 1.0; 
	visibleToSensor = false; 
	isTranslucent = true; 
}; 

function VehicleMaint::onDestroyed(%this)
{ 
	for(%i = 1; %i <= 8; %i++)
		GameBase::setDamageLevel($MaintPieces[%this,%i],1.1);
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "VehMaint"]--; 
}

function VehicleMaint::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == -1||%type == 68||%type == 69)
		return;
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}
//--------------------------------------------
//ICE'S VEHICLE BASE CODE FOR TESTING STATIONS
//--------------------------------------------
ItemImageData VehBaseImage 
{
	shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 0.5;
        firstPerson = false;
};
ItemData VehBase 
{
        description = "Vehicle Base";
        shapeFile = "vehi_pur_pnl";
        className = "Backpack";
     	heading = "fDeployables";
        imageType = VehBaseImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 5.0;
        price = 900000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function VehBase::onUse(%player,%item)
{
        if(Player::getMountedItem(%player,$BackpackSlot) != %item)
                Player::mountItem(%player,%item,$BackpackSlot);
        else
                Player::deployItem(%player,%item);
}
function VehBase::onDeploy(%player,%item,%pos)
{
        if(VehBase::deployShape(%player,%item))
                Player::decItemCount(%player,%item,$VehTestPadDec);
}
function VehBase::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		%team = GameBase::getTeam(%player);
		if(Vector::dot($los::normal,"0 0 1") > 0.7) {
			%rot1 = GameBase::getRotation(%player);
			%rot2 = Vector::Add(%rot1,"0 0 1.570796327");
			%rot3 = Vector::Add(%rot1,"0 0 -1.570796327");
			%pos1 = $los::position;
			%pos2 = Vector::Add(%pos1,Vector::getFromRot(%rot1,5));
			%pos3 = Vector::Add(%pos2,Vector::getFromRot(%rot2,-7));
			%pos4 = Vector::Add(%pos2,Vector::getFromRot(%rot3,-7));
			
			%phase1 = newObject("vehi_pur_pnl","StaticShape",$VehTestPadType@"Station",true);
			addToSet("MissionGroup/Teams/team"@%team,%phase1);
			GameBase::setTeam(%phase1,%team);
			GameBase::setPosition(%phase1,%pos1);
			GameBase::setRotation(%phase1,%rot1);
			Gamebase::setMapName(%phase1,$VehTestPadType@" Station");
			
			%phase2 = newObject("vehi_pur_poles","StaticShape",$VehTestPadType@"Pad",true);
			addToSet("MissionGroup/Teams/team"@%team,%phase2);
			GameBase::setTeam(%phase2,%team);
			GameBase::setPosition(%phase2,%pos2);
			GameBase::setRotation(%phase2,%rot1);
			Gamebase::setMapName(%phase2,$VehTestPadType@" Pad");

			%phase3 = newObject("solar_med","StaticShape",SolarPanel,true);
			addToSet("MissionGroup/Teams/team"@%team,%phase3);
			GameBase::setTeam(%phase3,%team);
			GameBase::setPosition(%phase3,%pos3);
			GameBase::setRotation(%phase3,%rot2);
			Gamebase::setMapName(%phase3,"Solar Panel");

 			%phase4 = newObject("solar_med","StaticShape",SolarPanel,true);
			addToSet("MissionGroup/Teams/team"@%team,%phase4);
			GameBase::setTeam(%phase4,%team);
			GameBase::setPosition(%phase4,%pos4);
			GameBase::setRotation(%phase4,%rot3);
			Gamebase::setMapName(%phase4,"Solar Panel");
 			
			Client::sendMessage(%client,0,$VehTestPadType@" Base Deployed");
			playSound(SoundPickupBackpack,%pos1);
			playSound(ForceFieldClose,%pos1);
			playSound(ForceFieldClose,%pos2);
			playSound(ForceFieldClose,%pos3);
			playSound(ForceFieldClose,%pos4);
			GameBase::startFadeIn(%phase1);
			GameBase::startFadeIn(%phase2);
			GameBase::startFadeIn(%phase3);
			GameBase::startFadeIn(%phase4);

			%phase1.VehiclePad = %phase2;
			return true;
		}
		else
			Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else
		Client::sendMessage(%client,0,"Deploy position out of range");
        return false;
}
$VehTestPadDec = 1;
$VehTestPadType = Vehicle;