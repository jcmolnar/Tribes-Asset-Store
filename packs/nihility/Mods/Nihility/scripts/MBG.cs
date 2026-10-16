//This File assigns and defines beacons, mines, nades,
//and oncontacts for friendlies and enmies for armors


$ItemMax[larmor, RepairKit] = 1;	//Seraph
$ItemMax[lfemale, RepairKit] = 1;	//Seraph
$ItemMax[earmor, RepairKit] = 1;	//Slave
$ItemMax[efemale, RepairKit] = 1;	//Slave
$ItemMax[marmor, RepairKit] = 1;	//Pawn
$ItemMax[aarmor, RepairKit] = 1;	//Navigator
$ItemMax[darmor, RepairKit] = 1;	//Atomizer
$ItemMax[barmor, RepairKit] = 1;	//Paladin

$ItemMax[larmor, MineAmmo] = 10;	//Seraph
$ItemMax[lfemale, MineAmmo] = 10;	//Seraph
$ItemMax[earmor, MineAmmo] = 10;	//Slave
$ItemMax[efemale, MineAmmo] = 10;	//Slave
$ItemMax[marmor, MineAmmo] = 10;	//Pawn
$ItemMax[aarmor, MineAmmo] = 10;	//Navigator
$ItemMax[darmor, MineAmmo] = 10;	//Atomizer
$ItemMax[barmor, MineAmmo] = 10;	//Paladin

$ItemMax[larmor, Grenade] = 10;		//Seraph
$ItemMax[lfemale, Grenade] = 10;	//Seraph
$ItemMax[earmor, Grenade] = 10;		//Slave
$ItemMax[efemale, Grenade] = 10;	//Slave
$ItemMax[marmor, Grenade] = 15;		//Pawn
$ItemMax[aarmor, Grenade] = 10;		//Navigator
$ItemMax[darmor, Grenade] = 20;		//Atomizer
$ItemMax[barmor, Grenade] = 20;		//Paladin

$ItemMax[larmor, Beacon] = 5;		//Seraph
$ItemMax[lfemale, Beacon] = 5;		//Seraph
$ItemMax[earmor, Beacon] = 5;		//Slave
$ItemMax[efemale, Beacon] = 5;		//Slave
$ItemMax[marmor, Beacon] = 8;		//Pawn
$ItemMax[aarmor, Beacon] = 5;		//Navigator
$ItemMax[darmor, Beacon] = 5;		//Atomizer
$ItemMax[barmor, Beacon] = 5;		//Paladin

$AutoUse[RepairKit] = false; 

$InvList[RepairKit] = 1;
$InvList[MineAmmo] = 1;
$InvList[Grenade] = 1;
$InvList[Beacon] = 1;

ItemData RepairKit 
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "eMisc Items";
	shadowDetailMask = 4;
	price = 10;
};

ItemData MineAmmo 
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "eMisc Items";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};


ItemData Grenade 
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = "eMisc Items";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

ItemData Beacon 
{ 
	description = "Beacon"; 
	shapeFile = "sensor_small"; 
	heading = "eMisc Items"; 
	shadowDetailMask = 4; 
	price = 10; 
	className = "HandAmmo"; 
}; 

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	%c = Player::getClient(%player);
	$poisonTime[%c] = 0;
} 

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%armor = Player::getArmor(%player);
			%client = Player::getClient(%player);
			if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine");
			else { %obj = newObject("","Mine","antipersonelMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
		%player.throwTime = getSimTime() + 0.5;
		}
	}
} 


function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%armor = Player::getArmor(%player);
			if (%armor == "larmor" || %armor == "lfemale")
			{
				Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds");
				%obj = newObject("","Mine","Nukebomb");
			}
			if (%armor == "garmor" || %armor == "gfemale")//ghost
			{
				Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds");
				%obj = newObject("","Mine","Nukebomb");
			}
			if (%armor == "gfarmor" || %armor == "gffemale")//ghost
			{
				Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds");
				%obj = newObject("","Mine","Nukebomb");
			}
			if (%armor == "earmor" || %armor == "efemale") %obj = newObject("","Mine","Shockgrenade");
			if (%armor == "marmor") %obj = newObject("","Mine","Handgrenade");
			if (%armor == "aarmor") %obj = newObject("","Mine","Tranqgrenade");
			if (%armor == "darmor") %obj = newObject("","Mine","Stickybomb");
			if (%armor == "barmor") %obj = newObject("","Mine","Mortarbomb");
	
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
} 

//=====================================
//=========sticky nades
//=====================================
SeekingMissileData TrackBomb
{	bulletShapeName = "grenade.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 4.5;
	kickBackStrength = 75.0;
	muzzleVelocity = 0.1;
	terminalVelocity = 0.1;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

//MineData Trackbomb
//{
//	mass = 0.3;
//	drag = 1.0;
//	density = 2.0;
//	elasticity = 0.0;
//	friction = 1.0;
//	className = "Handgrenade";
//	description = "MagNade";
//	shapeFile = "grenade";
//	shadowDetailMask = 4;
//	explosionId = rocketExp;
//	explosionRadius = 10.0;
//	damageValue = 2.0;
//	damageType = $MortarDamageType;
//	kickBackStrength = 300;
//	triggerRadius = 0.5;
//	maxDamage = 2.0;
//};

MineData StickNadeDet
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "Handgrenade";
	description = "MagNade";
	shapeFile = "armorkit";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 1.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

MineData Stickybomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "Handgrenade";
	description = "MagNade";
	shapeFile = "armorkit";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 4.0;
	damageValue = 1.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};


function Stickybomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

//GameBase::getRotation(%clientId)
//
//and the height of the nade on contact relative to player
//
//%Pos = GameBase::getPosition(%nade);
//%Pos = GameBase::getPosition(%player);
//
//break down the position of player, and add the diff..
//
//
//and reposition the nade, scheduled at 0.1 or something like that...
//GameBase::setPosition(%this, newposition);

//function Stickybomb::onCollision(%this,%obj)

//	%tpos=GameBase::getPosition(%player);
//	%target=AquireTarget(%player,1,%tpos);

//   	%vel = Item::getVelocity(%newobj);
//	%xvel = getWord(%vel,0);
//	%yvel = getWord(%vel,1);
//	%zvel = getWord(%vel,2);

function Stickybomb::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if (%type == "Player")
	{	
		%data = GameBase::getDataName(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
	}
}

//function Stickybomb::onCollision(%newobj)
//{
//	%player = Client::getOwnedObject(%client);
//	%Pos = GameBase::getPosition(%newobj); 
//
//	deleteobject(%newObj);
//	
//	%trans = GameBase::getMuzzleTransform(%player);
//	%vel = Item::getVelocity(%player);
//	
//	
//	%obj = Projectile::spawnProjectile("StickNadeDet",%trans,%pos,%vel);
//	Projectile::spawnProjectile(%obj);
//	GameBase::setPosition(%nade, %pos);
//	GameBase::getRotation(%player);
//	
//	%PosA = GameBase::getPosition(%obj);
//	%xposA = getWord(%PosA ,0);
//	%yposA = getWord(%PosA ,1);
//	%zposA = getWord(%PosA ,2);
//	%newposA = %xposA@" "@%yposA@" "@%zposA;
//	
//	%PosB = GameBase::getPosition(%player);
//	%xposB = getWord(%PosB ,0);
//	%yposB = getWord(%PosB ,1);
//	%zposB = getWord(%PosB ,2);
//	%newposB = %xposB@" "@%yposB@" "@%zposB;
//	
//	//%Dist = %newposA - %newposB;
//	
////if(1 > %Dist);
////}
////GameBase::setPosition(%obj,%newposB);
////{
//	
//	
//	//%obj = Projectile::spawnProjectile("StickNadeDet",%trans,%player,%vel);
//	//schedule("Mine::Detonate(" @ %this @ ");",10.0,%stick);
//	//%stick =
//}


//=====================================
//=========sticky nades^^^^^^^^^^^^
//=====================================

function Beacon::onUse(%player,%item) 
{ 
%armor = Player::getArmor(%player); %clientId = Player::getClient(%player); 
if (%armor == "larmor" || %armor == "lfemale") 
{ 
startCloak(%clientId, %player); 
Player::decItemCount(%player,%item); 
} 
if(%armor == "earmor" || %armor == "efemale") 
{ 
startShield(%clientId, %player); 
Player::decItemCount(%player,%item); 
}
if (%armor == "marmor") 
{ 
if($matchStarted) 
{ 
if(%player.throwTime < getSimTime() ) 
{ 
%obj = newObject("","Mine","Booster"); 
addToSet("MissionCleanup", %obj); 
%client = Player::getClient(%player); 
GameBase::throw(%obj,%player,15 * %client.throwStrength,false); 
%player.throwTime = getSimTime() + 0.5; 
Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); 
Player::decItemCount(%player,%item); 
} 
} 
} 
if (%armor == "aarmor") 
{ 
Renegades_startCloak(%clientId, %player); 
Player::decItemCount(%player,%item); 
} 
if (%armor == "barmor") 
{ 
startShield(%clientId, %player); 
Player::decItemCount(%player,%item); 
}
if (%armor == "darmor")
{ 
startShield(%clientId, %player); 
Player::decItemCount(%player,%item); 
}
} 


//=======================
//BEACON EFF SCRIPTS
//=======================

function startShield(%clientId, %player) 
{	// Taken straight from Annihilation
	%armor = Player::getArmor(%clientId);
	if (%armor == "earmor" || %armor == "efemale")
	{
		Client::sendMessage(%clientId,1,"Deflection Shield activated...");
		Client::sendMessage(%clientId,1,"25 seconds of protection...");
		GameBase::playSound(%player,ForceFieldOpen,0);
		%player.shieldStrength = 0.0164;
		if($shieldTime[%clientId] == 0) 
		{	$shieldTime[%clientId] = 25;
			checkPlayerShield(%clientId, %player);
		}
		else $shieldTime[%clientId] = 25;
	}
	if (%armor == "darmor")
	{
		Client::sendMessage(%clientId,1,"Electron Field generated...");
		Client::sendMessage(%clientId,1,"20 seconds of protection...");
		GameBase::playSound(%player,ForceFieldOpen,0);
		%player.shieldStrength = 0.0162;
		if($shieldTime[%clientId] == 0) 
		{	$shieldTime[%clientId] = 20;
			checkPlayerShield(%clientId, %player);
		}
		else $shieldTime[%clientId] = 20;
	}
	if (%armor == "barmor")
	{
		Client::sendMessage(%clientId,1,"Diffusion Buffer generated...");
		Client::sendMessage(%clientId,1,"20 seconds of protection...");
		GameBase::playSound(%player,ForceFieldOpen,0);
		%player.shieldStrength = 0.0162;
		if($shieldTime[%clientId] == 0) 
		{	$shieldTime[%clientId] = 20;
			checkPlayerShield(%clientId, %player);
		}
		else $shieldTime[%clientId] = 20;
	}
}


function checkPlayerShield(%clientId, %player) 
{	// Taken straight from Annihilation
	if ($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{	$shieldTime[%clientId] -= 2;
		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{	$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,1,"!! emergency systems powering down !!");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}


//=======================
//END BEACON EFF SCRIPTS
//=======================


//=======================
//BEACON CLOAKING SCRIPTS
//=======================

//CLOAK 1

function Renegades_startCloak(%clientId, %player) 
{ 
%armor = Player::getArmor(%player); 
Client::sendMessage(%clientId,1,"Phasing Out..."); 
GameBase::playSound(%player,ForceFieldOpen,0); 
GameBase::startFadeout(%player); 
%rate = Player::getSensorSupression(%player) + 3; Player::setSensorSupression(%player,%rate); 
if($cloakTime[%clientId] == 0) 
{ 
$cloakTime[%clientId] = 20; 
checkPlayerCloak(%clientId, %player); 
} 
else 
$cloakTime[%clientId] = 20; 
} 




function checkPlayerCloak(%clientId, %player) 
{ 
%armor = Player::getArmor(%player); 
if($cloakTime[%clientId] > 0) 
{ 
$cloakTime[%clientId] -= 2; 
if ( (!Player::isDead(%player)) && (%armor == "aarmor" || %armor == "afemale") ) 
{ } 
else 
{ 
$cloakTime[%clientId] = 0; 
} 
schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); 
} 
else 
{ 
Client::sendMessage(%clientId,1,"Phasing In..."); 
GameBase::playSound(%player,ForceFieldOpen,0); 
GameBase::startFadein(%player); 
%rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,0); 
} 
} 

//CLOAK 2

function startCloak(%clientId, %player) 
{
	// Taken straight from Annihilation 
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,1,"Phasing Out...");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
	if($cloakTime[%clientId] == 0) 
	{	$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else $cloakTime[%clientId] = 20;
}

function checkPlayerCloak(%clientId, %player) 
{	%armor = Player::getArmor(%player);
	if (!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
	{	$cloakTime[%clientId] -= 2;
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{	$cloakTime[%clientId] = 0;
		Client::sendMessage(%clientId,1,"Phasing In...");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

//=======================
//END OF BEACON CLOAKING SCRIPTS
//=======================

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

function firework(%client)
{
	%player = Client::getOwnedObject(%client);
	Player::setItemCount(%client, Nihility, 1);
	Player::mountItem(%player,Nihility);
}

function spawndeath(%client) {
        %player = Client::getOwnedObject(%client);
        %vel = Item::getVelocity(%player);
                for(%i=0; %i < 6.28; %i += 0.628) {
                %pos = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 2, 1));
                %trans = "0 0 1 0 0 0 0 0 1 " @ %pos;
                %obj = Projectile::spawnProjectile("GrenadeShell",%trans, %player, %vel);
                Projectile::spawnProjectile(%obj);
                Item::setVelocity(%obj, %vel);
                }
}

function spankdeath(%client) {
        %player = Client::getOwnedObject(%client);
        %vel = Item::getVelocity(%player);
                for(%i=0; %i < 6.28; %i += 0.628) {
                %pos = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 2, 1));
                %trans = "0 0 1 0 0 0 0 0 1 " @ %pos;
                %obj = Projectile::spawnProjectile("SpankShell",%trans, %player, %vel);
                Projectile::spawnProjectile(%obj);
                Item::setVelocity(%obj, %vel);
                }
}

function mortardeath(%client) {
        %player = Client::getOwnedObject(%client);
        %vel = Item::getVelocity(%player);
                for(%i=0; %i < 6.28; %i += 0.628) {
                %pos = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 2, 1));
                %trans = "0 0 1 0 0 0 0 0 1 " @ %pos;
                %obj = Projectile::spawnProjectile("mortarshell",%trans, %player, %vel);
                Projectile::spawnProjectile(%obj);
                Item::setVelocity(%obj, %vel);
                }
}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

//GrenadeShell