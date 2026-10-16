//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[PlatformDoor] = 1;

$TeamItemMax[PlatformDoor] = 20;

$ItemMax[larmor, PlatformDoor] = 0;	//Seraph
$ItemMax[lfemale, PlatformDoor] = 0;	//Seraph
$ItemMax[earmor, PlatformDoor] = 1;	//Slave
$ItemMax[efemale, PlatformDoor] = 1;	//Slave
$ItemMax[marmor, PlatformDoor] = 0;	//Pawn
$ItemMax[aarmor, PlatformDoor] = 0;	//Navigator
$ItemMax[darmor, PlatformDoor] = 0;	//Atomizer
$ItemMax[barmor, PlatformDoor] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ PlatformDoor] = 0;
//	$TeamItemCount[1 @ PlatformDoor] = 0;
//	$TeamItemCount[2 @ PlatformDoor] = 0;
//	$TeamItemCount[3 @ PlatformDoor] = 0;
//	$TeamItemCount[4 @ PlatformDoor] = 0;
//	$TeamItemCount[5 @ PlatformDoor] = 0;
//	$TeamItemCount[6 @ PlatformDoor] = 0;
//	$TeamItemCount[7 @ PlatformDoor] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData PlatformDoorImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PlatformDoor
{
        description = "Small Platform Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = PlatformDoorImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PlatformDoor::onUse(%player,%item)
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

function PlatformDoor::onDeploy(%player,%item,%pos)
{
        if (PlatformDoor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function PlatformDoor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("PlatformDoor","StaticShape",PlatformDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Platform Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Small Platform Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "PlatformDoor"]++;
                                        echo("MSG: ",%client," deployed a PlatformDoor ");
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