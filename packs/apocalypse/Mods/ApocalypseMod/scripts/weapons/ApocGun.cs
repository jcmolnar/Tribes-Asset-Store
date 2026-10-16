$FireModes[ApocGun] = 2;
//--------------------------------------

$AutoUse[ApocGun] = True;
addAmmo(ApocGun,ApocAmmo,2,2);

addToInv(ApocGun,1,1);
addToInv(ApocAmmo,1,1);

setArmorItemMax(ApocGun,0,0,0,0,0,0,1, 1, 0,0,0,0);
setArmorItemMax(ApocAmmo,2,2,2,2,2,2,6, 99, 0,0,0,0);

//--------------------------------------

RocketData ApocNWShell
{
   bulletShapeName = "rocket.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.25;
   damageType       = $ApocalypseDamageType;

   explosionRadius  = 100.0;
   kickBackStrength = 250.0;

   muzzleVelocity   = 40.0;
   terminalVelocity = 50.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 1.8;

   soundId = SoundWindGust;
};

//---------------------------------------
RocketData ApocSBShell
{
   bulletShapeName = "mortar.dts";
   explosionTag    = plasmaExp0;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $ApocalypseDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 5.0;

   muzzleVelocity   = 180.0;
   terminalVelocity = 180.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundWindGust;
};

//Scatter Bombs--------------------------------------
GrenadeData ScatterShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = plasmaExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ApocalypseDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

//--------------------------------------

ItemData ApocAmmo
{
        description = "Apocalypse Ammo";
        className = "Ammo";
   heading = $InvCatAmmo;
        shapeFile = "mortarammo";
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData ApocGunImage
{
        shapeFile = "mortargun";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = ApocAmmo;
//        projectileType = ApocNWShell;
        accuFire = false;
        reloadTime = 2.0;
        fireTime = 1.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = bigExplosion1;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMortarIdle;
};

ItemData ApocGun
{
        description = "Apocalypse Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "mortar";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = ApocGunImage;
        price = 375;
        showWeaponBar = true;
   validateShape = true;
};

function ApocGunImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %ammo = Player::getItemCount(%player,ApocAmmo);
        if(%ammo > 0) {
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                if($WeapMode[%client,ApocGun] == 1 || $WeapMode[%client,ApocGun] < 1  || $WeapMode[%client,ApocGun] == "")
                        Projectile::spawnProjectile(ApocNWShell,%trans,%player,%vel);
                else if($WeapMode[%client,ApocGun] >= $FireModes[ApocGun]) {
                        //Scatter Bomb code part 1 by Plasmatic modifed by ProtoManX
                        if(GameBase::getLOSInfo(%player,800)){
                                %dist = Vector::getDistance(GameBase::getPosition(%player),$los::position);
                                if(%dist == 0)
                                         %time = 1;
                                else
                                         %time=(%dist/180)-0.05;
                                %obj = Projectile::spawnProjectile(ApocSBShell,%trans,%player,%vel);
                                schedule("ScatterBombs(" @ %player @ ", " @ %client @ ", " @ %obj @ ");", %time);
                        }
                        else{
                                %time = 1;
                                %obj = Projectile::spawnProjectile(ApocSBShell,%trans,%player,%vel);
                                schedule("ScatterBombs(" @ %player @ ", " @ %client @ ", " @ %obj @ ");", %time);
                        }
                }
                Player::decItemCount(%player,ApocAmmo,1);
        }
}

//Scatter Bomb code part 2 by Plasmatic modifed by ProtoManX
function ScatterBombs(%player, %client, %obj) {
        %pos = GameBase::getPosition(%obj);
        %vel = Item::getVelocity(%obj);
        for(%i = 0; %i < 10; %i++) {
                %xrnd = floor(getRandom() * 60) -30;
                %yrnd = floor(getRandom() * 60) -30;
                %zrnd = floor(getRandom() * 60) -30;
                %newvel = %xrnd@" "@%yrnd@" "@%zrnd;
                %trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%obj);
                %newobj = Projectile::spawnProjectile(ScatterShell,%trans,%player,%vel);
//                Projectile::spawnProjectile(%newobj);
                GameBase::setPosition(%newobj, %pos);
                Item::setVelocity(%newobj, %newvel);
        }
}

function ApocGun::onMount(%player,%item)
{
        %client = Player::getClient(%player);
        if($WeapMode[%client,ApocGun] == 2 || $WeapMode[%client,ApocGun] > $FireModes[ApocGun]) {
                Player::mountItem(%player,ApocScaMod,$ExtraSlotA);
                Player::mountItem(%player,ApocScaMod2,$ExtraSlotB);
        }
}

function ApocGun::onUnMount(%player,%item)
{
        %client = Player::getClient(%player);
        if($WeapMode[%client,ApocGun] == 2 || $WeapMode[%client,ApocGun] > $FireModes[ApocGun]) {
                Player::unmountItem(%player,$ExtraSlotA);
                Player::unmountItem(%player,$ExtraSlotB);
        }
}

$MountMSG[ApocGun,1] = "<JC><F2>Apocalypse Cannon <F0>- <F1>Fires a nuclear warhead.";
$MountMSG[ApocGun,2] = "<JC><F2>Apocalypse Cannon <F0>- <F1>Fires a nuclear scatter bomb.";

AddWeapon(ApocGun);
