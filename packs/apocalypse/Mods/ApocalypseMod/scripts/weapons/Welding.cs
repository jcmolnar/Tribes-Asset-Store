//--------------------------------------

$AutoUse[WeldingGun] = True;
$WeaponAmmo[WeldingGun] = "";

addToInv(WeldingGun,1,1);

setArmorItemMax(WeldingGun,0,0,0,0,1,0,0, 1, 0,0,0,0);

//--------------------------------------

RepairEffectData WeldingBolt
{
   bitmapName       = "repairadd.bmp";
//   bitmapName       = "rtrail2.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function WeldingBolt::onAcquire(%this, %player, %target)
{
        %client = Player::getClient(%player);

        %pack = Player::getMountedItem(%player,$BackpackSlot);
        if (%target == %player) {
                %player.repairTarget = -1;
                if (GameBase::getDamageLevel(%player) != 0) {
                        %player.repairRate = 0.05;
                        if(%pack == PerGenPack)
                                %player.repairRate = 0.025; //slowed down becuase of unlimited energy
                        %player.repairTarget = %player;
                        Client::sendMessage(%client, 0, "AutoWelding On");
                }
                else {
                        Client::sendMessage(%client,0,"Nothing in range");
                        Player::trigger(%player, $WeaponSlot, false);
                        return;
                }
        }
        else {
                %player.repairTarget = %target;
                %player.repairRate   = 0.1;
                if(%pack == PerGenPack)
                        %player.repairRate = 0.05; //slowed down becuase of unlimited energy
                if (getObjectType(%player.repairTarget) == "Player") {
                        %rclient = Player::getClient(%player.repairTarget);
                        %name = Client::getName(%rclient);
                }
                else {
                        %name = GameBase::getMapName(%target);
                        if(%name == "") {
                                %name = (GameBase::getDataName(%player.repairTarget)).description;
                        }
                }
                if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
                        Client::sendMessage(%client,0,%name @ " is not damaged");
                        Player::trigger(%player,$WeaponSlot,false);
                        %player.repairTarget = -1;
                        return;
                }
                if (getObjectType(%player.repairTarget) == "Player") {
                        Client::sendMessage(%rclient,0,"Being Welded by " @ Client::getName(%client));
                }
                Client::sendMessage(%client,0,"Welding " @ %name);
        }
        %rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
        GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function WeldingBolt::onRelease(%this, %player)
{
        %object = %player.repairTarget;
        if (%object != -1) {
                %client = Player::getClient(%player);
                if (%object == %player) {
                        Client::sendMessage(%client,0,"AutoWelding Off");
                }
                else {
                        if (GameBase::getDamageLevel(%object) == 0) {
                                Client::sendMessage(%client,0,"Welding Done");
                        }
                        else {
                                Client::sendMessage(%client,0,"Welding Stopped");
                        }
                }
                %rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;

                GameBase::setAutoRepairRate(%object,%rate);
        }
}

function WeldingBolt::checkDone(%this, %player)
{
        if (Player::isTriggered(%player,$WeaponSlot) &&
       Player::getMountedItem(%player,$WeaponSlot) == WeldingGun &&
                 %player.repairTarget != -1) {
                %object = %player.repairTarget;
                if (%object == %player) {
                        if (GameBase::getDamageLevel(%player) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
                else {
                        if (GameBase::getDamageLevel(%object) == 0) {
                                Player::trigger(%player,$WeaponSlot,false);
                                return;
                        }
                }
        }
}

//--------------------------------------

ItemImageData WeldingGunImage
{
        shapeFile = "repairgun";
        mountPoint = 0;

        weaponType = 2;  // Sustained
        projectileType = WeldingBolt;
        minEnergy  = 8;
        maxEnergy = 20;  // Energy used/sec for sustained weapons

        lightType   = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime   = 1;
        lightColor  = { 0.25, 1, 0.25 };

        sfxActivate = SoundPickUpWeapon;
        sfxFire = SoundRepairItem;
};

ItemData WeldingGun
{
        description = "Welding Torch";
        shapeFile = "repairgun";
        hudIcon       = "repairpack";
        className = "Tool";
        heading = $InvCatTools;
        shadowDetailMask = 4;
        imageType = WeldingGunImage;
        price = 300;
        showWeaponBar = false;
   validateShape = true;
};

$MountMSG[WeldingGun] = "<JC><F2>Welding Torch <F0>- <F1>repairs items at a slightly slow rate the a repair pack.";

AddWeapon(WeldingGun);
