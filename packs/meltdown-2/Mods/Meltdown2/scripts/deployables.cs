function deployShape(%player,%item,%name,%losDeployDist,%objectType,%object,%deploySlant,%bTerrain,%bInteriorShape,%bBlastFloor)
{
	if($TeamItemCount[GameBase::getTeam(%player) @ %object] < $TeamItemMax[%object]) 
	{
		if(GameBase::getLOSInfo(%player,%losDeployDist)) 
		{
			if((%bTerrain && getObjectType($los::object) == "SimTerrain") || (%bInteriorShape && getObjectType($los::object) == "InteriorShape") || (%bBlastFloor && getObjectType($los::object) == "StaticShape"))
			{
				if(Vector::dot($los::normal,"0 0 1") > %deploySlant) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%deploy = newObject(%name,%objectType,%object,true);
						addToSet("MissionCleanup", %deploy);
						GameBase::setTeam(%deploy,GameBase::getTeam(%player));
						GameBase::setPosition(%deploy,$los::position);
						GameBase::setRotation(%deploy,GameBase::getRotation(%player));
						Gamebase::setMapName(%deploy,%name);
						Client::sendMessage(Player::getClient(%player),0, %item.description @" deployed.");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%this) @ %object]++;
						echo("MSG: ",getName(%player)," deployed ",%item);
						return true;
					}
				}
				else 
					Client::sendMessage(Player::getClient(%player),0,"Cannot deploy here");
			}
			else 
				Client::sendMessage(Player::getClient(%player),0,"Cannot deploy here");
		}
		else 
			Client::sendMessage(Player::getClient(%player),0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(Player::getClient(%player),0,"Deployable limit reached for " @ %item.description @ "s");

	return false;
}

//-----------------------------------------------------------------------------------------------------------
//					AAOD Deployables File
//___________________________________________________________________________________________________________
//	Contains all the Deployable related functions as well as the generic 
//	Deployable Routines......
//-----------------------------------------------------------------------------------------------------------

$boostStr	= 0.17;

function PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName)
{	if($trace) echo( $ver@"|Pack up Stuff");
	if(%this.isbusy)
	{	Client::sendMessage(%client,0,"Unable to Pack up - Unit is Busy performing some function!~wError_message.wav");
		return(false);
	}

	if(%this.ShieldNode)
	{	Client::sendMessage(%client,0,"Unable to Pack up - Unit has an Attached Shield Node.| Pack Shield Node up First!~wError_message.wav");
		return(false);
	}

	%name = Client::getName(%client);
	%team = Client::getTeam(%client);
	%pack=Player::getMountedItem(%player,$BackpackSlot);
	if (%nopack==true)	// If Client must not have a pack on to pack up
		if(%pack!=-1)	// then check to see if he has a pack
		{	Client::sendMessage(%client,0,"Unable to Pack up - You are wearing a Pack!~wError_message.wav");
			return(false);		// if he does return without packing up
		}

	if(%armor!="")
	{	%parmor = Player::getArmor(%client);
		%parm=String::getSubStr(%parmor, 0, 1);
		%num=String::findSubStr(%armor, %parm);	//	Is the Armor Type the player is wearing in the list of acceptable armor types
		if (%num==-1)
		{	Client::sendMessage(%client,0,"Unable to Pack up - You are not wearing the compatable armor!~wError_message.wav");
			return(false);		// if he is not wearing right armor return without packing up
		}
			
	}
			
	if(GameBase::getDamageLevel(%this)!=0)				// Item is Damaged so dont Pack it up
	{	Client::sendMessage(%client,0,"Unable to Pack up "@%desc@". It Requires Repair!~wError_message.wav");	
		return(false);
	}
	else
	{	GameBase::stopSequence(%this,0);
		GameBase::setSequenceDirection(%this,1,0);
		GameBase::playSequence(%this,1,"deploy");
		if(%this.pset)	//	Is This a power generator???
		{	GameBase::virtual(%this,"Disabled");
			%player.isDeploying = true;
			%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");
			%td=DisconnectGenerator(%this)+1;	// Dis-connect it from the grid
			removeFromSet($GenSet[%team],%this);
			schedule("GameBase::startFadeOut("@%this@");",%td,%this);
			schedule("deleteObject(" @ %this @ ");",(%td+1),%this);
			schedule("PlaceItemPack(" @ %player @ "," @ %pName @ ",\"" @ %pos @ "\");",(%td+1.15),%player);		
			return(true);
		}
		else
		{	%player.isDeploying = true;
			%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");
			GameBase::startFadeOut(%this);
			schedule("deleteObject(" @ %this @ ");",1.0,%this);
			schedule("PlaceItemPack(" @ %player @ "," @ %pName @ ",\"" @ %pos @ "\");",1.15,%player);		
			return(true);
		}
		echo(">INF: ",$User[%client]," Packed up a "@%desc);
	}
}

function DeployTheShape(%player, %item, %turret, %objects, %flagdist, %flatonly, %MaxLength, %MaxWidth, %MaxHeight, %MinLength, %MinWidth, %MinHeight, %number, %msg) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance(GameBase::getPosition($teamFlag[%playerTeam]), $los::position) < %flagdist) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				return false;
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%set = newObject("set",SimSet); 
			%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 32, 32, 17, 0); 
			%num = CountThes(%set, %num);
			deleteObject(%set); 
			if(%num > 4) {
				Client::sendMessage(%client,0,"Sensor Interference - Too many turrets in the area");
				return false;
			}			
			%set = newObject("set",SimSet); 
			%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MaxLength, %MaxWidth, %MaxHeight, 0); 
			%num = CountObjects(%set, %turret, %numinset);
			%object = getword(%objects, 0);
			for(%i = 1; %object != -1; %i++) {
				%num = %num + CountObjects(%set, %object, %numinset);
				%object = getword(%objects, %i);
			}
			deleteObject(%set); 
			if(%num < $MaxNumTurretsInBox) { 
				%set = newObject("set",SimSet); 
				%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MinLength, %MinWidth, %MinHeight, 0); 
				%num = CountObjects(%set, %turret, %numinset);
				%object = getword(%objects, 0);
				for(%i = 1; %object != -1; %i++) {
					%num = %num + CountObjects(%set, %object, %numinset);
					%object = getword(%objects, %i);
				}
				deleteObject(%set); 
				if(%num == 0) {
					%rot = GameBase::getRotation(%player);
					if (%flatonly) {
						if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
							return false;
						}
					} else {
						%zRot = getWord(%rot, 2);
						if (Vector::dot($los::normal, "0 0 1") > 0.6) {
							%rot = "0 0 " @ %zRot;
						} else {
							if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
								%rot = "3.14159 0 " @ %zRot;
							} else {
								%rot = Vector::getRotation($los::normal);
							}
						}
					}
					if(%number != "") {
						%number++;
						%number = " #" @ %number;
					}
					%turret = newObject("", "Turret", %turret, true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret, %playerTeam);
					GameBase::setRotation(%turret, %rot);
					GameBase::startFadeIn(%turret);
					GameBase::setPosition(%turret, $los::position);
					%turret.ownerName = Client::getName(%client); 
					dotog(%player);
					Gamebase::setMapName(%turret, %item.description @ %number @ " " @ %turret.ownerName);
					Client::sendMessage(%client, 0, %item.description @ %number @ " deployed");
					echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description,%number); 
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[%playerTeam @ %item]++;
					%client.hasDeployed = true;
					doset(%client, %player, %turret);
					return %turret;
				} else
					Client::sendMessage(%client,0,"Frequency Overload - Too close to another " @ %msg @ " Turret"); 
			} else
				Client::sendMessage(%client,0,"Interference from other " @ %msg @ " Turrets in the area");
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function DeployAnyShape(%player, %item, %cat, %name, %flatonly, %deployon) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance(GameBase::getPosition($teamFlag[%playerTeam]), $los::position) < 1) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if(%deployon == 1) {
				if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
					Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
					return false;
				}
			} else if(%deployon == 2) {
				if (%obj != "SimTerrain") {
					Client::sendMessage(%client,0,"Can only deploy on terrain");
					return false;
				}
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%rot = GameBase::getRotation(%player);
			if (%flatonly) {
				if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					return false;
				}
			} else {
				%zRot = getWord(%rot, 2);
				if (Vector::dot($los::normal, "0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				} else {
					if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					} else {
						%rot = Vector::getRotation($los::normal);
					}
				}
			}
			%turret = newObject("", %cat, %name, true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret, %playerTeam);
			GameBase::setRotation(%turret, %rot);
			GameBase::startFadeIn(%turret);
			GameBase::setPosition(%turret, $los::position);
			%turret.ownerName = Client::getName(%client); 
			dotog(%player);
			Gamebase::setMapName(%turret, %item.description);
			Client::sendMessage(%client, 0, %item.description @ " deployed");
			echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description); 
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[%playerTeam @ %item]++;
			%client.hasDeployed = true;
			doset(%client, %player, %turret);
			return %turret;
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function CheckObjectType(%object,%type)
{	//if($traceDep) Echo("Checking: Is deployable placement on ",%object," valid for type: ",%type);

	if (%type==0)		// **** Can be PLaced on Terrain Only
	{	if (%object=="SimTerrain")
			return(true);
	}
	else if (%type==1)	// **** Can Be Placed on Terrain & Buildings
	{	if (%object=="SimTerrain" || %object=="InteriorShape")
			return(true);
	}	
	else if (%type==2)	// **** Can Be Placed on Terrain, Buildings & Some objects
	{	if ((%object=="SimTerrain" || %object=="InteriorShape" ) || (%object=="Turret" || %object=="sensor"))
			return(true);
	}
	else if(%type==3)	// **** Can Be Placed on Buildings & Terrain but Must be Outside
	{	if (%object=="SimTerrain" || %object=="InteriorShape")
		{	%num=0;
			%setx = newObject("set",SimSet);
			%pos1=$los::position;
			%pos=Vector::Add(%pos1,"0 0 30");
			%num = containerBoxFillSet(%setx,$SimInteriorObjectType,%pos,1,1,50,0);
			deleteObject(%setx);
			if(!%num)			
				return(true);
		}
	}
	return(false);
}

function DeployStuff(%player,%item,%shape,%pType,%dist,%cType,%dtype,%DonD,%Power,%pRange)
{	
	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	// %ptype = 0 for SimTerrain only
	// %ptype = 1 for SimTerrain or Interior Shapes
	// %ptype = 2 for SimTerrain or Interior Shapes or Objects
	// %ptype = 3 Outside clear sky above....(is this possible - The answer being yes!!!)
	// %dist is the max deploy distance
	// %ctype = 0	Use Defaults for Interference Checking
	// %ctype = 1	Turret Use Turret Box Values for checking interference
	// %ctype = 2	Forcefield Use Forcefield Values for Interference checking
	// %dtype = true or false	(True means it can be placed on any surface)
	// %shape = Shape Name (String) The Name of the DATA Block for this shape
	// %shape = Shape
	// %DonD  = Delete on Destroy True or False
	// %tname = Name of Type items
	// %power = 0= Item has No special Power Needs|1=Item Requires Power|2=Item generates Power 
	//			   (Item which requires Power will have an %item.prange var for how far it can look for power)
	
	%descr=%item.description;
		
	if(%ptype==0)
		%pDesc="Terrain";
	else if(%ptype==1)
		%pDesc="Terrain & Buildings";
	else if(%ptype==2)
		%pDesc="Terrain, Buildings & Objects";
	else if(%ptype==3)
		%pDesc="Terrain & Buildings but MUST be Outside";
	else if(%ptype==4)
		%pDesc="Terrain";

			
	if (%ctype==1)
	{	%BxMxL=$TurretBoxMaxLength;
		%BxMnL=$TurretBoxMinLength;
		%BxMxW=$TurretBoxMaxWidth;
		%BxMnW=$TurretBoxMinWidth;
		%BxMxH=$TurretBoxMaxHeight;
		%BxMnH=$TurretBoxMinHeight;
		%MaxNum=$MaxNumTurretsInBox;
		%class="Turret";
		%tname="deployable Turrets";
	}
	else if (%ctype==2)
	{	%BxMxL=$FFBxMxLength;
		%BxMnL=$FFBxMnLength;
		%BxMxW=$FFBxMxWidth;
		%BxMnW=$FFBxMnWidth;
		%BxMxH=$FFBxMxHeight;
		%BxMnH=$FFBxMnHeight;
		%MaxNum=$MaxNumFieldsInBox;
		%class="StaticShape";
		%tname="Deployable Forcefields";
	}
	else if (%ctype==4)	// Nodes
	{	%BxMxL=10;
		%BxMnL=1;
		%BxMxW=10;
		%BxMnW=1;
		%BxMxH=10;
		%BxMnH=1;
		%MaxNum=2;
		%class="StaticShape";
	}
	else
	{	%BxMxL=2;
		%BxMnL=1;
		%BxMxW=2;
		%BxMnW=1;
		%BxMxH=2;
		%BxMnH=1;
		%MaxNum=1;
		%class="StaticShape";
	}
	
	%team=GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	if($TeamItemCount[ %team @ %item] < $TeamItemMax[%item])	// Check to see if Item Count has been Reached
	{	%thisnum=$TeamItemCount[%team @ %item]+1;
		if (GameBase::getLOSInfo(%player,%dist)) 
		{	%obj = getObjectType($los::object);
			if(CheckObjectType(%obj,%ptype))
			{	%set = newObject("set",SimSet);
				%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMxL,%BxMxW,%BxMxH,0);
				%num = GetNumObjects(%set,%ctype,%tnum);
				deleteObject(%set);
				if(%MaxNum > %num) 
				{	%set = newObject("set",SimSet);
					%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMnL,%BxMnW,%BxMnH,0);
					%num = GetNumObjects(%set,%ctype,%tnum);
					if(0 == %num)	// No Objects within the Minimum Box
					{	if(%dtype==1)	//	If Deployable on Any Surface
						{	// Try to stick it straight up or down, otherwise
							// just use the surface normal
							%prot = GameBase::getRotation(%player);
							//if($trace) echo("Player Rotation ",%prot);
							//%zRot = (3.141592654-getWord(%prot,2));
							//if($trace) echo("Player Rotation ",%zrot);
							%zRot = (getWord(%prot,2));

							if (Vector::dot($los::normal,"0 0 1") > 0.6) 
							{	%rot = "0 0 " @ %zRot;}
							else
							{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
								{	%rot = "3.14159 0 " @ %zRot;}
								else
								{	%rot = Vector::getRotation($los::normal);}
							}
						}
						else if(%dtype==2)	//	Matches Any Surface
						{	%rot = Vector::getRotation($los::normal);
							
						}
						else
						{	if (Vector::dot($los::normal,"0 0 1") <= 0.7)
							{	Client::sendMessage(%client,0,%desc@" Can only deploy on flat surfaces~werror_message.wav");
								return (false);
							}
							%rot = GameBase::getRotation(%player);
						}	
							
						if(checkDeployArea(%client,$los::position)) 
						{	%newitem = newObject(%shape,%class,%shape,%DonD);
							if($traceObj) Echo($Ver,"|Created New Object :",%newitem," ",%descr);
							GameBase::playSequence(%newitem,1,"deploy");
							GameBase::SetActive(%newItem,false);
							%newitem.faded=1;
							addToSet("MissionCleanup", %newitem);
							GameBase::setTeam(%newitem,%team);
							GameBase::setPosition(%newitem,$los::position);
							GameBase::setRotation(%newitem,%rot);
							Gamebase::setMapName(%newitem,%descr @" #" @ %thisnum @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,%descr @" deployed");
							playSound(SoundCreateItem,$los::position);
							$TeamItemCount[%team @ %item]++;
							
							%newitem.deployedBy	= %client;
							%newitem.powerReq	= %power;
							%newitem.pRange		= %pRange;

							if(%power==1)	// Item Requires Power
							{	if($TracePwr) echo(%newitem," requires Power!");
								Client::sendMessage(%client,1,"Attempting to connect to Main Power Grid~AAODSFX13.WAV");
								schedule("PowerItem("@%newitem@","@%pRange@","@%client@");",2,%newitem);
							}
							else if(%power==2)	// Item generates Power
							{	if($TracePwr) echo(%newitem,"	Power Generator!");
								GameBase::SetActive(%newItem,true);
								Client::sendMessage(%client,1,"Attempting to connect Generator to Main Grid~AAODSFX13.WAV");
								schedule("ConnectGenerator("@%newitem@","@%client@");",2,%newitem);
								if($GenSet[%team])
								{	addToSet($GenSet[%team],%newItem);
								}
								else
								{	$GenSet[%team]=newObject("set",SimSet);
									addToSet("MissionCleanup",$GenSet[%team]);
									addToSet($GenSet[%team],%newItem);
								}
							}
							else
								GameBase::SetActive(%newItem,true);

							echo(">INF: ",$User[%client]," deployed a "@ %descr);
							return (%newitem);
						}
					}
					else Client::sendMessage(%client,0,"Frequency Overload - Too close to other "@%tname);
				}
				else Client::sendMessage(%client,0,"Too Many Other "@%tname@" in the area");
			}
			else Client::sendMessage(%client,0,%descr@" can only be deployed "@%pDesc@"~wAAODSFX09.WAV");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
	return (false);
}

//--------------------------------------
RocketData AFBolt
{
   bulletShapeName = "tracer.dts";
   explosionTag    = boltexp2;

   collisionRadius = 0.0;

  mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ImpactDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 768.0;
   terminalVelocity = 768.0;
   acceleration     = 0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;

   soundId = SoundJetHeavy;
};


//************************************
// 	AODShieldNode Backpack Script
//************************************
$InvList[AODShieldNode]	= 1;
$RemoteInvList[AODShieldNode]	= 1;
$TeamItemMax[AODShieldNode]	= 32;

$ItemMax[larmor, AODShieldNode]	= 1;
$ItemMax[lfemale, AODShieldNode]	= 1;
$ItemMax[marmor, AODShieldNode]	= 1;
$ItemMax[mfemale, AODShieldNode]	= 1;
$ItemMax[harmor, AODShieldNode]	= 1;

ItemImageData AODShieldNodeImage 
{	shapeFile = "sensor_jammer";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODShieldNode 
{	description = "Remote Shield Node";
	shapeFile = "sensor_jammer";
	classname = "Backpack";
	heading = "lDeployables";
	imageType = AODShieldNodeImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData RemoteShieldNode 
{	description		= "Shield Node";
	shapeFile		= "sensor_jammer";
	classname		= "ShieldNode";
	debrisId		= flashDebrisSmall;
	sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 2.5;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	maxEnergy		= 50;
};

function AODShieldNode::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);	}
	else 
	{	Player::deployItem(%player,%item);}
}

function AODShieldNode::onDeploy(%player,%item,%pos)
{	if (AODShieldNode::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODShieldNode::deployShape(%player,%item)
{	if($trace) echo( $ver@"|Deploying Remote Shield Node");
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{	if (GameBase::getLOSInfo(%player,5)) 
		{	%obj = getObjectType($los::object);
			if($trace) echo( $ver@"|Object Type = ",%obj);
			if ((%obj == "SimTerrain" || %obj == "InteriorShape") || (%obj == "Turret" || %obj =="sensor") ||( %obj == "StaticShape"))
			{	%set = newObject("set",SimSet);
				%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,2,2,2,0);
				%num = GetNumObjects(%set,0,%tnum);
				if(%num==1) 
				{		%boostObj=Group::getObject(%set,0);
						if (%boostObj.shieldNode)
						{	Client::sendMessage(%client,0,"DANGER!!! Shield Node Feedback!!~wError_message.wav");
							%pos1=GameBase::getPosition(%BoostObj.shieldNode);
							%pos2=GameBase::getPosition(%client);
							%vec=vector::sub(%pos1,%pos2);
							Player::onDamage(%client,$EnergyDamageType,1.5,%pos,%vec,"","head","front_left",%node);
							return false;
						}
						else
						{	deleteObject(%set);
							%prot = GameBase::getRotation(%player);
							%zRot = getWord(%prot,2);
							if (Vector::dot($los::normal,"0 0 1") > 0.6) 
							{	%rot = "0 0 " @ %zRot;}
							else
							{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
								{	%rot = "3.14159 0 " @ %zRot;}
								else
								{	%rot = Vector::getRotation($los::normal);}
							}
							%node = newObject("RemoteShieldNode","StaticShape",RemoteShieldNode,true);
							if($traceObj) Echo($Ver,"|Created New Object :",%newitem," | Remote Shield Node");
							echo("Shield Node Created (Node #",%node,") ");
							%team=GameBase::getTeam(%player);
							GameBase::setTeam(%node,%team);
							GameBase::setPosition(%node,$los::position);
							GameBase::setRotation(%node,%rot);
							Gamebase::setMapName(%node,"ShieldNode#" @ $totalNumNodes++ @ " " @ Client::getName(%client));
							Gamebase::StartFadein(%node);
							addToSet("MissionCleanup", %node);
							Client::setOwnedObject(%client, %node); 
							Client::setOwnedObject(%client, %player);
							GameBase::setActive(%node,true);
							playSound(SoundCreateItem,$los::position);
							%boostObj.shieldNode=%node;
							%node.isGuarding=%boostObj;
							// Add Node to Node Set
							if(!$NodeSet[%team])
							{	if($trace) echo( $ver@"|Creating a Node Set for Team ",%team);
								$NodeSet[%team] = newObject("ShieldNodes",SimSet);
								addToSet("MissionCleanup", $NodeSet[%team]);
							}
								
							addToSet($NodeSet[%team],%node);
							%name=GameBase::GetDataName(%boostObj);
							//	Get the shield strength of the Item
							if (!$ShieldGenOn[%team])
								Client::sendMessage(%client,1,"Shield Generator is NOT functioning!!");
							Client::sendMessage(%client,0,"Remote Shield Node deployed - Shield activated on:"@%name);
							$TeamItemCount[GameBase::getTeam(%player) @ "AODShieldNode"]++;
							echo("MSG: ",$User[%client]," deployed a Remote Shield Node on ",%name);
							return true;						
						}
				}
				else 
				{	deleteObject(%set);
					if (%num>1)
					{	Client::sendMessage(%client,0,"Too Many Items in area - unable to obtain single interface");}
					else if (%num==0)
					{	Client::sendMessage(%client,0,"Nothing to interface to. Node Must be placed close to an object which will have its shield boosted.~Werror_message.wav");}
				}
				
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain/buildings or objects");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


function RemoteShieldNode::onEndSequence(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	echo("Node on End sequence");
	if(%this.position==1)	
		GameBase::playSequence(%this,0,"power");
}

function RemoteShieldNode::onDestroyed(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	if($trace) echo( $ver@"|Remote Shield Node::On destroyed");
	%team=GameBase::getTeam(%this);
	$TeamItemCount[%team @ "AODShieldNode"]--;
	$totalNumNodes--;
	for(%i=0;%i<=Group::objectCount($NodeSet[%team]);%i++)
	{	%node=Group::GetObject($NodeSet[%team],%i);
		if(%node==%this)
		{	removeFromSet($NodeSet[%team], %i);
		}
	}
	%boostObj				= %this.isGuarding;
	%this.isGuarding		="";
	%boostObj.shieldNode	="";
						
	if ($ShieldGen[%team])
	{	if($trace) echo( $ver@"|Shield Gen Exists applying Node Feedback Damage");
		%pos1=GameBase::getPosition(%this);
		%pos2=GameBase::getPosition($ShieldGen[%team]);
		%vec=vector::sub(%pos1,%pos2);
		%damageLevel = GameBase::getDamageLevel($ShieldGen[%team]);
		NewStaticShapeDamage($ShieldGen[%team],%this,%damageLevel,0.1);
	}
}

function RemoteShieldNode::onDisabled(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	if($trace) echo( $ver@"|Remote Shield Node on Disabled");
	GameBase::setRechargeRate(%this,0);
	Gamebase::setEnergy(%this,0);
	%this.Position=0;
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::playSequence(%this,1,"deploy");
	%this.shieldStrength = 0;
	
}

function RemoteShieldNode::onActivate(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	if($trace) echo( $ver@"|Remote Shield Node onActivate");
	if($trace) echo( $ver@"|Node ID = ",%this);
	%team=GameBase::getTeam(%this);
	%this.shieldStrength = $boostStr;
	if($ShieldGen[%team])
	{	if($trace) echo( $ver@"|Shield Generator Exists for This Team (",%team,")& is ON");
		if($ShieldGenOn[%team])
		{	if($trace) echo($Ver,"| Shield Generator is On!");
		GameBase::setActive(%this,true);
			%this.Position=1;
			GameBase::setSequenceDirection(%this,1,1);
			GameBase::playSequence(%this,1,"deploy");
			GameBase::setRechargeRate(%this,15);
			GameBase::playSequence(%this,1); 
		}
		else
			if($trace) echo($Ver,"| Shield Generator is Off!");

	}
	else
		if($trace) echo( $ver@"|Shield Generator Does Not Exist for This Team");
	
}

function RemoteShieldNode::onEnabled(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	if($trace) echo( $ver@"|Shield Node - Enabled");
	if($trace) echo( $ver@"|Node ID = ",%this);
	RemoteShieldNode::onActivate(%this);
}

function RemoteShieldNode::onDeActivate(%this)
{ if(GameBase::getDataName(%this) != "RemoteShieldNode") return;	if($trace) echo( $ver@"|Shield Node - DeActivated");
	RemoteShieldNode::onDisabled(%this);
}

ItemImageData CNodeImage
{
        shapeFile = "sensor_small";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData CNode
{
        description = "Remote Cloaking Node";
        shapeFile = "sensor_small";
        className = "Backpack";
        heading = "lDeployables";
        imageType = CNodeImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 1200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function CNode::onUse(%player,%item)
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

function CNode::onDeploy(%player,%item,%pos)
{
        if (CNode::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}


function CNode::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        %data = GameBase::getDataName($los::object);
                        if ((%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor") && %data != "BlastDoorShape" && %data != "BlastFloorShape" && %data != "doorfivebyfiveForceFieldShape" && %data != "doorthreebyfourForceFieldShape" && %data != "doorfourbyeightForceFieldShape" && %data != "TowerSwitch") {
                                    %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                if (Vector::dot($los::normal,"0 0 1") > 0.6) {
                                        %rot = "0 0 " @ %zRot;
                                } else {
                                        if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
                                                %rot = "3.14159 0 " @ %zRot;
                                        } else {
                                                %rot = Vector::getRotation($los::normal);
                                        }
                                }
                                %turret = newObject("","Sensor",CloakingNode,true);
                    addToSet("MissionCleanup", %turret);
                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                GameBase::setPosition(%turret,$los::position);
                                GameBase::setRotation(%turret,%rot);
                                Gamebase::setMapName(%turret,"Cloaking Node");
                                Client::sendMessage(%client,0,"Cloaking Node deployed");
                                playSound(SoundPickupBackpack,$los::position);
                                $TeamItemCount[GameBase::getTeam(%player) @ "Hider"]++;
                                echo("MSG: ",%client," ",Client::getName(%client)," deployed a Cloaking Node");
                                GameBase::startFadeOut($los::object);
                                schedule("GameBase::startFadeOut("@%turret@");", 6, $los::object);
                                schedule("Item::hide("@%turret@", true);", 6, $los::object);
                                %turret.cloaked = $los::object;
                                return true;
                        } else {
                                Client::sendMessage(%client,0,"Cannot cloak this object");
                        }
                } else {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        } else {                                                                                                                                                                Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
        }
        return false;
}

$InvList[CNode]        			   = 1;
$RemoteInvList[CNode]        		   = 0;
$TeamItemMax[CNode]        		   = 32;

$ItemMax[larmor, CNode]                = 1;
$ItemMax[lfemale, CNode]        	   = 1;
$ItemMax[marmor, CNode]                = 1;
$ItemMax[mfemale, CNode]        	   = 1;
$ItemMax[harmor, CNode]                = 1;

//----------------------------------------------------------------------------

ItemImageData PulseSensorPackImage
{
        shapeFile = "radar_small";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData PulseSensorPack
{
        description = "Pulse Sensor";
        shapeFile = "radar_small";
        className = "Backpack";
   heading = "lDeployables";
        imageType = PulseSensorPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 125;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
        if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
                Player::decItemCount(%player,%item);
                $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
        }
}

ItemImageData DeployableSensorJamPackImage
{
        shapeFile = "sensor_jammer";
         mountPoint = 2;
          mountOffset = { 0, 0.03, 0.1 };
          mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
        description = "Sensor Jammer";
          shapeFile = "sensor_jammer";
          className = "Backpack";
   heading = "lDeployables";
        imageType = DeployableSensorJamPackImage;
          shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
          price = 225;

        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
        if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
                Player::decItemCount(%player,%item);
                $TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
        }
}

ItemImageData MotionSensorPackImage
{
        shapeFile = "sensor_small";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData MotionSensorPack
{
        description = "Motion Sensor";
        shapeFile = "sensor_small";
        className = "Backpack";
   heading = "lDeployables";
        imageType = MotionSensorPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 125;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
        if (MotionSensorPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
                $TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
        }
}

function MotionSensorPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                                %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                if (Vector::dot($los::normal,"0 0 1") > 0.6) {
                                        %rot = "0 0 " @ %zRot;
                                }
                                else {
                                        if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
                                                %rot = "3.14159 0 " @ %zRot;
                                        }
                                        else {
                                                %rot = Vector::getRotation($los::normal);
                                        }
                                }
                                if(checkDeployArea(%client,$los::position)) {
                                        %mSensor = newObject("","Sensor",DeployableMotionSensor,true);
                         addToSet("MissionCleanup", %mSensor);
                                        GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
                                        GameBase::setRotation(%mSensor,%rot);
                                        GameBase::setPosition(%mSensor,$los::position);
                                        Gamebase::setMapName(%mSensor,"Motion Sensor");
                                        Client::sendMessage(%client,0,"Motion Sensor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        echo("MSG: ",%client," deployed a Motion Sensor");
                                        return true;
                                }
                        }
                        else {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

ItemImageData CameraPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.06 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData CameraPack
{
        description = "Camera";
        shapeFile = "camera";
        className = "Backpack";
   heading = "lDeployables";
        imageType = CameraPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 100;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function CameraPack::onDeploy(%player,%item,%pos)
{
        if (CameraPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function CameraPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "BlastFloorShape")  {
                                %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                if (Vector::dot($los::normal,"0 0 1") > 0.6) {
                                        %rot = "0 0 " @ %zRot;
                                }
                                else {
                                        if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
                                                %rot = "3.14159 0 " @ %zRot;

                                        }
                                        else {
                                                %rot = Vector::getRotation($los::normal);
                                        }
                                }
                                if(checkDeployArea(%client,$los::position)) {
                                        %camera = newObject("Camera","Turret",CameraTurret,true);
                         addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Camera deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
                                        echo("MSG: ",%client," deployed a Camera");
                                        return true;
                                }
                        }
                        else {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

ItemImageData DeployableInvPackImage
{
        shapeFile = "invent_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData DeployableInvPack
{
        description = "Inventory Station";
        shapeFile = "invent_remote";
        className = "Backpack";
   heading = "lDeployables";
        shadowDetailMask = 4;
        imageType = DeployableInvPackImage;
        mass = 1.0;
        elasticity = 0.2;
        price = 1500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
        if (DeployableInvPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function DeployableInvPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "BlastFloorShape")  {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                        if(checkDeployArea(%client,$los::position)) {
                                                %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
                                   addToSet("MissionCleanup", %inv);
                                                %rot = GameBase::getRotation(%player);
                                                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                                                GameBase::setPosition(%inv,$los::position);
                                                GameBase::setRotation(%inv,%rot);
                                                Gamebase::setMapName(%inv,%name);
                                                Client::sendMessage(%client,0,"Inventory Station deployed");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
                                                echo("MSG: ",%client," deployed an Inventory Station");
                                                return true;
                                        }
                                }
                                else {
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                }

                       }
                        else {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

ItemImageData DeployableAmmoPackImage
{
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData DeployableAmmoPack
{
        description = "Ammo Station";
        shapeFile = "ammounit_remote";
        className = "Backpack";
   heading = "lDeployables";
        shadowDetailMask = 4;
        imageType = DeployableAmmoPackImage;
        mass = 1.0;
        elasticity = 0.2;
        price = 1000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
        if (DeployableAmmoPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function DeployableAmmoPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape")  {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                        if(checkDeployArea(%client,$los::position)) {
                                                %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
                            addToSet("MissionCleanup", %inv);
                                                %rot = GameBase::getRotation(%player);
                                                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                                                GameBase::setPosition(%inv,$los::position);
                                                GameBase::setRotation(%inv,%rot);
                                                Gamebase::setMapName(%inv,%name);
                                                Client::sendMessage(%client,0,"Ammo Station deployed");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
                                                echo("MSG: ",%client," deployed an Ammo Station");
                                                return true;
                                        }
                                }
                                else
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}


$TeamItemMax[dummy] = 32;

$TeamItemMax[dummypack] = 32;

$ItemMax[harmor, dummypack] = 1;
$ItemMax[marmor, dummypack] = 1;
$ItemMax[mfemale, dummypack] = 1;
$ItemMax[larmor, dummypack] = 1;
$ItemMax[lfemale, dummypack] = 1;

$InvList[dummypack] = 1;
$RemoteInvList[dummypack] = 0;

ItemImageData DummyPackImage
{
        shapeFile = "armorpack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData DummyPack
{
        description = "Decoy Creator";
        shapeFile = "larmor";
        className = "Backpack";
        heading = "lDeployables";
        imageType = DummyPackImage;
        shadowDetailMask = 4;
        mass = 1.0;

       elasticity = 0.2;
        price = 900;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DummyPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DummyPack::onDeploy(%player,%item,%pos)
{
        if (DummyPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
       }
}

function DummyPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "dummy"] < $TeamItemMax["dummy"]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);

                                    %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"Dummy",%num);
                                deleteObject(%set);

                                        if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                if(checkDeployArea(%client,$los::position)) {
                                                        %rot = GameBase::getRotation(%player);
                                                        %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 6)

                                                           %fField = newObject("","StaticShape",Dummyl,true);
                                                        else
                                                                if((%rnd > 2) && (%rnd < 7))


                                                           %fField = newObject("","StaticShape",Dummym,true);
                                                        else


                                                           %fField = newObject("","StaticShape",Dummyh,true);

                                                        addToSet("MissionCleanup", %fField);
                                                        GameBase::setTeam(%fField,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%fField,$los::position);
                                                        GameBase::setRotation(%fField,%rot);
                                                        Client::sendMessage(%client,0,"Dummy Deployed");
                                                        echo("MSG: ",%client," deployed a Hologram");
                                                        GameBase::startFadeIn(%fField);
                                                        playSound(Hologram,$los::position);


                                                        $TeamItemCount[GameBase::getTeam(%player) @ "dummy"]++;
                                                        return true;
                                                }
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

//----------------------------------------------------------------------------

$TeamItemMax[HoloPack] = 32;

$InvList[HoloPack] = 1;
$RemoteInvList[HoloPack] = 0;

$ItemMax[marmor, HoloPack] = 1;
$ItemMax[mfemale, HoloPack] = 1;
$ItemMax[larmor, HoloPack] = 0;
$ItemMax[lfemale, HoloPack] = 0;
$ItemMax[harmor, HoloPack] = 0;

ItemImageData HoloPackImage
{
        shapeFile = "shieldpack";
        mountPoint = 2;
        firstPerson = false;
};

ItemData HoloPack
{
        description = "Hologram Creator";
        shapeFile = "larmor";
        className = "Backpack";
   heading = "lDeployables";
        imageType = HoloPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 1250;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function HoloPack::onDeploy(%player,%item,%pos)
{
        if (HoloPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function HoloPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[holopack])
        {
                if (GameBase::getLOSInfo(%player,7))
                {
                        %obj = getObjectType($los::object); if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %rPos = GameBase::getRotation(%client);
                                        %HologramName = Client::getName(%client) @ "   ";
                                        while($Hologram[%HologramName] != "")
                                        %HologramName = %HologramName @ " ";
                                        %parmor = Player::getArmor(%player);
                                        %rnd = floor(getRandom() * 10);
                                        if(%rnd > 6)
                                        %armor = "harmor";
                                        else if(%rnd > 2 && %rnd < 7)
                                        %armor = "marmor";
                                        else
                                        %armor = "larmor";
                                        if (%parmor == "larmor")
                                        %armor = %parmor;
                                        %some = Ai::spawn(%HologramName, %armor, $los::position, %rPos);
                                        $Hologram[%HologramName] = GameBase::getTeam(%player);
                                        %hID = AI::getId(%HologramName);
                                        %type = Player::getMountedItem(%client,0);
                                        Player::setItemCount(%hId, %type, 1);
                                        Player::mountItem(%hId, %type, 0);
                                        Client::sendMessage(%client,0,"Hologram Created");
                                        GameBase::startFadeIn(%hID);
                                        playSound(ForceFieldOpen,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"]++;
                                        return true;
                                        }
                                }
                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                else Client::sendMessage(%client,0,"Deploy position out of range");
                }
        else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
        return false;
}

$InvList[treepack] = 1;
$RemoteInvList[treepack] = 1;

$TeamItemMax[treepack] = 32;

$ItemMax[harmor, treepack] = 1;
$ItemMax[marmor, treepack] = 1;
$ItemMax[mfemale, treepack] = 1;
$ItemMax[larmor, treepack] = 0;
$ItemMax[lfemale, treepack] = 0;

ItemImageData TreePackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TreePack
{
        description = "Tree Planter";
        shapeFile = "ammopack";
        className = "Backpack";
   heading = "lDeployables";
        imageType = TreePackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.1;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function TreePack::onDeploy(%player,%item,%pos)
{
        if (TreePack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function TreePack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj != "BlastFloorShape")
                        {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %tree = newObject("Tree","StaticShape",Tree,true);
                                                 addToSet("MissionCleanup", %tree);
                                                GameBase::setTeam(%tree,GameBase::getTeam(%player));
                                                GameBase::setPosition(%tree,$los::position);
                                                GameBase::setRotation(%tree,%rot);
                                                Gamebase::setMapName(%tree,"Tree " @ Client::getName(%client));
                                                Client::sendMessage(%client,0,"Tree Planted");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
                                                echo("MSG: ",%client," planted a seed");
                                                //        Remote turrets - kill points to player that deploy them
                                                // Client::setOwnedObject(%client, %tree);
                                                // Client::setOwnedObject(%client, %player);
                                                return true;
                                        }
                        }
                        else
                                Client::sendMessage(%client,0,"Cannot deploy in buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description);

        return false;
}

ItemImageData DronePackImage
{
        shapeFile = "ammopack";
        weaponType = 2;
        mountPoint = 2;
        mountOffset = { 0, -0.1, 0 };

        minEnergy = 4;
         maxEnergy = 4.5;
        firstPerson = false;
};

ItemData DronePack
{
        description = "Drone";
        shapeFile = "ammopack";
        className = "Backpack";
    heading = "lDeployables";
        shadowDetailMask = 4;
        imageType = DronePackImage;
        mass = 1;
        price = 2000;
       hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DronePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
		else Player::deployItem(%player,%item);
}

function DronePack::onDeploy(%player,%item,%pos)
{
	if(DeployDrone(%player,%item,SurveyDrone,flier,SurveyDrone)) 
		if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

$TeamItemMax[DronePack] = 5;
$InvList[DronePack] = 1;
$RemoteInvList[DronePack] = 0;

$ItemMax[marmor, DronePack] = 1;
$ItemMax[mfemale, DronePack] = 1;
$ItemMax[larmor, DronePack] = 1;
$ItemMax[lfemale, DronePack] = 1;
$ItemMax[harmor, DronePack] = 1;

//************************************
//         AODDefender Backpack Script
//         (Defender Defense Turret)
//************************************

$InvList[AODDefender]                        = 1;
$RemoteInvList[AODDefender]                = 1;
$TeamItemMax[AODDefender]                = 5;

$ItemMax[larmor, AODDefender]        = 1;
$ItemMax[lfemale, AODDefender]        = 1;
$ItemMax[marmor, AODDefender]        = 1;
$ItemMax[mfemale, AODDefender]        = 1;
$ItemMax[harmor, AODDefender]        = 1;

ItemImageData AODDefenderImage
{        shapeFile        = "CAMERA";
        mountPoint        = 2;
        mass                = 2.0;
        firstPerson = false;
};

ItemData AODDefender
{        description                        = "Defender Designator";
        shapeFile                        = "CAMERA";
        classname                        = "Backpack";
        heading                         = "pTurrets";
        imageType                        = AODDefenderImage;
        shadowDetailMask        = 4;
        mass                                = 3.0;
        elasticity                        = 0.2;
        price                                = 325;
        hudIcon                                = "deployable";
        showWeaponBar                = true;
        hiliteOnActive                = true;
};

TurretData DefenderTurret
{        classname                        = "SensorNet";
        shapeFile                        = "CAMERA";

        projectileType                = designatorX;
        maxDamage                        = 0.75;
        maxEnergy                        = 100;
        minGunEnergy                = 0.1;
        maxGunEnergy                = 1;
        sequenceSound[0]        = {"deploy", SoundActivateMotionSensor};
        reloadDelay                        = 1;
        speed                                = 4.5;
        speedModifier                = 1.5;
        range                                = 200;
        visibleToSensor                = true;
        shadowDetailMask        = 4;
        dopplerVelocity                = 0;
        castLOS                                = true;
        supression                        = false;
        mapFilter                        = 2;
        mapIcon                                = "M_turret";
        debrisId                        = flashDebrisSmall;
        shieldShapeName                = "shield";

       fireSound                        = SoundFireDefender;
        activationSound                = SoundRemoteTurretOn;
        deactivateSound                = SoundRemoteTurretOff;
        explosionId                        = flashExpMedium;
        description                        = "Defender Turret";
        damageSkinData                = "objectDamageSkins";
        pinger                                = false;
        lightColor                        = { 0.75, 0.75, 0.85 };
};


function AODDefender::onUse(%player,%item)
{        %client = Player::getClient(%player);
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);}
        else
        {        Player::deployItem(%player,%item); }
}

function AODDefender::onDeploy(%player,%item,%pos)
{        if (AODDefender::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODDefender::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,DefenderTurret,1,4,1,1,true,false,0);
}

function DefenderTurret::onAdd(%this)
{        schedule("DefenderTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.025;
        if (GameBase::getMapName(%this) == "")
        {        GameBase::setMapName (%this, "Defender Turret");}
}

function DefenderTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function DefenderTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}

function DefenderTurret::onDestroyed(%this)
{        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODDefender"]--;
}

function DefenderTurret::onPower(%this,%power,%generator)
{}

function DefenderTurret::onEnabled(%this)
{        GameBase::setRechargeRate(%this,10);
        GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------

ItemImageData TurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TurretPack
{
        description = "Laser Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function TurretPack::onDeploy(%player,%item,%pos)
{
        if (TurretPack::deployShape(%player,%item)) {




                Player::decItemCount(%player,%item);
        }
}

function CountObjects(%set,%name,%num)
{
        %count = 0;
        for(%i=0;%i<%num;%i++) {
                %obj=Group::getObject(%set,%i);
                if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
                        %count++;
        }
        return %count;
}

function TurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);

                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);


                                       deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("remoteTurret","Turret",DeployableTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Laser Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Laser Turret");
                                                      Client::setOwnedObject(%client, %turret);
                                                      Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

$InvList[TTurretPack]                        = 1;
$RemoteInvList[TTurretPack]                = 1;
$TeamItemMax[TTurretPack]                = 5;

$ItemMax[larmor, TTurretPack]        = 0;
$ItemMax[lfemale, TTurretPack]        = 0;
$ItemMax[marmor, TTurretPack]        = 1;
$ItemMax[mfemale, TTurretPack]        = 1;
$ItemMax[harmor, TTurretPack]        = 1;

ItemImageData TractorTurretI 
{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TTurretPack 
{ 
	description = "Tractor Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "pTurrets"; 
	imageType = TractorTurretI; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 400; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
};

function TTurretPack::onUse(%player,%item) 
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

function TTurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (DeployTheShape(%player, %item, "DeployableTTurret", "", 2, false, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "Tractor")) 
	{
		Player::decItemCount(%player,%item); 
	} 
} 

ExplosionData turret1Exp
{
   shapeName = "breath.dts";
   soundId   = SoundFireFlierRocket;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.0,  1.0,  0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

RocketData IonEEBolt { bulletShapeName = "breath.dts"; explosionTag = turret1Exp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.07; damageType = $TractorDamageType; explosionRadius = 4; kickBackStrength = -300.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.2, 1.0, 0.2 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 130; trailWidth = 0.5; soundId = SoundJetHeavy; }; 

TurretData DeployableTTurret { className = "Turret"; shapeFile = "remoteturret"; projectileType = IonEEBolt; maxDamage = 0.5; maxEnergy = 75; minGunEnergy = 6; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.9; speed = 2.5; speedModifier = 1.5; range = 45; gunrange = 65; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Tractor Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableTTurret::onAdd(%this) { schedule("DeployableTTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.001; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Tractor Turret"); } } 

function DeployableTTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableTTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableTTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TTurretPack"]--; } function DeployableTTurret::onPower(%this,%power,%generator) {} function DeployableTTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


$InvList[LELFPack]                        = 1;
$RemoteInvList[LELFPack]                = 0;
$TeamItemMax[LELFPack]                = 3;

$ItemMax[larmor, LELFPack]        = 0;
$ItemMax[lfemale, LELFPack]        = 0;
$ItemMax[marmor, LELFPack]        = 1;
$ItemMax[mfemale, LELFPack]        = 1;
$ItemMax[harmor, LELFPack]        = 1;

ItemImageData LELFPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LELFPack
{
	description = "ELF Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "pTurrets";
	imageType = LELFPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 550;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LELFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}

function LELFPack::onDeploy(%player,%item,%pos)
{
	if (DeployTheShape(%player, %item, "LELFTurret", "DeployableElf ELFTurret", 3, true, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "ELF")) {
		Player::decItemCount(%player,%item);
	}
}

TurretData LELFTurret { maxDamage = 0.85; maxEnergy = 150; minGunEnergy = 50; maxGunEnergy = 5; range = 40; visibleToSensor = true; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = defaultDebrisMedium; className = "Turret"; shapeFile = "chainturret"; shieldShapeName = "shield"; speed = 5.0; speedModifier = 1.5; projectileType = turretCharge; reloadDelay = 0.3; explosionId = LargeShockwave; description = "ELF Turret"; fireSound = SoundGeneratorPower; activationSound = SoundChainTurretOn; deactivateSound = SoundChainTurretOff; damageSkinData = "objectDamageSkins"; shadowDetailMask = 8; isSustained = true; firingTimeMS = 750; energyRate = 30.0; }; 

function LELFTurret::onAdd(%this)
{

	schedule("LELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	
	%this.shieldStrength = 0.0315;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ELF Turret");
	}
}

function LELFTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LELFTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LELFTurret::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this, 0);
	GameBase::setActive(%this,false);
	StaticShape::objectiveDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LELFPack"]--;
}

function LELFTurret::onPower(%this,%power,%generator) {}
function LELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//****************************************************
// AAOD Mod Deployable Kit
//************************************
//         AODGrogPack Backpack Script
//        GROGTurret Script
//         (Deployable Chaingun Turret)
//         GrogShot

$InvList[AODGrogPack]                        = 1;
$RemoteInvList[AODGrogPack]                = 1;
$TeamItemMax[AODGrogPack]                = 3;

$ItemMax[larmor, AODGrogPack]        = 0;
$ItemMax[lfemale, AODGrogPack]        = 0;
$ItemMax[marmor, AODGrogPack]        = 1;
$ItemMax[mfemale, AODGrogPack]        = 1;
$ItemMax[harmor, AODGrogPack]        = 1;

BulletData GrogShot
{        bulletShapeName = "bullet.DTS";
        explosionTag = bulletExp0;
        expRandCycle        = 3;
        mass = 1;
        collisionRadius = 0.0;
        bulletHoleIndex = 0;
        ExplosionRadius = 0;
        damageClass = 0;
        damageValue = 0.12;
        damageType = $ChaingunDamageType;
        aimDeflection = 0.005;
        muzzleVelocity = 500.0;
        totalTime = 0.5;

        inheritedVelocityScale = 0.5;
        liveTime = 2.0;
        isVisible = False;
        tracerPercentage = 0.0;
        tracerLength = 0;
        detachFromShooter = false;
        rotationPeriod = 0;
        lightRange = 0.0;
        lightColor = {1.0, 0.25,0.25};
};

ItemImageData AODGrogPackImage
{        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData AODGrogPack
{        description                = "Chaingun Turret";
        shapeFile                = "remoteturret";
        classname                = "Backpack";
        heading                        = "pTurrets";
        imageType                = AODGrogPackImage;
        shadowDetailMask = 4;
        mass                        = 3.0;
        elasticity                = 0.2;
        price                        = 650;
        hudIcon                        = "deployable";
        showWeaponBar        = true;

       hiliteOnActive        = true;
};

TurretData GROGTurret
{         classname                = "Turret";
        shapeFile                = "remoteturret";
        projectileType        = GrogShot;
        maxDamage                = 1.15;
        maxEnergy                = 50;
        minGunEnergy        = 5;
        maxGunEnergy        = 5;
        sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.25;
        speed                        = 6.0;
        speedModifier        = 1.5;
        range                        = 40;
        visibleToSensor = true;
        shadowDetailMask= 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound                = SoundGrogFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = flashExpMedium;
        description                = "Chaingun Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};

function AODGrogPack::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);        }
        else
        {        Player::deployItem(%player,%item); }
}

function AODGrogPack::onDeploy(%player,%item,%pos)
{        if (AODGrogPack::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODGrogPack::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
        DeployStuff(%player,%item,GROGTurret,1,3,1,0,true,false,0);
}


function GROGTurret::onAdd(%this)
{        schedule("GROGTurret::deploy(" @ %this @ ");",1,%this);
}

function GROGTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function GROGTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}

function GROGTurret::onDestroyed(%this)
{        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODGrogPack"]--;
}

function GROGTurret::onPower(%this,%power,%generator)
{
}

function GROGTurret::onEnabled(%this)
{        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
        %this.shieldStrength = 0.0085;
}

//****************************************************
// AAOD Mod Deployable Kit
//************************************
//         AODVelcroPack Backpack Script
//        VELCROTurret Script

$InvList[AODVelcroPack]                        = 1;
$RemoteInvList[AODVelcroPack]                = 1;
$TeamItemMax[AODVelcroPack]                = 5;

$ItemMax[larmor, AODVelcroPack]        = 0;
$ItemMax[lfemale, AODVelcroPack]        = 0;
$ItemMax[marmor, AODVelcroPack]        = 1;
$ItemMax[mfemale, AODVelcroPack]        = 1;
$ItemMax[harmor, AODVelcroPack]        = 1;

ExplosionData velcroExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.75, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.75, 1.0 };
   colors[2]  = { 0.5, 1.0,  0.5 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

BulletData VelcroProjectile
{
   bulletShapeName  = "mortartrail.dts";
   explosionTag     = velcroExp;
   mass             = 0.05;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.25;
   damageType       = $EnergyDamageType;
   muzzleVelocity   = 60.0;
   totalTime        = 4.0;
   liveTime         = 4.0;
   isVisible        = True;
   rotationPeriod        = 0.15;
};


ItemImageData AODVelcroPackImage
{        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData AODVelcroPack
{        description = "Velcro Turret";
        shapeFile = "remoteturret";
        classname = "Backpack";
        heading = "pTurrets";
        imageType = AODVelcroPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 750;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

TurretData VELCROTurret
{
         classname                = "Turret";
        shapeFile                = "remoteturret";

        projectileType        = VelcroProjectile;
        maxDamage                = 0.70;
        maxEnergy                = 90;
        minGunEnergy        = 7.5;
        maxGunEnergy        = 15;
        sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.75;
        speed                        = 4.0;
        speedModifier        = 1.5;
        range                        = 75;
        visibleToSensor = true;
        shadowDetailMask = 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound                = SoundRemoteTurretFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = flashExpMedium;
        description                = "Velcro Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};


function AODVelcroPack::onUse(%player,%item)
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

function AODVelcroPack::onDeploy(%player,%item,%pos)
{        if (AODVelcroPack::deployShape(%player,%item))
                Player::decItemCount(%player,%item);
}

function AODVelcroPack::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
        DeployStuff(%player,%item,VELCROTurret,1,4,1,1,true,false,0);
}


function VELCROTurret::onAdd(%this)
{        schedule("VELCROTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.010;
        if (GameBase::getMapName(%this) == "")
                GameBase::setMapName (%this, "Velcro Turret");
}

function VELCROTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function VELCROTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}

function VELCROTurret::onDestroyed(%this)
{        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODVelcroPack"]--;
}

function VELCROTurret::onPower(%this,%power,%generator)
{
}

function VELCROTurret::onEnabled(%this)
{        GameBase::setRechargeRate(%this,10);
        GameBase::setActive(%this,true);
}

//----------------------------------------------------------------------------
// Flux Turret
//----------------------------------------------------------------------------

ItemImageData FluxPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData FluxPack
{
        description = "EMP Blast Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = FluxPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 1000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function FluxPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function FluxPack::onDeploy(%player,%item,%pos)
{
        if (FluxPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function FluxPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

                                %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);

                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("remoteTurret","Turret",Fluxturret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"EMP Blast Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"EMP Blast Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "FluxPack"]++;
                                                                echo("MSG: ",%client," deployed a Turret");
                                                      Client::setOwnedObject(%client, %turret);
                                                      Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData Fluxturret
{
        maxDamage = 0.75;
        maxEnergy = 60;
        minGunEnergy = 15;
        maxGunEnergy = 15;
        range = 100;
        gunRange = 150;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisLarge;
        className = "Turret";
        shapeFile = "remoteturret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = SeekingRPEMP;
        reloadDelay = 3;
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
   targetableFovRatio = 0.5;
        explosionId = LargeShockwave;
        description = "EMP Blast Turret";
};

function FluxTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function Fluxturret::onAdd(%this)
{
        schedule("Fluxturret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.01;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "EMP Blast Turret");
        }
}

function Fluxturret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function Fluxturret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function Fluxturret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "FluxPack"]--;
}

// Override base class just in case.
function Fluxturret::onPower(%this,%power,%generator) {}
function Fluxturret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}

$InvList[FluxPack] = 1;
$RemoteInvList[FluxPack] = 1;

$TeamItemMax[FluxPack] = 5;
$ItemMax[marmor, FluxPack] = 1;
$ItemMax[mfemale, FluxPack] = 1;
$ItemMax[larmor, FluxPack] = 0;
$ItemMax[lfemale, FluxPack] = 0;
$ItemMax[harmor, FluxPack] = 0;

//----------------------------------------------------------------------------
// Fusion Turret
//----------------------------------------------------------------------------

ItemImageData Turret4PackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1.5;
        firstPerson = false;
};

ItemData Turret4Pack
{
        description = "Fusion Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = Turret4PackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 3500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function Turret4Pack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }

       else {
                Player::deployItem(%player,%item);
        }

}

function Turret4Pack::onDeploy(%player,%item,%pos)
{
        if (Turret4Pack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function Turret4Pack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"Turret4",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);

                                       %num = CountObjects(%set,"FusionTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("","Turret",FusionTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Fusion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Fusion Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "Turret4Pack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
                                                                Client::setOwnedObject(%client, %turret);
                                                                Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData FusionTurret
{
        maxDamage = 1.0;
        maxEnergy = 100;
        minGunEnergy = 75;
        maxGunEnergy = 15;
        reloadDelay = 1;
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 150;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "hellfiregun";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = ChargedFusionBolt;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Fusion Turret";
};

function FusionTurret::onAdd(%this)
{
        schedule("FusionTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,25);
        %this.shieldStrength = 0.006;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Fusion Turret");
        }
}

function FusionTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function FusionTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function FusionTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "Turret4Pack"]--;
}

// Override base class just in case.
function FusionTurret::onPower(%this,%power,%generator) {}
function FusionTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,25);
        GameBase::setActive(%this,true);
}

$InvList[Turret4Pack] = 1;
$RemoteInvList[Turret4Pack] = 0;

$TeamItemMax[Turret4Pack] = 2;
$ItemMax[marmor, Turret4Pack] = 1;
$ItemMax[mfemale, Turret4Pack] = 1;
$ItemMax[larmor, Turret4Pack] = 0;
$ItemMax[lfemale, Turret4Pack] = 0;
$ItemMax[harmor, Turret4Pack] = 0;

//----------------------------------------------------------------------------
// Ion Turret
//----------------------------------------------------------------------------

ItemImageData DisruptorTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData DisruptorTurretPack
{
        description = "Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = DisruptorTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 2000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DisruptorTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DisruptorTurretPack::onDeploy(%player,%item,%pos)
{
        if (DisruptorTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function DisruptorTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DisruptorTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DisruptorTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {

                                               if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("","Turret",PlasmaTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Plasma Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DisruptorTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
                                                                Client::setOwnedObject(%client, %turret);
                                                                Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

$InvList[DisruptorTurretPack] = 1;
$RemoteInvList[DisruptorTurretPack] = 0;

$TeamItemMax[DisruptorTurretPack] = 2;

$ItemMax[marmor, DisruptorTurretPack] = 1;
$ItemMax[mfemale, DisruptorTurretPack] = 1;
$ItemMax[larmor, DisruptorTurretPack] = 0;
$ItemMax[lfemale, DisruptorTurretPack] = 0;
$ItemMax[harmor, DisruptorTurretPack] = 0;

//----------------------------------------------------------------------------
// Mitzi Blast Turret
//----------------------------------------------------------------------------

ItemImageData IonTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData IonTurretPack
{
        description = "Mitzi Blast Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = IonTurretPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 3000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function IonTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function IonTurretPack::onDeploy(%player,%item,%pos)
{
        if (IonTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function IonTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"IonTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"IonTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("","Turret",IonTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"MB Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Mitzi Blast Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "IonTurretPack"]++;

                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
                                                                Client::setOwnedObject(%client, %turret);
                                                                Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData IonTurret
{
        maxDamage = 1.0;
        maxEnergy = 300;
        minGunEnergy = 25;
        maxGunEnergy = 25;
        reloadDelay = 2;
        fireSound = capturedTower;
        activationSound = SoundMortarTurretOn;
        deactivateSound = SoundMortarTurretOff;
        whirSound = SoundMortarTurretTurn;
        range = 150;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "mortar_turret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = IonShock3;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Mitzi Blast Turret";
};

function IonTurret::onAdd(%this)
{
        schedule("IonTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0.006;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Mitzi Blast Turret");
        }
}

function IonTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function IonTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function IonTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "IonTurretPack"]--;
}

// Override base class just in case.
function IonTurret::onPower(%this,%power,%generator) {}
function IonTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
}

$InvList[IonTurretPack] = 1;
$RemoteInvList[IonTurretPack] = 0;

$TeamItemMax[IonTurretPack] = 5;

$ItemMax[marmor, IonTurretPack] = 1;
$ItemMax[mfemale, IonTurretPack] = 1;
$ItemMax[larmor, IonTurretPack] = 0;
$ItemMax[lfemale, IonTurretPack] = 0;
$ItemMax[harmor, IonTurretPack] = 0;

//----------------------------------------------------------------------------
// Pulse Turret
//----------------------------------------------------------------------------

ItemImageData PulseTurretPackImage
{

       shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData PulseTurretPack
{
        description = "AA Battery";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = PulseTurretPackImage;
        shadowDetailMask = 4;
        mass = 0.5;
        elasticity = 0.2;
        price = 950;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PulseTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function PulseTurretPack::onDeploy(%player,%item,%pos)
{
        if (PulseTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function PulseTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape"  || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"PulseTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"PulseTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("","Turret",PulseTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"AF Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"AF Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "PulseTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
                                                                Client::setOwnedObject(%client, %turret);
                                                                Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData PulseTurret
{
        maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 15;
        maxGunEnergy = 5;
        reloadDelay = 0.375;
        fireSound = SoundFireSeeking;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 200;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "hellfiregun";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = AFBolt;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "AF Turret";
};

function PulseTurret::onAdd(%this)
{
        schedule("PulseTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "AF Turret");
        }
}

function PulseTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function PulseTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function PulseTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "PulseTurretPack"]--;
}

// Override base class just in case.
function PulseTurret::onPower(%this,%power,%generator) {}
function PulseTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
}

$InvList[PulseTurretPack] = 1;
$RemoteInvList[PulseTurretPack] = 0;

$TeamItemMax[PulseTurretPack] = 5;

$ItemMax[marmor, PulseTurretPack] = 1;
$ItemMax[mfemale, PulseTurretPack] = 1;
$ItemMax[larmor, PulseTurretPack] = 0;
$ItemMax[lfemale, PulseTurretPack] = 0;
$ItemMax[harmor, PulseTurretPack] = 0;

//----------------------------------------------------------------------------
// Disc Turret
//----------------------------------------------------------------------------

ItemImageData DiscPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData DiscTurretPack
{
       description = "Disc Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = DiscPackImage;
        shadowDetailMask = 4;
       mass = 0.5;
        elasticity = 0.2;
        price = 700;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DiscTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DiscTurretPack::onDeploy(%player,%item,%pos)
{
        if (DiscTurretPack::deployShape(%player,%item)) {

               Player::decItemCount(%player,%item);
        }
}

function DiscTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DiscTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DiscTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("","Turret",DiscTurret,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Disc Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Disc Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DiscTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
                                                                Client::setOwnedObject(%client, %turret);
                                                                Client::setOwnedObject(%client, %player);
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }

                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData DiscTurret
{
        maxDamage = 1.0;
        maxEnergy = 100;
        minGunEnergy = 45;
        maxGunEnergy = 5;
        reloadDelay = 1;
        fireSound = SoundFireDisc;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 100;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "chainturret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = TurretDiscShell;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Disc Turret";
};

function DiscTurret::onAdd(%this)
{
        schedule("DiscTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,8);
        %this.shieldStrength = 0.006;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Disc Turret");
        }
}

function DiscTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DiscTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DiscTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DiscTurretPack"]--;
}

// Override base class just in case.
function DiscTurret::onPower(%this,%power,%generator) {}
function DiscTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,8);
        GameBase::setActive(%this,true);
}

$InvList[DiscTurretPack] = 1;
$RemoteInvList[DiscTurretPack] = 0;

$TeamItemMax[DiscTurretPack] = 5;

$ItemMax[marmor, DiscTurretPack] = 1;
$ItemMax[mfemale, DiscTurretPack] = 1;
$ItemMax[larmor, DiscTurretPack] = 0;
$ItemMax[lfemale, DiscTurretPack] = 0;
$ItemMax[harmor, DiscTurretPack] = 0;

ItemImageData RocketPackImage
{
        shapeFile = "missileturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData RocketPack
{
        description = "Rocket Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = RocketPackImage;
        shadowDetailMask = 4;
        mass = 3.0;
        elasticity = 0.2;
        price = 1200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};



function RocketPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function RocketPack::onDeploy(%player,%item,%pos)
{
        if (RocketPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function RocketPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num) {
                                    %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
                                        deleteObject(%set);
                                        if(0 == %num) {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                                        if(checkDeployArea(%client,$los::position)) {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("remoteTurret","Turret",DeployableRocket,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"RMT Rocket#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Rocket Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
                                                                return true;
                                                        }
                                                }
                                                else
                                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
                                }
                           else
                                        Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

$InvList[RocketPack] = 1;
$RemoteInvList[RocketPack] = 0;

$TeamItemMax[RocketPack] = 4;

$ItemMax[marmor, RocketPack] = 1;
$ItemMax[mfemale, RocketPack] = 1;
$ItemMax[larmor, RocketPack] = 0;
$ItemMax[lfemale, RocketPack] = 0;
$ItemMax[harmor, RocketPack] = 1;
$ItemMax[MagIonM, RocketPack] = 0;
$ItemMax[MAgIonF, RocketPack] = 0;
$ItemMax[BlastechM, RocketPack] = 0;
$ItemMax[BlastechF, RocketPack] = 0;
$ItemMax[MECH, RocketPack] = 0;

TurretData DeployableRocket
{
        maxDamage = 0.75;
        maxEnergy = 100;
        minGunEnergy = 60;
        maxGunEnergy = 60;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisLarge;
        className = "Turret";
        shapeFile = "missileturret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = TurretMissile;
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
   targetableFovRatio = 0.5;
        explosionId = LargeShockwave;
        description = "Rocket Turret";
};

function DeployableRocket::onAdd(%this)
{
        schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.03;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rocket Turret");
        }
}

function DeployableRocket::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DeployableRocket"]--;
}

// Override base class just in case.
function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,14);
        GameBase::setActive(%this,true);
}

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//---------------------------------
//         AODArtilleryPack Backpack Script
//---------------------------------
$InvList[AODArtilleryPack]                = 1;
$RemoteInvList[AODArtilleryPack]        = 0;
$TeamItemMax[AODArtilleryPack]                = 3;

$ItemMax[larmor, AODArtilleryPack]                = 0;
$ItemMax[lfemale, AODArtilleryPack]        = 0;
$ItemMax[marmor, AODArtilleryPack]                = 1;
$ItemMax[mfemale, AODArtilleryPack]        = 1;
$ItemMax[harmor, AODArtilleryPack]                = 1;

ItemImageData AODArtilleryPackImage
{        shapeFile                = "magcargo";
        mountPoint                = 2;
        mountOffset                = { 0, -0.65, -0.4 };
        mountRotation        = { 0, 0, 0 };
        mass                                = 3.0;
        firstPerson                = false;
};

ItemData AODArtilleryPack
{        description                = "SHB Turret";
        shapeFile                = "Mortar_Turret";
        classname                = "Backpack";
        heading                        = "pTurrets";
        imageType                = AODArtilleryPackImage;
        shadowDetailMask = 4;
        mass                        = 3.0;
        elasticity                = 0.2;
        price                        = 9500;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive = true;
};


TurretData ArtilleryTurret
{        classname                = "Turret";
        shapeFile                = "Mortar_Turret";
        projectileType        = SuperBlaster;
        maxDamage                = 1.5;
        maxEnergy                = 100;
        minGunEnergy        = 15;
        maxGunEnergy        = 10;
        sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.25;
        speed                        = 6.0;
        speedModifier        = 1.5;
        range                        = 150;
        visibleToSensor = true;
        shadowDetailMask= 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = FlierDebris;
        shieldShapeName = "shield";
        fireSound                = SoundPlasmaTurretFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = LargeShockwave;
        description                = "Super Hyper Blaster Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};


function AODArtilleryPack::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);}
        else
        {        Player::deployItem(%player,%item);}
}

function AODArtilleryPack::onDeploy(%player,%item,%pos)
{        if (AODArtilleryPack::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODArtilleryPack::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete,PowerReq,PRange)
        DeployStuff(%player,%item,ArtilleryTurret,1,5,1,0,true,true,250);
}

function ArtilleryTurret::onDestroyed(%this)
{        ArtilleryTurret::onDisabled(%this);
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODArtilleryPack"]--;
}

function ArtilleryTurret::onEnabled(%this)
{        if(GameBase::isPowered(%this))
        {        GameBase::setRechargeRate(%this,24);
                %this.shieldStrength = 0.005;
                GameBase::setActive(%this,true);
        }
}

function ArtilleryTurret::onDisabled(%this)
{        GameBase::setRechargeRate(%this,0);
        %this.shieldStrength = 0.0;
        GameBase::setActive(%this,false);
}

function ArtilleryTurret::onPower(%this,%power,%gen)
{        if(%power)
                ArtilleryTurret::onEnabled(%this);
        else
                ArtilleryTurret::onDisabled(%this);
}

//----------------------------------------------------------------------------
// PBW Turret
//----------------------------------------------------------------------------

ItemImageData ElectroTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData ElectroTurretPack
{
	description = "PBW Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "pTurrets";
	imageType = ElectroTurretPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 15000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectroTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {

	Player::deployItem(%player,%item);
	}
}

function ElectroTurretPack::onDeploy(%player,%item,%pos)
{
	if (ElectroTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ElectroTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"AntiTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"ElectroTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("","Turret",AntiTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"PBW Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"PBW Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ElectroTurretPack"]++;
								echo("MSG: ",%client," deployed a PBW Turret");

							//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}

						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

TurretData AntiTurret
{
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 99.9;
	maxGunEnergy = 100;
	reloadDelay = 5;
	fireSound = SoundPBWBreakSoundBarrier;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = ParticleBeam;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PBW Turret";
};

function AntiTurret::onAdd(%this)
{
	schedule("AntiTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.008;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "PBW Turret");
	}
}

function AntiTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AntiTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AntiTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ElectroTurretPack"]--;
}

// Override base class just in case.
function AntiTurret::onPower(%this,%power,%generator) {}
function AntiTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}

$InvList[ElectroTurretPack] = 1;
$RemoteInvList[ElectroTurretPack] = 0;

$TeamItemMax[ElectroTurretPack] = 4;

$ItemMax[marmor, ElectroTurretPack] = 1;
$ItemMax[mfemale, ElectroTurretPack] = 1;
$ItemMax[larmor, ElectroTurretPack] = 0;
$ItemMax[lfemale, ElectroTurretPack] = 0;
$ItemMax[harmor, ElectroTurretPack] = 0;

//------------------------------------
// *******  Teleport Station  ********
// -----------------------------------
$InvList[AODTeleporter]                = 1;
$RemoteInvList[AODTeleporter]        = 0;

$ItemMax[larmor, AODTeleporter]        = 0;
$ItemMax[marmor, AODTeleporter]        = 1;
$ItemMax[harmor, AODTeleporter]        = 1;
$ItemMax[lfemale, AODTeleporter]        = 0;
$ItemMax[mfemale, AODTeleporter]        = 1;
$TeamItemMax[AODTeleporter]=2;


ExplosionData TeleportHop
{        shapeName        = "Fusionbolt.dts";
        soundId                = SoundHFootLSoft;
        faceCamera        = true;
        randomSpin        = true;
        hasLight        = true;
        lightRange        = 10.0;
        timeScale        = 1.0;
        colors[0]        = { 1.0, 1.0, 0.0 };
        colors[1]        = { 1.0, 1.0, 0.75 };
        colors[2]        = { 1.0, 1.0, 0.75 };
        radFactors        = { 0.375, 1.0, 0.9 };
};

GrenadeData TeleportBeam
{        explosionTag                = TeleportHop;
        collideWithOwner        = True;
        ownerGraceMS                = 50;
        collisionRadius                = 10.0;
        mass                                = 0.1;
        elasticity                        = 5.0;
        damageClass                        = 1;
        damageValue                        = 0.0;
        damageType                        = $InfernoDamageType;
        explosionRadius                = 1.0;
        kickBackStrength        = 1.0;
        maxLevelFlightDist        = 2;
        totalTime                        = 0.25;
        liveTime                        = 0.25;
        projSpecialTime                = 0.1;
        lightRange                        = 15.0;
        lightColor                        = { 0.1, 1.0, 0.1 };
        inheritedVelocityScale = 0.5;
        smokeName                        = "FusionEx.dts";
        // soundId                                = ;
};

ItemImageData AODTeleporterImage
{        shapeFile        = "MagCargo";
        mountPoint        = 2;
        mountOffset                                = { 0, -0.65, -0.4 };
        mountRotation                        = { 0, 0, 0 };
        mass                = 1.0;
        firstPerson = false;
};


ItemData AODTeleporter
{        description                = "Mobile Teleporter Pad";
        shapeFile                = "enerpad";
        classname                = "Backpack";
        heading                        = "lDeployables";
        imageType                = AODTeleporterImage;
        shadowDetailMask = 4;
        elasticity                = 0.2;
        price                        = 4500;
        hudIcon                        = "Deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};


StaticShapeData Teleporter
{        description                = "Mobile Teleport Pad";
        shapeFile                = "enerpad";
        classname                = "AAODDep";
        debrisId                = flashDebrislarge;
        maxDamage                = 2;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId                = LargeShockwave;
        visibleToSensor = true;
        mapFilter                = 4;

};

StaticShapeData TeleporterNode
{        description                = "Mobile Teleport Pad";
        shapeFile                = "enerpad";
        classname                = "AAODDep";
        debrisId                = flashDebrislarge;
        maxDamage                = 2;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId                = LargeShockwave;
        visibleToSensor = true;
        mapFilter                = 4;
};

function AODTeleporter::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);
	}
    else
        {        %team=GameBase::getTeam(%player);
                Player::deployItem(%player,%item);
        }
}

$deploypadtime = 300;

function AODTeleporter::onDeploy(%player,%item,%pos)
{        %team=Gamebase::getTeam(%player);
        if($trace) echo($ver,"|",$User[%player]," Deployed a Teleporter ");

        if(!$Teleporter[%team])
        {        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
                %result=DeployStuff(%player,%item,Teleporter,1,5,0,0,true,1,384);
                if(%result)
                {        //        Player Gets 5 Min to deploy Second Half....
                        //        If Not Deployed By then it Self Destructs
                        GameBase::setActive(%result,false);
                        echo("teleport Main Pad Deployed");
                        WarnPlayer(%player);
                        %result.timer=$Meltdown::TeleCountdownTime;

                        BeginCountdown(%result);
                        $Teleporter[%team]=%result;
                }
        }
        else if ($Teleporter[%team])
        {        %result=DeployStuff(%player,%item,TeleporterNode,1,5,0,0,true,false,0);
                if(%result)
                {        //        Player has deployed Second Half....
                        $TeleporterNode[%team]=%result;
                        addtoset(GetGroup($Teleporter[%team]),%result);        // Stick in the same generator set as the main pad...
                        Player::decItemCount(%player,%item);


                       Teleporter::onEnabled($Teleporter[%team]);
                        BeginCountdown($Teleporter[%team]);
                }

        }
}

function WarnPlayer(%player)
{        if($trace) echo("Warning ",%player," of Teleport Danger");
        %client=player::getclient(%player);
        %message="<jc><f1><f4>WARNING...\nYou have "@$Meltdown::TeleCountdownTime@" seconds to Deploy Teleport Receiver\nUn-connected Teleport PAD will explode!!!";
        Client::SendMessage(%client,1,"~wAAODSFX51.WAV");
        schedule("CenterPrint("@%client@",\""@escapeString(%message)@"\",5);",2,%player);
        schedule("Client::SendMessage("@%client@",1,\"~wAAODSFX51.WAV\");",3,%player);
}

function BeginCountdown(%this)
{        if($trace) echo("Counting Down - Time is ",%this.timer);
        %team=GameBase::getTeam(%this);
        if(%this.isBusy)
        {        if($Teleporter[%team] && $TeleporterNode[%team])
                {        %this.isBusy=false;
                        return;
                }
                if(%this.timer<=3)
                {        detonateTeleporter(%this);
                        return;
                }
                if(%this.timer>=120)
                {        %Dec=60;
                        schedule("BeginCountdown("@%this@");",60,%this);
                        %wav="~wAAODSFX51.wav";
                }
                else if (%this.timer>=30)
                {        %Dec=20;
                        schedule("BeginCountdown("@%this@");",20,%this);
                        %wav="~wAAODSFX51.wav";
                }
                else
                {        %Dec=5;
                        schedule("BeginCountdown("@%this@");",5,%this);
                        %wav="~wAAODSFX53.wav";
                }
                %client=%this.Deployedby;
        }
        else
        {        %this.isBusy=true;
                %dec=5;
                schedule("BeginCountdown("@%this@");",5,%this);
        }
        Client::SendMessage(%client,1,"Teleport Pad Overload in "@%this.timer@" seconds!"@%wav);
        %this.timer-=%dec;
}

function Teleporter::onAdd(%this)
{}
function TeleporterNode::onAdd(%this)
{}

function Teleporter::onEnabled(%this)
{        if($trace) echo( $ver@"|Teleporter::OnEnabled");
        if(GameBase::IsPowered(%this))
        {        %team=GameBase::getTeam(%this);
                GameBase::setActive(%this,true);
                GameBase::playSequence(%this,0,"on");
                if($TeleporterNode[%team])
                {        GameBase::setActive($TeleporterNode[%team],true);
                        GameBase::playSequence($TeleporterNode[%team],0,"on");
                }
        }
}

function TeleporterNode::onEnabled(%this)
{        if($trace) echo( $ver@"|TeleporterNode::OnEnabled");
        %team=GameBase::getTeam(%this);
        Teleporter::onEnabled($Teleporter[%team]);
}
 
function Teleporter::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{        %team=GameBase::getTeam(%this);
        StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
        StaticShape::onDamage($TeleporterNode[%team],%type,%value,%pos,%vec,%mom,%object);
}

function TeleporterNode::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{        %team=GameBase::getTeam(%this);
        StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
        StaticShape::onDamage($Teleporter[%team],%type,%value,%pos,%vec,%mom,%object);
}

function Teleporter::onDestroyed(%this)
{        if($trace) echo( $ver@"|Teleporter::onDestroyed");
        %team=gameBase::getTeam(%this);
        %pset=GetGroup(%this);
        RemoveFromSet(%pset,%this);
        RemoveFromSet(%pset,$TeleporterNode[%team]);
        StaticShape::objectiveDestroyed(%this);
        calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
        $TeamItemCount[%team@AODTeleporter]=0;
        $Teleporter[%team]=false;
        $TeleporterNode[%team]=false;
}

function TeleporterNode::onDestroyed(%this)
{        if($trace) echo( $ver@"|TeleporterNode::onDestroyed");
        calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
}


function Teleporter::onDisabled(%this)
{        if($trace) echo( $ver@"|Teleporter::onDisabled");
        %team=GameBase::getTeam(%this);
        GameBase::setActive(%this,false);
        GameBase::stopSequence(%this,0);
        GameBase::setActive($TeleporterNode[%team],false);
        GameBase::stopSequence($TeleporterNode[%team],0);
}

function TeleporterNode::onDisabled(%this)
{
          if($trace) echo( $ver@"|TeleporterNode::onDisabled");
        %team=GameBase::getTeam(%this);
        Teleporter::onDisabled($Teleporter[%team]);
}

function Teleporter::onCollision(%this,%object)
{        %Team=GameBase::getTeam(%this);
        if(%this.isBusy)
        {        if(%this.teleported==%object)


                       return;
                else
                        Client::SendMessage(%object,0,"Teleport Pad is busy~wAAODSFX15.WAV");
                        return;
        }
        else
                %this.isBusy=true;
        if(GameBase::isActive(%this))
        {        if(!$TeleporterNode[%team])
                        return;
                %ObjTeam=Gamebase::getTeam(%object);
                if(%Team==%Objteam || %object.talent[$Stealth]==2)
                {        %node=$TeleporterNode[%team];
                        if (teleport(%node,%object))
                        {        %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.08");
                                GameBase::setPosition(%object,%pos1);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.25");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",0.5,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.5");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",1,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.75");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",1.5,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -1.0");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",2,%object);

                                schedule("ResetTeleporter("@%node@");",8);
                                playsound(SoundTeleport,%pos1);
                                GameBase::startFadeOut(%object);
                                TeleportFx(%this,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -1.0");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",2.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.75");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",3.0,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.5");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",3.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.25");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",4.0,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.08");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",4.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 0.5");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",5.0,%object);
                                Schedule("TeleportFx("@%node@","@%object@");",2.75,%object);
                                schedule("GameBase::startFadeIn("@%object@");",3,%object);
                                schedule("playsound(SoundTeleport,\""@%pos2@"\");",2.75,%object);
                        }
                }
                else
                        Eject(%this,%object);
        }

}

function TeleporterNode::onCollision(%this,%object)
{        %Team=GameBase::getTeam(%this);
        if($Teleporter[%team].isBusy)
        {        if($Teleporter[%team].teleported==%object)
                        return;
                else
                        Client::SendMessage(%object,0,"Teleport Pad is busy~wAAODSFX15.WAV");
                        return;
        }
        $Teleporter[%team].isBusy=true;
        if(GameBase::isActive(%this))
        {        if(!$Teleporter[%team])
                        return;
                %ObjTeam=Gamebase::getTeam(%object);
                if(%Team==%Objteam || %object.talent[$Stealth]==2)
                {        %node=$Teleporter[%team];
                        if(teleport(%node,%object))
                        {        %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.15");
                                GameBase::setPosition(%object,%pos1);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.25");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",0.5,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.5");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",1,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.75");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",1.5,%object);
                                %pos1=vector::add(GameBase::getPosition(%this),"0 0 -1.0");
                                schedule("GameBase::setPosition("@%object@",\""@%pos1@"\");",2,%object);

                                schedule("ResetTeleporter("@%node@");",8);
                                playsound(SoundTeleport,%pos1);
                                GameBase::startFadeOut(%object);
                                TeleportFx(%this,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -1.0");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",2.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.75");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",3.0,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.5");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",3.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.25");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",4.0,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 -0.15");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",4.5,%object);
                                %pos2=vector::add(GameBase::getPosition(%node),"0 0 0.1");
                                schedule("GameBase::setPosition("@%object@",\""@%pos2@"\");",5.0,%object);
                                Schedule("TeleportFx("@%node@","@%object@");",2.75,%object);
                                schedule("GameBase::startFadeIn("@%object@");",3,%object);
                                schedule("playsound(SoundTeleport,\""@%pos2@"\");",2.75,%object);
                        }
                }
                else
                        Eject(%this,%object);

        }

}

function TeleportFx(%this,%object)
{        %rot="1.570796 0.000000 0.000000";
        %pos=vector::add(GameBase::getPosition(%this),"0 0 1");




       %trans=        "-1.570796 0.000000 0.000000 0.000000 0.000000 2.500000 "@%rot@" "@%pos;
        %transx=GameBase::getMuzzleTransform(%object);
        %vel=Item::getVelocity(%this);
        Projectile::spawnProjectile("TeleportBeam",%trans,%object,%vel);
        schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.25);
        schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.5);
        schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.75);

}

function DetonateTeleporter(%this)
{        if($trace) echo( $ver@"|Detonate Teleporter");
        %team=GameBase::GetTeam(%this);
        TeamMessages(%team,0,"Teleporter Pad CRITICAL!~wAAODSFX53.wav");
        %pos=GameBase::getPosition(%this);
        playsound(ForceFieldFeedback,%pos);
        schedule("GameBase::setDamageLevel("@%this@",10);",3,%this);

        %player = Client::getOwnedObject(%this.deployedby);
        if (Player::getMountedItem(%player,$BackpackSlot) == AODTeleporter)
    {        %item=Player::dropItem(%player,AODTeleporter);
                $AODTeleporter[%team].isBusy=true;
        }
        schedule("DetonateTelePack("@%team@");",1);
}

function DetonateTelepack(%team)
{        %Pos2=GameBase::getPosition($TeleportPack[%team]);
        echo("Detonating teleportPack: pack  is ",$TeleportPack[%team]," and is located at ",%Pos2);
        if($TeleportPack[%team])
        {        deleteObject($TeleportPack[%team]);
                %newitem = newObject("TeleportNode","StaticShape",TeleporterNode,true);
                if($traceObj) Echo($Ver,"|Created New Object :",%newitem," | Teleport Node ");
                addToSet("MissionCleanup", %newitem);
                GameBase::setTeam(%newitem,%team);
                GameBase::setPosition(%newitem,%pos2);
                Gamebase::setMapName(%newitem,%descr @" #" @ %thisnum @ " " @ Client::getName(%client));
                %newitem.deployedBy=%client;
                playSound(SoundCreateItem,$los::position);
                $TeamItemCount[%team @ %pname]++;
                playsound(ForceFieldFeedback,%pos);
                schedule("GameBase::setDamageLevel("@%newitem@",10);",3,%newitem);
        }
}
function Teleport(%this,%object)
{        if($trace) echo("Telport pad ",%this," teleporting ",%object);
        %team=gameBase::getTeam(%this);
        if(!$Teleporter[%team].Teleported)
        {        $Teleporter[%team].Teleported=%object;
                return(true);
        }
        return(false);
}

function ResetTeleporter(%this)
{        if($trace) echo("Telport pad ",%this," Resetting ",%object);
        %team=gameBase::getTeam(%this);
        $Teleporter[%team].Teleported=false;
        $Teleporter[%team].isBusy=false;
}

function Teleporter::onPower(%this, %state, %generator)
{        if(%state)
                Teleporter::onEnabled(%this);
        else
                Teleporter::onDisabled(%this);
}

//--------------------------------------------------------------------------------------------------------
// Teleport Pads - Shane Hyde
//--------------------------------------------------------------------------------------------------------

$TeamItemMax[TeleportPack] = 2;
$TeamItemMax[DeployableTeleport] = 2;

$InvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 1;

$ItemMax[marmor, TeleportPack] = 1;
$ItemMax[mfemale, TeleportPack] = 1;
$ItemMax[larmor, TeleportPack] = 0;
$ItemMax[lfemale, TeleportPack] = 0;
$ItemMax[harmor, TeleportPack] = 1;


ItemImageData TeleportPackImage
{
        shapeFile = "mineammo";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData TeleportPack
{
        description = "Backup TelePads";
        shapeFile = "mineammo";
        className = "Backpack";
    heading = "lDeployables";
        imageType = TeleportPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 3200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function TeleportPack::onDeploy(%player,%item,%pos)
{
        if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
                Player::decItemCount(%player,%item);
                $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
        }
}

function CreateteleportSimSet()
{
    %teleset = nameToID("MissionCleanup/Teleports");
        if(%teleset == -1)
        {
                newObject("Teleports",SimSet);
                addToSet("MissionCleanup","Teleports");
        }
}

function TeleportPack::deployShape(%player,%name,%shape,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        // GetLOSInfo sets the following globals:
                        //         los::position
                        //         los::normal
                        //         los::object
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                        if(checkDeployArea(%client,$los::position)) {
                                                %sensor = newObject("Teleport Pad","StaticShape",%shape,true);
                                                CreateteleportSimSet();
				                        addToSet("MissionCleanup/Teleports", %sensor);
                        			      addToSet("MissionCleanup", %sensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                %pos = Vector::add($los::position,"0 0 -0.4");
                                                GameBase::setPosition(%sensor,%pos);
                                                Gamebase::setMapName(%sensor,%name);
                                                Client::sendMessage(%client,0,%item.description @ " deployed");
                                                %sensor.disabled = false;
                                                playSound(SoundPickupBackpack,$los::position);

                                                %beam = newObject("","StaticShape",ElectricalBeamBig,true);
								addToSet("MissionCleanup", %beam);
                                                GameBase::setTeam(%beam,GameBase::getTeam(%player));
                                                GameBase::setPosition(%beam,%pos);
								GameBase::startFadeIn(%beam);
                                                %sensor.beam1 = %beam;

                                                %topsensor = newObject("","Sensor",DeployablePulseSensor,true);
                        			      addToSet("MissionCleanup", %topsensor);
				                        addToSet("MissionCleanup/Teleports", %topsensor);
                                                GameBase::setTeam(%sensor,GameBase::getTeam(%player));
                                                %pos = Vector::add($los::position,"0 0 4.4");
                                                GameBase::setPosition(%topsensor,%pos);
                                                Gamebase::setMapName(%topsensor,%name);
                                                %sensor.topPad = %topsensor;
                                                return true;
                                        }
                                }
                                else
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
        return false;
}

StaticShapeData DeployableTeleport 
{ 
	className = "DeployableTeleport"; 
	damageSkinData = "objectDamageSkins"; 
	shapeFile = "mineammo"; 
	maxDamage = 3; 
	maxEnergy = 200; 
	mapFilter = 2; 
	visibleToSensor = true; 
	explosionId = mortarExp; 
	debrisId = flashDebrisLarge; 
	lightRadius = 12.0; 
	lightType = 2; 
	lightColor = {1.0,0.2,0.2}; 
};

StaticShapeData TopPad 
{ 
	className = "DeployableTeleport"; 
	damageSkinData = "objectDamageSkins"; 
	shapeFile = "mineammo"; 
	maxDamage = 19.9; 
	maxEnergy = 200; 
	mapFilter = 2; 
	visibleToSensor = true; 
	explosionId = largeShockwave; 
	debrisId = flashDebrisLarge; 
	lightRadius = 12.0; 
	lightType = 2; 
	lightColor = {1.0,0.2,0.2}; 
   description = "Teleport Pad";
};

function RemoveBeam(%b) 
{ 
	deleteObject(%b); 
} 

function DeployableTeleport::onDestroyed(%this) 
{ 
	schedule("RemoveBeam("@%this.beam1@");",0.5); 
	schedule("RemoveBeam("@%this.topPad@");",0.5);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--; 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++) 
	{ 
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this) 
		{ 
			GameBase::applyDamage(%o,$DebrisDamageType,25,GameBase::getPosition(%o),"0 0 0","0 0 0",%this); 
			return; 
		} 
	} 
}

function DeployableTeleport::onCollision(%this, %obj) 
{ 
	if($Collided == true)
		return;

	if(getObjectType(%obj) != "Player") 
		return; 

	if(Player::isDead(%obj)) 
		return; 

	%c = Player::getClient(%obj); 
	%playerTeam = GameBase::getTeam(%obj); 
	%teleTeam = GameBase::getTeam(%this); 

	if(%teleTeam != %playerTeam) 
	{ 
		Client::SendMessage(%c,1,"Warning! Wrong team!~werror_message.wav"); 
		return; 
	} 

	if(%this.disabled == true) 
	{ 
		Client::SendMessage(%c,3,"Teleporter is recharging."); 
		return; 
	} 

	%teleset = nameToID("MissionCleanup/Teleports"); 

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++) 
	{ 
            if(GameBase::getTeam(%o) == %playerteam && %o != %this) 
		{
			%camera = Client::getObserverCamera(%c);
			%t1pos = Vector::add(GameBase::getPosition(%this),"0 0 1");
			$Collided = true;

			GameBase::setPosition(%obj,%t1pos);
			Client::setControlObject(%c, %camera);
			Observer::setOrbitObject(%c, %this, 3, 3, 3);
			GameBase::startFadeOut(%obj);

			schedule("doTeleport("@%obj@","@%this@","@%o@");",2.5,%obj);
		}
	}
}

function DeployableTeleport::Reenable(%this) 
{
	GameBase::startFadeIn(%this.beam1);
	%this.disabled = false; 
	GameBase::playSound(%this,ForceFieldClose,0);
} 

function doTeleport(%player,%tele1,%tele2)
{
	%client = Player::getClient(%player);
	%tele1.Disabled = true; 
	%tele2.Disabled = true; 
	
	%t2pos = Vector::add(GameBase::getPosition(%tele2),"0 0 1");
	GameBase::startFadeOut(%tele1.beam1);
	GameBase::startFadeOut(%tele2.beam1);
	GameBase::playSound(%tele1,enterdimension,0); 
	GameBase::playSound(%tele2,enterdimension,0); 
	GameBase::SetPosition(%player,%t2pos);
	GameBase::startFadeIn(%player);
	Observer::setOrbitObject(%client, %tele2, 3, 3, 3);

	schedule("DeployableTeleport::Reenable("@%tele1@");",5); 
	schedule("DeployableTeleport::Reenable("@%tele2@");",5); 
	schedule("finishTeleport("@%player@");",2.5);

	return; 
}

function finishTeleport(%player)
{
	%client = Player::getClient(%player);
	$Collided = false;

	Client::setControlObject(%client, %player);
}

//***********************************
// AAOD Mobile Inventory Pack
//***********************************

$InvList[AODMobileInv]        = 1;
$RemoteInvList[AODMobileInv] = 0;
$TeamItemMax[AODMobileInv]        = 5;

$ItemMax[larmor, AODMobileInv]        = 0;
$ItemMax[lfemale, AODMobileInv]        = 0;
$ItemMax[marmor, AODMobileInv]        = 1;
$ItemMax[mfemale, AODMobileInv]        = 1;
$ItemMax[harmor, AODMobileInv]        = 1;

ItemImageData AODMobileInvImage
{        shapeFile        = "MagCargo";
        mountPoint        = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass                        = 5.0;
        firstPerson = false;
};

ItemData AODMobileInv
{        description                = "Mobile Inventory Stn";
        shapeFile                = "inventory_sta";
        classname                = "Backpack";
        heading                        = "lDeployables";
        imageType                = AODMobileInvImage;
        shadowDetailMask = 4;
        elasticity                = 0.2;
        price                        = 5000;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData MobileInvent
{  description                = "Mobile Supply Unit";
        shapeFile                = "inventory_sta";
        classname                = "station";
        visibleToSensor = true;
        sequenceSound[0] = { "activate", SoundActivateInventoryStation };
        sequenceSound[1] = { "power", SoundInventoryStationPower };
        sequenceSound[2] = { "use", SoundUseInventoryStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;
        mapFilter                = 4;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};


function AODMobileInv::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function AODMobileInv::onDeploy(%player,%item,%pos)
{        if (AODMobileInv::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);

        }
}

function AODMobileInv::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,MobileInvent,1,5,0,0,true,1,200);

}


function MobileInvent::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                InventoryStation::onResupply(%this,"InvList");
}

$InvList[PortaComm]        = 1;
$RemoteInvList[PortaComm] = 0;
$TeamItemMax[PortaComm]        = 5;

$ItemMax[larmor, PortaComm]        = 0;
$ItemMax[lfemale, PortaComm]        = 0;
$ItemMax[marmor, PortaComm]        = 1;
$ItemMax[mfemale, PortaComm]        = 1;
$ItemMax[harmor, PortaComm]        = 1;

ItemImageData PortaCommImage

{        shapeFile        = "MagCargo";
        mountPoint        = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass                        = 5.0;
        firstPerson = false;
};

ItemData PortaComm
{        description                = "Mobile Command Stn";
        shapeFile                = "cmdpnl";
        classname                = "Backpack";
        heading                        = "lDeployables";
        imageType                = PortaCommImage;
        shadowDetailMask = 4;
        elasticity                = 0.2;
        price                        = 5000;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData PortaC
{  description                = "Mobile Command Unit";
        shapeFile                = "cmdpnl";
        classname                = "station";
        visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;
        mapFilter                = 4;

        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};

function PortaComm::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function PortaComm::onDeploy(%player,%item,%pos)
{        if (PortaComm::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);

        }
}

function PortaComm::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,PortaC,1,5,0,0,true,1,200);
}


function PortaC::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                CommandStation::onResupply(%this);
}

$InvList[PortaAmmo]        = 1;
$RemoteInvList[PortaAmmo] = 0;
$TeamItemMax[PortaAmmo]        = 5;

$ItemMax[larmor, PortaAmmo]        = 0;
$ItemMax[lfemale, PortaAmmo]        = 0;
$ItemMax[marmor, PortaAmmo]        = 1;
$ItemMax[mfemale, PortaAmmo]        = 1;
$ItemMax[harmor, PortaAmmo]        = 1;

ItemImageData PortaAmmoImage
{        shapeFile        = "MagCargo";
        mountPoint        = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass                        = 5.0;
        firstPerson = false;
};

ItemData PortaAmmo
{        description                = "Mobile Ammo Stn";
        shapeFile                = "ammounit";
        classname                = "Backpack";
        heading                        = "lDeployables";
        imageType                = PortaAmmoImage;
        shadowDetailMask = 4;
        elasticity                = 0.2;
        price                        = 5000;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData PortaA
{  description                = "Mobile Ammo Unit";
        shapeFile                = "Ammounit";
        classname                = "station";
        visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundAmmoStationPower };
	sequenceSound[2] = { "use", SoundUseAmmoStation };
        maxDamage                = 1.5;
        debrisId                = flashDebrisLarge;

       mapFilter                = 4;
        mapIcon                        = "M_station";
        damageSkinData        = "objectDamageSkins";
        shadowDetailMask = 16;
        triggerRadius        = 1.5;
        explosionId                = flashExpLarge;
        shieldShapeName = "shield";

};

function PortaAmmo::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function PortaAmmo::onDeploy(%player,%item,%pos)
{        if (PortaAmmo::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);

        }
}

function PortaAmmo::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,PortaA,1,5,0,0,true,1,200);
}


function PortaA::onEndSequence(%this,%thread)
{
        if (Station::onEndSequence(%this,%thread))
                AmmoStation::onResupply(%this);
}

//-------------------------------
// ******* Mobile Generator *****
//-------------------------------
$TeamItemMax[AODMobileGen]		= 2;
$InvList[AODMobileGen]		= 1;
$RemoteInvList[AODMobileGen]	= 0;

$ItemMax[larmor, AODMobileGen]		= 0;
$ItemMax[lfemale, AODMobileGen]	= 0;
$ItemMax[marmor, AODMobileGen]		= 1;
$ItemMax[mfemale, AODMobileGen]	= 1;
$ItemMax[harmor, AODMobileGen]		= 0;

ItemImageData AODMobileGenImage 
{	shapeFile	= "generator_p";
	mountPoint	= 2;
	mountOffset = { 0, -0.65, -0.4 };
	mas			= 5.0;
	firstPerson = false;
};


ItemData AODMobileGen
{	description		= "Portable Generator";
	shapeFile		= "generator_p";
	classname		= "Backpack";
	heading			= "lDeployables";
	imageType		= AODMobileGenImage;
	shadowDetailMask = 4;
	mass			= 4.5;
	elasticity		= 0.2;
	price			= 2500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData MobileGen 
{	description		= "Portable Generator";
	shapeFile		= "generator_p";
	classname		= "pGen";
	debrisId		= flashDebrisSmall;
	sfxAmbient		= SoundGeneratorPower;
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
		
};


function AODMobileGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODMobileGen::onDeploy(%player,%item,%pos)
{	if (AODMobileGen::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function AODMobileGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileGen,1,5,0,0,false,2,350);
	
}

function MobileGen::onAdd(%this)
{}

function MobileGen::onDestroyed(%this)
{	if($trace) echo($ver,"| MobileGen::onDestroyed");
	MobileGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function MobileGen::onEnabled(%this)
{	if($trace) echo($ver,"| MobileGen::onEnabled ",%this);
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
}

function MobileGen::onDisabled(%this)
{	if($trace) echo($ver,"| MobileGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

//---------------------------------
// ******* Shield Generator *******
//---------------------------------
//  	Shield Power Functions
// --------------------------------
$InvList[AODShieldGen]		= 1;
$RemoteInvList[AODShieldGen]	= 0;
$TeamItemMax[AODShieldGen]		= 1;

$ItemMax[larmor, AODShieldGen]		= 0;
$ItemMax[lfemale, AODShieldGen]	= 0;
$ItemMax[marmor, AODShieldGen]		= 1;
$ItemMax[mfemale, AODShieldGen]	= 1;
$ItemMax[harmor, AODShieldGen]		= 0;

ItemImageData AODShieldGenImage 
{	shapeFile		= "MagCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 5.0;
	firstPerson		= false;
};


ItemData AODShieldGen
{	description		= "Shield Generator";
	shapeFile		= "generator";
	classname		= "Backpack";
	heading			= "lDeployables";
	imageType		= AODShieldGenImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 1500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData ShieldGen 
{	description			= "Shield Generator";
	shapeFile			= "generator";
	classname			= "ShieldGen";
	debrisId			= flashDebrisLarge;
	maxDamage			= 1.8;
	mapIcon				= "M_generator";
	damageSkinData		= "objectDamageSkins";

shadowDetailMask	= 16;
	explosionId			= LargeShockWave;
	visibleToSensor		= true;
	mapFilter			= 4;
	shieldShapeName		= "shield";
	sequenceSound[0] = { "power", SoundShieldGenerator };
};


function AODShieldGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODShieldGen::onDeploy(%player,%item,%pos)
{	if (AODShieldGen::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function AODShieldGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%gen=DeployStuff(%player,%item,ShieldGen,1,5,0,0,false,1,196);
	if(%gen)
	{	%team=GameBase::getTeam(%player);
		$ShieldGen[%team]=%gen;
		$ShieldGenOn[%team]=true;
		if($trace) echo( $ver@"|NodeSet for this team is ",$NodeSet[%team]);
		if(!$NodeSet[%team])
		{	if($trace) echo( $ver@"|Creating a Node Set for Team ",%team);
			$NodeSet[%team] = newObject("ShieldNodes",SimSet);
			addToSet("MissionCleanup", $NodeSet[%team]);
		}

	}
}

function ShieldGen::onAdd(%this)
{}

function ShieldGen::onEnabled(%this)
{	if($trace) echo( $ver@"|Shield Gen OnEnabled");
	%team=GameBase::getTeam(%this);
	if(%this.destroyed==true)
	{	// Was destroyed but is no longer - Has been repaired
		%this.destroyed=false;
	}
	if(GameBase::isPowered(%this))
	{	GameBase::playSequence(%this,0,"power");
		if (%team!=-1)
		{	$ShieldGenOn[%team]=true;
			ActivateNodes(true,%team);
		}
	}
}

function ShieldGen::onDestroyed(%this)
{	if($trace) echo( $ver@"|ShieldGen::onDestroyed");
	%team=GameBase::getTeam(%this);
	if($ShieldGenOn[%team])
		ShieldGen::onDisabled(%this);

	$ShieldGen[%team]=false;
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 8.5, 0.10, 55, 23, 3, 1.5, 1.0, 250, 170); 
}

function ShieldGen::onDisabled(%this)
{	if($trace) echo( $ver@"|ShieldGen::onDisabled");
	%team=GameBase::getTeam(%this);
	GameBase::stopSequence(%this,0);
 	$ShieldGenOn[%team]=false;
	ActivateNodes(false,%team);
}

function ShieldGen::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|ShieldGen::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		ShieldGen::OnEnabled(%this);
	else
		ShieldGen::OnDisabled(%this);
}



function ActivateNodes(%status,%team)
{	if($trace) echo( $ver@"|Activate Shield Nodes for Team ",%team);
	%num=$TeamItemCount[%team @ AODShieldNode];
	if (%num>0)
	{	for(%i=0;%i<%num;%i++)
		{	%node=Group::GetObject($NodeSet[%team],%i);
			if($trace) echo( $ver@"|Node ID is:",%node);
			if (%status==true)
			{	if($trace) echo( $ver@"|Activating Node :",%i);
				if($trace) echo( $ver@"|Node ID = ",%node);
				RemoteShieldNode::onActivate(%node);}
			else
			{	if($trace) echo( $ver@"|DeActivating Node :",%i);
				if($trace) echo( $ver@"|Node ID = ",%node);
				RemoteShieldNode::onDeActivate(%node);}
		}
	}
	else
		if($trace) echo( $ver@"|No Nodes to Activate");
}

$InvList[DShieldPack]		= 1;
$RemoteInvList[DShieldPack]	= 0;
$TeamItemMax[DShield]		= 2;

$ItemMax[larmor, DShieldPack]		= 0;
$ItemMax[lfemale, DShieldPack]	= 0;
$ItemMax[marmor, DShieldPack]		= 1;
$ItemMax[mfemale, DShieldPack]	= 1;
$ItemMax[harmor, DShieldPack]		= 0;

$DShield::MaxCapCharge=4.0;
$DShield::TimerTick=0.25;
$DShield::ShieldEnhance=0.05;
$DShield::ProtectArea=150; 
$DShield::OverlapValue=0; 

StaticShapeData DShield
{
	description = "Enhancement Beacon";
	className = "DShield";
	damageSkinData = "objectDamageSkins";
	shapeFile = "bridge"; 
	maxDamage = 1.4;
	maxEnergy = 500;
	sfxAmbient = SoundGeneratorPower;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = LargeShockwave;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	mass=2.5;
	shieldShapeName = "shield";
};

ItemImageData DShieldPackImage
{
	shapeFile = "bridge"; 
	mountPoint = 2;
	mountOffset = { 0, -0.5, -1 }; 
	mountRotation = { 0.2, 0, 0 }; 
	firstPerson = false;
};

ItemData DShieldPack
{
	description = "Enhancement Beacon";
	shapeFile = "bridge"; 
	className = "Backpack";
	heading = "lDeployables"; 
	imageType = "DShieldPackImage";
	sequenceSound[0] = { "power", SoundSensorPower };
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DShieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Any team member within 100m will have their energy regeneration boosted significantly.  Great for base defense, Also adds shields to any team member in the radius.");
}

function CheckDeployTerrain (%this) 
{
	%obj=getObjectType(%this);
	if( %obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName(%this) == "DeployableBaseOps" || GameBase::getDataName(%this)=="BlastFloorShape") 
	{
		return 1;
	}
	return 0;
}

function ZTekDebug() 
{
	%DebugClient=2049;
	%DebugObject=Client::getOwnedObject(2049);
	echo("Player Data:");
	echo("Client: 2049");
	echo("Player Object:"@%DebugObject);
	echo("Shields: "@%DebugObject.shieldStrength);
}

function DShield::onDestroyed(%this)
{
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	if ($functioning[%this]==1)
	{
		GameBase::stopSequence(%this,0);
		%pos=GameBase::getPosition(%this);
		echo("shield disabled");
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%matrix = %clientId @ %this;
			%obj = Client::getOwnedObject(%clientId);
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if ($oldShieldGen[%matrix] == 1)
				{
					%recharge=GameBase::getRechargerate(%obj)-15;
					if (%recharge > 7 || $empTime[%clientId] > 0)
					{
						GameBase::setRechargeRate(%obj, 8);
						client::sendMessage(%clientId,1,"WARNING:  EMS Power flux failure in Enhancement Beacon ID#" @ %this @"!");
					}
					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
				}
			}
		}	
	}
	$functioning[%this]=0;
}

function DShieldPack::onUse(%player,%item)
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

function DShieldPack::onDeploy(%player,%item,%pos)
{
	if (DShieldPack::deployShape(%player,"Shield Generator",DShield,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DShield"]++;
	}
}

function CreateDShieldSimSet(%this)
{
	%dset = nameToID("MissionCleanup/DShield");
	if(%dset == -1)
	{
		newObject("DShield",SimSet);
		addToSet("MissionCleanup","DShield");
	}
	%dset = nameToID("MissionCleanup/DShield/DShield"@%this);
	if(%dset == -1)
	{
		newObject("DShield"@%this,SimSet);
		addToSet("MissionCleanup/DShield","DShield"@%this);
	}
}

function DShieldPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DShield"] < $TeamItemMax[DShield]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (CheckDeployTerrain($los::object)) 
			{
				%set = newObject("set",SimSet);
				%ovr = ($DShield::ProtectArea-$DShield::OverlapValue)/2;
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%ovr,%ovr,%ovr,0);
				%num = CountObjects(%set,"DShield",%num);
				deleteObject(%set);
				if(!%num) 
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						if (checkenemybase($los::position,$los::object,%player) != true)
						{
							if(checkDeployArea(%client,$los::position)) 
							{
								%sensor = newObject("Enhancement Beacon","StaticShape",%shape,true);
								$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]++;
								%team = GameBase::getTeam(%this);
								%index = $TeamItemCount[GameBase::getTeam(%this) @ "DShield"];
								$ShieldGen++;
								$ShieldGenObject[$ShieldGen]=%sensor;
								CreateDShieldSimSet(%sensor);
								addToSet("MissionCleanup/DShield", %sensor);
								addToSet("MissionCleanup", %sensor);
								GameBase::setTeam(%sensor,GameBase::getTeam(%player));
								%pos = Vector::add($los::position,"0 0 0");
								GameBase::setRotation(%sensor,GameBase::getRotation(%player));
								GameBase::setPosition(%sensor,%pos);
								Gamebase::setMapName(%sensor,%name);
								GameBase::setRechargeRate(%sensor,1);
								GameBase::setActive(%sensor,True);
								Client::sendMessage(%client,0,%item.description @ " deployed!");
								playSound(SoundPickupBackpack,$los::position);
								Client::sendMessage(%client,0,%item.description @ " initializing flux.");
								schedule("DShield::checkAreaDfox("@%sensor@");",3, %sensor);
								return true;
							}
						}
						else 
						Client::sendMessage(%client,0,"Cannot deploy the Enhancement Beacon on an enemy base.");
					}
					else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else
				Client::sendMessage(%client,0,"Too close to other Enhancement Beacons");
			}
			else 
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

function DShield::onEnabled(%this)
{
	DShield::setActive(%this,true);
}

function DShield::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	%pos=GameBase::getPosition(%this);
	$functioning[%this]=0;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%matrix = %clientId @ %this;
		if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
		%obj = Client::getOwnedObject(%clientId);
		%clientpos=gamebase::getPosition(%clientId);
		%dist = Vector::getDistance(%pos, %clientpos);
		if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
		{
			if ($oldShieldGen[%matrix] == 1)
			{
				%recharge=GameBase::getRechargerate(%obj)-15;
				if (%recharge > 7 || $empTime[%clientId] > 0)
				{
					GameBase::setRechargeRate(%obj, 8);
					client::sendMessage(%clientId,1,"WARNING:  EMS Power flux failure in Enhancement Beacon ID#" @ %this @"!");
				}
				if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
				{
					if(Player::isTriggered(%obj, $BackpackSlot) == true)
					{
					}
				}
				else %obj.shieldStrength = 0.0;
				$oldShieldGen[%matrix]=0;
			}
		}
	}	
	GameBase::applyDamage(%objt1,$CrushDamageType,0.15,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
}

function DShield::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::setActive(%this)
{
	GameBase::playSequence(%this,0,"power");
}

function DShield::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	echo("shield deactivated");
	playSound(SoundGeneratorPower,GameBase::getposition(%this));
}

function Dshield::CheckAreaDfox(%this)
{
	if(GameBase::getDamageState(%this) =="Enabled") 
	{
		$functioning[%this]=1;
		%pos=GameBase::getPosition(%this);
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%obj = Client::getOwnedObject(%clientId);
			%matrix = %clientId @ %this;
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if (%dist<140)
				{
					if ($oldShieldGen[%matrix]==0)
					{
						GameBase::setRechargeRate(%obj, 16);
						client::sendMessage(%clientId,3,"Enhancement Beacon #" @ %this @ " active and enhancing.");
//						if(%obj.shieldStrength < 0.012) 
						%obj.shieldStrength = 0.006;
						$oldShieldGen[%matrix]=1;
					}
				}
				else if($oldShieldGen[%matrix]==1)
				{
						GameBase::setRechargeRate(%obj, 8);
						client::sendMessage(%clientId,1,"Left Enhancement Beacon #" @ %this @ "'s enhancing range. ");

					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
				}
			}
		}
	}
	schedule("DShield::checkAreaDfox("@%this@");",1, %this);
}

$TeamItemMax[EpodV] = 1024;

//---------------------------------------------------------------------------------------------

//===============================================================================================
// Force field doors Blast Door
//===============================================================================================

ItemImageData doorfivebyfiveForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mass = 1.5;
        firstPerson = false;
};

ItemData doorfivebyfiveForceFieldPack
{
        description = "5x5 Forcefield";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "nBarriers";
        imageType = doorfivebyfiveForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;

};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
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

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);

                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"5x5 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"5x5 Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 5x5 Force Field Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else


               Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


StaticShapeData doorfivebyfiveForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 10;
maxEnergy = 20;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "5x5 Field Door";
	shieldShapeName = "shield";
};
function doorfivebyfiveForceFieldShape::Destruct(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
}
function doorfivebyfiveForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "doorfivebyfiveForceFieldShape"]--;
}

function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfivebyfiveForceFieldShape::openDoor(%this);
return;
}
function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}
function doorfivebyfiveForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}

$TeamItemMax[doorfivebyfiveForceFieldShape] = 12;

$InvList[doorfivebyfiveForceFieldPack] = 1;
$RemoteInvList[doorfivebyfiveForceFieldPack] = 1;

$ItemMax[marmor, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[mfemale, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[larmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[lfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[harmor, doorfivebyfiveForceFieldPack] = 0;

//=============================================================================================

ItemImageData doorfourbyeightForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mass = 1.5;
        firstPerson = false;
};

ItemData doorfourbyeightForceFieldPack
{
        description = "4x8 Forcefield";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "nBarriers";
        imageType = doorfourbyeightForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 1000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyeightForceFieldPack::onUse(%player,%item)
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

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyeightForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyeightForceFieldPack::deployShape(%player,%item)
{
          %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("","StaticShape",doorfourbyeightForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x8 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x8 Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x8 Force Field Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData doorfourbyeightForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x8";
maxDamage = 15.0;
maxEnergy = 40;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "4x8 Field Door";
	shieldShapeName = "shield";
};
function doorfourbyeightForceFieldShape::Destruct(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
}
function doorfourbyeightForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfourbyeightForceFieldShape::onDestroyed(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyeightForceFieldShape"]--;
}
function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfourbyeightForceFieldShape::openDoor(%this);
return;
}
function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}
function doorfourbyeightForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);

schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}

$TeamItemMax[doorfourbyeightForceFieldShape] = 8;

$InvList[doorfourbyeightForceFieldPack] = 1;
$RemoteInvList[doorfourbyeightForceFieldPack] = 1;

$ItemMax[marmor, doorfourbyeightForceFieldPack] = 1;
$ItemMax[mfemale, doorfourbyeightForceFieldPack] = 1;
$ItemMax[larmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[lfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[harmor, doorfourbyeightForceFieldPack] = 0;

//=============================================================================================

ItemImageData BlastDoorI
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mass = 1.5;
        firstPerson = false;
};

ItemData BlastDoor
{
        description = "Blast Door";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "nBarriers";
        imageType = BlastDoorI;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 2000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastDoor::onUse(%player,%item)
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

function BlastDoor::onDeploy(%player,%item,%pos)
{
        if (BlastDoor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastDoor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

            if (GameBase::getLOSInfo(%player,3)) 
		{

                      %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastDoor","StaticShape",BlastDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"BlastDoor #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Blast Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoor"]++;
                                        echo("MSG: ",%client," deployed a Blast Door");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData BlastDoorShape
{
        className = "Blast Door";
        damageSkinData = "objectDamageSkins";
        shapeFile = "Newdoor5";
        maxDamage = 25;
        maxEnergy = 80;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "Blast Door";
	shieldShapeName = "shield";
};

function BlastDoorShape::Destruct(%this)
{
        BlastDoorShape::doDamage(%this);
}

function BlastDoorShape::doDamage(%this)
{
        calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BlastDoorShape::onDestroyed(%this)
{
        BlastDoorShape::doDamage(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "BlastDoorShape"]--;
}

function BlastDoorShape::onCollision(%this,%obj)
{
        if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
        {
                return;
        }

        %c = Player::getClient(%obj);
        %playerTeam = GameBase::getTeam(%obj);
        %fieldTeam = GameBase::getTeam(%this);

        if(%fieldTeam != %playerTeam)
        {
                return;

        }

        BlastDoorShape::openDoor(%this);
        return;
}

function BlastDoorShape::openDoor(%this)
{
        schedule("GameBase::playSound("@%this@",BlastDoorOpen,0);",0.15);

        GameBase::startfadeout(%this);
        %pos=GameBase::getPosition(%this);
        %pos=Vector::add(%pos,"0 0 8");
        GameBase::setPosition(%this,%pos);
        schedule("BlastDoorShape::closeDoor("@%this@");",4);
}

function BlastDoorShape::closeDoor(%this)
{
        schedule("GameBase::playSound("@%this@",BlastDoorClose,0);",0.15);
        %pos=GameBase::getPosition(%this);
        %pos=Vector::add(%pos,"0 0 -8");
        GameBase::setPosition(%this,%pos);
        GameBase::startfadein(%this);
}

function BlastDoorShape::openDoor(%this)
{
        schedule("GameBase::playSound("@%this@",BlastDoorOpen,0);",0.15);
        GameBase::startfadeout(%this);

        %pos=GameBase::getPosition(%this);
        %pos=Vector::add(%pos,"0 0 8");
        GameBase::setPosition(%this,%pos);
        schedule("BlastDoorShape::closeDoor("@%this@");",4);
}

$TeamItemMax[BlastDoorShape] = 10;

$InvList[BlastDoor] = 1;
$RemoteInvList[BlastDoor] = 0;

$ItemMax[marmor, BlastDoor] = 1;
$ItemMax[mfemale, BlastDoor] = 1;
$ItemMax[larmor, BlastDoor] = 0;
$ItemMax[lfemale, BlastDoor] = 0;
$ItemMax[harmor, BlastDoor] = 0;

//=============================================================================================

ItemImageData BlastFloorI
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mass = 1.5;
        firstPerson = false;
};

ItemData BlastFloor
{
        description = "Blast Floor";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "nBarriers";
        imageType = BlastFloorI;
        shadowDetailMask = 4;
        mass = 1.5;
       elasticity = 0.2;
        price = 2500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastFloor::onUse(%player,%item)
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

function BlastFloor::onDeploy(%player,%item,%pos)
{
        if (BlastFloor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastFloor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastFloor","StaticShape",BlastFloorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"BlastFloor #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Blast Floor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastFloorShape"]++;

                                       echo("MSG: ",%client," deployed a Blast Floor");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData BlastFloorShape
{
        className = "Blast Floor";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6x6thin";
        maxDamage = 5;
        maxEnergy = 10;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        side = "single";
        isTranslucent = true;
        description = "Blast Floor";
	shieldShapeName = "shield";
};

function BlastFloorShape::Destruct(%this)
{
        BlastFloorShape::doDamage(%this);
}

function BlastFloorShape::doDamage(%this)
{
        calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BlastFloorShape::onDestroyed(%this)
{
        BlastDoorShape::doDamage(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "BlastFloorShape"]--;
}

$TeamItemMax[BlastFloorShape] = 128;

$InvList[BlastFloor] = 1;
$RemoteInvList[BlastFloor] = 0;

$ItemMax[marmor, BlastFloor] = 1;
$ItemMax[mfemale, BlastFloor] = 1;
$ItemMax[larmor, BlastFloor] = 0;
$ItemMax[lfemale, BlastFloor] = 0;
$ItemMax[harmor, BlastFloor] = 0;

//***********************************
// AAOD Mobile Bunker Pack
//***********************************
$InvList[AODBunker]                = 1;
$RemoteInvList[AODBunker]                = 0;
$TeamItemMax[AODBunker]                = 5;

$ItemMax[larmor, AODBunker]                = 0;
$ItemMax[lfemale, AODBunker]                = 0;
$ItemMax[marmor, AODBunker]                = 1;
$ItemMax[mfemale, AODBunker]                = 1;
$ItemMax[harmor, AODBunker]                = 1;

ItemImageData AODBunkerImage
{        shapeFile = "MagCargo";
        mountPoint = 2;
        mountOffset = { 0, -0.65, -0.4 };
        mass = 1.0;
        firstPerson = false;

};

ItemData AODBunker
{        description                = "Mobile Bunker";
        shapeFile                = "MagCargo";
        classname                = "Backpack";
        heading                        = "nBarriers";
        imageType                = AODBunkerImage;
        shadowDetailMask = 4;
        mass                        = 4.5;
        elasticity                = 0.2;
        price                        = 1200;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive        = true;
};

StaticShapeData MobileBunker
{        className                = "AAODDep";
        shapeFile                = "NewDoor5";
        debrisId                = defaultDebrisSmall;
        maxDamage                = 35;
        visibleToSensor = true;
        isTranslucent        = true;
        description                = "Mobile Bunker Wall";
        shieldShapeName = "shield";
};


function AODBunker::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {        Player::mountItem(%player,%item,$BackpackSlot);}
    else
        {        Player::deployItem(%player,%item);}
}

function AODBunker::onDeploy(%player,%item,%pos)
{        if (AODBunker::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODBunker::deployShape(%player,%item)
{        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {        if (GameBase::getLOSInfo(%player,5))
                {        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || GameBase::getDataName($los::object) == "BlastFloorShape")
                        {        %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,20,15,15,0);
                                deleteObject(%set);
                                if(0 == %num)
                                {        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                        {                %rot = GameBase::getRotation(%player);
                                                        %team=GameBase::getteam(%player);
                                                        // 1st Wall
                                                        %CurrPos=$los::position;
                                                        %NewVector="0 0 -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%rot);
                                                        Gamebase::setMapName(%wall,"Mobile Bunker");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[0 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);


                                                        // 2nd Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.375245789"),2);
                                                        %x=COS(%ang)*9.2;
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.375245789"),2);
                                                        %y=SIN(%ang)*9.2;
                                                        %NewVector=%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 -0.785398163");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"Mobile Bunker");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[1 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);

                                                        //3rd Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.375245789"),2);
                                                        %x=COS(%ang)*-9.2;
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.375245789"),2);
                                                        %y=SIN(%ang)*-9.2;


                                                        %NewVector=""@%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 0.785398163");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"Mobile Bunker");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[2 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);

                                                       Client::setOwnedObject(%client, %player);

                                                        //4th Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.785398163"),2);
                                                        %x=COS(%ang)*16.8;
                                                        %ang=Getword(Vector::add(%rot,"0 0 -0.785398163"),2);
                                                        %y=SIN(%ang)*16.8;
                                                        %NewVector=""@%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 -1.570796327");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"Mobile Bunker");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[3 @ %Team]=%wall;
                                                        playSound(SoundBunkerDeploy,$los::position);
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);

                                                        // 5th Wall
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.785398163"),2);
                                                        %x=COS(%ang)*-16.8;
                                                        %ang=Getword(Vector::add(%rot,"0 0 0.785398163"),2);
                                                        %y=SIN(%ang)*-16.8;
                                                        %NewVector=%x@" "@%y@" -0.5";
                                                        %NewPos=Vector::add(%CurrPos,%NewVector);
                                                        %ang=Vector::add(%rot,"0 0 1.570796327");
                                                        %wall = newObject("Bunker","StaticShape",MobileBunker,false);
                                                        addToSet("MissionCleanup", %wall);
                                                        GameBase::setTeam(%wall,GameBase::getTeam(%player));
                                                        GameBase::setPosition(%wall,%NewPos);
                                                        GameBase::setRotation(%wall,%ang);
                                                        Gamebase::setMapName(%wall,"Mobile Bunker");
                                                        GameBase::startFadeIn(%wall);
                                                        $TeamBunker[4 @ %Team]=%wall;
                                                        Client::setOwnedObject(%client, %wall);
                                                        Client::setOwnedObject(%client, %player);

                                                        $TeamItemCount[GameBase::getTeam(%player) @ "AODBunker"]++;
                                                        echo("INF: ",$User[%client]," deployed a Mobile Bunker");
                                                        return true;
                                        }
                                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                                }
                                else Client::sendMessage(%client,0,"Some other Item in the Way!!");
                        }
                        else Client::sendMessage(%client,0,"Can only deploy Outside on terrain");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}


function MobileBunker::onDestroyed(%this)
{        // StaticShape::onDestroyed(%this);
        // $TeamItemCount[GameBase::getTeam(%this) @ "AODBunker"]--;
}

//=====================================

$InvList[C4Pack] = 1;
$RemoteInvList[C4Pack] = 1;

$TeamItemMax[C4Pack] = 100000;

$ItemMax[harmor, C4Pack] = 0;
$ItemMax[marmor, C4Pack] = 1;
$ItemMax[mfemale, C4Pack] = 1;
$ItemMax[larmor, C4Pack] = 1;
$ItemMax[lfemale, C4Pack] = 1;

ItemImageData C4PackImage
{
        shapeFile = "grenammo";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        mass = 1.5;
        firstPerson = false;

};

ItemData C4Pack
{
        description = "C-4 LAM";
        shapeFile = "grenammo";
        className = "Backpack";
   heading = "lDeployables";
        imageType = C4packImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 5000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function C4Pack::onUse(%player,%item)
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

function C4Pack::onUnmount(%player,%item)
{
        deleteObject(%item);

}

function C4Pack::onDeploy(%player,%item,%pos)
{
        if (C4Pack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function C4Pack::deployShape(%player,%item)
{
        Player::unmountItem(%player,$BackpackSlot);

                        %obj = newObject("C-4","Mine","C4");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
        bottomprint(Player::getClient(%player), "<jc>C-4 will explode in <f2>15 seconds", 5);
}

ItemImageData BlastPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.5;
        firstPerson = false;
};

ItemData TNTPack
{
        description = "Blast Pack";
        shapeFile = "magcargo";
        className = "Backpack";
   heading = "lDeployables";
        imageType = BlastPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 10000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TNTPack::onUse(%player,%item)
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

function TNTPack::onUnmount(%player,%item)
{
        deleteObject(%item);

}

function TNTPack::onDeploy(%player,%item,%pos)
{
        if (TNTPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function TNTPack::deployShape(%player,%item)
{
        Player::unmountItem(%player,$BackpackSlot);

                        %obj = newObject("Deployable Mortar","Mine","TNT");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
        bottomprint(Player::getClient(%player), "<jc>Blast pack will explode in <f2>15 seconds", 5);
}


$InvList[TNTPack] = 1;
$RemoteInvList[TNTPack] = 1;

$TeamItemMax[TNTPack] = 100000;

$ItemMax[harmor, TNTPack] = 1;
$ItemMax[marmor, TNTPack] = 1;
$ItemMax[mfemale, TNTPack] = 1;
$ItemMax[larmor, TNTPack] = 0;
$ItemMax[lfemale, TNTPack] = 0;

//--------------------------------------------------------------------------------------------------------
// Mini Base
//--------------------------------------------------------------------------------------------------------

$TeamItemMax[MiniBase] = 2;

ItemImageData MiniBaseImage
{
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData MiniBase
{
	description = "Mini-Base";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading =  "lDeployables";
	imageType = MiniBaseImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 10000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData MiniBaseGenerator
{
   description = "Power Source";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 1.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;
};

function MiniBase::Destruct(%this)
{
                %obj = newObject("","Mine","armorCoreExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 -2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","armorExp");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
	return;
}

function MiniBaseGenerator::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	MiniBase::Destruct(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "MiniBase"]--;
}

StaticShapeData BasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 15.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Mini-Base";
};

function BasePlatform::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	MiniBase::Destruct(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 30, 1000, 250, 30, 25, 1000, 999, 250, 100);
}

function MiniBase::onUse(%player,%item)
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

function MiniBase::onDeploy(%player,%item,%pos)
{
        if (MiniBase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function MiniBase::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
      %client = Player::getClient(%player);
      %playerPos = GameBase::getPosition(%player);

      if($TeamItemCount[GameBase::getTeam(%player) @ "MiniBase"] >= $TeamItemMax[MiniBase])
      { 
		Client::sendMessage(%client,0,"Too many Mini-Bases"); 
		return false; 
	}

      %obj = getObjectType($los::object);
      %set = newObject("MiniBase",SimSet);
      %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
      %num = CountObjects(%set,"MiniBase",%num);
      deleteObject(%set);

      %objDevice = newObject("groundBase","Staticshape",MiniBaseGenerator,true);
      %objDevice.objSide1 = newObject("groundBase1","Staticshape",BasePlatform,true);
      %objDevice.objSide2 = newObject("groundBase2","Staticshape",BasePlatform,true);
      %objDevice.objSide3 = newObject("groundBase3","Staticshape",BasePlatform,true);
      %objDevice.objSide4 = newObject("groundBase4","Sensor",PulseSensor,true);
      %objDevice.objSide5 = newObject("groundBase5","StaticShape",BasePlatform,true);
      %objDevice.objSide6 = newObject("groundBase6","StaticShape",AmmoStation,true);
      %objDevice.objSide7 = newObject("groundBase7","StaticShape",InventoryStation,true);
      %objDevice.objSide8 = newObject("groundBase8","StaticShape",VehicleStation,true);
      %objDevice.objSide9 = newObject("groundBase9","StaticShape",VehiclePad,true);

      %objDevice.objSide1.objParent = %objDevice;
      %objDevice.objSide2.objParent = %objDevice;
      %objDevice.objSide3.objParent = %objDevice;
      %objDevice.objSide4.objParent = %objDevice;
      %objDevice.objSide5.objParent = %objDevice;
      %objDevice.objSide6.objParent = %objDevice;
      %objDevice.objSide7.objParent = %objDevice;
      %objDevice.objSide8.objParent = %objDevice;
      %objDevice.objSide9.objParent = %objDevice;

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

// The Building <(8)>

      %pos = Vector::add(GameBase::getPosition(%player), "7.5 0 22");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide5,%rot);
      GameBase::setPosition(%objDevice.objSide5,%pos);
      GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

      %pos = Vector::add(GameBase::getPosition(%player), "-7.5 0 22");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide1,%rot);
      GameBase::setPosition(%objDevice.objSide1,%pos);
      GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));

      %pos = Vector::add(GameBase::getPosition(%player), "0 7 15");
      %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
      GameBase::setRotation(%objDevice.objSide2,%rot);
      GameBase::setPosition(%objDevice.objSide2,%pos);
      GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 -7 15");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
       GameBase::setRotation(%objDevice.objSide3,%rot);
       GameBase::setPosition(%objDevice.objSide3,%pos);
       GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 0 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
       GameBase::setRotation(%objDevice.objSide4,%rot);
       GameBase::setPosition(%objDevice.objSide4,%pos);
       GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "0 0 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice,%rot);
       GameBase::setPosition(%objDevice,%pos);
       GameBase::setTeam(%objDevice.objSide5,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "-1 7 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 -4.71339");
       GameBase::setRotation(%objDevice.objSide6,%rot);
       GameBase::setPosition(%objDevice.objSide6,%pos);
       GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "1 -7 15.40");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide7,%rot);
       GameBase::setPosition(%objDevice.objSide7,%pos);
       GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "-7 1 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide8,%rot);
       GameBase::setPosition(%objDevice.objSide8,%pos);
       GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));

       %pos = Vector::add(GameBase::getPosition(%player), "7 -1 22.50");
       %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
       GameBase::setRotation(%objDevice.objSide9,%rot);
       GameBase::setPosition(%objDevice.objSide9,%pos);
       GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
       Gamebase::setMapName(%inv,"Mini-Base " @  Client::getName(%client));

       playSound(SoundPickupBackpack,$los::position);
       $TeamItemCount[GameBase::getTeam(%player) @ "MiniBase"]++;
       Client::sendMessage(%client,0,"Mini-Base Deployed.");
       echo("MSG: ",%client," deployed a Mini-Base");
       return true;
}

$InvList[MiniBase] = 1;
$RemoteInvList[MiniBase] = 1;

$ItemMax[harmor, MiniBase] = 1;
$ItemMax[marmor, MiniBase] = 1;
$ItemMax[mfemale, MiniBase] = 1;
$ItemMax[larmor, MiniBase] = 0;
$ItemMax[lfemale, MiniBase] = 0;

//--------------------------------------------------------------------------------------------------------
// Dropship Pack - deploy design by Scavenger
//--------------------------------------------------------------------------------------------------------

$TeamItemMax[HPCPack] = 2;

$InvList[HPCPack] = 1;
$RemoteInvList[HPCPack] = 1;

$ItemMax[larmor, HPCPack] = 0;
$ItemMax[lfemale, HPCPack] = 0;
$ItemMax[marmor, HPCPack] = 1;
$ItemMax[mfemale, HPCPack] = 1;
$ItemMax[harmor, HPCPack] = 1;

ItemImageData HPCPackImage
{
        shapeFile = "generator_p";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 0.25;
        firstPerson = false;
};

ItemData HPCPack
{
        description = "Dropship";
        shapeFile = "generator_p";
        className = "Backpack";
   heading = "lDeployables";
        shadowDetailMask = 4;
        imageType = HPCPackImage;
        mass = 0.5;
        elasticity = 0.2;
        price = 150000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HPCPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function HPCPack::onDeploy(%player,%item,%pos)
{
	if (HPCPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HPCPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player); 
	%obj = getObjectType($los::object); 

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
		return false; 
	}

	if (!GameBase::getLOSInfo(%player,3)) 
	{ 
		Client::sendMessage(%client,0,"Deploy position out of range"); 
		return false; 
	}

	if (%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain"); 
		return false; 
	}

	if (!checkDeployArea(%client,$los::position)) 
		return false;
      
      %playerPos = GameBase::getPosition(%player);
      %obj = getObjectType($los::object);
      %set = newObject("set",SimSet);
      %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,200,200,250,0);
      %num = CountObjects(%set,"FlagStand",%num);
      deleteObject(%set);

	if(%num)
      { 
		Client::sendMessage(%client,0,"You are too close to a flag, Must be at least 200m from flag to deploy."); 
		return; 
	}
	else
	{
 		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$ItemObjectType,%teamspot,25,25,1000,0); // 100 100 800
		%num2 = CountObjects(%set,"flag",%num);
		%totalnum = Group::objectCount(%set);
		%enemyflag=0;
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%name = Item::getItemData(%obj);
			if(%name == "flag")
			{
				if(GameBase::getTeam(%obj) != Gamebase::getTeam(%player)) %enemyflag = %enemyflag+1;
			}
		}
		deleteObject(%set);

		%set = newObject("set",SimSet);
      	%num = containerBoxFillSet(%set,$ItemObjectType,$los::position,200,200,250,0);
	      %num = CountObjects(%set,"Flag",%num);
	      %numrf = CountObjects(%set,"RaceFlag",%num);
      	deleteObject(%set2);

		if(%num || %numrf)
      	{ 
			Client::sendMessage(%client,0,"You are too close to a flag, Must be at least 200m from flag to deploy."); 
			return; 
		}
		else
		{
			%num2 = CountObjects(%set,"flag",%num);
			%totalnum = Group::objectCount(%set);

			for(%i = 0; %i < %totalnum; %i++)
			{
				%obj = Group::getObject(%set, %i);
				%name = Item::getItemData(%obj);
		
				if(%name == "flag")
				{
					Client::sendMessage(%client,0,"You are too close to a flag, Must be at least 200m from flag to deploy."); 
					return; 
				}
			}
			deleteObject(%set);
		}
	}

	 //
	 // Passed validation, create the object
	 //
	%rot="0 0 0";
	%opos=Vector::add($los::position,"0 0 5");
								
	%objShip1 = newObject("BasicDropShip1","InteriorShape", "gdsdrop.dis"); 
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup", %objShip1); 
	GameBase::setTeam(%objShip1,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objShip1,%pos); 
	GameBase::setRotation(%objShip1,%rot); 
	Gamebase::setMapName(%objShip1,"Dropship"); 
	
	%objShip1 = newObject("Generator1","StaticShape",MiniBaseGenerator,true);
	%pos=Vector::add(%opos,"11.0328 5.33114 15.000196456"); 
	addToSet("MissionCleanup", %objShip1);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	GameBase::setPosition(%objShip1,"1.0328 9.33114 1.000196456"); 
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Internal Generator");
	GameBase::setPosition(%objship1,%pos);
	GameBase::setActive(%objship1,True);

	%objShip1 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"13.0328 0.0 14.000196456");
	addToSet("MissionCleanup", %objShip1);
	GameBase::setTeam(%objship1,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Inventory Station");
	GameBase::setPosition(%objShip1,%pos);
	
	%objShip1 = newObject("Ammo1","StaticShape",AmmoStation,false);
	%pos = Vector::add(%opos,"-13.5328 0.53114 14.000196456");	
	addToSet("MissionCleanup", %objShip1);
	GameBase::setTeam(%objship1,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Ammo Station");
	GameBase::setPosition(%objShip1,%pos);

	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "HPCPack"]++; 
      Client::sendMessage(%client,0,"Dropship Deployed.");        
	return true; 
} 

//======================Borg Cube

$TeamItemMax[BaseOpsPack] = 2;
$TeamItemMax[DeployableBaseOps] = 2;

$InvList[BaseOpsPack] = 1;
$RemoteInvList[BaseOpsPack] = 1;

$ItemMax[larmor, BaseOpsPack] = 0;
$ItemMax[lfemale, BaseOpsPack] = 0;
$ItemMax[marmor, BaseOpsPack] = 1;
$ItemMax[mfemale, BaseOpsPack] = 1;
$ItemMax[harmor, BaseOpsPack] = 1;

ItemImageData BaseOpsPackImage
{
        shapeFile = "shieldPack";
        mountPoint = 2;
        firstPerson = false;
};

ItemData BaseOpsPack // Borg cube Pack
{
        description = "The Borg Cube";
        shapeFile = "logo";
        className = "Backpack";
        heading = "lDeployables";
        imageType = BaseOpsPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 9950;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

StaticShapeData DeployableBaseOps // Main Borg cube panel...
{
        className = "DeployableBaseOps";
        damageSkinData = "objectDamageSkins";
        shapeFile = "elevator6x6thin";
        maxDamage = 500;
        maxEnergy = 200;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,1.0,1.0};
        side = "single";
        isTranslucent = false;
};

StaticShapeData BaseOpsGenerator
{
        className = "BaseOpsGenerator";
        damageSkinData = "objectDamageSkins";
        shapeFile = "generator";
        maxDamage = 0.5;
        maxEnergy = 500;
        sfxAmbient = SoundGeneratorPower;
        mapFilter = 2;
        visibleToSensor = true;
        explosionId = mortarExp;
        debrisId = flashDebrisLarge;
        lightRadius = 12.0;
        lightType=2;
        lightColor = {1.0,0.2,0.2};
        mass=2.5;
};


function BaseOpsGenerator::onDestroyed(%this)
{
        BaseOpsGenerator::onDisabled(%this);
        %team=GameBase::getTeam(%this);
        %set=nameToID("MissionCleanup/BaseOps!"@%team);
        if(%set!=-1)
        {
                DeployableBaseOps::onDestroyed(Group::getObject(%set,0));
        }
}

function BaseOpsGenerator::onEnabled(%this)
{
        BaseOpsGenerator::setActive(%this,true);
}

function BaseOpsGenerator::onDisabled(%this)
{
        GameBase::stopSequence(%this,0);
        DeployableBaseOps::setPower(GameBase::getTeam(%this),0);
}

function BaseOpsGenerator::setActive(%this)
{
        GameBase::playSequence(%this,0,"power");
        DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}

function BaseOpsGenerator::onActivate(%this)
{
        GameBase::playSequence(%this,0,"power");
        DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}

function DeployableBaseOps::Destruct(%this)
{
        DeployableBaseOps::doDamage(%this);
}

function DeployableBaseOps::doDamage(%this)
{
        calcRadiusDamage(%this, $DebrisDamageType, 5, 1, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function DeployableBaseOps::powerState(%this)
{
        %team=GameBase::getTeam(%this);
        %set=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
        if(%set!=-1)
        {
                %obs=Group::objectCount(%set);
                %gen=-1;
                %obj=-1;
                for(%x=0;%x<%obs;%x++) {

               %objt=Group::getObject(%set,%x);
                if(%objt==%this)
                {
                        %obj=%objt;
                }
                if(GameBase::getDataName(%objt)=="BaseOpsGenerator") %gen=%objt;
        }
        if(%obj!=-1&&%gen!=-1)
        {
                if(GameBase::getDamageState(%gen)!="Enabled")
                {
                        return 0;
                }
                else
                {
                        return 1;
                }
        }
}
return 0;
}

function DeployableBaseOps::onDestroyed(%this)
{
        DeployableBaseOps::doDamage(%this);
        %team=GameBase::getTeam(%this);
        %set1=nameToID("MissionCleanup/BaseOps!"@%team);
        %set2=nameToID("MissionCleanup/BaseOpsX!"@%team);
        %set3=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
        if(%set1!=-1&&%set2!=-1&&%set3!=-1)

        {
                $TeamItemCount[%team @ "DeployableBaseOps"]--;
                if(%this==Group::getObject(%set1,0))
                {
                        %objs=group::objectcount(%set1);
                        for(%x=0;%x<%objs;%x++)
                        {
                                %obj=Group::getObject(%set1,%x);
                                schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
                                if(GameBase::getMapName(%obj)=="Borg Cube") schedule("$TeamItemCount["@%team@"@\"DeployableBaseOps\"]=0;",20);
                        }
                        deleteObject(%set1);
                        %objs=group::objectcount(%set3);
                        for(%x=0;%x<%objs;%x++)
                        {
                                %obj=Group::getObject(%set3,%x);
                                schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
                        }
                        deleteObject(%set1);
                        %objs=group::objectcount(%set2);
                        for(%x=0;%x<%objs;%x++)
                        {
                                %obj=Group::getObject(%set2,%x);
                                schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
                        }
                        deleteObject(%set2);
			}
				else
      		{
		      GameBase::setDamageLevel(Group::getObject(%set1,0),10000);
      	}
	}
}

function DeployableBaseOps::onCollision(%this,%obj)
{
        return;
}

function BaseOpsPack::onUse(%player,%item)
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

function BaseOpsPack::onDeploy(%player,%item,%pos)
{
        if (BaseOpsPack::deployShape(%player,"Borg Cube",DeployableBaseOps,%item))
        {
        Player::decItemCount(%player,%item);
        $TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"]++;
        }
}

function CreateBaseOpsimSet(%team)
{
        %teleset = nameToID("MissionCleanup/BaseOps!"@%team);
        if(%teleset == -1)
        {
                newObject("BaseOps!"@%team,SimSet);
                addToSet("MissionCleanup","BaseOps!"@%team);
        }
        %teleset = nameToID("MissionCleanup/BaseOpsX!"@%team);
        if(%teleset == -1)
        {
                newObject("BaseOpsX!"@%team,SimSet);
                addToSet("MissionCleanup","BaseOpsX!"@%team);
        }
        %teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
        if(%teleset == -1)
        {
                newObject("BaseOpsX!"@%team@"!Powered",SimSet);
                addToSet("MissionCleanup","BaseOpsX!"@%team@"!Powered");
        }
}

function DeployableBaseOps::setPower(%team,%power)
{
        %teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
        if(%teleset != -1)
        {
                %objs=Group::objectCount(%teleset);
                if(%objs)
                {
                        for(%x=0;%x<%objs;%x++)
                        {
                                %obj=Group::getObject(%teleset,%x);
                                if(GameBase::getMapName(%obj)=="Borg Cube Inventory Station"
                                || GameBase::getMapName(%obj)=="Borg Cube Ammo Station"
                                || GameBase::getMapName(%obj)=="Borg Cube Command Station") {
                                if(GameBase::getDamageState(%obj)!="Disabled")
                                {
                                        Station::onPower(%obj,%power,0);
                                }
                                else
                                {
                                        Station::onPower(%obj,0,0);
                                }
                        }
                        else if(GameBase::getMapName(%obj)=="Borg Cube External Defense Turret")
                        {
                                GameBase::setActive(%obj,%power);
                                if(GameBase::getDamageState(%obj)!="Disabled")
                        {
                                if (%power)
                                {
                                        %obj.shieldStrength = 0.03;
                                        GameBase::setRechargeRate(%obj,10);
                                        GameBase::playSequence(%obj,0,"power");
                                }
                                else
                                {
                                        %this.shieldStrength = 0;
                                        GameBase::setRechargeRate(%obj,0);
                                        GameBase::StopSequence(%obj,0);
                                }
                                GameBase::setActive(%this,%power);
                                }
                                else
                                {
                                        GameBase::StopSequence(%obj,0);
                                }
                        }
                        else
                        {
                        }
                }
        }
}
}

function BaseOpsPack::deployShape(%player,%name,%shape,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"] < $TeamItemMax[DeployableBaseOps]) {
        if (GameBase::getLOSInfo(%player,3))
        {
                %obj = getObjectType($los::object);
                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                {
                        %team=GameBase::getTeam(%player);
                        CreateBaseOpsimSet(%team);
                        %rot="0 0 0";
                        %opos=Vector::add($los::position,"0 0 5");

                        //Borg Cube Start
                        %sensor = newObject("RBOCL1T0","StaticShape",%shape,true);
                        %pos=Vector::add(%opos,"0 0 0");

                        addToSet("MissionCleanup", %sensor);
                        GameBase::setTeam(%sensor,%team);
                        GameBase::setRotation(%sensor,%rot);

                       %rtime=(floor(getRandom()*150)/10);
                        GameBase::setPosition(%sensor,%pos);
                        GameBase::startFadeIn(%sensor);
                        Gamebase::setMapName(%sensor,%name);

                        %dcont=1;
                        for(%z=0;%z<10;%z++)
                        {
                                %tpos=Vector::add(%opos,"0 0 "@%z);
                                GameBase::setPosition(%sensor,%tpos);
                                for(%x=0;%x<360;%x+=5)
                                {
                                        %rad=(%x/180)*3.141592654;
                                        %rpos="0 0 "@%rad;
                                        if(GameBase::getLOSInfo(%sensor,14,%rpos)!=False)
                                        {
                                                %dcont=0;
                                                break;
                                        }
                                }
                                if(%dcont) %z++;
                        }
                        if(!%dcont)
                        {
                                GameBase::setPosition(%sensor,"-2000,-2000,-2000");
                                GameBase::setDamageLevel(%sensor,10000);
                                Client::sendMessage(%client,0,"Cannot build Borg Cube.  Object(s) in way.");
                                return false;
                        }
                        %opos=%tpos;
                        addToSet("MissionCleanup/BaseOps!"@%team, %sensor);
                        echo("Final Deployment Position:  "@%opos);

                        //Inventory Station
                        %sensor = newObject("Inventory1","StaticShape",InventoryStation,true);
                        %pos=Vector::add(%opos,"6.863 6.844 6.496");
                        addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
                        addToSet("MissionCleanup", %sensor);
                        GameBase::setTeam(%sensor,%team);
                        GameBase::setRotation(%sensor,"0 -0 -0.752468");
                        %rtime=(floor(getRandom()*150)/10);
                        schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
                        schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
                        Gamebase::setMapName(%sensor,%name@" Inventory Station");

//Command Station
%sensor = newObject("Command1","StaticShape",CommandStation,true);
%pos=Vector::add(%opos,"7.458 -7.435 6.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -2.37301");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Command Station");

//Ammo Station
%sensor = newObject("Ammo1","StaticShape",AmmoStation,true);
%pos=Vector::add(%opos,"7.015 -6.949 0.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -2.34776");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Ammo Station");


//Internal Defense Turret
%sensor = newObject("IDT","Turret",DeployableTurret,true);
%pos=Vector::add(%opos,"-7.459 7.344 0.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 0.803911");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Internal Defense Turret");

//External Defense Turret
%sensor = newObject("EDT","Turret",FusionTurret,true);
%pos=Vector::add(%opos,"0 5 12.498");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 0 0");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" External Defense Turret");

//External Defense Turret 2
%sensor = newObject("EDT2","Turret",FusionTurret,true);
%pos=Vector::add(%opos,"0 -5 12.498");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 0 1.57");
%rtime=(floor(getRandom()*150)/10);

schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" External Defense Turret");

//Generator
%sensor = newObject("Generator1","StaticShape",MobileGen,true);
%pos=Vector::add(%opos,"-5.909 6.186 6.495");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -0.0219599");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Generator");
GameBase::setActive(%sensor,True);

//Self-destruct key
%sensor = newObject("Generator1","StaticShape",BaseOpsGenerator,true);
%pos=Vector::add(%opos,"-5.909 6.186 6.495");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -0.0219599");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Generator");
GameBase::setActive(%sensor,True);

//The Walls
//Wall
%sensor = newObject("RBOCL1T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1T8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 0 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);

schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 -6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);

addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);

addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 0 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));

%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);

Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 -6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W10","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL1W11","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);


%sensor = newObject("RBOCL2W0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 0 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 -6 9");

addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W4","StaticShape",BorgWindow,true);
%pos=Vector::add(%opos,"6 8.5 7");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 0 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 -6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W10","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL2W11","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);


////////
/////////
/////////
/////////

%sensor = newObject("RBOCL3T0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);

GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

%sensor = newObject("RBOCL3T8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);

                        Client::sendMessage(%client,0,%item.description @ " under construction. 15 seconds to completion.");
                        echo("Borg Cube Deployed Deployed ("@%sensor@")");
                        playSound(SoundPickupBackpack,$los::position);
                        GameBase::startfadein(%sensor);
                        return true;

                       }
                        else
                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else
                Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
        return false;
}

StaticShapeData BorgWindow // closest to 6x6, but no 6x6 forcefield
{
        shapeFile = "forcefield_5x5";
        debrisId = defaultDebrisSmall;
        maxDamage = 450.0;
        isTranslucent = true;
   description = "Borg Cube Window";
};

function DeployDrone(%player,%item,%shape,%data,%name)
{
 %client = Player::getClient(%player);
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %obj = newObject(%name,%data,%shape,true);
   if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
    {
		centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
		deleteObject(%obj);
		return;
	}
   addToSet("MissionCleanup",%obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,$los::position);
   GameBase::setRotation(%obj,%rot);
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,%name@" Deployed ");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   Client::setControlObject(%client,%obj);
   %player.vehicle = %obj;
   $TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 return false;
}

function DeployDrone(%player,%item,%shape,%data,%name)
{
 %client = Player::getClient(%player);
 if(GameBase::getLOSInfo(%player,3))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
   %rot = GameBase::getRotation(%player);
   %obj = newObject(%name,%data,%shape,true);
   if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
    {
		centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
		deleteObject(%obj);
		return;
	}
   addToSet("MissionCleanup",%obj);
   GameBase::setTeam(%obj,GameBase::getTeam(%player));
   GameBase::setPosition(%obj,$los::position);
   GameBase::setRotation(%obj,%rot);
   Gamebase::setMapName(%obj,%name);
   Client::sendMessage(%client,0,%name@" Deployed ");
   GameBase::startFadeIn(%obj);
   playSound(SoundPickupBackpack,$los::position);
   Client::setControlObject(%client,%obj);
   %player.vehicle = %obj;
   $TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
   return true;
   }
   else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
   }
  else Client::sendMessage(%client,0,"Deploy position out of range");
 return false;
}

function ItemBusy(%this)
{        %this.isbusy=true;
}

function ItemNotBusy(%this)
{        %this.isbusy=false;
}

//Shield node Connection objects
$ObjType[0]="DeployableTurret";
$ObjType[1]="VELCROTurret";
$ObjType[2]="GROGTurret";
$ObjType[3]="Fluxturret";
$ObjType[4]="RocketTurret";
$ObjType[5]="PlasmaTurret";
$ObjType[6]="FusionTurret";
$ObjType[7]="AATurret";
$ObjType[8]="ELFTurret";
$ObjType[9]="IndoorTurret";
$ObjType[10]="ArtilleryTurret";
$ObjType[11]="DisruptorTurret";
$ObjType[12]="IonTurret";

// ForceFields
$ObjType[13]="BlastFloorShape";
$ObjType[14]="doorfivebyfiveForceFieldShape";
$ObjType[15]="doorfourbyeightForceFieldShape";
$ObjType[16]="BlastDoorShape";

// Other Static Objects
$ObjType[17]="PulseSensor";
$ObjType[18]="Generator";
$ObjType[19]="SolarPanel";
$ObjType[20]="DeployableRocket";
$ObjType[21]="CloakingNode";

$ObjType[22]="VehiclePad";
$ObjType[23]="ShieldGen";
$ObjType[24]="JumpPad";
$ObjType[25]="MobileGen";
$ObjType[26]="MobileInvent";
$ObjType[27]="InventoryStation";
$ObjType[28]="Teleporter";
$ObjType[29]="TeleporterNode";
$ObjType[30]="DeployableTeleport";
$ObjType[31]="AntiTurret";
$ObjType[32]="DiscTurret";
$ObjType[33]="PulseTurret";
$ObjType[34]="PortaC";

$ObjType[35]="MobileBunker";
$ObjType[36]="PortGenerator";
$ObjType[37]="AmmoStation";
$ObjType[38]="DeployableAmmoStation";
$ObjType[39]="DeployableInvStation";
$ObjType[40]="CommandStation";
$ObjType[41]="VehicleStation";

function GetNumObjects(%set,%type,%tnum)
{        if(%tnum==0)
                return (0);
        if(%type==4)
                return(0);

        if(%type==1)        //        Turrets only
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[0],%tnum);
                %num+=CountObjects(%set,$ObjType[1],%tnum);
                %num+=CountObjects(%set,$ObjType[2],%tnum);
                %num+=CountObjects(%set,$ObjType[3],%tnum);
                %num+=CountObjects(%set,$ObjType[4],%tnum);
                %num+=CountObjects(%set,$ObjType[5],%tnum);
                %num+=CountObjects(%set,$ObjType[6],%tnum);
                %num+=CountObjects(%set,$ObjType[7],%tnum);
                %num+=CountObjects(%set,$ObjType[8],%tnum);
                %num+=CountObjects(%set,$ObjType[9],%tnum);
                %num+=CountObjects(%set,$ObjType[10],%tnum);
                %num+=CountObjects(%set,$ObjType[11],%tnum);
                %num+=CountObjects(%set,$ObjType[12],%tnum);
                return (%num);
        }
        else if(%type==2)        // Forcefields Only
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[13],%tnum);

               %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                return (%num);
        }

        else if(%type==3)        // Forcefields & Static Objects
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[13],%tnum);
                %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                %num+=CountObjects(%set,$ObjType[17],%tnum);
                %num+=CountObjects(%set,$ObjType[18],%tnum);
                %num+=CountObjects(%set,$ObjType[19],%tnum);
                %num+=CountObjects(%set,$ObjType[20],%tnum);
                %num+=CountObjects(%set,$ObjType[21],%tnum);
                %num+=CountObjects(%set,$ObjType[22],%tnum);
                %num+=CountObjects(%set,$ObjType[23],%tnum);
                %num+=CountObjects(%set,$ObjType[24],%tnum);
                %num+=CountObjects(%set,$ObjType[25],%tnum);
                %num+=CountObjects(%set,$ObjType[26],%tnum);
                %num+=CountObjects(%set,$ObjType[27],%tnum);

                %num+=CountObjects(%set,$ObjType[28],%tnum);
                %num+=CountObjects(%set,$ObjType[29],%tnum);
                %num+=CountObjects(%set,$ObjType[30],%tnum);
                %num+=CountObjects(%set,$ObjType[31],%tnum);

               %num+=CountObjects(%set,$ObjType[32],%tnum);
                %num+=CountObjects(%set,$ObjType[33],%tnum);
                %num+=CountObjects(%set,$ObjType[34],%tnum);
                %num+=CountObjects(%set,$ObjType[35],%tnum);
                %num+=CountObjects(%set,$ObjType[36],%tnum);
                %num+=CountObjects(%set,$ObjType[37],%tnum);
                %num+=CountObjects(%set,$ObjType[38],%tnum);
                %num+=CountObjects(%set,$ObjType[39],%tnum);
                %num+=CountObjects(%set,$ObjType[40],%tnum);
                %num+=CountObjects(%set,$ObjType[41],%tnum);

                return(%num);
        }
        else if(%type==0)
        {        %num=0;
                %num+=CountObjects(%set,$ObjType[0],%tnum);
                %num+=CountObjects(%set,$ObjType[1],%tnum);
                %num+=CountObjects(%set,$ObjType[2],%tnum);
                %num+=CountObjects(%set,$ObjType[3],%tnum);
                %num+=CountObjects(%set,$ObjType[4],%tnum);
                %num+=CountObjects(%set,$ObjType[5],%tnum);
                %num+=CountObjects(%set,$ObjType[6],%tnum);
                %num+=CountObjects(%set,$ObjType[7],%tnum);
                %num+=CountObjects(%set,$ObjType[8],%tnum);
                %num+=CountObjects(%set,$ObjType[9],%tnum);
                %num+=CountObjects(%set,$ObjType[10],%tnum);
                %num+=CountObjects(%set,$ObjType[11],%tnum);
                %num+=CountObjects(%set,$ObjType[12],%tnum);
                %num+=CountObjects(%set,$ObjType[13],%tnum);
                %num+=CountObjects(%set,$ObjType[14],%tnum);
                %num+=CountObjects(%set,$ObjType[15],%tnum);
                %num+=CountObjects(%set,$ObjType[16],%tnum);
                %num+=CountObjects(%set,$ObjType[17],%tnum);
                %num+=CountObjects(%set,$ObjType[18],%tnum);
                %num+=CountObjects(%set,$ObjType[19],%tnum);
                %num+=CountObjects(%set,$ObjType[20],%tnum);
                %num+=CountObjects(%set,$ObjType[21],%tnum);
                %num+=CountObjects(%set,$ObjType[22],%tnum);
                %num+=CountObjects(%set,$ObjType[23],%tnum);
                %num+=CountObjects(%set,$ObjType[24],%tnum);
                %num+=CountObjects(%set,$ObjType[25],%tnum);
                %num+=CountObjects(%set,$ObjType[26],%tnum);
                %num+=CountObjects(%set,$ObjType[27],%tnum);
                %num+=CountObjects(%set,$ObjType[28],%tnum);
                %num+=CountObjects(%set,$ObjType[29],%tnum);
                %num+=CountObjects(%set,$ObjType[30],%tnum);

               %num+=CountObjects(%set,$ObjType[31],%tnum);
                %num+=CountObjects(%set,$ObjType[32],%tnum);
                %num+=CountObjects(%set,$ObjType[33],%tnum);

                %num+=CountObjects(%set,$ObjType[34],%tnum);
                %num+=CountObjects(%set,$ObjType[35],%tnum);
                %num+=CountObjects(%set,$ObjType[36],%tnum);
                %num+=CountObjects(%set,$ObjType[37],%tnum);
                %num+=CountObjects(%set,$ObjType[38],%tnum);
                %num+=CountObjects(%set,$ObjType[39],%tnum);
                %num+=CountObjects(%set,$ObjType[40],%tnum);
                %num+=CountObjects(%set,$ObjType[41],%tnum);

                return(%num);
        }
}

function ConnectGenerator (%this,%client)
{	if($TracePwr) echo("Connect this ",%this," Generator to Power Grid (Client = ",%client,")");
	if(%this.isBusy)
		return;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);

	if(GameBase::getDamageState(%this)!="Enabled")
	{	echo("Backup Generator ",%this," is disabled!!");
		TeamMessages(0,%team,%name@" DIS-ABLED Unable to come ON Line...~wAAODSFX50.wav");
		return;
	}

	%range = %this.pRange;
	ItemBusy(%this);
	%team = GameBase::getTeam(%this);
	echo("Connecting Generator for Team ",%team);
	echo("Connecting Generator for Client ",$User[%client]);

	
	if(%this.pset)
	{	// Generator has a powerset....refresh it
		%pset=%this.pset;
		if($tracePwr) echo("Generator ",%this," has a power set (",%pset,") ....Refreshing");
	}
	else	// Generator does not have a powerset Create one & refresh it
	{	%pset=MakePowerSet(%this);
		%this.powerset=getGroup(%this);
		removeFromSet(%this.powerset,%this);
		addtoSet(%pset,%this);
		%this.pset=%pset;
	}
	// Scan for Items to Power
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set,$StaticObjectType | $StaticShapeType ,%pos,%range,%range,%range,0);
	%td=0;
	if (%tnum>0)
	{	// There are Items within scan range
		if($tracePwr) echo($Ver,"| Generator Checking ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(PowerReq(%tgt))									// Does Item Require Power then check otherwise don't Bother
			{	if(%team==%tgtTeam)								// Is it of the Same Team
				{	if (!GameBase::isPowered(%tgt))				// Has NO Power so Connect to it!
					{	%td+=3;									// Time to hookup = 3 Sec
						if(%tgt.powerSet=="")					// This Item has Not Been previously Connected to a Portable Generator
						{	%tgt.powerSet=getGroup(%tgt);			// If it Had Power Remeber where it Was from
						}
						if($tracePwr) echo($Ver,"|Item Has No Power - Removing from Old group ",%tgt.powerSet," adding to ",%pset);
						schedule("PowerSet("@%this@","@%tgt@");",%td);
					}
				}
			}			
		}
	}
	deleteObject(%set);
	schedule("ItemNotBusy("@%this@");",%td);
	if (%td==0)
	{	if(%client)
			Client::SendMessage(%client,1,"Backup power grid Initialized");
		return (false);
	}
	else
		TeamMessages(0,%team,%name@" coming ON Line...~wAAODSFX50.wav");
	return (true);
}

function DisconnectGenerator(%this)	
{	if($TracePwr) echo("Disconnecting this ",%this," Generator from Power Grid");
	//	Use when Packing up a Power Generator
	//	& End of Mission 
	//	Unhooks everything
	ItemBusy(%this);
	%pset=%this.pset;
	%name=GameBase::GetMapName(%this);
	if(!%name)
		%name=GameBase::GetDataName(%this);
	%team = GameBase::getTeam(%this);
	%tnum = Group::objectCount(%pset);
	TeamMessages(1,%team,%name@" Going OFF Line...~wAAODSFX50.wav");
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%pset,0);
			%td+=2;
			schedule("PowerReset("@%this@","@%tgt@");",%td);
		}
	}
	%td+=1;
	schedule("deleteObject("@%pset@");",%td);
	schedule("ItemNotBusy("@%this@");",%td,%this);
	return (%td);
}


function PowerReq(%this)
{	
	%name=GameBase::GetDataName(%this);
	if(%this.powerReq==1) 
		return true;
	else if(%this.powerReq==false) 
		return false;
	else if(%name.classname == "Turret" || %name.classname == "Station" || %name=="PulseSensor" )
		return (true);
	else
		return (false);
}

function RecheckGrid(%this)
{	if($TracePwr) echo("RE-Connect this ",%this," Generator to Power Grid ");
	// Call When Main Power Source has come back online after a failure
	%mset=getGroup(%this);
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," Back on line .. re-routing power from ",%tnum," alternate Generators for Team ",%team);
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject($GenSet[%team],%i);
			%num = Group::objectCount(%tgt.pset);
			if(%num>1)	// If it has more than one object the unit is powering something
			{	for (%j=0;%j<%num;%j++)
				{	%tgt2=Group::getObject(%tgt.pset,%j);
					if(%tgt2.powerset==%mset)	// Object belong in the Power Set for %this which was just restored
					{	removeFromSet(%tgt.pset,%tgt2);
						addToSet(%mset,%tgt2);
						%j--;
						%num--;
					}
				}
			}
		}
	}
}

function EngageBackupPower(%this)
{	if($tracePwr) echo("Engage Backup Power for this ",%this," Generator (It has Been Destroyed or Disabled)");
	%NumFF=0;
	// Call When Main Power has Experienced a failure
	// Check Main Generator Group... If Multiple generators Then Dont Engage Backup
	%Mainset=getGroup(%this);
	%MainNum = Group::objectCount(%MainSet);
	if($tracePwr) echo("Generator Group = ",%MainSet," Number of Items in Group ",%MainNum);
	for (%i=0;%i<%MainNum;%i++)
	{	%tgt=Group::getObject(%MainSet,%i);
		%name = GameBase::getDataName(%tgt);
		%type = GetObjectType(%tgt);
		// if(%name=="" && %type == SimGroup) %name="DoorGroup";
		if($tracePwr) echo("Checking Item ",%tgt," Item is: ",%Name," Class = ",%name.className," type ",%type);
		if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
		{	%result=GameBase::getDamageState(%tgt);	
			if(%result==Enabled) %NotReq=True;
		}
		else if(%name=="DoorGroup" || %name.classname == "ForceDoor" || %name.classname == "Door" || %name.classname == "ForceField")
		{	if($TracePwr) echo("Re-Routing ForceField Power for ",%name," Id# ",%tgt);
			%ForceField[%NumFF]=%tgt;
			%NumFF++;
		}
		if(%NotReq==true) %i=%MainNum;
	}

	if(%NotReq) return;
	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($GenSet[%team]);
	if ($tracePwr) echo($ver,"| Main Gen ",%this," FAILURE .. ",%tnum," alternate Generators re-checking Grid ",%team);
	%td=0;
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%td+=2;
			%tgt=Group::getObject($GenSet[%team],%i);
			// ForceField Reconnect Routine
			// First Active Generator Gets the ForceFields
			%result=GameBase::getDamageState(%tgt);	
			if(GameBase::getDamageState(%tgt) == "Enabled")
			{	for (%j=0;%j<%NumFF;%j++)
				{	%ff=%ForceField[%j];
					%ff.powerSet=getGroup(%ff);			// Remember where it Was from
					PowerSet(%tgt,%ff);
					//schedule("PowerSet("@%tgt@","@%ff@");",5,%ff);
					if ($tracePwr) echo($ver,"| Routing Power for ",%ff," Forcefield to ",GetGroup(%tgt));
					
				}
			}
			schedule("ConnectGenerator("@%tgt@", false);",%td);
		}
	}
}

function MakePowerSet(%this)
{	%SetName ="PG"@%this;
	%pset= newObject(%SetName,SimGroup);
	addToSet("MissionCleanup", %pset);
	if($tracePwr) echo("Created NEW power set (",%pset,") for Generator ",%this);
	return(%pset);
}

function Powerset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")							
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	TeamMessages(0,%team,"Power for "@%mname@" routed to: "@%gname@"~wAAODSFX52.wav");
	%OldSet=getGroup(%object);
	RemoveFromSet(%OldSet,%object);
	%res=AddToSet(%pset,%object);
	if ($tracePwr) echo("Power for "@%object@" routed to power group "@%pset@" generator "@%gen@" for Team ",%team);
}

function Powerreset(%gen,%object)
{	%gname=GameBase::GetMapName(%gen);
	if(!%gname)
		%gname=GameBase::GetDataName(%gen);
	%pset=%gen.pset;
	%mname = GameBase::getMapName(%object);
	if(%mname=="")							
		%mname = GameBase::getDataName(%object);
	%team=GameBase::getTeam(%gen);
	if(%object.powerReq!=2)
		TeamMessages(0,%team,"Power for "@%mname@" disconnected from "@%gname@"~wAAODSFX52.wav");
	removeFromSet(%pset,%object);
	%res=addToSet(%object.powerSet,%object);
	if ($tracePwr) echo("Power for ",%object," set to orignal group ",%object.powerSet," from  generator ",%gen," for Team ",%team);
}


function PowerItem (%this,%range,%client)
{	if($TracePwr) echo($ver,"|Looking for POWER for ",%this," in a ",%range," meter area");
	//** Search Area within specified range
	//** If a Main Generator exists Draw power from that
	//** If a portable generator exists Place %this into the power set for it..
	%numGen=0;
	%team = GameBase::getTeam(%this);
	%set = newObject("set",SimSet);
	%pos =	GameBase::getPosition(%this);
	%tnum = containerBoxFillSet(%set, $StaticObjectType ,%pos,%range,%range,%range,0);
	echo(" Number of Objects Found = ",%tnum);
	if (%tnum>0)
	{	// There are Items within scan range
		if($trace) echo($Ver,"|Scanning ",%tnum," items");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			%name = GameBase::getDataName(%tgt);
			if(%team==%tgtTeam)	
			{	if(%name == "Generator" || %name == "SolarPanel" || %name == "PortGenerator")
				{	%nset=getGroup(%tgt);
					if(GameBase::getDamageState(%tgt) == "Enabled")
					{	Client::sendMessage(%client,1,"Main Power connection found..connecting~wAAODSFX16.wav");
						if($tracePwr) echo($Ver,"| Found MAIN Generator : Group ",%nset," Placing Unit in Group");	
						// %power=true;
						if(%nset)
						{	addToSet(%nset,%this);
							%this.powerset=%nset;
							%i=%tnum;
						}
						%numGen++;
					}
					else if(%nset) %this.powerset=%nset;	// Route Main Connection to Main Power Group...

				}
				else if(%name == "MobileGen" || %name == "PortaSolar" || %name == "PowerNode")
				{	if($tracePwr) echo($Ver,"|Found an alternate Power Source.. if needed ",%tgt);

				%Pgen=%tgt;	
				}
					
			}
			
		}
	}
	deleteObject(%set);
	if (%numGen==0)										// If there are No Main Generators to connect to... then
	{	if(%Pgen)										// If there is a portable Power Source connect to it
		{	if($trace) echo($Ver,"|Found a Secondary power Generator ",%PGen," Connecting to it");
			Client::sendMessage(%client,1,"Secondary Power connection found..connecting");
			%result=GameBase::getDamageState(%Pgen);	// Check state of Generator
			%nset=getGroup(%Pgen);
			if(%nset)
				addToSet(%nset,%this);
			//if(%result==Enabled)
				// %power=true;
			//else
				// %power=false;
			// GameBase::virtual(%this,"onPower",%power,%Pgen);
			return (true);
		}
		else
		{	Client::sendMessage(%client,1,"Unable to obtain Power!! Too far from any power generators!!~werror_message.wav");
			return (false);
		}

	}
	return (true);
}

