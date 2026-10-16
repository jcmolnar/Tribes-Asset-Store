///-----------------------------------------------
/// Description - "Blast Wall";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "BlastWall.CodeFusion.cs", "Blast Wall Plugin");
MiniMod::Turbo::Class(BlastWall, 9);

$TeamItemMax[BlastWall] = 20;

ItemImageData BlastWallImage
{
        shapeFile = "newdoor5";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastWall
{
        description = "Blast Wall";
        shapeFile = "newdoor5";
        className = "Backpack";
        heading = "nDeployable Walls";
        imageType = BlastWallImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWall::onUse(%player,%item)
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

function BlastWall::onDeploy(%player,%item,%pos)
{
        if (BlastWall::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastWall::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Wall#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastWall"]++;
                                        echo("MSG: ",%client," deployed a Blast Wall");
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

StaticShapeData BlastWallShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 10.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Portable Wall";
};

function BlastWallShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastWall"]--;

}

$InvList[BlastWall] = 1;
$RemoteInvList[BlastWall] = 1;

MiniMod::MonitorFile(stop, "BlastWall.CodeFusion.cs", "Blast Wall Plugin");
