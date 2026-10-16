//========================================================
//Kuroi's custom made weapon
//========================================================
//+++++++++++++++++++++++++++++++++++++++
$AutoUse[Mechgun] = True;
//addAmmo(Mechgun,MechgunAmmo,6,6);

addToInv(Mechgun,1,1);
//addToInv(MechgunAmmo,1,1);

setArmorItemMax(Mechgun,0,0,0,0,0,0,0, 1, 0,0,0,0);
//setArmorItemMax(MechgunAmmo,0,0,0,0,0,0,0, 99, 0,0,0,0);


BulletData Mech
{
        bulletShapeName = "discb.dts";
        explosionTag = flashExpLarge;
        mass = 0.10;
        bulletHoleIndex = 0;
        damageClass = 0;
        damageValue = 0.055;
        damageType = $BulletDamageType;
        aimDeflection = 0.005;
        muzzleVelocity = 300.0;
        totalTime = 1.0;
        inheritedVelocityScale = 1.0;
        isVisible = True;
        tracerPercentage = 3.0;
        tracerLength = 150;
        rotationperiod = -1;
};

BulletData Mech2
{
        bulletShapeName = "discb.dts";
        explosionTag = flashExpLarge;
        mass = 0.10;
        bulletHoleIndex = 0;
        damageClass = 0;
        damageValue = 0.055;
        damageType = $BulletDamageType;
        aimDeflection = 0.005;
        muzzleVelocity = 300.0;
        totalTime = 1.0;
        inheritedVelocityScale = 1.0;
        isVisible = True;
        tracerPercentage = 3.0;
        tracerLength = 150;
        rotationperiod = 1;
};

//++++++++++++++++++++++++++++++++++++++

SoundData SoundMechgun
{       wavFileName = "access_denied.wav";
        profile = Profile3dMedium;
};

$MechgunSlotA=4;
$MechgunSlotB=7;
$MechgunSlotC=6;

ItemData MechgunAmmo
{
        description = "Mechgun Ammo";
        className = "Ammo";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 1;
};

ItemImageData MechgunImage
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountOffset = { -0.3, 0, 0 };
        mountRotation = { 0, 0, 0 };
        weaponType = 1;
        minEnergy = 1;
        maxEnergy = 2;
        reloadTime = 0;
        spinUpTime = 0.1;
        spinDownTime = 3;
        fireTime = 0.1;
        accuFire = true;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData Mechgun
{
        description = "Mechgun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
        heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = MechgunImage;
        price = 7500;
        showWeaponBar = true;
};


ItemImageData Mechgun2Image
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountOffset = { -0.5, 0, 0 };
        mountRotation = { 0, 0, 0};
        weaponType = 1;
        reloadTime = 0;
        spinUpTime = 0.1;
        spinDownTime = 3;
        fireTime = 0.1;
        projectileType = Mech2;
        accuFire = true;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData Mechgun2
{
        description = "Mechgun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
        shadowDetailMask = 4;
        imageType = Mechgun2Image;
        price = 0;
        showWeaponBar = false;
        showInventory = false;
};

ItemImageData Mechgun3Image
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountOffset = { -0.7, 0, 0 };
        mountRotation = { 0, 0, 0 };
        weaponType = 1;
        reloadTime = 0;
        spinUpTime = 0.1;
        spinDownTime = 3;
        fireTime = 0.1;
        projectileType = Mech;
        accuFire = true;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData Mechgun3
{
        description = "Mechgun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
        shadowDetailMask = 4;
        imageType = Mechgun3Image;
        price = 0;
        showWeaponBar = false;
        showInventory = false;
};
ItemImageData Mechgun4Image
{
        shapeFile = "chaingun";
        mountPoint = 0;
        mountOffset = {-0.9, 0, 0 };
        mountRotation = { 0, 0, 0};
        weaponType = 1;
        reloadTime = 0;
        spinUpTime = 0.1;
        spinDownTime = 3;
        fireTime = 0.1;
        projectileType = Mech;
        accuFire = true;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData Mechgun4
{
        description = "Mechgun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
        shadowDetailMask = 4;
        imageType = Mechgun4Image;
        price = 0;
        showWeaponBar = false;
        showInventory = false;
};

function MechgunImage::onFire(%player, %slot)
{
        //if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));
        //MechgunImage::spawnProjectile(%player);
        %client = GameBase::getOwnerClient(%player);
        //%player.firingMechgun = true;
        //schedule("MechgunImage::spawnProjectile(" @ %player @ ");",1);
        //Player::decItemCount(%player,$WeaponAmmo[Mechgun],1);
        %trans = GameBase::getMuzzleTransform(%player);
        %vel = Item::getVelocity(%player);
        Projectile::spawnProjectile("Mech",%trans,%player,%vel,%player);
        if(!$FiringMechgun[%client])
                CheckMechgun(%client, %player);
}

function MechgunImage::spawnProjectile(%player)
{
        %client = GameBase::getOwnerClient(%player);
        if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Mechgun"))
        {
                //Player::decItemCount(%player,$WeaponAmmo[Mechgun],1);
                %trans = GameBase::getMuzzleTransform(%player);
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile("Mech",%trans,%player,%vel,%player);
        }
}

function Mechgun::onDrop(%player,%item)
{
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state != "Fire" && %state != "Reload")
        {
                Player::setItemCount(%player, Mechgun2, 0);
                Item::onDrop(%player,%item);
        }
}

function Mechgun::onMount(%player,%item)
{
        //if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
        Player::mountItem(%player,Mechgun2,$MechgunSlotA);
        Player::mountItem(%player,Mechgun3,$MechgunSlotB);
        Player::mountItem(%player,Mechgun4,$MechgunSlotC);
        %clientId = Player::getclient(%player);
//                bottomprint(%clientId, "<jc><f2>Mechgun: You don't want to get in the way of this quad chaingun!");
}

function Mechgun::onUnmount(%player,%imageSlot)
{
        Player::unmountItem(%player,$MechgunSlotA);
        Player::unmountItem(%player,$MechgunSlotB);
        Player::unmountItem(%player,$MechgunSlotC);
}

function CheckMechgun(%client, %player)
{
        if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Mechgun"))
        {
                Player::trigger(%player,$MechgunSlotA,true);
                Player::trigger(%player,$MechgunSlotB,true);
                Player::trigger(%player,$MechgunSlotC,true);
                schedule("CheckMechgun(" @ %client @ "," @ %player @ ");",0.1);
                $FiringMechgun[%client] = true;
        }
        else
        {
                Player::trigger(%player,$MechgunSlotA,false);
                Player::trigger(%player,$MechgunSlotB,false);
                Player::trigger(%player,$MechgunSlotC,false);
                $FiringMechgun[%client] = false;
        }
}

$MountMSG[Mechgun] = "<JC><F2>Kuroi Mechgun <F0>- <F1>You don't want to get in the way of this quad chaingun!";

AddWeapon(Mechgun);

//--------------------------------------

//$AutoUse[Kuroigun] = True;
//addAmmo(Kuroigun,KuroiAmmo,6,6);

//addToInv(Kuroigun,1,1);
//addToInv(KuroiAmmo,1,1);

//setArmorItemMax(Kuroigun,0,0,0,0,0,0,0, 1, 0,0,0,0);
//setArmorItemMax(KuroiAmmo,0,0,0,0,0,0,0, 99, 0,0,0,0);

//--------------------------------------
RocketData KurioBurst
{
   bulletShapeName  = "enbolt.dts";
   explosionTag     = turretExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $EnergyDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;
   muzzleVelocity   = 400.0;
   terminalVelocity = 500.0;
   acceleration     = 50.0;
   totalTime        = 10.0;
   liveTime         = 10.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//----------------------------------------------------------------------------

ItemData KuroiAmmo
{
        description = "Burst Round";
   heading = $InvCatAmmo;
        className = "Ammo";
        shapeFile = "force";
        shadowDetailMask = 4;
        price = 6;
};

ItemImageData KuroigunImage
{
        shapeFile = "sniper";
        mountPoint = 0;
//        mountRotation = { 0,3.14, 0 };

        weaponType = 0; // Single Shot
        ammoType = KuroiAmmo;
        projectileType = KurioBurst;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 0.25;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 1, 1, 0.2 };

        sfxFire = ricochet2;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDryFire;
};

ItemData Kuroigun
{
        description = "Kuroi Burst Rifle";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "blaster";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = KuroigunImage;
        price = 300;
        showWeaponBar = true;
};

$MountMSG[Kuroigun] = "<JC><F2>Kuroi Burst Rifle <F0>- <F1>Fires a small at high velocity that rocket.";

//AddWeapon(Kuroigun);

//========================================================
//Ozzy's custom made weapon
//========================================================

//========================================================
//CrshMan's custom made weapon
//========================================================
//--------------------------------------

addAmmo(CrshLauncher,CrshAmmo,5,15);

addToInv(CrshLauncher,1,1);
addToInv(CrshAmmo,1,1);

setArmorItemMax(CrshLauncher,0,0,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(CrshAmmo,0,0,0,0,0,0,0, 99, 0,0,0,0, 0,0,0,0);

//--------------------------------------
BulletData CrushBullet
{
   bulletShapeName    = "cube4.dts";
   validateShape = true;
   explosionTag       = rocketExp;
   mass               = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $CrushDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 0.25;
   isVisible          = true;

};

//--------------------------------------

ItemData CrshAmmo
{
        description = "Crash Bricks";
        className = "Ammo";
        shapeFile = "magcargo";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 2;
};

ItemImageData CrshLauncherImage
{
        shapeFile = "mortargun";
        mountPoint = 0;

        weaponType = 3; // DiscLauncher
        ammoType = CrshAmmo;
        projectileType = CrushBullet;
        accuFire = true;
        reloadTime = 0.25;
        fireTime = 1.25;
        spinUpTime = 0.25;

        sfxFire = SoundFireDisc;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundDiscReload;
        sfxReady = SoundDiscSpin;
};

ItemData CrshLauncher
{
        description = "Crash Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "disk";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = CrshLauncherImage;
        price = 150;
        showWeaponBar = true;
};

$MountMSG[CrshLauncher] = "<JC><F2>Crash Cannon <F0>- <F1>Crushing projectiles at helpless victims.";

AddWeapon(CrshLauncher);

//========================================================
//Kick's custom made weapon
//========================================================

//========================================================
//Ice's custom made weapon
//========================================================
//--------------------------------------

$AutoUse[Icegun] = True;
addAmmo(Icegun,BulletAmmo,25,150);

addToInv(Icegun,1,1);
addToInv(BulletAmmo,1,1);

setArmorItemMax(Icegun,0,1,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(BulletAmmo,100,125,175,200,225,250,275, 300, 0,0,0,0);

//--------------------------------------

BulletData IcegunBullet
{
   bulletShapeName    = "rsmoke.dts";
   validateShape      = true;
   explosionTag       = smokeExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $FrostDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 125.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

};

//----------------------------------------------------------------------------

ItemData IceAmmo
{
        description = "Ice";
        className = "Ammo";
        shapeFile = "ammo1";
   heading = $InvCatAmmo;
        shadowDetailMask = 4;
        price = 1;
};

//--------------------------------------

ItemImageData IcegunImage
{
        shapeFile = "chaingun";
        mountPoint = 0;

        weaponType = 1; // Spinning
        reloadTime = 0;
        spinUpTime = 0.5;
        spinDownTime = 3;
        fireTime = 0.1;

        ammoType = IceAmmo;
        projectileType = IcegunBullet;
        accuFire = false;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1 };

        sfxFire = SoundFireChaingun;
        sfxActivate = SoundPickUpWeapon;
        sfxSpinUp = SoundSpinUp;
        sfxSpinDown = SoundSpinDown;
};

ItemData Icegun
{
        description = "Ice Gun";
        className = "Weapon";
        shapeFile = "chaingun";
   validateShape = true;
        hudIcon = "chain";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = IcegunImage;
        price = 150;
        showWeaponBar = true;
};

$MountMSG[Icegun] = "<JC><F2>Ice Gun <F0>- <F1>Generate a frosty breeze from this gun.";

AddWeapon(Icegun);
//========================================================
//Tart Loaf's custom made weapon
//========================================================

//========================================================
//Thunder Sloth's custom made weapon
//========================================================

//========================================================
//Sym's custom made weapon
//========================================================

