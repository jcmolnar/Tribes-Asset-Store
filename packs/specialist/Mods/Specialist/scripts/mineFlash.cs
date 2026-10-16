$InvList[FlashMine] = 1;
$RemoteInvList[FlashMine] = 1;
$AutoUse[FlashMine] = 0;
$CoreType[FlashMine] = "Mine";
$Core[Mine, $MineInitCounter++] = FlashMine;

$SellAmmo[FlashMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, FlashMine] = 3;
$ItemMax[reconfemalearmor, FlashMine] = 3;
$ItemMax[espionagearmor, FlashMine] = 3;
$ItemMax[espionagefemalearmor, FlashMine] = 3;
$ItemMax[engineerarmor, FlashMine] = 3;
$ItemMax[engineerfemalearmor, FlashMine] = 3;
$ItemMax[infantryarmor, FlashMine] = 3;
$ItemMax[infantryfemalearmor, FlashMine] = 3;
$ItemMax[falloutarmor, FlashMine] = 3;
$ItemMax[falloutfemalearmor, FlashMine] = 3;
$ItemMax[demolitionsarmor, FlashMine] = 5;
$ItemMax[assaultarmor, FlashMine] = 3;
$ItemMax[artilleryarmor, FlashMine] = 3;
$ItemMax[commanderarmor, FlashMine] = 3;

ItemData FlashMine
{
	description = "+ Flash Core";
	shapeFile = "mineammo";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function FlashMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
	
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mFlashMine");
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
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a mine.");
			}
		}
	}
}


MineData mFlashMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = energyExp;
	explosionRadius = 30.0;
	damageValue = 0.0001;
	damageType = $BlindDamageType;
	kickBackStrength = 0.001;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mFlashMine::onAdd(%this)
{
	%this.damage = 0;
	mFlashMine::deployCheck(%this);
}

function mFlashMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == EMPMine || %data == FlashMine || %data == ConcussionMine || %data == IncendiaryMine || %data == DecoyMine || %data == FlagMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  {

		// Now check for smart mines, and compare the teams
		if ($Specialist::SmartMines) {

			%mineteam = GameBase::getTeam(%this);
			%playerteam = GameBase::getTeam(%object);

			if (%mineteam != %playerteam)
				GameBase::setDamageLevel(%this, %data.maxDamage);
		}
	}
}

function mFlashMine::deployCheck(%this)
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
		schedule("mFlashMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mFlashMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mFlashMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
