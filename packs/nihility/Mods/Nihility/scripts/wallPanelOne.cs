//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[newdoorone] = 1;

$TeamItemMax[newdoorone] = 20;

$ItemMax[larmor, newdoorone] = 0;	//Seraph
$ItemMax[lfemale, newdoorone] = 0;	//Seraph
$ItemMax[earmor, newdoorone] = 1;	//Slave
$ItemMax[efemale, newdoorone] = 1;	//Slave
$ItemMax[marmor, newdoorone] = 0;	//Pawn
$ItemMax[aarmor, newdoorone] = 0;	//Navigator
$ItemMax[darmor, newdoorone] = 0;	//Atomizer
$ItemMax[barmor, newdoorone] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ newdoorone] = 0;
//	$TeamItemCount[1 @ newdoorone] = 0;
//	$TeamItemCount[2 @ newdoorone] = 0;
//	$TeamItemCount[3 @ newdoorone] = 0;
//	$TeamItemCount[4 @ newdoorone] = 0;
//	$TeamItemCount[5 @ newdoorone] = 0;
//	$TeamItemCount[6 @ newdoorone] = 0;
//	$TeamItemCount[7 @ newdoorone] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData newdooroneImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};
ItemData newdoorone
{
        description = "Panel One";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nDoors - Walls - Platforms";
        imageType = newdooroneImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function newdoorone::onUse(%player,%item)
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

function newdoorone::onDeploy(%player,%item,%pos)
{
        if (newdoorone::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorone::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorone","StaticShape",newdooroneShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall1 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Panel Type One deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorone"]++;
                                        echo("MSG: ",%client," deployed a Panel One Wall");
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