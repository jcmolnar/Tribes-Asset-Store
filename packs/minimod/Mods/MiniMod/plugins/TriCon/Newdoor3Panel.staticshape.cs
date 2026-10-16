///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------
StaticShapeData newdoorthreeShape
{
        shapeFile = "newdoor3_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Three";
};

function newdoorthreeShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorthree"]--;

}