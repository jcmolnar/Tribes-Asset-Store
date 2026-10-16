//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[JailCapPack] = 1;

$TeamItemMax[JailCapPack] = 20;

$ItemMax[larmor, JailCapPack] = 0;	//Seraph
$ItemMax[lfemale, JailCapPack] = 0;	//Seraph
$ItemMax[earmor, JailCapPack] = 1;	//Slave
$ItemMax[efemale, JailCapPack] = 1;	//Slave
$ItemMax[marmor, JailCapPack] = 0;	//Pawn
$ItemMax[aarmor, JailCapPack] = 0;	//Navigator
$ItemMax[darmor, JailCapPack] = 0;	//Atomizer
$ItemMax[barmor, JailCapPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ JailCapPack] = 0;
//	$TeamItemCount[1 @ JailCapPack] = 0;
//	$TeamItemCount[2 @ JailCapPack] = 0;
//	$TeamItemCount[3 @ JailCapPack] = 0;
//	$TeamItemCount[4 @ JailCapPack] = 0;
//	$TeamItemCount[5 @ JailCapPack] = 0;
//	$TeamItemCount[6 @ JailCapPack] = 0;
//	$TeamItemCount[7 @ JailCapPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData JailCapPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData JailCapPack
{
        description = "Jail Capture Pad";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "lJail Equipment";
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
                if (GameBase::getLOSInfo(%player,10)) {

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
