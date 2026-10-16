///-----------------------------------------------
/// description = "Jail Cell";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData LLargeForceField
{
        shapeFile = "forcefield";
        debrisId = defaultDebrisLarge;
        maxDamage = 200.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Jail Cell";
};

function LLargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "jailpack"]--;
}
StaticShapeData JailSwitchOpen
{
        description = "The Jail";
        className = "towerSwitch";
        shapeFile = "tower";
        showInventory = "false";
        visibleToSensor = true;
        mapFilter = 4;
        mapIcon = "M_generator";
        maxDamage = 200.0;
};
function JailSwitchOpen::onCollision(%this,%obj)

{

}

StaticShapeData JailSwitchClose
{
        description = " The Jail";
        className = "towerSwitch";
        shapeFile = "tower";
        showInventory = "false";
        visibleToSensor = true;
        mapFilter = 4;
        mapIcon = "M_generator";
        maxDamage = 200.0;
};
function JailSwitchClose::onCollision(%this,%obj)

{

}


StaticShapeData jLargeForceField
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "ForceField";
maxDamage = 200.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Jail Cell Door";
};
function jLargeForceField::Destruct(%this)
{
jLargeForceField::doDamage(%this);
}
function jLargeForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function jLargeForceField::onDestroyed(%this)
{
jLargeForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function jLargeForceField::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
jLargeForceField::openSesame(%this);
return;
}
function jLargeForceField::openSesame(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("jLargeForceField::closeSesame("@%this@");",4);
}
function jLargeForceField::closeSesame(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function jLargeForceField::openSesame(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("jLargeForceField::closeSesame("@%this@");",4);
}


function jLargeForceField::jailSesame(%obj)
{
%teleset = nameToID("MissionCleanup/releasepad");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);

             if(%oteam != GameBase::getTeam(%obj))
                    {
                    GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
                    }
                    }


}
StaticShapeData jailStand
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStand::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStand::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Placed In Jail. No Escaping this way! You must wait out your sentence of 30 seconds.");
}
StaticShapeData jailStandTop
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStandTop::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStandTop::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}
StaticShapeData jailStandBottom
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 200.0;
        description = "POW Release Pad";
};
function jailStandBottom::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);


}
function jailStandBottom::onCollision(%this,%obj)
{
Client::SendMessage(%obj,0,"You Have Been Released. Run Forrest Run!!!!");
}


