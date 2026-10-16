ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	showinventory = false;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
%client = player::getclient(%player);
if(!%client.canchangeweapon || %player.parachute) return;
if(player::getitemcount(%player, nadeammo) > 0) {
if(%player.throwTime < getSimTime() ) {
player::unmountItem(%player, $weaponslot);	
Player::mountItem(%player, nade, $weaponslot);
}
}
}

ItemData nadeAmmo
{
	description = "Grenades";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData nadeImage 
{
	shapeFile = "grenade";
	mountPoint = 0;
	weaponType = 0;
	showinventory = false;
	ammoType = nadeammo;
	reloadTime = 0.1;
	accuFire = false;
	fireTime = 0.1;
	sfxFire = SoundFirechaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData nade
{
	description = "Grenade";
	shapeFile = "grenade";
	showinventory = false;
	hudIcon = "grenade";
	className = "Weapon";
	heading = "pHand Explosives";
	shadowDetailMask = 4;
	imageType = nadeImage;
	showWeaponBar = true;
	price = 1;
};

function nadeimage::onFire(%player, %slot)  
{
%clId = Player::getclient(%player);
if(player::isAIControlled(%player)) %clId = %player+1;
if(%player.throwTime < getSimTime() ) {
player::setanimation(%player, 21);
%clId.canchangeweapon = false;
schedule("thrownade(" @ %clId @ "," @ %player @ ");", 1);
player::unmountItem(%player, $weaponslot);
}
}

function thrownade(%clId, %player)
{

	
		if(!Player::isdead(%player)) {
			
			Player::decItemCount(%player,nadeAmmo);
			%obj = newObject("","Mine","Grenadebomb");
 	 	 	%clId.canchangeweapon = true;
			addToSet("MissionCleanup", %obj);
			%obj.owner = %player;
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 ,false);
			%player.throwTime = getSimTime() + 1.35;
			
	}
%clId.canchangeweapon = true;		
		
}


MineData Grenadebomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 0.5;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 18.2;
	damageValue = 1.1;
	damageType = $grenade;
	kickBackStrength = 90;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function Grenadebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Grenade::Detonate(" @ %this @ ");",3.1,%this);
}

function Grenade::Detonate(%this)
{
	
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	%trans = "0 0 1 " @ vector::getrandom() @ " 1 0 0 " @ getboxcenter(%this);
	%vel = Item::getVelocity(%this);
	for(%x = 0; %x < 10; %x++) { Projectile::spawnProjectile("GrenadeDust",%trans,%this.owner,%vel); %trans = "0 0 1 " @ vector::getrandom() @ " 1 0 0 " @ getboxcenter(%this); }
	%Set = newObject("set",SimSet);
	%Pos = gamebase::getposition(%this);
	%num = containerBoxFillSet(%Set, $Simplayerobjecttype, %Pos, 40, 40, 40,0); 
	for(%x = 0; %x < %num; %x++)
		{
		%curplayer = group::getobject(%set, %x);
		%dist = vector::getdistance(gamebase::getposition(%curplayer), %pos);
		if(!player::isDead(%curplayer) && %curplayer.isturretguy != 1) WWII::screenshake(%curplayer,0.5*sqrt(1/%dist)); 
		}
	deleteobject(%set);


}

RocketData GrenadeDust
{
	bulletShapeName = "bullet.dts";
	explosionTag = Dust;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.71;
	damageType = $Grenade;		
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 90.0;
	terminalVelocity = 90.0;
	acceleration = 500.0;
	totalTime = 0.7;
	liveTime = 0.7;
	lightRange = 0.0;
	//lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	//soundId = SoundJetHeavy;
};
