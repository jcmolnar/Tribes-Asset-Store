//--------------------------------------

$SellAmmo[MineAmmo] = 5;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackItems[5] = MineAmmo;

//--------------------------------------

$TeamItemMax[mineammo] = 35;

//--------------------------------------

$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;

//--------------------------------------

MineData Casing
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "casingshell";
   description = "turretshell";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Casing::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut("@%this@");", 0.0,%this);
	schedule("deleteObject("@%this@");", 2.5,%this);
}

function Casing::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {}
