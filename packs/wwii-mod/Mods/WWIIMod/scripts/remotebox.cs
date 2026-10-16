ItemData DeployBoxammo
{
	description = "...lol";
	className = "Ammo";
	shapeFile = "force";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
	showinventory = false;
	showweaponbar = false;
};

ItemImageData DeployBoxImage
{
	shapeFile = "ammo1";
	mountPoint = 0;
	mountrotation = { 0, 0, 1.55 };
	weaponType = 3;
	reloadTime = 0;
	Mountoffset = { 0, 0, -0.1 };
	fireTime = 0.05;

	ammoType = DeployBoxammo;
	
	accuFire = true;
	sfxActivate = SoundPickUphealth;
	
};

ItemData DeployBox
{
	description = "Deployable Resupplies";
	className = "Weapon";
	shapeFile = "ammo1";
   validateShape = true;
	hudIcon = "weapon";
   heading = "dEngineer";
	shadowDetailMask = 4;
	imageType = DeployBoxImage;
	price = 200;
	showWeaponBar = true;
	
};

function DeployBox::onMount(%player, %item)
{
if(player::getitemcount(%player, DeployBoxammo) < 1) {
player::unmountItem(%player, $weaponslot);
// PORT FIX: was remoteeval(client, eval, nextweapon) -- it told the CLIENT to run its own
// remoteEval builtin and ask for the next weapon. Same result, without that trick.
schedule("remoteNextWeapon(" @ player::getclient(%player) @ ");", 0.1);
}
}

function DeployBoxImage::onFire(%player, %slot)
{
%clId = Player::getclient(%player);
if(%player.throwTime < getSimTime() ) {
%clId.canchangeweapon = false;
schedule("DeployBox(" @ %clId @ "," @ %player @ ");", 1);
player::unmountItem(%player, $weaponslot);
}
}

function DeployBox(%clId, %player)
{

	
		if(!Player::isdead(%player)) {
			
			Player::decItemCount(%player,DeployBoxAmmo);
			%obj = newObject("","Mine","RemoteBox");
			%clId.canchangeweapon = true;
			%obj.ownerclient = %clId;
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,3 ,false);
			%player.throwTime = getSimTime() + 1.35;
			//schedule("RemoteBox::onAdd(" @ %obj @ ");", 4);
			
	}		
		
}

//Anti-Infantry mine
MineData RemoteBox
{
	className = "Mine";
   description = "boxxy woxxy";
   shapeFile = "ammo1";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = debrisExpsmall;
	explosionRadius = 3.0;
	damageValue = 0.6;
	damageType = $explosion;
	kickBackStrength = 50;
	triggerRadius = 2.0;
	maxDamage = 3;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function RemoteBox::onAdd(%this)
{
}

function RemoteBox::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(%type == "Player") WWII::PlayerResupply(%object);
}

function RemoteBox::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 1, %this);
}

function RemoteBox::onDamage(%this,%type,%val,%pos,%vec,%mom,%object)
{
if(getdamagetype(%type) != "exp") return;
%group = getgroup(%this);
if(%group != "MissionCleanup") return;
%dlevel = gamebase::getdamagelevel(%this);
gamebase::setdamagelevel(%this, %dlevel+%val);
}
