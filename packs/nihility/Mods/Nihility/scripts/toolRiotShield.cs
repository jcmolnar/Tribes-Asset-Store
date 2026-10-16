//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Riot);
$InvList[Riot] = 1;

$AutoUse[Riot] = True;
$WeaponAmmo[Riot] = "";

$ItemMax[larmor, Riot] = 0;		//Seraph
$ItemMax[lfemale, Riot] = 0;		//Seraph
$ItemMax[earmor, Riot] = 1;		//Slave
$ItemMax[efemale, Riot] = 1;		//Slave
$ItemMax[marmor, Riot] = 0;		//Pawn
$ItemMax[aarmor, Riot] = 0;		//Navigator
$ItemMax[darmor, Riot] = 0;		//Atomizer
$ItemMax[barmor, Riot] = 0;		//Paladin


//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
RepairEffectData EngCharge
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

ItemImageData RiotImage 
{
	mountRotation = { 0, 1.57, 0 };
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = EngCharge;
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

ItemData Riot 
{
	description = "Riot Shield Tool";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "shieldpack";
	heading = "fTools";
	shadowDetailMask = 4;
	imageType = RiotImage;
	price = 77;
	showWeaponBar = true;
	//hiliteOnActive = true;
}; 

function Riot::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Riot Shield Tool");
}

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


LinkObject(RiotEng,Eforcefield);

StaticShapeData RiotEng
{	
	shapeFile		= "forcefield_5x5";
	debrisId		= defaultDebrisSmall;
	maxDamage		= 5.0;
	maxEnergy		= 250;
	visibleToSensor = true;
	isTranslucent	= true;
	description		= "Riot Shield";
	shieldShapeName = "shield";
	classname		= "ForceField";
};



function EngCharge::onAcquire(%this, %player, %target)
{
	%Vector=GameBase::getMuzzleTransform(%Player);
	//%Pos = Vector::add(GameBase::getPosition(%player), "0 5 0");
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);

	%newPos=GetLOSOffset2(%player,3);
	//%newPos = Vector::add(GameBase::getPosition(%player), "5 5 0");
	%newitem = newObject("EField",StaticShape,RiotEng,true);
	addToSet("MissionCleanup", %newitem);
	GameBase::setTeam(%newitem,%team);
	GameBase::setRotation(%newitem,%rot);
	GameBase::setPosition(%newitem,%Newpos);
	Playsound(ForcefieldClose,%pos);

	%target=%newitem;
	%player.EField = %newItem;
	%player.repairTarget = %player.EField;
	Player::trigger(%player, $WeaponSlot, true);
}

function EngCharge::onRelease(%this, %player)
{
	if($matchStarted)
	{	deleteobject(%player.Efield);
		%client = Player::getClient(%player);
		Player::trigger(%player, $WeaponSlot, false);
	}
}

function FFCharge::checkDone(%this, %player)
{	
	
	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
	%newPos=GetLOSOffset2(%player,3);
	//%newPos = Vector::add(GameBase::getPosition(%player), "5 5 0");
	GameBase::setRotation(%player.efield,%rot);
	GameBase::setPosition(%player.efield,%Newpos);
}
//this is where I need to look to make sticky nades
function GetLOSOffset2(%player,%offset)
{
	%energy = GameBase::getEnergy(%player);
	%energy -= 70;
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