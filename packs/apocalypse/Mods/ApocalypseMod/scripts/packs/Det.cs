//--------------------------------------

addToInv(DetPack,1,1);

setArmorItemMax(DetPack,0,0,0,0,1,0,1, 0, 0,0,0,0);

//--------------------------------------

ItemImageData DetPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;   // Energy/sec for sustained weapons
        sfxFire = SoundPackFail;
        firstPerson = false;
};

ItemData DetPack
{
        description = "Detonation Bomb";
        shapeFile = "magcargo";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = DetPackImage;
        price = 200;
        hudIcon = "backpack";
        showWeaponBar = true;
        hiliteOnActive = true;
   validateShape = true;
   //validateMaterials = true;
};

$MountMSG[DetPack] = "<JC><F2>Detonation Bomb <F0>- <F1>Once placed this bomb will cuasae mass devastation.";

function DetPackImage::onActivate(%player,%imageSlot)
{
        Player::decItemCount(%player,Player::getMountedItem(%player,%imageSlot));
        %client = Player::getClient(%player);
        %obj = newObject("","Mine","DetPackBomb");
        addToSet("MissionCleanup", %obj);
        Client::sendMessage(%client,1,"Detonation Bomb with destruct in 10 seconds.");
        GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
        %player.throwTime = getSimTime() + 0.5;
}
//--------------------------------------
