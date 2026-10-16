//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[TripwirePack] = 1;

$TeamItemMax[TripwirePack] = 60;

$ItemMax[larmor, TripwirePack] = 0;	//Seraph
$ItemMax[lfemale, TripwirePack] = 0;	//Seraph
$ItemMax[earmor, TripwirePack] = 1;	//Slave
$ItemMax[efemale, TripwirePack] = 1;	//Slave
$ItemMax[marmor, TripwirePack] = 0;	//Pawn
$ItemMax[aarmor, TripwirePack] = 0;	//Navigator
$ItemMax[darmor, TripwirePack] = 0;	//Atomizer
$ItemMax[barmor, TripwirePack] = 0;	//Paladin

//function deployBlastDoor::Initialize()
//{	
//	$TeamItemCount[0 @ TripwirePack] = 0;
//	$TeamItemCount[1 @ TripwirePack] = 0;
//	$TeamItemCount[2 @ TripwirePack] = 0;
//	$TeamItemCount[3 @ TripwirePack] = 0;
//	$TeamItemCount[4 @ TripwirePack] = 0;
//	$TeamItemCount[5 @ TripwirePack] = 0;
//	$TeamItemCount[6 @ TripwirePack] = 0;
//	$TeamItemCount[7 @ TripwirePack] = 0;
//}

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData TripwirePackImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TripwirePack 
{ 
	description = "Blast Wall"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = "nDoors - Walls - Platforms"; 
	imageType = TripwirePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 50; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function TripwirePack::onUse(%player,%item) 
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

function TripwirePack::onDeploy(%player,%item,%pos) 
{ 
	if (TripwirePack::deployShape(%player,%item)) 
	{ 
		Player::decItemCount(%player,%item); 
	} 
} 

function TripwirePack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,10)) 
		{ 
			%obj = "SimTerrain"; 
			if (%obj == "SimTerrain") 
			{ 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); 
				%num = CountObjects(%set,"BlastWall",%num); 
				deleteObject(%set); 
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{ 
					if(checkDeployArea(%client,$los::position)) 
					{ 
						%rot = GameBase::getRotation(%player); 
						%phase = newObject("","StaticShape",BlastWall,true); 
						addToSet("MissionCleanup", %phase); 
						GameBase::setTeam(%phase,GameBase::getTeam(%player));
						GameBase::setPosition(%phase,$los::position);
						GameBase::setRotation(%phase,%rot);
						Gamebase::setMapName(%phase,"Blast Wall");
						Client::sendMessage(%client,0,"Blast Wall Deployed");
						GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position);
						playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++;
						return true;
					}
				}
				else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
} 