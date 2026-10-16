// Help.cs 
// To give helpful messages about item use when a player buys them at an inventory station and vehicle station

// Servers change this to false to disable help msg's

$GiveHelp = true;

// Strings to display

$helpstr[airmineammo] = "Airmines appear in your position when thrown. In a minelayerpack, a player can quickly set up an air minefield.";
$helpstr[flagmineammo] = "Flag mines look the same as your teams flag, and do not blowup for your teammates.";

$helpstr[flagarmor] = "Use the flagmover armor to move your flag to a deployable flagstand.";
$helpstr[sensorarmor] = "Sensor armors can carry 5 sensor deployables, and can control all items without a command station.";
$helpstr[Medicarmor] = "Medics can carry 5 repair kits, and repair items and players 50% faster than normal.";

$helpstr[mineLayerPack] = "The mine layer pack holds 10 air or regular mines.";
$helpstr[repairmakerpack] = "The repair kit maker creates a repair kit, it can be thrown to teammates because it throws the kit out in front of the user. One kit is made for half of the players energy.";
$helpstr[cloakpack] = "The cloaking pack turns you invisible. Your triangle will still show up, unless you take out the enemy sensors.";
$helpstr[heatsinkpack]="The heat sink pack makes you invisible to automated rocket turrets.";

$helpstr[flagstandpack] = "The flag stand can hold a flag brought by a flagmover armor, or an enemy flag brought by any armor. Since you cannot place walls and force fields close to the flag, setup an area first and then move your flag there.";
$helpstr[deployablewallpack] = "Walls can have motion sensors, cameras, and laser turrets on them.";
$helpstr[airplatformpack] = "Fly up and hit use to deploy. Deployable stations, turrets, sensors, walls, and force fields can be deployed on air platforms. A good use is deploying very high up so that they cant be seen well from the ground.";
$helpstr[largeairplatpack] = "Fly up and hit use to deploy. Deployable stations, turrets, sensors, walls, and force fields can be deployed on air platforms. Create remote floating bases anywhere.";
$helpstr[satcamerapack] = "Fly up and hit use pack to deploy. Satellite cameras can fill in blind spots on your sensor map, since pulse sensors are line of sight";

$helpstr[laserturretpack] = "Laser turrets have a short range and long reload time. Only 1 in the same area as 2 normal turrets. They can also be remotely controlled by a Sensor Armor or from a command station for remote sniping.";
$helpstr[rocketturretpack] = "Deployable rocket turrets have shorter range than normal ones, and are more easily destroyed.";
$helpstr[smallelfpack] = "Deployable elf turrets have shorter range than normal ones, and are more easily destroyed.";

$helpstr[dogfightervehicle] = "Dogfighters have more control and speed than scouts, but are very vulnerable to chaingun damage.";
$helpstr[quicklpcvehicle] = "The Quick LPC accelerates slowly, but has the top speed of a scout. Health is traded for speed, and 2 laser hits will destroy it.";

//

function giveHelp(%client,%item)
{ 
	if(!$GiveHelp)
		return;	
	bottomprint(%client, $helpstr[%item], 10);
}