//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[newdoortwo] = 1;

$TeamItemMax[newdoortwo] = 20;

$ItemMax[larmor, newdoortwo] = 0;	//Seraph
$ItemMax[lfemale, newdoortwo] = 0;	//Seraph
$ItemMax[earmor, newdoortwo] = 1;	//Slave
$ItemMax[efemale, newdoortwo] = 1;	//Slave
$ItemMax[marmor, newdoortwo] = 0;	//Pawn
$ItemMax[aarmor, newdoortwo] = 0;	//Navigator
$ItemMax[darmor, newdoortwo] = 0;	//Atomizer
$ItemMax[barmor, newdoortwo] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ newdoortwo] = 0;
//	$TeamItemCount[1 @ newdoortwo] = 0;
//	$TeamItemCount[2 @ newdoortwo] = 0;
//	$TeamItemCount[3 @ newdoortwo] = 0;
//	$TeamItemCount[4 @ newdoortwo] = 0;
//	$TeamItemCount[5 @ newdoortwo] = 0;
//	$TeamItemCount[6 @ newdoortwo] = 0;
//	$TeamItemCount[7 @ newdoortwo] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData newdoortwoImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData newdoortwo
{
        description = "Panel Two";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = newdoortwoImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function newdoortwo::onUse(%player,%item)
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

function newdoortwo::onDeploy(%player,%item,%pos)
{
        if (newdoortwo::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoortwo::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoortwo","StaticShape",newdoortwoShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall2 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Panel Type Two deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoortwo"]++;
                                        echo("MSG: ",%client," deployed a Panel Two Wall");
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

