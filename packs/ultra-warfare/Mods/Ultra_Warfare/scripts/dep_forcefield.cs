//=============================================================
//deployable platforms
//=============================================================
$ItemMax[larmor, ForceFieldPack] = 0;
$ItemMax[lfemale, ForceFieldPack] = 0;
$ItemMax[marmor, ForceFieldPack] = 0;
$ItemMax[mfemale, ForceFieldPack] = 0;
$ItemMax[harmor, ForceFieldPack] = 1;
//=============================================
$ItemMax[larmor, LargeFieldPack] = 0;
$ItemMax[lfemale, LargeFieldPack] = 0;
$ItemMax[marmor, LargeFieldPack] = 0;
$ItemMax[mfemale, LargeFieldPack] = 0;
$ItemMax[harmor, LargeFieldPack] = 1;
//=============================================
$ItemMax[larmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[lfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[marmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[mfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[harmor, doorfivebyfiveForceFieldPack] = 1;
//=============================================

$InvList[ForceFieldPack] = 1;
$InvList[LargeFieldPack] = 1;
$InvList[doorfivebyfiveForceFieldPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
$RemoteInvList[LargeFieldPack] = 1;
$RemoteInvList[doorfivebyfiveForceFieldPack] = 1;
$TeamItemMax[ForceFieldPack] = 5;
$TeamItemMax[LargeFieldPack] = 5;
$TeamItemMax[doorfivebyfiveForceFieldPack] = 5;
//======================================================
SoundData ForceFieldOpen
{
   wavFileName = "ent_ff_open.wav";
   profile = Profile3dNear;
};
SoundData ForceFieldClose
{
   wavFileName = "ent_ff_close.wav";
   profile = Profile3dNear;
};
SoundData SoundForceIdle
{
   wavFileName = "ent_ff_idle.wav";
   profile = Profile3dNearLoop;
};

//======================================================
ItemImageData ForceFieldPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData ForceFieldPack
{
        description = "Small Force Field";
        shapefile = "ammopack";
        classname = "Backpack";
        heading = "wDeployables";
        imageType = ForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 5.0;
        elasticity = 0.1;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
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

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (ForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function ForceFieldPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape")
                        {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                        {
                                                // if player is within 30 yards of flag cannot deploy
                                                %playerPos = GameBase::getPosition(%player);
                                                %flag = $teamFlag[GameBase::getTeam(%player)];
                                                %flagpos = gamebase::getPosition(%flag);
                                                echo("%flagpos " @ %flagpos);
                                                echo("%playerpos " @ %playerpos);
                                                if(Vector::getDistance(%flagpos, %playerpos) > 3)
                                                {
                                                        %inv = newObject("Small Force Field","StaticShape","SmallForceField",true);
                                                            addToSet("MissionCleanup", %inv);
                                                        %rot = GameBase::getRotation(%player);
                                                        GameBase::setTeam(%inv,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%inv,$los::position);
                                                        GameBase::setRotation(%inv,%rot);
                                                        Gamebase::setMapName(%inv,%name);
                                                        Client::sendMessage(%client,0,"Small Force Field  deployed");
                                                        playSound(SoundPickupBackpack,$los::position);
                                                        $TeamItemCount[GameBase::getTeam(%inv) @ "ForceFieldPack"]++;
                                                        echo("MSG: ",%client," deployed a Small Force Fieldl");
                                                        return true;
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
                                                        return false;
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
                return false;
}

//=============================================================


ItemImageData LargeFieldPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        firstPerson = false;
};

ItemData LargeFieldPack
{
        description = "Large Force Field";
        shapefile = "ammopack";
        classname = "Backpack";
        heading = "wDeployables";
        imageType = LargeFieldPackImage;
        shadowDetailMask = 4;
        mass = 5.0;
        elasticity = 0.1;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function LargeFieldPack::onUse(%player,%item)
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

function LargeFieldPack::onDeploy(%player,%item,%pos)
{
        if (LargeFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function LargeFieldPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape")
                        {
                                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                        {
                                                // if player is within 30 yards of flag cannot deploy
                                                %playerPos = GameBase::getPosition(%player);
                                                %flag = $teamFlag[GameBase::getTeam(%player)];
                                                %flagpos = gamebase::getPosition(%flag);
                                                echo("%flagpos " @ %flagpos);
                                                echo("%playerpos " @ %playerpos);
                                                if(Vector::getDistance(%flagpos, %playerpos) > 5)
                                                {
                                                        %inv = newObject("Large Force Field","StaticShape","LargeForceField",true);
                                                            addToSet("MissionCleanup", %inv);
                                                        %rot = GameBase::getRotation(%player);
                                                        GameBase::setTeam(%inv,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%inv,$los::position);
                                                        GameBase::setRotation(%inv,%rot);
                                                        Gamebase::setMapName(%inv,%name);
                                                        Client::sendMessage(%client,0,"Large Force Field  deployed");
                                                        playSound(SoundPickupBackpack,$los::position);
                                                        $TeamItemCount[GameBase::getTeam(%inv) @ "LargeFieldPack"]++;
                                                        echo("MSG: ",%client," deployed a Large Force Fieldl");
                                                        return true;
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
                                                        return false;
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
                return false;
}
//=============================================================
ItemImageData doorfivebyfiveForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfivebyfiveForceFieldPack
{
        description = "Force Field Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "wDeployables";
        imageType = doorfivebyfiveForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 0;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
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

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
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
