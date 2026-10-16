function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.1\nFire Rate: 0.3 seconds", $DisplayTime);
}

function IonCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 2.3\nFire Rate: 3 seconds", $DisplayTime);
}

function AssaultR::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.2\nFire Rate: 0.2 seconds", $DisplayTime);
}

function MBCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.375\nFire Rate: 1.25 seconds", $DisplayTime);
}

function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.15\nFire Rate: 0.2 seconds", $DisplayTime);
}

function GatB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.05\nFire Rate: 0.1 seconds", $DisplayTime);
}

function Gauss::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.14\nFire Rate: 0.2 seconds", $DisplayTime);
}

function MiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.075\nFire Rate: 0.05 seconds", $DisplayTime);
}

function MMiniGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.15 x 4\nFire Rate: 0.025 seconds", $DisplayTime);
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
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 1.0 to 5.0\nFire Rate: 2.25 seconds", $DisplayTime);
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
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 0.5 to 0.65\nFire Rate: 1.6 seconds\nSpecial Ability: Any enemy NEAR your crosshair is programmed into the missile and it seeks to them.", $DisplayTime);
}

function MRPGLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>MECH Super Hyper Blaster\n<f0>Damage per shot: 1.2\nFire Rate: 0.5 seconds", $DisplayTime);
}

function MechRocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: variable 1.0 - 1.3\nFire Rate: 2.0 seconds", $DisplayTime);
}

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.6\nFire Rate: 0.3 seconds", $DisplayTime);
}

function Rifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.7\nFire Rate: 1.5 seconds", $DisplayTime);
}

function AAODSniperX::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: Armor-Dependant\nFire Rate: 1.5 seconds\nSpecial Ability: The heavier the armor plating, the more damage this weapon does.", $DisplayTime);
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

function AODForceProj::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Projects a temporal forcefield, uses a LOT of energy to maintain\nUse Particle Accelerator to lower energy drain.", $DisplayTime);
}

////////////////////////////////////////////////////////////////////////////////
//    New mount messages added 9-5-2002  by Defender
////////////////////////////////////////////////////////////////////////////////

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.1 x 16 bullets\nFire Rate: 1.75 seconds;", $DisplayTime);
}

function SniperRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
 bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.69\nFire Rate: 0.4 seconds;", $DisplayTime);
}

function RailGun2::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
 bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.59\nFire Rate: 0.6 seconds;", $DisplayTime);
}

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
 bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.70\nFire Rate: 0.6 seconds;", $DisplayTime);
}

function ATC::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.255\nFire Rate: 0.2 seconds", $DisplayTime);
}

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per burn: 0.03\nFire Rate: 0.0 seconds", $DisplayTime);
}

function Infantry::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 1.0\nFire Rate: 0.8 seconds", $DisplayTime);
}

function SR100::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.69\nFire Rate: 0.5 seconds", $DisplayTime);
}

function OmegaRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage Per Sec: 0.03\nFire Rate: 0.2 seconds", $DisplayTime);
}

function AlienLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.022\nFire Rate: 0.1 seconds", $DisplayTime);
}

function HyperLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.20\nFire Rate: 0.1 seconds", $DisplayTime);
}

function VertigoCannon::onUse(%player,%item)  // Vertigo Cannon
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.15\nFire Rate: 0.8 seconds", $DisplayTime);
}

function EnergyGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.19\nFire Rate: 0.1 seconds", $DisplayTime);
}

function BabyNukeMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 4.0\n1 shot: per reload", $DisplayTime);
}

function LaserPistol::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.021\nFire Rate: 0.1 seconds", $DisplayTime);
}

function AR::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.15\nFire Rate: 0.1 seconds", $DisplayTime);
}

function StasisCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f1>" @ %item.description @ "\n<f0>Damage per shot: 0.0\nFire Rate: 2.5 seconds\ncreats a large smoke cloud", $DisplayTime);
}


