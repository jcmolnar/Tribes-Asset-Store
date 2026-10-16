//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[LargePlatDoor] = 1;

$TeamItemMax[LargePlatDoor] = 20;

$ItemMax[larmor, LargePlatDoor] = 0;	//Seraph
$ItemMax[lfemale, LargePlatDoor] = 0;	//Seraph
$ItemMax[earmor, LargePlatDoor] = 1;	//Slave
$ItemMax[efemale, LargePlatDoor] = 1;	//Slave
$ItemMax[marmor, LargePlatDoor] = 0;	//Pawn
$ItemMax[aarmor, LargePlatDoor] = 0;	//Navigator
$ItemMax[darmor, LargePlatDoor] = 0;	//Atomizer
$ItemMax[barmor, LargePlatDoor] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ LargePlatDoor] = 0;
//	$TeamItemCount[1 @ LargePlatDoor] = 0;
//	$TeamItemCount[2 @ LargePlatDoor] = 0;
//	$TeamItemCount[3 @ LargePlatDoor] = 0;
//	$TeamItemCount[4 @ LargePlatDoor] = 0;
//	$TeamItemCount[5 @ LargePlatDoor] = 0;
//	$TeamItemCount[6 @ LargePlatDoor] = 0;
//	$TeamItemCount[7 @ LargePlatDoor] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData LargePlatDoorImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData LargePlatDoor
{
        description = "Large Platform Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = LargePlatDoorImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function LargePlatDoor::onUse(%player,%item)
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

function LargePlatDoor::onDeploy(%player,%item,%pos)
{
        if (LargePlatDoor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function LargePlatDoor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("LargePlatDoor","StaticShape",LargePlatDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Large Platform Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "LargePlatDoor"]++;
                                        echo("MSG: ",%client," deployed a LargePlatDoor ");
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