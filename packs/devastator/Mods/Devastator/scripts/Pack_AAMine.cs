$InvList[AAMinePack] = 1;
$RemoteInvList[AAMinePack] = 1;
$TeamItemMax[AAMinePack] = 20;
$Dec[AAMinePack] = 1;
$AAMineMaxAmmo = 1; //- Currently Set to Disposable

$ItemMax[larmor, AAMinePack] = 0;
$ItemMax[marmor, AAMinePack] = 1;
$ItemMax[harmor, AAMinePack] = 0;
$ItemMax[qarmor, AAMinePack] = 0;
$ItemMax[tarmor, AAMinePack] = 0;
$ItemMax[sarmor, AAMinePack] = 1;
$ItemMax[srarmor, AAMinePack] = 0;
$ItemMax[parmor, AAMinePack] = 0;
$ItemMax[psarmor, AAMinePack] = 0;
$ItemMax[psfemale, AAMinePack] = 0;
$ItemMax[IceMor, AAMinePack] = 1;
$ItemMax[lfemale, AAMinePack] = 0;
$ItemMax[mfemale, AAMinePack] = 1;
$ItemMax[qarmor, AAMinePack] = 0;
$ItemMax[sarmor, AAMinePack] = 1;
$ItemMax[srarmor, AAMinePack] = 0;
$ItemMax[parmor, AAMinePack] = 0;
//----------------------------------------------------------------------------

SeekingMissileData AAMineSiloRocket
{
	bulletShapeName = "rocket.dts";
	explosionTag    = KamiExplosion;
	collisionRadius = 0.0;
	mass            = 2.0;

	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 1.5;
	damageType       = $AAMineDamageType;
	explosionRadius  = 15.5;
	kickBackStrength = 120.0;

	muzzleVelocity          = 50.0;
	totalTime               = 100;
	liveTime                = 100;
	seekingTurningRadius    = 2.0;
	nonSeekingTurningRadius = 2.0;
	proximityDist           = 5.5;
	smokeDist               = 2;

	lightRange       = 1.0;
	lightColor       = { 0.4, 0.4, 1.0 };

	inheritedVelocityScale = 1.0;

	soundId = SoundJetHeavy;
};

//----------------------------------------------------------------------------

ItemImageData AAMinePackImage 
{ 
	shapeFile = "liqcyl"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData AAMinePack 
{ 
	description = "AA Mine Silo"; 
	shapeFile = "liqcyl"; 
	className = "Backpack"; 
	heading = fDeployables; 
	imageType = AAMinePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

//------------------------------------

TriggerData AAMineBoxTrigger
{
	className = "Trigger";
	dimensions = "50 50 200";
	rate = 5.0;
};

MineData AAMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "liqcyl";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 1.5;
	damageType = $AAMineDamageType;
	kickBackStrength = 150;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
};

//------------------------------------

function AAMinePack::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function AAMinePack::onDeploy(%player,%item,%pos) 
{ 
	if(AAMinePack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item,$Dec[AAMinePack]);
}

function AAMinePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain") {
				if(checkDeployArea(%client,$los::position) && checkSiloNetwork(%client,$los::position)) {
					%LOS = $los::object;
					%obj = newObject("","Mine","AAMine");
 	 		         	addToSet("MissionCleanup", %obj);
					GameBase::setTeam(%obj,GameBase::getTeam(%player));
					%rot = GameBase::getRotation(%player);
					GameBase::setPosition(%obj,$los::position);
					GameBase::setRotation(%obj,%rot);
					%Name = "AA Mine Silo #"@$TeamItemCount[GameBase::getTeam(%player) @ "AAMinePack"];
					GameBase::setMapName(%obj,%Name);
					Client::sendMessage(%client,0,%Name@" Deployed");
					playSound(SoundPickupBackpack,$los::position);
					playSound(SoundPlasmaTurretOn,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ "AAMinePack"]++;
					%obj.deployer = %client;
					echo("MSG: ",%client," deployed an AA Mine Silo");
					return true;
				}
			}
			else
				Client::sendMessage(%client,0,"Can only be deployed on Terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function AAMinePack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>The Anti-Aircraft Mine Silo can be deployed as a Defensive Shield against incoming Aircraft threats, place in high traffic areas for the best outcome.");
}

function checkSiloNetwork(%client,%pos)
{
	echo("At "@%pos@" Checking Silo Network");
	%set = newObject("set",SimSet);
	%ClosestDist = 50;
	if(containerBoxFillSet(%set,$MineObjectType,%pos,50,50,5,-2.5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++) {
			echo(Group::getObject(%set,%i));
			%TempDist = Vector::getDistance(%pos,GameBase::getPosition(Group::getObject(%set,%i)));
			if(%TempDist < %ClosestDist) {
				%ClosestDist = %TempDist;
				%Closest = Group::getObject(%set,%i);
				echo(%Closest);
			}
		}
		echo(%Closest);
		%SiloName = GameBase::getMapName(%Closest);
		Client::sendMessage(%client,0,"Deploy Site Interference from "@%SiloName@".");
		deleteObject(%set);
		return false;
	}
	deleteObject(%set);
}

function AAMine::onAdd(%this)
{
	%this.damage = 0;
	AAMine::deployCheck(%this);
	$AAMineAmmoCount[%this] = $AAMineMaxAmmo;
	echo(%this@" AA Mine Deployable Silo Added with "@$AAMineAmmoCount[%this]@" Loaded Missile");
}

function AAMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(%type == "Flier" && GameBase::isActive(%this)) {
		%LastPilot = %object.clLastMount;
		if(GetTeam(%LastPilot,%this) != Same && GetTeam(%LastPilot,%player) != You)
			GameBase::setDamageLevel(%this,%data.maxDamage);
	}
	else if(%type == "player" && GameBase::isActive(%this)) {
		Gamebase::StartFadeIn(%this);
		schedule("Gamebase::StartFadeOut("@%this@");",5.0,%this);
	}
}

function AAMine::deployCheck(%this)
{
	echo(%this@" Deploy Check");
	if(GameBase::isAtRest(%this)) {
	 	GameBase::setActive(%this,true);
		echo(%this@" Rested and Activated");
		AAMine::immediatelaunchCheck(%this);
		schedule("Gamebase::StartFadeOut("@%this@");",1.0,%this);
	}
	else 
		schedule("AAMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AAMine::immediatelaunchCheck(%this)
{
	%set = newObject("set",SimSet);
	if(containerBoxFillSet(%set,$VehicleObjectType,GameBase::getPosition(%this),1,1,200,2.5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++) {
			%target = Group::getObject(%set,%i);
			%LastPilot = %target.clLastMount;
			if(GetTeam(%LastPilot,%this) != Same && GetTeam(%LastPilot,%this) != You) {
				AAMine::LaunchMissile(%this,%target);
				deleteObject(%set);
				return FALSE;
			}
		}
	}
	else
		AAMine::SetTargetBox(%this);
	deleteObject(%set);
}

function AAMine::SetTargetBox(%this)
{
	%x = getWord(GameBase::getPosition(%this),0);
	%y = getWord(GameBase::getPosition(%this),1);
	%z = getWord(GameBase::getPosition(%this),2)+2.5;
	%pos = %x@" "@%y@" "@%z;
}

function AAMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "AAMinePack"]--;
}

function AAMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%object == 0 || %object == %this)
		return;
	%data = GameBase::getDataName(%this);
	echo(%this@" being damaged by "@%object);
	if((%data.maxDamage/1.5) < %this.damage+%value) {
		GameBase::setDamageLevel(%this,%data.maxDamage);
		AAMine::LaunchMissile(%this,%object);
	}
	else 
		%this.damage += %value;
}
$ZforAAMine = 50;
$ProjforAAMine = "AAMineSiloRocket";
function AAMine::LaunchMissile(%this,%target)
{
	echo(%this@" Launching Missile at "@%target);
	%data = GameBase::getDataName(%this);
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%vec = Vector::getfromrot(%rot);
	%pilot = %this.deployer;
	GameBase::StartFadeIn(%this);
	%vel = "0 0 "@$ZforAAMine;
	%trans = %rot@" "@%vec@" "@%rot@" "@%pos;
	%proj = Projectile::spawnProjectile($ProjforAAMine,%trans,%pilot,%vel,%target);
	Client::sendMessage(%target,0,"Bang your dead.");
	Client::sendMessage(%target.clLastMount,0,"Bang your dead.");
	echo("Past Projectile "@%proj);
	$Shooter[%proj] = %this.deployer;
	$Target[%proj]  = %target;
	$Locked[%target] = %proj;
	$AAMineAmmoCount[%this]--;
	if($AAMineAmmoCount[%this] <= 0)
		schedule("GameBase::setDamageLevel("@%this@","@%data.maxDamage@");",0.1,%this);
	playSound(SoundMortarTurretFire,%pos);
}