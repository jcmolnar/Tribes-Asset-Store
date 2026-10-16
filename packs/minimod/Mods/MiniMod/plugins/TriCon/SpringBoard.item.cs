///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

$TeamItemMax[Springboard] = 6;

ItemImageData SpringPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData SpringPack
{
        description = "Springboard";
        shapeFile = "ammopack";
        className = "Backpack";
        heading = "sPersonnel Movers";
        imageType = SpringPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function SpringPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function SpringPack::onDeploy(%player,%item,%pos)
{
        if (SpringPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function SpringPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "Springboard"] < $TeamItemMax[Springboard]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                            %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set, Springboard, %num);
                        deleteObject(%set);


                        %rot = GameBase::getRotation(%player);
                        %objSpringboard = newObject("Springboard", "StaticShape", Springboard, true);


                        addToSet("MissionCleanup", %objSpringboard);
                        GameBase::setTeam(%objSpringboard, GameBase::getTeam(%player));
                        GameBase::setPosition(%objSpringboard, $los::position);
                        GameBase::setRotation(%objSpringboard, %rot);
                        Gamebase::setMapName(%objSpringboard, "Springboard");
                        Client::sendMessage(%client,0,"Springboard Deployed");
                         echo("MSG: ",%client," deployed a SpringBoard");
                        GameBase::startFadeIn(%objSpringboard);
                        playSound(SoundPickupBackpack, $los::position);
                        $TeamItemCount[GameBase::getTeam(%player) @ "Springboard"]++;
                        return true;
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


