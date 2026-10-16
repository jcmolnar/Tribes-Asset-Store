//================================================================
//Slayer
//================================================================
$AutoUse[Slayer] = False;
//===========================================
$InvList[Slayer] = 1;
$InvList[FBWRocketLauncher] = 1;
$InvList[FBWRocketAmmo] = 1;
$RemoteInvList[Slayer] = 1;
$RemoteInvList[FBWRocketLauncher] = 1;
$RemoteInvList[FBWRocketAmmo] = 1;
//================================================================
$DamageScale[larmor, $FBWDamageType] = 1.5;
$DamageScale[lfemale, $FBWDamageType] = 1.5;
$DamageScale[marmor, $FBWDamageType] = 1.5;
$DamageScale[mfemale, $FBWDamageType] = 1.5;
$DamageScale[harmor, $FBWDamageType] = 1.5;

$ItemMax[larmor, Slayer] = 1;				
$ItemMax[lfemale, Slayer] = 1;			
$ItemMax[marmor, Slayer] = 1;				
$ItemMax[mfemale, Slayer] = 1;					
$ItemMax[harmor, Slayer] = 1;				

$ItemMax[larmor, FBWRocketLauncher] = 1;				
$ItemMax[lfemale, FBWRocketLauncher] = 1;		
$ItemMax[marmor, FBWRocketLauncher] = 1;				
$ItemMax[mfemale, FBWRocketLauncher] = 1;				
$ItemMax[harmor, FBWRocketLauncher] = 1;					
	
$ItemMax[larmor, FBWRocketAmmo] = 25;				
$ItemMax[lfemale, FBWRocketAmmo] = 25;				
$ItemMax[marmor, FBWRocketAmmo] = 25;				
$ItemMax[mfemale, FBWRocketAmmo] = 25;				
$ItemMax[harmor, FBWRocketAmmo] = 25;				
//================================================================
SoundData SoundWPNSlayer
{
   wavFileName = "wpn_slayer.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNSlayerIdle
{
   wavFileName = "wpn_slayer_idle.wav";
   profile = Profile3dCloseLoop;
};
SoundData SlayerExplosion
{
	wavFilename = "exp_slayer.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizSlayer
{
   wavFileName = "whiz_slayer.wav";
   profile = Profile3dMediumLoop;
};
//================================================================
ExplosionData SlayerExp
{
   shapeName = "fiery.dts";
   soundId   = slayerExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.5;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 1.0, 0.5, 0.0 };
   colors[1]  = { 2.0, 1.0, 0.0 };
   colors[2]  = { 3.0, 1.5, 0.0 };
   radFactors = { 1.0, 0.75, 0.0 };
};
//=====================================================
RocketData Slayerproj
{
   bulletShapeName  = "proj_Rocket.dts";
   explosionTag     = SlayerExp;
   collisionRadius  = 0.0;
   mass             = 3.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $FBWDamageType;

   explosionRadius  = 13;
   kickBackStrength = -500;
   muzzleVelocity   = 750;
   terminalVelocity = 250;
   acceleration     = 1;
   totalTime        = 10;
   liveTime         = 10;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.0;

   //soundId = SoundWhizSlayer;
};
BulletData InvisFBWRocket
{
	bulletShapeName  = "proj_Rocket.dts";
	explosionTag     = SlayerExp;
	mass             = 0.1;
	
	damageClass      = 1;       
	damageValue      = 0.0;
	damageType       = $FBWDamageType;
	aimDeflection      = 0.0;
	kickBackStrength = 0.1;
	muzzleVelocity   = 0.1;
	totalTime        = 0.01;
	liveTime         = 0.01;
	inheritedVelocityScale = 1.5;
	
	soundId = SoundWhizSlayer;
};

// BEGIN ADDED CODE
function FBWOutOfFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	Vehicle::dismount(%fbw, "0 0 0");
	remoteEval(%cl, BP, "<jc><f0>Rocket Out of Fuel", 2);
}
function FBWLowFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	remoteEval(%cl, BP, "<jc><f0>Rocket Low On Fuel", 3);
}
// END ADDED CODE

function InvisFBWRocket::onAdd(%this)
{
	%rot = GameBase::getRotation(%this);
	%pos = GameBase::getPosition(%this);
	%client = $clientID;
	$clientID = 0;
	
	//Spawn Rocket
	%obj = newObject("","Flier","FBWRocket",true);
	addToSet("MissionCleanup", %obj);
	$FBWClientID[%obj] = %client;
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
	//echo("$FBWClientID[%obj] - Proj onAdd ",$FBWClientID[%obj]);
	//Position
	GameBase::setPosition(%obj, %pos);
	GameBase::setRotation(%obj, %rot);
	//Set Controls
	Client::setControlObject(%client,%obj);
	
	// BEGIN ADDED CODE
	schedule("FBWLowFuel("@%obj@");", 12, %obj);
	schedule("FBWOutOfFuel("@%obj@");", 15, %obj);
	// END ADDED CODE
}
//================================================================
ItemData FBWRocketAmmo
{
	description = "FBW Rockets";
	className = "Ammo";
	shapeFile = "ammo_round";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};


ItemImageData SlayerImage 
{ 
        shapeFile = "wpn_rocketL";
        mountPoint = 0;
        weaponType = 0;
        ammoType = FBWRocketAmmo;
        projectileType = SlayerProj;
        accuFire = true;
        reloadTime = 0.85;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
        sfxFire = SoundWPNSlayer;
        sfxActivate = SoundPickUpWeapon;
        //sfxReady = SoundSlayerIdle;
};
ItemData Slayer
{ 
        description = "Slayer";
        className = "Weapon";
        shapeFile = "wpn_rocketL";
        hudIcon = "slayer";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = SlayerImage;
        price = 0;
        showWeaponBar = true;
	 //validateShape = true;
       //validateMaterials = true;
};


//-----------------
// 6/16/99 - 6:30PM
//-----------------
//FBW Rocket Launcher


ItemImageData FBWRocketLauncherImage
{
	shapeFile = "wpn_fbwlauncher";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = FBWRocketAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 1.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = SoundWPNSlayer;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FBWRocketLauncher
{
	description = "Slayer";
	className = "Weapon";
	shapeFile = "wpn_fbwlauncher";
	hudIcon = "FBW";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FBWRocketLauncherImage;
	price = 1000;
	showWeaponBar = true;
	showInventory = false;
	   //validateShape = true;
         //validateMaterials = true;
};

function FBWRocketLauncherImage::onFire(%player, %slot) 
{
	%client = Player::getClient(%player);
	
	if ( $FBWRocketReload[%player] == TRUE )
	{
		remoteEval(%client, BP, "<jc><f0>Reloading...", 1);
		FBWRocketNoFireAnim(%player);
	}
	else
	{
		if ( !Player::isCrouching(%player) || Player::getLastContactCount(%player) > 0 )
		{
			remoteEval(%client, BP, "<jc><f0>Must Be Crouched to Fire Guided Rockets", 3);
			FBWRocketNoFireAnim(%player);
		}
		else
		{
			%item = "FBW";
			//echo("My Above Check ", CheckAboveMe(%player));
			if( CheckAboveMe(%player) == FALSE )
			{
				if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] )
				{
					%trans = LabRat::getMuzzleTransform(%player);
					%vel = Item::getVelocity(%player);
					$clientID = GameBase::getOwnerClient(%player);
					Projectile::spawnProjectile("InvisFBWRocket",%trans,%player,%vel);
					
					//Misc
					Player::decItemCount(%player, FBWRocketAmmo, 1);
					GameBase::playSound(%player , SoundWPNSlayer, 0);
					$TeamItemCount[GameBase::getTeam(%client) @ %item]++;
					$FBWRocketReload[%player] = TRUE;
					schedule("$FBWRocketReload["@%player@"] = FALSE;", 2.5);
					schedule("FBWRocketNoFireAnim(" @%player@ ");", 0.05);
				}
				else
				{
					remoteEval(%client, BP, "<jc><f1>FREQUENCY OVERLOAD: <f0>To Many Rockets in Flight", 3);
					FBWRocketNoFireAnim(%player);
				}
			}
			else
			{
				remoteEval(%client, BP, "<jc><f1>LAUNCH ABORTED: <f0>Satellite Contact Blocked", 3);
				FBWRocketNoFireAnim(%player);
			}
		}
	}
}

function CheckAboveMe(%player)
{
	%rot = "1.570796 0 0";
	//Do LOS directly above player to see if building is found
	if(GameBase::getLOSInfo(%player,10000,%rot))
	{
		if( $los::object )
			return TRUE;
		else
			return FALSE;
	}
	else
		return FALSE;
}

function FBWRocketNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,FBWRocketLauncher,$WeaponSlot);
}


exec("lrgmt.cs");
exec(fbw_rocket);

//================================================================
//echo("Slayer Loaded");