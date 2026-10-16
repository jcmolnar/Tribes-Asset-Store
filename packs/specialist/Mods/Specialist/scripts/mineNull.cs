$CoreType[NullMine] = "Mine";
$Core[Mine, $MineInitCounter++] = NullMine;

ExplosionData nullMineExp
{
   shapeName = "breath.dts";
   soundId   = SoundLFootLSoft;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.001;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ItemData NullMine
{
	description = "Null Mine Core";
	shapeFile = "grenade";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function NullMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,MineAmmo);
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","mNullMine");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);

			// If smart mines, set this mine's team
			if ($Specialist::SmartMines) {
				%playerteam = GameBase::getTeam(%player);
				GameBase::setTeam(%obj, %playerteam);
			}

			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

MineData mNullMine
{
	className = "Mine";
	description = "Null Mine Core";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = nullMineExp;
	explosionRadius = 0.1;
	damageValue = 0.0001;
	damageType = $NullDamageType;
	kickBackStrength = 1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mNullMine::onAdd(%this)
{
	%this.damage = 0;
	mNullMine::deployCheck(%this);
}

function mNullMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == mNullMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function mNullMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("mNullMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mNullMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mNullMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
