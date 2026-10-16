// Bunker
// by C|one
$TeamItemMax[CommandCenterPack19] = Infinite;
$InvList[CommandCenterPack19] = 1;
$CanAlwaysTeamDestroy[CommandCenterPack19] = 1;


// ebunker, arena2,command1,common1
function CommandCenterPack19::Initialize()
{
	$TeamItemCount[0 @ CommandCenterPack19] = 0; 
	$TeamItemCount[1 @ CommandCenterPack19] = 0; 
	$TeamItemCount[2 @ CommandCenterPack19] = 0; 
	$TeamItemCount[3 @ CommandCenterPack19] = 0; 
	$TeamItemCount[4 @ CommandCenterPack19] = 0; 
	$TeamItemCount[5 @ CommandCenterPack19] = 0; 
	$TeamItemCount[6 @ CommandCenterPack19] = 0; 
	$TeamItemCount[7 @ CommandCenterPack19] = 0;
} 


ItemImageData CommandCenterPack19Image
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData CommandCenterPack19
{
        description = "Leviathan";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "iDeployable Bases";
        shadowDetailMask = 4;
        imageType = CommandCenterPack19Image;
        mass = 2.0;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function CommandCenterPack19::onUse(%player,%item)
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

function CommandCenterPack19::onDeploy(%player,%item,%pos)
{
	if (CommandCenterPack19::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CommandCenterPack19::deployShape(%player,%item)
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
				%ccname = "CommCen19" @ Client::getTeam(%player);

                        instant SimGroup %ccname  {
                                instant InteriorShape "CommCenBase19" {
                                        filename="challs2.0.dis";
                                        iscontainer="1";
                                        position=Vector::add(Gamebase::getPosition(%player), "0 0 1000");
                                        rotation="0 0 " @ %rot;
                                        lightparams="1";
                                        locked="0";
                                        
                                        };


                                };

                                playSound(SoundActivateInventoryStation,$los::position);
                                Client::sendMessage(%client,0,"Deployed the Leviathan base. You have been transported inside it.");

















        GameBase::getLOSInfo(%player,10);
        %client = Player::getClient(%player);
                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);

                %obj = getObjectType($los::object);

                %set = newObject("Leviathan Inventory Stand",SimSet);
                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                %num = CountObjects(%set,"Leviathan Inventory Stand",%num);



                %objDevice =   newObject("Leviathan Inventory Stand","Staticshape",UBaseThing,true);


                 addToSet(MissionCleanup, %objDevice);


                 %pos = Vector::add(GameBase::getPosition(%player), "0 .5 700");
                 GameBase::setRotation(%objDevice,"4.71339 0 0");
                 GameBase::setPosition(%objDevice,%pos);
                 GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

                playSound(SoundPickupBackpack,$los::position);


                                        %sensor = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
                                                addToSet("MissionCleanup/ammounit_remote", %sensor);
                                                addToSet("MissionCleanup", %sensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                 %pos = Vector::add(GameBase::getPosition(%player), "0 305 700");
                                                GameBase::setPosition(%sensor,%pos);
                                                Gamebase::setMapName(%sensor,%name);


                                                %sensor.disabled = false;
                                                playSound(SoundPickupBackpack,$los::position);



                                                GameBase::setPosition(%sensor,%pos);
                                                Gamebase::setMapName(%sensor,%name);


                                                %sensor.disabled = false;



                                                $TeamItemCount[GameBase::getTeam(%sensor) @ "ubasepack"]++;
//
%playerpos = GameBase::getPosition(%player);
%newplayerpos = Vector::add(%playerpos, "0 300 700");
GameBase::setPosition(%player,%newplayerpos);
//










































					  //Get rid of it when we change missions...
					  addToSet("MissionCleanup","CommCen19" @ Client::getTeam(%player));

                                $TeamItemCount[GameBase::getTeam(%player) @ "CommandCenterPack19"]++;
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