///-----------------------------------------------
/// description = "Air Ammo Pad";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "AirAmmoPad.CodeFusion.cs", "Air Ammo Pad Plugin");
MiniMod::Turbo::Class(AirAmmoPad, 9);

$TeamItemMax[AirAmmoPad] = 4;

ItemImageData AirAmmoPadPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData AirAmmoPad
{
        description = "Air Ammo Pad";
        shapefile = "ammopack";
        classname = "Backpack";
        heading =  "mAir Deployables";
        imageType = AirAmmoPadPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.1;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function AirAmmoPad::onUse(%player,%item)
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

function AirAmmoPad::onDeploy(%player,%item,%pos)
{
        if (AirAmmoPad::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AirAmmoPad::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {

                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);
                if(Vector::getDistance(%flagpos, %playerpos) > 10)
                {
                %camera = newObject("Spy Station","Staticshape",AirAmmoBasePad,true);
                addToSet("MissionCleanup", %camera);
                %rot = GameBase::getRotation(%player);
                GameBase::setTeam(%camera,GameBase::getTeam(%player));
                GameBase::setRotation(%camera,%rot);
                GameBase::setPosition(%camera,GameBase::getPosition(%player));
                Gamebase::setMapName(%camera,"Spy Station" @  Client::getName(%client));
                Client::sendMessage(%client,0,"Air Ammo Station deployed");


                %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,GameBase::getPosition(%player));
                Gamebase::setMapName(%inv,"Air Ammo Pad " @  Client::getName(%client));
                playSound(SoundPickupBackpack,$los::position);
                echo("MSG: ",%client," deployed an Air Ammo Pad ");

                return true;
                }
                else
                        Client::sendMessage(%client,0,"You are too close to your flag.");
                        return false;
        }

}

StaticShapeData AirAmmoBasePad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "AirAmmoBasePad";
};

function thinelevator::onDestroyed(%this)
{
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirAmmoPad"]--;
}

$InvList[AirAmmoPad] = 1;
$RemoteInvList[AirAmmoPad] = 1;

MiniMod::MonitorFile(stop, "AirAmmoPad.CodeFusion.cs", "Air Ammo Pad Plugin");
