$AutoUse[Blaster] = True; 
$AutoUse[Chaingun] = True; 
$AutoUse[PlasmaGun] = True; 
$AutoUse[Mortar] = True; 
$AutoUse[GrenadeLauncher] = True; 
$AutoUse[LaserRifle] = True; 
$AutoUse[EnergyRifle] = True; 
$AutoUse[TargetingLaser] = False; 
$AutoUse[Fixit] = False; 
$AutoUse[Flamer] = True; 
$AutoUse[RocketLauncher] = True; 
$AutoUse[SniperRifle] = True; 
$AutoUse[WaveGun] = True; 
$AutoUse[Railgun] = True; 
$AutoUse[Omega] = True; 
$AutoUse[Vulcan] = True; 
$AutoUse[Silencer] = True; 
$AutoUse[PlasmaCannon] = True; 
$AutoUse[TranqGun] = True; 
$AutoUse[Napalm] = True; 
$AutoUse[Shotgun] = True; 
$AutoUse[DiscLauncher] = True;
$AutoUse[SR] = True;
$AutoUse[Rifle] = True;
$AutoUse[TankRPGLauncher] = True;
$AutoUse[R] = True;
$AutoUse[KineticRifle] = True;
$AutoUse[AssFlak] = True;
$AutoUse[RocketBooster] = True;
$AutoUse[Nukex] = True;
$AutoUse[Flame] = True;
$AutoUse[Plasmat] = True;
$AutoUse[Grap] = True;
$AutoUse[Push] = True;
$AutoUse[Minigun] = True;
$AutoUse[ParticleBeamWeapon] = True; 


$WeaponAmmo[Blaster] = ""; 
$WeaponAmmo[PlasmaGun] = PlasmaAmmo; 
$WeaponAmmo[Chaingun] = BulletAmmo; 
$WeaponAmmo[DiscLauncher] = DiscAmmo; 
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo; 
$WeaponAmmo[Mortar] = MortarAmmo; 
$WeaponAmmo[LaserRifle] = ""; 
$WeaponAmmo[EnergyRifle] = ""; 
$WeaponAmmo[RocketLauncher] = RocketAmmo; 
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo; 
$WeaponAmmo[WaveGun] = ""; 
$WeaponAmmo[PlasmaCannon] = PlasCAmmo; 
$WeaponAmmo[Flamer] = ""; 
$WeaponAmmo[Shotgun] = ShotgunAmmo; 
$WeaponAmmo[Silencer] = SilencerAmmo; 
$WeaponAmmo[Vulcan] = VulcanAmmo; 
$WeaponAmmo[Omega] = ""; 
$WeaponAmmo[TranqGun] = TranqAmmo; 
$WeaponAmmo[Napalm] = NapalmAmmo;
$WeaponAmmo[SR] = SRAmmo;
$WeaponAmmo[Rifle] = Shells;
$WeaponAmmo[TankRPGLauncher] = "TankRPGAmmo";
$WeaponAmmo[R] = "ShriekAmmo";
$WeaponAmmo[KineticRilfe] = "KineticAmmo";
$WeaponAmmo[AssFlak] = "AssFlakAmmo";
$WeaponAmmo[RocketBooster] = "BoosterCharge";
$WeaponAmmo[Nukex] = "NukexAmmo";
$WeaponAmmo[Flame] = "";
$WeaponAmmo[Plasmat] = "PlasmatAmmo";
$WeaponAmmo[Grap] = "";
$WeaponAmmo[Push] = "";
$WeaponAmmo[MiniGun] = "MiniGunAmmo";
$WeaponAmmo[ParticleBeamWeapon] = "";


ItemData Weapon 
	{ 
	description = "Weapon"; 
	showInventory = false; 
	}; 

function Weapon::onUse(%player,%item)
{
	%ammo = %item.imageType.ammoType;
	if (%ammo == "") {
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else {
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else {
			Client::sendMessage(Player::getClient(%player),0,
			strcat(%item.description," has no ammo"));
		}
	}
} 

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload" && !$Reload)
		Item::onDrop(%player,%item);
}

 ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}

ItemData Ammo 
	{ 
	description = "Ammo"; 
	showInventory = false; 
	}; 

function Ammo::onDrop(%player,%item) 
	{ 
	if($matchStarted) 
	{ 
	%count = Player::getItemCount(%player,%item); 
	%delta = $SellAmmo[%item]; 
	if(%count <= %delta) 
	{ 
	if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) 
	%delta = %count; 
	else 
	%delta = %count - 1; 
	} 
	if(%delta > 0) 
	{ 
	%obj = newObject("","Item",%item,%delta,false); 
	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); 
	addToSet("MissionCleanup", %obj); 
	GameBase::throw(%obj,%player,20,false); 
	Item::playPickupSound(%obj); 
	Player::decItemCount(%player,%item,%delta); 
	} 
	} 
	}

// Easier to use for modding, just add a weapon, and modify the Max number
$WeaponNum[1] =  Nukex;
$WeaponNum[2] =  JailGun;
$WeaponNum[3] =  Blaster;
$WeaponNum[4] =  PlasmaGun;
$WeaponNum[5] =  Chaingun;
$WeaponNum[6] =  DiscLauncher;
$WeaponNum[7] =  GrenadeLauncher;
$WeaponNum[8] =  Mortar;
$WeaponNum[9] =  LaserRifle;
$WeaponNum[10] = RocketLauncher;
$WeaponNum[11] = SniperRifle;
$WeaponNum[12] = WaveGun;
$WeaponNum[13] = EnergyRifle;
$WeaponNum[14] = Railgun;
$WeaponNum[15] = Omega;
$WeaponNum[16] = Silencer;
$WeaponNum[17] = Vulcan;
$WeaponNum[18] = Flamer;
$WeaponNum[19] = PlasmaCannon;
$WeaponNum[20] = TranqGun;
$WeaponNum[21] = Napalm;
$WeaponNum[22] = Shotgun;
$WeaponNum[23] = Fixit;
$WeaponNum[24] = SR;
$WeaponNum[25] = F;
$WeaponNum[26] = TankRPGLauncher;
$WeaponNum[27] = R;
$WeaponNum[28] = KineticRifle;
$WeaponNum[29] = AssFlak;
$WeaponNum[30] = Flame;
$WeaponNum[31] = Plasmat;
$WeaponNum[32] = Grap;
$WeaponNum[33] = push;
$WeaponNum[34] = MiniGun;
$WeaponNum[35] = ParticleBeamWeapon;

$MaxWeapon=35;


function remoteNextWeapon(%client)
{
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f3>[<f1>You Have No Weapons<f3>]", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item++;
	if(%item == $MaxWeapon+1)
		%item = 1;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		$CurWeap = %item;
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else {
		%client.wcyc++; // PORT: one full turn of the weapon list at most
		if(%client.wcyc <= $MaxWeapon)
			remoteNextWeapon(%client);
	}
	%client.wcyc = "";
}

function remotePrevWeapon(%client)
{
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f3>[<f1>You Have No Weapons<f3>]", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item--;
	if(%item == 0)
		%item = $MaxWeapon;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else {
		%client.wcyc++; // PORT: one full turn of the weapon list at most
		if(%client.wcyc <= $MaxWeapon)
			remotePrevWeapon(%client);
	}
	%client.wcyc = "";
}

function selectValidWeapon(%client)
{
	%item = 1;
	for(%weapon = %item++; %weapon != %item; %weapon = %item++) {
		echo(%weapon);
		if(isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if($Reloading[%client] != 1) {
			if(%ammo == ""||Player::getItemCount(%client,%ammo) > 0||Player::getItemCount(%client,$Clip[%weapon]) > 0||%weapon == PAttack)
				return true;
		}
	}
	return false;
}
