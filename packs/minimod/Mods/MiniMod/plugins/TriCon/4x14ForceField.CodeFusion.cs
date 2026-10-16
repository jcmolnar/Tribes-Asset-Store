///-----------------------------------------------
/// description = "4x14 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "4x14ForceField.CodeFusion.cs", "4x14 Force Field Plugin");
MiniMod::Turbo::Class(fourbyfourteenForceFieldPack, 9);

$TeamItemMax[fourbyfourteenForceFieldPack] = 2;

ItemImageData fourbyfourteenForceFieldPackImage
{
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData fourbyfourteenForceFieldPack
{
        description = "4x14 Force Field";
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        className = "Backpack";
         heading = "oForce Fields";
        imageType = fourbyfourteenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function fourbyfourteenForceFieldPack::onUse(%player,%item)
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

function fourbyfourteenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (fourbyfourteenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function fourbyfourteenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("fourbyfourteenForceFieldPack","StaticShape",fourbyfourteenForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x14 ForceField#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x14 Force Field deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "fourbyfourteenForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x14 Force Field ");
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

StaticShapeData fourbyfourteenForceFieldShape
{
        shapeFile = "forcefield_4x14";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x14 Force Field";
};

function fourbyfourteenForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyfourteenForceFieldPack"]--;

}

$InvList[fourbyfourteenForceFieldPack] = 1;
$RemoteInvList[fourbyfourteenForceFieldPack] = 1;

MiniMod::MonitorFile(stop, "4x14ForceField.CodeFusion.cs", "4x14 Force Field Plugin");
