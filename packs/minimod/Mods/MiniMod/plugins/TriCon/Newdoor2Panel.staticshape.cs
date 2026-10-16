///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData newdoortwoShape
{
        shapeFile = "newdoor2_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Two";
};

function newdoortwoShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoortwo"]--;

}