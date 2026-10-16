///-----------------------------------------------
/// description = "Hologram";
/// MiniMod Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------
$TeamItemMax[hologram] = 15;

MiniMod::MonitorFile(start, "Hologram.CodeFusion.cs", "Hologram Plugin");
MiniMod::Turbo::Class(HoloPack, 9);

ItemImageData HoloPackImage
{
        shapeFile = "ShieldPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData HoloPack
{
        description = "Hologram";
        shapeFile = "larmor";
        className = "Backpack";
        heading = "dDeployables";
        imageType = HoloPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 900;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function HoloPack::onDeploy(%player,%item,%pos)
{
        if (HoloPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function HoloPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);

                                    %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"Hologram",%num);
                                deleteObject(%set);

                                        if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                if(checkDeployArea(%client,$los::position)) {
                                                        %rot = GameBase::getRotation(%player);
                                                        %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 6)

                                                           %fField = newObject("","StaticShape",Hologram1,true);
                                                        else
                                                                if((%rnd > 2) && (%rnd < 7))


                                                           %fField = newObject("","StaticShape",Hologram2,true);
                                                        else


                                                           %fField = newObject("","StaticShape",Hologram3,true);

                                                        addToSet("MissionCleanup", %fField);
                                                        GameBase::setTeam(%fField,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%fField,$los::position);
                                                        GameBase::setRotation(%fField,%rot);
                                                        Client::sendMessage(%client,0,"Hologram Deployed");
                                                        echo("MSG: ",%client," deployed a Hologram");
                                                        GameBase::startFadeIn(%fField);
                                                        playSound(ForceFieldOpen,$los::position);


                                                        $TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
                                                        return true;
                                                }
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData Hologram1
{
        shapeFile = "larmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 0.75;
   description = "Hologram";
};
function Hologram1::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}


StaticShapeData Hologram2
{
        shapeFile = "marmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 1.10;
   description = "Hologram";
};
function Hologram2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}

//----------------
StaticShapeData Hologram3
{
        shapeFile = "harmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 1.5;
   description = "Hologram";
};
function Hologram1::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}

$InvList[HoloPack] = 1;
$RemoteInvList[HoloPack] = 1;

MiniMod::MonitorFile(stop, "Hologram.CodeFusion.cs", "Hologram Plugin");
