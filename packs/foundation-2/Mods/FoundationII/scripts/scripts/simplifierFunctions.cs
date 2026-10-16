//=========================================================
//functions used to simplify and reduce coding by ProtoManX
//unless noted otherwise
//=========================================================
//==================================================================
//Sets damage scale for given damage type for all armor and vehicles
//==================================================================
function setDamageScale(%type,%la,%ma,%ha,%sc,%lp,%hp,%dr)
{
        //males
        $DamageScale[larmor,%type] = %la;
        $DamageScale[marmor,%type] = %ma;

        //females
        $DamageScale[lfemale,%type] = %la;
        $DamageScale[mfemale,%type] = %ma;

        //hermaphrodites =P
        $DamageScale[harmor,%type] = %ha;

        //vehicles
        $DamageScale[Scout, %type] = %sc;
        $DamageScale[LAPC, %type] = %lp;
        $DamageScale[HAPC, %type] = %hp;

        //doors
        $DoorScale[%type] = %dr;
}

//======================================================
//sets item max for given item for each armor
//======================================================
function setArmorItemMax(%item,%la,%ma,%ha)
{
        //males
        $ItemMax[larmor,%item] = %la;
        $ItemMax[marmor,%item] = %ma;

        //females
        $ItemMax[lfemale,%item] = %la;
        $ItemMax[mfemale,%item] = %ma;

        //hermaphrodites =P
        $ItemMax[harmor,%item] = %ha;
}

//===================================================================
//sets weapons ammo amount to sell when sold of given weapon and ammo
//===================================================================
function addAmmo(%item,%iammo,%iasell,%apmax)
{
        $WeaponAmmo[%item] = %iammo;
        $SellAmmo[%iammo] = %iasell;
        addAPack(%iammo,%apmax);
}

//============================================================================
//Adds ammo and and set the ammo pack max and number of items in the ammo pack
//============================================================================
$APINum = 0;
function addAPack(%item,%ammo)
{
        $AmmoPackItems[$APINum] = %item;
        $AmmoPackMax[%item] = %ammo;
        $APINum++;
}

//======================================================
//adds items stations and remote inventory units
//======================================================
function addToInv(%item,%sinv,%rinv)
{
        $InvList[%item] = %sinv;
        $RemoteInvList[%item] = %rinv;
}

//======================================================
//adds items to list of items to reinit
//Note: I think I made this but its possible I took the
//      code from Annihilation or Devastator
//======================================================
$ReinitNum = 0;
function dataReinit(%item)
{
        $ReinitItem[$ReinitNum] = %item;
        $ReinitNum++;
}
//======================================================
//compares the team of 2 given objects
//Note: this was not done by ProtoManX I believe it was
//      Ice or I did it and forgot thinking i didn't ^^
//======================================================
function TeamCompare(%this,%object)
{
        if(Player::getClient(%this) == Player::getClient(%object))
                return You;
        else if($teamplay && GameBase::getTeam(%this) == GameBase::getTeam(%object))
                return Same;
        else
                return Diff;
}

//======================================================
//prints out info of given item to users screen
//Note: taken from Devastator Mod by Ice
//======================================================
function printMessage(%player,%item)
{
        %client = Player::getClient(%player);
        if(%item.className == Weapon || %item.className == Tool) {
                if($WeapPrint[%client] == false) {
                        return;
                }
                if($FireModes[%item] == "") {
                        Bottomprint(%client, $MountMSG[%item]);
                }
                else {
                        %CurMode = $WeapMode[%client,%item];
                        if(%CurMode == "" || %CurMode < 1)
                                %CurMode = 1;
                        else if(%CurMode > $FireModes[%item])
                                %CurMode = $FireModes[%item];
                        Bottomprint(%client, $MountMSG[%item,%CurMode]);
                }
        }
        else if(%item.className == Backpack) {
                if($PackPrint[%client] == false) {
                        return;
                }
                Bottomprint(%client, $MountMSG[%item]);
        }
        else if(%item.className == Armor)
        {
                if($BodyPrint[%client] == false) {
                        return;
                }
                %armormsg = "<JC><F2>Armor <F0>- <F1>" @ %item.description;
                %armormsg = %armormsg @ "\n<JC><F2>Beacon <F0>- <F1>" @ $BeaconMSG[%item];
                %armormsg = %armormsg @ "\n<JC><F2>Grenade <F0>- <F1>" @ $GrenadeMSG[%item];
                %armormsg = %armormsg @ "\n<JC><F2>Mine <F0>- <F1>" @ $MineMSG[%item];
//                %armormsg = %armormsg @ "\n<JC><F2>Contact <F0>- <F1>" @ $ContactMSG[%item];
                Centerprint(%client,%armormsg);
        }
}

//======================================================
//Makes adding and removing items from a mod simple
//while keeping auto sell and buy
//======================================================
function setSellDependants()
{
        %max = getNumItems();
        for (%i = 0; %i < %max; %i++)
                $ItemNTN[getItemData(%i)] = %i;
}

//==========================================================
//Reduces or Removes poison, fire, blinding, and/or emp time
//==========================================================
function Repair::checkStatus(%player,%time)
{
        if(%time == 50){
                %player.blinded = 0;
                %player.poisoned = 0;
                %player.burning = 0;
                %player.shorted = 0;
                return;
        }
        if(%player.blinded){
                if(%player.blinded > (%time * 2))
                        %player.blinded -= (%time * 2);
                else
                        %player.blinded = 0;
        }
        if(%player.poisoned){
                if(%player.poisoned > %time)
                        %player.poisoned -= %time;
                else
                        %player.poisoned = 0;
        }
        if(%player.burning){
                if(%player.burning > %time)
                        %player.burning -= %time;
                else
                        %player.burning = 0;
        }
        if(%player.shorted){
                if(%player.shorted > %time)
                        %player.shorted -= %time;
                else
                        %player.shorted = 0;
        }
}

//======================================================
//New deploy functions to make it easier
//======================================================

//checks terrain type
$TerrainMSG["ALL"] = "Whoa buddy wtf did you try to place this on";
$TerrainMSG["OBJECTS"] = "Can only deploy on objects";
$TerrainMSG["LAND"] = "Can only deploy on terrain or buildings";
$TerrainMSG["OUTSIDE"] = "Can only deploy on terrain or buildings but MUST be outside";

function terrainCheck(%obj,%terr)
{
        if(%terr == "ALL")
                return true;
        else if(%terr == "OBJECTS") {
                if(%obj == "Turret" || %obj == "sensor" || %obj == "StaticShape")
                        return true;
        }
        else if(%terr == "LAND") {
                if(%obj == "SimTerrain" || %obj == "InteriorShape")
                        return true;
        }
        else if(%terr == "OUTSIDE") { //outside only code from Annihilation
                if(%object=="SimTerrain" || %object=="InteriorShape") {
                        %num=0;
                        %setx = newObject("set",SimSet);
                        %pos1=$los::position;
                        %pos=Vector::Add(%pos1,"0 0 30");
                        %num = containerBoxFillSet(%setx,$SimInteriorObjectType,%pos,1,1,50,0);
                        deleteObject(%setx);
                        if(!%num)
                                return true;
                }
        }
        return false;
}

//check the proximity to the enemies base
$MinDeployDisctance = 120;
function offensiveCheck(%pos,%player)
{
        %dTeam = GameBase::getTeam(%player);
        for(%teamctr = 0; %teamctr < 8; %teamctr++) {
                if(%dTeam != %teamctr && %teamctr != -1) {
                        %group = nameToID("MissionGroup/Teams/team" @ %teamctr @ "/DropPoints/Random");
                        %spawnctr = Group::objectCount(%group);
                        if(!%spawnctr) {
                                return false;
                        }
                        for(%i = 0; %i < %spawnctr; %i++) {
                                %obj = Group::getObject(%group, %i);
                                %objpos = GameBase::getPosition(%obj);
                                if(Vector::getDistance(%pos,%objpos) <= $MinDeployDisctance)
                                        return true;
                        }
                }
        }
        return false;
}

//checks for objects of a given type
function typeCount(%set,%type,%num)
{
        if(%num == 0)
                return 0;
        %count = 0;
        for(%i=0;%i<%num;%i++) {
                %obj = GameBase::getDataName(Group::getObject(%set,%i));
                if(%obj.className == %type)
                        %count++;
        }
        return %count;
}

//deploys nearly any item
function Item::universalDeploy(%player,%item,%dist,%terr,%BxMxLn,%BxMxWd,%BxMxHt,%BxMnLn,%BxMnWd,%BxMnHt,%mib,%flat,%shape,%type,%dod)
{
        %client = Player::getClient(%player);
        %team = GameBase::getTeam(%player);
        if($TeamItemCount[%team @ %item] < $TeamItemMax[%item]) {
                if(GameBase::getLOSInfo(%player,%dist)) {
                        if((!offensiveCheck($los::position, %player)) || (%type != "Turret")) {
                                %obj = getObjectType($los::object);
                                if(terrainCheck(%obj,%terr)) {
                                        %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMxLn,%BxMxWd,%BxMxHt,0);
                                        %num = typeCount(%set,%type,%num);
                                        deleteObject(%set);
                                        if(%mib > %num || %mib == "") {
                                                %set = newObject("set",SimSet);
                                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMnLn,%BxMnWd,%BxMnHt,0);
                                                %num = typeCount(%set,%type,%num);
                                                deleteObject(%set);
                                                if(0 == %num) {
                                                        if(%flat == false) {
                                                                // Try to stick it straight up or down, otherwise
                                                                // just use the surface normal
                                                                if (Vector::dot($los::normal,"0 0 1") > 0.6)
                                                                        %rot = "0 0 0";
                                                                else {
                                                                        if (Vector::dot($los::normal,"0 0 -1") > 0.6)
                                                                                %rot = "3.14159 0 0";
                                                                        else
                                                                                %rot = Vector::getRotation($los::normal);
                                                                }
                                                        }
                                                        else {
                                                                if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
                                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                                                        return false;
                                                                }
                                                                else
                                                                        %rot = GameBase::getRotation(%player);
                                                        }
                                                        if(checkDeployArea(%client,$los::position,%terr)) {
                                                                %obj = newObject(%shape.shapeFile,%type,%shape,%dod);
                                                                addToSet("MissionCleanup", %obj);
                                                                GameBase::setTeam(%obj,%team);
                                                                GameBase::setPosition(%obj,$los::position);
                                                                GameBase::setRotation(%obj,%rot);
                                                                Client::sendMessage(%client,0,%item.description @ " deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                if($TeamItemMax[%item] != "") {
                                                                        $TeamItemCount[%team @ %item]++;
                                                                        Gamebase::setMapName(%obj,%shape.description @ "#" @ $TeamItemCount[%team @ %item] @ " " @ Client::getName(%client));
                                                                }
                                                                else
                                                                        Gamebase::setMapName(%obj,%shape.description);
                                                                Client::setOwnedObject(%client, %obj);
                                                                Client::setOwnedObject(%client, %player);
                                                                echo("MSG: ",%client," deployed a ",%shape.description);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"To close to another " @ %type);
                                        }
                                        else
                                                Client::sendMessage(%client,0,"To many " @ %type @ "s in the area");
                                }
                                else
                                        Client::sendMessage(%client,0,$TerrainMSG[%terr]);
                        }
                        else
                                Client::sendMessage(%client,0,"You can not deploy " @ %shape.description @ " in the enemy territory~waccess_denied.wav");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
        return false;
}

//======================================================
//Ice's Vector::getRotAim & getTransFix
//======================================================
//-Given two points, gives you the rotation aiming at the other point. EXAMPLE OF USE: ( GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object))); )
function Vector::getRotAim(%pos1,%pos2)
{
        %vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
        %rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
        return %rot;
}

//creates perfect spawn point if there is a target(actualy rotates the bullet so it is aiming at the location in cross hair)
function getTransFix(%player)
{
        $los::position = "";
        GameBase::getLOSInfo(%player,3000);
        %rot = GameBase::getRotation(%player);
        %targetPos = $los::position;
        $los::position = "";
        %trans = GameBase::getMuzzleTransform(%player);
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        %rot1 = %vec3@" "@%vec4@" "@%vec5;
        %pos1 = %vec6@" "@%vec7@" "@%vec8;
        %rot0 = Vector::getRotAim(%Pos1,%targetPos);
        %vec = Vector::getFromRot(%rot0,1);
        if(%targetPos)
                %trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot1@" "@%pos1;
//        echo("Set1["@%vec0@" "@%vec1@" "@%vec2@"] Set2["@%vec@"] Set3["@%rot1@"] Set4["@%pos1@"]");
        return %trans;
}
