//--------------------------------------

$AutoUse[Lightning] = True;
$WeaponAmmo[Lightning] = "";

//--------------------------------------

$InvList[Lightning] = 1;
$RemoteInvList[Lightning] = 1;

//--------------------------------------

ItemImageData LightningImage
{
	shapeFile = "enbolt";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = PsylightningCharge;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;

   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Lightning
{
   description = "Lightning";
	shapeFile = "force";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "dPowers";
   shadowDetailMask = 4;
   imageType = LightningImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

//--------------------------------------
function Lightning::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Lightning: <f2>Drain the health and energy of your target at the same time!");
}
