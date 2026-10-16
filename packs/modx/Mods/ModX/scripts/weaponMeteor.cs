$WeaponAmmo[MeteorStrike] = MeteorStrikeAmmo;

$MaxRange = 1000;
$MeteorRadius = 75;
$MeteorRadiusHeight = 100;
$MeteorInitHeight = 200;
$MeteorSpawnNum = 5;

addWeapon(MeteorStrike);

function give()
{
    Player::setItemCount(2049, "MeteorStrikeAmmo", 10);
    Player::setItemCount(2049, "MeteorStrike", 1);
}

LaserData meteorDesignateCharge
{
   laserBitmapName   = "paintpulse.bmp";

   damageConversion  = 0.000;
   baseDamageType    = $ElectricityDamageType;

   beamTime          = 0.2;

    lightType   = 3;  // Weapon Fire
    lightRadius = 2;
    lightTime   = 1;
    lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
};

ExplosionData MeteorOfDoomExp
{
	shapeName = "fiery.dts";
	soundId = rocketExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 25.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
};

ItemData MeteorStrikeAmmo
{
   description = "Meteor Strike Charge";
   className = "Ammo";
   shapeFile = "ammo1";
   heading = $InvHead[ihAmm];
   shadowDetailMask = 4;
   price = 1;
};

RocketData MeteorOfDoom
{
   bulletShapeName = "tracer.dts";
   explosionTag = MeteorOfDoomExp;
   collisionRadius = 0.0;
   mass = 2.0;
   damageClass = 1;
   damageValue = 1.25;
   DamageType = $MissileDamageType;
   explosionRadius = 25.0;
   kickBackStrength = 450.0;
   muzzleVelocity = 80.0;
   terminalVelocity = 80.0;
   acceleration = 5.0;
   totalTime = 15.0;
   liveTime = 15.0;
   lightRange = 10.0;
   lightColor = { 1.0, 6.7, 9.5 };
   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "fiery.dts";
   smokeDist = 1.8;
   soundId = SoundJetHeavy;
};

ItemImageData MeteorStrikeImage
{
   shapeFile = "force";
   mountPoint = 0;
   mountRotation = { 1.57, 0.0, 3.14 };
   mountOffset = { 0.1, 0.13, 0.2 };
   weaponType = 0;
   //projectileType = SniperBullet;
   ammoType = MeteorStrikeAmmo;
   accuFire = true;
   fireTime = 1.50;
   reloadTime = 0;
   sfxFire = SoundPackUse;
   sfxActivate = SoundPickUpWeapon;
};

ItemData MeteorStrike
{
   description = "Meteor Strike Designator";
   className = "Weapon";
   shapeFile = "sniper";
   hudIcon = "sniper";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = MeteorStrikeImage;
   price = 4500;
   showWeaponBar = true;
};

ItemImageData MeteorStrike_Extra1Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0.1, 0.0, 0.2 };
	mountRotation = {2.79, 0.0, 0.0};
	weaponType = 0;
};

ItemData MeteorStrike_Extra1
{
	description = "--";
	className = "Weapon";
	shapeFile = "paintgun";
	//hudIcon = "sniper";
	heading = "zInvalid";
	shadowDetailMask = 4;
	imageType = MeteorStrike_Extra1Image;
	price = 0;
	showWeaponBar = false;
};

ItemImageData MeteorStrike_Extra2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0.1, 0.0, 0.2 };
	mountRotation = {3.275, 3.14, 0.0};
	weaponType = 0;
};

ItemData MeteorStrike_Extra2
{
	description = "--";
	className = "Weapon";
	shapeFile = "paintgun";
	//hudIcon = "sniper";
	heading = "zInvalid";
	shadowDetailMask = 4;
	imageType = MeteorStrike_Extra2Image;
	price = 0;
	showWeaponBar = false;
};

function MeteorStrike::MountExtras(%player)
{
	Player::mountItem(%player,MeteorStrike_Extra1,7);
    Player::mountItem(%player,MeteorStrike_Extra2,6);
}

function MeteorStrike::onUnmount(%player,%item)
{
	Player::unmountItem(%player,7);
    Player::unmountItem(%player,6);
}

function MeteorStrike::onMount(%player,%item)
{
   if($debug)
      echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

   %clientId = Player::getclient(%player);
   if(%clientId.weaponHelp)
      bottomprint(%clientId, "<jc>Meteor Strike Designator: <f2>Paints a target for a massive bombardment of meteors.");
      
   Weapon::CompleteMount(%player,%item);
}

function MeteorStrikeImage::onFire(%player, %slot)
{
    if (GameBase::getLOSInfo(%player, $maxRange))
    {
        %trans = GameBase::getMuzzleTransform(%player);
        Projectile::spawnProjectile("meteorDesignateCharge",%trans,%player,"0 0 0");
        playSound(SoundMineActivate, GameBase::getMuzzlePosition(%player));

        for(%i = 0; %i <= $MeteorSpawnNum; %i++)
        {
            %randX = Math::randomInt($MeteorRadius) - $MeteorRadius / 2;
            %randY = Math::randomInt($MeteorRadius) - $MeteorRadius / 2;
            %randZ = Math::randomInt($MeteorRadiusHeight) + $MeteorInitHeight;
            %pos = Vector::add($los::position, %randX @ " " @ %randY @ " " @ %randZ);
            Projectile::spawnProjectile(MeteorOfDoom,"1 0 0 0 0 -1 0 1 0 " @ %pos, %player, "0 0 0");
        }

        Player::decItemCount(%player, "MeteorStrikeAmmo", 1);
        if(Player::getItemCount(%player, "MeteorStrikeAmmo") == 0)
        {
            Client::sendMessage(Player::getClient(%player), 1, "Your designator charge supply has been depleted!");
            playSound(SoundMortarTurretOff, GameBase::getMuzzlePosition(%player));
            return;
        }
    }
    else
        Client::sendMessage(Player::getClient(%player), 1, "Designator signal too far, out of range.");
}

function GameBase::getMuzzlePosition(%player)
{
    %trans = GameBase::getMuzzleTransform(%player);
    %vec6 = getWord(%trans,9);
    %vec7 = getWord(%trans,10);
    %vec8 = getWord(%trans,11);
    return %vec6@" "@%vec7@" "@%vec8;
}

function Math::randomInt(%max)
{
    return floor(getRandom() * (%max - 0.01));
}
