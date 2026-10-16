function Game::SpawnInterface(%clientId)
{
if(getword(%clientId.menumode,0) != -1) return;
if(gamebase::Getteam(%clientId) != 0 && gamebase::Getteam(%clientId) != 1) return;
if(%clientId.choosingclass) { 
if(%clientId.lockspawnclass) { %clientId.choosingclass = false; Game::SpawnInterface(%clientId); return; } //FIX NEEDED
Client::buildMenu(%clientId, "Pick spawn class:", "chooseclass", true);
%x=0;
Client::addMenuItem(%clientId, %x++ @ "Scout(Sniper)", "scout");
Client::addMenuItem(%clientId, %x++ @ "Assault", "assault");
Client::addMenuItem(%clientId, %x++ @ "Assault2", "assault2");
Client::addMenuItem(%clientId, %x++ @ "Anti-Tank", "antitank");
if($country[gamebase::getteam(%clientId)] != German && $country[gamebase::getteam(%clientId)] != US) Client::addMenuItem(%clientId, %x++ @ "Anti-Tank2", "antitank2");
Client::addMenuItem(%clientId, %x++ @ "Medic", "medic");
Client::addMenuItem(%clientId, %x++ @ "Engineer", "engineer");
%clientId.choosingclass = false;
}
else {
%p = 1;
Client::buildMenu(%clientId, "Pick spawn Location:", "choosespawn");
Client::addMenuItem(%clientId, "0<--Back", "!back");
Client::addMenuItem(%clientId, %p++ @ "Main Base", "base");
for(%x = 1; NameToID("MissionGroup/Outpost" @ %x) != -1; %x++)
	{
	%group = NameToID("MissionGroup/Outpost" @ %x);
	if(GameBase::GetTeam(Group::GetObject(%group, 0)) == client::getteam(%clientId)) { 
	for(%y = 0; Group::GetObject(%group, %y) != -1; %y++)
		{
		%obj = Group::getObject(%group, %y);
		if(getword(Object::GetName(%obj), 0) == "Drop") 
			{
			Client::addMenuItem(%clientId, %p++ @ GameBase::GetMapName(group::getobject(%group, 0)), "Outpost" @ %x);
			break;
			}
		}
	} }
%clientId.choosingclass = true;
}

}


function m::ChooseClass(%clientId, %opt)
{
%x = getword(%opt, 0);
if((%x != "scout" && %x != "assault" && %x != "antitank" && %x != "antitank2" && %x != "medic" && %x != "engineer" && %x != "assault2") || (($country[1]!="German" && $country[1]!="Japan") && gamebase::getteam(%clientId) == 1)) schedule("net::kick(" @ %clientId @ ", \"Wrong menu item! reconnect..\"); messageall(2,\"Server: Menu Error!\");", 0);
%clientId.spawnclass = %x;
Game::SpawnInterface(%clientId);
}

function M::ChooseSpawn(%clientId, %opt)
{
if($Game::MissionType == "Deathmatch") return;
if(%opt == "!back") { %clientId.choosingclass = true; Game::SpawnInterface(%clientId); return; }
%client.observermode = "";
%y = sqrt(getnumclients()); 
centerprint(%clientId, "<jc><f1>You are being spawned on the battlefield...", 1.5,CLASS);
schedule("Game::playerSpawn(" @ %clientId @ ", false, " @ getword(%opt, 0) @ ");", 1.5);
}	

function WWII::PlayerSetup(%clientId, %country)
{
game::refreshclientscore(%clientId);
%clientId.trigger = 0;
%clientId.canmountguns = true;
%clientId.canchangeweapon = true;
%clientId.canthrownade = true;
%clientId.isreloading = false;
%clientId.canchangeweapon = true;
%x = %clientId.spawnclass;
%team = gamebase::getteam(%clientId);
player::setitemcount(%clientId, beacon, 1);
player::setitemcount(%clientId, Grenade, 1);
player::setitemcount(%clientId, mineammo, 1);
player::setitemcount(%clientId, targetinglaser, 1);
player::setitemcount(%clientId, repairkit, 1);

if(%x == "medic") {
	player::setitemcount(%clientId, medicalkit, 1);
	player::setitemcount(%clientId, medicalkitammo, 120);
	}


if(%country == "") %country = $country[%team];

WWII::GiveItem(%clientId, 4, %x, %country);	
WWII::GiveItem(%clientId, 3, %x, %country);	
WWII::GiveItem(%clientId, 2, %x, %country);
%mainweapon = $weapon[%x, %country];
Client::setSkin(%clientId, Game::getcustomskin(%clientId));
if(%x == "scout") 
	{ 
	if(%clientId.scoutspecial == "cactus") { client::getownedobject(%clientId).client = %clientId; %clientId.player = client::getownedobject(%clientId); player::mountitem(%clientid, cactuscamo, 2); }
	else if(%clientId.scoutspecial == "blackplant") { client::getownedobject(%clientId).client = %clientId; %clientId.player = client::getownedobject(%clientId); client::setskin(%clientId, cphoenix); player::mountitem(%clientid, plantcamo, 2); }
	else if(%clientId.scoutspecial == "greenskin") { client::getownedobject(%clientId).client = %clientId; %clientId.player = client::getownedobject(%clientId); client::setskin(%clientId, green); }
	}

Player::mountitem(%clientId, %mainweapon, $weaponslot); 
}

function WWII::GiveItem(%clientId, %slot, %class, %country)
{
if(%class == "scout") player::setitemcount(%clientId, Binoculars, 1);
//--------------------------------
if(%slot == 2)
	{
	if(%country != "German" && %country != "Japan")
		{
		player::setitemcount(%clientId, ypistol, 1);
		player::setitemcount(%clientId, $clip[ypistol], 3);
		player::setitemcount(%clientId, $ammo[ypistol], 12);
		}
	else
		{
		player::setitemcount(%clientId, xpistol, 1);
		player::setitemcount(%clientId, $clip[xpistol], 3);
		player::setitemcount(%clientId, $ammo[xpistol], 9);
		}
	}
//-------------------------------
else if(%slot == 3)
	{
	%weapon = $Weapon[%class, %country];
	player::setitemcount(%clientId, %weapon, 1);
	player::setitemcount(%clientId, $clip[%weapon], $numclips[%weapon]);
	player::Setitemcount(%clientId, $ammo[%weapon], $clipsize[%weapon]);
	}
//-------------------------------
else if(%slot == 4)
	{
	if(%class == "engineer") {
	player::setitemcount(%clientId, exppack, 1);
	player::setitemcount(%clientId, exppackammo, 4);
	player::setitemcount(%clientId, detonator, 1);
	player::setitemcount(%clientId, detonatorammo, 1);
	player::setitemcount(%clientId, DeployMine, 1);
	player::setitemcount(%clientId, DeployMineammo, 5);
	player::setitemcount(%clientId, DeployBox, 1);
	player::setitemcount(%clientId, DeployBoxammo, 1);
	
	}
	else { 
	player::setitemcount(%clientId, nade, 1);
	player::setitemcount(%clientId, nadeammo, 3);
	}
	if(%class == "scout" && gamebase::getTeam(%clientId) == 1) {
	player::setitemcount(%clientId, xgrifle, 1);
	player::setitemcount(%clientId, xgAmmo, 1);
	} 
	}
}

function WWII::SetWeaponslist(%list, %num)
{
%buffer = 0;
for(%x = 0; %x < %num; %x++)
	{
	%temp = getword(%list, %buffer) @ " " @  getword(%list, %buffer + 1) @ " " @ getword(%list, %buffer + 2) @ " " @ getword(%list, %buffer + 3) @ " ";
	if(getword(%list, %buffer) != -1) {
	%buffer = %buffer + 4;
	WWII::Givevalues(%temp);
	}}
}

function WWII::Givevalues(%text)
{
%weapon = getword(%text, 0);
%class = getword(%text, 1);
%country = getword(%text, 2);
%maxclips = getword(%text, 3);

$weapon[%class, %country] = %weapon;
$numclips[%weapon] = %maxclips;
}

//Weapon, class, country, maxclips

//==========================================================================
//============================EDITING WEAPON LIST===========================
WWII::setweaponslist("ylanchester assault2 British 3 yM3 assault2 US 3 yDP assault2 Russia 3 xar assault2 German 3 ysniperrifle scout US 15 ymosinnagant scout Russia 20 ysniperrifle scout British 15 xrifle scout German 15 ythompson assault US 3 yppsh assault Russia 2 ybar assault British 5 xstg assault German 3 ybazooka antitank US 9 ybazooka antitank Russia 9 ybazooka antitank British 9 xpanzergun antitank German 6 ysten medic US 3 ysubmgun medic Russia 3 ybren medic British 3 xmp40 medic German 3 ycarbine engineer US 5 ygarand engineer Russia 5 ysten engineer British 3 ysubmgun engineer German 3 yPTRD antitank2 Russia 12 yPIAT antitank2 British 9 xRifleJ scout Japan 15 xtype100 assault Japan 3 xtype96 assault2 Japan 3 xRocket antitank Japan 8 xType97 antitank2 Japan 2 xRifleJE engineer Japan 3 ysubmgun medic Japan 3 xShotgun engineer German 5", 39);
