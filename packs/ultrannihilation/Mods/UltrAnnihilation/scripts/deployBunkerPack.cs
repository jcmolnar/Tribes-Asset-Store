$InvList[BunkerPack] = 1;
$MobileInvList[BunkerPack] = 1;
$RemoteInvList[BunkerPack] = 0;

//-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployBunkerPack::Initialize()
{	$TeamItemCount[0 @ BunkerPack] = 0;
	$TeamItemCount[1 @ BunkerPack] = 0;
	$TeamItemCount[2 @ BunkerPack] = 0;
	$TeamItemCount[3 @ BunkerPack] = 0;
	$TeamItemCount[4 @ BunkerPack] = 0;
	$TeamItemCount[5 @ BunkerPack] = 0;
	$TeamItemCount[6 @ BunkerPack] = 0;
	$TeamItemCount[7 @ BunkerPack] = 0;
}

ItemImageData BunkerPackImage
{	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData BunkerPack
{	description = "Deployable Bunker";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};
function BunkerPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function BunkerPack::onDeploy(%player,%item,%pos)
{	if (BunkerPack::deployShape(%player,%item)) 
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

function BunkerPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
				%num = CountObjects(%set,"eround1",%num);
				deleteObject(%set);
				if(20 > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
					%num = CountObjects(%set,"eround1",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(BnkrDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%vctr = "0 0 3.3";
								%rot = Vector::add(%rot,%vctr);
								%bunker = newObject("eround1",InteriorShape,"eround.dis",false);
				                     addToSet("MissionCleanup", %bunker);
								GameBase::setTeam(%bunker,GameBase::getTeam(%player));
								GameBase::setPosition(%bunker,$los::position);
								GameBase::setRotation(%bunker,%rot);
								Client::sendMessage(%client,0,"Bunker Deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
								echo("MSG: ",%client," deployed a bunker.");
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

function BnkrDeployArea(%client,%pos)
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