///-----------------------------------------------
/// description = "Air Large Platform";
/// MiniMod Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------
$TeamItemMax[LargeAirPlatPack] = 15;

ItemImageData LargeAirPlatPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData LargeAirPlatPack
{
        description = "Air Large Platform";
        shapefile = "ammopack";
        classname = "Backpack";
        heading =  "mAir Deployables";
        imageType = LargeAirPlatPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.1;
        price = 150;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function LargeAirPlatPack::onUse(%player,%item)
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

function LargeAirPlatPack::onDeploy(%player,%item,%pos)
{
        if (LargeAirPlatPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function LargeAirPlatPack::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {

                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);
                echo("%flagpos " @ %flagpos);
                echo("%playerpos " @ %playerpos);
                if(Vector::getDistance(%flagpos, %playerpos) > 10)
                {
                %camera = newObject("Large Air Platform","Staticshape",LargeAirPlatform,true);
                   addToSet("MissionCleanup", %camera);
                GameBase::setTeam(%camera,GameBase::getTeam(%player));
                GameBase::setRotation(%camera,"0 0 0");
                GameBase::setPosition(%camera,GameBase::getPosition(%player));
                Gamebase::setMapName(%camera,"Large Air Platform" @  Client::getName(%client));
                Client::sendMessage(%client,0,"Large Air Platform deployed");
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%camera) @ "LargeAirPlatPack"]++;
                echo("MSG: ",%client," deployed a Large Air Platform ");

                return true;
                }
                else
                        Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag in this mod.");
                        return false;
        }

}