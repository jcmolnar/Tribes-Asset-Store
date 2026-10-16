// Bunker
// by C|one
$TeamItemMax[CommandCenterPack7] = Infinite;
$InvList[CommandCenterPack7] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack7] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack7::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack7] = 0; 
	$TeamItemCount[1 @ CommandCenterPack7] = 0; 
	$TeamItemCount[2 @ CommandCenterPack7] = 0; 
	$TeamItemCount[3 @ CommandCenterPack7] = 0; 
	$TeamItemCount[4 @ CommandCenterPack7] = 0; 
	$TeamItemCount[5 @ CommandCenterPack7] = 0; 
	$TeamItemCount[6 @ CommandCenterPack7] = 0; 
	$TeamItemCount[7 @ CommandCenterPack7] = 0;
} 


ItemImageData CommandCenterPack7Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack7
{
        description = "Dropship 2";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack7Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack7::onUse(%player,%item)
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

function CommandCenterPack7::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack7::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack7::deployShape(%player,%item)
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
				%ccname = "CommCen7" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase7" {
                                        filename="GCOTPdrop.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 20");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundFireBlaster,$los::position);
                                Client::sendMessage(%client,0,"Deployed the Dropship (2) base.");

					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen7" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack7"]++;
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