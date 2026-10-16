//DT Dark Storm
$InvList[DStorm] = 1;
$RemoteInvList[DStorm] = 1;
$VehicleInvList[DStorm] = 1;
$AutoUse[DStorm] = False;
$WeaponAmmo[DStorm] = "";

addWeapon(DStorm);

GrenadeData DStormCall
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = TurretExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 80;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $ElectricityDamageType;
  explosionRadius = 20;
  kickBackStrength = -200;
  maxLevelFlightDist = 0;
  totalTime = 10.0;
  liveTime = 0.1;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0;
  smokeDist = 1;
};

ItemImageData DStormImage 
{
  shapeFile = "lflame";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1.5;
  fireTime = 2.0;
  minEnergy = 9;
  maxEnergy = 10;
  projectileType = "Undefined";
  accuFire = false;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DStorm 
{
  description = "Dark Storm";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWet];
  shadowDetailMask = 4;
  imageType = DStormImage;
  price = 600;
  showWeaponBar = true;
};

function DStorm::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<f2>Dark Psi Storm: The Dark Templar of Shakuras have developed a psionic storm that will rain down electricity on their foes.");
}

function DStormImage::onFire(%player, %slot)
{
 %energy = GameBase::getEnergy(%player);
	 if (%energy > 11)
	 {
		 %client = GameBase::getOwnerClient(%player);
	         %vel = Item::getVelocity(%player);

		if(GameBase::getLOSInfo(%player,1000))
		{
		    %curren = GameBase::getEnergy(%player) - 10;
		      GameBase::setEnergy(%player,%curren);
                       %object = getObjectType($los::object);
			if(%object == "Player" || %object == "Flier")
                         {
			 $DS[%player] = $los::position;
                         Client::sendMessage(Player::getClient(%player), 1,"Target for Dark Storm acquired.");
                           %highpos = Vector::add($DS[%player], "0 0 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                                return;
			 }
			 else
			 {
                           $DS[%player] = $los::position;
//1
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
//4
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
//6
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
//10
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                                return;
			 }
                         return;
		}
                else
                {
                Client::sendMessage(Player::getClient(%player), 1,"Nothing to target in desired area.");
                return;
                }
        }
	else if(GameBase::getLOSInfo(%player,1000))
        {
			 $DS[%player] = $los::position;
                          Client::sendMessage(Player::getClient(%player), 1,"Not enough energy for a full dark storm.");
//1
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
//4
                           %random = (floor(getRandom() * 20)-10);
                           %random2 = (floor(getRandom() * 20)-10);
                           %highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
                           %newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
                           Projectile::spawnProjectile("DStormCall",%newtrans,%player,%vel);
                                return;

        }
        else return;
}