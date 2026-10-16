//==========================================
//Discer Items
//==========================================

$AutoUse[EDiscLauncher] = True;
$WeaponAmmo[EDiscLauncher] = "";

addToInv(EDiscLauncher,1,1);

setArmorItemMax(EDiscLauncher,0,0,0,0,0,0,0, 1,0,0,0,1);

//--------------------------------------

BulletData EDiscShell
{
   bulletShapeName    = "discb.dts";
   explosionTag       = turretExp;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 3.75;

   muzzleVelocity     = 175.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

};

//--------------------------------------

ItemImageData EDiscLauncherImage
{
        shapeFile = "disc";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.625;
        minEnergy = 8;
        maxEnergy = 9;

        projectileType = EDiscShell;
        accuFire = true;

        sfxFire = SoundFireBlaster;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDiscSpin;
};

ItemData EDiscLauncher
{
        description = "Energy Discer";
        className = "Weapon";
        shapeFile = "disc";
        hudIcon = "disk";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = EDiscLauncherImage;
        price = 9000;
        showWeaponBar = true;
};

$MountMSG[EDiscLauncher] = "<JC><F2>Energy Discer <F0>- <F1>Fires explosive energy disc at high velocity.";

AddWeapon(EDiscLauncher);
//--------------------------------------
//--------------------------------------

$AutoUse[GDiscLauncher] = True;
addAmmo(GDiscLauncher,GDiscAmmo,5,0);

addToInv(GDiscLauncher,1,1);

setArmorItemMax(GDiscLauncher,0,0,0,0,0,0,0, 1,0,0,0,1);
setArmorItemMax(GDiscAmmo,0,0,0,0,0,0,0, 99,0,0,0,30);

//--------------------------------------

GrenadeData GDiscShell
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;
   maxLevelFlightDist = 125;
   totalTime          = 25.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "chainspk.dts";
};

//--------------------------------------

ItemData GDiscAmmo
{
        description = "Grenade Disc";
        className = "Ammo";
        shapeFile = "discammo";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 90;
};

ItemImageData GDiscLauncherImage
{
        shapeFile = "grenadeL";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = GDiscAmmo;
        projectileType = GDiscShell;
        accuFire = false;
        reloadTime = 0.5;
        fireTime = 0.5;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = SoundFireGrenade;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDiscReload;
        sfxReady = SoundDiscSpin;
};

ItemData GDiscLauncher
{
        description = "Grenade Discer";
        className = "Weapon";
        shapeFile = "grenadeL";
        hudIcon = "disk";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = GDiscLauncherImage;
        price = 9000;
        showWeaponBar = true;
};

$MountMSG[GDiscLauncher] = "<JC><F2>Grenade Discer <F0>- <F1>Lobs an explosive disc.";

AddWeapon(GDiscLauncher);
//--------------------------------------
//--------------------------------------

$AutoUse[RDiscgun] = True;
addAmmo(RDiscgun,RDiscAmmo,5,0);

addToInv(RDiscgun,1,1);

setArmorItemMax(RDiscgun,0,0,0,0,0,0,0, 1,0,0,0,1);
setArmorItemMax(RDiscAmmo,0,0,0,0,0,0,0, 99,0,0,0,20);

//--------------------------------------
BulletData RDiscBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.15;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ExplosionDamageType;

   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;
};

//----------------------------------------------------------------------------

ItemData RDiscAmmo
{
        description = "Disc Blade";
   heading = $InvCatAmmo;
        className = "Ammo";
        shapeFile = "discammo";
        shadowDetailMask = 4;
        price = 6;
};

ItemImageData RDiscgunImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = RDiscAmmo;
        projectileType = RDiscBullet;
        accuFire = true;
        reloadTime = 0.1;
        fireTime = 1.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDryFire;
};

ItemData RDiscgun
{
        description = "Disc Rifle";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "disk";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = RDiscgunImage;
        price = 9000;
        showWeaponBar = true;
};

$MountMSG[RDiscgun] = "<JC><F2>Disc Rifle <F0>- <F1>Fires a spining disc blade.";

AddWeapon(RDiscgun);
//==========================================
//Proto Items
//Blaster & Proto Gun charge code by ProtoManX
//==========================================

$AutoUse[ProtoXBuster] = True;
$Use[ProtoXBuster] = True;
$WeaponAmmo[ProtoXBuster] = "";

addToInv(ProtoXBuster,1,1);

setArmorItemMax(ProtoXBuster,0,0,0,0,0,0,0, 0,0,0,1,0);

//--------------------------------------
BulletData ProtoXBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp0;

   damageClass        = 0;
   damageValue        = 1.25;
   damageType         = $ProtoDamageType;
   explosionradius    = 4.0;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------

BulletData ProtoBolt
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = plasmaExp1;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $ProtoDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//----------------------------------------------------------------------------

ItemImageData ProtoXBuster2Image
{
   shapeFile  = "mortargun";
        mountPoint = 0;
        mountOffset = { 0.0, -0.3, -0.15 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

        sfxFire = SoundFireBlaster;
        sfxReady = SoundMortarIdle;
};

ItemData ProtoXBuster2
{
   heading = "bProto Equipment";
        description = "Proto Gun";
        className = "Weapon";
   shapeFile  = "mortargun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = ProtoXBuster2Image;
        price = 0;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData ProtoXBusterImage
{
   shapeFile  = "breath";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 5;
        maxEnergy = 60;

        accuFire = true;

        sfxActivate = SoundPickUpWeapon;
};

ItemData ProtoXBuster
{
   heading = $InvCatWeapons[Pro];
        description = "Proto Gun";
        className = "Weapon";
   shapeFile  = "mortargun";
        hudIcon = "blaster";
        shadowDetailMask = 4;
        imageType = ProtoXBusterImage;
        price = 9000;
        showWeaponBar = true;
};

function ProtoXBusterImage::onFire(%player, %slot)
{
        if(%player.ChrgOn == 0) {
                %player.EnChrg = 0;
                %energy = GameBase::getEnergy(%player);
                ProtoXBuster::Charge(%player,%energy);
        }
}

function ProtoXBuster::Charge(%player,%energy)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state == "Fire") {
                %player.ChrgOn = 1;
                %energy -= 1.5;
                if(%energy < 0)
                        %energy = 0;
                GameBase::setEnergy(%player,%energy);
                %player.EnChrg += 1.5;
                if(%player.EnChrg >= %armor.maxEnergy)
                        %player.EnChrg = %armor.maxEnergy;
                if(%player.EnChrg >= 60)
                        %player.ChrgLvl = 1;
                else
                        %player.ChrgLvl = 0;
                %energy = GameBase::getEnergy(%player);
                Bottomprint(%client, "<JC><F1>Charge Level: <F2>" @ %player.ChrgLvl,1);
                schedule("ProtoXBuster::Charge(" @ %player @ "," @ %energy @ ");",0.1);
        }
        else {
                %player.ChrgOn = 0;
        //        %trans = GameBase::getMuzzleTransform(%player);
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                Player::trigger(%player,6,true);
                Player::trigger(%player,6,false);
                if(%player.ChrgLvl == 1)
                        Projectile::spawnProjectile("ProtoXBolt",%trans,%player,%vel);
                else
                        Projectile::spawnProjectile("ProtoBolt",%trans,%player,%vel);
        }
}

function ProtoXBuster::onMount(%player,%item)
{
        Player::mountItem(%player,ProtoXBuster2,$ExtraSlotA);
}

function ProtoXBuster::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
}
$MountMSG[ProtoXBuster] = "<JC><F2>Proto Gun <F0>- <F1>powerful energy weapon.";

AddWeapon(ProtoXBuster);
//--------------------------------------

addToInv(ProtoShieldPack,1,1);

setArmorItemMax(ProtoShieldPack,0,0,0,0,0,0,0, 0,0,0,1,0);

//--------------------------------------

ItemImageData ProtoShieldImage
{
        shapeFile = "forcefield_3x4";
        mountPoint = 0;
        mountOffset = { -0.3, 0.5, -2.0 };

        weaponType = 2;  // Sustained
        minEnergy  = 0;
        maxEnergy = 0;  // Energy used/sec for sustained weapons

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxActivate = SoundPickUpWeapon;
};

ItemData ProtoShield
{
        description = "Proto Shield";
        shapeFile = "forcefield_3x4";
        hudIcon = "shieldpack";
        className = "Weapon";
        shadowDetailMask = 4;
        imageType = ProtoShieldImage;
        showInventory = false;
        price = 0;
        showWeaponBar = true;
};

function ProtoShield::onMount(%player,%imageSlot)
{
        Player::trigger(%player,$BackpackSlot,true);
}

function ProtoShield::onUnmount(%player,%imageSlot)
{
        Player::trigger(%player,$BackpackSlot,false);
        if(Player::getItemCount(%player,ProtoShieldPack) > 0)
                Player::mountItem(%player,ProtoShieldPack,$BackpackSlot);
}

function ProtoShield::onDrop (%player,%item)
{
        if($matchStarted) {
                %mounted = Player::getMountedItem(%player,$WeaponSlot);
                if (%mounted == ProtoShield) {
                        Player::unmountItem(%player,$WeaponSlot);
                }
                else {
                        Player::mountItem(%player,%mounted,$WeaponSlot);
                }
                Item::onDrop(%player,ProtoShieldPack);
        }
}

$MountMSG[ProtoShield] = "<JC><F2>Proto Shield <F0>- <F1>Stops frontal assualts while in hands and rear assualts while on back.";

//--------------------------------------

ItemImageData ProtoShieldPackImage
{
        shapeFile = "forcefield_3x4";
        mountPoint = 2;
        mountOffset = { 1.3, 0.1, -1.6 };
        mountRotation = { 0, -0.785, 0 };
        weaponType = 2;  // Sustained
   minEnergy = 0;
        maxEnergy = 0;   // Energy used/sec for sustained weapons
        firstPerson = false;
};

ItemData ProtoShieldPack
{
        description = "Proto Shield";
        shapeFile = "forcefield_3x4";
        className = "Backpack";
   heading = $InvCatWeapons[Pro];
        shadowDetailMask = 4;
        imageType = ProtoShieldPackImage;
        price = 9000;
        hudIcon = "shieldpack";
        showWeaponBar = false;
        hiliteOnActive = false;
};

function ProtoShieldPack::onMount(%player, %item)
{
        if (Player::getMountedItem(%player,$WeaponSlot) == ProtoShield) {
                Player::unmountItem(%player,$WeaponSlot);
        }
}

function ProtoShieldPack::onUnmount(%player,%item)
{
        if (Player::getMountedItem(%player,$WeaponSlot) == ProtoShield) {
                Player::unmountItem(%player,$WeaponSlot);
        }
}

function ProtoShieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::unmountItem(%player,$BackpackSlot);
                Player::mountItem(%player,ProtoShield,$WeaponSlot);
        }
}

function ProtoShieldPack::onDrop(%player,%item)
{
        if($matchStarted) {
                %mounted = Player::getMountedItem(%player,$WeaponSlot);
                if (%mounted == ProtoShield) {
                        Player::unmountItem(%player,$WeaponSlot);
                }
                else {
                        Player::mountItem(%player,%mounted,$WeaponSlot);
                }
                Item::onDrop(%player,%item);
        }
}

$MountMSG[ProtoShieldPack] = "<JC><F2>Proto Shield <F0>- <F1>Stops frontal assualts while in hands and rear assualts while on back.";
//==========================================
//Saiyan Items
//Saiyan charge function by ProtoManX
//==========================================
//--------------------------------------

$AutoUse[Renzokugun] = True;
$WeaponAmmo[Renzokugun] = "";

addToInv(Renzokugun,1,1);

setArmorItemMax(Renzokugun,0,0,0,0,0,0,0, 0,1,1,0,0);

//--------------------------------------
BulletData RenzokuBullet
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $NCSaiyanDamageType;
   explosionRadius    = 2.0;

   aimDeflection      = 0.005;
   muzzleVelocity     = 350.0;
   totalTime          = 2.0;
   liveTime           = 1.125;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
};

//----------------------------------------------------------------------------

ItemImageData RenzokugunImage
{
        shapeFile = "plasmatrail";
        mountPoint = 0;

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.5;
        spinDownTime = 1.0;
        fireTime = 0.1;
        projectileType = RenzokuBullet;
        accuFire = true;
        minEnergy = 6;
        maxEnergy = 8;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = SoundFireBlaster;
        sfxActivate = SoundPickUpWeapon;
};

ItemData Renzokugun
{
        description = "Renzoku";
        className = "Weapon";
        shapeFile = "plasmatrail";
        hudIcon = "plasma";
   heading = $InvCatWeapons[Sai];
        shadowDetailMask = 4;
        imageType = RenzokugunImage;
        price = 9000;
        showWeaponBar = true;
};

$MountMSG[Renzokugun] = "<JC><F2>Renzoku <F0>- <F1>rapidly fire balls of energy.";

AddWeapon(Renzokugun);
//--------------------------------------
//--------------------------------------

$AutoUse[SpiritBomb] = True;
$Use[SpiritBomb] = True;
$WeaponAmmo[SpiritBomb] = "";

addToInv(SpiritBomb,1,1);

setArmorItemMax(SpiritBomb,0,0,0,0,0,0,0, 0,1,1,0,0);

//--------------------------------------
RocketData SpiritShell
{
   bulletShapeName = "fusionex.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.02;
   damageType       = $SaiyanDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 300.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fusionex.dts";
   smokeDist   = 0.01;
};

//----------------------------------------------------------------------------

ItemImageData SpiritBombImage
{
   shapeFile  = "fusionbolt";
        mountPoint = 0;
        mountOffset = { 0.0, 0.3, -0.1 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

        sfxActivate = SoundPickUpWeapon;
};

ItemData SpiritBomb
{
   heading = $InvCatWeapons[Sai];
        description = "Spirit Bomb";
        className = "Weapon";
   shapeFile  = "fusionbolt";
        hudIcon = "plasma";
        shadowDetailMask = 4;
        imageType = SpiritBombImage;
        price = 9000;
        showWeaponBar = true;
};

function SpiritBombImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        if(%player.ChrgOn == 0) {
                %client.EnChrg = 0;
                GameBase::setRechargeRate(%player, 0);
                %energy = GameBase::getEnergy(%player);
                SpiritBomb::Charge(%player,%energy);
        }
}

function SpiritBomb::Charge(%player,%energy)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state == "Fire") {
                %player.ChrgOn = 1;
                if(%client.EnChrg < 100 && %energy >= 1) {
                        %energy -= 1;
                        if(%energy < 0.9)
                                %energy = 0.9;
                        GameBase::setEnergy(%player,%energy);
                        %client.EnChrg += 1;
                }
                if(%client.EnChrg >= 100)
                        %client.EnChrg = 100;
                %energy = GameBase::getEnergy(%player);
                Bottomprint(%client, "<JC><F1>Charge <F2>%" @ %client.EnChrg,1);
                schedule("SpiritBomb::Charge(" @ %player @ "," @ %energy @ ");",0.1);
        }
        else {
                %player.ChrgOn = 0;
                GameBase::setRechargeRate(%player, 8);
  //        %trans = GameBase::getMuzzleTransform(%player);
          %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                GameBase::PlaySound(%player, SoundFirePlasma, 2);
                Projectile::spawnProjectile("SpiritShell",%trans,%player,%vel);
        }
}

$MountMSG[SpiritBomb] = "<JC><F2>Spirit Bomb <F0>- <F1>gather energy and release it in one big shot.";

AddWeapon(SpiritBomb);
//--------------------------------------
//--------------------------------------

$AutoUse[Kamehameha] = True;
$Use[Kamehameha] = True;
$WeaponAmmo[Kamehameha] = "";

addToInv(Kamehameha,1,1);

setArmorItemMax(Kamehameha,0,0,0,0,0,0,0, 0,1,1,0,0);

//--------------------------------------
RocketData KamehaShell
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = plasmaExp0;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.04;
   damageType       = $SaiyanDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 200.0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 110.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 0.01;
};

//----------------------------------------------------------------------------

ItemImageData KamehamehaImage
{
   shapeFile  = "plasmabolt";
        mountPoint = 0;
        mountOffset = { 0.0, -0.1, -0.2 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

        sfxActivate = SoundPickUpWeapon;
};

ItemData Kamehameha
{
   heading = $InvCatWeapons[Sai];
        description = "Kamehameha Wave";
        className = "Weapon";
   shapeFile  = "plasmabolt";
        hudIcon = "plasma";
        shadowDetailMask = 4;
        imageType = KamehamehaImage;
        price = 9000;
        showWeaponBar = true;
};

function KamehamehaImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        if(%player.ChrgOn == 0) {
                %client.EnChrg = 0;
                GameBase::setRechargeRate(%player, 0);
                %energy = GameBase::getEnergy(%player);
                Kamehameha::Charge(%player,%energy);
        }
}

function Kamehameha::Charge(%player,%energy)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state == "Fire") {
                %player.ChrgOn = 1;
                if(%client.EnChrg < %armor.maxEnergy && %energy >= 1) {
                        %energy -= 1;
                        if(%energy < 0.9)
                                %energy = 0.9;
                        GameBase::setEnergy(%player,%energy);
                        %client.EnChrg += 1;
                }
                if(%client.EnChrg >= %armor.maxEnergy)
                        %client.EnChrg = %armor.maxEnergy;
                %energy = GameBase::getEnergy(%player);
                Bottomprint(%client, "<JC><F1>Charge <F2>%" @ 100 * (%client.EnChrg/%armor.maxEnergy),1);
                schedule("Kamehameha::Charge(" @ %player @ "," @ %energy @ ");",0.1);
        }
        else {
                %player.ChrgOn = 0;
                GameBase::setRechargeRate(%player, 8);
        //        %trans = GameBase::getMuzzleTransform(%player);
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                GameBase::PlaySound(%player, SoundFirePlasma, 2);
                Projectile::spawnProjectile("KamehaShell",%trans,%player,%vel);
        }
}

$MountMSG[Kamehameha] = "<JC><F2>Kamehameha Wave <F0>- <F1>gather energy and release it in one big shot.";

AddWeapon(Kamehameha);
//--------------------------------------
//--------------------------------------

$AutoUse[DestructoDisc] = True;
$Use[DestructoDisc] = True;
$WeaponAmmo[DestructoDisc] = "";

addToInv(DestructoDisc,1,1);

setArmorItemMax(DestructoDisc,0,0,0,0,0,0,0, 0,1,1,0,0);

//--------------------------------------
BulletData DestructoShell
{
   bulletShapeName    = "discb.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 2.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.04;
   damageType         = $SaiyanDamageType;

   muzzleVelocity     = 100.0;
   totalTime          = 6.5;
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   soundId = SoundDiscSpin;
};

//----------------------------------------------------------------------------

ItemImageData DestructoDiscImage
{
   shapeFile  = "discb";
        mountPoint = 0;
        mountOffset = { 0.0, 0.0, -0.1 };

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.0;
        minEnergy = 0;
        maxEnergy = 0;

        accuFire = true;

        sfxActivate = SoundPickUpWeapon;
};

ItemData DestructoDisc
{
   heading = $InvCatWeapons[Sai];
        description = "Destructo Disc";
        className = "Weapon";
   shapeFile  = "discb";
        hudIcon = "disk";
        shadowDetailMask = 4;
        imageType = DestructoDiscImage;
        price = 9000;
        showWeaponBar = true;
};

function DestructoDiscImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        if(%player.ChrgOn == 0) {
                %client.EnChrg = 0;
                GameBase::setRechargeRate(%player, 0);
                %energy = GameBase::getEnergy(%player);
                DestructoDisc::Charge(%player,%energy);
        }
}

function DestructoDisc::Charge(%player,%energy)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state == "Fire") {
                %player.ChrgOn = 1;
                if(%client.EnChrg < 50 && %energy >= 1) {
                        %energy -= 1;
                        if(%energy < 0.9)
                                %energy = 0.9;
                        GameBase::setEnergy(%player,%energy);
                        %client.EnChrg += 1;
                }
                if(%client.EnChrg >= 50)
                        %client.EnChrg = 50;
                %energy = GameBase::getEnergy(%player);
                Bottomprint(%client, "<JC><F1>Charge <F2>%" @ 100 * (%client.EnChrg/50),1);
                schedule("DestructoDisc::Charge(" @ %player @ "," @ %energy @ ");",0.1);
        }
        else {
                %player.ChrgOn = 0;
                GameBase::setRechargeRate(%player, 8);
        //        %trans = GameBase::getMuzzleTransform(%player);
                %trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                GameBase::PlaySound(%player, SoundFireDisc, 2);
                Projectile::spawnProjectile("DestructoShell",%trans,%player,%vel);
        }
}

$MountMSG[DestructoDisc] = "<JC><F2>Destructo Disc <F0>- <F1>gather energy and release it in form of a blade.";

AddWeapon(DestructoDisc);
//==========================================
//Friends Items
//==========================================

$AutoUse[PlobeLauncher] = True;
addAmmo(PlobeLauncher,PlobeAmmo,10,0);

addToInv(PlobeLauncher,1,1);
addToInv(PlobeAmmo,1,1);

setArmorItemMax(PlobeLauncher,0,0,0,0,0,0,0, 1,0,0,0,0);
setArmorItemMax(PlobeAmmo,0,0,0,0,0,0,0, 99,0,0,0,0);

//--------------------------------------
RocketData PlobeShell
{
   bulletShapeName = "paint.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 5.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $PlobeDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 500.0;

   muzzleVelocity   = 25.0;
   terminalVelocity = 50.0;
   acceleration     = 1.0;

   totalTime        = 8.0;
   liveTime         = 10.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "paint.dts";
   smokeDist   = 1.5;

   soundId = SoundShieldOn;
};

//--------------------------------------

BulletData PlobeBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = greenExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $PlobeDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 100.0;
   totalTime          = 8.0;
   liveTime           = 10.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//----------------------------------------------------------------------------

ItemData PlobeAmmo
{
        description = "Plobes";
        className = "Ammo";
        shapeFile = "plasammo";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 90;
};

ItemImageData PLCylImage
{
        shapeFile = "liqcyl";
        mountPoint = 0;
        mountOffset = { 0, -0.2, 0.1 }; //-  left-right, back-front, up-down
        mountRotation = { -1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PLCyl
{
        description = "Plobe Launcher";
        className = "Tool";
        shapeFile = "liqcyl";
        shadowDetailMask = 4;
        imageType = PLCylImage;
        showWeaponBar = false;
        showInventory = false;
};

ItemImageData PlobeLauncherImage
{
        shapeFile = "mortargun";
        mountPoint = 0;

        weaponType = 3; // DiscLauncher
        ammoType = PlobeAmmo;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 2.0;

        sfxFire = bigExplosion1;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMissileTurretOn;
};

ItemData PlobeLauncher
{
        description = "Plobe Launcher";
        className = "Tool";
        shapeFile = "liqcyl";
        hudIcon = "ammopack";
   heading = $InvCatTools;
        shadowDetailMask = 4;
        imageType = PlobeLauncherImage;
        price = 9000;
        showWeaponBar = true;
};

function PlobeLauncher::onMount(%player,%item)
{
        Player::mountItem(%player, PLCyl, $ExtraSlotA);
}

function PlobeLauncher::onUnmount(%player,%item)
{
        Player::unmountItem(%player, $ExtraSlotA);
}

function PlobeLauncherImage::onFire(%player, %slot)
{
        Player::decItemCount(%player,$WeaponAmmo[PlobeLauncher],1);
//        %trans = GameBase::getMuzzleTransform(%player);
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        %randType = floor(getRandom() * 10);
        if(%randType > 4)
                Projectile::spawnProjectile("PlobeShell",%trans,%player,%vel);
        else {
                %randPNum = floor(getRandom() * 50) + 1;
                for(%randPNum; %randPNum > 0; %randPNum--)
                        Projectile::spawnProjectile("PlobeBolt",%trans,%player,%vel);
        }
}

$PlobeDesc = "<JC><F2>Plobe Launcher <F0>- <F1>Launches an almighty Plobe at the poor soul in your cross hair.\n";
$MountMSG[PlobeLauncher] = $PlobeDesc@"<JC><F0>The word Plobe is property of ThunderSloth.";

AddWeapon(PlobeLauncher);

//--------------------------------------
