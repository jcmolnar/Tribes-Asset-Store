

function CheckObjectType(%object,%type)
{
	//if($traceDep) Echo("Checking: Is deployable placement on ",%object," valid for type: ",%type);
	if(%type==0) // **** Can be PLaced on Terrain Only
	{
		if(%object=="SimTerrain")
			return(true);
	}
	else if(%type==1) // **** Can Be Placed on Terrain & Buildings
	{
		if(%object=="SimTerrain" || %object=="InteriorShape")
			return(true);
	}	
	else if(%type==2) // **** Can Be Placed on Terrain, Buildings & Some objects
	{
		if((%object=="SimTerrain" || %object=="InteriorShape" ) || (%object=="Turret" || %object=="sensor"))
			return(true);
	}
	else if(%type==3) // **** Can Be Placed on Buildings & Terrain but Must be Outside
	{
		if(%object=="SimTerrain" || %object=="InteriorShape")
		{
			%num=0;
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
	// Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
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
	// %DonD = Delete on Destroy True or False
	// %tname = Name of Type items
	// %power = 0= Item has No special Power Needs|1=Item Requires Power|2=Item generates Power 
	// (Item which requires Power will have an %item.prange var for how far it can look for power)
	
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
			
	if(%ctype==1)
	{
		%BxMxL=$TurretBoxMaxLength;
		%BxMnL=$TurretBoxMinLength;
		%BxMxW=$TurretBoxMaxWidth;
		%BxMnW=$TurretBoxMinWidth;
		%BxMxH=$TurretBoxMaxHeight;
		%BxMnH=$TurretBoxMinHeight;
		%MaxNum=$MaxNumTurretsInBox;
		%class="Turret";
		%tname="deployable Turrets";
	}
	else if(%ctype==2)
	{
		%BxMxL=$FFBxMxLength;
		%BxMnL=$FFBxMnLength;
		%BxMxW=$FFBxMxWidth;
		%BxMnW=$FFBxMnWidth;
		%BxMxH=$FFBxMxHeight;
		%BxMnH=$FFBxMnHeight;
		%MaxNum=$MaxNumFieldsInBox;
		%class="StaticShape";
		%tname="Deployable Forcefields";
	}
	else if(%ctype==4) // Nodes
	{
		%BxMxL=10;
		%BxMnL=1;
		%BxMxW=10;
		%BxMnW=1;
		%BxMxH=10;
		%BxMnH=1;
		%MaxNum=2;
		%class="StaticShape";
	}
	else
	{
		%BxMxL=2;
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
	if($TeamItemCount[ %team @ %item] < $TeamItemMax[%item] || $build)	// Check to see if Item Count has been Reached
	{
		%thisnum=$TeamItemCount[%team @ %item]+1;
		if(GameBase::getLOSInfo(%player,%dist)) 
		{
			%obj = getObjectType($los::object);
			if(CheckObjectType(%obj,%ptype))
			{
				%set = newObject("set",SimSet);
				%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMxL,%BxMxW,%BxMxH,0);
				%num = GetNumObjects(%set,%ctype,%tnum);
				deleteObject(%set);
				if(%MaxNum > %num) 
				{
					%set = newObject("set",SimSet);
					%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,%BxMnL,%BxMnW,%BxMnH,0);
					%num = GetNumObjects(%set,%ctype,%tnum);
					deleteObject(%set); // Sevnn - Test
					if(0 == %num) // No Objects within the Minimum Box
					{
						if(%dtype==1) // If Deployable on Any Surface
						{
							// Try to stick it straight up or down, otherwise
							// just use the surface normal
							%prot = GameBase::getRotation(%player);
							//if($trace) echo("Player Rotation ",%prot);
							//%zRot = (3.141592654-getWord(%prot,2));
							//if($trace) echo("Player Rotation ",%zrot);
							%zRot = (getWord(%prot,2));

							if(Vector::dot($los::normal,"0 0 1") > 0.6) 
								%rot = "0 0 " @ %zRot;
							else
							{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
									%rot = "3.14159 0 " @ %zRot;
								else
									%rot = Vector::getRotation($los::normal);
							}
						}
						else if(%dtype==2) // Matches Any Surface
							%rot = Vector::getRotation($los::normal);
						else
						{
							if(Vector::dot($los::normal,"0 0 1") <= 0.7)
							{	Client::sendMessage(%client,0,%desc@" Can only deploy on flat surfaces~werror_message.wav");
								return (false);
							}
							%rot = GameBase::getRotation(%player);
						}	
						if(checkDeployArea(%client,$los::position)) 
						{
							%newitem = newObject(%shape,%class,%shape,%DonD);
							NukeList(%newitem);
							if($traceObj) Echo($Ver,"|Created New Object :",%newitem," ",%descr);
							GameBase::playSequence(%newitem,1,"deploy");
							GameBase::SetActive(%newItem,false);
							%newitem.faded=1;
							addToSet("MissionCleanup", %newitem);
							GameBase::setTeam(%newitem,%team);
							GameBase::setPosition(%newitem,$los::position);
							GameBase::setRotation(%newitem,%rot);
							Gamebase::setMapName(%newitem,%descr);
							Client::sendMessage(%client,0,%descr @" deployed");
							playSound(SoundCreateItem,$los::position);
							$TeamItemCount[%team @ %item]++;
							%newitem.deployedBy = %client;
							%newitem.powerReq = %power;
							%newitem.pRange = %pRange;

							if(%power==1) // Item Requires Power
							{
								if($TracePwr) echo(%newitem," requires Power!");
								Client::sendMessage(%client,1,"Attempting to connect to Main Power Grid"); //~AAODSFX13.WAV
								schedule("PowerItem("@%newitem@","@%pRange@","@%client@");",2,%newitem);
							}
							else if(%power==2) // Item generates Power
							{
								if($TracePwr) echo(%newitem,"	Power Generator!");
								GameBase::SetActive(%newItem,true);
								Client::sendMessage(%client,1,"Attempting to connect Generator to Main Grid"); //~AAODSFX13.WAV
								schedule("ConnectGenerator("@%newitem@","@%client@");",2,%newitem);
								//Echo ("GenSet exhist?: ", $GenSet[%team]);
								if($GenSet[%team])
									addToSet($GenSet[%team],%newItem);
								else
								{	$GenSet[%team]=newObject("set",SimSet);
									addToSet("MissionCleanup",$GenSet[%team]);
									addToSet($GenSet[%team],%newItem);
								}
								//Echo ("GenSet exhist?: ", $GenSet[%team]);
							}
							else
								GameBase::SetActive(%newItem,true);

							echo("MSG: ",$User[%client]," deployed a "@ %descr);
							return (%newitem);
						}
					}
					else Client::sendMessage(%client,0,"Frequency Overload - Too close to other "@%tname);
				}
				else Client::sendMessage(%client,0,"Too Many Other "@%tname@" in the area");
			}
			else Client::sendMessage(%client,0,%descr@" can only be deployed "@%pDesc@""); //~wAAODSFX09.WAV
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
	return (false);
}

function GetNumObjects(%set,%type,%tnum)
{
	if(%tnum==0)
		return (0);
	if(%type==4)
		return(0);

	if(%type==1) // Turrets only
	{
		%num=0;
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
	else if(%type==2) // Forcefields Only
	{
		%num=0;
		%num+=CountObjects(%set,$ObjType[13],%tnum);
		%num+=CountObjects(%set,$ObjType[14],%tnum);
		%num+=CountObjects(%set,$ObjType[15],%tnum);
		%num+=CountObjects(%set,$ObjType[16],%tnum);
		return (%num);
	}
	else if(%type==3) // Forcefields & Static Objects
	{
		%num=0;
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
	{
		%num=0;
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