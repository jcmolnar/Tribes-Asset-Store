//--------------------------------------------------------------------
// Foundation mod custom server script - by Nicodemus - 30.05.2000
//--------------------------------------------------------------------
//
//------------------------------------------------------------
// Notes on adding new items:
//------------------------------------------------------------
//
// 1. Be aware that the order in which you load items in
// here has a direct effect on the order in which they will
// appear in the stations. You can rearrange the order as
// you prefer, but I'd suggest you don't stray too far from
// the defaults. Also be aware that items will always go
// into their default categories. For example: you couldn't
// have the Blaster showing up under 'Armours'.
//
// 2. Be sure to complete the exec command including the ""
// (quotes) & .cs extension. This is really only necessary
// if you place the script in a subdirectory as all the
// default items are in this mod.
//
// 3. All script names are appropriate to the data they
// contain. When deciding on a name for a new item you
// should break it down by category, most general first.
//
// e.g. StaticSensorPulseMedium.cs 
//
// Static: Because it's present at the start of the game,
// and doesn't move during the game.
// Sensor: It's a sensor, dummy!
// Pulse: It's a pulse sensor, not a motion sensor.
// Medium: It's a medium sized item.
//
// You should be able to figure out the rest. :)
//
// Follow these simple rules, and it'll make your life a
// whole lot easier when trying to track down a single script
// file mixed in amongst hundreds.
//
//------------------------------------------------------------
//
//------------------------------------------------------------
// Static items (anything pre-deployed in a map):
//------------------------------------------------------------
// Stations
exec("stations\\StaticAmmo.cs");
exec("stations\\StaticCommand.cs");
exec("stations\\StaticInventory.cs");
exec("stations\\StaticVehicle.cs");

// Turrets
exec("turrets\\StaticELF.cs");
exec("turrets\\StaticIndoor.cs");
exec("turrets\\StaticMortar.cs");
exec("turrets\\StaticPlasma.cs");
exec("turrets\\StaticRocket.cs");

// Sensors
exec("sensors\\StaticPulseLarge.cs");
exec("sensors\\StaticPulseMedium.cs");


//------------------------------------------------------------
// Items available through stations (arranged by category):
//------------------------------------------------------------
//--------------------------------------
// Armour:
//--------------------------------------
exec("armours\\Light.cs");
exec("armours\\Medium.cs");
exec("armours\\Heavy.cs");

// Weapons:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts.
//Modules called here to prevent error with weapon modes
exec("weapons\\Blaster.cs");
exec("weapons\\ChainGun.cs");
exec("weapons\\PlasmaGun.cs");
exec("weapons\\GrenadeLauncher.cs");
exec("weapons\\Mortar.cs");
exec("weapons\\DiscLauncher.cs");
exec("weapons\\LaserRifle.cs");
exec("weapons\\EnergyRifle.cs");
exec("weapons\\TargetingLaser.cs");

// Backpacks:
//--------------------------------------
exec("packs\\Energy.cs");
exec("packs\\Ammo.cs");
exec("packs\\Repair.cs");
exec("packs\\Shield.cs");
exec("packs\\SensorJammer.cs");

// Deployables:
//--------------------------------------
exec("deployables\\StationInventory.cs");
exec("deployables\\StationAmmo.cs");
exec("deployables\\SensorMotion.cs");
exec("deployables\\SensorPulse.cs");
exec("deployables\\SensorJammer.cs");
exec("deployables\\TurretCamera.cs");
exec("deployables\\Turret.cs");

// Miscellany:
//--------------------------------------
exec("miscellany\\RepairKit.cs");
exec("miscellany\\Mine.cs");
exec("miscellany\\Grenade.cs");
exec("miscellany\\Beacon.cs");

// Ammo:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts. This
// is just here as a guide to where you should place the data
// if a seperate ammo script is required.


// Vehicles:
//--------------------------------------
exec("vehicles\\Scout.cs");
exec("vehicles\\LAPC.cs");
exec("vehicles\\HAPC.cs");

setSellDependants();
