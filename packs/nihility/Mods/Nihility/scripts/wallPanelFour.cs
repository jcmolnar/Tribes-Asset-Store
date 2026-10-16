//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[newdoorfour] = 1;

$TeamItemMax[newdoorfour] = 20;

$ItemMax[larmor, newdoorfour] = 0;	//Seraph
$ItemMax[lfemale, newdoorfour] = 0;	//Seraph
$ItemMax[earmor, newdoorfour] = 1;	//Slave
$ItemMax[efemale, newdoorfour] = 1;	//Slave
$ItemMax[marmor, newdoorfour] = 0;	//Pawn
$ItemMax[aarmor, newdoorfour] = 0;	//Navigator
$ItemMax[darmor, newdoorfour] = 0;	//Atomizer
$ItemMax[barmor, newdoorfour] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ newdoorfour] = 0;
//	$TeamItemCount[1 @ newdoorfour] = 0;
//	$TeamItemCount[2 @ newdoorfour] = 0;
//	$TeamItemCount[3 @ newdoorfour] = 0;
//	$TeamItemCount[4 @ newdoorfour] = 0;
//	$TeamItemCount[5 @ newdoorfour] = 0;
//	$TeamItemCount[6 @ newdoorfour] = 0;
//	$TeamItemCount[7 @ newdoorfour] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData newdoorfourImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData newdoorfour
{
        description = "Panel Four";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = newdoorfourImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function newdoorfour::onUse(%player,%item)
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

function newdoorfour::onDeploy(%player,%item,%pos)
{
        if (newdoorfour::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorfour::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorfour","StaticShape",newdoorfourShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall 4 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Panel Type Four deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorfour"]++;
                                        echo("MSG: ",%client," deployed a Panel Four Wall");
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