// Bunker
// by C|one
$TeamItemMax[CommandCenterPack18] = Infinite;
$InvList[CommandCenterPack18] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack18] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack18::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack18] = 0; 
	$TeamItemCount[1 @ CommandCenterPack18] = 0; 
	$TeamItemCount[2 @ CommandCenterPack18] = 0; 
	$TeamItemCount[3 @ CommandCenterPack18] = 0; 
	$TeamItemCount[4 @ CommandCenterPack18] = 0; 
	$TeamItemCount[5 @ CommandCenterPack18] = 0; 
	$TeamItemCount[6 @ CommandCenterPack18] = 0; 
	$TeamItemCount[7 @ CommandCenterPack18] = 0;
} 


ItemImageData CommandCenterPack18Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack18
{
        description = "Phoenix Tower";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack18Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack18::onUse(%player,%item)
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

function CommandCenterPack18::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack18::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack18::deployShape(%player,%item)
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
				%ccname = "CommCen18" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase18" {
                                        filename="Phoenixtower.0.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 5");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundFireBlaster,$los::position);
                                Client::sendMessage(%client,0,"Deployed the Phoenix Tower base. (You are now inside its walls. Walk backwards to get out.)");

					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen18" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack18"]++;
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