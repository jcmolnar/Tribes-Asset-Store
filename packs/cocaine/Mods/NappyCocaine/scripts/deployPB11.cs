// Bunker
// by C|one
$TeamItemMax[CommandCenterPack11] = Infinite;
$InvList[CommandCenterPack11] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack11] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack11::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack11] = 0; 
	$TeamItemCount[1 @ CommandCenterPack11] = 0; 
	$TeamItemCount[2 @ CommandCenterPack11] = 0; 
	$TeamItemCount[3 @ CommandCenterPack11] = 0; 
	$TeamItemCount[4 @ CommandCenterPack11] = 0; 
	$TeamItemCount[5 @ CommandCenterPack11] = 0; 
	$TeamItemCount[6 @ CommandCenterPack11] = 0; 
	$TeamItemCount[7 @ CommandCenterPack11] = 0;
} 


ItemImageData CommandCenterPack11Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack11
{
        description = "Dropship 4";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack11Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack11::onUse(%player,%item)
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

function CommandCenterPack11::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack11::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack11::deployShape(%player,%item)
{

        %client = Player::getClient(%player);

if(%player.outArea == 1 || %player.outArea == 0) {

        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,10))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %obj == "StaticShape")
                        {
				 
	
                                if (Vector::dot($los::normal,"5 13 80") > 0.7)
                                {
                        

				%rot = getWord(GameBase::getRotation(%player), 2);
				%ccname = "CommCen11" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase11" {
                                        filename="GSWDROP.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 20");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundFireBlaster,$los::position);
                                Client::sendMessage(%client,0,"Deployed the Dropship (4) base.");

					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen11" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack11"]++;
                                %playerpos = GameBase::getPosition(%player);
                                %newplayerpos = Vector::add(%playerpos, "0 0 0.2");
                                GameBase::setPosition(%player,%newplayerpos);
                                
                                return true;
                                }
                                else
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain.");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
}
else
	Client::sendMessage(%client,0,"Can only deploy outside the mission area!");
                 return false;

}