//========================================================================
//::::::::::::::::::::::::::::BEAM TOOLS::::::::::::::::::::::::::::::::::
//========================================================================
addWeapon(Fixit);
addWeapon(Hack);
addWeapon(Tract);
addWeapon(ReTract);
addWeapon(Grap);


$ItemMax[larmor, Grap] = 0;		//Seraph
$ItemMax[lfemale, Grap] = 0;		//Seraph
$ItemMax[earmor, Grap] = 1;		//Slave
$ItemMax[efemale, Grap] = 1;		//Slave
$ItemMax[marmor, Grap] = 0;		//Pawn
$ItemMax[aarmor, Grap] = 1;		//Navigator
$ItemMax[darmor, Grap] = 0;		//Atomizer
$ItemMax[barmor, Grap] = 0;		//Paladin

$ItemMax[larmor, ReTract] = 0;		//Seraph
$ItemMax[lfemale, ReTract] = 0;		//Seraph
$ItemMax[earmor, ReTract] = 1;		//Slave
$ItemMax[efemale, ReTract] = 1;		//Slave
$ItemMax[marmor, ReTract] = 0;		//Pawn
$ItemMax[aarmor, ReTract] = 0;		//Navigator
$ItemMax[darmor, ReTract] = 0;		//Atomizer
$ItemMax[barmor, ReTract] = 0;		//Paladin

$ItemMax[larmor, Tract] = 0;		//Seraph
$ItemMax[lfemale, Tract] = 0;		//Seraph
$ItemMax[earmor, Tract] = 0;		//Slave
$ItemMax[efemale, Tract] = 0;		//Slave
$ItemMax[marmor, Tract] = 0;		//Pawn
$ItemMax[aarmor, Tract] = 1;		//Navigator
$ItemMax[darmor, Tract] = 0;		//Atomizer
$ItemMax[barmor, Tract] = 0;		//Paladin

$ItemMax[larmor, Hack] = 0;		//Seraph
$ItemMax[lfemale, Hack] = 0;		//Seraph
$ItemMax[earmor, Hack] = 1;		//Slave
$ItemMax[efemale, Hack] = 1;		//Slave
$ItemMax[marmor, Hack] = 0;		//Pawn
$ItemMax[aarmor, Hack] = 0;		//Navigator
$ItemMax[darmor, Hack] = 0;		//Atomizer
$ItemMax[barmor, Hack] = 0;		//Paladin

$ItemMax[larmor, Fixit] = 0;		//Seraph
$ItemMax[lfemale, Fixit] = 0;		//Seraph
$ItemMax[earmor, Fixit] = 1;		//Slave
$ItemMax[efemale, Fixit] = 1;		//Slave
$ItemMax[marmor, Fixit] = 0;		//Pawn
$ItemMax[aarmor, Fixit] = 1;		//Navigator
$ItemMax[darmor, Fixit] = 0;		//Atomizer
$ItemMax[barmor, Fixit] = 0;		//Paladin

$AutoUse[Tract] = true;
$AutoUse[Hack] = true;
$AutoUse[Retract] = true;
$AutoUse[Grap] = true;
$AutoUse[Fixit] = true;

$WeaponAmmo[Tract]			= "";
$WeaponAmmo[Hack]			= "";
$WeaponAmmo[Retract]			= "";
$WeaponAmmo[Grap]			= "";
$WeaponAmmo[Fixit]			= "";

$InvList[Grap] = 1;
$InvList[Hack] = 1;
$InvList[Tract] = 1;
$InvList[ReTract] = 1;
$InvList[Fixit] = 1;

//======================================================
//:::::::::::::::::::REPAIR MODE::::::::::::::::::::::::
//======================================================
ItemImageData FixitImage 
{
	mountRotation = { 0, -3.14, 0 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = RepairBolt;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Fixit 
{
	description = "Repair Gun";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "repairpack";
	heading = "fTools";
	shadowDetailMask = 4;
	imageType = FixitImage;
	price = 77;
	showWeaponBar = true;
	//hiliteOnActive = true;
}; 

function Fixit::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Repair Gun");
}

ItemData Backpack 
{
	description = "Backpack";
	showInventory = false;
};
function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot);
	}
} 
//======================================================
//:::::::::::::::::::::HACK MODE::::::::::::::::::::::::
//======================================================
ItemImageData HackImage 
{
	mountRotation = { 0, -3.14, 0 };
  	//mountOffset = { 0, 0, 0.04 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = HackBolt;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Hack 
{
	description = "Hack Gun";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "repairpack";
	heading = "fTools";
	shadowDetailMask = 4;
	imageType = HackImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
	//hiliteOnActive = true;
}; 

function Hack::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Hack Gun");
}

//======================================================
//:::::::::::::::::::TRACTOR MODE:::::::::::::::::::::::
//======================================================
ItemImageData TractImage 
{
	mountRotation = { 0, -3.14, 0 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = gravCharge;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundSensorPower;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Tract 
{
	description = "Tractor Beam";
	className = "Weapon";
	shapeFile = "repairgun";
	//hudIcon = "energyRifle";
	heading = "bweapons";
	shadowDetailMask = 4;
	imageType = TractImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
	//hiliteOnActive = true;
}; 


function Tract::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Tractor Beam");
}
//======================================================
//:::::::::::::::::::RE-TRACTOR MODE::::::::::::::::::::
//======================================================
ItemImageData RetractImage 
{
	mountRotation = { 0, -3.14, 0 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = antigravCharge;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundSensorPower;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Retract 
{
	description = "Repulsor Beam";
	className = "Weapon";
	shapeFile = "repairgun";
	//hudIcon = "energyRifle";
	heading = "bweapons";
	shadowDetailMask = 4;
	imageType = RetractImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
	//hiliteOnActive = true;
}; 

function Retract::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Repulsor Beam");
}
//======================================================
//:::::::::::::::::::GRAPPLER MODE::::::::::::::::::::::
//======================================================
ItemImageData Pull
{
	mountRotation = { 0, -3.14, 0 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType =tractorCharge;
	minEnergy = 3;
	maxEnergy = 3;
	reloadTime = 1;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundSensorPower;
};

ItemData Grap
{
	description = "Grappler Beam";
	shapeFile = "shotgun";
	//hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bweapons";
	shadowDetailMask = 4;
	imageType = Pull;
	showWeaponBar = true;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
	//hiliteOnActive = true;
};

function Grap::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Grappler Beam");
}

//======================================================
//::::::::::::::::::::RUNAWAY MODE::::::::::::::::::::::
//======================================================

ItemImageData Runimage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType =tractorCharge;
	minEnergy = 3;
	maxEnergy = 3;
	reloadTime = 1;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundSensorPower;
};

ItemData Run
{
	description = "Grappler Beam";
	shapeFile = "shotgun";
	//hudIcon = "energyRifle";
	className = "Weapon";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = Runimage;
	showWeaponBar = true;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
	//hiliteOnActive = true;
};

function Run::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Grappler Beam");
}

//===================================================================
// WEAPON OPTIONS REPAIR TOOL
//===================================================================

//$FixitSlotA=4;
//
//function Fixit::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	%client = Player::getclient(%player);
//	//bottomprint(%client, "<jc><f2>Laser Gatling Gun");
//
//	Player::mountItem(%player,Hack,$FixitSlotA); 
//
//
//}
//
//function Fixit::onUnmount(%player,%imageSlot)
//{
//	Player::unmountItem(%player,$FixitSlotA); 
//
//}


//function FixitImage::onFire(%player, %slot) 
//{
//
//	%playerId = Player::getClient(%player);
//	%fired.deployer = %player;
//	%client = GameBase::getOwnerClient(%player);
//	%vel = Item::getVelocity(%player);
//	%trans = GameBase::getMuzzleTransform(%player);
//
//	if (!%playerId.Fixit || %playerId.Fixit == 0)
//	{
//		Player::trigger(%player, 0, true);	
//		//Repair(%player); 
//		//%newObj = Projectile::spawnProjectile("repairbolt", %trans, %player, %vel);		
//		%newObj = Projectile::spawnProjectile("repairbolt", %trans, %player, %vel);
//
//		//schedule("endbeam(" @ %newObj @ ", " @ %client @ ");", 0.1, %player);	
//	}
//	
//	else if (%playerId.Fixit == 1)
//	{
//		Player::trigger(%player, 4, true);
//		//Hack(%player); 
//		//%newObj = Projectile::spawnProjectile("hackbolt", %trans, %player, %vel);
//	}
//			deleteobject(%newObj);
//	//Player::trigger(%player, 0, false);
//	//Player::trigger(%player, 4, false);	
//}

//function endbeam(%newObj, %client)
//{
//	%player = Client::getOwnedObject(%client);
//	%trans = GameBase::getMuzzleTransform(%player);
//	%vel = Item::getVelocity(%player);
//	
////	if(%client.targetLock) {
////		//echo("HandRocket");
////		Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,%client.targetLock);//LilTurretMissi1e HandRocket
////		
////	}
////	else
////	{
////		//echo("AvengerMissile");
////				
////	}
//	%client.targetLock = 0;
//	deleteobject(%newObj);
//}

//function repairbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
//{
////	if(getObjectType(%target) == "Flier" && GameBase::getDataName(%target).shapeFile == "rocket")
////	{
////		%shooterId.targetLock = %target;
////	}
//}

//function Fixit::onFire(%player,%item)
//{
//        Weapon::onUse(%player,%item);
//	%client = GameBase::getOwnerClient(%player);
//	if (!%client.Fixit || %client.Fixit == 0)
//	{
//	        bottomprint(%client, "<jc><f2>Repair Tool<f1> Repair Mode", 2);
//	}
//	if (%client.Fixit == 1)
//	{
//	        bottomprint(%client, "<jc><f2>Repair Tool<f1> Hack Mode", 2);
//	}
//}

//===================================================================
// WEAPON OPTIONS GRAV BEAM
//===================================================================


//$TractSlotA=4;
//$TractSlotB=7;
//
//
//function Tract::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	%client = Player::getclient(%player);
//	//bottomprint(%client, "<jc><f2>Laser Gatling Gun");
//
//	Player::mountItem(%player,Retract,$TractSlotA);
//	Player::mountItem(%player,Grap,$TractSlotB); 
//
//
//
//}
//
//function Tract::onUnmount(%player,%imageSlot)
//{
//	Player::unmountItem(%player,$TractSlotA); 
//	Player::unmountItem(%player,$TractSlotB); 
//
//}


//function TractImage::onFire(%player, %slot) 
//{
//
//	%playerId = Player::getClient(%player);
//	%fired.deployer = %player;
//	%client = GameBase::getOwnerClient(%player);
//	%vel = Item::getVelocity(%player);
//	%trans = GameBase::getMuzzleTransform(%player);
//
//	if (!%playerId.Tract || %playerId.Tract == 0)
//	{
//		%newObj = Projectile::spawnProjectile("gravCharge", %trans, %player, %vel);		
//	}
//	//Player::trigger(%player, 0, false);
//	else if (%playerId.Tract == 1)
//	{
//		%newObj = Projectile::spawnProjectile("antigravCharge", %trans, %player, %vel);
//	}
//	//Player::trigger(%player, 4, false);
//	else if (%playerId.Tract == 2)
//	{
//		wang(%player)
//		//%newObj = Projectile::spawnProjectile("tractorCharge", %trans, %player, %vel);
//	}
//	//Player::trigger(%player, 7, false);
//}

//function Tract::onUse(%player,%item)
//{
//        Weapon::onUse(%player,%item);
//	%client = GameBase::getOwnerClient(%player);
//	if (!%client.Tract || %client.Tract == 0)
//	{
//	        bottomprint(%client, "<jc><f2>Grav Beam<f1> Tractor Mode", 2);
//	}
//	if (%client.Tract == 1)
//	{
//	        bottomprint(%client, "<jc><f2>Grav Beam<f1> Repulsor Mode", 2);
//	}
//	if (%client.Tract == 2)
//	{
//	        bottomprint(%client, "<jc><f2>Grav Beam<f1> Grappler Mode", 2);
//	}
//}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

//function wang(%player){
//        if(GameBase::getLOSInfo(%player,1000))
//        {        
//                %object = getObjectType($los::object);
//                        
//                %xopos = getWord($los::position,0);
//                %yopos = getWord($los::position,1);
//                %zopos = getWord($los::position,2);
//        %pos = %xopos @" "@ %yopos @" "@ %zopos +20;
//        }        
//
//%trans = GameBase::getMuzzleTransform(%player);
//%vel = Item::getVelocity(%player);
//        for(%i=0; %i < 10; %i += 1) {
//
//                %xrnd = floor(getRandom() *10)/5 -1;
//                %yrnd = floor(getRandom() *10)/5 -1;
//                %zrnd = -1;                //floor(getRandom() *10)/5 -1;
//
////%apos = getBoxCenter(%player);
////echo(%apos);
//
//                %trans1= getWord(%trans,0);
//                %trans2= getWord(%trans,1);
//                %trans3= getWord(%trans,2);
//                %trans4= getWord(%trans,3) + %xrnd;
//                %trans5= getWord(%trans,4) + %yrnd;
//                %trans6= getWord(%trans,5) + %zrnd;
//                %trans7= getWord(%trans,6);
//                %trans8= getWord(%trans,7);
//                %trans9= getWord(%trans,8);
//                %trans10=getWord(%trans,9);
//                %trans11=getWord(%trans,10);
//                %trans12=getWord(%trans,11);
//                
//        %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos;
//
////%trans10 @" "@ %trans11 @" "@ %trans12;
//
//// targetLaser, sniperLaser -freaky, uses mounted weapon trans
//// turretCharge, MortarShell, TurretMissile, FusionBolt ,discshell -works fine
//// SwissBolt
//        Projectile::spawnProjectile("tractorCharge", %NewTrans, %player, %vel);
////        Projectile::spawnProjectile(%newObj);
////        schedule("DeleteLaser(" @ %newObj @ ");", 1.5);
//                        }
//        }

//function Repair(%player)
//{ 
//	if(GameBase::getLOSInfo(%player,10000)) 
//	{
//		%object = getObjectType($los::object); 
//		%xopos = getWord($los::position,0) ; 
//		%yopos = getWord($los::position,1) ; 
//		%zopos = getWord($los::position,2) ; 
//		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
//	}
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//
//	%trans1= getWord(%trans,0); 
//	%trans2= getWord(%trans,1); 
//	%trans3= getWord(%trans,2); 
//	%trans4= getWord(%trans,3) ; 
//	%trans5= getWord(%trans,4) ; 
//	%trans6= getWord(%trans,5) ; 
//	%trans7= getWord(%trans,6); 
//	%trans8= getWord(%trans,7); 
//	%trans9= getWord(%trans,8); 
//	%trans10=getWord(%trans,9); 
//	%trans11=getWord(%trans,10); 
//	%trans12=getWord(%trans,11); 
//	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
//	//%NewTrans = %trans1 @" "@ %pos; 
//
//	Projectile::spawnProjectile("repairbolt", %NewTrans, %player, 0); 
//	Projectile::spawnProjectile(%newObj); 
//	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
//	//schedule("reload(" @ %player @ ");",0.001); 
//	//} 
//}
//
//function Hack(%player)
//{ 
//	if(GameBase::getLOSInfo(%player,10000)) 
//	{
//		%object = getObjectType($los::object); 
//		%xopos = getWord($los::position,0) ; 
//		%yopos = getWord($los::position,1) ; 
//		%zopos = getWord($los::position,2) ; 
//		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
//	}
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//
//	%trans1= getWord(%trans,0); 
//	%trans2= getWord(%trans,1); 
//	%trans3= getWord(%trans,2); 
//	%trans4= getWord(%trans,3) ; 
//	%trans5= getWord(%trans,4) ; 
//	%trans6= getWord(%trans,5) ; 
//	%trans7= getWord(%trans,6); 
//	%trans8= getWord(%trans,7); 
//	%trans9= getWord(%trans,8); 
//	%trans10=getWord(%trans,9); 
//	%trans11=getWord(%trans,10); 
//	%trans12=getWord(%trans,11); 
//	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
//	//%NewTrans = %trans1 @" "@ %pos; 
//
//	Projectile::spawnProjectile("hackbolt", %NewTrans, %player, 0); 
//	Projectile::spawnProjectile(%newObj); 
//	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
//	//schedule("reload(" @ %player @ ");",0.001); 
//	//} 
//}
//
//function Tractor(%player)
//{ 
//	if(GameBase::getLOSInfo(%player,10000)) 
//	{
//		%object = getObjectType($los::object); 
//		%xopos = getWord($los::position,0) ; 
//		%yopos = getWord($los::position,1) ; 
//		%zopos = getWord($los::position,2) ; 
//		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
//	}
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//
//	%trans1= getWord(%trans,0); 
//	%trans2= getWord(%trans,1); 
//	%trans3= getWord(%trans,2); 
//	%trans4= getWord(%trans,3) ; 
//	%trans5= getWord(%trans,4) ; 
//	%trans6= getWord(%trans,5) ; 
//	%trans7= getWord(%trans,6); 
//	%trans8= getWord(%trans,7); 
//	%trans9= getWord(%trans,8); 
//	%trans10=getWord(%trans,9); 
//	%trans11=getWord(%trans,10); 
//	%trans12=getWord(%trans,11); 
//	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
//	//%NewTrans = %trans1 @" "@ %pos; 
//
//	Projectile::spawnProjectile("BlueShell", %NewTrans, %player, 0); 
//	Projectile::spawnProjectile(%newObj); 
//	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
//	//schedule("reload(" @ %player @ ");",0.001); 
//	//} 
//}
//
//function Repulsor(%player)
//{ 
//	if(GameBase::getLOSInfo(%player,10000)) 
//	{
//		%object = getObjectType($los::object); 
//		%xopos = getWord($los::position,0) ; 
//		%yopos = getWord($los::position,1) ; 
//		%zopos = getWord($los::position,2) ; 
//		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
//	}
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//
//	%trans1= getWord(%trans,0); 
//	%trans2= getWord(%trans,1); 
//	%trans3= getWord(%trans,2); 
//	%trans4= getWord(%trans,3) ; 
//	%trans5= getWord(%trans,4) ; 
//	%trans6= getWord(%trans,5) ; 
//	%trans7= getWord(%trans,6); 
//	%trans8= getWord(%trans,7); 
//	%trans9= getWord(%trans,8); 
//	%trans10=getWord(%trans,9); 
//	%trans11=getWord(%trans,10); 
//	%trans12=getWord(%trans,11); 
//	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
//	//%NewTrans = %trans1 @" "@ %pos; 
//
//	Projectile::spawnProjectile("BlueShell", %NewTrans, %player, 0); 
//	Projectile::spawnProjectile(%newObj); 
//	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
//	//schedule("reload(" @ %player @ ");",0.001); 
//	//} 
//}
//
//function Grappler(%player)
//{ 
//	if(GameBase::getLOSInfo(%player,10000)) 
//	{
//		%object = getObjectType($los::object); 
//		%xopos = getWord($los::position,0) ; 
//		%yopos = getWord($los::position,1) ; 
//		%zopos = getWord($los::position,2) ; 
//		%pos = %xopos @" "@ %yopos @" "@ %zopos +0; 
//	}
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//
//	%trans1= getWord(%trans,0); 
//	%trans2= getWord(%trans,1); 
//	%trans3= getWord(%trans,2); 
//	%trans4= getWord(%trans,3) ; 
//	%trans5= getWord(%trans,4) ; 
//	%trans6= getWord(%trans,5) ; 
//	%trans7= getWord(%trans,6); 
//	%trans8= getWord(%trans,7); 
//	%trans9= getWord(%trans,8); 
//	%trans10=getWord(%trans,9); 
//	%trans11=getWord(%trans,10); 
//	%trans12=getWord(%trans,11); 
//	%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos; 
//	//%NewTrans = %trans1 @" "@ %pos; 
//
//	Projectile::spawnProjectile("BlueShell", %NewTrans, %player, 0); 
//	Projectile::spawnProjectile(%newObj); 
//	// schedule("DeleteLaser(" @ %newObj @ ");", 1.5); 
//	//schedule("reload(" @ %player @ ");",0.001); 
//	//} 
//}