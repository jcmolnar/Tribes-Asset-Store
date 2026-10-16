
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Beacon (Beacon)
//  By Dynamix, Mephisto, Alazane, and Mjolnir
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//  Depends on:
//    Only Alliance armor being used (onBeacon support)
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$SellAmmo[Beacon] = 5;
$TeamItemMax[Beacon] = 40;
$InvList[Beacon] = 1;
$RemoteInvList[Beacon] = 1;

addAmmo("", Beacon, 1);

function miscBeacon::Initialize()
{
  $TeamItemCount[0 @ Beacon] = 0;
  $TeamItemCount[1 @ Beacon] = 0;
  $TeamItemCount[2 @ Beacon] = 0;
  $TeamItemCount[3 @ Beacon] = 0;
  $TeamItemCount[4 @ Beacon] = 0;
  $TeamItemCount[5 @ Beacon] = 0;
  $TeamItemCount[6 @ Beacon] = 0;
  $TeamItemCount[7 @ Beacon] = 0;
}

ItemData Beacon 
{
  description = "Beacon";
  shapeFile = "sensor_small";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  price = 5;
  className = "HandAmmo";
};

StaticShapeData DefaultBeacon
{
  className = "Beacon";
  damageSkinData = "objectDamageSkins";

  shapeFile = "sensor_small";
  maxDamage = 0.1;
  maxEnergy = 200;

  castLOS = true;
  supression = false;
  mapFilter = 2;
  //mapIcon = "M_marker";
  visibleToSensor = true;
  explosionId = flashExpSmall;
  debrisId = flashDebrisSmall;
};
																						 
function Beacon::onEnabled(%this)
{
  GameBase::setIsTarget(%this,true);
  %data = GameBase::getDataName(%this);
  schedule("GameBase::setDamageLevel(" @ %this @ "," @ %data.maxDamage @ ");", 200);
}

function Beacon::onDisabled(%this)
{
  GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
  GameBase::setIsTarget(%this,false);
  $TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Beacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
  if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
    return;

  %damageLevel = GameBase::getDamageLevel(%this);
  %dValue = %damageLevel + %value;
  %this.lastDamageObject = %object;
  %this.lastDamageTeam = GameBase::getTeam(%object);
  if (GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
  {
    %name = GameBase::getDataName(%this);
    if (%name.className == Generator || %name.className == Station) 
    {
      %TDS = $Server::TeamDamageScale;
      %dValue = %damageLevel + %value * %TDS;
      %disable = GameBase::getDisabledDamage(%this);
      if (!$Server::TourneyMode && %dValue > %disable - 0.05) 
      {
        if (%damageLevel > %disable - 0.05)
          return;
        else
          %dValue = %disable - 0.05;
      }
    }
  }
  GameBase::setDamageLevel(%this,%dValue);
}

function Beacon::onUse(%player,%item) 
{
  if (!$matchStarted) return;
  %armor = Player::getArmor(%player);
  eval(%armor @ "::onBeacon(" @ %player @ ", " @ %item @ ");");
}

function Beacon::deployShape(%player,%item)
{
	// This is the original code for deploying a beacon.  An armor class does not have to use
        // a call back to this code in its onBeacon event, but it may.
        //
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
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
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

 // This can most likely be ripped

ItemData RepairPatch 
{
  description = "Repair Patch";
  className = "Repair";
  shapeFile = "armorPatch";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  price = 2;
};

function RepairPatch::onCollision(%this,%object) 
{
  if (getObjectType(%object) == "Player") 
  {
    if(GameBase::getDamageLevel(%object)) 
    {
      GameBase::repairDamage(%object,0.125);
      %c = Player::getClient(%object);
      $poisonTime[%c] = 0;
      %item = Item::getItemData(%this);
      Item::playPickupSound(%this);
      Item::respawn(%this);
    }
  }
}

function RepairPatch::onUse(%player,%item) 
{
  Player::decItemCount(%player,%item);
  GameBase::repairDamage(%player,0.1);
}
