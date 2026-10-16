//-----------------------------------------------------------------------------------------------------------
//					AAOD Deployables File
//___________________________________________________________________________________________________________
//	Contains all the Deploayble related functions as well as the generic 
//	Deployable Routines......
//-----------------------------------------------------------------------------------------------------------

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




//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODGrogPack Backpack Script
//	GROGTurret Script
// 	(Deployable Chaingun Turret)
// 	GrogShot

$InvList[AODGrogPack]			= 1;
$RemoteInvList[AODGrogPack]		= 1;
$TeamItemMax[AODGrogPack]		= 3;
$ItemMax[larmor, AODGrogPack]	= 0;
$ItemMax[lfemale, AODGrogPack]	= 0;
$ItemMax[marmor, AODGrogPack]	= 1;
$ItemMax[mfemale, AODGrogPack]	= 1;
$ItemMax[harmor, AODGrogPack]	= 1;

BulletData GrogShot
{	bulletShapeName = "bullet.DTS";
	explosionTag = bulletExp0;	
	expRandCycle	= 3;		
	mass = 2.75;				
	collisionRadius = 0.0;		
	bulletHoleIndex = 0;		
	ExplosionRadius = 0;		
	damageClass = 0;			
	damageValue = 0.12;			
	damageType = $GrogDamageType;
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
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODGrogPack 
{	description		= "Chaingun Turret";
	shapeFile		= "remoteturret";
	classname		= "Backpack";
	heading			= "dDeployables";
	imageType		= AODGrogPackImage;
	shadowDetailMask = 4;
	mass			= 3.0;
	elasticity		= 0.2;
	price			= 650;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;	
};
function AODGrogPack::Help(%client)
{	%msg=HelpTitle("Chaingun Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Rapid Fire, Short Range - good Damage.");
	%msg=AddHelpLine(%msg,"Excellent Defensive/offensive turret!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
TurretData GROGTurret 
{ 	classname		= "Turret";
	shapeFile		= "remoteturret";
	projectileType	= GrogShot;
	maxDamage		= 1.15;
	maxEnergy		= 50;
	minGunEnergy	= 5;
	maxGunEnergy	= 5;
	sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
	reloadDelay		= 0.25;
	speed			= 6.0;
	speedModifier	= 1.5;
	range			= 40;
	visibleToSensor = true;
	shadowDetailMask= 4;
	dopplerVelocity = 0;
	castLOS			= true;
	supression		= false;
	mapFilter		= 2;
	mapIcon			= "M_turret";
	debrisId		= flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound		= SoundGrogFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId		= flashExpMedium;
	description		= "Chaingun Turret";
	damageSkinData	= "objectDamageSkins";
	pinger			= false;
};

function AODGrogPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);	}
	else 
	{	Player::deployItem(%player,%item); }
}

function AODGrogPack::onDeploy(%player,%item,%pos)
{	if (AODGrogPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODGrogPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
	DeployStuff(%player,%item,GROGTurret,1,3,1,0,true,false,0);
}


function GROGTurret::onAdd(%this)
{	schedule("GROGTurret::deploy(" @ %this @ ");",1,%this);
}

function GROGTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function GROGTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function GROGTurret::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODGrogPack"]--;
}

function GROGTurret::onPower(%this,%power,%generator)
{
}

function GROGTurret::onEnabled(%this)
{	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.0085;
}

function GROGTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "m h";
	%desc		= "Chaingun turret";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODGrogPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODVelcroPack Backpack Script
//	VELCROTurret Script

$InvList[AODVelcroPack]			= 1;
$RemoteInvList[AODVelcroPack]		= 1;
$TeamItemMax[AODVelcroPack]		= 3;

$ItemMax[larmor, AODVelcroPack]	= 0;
$ItemMax[lfemale, AODVelcroPack]	= 0;
$ItemMax[marmor, AODVelcroPack]	= 1;
$ItemMax[mfemale, AODVelcroPack]	= 1;
$ItemMax[harmor, AODVelcroPack]	= 1;

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
   damageType       = $VelcroDamageType;
   muzzleVelocity   = 60.0;
   totalTime        = 4.0;
   liveTime         = 4.0;
   isVisible        = True;
   rotationPeriod	= 0.15;
};


ItemImageData AODVelcroPackImage 
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODVelcroPack 
{	description = "Velcro Turret";
	shapeFile = "remoteturret";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = AODVelcroPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODVelcroPack::Help(%client)
{	%msg=HelpTitle("Velcro Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Can Be deployed on any surface.");
	%msg=AddHelpLine(%msg,"Med-Slow Rate of fire - good damage.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
TurretData VELCROTurret 
{
 	classname		= "Turret";
	shapeFile		= "remoteturret";
	projectileType	= VelcroProjectile;
	maxDamage		= 0.70;
	maxEnergy		= 90;
	minGunEnergy	= 7.5;
	maxGunEnergy	= 15;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay		= 0.75;
	speed			= 4.0;
	speedModifier	= 1.5;
	range			= 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS			= true;
	supression		= false;
	mapFilter		= 2;
	mapIcon			= "M_turret";
	debrisId		= flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound		= SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId		= flashExpMedium;
	description		= "Velcro Turret";
	damageSkinData	= "objectDamageSkins";
	pinger			= false;
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
{	if (AODVelcroPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
}

function AODVelcroPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
	DeployStuff(%player,%item,VELCROTurret,1,4,1,1,true,false,0);
}


function VELCROTurret::onAdd(%this)
{	schedule("VELCROTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Velcro Turret");
}

function VELCROTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function VELCROTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function VELCROTurret::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODVelcroPack"]--;
}

function VELCROTurret::onPower(%this,%power,%generator)
{
}

function VELCROTurret::onEnabled(%this)
{	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

function VELCROTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "";
	%desc		= "Velcro turret";
	%nopack		= false;			// does not have to have no pack on
	%pName		= AODVelcroPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODSamPack Backpack Script
//	SAMTurret Script
// 	(SAM Missile Turret)
// 	SAMMissile

$InvList[AODSamPack]			= 1;
$RemoteInvList[AODSamPack]			= 1;
$TeamItemMax[AODSamPack]			= 3;

$ItemMax[larmor, AODSamPack]			= 0;
$ItemMax[lfemale, AODSamPack]			= 0;
$ItemMax[marmor, AODSamPack]			= 0;
$ItemMax[mfemale, AODSamPack]			= 0;
$ItemMax[harmor, AODSamPack]			= 1;

SeekingMissileData SAMMissile 
{	bulletShapeName		= "rocket.dts";
	explosionTag		= rocketExp;
	collisionRadius		= 0.0;
	mass				= 2.0;
	damageClass			= 1;
	damageValue			= 0.4;
	damageType			= $SamDamageType;
	explosionRadius		= 9.5;
	kickBackStrength	= 175.0;
	muzzleVelocity		= 65.0;
	totalTime			= 25;
	liveTime			= 25;
	seekingTurningRadius = 0.1;
	nonSeekingTurningRadius = 5.0;
	proximityDist		= 1.5;
	smokeDist			= 1.75;
	lightRange			= 5.0;
	lightColor			= { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId				= SoundJetHeavy;
};


ItemImageData AODSamPackImage 
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODSamPack 
{	description = "SAM Missile Turret";
	shapeFile = "remoteturret";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = AODSamPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODSamPack::Help(%client)
{	%msg=HelpTitle("SAM Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Surface to Air Missile turret.");
	%msg=AddHelpLine(%msg,"Good light weight air defense");
	%msg=AddHelpLine(%msg,"Not an extremely sturdy turret.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData SAMTurret 
{ 	classname = "Turret";
	shapeFile = "remoteturret";
	projectileType = SAMMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "SAM Missile Turret";
	damageSkinData = "objectDamageSkins";
	pinger = false;
};


function AODSamPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function AODSamPack::onDeploy(%player,%item,%pos)
{	if (AODSamPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
}

function AODSamPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
	DeployStuff(%player,%item,SAMTurret,1,3,1,0,true,false,0);
}

function SAMTurret::verifyTarget(%this,%target)
{	// if($trace) echo($Ver,"SAM Turret Verify Target (This.target) (",%this,".",%target,")");
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
		return (true);
	else 
		return (false);
} 

function SAMTurret::onAdd(%this)
{	schedule("SAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "SAM Missile Turret");
}

function SAMTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function SAMTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function SAMTurret::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODSamPack"]--;
}

function SAMTurret::onPower(%this,%power,%generator)
{
}

function SAMTurret::onEnabled(%this)
{	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.015;
	GameBase::setActive(%this,true);
}

function SAMTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "SAM turret";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODSamPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODInfernoPack Backpack Script
//	InfernoMine Script
// 	(Inferno Defense Mine)
// 	PyroBurst

$InvList[AODInfernoPack]		= 1;
$RemoteInvList[AODInfernoPack]		= 1;
$TeamItemMax[AODInfernoPack]		= 4;

$ItemMax[larmor, AODInfernoPack]		= 0;
$ItemMax[lfemale, AODInfernoPack]		= 0;
$ItemMax[marmor, AODInfernoPack]		= 1;
$ItemMax[mfemale, AODInfernoPack]		= 1;
$ItemMax[harmor, AODInfernoPack]		= 1;

ExplosionData PyroBurstExp 
{	shapeName = "plasmaex.dts";
	soundId = SoundHFootLSoft;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 6.0;
	timeScale = 0.6;
	colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};

GrenadeData PyroBurst 
{	explosionTag		= PyroBurstExp;
	collideWithOwner	= True;
	ownerGraceMS		= 50;
	collisionRadius		= 10.0;
	mass				= 5.0;
	elasticity			= 0.1;
	damageClass			= 1;
	damageValue			= 0.65;
	damageType			= $InfernoDamageType;
	explosionRadius		= 8.0;
	kickBackStrength	= 25.0;
	maxLevelFlightDist	= 25;
	totalTime			= 0.5;
	liveTime			= 0.5;
	projSpecialTime		= 0.01;
	lightRange			= 10.0;
	lightColor			= { 1.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	smokeName			= "plastrail.dts";
	soundId				= SoundInfernoFire;
};

ItemImageData AODInfernoPackImage 
{	shapeFile = "Camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODInfernoPack 
{	description		= "Inferno Defense Mine";
	shapeFile		= "Camera";
	classname		= "Backpack";
	heading			= "dDeployables";
	imageType		= AODInfernoPackImage;
	shadowDetailMask = 4;
	mass			= 3.0;
	elasticity		= 0.2;
	price			= 650;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODInfernoPack::Help(%client)
{	%msg=HelpTitle("Inferno Turret: Self Powered");
	%msg=AddHelpLine(%msg,"deploys on Any surface.");
	%msg=AddHelpLine(%msg,"Very Small Easily missed turret. Has very limited range.");
	%msg=AddHelpLine(%msg,"Best used in confined areas. Not very effective outdoors");
	%msg=AddHelpLine(%msg,"Excellent for flag & corridoor defense!!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData InfernoMine 
{	classname		= "Turret";
	shapeFile		= "camera";
	projectileType	= PyroBurst;
	maxDamage		= 1.25;
	maxEnergy		= 100;
	minGunEnergy	= 10;
	maxGunEnergy	= 15;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay		= 0.75;
	speed			= 8.0;
	speedModifier	= 1.5;
	range			= 20;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS			= true;
	supression		= false;
	mapFilter		= 2;
	mapIcon			= "M_turret";
	debrisId		= flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound		= SoundInfernoActive;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId		= flashExpMedium;
	description		= "Inferno Defense Mine";
	damageSkinData	= "objectDamageSkins";
	pinger			= false;
};


function AODInfernoPack::onUse(%player,%item)
{	 if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);	}
	else 
	{	Player::deployItem(%player,%item); }
}

function AODInfernoPack::onDeploy(%player,%item,%pos)
{	if (AODInfernoPack::deployShape(%player,%item)) 
	{Player::decItemCount(%player,%item);}
}

function AODInfernoPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,InfernoMine,1,4,1,1,true,false,0);
}

function InfernoMine::onAdd(%this)
{	schedule("InfernoMine::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Inferno Defense Mine");
}

function InfernoMine::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function InfernoMine::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function InfernoMine::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODInfernoPack"]--;
}

function InfernoMine::onEnabled(%this)
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function InfernoMine::packUp(%this, %pos, %client, %player)
{	%armor		= "m h";
	%desc		= "Inferno Mine";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODInfernoPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

//*****************************
// AAOD Mod Deployable Kit
//*****************************
// 	AODAAPack Backpack Script
//	AATurret Script
// 	(AA Missile Turret)
// 	AAMissile

$InvList[AODAAPack]			= 1;
$RemoteInvList[AODAAPack]			= 0;
$TeamItemMax[AODAAPack]			= 1;

$ItemMax[larmor, AODAAPack]			= 0;
$ItemMax[lfemale, AODAAPack]			= 0;
$ItemMax[marmor, AODAAPack]			= 0;
$ItemMax[mfemale, AODAAPack]			= 0;
$ItemMax[harmor, AODAAPack]			= 1;

SeekingMissileData AAMissile 
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.40;
	damageType = $AADamageType;
	explosionRadius = 5.5;
	kickBackStrength = 100.0;
	muzzleVelocity = 100.0;
	totalTime = 15;
	liveTime = 16;
	seekingTurningRadius = 1.0;
	nonSeekingTurningRadius = 5.0;
	proximityDist = 5.5;
	smokeDist = 0.5;
	lightRange = 5.0;
	lightColor = { 0.8, 0.2, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};


ItemImageData AODAAPackImage 
{	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODAAPack 
{	description = "AA Missile Turret";
	shapeFile = "Missileturret";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = AODAAPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODAAPack::Help(%client)
{	%msg=HelpTitle("Anti Air Turret: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Excellent for long range Air suppression. Will remove");
	%msg=AddHelpLine(%msg,"most flying pests from your skies. Fires a volley of Surface to air missiles");
	%msg=AddHelpLine(%msg,"clearing your skies on unwanted guests!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData AATurret 
{ 	classname = "Turret";
	shapeFile = "Missileturret";
	projectileType = AAMissile;
	maxDamage = 1.0;
	maxEnergy = 100;
	minGunEnergy = 15;
	maxGunEnergy = 20;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay = 0.15;
	speed = 2.0;
	speedModifier = 1.5;
	range = 350;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "AA Missile Turret";
	damageSkinData = "objectDamageSkins";
	pinger = false;
};


function AODAAPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
	else 
	{	Player::deployItem(%player,%item);}
}

function AODAAPack::onDeploy(%player,%item,%pos)
{	if (AODAAPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODAAPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,AATurret,1,5,1,0,true,true,100);
}

function AATurret::verifyTarget(%this,%target)
{	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
		return (true);
	else 
		return (false);
} 

function AATurret::onDestroyed(%this)
{	AATurret::OnDisabled(%this);
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODAAPack"]--;
}

function AATurret::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "AA turret";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODAAPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function AATurret::onEnabled(%this)
{	if(GameBase::isPowered(%this))
	{	GameBase::setRechargeRate(%this,10);
		%this.shieldStrength = 0.015;
		GameBase::setActive(%this,true);
	}
}

function AATurret::onDisabled(%this)
{	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0.0;
	GameBase::setActive(%this,false);
}

function AATurret::onPower(%this,%power,%gen)
{	if(%power)
		AATurret::onEnabled(%this);
	else
		AATurret::onDisabled(%this);
}
		

//---------------------------------
// 	AODArtilleryPack Backpack Script
//---------------------------------
$InvList[AODArtilleryPack]		= 1;
$RemoteInvList[AODArtilleryPack]	= 0;
$TeamItemMax[AODArtilleryPack]		= 1;

$ItemMax[larmor, AODArtilleryPack]		= 0;
$ItemMax[lfemale, AODArtilleryPack]	= 0;
$ItemMax[marmor, AODArtilleryPack]		= 0;
$ItemMax[mfemale, AODArtilleryPack]	= 0;
$ItemMax[harmor, AODArtilleryPack]		= 1;

ExplosionData ArtilleryExp
{	shapeName		= "Tumult_large.dts";
	soundId			=  SoundArtilleryExplosion;
	faceCamera		= true;				
	randomSpin		= false;			
	hasLight			= true;			
	lightRange		= 15.0;			
	timeZero			= 0.0;			
	timeOne			= 0.500;			
	colors[0]		= {0.5,0.4,0.2};
	colors[1]		= {0.5,0.7,0.5};
	colors[2]		= {0.0,1.0,0.0};
	radFactors		= {0.5,1.0,0.0};
	shiftPosition	= False;			
};


GrenadeData ArtilleryShell
{	bulletShapeName			= "mortar.dts";
	explosionTag			= ArtilleryExp;
	collideWithOwner		= True;
	ownerGraceMS			= 250;
	collisionRadius			= 0.3;
	mass					= 15.0;
	elasticity				= 0.0001;
	damageClass				= 1;     
	damageValue				= 1.50;	
	damageType				= $ArtyDamageType;	
	explosionRadius			= 35;			
	kickBackStrength		= 450.0;		
	maxLevelFlightDist		= 650;		
	totalTime				= 30.0;
	liveTime				= 0.25;
	projSpecialTime			= 0.01;
	inheritedVelocityScale	= 0.5;
	smokeName				= "smoke.dts";
	soundId					= SoundArtilleryShot;
};



ItemImageData AODArtilleryPackImage 
{	shapeFile		= "magcargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass				= 3.0;
	firstPerson		= false;
};

ItemData AODArtilleryPack 
{	description		= "Artillery Turret";
	shapeFile		= "Mortar_Turret";
	classname		= "Backpack";
	heading			= "dDeployables";
	imageType		= AODArtilleryPackImage;
	shadowDetailMask = 4;
	mass			= 3.0;
	elasticity		= 0.2;
	price			= 950;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive = true;
};

function AODArtilleryPack::Help(%client)
{	%msg=HelpTitle("Artillery Turret: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Good for those who lke to reach out and TOUCH someone.");
	%msg=AddHelpLine(%msg,"Very Long range artillery shells do awesome damage!");
	%msg=AddHelpLine(%msg,"(Needs to be controlled!!)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData ArtilleryTurret 
{	classname		= "Turret";
	shapeFile		= "Mortar_Turret";
	projectileType	= ArtilleryShell;
	maxDamage		= 1.5;
	maxEnergy		= 100;
	minGunEnergy	= 25;
	maxGunEnergy	= 30;
	sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
	reloadDelay		= 1.0;
	speed			= 6.0;
	speedModifier	= 1.5;
	range			= 0;
	visibleToSensor = true;
	shadowDetailMask= 4;
	dopplerVelocity = 0;
	castLOS			= true;
	supression		= false;
	mapFilter		= 2;
	mapIcon			= "M_turret";
	debrisId		= flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound		= SoundArtilleryFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId		= flashExpMedium;
	description		= "Artillery Turret";
	damageSkinData	= "objectDamageSkins";
	pinger			= false;
};


function AODArtilleryPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
	else 
	{	Player::deployItem(%player,%item);}
}

function AODArtilleryPack::onDeploy(%player,%item,%pos)
{	if (AODArtilleryPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODArtilleryPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete,PowerReq,PRange)
	DeployStuff(%player,%item,ArtilleryTurret,1,5,1,0,true,true,100);
}

function ArtilleryTurret::onDestroyed(%this)
{	ArtilleryTurret::onDisabled(%this);
	if(%this.isMarked)
	{	// Object is Marked as a target...Unmark it when it is Unmounted
		// if($trace) Echo("Object is ",%ctrlObject," has an attached enemy target beacon");
		deleteObject(%this.isMarked);
		%this.isMarked=false;
	}
	
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODArtilleryPack"]--;
}

function ArtilleryTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "Artillery turret";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODArtilleryPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function ArtilleryTurret::onEnabled(%this)
{	if(GameBase::isPowered(%this))
	{	GameBase::setRechargeRate(%this,15);
		%this.shieldStrength = 0.005;
		GameBase::setActive(%this,true);
	}
}

function ArtilleryTurret::onDisabled(%this)
{	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0.0;
	GameBase::setActive(%this,false);
}

function ArtilleryTurret::onPower(%this,%power,%gen)
{	if(%power)
		ArtilleryTurret::onEnabled(%this);
	else
		ArtilleryTurret::onDisabled(%this);
}

//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODMortPack Backpack Script
//	MORTTurret Script
// 	(MORT Turret)
// 	MORTShell
//----------------------------------------------------
$InvList[AODMortPack]			= 1;
$RemoteInvList[AODMortPack]		= 1;
$TeamItemMax[AODMortPack]			= 1;

$ItemMax[larmor, AODMortPack]			= 0;
$ItemMax[lfemale, AODMortPack]			= 0;
$ItemMax[marmor, AODMortPack]			= 0;
$ItemMax[mfemale, AODMortPack]			= 0;
$ItemMax[harmor, AODMortPack]			= 1;

// Insert Projectile Block Here

ExplosionData MortShotExp
{  shapeName = "flash_small.dts";
   soundId		= soundmortexp;
   faceCamera	= true;
   randomSpin	= true;
   hasLight		= true;
   lightRange	= 3.0;
   timeZero		= 0.05;
   timeOne		= 0.07;
   colors[0]	= { 0.75, 0.25, 1.0 };
   colors[1]	= { 0.75, 0.25, 1.0 };
   colors[2]	= { 1.0, 0.75,  1.0 };
   radFactors	= { 1.0, 1.0,  1.0 };
   shiftPosition = True;
};


BulletData MortShot
{	bulletShapeName		= "plasmatrail.dts";
	explosionTag		= MortShotExp;
	mass				= 0.50;
	bulletHoleIndex		= 0;
	damageClass			= 0; 
	damageValue			= 0.20;
	damageType			= $MortDamageType;
	aimDeflection		= 0.005;
	muzzleVelocity		= 125.0;
	totalTime			= 3;
	inheritedVelocityScale = 0.5;
	isVisible			= true;
	tracerPercentage	= 0.5;
	tracerLength		= 15;
	rotationPeriod		= 0.25;
	lightRange			= 4.0;
	lightColor			= {0.75, 0.25,0.35};
};

ItemImageData AODMortPackImage 
{	shapeFile				= "magcargo";
	mountPoint				= 2;
	mountOffset				= { 0, -0.65, -0.4 };
	mountRotation			= { 0, 0, 0 };
	mass					= 3.0;
	firstPerson				= false;
};

ItemData AODMortPack 
{	description				= "MORT Turret";
	shapeFile				= "ChainTurret";
	classname				= "Backpack";
	heading					= "dDeployables";
	imageType				= AODMortPackImage;
	shadowDetailMask		= 4;
	mass					= 4.0;
	elasticity				= 0.2;
	price					= 1250;
	hudIcon					= "deployable";
	showWeaponBar			= true;
	hiliteOnActive			= true;
};

function AODMortPack::Help(%client)
{	%msg=HelpTitle("MORT Turret: Needs Power");
	%msg=AddHelpLine(%msg,"Can deploy on Any surface.");
	%msg=AddHelpLine(%msg,"** Note cant shoot directly above itself **");
	%msg=AddHelpLine(%msg,"Rapid fire does great damage poor accuracy");
	%msg=AddHelpLine(%msg,"Great suppression turret!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData MORTTurret 
{	classname				= "Turret";
	shapeFile				= "Chainturret";
	projectileType			= MORTShot;
	maxDamage				= 2.5;
	maxEnergy				= 100;
	minGunEnergy			= 8;
	maxGunEnergy			= 10;
	sequenceSound[0]		= {"deploy", SoundMortActivate};
	reloadDelay				= 0.4;
	speed					= 5.0;
	speedModifier			= 1.5;
	range					= 200;
	visibleToSensor			= true;
	shadowDetailMask		= 4;
	dopplerVelocity			= 0;
	castLOS					= true;
	supression				= false;
	mapFilter				= 2;
	mapIcon					= "M_turret";
	debrisId				= flashDebrisMedium;
	shieldShapeName			= "shield";
	fireSound				= SoundMORTFire;
	activationSound			= SoundRemoteTurretOn;
	deactivateSound			= SoundRemoteTurretOff;
	explosionId				= flashExpMedium;
	description				= "MORT Turret";
	damageSkinData			= "objectDamageSkins";
	pinger					= false;
};


function AODMortPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
	else 
	{	Player::deployItem(%player,%item);}
}

function AODMortPack::onDeploy(%player,%item,%pos)
{	if (AODMortPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODMortPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MORTTurret,1,5,1,1,true,true,100);
}

function MORTTurret::onDestroyed(%this)
{	MORTTurret::onDisabled(%this);
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODMortPack"]--;
}

function MORTTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "Mortis turret";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODMortPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function MORTTurret::onEnabled(%this)
{	if(GameBase::isPowered(%this))
	{	GameBase::setRechargeRate(%this,45);
		GameBase::setActive(%this,true);
		%this.shieldStrength = 0.010;
	}
}
function MORTTurret::onDisabled(%this)
{	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0.0;
	GameBase::setActive(%this,false);
}

function MORTTurret::onPower(%this,%power,%gen)
{	if(%power)
		MORTTurret::onEnabled(%this);
	else
		MORTTurret::onDisabled(%this);
}


//--------------------------------------------
//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODAmbushAPPack Backpack Script
//	AmbusherAp Script
// 	(Deployable Ambusher Turret)

$InvList[AODAmbushAPPack]			= 1;
$RemoteInvList[AODAmbushAPPack]		= 1;
$TeamItemMax[AODAmbushAPPack]		= 2;

$ItemMax[lfemale, AODAmbushAPPack]	= 0;
$ItemMax[mfemale, AODAmbushAPPack]	= 1;
$ItemMax[larmor, AODAmbushAPPack]	= 0;
$ItemMax[marmor, AODAmbushAPPack]	= 1;
$ItemMax[harmor, AODAmbushAPPack]	= 1;

BulletData AmbusherAPShot
{	bulletShapeName = "ShotgunBolt.DTS";
	explosionTag	= blasterExp;	
	mass			= 2.75;				
	collisionRadius = 0.0;		
	bulletHoleIndex = 0;		
	ExplosionRadius = 0;		
	damageClass		= 0;			
	damageValue		= 0.12;			
	damageType		= $AmbushAPDamageType;
	aimDeflection	= 0.005;		
	muzzleVelocity	= 400.0;		
	totalTime		= 0.5;			
	inheritedVelocityScale = 0.5;
	liveTime		= 2.0;			
	isVisible		= true;		
	detachFromShooter = false;		
	rotationPeriod	= 0.5;			
	lightRange		= 0.0;			
	lightColor		= {1.0, 0.25,0.25};
};

ItemImageData AODAmbushAPPackImage 
{	shapeFile		= "remoteturret";
	mountPoint		= 2;
	mountOffset		= { 0, -0.12, -0.1 };
	mountRotation	= { 0, 0, 0 };
	mass			= 3.0;
	firstPerson		= false;
	mass			= 2.0;
};

ItemData AODAmbushAPPack 
{	description		= "Ambusher Turret";
	shapeFile		= "remoteturret";
	classname		= "Backpack";
	heading			= "dDeployables";
	imageType		= AODAmbushAPPackImage;
	shadowDetailMask = 4;
	mass			= 2.0;
	elasticity		= 0.2;
	price			= 750;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODAmbushAPPack::Help(%client)
{	%msg=HelpTitle("AntiPersonnell Ambusher Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Must be deployed on relatively flat terrain.");
	%msg=AddHelpLine(%msg,"This nasty guy 'hides' itself under the ground.");
	%msg=AddHelpLine(%msg,"When an enemy wanders into range it 'pops' up");
	%msg=AddHelpLine(%msg,"and fires a devastating volly!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

TurretData AmbusherAP
{	classname		= "Turret";
	shapeFile		= "remoteturret";
	projectileType	= AmbusherApShot;
	maxDamage		= 1.25;
	maxEnergy		= 60;
	minGunEnergy	= 6;
	maxGunEnergy	= 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay		= 0.14;
	speed			= 3.0;
	speedModifier	= 1.5;
	range			= 40;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS			= true;
	supression		= false;
	mapFilter		= 2;
	mapIcon			= "M_turret";
	debrisId		= flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound		= SoundRemoteTurretFire;
	activationSound = SoundplasmaTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId		= flashExpMedium;
	description		= "Ambusher AntiPersonell Turret";
	damageSkinData	= "objectDamageSkins";
};

function AODAmbushAPPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);	}
	else 
	{	Player::deployItem(%player,%item); }
}

function AODAmbushAPPack::onDeploy(%player,%item,%pos)
{	if (AODAmbushAPPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function AODAmbushAPPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Category, Surfaces, Delete,PowerReq,PRange)
	DeployStuff(%player,%item,AmbusherAp,0,5,1,2,true,false,0);
}

function AmbusherAp::onAdd(%this)
{	if(%this.isbusy) return;
	%this.isBusy=true;
	schedule("AmbusherAp::deploy(" @ %this @ ");",1,%this);	
}

function AmbusherAp::deploy(%this)
{	%this.IsUp=true;
	%this.position=6;
	%this.move=-2;		// When Finished Sequence Packup & Move Down
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,1,"deploy");
}

function AmbusherAp::onEndSequence(%this,%thread)
{	%this.isBusy=false;
	if(%this.move==-2)
	{	startAmbushScan(%this);
		%this.move=0;
	}
	else if (%this.move==-1)
	{	AmbusherMove(%this,0);}
	else if(%this.move==0)
	{	GameBase::setActive(%this,true);}
}

function AmbusherAp::onDestroyed(%this)
{	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "AODAmbushAPPack"]--;
}

function AmbusherAp::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,8);
	%this.shieldStrength=0;
	GameBase::setActive(%this,true);
}

function AmbusherAp::packUp(%this, %pos, %client, %player)
{	PackUpStuff(%this,%client, %player,"m h","Ambusher AP Turret",false,AODAmbushAPPack);
}



//****************************************************
// AAOD Mod Deployable Kit
//************************************
// 	AODSamPack Backpack Script
//	AmbusherAA Script
// 	(SAM Missile Turret)
// 	SAMMissile

$InvList[AODAmbushAAPack] = 1;
$RemoteInvList[AODAmbushAAPack] = 1;


$ItemMax[lfemale, AODAmbushAAPack] = 0;
$ItemMax[mfemale, AODAmbushAAPack] = 1;
$ItemMax[larmor, AODAmbushAAPack] = 0;
$ItemMax[marmor, AODAmbushAAPack] = 1;
$ItemMax[harmor, AODAmbushAAPack] = 1;

$TeamItemMax[AODAmbushAAPack] = 2;


SeekingMissileData AmbusherAAShot 
{	bulletShapeName		= "rocket.dts";
	explosionTag		= rocketExp;
	collisionRadius		= 0.0;
	mass				= 2.0;
	damageClass			= 1;
	damageValue			= 0.4;
	damageType			= $AmbushAADamageType;
	explosionRadius		= 9.5;
	kickBackStrength	= 175.0;
	muzzleVelocity		= 65.0;
	totalTime			= 25;
	liveTime			= 25;
	seekingTurningRadius = 0.1;
	nonSeekingTurningRadius = 5.0;
	proximityDist		= 1.5;
	smokeDist			= 1.75;
	lightRange			= 5.0;
	lightColor			= { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId				= SoundJetHeavy;
};


ItemImageData AODAmbushAAPackImage 
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData AODAmbushAAPack 
{	description = "Anti Air Ambusher";
	shapeFile = "remoteturret";
	classname = "Backpack";
	heading = "dDeployables";
	imageType = AODAmbushAAPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODAmbushAAPack::Help(%client)
{	%msg=HelpTitle("Anti Air Ambusher Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Must be deployed on relatively flat terrain.");
	%msg=AddHelpLine(%msg,"This nasty guy 'hides' itself under the ground.");
	%msg=AddHelpLine(%msg,"When an enemy flies into range it 'pops' up");
	%msg=AddHelpLine(%msg,"and fires a salvo of 2 Ground to air Missiles!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
TurretData AmbusherAA 
{ 	classname = "Turret";
	shapeFile = "remoteturret";
	projectileType = AmbusherAAShot;
	maxDamage = 1.25;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay = 0.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Anti Air AMBUSHER";
	damageSkinData = "objectDamageSkins";
	pinger = false;
};


function AODAmbushAAPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function AODAmbushAAPack::onDeploy(%player,%item,%pos)
{	if (AODAmbushAAPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);
}

function AODAmbushAAPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PackName,PowerReq,PRange)
	DeployStuff(%player,%item,AmbusherAA,0,5,1,2,true,false,0);
}

function AmbusherAA::verifyTarget(%this,%target)
{	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
		return (true);
	else
		return (false);
} 

function AmbusherAA::onAdd(%this)
{	if(%this.isBusy) return;
	%this.isBusy=true;
	schedule("AmbusherAA::deploy(" @ %this @ ");",1,%this);
}

function AmbusherAA::deploy(%this)
{	%this.IsUp=true;
	%this.position=6;
	%this.move=-2;		// When Finished Sequence Packup & Move Down
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,1,"deploy");
}

function AmbusherAA::onEndSequence(%this,%thread)
{	%this.isBusy=false;
	if(%this.move==-2)
	{	startAmbushScan(%this);
		%this.move=0;
		
	}
	else if (%this.move==-1)
	{	AmbusherMove(%this,0);}
	else if(%this.move==0)
	{	GameBase::setActive(%this,true);}
}

function AmbusherAA::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODAmbushAAPack"]--;
}

function AmbusherAA::onPower(%this,%power,%generator)
{
}

function AmbusherAA::onEnabled(%this)
{	GameBase::setRechargeRate(%this,8);
	%this.shieldStrength = 0;
	GameBase::setActive(%this,true);
}

function AmbusherAA::packUp(%this, %pos, %client, %player)
{	%armor		= "m h";
	%desc		= "Ambusher Anti-Air turret";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODAmbushAAPack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//******************************************************
//			Begin Ambusher Special Functions
//******************************************************

function AmbusherWake(%this)
{	%this.time=0;
	%pos=GameBase::getPosition(%this);
	if($traceAll) echo("Ambusher Wakeup!! (",%this,")");
	playsound(AmbusherWake,%pos);
	// Move Into Position
	if(%this.isUp==false)
		AmbusherMove(%this,1);
}

function AmbusherSleep(%this)
{	playSound(AmbusherSleep,%pos);
	if($traceAll) echo("Ambusher goto Sleep (",%this,")");
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
	%this.move=-1;	// When Finished sequence Turret goes (Down)
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::playSequence(%this,1,"deploy");
}

// Once deployed it will go down in 6 Steps of 0.1 each
function AmbusherMove(%this,%dir)
{	if(%dir==1)	// Move Up
	{	if (%this.isUp)
			return;
		%this.position++;
		%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 0.105");
		GameBase::setPosition(%this,%pos);
		if($traceAll) echo("Ambusher Moving UP (",%this,") Direction ",%dir," Position = ",%this.position," Actual Position ",%pos);
		if (%this.position==6)
		{	%this.isUp=true;
			%this.move=0;
			GameBase::setSequenceDirection(%this,1,1);
			GameBase::playSequence(%this,1,"deploy");
		}
		else
			schedule("AmbusherMove("@%this@", 1);",0.1,%this);	
	}
	else if(%dir==0)
	{	if (!%this.isUp)
			return;
		%this.position--;
		%pos=GameBase::getPosition(%this);
		%pos=Vector::sub(%pos,"0 0 0.105");
		GameBase::setPosition(%this,%pos);
		if($traceAll) echo("Ambusher Moving DOWN (",%this,") Direction ",%dir," Position = ",%this.position," Actual Position ",%pos);
		if (%this.position==0)
		{	%this.isUp=false;
			%this.position=0;
			%this.move=0;
			Gamebase::setActive(%this,false);
		}
		else
			schedule("AmbusherMove("@%this@", 0);",0.1,%this);	
	}
}

function startAmbushScan(%this)
{	echo("Start Ambusher ground Scanning");
	if (%this.scanning==true)
		return;
	%this.scanning=true;
	AmbusherScan(%this);
}

function AmbusherScan(%this)
{	if($traceAll) echo($Ver,"| AmbusherScan (",%this,") (this is scanning= ",%this.scanning," Time elapsed ",%this.time);
	%set = newObject("set",SimSet);
	%pos=GameBase::getPosition(%this);
	if(%this.isAA)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType,%pos,240,240,0,240);
	}
	else
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType,%pos,80,80,80,0);
	}
	
	%team = GameBase::getTeam(%this);
	%slowScan=false;
	if (%tnum>0)
	{	// Players are within scan range
		// if($trace) echo($Ver,"| Someone is within Range of Ambusher...");
		for (%i=0;%i<%tnum;%i++)
		{	%plyr=Group::getObject(%set,%i);
			if(GameBase::getTeam(%plyr)!=%team)
			{
				if(%this.isAA)
				{	%targ=AmbusherAA::verifyTarget(%this,%plyr);
					if(%targ==True)
					{	// echo("Air Target Verified");
						AmbusherWake(%this);
						%t=%tnum;
						%slowScan=true;
					}
				}
				else
				{	// Activate Turret
					// echo("Ground Target Verified");
					AmbusherWake(%this);
					%t=%tnum;
					%slowScan=true;
				}
			}
		}
	}
	
	deleteObject(%set);

	if (%this.time>5)
	{	if (%this.isUp==true)
		{	AmbusherSleep(%this);
		}
		
	}
	else
		%this.time++;
	
	if(%slowScan==true)
	{	schedule("AmbusherScan("@%this@");",6,%this);
		%this.time=6;
	}
	else
		schedule("AmbusherScan("@%this@");",2,%this);
	
}

function AmbusherHelp()
{	HelpTitle("AAOD - Ambusher Turrets");
	AddHelpLine("Once deployed it will Burrow into the ground");
	AddHelpLine("When an enemy target is within range it will");
	AddHelpLine("Pop up and deploy, unleashing a surprise barrage!!");
	return ($HelpMessage);
}

//******************************************************
//			End of Ambusher Special Functions
//******************************************************




//***********************************
// AAOD Force Field Mods
//***********************************
$InvList[AODForce1Pack]		= 1;
$RemoteInvList[AODForce1Pack]		= 1;
$TeamItemMax[AODForce1Pack]		= 4;

$ItemMax[larmor, AODForce1Pack]		= 1;
$ItemMax[lfemale, AODForce1Pack]		= 1;
$ItemMax[marmor, AODForce1Pack]		= 1;
$ItemMax[mfemale, AODForce1Pack]		= 1;
$ItemMax[harmor, AODForce1Pack]		= 0;

ItemImageData FField1Image 
{	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.5 };
	mountRotation = { 0, 0, 0};
	mass = 2.5;
	firstPerson = false;
};

ItemData AODForce1Pack
{	description = "Small Force Field Lvl-1";
	shapeFile = "liqcyl";
	classname = "Backpack";
	heading = "fForceFields";
	imageType = FField1Image;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODForce1Pack::Help(%client)
{	%msg=HelpTitle("Small Force Field: Needs Power");
	%msg=AddHelpLine(%msg,"Can be deployed on Any surface.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData DeployableField1 
{	classname	= "ForceField";
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.25;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Small Force Field";
	shieldShapeName = "shield";
};

function AODForce1Pack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function AODForce1Pack::onDeploy(%player,%item,%pos)
{	if (DForceField::deployshape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODForce1Pack::onDestroyed(%this)
{	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODForce1Pack"]--;
}

function DeployableField1::packUp(%this, %pos, %client, %player)
{	%armor		= "l m h";
	%desc		= "Small Force Field";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODForce1Pack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//***********************************
// AAOD Force Field2
//***********************************
$InvList[AODForce2Pack]		= 1;
$RemoteInvList[AODForce2Pack]		= 1;
$TeamItemMax[AODForce2Pack]		= 2;

$ItemMax[larmor, AODForce2Pack]		= 0;	
$ItemMax[lfemale, AODForce2Pack]		= 0;	
$ItemMax[marmor, AODForce2Pack]		= 1;	
$ItemMax[mfemale, AODForce2Pack]		= 1;	
$ItemMax[harmor, AODForce2Pack]		= 0;	

ItemImageData Ffield2Image 
{	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.5 };
	mountRotation = { 0, 0, 0};
	mass = 2.5;
	firstPerson = false;
};

ItemData AODForce2Pack
{	description = "Large Force Field Lvl-2";
	shapeFile = "liqcyl";
	classname = "Backpack";
	heading = "fForceFields";
	imageType = Ffield2Image;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODForce2Pack::Help(%client)
{	%msg=HelpTitle("Large Force Field: Needs Power");
	%msg=AddHelpLine(%msg,"Can be deployed on any surface.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData DeployableField2 
{	shapeFile = "forcefield_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.25;
	maxEnergy = 40;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Large Force Field";
	shieldShapeName = "shield";
	classname	= "ForceField";
	
};

function AODForce2Pack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function AODForce2Pack::onDeploy(%player,%item,%pos)
{	if (DForceField::deployshape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}


function AODForce2Pack::onDestroyed(%this)
{	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODForce2Pack"]--;
}

function DeployableField2::packUp(%this, %pos, %client, %player)
{	%armor		= "m";
	%desc		= "large Force Field";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODForce2Pack;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

//-----------------------------------------------
// AAOD MOD Deployable Force Door Kit
// description = "Door 3x4 Force Field";
//-----------------------------------------------
$InvList[AODForceDoorS]	= 1;
$RemoteInvList[AODForceDoorS]	= 1;
$TeamItemMax[AODForceDoorS]	= 4;

$ItemMax[larmor, AODForceDoorS]	= 0;
$ItemMax[lfemale, AODForceDoorS]	= 0;
$ItemMax[marmor, AODForceDoorS]	= 1;
$ItemMax[mfemale, AODForceDoorS]	= 1;
$ItemMax[harmor, AODForceDoorS]	= 0;

ItemImageData AODForceDoorSImage
{       shapeFile = "liqcyl"; // Shape of the Backpack
        mountPoint = 2;
      	mountOffset = { 0, -0.5, -0.5 };
		mountRotation = { 0, 0, 0};
        mass = 2.5;
        firstPerson = false;
};

ItemData AODForceDoorS
{	description = "Small Force Door";
	shapeFile = "liqcyl";			// Shape of the Backpack
    classname = "Backpack";
    heading = "fForceFields";
    imageType = AODForceDoorSImage;
    shadowDetailMask = 4;
    mass = 2.5;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function AODForceDoorS::Help(%client)
{	%msg=HelpTitle("Small Force Door: Needs Power");
	%msg=AddHelpLine(%msg,"Can be deployed on any surface.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
StaticShapeData SmallForceDoor
{	classname = "ForceDoor";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_3x4";
	maxDamage = 4.0;
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
	description = "Small Force Door";
	fadeTime=2.5;
	shieldShapeName = "shield";
	
	
};


function AODForceDoorS::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AODForceDoorS::onDeploy(%player,%item,%pos)
{	if (DForceField::deployshape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function SmallForceDoor::Destruct(%this)
{	SmallForceDoor::doDamage(%this);
}

function SmallForceDoor::doDamage(%this) 
{	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function SmallForceDoor::onDestroyed(%this)
{	
	SmallForceDoor::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODForceDoorS"]--;
}

function SmallForceDoor::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
		return;
	%c = Player::getClient(%obj);
	if(!GameBase::IsPowered(%this))
	{	%pos=GameBase::getPosition(%this);
		playSound(ForceDoorUnActive,%pos);
		Client::sendMessage(%c,0,"Force Door is Busy...Please try again Later");
		return;
	}
	
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%c.talent[$Stealth]==2 || %fieldteam==%playerTeam)
		ForceDoor::openDoor(%this);
}

function SmallForceDoor::packUp(%this, %pos, %client, %player)
{	%armor		= "m";
	%desc		= "Small Force Door";
	%nopack		= false;			// does not have to have no pack on
	%pName		= AODForceDoorS;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//-----------------------------------------------
// AAOD MOD Deployable Force Door Kit
// description = "4x8 Force Field Door"
//-----------------------------------------------
$InvList[AODForceDoorL]	= 1;
$RemoteInvList[AODForceDoorL]	= 1;
$TeamItemMax[AODForceDoorL]	= 2;

$ItemMax[larmor, AODForceDoorL]	= 0;
$ItemMax[lfemale, AODForceDoorL]	= 0;
$ItemMax[marmor, AODForceDoorL]	= 1;
$ItemMax[mfemale, AODForceDoorL]	= 1;
$ItemMax[harmor, AODForceDoorL]	= 0;

ItemImageData AODForceDoorLImage
{	shapeFile = "liqcyl"; 
    mountPoint = 2;
	mountOffset = { 0, -0.5, -0.5 };
	mountRotation = { 0, 0, 0};
    mass = 2.5;
    firstPerson = false;
};

ItemData AODForceDoorL
{	description = "Large Force Door";
	shapeFile = "liqcyl";		
    classname = "Backpack";
    heading = "fForceFields";
    imageType = AODForceDoorLImage;
    shadowDetailMask = 4;
    mass = 2.5;
    elasticity = 0.2;
    price = 700;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function AODForceDoorL::Help(%client)
{	%msg=HelpTitle("Large Force Door: Needs Power");
	%msg=AddHelpLine(%msg,"Can be deployed on any surface.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData LargeForceDoor
{	classname = "ForceDoor";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x8";
	maxDamage = 4.0;
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
	description = "Large Force Door";
	shieldShapeName = "shield";
		
};


function AODForceDoorL::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);}
	else
    {	Player::deployItem(%player,%item);}
}

function AODForceDoorL::onDeploy(%player,%item,%pos)
{	if (DForceField::deployshape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function LargeForceDoor::Destruct(%this)
{	LargeForceDoor::doDamage(%this);
}

function LargeForceDoor::doDamage(%this) 
{	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function LargeForceDoor::onDestroyed(%this)
{	LargeForceDoor::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODForceDoorL"]--;
}

function LargeForceDoor::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
		return;
	%c = Player::getClient(%obj);
	if(!GameBase::IsPowered(%this))
	{	%pos=GameBase::getPosition(%this);
		playSound(ForceDoorUnActive,%pos);
		Client::sendMessage(%c,0,"Force Door is Busy...Please try again Later");
		return;
	}
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%c.talent[$Stealth]==2 || %fieldteam==%playerTeam) ForceDoor::openDoor(%this);
}

function LargeForceDoor::packUp(%this, %pos, %client, %player)
{	%armor		= "m";
	%desc		= "Large Force Door";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODForceDoorL;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


function DForceField::deployShape(%player,%item)
{	if(%item=="AODForce1Pack")
	{	%thishape="Small Force Field";
		%shape=DeployableField1;
	}
	else if(%item=="AODForce2Pack")
	{	%thishape="Large Force Field";
		%shape=DeployableField2;
	}
	else if(%item=="AODForceDoorS")
	{	%thishape="Small Force Door";
		%shape=SmallForceDoor;
	}
	else if(%item=="AODForceDoorL")
	{	%thishape="Large Force Door";
		%shape=LargeForceDoor;
	}
	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete,PowerReq,PRange)
	%ffield= DeployStuff(%player,%item,%shape,1,5,2,1,true,1,100);
	
	if(%ffield)
	{	%ffield.isBusy=false;
		echo("Field Power is ",%ffield.PowerReq);
		schedule("CheckPower("@%ffield@");",3,%ffield);
		
		return (true);
	}
	else
		return (false);

}

function CheckPower(%this)
{	Echo("Checking Forcefield Power");
	%this.Power=GameBase::isPowered(%this);
	if(!%this.Power)
	{	echo("this.powerset = ",%this.powerset);
		if(!this.powerset)	// Not connected to anything
		{	%client=%this.deployedby;
			Client::SendMessage(%client,0,"NO POWER - unable to sustain Field!~wAAODSFX50.wav");
			%pos=GameBase::getPosition(%this);
			playsound(ForceFieldFeedback,%pos);
			schedule("GameBase::setDamageLevel("@%this@",10);",3,%this);
		}
		else
		{	%this.isBusy=false;
			ForceDoor::OpenDoor(%this);
			%this.isBusy=false;
			%client=%this.deployedby;
			Client::SendMessage(%client,0,"POWER FAILURE - Field Power Depleted!!~wAAODSFX50.wav");
		}
		


	}
}

function ForceDoor::openDoor(%this) 
{	if(%this.isBusy==false)
	{	%this.isBusy=true;
		GameBase::startFadeOut(%this);
		%pos=GameBase::getPosition(%this);
		playSound(ForceDoorActivate,%pos);
		%pos=Vector::add(%pos,"0 0 -150");
		schedule("GameBase::playSound("@%this@","@ForceFieldOpen@",0);",1.0);
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",1.50);
		schedule("ForceDoor::closeDoor("@%this@");",5,%this);
	}
}

function ForceDoor::closeDoor(%this) 
{	if(%this.isBusy==true)	//Door is Open Close It
	{	%pos=GameBase::getPosition(%this);
		%pos=Vector::add(%pos,"0 0 150");
		GameBase::setPosition(%this,%pos);
		GameBase::startFadeIn(%this);
		playSound(ForceFieldClose,%pos);
		%this.isBusy=false;
	}
}

function ForceDoor::OnPower (%this,%power,%gen)
{	if(%power)
	{	if(%this.Power==false)
		{	%this.isBusy=true;
			ForceDoor::closeDoor(%this);
			%this.Power=true;
		}
	}
	else
	{	if(%this.Power=true)
		{	if(!%this.isBusy)
			{	%this.isBusy=false;
				ForceDoor::OpenDoor(%this);
			}
			%this.isBusy=false;
			%this.Power=false;
		}
			
	}
}

function ForceField::OnPower (%this,%power,%gen)
{	if(%power)
	{	if(%this.Power==false)
		{	%this.isBusy=true;
			ForceDoor::closeDoor(%this);
			%this.Power=true;
		}
	}
	else
	{	if(%this.Power=true)
		{	if(!%this.isBusy)
			{	%this.isBusy=false;
				ForceDoor::OpenDoor(%this);
			}
			%this.isBusy=false;
			%this.Power=false;
		}
			
	}
}



//************************************
// 	AODDefender Backpack Script
// 	(Defender Defense Turret)
//************************************

$InvList[AODDefender]			= 1;
$RemoteInvList[AODDefender]		= 1;
$TeamItemMax[AODDefender]		= 2;

$ItemMax[larmor, AODDefender]	= 1;
$ItemMax[lfemale, AODDefender]	= 1;
$ItemMax[marmor, AODDefender]	= 1;
$ItemMax[mfemale, AODDefender]	= 1;
$ItemMax[harmor, AODDefender]	= 1;

ExplosionData DesignatorExp
{	shapeName = "plasmaEx.DTS";		
	soundId=  SoundDefenderScan;	
	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=2.0;			
	timeZero=0.100;				
	timeOne=0.900;				
	colors[0]={0.0,0.0,0.0};	
	colors[1]={1.0,1.0,0.5};	
	colors[2]={0.0,1.0,0.0};	
	radFactors={0.0,1.0,0.0};	
	shiftPosition=False;		
};

BulletData TargetScan
{	bulletShapeName		= "plastrail.DTS";
	explosionTag		= DesignatorExp;		
	expRandCycle		= 0;				
	accufire			= true;
	mass				= 0.75;					
	collisionRadius		= 0.0;		
	bulletHoleIndex		= 0;			
	ExplosionRadius		= 1;			
	damageClass			= 0;			
	damageValue			= 6;						// Means something Diff for Designators
	damageType			= $DesignatorDamageType;
	muzzleVelocity		= 1000;	
	totalTime			= 1.5;			
	inheritedVelocityScale = 0.0;		
	isVisible			= True;			
	tracerPercentage	= 1.00;
	tracerLength		= 25;		
	detachFromShooter	= false;		
	rotationPeriod		= 0.25;			
	lightRange			= 4.0;			
	lightColor			= {0.75, 0.25,0.35};		
	hitSoundId			= SoundDefenderScan;
};


ItemImageData AODDefenderImage 
{	shapeFile	= "CAMERA";
	mountPoint	= 2;
	mass		= 2.0;
	firstPerson = false;
};

ItemData AODDefender 
{	description			= "Defender Designator";
	shapeFile			= "CAMERA";
	classname			= "Backpack";
	heading				= "jSensors & Detectors";
	imageType			= AODDefenderImage;
	shadowDetailMask	= 4;
	mass				= 3.0;
	elasticity			= 0.2;
	price				= 325;
	hudIcon				= "deployable";
	showWeaponBar		= true;
	hiliteOnActive		= true;
};


function AODDefender::Help(%client)
{	%msg=HelpTitle("Designator Defender Turret: Self Powered");
	%msg=AddHelpLine(%msg,"Can be deployed on any surface.");
	%msg=AddHelpLine(%msg,"Fires Temporary markers at incoming enemies.");
	%msg=AddHelpLine(%msg,"These Markers can be seen by any team member.");
	%msg=AddHelpLine(%msg,"They also have the range for mortars & artillery.");
	%msg=AddHelpLine(%msg,"Very Handy Defense Weapon.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


TurretData DefenderTurret 
{	classname			= "SensorNet";
	shapeFile			= "CAMERA";
	projectileType		= targetscan;
	maxDamage			= 0.75;
	maxEnergy			= 100;
	minGunEnergy		= 5;
	maxGunEnergy		= 15;
	sequenceSound[0]	= {"deploy", SoundActivateMotionSensor};
	reloadDelay			= 1;
	speed				= 4.5;
	speedModifier		= 1.5;
	range				= 400;
	visibleToSensor		= true;
	shadowDetailMask	= 4;
	dopplerVelocity		= 0;
	castLOS				= true;
	supression			= false;
	mapFilter			= 2;
	mapIcon				= "M_turret";
	debrisId			= flashDebrisSmall;
	shieldShapeName		= "shield";
	fireSound			= SoundFireDefender;
	activationSound		= SoundRemoteTurretOn;
	deactivateSound		= SoundRemoteTurretOff;
	explosionId			= flashExpMedium;
	description			= "Defender Turret";
	damageSkinData		= "objectDamageSkins";
	pinger				= false;
	lightColor			= { 0.75, 0.75, 0.85 };
};


function AODDefender::onUse(%player,%item)
{	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
	else 
	{	Player::deployItem(%player,%item); }
}

function AODDefender::onDeploy(%player,%item,%pos)
{	if (AODDefender::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function AODDefender::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,DefenderTurret,1,4,1,1,true,false,0);
}

function DefenderTurret::packUp(%this, %pos, %client, %player)
{	%armor		= "";
	%desc		= "Defender Designator";
	%nopack		= false;			// does not have to have no pack on
	%pName	= AODDefender;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function DefenderTurret::onAdd(%this)
{	schedule("DefenderTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.025;
	if (GameBase::getMapName(%this) == "") 
	{	GameBase::setMapName (%this, "Defender Turret");}
}

function DefenderTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function DefenderTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function DefenderTurret::onDestroyed(%this)
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODDefender"]--;
}

function DefenderTurret::onPower(%this,%power,%generator)
{}

function DefenderTurret::onEnabled(%this)
{	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}

//***********************************
// AAOD Mobile Bunker Pack
//***********************************
$InvList[AODBunker]		= 1;
$RemoteInvList[AODBunker]		= 0;
$TeamItemMax[AODBunker]		= 1;


$ItemMax[larmor, AODBunker]		= 0;
$ItemMax[lfemale, AODBunker]		= 0;
$ItemMax[marmor, AODBunker]		= 0;
$ItemMax[mfemale, AODBunker]		= 0;
$ItemMax[harmor, AODBunker]		= 1;

ItemImageData AODBunkerImage 
{	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};


ItemData AODBunker
{	description		= "Mobile Bunker";
	shapeFile		= "MagCargo";
	classname		= "Backpack";
	heading			= "gAAOD Deployables";
	imageType		= AODBunkerImage;
	shadowDetailMask = 4;
	mass			= 4.5;
	elasticity		= 0.2;
	price			= 1200;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODBunker::Help(%client)
{	%msg=HelpTitle("Portable Bunker: No Power Requirements");
	%msg=AddHelpLine(%msg,"Must be deployed on relative flat terrain.");
	%msg=AddHelpLine(%msg,"Provides a durable defendable shelter.");
	%msg=AddHelpLine(%msg,"of 5 walls in a u shape");
	%msg=AddHelpLine(%msg,"Excellent for establishing forward bases.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
StaticShapeData MobileBunker 
{	className		= "AAODDep";
	shapeFile		= "NewDoor5";
	debrisId		= defaultDebrisSmall;
	maxDamage		= 5.5;
	visibleToSensor = true;
	isTranslucent	= true;
	description		= "Mobile Bunker Wall";
	shieldShapeName = "shield";
};


function AODBunker::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODBunker::onDeploy(%player,%item,%pos)
{	if (AODBunker::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODBunker::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{	if (GameBase::getLOSInfo(%player,5)) 
		{	%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") 
			{	%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,20,15,15,0);
				deleteObject(%set);
				if(0 == %num) 
				{	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{		%rot = GameBase::getRotation(%player);
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
{	// StaticShape::onDestroyed(%this);
	// $TeamItemCount[GameBase::getTeam(%this) @ "AODBunker"]--;
}

function MobileBunker::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|Packup Mobile Bunker");
	%name = Client::getName(%client);
	%team = Client::getTeam(%client);
	// Must be Wearing Heavy Armor
	%armor = Player::getArmor(%client);
	%arm=String::getSubStr(%armor, 0, 1);
	if (%arm!="h")
	{	Client::sendMessage(%client,0,"Must be in Heavy Armour to Pack Up Mobile Bunker ~wError_Message.wav");
		return;
	}
	
	%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");

	// Must Have No Pack on....
	%isDamaged=false;
	for(%i=0;%i<3;%i++)
	{	%wall=$TeamBunker[%i @ %team];
		if(GameBase::getDamageLevel(%wall)) 
			%isDamaged=true;
	}
	if (!%isDamaged)
	{	// Pack up Bunker
		%player.isDeploying = true;
		%player.deployPosition = %pos;
		playSound(SoundBunkerDeploy,%pos);
		for (%i=0;%i<5;%i++)
		{	%wall=$TeamBunker[%i @ %team];
			GameBase::startFadeOut(%wall);
			schedule("deleteObject(" @ %wall @ ");",0.5,%wall);						
		}
		
		schedule("PlaceItemPack(" @ %player @ ",AODBunker," @ %pos @ ");",2,%player);
		Client::sendMessage(%client,0,"Packing Up Mobile Bunker ~wDoor2.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to Pack up Bunker.. One or more Walls are Damaged!~wError_message.wav");
	
}

//***********************************
// AAOD Mobile BlastShield Pack
//***********************************
$InvList[AODBlastShield]	= 1;
$RemoteInvList[AODBlastShield]	= 0;
$TeamItemMax[AODBlastShield]	= 4;

$ItemMax[larmor, AODBlastShield]	= 0;
$ItemMax[lfemale, AODBlastShield]	= 0;
$ItemMax[marmor, AODBlastShield]	= 1;
$ItemMax[mfemale, AODBlastShield]	= 1;
$ItemMax[harmor, AODBlastShield]	= 1;

ItemImageData AODBlastShieldImage 
{	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData AODBlastShield
{	description = "Mobile BlastShield";
	shapeFile = "MagCargo";
	classname = "Backpack";
	heading = "gAAOD Deployables";
	imageType = AODBlastShieldImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODBlastShield::Help(%client)
{	%msg=HelpTitle("Mobile Blask Shield: No Power Requirements");
	%msg=AddHelpLine(%msg,"Can be deployed on Any surface.");
	%msg=AddHelpLine(%msg,"provides a solid wall which must be destroyed.");
	%msg=AddHelpLine(%msg,"in order to get past.");
	%msg=AddHelpLine(%msg,"Excellent for blocking unused corridors & doors");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData MobileBlastShield 
{	shapeFile = "NewDoor5";
	className	= "AAODDep";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.5;
	visibleToSensor = true;
	isTranslucent = false;
	description = "Mobile BlastShield Wall";
	shieldShapeName = "shield";
};


function AODBlastShield::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODBlastShield::onDeploy(%player,%item,%pos)
{	if (AODBlastShield::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODBlastShield::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileBlastShield,1,5,0,0,true,false,0);
}

function MobileBlastShield::onDestroyed(%this)
{	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODBlastShield"]--;

}

function MobileBlastShield::packUp(%this, %pos, %client, %player)
{	%armor		= "m h";
	%desc		= "Mobile Blast Shield";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODBlastShield;

	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}


//***********************************
// AAOD Mobile Inventory Pack
//***********************************
$InvList[AODMobileInv]	= 1;
$RemoteInvList[AODMobileInv] = 0;
$TeamItemMax[AODMobileInv]	= 1;

$ItemMax[larmor, AODMobileInv]	= 0;
$ItemMax[lfemale, AODMobileInv]	= 0;
$ItemMax[marmor, AODMobileInv]	= 0;
$ItemMax[mfemale, AODMobileInv]	= 0;
$ItemMax[harmor, AODMobileInv]	= 1;

ItemImageData AODMobileInvImage 
{	shapeFile	= "MagCargo";
	mountPoint	= 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass			= 5.0;
	firstPerson = false;
};


ItemData AODMobileInv
{	description		= "Mobile Inventory Stn";
	shapeFile		= "inventory_sta";
	classname		= "Backpack";
	heading			= "gAAOD Deployables";
	imageType		= AODMobileInvImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 5000;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODMobileInv::Help(%client)
{	%msg=HelpTitle("Mobile Inventory Station: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Provides a Convenient Portable Inventory Station.");
	%msg=AddHelpLine(%msg,"Its expensive so defend it!!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData MobileInvent
{  description		= "Mobile Supply Unit";
	shapeFile		= "inventory_sta";
	classname		= "station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage		= 1.5;
	debrisId		= flashDebrisLarge;
	mapFilter		= 4;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius	= 1.5;
	explosionId		= flashExpLarge;
	shieldShapeName = "shield";
		
};

function AODMobileInv::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODMobileInv::onDeploy(%player,%item,%pos)
{	if (AODMobileInv::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function AODMobileInv::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,MobileInvent,1,5,0,0,false,1,100);
}


function MobileInvent::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"InvList");
}

function MobileInvent::packUp(%this, %pos, %client, %player)
{	PackUpStuff(%this,%client, %player,"h","Mobile Inventory Station",true,AODMobileInv);
}


//-------------------------------
// ******* Mobile Generator *****
//-------------------------------
$TeamItemMax[AODMobileGen]		= 2;
$InvList[AODMobileGen]		= 1;
$RemoteInvList[AODMobileGen]	= 0;

$ItemMax[larmor, AODMobileGen]		= 0;
$ItemMax[lfemale, AODMobileGen]	= 0;
$ItemMax[marmor, AODMobileGen]		= 0;
$ItemMax[mfemale, AODMobileGen]	= 0;
$ItemMax[harmor, AODMobileGen]		= 1;

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
	heading			= "hPower Deployables";
	imageType		= AODMobileGenImage;
	shadowDetailMask = 4;
	mass			= 4.5;
	elasticity		= 0.2;
	price			= 2500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODMobileGen::Help(%client)
{	%msg=HelpTitle("Portable Generator: Supplies Power");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Provides Power to any item within its power range.");
	%msg=AddHelpLine(%msg,"Good for forward Bases... or Backup power for");
	%msg=AddHelpLine(%msg,"Main Base.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

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
	DeployStuff(%player,%item,MobileGen,1,5,0,0,false,2,200);
	
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

function MobileGen::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|MobileGen::Packup");
	if(%this.isBusy)
	{	Client::SendMessage(%client,"Generator is Busy... try packing up later");
		return;
	}
	MobileGen::onDisabled(%this);
	%time=DisconnectGenerator(%this)+1;
	schedule("PackGen("@%this@","@%client@","@%player@");",%time);

}

function PackGen(%this,%client,%player)
{	if(PackUpStuff(%this,%client,%player,"h","Portable Generator",true,AODMobileGen)==false)
	{	MobileGen::onEnabled(%this);
		ConnectGenerator(%this);
	}
}

//------------------------------------
// ******* Portable solar Panel *******
// -----------------------------------
$InvList[AODPortaSolar]		= 1;
$RemoteInvList[AODPortaSolar]	= 1;

$ItemMax[larmor, AODPortaSolar]	= 1;
$ItemMax[marmor, AODPortaSolar]	= 1;
$ItemMax[harmor, AODPortaSolar]	= 1;
$ItemMax[lfemale, AODPortaSolar]	= 1;
$ItemMax[mfemale, AODPortaSolar]	= 1;

$TeamItemMax[AODPortaSolar] = 3;

ItemImageData AODPortaSolarImage 
{	shapeFile		= "magCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 2.5;
	firstPerson		= false;
};


ItemData AODPortaSolar
{	description		= "Portable Solar Panel";
	shapeFile		= "solar_med";
	classname		= "Backpack";
	heading			= "hPower Deployables";
	imageType		= AODPortaSolarImage;
	shadowDetailMask = 4;
	mass			= 1;
	elasticity		= 0.2;
	price			= 500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODPortaSolar::Help(%client)
{	%msg=HelpTitle("Portable Solar Array: Provides Power");
	%msg=AddHelpLine(%msg,"Must be deployed outdoors a flat surface.");
	%msg=AddHelpLine(%msg,"Supplies power to any item in its power range.");
	%msg=AddHelpLine(%msg,"Lighter than a portable generator it also cost a lot less");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData PortaSolar 
{	description		= "Portable Solar Panel";
	shapeFile		= "solar_med";
	classname		= "pGen";
	debrisId		= flashDebrisSmall;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
};

function AODPortaSolar::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODPortaSolar::onDeploy(%player,%item,%pos)
{	if (AODPortaSolar::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODPortaSolar::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	DeployStuff(%player,%item,PortaSolar,3,4,0,0,false,2,150);
}

function PortaSolar::onDestroyed(%this)
{	if($trace) echo($ver,"|PortaSolar::onDestroyed");
	PortaSolar::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	
}

function PortaSolar::onEnabled(%this)
{	if($trace) echo($ver,"|PortaSolar::onEnabled");
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
}

function PortaSolar::onDisabled(%this)
{	if($trace) echo($ver,"|PortaSolar::onDisabled");
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function PortaSolar::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|Portable Solar Panel::Packup");
	if(%this.isBusy)
		return;
	PortaSolar::onDisabled(%this);
	%time=DisconnectGenerator(%this)+1;
	schedule("PackSolar("@%this@","@%client@","@%player@");",%time);
}

function PackSolar(%this,%client,%player)
{	if(PackUpStuff(%this,%client,%player,"m h","Portable Solar Panel",true,AODPortaSolar)==false)
	{	PortaSolar::onEnabled(%this);
		ConnectGenerator(%this);
	}
}

//------------------------------------
// ******* Power Node   *******
// -----------------------------------
$InvList[AODPowerNode]			= 1;
$RemoteInvList[AODPowerNode]	= 1;

$ItemMax[larmor, AODPowerNode]	= 1;
$ItemMax[marmor, AODPowerNode]	= 1;
$ItemMax[harmor, AODPowerNode]	= 1;
$ItemMax[lfemale, AODPowerNode]	= 1;
$ItemMax[mfemale, AODPowerNode]	= 1;

$TeamItemMax[AODPowerNode] = 5;

ItemImageData AODPowerNodeImage 
{	shapeFile		= "sensor_small";
	mountPoint		= 2;
	mountOffset		= { 0, -0.15, 0 };
	mountRotation	= {-1.570796327, 0 , 0};
	mass			= 2.5;
	firstPerson		= false;
};


ItemData AODPowerNode
{	description		= "Remote Power Node";
	shapeFile		= "sensor_small";
	classname		= "Backpack";
	heading			= "hPower Deployables";
	imageType		= AODPowerNodeImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 750;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODPowerNode::Help(%client)
{	%msg=HelpTitle("PowerNode: Provides Power");
	%msg=AddHelpLine(%msg,"Can be deployed on any surface.");
	%msg=AddHelpLine(%msg,"** Requires a Satelite Power Center to work **");
	%msg=AddHelpLine(%msg,"Nodes recieve transmitted power and route that power");
	%msg=AddHelpLine(%msg,"to any Items in close proximity.)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData PowerNode 
{	description		= "Remote Power Node";
	shapeFile		= "sensor_small";
	classname		= "pGen";
	debrisId		= flashDebrisSmall;
	maxDamage		= 8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	sequenceSound[0] = { "power", SoundSatNode };
};

function AODPowerNode::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODPowerNode::onDeploy(%player,%item,%pos)
{	if (AODPowerNode::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODPowerNode::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%pNode=(DeployStuff(%player,%item,PowerNode,2,4,4,2,true,2,15));
	if(%pNode)
	{	%team=GameBase::getTeam(%pNode);
		if(!$PowerSatSet[%team])
		{	$PowerSatSet[%team]=newobject("set",SimSet);
			addtoSet("missionCleanup",$PowerSatSet[%team]);
		}
		addtoSet($PowerSatSet[%team],%pNode);
		PowerNode::onEnabled(%pNode);
		return (true);
	}
		
}

function PowerNode::onDestroyed(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onDestroyed");
	%team=GameBase::GetTeam(%this);
	PowerNode::onDisabled(%this);
	DisconnectGenerator(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	removeFromSet($PowerSatSet[%team],%this);
	$TeamItemCount[%team @ AODPowerNode]--;

}

function PowerNode::onEnabled(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onEnabled");
	%team=GameBase::getTeam(%this);
	if(GameBase::getDamageState($PowerSat[%team])=="Enabled")
	{	if(GameBase::isPowered($PowerSat[%team]))
		{	GameBase::setActive(%this,true);
			GameBase::playSequence(%this,0,"power");
			GameBase::generatePower(%this, true);
			GameBase::isPowerGenerator(%this);
		}
	}
}

function PowerNode::onDisabled(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onDisabled");
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}


function PowerNode::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|PowerNode::Packup");
	if(%this.isBusy)
		return;
	PowerNode::onDisabled(%this);
	%time=DisconnectGenerator(%this)+1;
	schedule("PackNode("@%this@","@%client@","@%player@");",%time);
}

function PackNode(%this,%client,%player)
{	if(PackUpStuff(%this,%client,%player,"","Power Node",true,AODPowerNode)==false)
	{	PowerNode::onEnabled(%this);
		ConnectGenerator(%this);
	}
}
	

//------------------------------------
// ******* Satellite Power System  *******
// -----------------------------------
$InvList[AODSatPwrSys]		= 1;
$RemoteInvList[AODSatPwrSys]	= 0;

$ItemMax[larmor, AODSatPwrSys]		= 0;
$ItemMax[marmor, AODSatPwrSys]		= 0;
$ItemMax[harmor, AODSatPwrSys]		= 1;
$ItemMax[lfemale, AODSatPwrSys]	= 0;
$ItemMax[mfemale, AODSatPwrSys]	= 0;

$TeamItemMax[AODSatPwrSys] = 1;

ItemImageData AODSatPwrSysImage 
{	shapeFile		= "magCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 8.0;
	firstPerson		= false;
};


ItemData AODSatPwrSys
{	description		= "Satelite Power System";
	shapeFile		= "sat_big";
	classname		= "Backpack";
	heading			= "hPower Deployables";
	imageType		= AODSatPwrSysImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 4500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODSatPwrSys::Help(%client)
{	%msg=HelpTitle("Satellite Power Distribution Centre: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed Outside on a flat surface.");
	%msg=AddHelpLine(%msg,"Transmits Power via Satelite to Remote Power Nodes.");
	%msg=AddHelpLine(%msg,"Power Nodes are More durable & portable than");
	%msg=AddHelpLine(%msg,"Generators or Solar Panels");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

StaticShapeData SatSystem 
{	description		= "Satelite Power System";
	shapeFile		= "sat_big";
	classname		= "pGen";
	debrisId		= flashDebrisLarge;
	maxDamage		= 15;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpLarge;
	visibleToSensor = true;
	mapFilter		= 4;
	sfxAmbient		= SoundSatSystem;
};

function AODSatPwrSys::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODSatPwrSys::onDeploy(%player,%item,%pos)
{	if (AODSatPwrSys::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODSatPwrSys::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%pSat=(DeployStuff(%player,%item,SatSystem,3,6,0,0,true,1,80));
	if(%pSat)
	{	%team=GameBase::getTeam(%pSat);
		if(!$PowerSatSet[%team])
		{	$PowerSatSet[%team]=newobject("set",SimSet);
			addtoSet("missionCleanup",$PowerSatSet[%team]);
		}
		$PowerSat[%team]=%pSat;
		return (true);
	}
}

function SatSystem::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|SatSystem::Packup");
	if(PackUpStuff(%this,%client, %player,"h","Satelite Power Transmitter",false,AODSatPwrSys))
	{ DeleteObject($PowerSat[%team]);
	}
}

function SatSystem::onAdd(%this)
{}

function SatSystem::onEnabled(%this)
{	%team=GameBase::getTeam(%this);
	if(GameBase::isPowered(%this))
	{	if(%team != -1)
		{	%tnum = Group::objectCount($PowerSatSet[%team]);
			if($tracePwr) echo( $ver@"|SatSystem::OnEnabled Activating Nodes ",%tnum," for Team ",%team);
			if (%tnum>0)
			{	for (%i=0;%i<%tnum;%i++)
				{	%tgt=Group::getObject($PowerSatSet[%team],%i);
					PowerNode::OnEnabled(%tgt);
				}
			}
			GameBase::setActive(%this,true);
			GameBase::playSequence(%this,0,"power");
		}
	}
}

function SatSystem::onDestroyed(%this)
{	if($trace) echo( $ver@"|SatSystem::onDestroyed");
	%team=GameBase::getTeam(%this);
	SatSystem::onDisabled(%this);
	$PowerSat[%team]=false;
}

function SatSystem::onDisabled(%this)
{	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($PowerSatSet[%team]);
	if($tracePwr) echo( $ver@"|SatSystem::OnDisAbled DE-Activating Nodes ",%tnum," for Team ",%team);
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject($PowerSatSet[%team],%i);
			PowerNode::OnDisabled(%tgt);
		}
	}
}


function SatSystem::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|SatSystem::onPower this|state|generator ",%this,%state,%generator);
	if (%state)
		SatSystem::onEnabled(%this);
	else
		SatSystem::onDisabled(%this);
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
			Client::SendMessage(%client,1,"Unable to connect to any Unpowered Items\nOn Standby");
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
	TeamMessages(0,%team,"Power for "@%mname@" routed to :"@%gname@"~wAAODSFX52.wav");
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
		{	Client::sendMessage(%client,1,"Unable to obtain Power!! Too far from any power generators!!~Werror_message.wav");
			return (false);
		}

	}
	return (true);
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
$ItemMax[marmor, AODShieldGen]		= 0;
$ItemMax[mfemale, AODShieldGen]	= 0;
$ItemMax[harmor, AODShieldGen]		= 1;

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
	heading			= "gAAOD Deployables";
	imageType		= AODShieldGenImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 1500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODShieldGen::Help(%client)
{	%msg=HelpTitle("Shield Generator: Needs Power");
	%msg=AddHelpLine(%msg,"Provides extra shielding to items Via Shield Nodes.");
	%msg=AddHelpLine(%msg,"Deploy Shield Nodes on or near Items which need extra Shielding");
	%msg=AddHelpLine(%msg,"** Causes LARGE Explosion when destroyed!! **");
	%msg=AddHelpLine(%msg,"(Critical piece of Equip. Defend well!!)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

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
	sequenceSound[0] = { "enable", SoundFabGenStart };
	sequenceSound[1] = { "power", SoundShieldGenerator };
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
	%gen=DeployStuff(%player,%item,ShieldGen,1,5,0,0,false,1,100);
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

function ShieldGen::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "Shield Generator";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODShieldGen;

	%result=PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
	if(%result==true)
	{	%team = Client::getTeam(%client);
		$ShieldGenOn[%team]=false;
		ActivateNodes(false,%team);
	}
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

//************************************
// 	AODShieldNode Backpack Script
//************************************
$InvList[AODShieldNode]	= 1;
$RemoteInvList[AODShieldNode]	= 1;
$TeamItemMax[AODShieldNode]	= 6;

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
	heading = "gAAOD Deployables";
	imageType = AODShieldNodeImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODShieldNode::Help(%client)
{	%msg=HelpTitle("Shield Node: Needs Shield Generator");
	%msg=AddHelpLine(%msg,"Can be deployed on Any surface.");
	%msg=AddHelpLine(%msg,"Provides a shield to the Item it is deployed on or near.");
	%msg=AddHelpLine(%msg,"using the bases power to protect the item");
	%msg=AddHelpLine(%msg,"(When destoryed the Shield generators Take feedback Damage)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

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
								Client::sendMessage(%client,0,"Shield Generator is NOT functioning!!");
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
					{	Client::sendMessage(%client,0,"Nothing to interface to.\n Node Must be placed close to an object which will have its shield boosted.~Werror_message.wav");}
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
{	echo("Node on End sequence");
	if(%this.position==1)	
		GameBase::playSequence(%this,0,"power");
}

function RemoteShieldNode::onDestroyed(%this)
{	if($trace) echo( $ver@"|Remote Shield Node::On destroyed");
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
		NewStaticShapeDamage($ShieldGen[%team],%this,%damageLevel,0.35);
	}
}

function RemoteShieldNode::onDisabled(%this)
{	if($trace) echo( $ver@"|Remote Shield Node on Disabled");
	GameBase::setRechargeRate(%this,0);
	Gamebase::setEnergy(%this,0);
	%this.Position=0;
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::playSequence(%this,1,"deploy");
	%this.shieldStrength = 0;
	
}

function RemoteShieldNode::onActivate(%this)
{	if($trace) echo( $ver@"|Remote Shield Node onActivate");
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
{	if($trace) echo( $ver@"|Shield Node - Enabled");
	if($trace) echo( $ver@"|Node ID = ",%this);
	RemoteShieldNode::onActivate(%this);
}

function RemoteShieldNode::onDeActivate(%this)
{	if($trace) echo( $ver@"|Shield Node - DeActivated");
	RemoteShieldNode::onDisabled(%this);
}

function RemoteShieldNode::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|Pack up Remote shield node");
	%name = Client::getName(%client);
	%team = Client::getTeam(%client);
	%pack=Player::getMountedItem(%player,$BackpackSlot);
	if($trace) echo( $ver@"|Player is wearing Pack Item :",%pack);
	if(%pack== -1)	// Must Have No Pack on....
	{	if($trace) echo( $ver@"|Shield Node Pickup Routine");
		if(!GameBase::getDamageLevel(%this))				// Node is Damaged
		{	if (!$ShieldGenOn[%team])
			{	Client::sendMessage(%client,0,"Shield Generator is NOT functioning!!/nUnable to Self-Repair Node..");
				return;
			}
			else
				Client::sendMessage(%client,0,"Shield Generator functioning/nRunning Node Self-Repair.");
		}
		for(%i=0;%i<=Group::objectCount($NodeSet[%team]);%i++)
		{	%node=Group::GetObject($NodeSet[%team],%i);
			if(%node==%this)
			{	removeFromSet($NodeSet[%team], %i);
			}
		}
		%boostObj				=%this.isGuarding;
		%BoostObj.shieldNode	="";
		%this.isGuarding		="";
		%pos=vector::add(Gamebase::getPosition(%this),"0 0 0.5");
		%player.isDeploying = true;
		%player.deployPosition = %pos;
		GameBase::startFadeOut(%this);
		schedule("deleteObject(" @ %this @ ");",1.75,%this);			
		schedule("PlaceItemPack(" @ %player @ ",AODShieldNode,\"" @ %pos @ "\");",2,%player);
		RemoteShieldNode::onDisabled(%this);
		echo("MSG: ",%client," Packed up a remote Shield Node");
	}
	else
		Client::sendMessage(%client,0,"Unable to Pack up Node.. You are wearing a Pack!~wError_message.wav");
}





//------------------------------------
// ******* Portable Launch Pad *******
// -----------------------------------
$InvList[AODJumpPad]			= 1;
$RemoteInvList[AODJumpPad]		= 1;
$TeamItemMax[AODJumpPad]		= 5;
$ItemMax[larmor, AODJumpPad]	= 1;
$ItemMax[marmor, AODJumpPad]	= 1;
$ItemMax[harmor, AODJumpPad]	= 1;
$ItemMax[lfemale, AODJumpPad]	= 1;
$ItemMax[mfemale, AODJumpPad]	= 1;

ItemImageData AODJumpPadImage 
{	shapeFile		= "FlagStand";
	mountPoint		= 2;
	mountOffset		= { 0, -0.15, 0.5 };
	mountRotation	= {  -1.570796327, 0 , 0};
	mass			= 1.0;
	firstPerson		= false;
};

ItemData AODJumpPad
{	description		= "Portable Jump Pad";
	shapeFile		= "FlagStand";
	classname		= "Backpack";
	heading			= "gAAOD Deployables";
	imageType		= AODJumpPadImage;
	shadowDetailMask = 4;
	mass			= 1;
	elasticity		= 0.2;
	price			= 500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData JumpPad 
{	description		= "Portable Jump Pad";
	shapeFile		= "FlagStand";
	classname		= "AAODDep";
	debrisId		= flashDebrisSmall;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
};

function AODJumpPad::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODJumpPad::onDeploy(%player,%item,%pos)
{	if (AODJumpPad::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODJumpPad::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	if(DeployStuff(%player,%item,JumpPad,1,4,0,2,true, false ,0))
		return (true);
}

function JumpPad::onAdd(%this)
{}

function JumpPad::onEnabled(%this)
{	GameBase::SetActive(%this,true);
}
function JumpPad::onDisabled(%this)
{	GameBase::SetActive(%this,false);
}
function JumpPad::onDestroyed(%this)
{	$TeamItemCount[GameBase::getTeam(%this) @ "AODJumpPad"]--;
}
function JumpPad::onCollision(%this,%object)
{	%team1=GameBase::getTeam(%this);
	%team2=GameBase::getTeam(%object);
	%pos=GameBase::getPosition(%this);
	%arm = String::getSubStr(Player::getArmor(%object),0,1);
	if (%arm=="l")
		%lift=400;
	else if(%arm=="m")
		%lift=600;
	else if (%arm=="h")
		%lift=800;
	// Give Beep
	playSound(ForceDoorActivate,%pos);
	// 1 Sec Delay
	// Apply Impulse Straight up from Pad
	%prot = GameBase::getRotation(%this);
	echo("Rotation ",%prot);
	%xRot = getWord(%prot,0);
	%yRot = getWord(%prot,1);
	%zRot = getWord(%prot,2);
	%v1=Sin(%xRot)*%lift;
	%Xf=Sin(%zrot)*%v1;	
	%Yf=Cos(%zrot)*%v1*-1;
	%Zf=Cos(%xRot)*%lift;
	%force = %Xf@" "@%Yf@" "@%Zf;
	if(%team1==%team2)
	{	schedule("Player::applyImpulse("@%object@",\""@%force@"\");",0.5,%object);
		schedule("playSound( JumpPadActivate,\""@%pos@"\");",0.5,%object);
	}
	else
	{	playSound(ErrorMsg,%pos);
		schedule("Player::applyImpulse("@%object@",\""@%force@"\");",0.5,%object);
		schedule("playSound( JumpPadActivate,\""@%pos@"\");",0.5,%object);
		%Xf=%Xf*-1;
		%Yf=%Yf*-1;
		%Zf=%Zf*-3;
		%force = %Xf@" "@%Yf@" " @ %Zf;
		schedule("Player::applyImpulse("@%object@",\""@%force@"\");",2.0,%object);
	}
	
}
function JumpPad::packUp(%this, %pos, %client, %player)
{	PackUpStuff(%this,%client, %player,"","Portable Jump Pad",true,AODJumpPad);
}

function JumpPad::onPower(%this, %state, %generator)
{}

function AODJumpPad::help(%client)
{	%msg=HelpTitle("Jump Pad: Self Powered, Deployes on any surface");
	%msg=AddHelpLine(%msg,"Launches players away from the surface");
	%msg=AddHelpLine(%msg,"It is deployed on.");
	%msg=AddHelpLine(%msg,"** has a nasty surprise for enemies who use it!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


//------------------------------------
// *******  Teleport Station  ********
// -----------------------------------
$InvList[AODTeleporter]		= 1;
$RemoteInvList[AODTeleporter]	= 1;

$ItemMax[larmor, AODTeleporter]	= 0;
$ItemMax[marmor, AODTeleporter]	= 1;
$ItemMax[harmor, AODTeleporter]	= 1;
$ItemMax[lfemale, AODTeleporter]	= 0;
$ItemMax[mfemale, AODTeleporter]	= 1;
$TeamItemMax[AODTeleporter]=2;


ExplosionData TeleportHop 
{	shapeName	= "Fusionbolt.dts";
	soundId		= SoundHFootLSoft;
	faceCamera	= true;
	randomSpin	= true;
	hasLight	= true;
	lightRange	= 10.0;
	timeScale	= 1.0;
	colors[0]	= { 1.0, 1.0, 0.0 };
	colors[1]	= { 1.0, 1.0, 0.75 };
	colors[2]	= { 1.0, 1.0, 0.75 };
	radFactors	= { 0.375, 1.0, 0.9 };
};

GrenadeData TeleportBeam 
{	explosionTag		= TeleportHop;
	collideWithOwner	= True;
	ownerGraceMS		= 50;
	collisionRadius		= 10.0;
	mass				= 0.1;
	elasticity			= 5.0;
	damageClass			= 1;
	damageValue			= 0.0;
	damageType			= $InfernoDamageType;
	explosionRadius		= 1.0;
	kickBackStrength	= 1.0;
	maxLevelFlightDist	= 2;
	totalTime			= 0.25;
	liveTime			= 0.25;
	projSpecialTime		= 0.1;
	lightRange			= 15.0;
	lightColor			= { 0.1, 1.0, 0.1 };
	inheritedVelocityScale = 0.5;
	smokeName			= "FusionEx.dts";
	// soundId				= ;
};

ItemImageData AODTeleporterImage 
{	shapeFile	= "MagCargo";
	mountPoint	= 2;
	mountOffset				= { 0, -0.65, -0.4 };
	mountRotation			= { 0, 0, 0 };
	mass		= 5.0;
	firstPerson = false;
};


ItemData AODTeleporter
{	description		= "Mobile Teleporter Pad";
	shapeFile		= "enerpad";
	classname		= "Backpack";
	heading			= "gAAOD Deployables";
	imageType		= AODTeleporterImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 4500;
	hudIcon			= "Deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData Teleporter 
{	description		= "Mobile Teleport Pad";
	shapeFile		= "enerpad";
	classname		= "AAODDep";
	debrisId		= flashDebrislarge;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= LargeShockwave;
	visibleToSensor = true;
	mapFilter		= 4;
	
};

StaticShapeData TeleporterNode
{	description		= "Mobile Teleport Pad";
	shapeFile		= "enerpad";
	classname		= "AAODDep";
	debrisId		= flashDebrislarge;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= LargeShockwave;
	visibleToSensor = true;
	mapFilter		= 4;
};

function AODTeleporter::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	%team=GameBase::getTeam(%player);
		Player::deployItem(%player,%item);
	}
}

function AODTeleporter::onDeploy(%player,%item,%pos)
{	%team=Gamebase::getTeam(%player);
	if($trace) echo($ver,"|",$User[%player]," Deployed a Teleporter ");
	if(!$Teleporter[%team])
	{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
		%result=DeployStuff(%player,%item,Teleporter,1,5,0,0,true,1,60);
		if(%result)
		{	//	Player Gets 5 Min to deploy Second Half....
			//	If Not Deployed By then it Self Destructs
			GameBase::setActive(%result,false);
			echo("teleport Main Pad Deployed");
			WarnPlayer(%player);
			%result.timer=$DeployPadTime;
			BeginCountdown(%result);
			$Teleporter[%team]=%result;
		}
	}
	else if ($Teleporter[%team])
	{	%result=DeployStuff(%player,%item,TeleporterNode,1,5,0,0,true,false,0);
		if(%result)
		{	//	Player has deployed Second Half....
			$TeleporterNode[%team]=%result;
			addtoset(GetGroup($Teleporter[%team]),%result);	// Stick in the same generator set as the main pad...
			Player::decItemCount(%player,%item);
			Teleporter::onEnabled($Teleporter[%team]);
			BeginCountdown($Teleporter[%team]);
		}
		
	}
}

function Teleporter::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|Teleporter::Packup");
	%armor		= "";
	%desc		= "Teleport Pad";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODTeleporter;
	if(PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName))
	{	WarnPlayer(%player);
		schedule("DetonateTeleporter("@%result@");",360,%result);
		$Teleporter[%team]=false;
	}
}

function TeleporterNode::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|TeleporterNode::Packup");
	%armor		= "";
	%desc		= "Teleport Node";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODTeleporter;
	if(PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName))
	{	WarnPlayer(%player);
		schedule("DetonateTeleporter("@%result@");",360,%result);
		$TeleporterNode[%team]=false;
	}
}

function WarnPlayer(%player)
{	if($trace) echo("Warning ",%player," of Teleport Danger");
	%client=player::getclient(%player);
	%message="<jc><f1><f4>WARNING...\nYou have "@$DeployPadTime@" seconds to Deploy Teleport Receiver\nUn-connected Teleport PAD will explode!!!";
	Client::SendMessage(%client,1,"~wAAODSFX51.WAV");
	schedule("CenterPrint("@%client@","@%message@",5);",2,%player);
	schedule("Client::SendMessage("@%client@",1,\"~wAAODSFX51.WAV\");",3,%player);
}

function BeginCountdown(%this)
{	if($trace) echo("Counting Down - Time is ",%this.timer);
	%team=GameBase::getTeam(%this);
	if(%this.isBusy)
	{	if($Teleporter[%team] && $TeleporterNode[%team])
		{	%this.isBusy=false;
			return;
		}
		if(%this.timer<=3)
		{	detonateTeleporter(%this);
			return;
		}
		if(%this.timer>=120)
		{	%Dec=60;
			schedule("BeginCountdown("@%this@");",60,%this);
			%wav="~wAAODSFX51.wav";
		}
		else if (%this.timer>=30)
		{	%Dec=20;
			schedule("BeginCountdown("@%this@");",20,%this);
			%wav="~wAAODSFX51.wav";
		}
		else
		{	%Dec=5;
			schedule("BeginCountdown("@%this@");",5,%this);
			%wav="~wAAODSFX53.wav";
		}
		%client=%this.Deployedby;
	}
	else
	{	%this.isBusy=true;
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
{	if($trace) echo( $ver@"|Teleporter::OnEnabled");
	if(GameBase::IsPowered(%this))
	{	%team=GameBase::getTeam(%this);
		GameBase::setActive(%this,true);
		GameBase::playSequence(%this,0,"on");
		if($TeleporterNode[%team])
		{	GameBase::setActive($TeleporterNode[%team],true);
			GameBase::playSequence($TeleporterNode[%team],0,"on");
		}
	}
}

function TeleporterNode::onEnabled(%this)
{	if($trace) echo( $ver@"|TeleporterNode::OnEnabled");
	%team=GameBase::getTeam(%this);
	Teleporter::onEnabled($Teleporter[%team]);
}

function Teleporter::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	%team=GameBase::getTeam(%this);
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	StaticShape::onDamage($TeleporterNode[%team],%type,%value,%pos,%vec,%mom,%object);
}
function TeleporterNode::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	%team=GameBase::getTeam(%this);
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	StaticShape::onDamage($Teleporter[%team],%type,%value,%pos,%vec,%mom,%object);
}

function Teleporter::onDestroyed(%this)
{	if($trace) echo( $ver@"|Teleporter::onDestroyed");
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
{	if($trace) echo( $ver@"|TeleporterNode::onDestroyed");
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
}


function Teleporter::onDisabled(%this)
{	if($trace) echo( $ver@"|Teleporter::onDisabled");
	%team=GameBase::getTeam(%this);
	GameBase::setActive(%this,false);
	GameBase::stopSequence(%this,0);
	GameBase::setActive($TeleporterNode[%team],false);
	GameBase::stopSequence($TeleporterNode[%team],0);
}

function TeleporterNode::onDisabled(%this)
{	if($trace) echo( $ver@"|TeleporterNode::onDisabled");
	%team=GameBase::getTeam(%this);
	Teleporter::onDisabled($Teleporter[%team]);
}

function Teleporter::onCollision(%this,%object)
{	%Team=GameBase::getTeam(%this);
	if(%this.isBusy)
	{	if(%this.teleported==%object)
			return;
		else
			Client::SendMessage(%object,0,"Teleport Pad is busy~wAAODSFX15.WAV");
			return;
	}
	else
		%this.isBusy=true;
	if(GameBase::isActive(%this))
	{	if(!$TeleporterNode[%team])
			return;
		%ObjTeam=Gamebase::getTeam(%object);
		if(%Team==%Objteam || %object.talent[$Stealth]==2)
		{	%node=$TeleporterNode[%team];
			if (teleport(%node,%object))
			{	%pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.08");
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
{	%Team=GameBase::getTeam(%this);
	if($Teleporter[%team].isBusy)
	{	if($Teleporter[%team].teleported==%object)
			return;
		else
			Client::SendMessage(%object,0,"Teleport Pad is busy~wAAODSFX15.WAV");
			return;
	}
	$Teleporter[%team].isBusy=true;
	if(GameBase::isActive(%this))
	{	if(!$Teleporter[%team])
			return;
		%ObjTeam=Gamebase::getTeam(%object);
		if(%Team==%Objteam || %object.talent[$Stealth]==2)
		{	%node=$Teleporter[%team];
			if(teleport(%node,%object))
			{	%pos1=vector::add(GameBase::getPosition(%this),"0 0 -0.15");
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
{	%rot="1.570796 0.000000 0.000000"; 
	%pos=vector::add(GameBase::getPosition(%this),"0 0 1");
	%trans=	"-1.570796 0.000000 0.000000 0.000000 0.000000 2.500000 "@%rot@" "@%pos;
	%transx=GameBase::getMuzzleTransform(%object);
	%vel=Item::getVelocity(%this);
	Projectile::spawnProjectile("TeleportBeam",%trans,%object,%vel);
	schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.25);
	schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.5);
	schedule("Projectile::spawnProjectile(\"TeleportBeam\",\""@%trans@"\","@%object@",\""@%vel@"\");",0.75);
	
}


function DetonateTeleporter(%this)
{	if($trace) echo( $ver@"|Detonate Teleporter");
	%team=GameBase::GetTeam(%this);
	TeamMessages(%team,0,"Teleporter Pad CRITICAL!~wAAODSFX53.wav");
	%pos=GameBase::getPosition(%this);
	playsound(ForceFieldFeedback,%pos);
	schedule("GameBase::setDamageLevel("@%this@",10);",3,%this);
	
	%player = Client::getOwnedObject(%this.deployedby);
	if (Player::getMountedItem(%player,$BackpackSlot) == AODTeleporter)
    {	%item=Player::dropItem(%player,AODTeleporter);
		$AODTeleporter[%team].isBusy=true;
	}
	schedule("DetonateTelePack("@%team@");",1);
}

function DetonateTelepack(%team)
{	%Pos2=GameBase::getPosition($TeleportPack[%team]);
	echo("Detonating teleportPack: pack  is ",$TeleportPack[%team]," and is located at ",%Pos2);
	if($TeleportPack[%team])
	{	deleteObject($TeleportPack[%team]);
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
{	if($trace) echo("Telport pad ",%this," teleporting ",%object);
	%team=gameBase::getTeam(%this);
	if(!$Teleporter[%team].Teleported)
	{	$Teleporter[%team].Teleported=%object;
		return(true);
	}
	return(false);
}

function ResetTeleporter(%this)
{	if($trace) echo("Telport pad ",%this," Resetting ",%object);
	%team=gameBase::getTeam(%this);
	$Teleporter[%team].Teleported=false;
	$Teleporter[%team].isBusy=false;
}

function Teleporter::onPower(%this, %state, %generator)
{	if(%state)
		Teleporter::onEnabled(%this);
	else
		Teleporter::onDisabled(%this);
}


function AODTeleporter::Help(%client)
{	%msg=HelpTitle("Teleporter Pad: 1st Pad needs Power, Deploys on FLAT surf.");
	%msg=AddHelpLine(%msg,"Pack contains 2 pads - You MUST Deploy BOTH pads.");
	%msg=AddHelpLine(%msg,"within 5 minutes. Pads are linked. When");
	%msg=AddHelpLine(%msg,"one is damaged so is the other.");
	%msg=AddHelpLine(%msg,"Great for establishing forward bases");
	%msg=AddHelpLine(%msg,"Unlimited Range.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


//------------------------------------
// ******* Anti Battery Sensor *******
// -----------------------------------
$InvList[AODCounterBattery]		= 1;
$RemoteInvList[AODCounterBattery]	= 1;

$ItemMax[larmor, AODCounterBattery]	= 1;
$ItemMax[marmor, AODCounterBattery]	= 1;
$ItemMax[harmor, AODCounterBattery]	= 1;
$ItemMax[lfemale, AODCounterBattery]	= 1;
$ItemMax[mfemale, AODCounterBattery]	= 1;

$TeamItemMax[AODCounterBattery] = 1;

ItemImageData AODCounterBatteryImage 
{	shapeFile	= "magCargo";
	mountPoint	= 2;
	mountOffset				= { 0, -0.65, -0.4 };
	mountRotation			= { 0, 0, 0 };
	mass		= 1.0;
	firstPerson = false;
};


ItemData AODCounterBattery
{	description		= "Counter Battery Sensor";
	shapeFile		= "sensor_pulse_med";
	classname		= "Backpack";
	heading			= "jSensors & Detectors";
	imageType		= AODCounterBatteryImage;
	shadowDetailMask = 4;
	mass			= 1;
	elasticity		= 0.2;
	price			= 500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData CounterBattery 
{	description		= "Counter Battery Sensor";
	shapeFile		= "sensor_pulse_med";
	classname		= "SensorNet";
	debrisId		= flashDebrisSmall;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	sequenceSound[0] = { "power", SoundSensorPower };
};

function AODCounterBattery::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODCounterBattery::onDeploy(%player,%item,%pos)
{	if (AODCounterBattery::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function AODCounterBattery::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	return(DeployStuff(%player,%item,CounterBattery,1,4,0,0,true,1,150));
}

function CounterBattery::onAdd(%this)
{}

function CounterBattery::onEnabled(%this)
{	if($trace) echo( $ver@"|CounterBattery::OnEnabled");
	if(GameBase::isPowered(%this))
	{	%team=GameBase::getTeam(%this);
		GameBase::setActive(%this,true);
		GameBase::playSequence(%this,0,"power");
		$CounterBattery[%team]=%this;
	}
}

function CounterBattery::onDestroyed(%this)
{	if($trace) echo( $ver@"|CounterBattery::onDestroyed");
	CounterBattery::onDisabled(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODCounterBattery"]--;
}

function CounterBattery::onDisabled(%this)
{	if($trace) echo( $ver@"|CounterBattery::onDisabled");
	%team=GameBase::getTeam(%this);
	GameBase::setActive(%this,false);
	GameBase::stopSequence(%this,0);
	$CounterBattery[%team]=%false;
}

function CounterBattery::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|CounterBattery::Packup");
	CounterBattery::onDisabled(%this);
	%armor		= "h";
	%desc		= "Anti-Battery Sensor";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODCounterBattery;
	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function CounterBattery::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|CounterBattery::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		CounterBattery::onEnabled(%this);
	else
		CounterBattery::onDisabled(%this);
}


function CounterBatteryCheck(%this)
{	%team=GameBase::getTeam(%this);
	%enemy=GetEnemyTeam(%team);
	if($CounterBattery[%enemy])	Designatetarget(%this,$CBMarkerDuration,false);
}


function ResetTarget(%this)
{	%this.isMarked=false;
}
function SetTarget(%this,%mark)
{	%this.isMarked=%mark;
}

function AODCounterBattery::Help(%client)
{	%msg=HelpTitle("Counter Battery Sensor: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed Outside on a flat surface.");
	%msg=AddHelpLine(%msg,"Detects Incoming Mortar & artillery Fire.");
	%msg=AddHelpLine(%msg,"Designates the source as a return target.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
//----------------------------------
// ***** Fabrication Generator *****
//----------------------------------
$InvList[AODTeamEGen]			= 1;
$RemoteInvList[AODTeamEGen]		= 0;

$ItemMax[larmor, AODTeamEGen]	= 0;
$ItemMax[marmor, AODTeamEGen]	= 0;
$ItemMax[harmor, AODTeamEGen]	= 1;
$ItemMax[lfemale, AODTeamEGen]	= 0;
$ItemMax[mfemale, AODTeamEGen]	= 0;

$TeamItemMax[AODTeamEGen]		= 6;	// Generic Team Item Max

ItemImageData AODTeamEGenImage 
{	shapeFile	= "Generator_p";
	mountPoint	= 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass		= 5.0;
	firstPerson = false;
};

ItemData AODTeamEGen
{	description		= "Fabrication Generator";
	shapeFile		= "generator_p";
	classname		= "Backpack";
	heading			= "iTEAM ENERGY Stuff";
	imageType		= AODTeamEGenImage;
	shadowDetailMask = 4;
	mass			= 4.5;
	elasticity		= 0.2;
	price			= 2500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData TeamEngGen 
{	description		= "Fabrication Generator";
	shapeFile		= "generator_p";
	classname		= "TeamEGen";
	debrisId		= flashDebrisSmall;
	sequenceSound[0] = { "enable", SoundFabGenStart };
	sequenceSound[1] = { "power", SoundFabGenerator };
	maxDamage		= 1.8;
	mapIcon			= "M_generator";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask= 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	shieldShapeName = "shield";
};

function AODTeamEGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODTeamEGen::onDeploy(%player,%item,%pos)
{	if (AODTeamEGen::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function AODTeamEGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%gen=DeployStuff(%player,%item,TeamEngGen,1,5,0,0,false,1,80);
	if(%gen)
	{	
		echo("MSG: ",%client,"Team Energy Generator deployed. Team Energy Recovery has been Boosted!");
		return (true);
	}	
}

function TeamEngGen::packUp(%this, %pos, %client, %player)
{	%armor		= "h";
	%desc		= "Fabrication Generator";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODTeamEGen;
	
	TeamEngGen::OnDisabled(%this);

	if(PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName))
	{	echo("MSG: ",%client,"Team Energy Generator Packed UP! Team Energy Recovery has been reduced!");
	}
}

function TeamEngGen::onDestroyed(%this)
{	if($trace) echo( $ver@"|TeamEngGen::OnDestroyed");
	%team=GameBase::getTeam(%this);
	TeamEngGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	TeamEnergyGenLost(%this,$ClassAIncrease);
}

function TeamEngGen::onEnabled(%this)
{	if($trace) echo( $ver@"|TeamEngGen::OnEnabled");
	if(GameBase::isPowered(%this))
	{	GameBase::setActive(%this,true);
		GameBase::playSequence(%this,0,"power");
		%team=GameBase::getTeam(%this);
		GenerateTeamEnergy(%this,"A",true);
	}
}

function TeamEngGen::onDisabled(%this)
{	if($trace) echo( $ver@"|TeamEngGen::On Disabled");
	GameBase::stopSequence(%this,0);
	GameBase::setActive(%this,false);
	%team=GameBase::getTeam(%this);
	GenerateTeamEnergy(%this,"A",false);
}


function TeamEngGen::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|TeamEngGen::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		TeamEngGen::OnEnabled(%this);
	else
		TeamEngGen::OnDisabled(%this);

}

function AODTeamEGen::Help(%client)
{	%msg=HelpTitle("Team Energy Generator: Needs Power");
	%msg=AddHelpLine(%msg,"Must be deployed on a flat surface.");
	%msg=AddHelpLine(%msg,"Converts Power into team Energy.");
	%msg=AddHelpLine(%msg,"Team Energy is used to 'buy' stuff at stations");
	%msg=AddHelpLine(%msg,"(Critical piece of Equip. Defend well!!)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
//---------------------------------
// End Fabrication Generator
//---------------------------------


//-----------------------------------------
// ******* Solar Fabrication Panels *******
// ----------------------------------------
$InvList[AODSolarTEGen]				= 1;
$RemoteInvList[AODSolarTEGen]		= 1;

$ItemMax[larmor, AODSolarTEGen]		= 0;
$ItemMax[marmor, AODSolarTEGen]		= 0;
$ItemMax[harmor, AODSolarTEGen]		= 1;
$ItemMax[lfemale, AODSolarTEGen]	= 0;
$ItemMax[mfemale, AODSolarTEGen]	= 0;

$TeamItemMax[AODSolarTEGen]			= 1;


ItemImageData AODSolarTEGenImage 
{	shapeFile		= "magCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 3.0;
	firstPerson		= false;
};


ItemData AODSolarTEGen
{	description		= "Solar Eng-Generator";
	shapeFile		= "solar";
	classname		= "Backpack";
	heading			= "iTEAM ENERGY Stuff";
	imageType		= AODSolarTEGenImage;
	shadowDetailMask = 4;
	elasticity		= 0.2;
	price			= 4500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData SolarFGen 
{	description		= "Solar Eng-Generator";
	shapeFile		= "solar";
	classname		= "TeamEGen";
	debrisId		= flashDebrisSmall;
	maxDamage		= 2;
	mapIcon			= "M_station";
	damageSkinData	= "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId		= flashExpMedium;
	visibleToSensor = true;
	mapFilter		= 4;
	sfxAmbient		= SoundFabGenerator;
	shieldShapeName = "shield_large";
	maxEnergy		= 150;
};

function AODSolarTEGen::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODSolarTEGen::onDeploy(%player,%item,%pos)
{	if (AODSolarTEGen::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODSolarTEGen::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%gen=DeployStuff(%player,%item,SolarFGen,3,6,0,0,true,false,0);
	if(%gen)
	{	echo("MSG: ",%client,"SOLAR Team Energy Generator deployed. Team Energy Recovery has been Boosted!");
		return (true);
	}
}

function SolarFGen::packUp(%this, %pos, %client, %player)
{	if($traceTE) echo( $ver@"|SolarFGen::Packup");
	SolarFGen::OnDisabled(%this);
	if(PackUpStuff(%this,%client, %player,"h","Solar Fabricatiuon Generator",false,AODSolarTEGen))
		echo("MSG: ",%client,"SOLAR Team Energy Generator Packed Up. Team Energy Recovery has been Reduced!");
}

function SolarFGen::onAdd(%this)
{}

function SolarFGen::onEnabled(%this)
{	if($traceTE) echo( $ver@"|SolarFGen::OnEnabled");
	GameBase::setActive(%this,true);
	%team=GameBase::getTeam(%this);
	GenerateTeamEnergy(%this,"B",true);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.01;
}

function SolarFGen::onDestroyed(%this)
{	if($traceTE) echo( $ver@"|SolarFGen::onDestroyed");
	SolarFGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	TeamEnergyGenLost(%this,$ClassBIncrease);
	$TeamItemCount[GameBase::getTeam(%this) @ "AODSolarTEGen"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function SolarFGen::onDisabled(%this)
{	if($traceTE) echo( $ver@"|SolarFGen::onDisabled");
	%team=GameBase::getTeam(%this);
	GenerateTeamEnergy(%this,"B",false);
	GameBase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0.0;
}

function AODSolarTEGen::Help(%client)
{	%msg=HelpTitle("Solar Energy Generator: Provides own Power");
	%msg=AddHelpLine(%msg,"Must be deployed OUTSIDE on a flat surface.");
	%msg=AddHelpLine(%msg,"Converts solar Power into team Energy.");
	%msg=AddHelpLine(%msg,"Team Energy is used to 'buy' stuff at stations");
	%msg=AddHelpLine(%msg,"(Critical piece of Equip. Defend well!!)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

//----------------------------------------------------
//************** Team Energy Functions ***************
//----------------------------------------------------
function GenerateTeamEnergy(%this,%set,%status)
{	if($traceTE) echo("Generate team Energy ",%this," ",%set," ",%status);
	%team=GameBase::GetTeam(%this);
	if(%team==-1)
	{	echo("Item ",%this," Does not have a valid team yet");
		schedule("GenerateTeamEnergy("@%this@","@%set@","@%status@");",2,%this);	// Retry in a couple of secoonds
		return;
	}
	if(%set=="A"||%set=="a")
	{	if($ClassAGen[%team]=="")
		{	echo("Power Set for This Fabrication Gen does not exist for this team");
			$ClassAGen[%team]=newObject("Set",SimSet);
			AddToSet("MissionCleanup",$ClassAGen[%team]);
			if ($traceTE) echo("Team Energy Generator Set for ",%this," did not exist - Created it ",$ClassAGen[%team]," Team is ",%team);
		}
		if(%status)
			%res = AddToSet($ClassAGen[%team],%this);
		else
			%res = removeFromSet($ClassAGen[%team],%this);

	}
	if(%set=="B"||%set=="b")
	{	if($ClassBGen[%team]=="")
		{	$ClassBGen[%team]=newObject("Set",SimSet);
			AddToSet("MissionCleanup",$ClassBGen[%team]);
			if ($traceTE) echo("Power Set for ",%this," did not exist - Created it ",$ClassBGen[%team]," Team is ",%team);
		}
		if(%status)
			%res = AddToSet($ClassBGen[%team],%this);
		else
			%res = removeFromSet($ClassBGen[%team],%this);
		%numb=Group::ObjectCount($ClassBGen[%team]);
		if($traceTE) echo("Added Panel to Powerset result is ",%res," Num Gen = ",%numb);

	}

	if($traceTE) echo("Fab Generator ",%this," Status Requested =",%status," Result = (",%res,")");
}


function TeamEnergyGenLost(%this,%GenVal)
{	%team=GameBase::getTeam(%this);
	%energy=600;
	if($TeamItemCount[%team@AODSolarTEGen]>0) %energy+=($TeamItemCount[%team@AODSolarTEGen]*$ClassBIncrease);
	if($TeamItemCount[%team@AODTeamEGen]>0) %energy+=($TeamItemCount[%team@AODTeamEGen]*$ClassAIncrease);
	
	%mod=%GenVal/%energy;
	if(%mod>0.75) %mod=0.75;
	if($TraceTE) echo("%",%mod*100," percent of Team Energy will be lost");

	%loss=$TeamEnergy[%team]*%mod;

	if($traceTE) echo("*** Team Energy Loss! Gen Value = ",%genVal," Total Energy Gen = ",%energy ," loss = ",%loss);

	$TeamEnergy[%team]-=%loss;

	if(%team==0)
		%enemy=1;
	else
		%enemy=0;
	
	$TeamEnergy[%enemy]+=%loss;
	%cl=%this.lastDamagedObject;
	%name=Client::GetName(%cl);
	%teamName=GetTeamname(%team);
	%msg=%name@" destroyed the "@%TeamName@" Fabrication Generator and recovered "@%loss@" pts of Team Energy!!~wAAODSFX54.WAV";
	
	TeamMessages(%enemy,%msg);
	echo(%msg);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++

//-----------------------------
// ******* Alarm System *******
// ----------------------------
$InvList[AODAlarm]			= 1;
$RemoteInvList[AODAlarm]	= 1;

$ItemMax[larmor, AODAlarm]		= 0;
$ItemMax[marmor, AODAlarm]		= 0;
$ItemMax[harmor, AODAlarm]		= 1;
$ItemMax[lfemale, AODAlarm]	= 0;
$ItemMax[mfemale, AODAlarm]	= 0;

$TeamItemMax[AODAlarm] = 1;

ItemImageData AODAlarmImage 
{	shapeFile		= "magCargo";
	mountPoint		= 2;
	mountOffset		= { 0, -0.65, -0.4 };
	mountRotation	= { 0, 0, 0 };
	mass			= 3.0;
	firstPerson		= false;
};


ItemData AODAlarm
{	description		= "Base Alarm system";
	shapeFile		= "anten_lrg";
	classname		= "Backpack";
	heading			= "jSensors & Detectors";
	imageType		= AODAlarmImage;
	shadowDetailMask = 4;
	mass			= 1;
	elasticity		= 0.2;
	price			= 500;
	hudIcon			= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

StaticShapeData Alarm 
{	description			= "Base Alarm System";
	shapeFile			= "anten_lrg";
	classname			= "SensorNet";
	debrisId			= flashDebrisSmall;
	maxDamage			= 15;
	mapIcon				= "M_sensor";
	damageSkinData		= "objectDamageSkins";
	shadowDetailMask	= 16;
	explosionId			= flashExpMedium;
	visibleToSensor		= true;
	mapFilter			= 4;
	range				= 250;
	activationSound		= ForceFieldFeedBack;
	deactivationSound	= ForceFieldFeedBack;
	sequenceSound[0]	= { "power" , SoundAlarmSystem };
};

function AODAlarm::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
    {	Player::mountItem(%player,%item,$BackpackSlot);}
    else
	{	Player::deployItem(%player,%item);}
}

function AODAlarm::onDeploy(%player,%item,%pos)
{	if (AODAlarm::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function AODAlarm::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	return(DeployStuff(%player,%item,Alarm,3,4,0,2,true,1,150));
}

function Alarm::onAdd(%this)
{}

function Alarm::onEnabled(%this)
{	if($trace) echo( $ver@"|Alarm::OnEnabled");	
	if(GameBase::isPowered(%this))
	{	%team=GameBase::getTeam(%this);
		GameBase::setActive(%this,true);
		GameBase::playSequence(%this,0,"power");
		$Alarm[%team]=true;
	}
}


function Alarm::onDisabled(%this)
{	if($trace) echo( $ver@"|Alarm::onDisabled");
	ItemIsNotBusy(%this);
	$Alarm[%team]=false;
}

function Alarm::onActivate(%this)
{	if($trace) echo( $ver@"|Alarm::onActivate");
}
function Alarm::onDeactivate(%this)
{	if($trace) echo( $ver@"|Alarm::onDeactivate");
}
function SensorNet::onActivate(%this)
{	if($trace) echo( $ver@"|SensorNet::onActivate");
}

function SensorNet::onDeActivate(%this)
{	if($trace) echo( $ver@"|SensorNet::onDeActivate");
}

function Alarm::packUp(%this, %pos, %client, %player)
{	if($trace) echo( $ver@"|Alarm::Packup");
	%armor		= "";
	%desc		= "Sat Power System";
	%nopack		= true;			// does not have to have no pack on
	%pName	= AODAlarm;
	PackUpStuff(%this,%client, %player,%armor,%desc,%nopack,%pName);
}

function Alarm::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|Alarm::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		Alarm::onEnabled(%this);
	else
		Alarm::onDisabled(%this);
}

function ResetAlarm(%this)
{	%this.Alarm=false;
}

function SoundAlarm(%this,%enemy,%team)
{	%this.Alarm = true;
	Schedule("ResetAlarm("@%this@");",120);
	%Item=GameBase::getDataName(%this);
	%Shooter=Client::getName(%enemy);
	%msg="<jc>**ALERT !!** \n"@%Item@" Under Attack by "@%Shooter;
	TeamMessage(%team,%msg,"3","AAODSFX12");
	if($trace) echo("*** ALARM ** "@%msg);
}

function DesignatePlyrAlarm(%enemy)
{	%enemy.Alarm = true;
	Schedule("ResetAlarm("@%this@");",120);
	%name = Client::getName(%enemy);
	%msg="<jc>**ALERT !!** \n"@%Item@" Under Attack by "@%Shooter;
	TeamMessage(%team,%msg,"3","AAODSFX12");
	if($trace) echo("*** ALARM ** "@%msg);

}

function DesignateVehAlarm(%this,%enemy)
{

}

function CBArtyAlarm(%this,%enemy)
{

}

function CBMortarAlarm(%this,%enemy)
{

}

function TeleportAlarm(%this,%enemy)
{

}

function AODAlarm::Help(%client)
{	%msg=HelpTitle("Base Alarm System: Requires Power");
	%msg=AddHelpLine(%msg,"Must be deployed OUTSIDE on a flat surface.");
	%msg=AddHelpLine(%msg,"Notifies team when Items are being attacked.");
	%msg=AddHelpLine(%msg,"Notifies team when Teleporter is Activated within range.");
	%msg=AddHelpLine(%msg,"Other ideas welcome...(In Development)");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

//************************** Global Deployable Functions *************************
function ItemBusy(%this)
{	%this.isbusy=true;
}

function ItemNotBusy(%this)
{	%this.isbusy=false;
}


ItemImageData UnBeaconImage
{  	shapeFile		= "plasmatrail";
	mountPoint		= 2;
	lightType		= 2;   // Pulsing
	lightRadius		= 4;
	lightTime		= 1;
	lightColor		= { 0.5, 1, 0.5 };
	sfxambient		= SoundUnBeacon;
};


ItemData UnBeacon
{	description		= "UnBeacon";
	shapeFile		= "plasmatrail";
	classname		= "Marker";
	imageType		= UnBeaconImage;
	shadowDetailMask = 4;
	price			= 1;
	hudIcon			= "deployable";
	showWeaponBar	= false;
	hiliteOnActive	= false;
};



$ObjType[0]="DeployableTurret";
$ObjType[1]="VELCROTurret";
$ObjType[2]="GROGTurret";
$ObjType[3]="SAMTurret";
$ObjType[4]="RocketTurret";
$ObjType[5]="PlasmaTurret";
$ObjType[6]="MORTTurret";
$ObjType[7]="AATurret";
$ObjType[8]="ELFTurret";
$ObjType[9]="IndoorTurret";
$ObjType[10]="ArtilleryTurret";
$ObjType[11]="AmbusherAP";
$ObjType[12]="AmbusherAA";

// ForceFields 
$ObjType[13]="DeployableField1";
$ObjType[14]="DeployableField2";
$ObjType[15]="SmallForceDoor";
$ObjType[16]="LargeForceDoor";

// Other Static Objects
$ObjType[17]="PulseSensor";
$ObjType[18]="Generator";
$ObjType[19]="SolarPanel";
$ObjType[20]="MobileBunker";
$ObjType[21]="MobileBlastShield";
$ObjType[22]="VehiclePad";
$ObjType[23]="ShieldGen";
$ObjType[24]="TeamEngGen";
$ObjType[25]="MobileGen";
$ObjType[26]="MobileInvent";
$ObjType[27]="InventoryStation";
$ObjType[28]="JumpPad";
$ObjType[29]="PortaSolar";
$ObjType[30]="Teleporter";
$ObjType[31]="TeleporterNode";
$ObjType[32]="SolarFGen";
$ObjType[33]="CounterBattery";
$ObjType[34]="SatSystem";
$ObjType[35]="Alarm";
$ObjType[36]="PortGenerator";
$ObjType[37]="AmmoStation";
$ObjType[38]="DeployableAmmoStation";
$ObjType[39]="DeployableInvStation";
$ObjType[40]="CommandStation";
$ObjType[41]="VehicleStation";



	
function GetNumObjects(%set,%type,%tnum)
{	if(%tnum==0)
		return (0);
	if(%type==4)
		return(0);

	if(%type==1)	//	Turrets only
	{	%num=0;
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
	else if(%type==2)	// Forcefields Only
	{	%num=0;
		%num+=CountObjects(%set,$ObjType[13],%tnum);
		%num+=CountObjects(%set,$ObjType[14],%tnum);
		%num+=CountObjects(%set,$ObjType[15],%tnum);
		%num+=CountObjects(%set,$ObjType[16],%tnum);
		return (%num);
	}
	else if(%type==3)	// Forcefields & Static Objects
	{	%num=0;
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
	{	%num=0;
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

function CheckItemPickup(%player)
{	if($traceDep) echo( $ver@"|Check Item Pickup (player) (",%player,") Is Deploying: ",%client.isDeploying);
	%client = Player::getClient(%player);
	if(!%player.isDeploying) 
	{	if(GameBase::getLOSinfo(%player,3)) 
		{	%this = $los::object;
			%name = GameBase::getDataName(%this);
			if($trace) echo( $ver@"|Packing Up a ",%name);
			if((%name.classname != Armor) && (%name.classname != Vehicle) && (%name.classname != Generator)) 
			{	%thisTeam = GameBase::getTeam(%this);
				%team = Client::getTeam(%client);
				if(%team == %thisTeam) GameBase::virtual(%this,"packUp",$los::position,%client,%player);
			}
		}
	}
}

function PlaceItemPack(%player, %pack, %pos)
{	%team=GameBase::getTeam(%player);
	%obj = newObject("","Item",%pack,1,false);
	schedule("Item::Pop(" @ %obj @ ");", 30, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);
	$TeamItemCount[%team @ %pack]--;
	playSound(SoundPackupItem,%pos);
	%player.isDeploying = false;
}


function Mission::reinitData()
{	
	%numPlayers = getNumClients();
	
	for(%i = 0; %i < %numPlayers; %i++)
	{	%pl = getClientByIndex(%i);
		if($trace) echo($ver,"| Resetting Team Kill counts for - ",$User[%pl]);
		%pl.teamkills=0;
		%pl.tkobjects=0;
	}

	for(%i = -1; %i < 2 ; %i++)		// AAOD Mod Only Supports 2 Teams at this time
	{	$NodeSet[%i]		= false;
		$AAPCSet[%i]		= false;
		$PowerSet[%i]		= false;
		$PowerSat[%i]		= false;				// Satelite Power System
		$PowerSatSet[%i]	= "";				// Satelite Power System Node Set
		$TeamEnergy[%i]		= $DefaultTeamEnergy;
		$LastEnergy[%i]		= 0;
		$IncTeamEnergy[%i]	= $DefTeamEnergyInc; 
		$ShieldGenOn[%i]	= false;
		$ShieldGen[%i]		= false;
		$NodeSet[%i]		= "";
		$AAPCSet[%i]		= false;
		$LastFlagHolder[%i]	= false;
		$Teleporter[%i]		= false;
		$TeleportNode[%i]	= false;
		$ClassBGen[%i]		= "";
		$ClassAGen[%i]		= "";
		$Alarm[%i]			= false;
		$GenSet[%i]			= "";
				
		$TeamItemCount[%i @ DeployableAmmoPack]			= 0;
		$TeamItemCount[%i @ DeployableInvPack]			= 0;
		$TeamItemCount[%i @ TurretPack]					= 0;
		$TeamItemCount[%i @ CameraPack]					= 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack]			= 0;
		$TeamItemCount[%i @ MotionSensorPack]			= 0;
		$TeamItemCount[%i @ ScoutVehicle]				= 0;
		$TeamItemCount[%i @ LAPCVehicle]				= 0;
		$TeamItemCount[%i @ HAPCVehicle]				= 0;
		$TeamItemCount[%i @ Beacon]						= 0;
		$TeamItemCount[%i @ mineammo]					= 0;
		$TeamItemCount[%i @ AODSAMPack]					= 0;
		$TeamItemCount[%i @ AODGROGPack]				= 0;
		$TeamItemCount[%i @ AODVelcroPack]				= 0;
		$TeamItemCount[%i @ AODInfernoPack]				= 0;
		$TeamItemCount[%i @ AODForce1Pack]				= 0;
		$TeamItemCount[%i @ AODForce2Pack]				= 0;
		$TeamItemCount[%i @ AODForceDoorS]				= 0;
		$TeamItemCount[%i @ AODForceDoorL]				= 0;
		$TeamItemCount[%i @ AODVehicle1]				= 0;
		$TeamItemCount[%i @ AODVehicle2]				= 0;
		$TeamItemCount[%i @ AODAAPack]					= 0;
		$TeamItemCount[%i @ AODDefender]				= 0;
		$TeamItemCount[%i @ AODArtilleryPack]			= 0;
		$TeamItemCount[%i @ AODMORTPack]				= 0;
		$TeamItemCount[%i @ AODBunker]					= 0;
		$TeamItemCount[%i @ AODBlastShield]				= 0;
		$TeamItemCount[%i @ AODMobileInv]				= 0;
		$TeamItemCount[%i @ AODMobileGen]				= 0;
		$TeamItemCount[%i @ AODShieldGen]				= 0;
		$TeamItemCount[%i @ AODShieldNode]				= 0;
		$TeamItemCount[%i @ AODTeamEGen]				= 0;
		$TeamItemCount[%i @ AODAmbushApPack]			= 0;
		$TeamItemCount[%i @ AODAmbushAAPack]			= 0;
		$TeamItemCount[%i @ AODJumpPad]					= 0;
		$TeamItemCount[%i @ AODTeleporter]				= 0;
		$TeamItemCount[%i @ AODCounterBattery]			= 0;
		$TeamItemCount[%i @ AODSolarTEGen]				= 0;
		$TeamItemCount[%i @ AODPortaSolar]				= 0;
		$TeamItemCount[%i @ AODSatPwrSys]				= 0;
		$TeamItemCount[%i @ AODPowerNode]				= 0;
		$TeamItemCount[%i @ AODAlarm]					= 0;
	}
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	
}

//******************************************
// Functions pulled from static shape.cs
//******************************************

// ReplishTeam Energy Goes Here!!

function replenishTeamEnergy(%team)
{	%MaxNumA=$TeamItemCount[%team@AODTeamEGen];
	%MaxNumB=$TeamItemCount[%team@AODSolarTEGen];
	
	%energy=0;
	if(%MaxNumB)
	{	%numb=Group::ObjectCount($ClassBGen[%team]);
		if($traceTE) echo(%MaxNumB," Solar Fabricators Exist - Power Set is:", $ClassBGen[%team]," Number in set ",%numb);
		%energy+=(%numb*$ClassBIncrease);
	}
	
	if(%MaxNumA)
	{	%numa=Group::ObjectCount($ClassAGen[%team]);
		if($traceTE) echo(%maxNumA," Fabricators Exist - Power Set is:", $ClassAGen[%team]," Number in set ",%numa);
		%energy+=(%numa*$ClassAIncrease);
	}
	%energy+=$IncTeamEnergy[%team];
	%change=$TeamEnergy[%team]-$LastEnergy[%team];
	if($traceTE) echo("Team Power has changed by ",%change);
	if(%change<-2000)
	{	%msg="<f1><jc>**** Warning ****\nFabrication Generators UNABLE to supply \n enough Team Energy!!\n*** Losing Team Energy ***";
		if (%MaxNumB>%numb && %MaxNumB>0)	// If Solar Fabrication Gen exists and is not functioning
			%msg=%msg@"SOLAR Fabrication Gnerator requires Repair!!\n";
		
		if (%MaxNumA>%numa && %MaxNumA>0)
			%msg=%msg@"Repair your deployabled Fabrication Gnerator!!\n";
		
		%msg=%msg@"To recover TEAM Energy FASTER - DEPLOY a Fabrication Generator!!\n";
		TeamMessage(%team,%msg,3,"AAODSFX51");
	}
	$LastEnergy[%team]=$TeamEnergy[%team];
	$TeamEnergy[%team] += %energy;
	if($traceTE) echo($Ver,"| Team ",%team," Recovered ",%energy," Pts of Energy| Total = ",$TeamEnergy[%team]);
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
	
}



