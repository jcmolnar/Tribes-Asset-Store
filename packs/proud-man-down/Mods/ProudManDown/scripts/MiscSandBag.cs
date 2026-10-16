//--------------------------------------

$SellAmmo[Sandbag] = 5;
$AmmoPackMax[Sandbag] = 30;
$AmmoPackItems[30] = Sandbag;

//--------------------------------------

$TeamItemMax[Sandbag] = 80;

//--------------------------------------

$InvList[Sandbag] = 1;
$RemoteInvList[Sandbag] = 1;

//--------------------------------------

ItemData Sandbag
{
   description = "SandBag";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Sandbag::onUse(%player,%item)
{
	if (Sandbag::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Sandbag::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%Sandbag = newObject("Deployed Sandbag", "StaticShape", "DefaultSandbag", true);
				   addToSet("MissionCleanup", %Sandbag);
					//, CameraTurret, true);
					GameBase::setTeam(%Sandbag,GameBase::getTeam(%player));
					GameBase::setRotation(%Sandbag,%rot);
					GameBase::setPosition(%Sandbag,$los::position);
					Gamebase::setMapName(%Sandbag,"Sandbag");
   			   //PORT-OFF: Sandbag::onEnabled(%Sandbag);
					Client::sendMessage(%client,0,"Sandbag deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%Sandbag) @ "Sandbag"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

//PORT: a destroyed sandbag gives its team slot back (same as Beacon::onDestroyed)
function Sandbag::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "Sandbag"]--;
}

//--------------------------------------

StaticShapeData DefaultSandbag
{
	className = "Sandbag";
	damageSkinData = "objectDamageSkins";

	shapeFile = "mineammo";
	maxDamage = 9.1;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
//--------------------------------------