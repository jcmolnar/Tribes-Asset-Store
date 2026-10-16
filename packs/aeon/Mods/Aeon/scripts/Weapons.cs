//--------------------------------------------------------------------
//ITEM				COST	CAPACITY
//					
//Single Action Pistol		5000	6
//Pump Action Shotgun		6000	5
//Bolt Action Rifle		7000	5
//Double Action Pistol		10000	8
//Semi-Automatic Shotgun	12000	8
//Semi-Automatic Rifle		14000	10
//Automatic Pistol		20000	20
//Automatic Shotgun		24000	10
//Automatic Rifle		28000	20
//
//Pistol Rounds			100	X
//Pistol Magazine		2000	X
//Rifle Rounds			150	X
//Rifle Magazine		2500	X
//Shotgun Rounds		200	X
//Shotgun Magazine		3000	X
//Empty Rounds			1	X
//Empty Magazine		1000	X
//--------------------------------------------------------------------
//-------------- GunsNAmmo Weapon Design by [RR]Mr.Pibb --------------
//--------------------------------------------------------------------
$Aeon::invStyle[Gun] = "held";
$Aeon::invStyle[PistolRounds] = "held";
$Aeon::invStyle[PistolMagazine] = "held";
$Aeon::invStyle[RifleRounds] = "held";
$Aeon::invStyle[RifleMagazine] = "held";
$Aeon::invStyle[ShotgunRounds] = "held";
$Aeon::invStyle[ShotgunMagazine] = "held";
$Aeon::invStyle[EmptyRounds] = "held";
$Aeon::invStyle[EmptyMagazine] = "held";
$Aeon::invStyle[SingleActionPistol] = "held";
$Aeon::invStyle[DoubleActionPistol] = "held";
$Aeon::invStyle[AutomaticPistol] = "held";
$Aeon::invStyle[PumpActionShotgun] = "held";
$Aeon::invStyle[SemiAutomaticShotgun] = "held";
$Aeon::invStyle[AutomaticShotgun] = "held";
$Aeon::invStyle[BoltActionRifle] = "held";
$Aeon::invStyle[SemiAutomaticRifle] = "held";
$Aeon::invStyle[AutomaticRifle] = "held";
$Aeon::weaponClass["Tool"] = true;
$Aeon::weaponClass["Melee"] = true;
$Aeon::weaponClass["Weapon"] = true;
$Aeon::weaponClass["Firearm"] = true;

function Ammunition::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(getSimTime()-%clientId.lastAmmoTime < 0.2)
		return;
	%clientId.lastAmmoTime = getSimTime();
	%mountedItem = Player::getMountedItem(%player,0);
	if(%item == EmptyRounds || %item == EmptyMagazine) {
		GameBase::playSound(%player,SoundDryFire,0);
	}
	else if(%item == PistolRounds) {
		if((%mountedItem == SingleActionPistol && %player.ammo[%mountedItem] < 6) || (%mountedItem == DoubleActionPistol && %player.ammo[%mountedItem] < 8)) {
			%player.ammo[%mountedItem]++;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyRounds);
		}
	}
	else if(%item == PistolMagazine) {
		if(%mountedItem == AutomaticPistol && %player.ammo[%mountedItem] != 20) {
			%player.ammo[%mountedItem] = 20;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyMagazine);
		}
	}
	else if(%item == ShotgunRounds) {
		if((%mountedItem == PumpActionShotgun && %player.ammo[%mountedItem] < 5) || (%mountedItem == SemiAutomaticShotgun && %player.ammo[%mountedItem] < 8)) {
			%player.ammo[%mountedItem]++;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyRounds);
		}
	}
	else if(%item == ShotgunMagazine) {
		if(%mountedItem == AutomaticShotgun && %player.ammo[%mountedItem] != 10) {
			%player.ammo[%mountedItem] = 10;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyMagazine);
		}
	}
	else if(%item == RifleRounds) {
		if((%mountedItem == BoltActionRifle && %player.ammo[%mountedItem] < 5) || (%mountedItem == SemiAutomaticRifle && %player.ammo[%mountedItem] < 10)) {
			%player.ammo[%mountedItem]++;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyRounds);
		}
	}
	else if(%item == RifleMagazine) {
		if(%mountedItem == AutomaticRifle && %player.ammo[%mountedItem] != 20) {
			%player.ammo[%mountedItem] = 20;
			GameBase::playSound(%player,SoundDryFire,1);
			Player::decItemCount(%player,%item);
			Aeon::incItemCount(%player,EmptyMagazine);
		}
	}
	Aeon::ExportInfo(%clientId);
}

//--------------------------------------------------------------------
function Firearm::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(%clientId.sentryCtrl || %clientId.prisonCell)
		return;
	if(%player.Station == "" && isSelectableWeapon(%clientId,%item)) {
		Player::mountItem(%player,%item,$WeaponSlot);
	}
}

function Firearm::onFire(%player,%slot)
{
	%mountedItem = Player::getMountedItem(%player,%slot);
	%muzzleTransform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	if(%mountedItem == SingleActionPistol) {
		if(%player.chokeHammer == backward) {
			%player.chokeHammer = forward;
			if(%player.ammo[%mountedItem]) {
				%player.ammo[%mountedItem]--;
				Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
				GameBase::playSound(%player,debrisMediumExplosion,0);
			}
			else
				GameBase::playSound(%player,SoundPickUpWeapon,1);
		}
		else {
			%player.chokeHammer = backward;
			GameBase::playSound(%player,SoundDryFire,1);
		}
		Player::unmountItem(%player,0);
		Player::mountItem(%player,SingleActionPistol,0);
	}
	else if(%mountedItem == DoubleActionPistol) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			GameBase::playSound(%player,debrisMediumExplosion,0);
		}
		else
			GameBase::playSound(%player,SoundPickUpWeapon,1);
		Player::unmountItem(%player,0);
		Player::mountItem(%player,DoubleActionPistol,0);
	}
	else if(%mountedItem == AutomaticPistol) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;

			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);

			GameBase::playSound(%player,debrisMediumExplosion,0);
		}
		else {
			GameBase::playSound(%player,SoundPickUpWeapon,1);

			Player::unmountItem(%player,0);
			Player::mountItem(%player,AutomaticPistol,0);
		}
	}
	else if(%mountedItem == PumpActionShotgun) {
		if(%player.chokePump == backward) {
			%player.chokePump = forward;
			if(%player.ammo[%mountedItem]) {
				%player.ammo[%mountedItem]--;
				Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
				Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
				Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
				GameBase::playSound(%player,mineExplosion,0);
			}
			else
				GameBase::playSound(%player,SoundPickUpWeapon,1);
		}
		else {
			%player.chokePump = backward;

			GameBase::playSound(%player,SoundRackingMetal,1);
		}
		Player::unmountItem(%player,0);
		Player::mountItem(%player,PumpActionShotgun,0);
	}
	else if(%mountedItem == SemiAutomaticShotgun) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			GameBase::playSound(%player,mineExplosion,0);
		}
		else
			GameBase::playSound(%player,SoundPickUpWeapon,1);
		Player::unmountItem(%player,0);
		Player::mountItem(%player,SemiAutomaticShotgun,0);
	}
	else if(%mountedItem == AutomaticShotgun) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			GameBase::playSound(%player,mineExplosion,0);
		}
		else {
			GameBase::playSound(%player,SoundPickUpWeapon,1);
			Player::unmountItem(%player,0);
			Player::mountItem(%player,AutomaticShotgun,0);
		}
	}
	else if(%mountedItem == BoltActionRifle) {
		if(%player.chokeBolt == backward) {
			%player.chokeBolt = forward;
			if(%player.ammo[%mountedItem]) {
				%player.ammo[%mountedItem]--;
				Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
				GameBase::playSound(%player,debrisLargeExplosion,0);
			}
			else
				GameBase::playSound(%player,SoundPickUpWeapon,1);
		}
		else {
			%player.chokeBolt = backward;
			//GameBase::playSound(%player,SoundRackingMetal,1);
			GameBase::playSound(%player,SoundRackingBolt,1);
		}
		Player::unmountItem(%player,0);
		Player::mountItem(%player,BoltActionRifle,0);
	}
	else if(%mountedItem == SemiAutomaticRifle) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			GameBase::playSound(%player,debrisLargeExplosion,0);
		}
		else
			GameBase::playSound(%player,SoundPickUpWeapon,1);
		Player::unmountItem(%player,0);
		Player::mountItem(%player,SemiAutomaticRifle,0);
	}
	else if(%mountedItem == AutomaticRifle) {
		if(%player.ammo[%mountedItem]) {
			%player.ammo[%mountedItem]--;
			Projectile::spawnProjectile("Projectile",%muzzleTransform,%player,%velocity);
			GameBase::playSound(%player,debrisLargeExplosion,0);
		}
		else {
			GameBase::playSound(%player,SoundPickUpWeapon,1);
			Player::unmountItem(%player,0);
			Player::mountItem(%player,AutomaticRifle,0);
		}
	}
}

function Firearm::getAmmo(%weapon)
{
	%type = String::getSubStr(%weapon.imageType,0,String::findSubStr(%weapon.imageType,"Image"));
	%ammo = %type@"Rounds";
	return %ammo;
}

function Firearm::getMagazine(%weapon)
{
	%type = String::getSubStr(%weapon.imageType,0,String::findSubStr(%weapon.imageType,"Image"));
	%mag = %type@"Magazine";
	return %mag;
}

//--------------------------------------------------------------------
function Firearm::quickGive(%clientId)
{
	if(%clientId) {
		Aeon::incItemCount(%clientId,PistolRounds,500);
		Aeon::incItemCount(%clientId,PistolMagazine,50);
		Aeon::incItemCount(%clientId,RifleRounds,500);
		Aeon::incItemCount(%clientId,RifleMagazine,50);
		Aeon::incItemCount(%clientId,ShotgunRounds,500);
		Aeon::incItemCount(%clientId,ShotgunMagazine,50);
		Aeon::incItemCount(%clientId,EmptyRounds,500);
		Aeon::incItemCount(%clientId,EmptyMagazine,50);
		Aeon::incItemCount(%clientId,SingleActionPistol,50);
		Aeon::incItemCount(%clientId,DoubleActionPistol,50);
		Aeon::incItemCount(%clientId,AutomaticPistol,50);
		Aeon::incItemCount(%clientId,PumpActionShotgun,50);
		Aeon::incItemCount(%clientId,SemiAutomaticShotgun,50);
		Aeon::incItemCount(%clientId,AutomaticShotgun,50);
		Aeon::incItemCount(%clientId,BoltActionRifle,50);
		Aeon::incItemCount(%clientId,SemiAutomaticRifle,50);
		Aeon::incItemCount(%clientId,AutomaticRifle,50);
	}
}

//--------------------------------------------------------------------
function remoteNextWeapon(%clientId)
{
	if(getSimTime() - %clientId.lastWeapSwap < 0.2 || %clientId.prisonCell || !isPlayerIdle(%clientId))
		return;
	%clientId.lastWeapSwap = getSimTime();
	if(Client::getOwnedObject(%clientId).vehicle && Client::getOwnedObject(%clientId).driver == 1) {
		%data = GameBase::getDataName(Client::getOwnedObject(%clientId).vehicle);
		if($VehicleWeapons[%data,num] != "" && $VehicleWeapons[%data,num] > 1)
			Eval(%data@"::WeaponNext("@%clientId@","@Client::getOwnedObject(%clientId).vehicle@");");
	}
	Firearm::switch(%clientId,1);
}

function remotePrevWeapon(%clientId)
{
	if(getSimTime() - %clientId.lastWeapSwap < 0.2 || clientId.prisonCell || !isPlayerIdle(%clientId))
		return;
	%clientId.lastWeapSwap = getSimTime();
	if(Client::getOwnedObject(%clientId).vehicle && Client::getOwnedObject(%clientId).driver == 1) {
		%data = GameBase::getDataName(Client::getOwnedObject(%clientId).vehicle);
		if($VehicleWeapons[%data,num] != "" && $VehicleWeapons[%data,num] > 1)
			Eval(%data@"::WeaponPrev("@%clientId@","@Client::getOwnedObject(%clientId).vehicle@");");
	}
	Firearm::switch(%clientId,-1);
}

function selectValidWeapon(%clientId)
{
	return true;
}

function isSelectableWeapon(%clientId,%weapon)
{
	if(%clientId.prisonCell)
		return false;
	if(Player::getItemCount(%clientId,%weapon)) {
		return true;
	}
	return false;
}

//--------------------------------------------------------------------
function Firearm::buildList()
{
	%max = getNumItems();
	$Aeon::weaponList = "";
	%count = 0;
	for(%i = 0; %i < %max; %i++) {
		%data = getItemData(%i);
		if($Aeon::weaponClass[%data.className] == true) {
			%count++;
			$Aeon::weaponList = $Aeon::weaponList@%data@" ";
		}
	}
	$Aeon::weaponCount = %count;
}

function Firearm::getNum(%weapon)
{
	for(%i = 0; getWord($Aeon::weaponList,%i) != -1; %i++) {
		if(getWord($Aeon::weaponList,%i) == %weapon)
			return %i;
	}
	return false;
}

function Firearm::switch(%clientId,%dir)
{
	%oldWeapon = Player::getMountedItem(%clientId,$WeaponSlot);
	%num = Firearm::getNum(%oldWeapon);
	%count = 0;
	for(%i = %num+%dir; %oldWeapon == Player::getMountedItem(%clientId,$WeaponSlot) && %count <= $Aeon::weaponList; %i+=%dir) {
		%newWeapon = getWord($Aeon::weaponList,%i);
		if(%newWeapon == -1) {
			%newNum = $Aeon::weaponCount-1;
			if(%dir > 0)
				%newNum = 0;
			%newWeapon = getWord($Aeon::weaponList,%newNum);
			%i = %newNum;
		}
		if(isSelectableWeapon(%clientId,%newWeapon)) {
			Player::useItem(%clientId,%newWeapon);
			return;
		}
		%count++;
	}
}

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	Firearm::onUse(%player,%item);
}
