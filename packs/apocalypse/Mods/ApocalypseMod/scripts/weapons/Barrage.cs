//--------------------------------------

$AutoUse[Barrage] = True;

addAmmo(Barrage,HomingAmmo,3,6);

addToInv(Barrage,1,1);
addToInv(HomingAmmo,1,1);

setArmorItemMax(Barrage,0,0,0,0,0,1,1, 1, 0,0,0,0);
setArmorItemMax(HomingAmmo,10,10,12,12,12,9,12, 99, 0,0,0,0);

//--------------------------------------
RocketData TinyRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.45;
   damageType       = $MissileDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 75.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 20.0;
   totalTime        = 10.0;
   liveTime         = 10.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TinyMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.45;
   damageType       = $MissileDamageType;
   explosionRadius  = 10.0;
   kickBackStrength = 75.0;

   muzzleVelocity    = 100.0;
   terminalVelocity = 150.0;
   acceleration     = 20.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9.0;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
LightningData missilePrep
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 250.0;
   coneAngle        = 25.0;

   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 1;
   beamWidth = 0.1;

   updateTime   = 3000;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.0 };

   isVisible = false;
};

//missile lock coded by Creeperman
        //missile lock Part1
function missilePrep::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
        %client = %shooterId;
        %player = Client::getControlObject(%client);
        %data = getObjectType(%target);

        if(%data == "Player" || %data == "Flier") {
                if(!%player.vehicle || (%target.vehicle != %player.vehicle && %target != %player.vehicle)) {
                        if(%data == "Player") {
                                if(Player::getSensorSupression(%target) >= 20)
                                        %target = 0;
                                else if(%target.vehicle)
                                        %target = %target.vehicle;
                        }
                        %client.targetLock = %target;
                }
                else
                        %client.targetLock = 0;
        }
        else
                %client.targetLock = 0;
}

//----------------------------------------------------------------------------

ItemData HomingAmmo
{
        description = "Homing Missiles";
        className = "Ammo";
        heading = $InvCatAmmo;
        shapeFile = "rocket";
        shadowDetailMask = 4;
        price = 5;
};

//ItemData BarrageAmmo
//{
//        description = "Barrage Missiles";
//        className = "Ammo";
//        shapeFile = "rocket";
//   heading = $InvCatAmmo;
//        shadowDetailMask = 4;
//        price = 6;
//};

ItemImageData BarrageImage
{
        shapeFile = "mortargun";
        mountPoint = 0;
//        mountOffset = { 0.0, -0.6, 0.4 };
//        mountRotation = { 0, 0, 0 };

        weaponType = 0; // Sustained
        ammoType = HomingAmmo;
        accuFire = true;
        fireTime = 0.1;
        reloadTime = 4.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1.0, 1.0, 1.0 };

        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundMissileTurretTurn;
};

ItemData Barrage
{
        description = "Barrage Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "targetlaser";
        heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = BarrageImage;
        price = 250;
        showWeaponBar = true;
};

function BarrageImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        %client.targetLock = 0;
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        %newObj = Projectile::spawnProjectile("missilePrep",%trans,%player,%vel);
        schedule("deleteobject(" @ %newObj @ ");",0.1,%newObj);
        schedule("Weapon::fireMissiles(" @ %player @ ",3,Barrage,true);",0.05,%player);
}

        //missile lock Part2
function Weapon::fireMissiles(%player,%count,%item,%warn)
{
        %client = GameBase::getControlClient(%player);
        if(Player::getItemCount(%player,$WeaponAmmo[%item])) {
                Player::decItemCount(%player,$WeaponAmmo[%item], 1);
        //        %trans = GameBase::getMuzzleTransform(%player);
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);

                GameBase::PlaySound(%player, SoundMissileTurretFire, 2);

                if(%client.targetLock && TeamCompare(%player,%client.targetLock) == Diff) { //&& GameBase::isAtRest(%player)
                        %newObj = Projectile::spawnProjectile("TinyMissile",%trans,%player,%vel,%client.targetLock);

                        if(%warn) {

                                // Audio and bottom-printed warning while missile is in flight...
                                if(GameBase::getControlClient(%client.targetLock) != -1)
                                        bottomPrint(%client,"<JC><F2>Alert!  <F0>Guided missile lock acquired on <F1>" @ Client::getName(GameBase::getControlClient(%client.targetLock)) @ "<F0>!",3);
                                else
                                        bottomPrint(%client,"<JC><F2>Alert!  <F0>Guided missile lock acquired on <F1>" @ GameBase::getDataName(%client.targetLock) @ "<F0>!",3);

                                GameBase::PlaySound(%player, SoundMineActivate, 1);

                                bottomPrint(GameBase::getControlClient(%client.targetLock),"<F2>Warning!  <F0>" @ Client::getName(%client) @ "<F1> has a guided missile lock!",3);
                                schedule("GameBase::PlaySound(" @ %client.targetLock @ ", SoundErrorMessage, 1);",0.0,%newObj);
                                schedule("GameBase::PlaySound(" @ %client.targetLock @ ", SoundErrorMessage, 1);",0.5,%newObj);
                                schedule("GameBase::PlaySound(" @ %client.targetLock @ ", SoundErrorMessage, 1);",1.0,%newObj);
                        }
                }
                else
                        Projectile::spawnProjectile("TinyRocket",%trans,%player,%vel);

                %count--;
        }

        if(%count && Player::getItemCount(%player,$WeaponAmmo[%item]))
                schedule("Weapon::fireMissiles(" @ %player @ "," @ %count @ "," @ %item @ ",false" @ ");",0.5,%player);
        else {
                if(Player::getItemCount(%player,$WeaponAmmo[%item]) > 0)
                        GameBase::PlaySound(%player, SoundMissileTurretOn, 3);
                else
                        GameBase::PlaySound(%player, SoundMissileTurretOff, 3);
        }
}

$MountMSG[Barrage] = "<JC><F2>Barrage Cannon <F0>- <F1>Fires 3 consecutive guided or unguided missiles. You can not move while firing guided missiles.";

AddWeapon(Barrage);
