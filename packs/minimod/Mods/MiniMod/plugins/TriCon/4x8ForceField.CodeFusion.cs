///-----------------------------------------------
/// description = "4x8 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "4x8ForceField.CodeFusion.cs", "4x8 Force Field Plugin");
MiniMod::Turbo::Class(fourbyeightForceFieldPack, 9);

$TeamItemMax[fourbyeightForceFieldPack] = 8;

ItemImageData fourbyeightForceFieldPackImage
{
        //shapeFile = "forcefield_4x8";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData fourbyeightForceFieldPack
{
        description = "4x8 Force Field";
        //shapeFile = "forcefield_4x8";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "oForce Fields";
        imageType = fourbyeightForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function fourbyeightForceFieldPack::onUse(%player,%item)
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

function fourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (fourbyeightForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function fourbyeightForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("fourbyeightForceFieldPack","StaticShape",fourbyeightForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x8 ForceField#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x8 Force Field deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "fourbyeightForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x8 Force Field ");
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

StaticShapeData fourbyeightForceFieldShape
{
        shapeFile = "forcefield_4x8";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x8 Force Field";
};

function fourbyeightForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyeightForceFieldPack"]--;

}

$InvList[fourbyeightForceFieldPack] = 1;
$RemoteInvList[fourbyeightForceFieldPack] = 1;

MiniMod::MonitorFile(stop, "4x8ForceField.CodeFusion.cs", "4x8 Force Field Plugin");
