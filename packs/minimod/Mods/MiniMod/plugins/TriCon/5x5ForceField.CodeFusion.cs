///-----------------------------------------------
/// description = "5x5 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "5x5ForceField.CodeFusion.cs", "5x5 Force Field Plugin");
MiniMod::Turbo::Class(fivebyfiveForceFieldPack, 9);

$TeamItemMax[fivebyfiveForceFieldPack] = 8;

ItemImageData fivebyfiveForceFieldPackImage
{
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData fivebyfiveForceFieldPack
{
        description = "5x5 Force Field";
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "oForce Fields";
        imageType = fivebyfiveForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function fivebyfiveForceFieldPack::onUse(%player,%item)
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

function fivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (fivebyfiveForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function fivebyfiveForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("fivebyfiveForceFieldPack","StaticShape",fivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"5x5 ForceField#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"5x5 Force Field deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "fivebyfiveForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 5x5 Force Field ");
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

StaticShapeData fivebyfiveForceFieldShape
{
        shapeFile = "forcefield_5x5";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "5x5 Force Field";
};

function fivebyfiveForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fivebyfiveForceFieldPack"]--;

}

$InvList[fivebyfiveForceFieldPack] = 1;
$RemoteInvList[fivebyfiveForceFieldPack] = 1;

MiniMod::MonitorFile(stop, "5x5ForceField.CodeFusion.cs", "5x5 Force Field Plugin");
