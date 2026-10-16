StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 1.5;
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
   GameBase::startFadeOut(%this);
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
   if (%type == $LaserDamageType) %value = ScaleLaserDamage(%this,%value);
   if ($UseAdjustedDamageScale == "true") %value = (%value * $AdjustedDamageScale);
   if ($UseAdjustedScoring == "true")
	{
		%value = (%value * $AdjustedDamageScale);
	}
      %this.lastDamageObject = %object;
      %this.lastDamageTeam = GameBase::getTeam(%object);
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
            if(%damageLevel > %disable - 0.05)
               return;
            else
               %dValue = %disable - 0.05;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}
