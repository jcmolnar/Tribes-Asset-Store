//======================================================
//Normal Punch Bullet
//======================================================
BulletData PunchBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = smokeExp1;
   mass               = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PhysicalDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 25.0;
   totalTime          = 0.075;
   inheritedVelocityScale = 1.0;
   isVisible          = false;
};

function Normal::Punch(%player,%object)
{
        if(Player::getItemState(%player,$WeaponSlot) == "Fire")
                return;
        if(TeamCompare(%player,%object) == Same)
                return;
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        Projectile::spawnProjectile("PunchBullet",%trans,%player,%vel);
}

//======================================================
//Saiyan Punch Bullet
//Wanted different look for the exp so needed new bullet
//======================================================
BulletData SPunchBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave2;
   mass               = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PhysicalDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 25.0;
   totalTime          = 0.075;
   inheritedVelocityScale = 1.0;
   isVisible          = false;
};

function Saiyan::Punch(%player,%object)
{
        if(Player::getItemState(%player,$WeaponSlot) == "Fire")
                return;
        if(TeamCompare(%player,%object) == Same)
                return;
        %trans = getPerfectTrans(%player);
        %vel = Item::getVelocity(%player);
        Projectile::spawnProjectile("SPunchBullet",%trans,%player,%vel);
}
