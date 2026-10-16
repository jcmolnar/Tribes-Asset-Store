function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.127\nFire Rate: 0.3 seconds", $DisplayTime);
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

function MBCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.5\nFire Rate: 1.25 seconds", $DisplayTime);
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

function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.11\nFire Rate: 0.2 seconds", $DisplayTime);
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

function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.4\nFire Rate: 1 second", $DisplayTime);
}

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.0\nFire Rate: 2.5 seconds", $DisplayTime);
}

function ImpactMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.0\nFire Rate: 2.5 seconds\nSpecial Ability: Exlodes on Impact", $DisplayTime);
}

function EMPGrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: N/A\nFire Rate: 2.5 seconds\nSpecial Ability: EMP slowly drains your energy. When out of energy, it uses health.", $DisplayTime);
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

function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.5\nFire Rate: 1.75 seconds", $DisplayTime);
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
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.7\nFire Rate: 1.5 seconds", $DisplayTime);
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

function PlasmaGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.45\nFire Rate: 0.6 seconds", $DisplayTime);
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
