$InvList[Stinger] = 1;
$MobileInvList[Stinger] = 1;
$RemoteInvList[Stinger] = 1;

$InvList[StingerAmmo] = 1;
$MobileInvList[StingerAmmo] = 1;
$RemoteInvList[StingerAmmo] = 1;

$AutoUse[Stinger] = false;
$WeaponAmmo[Stinger] = StingerAmmo;
$SellAmmo[StingerAmmo] = 5;

addweapon(Stinger);
addammo(Stinger, StingerAmmo, 2);

ItemData StingerAmmo
{
	description = "Stinger Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData StingerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0, -0.785, 0 };
	weaponType = 0; 
	reloadTime = 0.1; 
   	fireTime = 0.1; 

	ammoType = StingerAmmo;
	accuFire = true;

	sfxFire	= SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData Stinger
{
	heading = $InvHead[ihWea];
	description = "Stinger Missle";
	classname = "Weapon";
	shapeFile = "GrenadeL";
	hudIcon	= "sensorjamerpack";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 350;
	showWeaponBar = true;
};

function Stinger::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Stinger Missile: <f2>Mounted");
}

		
function StingerImage::onFire(%player,%slot)
{	
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));


	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Stinger]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   %gay = Client::getName(%cl);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($DiskerUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl = Player::GetClient(%target);	 
				%jam = CheckTargetJamming(%target);
				if(%jam == 1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
					Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,1,%tpos);
					
					if(%target)
					{	
						Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
						%name = Client::getName(%target);
						bottomprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>" @ %name, 10);
					}
				}
				else
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
					%name = Client::getName(%target);
					bottomprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,0,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
						Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
		
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,12,%tpos);
						%playername = Client::getName(%player);
						if(%target)
						{	
							Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
							%name = Client::getName(%target);
							bottomprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
						      Client::sendMessage(%client,0,"~wmine_act.wav");
						      Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
						%name = Client::getName(%target);
						bottomprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
					Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);	
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier") 
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
					%name = Client::getName(%targetId);	
                              bottomprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);
				}
				else if(%object == "Turret" || %object =="Sensor")
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
					
                              centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Stinger <f1>lock on you...");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);
				}
				else
  				{
				
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
		
			}

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"Stinger has no ammo ~waccess_denied.wav");
}		
