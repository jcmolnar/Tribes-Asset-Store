
$ammo[exppack] = Exppackammo;
$AutoUse[Exppack] = true;



ItemData ExppackAmmo
{
	description = "...lol";
	className = "Ammo";
	shapeFile = "force";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
	showinventory = false;
	showweaponbar = false;
};

ItemData detonatorAmmo
{
	description = ".,.lol";
	className = "Ammo";
	shapeFile = "force";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
	showinventory = false;
	showweaponbar = false;
};

ItemImageData ExppackImage
{
	shapeFile = "grenammo";
	mountPoint = 0;
	mountrotation = { 0, 0, 1.55 };
	weaponType = 3;
	reloadTime = 0;
	Mountoffset = { 0, 0, -0.1 };
	fireTime = 0.05;

	ammoType = Exppackammo;
	
	accuFire = true;
	sfxActivate = SoundPickUphealth;
	
};

ItemData Exppack
{
	description = "Explosives";
	className = "Weapon";
	shapeFile = "grenammo";
   validateShape = true;
	hudIcon = "weapon";
   heading = "dEngineer";
	shadowDetailMask = 4;
	imageType = ExppackImage;
	price = 200;
	showWeaponBar = true;
	
};

function exppack::onMount(%player, %item)
{
if(player::getitemcount(%player, exppackammo) < 1) 
player::mountitem(%player, detonator, $weaponslot);
}

function exppackImage::onFire(%player, %slot)
{
echo(checkpointA);
%clId = Player::getclient(%player);
if(%player.throwTime < getSimTime() ) {
echo(checkpointB);
%clId.canchangeweapon = false;
schedule("throwexplosive(" @ %clId @ "," @ %player @ ");", 1);
player::unmountItem(%player, $weaponslot);
}
}

function throwExplosive(%clId, %player)
{

	
		if(!Player::isdead(%player)) {
			echo(checkpointC, %player);
			Player::decItemCount(%player,exppackammo);
			%obj = newObject("","Mine","dynamite");
 	 	 	registerdynamite(%obj, %player);
			echo(OBJECT_IS_, %obj);
			%clId.canchangeweapon = true;
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,2 ,false);
			%player.throwTime = getSimTime() + 1.35;
			
	}		
		
}

function registerdynamite(%obj, %pl)
{
$Dynamites[%pl]++;
%x = $Dynamites[%pl];
$DynamiteToOwner[%obj] = %pl;
$OwnerToDynamite[%pl, %x] = %obj;
%obj.crap = false;
}

function cleardynamites(%pl)
{
%count = $Dynamites[%pl];
if(%count == 0) return;

for(%x = 1; %x < (%count + 1); %x++)
	{
	%Id = $OwnerToDynamite[%pl, %x];
	%id.crap = true;
	schedule("if(" @ %id @ ".crap) deleteobject(" @ %Id @ ");", 20);
	}
$dynamites[%pl] = 0;
}

MineData Dynamite
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1;
	className = "Handgrenade";
   description = "Dynamite";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = DebrisExpLarge;
	explosionRadius = 11.2;
	damageValue = 2;
	damageType = $exppack;
	kickBackStrength = 70;
	triggerRadius = 4.2;
	maxDamage = 0.5;
};

function Dynamite::onDestroyed(%this)
{
%Set = newObject("set",SimSet);
	%Pos = gamebase::getposition(%this);
	%num = containerBoxFillSet(%Set, $Simplayerobjecttype, %Pos, 30, 30, 30,0); 
	for(%x = 0; %x < %num; %x++)
		{
		%curplayer = group::getobject(%set, %x);
		%dist = vector::getdistance(gamebase::getposition(%curplayer), %pos);
		if(!player::isDead(%curplayer) && %curplayer.isturretguy != 1) WWII::screenshake(%curplayer,0.5*sqrt(1/%dist)); 
		}
	deleteobject(%set);
}

function exppack::onMount(%player, %item)
{
%clientId = player::getclient(%player);
bottomprint(%clientId, "<jc><f2>Press <f1>B<f2> to switch to detonator.", 5);
}

ItemImageData DetonatorImage
{
	shapeFile = "ammopack";
	mountPoint = 0;
	mountrotation = { 0, 0, 0 };
	weaponType = 3;
	reloadTime = 0;
	Mountoffset = { -0.1, -0.04, -0.1 };
	fireTime = 0.05;

	ammoType = detonatorAmmo;
	
	accuFire = true;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Detonator
{
	description = "Detonator";
	className = "Weapon";
	shapeFile = "ammopack";
   validateShape = true;
	hudIcon = "weapon";
   heading = "dEngineer";
	shadowDetailMask = 4;
	imageType = DetonatorImage;
	price = 200;
	showWeaponBar = true;
	
};

ItemImageData detonator2Image 
{
	shapeFile = "force";
	mountPoint = 0;
	mountRotation = { 0, -3.1, 0 };
	weaponType = 0;
	mountOffset = { -0.1, -0.03, 0.33 };
	accuFire = true;
};

ItemData detonator2
{
	description = "ac23";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = detonator2Image;
	showWeaponBar = false;
	showInventory = false;
	price = 0;
};

ItemImageData detonator3Image 
{
	shapeFile = "force";
	mountPoint = 0;
	mountRotation = { 0, -1.55, 0 };
	weaponType = 0;
	mountOffset = { -0.1, -0.03, 0.33 };
	accuFire = true;
};

ItemData detonator3
{
	description = "ac23";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = detonator3Image;
	showWeaponBar = false;
	showInventory = false;
	price = 0;
};

ItemImageData detonator4Image 
{
	shapeFile = "force";
	mountPoint = 0;
	mountRotation = { 0, 1.55, 0 };
	weaponType = 0;
	mountOffset = { -0.1, -0.03, 0.33 };
	accuFire = true;
};

ItemData detonator4
{
	description = "ac23";
	shapeFile = "force";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = detonator4Image;
	showWeaponBar = false;
	showInventory = false;
	price = 0;
};


function detonatorImage::onFire(%player, %slot)
{
%count = $dynamites[%player];
if(%count == 0) return;

for(%x = 1; %x < (%count + 1); %x++)
	{
	%id = $OwnerToDynamite[%player, %x];
	
	%data = GameBase::getDataName(%id);
	GameBase::setDamageLevel(%id, %data.maxDamage);
	}
$dynamites[%player] = 0;
player::setitemcount(%player, detonatorammo, 1);
}


function detonator::onMount(%player, %item)
{
player::mountitem(%player, detonator2, 4);
player::mountitem(%player, detonator3, 5);
player::mountitem(%player, detonator4, 6);
}

function detonator::onUnMount(%player, %item)
{
player::unMountItem(%player, 4);
player::unMountItem(%player, 5);
player::unMountItem(%player, 6);
}