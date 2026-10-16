//FreeMan Gun Script and Bounty Script

//--------------------------------------

$AutoUse[SD] = True;
$SellAmmo[BulletAmmo] = 25;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackItems[0] = BulletAmmo;
$WeaponAmmo[SD] = BulletAmmo;

//--------------------------------------

$InvList[SD] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[SD] = 1;
$RemoteInvList[BulletAmmo] = 1;

//--------------------------------------

BulletData SDBullet
{
   bulletShapeName    = "Rocket.dts";
   validateShape      = true;
   explosionTag       = LargeShockwave;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $electricityDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 900.0;
   totalTime          = 4.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1;
   tracerLength       = 1;
   soundId = SoundElfFire;
};

//--------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SDImage
{
	shapeFile = "Sniper";
	mountPoint = 0;
                mountoffset = { 0, 0, 0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 1;
	fireTime = 1;
	
	projectileType = SDBullet;
	accuFire = true;

	
	
	sfxFire = SoundElfFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxReady = SoundTankIdle;
};

ItemData SD
{
	description = "Freeman's Rifle";
	className = "Weapon";
	shapeFile = "Sniper";
   validateShape = true;
	hudIcon = "chain";
   heading = "h:(Snipers Gear:(";
	shadowDetailMask = 4;
	imageType = SDImage;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------
function SD::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Freeman rifle was invented by one of the Hacker's best scientists, Freeman. The rocket actually punctures the sound barrier with so much force it creates a shock wave.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------






$AutoUse[Bounty] = false;

ItemData Bounty
{
   description = "Bounty Exchange";
   shapeFile = "Discb";
   heading = "pArmor Upgrades";
   shadowDetailMask = 4;
   price = 305;
   validateShape = true;
   validateMaterials = true;
};

function Bounty::onUse(%player,%item)
{
	
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);								
	if (%armor == "Tarmor")Bounty(%clientId, %player, %item);
}


//--------------------------------------
// My bounty scripts :) makes the bounty hunter big and bad :)
//
//This i idea is one of my favorites , its right up there with kaioken :) -HaCk

function Bounty(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);
       %Bounty = Player::getItemCount(%player,"Money");	

	if (%bounty < 300)
	{
	Client::sendMessage(%clientId,3,"Need More Creds...");
	}
	
	if (%bounty > 299)
	{
	Client::sendMessage(%clientId,3,"Energy Increased");
	 GameBase::setEnergy(%player,%min);
	%min=%min+%maxE+30; 
	Player::setItemCount(%Player, Money, 0);
	}
	
	if (%bounty > 599)
	{
	 Client::sendMessage(%clientId,3,"Extra Ammo");
	Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);
		Player::setItemCount(%clientId,EnergyAmmo,$ItemMax[%armor, EnergyAmmo]);
      		Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);
		Player::setItemCount(%clientId,RepairKit,1);
		Player::setItemCount(%Player, Money, 0);
	}
	
        if (%bounty > 1199)
	{
	Client::sendMessage(%clientId,3,"Energy Recharge Upgraded");	
	GameBase::setRechargeRate(%player,%med);
	%med=%med+%maxR+10;
	Player::setItemCount(%Player, Money, 0);
	}

	 if (%bounty > 2399)
	{
	Client::sendMessage(%clientId,3,"MEGA Energy and Recharge Boost!!!");	
	GameBase::setEnergy(%player,%maxE); 
	GameBase::setRechargeRate(%player,%maxR);
	%maxE=%maxE+%min+350;
	%maxR=%maxR+%med+40;
	Player::setItemCount(%Player, Money, 0);
	}


	
	
}

