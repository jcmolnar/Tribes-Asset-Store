//Mkay! All the shit below was originally done by Plasmatic - Aka Tribes God to me. 
//This lil Postage note is here to give him credit for everything hes helped me on and 
//the use of this script. 
//All im doin to it is replacing miner with napalm setter....lol
//We Love Ya Plasmatic - not in that way ... 
/////////Something funny......                       
//Fire ON MY TARGET!!!            ( o ) ( o)
//      8=============D -->            \       / 
//                                                  )  o ( 
             

$InvList[NapalmSetter] = 1;
$RemoteInvList[NapalmSetter] = 1;

$ItemMax[marmor, NapalmSetter] = 1;
$ItemMax[mfemale, NapalmSetter] = 1;
$ItemMax[larmor, NapalmSetter] = 1;
$ItemMax[lfemale, NapalmSetter] = 1;
$ItemMax[harmor, NapalmSetter] = 1;

$WeaponAmmo[NapalmSetter] = "NapalmSetterAmmo";

$ItemMax[marmor, NapalmSetterAmmo] = 12;
$ItemMax[mfemale, NapalmSetterAmmo] = 12;
$ItemMax[larmor, NapalmSetterAmmo] = 6;
$ItemMax[lfemale, NapalmSetterAmmo] = 6;
$ItemMax[harmor, NapalmSetterAmmo] = 18;


$InvList[NapalmSetterAmmo] = 1;
$RemoteInvList[NapalmSetterAmmo] = 1;

$SellAmmo[NapalmSetterAmmo]			= 10;

$AmmoPackMax[NapalmSetterAmmo] = 30;
$AmmoPackItems[15] = NapalmSetterAmmo;


ItemData NapalmSetterAmmo
{
	description = "Slippery Napalm Balls";
	className = "Ammo";
heading = "xAmmunition";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	price = 10;
};


ItemImageData NapalmSetterImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = NapalmSetterAmmo;
	mountPoint = 0;
	mountRotation = { 0, -0.785, 0 };
	mountOffset = {-0.065, 0, 0.07}; 
	//projectileType = NapalmSetterShell;// interferes with image fire
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

ItemData NapalmSetter
{
	description = "Napalm Setter";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
heading = "bWeapons";
	shadowDetailMask = 4;
        imageType = NapalmSetterImage;
	price = 7500;
	showWeaponBar = true;
};


function NapalmSetterImage::onFire(%this) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,NapalmSetterAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,NapalmSetterAmmo);

 		%newObj = Projectile::spawnProjectile("GooeyNapalm", %trans, %this, %vel);
		schedule("TossMines(" @ %newObj @ ", " @ %this @ ");", 2);
		schedule("SplitMines(" @ %newObj @ ", " @ %this @ ");", 1.9);
	}
}

function SplitMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 32; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("SmearShell", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	%rnd = (floor(getRandom()*20)/80);
		}
	}
}

function NapalmSetter::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "Blow the wholy shit out of the enemy with sticky napalm >:P. ", 10);
}
//-----

