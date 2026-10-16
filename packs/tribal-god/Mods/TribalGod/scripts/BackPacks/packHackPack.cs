//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

// BASE PROJECTILE DATA
RepairEffectData HackBolt
{
	bitmapName = "lightningNew.bmp";
	boltLength = 50.0;
	segmentDivisions = 4;
	beamWidth = 0.145;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
};

function HackBolt::onAcquire(%this, %player, %target)
{
	if(%target.hasFireWall == true)
	{
		Client::sendMessage(Player::getClient(%player), 0, (GameBase::getDataName(%target)).description @" Has A Firewall, So It Can Not Be Hacked.~wAccess_Denied>wav");
		Player::Trigger(%player, $WeaponSlot, false);
		return;
	}
	
	%clientId = Player::getClient(%player); 
	%pTeam = GameBase::getTeam(%player);
	%tTeam = GameBase::getTeam(%target); 
	%datab = GameBase::getDataName(%target); 
	%Description = %datab.description;
	
	if(GameBase::getTeam(%player) != GameBase::getTeam(%target) && getObjectType(%target) != "Player" && %target != %player)
	{
		if($Hackable[%datab] == true)
		{
			%player.HackTarget = %target; 
			%player.isHacking = true; 
			%target.beingHacked = true; 
			CheckHackStatus(%player, %target); 
			return;
		}
		else
		{
			Client::sendMessage(%clientId, 1, "You Cannot Hack "@ %Description @"s.~wAccess_Denied.Wav");
			BottomPrint(%clientId, "<jc><f1>You Cannot Hack "@ %Description @"s.", 5); 
			Player::Trigger(%player, $WeaponSlot, false); 
			%clientId.justHacked = false;
			return;
		}
	}
	else if(%pTeam == %tTeam && %target != %player)
	{
		%target.hasFireWall = true;
		%clientId.justHacked = true;
		Schedule(%clientId @".justHacked = false;", 3);
		Schedule(%target @".hasFireWall = false;", $HackPack::FWallTime);
		Client::sendMessage(%clientId, 3, %Description @" Has Been Hack Proofed For "@ $HackPack::FWallTime @" Seconds.~wShell_Click.Wav");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}
	else
	{
		%player.HackTarget = %player; 
		Client::sendMessage(%clientId, 1, "Nothing In Range.~wAccess_Denied.Wav"); 
		Player::trigger(%player, $WeaponSlot, false); 
	}
}

function HackBolt::onRelease(%this, %player)
{
	%target = %player.HackTarget;
	CheckHackStatus(%player, %target);
	
	%c = Player::getClient(%player);
	%player.isHacking = false;
	%target.beingHacked = false;
	%c.HackPercent = 0;
	
	if(%c.HackStatus == "Interrupted")
	{
		Client::sendMessage(%c, 1, "Hacking Interrupted!~wAccess_Denied.Wav");
		BottomPrint(%c, "", 1);
	}
}

function CheckHackStatus(%player, %target)
{
	%c = Player::getClient(%player);
	
	if(%target.hasFireWall || (!%player.isHacking && !%target.beingHacked))
	{
		%player.HackTarget = ""; 
		%player.isHacking = false; 
		%target.beingHacked = false;
		%c.HackPercent = 0;
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}
	
	%datab = GameBase::getDataName(%target);
	%databName = %datab.description;
	Schedule("CheckHackStatus("@ %player @", "@ %target @");", 0.5);
	
	if(Player::isTriggered(%player, $WeaponSlot) && (Player::getMountedItem(%player, $WeaponSlot) == "HackGun"))
	{
		if(%c.HackPercent == 0 || %c.HackPercent == "")
		{
			%c.HackPercent = 0;
			if(%target.isHacked)
			{
				Client::sendMessage(%c, 3, "Re-Hacking X-Friendly "@ %databName @"...~wSensor_Deploy.Wav");
				BottomPrint(%c, "<jc><f1>Hacking X-Friendly "@ %databName @" Back To It's Original Team.", 5);
				%c.HackStatus = "Hacking";
			}
			else
			{
				%target.origTeam = GameBase::getTeam(%target);
				Client::sendMessage(%c, 3, "Hacking Enemy "@ %databName @"....~wSensor_Deploy.Wav");
				BottomPrint(%c, "<jc><f1>Hacking Enemy "@ %databName @"...", 5);
				%c.HackStatus = "Hacking";
			}
			%c.HackPercent++;
			return;
		}
		
		else if(%c.HackPercent == 15)
		{
			%pTeam = GameBase::getTeam(%player);
			
			if(%target.isHacked)
			{
				Client::sendMessage(%c, 3, "Item Hacked: Friendly "@ %databName @".~wShell_Click.Wav");
				BottomPrint(%c, "<jc><f1>Item Hacked: Friendly "@ %databName @".", 5);
				%target.isHacked = false;
				%c.justHacked = true;
				%c.HackStatus = "Hacked";
				Schedule(%c @".justHacked = false;", 3);
			}
			else
			{
				Client::sendMessage(%c, 3, "Item Hacked: Enemy "@ %databName @".~wShell_Click.Wav");
				BottomPrint(%c, "<jc><f1>Item Hacked: Enemy "@ %databName @".", 5);
				%target.isHacked = true;
				%c.justHacked = true;
				%c.HackStatus = "Hacked";
				Schedule(%c @".justHacked = false;", 3);
			}
			
			GameBase::setTeam(%target, %pTeam);
			Schedule("HackPack::UnHack("@ %target @");", $HackPack::HackTime, %target);
			if(GameBase::getDamageLevel(%item) != "Enabled")
			{ GameBase::repairDamage(%target, 0.99); }
			
			Player::trigger(%player, $WeaponSlot, false);
			%c.HackPercent = 0;
			return;
		}
		else{ %c.HackPercent++; }
	}
	else if(!Player::isTriggered(%player, $WeaponSlot))
	{
		if(%c.HackStatus != "Hacked")
		{ %c.HackStatus = "Interrupted"; }
		%c.HackPercent = 0;
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}
}

$HackPack::FWallTime = 25;
$HackPack::HackTime = 25;

function SetupHackList()
{
	$Hackable[TG::DeployableBase:DoorShape] = true;
	$Hackable[DeployableTaserTrtB] = true;
	$Hackable[ForceFieldFloorPack] = true;
	$Hackable[medaForceFieldPack] = false;
	$Hackable[medbForceFieldPack] = false;
	$Hackable[medcForceFieldPack] = false;
	$Hackable[lgaForceFieldPack] = false;
	$Hackable[lgbForceFieldPack] = false;
	$Hackable[InventoryStation] = true;
	$Hackable[DeployableSeeker] = true;
	$Hackable[ArbitorBoxPack] = true;
	$Hackable[ShockFloorPack] = true;
	$Hackable[CommandStation] = true;
	$Hackable[Deployablebase] = true;
	$Hackable[PlasmaTurret] = true;
	$Hackable[RocketTurret] = true;
	$Hackable[MortarTurret] = true;
	$Hackable[IndoorTurret] = true;
	$Hackable[CameraTurret] = true;
	$Hackable[LaserTurretB] = true;
	$Hackable[TeleportPack] = false;
	$Hackable[AmmoStation] = true;
	$Hackable[LaserTurret] = true;
	$Hackable[BlastWall] = true;
	$Hackable[ELFTurret] = true;
	$Hackable[HoloPack] = false;
	$Hackable[HolePack] = true;
	$Hackable[airbase] = true;
}

function HackPack::UnHack(%item)
{ GameBase::setTeam(%item, %item.origTeam); }

//=====================================================
//          ITEM DATA FOR HACK PACK
//=====================================================
// Actuall Gun here.
ItemImageData HackGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = HackBolt;
	minEnergy  = 3;
	maxEnergy  = 10;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.75, 0, 8.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};
ItemData HackGun
{
	description = "Hack Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = HackGunImage;
	showInventory = false;
	price = 125;
	validateShape = false;
};
function HackGun::onMount(%player,%imageSlot)
{ Player::trigger(%player,$BackpackSlot,true); }

function HackGun::onUnmount(%player,%imageSlot)
{ Player::trigger(%player,$BackpackSlot,false); }

function HackGun::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }


ItemImageData HackPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy  = 0;
	maxEnergy  = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData HackPack
{
	description = "Hack Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = HackPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};

function HackPack::onUnmount(%player, %item)
{
	if(Player::getMountedItem(%player, $WeaponSlot) == HackGun)
	{ Player::unmountItem(%player, $WeaponSlot); }
}

function HackPack::onUse(%player, %item)
{
	%clientId = Player::getClient(%player);
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::mountItem(%player, HackGun, $WeaponSlot); }
}

function HackPack::onDrop(%player, %item)
{ 
	if(!$matchStarted)
	{ return; }
	%mounted = Player::getMountedItem(%player, $WeaponSlot); 
	if (%mounted == HackGun)
	{ Player::unmountItem(%player, $WeaponSlot); }
	else
	{ Player::mountItem(%player, %mounted, $WeaponSlot); }
	Item::onDrop(%player, %item); 
}

SetupHackList();