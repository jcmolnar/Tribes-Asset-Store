//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[doorfourbyseventeenForceFieldPack] = 1;

$TeamItemMax[doorfourbyseventeenForceFieldPack] = 20;

$ItemMax[larmor, doorfourbyseventeenForceFieldPack] = 0;	//Seraph
$ItemMax[lfemale, doorfourbyseventeenForceFieldPack] = 0;	//Seraph
$ItemMax[earmor, doorfourbyseventeenForceFieldPack] = 1;	//Slave
$ItemMax[efemale, doorfourbyseventeenForceFieldPack] = 1;	//Slave
$ItemMax[marmor, doorfourbyseventeenForceFieldPack] = 0;	//Pawn
$ItemMax[aarmor, doorfourbyseventeenForceFieldPack] = 0;	//Navigator
$ItemMax[darmor, doorfourbyseventeenForceFieldPack] = 0;	//Atomizer
$ItemMax[barmor, doorfourbyseventeenForceFieldPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[1 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[2 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[3 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[4 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[5 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[6 @ doorfourbyseventeenForceFieldPack] = 0;
//	$TeamItemCount[7 @ doorfourbyseventeenForceFieldPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData doorfourbyseventeenForceFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData doorfourbyseventeenForceFieldPack
{
        description = "Wide FF Door";
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        className = "Backpack";
         heading = "nDoors - Walls - Platforms";
        imageType = doorfourbyseventeenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyseventeenForceFieldPack::onUse(%player,%item)
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

function doorfourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyseventeenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyseventeenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfourbyseventeenForceFieldPack","StaticShape",doorfourbyseventeenForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Wide Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wide FF Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyseventeenForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Wide Force Field Door ");
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