//--------------------------------------

$AutoUse[Nanite] = True;
addAmmo(Nanite,NaniteAmmo,25,50);

addToInv(Nanite,1,1);
addToInv(NaniteAmmo,1,1);

setArmorItemMax(Nanite,0,0,1,1,1,1,0, 1, 0,0,0,0);
setArmorItemMax(NaniteAmmo,0,0,150,200,350,250,0, 400, 0,0,0,0);

//--------------------------------------

GrenadeData NaniteShell
{
   bulletShapeName    = "plasammo.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $NaniteDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 175;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "paint.dts";
};

function NaniteShell::onRemove(%this)
{
         %client = $NaniteClient[%this];
         %client.nanReady = true;
}

//--------------------------------------

ItemData NaniteAmmo
{
        description = "Nanites";
        className = "Ammo";
   heading = $InvCatAmmo;
        shapeFile = "paint";
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData Nanite2Image
{
        shapeFile = "mortargun";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 0; // Single Shot
        accuFire = false;
        reloadTime = 0.0;
        fireTime = 0.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = bigExplosion1;
        sfxReload = SoundDryFire;
        sfxReady = SoundMortarIdle;
};

ItemData Nanite2
{
        description = "Nanite Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "mortar";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = Nanite2Image;
        price = 375;
        showWeaponBar = false;
        showinventory = false;
};

ItemImageData NaniteImage
{
        shapeFile  = "breath";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = NaniteAmmo;
        accuFire = false;
        reloadTime = 0.0;
        fireTime = 0.0;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxActivate = SoundPickUpWeapon;
};

ItemData Nanite
{
        description = "Nanite Cannon";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "mortar";
   heading = $InvCatWeapons[All];
        shadowDetailMask = 4;
        imageType = NaniteImage;
        price = 375;
        showWeaponBar = true;
};

function NaniteImage::onFire(%player, %slot)
{
        %client = Player::getClient(%player);
        if(%client.nanReady  == true || %client.nanReady == "") {
                if(!%player.ChrgOn && Player::getItemCount(%player,NaniteAmmo) > 0) {
                        %client.NanUse = 0;
                        %player.MaxNan = Player::getItemCount(%player,NaniteAmmo);
                        Nanite::Charge(%player,%player.MaxNan);
                }
        }
}

//charge coded by ProtoManX
function Nanite::Charge(%player,%ammo)
{
        %client = Player::getClient(%player);
        %state = Player::getItemState(%player,$WeaponSlot);
        if(%state == "Fire") {
                %player.ChrgOn = true;
                if(%ammo > 0) {
                        %ammo -= 1;
                        if(%ammo < 1)
                                %ammo = 1;
                        %client.NanUse += 1;
                }
                Player::setItemCount(%player,NaniteAmmo,%ammo);
                if(%client.NanUse > %player.MaxNan)
                        %client.NanUse = %player.MaxNan;
                Bottomprint(%client, "<JC><F1>Nanites loaded: <F2>" @ %client.NanUse,1);
                schedule("Nanite::Charge(" @ %player @ "," @ Player::getItemCount(%player,NaniteAmmo) @ ");",0.1);
        }
        else {
                %player.ChrgOn = false;
                %trans = GameBase::getMuzzleTransform(%player);
                //%trans = getPerfectTrans(%player);
                %vel = Item::getVelocity(%player);
                Player::trigger(%player,$ExtraSlotA,true);
                Player::trigger(%player,$ExtraSlotA,false);
                %naniteproj = Projectile::spawnProjectile("NaniteShell",%trans,%player,%vel);
                $NaniteClient[%naniteproj] = %client;
                %client.nanReady = false;
                if(%client.NanUse == %player.MaxNan)
                        Player::setItemCount(%player,NaniteAmmo,0);
        }
}

$MountMSG[Nanite] = "<JC><F2>Nanite Cannon <F0>- <F1>Lobs a canister of nanites that are able to distinguish between friend and foe.";

function Nanite::onMount(%player,%item)
{
        Player::mountItem(%player,Nanite2,$ExtraSlotA);
}

function Nanite::onUnMount(%player,%item)
{
        Player::unmountItem(%player,$ExtraSlotA);
}

AddWeapon(Nanite);
