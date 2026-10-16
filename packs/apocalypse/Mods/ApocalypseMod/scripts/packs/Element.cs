$FireModes[ElementPack] = 4;
//--------------------------------------

addToInv(ElementPack,1,1);

setArmorItemMax(ElementPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

//--------------------------------------

ItemImageData ElementPack2Image
{
        shapeFile = "sensor_small";
        mountPoint = 2;
        weaponType = 2;  // Sustained
//        mountOffset = { 0, 0, -0.1 };
        mountRotation = { 3.14, 0, 0 };
        minEnergy = 4;
        maxEnergy = 9;   // Energy/sec for sustained weapons
        sfxFire = SoundShieldOn;
        firstPerson = false;
};

ItemData ElementPack2
{
        description = "Elemental Barrier";
        shapeFile = "sensor_small";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = ElementPack2Image;
        price = 225;
        hudIcon = "shieldpack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;
};

ItemImageData ElementPackImage
{
        shapeFile = "sensor_small";
        mountPoint = 2;
        weaponType = 2;  // Sustained
//        mountOffset = { 0, 0, 0.1 };
        minEnergy = 4;
        maxEnergy = 9;   // Energy/sec for sustained weapons
        sfxFire = SoundShieldOn;
        firstPerson = false;
};

ItemData ElementPack
{
        description = "Elemental Barrier";
        shapeFile = "sensor_small";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = ElementPackImage;
        price = 225;
        hudIcon = "shieldpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

$MountMSG[ElementPack,1] = "<JC><F2>Fire Elemental Barrier <F0>- <F1>Protects user from fire based damage.";
$MountMSG[ElementPack,2] = "<JC><F2>Wind Elemental Barrier <F0>- <F1>Protects user from wind based damage.";
$MountMSG[ElementPack,3] = "<JC><F2>Earth Elemental Barrier <F0>- <F1>Protects user from earth based damage.";
$MountMSG[ElementPack,4] = "<JC><F2> Electric Elemental Barrier <F0>- <F1>Protects user from electrical based damage.";

function ElementPack::onMount(%player,%item)
{
        Player::mountItem(%player,ElementPack2,$ExtraSlotC);
}

function ElementPack::onUnmount(%player,%item)
{
        Player::unMountItem(%player,$ExtraSlotC);
}

function ElementPackImage::onActivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        Client::sendMessage(Player::getClient(%player),0,"Elemental Barrier On");
        %player.elementStrength = 0.024;
        %player.Elemental = true;
        if($WeapMode[%client,ElementPack] == 1 || $WeapMode[%client,ElementPack] == "") {
                $Element[%player] = $PlasmaDamageType;
                animateElement::Fire(%player);
        }
        else if($WeapMode[%client,ElementPack] == 2) {
                $Element[%player] = $StormDamageType;
                animateElement::Wind(%player);
        }
        else if($WeapMode[%client,ElementPack] == 3) {
                $Element[%player] = $ImpactDamageType;
                animateElement::Earth(%player);
        }
        else if($WeapMode[%client,ElementPack] >= $FireModes[ElementPack]) {
                $Element[%player] = $ElectricityDamageType;
                animateElement::Electricty(%player);
        }
}

function ElementPackImage::onDeactivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        if(%player.Elemental) {
                Client::sendMessage(Player::getClient(%player),0,"Elemental Barrier Off");
                $Element[%player] = "";
                %player.elementStrength = 0;
                %player.Elemental = false;
                Player::trigger(%player,$BackpackSlot,false);
        }
}

//-------------------------------------

function animateElement::Fire(%player)
{
        if(%player.Elemental == true) {
                %trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile("FireEffectBomb", %trans, %player, %vel);
                schedule("animateElement::Fire(" @ %player @ ");",0.1);
        }
}

function animateElement::Wind(%player)
{
        if(%player.Elemental == true) {
                %obj = newObject("","Mine","ShockwaveEffectBomb");
                addToSet("MissionCleanup", %obj);
                GameBase::setPosition(%obj, GameBase::getPosition(%player));
                schedule("animateElement::Wind(" @ %player @ ");",0.5);
        }
}

function animateElement::Earth(%player)
{
        if(%player.Elemental == true) {
                %trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile("DustEffectBomb", %trans, %player, %vel);
                schedule("animateElement::Earth(" @ %player @ ");",0.1);
        }
}

function animateElement::Electricty(%player)
{
        if(%player.Elemental == true) {
                %trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
                %vel = Item::getVelocity(%player);
                Projectile::spawnProjectile("EmpEffectBomb", %trans, %player, %vel);
                schedule("animateElement::Electricty(" @ %player @ ");",0.1);
        }
}
