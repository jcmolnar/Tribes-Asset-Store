//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Isolanth : Storm Demon Aspects weapon
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Demogun] = 1;
$RemoteInvList[Demogun] = 1;
$AutoUse[Demogun] = False;
$WeaponAmmo[Demogun] = "";

addWeapon(Demogun);

//======================================================================== Demolisher Cannon

RocketData IsoBurst
{
  bulletShapeName = "shield.dts";
  explosionTag = isoExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 0;
  damageValue = 0.35;
  damageType = $DDamageType;
  kickBackStrength = 0.0;
  muzzleVelocity = 185.0;
  terminalVelocity = 830.0;
  acceleration = 5.0;
  totalTime = 10.28;
  liveTime = 10.28;
  lightRange = 2.0;
  lightColor = { 0.50, 0.0, 0.50 };
  inheritedVelocityScale = 0.0;
  trailType = 2;
  trailString = "shield.dts";
  smokeDist = 1.0;
};

ItemImageData DemoGunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.1;
  fireTime = 0.1;
  minEnergy = 10;
  maxEnergy = 20;
  projectileType = IsoBurst;
  accuFire = true;
  sfxFire = SoundFireMortar;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DemoGun 
{
  heading = $InvHead[ihWel];
  description = "Isolanth";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = DemoGunImage;
  price = 17;
  showWeaponBar = true;
};

function DemoGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Isolanth: Storm Daemons weapon. Fires sonic speed fusion charged flachettes that rip through nearly any material.");
}

function DemoGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack || Player::getMountedItem(%player,$BackpackSlot) == LaserPack)
		Weapon::onUse(%player,%item);
 
 
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use a Demolisher Cannon."); 

	}