ItemData DeployMineAmmo
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

ItemImageData DeployMineImage
{
	shapeFile = "mine";
	mountPoint = 0;
	mountrotation = { 0, 0, 1.55 };
	weaponType = 3;
	reloadTime = 0;
	Mountoffset = { 0, 0, -0.1 };
	fireTime = 0.05;

	ammoType = DeployMineammo;
	
	accuFire = true;
	sfxActivate = SoundPickUphealth;
	
};

ItemData DeployMine
{
	description = "Anti-Infantry Mine";
	className = "Weapon";
	shapeFile = "mine";
   validateShape = true;
	hudIcon = "weapon";
   heading = "dEngineer";
	shadowDetailMask = 4;
	imageType = DeployMineImage;
	price = 200;
	showWeaponBar = true;
	
};

function DeployMine::onMount(%player, %item)
{
if(player::getitemcount(%player, DeployMineammo) < 1) {
player::unmountItem(%player, $weaponslot);
// PORT FIX: was remoteeval(client, eval, nextweapon) -- it told the CLIENT to run its own
// remoteEval builtin and ask for the next weapon. Same result, without that trick.
schedule("remoteNextWeapon(" @ player::getclient(%player) @ ");", 0.1);
}
}

function DeployMineImage::onFire(%player, %slot)
{
%clId = Player::getclient(%player);
if(%player.throwTime < getSimTime() ) {
%clId.canchangeweapon = false;
schedule("DeployMine(" @ %clId @ "," @ %player @ ");", 1);
player::unmountItem(%player, $weaponslot);
}
}

function DeployMine(%clId, %player)
{

	
		if(!Player::isdead(%player)) {
			
			Player::decItemCount(%player,DeployMineAmmo);
			%obj = newObject("","Mine","AiMine");
			%clId.canchangeweapon = true;
			%obj.ownerclient = %clId;
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,3 ,false);
			%player.throwTime = getSimTime() + 1.35;
			//schedule("AiMine::onAdd(" @ %obj @ ");", 4);
			
	}		
		
}

//Anti-Infantry mine
MineData AIMine
{
	className = "Mine";
   description = "Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
	explosionRadius = 10.0;
	damageValue = 1.3;
	damageType = $AIMine;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AIMine::onAdd(%this)
{
	schedule("AIMine::deployCheck(" @ %this @ ");", 4);
}

function AIMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %type == "Moveable") && Gamebase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage+floor(getrandom()*2));
}

function AIMine::deployCheck(%this)
{
	
	GameBase::playSequence(%this,1,"deploy");
	schedule("GameBase::setActive(" @ %this @ ",true);", 1.5);
		
	
}	

function AIMine::onDestroyed(%this)
{
if(%this.ownerclient == "") schedule("AiMine::Respawn(\"" @ gamebase::getposition(%this) @ "\");", 30);
}

function AIMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
%data = gamebase::getdataname(%this);
GameBase::setDamageLevel(%this, %data.maxDamage+floor(getrandom()*2));	
%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%this);
%num = containerBoxFillSet(%Set, $Simplayerobjecttype, %Pos, 30, 30, 30,0); 
for(%x = 0; %x < %num; %x++)
	{
	%curplayer = group::getobject(%set, %x);
	%dist = vector::getdistance(gamebase::getposition(%curplayer), %pos);
	if(!player::isDead(%curplayer)&& %curplayer.isturretguy != 1) WWII::screenshake(%curplayer,0.5*sqrt(1/%dist)); 
	}
deleteobject(%set); 	
}

function AiMine::Respawn(%pos)
{
%obj = newObject("","Mine","AiMine");
addToSet("MissionCleanup", %obj);
GameBase::setposition(%obj, %pos);
GameBase::setRotation(%obj, "0 0 0");
AiMine::onAdd(%obj);
}

function Mine::OnDamage(%this, %type, %val)
{
%dlevel = gamebase::getdamagelevel(%this);
gamebase::setdamagelevel(%this, %dlevel+%val);
}