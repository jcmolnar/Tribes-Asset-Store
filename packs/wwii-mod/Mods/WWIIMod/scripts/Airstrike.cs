GrenadeData AB
{	bulletShapeName = "breath.dts";
	explosionTag = BombExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.2;
	damageClass = 4;
	damageValue = 3.6;
	damageType = $Airstrike;
	explosionRadius = 25;
	kickBackStrength = 280;
	maxLevelFlightDist = 450;
	totalTime = 12;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";
	smokeDist = 1.5;
};

function Airstrike::onCall(%player)
{
echo("Airstrike::onCall(" @ %player @ ");");
echo(player::Getclient(%player));
%clientId = player::getclient(%player);
if(Player::isAIControlled(%player)) %clientId = AI::getobject(client::getname(%clientid));
if(%clientId.airstrikewaittime == 0){
%clientId.firstaim = gamebase::getmuzzletransform(%player);
%clientId.firstpos = gamebase::getposition(%player);
%clientId.airstriketime = 0;
%clientId.percent = 0;
bottomprint(%clientId, "<jc>Transmitting airstrike coordinates: <f2>" @ %clientId.percent @ "%", 1,AIRSTRIKE);
schedule("Airstrike::onUpdateCallFirst(" @ %clientId @ ");", 1);
}
else client::sendmessage(%clientId, 0, "You cant call an air strike for another " @ %clientId.airstrikewaittime @ " seconds.");
}

function Airstrike::onCall2(%clientId)
{
%player=client::getownedobject(%clientId);
%clientId.airstrikewaittime = 50;
Airstrike::StartPlane(%player);
schedule("Airstrike::onUpdateCall(" @ %clientId @ ");", 0.75);
}

function Airstrike::onUpdateCallFirst(%clientId)
{
echo("Airstrike::onUpdateCallFirst(" @ %clientId @ ");");
%player=Client::getownedobject(%clientId);
if(Player::getmounteditem(%player,0)!="Binoculars")return;
if(gamebase::getmuzzletransform(%clientId) == %clientId.firstaim && gamebase::getposition(%clientId) == %clientId.firstpos && %clientId.airstriketime < 10)
	{
	%clientId.airstriketime++;
	%clientId.percent = %clientId.percent + 5;
	bottomprint(%clientId, "<jc>Transmitting airstrike coordinates: <f2>" @ %clientId.percent @ "%", 1,AIRSTRIKE);
	if(%clientId.percent == 50) Airstrike::onUpdateCallFirst(%clientId);
	else schedule("Airstrike::onUpdateCallFirst(" @ %clientId @ ");", 0.75);
	}
else if(gamebase::getmuzzletransform(%clientId) == %clientId.firstaim && gamebase::getposition(%clientId) == %clientId.firstpos && %clientId.airstriketime >= 9)
	{
	Airstrike::onCall2(%clientId);
	}
else
	{
	%clientId.firstaim = gamebase::getmuzzletransform(%player);
	%clientId.firstpos = gamebase::getposition(%player);
	if(!gamebase::getlosinfo(%player, 400)) { bottomprint(%clientId, "<jc>Target out of range!", 2,AIRSTRIKE); return; }
	bottomprint(%clientId, "<jc>You moved, you need to recalculate coordinates!", 5,AIRSTRIKE);
	%clientId.airstriketime=0;
	%clientId.percent=0;
	schedule("Airstrike::onUpdateCallFirst(" @ %clientId @ ");", 0.75);
	}
}

function Airstrike::onUpdateCall(%clientId)
{
if(gamebase::getmuzzletransform(%clientId) == %clientId.firstaim && gamebase::getposition(%clientId) == %clientId.firstpos && %clientId.airstriketime < 20)
	{
	%clientId.airstriketime++;
	%clientId.percent = %clientId.percent + 5;
	bottomprint(%clientId, "<jc>Transmitting airstrike coordinates: <f2>" @ %clientId.percent @ "%", 1,AIRSTRIKE);
	if(%clientId.percent == 100) Airstrike::onUpdateCall(%clientId);
	else schedule("Airstrike::onUpdateCall(" @ %clientId @ ");", 0.75);
	}
else if(gamebase::getmuzzletransform(%clientId) == %clientId.firstaim && gamebase::getposition(%clientId) == %clientId.firstpos && %clientId.airstriketime >= 19)
	{
	Airstrike::onActivate(%clientId);
	%clientId.airstrikewaittime = 60;
	schedule("Airstrike::onUpdateClient(" @ %clientId @ ");", 1);
	}
else
	{
	bottomprint(%clientId, "<jc>You moved, coordinates lost! Airstrike canceled.", 5,AIRSTRIKE);
	%clientId.airstrikewaittime = 60;
	schedule("Airstrike::onUpdateClient(" @ %clientId @ ");", 1);
	}
}
	
function Airstrike::onUpdateClient(%clientId)
{
%clientId.airstrikewaittime--;
if(%clientId.airstrikewaittime == 0) return;
else schedule("Airstrike::onUpdateClient(" @ %clientId @ ");", 1);
}

function Airstrike::onActivate(%clientId)
{
%player = client::getownedobject(%clientId);

if(gamebase::getlosinfo(%player, 400))
	{
	%beacon = newObject("Airstrike Beacon","Turret",ASB,true); 
	GameBase::setTeam(%beacon,gamebase::getteam(%player)); 
	gamebase::setposition(%beacon, $los::position);
	GameBase::setRotation(%beacon,"0, 0, 0"); 
	addToSet("MissionCleanup", %beacon);
	schedule("Airstrike::spawnBombs(" @ %beacon @ "," @ %player @ ");",7.5);
	schedule("deleteobject(" @ %beacon @ ");",7.6);
	}
else bottomprint(%clientId, "<jc>Target out of range!", 2,AIRSTRIKE);
}

TurretData ASB	   
{			 
	className = "Turret";
	shapeFile = "breath";
	maxDamage = 999999999999999999992.5;
	maxEnergy = 60;
	minGunEnergy = 100;
	maxGunEnergy = 6;
	reloadDelay = 0.1;
	speed = 5.0;
	speedModifier = 1.0;
	range = 0;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = debrislargeExplosion;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "A.S.B";
};

function Airstrike::spawnBombs(%beacon, %player)
{

%trans = gamebase::getmuzzletransform(%beacon);
		%pos1=getWord(%trans,0); //right 1
		%pos2=getWord(%trans,1); //right 2
		%pos3=getWord(%trans,2); //right 3
		%pos4=getWord(%trans,3); //front 1
		%pos5=getWord(%trans,4); //front 2
		%pos6=getWord(%trans,5); //front 3
		%pos7=getWord(%trans,6); //up 1
		%pos8=getWord(%trans,7); //up 2
		%pos9=getWord(%trans,8); //up 3
		%pos10=getWord(%trans,9); 
		%pos11=getWord(%trans,10);
		%pos12=getWord(%trans,11);

%newupvector = %pos7 @ " " @ %pos8 @ " " @ %pos9;
%newfrontvector = vector::neg(%newupvector);

%newpos4 = getword(%newfrontvector, 0);
%newpos5 = getword(%newfrontvector, 1);
%newpos6 = getword(%newfrontvector, 2);

%transA = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 150 @ " "@%pos12 + 200;
%transB = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 125 @ " "@%pos12 + 300;
%transC = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 100 @ " "@%pos12 + 400;
%transD = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 75 @ " "@%pos12 + 500;
%transE = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 50 @ " "@%pos12 + 600;
%transF = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 + 25 @ " "@%pos12 + 700;
%transG = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@ " "@%pos12 + 800;
%transH = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 25 @ " "@%pos12 + 900;
%transI = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 50 @ " "@%pos12 + 1000;
%transJ = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 75 @ " "@%pos12 + 1100;
%transK = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 100 @ " "@%pos12 + 1200;
%transL = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 125 @ " "@%pos12 + 1300;
%transM = %pos1@" "@%pos2@" "@%pos3@" "@%newpos4@" "@%newpos5@" "@%newpos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11 - 150 @ " "@%pos12 + 1400;
		
%vel = item::getvelocity(%beacon);
Projectile::spawnProjectile("AB",%transA,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transB,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transC,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transD,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transE,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transF,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transG,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transH,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transI,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transJ,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transK,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transL,%player,%vel).explosive = 1;
Projectile::spawnProjectile("AB",%transM,%player,%vel).explosive = 1;
}

function Airstrike::StartPlane(%player)
{
%clientId = Player::getClient(%player);


if(gamebase::getlosinfo(%player, 400))
	{
	%beacon = newObject("Airstrike Beacon","Turret",ASB,true); 
	GameBase::setTeam(%beacon,gamebase::getteam(%player)); 
	gamebase::setposition(%beacon, $los::position);
	GameBase::setRotation(%beacon,"0, 0, 0"); 
	addToSet("MissionCleanup", %beacon);
	%beaconpos = gamebase::getposition(%beacon);
	deleteobject(%beacon);
	%plane = newObject("AirStrike",InteriorShape,"gswdrop.dis");
	%planeSpawnPos = Vector::Add(%beaconpos, "0 825 180");
	Gamebase::setposition(%plane, %planeSpawnPos);
	GameBase::startFadeIn(%plane);
	addToSet("MissionCleanup", %plane);
	%clientId.plane = 800;
	Airstrike::PlaneFly(%plane, %clientId);
	
	}
else bottomprint(%clientId, "<jc>Target out of range!", 2,AIRSTRIKE);
}

function Airstrike::PlaneFly(%plane, %clientId)
{
%clientId.plane = %clientId.plane - 1;
%planepos = gamebase::getposition(%plane);
%newpos = vector::sub(%planepos, "0 5 0");
gamebase::setposition(%plane, %newpos);
if(%clientId.plane == 0) {
deleteobject(%plane);
return;
}
else schedule("Airstrike::PlaneFly(" @ %plane @ "," @ %clientId @ ");", 0.1);
}

//------------------------------------------------------------------
//---------------------Locking-Airstrike-code-----------------------
function Locker::onActivate(%cl)
{
focusserver();
%pl = client::getownedobject(%cl);
if(gamebase::getlosinfo(%pl, 800))   //Spawn 2 fighters 2000 meters from target
	{
	%pos = $los::position; 
	%obj = newObject(AutoFlier2,"Flier", AutoFlier2 );
	addToSet("MissionCleanup", %obj);	
	%randx = floor(getrandom()*2000-1000); %randy = floor(sqrt(2000*2000-%randx*%randx));
	if(getrandom() > 0.5) %randy = %randy*-1;
	%startpos = vector::add(%pos, %randx @ " " @ %randy @ " 200");
	%startrot = vector::sub(%pos, %startpos);
	%startrot = getword(%startrot, 0) @ " " @ getword(%startrot, 1) @ " 0";
	%startrot = vector::add(vector::getrotation(vector::normalize(%startrot)), "1.57079 0 0");
	echo(%startpos);
	echo(%startrot);
	gamebase::setposition(%obj, %startpos);
	gamebase::setrotation(%obj, %startrot);
	schedule("deleteobject(" @ %obj @ ");",60,%obj);
	
	%obj.target = %pos;
	schedule("locker::loop(" @ %obj @ ", " @ %cl @ ");",0.2);
	}
}

function locker::loop(%obj, %caller)
{
%pl = client::getownedobject(%caller);
if(Player::isDead(%pl)) return;
%lastpos = %obj.target;
if(gamebase::getlosinfo(%pl, 800))  
	{
	echo(loop,getrandom());
	%pos = $los::position; 
	if(vector::getdistance(%pos, %lastpos) > 6)
		{
		//cancel stuff
		return;
		}
	%vector = vector::sub(%pos, gamebase::getposition(%obj));
	if(vector::getdistance(%pos, gamebase::getposition(%obj)) > 500) %vector = getword(%vector,0) @ " " @ getword(%vector, 1) @ " 0";
	%vector = vector::normalize(%vector);
	%newrot = vector::add(vector::getrotation(%vector), "1.57079 0 0");
	gamebase::setrotation(%obj, %newrot);
	%obj.target = %pos;
	}
schedule("locker::loop(" @ %obj @ ", " @ %caller @ ");",0.2,%obj);
}