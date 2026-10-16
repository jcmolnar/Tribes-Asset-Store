//----------------------------------------------------------------------------

$ItemFavoritesKey = $Nappy::ItemFavorites;	// Change this if you add new items
						// and don't want to mess up everyone's
						// favorites - just put in something
						// that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;




$AutoUse[Blaster] = True; 
$AutoUse[Chaingun] = True; 
$AutoUse[PlasmaGun] = True; 
$AutoUse[Mortar] = True; 
$AutoUse[GrenadeLauncher] = True; 
$AutoUse[LaserRifle] = True; 
$AutoUse[EnergyRifle] = True; 
$AutoUse[TargetingLaser] = False; 
$AutoUse[Fixit] = True; 
$AutoUse[ChargeGun] = True; 
$AutoUse[RocketLauncher] = True; 
$AutoUse[SniperRifle] = True; 
$AutoUse[WaveGun] = True; 
$AutoUse[Railgun] = True; 
$AutoUse[Omega] = True; 
$AutoUse[Vulcan] = True; 
$AutoUse[Silencer] = True; 
$AutoUse[IonGun] = True; 
$AutoUse[TranqGun] = True; 
$AutoUse[Napalm] = True; 
$AutoUse[Shotgun] = True; 
$AutoUse[DiscLauncher] = True; 

$Use[Blaster] = True; 




$SellAmmo[ShotgunAmmo] = 5; 
$SellAmmo[NapalmAmmo] = 5; 
$SellAmmo[BulletAmmo] = 25; 
$SellAmmo[PlasmaAmmo] = 5; 
$SellAmmo[DiscAmmo] = 5; 
$SellAmmo[GrenadeAmmo] = 5; 
$SellAmmo[MortarAmmo] = 5; 
$SellAmmo[Beacon] = 5; 
$SellAmmo[Boost] = 5; 
$SellAmmo[Plastique] = 5; 
$SellAmmo[MineAmmo] = 5; 
$SellAmmo[Grenade] = 5; 
$SellAmmo[RocketAmmo] = 3; 
$SellAmmo[SniperAmmo] = 15; 
$SellAmmo[RailAmmo] = 25; 
$SellAmmo[SilencerAmmo] = 25; 
$SellAmmo[VulcanAmmo] = 100; 
$SellAmmo[TranqAmmo] = 2; 

$AmmoPackItems[0] = BulletAmmo; 
$AmmoPackItems[1] = PlasmaAmmo; 
$AmmoPackItems[2] = DiscAmmo; 
$AmmoPackItems[3] = GrenadeAmmo; 
$AmmoPackItems[4] = Grenade; 
$AmmoPackItems[5] = MineAmmo; 
$AmmoPackItems[6] = MortarAmmo; 
$AmmoPackItems[7] = Beacon; 
$AmmoPackItems[8] = RocketAmmo; 
$AmmoPackItems[9] = SniperAmmo; 
$AmmoPackItems[10] = RailAmmo; 
$AmmoPackItems[11] = VulcanAmmo; 
$AmmoPackItems[12] = TranqAmmo; 
$AmmoPackItems[13] = SilencerAmmo; 
$AmmoPackItems[14] = ShotgunAmmo; 
$AmmoPackItems[15] = NapalmAmmo; 

$AmmoPackMax[BulletAmmo] = 200; 
$AmmoPackMax[PlasmaAmmo] = 50; 
$AmmoPackMax[DiscAmmo] = 50; 
$AmmoPackMax[GrenadeAmmo] = 30; 
$AmmoPackMax[MortarAmmo] = 25; 
$AmmoPackMax[MineAmmo] = 35; 
$AmmoPackMax[Grenade] = 25; 
$AmmoPackMax[Beacon] = 10; 
$AmmoPackMax[Plastique] = 5; 
$AmmoPackMax[RocketAmmo] = 30; 
$AmmoPackMax[SniperAmmo] = 75; 
$AmmoPackMax[RailAmmo] = 30; 
$AmmoPackMax[VulcanAmmo] = 200; 
$AmmoPackMax[TranqAmmo] = 25; 
$AmmoPackMax[SilencerAmmo] = 25; 
$AmmoPackMax[ShotgunAmmo] = 10; 
$AmmoPackMax[NapalmAmmo] = 15; 

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 10;
$TeamItemMax[DeployableInvPack] = 15;
$TeamItemMax[DeployableComPack] = 5;

$TeamItemMax[CameraPack] = 10;
$TeamItemMax[IonTurretPack] = 25;
$TeamItemMax[LaserTurretPack] = 20;
$TeamItemMax[IndoorTurretPack] = 10;
$TeamItemMax[ShockTurretPack] = 20;
$TeamItemMax[AntiAirTurretPack] = 4;
$TeamItemMax[ElfTurretPack] = 10;
$TeamItemMax[MortarTurretPack] = 8;
$TeamItemMax[PlasmaTurretPack] = 20;
$TeamItemMax[RailTurretPack] = 4;
$TeamItemMax[RocketTurretPack] = 15;
$TeamItemMax[VulcanTurretPack] = 4;

$TeamItemMax[ArbitorPack] = 1;
$TeamItemMax[TeleportPack] = 4;
$TeamItemMax[FlagstandPack] = 4;
$TeamItemMax[JailCapPack] = 20;
$TeamItemMax[SpringPack] = 10;
$TeamItemMax[TreePack] = 40;
$TeamItemMax[HoloPack] = 25;
$TeamItemMax[BuilderPole] = 10;

$TeamItemMax[jailpack] = 1;
$TeamItemMax[RemoteBase] = 1;
$TeamItemMax[SniperHut] = 2;

$TeamItemMax[DeployableSensorJammerPack] = 30;
$TeamItemMax[PulseSensorPack] = 35;
$TeamItemMax[MotionSensorPack] = 35;
$TeamItemMax[BaseAlarm] = 10;

$TeamItemMax[ScoutVehicle] = 5;
$TeamItemMax[WraithVehicle] = 5;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 5;
$TeamItemMax[HAPCVehicle] = 5;

$TeamItemMax[Beacon] = 120;
$TeamItemMax[mineammo] = 200;
$TeamItemMax[SatchelPack] = 25;

//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
$TeamItemMax[BlastWallPack] = 100;
$TeamItemMax[newdooroneR] = 10;
$TeamItemMax[newdooroneL] = 10;
$TeamItemMax[newdoortwoR] = 10;
$TeamItemMax[newdoortwoL] = 10;
$TeamItemMax[newdoorthreeR] = 10;
$TeamItemMax[newdoorthreeL] = 10;
$TeamItemMax[newdoorfourR] = 10;
$TeamItemMax[newdoorfourL] = 10;
$TeamItemMax[DeployableForceField] = 30;
$TeamItemMax[LargeForceField] = 10;

$TeamItemMax[DeployablePlatform] = 200;
$TeamItemMax[MediumPlatform] = 10;
$TeamItemMax[LargePlatform] = 5;

$TeamItemMax[BlastDoor] = 5;
$TeamItemMax[doorthreebyfourForceField] = 10;
$TeamItemMax[doorfourbyeightForceField] = 10;
$TeamItemMax[doorfourbyfourteenForceField] = 10;
$TeamItemMax[doorfourbyseventeenForceField] = 10;
$TeamItemMax[doorfivebyfiveForceField] = 10;
$TeamItemMax[LargePlatformDoor] = 10;





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


$AutoUse[RepairKit] = false;



function Mission::reinitData()
{
	for(%i = -1; %i < 8 ; %i++){
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableComPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;

		$TeamItemCount[%i @ IonTurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ LaserTurretPack] = 0;
		$TeamItemCount[%i @ IndoorTurretPack] = 0;
		$TeamItemCount[%i @ ShockTurretPack] = 0;
		$TeamItemCount[%i @ AntiAirTurretPack] = 0;
		$TeamItemCount[%i @ ElfTurretPack] = 0;
		$TeamItemCount[%i @ MortarTurretPack] = 0;
		$TeamItemCount[%i @ PlasmaTurretPack] = 0;
		$TeamItemCount[%i @ RailTurretPack] = 0;
		$TeamItemCount[%i @ RocketTurretPack] = 0;
		$TeamItemCount[%i @ VulcanTurretPack] = 0;

		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ BaseAlarm] = 0;

		$TeamItemCount[%i @ Beacon] = 0;
		$TeamItemCount[%i @ mineammo] = 0;

		$TeamItemCount[%i @ BlastWallPack] = 0;
		$TeamItemCount[%i @ newdooroneR] = 0;
		$TeamItemCount[%i @ newdooroneL] = 0;
		$TeamItemCount[%i @ newdoortwoR] = 0;
		$TeamItemCount[%i @ newdoortwoL] = 0;
		$TeamItemCount[%i @ newdoorthreeR] = 0;
		$TeamItemCount[%i @ newdoorthreeL] = 0;
		$TeamItemCount[%i @ newdoorfourR] = 0;
		$TeamItemCount[%i @ newdoorfourL] = 0;
		$TeamItemCount[%i @ DeployableForceField] = 0;
		$TeamItemCount[%i @ LargeForceField] = 0;

		$TeamItemCount[%i @ DeployablePlatform] = 0;
		$TeamItemCount[%i @ MediumPlatform] = 0;
		$TeamItemCount[%i @ LargePlatform] = 0;

		$TeamItemCount[%i @ BlastDoor] = 0;
		$TeamItemCount[%i @ doorthreebyfourForceField] = 0;
		$TeamItemCount[%i @ doorfourbyeightForceField] = 0;
		$TeamItemCount[%i @ doorfourbyfourteenForceField] = 0;
		$TeamItemCount[%i @ doorfourbyseventeenForceField] = 0;
		$TeamItemCount[%i @ doorfivebyfiveForceField] = 0;
		$TeamItemCount[%i @ LargePlatformDoor] = 0;

		$TeamItemCount[%i @ TeleportPack] = 0;
		$TeamItemCount[%i @ SpringPack] = 0;
		$TeamItemCount[%i @ TreePack] = 0;
		$TeamItemCount[%i @ HoloPack] = 0;
		$TeamItemCount[%i @ BuilderPole] = 0;
		$TeamItemCount[%i @ JailCapPack] = 0;
		$TeamItemCount[%i @ ArbitorPack] = 0;
		$TeamItemCount[%i @ FlagstandPack] = 0;

		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ JetVehicle] = 0;
		$TeamItemCount[%i @ WraithVehicle] = 0;

		$TeamItemCount[%i @ jailpack] = 0;
		$TeamItemCount[%i @ RemoteBase] = 0;
		$TeamItemCount[%i @ SniperHut] = 0;

		$NumOfTeamTeleports[%i] = 0;
		$TeamTeleNum[%i,0] = 0;
		$TeamTeleNum[%i,1] = 0;
		$TeamTeleNum[%i,2] = 0;
		$TeamTeleNum[%i,3] = 0;
		$TeamTeleNum[%i,4] = 0;
		$TeamTeleNum[%i,5] = 0;
	}
	for(%i = 0; %i < $Server::MaxPlayers; %i++){
		%client = 2049 + %i;
		ClientItem::reinitData(%client);
	}
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}





function ClientItem::reinitData(%client)
{
	$totalNumMotionSensors[%client] = 0;
	$totalNumPulseSensors[%client] = 0;
	$totalNumSensorJammers[%client] = 0;
	$totalNumBaseAlarms[%client] = 0;

	$totalNumInventoryStations[%client] = 0;
	$totalNumAmmoStations[%client] = 0;
	$totalNumCommandStations[%client] = 0;

	$totalNumCameras[%client] = 0;
	$totalNumLaserTurrets[%client] = 0;
	$totalNumIonTurrets[%client] = 0;
	$totalNumIndoorTurrets[%client] = 0;
	$totalNumShockTurrets[%client] = 0;
	$totalNumAntiAirTurrets[%client] = 0;

	$totalNumElfTurrets[%client] = 0;
	$totalNumMortarTurrets[%client] = 0;
	$totalNumPlasmaTurrets[%client] = 0;
	$totalNumRailTurrets[%client] = 0;
	$totalNumRocketTurrets[%client] = 0;
	$totalNumVulcanTurrets[%client] = 0;

	$totalNumArbitors[%client] = 0;
	$totalNumTeleportPacks[%client] = 0;
	$totalNumDeployableFlagstands[%client] = 0;
	$totalNumSpringPacks[%client] = 0;
	$totalNumHolograms[%client] = 0;
	$totalNumTreePacks[%client] = 0;
	$totalNumJailCapPacks[%client] = 0;
	$totalNumBuilderPoles[%client] = 0;

	$totalNumDeployablePlatforms[%client] = 0;
	$totalNumMediumPlatforms[%client] = 0;
	$totalNumLargePlatforms[%client] = 0;

	$totalNumBlastDoors[%client] = 0;
	$totalNumdoorthreebyfourForceFields[%client] = 0;
	$totalNumdoorfourbyeightForceFields[%client] = 0;
	$totalNumdoorfourbyfourteenForceFields[%client] = 0;
	$totalNumdoorfourbyseventeenForceFields[%client] = 0;
	$totalNumdoorfivebyfiveForceFields[%client] = 0;
	$totalNumLargePlatformDoors[%client] = 0;

	$totalNumBlastWalls[%client] = 0;
	$totalNumnewdooroneR[%client] = 0;
	$totalNumnewdooroneL[%client] = 0;
	$totalNumnewdoortwoR[%client] = 0;
	$totalNumnewdoortwoL[%client] = 0;
	$totalNumnewdoorthreeR[%client] = 0;
	$totalNumnewdoorthreeL[%client] = 0;
	$totalNumnewdoorfourR[%client] = 0;
	$totalNumnewdoorfourL[%client] = 0;
	$totalNumDeployableForceFields[%client] = 0;
	$totalNumLargeForceFields[%client] = 0;

	$totalNumjailpacks[%client] = 0;
	$totalNumRemoteBases[%client] = 0;
	$totalNumSniperHuts[%client] = 0;

	$ClientRepairing[%client] = 0;
}










