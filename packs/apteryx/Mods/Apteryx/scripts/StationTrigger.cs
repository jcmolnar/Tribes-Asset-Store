
// inventory triggers... -plasmatic


// this is called on mission change, when inv station is added..
//slow this down a little so server can load mission up fully  -Plasmatic
function InventoryStation::onadd(%this)
{
//	echo("!! adding Inv");
	if($Annihilation::ExtendedInvs && !$ME::varsInitialized)				
		schedule("AddInventoryTrigger("@%this@");",3);
}




//for additional inventory check..
LightningData InventoryCharge
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 10.0;
	coneAngle = 35.0;
	damagePerSec = -0.5;
	energyDrainPerSec = 0.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;	// how wide..
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundMortarIdle;	//SoundELFFire;
};

TurretData InvTurret	   
{			 
	maxDamage = 1000.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 15;

	visibleToSensor = false;
	dopplerVelocity = 0.1;
	castLOS = true;
	supression = false;
	pinger = false;
	supressable = false;
	
	debrisId = defaultDebrisMedium;
	className = "";
	shapeFile = "camera";
	projectileType = InventoryCharge;
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.0; //0.3;	-handling this elsewhere... -plasmatic

	isSustained     = true;
	firingTimeMS    = 5000;	//1750
	energyRate      = 30.0;
};



TriggerData InvTrigger
{
	className = "Trigger";
	rate = 0.1;	//1.0;
};

// this is called on mission change, when inv station is added..
function AddInventoryTrigger(%this)
{
	//echo("ghost? "@$ghosting);
	if(!$ghosting)
		schedule("AddInventoryTrigger("@%this@");",3);
	
	else
	{				
		%group = newObject("InvNum"@%this,Simset);
		addToSet(MissionCleanup, %group);
		addToSet("MissionCleanup/Inventory",%group);	
		addToSet(%group,%this);	
		%this.group = %group;
		
		%Invpos = GameBase::GetPosition(%this);
		%rot = gamebase::getrotation(%this);
		%team = GameBase::getTeam(%this);
		%vec = rotateVector("0 -2.25 1.5",%rot);
		%pos = vector::add(%InvPos,%vec);
		
		// now for the fun part..
		instant Trigger "InventoryTrigger" {
			dataBlock = "InvTrigger";
			name = "InvTrigger";
			Team = %team;
			position = %pos;
			rotation = %rot;
			boundingBox = "-3 -3 -2.0 3 3 2.0";
			isSphere = "true";
			Owner = %this;
		};	
		
		// add inv turrets.. bah..	
		%vec = rotateVector("2.16 -0.5 1.4",%rot);
		%pos = vector::add(%InvPos,%vec);	
		%camera = newObject("Camera","Turret",InvTurret,true); 
		addToSet("MissionCleanup/Inventory", %camera);
		addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
		GameBase::setRotation(%camera,vector::add(%rot,"0 0 -2.02")); 
		GameBase::setPosition(%camera,%pos); 
		%this.rTurret = %camera;
			GameBase::setTeam(%camera,getNumTeams()-1); 	
			GameBase::setActive(%camera,true);
			GameBase::setRechargeRate(%camera,100); 	
					
		%vec = rotateVector("-2.2 -0.5 1.4",%rot);	// -damn inv is lopsided.. -plasmatic
		%pos = vector::add(%InvPos,%vec);	
		%camera = newObject("Camera","Turret",InvTurret,true); 
		addToSet("MissionCleanup/Inventory", %camera);
		addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
		GameBase::setRotation(%camera,vector::add(%rot,"0 0 -1.14")); 
		GameBase::setPosition(%camera,%pos); 	
		%this.lTurret = %camera;
			GameBase::setTeam(%camera,getNumTeams()-1); 	
			GameBase::setActive(%camera,true);
			GameBase::setRechargeRate(%camera,100); 					
	}	
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
		if(Player::isAIControlled(%object))
			return;
		%group = getGroup(%this); 
		%obj = %this.Owner;
		%client = GameBase::getOwnerClient(%object);
		
		gamebase::setactive(%obj.lTurret,true);	//just to make certain.. gets changed on drop ship destroy.. for some damn reason..
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
					%client.InvTargetable = true;
					if(!$Annihilation::Zappy)
					{
						%Client.InvConnect = true;
						%client.ListType = "InvList";
						GameBase::playSound(%object, SoundActivatePDA,0);
						Client::sendMessage(%client,3,"..Inventory Uplink established..");
						QuickInv(%client);
						schedule("ZappyResupply(" @ %client @ ");",0.25);	
					}
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
		if(Player::isAIControlled(%object))
			return;
		
		%client = GameBase::getOwnerClient(%object);
		
		//if(%object.InvTargetable)GameBase::playSound(%object, SoundPackFail,0);
		// The trigger check is not completely reliable,  
		// hard-coded check here to verify as well:
				
		%TrigPos = Gamebase::getPosition(%this);
		%PlPos = getBoxCenter(%object);	
		%dist = vector::getdistance(%PlPos,%TrigPos);		
		if(%dist > 3)
		{
			if($debug || $debuginv || $debugt)
			{
				echo("InvTrigger::onLeave, client= "@%client@" Dist= "@%dist);
			}
	
			%client.ConnectBeam = "";	//internal
			%client.InvTargetable = "";	//internal
			%Client.InvConnect = "";	//external	
			QuickInvOff(%client);	
			%object.ZappyResupply = "";
			%client.ListType = "";
		}	
	}
}


function InvTurret::verifyTarget(%this,%target)
{
	if(!$Annihilation::ExtendedInvs || !$Annihilation::Zappy) 
		return false;
	
	%client = GameBase::getOwnerClient(%target);
	
	if(!%client.InvTargetable || %client.ConnectBeam)
		return "False";
	else return "True";		
}

function InventoryCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	// verify player is within sight of coresponding inventory -invs not covered with blast walls..	
	// could do this with a diffrent damage type, but this would have to be in player::ondamage

	%client = GameBase::getOwnerClient(%target);
	if(!%Client.InvConnect)
	{	
		Client::sendMessage(%client,3,"..Inventory Uplink established..");
		QuickInv(%client);
		schedule("ZappyResupply(" @ %client @ ");",0.25);
		GameBase::playSound(%target, SoundActivatePDA,0);		
	}	
		
	%client.InvConnect = true;
	%client.ListType = "InvList";
	schedule("QuitBeam("@%client@");",1.0);
}

function QuitBeam(%client)
{
	if(%client.InvTargetable)	
		%client.ConnectBeam = "true";	
	else %client.ConnectBeam = "";	
}

function InvTurret::OnDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//do nothing, no damage..
}

function ZappyResupply(%client)
{
	if(%client.InvConnect && !isPlayerBusy(%client))
	{
		%player = Client::getOwnedObject(%client);
	
		%cnt = Station::itemsToResupply(%player);
		if(%cnt != 0 || gamebase::getdamagelevel(%player)) 
		{
			%player.ZappyResupply = true;
			%player.waitThrowTime = getSimTime();
			GameBase::repairDamage(%player,0.15);
			schedule("ZappyResupply(" @ %client @ ");",0.5);
			//return;
			
		}
		else %player.ZappyResupply = "";	
		//Client::sendMessage(%client,3,"...Resupply Complete, do something...");
	}
	
}