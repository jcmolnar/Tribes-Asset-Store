//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[TowerPack] = 1;

$TeamItemMax[TowerPack] = 3;

$ItemMax[larmor, TowerPack] = 0;	//Seraph
$ItemMax[lfemale, TowerPack] = 0;	//Seraph
$ItemMax[earmor, TowerPack] = 1;	//Slave
$ItemMax[efemale, TowerPack] = 1;	//Slave
$ItemMax[marmor, TowerPack] = 0;	//Pawn
$ItemMax[aarmor, TowerPack] = 0;	//Navigator
$ItemMax[darmor, TowerPack] = 0;	//Atomizer
$ItemMax[barmor, TowerPack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ TowerPack] = 0;
//	$TeamItemCount[1 @ TowerPack] = 0;
//	$TeamItemCount[2 @ TowerPack] = 0;
//	$TeamItemCount[3 @ TowerPack] = 0;
//	$TeamItemCount[4 @ TowerPack] = 0;
//	$TeamItemCount[5 @ TowerPack] = 0;
//	$TeamItemCount[6 @ TowerPack] = 0;
//	$TeamItemCount[7 @ TowerPack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData TowerPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TowerPack
{	description = "Tower";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "hDeployable Base Objects";
	imageType = TowerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};
function TowerPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function TowerPack::onDeploy(%player,%item,%pos)
{	if (TowerPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{	%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TowerPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
				%num = CountObjects(%set,"BETower2",%num);
				deleteObject(%set);
				if(20 > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
					%num = CountObjects(%set,"BETower2",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) { //"0 0 1"
									if(TwrDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%vctr = "0 0 0"; //"0 0 3.3"
								%rot = Vector::add(%rot,%vctr);
								%tower = newObject("BETower2",InteriorShape,"BETower2.dis",false);//eround.dis
				                     addToSet("MissionCleanup", %tower);
								GameBase::setTeam(%tower,GameBase::getTeam(%player));
								GameBase::setPosition(%tower,$los::position);
								GameBase::setRotation(%tower,%rot);
								Client::sendMessage(%client,0,"Tower Deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TowerPack"]++;
								echo("MSG: ",%client," deployed a Tower.");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Too close to other objects.");
				}
			   else 
					Client::sendMessage(%client,0,"Too close to other objects.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function TwrDeployArea(%client,%pos)
{  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}