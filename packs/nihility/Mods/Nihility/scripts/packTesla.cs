//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[TeslaPack] = 1;

$ItemMax[larmor, TeslaPack] = 0;	//Seraph
$ItemMax[lfemale, TeslaPack] = 0;	//Seraph
$ItemMax[earmor, TeslaPack] = 0;	//Slave
$ItemMax[efemale, TeslaPack] = 0;	//Slave
$ItemMax[marmor, TeslaPack] = 1;	//Pawn
$ItemMax[aarmor, TeslaPack] = 0;	//Navigator
$ItemMax[darmor, TeslaPack] = 0;	//Atomizer
$ItemMax[barmor, TeslaPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//RepairEffectData ForceBolt
//{	bitmapName			= "LightningNew.bmp";
//	boltLength			= 20.0;
//	segmentDivisions	= 6;
//	beamWidth			= 0.175;
//	updateTime			= 450;
//	skipPercent			= 0.6;
//	displaceBias		= 0.15;
//	lightRange			= 6.0;
//	lightColor			= { 0.85, 0.25, 0.25 };
//};

//ItemImageData TeslaGunImage 
//{
//	shapeFile = "repairgun";
//	mountPoint = 0;
//	weaponType = 2;
//	projectileType = ForceBolt;
//	reloadTime = 1; 
//	minEnergy = 1;
//	maxEnergy = 1;
//	lightType = 3;
//	lightRadius = 1;
//	lightTime = 1;
//	lightColor = { 0.25, 1, 0.25 };
//	sfxActivate = SoundPickUpWeapon;
//	sfxFire = SoundRepairItem;
//}; 
//
//ItemData TeslaGun 
//{
//	description = "Repair Gun";
//	shapeFile = "repairgun";
//	className = "Weapon";
//	shadowDetailMask = 4;
//	imageType = TeslaGunImage;
//	showInventory = false;
//	price = 33;
//}; 
//
//function TeslaGun::onMount(%player,%imageSlot)
//{
//	Player::trigger(%player,$BackpackSlot,true);
//}
//
//function TeslaGun::onUnmount(%player,%imageSlot)
//{
//	Player::trigger(%player,$BackpackSlot,false);
//}
//
//ItemImageData TeslaPackImage 
//{
//	shapeFile = "sensor_small";//jetpack
//	mountPoint = 2;
//	weaponType = 2;
//  	mountOffset = { 0, -0.1, 0.2 };
//  	mountRotation = { 1.0, -3.14, 0};
//	minEnergy = 0;
//	maxEnergy = 0;
//	reloadTime = 1;
////	mountOffset = { 0, -0.05, 0 };
////	mountRotation = { 0, 0, 0 };
//	firstPerson = false;
//};
//
//
//ItemData TeslaPack 
//{
//	description = "Riot Shield";
//	shapeFile = "armorPack";
//	className = "Backpack";
//	heading = "cBackpacks";
//	shadowDetailMask = 4;
//	imageType = TeslaPackImage;
//	price = 33;
//	hudIcon = "repairpack";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};
//
//function TeslaPack::onUnmount(%player,%item)
//{
//	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
//	{
//		Player::unmountItem(%player,$WeaponSlot);
//	}
//}
//
//function TeslaPack::onUse(%player,%item)
//{
//	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
//	{
//		Player::mountItem(%player,%item,$BackpackSlot);
//	}
//	else
//	{
//		Player::mountItem(%player,TeslaGun,$WeaponSlot);
//	}
//}
//
//function TeslaPack::onDrop(%player,%item)
//{
//	if($matchStarted)
//	{
//		%mounted = Player::getMountedItem(%player,$WeaponSlot);
//		if (%mounted == TeslaGun)
//		{
//			Player::unmountItem(%player,$WeaponSlot);
//		}
//		else
//		{
//			Player::mountItem(%player,%mounted,$WeaponSlot);
//		}
//		Item::onDrop(%player,%item);
//	}
//}

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX




//function AODForceProj::Help(%client)
//{	%msg=HelpTitle("Engineers Force Field Projection gun:");
//	%msg=AddHelpLine(%msg,"This gun when Fired projects a large forcefield which.");
//	%msg=AddHelpLine(%msg,"is just like the deployable force door except the forcefield draws its power");
//	%msg=AddHelpLine(%msg,"from the Chaos Engineers power system.");
//	topPrint(%client,%Msg,8);
//	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
//}
//
//// ----------------------------------
//// End of AODForceProj
////-----------------------------------
//
//LinkObject(ForceFieldE,Eforcefield);
//
//StaticShapeData ForceFieldE
//{	shapeFile		= "forcefield_4x17";
//	debrisId		= defaultDebrisSmall;
//	maxDamage		= 48.5;
//	maxEnergy		= 250;
//	visibleToSensor = true;
//	isTranslucent	= true;
//	description		= "5x5 Force Field";
//	shieldShapeName = "shield";
//	classname		= "ForceField";
//};
//
//function ForceBolt::onAcquire(%this, %player, %target)
//{	//Echo("Force Bolt on Aquire");
//	%Vector=GameBase::getMuzzleTransform(%Player);
//	%pos=Gamebase::GetPosition(%player);
//	%rot=GameBase::GetRotation(%player);
//	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
//	//echo("MT :",%vector," PR :",%rot);
//	%newPos=GetLOSOffset(%player,5);
//	//%NewPos=CalcPos2(%Pos,5,%rot,%rot2);
//
//	%newitem = newObject("EField",StaticShape,ForceFieldE,true);
//	addToSet("MissionCleanup", %newitem);
//	GameBase::setTeam(%newitem,%team);
//	GameBase::setRotation(%newitem,%rot);
//	GameBase::setPosition(%newitem,%Newpos);
//	Playsound(ForcefieldClose,%pos);
//
//	%target=%newitem;
//	%player.EField = %newItem;
//	%player.repairTarget = %player.EField;
//	Player::trigger(%player, $WeaponSlot, true);
//	// Client::sendMessage(%client,0,"Nothing in range");
//	// return;
//}
//
//function ForceBolt::onRelease(%this, %player)
//{	//Echo("Force Bolt on Release");
//	if($matchStarted)
//	{	deleteobject(%player.Efield);
//		%client = Player::getClient(%player);
//		Player::trigger(%player, $WeaponSlot, false);
//	}
//}
//
//function ForceBolt::checkDone(%this, %player)
//{	%Vector=GameBase::getMuzzleTransform(%Player);
//	%pos=Gamebase::GetPosition(%player);
//	%rot=GameBase::GetRotation(%player);
//	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
//	//echo("MT :",%vector," PR :",%rot);
//	%newPos=GetLOSOffset(%player,5);
//	//%NewPos=CalcPos2(%Pos,5,%rot,%rot2);
//	GameBase::setRotation(%player.efield,%rot);
//	GameBase::setPosition(%player.efield,%Newpos);
//}
//
//function GetLOSOffset(%player,%offset)
//{	%Vector=GameBase::getMuzzleTransform(%Player);
//	%pos=Gamebase::GetPosition(%player);
//	%rot=GameBase::GetRotation(%player);
//	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
//	// echo("MT :",%vector," PR :",%rot);
//
//	%X1=Getword(%vector,1);
//	%Y1=Getword(%vector,2);
//	%Z1=Getword(%vector,3);
//
//	%X2=Getword(%vector,6);
//	%Y2=Getword(%vector,7);
//	%Z2=Getword(%vector,8);
//
//	%zo1=SIN(%YRot) * %offset;
//	%zo2=COS(%XRot) * %offset;
//	%l2=COS(%YRot) * %offset;
//
//	echo(%x1," ",%y1," ",%z1," | ",%x2," ",%y2," ",%z2);
//
//	%p1=Vector::getFromRot(%rot,%l2,%zo);
//	%NewPos=Vector::Add(%Pos,%p1);
//	return(%NewPos);
//}
//function AODForceProj::onMount(%player,%item) 
//{
//  %client = Player::getClient(%player);
//  Bottomprint(%client, "<jc><f2>Riot-Shield Projector");
//}
//
//============================
RepairEffectData FFCharge
{	bitmapName			= "LightningNew.bmp";
	boltLength			= 20.0;
	segmentDivisions	= 6;
	beamWidth			= 0.175;
	updateTime			= 450;
	skipPercent			= 0.6;
	displaceBias		= 0.15;
	lightRange			= 6.0;
	lightColor			= { 0.85, 0.25, 0.25 };
};
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
ItemImageData TeslaPackImage 
{
	shapeFile = "sensor_small";//jetpack
	mountPoint = 2;
	weaponType = 2;
  	mountOffset = { 0, -0.1, 0.2 };
  	mountRotation = { 1.0, -3.14, 0};
	projectileType = FFCharge;
	minEnergy = 1;
	maxEnergy = 4;
	//reloadTime = 0.2;
	sfxFire = SoundELFIdle;
};


ItemData TeslaPack 
{
	description = "Riot Shield";
	shapeFile = "discammo";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = TeslaPackImage;
	price = 33;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

//????????????????????????????????????????????????????????????

function ixDotProd(%vec, %scalar) 
{ %return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar); return %return; } 

function ixSin(%theta) 
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800)); }  

function ixCos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800)); } 

function ixApplyKickback(%player, %strength, %lift) 
{ if((!%lift) && (%lift != 0)) %lift = 0; %rot = GameBase::getRotation(%player); %rad = getWord(%rot, 2); %x = (-1) * (ixSin(%rad)); %y = ixCos(%rad); %dir = %x @ " " @ %y @ " 0"; %force = ixDotProd(Vector::neg(%dir),%strength); %x = getWord(%force, 0); %y = getWord(%force, 1); %dir = %x @ " " @ %y @ " " @ %lift; Player::applyImpulse(%player,%force); } 

function Sin(%theta)
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));}
 
function Cos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));}

function NewVector(%vec, %scalar)
{	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function GiveKickback(%player, %strength, %lift)
{	
	if((!%lift) && (%lift != 0)) %lift = 0;
	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (Sin(%rad));
	%y = Cos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force=NewVector(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%force = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

//????????????????????????????????????????????????????????????


LinkObject(RiotFF,Eforcefield);

StaticShapeData RiotFF
{	
	shapeFile		= "forcefield_5x5";
	debrisId		= defaultDebrisSmall;
	maxDamage		= 20.5;
	maxEnergy		= 250;
	visibleToSensor = true;
	isTranslucent	= true;
	description		= "Riot Shield";
	shieldShapeName = "shield";
	classname		= "ForceField";
};

function FFCharge::onAcquire(%this, %player, %target)
{

	
	%Vector=GameBase::getMuzzleTransform(%Player);
	//%Pos = Vector::add(GameBase::getPosition(%player), "0 5 0");
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);

	%newPos=GetLOSOffset(%player,3);
	//%newPos = Vector::add(GameBase::getPosition(%player), "5 5 0");
	%newitem = newObject("EField",StaticShape,RiotFF,true);
	addToSet("MissionCleanup", %newitem);
	GameBase::setTeam(%newitem,%team);
	GameBase::setRotation(%newitem,%rot);
	GameBase::setPosition(%newitem,%Newpos);
	Playsound(ForcefieldClose,%pos);

	%target=%newitem;
	%player.EField = %newItem;
	%player.repairTarget = %player.EField;
	Player::trigger(%player, $BackpackSlot, true);
}

function FFCharge::onRelease(%this, %player)
{
	if($matchStarted)
	{	deleteobject(%player.Efield);
		%client = Player::getClient(%player);
		Player::trigger(%player, $BackpackSlot, false);
	}
}

function FFCharge::checkDone(%this, %player)
{	
	
	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
	%newPos=GetLOSOffset(%player,3);
	//%newPos = Vector::add(GameBase::getPosition(%player), "5 5 0");
	GameBase::setRotation(%player.efield,%rot);
	GameBase::setPosition(%player.efield,%Newpos);
}
//this is where I need to look to make sticky nades


function GetLOSOffset(%player,%offset)
{
	%energy = GameBase::getEnergy(%player);
	%energy -= 1;
	GameBase::setEnergy(%player,%energy);
	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);

	%X1=Getword(%vector,1);
	%Y1=Getword(%vector,2);
	%Z1=Getword(%vector,3);

	%X2=Getword(%vector,6);
	%Y2=Getword(%vector,7);
	%Z2=Getword(%vector,8);

	%zo1=SIN(%YRot) * %offset;
	%zo2=COS(%XRot) * %offset;
	%l2=COS(%YRot) * %offset;

	//echo(%x1," ",%y1," ",%z1," | ",%x2," ",%y2," ",%z2);

	%p1=Vector::getFromRot(%rot,%l2,%zo);
	%NewPos=Vector::Add(%Pos,%p1);
	return(%NewPos);
}


//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


//ItemImageData TeslaPackImage 
//{
//	shapeFile = "discammo";//jetpack
//	mountPoint = 2;
//	weaponType = 2;
//	mountOffset ={ 0, -0.1, 0 };
//	mountRotation ={ 0, 0, 1.57 };
//	projectileType = BlasterCharge;
//	minEnergy = 15;
//	maxEnergy = 15;
//	reloadTime = 0.2;
//	sfxFire = SoundELFIdle;
//};
//
//
//ItemData TeslaPack 
//{
//	description = "Tesla Alternator Pack";
//	shapeFile = "discammo";
//	className = "Backpack";
//	heading = "cBackpacks";
//	shadowDetailMask = 4;
//	imageType = TeslaPackImage;
//	price = 33;
//	hudIcon = "TeslaPack";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};
//
//function TeslaPackImage::onActivate(%player,%imageSlot,%client)
//{
//	Client::sendMessage(Player::getClient(%player),0,"Tesla Matrix On");
//	//Player::trigger(%player,$BackpackSlot,true);
//}
//
//function TeslaPackImage::onDeactivate(%player,%imageSlot,%client)
//{
//	Client::sendMessage(Player::getClient(%player),0,"Tesla Matrix Off");
//	Player::trigger(%player,$BackpackSlot,false);
//} 

