//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[doorfivebyfiveForceFieldPack] = 1;

$TeamItemMax[doorfivebyfiveForceFieldPack] = 20;

$ItemMax[larmor, doorfivebyfiveForceFieldPack] = 0;	//Seraph
$ItemMax[lfemale, doorfivebyfiveForceFieldPack] = 0;	//Seraph
$ItemMax[earmor, doorfivebyfiveForceFieldPack] = 1;	//Slave
$ItemMax[efemale, doorfivebyfiveForceFieldPack] = 1;	//Slave
$ItemMax[marmor, doorfivebyfiveForceFieldPack] = 0;	//Pawn
$ItemMax[aarmor, doorfivebyfiveForceFieldPack] = 0;	//Navigator
$ItemMax[darmor, doorfivebyfiveForceFieldPack] = 0;	//Atomizer
$ItemMax[barmor, doorfivebyfiveForceFieldPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[1 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[2 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[3 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[4 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[5 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[6 @ doorfivebyfiveForceFieldPack] = 0;
//	$TeamItemCount[7 @ doorfivebyfiveForceFieldPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData doorfivebyfiveForceFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData doorfivebyfiveForceFieldPack
{
        description = "Small FF Door";
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = doorfivebyfiveForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
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
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Small Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Small FF Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Small Force Field Door ");
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