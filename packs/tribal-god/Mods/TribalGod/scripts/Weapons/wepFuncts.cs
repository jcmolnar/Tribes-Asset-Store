//***************************************
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//***************************************
//
//function createWeapon(%weaponDN, %ammoDN, %ammoSell, %autoUse, %inv, %remote, %lmax, %mmax, %hmax, %emax){
//	addWeapon(%weaponDN);
//	$AutoUse[%weaponDN] = %autoUse;
//	AddToInv(%weaponDN, %inv, %remote);
//	AddToInv(%ammoDN, %inv, %remote);
//	ItemMax(FireScreenAbility, %lmax, %lmax, %mmax, %mmax, %hmax, %emax);

// All should be false..
$AutoUse[ExSmScreenAbility] = false;
$AutoUse[FireScreenAbility] = false;
$AutoUse[TankRPGLauncher] = false;
$AutoUse[SmScreenAbility] = false;
$AutoUse[TRocketLauncher] = false;
$AutoUse[GrenadeLauncher] = false;
$AutoUse[DetPackLauncher] = false;
$AutoUse[FireballAbility] = false;
$AutoUse[TargetingLaser] = false;
$AutoUse[PlasmaCannon] = false;
$AutoUse[DiscLauncher] = false;
$AutoUse[TankShredder] = false;
$AutoUse[DoublePlasma] = false;
$AutoUse[MineLauncher] = false;
$AutoUse[SpellAbility] = false;
$AutoUse[EnergyRifle] = false;
$AutoUse[MineSweeper] = false;
$AutoUse[LiLPOOmkii] = false;
$AutoUse[BeamOfPain] = false;
$AutoUse[LaserRifle] = false;
$AutoUse[TaserRifle] = false;
$AutoUse[GrenadeGun] = false;
$AutoUse[LiLPOOmki] = false;
$AutoUse[PlasmaGun] = false;
$AutoUse[JailRifle] = false;
$AutoUse[AirStrike] = false;
$AutoUse[Chaingun] = false;
$AutoUse[JailGun] = false;
$AutoUse[Blaster] = false;
$AutoUse[Mortar] = false;
$AutoUse[LiLFFB] = false;
$Use[Blaster] = false;


//========== Establish InvList ==========//
// Weapons: (Complete)
AddToInv(ExSmScreenAbility, 1, 1);
AddToInv(FireScreenAbility, 1, 1);
AddToInv(TankRPGLauncher, 1, 1);
AddToInv(GrenadeLauncher, 1, 1);
AddToInv(SmScreenAbility, 1, 1);
AddToInv(DetPackLauncher, 1, 1);
AddToInv(FireballAbility, 1, 1);
AddToInv(TRocketLauncher, 1, 1);
AddToInv(TargetingLaser, 0, 0);
AddToInv(PlasmaCannon, 1, 1);
AddToInv(DiscLauncher, 1, 1);
AddToInv(TankShredder, 1, 1);
AddToInv(DoublePlasma, 1, 1);
AddToInv(MineLauncher, 1, 1);
AddToInv(SpellAbility, 1, 1);
AddToInv(EnergyRifle, 1, 1);
AddToInv(MineSweeper, 1, 0);
AddToInv(LaserRifle, 1, 0);
AddToInv(LiLPOOmkii, 1, 1);
AddToInv(BeamOfPain, 1, 1);
AddToInv(TaserRifle, 1, 1);
AddToInv(GrenadeGun, 1, 1);
AddToInv(JailRifle, 1, 0);
AddToInv(LiLPOOmki, 1, 1);
AddToInv(AirStrike, 1, 0);
AddToInv(PlasmaGun, 1, 1);
AddToInv(Chaingun, 1, 1);
AddToInv(JailGun, 1, 0);
AddToInv(ATosser, 1, 0);
AddToInv(Blaster, 1, 0);
AddToInv(LiLFFB, 1, 1);
AddToInv(Mortar, 1, 1);


// Ammo: (Complete)
AddToInv(FireScreenAbilityAmmo, 1, 1);
AddToInv(ExSmScreenAbilityAmmo, 1, 1);
AddToInv(FireballAbilityAmmo, 1, 1);
AddToInv(SmScreenAbilityAmmo, 1, 1);
AddToInv(TRocketLauncherAmmo, 1, 1);
AddToInv(DetPackLauncherAmmo, 1, 0);
AddToInv(TankShredderAmmo, 1, 1);
AddToInv(DoublePlasmaAmmo, 1, 1);
AddToInv(SpellAbilityAmmo, 1, 1);
AddToInv(MineLauncherAmmo, 1, 1);
AddToInv(LiLPOOmkiiAmmo, 1, 1);
AddToInv(LiLPOOmkiAmmo, 1, 1);
AddToInv(ATosserAmmo, 1, 1);
AddToInv(GrenadeAmmo, 1, 1);
AddToInv(TankRPGAmmo, 1, 1);
AddToInv(BulletAmmo, 1, 1);
AddToInv(PlasmaAmmo, 1, 1);
AddToInv(LiLFFBAmmo, 1, 1);
AddToInv(MortarAmmo, 1, 1);
AddToInv(DiscAmmo, 1, 1);
//=======================================//


//==================== Establish Item Max ====================//
// Weapons: (Complete)
ItemMax(FireScreenAbility, 1, 1, 1, 1, 1, 0);
ItemMax(ExSmScreenAbility, 1, 1, 1, 1, 1, 0);
ItemMax(TRocketLauncher, 1, 1, 1, 1, 1, 0);
ItemMax(FireballAbility, 1, 1, 1, 1, 1, 0);
ItemMax(SmScreenAbility, 1, 1, 1, 1, 1, 0);
ItemMax(GrenadeLauncher, 1, 1, 1, 1, 1, 1);
ItemMax(TankRPGLauncher, 1, 1, 1, 1, 1, 0);
ItemMax(DetPackLauncher, 0, 0, 1, 1, 1, 0);
ItemMax(TargetingLaser, 0, 0, 0, 0, 0, 1);
ItemMax(TankShredder, 1, 1, 1, 1, 1, 0);
ItemMax(MineLauncher, 1, 1, 1, 1, 1, 1);
ItemMax(DiscLauncher, 1, 1, 1, 1, 1, 1);
ItemMax(SpellAbility, 1, 1, 1, 1, 1, 0);
ItemMax(DoublePlasma, 1, 1, 1, 1, 1, 1);
ItemMax(PlasmaCannon, 1, 1, 1, 1, 1, 1);
ItemMax(EnergyRifle, 1, 1, 1, 1, 1, 0);
ItemMax(MineSweeper, 0, 0, 0, 0, 0, 1);
ItemMax(BeamOfPain, 1, 1, 1, 1, 1, 0);
ItemMax(LaserRifle, 1, 1, 1, 1, 1, 0);
ItemMax(TaserRifle, 1, 1, 1, 1, 1, 0);
ItemMax(GrenadeGun, 1, 1, 1, 1, 1, 0);
ItemMax(LiLPOOmkii, 1, 1, 1, 1, 1, 0);
ItemMax(AirStrike, 1, 1, 1, 1, 1, 0);
ItemMax(JailRifle, 1, 1, 0, 0, 0, 1);
ItemMax(LiLPOOmki, 1, 1, 1, 1, 1, 0);
ItemMax(JailGun  , 0, 0, 1, 1, 1, 0);
ItemMax(ATosser  , 1, 1, 0, 0, 0, 0);
ItemMax(Blaster  , 1, 1, 1, 1, 1, 1);
ItemMax(Chaingun , 1, 1, 1, 1, 1, 0);
ItemMax(PlasmaGun, 1, 1, 1, 1, 1, 0);
ItemMax(LiLFFB   , 1, 1, 1, 1, 1, 1);
ItemMax(Mortar   , 1, 1, 1, 1, 1, 1);

// Ammo: (Complete)
ItemMax(FireScreenAbilityAmmo, 150, 150, 200, 200, 275, 0);
ItemMax(ExSmScreenAbilityAmmo, 25, 25, 75, 75, 100, 0);
ItemMax(FireballAbilityAmmo, 200, 200, 250, 250, 375, 0);
ItemMax(SmScreenAbilityAmmo, 100, 100, 150, 150, 200, 0);
ItemMax(TRocketLauncherAmmo, 150, 150, 200, 200, 275, 0);
ItemMax(DetPackLauncherAmmo, 0, 0, 5, 5, 10, 0);
ItemMax(TankShredderAmmo, 500, 500, 750, 750, 999, 0);
ItemMax(DoublePlasmaAmmo, 450, 450, 500, 500, 999, 350);
ItemMax(SpellAbilityAmmo, 250, 250, 375, 375, 500, 0);
ItemMax(MineLauncherAmmo, 45, 45, 75, 75, 100, 15);
ItemMax(LiLPOOmkiiAmmo, 10000, 10000, 10000, 10000, 10000, 0);
ItemMax(LiLPOOmkiAmmo, 10000, 10000, 10000, 10000, 10000, 0);
ItemMax(ATosserAmmo, 45, 45, 100, 100, 250, 0);
ItemMax(GrenadeAmmo, 100, 100, 250, 250, 500, 350);
ItemMax(TankRPGAmmo, 50, 50, 75, 75, 150, 0);
ItemMax(BulletAmmo, 500, 500, 750, 750, 999, 0);
ItemMax(PlasmaAmmo, 500, 500, 750, 750, 999, 0);
ItemMax(LiLFFBAmmo, 25, 25, 30, 30, 50, 350);
ItemMax(MortarAmmo, 40, 40, 50, 50, 75, 350);
ItemMax(DiscAmmo, 350, 350, 375, 375, 450, 350);
//============================================================//


//========== Ammount Of Ammo To Sell Or Drop ==========//
$SellAmmo[ExSmScreenAbilityAmmo] = 25;
$SellAmmo[FireScreenAbilityAmmo] = 25;
$SellAmmo[DetPackLauncherAmmo] = 5;
$SellAmmo[SmScreenAbilityAmmo] = 25;
$SellAmmo[TRocketLauncherAmmo] = 20;
$SellAmmo[TG::ClayMorMineAmmo] = 5;
$SellAmmo[DoublePlasmaAmmo] = 50;
$SellAmmo[MineLauncherAmmo] = 25;
$SellAmmo[TankShredderAmmo] = 25;
$SellAmmo[SpellAbilityAmmo] = 50;
$SellAmmo[LiLPOOmkiiAmmo] = 25;
$SellAmmo[RadiusMineAmmo] = 1;
$SellAmmo[LiLPOOmkiAmmo] = 25;
$SellAmmo[FlashGrenade] = 25;
$SellAmmo[LiLBoostammo] = 25;
$SellAmmo[GrenadeAmmo] = 25;
$SellAmmo[TankRPGAmmo] = 25;
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 25;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[LiLFFBAmmo] = 5;
$SellAmmo[DiscAmmo] = 50;
$SellAmmo[MineAmmo] = 10;
$SellAmmo[Grenade] = 10;
$SellAmmo[Beacon] = 10;
//=====================================================//


//========== Weapon To Ammo Table ==========//
$WeaponAmmo[ExSmScreenAbility] = ExSmScreenAbilityAmmo;
$WeaponAmmo[FireScreenAbility] = FireScreenAbilityAmmo;
$WeaponAmmo[FireballAbility] = FireballAbilityAmmo;
$WeaponAmmo[SmScreenAbility] = SmScreenAbilityAmmo;
$WeaponAmmo[TRocketLauncher] = TRocketLauncherAmmo;
$WeaponAmmo[DetPackLauncher] = DetPackLauncherAmmo;
$WeaponAmmo[TankRPGLauncher] = TankRPGAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[PlasmaCannon] = "";
$WeaponAmmo[MineLauncher] = MineLauncherAmmo;
$WeaponAmmo[TankShredder] = TankShredderAmmo;
$WeaponAmmo[DoublePlasma] = DoublePlasmaAmmo;
$WeaponAmmo[SpellAbility] = SpellAbilityAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[PlasmaCannon] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[MineSweeper] = "";
$WeaponAmmo[LiLPOOmkii] = LiLPOOmkiiammo;
$WeaponAmmo[BeamOfPain] = "";
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[TaserRifle] = "";
$WeaponAmmo[LiLPOOmki] = LiLPOOmkiammo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[JailRifle] = "";
$WeaponAmmo[AirStrike] = "";
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[ATosser] = ATosserAmmo;
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[JailGun] = "";
$WeaponAmmo[LiLFFB] = LiLFFBammo;
$WeaponAmmo[Mortar] = Mortarammo;
//==========================================//


//========== New Ways Of Setting Up Next/Previous Weapon Table ==========//
$FirstWeapon = "";
$LastWeapon  = "";

function addWeapon(%weap){
	if($FirstWeapon == "") $FirstWeapon = %weap;
	if($LastWeapon == "") $LastWeapon = %weap;
	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;
	$LastWeapon = %weap;
}

// I marked each one with a number for
// easy reference on how many i have.
addWeapon(Blaster);          // 1
addWeapon(PlasmaGun);        // 2
addWeapon(MineLauncher);     // 3
addWeapon(DoublePlasma);     // 4
addWeapon(LiLPOOmki);        // 5
addWeapon(LiLPOOmkii);       // 6
addWeapon(DiscLauncher);     // 7
addWeapon(FireballAbility);  // 8
addWeapon(FireScreenAbility);// 9
addWeapon(SmScreenAbility);  // 10
addWeapon(SpellAbility);     // 11
addWeapon(LaserRifle);       // 12
addWeapon(TankRPGLauncher);  // 13
addWeapon(TankShredder);     // 14
addWeapon(TRocketLauncher);  // 15
addWeapon(PlasmaCannon);     // 16
addWeapon(DetPackLauncher);  // 17
addWeapon(ATosser);          // 18
addWeapon(EnergyRifle);      // 19
addWeapon(Chaingun);         // 20
addWeapon(GrenadeLauncher);  // 21
addWeapon(Mortar);           // 22
addWeapon(LiLFFB);           // 23
addWeapon(BeamOfPain);       // 24
addWeapon(JailGun);          // 25
addWeapon(JailRifle);        // 26
AddWeapon(AirStrike);        // 27
addWeapon(TaserRifle);       // 28
addWeapon(ExSmScreenAbility);// 29
addWeapon(RepairGun);        // 30
addWeapon(MineSweeper);      // 31
addWeapon(GrenadeGun);       // 32
//=======================================================================//


function remoteNextWeapon(%client){
	//Echo("Observer Mode: "@ %client.observerMode);
	if(%client.observerMode != "") return;
	%player = Client::getOwnedObject(%client);
	if(%player.driver){
		%vehicle = %player.vehicle;
		%vName = GameBase::getDataName(%vehicle);
		if($Vehicle::Number[%vName, $Vehicle::curWeapon[%vehicle]] < 4){
			%num = $Vehicle::Number[%vName, $Vehicle::curWeapon[%vehicle]];
			$Vehicle::curWeapon[%vehicle] = $Vehicle::Weapon[%vName, %num +1];
			BottomPrint(%client, "<jc><f1>"@ %vName @" Weapon Mode: <f2>"@ $MountMsg[$Vehicle::curWeapon[%vehicle]], 5);
		}else{
			$Vehicle::curWeapon[%vehicle] = $Vehicle::Weapon[%vName, 1];
			Vehicles::onChangeWeapon(%vehicle);
			BottomPrint(%client, "<jc><f1>"@ %vName @" Weapon Mode: <f2>"@ $MountMsg[$Vehicle::curWeapon[%vehicle]], 5);
		}
		return;
	}
	//==== Possession Junk ====// ]KyA[X-Ecutioner
	if(%client.isPossessed == true) return;
	if(%client.isPossessing == true) %newClient = %client.hasPossClient;
	else %newClient = %client;
	//=========================//
	
	if($debug)
	{ echo("remote next weapon "@ %newClient); }
	%item = Player::getMountedItem(%newClient, $WeaponSlot);
	if(%item == -1 || $NextWeapon[%item] == "")
	{ selectValidWeapon(%newClient); }
	else{
		for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]){
			if(isSelectableWeapon(%newClient, %weapon)){
				Player::useItem(%newClient,%weapon);
				if(Player::getMountedItem(%newClient, $WeaponSlot) == %weapon || Player::getNextMountedItem(%newClient, $WeaponSlot) == %weapon) break;
			}
		}
	}
}

function remotePrevWeapon(%client){
	//Echo("Observer Mode: "@ %client.observerMode);
	if(%client.observerMode != "") return;
	%player = Client::getOwnedObject(%client);
	if(%player.driver){
		%vehicle = %player.vehicle;
		%vName = GameBase::getDataName(%vehicle);
		if($Vehicle::Number[%vName, $Vehicle::curWeapon[%vehicle]] > 1){
			%num = $Vehicle::Number[%vName, $Vehicle::curWeapon[%vehicle]];
			$Vehicle::curWeapon[%vehicle] = $Vehicle::Weapon[%vName, %num -1];
			BottomPrint(%client, "<jc><f1>"@ %vName @" Weapon Mode: <f2>"@ $MountMsg[$Vehicle::curWeapon[%vehicle]], 5);
		}else{
			$Vehicle::curWeapon[%vehicle] = $Vehicle::Weapon[%vName, 4];
			Vehicles::onChangeWeapon(%vehicle);
			BottomPrint(%client, "<jc><f1>"@ %vName @" Weapon Mode: <f2>"@ $MountMsg[$Vehicle::curWeapon[%vehicle]], 5);
		}
		return;
	}
	//==== Possession Junk ====// [TG]-X-Ecutioner
	if(%client.isPossessed == true) return;
	if(%client.isPossessing == true) %newClient = %client.hasPossClient;
	else %newClient = %client;
	//=========================//
	%item = Player::getMountedItem(%newClient, $WeaponSlot);
	if(%item == -1 || $PrevWeapon[%item] == "") selectValidWeapon(%newClient);
	else{
		for(%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]){
			if(isSelectableWeapon(%newClient, %weapon)){
				Player::useItem(%newClient,%weapon);
				if(Player::getMountedItem(%newClient, $WeaponSlot) == %weapon || Player::getNextMountedItem(%newClient,$WeaponSlot) == %weapon) break;
			}
		}
	}
}

function selectValidWeapon(%client){
	%item = $FirstWeapon;
	for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
	{
		if(isSelectableWeapon(%client, %weapon)){
			Player::useItem(%client, %weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon))
	{
		%ammo = $WeaponAmmo[%weapon];
		if(%ammo == "" || Player::getItemCount(%client, %ammo) > 0)
		{ return true; }
	}
	return false;
}

//====================================
// Extra weapon mode junk.. - DB
$WepModes[DiscLauncher] = true;
$WepModes[MineLauncher] = true;
$WepModes[Blaster] = true;
$WepModes[Mortar] = true;
//====================================

function Weapon::onUse(%player, %item){
	%client = Player::getClient(%player);
	if(%player.Station == ""){
		%ammo = %item.imageType.ammoType;
		if(%ammo == "") Player::mountItem(%player, %item, $WeaponSlot);
		else{
			if(Player::getItemCount(%player, %ammo) > 0) Player::mountItem(%player, %item, $WeaponSlot);
			else Client::sendMessage(Player::getClient(%player), 0, strcat(%item.description," has no ammo."));
		}
		if(%client.justLeftStation == true) return;
		if(%client.Tutorial == 1 || %client.Tutorial == "") BottomPrint(%client, "<jc>Using: <f2>"@ %item.description, 5);
		else if(%client.Tutorial == 2){
			if($WepModes[%item] == true){
				XBottomPrint(%client, "<jc><f1>"@ %item.description @": "@ $MountMsg[%item, $WeaponMode[%client, %item]], 5);
			}else{
				XBottomPrint(%client, "<jc><f1>"@ %item.description @": "@ $MountMsg[%item], 5);
			}
		}
	} 
}

function Ammo::onDrop(%player,%item){
	if($matchStarted){
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta){
			if(%item == BulletAmmo || (Player::getMountedItem(%player, $WeaponSlot)).imageType.ammoType != %item)
			{ %delta = %count; }
			else
			{ %delta = %count - 1; }
		}
		if(%delta > 0){
			%obj = newObject("", "Item", %item, %delta, false);
			schedule("Item::Pop("@ %obj @");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj, %player, 20, false);
			Item::playPickupSound(%obj);
			if($TG::InfiniteDropAmmo != true)
			{ Player::decItemCount(%player, %item, %delta); }
		}
	}
}


function SplitExplosion(%newobj, %this){
	%Pos = GameBase::getPosition(%newobj); 
   	%vel = Item::getVelocity(%newobj);

	%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function ScatterBombs2(%newobj, %this, %count, %delete){
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%xvel = getWord(%vel,0);
	%yvel = getWord(%vel,1);
	%zvel = getWord(%vel,2);
	if(GameBase::getPosition(%newObj))
	{
		for(%i = 0; %i < %count; %i += 1)
		{
			%xrnd = %xvel + floor(getRandom() * 60) -30;
			%yrnd = %yvel + floor(getRandom() * 60) -30;
			%zrnd = %zvel + floor(getRandom() * 20);
			%forceVel = %xrnd @" "@ %yrnd @" "@ %zrnd;
			%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%newObj);
			%obj = Projectile::spawnProjectile("MortarShell420", %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %forceVel);
			%rnd = (floor(getRandom()*20)/80);
		}
		if(%delete)
		{ deleteobject(%newObj); }
	}
}

//===== This is A Combination\Variation On Some Of Plasmatic's Functions ====//
function TG::TossMines(%newobj, %this, %count, %delete, %tossProj, %isMine)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%xvel = getWord(%vel, 0);
	%yvel = getWord(%vel, 1);
	%zvel = getWord(%vel, 2);
	if(GameBase::getPosition(%newObj))
	{
		for(%i = 0; %i < %count; %i += 1)
		{
			%xrnd = %xvel + floor(getRandom() * 80) -30;
			%yrnd = %yvel + floor(getRandom() * 80) -30;
			%zrnd = %zvel + floor(getRandom() * 20);
			%forceVel = %xrnd @" "@ %yrnd @" "@ %zrnd;
			%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%newObj);
			%obj = Projectile::spawnProjectile(%tossProj, %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %forceVel);
			if(%isMine)
			{
				%rnd = (floor(getRandom() * 20) / 80);
				Schedule("SetMines("@ %obj @", "@ %this @");", 2 - %rnd);
			}
		}
		if(%delete)
		{ deleteobject(%newObj); }
	}
}
//===========================================================================//

function CoolGun(%clientId, %time)
{
	%clientId.coolingGun = 1;
	Schedule(%clientId @".coolingGun = 0;", %time);
}

function SplitMines(%newobj, %this)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMines(%newobj,%this,%count,%delete)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%xvel = getWord(%vel, 0);
	%yvel = getWord(%vel, 1);
	%zvel = getWord(%vel, 2);
	if (GameBase::getPosition(%newObj))
	{
		for(%i = 0; %i < %count; %i += 1)
		{
			%xrnd = %xvel + floor(getRandom() * 60) - 30;
			%yrnd = %yvel + floor(getRandom() * 60) - 30;
			%zrnd = %zvel + floor(getRandom() * 20);
			%forceVel = %xrnd @" "@ %yrnd @" "@ %zrnd;
			%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%newObj);
			%obj = Projectile::spawnProjectile("MineFloaters", %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %forceVel);
			%rnd = (floor(getRandom() * 20) / 80);
			Schedule("SetMines("@ %obj @", "@ %this @");", 2 - %rnd);
		}
		if (%delete)
		{ deleteobject(%newObj); }
	}
}

function SetMines(%newobj, %this)
{
	if (GameBase::getPosition(%newObj))
	{
		%Pos = GameBase::getPosition(%newobj); 
		%vel = Item::getVelocity(%newobj);
		%Mine = newObject("", "Mine", "antipersonelMine");
		%mine.noOwner = "";
		if(player::isdead(%this))
		{ %team = %this.team; %mine.noOwner = true; }
		else
		{ %team = GameBase::getTeam (%this); }
		addToSet("MissionCleanup", %Mine);
		GameBase::throw(%Mine,%this,-1,true);
		GameBase::setTeam (%Mine,%team);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);
		deleteobject(%newObj);
	}
}

// To Be Honest, I've Tried This Function Out. Doesn't Work For 
// Me At All. Even Though I Don't See How, I Could Be Doing 
// Something Wrong :-\
function getPerfectTrans(%player)
{
        $los::position = "";
        GameBase::getLOSInfo(%player, 3000);
        %rot = GameBase::getRotation(%player);
        %targetPos = $los::position;
        $los::position = "";
        %trans = GameBase::getMuzzleTransform(%player);
        %vec0 = getWord(%trans, 0);
        %vec1 = getWord(%trans, 1);
        %vec2 = getWord(%trans, 2);
        %vec3 = getWord(%trans, 6);
        %vec4 = getWord(%trans, 7);
        %vec5 = getWord(%trans, 8);
        %vec6 = getWord(%trans, 9);
        %vec7 = getWord(%trans, 10);
        %vec8 = getWord(%trans, 11);
        %rot1 = %vec3 @" "@ %vec4 @" "@ %vec5;
        %pos1 = %vec6 @" "@ %vec7 @" "@ %vec8;
        %rot0 = Vector::getRotAim(%Pos1, %targetPos);
        %vec = Vector::getFromRot(%rot0, 1);
        if(%targetPos)
        { %trans = %vec0 @" "@ %vec1 @" "@ %vec2 @" "@ %vec @" "@ %rot1 @" "@ %pos1; }
        return %trans;
}

function ScatterBombs(%player, %client, %obj)
{
	%pos = GameBase::getPosition(%obj);
	%vel = Item::getVelocity(%obj);
	for(%i = 0; %i < 5; %i++)
	{
		%xrnd = floor(getRandom() * 60) -30;
		%yrnd = floor(getRandom() * 60) -30;
		%zrnd = floor(getRandom() * 60) -30;
		%newvel = %xrnd@" "@%yrnd@" "@%zrnd;
		%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%obj);
		%newobj = Projectile::spawnProjectile(AtomShell2, %trans, %player, %vel);
		GameBase::setPosition(%newobj, %pos);
		Item::setVelocity(%newobj, %newvel);
	}
}