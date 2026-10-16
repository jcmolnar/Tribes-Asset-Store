///-----------------------------------------------
/// description = "Jail Capture Pads";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------
MiniMod::MonitorFile(start, "JailCapturePad.CodeFusion.cs", "Jail Capture Pad Plugin");
MiniMod::Turbo::Class(JailCapPack, 9);

$TeamItemMax[JailCapPack] = 20;

ItemImageData JailCapPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mass = 2.5;
        firstPerson = false;
};

ItemData JailCapPack
{
        description = "Jail Capture Pad";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "zJail Deployables";
        imageType = JailCapPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function JailCapPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function JailCapPack::onDeploy(%player,%item,%pos)
{
        if (JailCapPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}
function JailCapPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);

                         %playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 10)
                          {
                          Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
                          return;
                          }


                                %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                %rot =  "1.57079 0 " @ %zRot;
                                %padd = "0 0 0";
                                %pos = Vector::add($los::position,%padd);
//
                                        %camera = newObject("","StaticShape","jailpad",true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,"0 0 0");
                                        GameBase::setPosition(%camera,%pos);
                                        Gamebase::setMapName(%camera,"JailPad " @ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Jail Pad Deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
                                        echo("MSG: ",%client," deployed a Jail Pad");
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

StaticShapeData jailpad
{
        shapeFile = "flagstand";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
        maxDamage = 1.6;
        debrisId = flashDebrisSmall;
};
function jailpad::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
        {
        return;
        }

    if(Player::isDead(%obj))
        {
        return;
        }

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
    %teleTeam = GameBase::getTeam(%this);


    if(%teleTeam == %playerTeam)
       {
      Client::SendMessage(%c,0,"You Stepped On Your Teams Jail Capture Pad");
      return;
      }

    %teleset = nameToID("MissionCleanup/jailports");
    %gclient = Client::getName(%c);
    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);

             if(%oteam != %playerTeam)
                    {
                        GameBase::playSound(%o,ForceFieldOpen,0);
                        GameBase::playSound(%this,ForceFieldOpen,0);
                        GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
                        schedule("jLargeForceField::jailSesame("@%obj@");",30);
                        Client::SendMessage(%c,0,"You are a Prisoner of War for 30 seconds");

                    }
                    }


    echo("ADMINMSG: ****" @ %gclient @ " stepped on a jail pad " );

}

function jailpad::Reenable(%this)
{
        %this.disabled = false;
}

$InvList[JailCapPack] = 1;
$RemoteInvList[JailCapPack] = 1;

MiniMod::MonitorFile(stop, "JailCapturePad.CodeFusion.cs", "Jail Capture Pad Plugin");
