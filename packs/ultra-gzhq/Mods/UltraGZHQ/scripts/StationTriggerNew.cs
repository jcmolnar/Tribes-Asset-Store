


$InvDamageType = 28;

// inventory triggers... -plasmatic
function InventoryStation::onadd(%this)
{
	%t = floor(getrandom() * 5);
	if($ME::varsInitialized != true)
		schedule("AddInventoryTrigger("@%this@");",%t+1);
	// less server lag this way, disabling additional triggers if the editor is open...
}


function AddInventoryTrigger(%this)
{

	%InvSet = nameToID("MissionCleanup/Inventory");
	if(%InvSet == -1)
	{
		%group = newObject("Inventory", SimGroup);
		addToSet("MissionCleanup", %group);
	}
	
// creating another team just for these turrets, and cham sensors..
// need to modify getnumteams(); because that will return an extra team...	
	%teamSet = nameToID("MissionCleanup/Inventory/InvTurretTeam");
	if(%teamSet == -1)
	{
		%group = newObject("InvTurretTeam", TeamGroup);
		addToSet("MissionCleanup/Inventory", %group);
	}	
	%TeamNum = getNumTeams()-1;
//	
	

	%group = newObject("InvNum"@%this,Simset);
	addToSet(MissionCleanup, %group);
	addToSet("MissionCleanup/Inventory",%group);	
	addToSet(%group,%this);	
	%this.group = %group;
	
	%Invpos = GameBase::GetPosition(%this);
	%rot = gamebase::getrotation(%this);
	%team = GameBase::getTeam(%this);
	%vec = rotateVector("0 -2.25 2",%rot);
	%pos = vector::add(%InvPos,%vec);
	
	// now for the fun part..
	instant Trigger "GroupTrigger1" {
		dataBlock = "GroupTrigger";
		name = "InvTrigger";
		Team = %team;
		position = %pos;
		rotation = %rot;
		boundingBox = "-3 -3 -1 3 3 1";
		isSphere = "true";
		Owner = %this;
	};	
	
	// add inv turrets.. bah..	
	%vec = rotateVector("2.16 -0.5 1.4",%rot);
	%pos = vector::add(%InvPos,%vec);	
	%camera = newObject("Camera","Turret",InvTurret,true); 
	//addToSet("MissionCleanup", %camera); 
	addToSet("MissionCleanup/Inventory", %camera);
	addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
//	if(%team == 0) %camteam = 1;
//	if(%team == 1) %camteam = 0;
	GameBase::setTeam(%camera,%TeamNum); 
	GameBase::setRotation(%camera,vector::add(%rot,"0 0 -2.02")); 
	GameBase::setPosition(%camera,%pos); 
	GameBase::setActive(%camera,true);
	GameBase::setRechargeRate(%camera,100); 
	%this.rTurret = %camera;
	
	%vec = rotateVector("-2.2 -0.5 1.4",%rot);
	%pos = vector::add(%InvPos,%vec);	
	%camera = newObject("Camera","Turret",InvTurret,true); 
	//addToSet("MissionCleanup", %camera); 
	addToSet("MissionCleanup/Inventory", %camera);
	addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
//	if(%team == 0) %camteam = 1;
//	if(%team == 1) %camteam = 0;
	GameBase::setTeam(%camera,%TeamNum); 
	GameBase::setRotation(%camera,vector::add(%rot,"0 0 -1.14")); 
	GameBase::setPosition(%camera,%pos); 	
	GameBase::setActive(%camera,true);
	GameBase::setRechargeRate(%camera,100); 
	%this.lTurret = %camera;
}


// gotta put this somewhere... make sure it gets added to mission cleanup, so it gets deleted on map change.
function InvTrigger::onadd(%this)
{
	%owner = %this.Owner;
	addToSet("MissionCleanup/Inventory", %this);
	addToSet("MissionCleanup/Inventory/InvNum"@%owner,%this);	
}


function InvTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player") 
	{
		%group = getGroup(%this); 
		%obj = %this.Owner;
		%client = GameBase::getOwnerClient(%object);
		
		gamebase::setactive(%obj.lTurret,true);	//just to make certain.. gets changed on drop ship destroy..
		gamebase::setactive(%obj.rTurret,true);
		GameBase::setRechargeRate(%obj.lTurret,100);
		GameBase::setRechargeRate(%obj.rTurret,100);
		
	if($debug || $debuginv || $debugt)
	{
		echo("InvTrigger::onEnter "@%obj@" Damage state,"@GameBase::getDamageState(%obj)@", Powered,"@GameBase::isPowered(%obj)@" client,"@%client);
		echo("Left turret active"@%obj.lTurret@", "@GameBase::isActive(%obj.lTurret)@ " energy="@GameBase::getEnergy(%obj.lTurret)@ " right turret active"@%obj.rTurret@", "@GameBase::isActive(%obj.rTurret)@ " energy="@GameBase::getEnergy(%obj.rTurret));
	}
		if((GameBase::getTeam(%object) == GameBase::getTeam(%obj) || GameBase::getTeam(%obj) == -1) && %client.isSpy != true)
		{
			if(GameBase::getDamageState(%obj) == "Enabled") 
			{
				if(GameBase::isPowered(%obj)) 
				{ 
					%object.InvAccess = true;
				}
			}
		}		
	}
}


function InvTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player")
	{
		%client = GameBase::getOwnerClient(%object);
		//if(%object.InvAccess)GameBase::playSound(%object, SoundPackFail,0);
		%object.InvAccess = "";
		%object.ConnectBeam = "";
				
		if(%object.InvConnect)	
		{	
			//GameBase::setAutoRepairRate(%object,%object.RepairRate);			
		}
		%client.InvConnect = "";
		%object.InvConnect = "";
		QuickInvOff(%client);		
	}
}



//additional check for inventories.. -plasmatic

LaserData oldInvLaser 
{	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.001;
	DamageType = $InvDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundActivatePDA;	//SoundLaserHit;
};

TargetLaserData InvLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.01;
	baseDamageType = $InvDamageType;
	lightRange = 20.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

TurretData InvTurret	   
{			 
	maxDamage = 1000.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 7;
	
	visibleToSensor = false;
	dopplerVelocity = 0.1;
	castLOS = true;
	supression = false;
	pinger = false;
	supressable = false;
	
//	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	projectileType = InvLaser;	//InventoryCharge;
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	
	reloadDelay = 2.0;
	//reloadDelay = 1.0; //0.3;
	explosionId = LargeShockwave;
//	description = "";

//	fireSound        = SoundGeneratorPower;
//	activationSound  = SoundChainTurretOn;
//	deactivateSound  = SoundChainTurretOff;
//	damageSkinData   = "objectDamageSkins";
//	shadowDetailMask = 8;

   	//	isSustained     = true;
   	//	firingTimeMS    = 1750;
	//	energyRate      = 30.0;
};


function InvTurret::verifyTarget(%this,%target)
{
	if(($debug || $debuginv) && !%this.debugmessage)
	{
		echo("InvTurret::verifyTarget "@%this@" ,"@%target@", inv access ="@%target.InvAccess @" Target beam ="@%target.ConnectBeam);
		%this.debugmessage = true;
		schedule(%this@".debugmessage = false;",0.5);	//verify target is called constantly, this is to reduce cpu load..
		echo("turret active"@GameBase::isActive(%this)@ " energy="@GameBase::getEnergy(%this));

	}
	%Client = Player::getClient(%target);
	
	if(%Client.InvConnect)
		return "False";
	else {
		%client = GameBase::getOwnerClient(%target);
		%client.zapStation = %this.Owner;	
		return "True";	
		
		}
	
}

function InventoryCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	// verify player is within sight of coresponding inventory -invs not covered with blast walls..	
	// could do this with a diffrent damage type, but this would have to be in player::ondamage
	%damVal = %timeSlice * %damPerSec;
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

	
	
	
	%client = GameBase::getOwnerClient(%target);
	if(!%target.InvConnect)
	{	
		Client::sendMessage(%client,3,"..Inventory Uplink established..");
		QuickInv(%client);
		GameBase::playSound(%target, SoundActivatePDA,0);
		//GameBase::SetDamageLevel(%target,0); // Fix all damage
		//%target.RepairRate = GameBase::getAutoRepairRate(%target);
		//GameBase::setAutoRepairRate(%target,%target.RepairRate + 0.25);		
	}	
		
	%target.InvConnect = true;
	schedule(%target@".ConnectBeam = true;",1);
}

function InvTurret::OnDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
}

