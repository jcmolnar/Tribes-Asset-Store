//Tractor Beam coded by Creeperman
//--------------------------------------

$AutoUse[TractorBeam] = True;
$WeaponAmmo[TractorBeam] = "";

addToInv(TractorBeam,1,1);

setArmorItemMax(TractorBeam,1,1,1,1,1,1,1, 1, 0,0,0,0);

//--------------------------------------
LightningData tractorCharge
{
   bitmapName = "lightningNew.bmp";

   boltLength = 200.0;
   coneAngle = 50.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 1;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function tractorCharge::pull(%client, %target)
{
        %pack = Player::getMountedItem(%client,$BackpackSlot);
        %myPos = GameBase::getPosition(%client);
        %yourPos = GameBase::getPosition(%target);
        %myRot = GameBase::getRotation(%client);

        %dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
        //make dir face opposite direction, thus pulls toward

        %myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
        %yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0";
        %dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
        //so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference

        if(%pack == PerGenPack) {
                %force = 5; //slowed down becuase of unlimited energy

                %height = 2.5 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //slowed down becuase of unlimited energy
        }
        else {
                %force = 20; //not too hard and fast

                %height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values
        }

        %diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force));

        if(%client.tractorMode == 1)
                %diffVector = Item::getVelocity(%target);

        Item::setVelocity(%client, %diffVector); //the actual movement function
}

function tractorCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
        //if(%target.shieldStrength > 0 || GameBase::getDataName(%target).className == "HandAmmo") {
        //        return;
        //}
        //else {
                tractorCharge::pull(%shooterID,%target);
        //}
}

//----------------------------------------------------------------------------
ItemImageData TractorBeamImage
{
        shapeFile = "disc";
        mountPoint = 0;
        mountRotation = { 0,3.14, 0 };

        weaponType = 2;
        projectileType = tractorCharge;
        minEnergy = 8;
        maxEnergy = 20;
        reloadTime = 0.2;

   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData TractorBeam
{
        description = "Grappler Beam";
        shapeFile = "disc";
        hudIcon       = "energyRifle";
        className = "Tool";
        heading = $InvCatTools;
        shadowDetailMask = 4;
        imageType = TractorBeamImage;
        showWeaponBar = true;
        price = 150;
        showWeaponBar = false;
};

$MountMSG[TractorBeam] = "<JC><F2>Grappler Beam <F0>- <F1>Pulls you toward almost any object.";

AddWeapon(TractorBeam);
