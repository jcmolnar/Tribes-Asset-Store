function WWII::WeatherLoop()
{
$WWII::ConstantWindEnabled = 0;
if(isobject(714)) { %wasfall = 1; deleteobject(714); }
%randomweather = randomitems($WWII::Weather, getnumwords($WWII::Weather));
if(%randomweather == "snow")
	{
	%obj = newObject("snowfall", snowfall, 1, 0, 0, 0);
	//addtoset("MissionCleanup", %obj); 
	}
else if(%randomweather == "rain") 
	{
	%obj = newobject("rain", snowfall, 1,0,0,1);
	//addtoset("MissionCleanup", %obj); 
	}
else if(%randomweather == "rainstorm")
	{
	if(%wasfall) 
		{
		Messageall(3, "--WARNING!! Catastrophic weather storm approaching!");
		%obj = newobject("rain", snowfall, 1,0,0,1);
		WWII::StartWindWeather();
		WWII::ScheduleLightningStorm();
		}
	else %obj = newobject("rain", snowfall, 1,0,0,1);
	}
schedule("WWII::WeatherLoop();", 4*60+getrandom()*60);
}

function WWII::StartWindWeather()
{
$WWII::ConstantWindEnabled = 1;
WWII::WindLoop();
}

function WWII::WindLoop()
{
if($WWII::ConstantWindEnabled != 1) return;
for(%cl = Client::getfirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	client::sendmessage(%cl, 1, "~wwind1.wav");
	}
schedule("WWII::WindLoop();", 4.4+getrandom()*0.12);
}

function WWII::ScheduleLightningStorm(%timeleft)
{
if(%timeleft > 0) %randomtime = getrandom() * %timeleft;
else %randomtime = getrandom() * 240; //default max time
echo(%randomtime, " = time until lightning");
schedule("WWII::LightningBlast(" @ %randomtime @ ");", %randomtime);
}

function WWII::LightningBlast(%timewaited)
{
for(%x = 8000; %x < 9500; %x++)
	if(isobject(%x))
		if(getobjecttype(%x) == "Player" || getobjecttype(%x) == "Turret" || getobjecttype(%x) == "staticshape")
			%objectslist = %objectslist @ %x @ " ";
%object = getword(%objectslist, floor(getrandom()*getnumwords(%objectslist)));
echo("Powered object: " @ %object @ "(", getobjecttype(%object), ")");
flash();
schedule("shock(" @ %object @ ");", 1);

schedule("GameBase::applyDamage(" @ %object @ ", " @ $Electricity @ ", 6, \"" @ getboxcenter(%object) @ "\", \"0 0 0\", \"0 0 0\", 2048);", 1);

schedule("WWII::ScheduleLightningStorm(" @ 238-%timewaited @ ");", 2);
}


function shock(%object)
{
%pos = vector::add(getboxcenter(%object), "0 0 100");
%target = %object;

//flash(vector::sub(%pos, "0 1 300"));
%obj = newobject("Shooter", Turret, DummyTurret);
addtoset("MissionCleanup", %obj);
gamebase::setposition(%obj, %pos);

%targetpos = gamebase::getposition(%target);
%vectotarget = vector::sub(%targetpos, %pos);
%vectotarget = vector::normalize(%vectotarget);
%rot = vector::add(vector::getrotation(%vectotarget), "1.57079 0 0");
gamebase::setposition(%obj, vector::add(%pos, %vectotarget));

gamebase::setrotation(%obj, %rot);
schedule("%id = projectile::spawnprojectile(\"HighPower\", gamebase::getmuzzletransform(" @ %obj @ "), " @ %obj @ ", \"0 0 0\"); schedule(\"deleteobject(\" @ %id @ \");\",0.4); ", 0.05);
//bigExplosion1
schedule("deleteobject(" @ %obj @ ");", 0.82);

for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	%p = getboxcenter(%cl);
	%dist = vector::getdistance(%p, getboxcenter(%dude));
	schedule("client::sendmessage(" @ %cl @ ",2,\"~wbxplo1.wav\");",%dist/300);
	}
}