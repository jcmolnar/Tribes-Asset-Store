function Blaster::onUse(%player,%item)
{
    %playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.Blaster == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.3 seconds\n<f0>Current Setting: [1/3] <f2>Regular", $DisplayTime);
	else if(%playerId.Blaster == 1)
    bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.3 seconds\n<f0>Current Setting: [2/3] <f2>Multi Blast", $DisplayTime);
    else if(%playerId.Blaster == 2)
    bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.3 seconds\n<f0>Current Setting: [3/3] <f2>Blue Blast", $DisplayTime);
}

function DisruptorGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.157\nFire Rate: 0.25 seconds", $DisplayTime);
}

function IonCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.255\nFire Rate: 0.65 seconds", $DisplayTime);
}

function OmegaRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Special Ablity: Drains target's health and transfers to your health\nTransfer rate Rate: 0.1 health per second", $DisplayTime);
}

function VertigoCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>Guided Energy Projectile gun\n<f0>Damage per shot: 0.15\nFire Rate: 0.8 seconds\nSpecial Ability: Rocket Launcher designed specifically against Blastech armor.", $DisplayTime);
}

//function MBCannon::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.5\nFire Rate: 1.25 seconds", $DisplayTime);
//}

function MBCannon::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.Cannon == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [1/12] <f2>Standard", $DisplayTime);
	else if(%playerId.Cannon == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [2/12] <f2>EMP", $DisplayTime);
	else if(%playerId.Cannon == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [3/12] <f2>Booster", $DisplayTime);
    else if(%playerId.Cannon == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [4/12] <f2>Booster X2", $DisplayTime);
    else if(%playerId.Cannon == 4)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [5/12] <f2>Poisoning", $DisplayTime);
	else if(%playerId.Cannon == 5)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [6/12] <f2>Heat", $DisplayTime);
    else if(%playerId.Cannon == 6)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [7/12] <f2>Blue Ray", $DisplayTime);
    else if(%playerId.Cannon == 7)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [8/12] <f2>Starburst", $DisplayTime);
    else if(%playerId.Cannon == 8)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [9/12] <f2>Annihilator", $DisplayTime);
    else if(%playerId.Cannon == 9)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [10/12] <f2>Swarmer Blast", $DisplayTime);
    else if(%playerId.Cannon == 10)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [11/12] <f2>Baby Nuke", $DisplayTime);
    else if(%playerId.Cannon == 11)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f0>Current Setting: [12/12] <f2>Large Nuke", $DisplayTime);
}

function Charger::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Electron Flux Cannon", $DisplayTime);
}

function EnergyGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.075\nFire Rate: 0.1 seconds", $DisplayTime);
}

//function Chaingun::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.11\nFire Rate: 0.2 seconds", $DisplayTime);
//}

function Chaingun::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.chaingun == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.2 seconds\n<f0>Current Setting: [1/2] <f2>Regular", $DisplayTime);
	else if(%playerId.chaingun == 1)
    bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.2 seconds\n<f0>Current Setting: [2/2] <f2>Gauss Bullet", $DisplayTime);
}

function GatB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.1\nFire Rate: 0.1 seconds", $DisplayTime);
}

function Gauss::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.25\nFire Rate: 0.2 seconds", $DisplayTime);
}

function MiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.075\nFire Rate: 0.05 seconds", $DisplayTime);
}

function MMiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.075\nFire Rate: 0.025 seconds", $DisplayTime);
}

//function GrenadeLauncher::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.4\nFire Rate: 1 second", $DisplayTime);
//}

function GrenadeLauncher::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.GrenadeLauncher == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1 second\n<f0>Current Setting: [1/3] <f2>Regular", $DisplayTime);
	else if(%playerId.GrenadeLauncher == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1 second\n<f0>Current Setting: [2/4] <f2>RPG", $DisplayTime);
	else if(%playerId.GrenadeLauncher == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1 second\n<f0>Current Setting: [3/4] <f2>Implosion Shell", $DisplayTime);
    else if(%playerId.GrenadeLauncher == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1 second\n<f0>Current Setting: [4/4] <f2>Multi Shell", $DisplayTime);
}
//function Mortar::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.0\nFire Rate: 2.5 seconds", $DisplayTime);
//}

function Mortar::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.Mortar == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [1/6] <f2>Regular", $DisplayTime);
	else if(%playerId.Mortar == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [2/6] <f2>Bouncing Betty HE", $DisplayTime);
	else if(%playerId.Mortar == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [3/6] <f2>Vertigo Bomb AB", $DisplayTime);
	else if(%playerId.Mortar == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [4/6] <f2>EMP Shell", $DisplayTime);
	else if(%playerId.Mortar == 4)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [5/6] <f2>Standard HE", $DisplayTime);
    else if(%playerId.Mortar == 5)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 2.5 seconds\n<f0>Current Setting: [6/6] <f2>Smoke Bomb Shell", $DisplayTime);
}

function DefendersRunGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.25\nFire Rate: 0.8 seconds", $DisplayTime);
}

function MineLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 1.5 seconds\nSpecial Ability: Deploys a set of 9 mines in a ''Box'' formation. These mines however are not team-friendly.", $DisplayTime);
}

function IMPGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 0.2 to 5.0\nFire Rate: 2.25 seconds", $DisplayTime);
}

function BabyNukeMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 5\nFire Rate: N/A", $DisplayTime);
}

//function DiscLauncher::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.5\nFire Rate: 1.75 seconds", $DisplayTime);
//}

function DiscLauncher::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.DiscLauncher == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.75 seconds\n<f0>Current Setting: [1/4] <f2>Regular", $DisplayTime);
	else if(%playerId.DiscLauncher == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.75 seconds\n<f0>Current Setting: [2/4] <f2>Power Disc", $DisplayTime);
	else if(%playerId.DiscLauncher == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.75 seconds\n<f0>Current Setting: [3/4] <f2>Power Disc Output 2x", $DisplayTime);
    else if(%playerId.DiscLauncher == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.75 seconds\n<f0>Current Setting: [4/4] <f2>Disc Shell Multi", $DisplayTime);
}

function TwinFusor::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.0\nFire Rate: 1.75 seconds", $DisplayTime);
}

function AODStinger::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 0.5 to 0.65\nFire Rate: 1.6 seconds\nSpecial Ability: When combined with a Missile Targeting Pack, the nearest enemy within 250m is programmed into the missile itself.", $DisplayTime);
}

function RPGLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>Rocket Propelled Grenade Launcher\n<f0>Damage per shot: 0.4\nFire Rate: 1.4 seconds", $DisplayTime);
}

function MRPGLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>MECH Super Hyper Blaster\n<f0>Damage per shot: 1.2\nFire Rate: 0.5 seconds", $DisplayTime);
}

function RPMLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>Rocket Propelled Mortar Launcher\n<f0>Damage per shot: 1.0\nFire Rate: 2.5 seconds", $DisplayTime);
}

function RPEMPLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>Rocket Propelled EMP Launcher\n<f0>Damage per shot: N/A\nFire Rate: 2.5 seconds\nSpecial Ability: EMP slowly drains your energy. When out of energy, it uses health.", $DisplayTime);
}

function MechRocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 1.0 - 1.3\nFire Rate: 2.0 seconds", $DisplayTime);
}

function LaserPistol::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.3\nFire Rate: 0.3 seconds", $DisplayTime);
}

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.6\nFire Rate: 0.3 seconds", $DisplayTime);
}

function MaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.5\nFire Rate: 1.5 seconds", $DisplayTime);
}

function LasCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 7.5\nFire Rate: N/A", $DisplayTime);
}

function Dartgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 1.5 seconds\nSpecial Ability: Poisons your target", $DisplayTime);
}

function Rifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
    if(%playerId.Rifle == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [1/4] <f2>Regular", $DisplayTime);
	else if(%playerId.Rifle == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [2/4] <f2>Explosive", $DisplayTime);
    else if(%playerId.Rifle == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [3/4] <f2>HP", $DisplayTime);
    else if(%playerId.Rifle == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [4/4] <f2>EMP", $DisplayTime);
}

function MassDriver::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.01\nFire Rate: 2 seconds", $DisplayTime);
}

function AAODSniperX::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.32\nFire Rate: 1.5 seconds\nSpecial Ability: The heavier the armor plating, the more damage this weapon does.", $DisplayTime);
}

function RailGun::onUse(%player,%item)
{
    Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.79\nFire Rate: 1.5 seconds.", $DisplayTime);
}

//function RailGun::onUse(%player,%item)
//{
//	%playerId = Player::getClient(%player);
//	Weapon::onUse(%player,%item);
//	if(%playerId.RailGun == 0)
//	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [1/2] <f2>Regular", $DisplayTime);
//	else if(%playerId.RailGun == 1)
//	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 1.5 seconds\n<f0>Current Setting: [2/2] <f2>EMP", $DisplayTime);
//}

//function PlasmaGun::onUse(%player,%item)
//{
//	Weapon::onUse(%player,%item);
//	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.45\nFire Rate: 0.6 seconds", $DisplayTime);
//}

function PlasmaGun::onUse(%player,%item)
{
	%playerId = Player::getClient(%player);
	Weapon::onUse(%player,%item);
	if(%playerId.Plasma == 0)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.6 seconds\n<f0>Current Setting: [1/4] <f2>Regular", $DisplayTime);
	else if(%playerId.Plasma == 1)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.3 seconds\n<f0>Current Setting: [2/4] <f2>Rapid Fire", $DisplayTime);
	else if(%playerId.Plasma == 2)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.6 seconds\n<f0>Current Setting: [3/4] <f2>Multi Fire", $DisplayTime);
    else if(%playerId.Plasma == 3)
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " - <f1>Fire Rate: 0.6 seconds\n<f0>Current Setting: [4/4] <f2>Plasma Burn", $DisplayTime);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 8\nFire Rate: N/A", $DisplayTime);
}

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.128\nFire Rate: 0.1 seconds", $DisplayTime);
}

function StasisCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 2.5 seconds", $DisplayTime);
}

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 1.1 seconds", $DisplayTime);
}

