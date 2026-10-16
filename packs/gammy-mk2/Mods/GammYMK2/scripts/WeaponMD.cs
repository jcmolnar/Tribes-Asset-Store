//--------------------------------------

$SellAmmo[DiscAmmo] = 5;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackItems[2] = DiscAmmo;
$WeaponAmmo[RocketLauncher] = DiscAmmo;

//--------------------------------------

$InvList[RocketLauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[RocketLauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;

//--------------------------------------
RocketData StingerMissile
{
   bulletShapeName = "Discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasmaex.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker
{
bulletShapeName = "Discb.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 2.6;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 15.0;
terminalVelocity = 2.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 1.0;
nonSeekingTurningRadius = 1.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
//--------------------------------------


ItemData DiscAmmo 
{
	description = "DiscAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "Discammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "discammo";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = DiscAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	} //=== End standard missile fire.


ItemData RocketLauncher
{
	description = "Desctro Disc";
	className = "Weapon";
	shapeFile = "discammo";
	hudIcon = "mortar";
    heading = "cDisc Launchers";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ "  Just sent a Masanka Disc at you!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 
//--------------------------------------
function RocketLauncher::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Desctro Disc...for all ya'll DBZ fan's this is for you..It shoots high speed discs unless you are pointing your reticle at someone...then it shoots a lower speed disc that will chase the enemy you Locked on until !!BOOM!!", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------