//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[newdoorthree] = 1;

$TeamItemMax[newdoorthree] = 20;

$ItemMax[larmor, newdoorthree] = 0;	//Seraph
$ItemMax[lfemale, newdoorthree] = 0;	//Seraph
$ItemMax[earmor, newdoorthree] = 1;	//Slave
$ItemMax[efemale, newdoorthree] = 1;	//Slave
$ItemMax[marmor, newdoorthree] = 0;	//Pawn
$ItemMax[aarmor, newdoorthree] = 0;	//Navigator
$ItemMax[darmor, newdoorthree] = 0;	//Atomizer
$ItemMax[barmor, newdoorthree] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ newdoorthree] = 0;
//	$TeamItemCount[1 @ newdoorthree] = 0;
//	$TeamItemCount[2 @ newdoorthree] = 0;
//	$TeamItemCount[3 @ newdoorthree] = 0;
//	$TeamItemCount[4 @ newdoorthree] = 0;
//	$TeamItemCount[5 @ newdoorthree] = 0;
//	$TeamItemCount[6 @ newdoorthree] = 0;
//	$TeamItemCount[7 @ newdoorthree] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData newdoorthreeImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData newdoorthree
{
        description = "Panel Three";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = newdoorthreeImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function newdoorthree::onUse(%player,%item)
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

function newdoorthree::onDeploy(%player,%item,%pos)
{
        if (newdoorthree::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorthree::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorthree","StaticShape",newdoorthreeShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall3 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Panel Type Three deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorthree"]++;
                                        echo("MSG: ",%client," deployed a Panel Three Wall");
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