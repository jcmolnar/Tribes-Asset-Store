//----------------------------------------------------------------------------
// Tools, Weapons & ammo Variables
//----------------------------------------------------------------------------
$ItemPopTime = 3;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = False;
$AutoUse[Chaingun] = False;
$AutoUse[PlasmaGun] = False;
$AutoUse[Mortar] = False;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[LaserRifle] = False;
$AutoUse[EnergyRifle] = False;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[FireballAbility] = False;
$AutoUse[SmScreenAbility] = False;
$AutoUse[ExSmScreenAbility] = False;
$AutoUse[FireScreenAbility] = False;
$AutoUse[SpellAbility] = False;
$AutoUse[TaserRifle] = False;
$AutoUse[LiLFFB] = False;
$AutoUse[LiLPOOmkii] = False;
$AutoUse[LiLPOOmki] = False;
$AutoUse[LiLRocketLauncher] = False;
$AutoUse[LiLEMPRocketLauncher] = False;
$AutoUse[BeamOfPain] = False;
$AutoUse[IX2002] = False;
$AutoUse[FEB] = False;
$AutoUse[CloakGun] = False;
$AutoUse[ShotGun] = False;
$AutoUse[Nuclear] = False;
$AutoUse[Jailgun] = False;
$AutoUse[Verminator] = False;
$AutoUse[Atomizer] = False;
$Use[Blaster] = False;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 50;
$SellAmmo[PlasmaAmmo] = 50;
$SellAmmo[DiscAmmo] = 50;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[RadiusMineAmmo] = 5;
$SellAmmo[SmScreenAbilityAmmo] = 50;
$SellAmmo[ExSmScreenAbilityAmmo] = 50;
$SellAmmo[FireScreenAbilityAmmo] = 50;
$SellAmmo[SpellAbilityAmmo] = 50;
$SellAmmo[LiLPOOmkiiAmmo] = 50;
$SellAmmo[LiLPOOmkiAmmo] = 50;
$SellAmmo[LiLFFBAmmo] = 50;
$SellAmmo[LiLRocketLauncherAmmo] = 50;
$SellAmmo[LiLEMPRocketLauncherAmmo] = 50;
$SellAmmo[IX2002Ammo] = 50;
$SellAmmo[FEBAmmo] = 50;
$SellAmmo[ShotgunAmmo] = 50;
$SellAmmo[VerminatorAmmo] = 50;
$SellAmmo[NuclearAmmo] = 1;
$SellAmmo[AtomizerAmmo] = 10;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;

// Limit on number of special Items you can buy-ZX
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[BaseAlarm] = 10;
$TeamItemMax[ArbitorBoxPack] = 3;
$TeamItemMax[AirbasePack] = 1;
$TeamItemMax[RemoteBase] = 1;
$TeamItemMax[Jailcappack] = 5;
$TeamItemMax[Jailpack] = 1;
$TeamItemMax[ElectricWeb] = 5;
$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[MercJetVehicle] = 10;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 12;
$TeamItemMax[Beacon] = 500;
$TeamItemMax[mineammo] = 500;
$TeamItemMax[TaserTrtBPack] = 10;
$TeamItemMax[TaserTrtCPack] = 10;
$TeamItemMax[LaserTurretPack] = 10;
$TeamItemMax[MaliceTurretPack] = 10;
$TeamItemMax[LaserTurretBPack] = 10;
$TeamItemMax[MiniFlakTurretPack] = 10;
$TeamItemMax[MiniSAMTurretPack] = 10;
$TeamItemMax[MiniELFTurretPack] = 10;
$TeamItemMax[MiniSmokeTurretPack] = 10;
$TeamItemMax[lgaForceFieldPack] = 12;
$TeamItemMax[lgbForceFieldPack] = 12;
$TeamItemMax[medaForceFieldPack] = 12;
$TeamItemMax[medbForceFieldPack] = 12;
$TeamItemMax[medcForceFieldPack] = 12;
$TeamItemMax[DeployableTeleport] = 4;
$TeamItemMax[cactuspack] = 4;
$TeamItemMax[radiusmineammo] = 1;




// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};

// Weapon to ammo table-ZX
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortarammo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[TaserRifle] = "";
$WeaponAmmo[BeamOfPain] = "";
$WeaponAmmo[LiLFFB] = LiLFFBammo;
$WeaponAmmo[LiLPOOmkii] = LiLPOOmkiiammo;
$WeaponAmmo[LiLPOOmki] = LiLPOOmkiammo;
$WeaponAmmo[LiLRocketLauncher] = LiLRocketLauncherammo;
$WeaponAmmo[LiLEMPRocketLauncher] = LiLEMPRocketLauncherammo;
$WeaponAmmo[FireballAbility] = "";
$WeaponAmmo[SmScreenAbility] = SmScreenAbilityAmmo;
$WeaponAmmo[ExSmScreenAbility] = ExSmScreenAbilityAmmo;
$WeaponAmmo[FireScreenAbility] = FireScreenAbilityAmmo;
$WeaponAmmo[SpellAbility] = SpellAbilityAmmo;
$WeaponAmmo[IX2002] = IX2002ammo;
$WeaponAmmo[FEB] = FEBammo;
$WeaponAmmo[CloakGun] = "";
$WeaponAmmo[JailGun] = "";
$WeaponAmmo[Shotgun] = Shotgunammo;
$WeaponAmmo[Nuclear] = Nuclearammo;
$WeaponAmmo[Verminator] = Verminatorammo;
$WeaponAmmo[Atomizer] = Atomizerammo;

$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = LiLPOOmki;
$NextWeapon[LiLPOOmki] = LiLPOOmkii;
$NextWeapon[LiLPOOmkii] = DiscLauncher;
$NextWeapon[DiscLauncher] = FireballAbility;
$NextWeapon[FireBallAbility] = SmScreenAbility;
$NextWeapon[SmScreenAbility] = ExSmScreenAbility;
$NextWeapon[ExSmScreenAbility] = FireScreenAbility;
$NextWeapon[FireScreenAbility] = SpellAbility;
$NextWeapon[SpellAbility] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LiLFFB;
$NextWeapon[LiLFFB] = LiLRocketLauncher;
$NextWeapon[LiLRocketLauncher] = LiLEMPRocketLauncher;
$NextWeapon[LiLEMPRocketLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = TaserRifle;
$NextWeapon[TaserRifle] = BeamOfPain;
$NextWeapon[BeamOfPain] = IX2002;
$NextWeapon[IX2002] = FEB;
$NextWeapon[FEB] = CloakGun;
$NextWeapon[CloakGun] = JailGun;
$NextWeapon[JailGun] = ShotGun;
$NextWeapon[ShotGun] = Nuclear;
$NextWeapon[Nuclear] = Verminator;
$NextWeapon[Verminator] = Atomizer;
$NextWeapon[Atomizer] = EnergyRifle;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[LiLPOOmki] = Chaingun;
$PrevWeapon[LiLPOOmkii] = LiLPOOmki;
$PrevWeapon[DiscLauncher] = LiLPOOmkii;
$PrevWeapon[FireBallAbility] = DiscLauncher;
$PrevWeapon[SmScreenAbility] = FireBallAbility;
$PrevWeapon[ExSmScreenAbility] = SmScreenAbility;
$PrevWeapon[FireScreenAbility] = ExSmScreenAbility;
$PrevWeapon[SpellAbility] = FireScreenAbility;
$PrevWeapon[GrenadeLauncher] = SpellAbility;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LiLFFB] = Mortar;
$PrevWeapon[LiLRocketLauncher] = LiLFFB;
$PrevWeapon[LiLEMPRocketLauncher] = LiLRocketLauncher;
$PrevWeapon[LaserRifle] = LiLEMPRocketLauncher;
$PrevWeapon[TaserRifle] = LaserRifle;
$PrevWeapon[BeamOfPain] = TaserRifle;
$PrevWeapon[IX2002] = BeamOfPain;
$PrevWeapon[FEB] = IX2002;
$PrevWeapon[CloakGun] = FEB;
$PrevWeapon[JailGun] = CloakGun;
$PrevWeapon[Shotgun] = JailGun;
$PrevWeapon[Nuclear] = Shotgun;
$PrevWeapon[Verminator] = Nuclear;
$PrevWeapon[Atomizer] = Verminator;
$PrevWeapon[EnergyRifle] = Atomizer;
//-----------------Weap On Mount Messages
$WDesc[EnergyGun] = "<jc><f2>ELF Mounted";
$WDesc[Blaster] = "<jc><f2>Blaster Mounted";
$WDesc[Plasmagun] = "<jc><f2>PlasmaGun Mounted";
$WDesc[Chaingun] = "<jc><f2>ChainGun Mounted";
$WDesc[LiLPOOmki] = "<jc><f2>IX-MayHeM Mounted";
$WDesc[LiLPOOmkii] = "<jc><f2>IX-Railgun Mounted";
$WDesc[DiscLauncher] = "<jc><f2>DiscLauncher Mounted";
$WDesc[FireballAbility] = "<jc><f2>Fire Ball Mounted";
$WDesc[SmScreenAbility] = "<jc><f2>Smoke Screen Mounted";
$WDesc[ExSmScreenAbility] = "<jc><f2>SplitWaster Mounted";
$WDesc[FireScreenAbility] = "<jc><f2>Field Of Fire Mounted";
$WDesc[SpellAbility] = "<jc><f2>Clone Spell Mounted";
$WDesc[GrenadeLauncher] = "<jc><f2>Grenade Launcher Mounted";
$WDesc[Mortar] = "<jc><f2>Mortar Mounted";
$WDesc[LiLFFB] = "<jc><f2>Heavy Impact Mortar Mounted";
$WDesc[LiLRocketLauncher] = "<jc><f2>LocK-JaW Mounted";
$WDesc[LiLEMPRocketLauncher] = "<jc><f2>Tracking Ion Cannon Mounted";
$WDesc[LaserRifle] = "<jc><f2>Laser Gat Mounted";
$WDesc[TaserRifle] = "<jc><f2>Taser Rifle Mounted";
$WDesc[BeamOfPain] = "<jc><f2>Beam O Pain Mounted";
$WDesc[IX2002] = "<jc><f2>IX-2002 Mounted";
$WDesc[FEB] = "<jc><f2>IX-FEB Mounted";
$WDesc[CloakGun] = "<jc><f2>CloakGun Mounted";
$WDesc[JailGun] = "<jc><f2>JailGun Mounted";
$WDesc[ShotGun] = "<jc><f2>ShotGun Mounted";
$WDesc[Nuclear] = "<jc><f2>Nuclear Emitter Mounted";
$WDesc[Verminator] = "<jc><f2>Retaliation Mounted";
$WDesc[Atomizer] = "<jc><f2>Atomizer Mounted";
$WDesc[Repairgun] = "<jc><f2>Repair Gun Mounted";
//+++++++++++++++++++++++++++++++++++++
// Weapon Code
//+++++++++++++++++++++++++++++++++++++
ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	if(%player.Station==""){
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
}


//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}



//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	