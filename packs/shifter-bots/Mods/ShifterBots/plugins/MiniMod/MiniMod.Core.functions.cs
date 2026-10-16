// This file contains MiniMod's brain so to speak.
// Its been made to load as a plugin since the release of MiniMod v.06
// This consept allows for much easier upgrading to users of 
// MiniMod v.06 or later. :)

echo("MiniMod: Loading core functions...");

$ItemFavoritesKey = "MiniMod v.07";
$DisplayLoadouts = false;
$DisplayDamageRatings = false;

function MiniMod::Include::Class() // This is called from all *.ArmorClass.cs files
{
if($ItemClass == $ArmorClass) {
	$ItemMax[$Armor, $Item] = $qty;
	if($DisplayLoadouts == true) {
		echo("Capacities for... ", $Armor, "  Item allowed to carry is, ", $Item, "  Quantity Allowed,", $qty);
		}
	}
if($DamageClass == $ArmorClass) { // Here we're setting DamageScale for vehicles and armors.
	$DamageScale[$Armor, $WeaponDamageType] = $value;
	if($DisplayDamageRatings == true) {
		echo("Damage rating for... ", $Armor, " has a DamageFactor of ", $value, " from ", $Item, ".");
		}
	}
}
function MiniMod::kick(%ShitListed, %reason)  //(%clientId, %ShitListed, %reason)
{
Net::kick($clientId, %reason);
}

function MiniMod::ShitList(%ShitListed, %reason)
{
   if($player == %ShitListed){
	$ShitListed = %ShitListed;
	$reason = %reason;
	}
}

function MiniMod::Load::ArmorClasses()
{
    deleteVariables("$mmGetArmor*");
    %i = 0;
    %file = File::findFirst("plugins\\*.ArmorClass.cs");  // find the first one
    while(%file != "")                                      // keep it up till they are all found
    {
        %unique = true;
        for(%b = 0; (%b < %i) && %unique; %b++) // this all seems unnecessary, but it is needed
        {                                       // otherwise, the same file may be found multiple times
            if($mmGetArmor[%b] == %file)        // timing issue maybe? I dunno.
                %unique = false;
        }
        if(%unique)
        {
            $mmGetArmor[%i] = %file;            // build an array of the filenames
            %i++;                               // increment our count
        }
        %file = File::findNext("plugins\\*.ArmorClass.cs"); // find the next one
    }

    for(%b = 0; %b < %i; %b++) // exec them all
        exec($mmGetArmor[%b]);
    $mmGetArmorSize = %i;
}

function MiniMod::Build::Classes()
{
MiniMod::Load::ArmorClasses();
if($ItemClass == $ArmorClass) {
	$ItemMax[$Armor, $Item] = $qty;
	}
if($DamageClass == $ArmorClass) { // Here we're setting DamageScale for vehicles and armors.
	$DamageScale[$Armor, $WeaponDamageType] = $value;
	}
}

function MiniMod::Build::Damage::Classes()
{
if($DamageClass == $ArmorClass) {
	$DamageScale[$Armor, $WeaponDamageType] = $value;
	}
}



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

function MiniMod::Init::Client()
{
MiniMod::Load("plugins\\*.Darkstar.Strings.cs");
MiniMod::Load("plugins\\*.Editor.Strings.cs");
MiniMod::Load("plugins\\*.CommonEditor.Strings.cs");
MiniMod::Load("plugins\\*.Esf.Strings.cs");
MiniMod::Load("plugins\\*.Fear.Strings.cs");
MiniMod::Load("plugins\\*.Help.Strings.cs");
MiniMod::Load("plugins\\*.Sfx.Strings.cs");
MiniMod::Load("plugins\\*.BanList.cs");
MiniMod::Load("plugins\\*.MissionList.cs");
MiniMod::Load("plugins\\*.Gui.cs");
MiniMod::Load("plugins\\*.Sae.cs");
MiniMod::Load("plugins\\*.Client.cs");
MiniMod::Load("plugins\\*.Server.cs");
MiniMod::Load("plugins\\*.TsDefaultMatProps.cs");
MiniMod::Load("plugins\\*.Game.cs");
MiniMod::Load("plugins\\*.GenericTriggers.cs");
MiniMod::Load("plugins\\*.Comchat.cs");
MiniMod::Load("plugins\\*.ChatMenu.cs");
MiniMod::Load("plugins\\*.Menu.cs");
MiniMod::Load("plugins\\*.Observer.cs");
MiniMod::Load("plugins\\*.PlayerSetup.cs");
MiniMod::Load("plugins\\*.Players.cs");
MiniMod::Load("plugins\\*.IRCClient.cs");
MiniMod::Load("plugins\\*.IRCServers.cs");
MiniMod::Load("plugins\\*.Options.cs");
MiniMod::Load("plugins\\*.Commander.cs");
MiniMod::Load("plugins\\*.Mod.cs");
MiniMod::Load("plugins\\*.ClientDefaults.cs");
MiniMod::Load("plugins\\*.ServerDefaults.cs");
MiniMod::Load("plugins\\*.ClientPrefs.cs");
MiniMod::Load("plugins\\*.ServerPrefs.cs");
MiniMod::Load("plugins\\*.Config.cs");
MiniMod::Load("plugins\\*.BadWords.cs");
MiniMod::Load("plugins\\*.AutoExec.cs");
MiniMod::Load("plugins\\*.Sound.cs");
MiniMod::Load("plugins\\*.Move.cs");
}


function MiniMod::Init::Server()
{
MiniMod::Load("plugins\\*.Plugin.Functions.cs");
MiniMod::Load("plugins\\*.Admin.cs");
MiniMod::Load("plugins\\*.Marker.cs");
MiniMod::Load("plugins\\*.Trigger.cs");
MiniMod::Load("plugins\\*.NSound.cs");
MiniMod::Load("plugins\\*.BaseExpData.cs");
MiniMod::Load("plugins\\*.BaseDebrisData.cs");
MiniMod::Load("plugins\\*.BaseProjData.cs");
MiniMod::Load("plugins\\*.ArmorData.cs");
MiniMod::Load("plugins\\*.ItemClass.cs");
MiniMod::Load("plugins\\*.Mission.cs");
MiniMod::Load("plugins\\*.Item.cs");
MiniMod::Load("plugins\\*.Player.cs");
MiniMod::Load("plugins\\*.Vehicle.cs");
MiniMod::Load("plugins\\*.Turret.cs");
MiniMod::Load("plugins\\*.StaticShape.cs");
MiniMod::Load("plugins\\*.Resupply.Update.cs");
MiniMod::Load("plugins\\*.Station.cs");
MiniMod::Load("plugins\\*.Moveable.cs");
MiniMod::Load("plugins\\*.Sensor.cs");
MiniMod::Load("plugins\\*.Mine.cs");
MiniMod::Load("plugins\\*.ChatMenu.cs");
MiniMod::Load("plugins\\*.AI.cs");
MiniMod::Load("plugins\\*.InteriorLight.cs");
MiniMod::Load("plugins\\*.Server.Functions.cs");
}

function MiniMod::Init::Mission()
{
MiniMod::Load("plugins\\*.ReinitData.Functions.cs");
MiniMod::Load("plugins\\*.ReinitData.cs");
MiniMod::Load("plugins\\*.Objectives.cs");
MiniMod::Load("plugins\\*.Game.cs");
MiniMod::Load("plugins\\*.Comchat.cs");
}