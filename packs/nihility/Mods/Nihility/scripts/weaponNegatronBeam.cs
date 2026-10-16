//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Titan);
$InvList[Titan] = 1;

$AutoUse[Titan] = True;
$InvList[TitanCell] = 0;
$WeaponAmmo[Titan] = "TitanCell";

$ItemMax[larmor, TitanCell] = 0;	//Seraph
$ItemMax[lfemale, TitanCell] = 0;	//Seraph
$ItemMax[earmor, TitanCell] = 0;	//Slave
$ItemMax[efemale, TitanCell] = 0;	//Slave
$ItemMax[marmor, TitanCell] = 0;	//Pawn
$ItemMax[aarmor, TitanCell] = 0;	//Navigator
$ItemMax[darmor, TitanCell] = 0;	//Atomizer
$ItemMax[barmor, TitanCell] = 50;	//Paladin

$ItemMax[larmor, Titan] = 0;		//Seraph
$ItemMax[lfemale, Titan] = 0;		//Seraph
$ItemMax[earmor, Titan] = 0;		//Slave
$ItemMax[efemale, Titan] = 0;		//Slave
$ItemMax[marmor, Titan] = 0;		//Pawn
$ItemMax[aarmor, Titan] = 0;		//Navigator
$ItemMax[darmor, Titan] = 0;		//Atomizer
$ItemMax[barmor, Titan] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//float_target.wav

//Charging Beam coded by Plasmatic ----- CHECK OUT SEX MOD!
//Most of this is Plasmatic's code - check with him before using it
//Go to www.annihilation.info forums ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//edited by Auto << charging ammo and weird double charge up hud = harder to make than you think...


ItemData TitanCell
{
	description = "Titan Cells";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
	showInventory = false;
};

SoundData NegStartCharge
{	wavFileName = "pda_on.wav";
	profile = Profile3dFar;
};

SoundData SoundNegatronFire
{	wavFileName = "targetlaser.wav";  
	profile = Profile3dFar;
};

RocketData BeamWav
{
   bulletShapeName = "shockwave_large.dts";
  explosionTag    = breathExp;//rocketExp;bulletExp1  turretExp  breath
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $MortarDamageType;//$ExplosionDamageType;
   explosionRadius  = 20;
   kickBackStrength = 10;
   muzzleVelocity   = 1.0;
   terminalVelocity = 1.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
   soundId = SoundNegatronFire;
};

RocketData IonShell
{
   bulletShapeName = "breath.dts";
  explosionTag    = turretExp;//rocketExp;bulletExp1  turretExp
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $MortarDamageType;//$ExplosionDamageType;
   explosionRadius  = 20;
   kickBackStrength = 10;
   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
   soundId = SoundNegatronFire;
};

RocketData ShockWavShell
{
   bulletShapeName = "breath.dts";
  explosionTag    = LargeShockwave;//rocketExp;bulletExp1  turretExp
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $ElectricityDamageType;//$ExplosionDamageType;
   explosionRadius  = 90;
   kickBackStrength = -300;
   muzzleVelocity   = 4000.0;
   terminalVelocity = 4000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;
   soundId = SoundNegatronFire;
};


LaserData Nuclearbeam
{	laserBitmapName = "blue_blink4.bmp"; //lightningNew  blue_blink4  zap03  blue_tek bullethole
	hitName = "breath.dts";//fusionex.dts laserhit  //fusionbolt  //enex //shockwave_large
	damageConversion = 0.0138;
	DamageType = $ElectricityDamageType;
	beamTime = 1.5;
	lightRange = 2.0;
	lightColor = { 0.25, 0.25, 0.85 };
	detachFromShooter = true;//<<<<<<<<<<<<<<<<<<change
	hitSoundId = SoundLaserHit; //SoundFlierCrash
};



RocketData SniperShell2
{
   bulletShapeName = "enex.dts";
  explosionTag    = Shockwave;//rocketExp;bulletExp1
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.58;
   damageType       = $ElectricityDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 1;
   trailWidth  = 0.05;
//   soundId = SoundDiscSpin;
};





ItemImageData TitanImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0};
	mountOffset = { 0 , 0, -0.1 };
	weaponType = 1; //0
	//projectileType = Nuclearbeam;
	ammoType = TitanCell;
	accuFire = true;
	reloadTime = 2;
	fireTime = 0.001;//5
	//
	spinUpTime = 0.001;//3
	spinDownTime = 0.001;//3
	//

	minEnergy = -20;//140
	maxEnergy = -10;//150
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	//sfxFire = SoundFireLaser;
	//sfxActivate = SoundPickUpWeapon;
		
	sfxFire = NegStartCharge;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = ForceFieldOpen;
	sfxSpinDown = ForceFieldClose;
}; 



ItemImageData TitanImage2 
{
	shapeFile = "grenammo";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.1416};
	mountOffset = { 0 , 0.2, -0.07 };
	weaponType = 0;
	projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = -40;
	maxEnergy = -30;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData TitanImage3 
{
	shapeFile = "shieldPack";
	mountPoint = 0;
	mountRotation = { 0, 0, 1.57};
	mountOffset = { 0.15 , 0.04, -0.05 };
	weaponType = 0;
	//projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = 290;
	maxEnergy = 300;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
//	sfxFire = SoundFireLaser;
//	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData TitanImage4 
{
	shapeFile = "shieldPack";
	mountPoint = 0;
	mountRotation = { 0, 0, -1.57};
	mountOffset = { -0.15 , 0.04, -0.05 };
	weaponType = 0;
	//projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = 290;
	maxEnergy = 300;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
//	sfxFire = SoundFireLaser;
//	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Titan 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage;
	price = 777;
	showWeaponBar = true;
};

ItemData Titan 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage;
	price = 777;
	showWeaponBar = true;
};

ItemData Titan2 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage2;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Titan3 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage3;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Titan4 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage4;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};



$TitanSlotA=4;
$TitanSlotB=7;
$TitanSlotC=6;

//All of the following code is by Auto - plz ask permission before using
//^^^^^^^^^www.annihilation.info forums^^^^^^^^^^^^^^

function Titan::onMount(%player,%item, $WeaponSlot)
{
	//$Org = Player::getItemCount(%player, $WeaponAmmo[Titan]);
	//$Org = Player::getItemCount(%player, Titancell);
	if(Player::getMountedItem(%player,$BackpackSlot) == IonPack)
	{
	Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Negatron Beam", 2);
	Player::mountItem(%player,Titan2,$TitanSlotA); 
	Player::mountItem(%player,Titan3,$TitanSlotB);
	Player::mountItem(%player,Titan4,$TitanSlotC);
	}
	//Client::sendMessage(%client,0,"Must have Ion Gen to use Negatron Beam");
}

function Titan::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$TitanSlotA); 
	Player::unmountItem(%player,$TitanSlotB); 
	Player::unmountItem(%player,$TitanSlotC); 
}

function TitanImage::onfire(%player,%Ammo) 
{	
	if (%player.lasercharging) return;
	$Org = Player::getItemCount(%player, $WeaponAmmo[Titan]);


	%player.Charge = 0;
	charger( %player );

}

function charger(%player,$Org)
{
	
	if (%player.reloading == "True") return;
	//if (%Ammo > 0)
	//{
//	if (%player.Charge = $Org)
//	{
//	Client::sendMessage(Player::getClient(%player), 0,"Buffer locked at current energy level");	
//	}
	if (Player::isTriggered(%player,$WeaponSlot))
	{
		Player::trigger(%player, 6, true);
		Player::trigger(%player, 7, true);
		%player.Charge ++ ;	//0.1
//		if (%player.Charge > 50 ) %player.Charge = 50;
		if (%player.Charge > $Org) %player.Charge = $Org;
		%player.lasercharging = "True";
		schedule("charger(" @ %player @ ");",0.1); 
		%energy = GameBase::getEnergy(%player);
		%energy -= 5;
		GameBase::setEnergy(%player,%energy);
		%client = GameBase::getOwnerClient(%player);
		%Ammo = Player::getItemCount(%player, $WeaponAmmo[Titan]);
		Player::decItemCount(%player,$WeaponAmmo[Titan],1);
		//%Ammo = Player::getItemCount(%player, $WeaponAmmo[Titan]);
		//bottomprint(%client, "<jc><f2>"@%player.Charge@"                                        "@%player.Charge, 0.5);
		//==================cool numbers ;P
		%Vector=GameBase::getMuzzleTransform(%Player);
		%X1=Getword(%vector,1);
		%Y1=Getword(%vector,2);
		%Z1=Getword(%vector,3);
		//echo(%x1," ",%y1," ",%z1," | ",%x2," ",%y2," ",%z2);
		//=================================
		centerprint(%client, "<jc><f2>    |Buffered Energy|  [+] ["@%player.Charge@"]                   |Energy Cells|  [-] ["@%Ammo@"]    \n::::::::: "@%x1@"   ::::                        :::: "@%z1@" :::::::::", 0.5);
		//bottomprint(%client, "<jc><f2>:: Charging Negatron Beam - Buffering Electrons ::", 0.5);
		
	}
	if (!Player::isTriggered(%player,$WeaponSlot))
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%smack = %player.Charge / 10;
		%Shockwave = %player.Charge / 10;
		playSound(SoundFireLaser, GameBase::getPosition(%player));
		if (%smack < 2) playSound(SoundNegatronFire, GameBase::getPosition(%player));
		if (%smack >= 2) playSound(SoundNegatronFire, GameBase::getPosition(%player));
		if (%smack >= 3) playSound(SoundNegatronFire, GameBase::getPosition(%player));
		
		Player::trigger(%player, 6, true);
		Player::trigger(%player, 7, true);

		for(%i=0; %i < %smack; %i += 1) //+= 1
		{
			Player::trigger(%player, 6, false);
			Player::trigger(%player, 7, false);
			Player::trigger(%player, 6, true);
			Player::trigger(%player, 7, true);
			Player::trigger(%player, 4, true);
			IonShoc(%player);
		}
		%player.Charge = 0;
		Projectile::spawnProjectile("BeamWav", %trans, %player, %vel);
		//Projectile::spawnProjectile("BeamWav", %trans, %player, %vel);
		%player.lasercharging = "";
		%player.reloading = "True";
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);
		Player::trigger(%player, 7, false);
		schedule("reload(" @ %player @ ");",0.1); 
		//ForwardKick(%player,%smack);
	}
	//}
	//schedule("reload(" @ %player @ ");",6.0); 	
	if($Rechargingtitan[%player] != True)
	{
		$Rechargingtitan[%player] = True;
		%guntype = Titan;
		schedule("RechargeTitan(" @ %player @ ", " @ %guntype @ ");",1,%player);
	}

}

function RechargeTitan(%player,%gunType)
{
	%armor = Player::GetArmor(%player);
	if(%gunType == Titan && (Player::getItemCount(%player,Titan) > 0))
	{
		if(Player::getItemCount(%player,TitanCell) < $ItemMax[%armor,TitanCell])
		{
			Player::incItemCount(%player,TitanCell,1);
			schedule("RechargeTitan(" @ %player @ ", " @ %gunType @ ");",0.5,%player);
		}
		else
			$Rechargingtitan[%player] = False;
	}
}



function reload(%player)
{
	%player.reloading = "";
	echo("ready");
	playSound(MortarReload, GameBase::getPosition(%player));
}






function IonShoc(%player)
{ 
	if(GameBase::getLOSInfo(%player,10000)) 
	{
		%object = getObjectType($los::object); 
		%xopos = getWord($los::position,0) ; 
		%yopos = getWord($los::position,1) ; 
		%zopos = getWord($los::position,2) ; 
		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
	}
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 

	%trans1= getWord(%trans,0); 
	%trans2= getWord(%trans,1); 
	%trans3= getWord(%trans,2); 
	%trans4= getWord(%trans,3) ; 
	%trans5= getWord(%trans,4) ; 
	%trans6= getWord(%trans,5) ; 
	%trans7= getWord(%trans,6); 
	%trans8= getWord(%trans,7); 
	%trans9= getWord(%trans,8); 
	%trans10=getWord(%trans,9); 
	%trans11=getWord(%trans,10); 
	%trans12=getWord(%trans,11); 
	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
	//%NewTrans = %trans1 @" "@ %pos; 


	Projectile::spawnProjectile("ShockWavShell", %NewTrans, %player, 1);
	Projectile::spawnProjectile("IonShell", %NewTrans, %player, 1); 
	Projectile::spawnProjectile(%newObj); 

}

