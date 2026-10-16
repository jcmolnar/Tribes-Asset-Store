ItemData DisruptorShellAmmo
{
description = "Disruptor Shell";
className = "Ammo";
heading = "xAmmunition";
shapeFile = "mortarammo";
shadowDetailMask = 4;
price = 5;
};
ExplosionData disruptorShellExp
{
shapeName = "shockwave.dts";
soundId = bigExplosion1;
faceCamera = true;
randomSpin = true;
hasLight = true;
lightRange = 8.0;
timeScale = 1.5;
timeZero = 0.450;
timeOne = 0.750;
colors[0] = { 0.0, 0.0, 0.0 };
colors[1] = { 1.0, 1.0, 1.0 };
colors[2] = { 1.0, 1.0, 1.0 };
radFactors = { 0.0, 1.0, 1.0 };
};
GrenadeData DisruptorShell
{
bulletShapeName = "mortar.dts";
explosionTag = disruptorShellExp;
collideWithOwner = True;
ownerGraceMS = 250;
collisionRadius = 0.3;
mass = 5.0;
elasticity = 0.05;
damageClass = 1; 
damageValue = 0.05;
damageType = $EMPDamageType;
explosionRadius = 20.0;
kickBackStrength = 50.0;
maxLevelFlightDist = 275;
totalTime = 30.0;
liveTime = 2.0;
projSpecialTime = 0.01;
inheritedVelocityScale = 0.5;
smokeName = "plastrail.dts";
};
ItemImageData DisruptorImage
{
shapeFile = "mortargun";
mountPoint = 0;
weaponType = 0; 
ammoType = DisruptorShellAmmo;
projectileType = DisruptorShell;
accuFire = false;
reloadTime = 0.5;
fireTime = 2.0;
lightType = 3; 
lightRadius = 3;
lightTime = 1;
lightColor = { 0.6, 1, 1.0 };
sfxFire = SoundFireMortar;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundMortarReload;
sfxReady = SoundMortarIdle;
};
ItemData Disruptor
{
description = "Disruptor Cannon";
className = "Weapon";
shapeFile = "mortargun";
hudIcon = "mortar";
heading = "fWeapons";
shadowDetailMask = 4;
imageType = DisruptorImage;
price = 975;
showWeaponBar = true;
};
function Disruptor::EnergyDrain(%this,%shooter,%damageLeft) { 
if(%damageLeft>1) schedule("Disruptor::EnergyDrain("@%this@","@%shooter@","@%damageLeft-1@");",3); else %this.EMPLevel--;
%Client = Player::getClient(%this);
if(%this.EMPLevel==0) {
Client::sendMessage(%Client,0,"Your energy system returns to normal.");
GameBase::setRechargeRate(%this,%this.EMPRecharge);
}
}
$deathMsg[$EMPDamageType, 0] = "%1 drains the life of %2.";
$deathMsg[$EMPDamageType, 1] = "%2 dies of Disruptoritis given by %1.";
$deathMsg[$EMPDamageType, 2] = "%1 gives %2 a lethal dose of radiation.";
$deathMsg[$EMPDamageType, 3] = "%2 gets a a shock out of meeting %1.";
$EMPDamageTime=5;
$EMPDamageLevel=0.05;
