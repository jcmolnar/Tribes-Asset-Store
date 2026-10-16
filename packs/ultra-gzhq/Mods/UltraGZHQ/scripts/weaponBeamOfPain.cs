$InvList[BeamOfPain] = 1;
$MobileInvList[BeamOfPain] = 1;
$RemoteInvList[BeamOfPain] = 1;

$AutoUse[BeamOfPain] = false;

$WeaponAmmo[BeamOfPain] = "";

addWeapon(BeamOfPain);


ItemImageData BeamOfPainImage
{
	shapeFile = "shotgun";
  	 mountPoint = 0;
       mountoffset = { 0, 0, -0.2 };
       mountrotation = { 0, 3, 0 };
  	 weaponType = 2;  // Sustained
	projectileType = BeamOfPainProj;
   	minEnergy = 3;
   	maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.03;
                        

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFFire;
};

ItemData BeamOfPain 
{
	description = "Beam Of Pain";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "jetpack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BeamOfPainImage;
	price = 375;
	showWeaponBar = true;
};

function BeamOfPain::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Beam Of Pain: <f2>Mounted");
}

