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
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "Turret" || %obj =="sensor" || %obj == "StaticShape")
			{	
%set = newObject("set",SimSet);
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
							Client::sendMessage(%client,3,"Remote Shield Node deployed - Shield activated on: "@%name);
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
					{	Client::sendMessage(%client,0,"Nothing to interface to. Node Must be placed close to an object which will have its shield boosted.~werror_message.wav");}
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
	%this.shieldStrength = 0.3;
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
                        if ((%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor"  || %obj ==  "BlastDoorShape" || %obj ==  "BlastFloorShape" || %obj == "doorfivebyfiveForceFieldShape" || %obj == "doorthreebyfourForceFieldShape" || %obj == "doorfourbyeightForceFieldShape" || %obj == "TowerSwitch")) {
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


//----------------------------------------------------------------------------

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
					%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				$TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
				Player::decItemCount(%player,%item);
                          }

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
maxDamage = 2.5;
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
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
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
				%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				$TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
				Player::decItemCount(%player,%item);

                          }


                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfourbyeightForceFieldPack","StaticShape",doorfourbyeightForceFieldShape,true);
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
maxDamage = 35.0;
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
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
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

            if (GameBase::getLOSInfo(%player,8)) 
		{
				%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				$TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoor"]++;
				Player::decItemCount(%player,%item);

                          }
	



                      %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

				%zRot = getWord(%rot, 2);
				if (Vector::dot($los::normal, "0 0 1") > 0.6)
				 {
					%rot = "0 0 " @ %zRot;
				 }
				else
				 {
					if (Vector::dot($los::normal, "0 0 -1") > 0.6)
					 {
						%rot = "3.14159 0 " @ %zRot;
					 } 
					else
					 {
						%rot = Vector::getRotation($los::normal);
					 }
				 }

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
                                        Player::decItemCount(%player,%item);
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
        maxDamage = 70;
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
        $TeamItemCount[GameBase::getTeam(%this) @ "BlastDoor"]--;
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
				%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				$TeamItemCount[GameBase::getTeam(%camera) @ "BlastFloorShape"]++;
				Player::decItemCount(%player,%item);

                          }

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
        maxDamage = 45;
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
        $TeamItemCount[GameBase::getTeam(%this) @ "BlastFloor"]--;
}

//--------------------------------------------------------------------------------------------------------
// Teleport Pads - Shane Hyde
//--------------------------------------------------------------------------------------------------------



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
        description = "Teleport Pad";
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

//-------------------------------
// ******* Mobile Generator *****
//-------------------------------

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
	shapeFile		= "generator_p";
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
	shapeFile			= "generator_p";
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
	Bottomprint(%client, "<jc><f1>Any team member within <f2>300m<f1> will have their energy regeneration boosted significantly.  Great for base defense,<f0> Also adds shields to any team member in the radius, as well as adding an autorepair element to these players!");
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
	if (DShieldPack::deployShape(%player,"Enhancement Beacon",DShield,%item)) 
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
								Client::sendMessage(%client,3,%item.description @ " deployed ~wshieldhit.wav");
								playSound(SoundPickupBackpack,$los::position);
								Client::sendMessage(%client,3,%item.description @ " initializing flux.");
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
				if (%dist<302)
				{
					if ($oldShieldGen[%matrix]==0)
					{
						GameBase::setRechargeRate(%obj, 16);
						GameBase::setAutoRepairRate(%obj, 0.33);
						client::sendMessage(%clientId,3,"Enhancement Beacon #" @ %this @ " active and enhancing.");
						%obj.shieldStrength = 0.001;
						$oldShieldGen[%matrix]=1;
					}
				}
				else if($oldShieldGen[%matrix]==1)
				{
						GameBase::setRechargeRate(%obj, 8);
						GameBase::setAutoRepairRate(%obj, 0.00);
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
//------------------------------------
// ******* Portable Launch Pad *******
// -----------------------------------



StaticShapeData AccelPadPack
{
className = "AccelPadPack";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator_6x6_octagon";
maxDamage = 10.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = debrisExpLarge;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = false;
};
function AccelPadPack::Destruct(%this)
{
AccelPadPack::doDamage(%this);
}
function AccelPadPack::doDamage(%this) {
}
function AccelPadPack::onDestroyed(%this)
{
AccelPadPack::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "AccelPadPack"]--;
}
function AccelPadPack::onCollision(%this,%obj)
{
if(getObjectType(%obj) != "Player") {return;}
if(Player::isDead(%obj)) {return;}
%c = Player::getClient(%obj);
%pteam = GameBase::getTeam(%obj);
%oteam = GameBase::getTeam(%this);
%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
%tpos=GameBase::getPosition(%this);
%opos=GameBase::getPosition(%obj);
%tstartX=getWord(%tpos,0);
%tstartY=getWord(%tpos,1);
%tstartZ=getWord(%tpos,2);
%ostartX=getWord(%opos,0);
%ostartY=getWord(%opos,1);
%ostartZ=getWord(%opos,2);
%diffX=%ostartX-%tstartX;
%diffY=%ostartY-%tstartY;
%diffZ=%ostartZ-%tstartZ;
if(%pteam==%oteam) {
if(%obj.deployStandby!=1) {
if(%diffZ>0.950) {
%obj.deployStandby=1;
%msg="<jc><f1>Jump Pad CPU: <f0>Face the direction you want to go, then jump or use your jets to thrust.  You may walk off the platform to avoid being thrusted.";
remoteEval(%c, "BP", %msg, 0);
AccelPadPack::CheckPlayer(%this,%obj);
}
} else if(%diffZ<0.950) {
remoteEval(%c, "CP", "", 0);
%obj.deployStandby=0;
}
}
return;
}
function AccelPadPack::CheckPlayer(%this,%obj) {
%tpos=GameBase::getPosition(%this);
%opos=GameBase::getPosition(%obj);
%tstartX=getWord(%tpos,0);
%tstartY=getWord(%tpos,1);
%tstartZ=getWord(%tpos,2);
%ostartX=getWord(%opos,0);
%ostartY=getWord(%opos,1);
%ostartZ=getWord(%opos,2);
%diffX=%ostartX-%tstartX;
%diffY=%ostartY-%tstartY;
%diffZ=%ostartZ-%tstartZ-0.92;
%deploy=0;
%recall=1;
if(%diffZ>0.5) %deploy=1;
if(%diffZ<0) %deploy=-1;
%client=Player::getClient(%obj);
if(%deploy>0) {
%armor=GameBase::getDataName(%obj);
%mass=%armor.mass;
%rot=GameBase::getRotation(%obj);
%len=50;
%zlen=50;
%rnd=floor(getrandom()*30);
if(%rnd>24 && %rnd<29) {
playSound(debrisMediumExplosion,%tpos);
%len+=15;
%zlen+=20;
} else if(%rnd>28) {
playSound(debrisLargeExplosion,%tpos);
%len+=200;
%zlen+=220;
} else {
playSound(debrisSmallExplosion,%tpos);
}
%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
Player::applyImpulse(%obj,%vec);
schedule(%obj@".deployStandby=0;",0.1);
%recall=0;
} else if(%deploy<0) {
%recall=0;
%obj.deployStandby=0;
}
if(%recall) {
schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
} else {
remoteEval(%client, "CP", "", 0);
}
}
ItemImageData AccelPPackImage
{
shapeFile = "shieldpack";
mountPoint = 2;
firstPerson = false;
};
ItemData AccelPPack
{
description = "Thrust Platform";
shapeFile = "elevator_6x6_octagon";
className = "Backpack";
heading =  "lDeployables";
imageType = AccelPPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 950;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function AccelPPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function AccelPPack::onDeploy(%player,%item,%pos)
{
if (AccelPPack::deployShape(%player,"AccelPad",AccelPadPack,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
}
}
function CreateAccelPadSimSet()
{
%teleset = nameToID("MissionCleanup/AccelPadPack");
if(%teleset == -1)
{
newObject("AccelPadPack",SimSet);
addToSet("MissionCleanup","AccelPadPack");
}
}
function AccelPPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"] < $TeamItemMax[AccelPPack]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
%sensor = newObject("AccelPadPack","StaticShape",%shape,true);
CreateAccelPadSimSet();
addToSet("MissionCleanup/AccelPadPack", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 -0.25");
GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
GameBase::setPosition(%sensor,%pos);
%Rot=GameBase::getRotation(%player);
%Rot=Vector::add(%Rot,"0 0 3.14159");
GameBase::setRotation(%sensor,%rot);
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,"Accel Pad");
Client::sendMessage(%client,0,%item.description @ " deployed");
echo("MSG: ",%client," deployed an Accelerator Pad ");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::startFadeIn(%sensor);
playSound(SoundPickupBackpack,$los::position);
GameBase::startfadein(%sensor);
return true;
}
else
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
}
else {
Client::sendMessage(%client,0,"Deploy position out of range");
}
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}
//---------------------------------------------------------
// Jail
//---------------------------------------------------------


ItemImageData jailpackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData jailpack
{
description = "Air Jail";
shapeFile = "shieldpack";
className = "Backpack";
heading =  "mAir Deployables";
imageType = jailpackImage;
shadowDetailMask = 4;
mass = 1.0;
elasticity = 0.2;
price = 9000;
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
function CreatereleasepadSimSet()
{
        %teleset = nameToID("MissionCleanup/releasepad");
        if(%teleset == -1)
        {  
                  newObject("releasepad",SimSet);
                  addToSet("MissionCleanup","releasepad");
        }        
}

function jailpack::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack])
        {
	        Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
	        return false;
         }

	  if(%player.outArea == 1)
        {
	        Client::sendMessage(%client,0,"Can Not Deploy Jail Cell OFF the map.");
	        return false;
	  }

                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);

				%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);

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



ItemImageData JailCapPackImage
{
        shapeFile = "flagstand";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mass = 1.5;
        firstPerson = false;
};

ItemData JailCapPack
{
        description = "Jail Capture Pad";
        shapeFile = "flagstand";
        className = "Backpack";
        heading =  "lDeployables";
        imageType = JailCapPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function JailCapPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function JailCapPack::onDeploy(%player,%item,%pos)
{
        if (JailCapPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}
function JailCapPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);

                         %playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item);

                          }


                                %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                %rot =  "1.57079 0 " @ %zRot;
                                %padd = "0 0 0";
                                %pos = Vector::add($los::position,%padd);

                                        %camera = newObject("","StaticShape","jailpad",true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,"0 0 0");
                                        GameBase::setPosition(%camera,%pos);
                                        Gamebase::setMapName(%camera,"JailPad " @ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,1,"Jail Pad Deployed ~wnoway.wav");
                                        playSound(SoundPickupBackpack,$los::position);
					          schedule("GameBase::startFadeOut("@%camera@");",6.0, $los::object);
                                        $TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
                                        echo("MSG: ",%client," deployed a Jail Pad");
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


//***********************************
// AAOD Mobile Bunker Pack
//***********************************

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
        maxDamage                = 100;
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

ItemImageData BlastPackImage
{
        shapeFile = "cactus1";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 18.5;
        firstPerson = false;
};

ItemData TNTPack
{
        description = "Nega-Bomb";
        shapeFile = "cactus1";
        className = "Backpack";
   heading = "lDeployables";
        imageType = BlastPackImage;
        shadowDetailMask = 4;
        mass = 18.5;
        elasticity = 0.2;
        price = 200000;
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
                        GameBase::throw(%obj,%player,10 * %client.throwStrength,false);
        bottomprint(Player::getClient(%player), "<jc>Nega-Bomb will explode in <f2>10 seconds", 5);
}



//===================================
$TeamItemMax[MiniBase] = 5;
$TeamItemMax[AIRBASE] = 5;
ItemImageData groundbasePackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData groundbase
{
description = "Vehicle Base";
shapeFile = "shieldpack";
className = "Backpack";
heading =  "lDeployables";
imageType = groundbasePackImage;
shadowDetailMask = 4;
mass = 1.0;
elasticity = 0.2;
price = 2000;
hudIcon = "deployable";
howWeaponBar = true;
hiliteOnActive = true;
};

function groundbase::onUse(%player,%item)
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

function groundbase::onDeploy(%player,%item,%pos)
{
        if (groundbase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function groundbase::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "MiniBase"] >= $TeamItemMax[MiniBase])
        { Client::sendMessage(%client,0,"Too many Ground-Bases"); return false; }


                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);
                echo("%flagpos " @ %flagpos);
                echo("%playerpos " @ %playerpos);
                if(Vector::getDistance(%flagpos, %playerpos) > 5)
                {

                %obj = getObjectType($los::object);
                %set = newObject("groundBase",SimSet);
                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                %num = CountObjects(%set,"groundBase",%num);
                deleteObject(%set);


                %objDevice =   newObject("groundBase","Staticshape",BaseGenerator,true);
                %objDevice.objSide1 = newObject("groundBase1","Staticshape",BasePlatform,true);
                %objDevice.objSide2 = newObject("groundBase2","Staticshape",BasePlatform,true);
                %objDevice.objSide3 = newObject("groundBase3","Staticshape",BasePlatform,true);
                %objDevice.objSide4 = newObject("groundBase4","Staticshape",ArtilleryTurret,true);
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


                %pos = Vector::add(GameBase::getPosition(%player), "6.75 -0 12.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide5,%rot);
                GameBase::setPosition(%objDevice.objSide5,%pos);
                GameBase::setTeam(%objDevice,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-6.75 -5.0 12.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide1,%rot);
                GameBase::setPosition(%objDevice.objSide1,%pos);
                GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "6.75 -0 5.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide2,%rot);
                GameBase::setPosition(%objDevice.objSide2,%pos);
                GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-6.75 -5.0 5.00");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide3,%rot);
                GameBase::setPosition(%objDevice.objSide3,%pos);
                GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "0 -2.0 12.50");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                GameBase::setRotation(%objDevice.objSide4,%rot);
                GameBase::setPosition(%objDevice.objSide4,%pos);
                GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-3 -5 5.40");

               %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice,%rot);
                GameBase::setPosition(%objDevice,%pos);
                GameBase::setTeam(%objDevice.objSide5,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-7 -5 5.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide6,%rot);
                GameBase::setPosition(%objDevice.objSide6,%pos);

                GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "5 0 5.40");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide7,%rot);
                GameBase::setPosition(%objDevice.objSide7,%pos);
                GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "-8 -5 12.50");
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide8,%rot);
                GameBase::setPosition(%objDevice.objSide8,%pos);
                GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));

                %pos = Vector::add(GameBase::getPosition(%player), "8 0 12.50");

               %rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
                GameBase::setRotation(%objDevice.objSide9,%rot);
                GameBase::setPosition(%objDevice.objSide9,%pos);
                GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
                Gamebase::setMapName(%inv,"Vehicle Base " @  Client::getName(%client));


                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "minibase"]++;
                Client::sendMessage(%client,0,"Vehicle Base Deployed.");
                echo("MSG: ",%client," deployed a Vehicle Base");

                return true;
               }
                else
                        Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
                        return false;


}

////////////======================================================

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
$ObjType[13]="SPlasmaTurret";

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
$ObjType[33]="HPTurret";
$ObjType[34]="PulseTurret";
$ObjType[35]="PortaC";

$ObjType[36]="MobileBunker";
$ObjType[37]="PortGenerator";
$ObjType[38]="AmmoStation";
$ObjType[39]="DeployableAmmoStation";
$ObjType[40]="DeployableInvStation";
$ObjType[41]="CommandStation";
$ObjType[42]="VehicleStation";
$ObjType[43]="SuperDoorShape";

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
                %num+=CountObjects(%set,$ObjType[42],%tnum);
		    %num+=CountObjects(%set,$ObjType[43],%tnum);


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
                %num+=CountObjects(%set,$ObjType[42],%tnum);
		    %num+=CountObjects(%set,$ObjType[43],%tnum);
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
			Client::SendMessage(%client,3,"Backup power grid Initialized");
		return (false);
	}
	else
		TeamMessages(3,%team,%name@" coming ON line...~wAAODSFX50.wav");
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
	TeamMessages(1,%team,%name@" going OFF line...~wAAODSFX50.wav");
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
	TeamMessages(3,%team,"Power for "@%mname@" routed to: "@%gname@"~wAAODSFX52.wav");
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
		TeamMessages(1,%team,"Power for "@%mname@" disconnected from "@%gname@"~wAAODSFX52.wav");
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
					{	Client::sendMessage(%client,3,"Main Power connection found... connecting...~wAAODSFX16.wav");
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
			Client::sendMessage(%client,3,"Secondary Power connection found... connecting...");
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
		{	Client::sendMessage(%client,1,"Warning! This item is not within range of a Generator!!~werror_message.wav");
			return (false);
		}

	}
	return (true);
}

exec("deployableturrets.cs");
