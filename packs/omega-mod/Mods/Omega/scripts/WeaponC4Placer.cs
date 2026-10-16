//Mkay! All the shit below was originally done by Plasmatic - Aka Tribes God to me. 
//This lil Postage note is here to give him credit for everything hes helped me on and 
//the use of this script.
//We Love Ya Plasmatic - not in that way ... 

$InvList[C4Placer] = 1;
$RemoteInvList[C4Placer] = 1;

$ItemMax[marmor, C4Placer] = 1;
$ItemMax[mfemale, C4Placer] = 1;
$ItemMax[larmor, C4Placer] = 0;
$ItemMax[lfemale, C4Placer] = 0;
$ItemMax[harmor, C4Placer] = 0;

$WeaponAmmo[C4Placer] = "C4PlacerAmmo";

$ItemMax[marmor, C4PlacerAmmo] = 3;
$ItemMax[mfemale, C4PlacerAmmo] = 3;
$ItemMax[larmor, C4PlacerAmmo] = 0;
$ItemMax[lfemale, C4PlacerAmmo] = 0;
$ItemMax[harmor, C4PlacerAmmo] = 0;


$InvList[C4PlacerAmmo] = 1;
$RemoteInvList[C4PlacerAmmo] = 1;

$SellAmmo[C4PlacerAmmo]			= 10;

$AmmoPackMax[C4PlacerAmmo] = 30;
$AmmoPackItems[15] = C4PlacerAmmo;


ItemData C4PlacerAmmo
{
	description = "C4 Bombs";
	className = "Ammo";
heading = "xAmmunition";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	price = 10;
};


ItemImageData C4PlacerImage
{
	shapeFile = "grenammo";
	mountPoint = 0;
	weaponType = 0;
	ammoType = C4PlacerAmmo;
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = {-0.065, 0, 0.07}; 
	//projectileType = C4PlacerShell;// interferes with image fire
	accuFire = false;
	reloadTime = 0.75;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;

};

ItemData C4Placer
{
	description = "Special Bomb Pack";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
heading = "cBackpacks";
	shadowDetailMask = 4;
        imageType = C4PlacerImage;
	price = 1960;
	showWeaponBar = true;
};


function C4PlacerImage::onFire(%this) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,C4PlacerAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,C4PlacerAmmo);

 		%newObj = Projectile::spawnProjectile("PlastickBomb", %trans, %this, %vel);
		schedule("PlasticToss(" @ %newObj @ ", " @ %this @ ");", 30);
		schedule("PlasticSplit(" @ %newObj @ ", " @ %this @ ");", 29.9);
	}
}

function PlasticSplit(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PlastickPrettySplit", %trans, %this,%vel); //plasmatic
	Projectile::spawnProjectile(%obj);                                 
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function PlasticToss(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 80; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 120) -60;
		%yrnd = %yvel + floor(getRandom() * 120) -60;
		%zrnd = %zvel + floor(getRandom() * 40);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("PlastickBombBlast", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	%rnd = (floor(getRandom()*20)/80);
		}
	}
}

function C4Placer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "This pack works exactly like the Napalm Setter does. Go where u want the C4 placed. Place it, after its placed you will have precisly one minute untill it explodes. Make sure teammates and Yourself are clear of the area when it goes off", 10);
}
//-----

