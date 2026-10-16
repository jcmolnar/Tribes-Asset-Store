// This file contains MiniMod's brain so to speak.
// Its been made to load as a plugin since the release of MiniMod v.06
// This consept allows for much easier upgrading to users of 
// MiniMod v.06 or later. :)

echo("MiniMod: Loading core functions...");

//$DisplayLoadouts = true;
//$DisplayDamageRatings = true;

MiniMod::Load("MiniMod.Prefs.cs");
function MiniMod::MonitorFile(%state, %file, %title)
{
	if(%state == start || begin)
	{
		if(%title != "")
		{
			$tempTitle = %title;
			%tempFile = %file;
			$CF::File = %file;
			$CF::PluginTitle = %title;
		}
	}
	if(%state == stop || end)
	{
		if($tempTitle == %title)
		{
			$CF::File = "";
			$CF::PluginTitle = "";
		}
	}
}

function MiniMod::BadFileAlarm(%clientId)
{
	if($MiniMod::MonitorErrors == True)
	{
		if($CF::File != "")
		{
			Client::sendMessage(%clientId,0,"~wC_BuySell.wav");
			Client::sendMessage(%clientId,0, "Error detected in: "@$CF::File@"", %clientId);
		}
		if($CF::PluginTitle != "")
		{
			Client::sendMessage(%clientId,0,"~wC_BuySell.wav");
			Client::sendMessage(%clientId,0, "The plugin's Title is: "@$CF::PluginTitle@"", %clientId);
		}
	}
}

$ItemFavoritesKey = "MiniMod v.07";
MiniMod::Load("plugins\\*.Prefs.cs");
//$DisplayLoadouts = true;
//$DisplayDamageRatings = true;

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

function MiniMod::Turbo::Class(%item, %class, %qty) // The Fast Method (Info stored here.)
{
	if(%qty == ""){%qty = 1;}
	if(%class == ""){%class = 0;}
	if(%item == ""){echo("Invalid Arguments:");echo("MiniMod::Turbo::Class(Item, <Class>, <Quantity>)");}
// class 0  = general stuff (ie. repair kits, flares, anything that most armors should carry.)
	if(%class == 0){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[tarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[scvarmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[jarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 1  = recon stuff
	if(%class == 1){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 2  = sniper stuff (weapons and ammo)
	if(%class == 2){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 3  = protective stuff (ie. shields, etc.)
	if(%class == 3){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 4  = light weapons
	if(%class == 4){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[tarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 5  = medium weapons
	if(%class == 5){
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
	}
// class 6  = heavy weapons
	if(%class == 6){
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
	}
// class 7  = assault weapons
	if(%class == 7){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[tarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[scvarmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[jarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 8  = defence weapons
	if(%class == 8){
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
	}
// class 9  = light deployables
	if(%class == 9){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 10 = medium deployables
	if(%class == 10){
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
	}
// class 11 = heavy deployables (ie. big sensors)
	if(%class == 11){
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
	}
// class 12 = heavy defence deployabes (ie. big turrets)
	if(%class == 12){
		$ItemMax[harmor, %item] = %qty;
	}
// class 13 = special deployables (ie. air bases, etc.)[Engineer stuff]
	if(%class == 13){
		$ItemMax[earmor, %item] = %qty;
	}
// class 14 = support stuff (ie. Inv. Stat's, Ammo Stat's, bulk ammo, etc.)
	if(%class == 14){
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
	}
// class 15 = repair stuff (ie. repair packs, etc.)
	if(%class == 15){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[tarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 16 = sensor stuff
	if(%class == 16){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 17 = heavy-duty sensor stuff
	if(%class == 17){
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
	}
// class 18 = general packs
	if(%class == 18){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[harmor, %item] = %qty;
		$ItemMax[darmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[dmarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 19 = special packs (you may wish to manually set these, instead)

// class 20 = command packs (ie. command PDA)
	if(%class == 20){
		$ItemMax[earmor, %item] = %qty;
	}
// class 21 = vehicle packs
	if(%class == 21){
		$ItemMax[larmor, %item] = %qty;
	}
// class 22 = sniper   armor specific
	if(%class == 22){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[sarmor, %item] = %qty;
		$ItemMax[secrarmor, %item] = %qty;
		$ItemMax[specarmor, %item] = %qty;
		$ItemMax[spyarmor, %item] = %qty;
		$ItemMax[stimarmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
		$ItemMax[sfemale, %item] = %qty;
		$ItemMax[spyfemale, %item] = %qty;
		$ItemMax[stimfemale, %item] = %qty;
	}
// class 23 = flight   armor specific
	if(%class == 23){
		$ItemMax[specarmor, %item] = %qty;
	}
// class 24 = engineer armor specific
	if(%class == 24){
		$ItemMax[earmor, %item] = %qty;
		$ItemMax[efemale, %item] = %qty;
	}
// class 25 = burster  armor specific
	if(%class == 25){
		$ItemMax[barmor, %item] = %qty;
		$ItemMax[bfemale, %item] = %qty;
	}
// class 26 = arbitor  armor specific
	if(%class == 26){
		$ItemMax[aarmor, %item] = %qty;
		$ItemMax[afemale, %item] = %qty;
	}
// class 27 = medium   armor specific
	if(%class == 27){
		$ItemMax[marmor, %item] = %qty;
		$ItemMax[mfemale, %item] = %qty;
	}
// class 28 = dragoon  armor specific
	if(%class == 28){
		$ItemMax[darmor, %item] = %qty;
	}
// class 29 = heavy    armor specific
	if(%class == 29){
		$ItemMax[harmor, %item] = %qty;
	}
// class 30 = light    armor specific
	if(%class == 30){
		$ItemMax[larmor, %item] = %qty;
		$ItemMax[lfemale, %item] = %qty;
	}
}

function MiniMod::Load::ArmorClasses() // The Slow Method. (File scanning)
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
   if($ItemClass <= 30)
   {
	MiniMod::Turbo::Class($Item, $ItemClass, $qty);
	break;
   }
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
MiniMod::Load("plugins\\*.CodeFusion.cs");
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