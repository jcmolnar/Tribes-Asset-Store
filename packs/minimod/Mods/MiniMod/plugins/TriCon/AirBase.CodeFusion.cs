///-----------------------------------------------
/// description = "Air Base";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------
MiniMod::MonitorFile(start, "AirBase.CodeFusion.cs", "Air Base Plugin");
MiniMod::Turbo::Class(airbase, 9);

$TeamItemMax[airbase] = 4;

ItemImageData airbasePackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData airbase
{
description = "AirBase";
shapeFile = "shieldpack";
className = "Backpack";
heading =  "mAir Deployables";
imageType = airbasePackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 2000;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};

function airbase::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function airbase::onDeploy(%player,%item,%pos)
{
        if (airbase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function airbase::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "airbase"] >= $TeamItemMax[airbase])
        { Client::sendMessage(%client,0,"Air Base Generator already Active Can Not Deploy "); return false; }


                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);
                echo("%flagpos " @ %flagpos);
                echo("%playerpos " @ %playerpos);
                if(Vector::getDistance(%flagpos, %playerpos) > 20)
                {

                %obj = getObjectType($los::object);
                %set = newObject("AirBase",SimSet);
                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                %num = CountObjects(%set,"AirBase",%num);
                deleteObject(%set);


                %objDevice =   newObject("AirBase","Staticshape",ABPortGenerator,true);
                %objDevice.objSide1 = newObject("AirBase1","Staticshape",LargeAirBasePlatform,true);
                %objDevice.objSide2 = newObject("AirBase2","Staticshape",LargeAirBasePlatform,true);
                %objDevice.objSide3 = newObject("AirBase3","Staticshape",LargeAirBasePlatform,true);
                %objDevice.objSide4 = newObject("AirBase4","Staticshape",LargeAirBaseRadar,true);
                %objDevice.objSide5 = newObject("AirBase5","StaticShape",LargeAirBasePlatform,true);
                %objDevice.objSide6 = newObject("AirBase6","StaticShape",CommandStation,true);
                %objDevice.objSide7 = newObject("AirBase7","StaticShape",InventoryStation,true);
                %objDevice.objSide8 = newObject("AirBase8","StaticShape",VehicleStation,true);
                %objDevice.objSide9 = newObject("AirBase9","StaticShape",VehiclePad,true);


                %objDevice.objSide1.objParent = %objDevice;
                %objDevice.objSide2.objParent = %objDevice;
                %objDevice.objSide3.objParent = %objDevice;
                %objDevice.objSide4.objParent = %objDevice;
                %objDevice.objSide5.objParent = %objDevice;
                %objDevice.objSide6.objParent = %objDevice;
                %objDevice.objSide7.objParent = %objDevice;
                %objDevice.objSide8.objParent = %objDevice;
                %objDevice.objSide9.objParent = %objDevice;



                 addToSet(MissionCleanup, %objDevice);
                 addToSet(MissionCleanup, %objDevice.objSide1);
                 addToSet(MissionCleanup, %objDevice.objSide2);
                 addToSet(MissionCleanup, %objDevice.objSide3);
                 addToSet(MissionCleanup, %objDevice.objSide4);
                 addToSet(MissionCleanup, %objDevice.objSide5);
                 addToSet(MissionCleanup, %objDevice.objSide6);
                 addToSet(MissionCleanup, %objDevice.objSide7);
                 addToSet(MissionCleanup, %objDevice.objSide8);
                 addToSet(MissionCleanup, %objDevice.objSide9);


                %pos = Vector::add(GameBase::getPosition(%player), "6.75 -0 88.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide5,%rot);
                GameBase::setPosition(%objDevice.objSide5,%pos);
                GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-6.75 -5.0 88.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide1,%rot);
                GameBase::setPosition(%objDevice.objSide1,%pos);
                GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "6.75 -0 80.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide2,%rot);
                GameBase::setPosition(%objDevice.objSide2,%pos);
                GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-6.75 -5.0 80.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide3,%rot);
                GameBase::setPosition(%objDevice.objSide3,%pos);
                GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-0 -2.0 88.50");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide4,%rot);
                GameBase::setPosition(%objDevice.objSide4,%pos);
                GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-3 -5 80.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice,%rot);
                GameBase::setPosition(%objDevice,%pos);
                GameBase::setTeam(%objDevice.objSide5,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-7 -5 80.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide6,%rot);
                GameBase::setPosition(%objDevice.objSide6,%pos);
                GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "5 0 80.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide7,%rot);
                GameBase::setPosition(%objDevice.objSide7,%pos);
                GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-8 -5 88.50");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide8,%rot);
                GameBase::setPosition(%objDevice.objSide8,%pos);
                GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "8 0 89.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide9,%rot);
                GameBase::setPosition(%objDevice.objSide9,%pos);
                GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
                Gamebase::setMapName(%inv,"Air Base Built By " @  Client::getName(%client));


                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "airbase"]++;
                Client::sendMessage(%client,1,"Air Base Deployed 150' Straight Up");
                echo("MSG: ",%client," deployed an AirBase ");

                return true;
               }
                else
                        Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
                        return false;


}

StaticShapeData ABPortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 5.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;

};

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;
}

StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1000.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData LargeAirBaseRadar
{
        shapeFile = "radar";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Air Base Radar";
};

function LargeRadar::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;

}
}

$InvList[airbase] = 1;
$RemoteInvList[airbase] = 1;

MiniMod::MonitorFile(stop, "AirBase.CodeFusion.cs", "Air Base Plugin");
