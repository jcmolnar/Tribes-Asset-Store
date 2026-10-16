//--------------------------------------

addToInv(KamikazePack,1,1);

setArmorItemMax(KamikazePack,0,1,1,1,1,0,0, 0, 0,0,0,0);

//--------------------------------------

ItemImageData KamikazePackImage
{
        shapeFile = "plasammo";
        mountPoint = 2;
        mountOffset = { 0, 0.0, -0.1 };
        weaponType = 2;  // Sustained
        minEnergy = 0;
        maxEnergy = 0;   // Energy/sec for sustained weapons
        sfxFire = SoundPackFail;
        firstPerson = false;
};

ItemData KamikazePack
{
        description = "Kamikaze Pack";
        shapeFile = "plasammo";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = KamikazePackImage;
        price = 175;
        hudIcon = "plasma";
        showWeaponBar = true;
        hiliteOnActive = true;
   validateShape = true;
   //validateMaterials = true;
};

$MountMSG[KamikazePack] = "<JC><F2>Kamikaze Pack <F0>- <F1>Become the divine wind.";

function KamikazePackImage::onActivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        KamikazePlayer(%player, %client, Player::getMountedItem(%client,%imageSlot), $KamikazeDamageType);
}

function KamikazePlayer(%player, %shooter, %item, %type)
{
        Player::decItemCount(%player,%item);
        %client = Player::getClient(%player);
        %obj = newObject("","Mine","KamikazeBomb");
        addToSet("MissionCleanup", %obj);
        GameBase::throw(%obj,%player,1 * %client.throwStrength,false);
        %obj = newObject("","Mine","ShockwaveEffectBomb");
        addToSet("MissionCleanup", %obj);
        GameBase::throw(%obj,%player,1 * %client.throwStrength,false);
        %player.throwTime = getSimTime() + 0.5;
        %client.score--;
        Game::refreshClientScore(%playerId);
        Client::onKilled(%client,%shooter,%type);
        Player::blowUp(%player);
        Player::Kill(%player);
}
//--------------------------------------
