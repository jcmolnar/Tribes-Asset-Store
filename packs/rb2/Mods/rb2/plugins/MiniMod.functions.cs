// This file contains MiniMod's brain so to speak.
// Its been made to load as a plugin since the release of MiniMod v.06
// This consept allows for much easier upgrading to users of 
// MiniMod v.06 or later. :)

echo("MiniMod: Loading core functions...");

function addPluginWeapon(%follows, %newweapon)
{
	%temp0 = $NextWeapon[%follows];
	$NextWeapon[%follows] = %newweapon;
	$NextWeapon[%newweapon] = %temp0;
	%temp1 = $PrevWeapon[%follows];
	$PrevWeapon[%follows] = %newweapon;
	$PrevWeapon[%newweapon] = %temp1;
}
// Calls to this function are made from the item.cs files of all
// weapons-based plugins that are MiniMod v.05 complient.


function MiniMod::WeaponCycle(%follows, %newweapon, %previous)
{
	%temp0 = $NextWeapon[%follows];
	$NextWeapon[%follows] = %newweapon;
	$NextWeapon[%newweapon] = %temp0;
	%temp1 = $PrevWeapon[%previous];
	$PrevWeapon[%previous] = %newweapon;
	$PrevWeapon[%newweapon] = %temp1;
}
// Calls to this function are made from the item.cs files of all
// weapons-based plugins that are MiniMod v.06 or later complient.

// If you enter " MiniMod::WeaponCycle(Blaster, FusionGun, PlasmaGun); " you'll get
// MiniMod to fit the "FusionGun" between the "Blaster" and the "PlasmaGun".
// NOTE: You MUST enter all 3 variables!!!!!! Or just use addPluginWeapon that is, if you
//  feel like entering just 2 variables and having a 'screwy' Weapon Cycle. :P


function MiniMod::Load::Admin()
{
%file = File::findFirst("plugins\\*.admin.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.admin.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::AI()
{
%file = File::findFirst("plugins\\*.AI.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.AI.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ArmorData()
{
%file = File::findFirst("plugins\\*.ArmorData.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.ArmorData.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::AutoExec()
{
%file = File::findFirst("plugins\\*.AutoExec.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.AutoExec.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::BadWords()
{
%file = File::findFirst("plugins\\*.BadWords.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.BadWords.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::BanList()
{
%file = File::findFirst("plugins\\*.BanList.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.BanList.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::BaseExpData()
{
%file = File::findFirst("plugins\\*.BaseExpData.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.BaseExpData.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::BaseDebrisData()
{
%file = File::findFirst("plugins\\*.BaseDebrisData.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.BaseDebrisData.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::BaseProjData()
{
%file = File::findFirst("plugins\\*.BaseProjData.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.BaseProjData.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Beacon()
{
%file = File::findFirst("plugins\\*.Beacon.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Beacon.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ChangeMission()
{
%file = File::findFirst("plugins\\*.changeMission.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.changeMission.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ChatMenu()
{
%file = File::findFirst("plugins\\*.chatmenu.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.chatmenu.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Client()
{
%file = File::findFirst("plugins\\*.client.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.client.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ClientDefaults()
{
%file = File::findFirst("plugins\\*.clientDefaults.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.clientDefaults.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ClientPrefs()
{
%file = File::findFirst("plugins\\*.ClientPrefs.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.ClientPrefs.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Comchat()
{
%file = File::findFirst("plugins\\*.comchat.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.comchat.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Commander()
{
%file = File::findFirst("plugins\\*.commander.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.commander.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::CommonEditor::Strings()
{
%file = File::findFirst("plugins\\*.commonEditor.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.commonEditor.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Config()
{
%file = File::findFirst("plugins\\*.Config.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Config.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Darkstar::Strings()
{
%file = File::findFirst("plugins\\*.darkstar.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.darkstar.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Desert()
{
%file = File::findFirst("plugins\\*.desert.terrain.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.desert.terrain.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::DM()
{
%file = File::findFirst("plugins\\*.dm.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.dm.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::EditMission()
{
%file = File::findFirst("plugins\\*.EditMission.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.EditMission.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Editor()
{
%file = File::findFirst("plugins\\*.editor.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.editor.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Editor::Strings()
{
%file = File::findFirst("plugins\\*.editor.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.editor.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::EditorConfig()
{
%file = File::findFirst("plugins\\*.editorconfig.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.editorconfig.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Esf::Strings()
{
%file = File::findFirst("plugins\\*.esf.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.esf.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Fear::Strings()
{
%file = File::findFirst("plugins\\*.fear.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.fear.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Game()
{
%file = File::findFirst("plugins\\*.game.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.game.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::GenericTriggers()
{
%file = File::findFirst("plugins\\*.GenericTriggers.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.GenericTriggers.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Gui()
{
%file = File::findFirst("plugins\\*.Gui.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Gui.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Help::Strings()
{
%file = File::findFirst("plugins\\*.help.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.help.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Ice()
{
%file = File::findFirst("plugins\\*.ice.terrain.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.ice.terrain.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::InteriorLight()
{
%file = File::findFirst("plugins\\*.interiorLight.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.interiorLight.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::IRCClient()
{
%file = File::findFirst("plugins\\*.IRCClient.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.IRCClient.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::IRCServers()
{
%file = File::findFirst("plugins\\*.IRCServers.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.IRCServers.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Item()
{
%file = File::findFirst("plugins\\*.item.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.item.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Keys()
{
%file = File::findFirst("plugins\\*.keys.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.keys.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::LoadShow()
{
%file = File::findFirst("plugins\\*.loadShow.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.loadShow.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Lush()
{
%file = File::findFirst("plugins\\*.lush.terrain.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.lush.terrain.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Marker()
{
%file = File::findFirst("plugins\\*.marker.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.marker.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Mars()
{
%file = File::findFirst("plugins\\*.mars.terrain.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.mars.terrain.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Med()
{
%file = File::findFirst("plugins\\*.med.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.med.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Menu()
{
%file = File::findFirst("plugins\\*.menu.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.menu.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Mine()
{
%file = File::findFirst("plugins\\*.Mine.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Mine.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Mission()
{
%file = File::findFirst("plugins\\*.mission.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.mission.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::MissionList()
{
%file = File::findFirst("plugins\\*.missionList.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.missionList.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::MissionTypes()
{
%file = File::findFirst("plugins\\*.missiontypes.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.missiontypes.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Mod()
{
%file = File::findFirst("plugins\\*.Mod.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Mod.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Move()
{
%file = File::findFirst("plugins\\*.move.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.move.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Moveable()
{
%file = File::findFirst("plugins\\*.moveable.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.moveable.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Mud()
{
%file = File::findFirst("plugins\\*.mud.terrain.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.mud.terrain.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::NewMission()
{
%file = File::findFirst("plugins\\*.newMission.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.newMission.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Nsound()
{
%file = File::findFirst("plugins\\*.nsound.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.nsound.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Objectives()
{
%file = File::findFirst("plugins\\*.objectives.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.objectives.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Observer()
{
%file = File::findFirst("plugins\\*.observer.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.objectives.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Options()
{
%file = File::findFirst("plugins\\*.Options.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Options.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Player()
{
%file = File::findFirst("plugins\\*.player.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.player.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Players()
{
%file = File::findFirst("plugins\\*.players.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.players.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::PlayerSetup()
{
%file = File::findFirst("plugins\\*.PlayerSetup.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.PlayerSetup.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::RegisterObjects()
{
%file = File::findFirst("plugins\\*.RegisterObjects.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.RegisterObjects.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ReinitData()
{
MiniMod::Load::Objectives();
MiniMod::Load::Game();
MiniMod::Load::Comchat();
%file = File::findFirst("plugins\\*.reinitData.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.reinitData.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::RegisterVolume()
{
%file = File::findFirst("plugins\\*.registervolume.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.registervolume.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Sae()
{
%file = File::findFirst("plugins\\*.sae.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.sae.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Sensor()
{
%file = File::findFirst("plugins\\*.sensor.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.sensor.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Server()
{
%file = File::findFirst("plugins\\*.server.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.server.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ServerDefaults()
{
%file = File::findFirst("plugins\\*.serverDefaults.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.serverDefaults.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::ServerPrefs()
{
%file = File::findFirst("plugins\\*.ServerPrefs.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.ServerPrefs.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Sfx::Strings()
{
%file = File::findFirst("plugins\\*.sfx.strings.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.sfx.strings.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Sound()
{
%file = File::findFirst("plugins\\*.sound.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.sound.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::StaticShape()
{
%file = File::findFirst("plugins\\*.staticshape.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.staticshape.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Station()
{
%file = File::findFirst("plugins\\*.station.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.station.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Tag()
{
%file = File::findFirst("plugins\\*.tag.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.tag.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Ted()
{
%file = File::findFirst("plugins\\*.ted.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.ted.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Terrains()
{
%file = File::findFirst("plugins\\*.terrains.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.terrains.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::AI()
{
%file = File::findFirst("plugins\\*.Training_AI.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_AI.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Commander()
{
%file = File::findFirst("plugins\\*.Training_Commander.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Commander.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::CTF()
{
%file = File::findFirst("plugins\\*.Training_CTF.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_CTF.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::DefendDestroy()
{
%file = File::findFirst("plugins\\*.Training_Defend_Destroy.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Defend_Destroy.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Retrieval()
{
%file = File::findFirst("plugins\\*.Training_Retrieval.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Retrieval.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Towers()
{
%file = File::findFirst("plugins\\*.Training_Towers.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Towers.cs.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Vehicles()
{
%file = File::findFirst("plugins\\*.Training_Vehicles.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Vehicles.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Weapons()
{
%file = File::findFirst("plugins\\*.Training_Weapons.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Weapons.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Training::Welcome()
{
%file = File::findFirst("plugins\\*.Training_Welcome.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.Training_Welcome.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Trees()
{
%file = File::findFirst("plugins\\*.trees.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.trees.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Trigger()
{
%file = File::findFirst("plugins\\*.trigger.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.trigger.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::TsDefaultMatProps()
{
%file = File::findFirst("plugins\\*.tsDefaultMatProps.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.tsDefaultMatProps.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Turret()
{
%file = File::findFirst("plugins\\*.turret.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.turret.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Vehicle()
{
%file = File::findFirst("plugins\\*.vehicle.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.vehicle.cs"))
exec(%file);
%i++;
}

function MiniMod::Load::Worlds()
{
%file = File::findFirst("plugins\\*.worlds.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.worlds.cs"))
exec(%file);
%i++;
}

function MiniMod::Init::Client()
{
MiniMod::Load::Darkstar::Strings();
MiniMod::Load::Editor::Strings();
MiniMod::Load::CommonEditor::Strings();
MiniMod::Load::Esf::Strings();
MiniMod::Load::Fear::Strings();
MiniMod::Load::Help::Strings();
MiniMod::Load::Sfx::Strings();
MiniMod::Load::BanList();
MiniMod::Load::MissionList();
MiniMod::Load::Gui();
MiniMod::Load::Sae();
MiniMod::Load::Client();
MiniMod::Load::Server();
MiniMod::Load::TsDefaultMatProps();
MiniMod::Load::Game();     	// Called from "MiniMod::Load::RenitData" also.
MiniMod::Load::GenericTriggers();
MiniMod::Load::Comchat();  	// Called from "MiniMod::Load::RenitData" also.
MiniMod::Load::ChatMenu();
MiniMod::Load::Menu();
MiniMod::Load::Observer();
MiniMod::Load::PlayerSetup();
MiniMod::Load::Players();
MiniMod::Load::IRCClient();
MiniMod::Load::IRCServers();
MiniMod::Load::Options();
MiniMod::Load::Commander();
MiniMod::Load::Mod();         	// Used for files like "Ideal.cs" (After being renamed to Ideal.mod.cs)
MiniMod::Load::ClientDefaults();
MiniMod::Load::ServerDefaults();
MiniMod::Load::ClientPrefs();
MiniMod::Load::ServerPrefs();
MiniMod::Load::Config();
MiniMod::Load::BadWords();
MiniMod::Load::AutoExec();
MiniMod::Load::Sound();
MiniMod::Load::Move();
}


function MiniMod::Init::Server()
{
MiniMod::Load::Admin();
MiniMod::Load::Marker();
MiniMod::Load::Trigger();
MiniMod::Load::NSound();
MiniMod::Load::BaseExpData();
MiniMod::Load::BaseDebrisData();
MiniMod::Load::BaseProjData();
MiniMod::Load::ArmorData();
MiniMod::Load::Mission();
MiniMod::Load::Item();
MiniMod::Load::Player();
MiniMod::Load::Vehicle();
MiniMod::Load::Turret();
MiniMod::Load::StaticShape();
MiniMod::Load::Station();
MiniMod::Load::Moveable();
MiniMod::Load::Sensor();
MiniMod::Load::Mine();
MiniMod::Load::ChatMenu();
MiniMod::Load::AI();
MiniMod::Load::InteriorLight();
}
