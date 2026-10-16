///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData newdoorfourShape
{
        shapeFile = "newdoor4_r";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Panel Four";
};

function newdoorfourShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "newdoorfour"]--;

}