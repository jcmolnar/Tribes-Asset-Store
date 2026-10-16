ItemData NaniteBurstAmmo
{
description = "Nanite Burst";
className = "Ammo";
shapeFile = "bullet";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 20;
};
ExplosionData NaniteBurstRifleExp
{
shapeName = "chainspk.dts";
soundId = ricochet1;
faceCamera = true;
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
RocketData NaniteBurstRifleBolt
{
bulletShapeName = "bullet.dts";
explosionTag = NaniteBurstRifleExp;
damageClass = 0;
damageValue = 0.235; 
damageType = $NaniteBurstDamageType;
terminalVelocity = 1000;
explosionRadius = 0.05;
kickBackStrength = 0;
acceleration = 500;
muzzleVelocity = 1000;
totalTime = 1.3; 
liveTime = 4.05;
lightRange = 2.0;
lightColor = { 1.0, 0.0, 0.0 };
inheritedVelocityScale = 0.5;
isVisible = True;
rotationPeriod = 1;
};
ItemImageData NaniteBurstRifleImage
{
shapeFile = "sniper";
mountPoint = 0;
weaponType = 0; 
reloadTime = 2;
fireTime = 1;
ammotype=NaniteBurstAmmo;
projectileType = NaniteBurstRifleBolt;
accuFire = true;
sfxFire = SoundPickupAmmo;
sfxActivate = SoundPickUpWeapon;
};
ItemData NaniteBurstRifle
{
heading = "fWeapons";
description = "Nanite Burst Rifle";
className = "Weapon";
shapeFile = "sniper";
hudIcon = "sniper";
shadowDetailMask = 4;
imageType = NaniteBurstRifleImage;
price = 675;
showWeaponBar = true;
};
function NaniteBurst::Infection(%this,%shooter,%damageLeft) { 
Player::setDamageFlash(%this,Player::getDamageFlash(%this)+0.1);
GameBase::applyDamage(%this,$NaniteBurstDamageType,$NaniteDamageLevel,GameBase::getPosition(%this),"0 0 0","0 0 0",%shooter);
if(%damageLeft>1) schedule("NaniteBurst::Infection("@%this@","@%shooter@","@%damageLeft-1@");",3); else %this.NaniteLevel--;
%Client = Player::getClient(%this);
if(%this.NaniteLevel>0)
Client::sendMessage(%Client,0,"Nanites eat into your vital organs!");
else
Client::sendMessage(%Client,0,"The Nanites cease to function.");
echo("NANITELEVEL: ("@%this@"): "@%this.NaniteLevel);
}
$deathMsg[$NaniteBurstDamageType, 0] = "%1 gives %2 a bad case of the creeps.";
$deathMsg[$NaniteBurstDamageType, 1] = "%2 dies of Nanite overdose given by %1.";
$deathMsg[$NaniteBurstDamageType, 2] = "%1 causes %2 to scrach %3self to death.";
$deathMsg[$NaniteBurstDamageType, 3] = "%2 gets a microsurgical dose from %1.";
$NaniteDamageTimes=2;
$NaniteDamageLevel=0.05;
