$InvList[RocketLauncher] = 1;
$MobileInvList[RocketLauncher] = 1;
$RemoteInvList[RocketLauncher] = 1;

$InvList[RocketAmmo] = 1;
$MobileInvList[RocketAmmo] = 1;
$RemoteInvList[RocketAmmo] = 1;

$AutoUse[RocketLauncher] = false;
$SellAmmo[RocketAmmo] = 50;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 50);

ItemData RocketAmmo 
{
	description = "Salvo Rockets";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
   shapeFile = "grenadeL"; 
   mountPoint = 0;   
   mountRotation = { 0, 0.785, 0 }; 
   weaponType = 0; 
   ammoType = RocketAmmo; 
   //projectileType = ThisShouldBeUndefined; 
   accuFire = true; 
   reloadTime = 1.5; 
   fireTime = 0.8; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 1, 1, 1 }; 
   //sfxFire = SoundSalvoLaunch; 
   sfxActivate = SoundMortarTurretTurn; 
   sfxReload = SoundMortarTurretOn;
   sfxReady = SoundMineActivate; 
};

ItemData RocketLauncher 
{
	description = "PayLoad Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};


function RocketLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>PayLoad Launcher: <f2>Mounted");
}

function RocketImage::onFire(%player, %slot) 
{ 
	GameBase::playSound(%player, SoundSalvoLaunch, 0);
	schedule("RocketLauncher::fireRockets(" @ %player @ ",3);",0.05,%player);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.05);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.10);
}

function RocketLauncher::fireRockets(%player,%count)
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
   if(%AmmoCount) 
	{
   	   %client = GameBase::getControlClient(%player);
   	   if(Player::getItemCount(%player,RocketAmmo)) 
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("SalvoRocket",%trans,%player,%vel);  
		%count--;
		}
	   if(%count && Player::getItemCount(%player,RocketAmmo))
	   schedule("RocketLauncher::fireRockets(" @ %player @ "," @ %count @ ");",0.2,%player);
	   Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
	} 
   else Client::sendMessage(Player::getClient(%player), 1,"***Out of Rockets***.~wAccess_Denied.wav");
}