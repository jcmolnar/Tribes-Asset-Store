// Bunker
// by C|one
$TeamItemMax[CommandCenterPack17] = Infinite;
$InvList[CommandCenterPack17] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack17] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack17::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack17] = 0; 
	$TeamItemCount[1 @ CommandCenterPack17] = 0; 
	$TeamItemCount[2 @ CommandCenterPack17] = 0; 
	$TeamItemCount[3 @ CommandCenterPack17] = 0; 
	$TeamItemCount[4 @ CommandCenterPack17] = 0; 
	$TeamItemCount[5 @ CommandCenterPack17] = 0; 
	$TeamItemCount[6 @ CommandCenterPack17] = 0; 
	$TeamItemCount[7 @ CommandCenterPack17] = 0;
} 


ItemImageData CommandCenterPack17Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack17
{
        description = "Tower";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack17Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack17::onUse(%player,%item)
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

function CommandCenterPack17::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack17::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack17::deployShape(%player,%item)
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
				%ccname = "CommCen17" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase17" {
                                        filename="BATower2.0.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 5");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundFireBlaster,$los::position);
                                Client::sendMessage(%client,0,"Deployed the Tower base.");

					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen17" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack17"]++;
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