function Vector::Ricochet(%vector, %normal)
{
%vector = vector::neg(%vector);
%x = vector::sub(%normal, %vector);
return vector::normalize(%x);		
}

function projectile::onhit(%this)
{
%pos = getboxcenter(%this);
%vel = item::getvelocity(%this);
%vector = vector::normalize(%vel);
if(%this.shooter == "") %shooterid = 2048;
if(getlosinfo(%pos, vector::add(%pos, %vel), -1))
	{
	if(%this.explosive)
		{
		if(getobjecttype($los::object) == "InteriorShape")
			{
			%vector = vector::ricochet(%vector, $los::normal);
			for(%x = 0; %x < 3+floor(getrandom()*2); %x++)
				{
				%vec = vector::sub(%vector, vector::multiply(vector::getrandom(), "0.4 0.4 0.4"));
				%trans = "0 1 0 " @ %vec @ " 0 1 0 " @ vector::add($los::position, %vector);
				projectile::Spawnprojectile("Arock", %trans, %shooterid, "0 0 0");
				}
			for(%x = 0; %x < 10; %x++)
				{
				%vec = vector::sub(%vector, vector::multiply(vector::getrandom(), "0.4 0.4 0.4"));
				%trans = "0 1 0 " @ %vec @ " 0 1 0 " @ vector::add($los::position, %vector);
				schedule("projectile::Spawnprojectile(\"DustWave1\",\"" @ %trans @ "\", %shooterid, \"0 0 0\");", %x*0.06);
				}
			}
		if(getobjecttype($los::object) == "SimTerrain" && getmaterial() != "ice")
			{
			%vector = vector::ricochet(%vector, $los::normal);
			for(%x = 0; %x < 5+floor(getrandom()*4); %x++)
				{
				%vec = vector::normalize(vector::sub(%vector, vector::multiply(vector::getrandom(), "0.5 0.5 0.8")));
				%trans = "0 1 0 " @ %vec @ " 0 1 0 " @ vector::add($los::position, %vector);
				projectile::Spawnprojectile("HiGround", %trans, %shooterid, "0 0 0");
				}
			for(%x = 0; %x < 10; %x++)
				{
				%vec = vector::sub(%vector, vector::multiply(vector::getrandom(), "0.5 0.5 0.8"));
				%trans = "0 1 0 " @ %vec @ " 0 1 0 " @ vector::add($los::position, %vector);
				schedule("projectile::Spawnprojectile(\"DustWave1\",\"" @ %trans @ "\", %shooterid, \"0 0 0\");", %x*0.02);
				}
			}
		if(getobjecttype($los::object) == "SimTerrain" && getmaterial() == "ice")
			{
			%vector = vector::ricochet(%vector, $los::normal);
			for(%x = 0; %x < 5+floor(getrandom()*4); %x++)
				{
				%vec = vector::normalize(vector::sub(%vector, vector::multiply(vector::getrandom(), "0.5 0.5 0.8")));
				%trans = "0 1 0 " @ %vec @ " 0 1 0 " @ vector::add($los::position, %vector);
				schedule("projectile::Spawnprojectile(\"SnowPuff\",\"" @ %trans @ "\", %shooterid, \"0 0 0\");", %x*0.02);
				}
			}
		}
	//echo("Hit object ", $los::object, " at position ", $los::position);
	//echo("Object: ", getobjecttype($los::object));
	}
}


function Alarm()
{
messageall(0, "~werror_message.wav");
messageall(0, "~wfloat_target.wav");

}

function GetSpawnClassCode(%class,%dead)
{
if(%dead) return "RIP";
if(%class == "assault") return "AS ";
else if(%class == "assault2") return "AS2";
else if(%class == "scout") return "SC ";
else if(%class == "antitank") return "AT ";
else if(%class == "medic") return "MED";
else if(%class == "engineer") return "ENG";
else if(%class == "antitank2") return "AT2";
else return "   ";
}

function WWII::ScreenShake(%pl, %level) //level 0 to 1
{
if(%pl.isvehicle == 1 || %pl.vehicle > 0) return;
%rot = GameBase::GetRotation(%pl);
%rot1 = getword(%rot, 0);
%rot2 = getword(%rot, 1);
%rot3 = getword(%rot, 2);
if(%pl.stimpack == 1) return;
for(%x = 0; true; %x += 0.1)
	{
	if(%level <= 0) break;
	%new = %rot1 @ " " @ %rot2 @ " " @ %rot3+%level;
	%left = %rot1 @ " " @ %rot2 @ " " @ %rot3-%level;
	schedule("GameBase::SetRotation(" @ %pl @ ", \"" @ %new @ "\");", %x);
	%level -= 0.025;
	schedule("GameBase::SetRotation(" @ %pl @ ", \"" @ %left @ "\");", %x+0.05);
	}

}

GrenadeData SnowPuff
{	
   bulletShapeName    = "smoke.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 2.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 10;
   totalTime          = 10.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

GrenadeData HiGround
{	
   bulletShapeName    = "dustplume.dts";
   explosionTag       = Dust;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 2.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 10;
   totalTime          = 10.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";
};

GrenadeData arock
{	
   bulletShapeName    = "mortar.dts";
   explosionTag       = flashexpsmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $explosion;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 14;
   totalTime          = 30.0;
   liveTime           = 2.2;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

GrenadeData fragexp1
{	
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisexpsmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};
GrenadeData fragexp2
{	
   bulletShapeName    = "camera.dts";
   explosionTag       = debrisexpmedium;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
GrenadeData fragexp3
{	
   bulletShapeName    = "mine.dts";
   explosionTag       = flashexpsmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};
GrenadeData fragexp4
{	
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = debrisexpmedium;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};
GrenadeData fragexp5
{	
   bulletShapeName    = "dustplume.dts";
   explosionTag       = flashexplarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";
};
GrenadeData fragexp6
{	
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = fire;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = 1000;

   explosionRadius    = 4.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};
GrenadeData defpart
{	
   bulletShapeName    = "flagstand.dts";
   explosionTag       = flashexpsmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = 1000;

   explosionRadius    = 5.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 40;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

function WWII::TreeFallsequence(%id)
{
gamebase::getlosinfo(%id, 15, "-1.57079 0 0");

if(getrandom() <= 0.5) {
%finalrot = vector::add("1.57079 0 0", vector::getrotation($los::normal));
%firstrot = gamebase::getrotation(%id);
%rottoturn = vector::sub(%finalrot, %firstrot);
%currot = %firstrot;
%frames = 15;
for(%x = 0; %x < %frames; %x++)
	{
	%f = vector::multiply(%rottoturn, "-0.066 0 0.0");
	%currot = vector::add(%currot, %f);
	schedule("treedam(" @ %id @ "); gamebase::setrotation(" @ %id @ ", \"" @ %currot @ "\");", sqrt(%x*2)/7-0.1);
	}
}
else {

%finalrot = vector::neg(vector::add("1.57079 0 0", vector::getrotation($los::normal)));
%firstrot = gamebase::getrotation(%id);
%rottoturn = vector::sub(%finalrot, %firstrot);
%rottoturn = vector::add(%rottoturn, "3.14159 0 0");
%currot = %firstrot;
%frames = 15;
for(%x = 0; %x < %frames; %x++)
	{
	%f = vector::multiply(%rottoturn, "0.066 0 0.0");
	%currot = vector::add(%currot, %f);
	schedule("treedam(" @ %id @ "); gamebase::setrotation(" @ %id @ ", \"" @ %currot @ "\");", sqrt(%x*2)/7-0.1);
	}

}
}

function treedam(%this)
{
GameBase::applyRadiusDamage($TreeDamageType, getBoxCenter(%this), 2.1+%this.rl, 1.1,10,%this);
%this.rl += 0.35;
}

//function WWII::RocketSeq(%this,%owner)
//{
//if(%owner != %this.player) return;
//%vel = item::getvelocity(%this);
//%vel = vector::sub(%vel, "0 0 1.3"); //go down
//%vel = vector::multiply(%vel, "1.01 1.01 1"); //accelerate
//item::setvelocity(%this, %vel);
//schedule("WWII::RocketSeq("@ %this @ "," @ %owner @ ");",0.1);
//}
RocketData Smokething1
{
	bulletShapeName = "dustplume.dts";
	explosionTag = Dust;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $nothing;		
	explosionRadius = 1;
	kickBackStrength = 1.0;
	muzzleVelocity = 4.0;
	terminalVelocity = 5.0;
	acceleration = 500.0;
	totalTime = 0.001;
	liveTime = 0.002;
	
	inheritedVelocityScale = 0.8;
	
};
RocketData Smokething2
{
	bulletShapeName = "dustplume.dts";
	explosionTag = smokeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $nothing;		
	explosionRadius = 1;
	kickBackStrength = 1.0;
	muzzleVelocity = 4.0;
	terminalVelocity = 5.0;
	acceleration = 500.0;
	totalTime = 0.001;
	liveTime = 0.002;
	
	inheritedVelocityScale = 0.8;
	
};

RocketData DustWave1
{
	bulletShapeName = "dustplume.dts";
	explosionTag = heavyDust;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $nothing;		
	explosionRadius = 1;
	kickBackStrength = 1.0;
	muzzleVelocity = 12.0;
	terminalVelocity = 11.0;
	acceleration = 500.0;
	totalTime = 0.85;
	liveTime = 0.85;
	trailType   = 2;                // smoke trail
  	 trailString = "dustplume.dts";
  	 smokeDist   = 1.8;
	inheritedVelocityScale = 0.8;
	
};
function WWII::RocketSeq(%this,%owner)
{
if(%owner != %this.player) return;
%vel = item::getvelocity(%this);
if(%vel == "0 0 0") return;
%vel = vector::add(%vel, "0 0 -0.26");
%vel = vector::multiply(%vel, "1.06 1.06 1.06"); //accelerate
if(%this.shooter == "") %shooterid = 2048;
item::setvelocity(%this, %vel);
if(%this.a == 0 || %this.a == 1) projectile::spawnprojectile("smokething2", "1 0 0 0 1 0 0 0 1 " @ vector::add(gamebase::getposition(%this),vector::multiply(%vel, "0.1 0.1 0.1")) , %shooterid, %vel);
else if(%this.a == 2) projectile::spawnprojectile("smokething1", "1 0 0 0 1 0 0 0 1 " @ gamebase::getposition(%this) , %shooterid, %vel);
//echo(gamebase::getmuzzletransform(%this));
schedule("WWII::RocketSeq("@ %this @ "," @ %owner @ ");",0.1);
%this.a++;
if(%this.a == 3) %this.a = 0;
}

function WWII::Blood(%pl, %val, %pos, %vec,%isexp)
{
%x = getrandom();
if(%val > 1) %val = 1;
//%pos = gamebase::getposition(%pl);
%vec = vector::normalize(%vec);
//echo("pl: ",%pl, " val:" , %val, " pos:", %pos, " vec:" , %vec);
%num1 = getrandom()/2.5 -0.2;%num2 = getrandom()/2.5 -0.2;%num3 = getrandom()/2.5 -0.2;
%vec = vector::normalize(vector::add(%vec, %num1 @ " " @ %num2 @ " " @ %num3)); 
for(%i = 0; %i < %val; %i += 0.125)
	{
	%num1 = getrandom()/2.5 -0.2;%num2 = getrandom()/2.5 -0.2;%num3 = getrandom()/2.5 -0.2;
	%vec = vector::normalize(vector::add(%vec, %num1 @ " " @ %num2 @ " " @ %num3)); 
	if(%isexp) %vec = Vector::getRandom();
	if(getrandom() > 0.4) //0.4 
		{
		if(%x > 0.3) %trans = "0 0 0 " @ %vec @ " 0 0 0 " @ %pos;
		else %trans = "0 0 0 " @ vector::neg(%vec) @ " 0 0 0 " @ %pos; 
		%id = projectile::spawnprojectile("bloodbullet", %trans, %pl, item::getvelocity(%pl));
		
		}
	else 
		{
		if(%x > 0.3) %trans = "0 0 0 " @ %vec @ " 0 0 0 " @ %pos;
		else %trans = "0 0 0 " @ vector::neg(%vec) @ " 0 0 0 " @ %pos; 
		%id = projectile::spawnprojectile("bloodfall", %trans, %pl, item::getvelocity(%pl));
		//echo("fallingblood"); echo(%pos);
		}
	}
}

GrenadeData bloodfall
{	bulletShapeName = "laserhit.dts";
	explosionTag = bloodexp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.2;
	damageClass = 4;
	damageValue = 0.05;
	damageType = $nothing;
	explosionRadius = 0.1;
	kickBackStrength = 0.4;
	maxLevelFlightDist = 3;
	totalTime = 3;
	liveTime = 0.05;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "laserhit.dts";
	smokeDist = 0.1;
};

BulletData bloodBullet
{
   bulletShapeName    = "laserhit.dts";
   validateShape      = true;
   explosionTag       = bloodexp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 1;

   damageClass        = 0;      
   damageValue        = 0.001;
   damageType         = $treedamagetype;

    aimDeflection      = 0.01;
   muzzleVelocity     = 6.5;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};

function WWII::SpawnKill(%cl)
{
messageall(2, client::getname(%cl) @ " activated the anti-spawnkill system.");
%list = FindObject("basepost");
if(gamebase::getteam(getword(%list, 0)) == 0) { %alliedbasepost = getword(%list, 0); %axisbasepost = getword(%list, 1); }
else { %alliedbasepost = getword(%list, 1); %axisbasepost = getword(%list, 0); }
 
%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%alliedbasepost);
%num = containerBoxFillSet(%Set, $Simplayerobjecttype, %Pos, 60, 60, 60,0); 
for(%i = 0; %i < %num; %i++)
	{
	%curplayer = group::getobject(%set, %i); if(gamebase::getteam(%curplayer) == 1 && !player::isdead(%curplayer)) {
	%group = "MissionGroup\\Teams\\Team1\\DropPoints\\Random";
	%numofdroppoints = group::objectcount(%group);
	%randomdroppoint = group::getobject(%group, floor(getrandom()*%numofdroppoints));
	gamebase::setposition(%curplayer, gamebase::getposition(%randomdroppoint));
	gamebase::playsound(%curplayer, soundshieldhit, 1);
	schedule("gamebase::playsound(" @ %curplayer @ ", soundshieldhit, 1);",0.2,%curplayer);
	}}
deleteobject(%set);

%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%axisbasepost);
%num = containerBoxFillSet(%Set, $Simplayerobjecttype, %Pos, 60, 60, 60,0); 
for(%i = 0; %i < %num; %i++)
	{
	%curplayer = group::getobject(%set, %i); if(gamebase::getteam(%curplayer) == 0 && !player::isdead(%curplayer)) {
	%group = "MissionGroup\\Teams\\Team0\\DropPoints\\Random";
	%numofdroppoints = group::objectcount(%group);
	%randomdroppoint = group::getobject(%group, floor(getrandom()*%numofdroppoints));
	gamebase::setposition(%curplayer, gamebase::getposition(%randomdroppoint));
	gamebase::playsound(%curplayer, soundshieldhit, 1);
	schedule("gamebase::playsound(" @ %curplayer @ ", soundshieldhit, 1);",0.2,%curplayer);
	}}
deleteobject(%set);
}

function Tank::Update(%this) //10 times saved lag!
{
if(%this > 2000 && string::findsubstr($WWII::TankList, %this) < 0) $WWII::TankList = $WWII::TankList @ %this @ " ";
for(%i = 0; getword($WWII::TankList, %i) != -1; %i++)
{
%this = getword($WWII::TankList, %i);
%speed = vector::getdistance(item::getvelocity(%this), "0 0 0");
%pos = gamebase::getposition(%this);
%los = getLosInfo(%pos, vector::add(%pos, "0 0 -10"),1);
if(%los) 
	{
	%N = $los::normal;
	%trans = gamebase::getmuzzletransform(%this);
	%upvector = getword(%trans, 6) @ " " @ getword(%trans, 7) @ " " @ getword(%trans, 8);	
	%aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
	%this.aimvector = %aimvector;
	%alpha = getanglebetweenvectors(%N, %aimvector);
	%alpha = %alpha - 90;
	%rad = 180/3.14159;
	%rot = gamebase::getrotation(%this);
		if(%this.lastrotZ != "") %forcerotZ = %this.lastrotZ;
		else %forcerotZ = getword(%rot, 2);
	%rot = getword(%rot,0)+(%alpha/%rad)*0.3 @ " " @ "0" @ " " @ %forcerotZ;
	if(%speed >= 3) gamebase::setrotation(%this, %rot); //Z ROTATE DONE
	%pos = gamebase::getposition(%this);
	if(vector::getdistance($los::position, %pos) < 1.9) gamebase::setposition(%this, vector::add(%pos, "0 0 " @ 1.9-vector::getdistance(%pos, $los::position)));
	if(vector::getdistance($los::position, %pos) > 2.5) gamebase::setposition(%this, vector::add(%pos, "0 0 " @ 1.9-vector::getdistance(%pos, $los::position)));
        %this.lastrotZ = getword(gamebase::getrotation(%this), 2);
	//POSITION FIX DONE	
	}
}

if($lfct != getsimtime())
schedule("tank::update(); ",0.1);
$lfct = getsimtime();
}

function flash(%pos)
{
%obj = newobject("Light", SimLight, "Point",1000,0,0,1,getword(%pos, 0),getword(%pos,1),getword(%pos,2));
schedule("deleteobject(" @ %obj @ ");",0.25+getrandom()*0.25,%obj);
addtoset("MissionCleanup", %obj);
}

LightningData HighPower
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $Electricity;
   boltLength       = 450.0;
   coneAngle        = 85.0;
   damagePerSec      = 40.06;
   energyDrainPerSec = 0.0;
   segmentDivisions = 6;
   numSegments      = 3;
   beamWidth        = 2;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   //soundId = SoundELFFire;
};
LightningData UltraPower
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $Pak;
   boltLength       = 450.0;
   coneAngle        = 10.0;
   damagePerSec      = 50.06;
   energyDrainPerSec = 0.0;
   segmentDivisions = 6;
   numSegments      = 1;
   beamWidth        = 6;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   //soundId = SoundELFFire;
};

function ShermanTank::Aim(%this,%dir) //aim 0.1 up
{
%pl = client::getownedobject(ai::getid("TankGuy" @ %this));
%trans = gamebase::getmuzzletransform(%this);
%aim = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);

if(%this.aimZ == "") %this.aimZ = 0;
if(%this.aimZ > 0.52 && %dir > 0) return;
if(%this.aimZ < -0.16 && %dir < 0) return;
%this.aimZ += 0.1*%dir;
%aimZ = %this.aimZ;

%forward = vector::multiply(%aim, "1000 1000 1000"); //vehicle always points forward
%targetpos = vector::add(%forward, vector::multiply("1000 1000 1000", "0 0 " @ %aimZ));
%this.aimvector = vector::normalize(vector::sub(%targetpos, getboxcenter(%this)));
//ai::directivetargetpoint("TankGuy" @ %this, "0 0 0", 101);
ai::directivetargetpoint("TankGuy" @ %this, %targetpos, 101);
echo(%targetpos);

}


function WWII::RealityDeath(%cl, %anim)
{
%trans = gamebase::getmuzzletransform(%cl);
%aimvector = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);

if(1)
	{
	%tmppos = vector::add(gamebase::getposition(%cl), vector::multiply(%aimvector, "2.2 2.2 2.2"));
	%tmpposx = gamebase::getposition(%cl);
	//echo(%aimvector);
	if(!getLOSinfo(%tmppos, vector::sub(%tmppos, "0 0 3"), 1))
		for(%x = 1.5; %x < 2.5; %x += 0.05) 	
			{
			schedule("if(player::getlastcontactcount(" @ %cl @ ") == 0) player::applyimpulse(" @ %cl @ ",\"" @ vector::multiply(%aimvector, "13 13 131") @ "\");", %x);
			%tmpposx = vector::add(%tmpposx, vector::multiply(%aimvector, "0.12 0.12 0.12"));
			
			}
	}
}


GrenadeData PlaneWing1
{	
   bulletShapeName    = "Anten_lava.dts";
   explosionTag       = debrisexplarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.7;
   damageType         = $explosion;

   explosionRadius    = 6.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1;
   smokeName              = "plasmaex.dts";
};

GrenadeData PlaneWing2
{	
   bulletShapeName    = "flyer.dts";
   explosionTag       = debrisexplarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.8;
   damageType         = $explosion;

   explosionRadius    = 9.0;
   kickBackStrength   = 3.0;
   maxLevelFlightDist = 30;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1;
   smokeName              = "plasmaex.dts";
};