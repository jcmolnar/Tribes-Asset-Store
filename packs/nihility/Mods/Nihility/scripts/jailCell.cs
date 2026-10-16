//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[JailPack] = 1;

$TeamItemMax[JailPack] = 1;

$ItemMax[larmor, JailPack] = 0;		//Seraph
$ItemMax[lfemale, JailPack] = 0;	//Seraph
$ItemMax[earmor, JailPack] = 1;		//Slave
$ItemMax[efemale, JailPack] = 1;	//Slave
$ItemMax[marmor, JailPack] = 0;		//Pawn
$ItemMax[aarmor, JailPack] = 0;		//Navigator
$ItemMax[darmor, JailPack] = 0;		//Atomizer
$ItemMax[barmor, JailPack] = 0;		//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ JailPack] = 0;
//	$TeamItemCount[1 @ JailPack] = 0;
//	$TeamItemCount[2 @ JailPack = 0;
//	$TeamItemCount[3 @ JailPack] = 0;
//	$TeamItemCount[4 @ JailPack] = 0;
//	$TeamItemCount[5 @ JailPack] = 0;
//	$TeamItemCount[6 @ JailPack] = 0;
//	$TeamItemCount[7 @ JailPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData jailpackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};



ItemData jailpack
{
description = "Jail Cell";
shapeFile = "shieldpack";
className = "Backpack";
heading = "lJail Equipment";
imageType = jailpackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 5000;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};




function jailpack::onUse(%player,%item)
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




function jailpack::onDeploy(%player,%item,%pos)
{
        if (jailpack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);

        }
}




function CreatejailportSimSet()
{
    %teleset = nameToID("MissionCleanup/jailports");
        if(%teleset == -1)
        {
                newObject("jailports",SimSet);
                addToSet("MissionCleanup","jailports");
        }
}




function jailpack::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,10);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack])
        {
        Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
        return false;
         }
                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);

                if(Vector::getDistance(%flagpos, %playerpos) < 150)
                {
                 Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
                 return ;
                }
                %obj = getObjectType($los::object);

                %set = newObject("Jail",SimSet);
                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                %num = CountObjects(%set,"Jail",%num);



                %objDevice =   newObject("Jail","Staticshape",LLargeForceField,true);
                %objDevice.objSide1 = newObject("Jail","Staticshape",LLargeForceField,true);
                %objDevice.objSide2 = newObject("Jail","Staticshape",LLargeForceField,true);
                %objDevice.objSide3 = newObject("Jail","Staticshape",LLargeForceField,true);
                %objDevice.objSide4 = newObject("Jail","Staticshape",LLargeForceField,true);
                %objDevice.objSide5 = newObject("Jail","StaticShape",LLargeForceField,true);
                %objDevice.objSide6 = newObject("Jail","StaticShape",LLargeForceField,true);
                %objDevice.objSide7 = newObject("Jail","StaticShape",LLargeForceField,true);
                %objDevice.objSide8 = newObject("Jail","StaticShape",JailSwitchOpen,true);
                %objDevice.objSide9 = newObject("Jail","StaticShape",LLargeForceField,true);
                %objDevice.objSide10 = newObject("Jail","StaticShape",JailSwitchClose,true);


                %objDevice.objSide1.objParent = %objDevice;
                %objDevice.objSide2.objParent = %objDevice;
                %objDevice.objSide3.objParent = %objDevice;
                %objDevice.objSide4.objParent = %objDevice;
                %objDevice.objSide5.objParent = %objDevice;
                %objDevice.objSide6.objParent = %objDevice;
                %objDevice.objSide7.objParent = %objDevice;
                %objDevice.objSide8.objParent = %objDevice;
                %objDevice.objSide9.objParent = %objDevice;
                %objDevice.objSide10.objParent = %objDevice;




                 addToSet(MissionCleanup, %objDevice);

                 addToSet(MissionCleanup, %objDevice.objSide1);
                 addToSet(MissionCleanup, %objDevice.objSide2);
                 addToSet(MissionCleanup, %objDevice.objSide3);
                 addToSet(MissionCleanup, %objDevice.objSide4);
                 addToSet(MissionCleanup, %objDevice.objSide5);
                 addToSet(MissionCleanup, %objDevice.objSide6);
                 addToSet(MissionCleanup, %objDevice.objSide7);
                 addToSet(MissionCleanup, %objDevice.objSide8);
                 addToSet(MissionCleanup, %objDevice.objSide9);
                 addToSet(MissionCleanup, %objDevice.objSide10);

                %pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
                GameBase::setRotation(%objDevice.objSide1,"0 0 0");
                GameBase::setPosition(%objDevice.objSide1,%pos);
                GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
                GameBase::setRotation(%objDevice.objSide2,"0 0 4.71339");
                GameBase::setPosition(%objDevice.objSide2,%pos);
                GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
                GameBase::setRotation(%objDevice.objSide3,"0 0 4.71339");
                GameBase::setPosition(%objDevice.objSide3,%pos);
                GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

                 %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
                 GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
                 GameBase::setPosition(%objDevice.objSide4,%pos);
                 GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));

                 %pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
                 GameBase::setRotation(%objDevice,"4.71339 0 0");
                 GameBase::setPosition(%objDevice,%pos);
                 GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
                GameBase::setRotation(%objDevice.objSide6,"-4.71339 0 0");
                GameBase::setPosition(%objDevice.objSide6,%pos);
                GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
                 GameBase::setRotation(%objDevice.objSide7,"4.71339 0 0");
                 GameBase::setPosition(%objDevice.objSide7,%pos);
                 GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));

                 %pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
                 GameBase::setRotation(%objDevice.objSide8,"0 0 0");
                 GameBase::setPosition(%objDevice.objSide8,%pos);
                 GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));

                 %pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
                 GameBase::setRotation(%objDevice.objSide9,"-4.71339 0 0");
                 GameBase::setPosition(%objDevice.objSide9,%pos);
                 GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));


                 %pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
                 GameBase::setRotation(%objDevice.objSide10,"0 0 0");
                 GameBase::setPosition(%objDevice.objSide10,%pos);
                 GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));


                playSound(SoundPickupBackpack,$los::position);

               newObject("jaildoor",SimSet);
                addToSet("MissionCleanup","jaildoor");
                %sensor = newObject("jaildoor","StaticShape",jLargeForceField,true);

                                                addToSet("MissionCleanup/jaildoor", %sensor);
                                                addToSet("MissionCleanup", %sensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                %pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
                                                GameBase::setPosition(%sensor,%pos);
                                                GameBase::setRotation(%sensor,"0 0 0");
                                                %sensor.disabled = false;
                                                playSound(SoundPickupBackpack,$los::position);



                                        %sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
                                                CreatejailportSimSet();
                                                addToSet("MissionCleanup/jailports", %sensor);
                                                addToSet("MissionCleanup", %sensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                 %pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
                                                GameBase::setPosition(%sensor,%pos);
                                                Gamebase::setMapName(%sensor,%name);


                                                %sensor.disabled = false;
                                                playSound(SoundPickupBackpack,$los::position);

                                                %beam = newObject("","StaticShape",ElectricalBeamBig,true);
                                                addToSet("MissionCleanup", %beam);
                                                GameBase::setTeam(%beam,GameBase::getTeam(%player));
                                                GameBase::setPosition(%beam,%pos);
                                                %sensor.beam1 = %beam;
                                                playSound(SoundPickupBackpack,$los::position);


                                                newObject("releasepad",SimSet);
                                                CreatereleasepadSimSet();
                                                addToSet("MissionCleanup/releasepad", %sensor);
                                                addToSet("MissionCleanup", %sensor);
                                                %sensor = newObject("releasepad","StaticShape","jailStandTop",true);

                                                addToSet("MissionCleanup/releasepad", %sensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                %pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");

                                                GameBase::setPosition(%sensor,%pos);
                                                Gamebase::setMapName(%sensor,%name);


                                                %sensor.disabled = false;


                                                $TeamItemCount[GameBase::getTeam(%sensor) @ "jailpack"]++;
                                                echo("MSG: ",%client," deployed a Jail Cell");
                                                Client::sendMessage(%client,0,%item.description @ " deployed 250' Up");
                return true;
               }



function CreatereleasepadSimSet()
{
%teleset = nameToID("MissionCleanup/releasepad");
if(%teleset == -1)
{
newObject("releasepad",SimSet);
addToSet("MissionCleanup","releasepad");
}
}