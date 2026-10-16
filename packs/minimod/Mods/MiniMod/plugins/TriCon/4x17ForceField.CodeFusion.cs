///-----------------------------------------------
/// description = "4x17 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "4x17ForceField.CodeFusion.cs", "4x17 Force Field Plugin");
MiniMod::Turbo::Class(fourbyseventeenForceFieldPack, 9);

$TeamItemMax[fourbyseventeenForceFieldPack] = 2;

ItemImageData fourbyseventeenForceFieldPackImage
{
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData fourbyseventeenForceFieldPack
{
        description = "4x17 Force Field";
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "oForce Fields";
        imageType = fourbyseventeenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function fourbyseventeenForceFieldPack::onUse(%player,%item)
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

function fourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (fourbyseventeenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function fourbyseventeenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("fourbyseventeenForceFieldPack","StaticShape",fourbyseventeenForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x17 ForceField#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x17 Force Field deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "fourbyseventeenForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x17 Force Field ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


StaticShapeData fourbyseventeenForceFieldShape
{
        shapeFile = "forcefield_4x17";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x17 Force Field";
};

function fourbyseventeenForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyseventeenForceFieldPack"]--;

}

$InvList[fourbyseventeenForceFieldPack] = 1;
$RemoteInvList[fourbyseventeenForceFieldPack] = 1;

MiniMod::MonitorFile(stop, "4x17ForceField.CodeFusion.cs", "4x17 Force Field Plugin");
