// Bunker
// by C|one
$TeamItemMax[CommandCenterPack4] = Infinite;
$InvList[CommandCenterPack4] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack4] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack4::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack4] = 0; 
	$TeamItemCount[1 @ CommandCenterPack4] = 0; 
	$TeamItemCount[2 @ CommandCenterPack4] = 0; 
	$TeamItemCount[3 @ CommandCenterPack4] = 0; 
	$TeamItemCount[4 @ CommandCenterPack4] = 0; 
	$TeamItemCount[5 @ CommandCenterPack4] = 0; 
	$TeamItemCount[6 @ CommandCenterPack4] = 0; 
	$TeamItemCount[7 @ CommandCenterPack4] = 0;
} 


ItemImageData CommandCenterPack4Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack4
{
        description = "DangerousCrossing";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack4Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack4::onUse(%player,%item)
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

function CommandCenterPack4::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack4::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack4::deployShape(%player,%item)
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
				%ccname = "CommCen4" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase4" {
                                        filename="tank17.1.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 -10");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundFireBlaster,$los::position);
                                Client::sendMessage(%client,0,"Deployed the DangerousCrossing base. (You are now inside its walls. Walk forward or jetpack to get out.)");

					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen4" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack4"]++;
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