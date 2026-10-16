///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData newdooroneShape
{
        shapeFile = "newdoor1_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel One";
};

function newdooroneShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorone"]--;

}