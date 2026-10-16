ExplosionData DimensionalRifterExp
{
shapeName = "shockwave_large.dts";
soundId = bigExplosion4;
faceCamera = false;
randomSpin = true;
hasLight = true;
lightRange = 3.0;
timeZero = 0.450;
timeOne = 0.750;
colors[0] = { 1.0, 1.0, 1.0 };
colors[1] = { 1.0, 1.0, 1.0 };
colors[2] = { 1.0, 1.0, 1.0 };
radFactors = { 1.0, 1.0, 1.0 };
kickBackStrength = 0;
shiftPosition = True;
};
RocketData DimensionalRifterBolt
{
bulletShapeName = "rocket.dts";
explosionTag = DimensionalRifterExp;
damageClass = 1;
damageValue = 0.15; 
damageType = $DimensionalRift;
terminalVelocity = 80;
explosionRadius = 10;
kickBackStrength = 350;
acceleration = 5;
muzzleVelocity = 25;
totalTime = 10; 
liveTime = 10.25;
lightRange = 4.0;
lightColor = { 0.0, 2.0, 0.0 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};
ItemImageData DimensionalRifterImage
{
shapeFile = "shotgun";
mountPoint = 0;
weaponType = 0; 
reloadTime = 1;
fireTime = 1;
minEnergy = 40;
maxEnergy = 60;
projectileType = DimensionalRifterBolt;
accuFire = true;
sfxFire = SoundPlasmaTurretFire;
sfxActivate = SoundPickUpWeapon;
};
ItemData DimensionalRifter
{
heading = "fWeapons";
description = "Dimensional Rifter";
className = "Weapon";
shapeFile = "shotgun";
hudIcon = "disk";
shadowDetailMask = 4;
imageType = DimensionalRifterImage;
price = 1200;
showWeaponBar = true;
};
StaticShapeData DRifter::Block1
{
className = "StaticShape";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 10000;
maxEnergy = 20000;
mapFilter = 2;
visibleToSensor = false;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
};
function DRifter::testPurgatory() {
%teleset = nameToID("MissionCleanup\\DRifter");
if(%teleset != -1) {
echo("Purgatory Already Created.");
} else {
echo("Purgatory Did not exist yet."); 
instant SimGroup "DRifter" {
instant InteriorShape "DRifterPurgatory" {
filename="tank9.dis";
iscontainer="1";
position="-1000 -1000 -1000";
rotation="0 0 0";
lightparams="1";
locked="0";
};
instant SimGroup "Items" {
instant StaticShape "Gate1" {
dataBlock="Drifter::Block1";
name="Gate To Hell";
position="-991.227 -999.807 -968.75";
rotation="0 -0 -1.57024";
destroyable="False";
};
};
};
echo("DR::"@nameToID("DRifter"));
addToSet("MissionCleanup","DRifter");
}
echo("DR::"@nameToID("MissionCleanup\\DRifter"));
}
function DRifter::getRandomPos() {
%DropPos[0]="-973.822 -987.615 -985";
%DropPos[1]="-971.145 -1012.95 -986";
%DropPos[2]="-1008.32 -1013.51 -986";
%DropPos[3]="-1008.91 -998.098 -986";
%DropPos[4]="-989.729 -996.97 -986";
%DropPos[5]="-970.853 -998.636 -986";
%DropPos[6]="-973.986 -1006.07 -986";
%DropPos[7]="-989.904 -1006 -986";
%DropPos[8]="-1005.69 -1005.95 -986";
%DropPos[9]="-982.495 -1005.63 -986";
return(%DropPos[floor(getrandom()*10)]);
}
