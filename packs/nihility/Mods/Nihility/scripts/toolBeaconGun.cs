//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(BeaconGun);

$InvList[BeaconGun] = 1;
$InvList[BeaconAmmo] = 1;

$AutoUse[BeaconGun] = True;
$WeaponAmmo[BeaconGun] = BeaconAmmo;
$TeamItemMax[BeaconAmmo] = 15;
$SellAmmo[BeaconAmmo] = 15;

$ItemMax[larmor, BeaconGun] = 0;	//Seraph
$ItemMax[lfemale, BeaconGun] = 0;	//Seraph
$ItemMax[earmor, BeaconGun] = 1;	//Slave
$ItemMax[efemale, BeaconGun] = 1;	//Slave
$ItemMax[marmor, BeaconGun] = 0;	//Pawn
$ItemMax[aarmor, BeaconGun] = 1;	//Navigator
$ItemMax[darmor, BeaconGun] = 0;	//Atomizer
$ItemMax[barmor, BeaconGun] = 0;	//Paladin

$ItemMax[larmor, BeaconAmmo] = 0;	//Seraph
$ItemMax[lfemale, BeaconAmmo] = 0;	//Seraph
$ItemMax[earmor, BeaconAmmo] = 15;	//Slave
$ItemMax[efemale, BeaconAmmo] = 15;	//Slave
$ItemMax[marmor, BeaconAmmo] = 0;	//Pawn
$ItemMax[aarmor, BeaconAmmo] = 15;	//Navigator
$ItemMax[darmor, BeaconAmmo] = 0;	//Atomizer
$ItemMax[barmor, BeaconAmmo] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


ItemData BeaconAmmo
{	description = "Targeting Beacons";
	classname = "Ammo";
	shapeFile = "sensor_small";
	heading = "fTools";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData BeaconGunImage
{	shapeFile = "PaintGun";
	mountPoint = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -2.75, 0};
	weaponType = 0;
	reloadTime = 0.75;
	fireTime = 1.5;
	minEnergy = 15;	
	maxEnergy = 50;	
	ammoType = BeaconAmmo;
	accuFire = true;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BeaconGun
{	heading = "fTools";
	description = "Beacon Gun";
	classname = "Tool";
	shapeFile = "PaintGun";
	hudIcon = "mortar";	
	shadowDetailMask = 4;
	imageType = BeaconGunImage;	
	price = 77;	
	showWeaponBar = true;	
};

function DeployRBeacon(%player)
{	%position=$Location;
	%rot=$Rotation;
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	if($traceObj) Echo($Ver,"|Created New Object :",%beacon," Beacon");
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%position);
	Gamebase::setMapName(%beacon,"Target Beacon");
	Beacon::onEnabled(%beacon);
}

function BeaconGunImage::onFire(%player,%slot)
{	%client = GameBase::getOwnerClient(%player);
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[BeaconGun]) && Player::getItemCount(%player,BeaconAmmo)) ;
	if(%AmmoCount)
	{	%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,250))
		{	%object = getObjectType($los::object);
			if (%object!="Player" && %object !="Flier" && %object !="") // == "SimTerrain" || %object == "InteriorShape" || %object=="StaticShape") 
			{	// Try to stick it straight up or down, otherwise
				// just use the surface normal
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{	%rot = "0 0 0";}
				else 
				{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{	%rot = "3.14159 0 0";}
					else 
					{	%rot = Vector::getRotation($los::normal);}
				}
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[BeaconAmmo] > $TeamItemCount[%team @ BeaconAmmo] || $TestCheats) 
				{	%Dist=Vector::getDistance(GameBase::getPosition(%player),$los::position);
					if(%Dist==0)
					{	%tTime=1;}
					else
					{	%tTime=%Dist/25;}
					Projectile::spawnProjectile("BeaconRocket",%trans,%player,%vel,$los::object);
					Client::sendMessage(%client,0,"Beacon Away");
					$Location=$los::position;
					$Rotation=%rot;
					schedule("DeployRBeacon(" @ %player @ " );",%tTime);
					$TeamItemCount[GameBase::getTeam(%beaconammo) @ "BeaconAmmo"]++;
					Player::decItemCount(%player,BeaconAmmo);
				}
				else
				Client::sendMessage(%client,0,"Deployable Item limit reached! ~Error_Message.wav");
			}
			else
			Client::sendMessage(%client,0,"** Invalid Target - Unable to attach to Object! ** ~wError_Message.wav");
		}
		else
		Client::sendMessage(%client,0,"** Object Out of Range !! ** ~wError_Message.wav");
	}
	else
	{	if (!Player::getItemCount(%player, $WeaponAmmo[BeaconGun]))
	{	Client::sendMessage(%client,0,"** Out of BeaconAmmo!! ** ~waccess_denied.wav");}
	else
	{ 	Client::sendMessage(%client,0,"** Out of Beacons!! ** ~waccess_denied.wav");}
	}
}

function BeaconGun::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Beacon Gun");
}