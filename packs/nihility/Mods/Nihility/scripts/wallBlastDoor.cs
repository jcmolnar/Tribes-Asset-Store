//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[BlastDoorPack] = 1;

$TeamItemMax[BlastDoorPack] = 20;

$ItemMax[larmor, BlastDoorPack] = 0;	//Seraph
$ItemMax[lfemale, BlastDoorPack] = 0;	//Seraph
$ItemMax[earmor, BlastDoorPack] = 1;	//Slave
$ItemMax[efemale, BlastDoorPack] = 1;	//Slave
$ItemMax[marmor, BlastDoorPack] = 0;	//Pawn
$ItemMax[aarmor, BlastDoorPack] = 0;	//Navigator
$ItemMax[darmor, BlastDoorPack] = 0;	//Atomizer
$ItemMax[barmor, BlastDoorPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ BlastDoorPack] = 0;
//	$TeamItemCount[1 @ BlastDoorPack] = 0;
//	$TeamItemCount[2 @ BlastDoorPack] = 0;
//	$TeamItemCount[3 @ BlastDoorPack] = 0;
//	$TeamItemCount[4 @ BlastDoorPack] = 0;
//	$TeamItemCount[5 @ BlastDoorPack] = 0;
//	$TeamItemCount[6 @ BlastDoorPack] = 0;
//	$TeamItemCount[7 @ BlastDoorPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData BlastDoorPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BlastDoorPack
{
        description = "Blast Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = BlastDoorPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastDoorPack::onUse(%player,%item)
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

function BlastDoorPack::onDeploy(%player,%item,%pos)
{
        if (BlastDoorPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastDoorPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastDoorPack","StaticShape",BlastDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Blast Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorPack"]++;
                                        echo("MSG: ",%client," deployed a Blast Door ");
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