function AddToInv(%item, %station, %remote){
	$InvList[%item] = %station;
	$RemoteInvList[%item] = %remote;
}

function ItemMax(%item, %lm, %lf, %mm, %mf, %h, %e){
	$ItemMax[larmor , %item] = %lm;
	$ItemMax[lfemale, %item] = %lf;
	$ItemMax[marmor , %item] = %mm;
	$ItemMax[mfemale, %item] = %mf;
	$ItemMax[harmor , %item] = %h;
	$ItemMax[Earmor , %item] = %e;
}

function DamageScale(%DamageType, %lm, %lf, %mm, %mf, %h, %e, %s, %lapc, %hapc){
	$DamageScale[larmor , %DamageType] = %lm;
	$DamageScale[lfemale, %DamageType] = %lf;
	$DamageScale[marmor , %DamageType] = %mm;
	$DamageScale[mfemale, %DamageType] = %mf;
	$DamageScale[harmor , %DamageType] = %h;
	$DamageScale[Earmor , %DamageType] = %e;
	$DamageScale[Scout  , %DamageType] = %s;
	$DamageScale[LAPC   , %DamageType] = %lapc;
	$DamageScale[HAPC   , %DamageType] = %hapc;
}

function LoadAdminFiles(){
	Echo(" ");
	Echo("*** Admin Files ***");
	exec("Admin\\admin.cs");
	exec("Admin\\AdminFunctions.cs");
	exec("Admin\\AdminProcessMenu.cs");
	exec("Admin\\CharacterOpts.cs");
	Echo("*******************");
	Echo(" ");
}

function LoadArmorFiles(){
	Echo(" ");
	Echo("*** Armor Files ***");
	exec("ArmorData\\ArmorData.cs");
	exec("ArmorData\\ArmorLight.cs");
	exec("ArmorData\\ArmorMedium.cs");
	exec("ArmorData\\ArmorEngineer.cs");
	exec("ArmorData\\ArmorHeavy.cs");
	Echo("*******************");
	Echo(" ");
}

function LoadDeployableFiles(){
	Echo(" ");
	Echo("*** Deployable Files ***");
	exec("Deployables\\deployableFuncts.cs");
	exec("Deployables\\Jail_Package.cs");
	exec("Deployables\\deployableHBlastWall.cs");
	exec("Deployables\\DeployableBase.cs");
	exec("Deployables\\deployableCarrier.cs");
	exec("Deployables\\deployableIBlock.cs");
	exec("Deployables\\deployableAirBase.cs");
	exec("Deployables\\deployableTGWall.cs");
	exec("Deployables\\deployableBlastWall.cs");
	exec("Deployables\\deployableForceFields.cs");
	exec("Deployables\\deployableFlyer.cs");
	exec("Deployables\\deployableHole.cs");
	exec("Deployables\\deployableBlastFloor.cs");
	exec("Deployables\\droidProbeDroid.cs");
	exec("Deployables\\droidCloakDroid.cs");
	exec("Deployables\\droidCloneDroid.cs");
	exec("Deployables\\deployableTeleport.cs");
	exec("Deployables\\deployableHologram.cs");
	exec("Deployables\\deployableInv.cs");
	exec("Deployables\\deployableAmmoInv.cs");
	exec("Deployables\\deployableSensors.cs");
	exec("Deployables\\deployableFreeze-KillPad.cs");
	Echo("***********************");
	Echo(" ");
}

function LoadTurretFiles(){
	Echo(" ");
	Echo("*** Turret Files ***");
	exec("Turrets\\turretFuncts.cs");
	exec("Turrets\\turretMisc.cs");
	exec("Turrets\\turretRail.cs");
	exec("Turrets\\turretLaser.cs");
	exec("Turrets\\turretIon.cs");
	exec("Turrets\\turretMini-Plasma.cs");
	exec("Turrets\\turretFireBall.cs");
	exec("Turrets\\turretFlame.cs");
	exec("Turrets\\turretMini-S.A.M.cs");
	exec("Turrets\\turretMini-Flak.cs");
	exec("Turrets\\turretNuke.cs");
	exec("Turrets\\turretGuardDog.cs");
	exec("Turrets\\turretWatchDog.cs");
	exec("Turrets\\turretMini-Me.cs");
	exec("Turrets\\turretTaser.cs");
	exec("Turrets\\turretMini-ELF.cs");
	exec("Turrets\\turretMini-B.O.P.cs");
	exec("Turrets\\turretTracker.cs");
	exec("Turrets\\turretRepair.cs");
	//PORT-OFF: exec("Turrets\\turretRejuvenation.cs");
	exec("Turrets\\turretObelisk.cs");
	exec("Turrets\\turretJail.cs");
	exec("Turrets\\turretArbitor.cs");
	Echo("********************");
	Echo(" ");
}

function LoadWeaponFiles(){
	Echo(" ");
	Echo("*** Weapon Files ***");
	exec("Weapons\\wepFuncts.cs");
	exec("Weapons\\wepItem.cs");
	exec("Weapons\\wepAtomTosser.cs");
	exec("Weapons\\wepPsionics.cs");
	exec("Weapons\\wepPlasmaCannon.cs");
	exec("Weapons\\wepEnergyWeps.cs");
	exec("Weapons\\wepTankShredder.cs");
	exec("Weapons\\wepTankRocket.cs");
	exec("Weapons\\wepMineLauncher.cs");
	exec("Weapons\\wepMortar.cs");
	exec("Weapons\\wepDoublePlasma.cs");
	exec("Weapons\\wepBlaster.cs");
	exec("Weapons\\wepDiscLauncher.cs");
	exec("Weapons\\Jail_Weapons.cs");
	exec("Weapons\\wepTankRPG.cs");
	exec("Weapons\\AirStrike.cs");
	exec("Weapons\\wepDetPackLauncher.cs");
	exec("Weapons\\wepDebug.cs");
	exec("Weapons\\dfjhsbdfsdf.cs");
	Echo("********************");
	Echo(" ");
}

function LoadBackPackFiles(){
	Echo(" ");
	Echo("*** BackPack Files ***");
	exec("BackPacks\\packFuncts.cs");
	exec("BackPacks\\packEnergyPack.cs");
	exec("BackPacks\\packRepairPack.cs");
	exec("BackPacks\\packHackPack.cs");
	//PORT-OFF: exec("BackPacks\\packChameleon.cs");
	exec("BackPacks\\packBoRgPaCk.cs");
	exec("BackPacks\\packHider.cs");
	exec("BackPacks\\packAmmoPack.cs");
	exec("BackPacks\\packCloakPack.cs");
	exec("BackPacks\\packShieldPack.cs");
	exec("BackPacks\\packStealthShield.cs");
	exec("BackPacks\\packSuicidePack.cs");
	Echo("**********************");
	Echo(" ");
}

function LoadMineFiles(){
	Echo(" ");
	Echo("***** Loading Mine Files *****");
	Exec("Mines\\mineExpData.cs");
	Exec("Mines\\Mine.cs");
	Exec("Mines\\mineClaymor.cs");
	Exec("Mines\\mineAnti-Personel.cs");
	Exec("Mines\\mineGrenades.cs");
	Exec("Mines\\mineRadius.cs");
	Exec("Mines\\mineSuicide.cs");
	//PORT-OFF: Exec("Mines\\mineAirStrikeShell.cs");
	Echo("******************************");
	Echo(" ");
}

function LoadStationFiles(){
	Echo(" ");
	Echo("***** Loading Station Files *****");
	exec("Stations\\stationFuncts.cs");
	exec("Stations\\stationAmmo.cs");
	exec("Stations\\stationInventory.cs");
	exec("Stations\\stationCommand.cs");
	exec("Stations\\stationVehicle.cs");
	Echo("*********************************");
	Echo(" ");
}

function LoadVehicleFiles(){
	Echo(" ");
	Echo("***** Loading Vehicle Files *****");
	exec("Vehicle\\vehicleFuncts.cs");
	exec("Vehicle\\vehicleScout.cs");
	exec("Vehicle\\vehicleLAPC.cs");
	exec("Vehicle\\vehicleHAPC.cs");
	Echo("*********************************");
	Echo(" ");
}

function KickDaJackal(%clientId){
	Net::kick(%clientId, "The FBI has been notified. You better buy a legit copy before they get to your house.");
}

for(%x = 0; $TG::BanList:Name[%x] != ""; %x++){
	BanList::addAbsolute("IP:"@ $TG::BanList:Name[%x] @"", 0);
	//PORT-OFF: Banlist::export("config\\banlist.cs");
}
exec("banlist.cs");