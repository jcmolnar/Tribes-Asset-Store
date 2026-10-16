exec(ai);
exec(WWII_GermanAI);

$SensorNetworkEnabled = false;

function spawnfirstdudes()
{
%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
%group = "MissionGroup\\Lolbot";
%spawnmarker = group::getobject(%group, 0);
%pos = gamebase::Getposition(%spawnmarker);
%rot = gamebase::getrotation(%spawnmarker);
%ainame = "deadmeatlol";
AI::spawn( %aiName, soldier, %pos, %rot, %plname, "male2" );
%id = ai::getid(%ainame);
%pl = client::getownedobject(%id);
client::setinitialteam(%id, 1);
gamebase::setteam(%id, 1);
ai::setvar(%ainame, iq, 280);
Ai::setscriptedtargets(%ainame);
ai::setvar(%ainame, attackmode, -1);
player::setitemcount(%id, xrifle, 1);
player::setitemcount(%id, grenade, 1);
player::setitemcount(%id, nadeammo, 0);
player::Setitemcount(%id, nade, 1);
player::setitemcount(%id, PriWeapClip, 7);
player::setitemcount(%id, xrifleammo, 1);
player::mountitem(%id, xshotgun, $weaponslot);
%pl.equipment = "scout";

%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
%group = "MissionGroup\\tkbot";
%spawnmarker = group::getobject(%group, 0);
%pos = gamebase::Getposition(%spawnmarker);
%rot = gamebase::getrotation(%spawnmarker);
%ainame = "dumbbot";
AI::spawn( %aiName, soldier, %pos, %rot, %plname, "male2" );
%id = ai::getid(%ainame);
%pl = client::getownedobject(%id);
client::setinitialteam(%id, 1);
gamebase::setteam(%id, 1);
ai::setvar(%ainame, iq, 280);
ai::setautomatictargets(%ainame);
ai::setvar(%ainame, attackmode, -1);
player::setitemcount(%id, xstg, 1);
player::setitemcount(%id, grenade, 1);
player::setitemcount(%id, nadeammo, 1);
player::Setitemcount(%id, nade, 1);
player::setitemcount(%id, PriWeapClip, 2);
player::setitemcount(%id, xstgammo, 20);
player::mountitem(%id, xstg, $weaponslot);
ai::Directivewaypoint(%ainame, gamebase::getposition(group::getobject(%group, 1)), 100);
ai::directivewaypoint(%ainame, %pos, 200);
%pl.equipment = "assault";

%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
%group = "MissionGroup\\sidebase\\bot2";
%spawnmarker = group::getobject(%group, 0);
%pos = gamebase::Getposition(%spawnmarker);
%rot = gamebase::getrotation(%spawnmarker);
%ainame = "dumbbot1";
AI::spawn( %aiName, soldier, %pos, %rot, %plname, "male2" );
%id = ai::getid(%ainame);
%pl = client::getownedobject(%id);
client::setinitialteam(%id, 1);
gamebase::setteam(%id, 1);
ai::setvar(%ainame, iq, 280);
ai::setautomatictargets(%ainame);
ai::setvar(%ainame, attackmode, -1);
player::setitemcount(%id, xpistol, 1);
player::setitemcount(%id, grenade, 1);
player::setitemcount(%id, nadeammo, 1);
player::Setitemcount(%id, nade, 1);
player::setitemcount(%id, $clip[xpistol], 3);
player::setitemcount(%id, xpistolammo, 9);
player::mountitem(%id, xpistol, $weaponslot);
%pl.equipment = "assault";

%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
%group = "MissionGroup\\sidebase\\bot1";
%spawnmarker = group::getobject(%group, 0);
%pos = gamebase::Getposition(%spawnmarker);
%rot = gamebase::getrotation(%spawnmarker);
%ainame = "dumbbot2";
AI::spawn( %aiName, soldier, %pos, %rot, %plname, "male2" );
%id = ai::getid(%ainame);
%pl = client::getownedobject(%id);
client::setinitialteam(%id, 1);
gamebase::setteam(%id, 1);
ai::setvar(%ainame, iq, 280);
ai::setautomatictargets(%ainame);
ai::setvar(%ainame, attackmode, -1);
player::setitemcount(%id, xar, 1);
player::setitemcount(%id, grenade, 1);
player::setitemcount(%id, nadeammo, 0);
player::Setitemcount(%id, nade, 0);
player::setitemcount(%id, $clip[xar], 2);
player::setitemcount(%id, xarammo, 31);
player::mountitem(%id, xar, $weaponslot);
for(%x = 0; %x < group::objectcount(%group); %x++) ai::directivewaypoint(%ainame, gamebase::getposition(group::getobject(%group, %x)), 10+10*%x);
%pl.equipment = "assault2";
}

function testsubject()
{
return Client::GetFirst();
}

$MusicON = 1;

function game::initialmissiondrop(%cl)
{
schedule("focusclient(); sfxclose();", 0.1);
schedule("focusclient(); sfxopen();", 0.2);
%group = "Missiongroup\\teams\\team0\\Droppoints\\Start";
%marker = group::getobject(%group, 0);
%pl = spawnplayer(soldier, gamebase::getposition(%marker), gamebase::getrotation(%marker));
//client::setinitialteam(%cl, 0);
gamebase::setteam(%cl, 0);
//%cl.spawnclass = assault;
gamebase::setteam(%pl, 0);
player::setitemcount(%pl, grenade, 1);
player::setitemcount(%pl, repairkit, 1);
player::setitemcount(%pl, beacon, 1);
player::setitemcount(%pl, mineammo, 1);

if(!$testing) { schedule("if($musicON) client::sendmessage(testsubject(), 1, \"~wtribes_04.wav\");", 338); schedule("if($musicON) client::sendmessage(testsubject(), 1, \"~wtribes_04.wav\");", 169); schedule("client::sendmessage(testsubject(), 1, \"~wtribes_04.wav\");", 0.3); }
schedule("client::setcontrolobject(" @ %cl @ ", " @ %pl @ ");",0.5);
schedule("client::setownedobject(" @ %cl @ ", " @ %pl @ ");", 0.5);
client::setguimode(%cl, $guimodeplay);
}

function animate(%group)
{
%g = 9.8;
%detail = 17;
for(%x = 0; %x < group::objectcount(%group)/2; %x++)
	{
	%obj = group::getobject(%group, %x);
	%marker = group::getobject(%group, (group::objectcount(%group)/2)+%x);
	%startpos = gamebase::getposition(%obj);
	%startrot = gamebase::getrotation(%obj);
	%dist = vector::getdistance(getboxcenter(%obj), getboxcenter(%marker));
	%rotchange = vector::multiply(vector::sub(gamebase::getrotation(%marker), gamebase::getrotation(%obj)), 1/(%dist*%detail) @ " " @ 1/(%dist*%detail) @ " " @ 1/(%dist*%detail));
	%poschange = vector::multiply(vector::sub(gamebase::getposition(%marker), gamebase::getposition(%obj)), 1/(%dist*%detail) @ " " @ 1/(%dist*%detail) @ " " @ 1/(%dist*%detail));
	for(%y = 0; %y < %dist*%detail; %y++)
		{
		schedule("gamebase::setrotation(" @ %obj @ ", vector::add(gamebase::getrotation(" @ %obj @ "), \"" @ %rotchange @ "\"));", sqrt(%y/2.5)/5);
		schedule("gamebase::setposition(" @ %obj @ ", vector::add(gamebase::getposition(" @ %obj @ "), \"" @ %poschange @ "\"));", sqrt(%y/2.5)/5);
		
		}
	//schedule("gamebase::setrotation(" @ %obj @ ", \"" @ %startrot @ "\");", sqrt(%dist*%detail)/5+2);
	//schedule("gamebase::setposition(" @ %obj @ ", \"" @ %startpos @ "\");", sqrt(%dist*%detail)/5+2);
		
	}

}

function spawnguards(%trig, %object)
{
%group = "MissionGroup\\guards";
%num = group::objectcount(%group);
for(%i = 1; %i <= %num; %i++)
	{
	%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
	%spawngroup = %group @ "\\guard" @ %i;
	%spawnpos = gamebase::getposition(group::getobject(%spawngroup, 0));
	%spawnrot = gamebase::getrotation(group::getobject(%spawngroup, 0));
	%classes = "scout assault assault2 medic engineer";
	%class = getword(%classes, floor(getrandom()*5));
	%ainame = "guardnoob" @ %i;
	AI::spawn( %aiName, soldier, %spawnpos, %spawnrot, %plname, "male2" );
	%id = ai::getid(%ainame);
	%pl = client::getownedobject(%id);
	client::setinitialteam(%id, 1);
	gamebase::setteam(%id, 1);
	ai::setvar(%ainame, iq, 280);
	ai::setautomatictargets(%ainame);
	ai::setvar(%ainame, attackmode, -1);
	player::setitemcount(%pl, $weapon[%class, German], 1);
	player::setitemcount(%pl, PriWeapClip, 1);
	if(%class == "scout") player::setitemcount(%pl, PriWeapClip, 10);
	player::setitemcount(%pl, xpistol, 1);
	player::setitemcount(%pl, SecWeapClip, 1);
	player::setitemcount(%pl, grenade, 1);
	if(%class != "engineer") { player::setitemcount(%pl, nade, 1); player::setitemcount(%pl, nadeammo, 1); }
	else { player::setitemcount(%pl, exppack, 1); player::setitemcount(%pl, exppackammo, 2); player::setitemcount(%pl, detonator, 1); player::setitemcount(%pl, detonatorammo, 1); }
	player::setitemcount(%pl, repairkit, 1);
	%pl.equipment = %class;
	player::mountitem(%pl, $weapon[%class, German], $weaponslot);
	for(%a = 0; %a < group::objectcount(%spawngroup); %a++) AI::DirectiveWaypoint(%ainame, gamebase::Getposition(group::getobject(%spawngroup, %a)), (%a+100)*100);
	}
	deleteobject(%trig);
}

function deadguyprocess()
{
%group = "MissionGroup\\dead";
%pl = group::getobject(%group, 0);
gamebase::Setteam(%pl, 1);
player::setitemcount(%pl, xpanzergun, 1);
player::setitemcount(%pl, xpanzerammo, 1);
player::setitemcount(%pl, PriWeapClip, 25);
player::setitemcount(%pl, xpistol, 1);
player::Setitemcount(%pl, SecWeapClip, 2);
player::Setitemcount(%pl, xpistolammo, $Clipsize[xpistol]);
player::setitemcount(%pl, grenade, 1);
player::setitemcount(%pl, nade, 1);
player::setitemcount(%pl, nadeammo, 3);
player::setitemcount(%pl, mineammo, 1);
player::Setitemcount(%pl, repairkit, 1);
%pl.equipment = "antitank";
player::mountitem(%pl, xpanzergun, $weaponslot); 
}

deadguyprocess();

function AIMine::onCollision(%this,%obj)
{
%trans = "1 0 0 0 0 1 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 4");
Projectile::spawnProjectile("HowitzerBomb",%trans,2048,"0 0 0").explosive = 1;
schedule("Projectile::spawnProjectile(\"HowitzerBomb\",\"" @ %trans @ "\",2048,\"0 0 0\").explosive = 1;", 0.8);
for(%x = 0; %x < 10; %x++)
	{
	%trans = "1 0 0 " @ 2*getrandom()-1 @ " " @ 2*getrandom()-1 @ " " @ getrandom() @ " 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 3");
	Projectile::spawnProjectile("fragexp1",%trans,2048,"0 0 0");
	%trans = "1 0 0 " @ 2*getrandom()-1 @ " " @ 2*getrandom()-1 @ " " @ getrandom() @ " 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 3");
	schedule("Projectile::spawnProjectile(\"fragexp2\",\"" @ %trans @ "\",2048,\"0 0 0\");",0.25);
	%trans = "1 0 0 " @ 2*getrandom()-1 @ " " @ 2*getrandom()-1 @ " " @ getrandom() @ " 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 3");
	schedule("Projectile::spawnProjectile(\"fragexp4\",\"" @ %trans @ "\",2048,\"0 0 0\");",0.5);
	%trans = "1 0 0 " @ 2*getrandom()-1 @ " " @ 2*getrandom()-1 @ " " @ getrandom() @ " 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 3");
	schedule("Projectile::spawnProjectile(\"fragexp5\",\"" @ %trans @ "\",2048,\"0 0 0\");",0.75);
	%trans = "1 0 0 " @ 2*getrandom()-1 @ " " @ 2*getrandom()-1 @ " " @ getrandom() @ " 0 1 0 " @ vector::add(gamebase::getposition(%this), "0 0 3");
	schedule("Projectile::spawnProjectile(\"fragexp6\",\"" @ %trans @ "\",2048,\"0 0 0\");",1);
	}
gamebase::setposition(%this, "0 0 1000");
}

function caketime(%trig, %pl)
{
if(player::getclient(%pl) != testsubject()) return;
$MusicOn = 0;
focusclient(); 
sfxclose();
sfxopen();
//focusserver();
messageall(1, "~wbxplo1.wav");
WWII::ScreenShake(%pl, 0.3);
%group = "MissionGroup\\boom1";
schedule("boom(1);boom(2);", 14);
schedule("stairfall(1);", 22);
schedule("checkloseXa();", 25);
gamebase::setposition(%trig, "0 0 1000");
spawnstairbots();
spawndeadguy();
}

function spawndeadguy()
{
%group = "MissionGroup\\fallingnoob";
%player = group::getobject(%group, 0);
player::kill(%player);
player::setanimation(%player, 25+floor(getrandom()*13));
gamebase::setteam(%player, 1);
%pos = gamebase::getposition(%player);
gamebase::setposition(%player, vector::sub(%pos, "0 0 30"));
}

function spawnstairbots()
{
focusserver();
for(%x = 1; %x <= 2; %x++)
	{
	%group = "MissionGroup\\stairbots\\bot" @ %x;
	%spawnmarker = group::getobject(%group, 0);
	%pos = gamebase::getposition(%spawnmarker);
	echo(%group);
	echo(%spawnmarker);
	%rot = "0 0 0";
	%ainame = "stairbot" @ %x;
	%plname = $AiName[1, floor(getrandom()* $AiNames[1])];
	AI::spawn( %aiName, soldier, %pos, %rot, %plname, "male2" );
	for(%i = 0; %i < group::objectcount(%group); %i++) AI::DirectiveWaypoint(%Ainame, gamebase::Getposition(group::getobject(%group, %i)), 100+%i*100);
	%cl = ai::getId(%ainame);
	ai::setautomatictargets(%ainame);
	ai::setvar(%ainame, iq, 80);
	ai::setvar(%ainame, SpotDist, 10);
	player::setitemcount(%cl, xpistol, 1);
	player::setitemcount(%cl, secweapclip, 2);
	player::mountitem(%cl, xpistol, $weaponslot);
	}
focusclient();
}
deletevariables("lastroom*");

function spawnlastroom()
{
if($lastroomspawnedggfs) return;
focusserver();
$lastroomspawnedggfs = 1;
%group = "MissionGroup/lastroom/friends";
for(%x = 0; %x < group::objectcount(%group); %x++)
	{
	%marker = group::getobject(%group, %x);
	%pos = getboxcenter(%marker);
	%rot = gamebase::getrotation(%marker);
	%ainame = "friendguy." @ %x;
	AI::spawn( %aiName, soldier, %pos, %rot, "watch this..", "male2" );
	%id = ai::getId(%ainame);
	%pl = client::getownedobject(%id);
	$friendbotlist = $friendbotlist @ %pl @ " ";
	client::setinitialteam(%id, 0);
	gamebase::setteam(%id, 0);
	player::mountitem(%id, yPPSH, $weaponslot);
	}
	focusclient();
}
deletevariables("friendbot*");

function kotarosidea()
{
%hellobot = getword($friendbotlist, 4);
player::setanimation(%hellobot, 50);
gamebase::playsound(%hellobot, AI_hello, 3);
for(%x = 0; getword($friendbotlist, %x) != -1; %x++)
	{
	%pl = getword($friendbotlist, %x);
	player::blowup(%pl);
	schedule("player::kill(" @ %pl @ ");", 1.5);
	}
winmission();
}

function winmission()
{
exec(game);
exec(ai);
exec(WWII_menu);
exec(WWII_spawninterface);
schedule("restartSFX();", 3);
centerprint(testsubject(), "<jc><f2>MISSION ACCOMPLISHED!!", 3, MISSION_ACCOMPLISHED);
schedule("vote::changemission(); server::loadmission(WWII_thearena, 1);", 5.1);


}

function disableweaponry()
{
%cl = testsubject();
player::setitemcount(%cl, priweapclip, 0);
player::setitemcount(%cl, secweapclip, 0);
player::unmountitem(%cl, $weaponslot);
}

deletevariables("stairsdown*");

function observershake(%cl, %pos)
{
%add = 2.5;
%g = 1;
for(%x = 1; %x < 10; %x += 0.25)
	{
	%g *= -1;
	%pos = vector::add(%pos, %g*%add/(%x*%x) @ " 0 0");
	%rot = vector::add(vector::getrotation("0 0 -1"), "1.57079 0 0");
	schedule("Observer::setFlyMode("@ %cl @ ",\"" @ %pos @ "\",\"" @ %rot @ "\", false, false);", %x/4);
	}
}

function stairfall(%num)
{
if($stairsdowndfg[%num]) return;
%cl = testsubject();
%pl = client::Getownedobject(%cl);
if(%num == 1)
	{
	%group = "Missiongroup\\camera";
	%pos = gamebase::Getposition(group::getobject(%group, 0));
	%rot = vector::add(vector::getrotation("0 0 -1"), "1.57079 0 0");
	client::setcontrolObject(%cl, client::getobserverCamera(%cl));
	Observer::setFlyMode(%cl, %pos, %rot, false, false);
	Observershake(%cl, %pos);
	schedule("if(!player::isDead(" @ %pl @ ")) client::setcontrolobject(testsubject()," @ %pl @ ");", 2.5);
	}
%group = "Missiongroup/Hugestairs/a" @ %num;
schedule("animate(\"" @ %group @ "\");", 0.5);
if(%num != 2) messageall(1, "~wbxplo1.wav");
WWII::ScreenShake(%pl, 0.2);
$stairsdowndfg[%num] = 1;
if(%num == 2) schedule("boom(3);", 11.5);
if(%num == 1) schedule("stairfall(2);stairfall(3);", 10);
if(%num == 3) schedule("stairfall(4);stairfall(5);", 17.5);
if(%num == 5) schedule("stairfall(6);stairfall(7);", 14);
schedule("checkloseXb();", 5);
}

function checkloseXa()
{
%cl = testsubject();
if(getword(gamebase::getposition(%cl), 2) < 55) gameover();
}

function checkloseXb()
{
%cl = testsubject();
if(getword(gamebase::getposition(%cl), 2) < 70) gameover();
}

function game::spawninterface(%cl)
{
if(%cl == testsubject()) gameover();
}

function restartSFX()
{
schedule("focusclient(); sfxclose();", 0.1);
schedule("focusclient(); sfxopen();", 0.2);
}

function gameover()
{
exec(game);
exec(ai);
exec(WWII_menu);
exec(WWII_spawninterface);
centerprint(testsubject(), "<jc><f2>MISSION FAILED!!", 2, MISSION_ACCOMPLISHED);
schedule("vote::changemission(); server::loadmission(WWII_thearena, 1);", 2.1);
schedule("restartSFX();", 1);
}

function boom(%num)
{
%group = "MissionGroup\\boom" @ %num;
%mine = group::getobject(%group, 1);
%marker = group::getobject(%group, 0);
if(%mine < 1) return;
WWII::ScreenShake(TESTSUBJECT(), 0.2);
gamebase::setposition(%mine, getboxcenter(%marker));
aimine::oncollision(%mine, 2048);
deleteobject(%mine);
}

if($testing != 1) spawnfirstdudes();

function AI::onTargetLOSAcquired(%aiName, %idNum)
{
if(%aiName == "stairbot1" || %aiName == "stairbot2") 
	{
	$simgame::timescale = 0.333;
	schedule("$Simgame::timescale = 1;", 3);
	}
%idnum.lastai = AI::getId(%ainame);
//if($SmartBotOn) $Ai::Int[%aiName] = "Enemy spotted: " @ %idnum;
}
function AI::onTargetLOSRegained(%aiName, %idNum)
{
if(%aiName == "stairbot1" || %aiName == "stairbot2") 
	{
	$simgame::timescale = 0.333;
	schedule("$Simgame::timescale = 1;", 3);
	}
//if($SmartBotOn) $Ai::Int[%aiName] = "Enemy spotted again: " @ %idnum;
}
