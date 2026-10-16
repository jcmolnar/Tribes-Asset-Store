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
exec("StaticStationAmmo.cs");
exec("StaticStationCommand.cs");
exec("StaticStationInventory.cs");
exec("StaticStationVehicle.cs");

// Turrets
exec("StaticTurretELF.cs");
exec("StaticTurretIndoor.cs");
exec("StaticTurretMortar.cs");
exec("StaticTurretPlasma.cs");
exec("StaticTurretRocket.cs");

// Sensors
exec("StaticSensorPulseLarge.cs");
exec("StaticSensorPulseMedium.cs");


//------------------------------------------------------------
// Items available through stations (arranged by category):
//------------------------------------------------------------
// Armour:
//--------------------------------------
exec("ArmourLight.cs");
exec("ArmourMedium.cs");
exec("ArmourHeavy.cs");

// Weapons:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts.
exec("WeaponBlaster.cs");
exec("WeaponChainGun.cs");
exec("WeaponPlasmaGun.cs");
exec("WeaponKnife.cs");
exec("WeaponGrenadeLauncher.cs");
exec("WeaponMortar.cs");
//PORT-OFF: exec("WeaponTankGun.cs");
exec("WeaponDiscLauncher.cs");
exec("WeaponLaserRifle.cs");
exec("WeaponTargetingLaser.cs");

// Backpacks:
//--------------------------------------
//exec("PackEnergy.cs");
exec("PackRepair.cs");
//PORT-OFF: exec("PackAmmo.cs");
exec("PackParachute.cs");

// Deployables:
//--------------------------------------
exec("DeployableTurretCamera.cs");
exec("DeployableTurret.cs");

// Miscellany:
//--------------------------------------
exec("MiscRepairKit.cs");
exec("MiscMine.cs");
exec("MiscGrenade.cs");
exec("MiscSmokeGrenade.cs");
exec("MiscBeacon.cs");
exec("MiscSandBag.cs");
exec("MiscMinen.cs");
exec("RifleClip.cs");
exec("SMGClip.cs");
exec("SniperClip.cs");
exec("MGClip.cs");
exec("HandgunClip.cs");
exec("RocketClip.cs");

// Ammo:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts. This
// is just here as a guide to where you should place the data
// if a seperate ammo script is required.


// Vehicles:
//--------------------------------------
exec("VehicleScout.cs");
exec("VehicleLAPC.cs");
exec("VehicleHAPC.cs");

