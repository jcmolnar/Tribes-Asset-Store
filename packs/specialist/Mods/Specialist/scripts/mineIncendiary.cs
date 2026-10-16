$InvList[IncendiaryMine] = 1;
$RemoteInvList[IncendiaryMine] = 1;
$AutoUse[IncendiaryMine] = 0;
$CoreType[IncendiaryMine] = "Mine";
$Core[Mine, $MineInitCounter++] = IncendiaryMine;

$SellAmmo[IncendiaryMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, IncendiaryMine] = 3;
$ItemMax[reconfemalearmor, IncendiaryMine] = 3;
$ItemMax[espionagearmor, IncendiaryMine] = 3;
$ItemMax[espionagefemalearmor, IncendiaryMine] = 3;
$ItemMax[engineerarmor, IncendiaryMine] = 3;
$ItemMax[engineerfemalearmor, IncendiaryMine] = 3;
$ItemMax[infantryarmor, IncendiaryMine] = 3;
$ItemMax[infantryfemalearmor, IncendiaryMine] = 3;
$ItemMax[falloutarmor, IncendiaryMine] = 3;
$ItemMax[falloutfemalearmor, IncendiaryMine] = 3;
$ItemMax[demolitionsarmor, IncendiaryMine] = 5;
$ItemMax[assaultarmor, IncendiaryMine] = 3;
$ItemMax[artilleryarmor, IncendiaryMine] = 3;
$ItemMax[commanderarmor, IncendiaryMine] = 3;

ItemData IncendiaryMine
{
	description = "+ Incendiary Core";
	shapeFile = "mineammo";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 15;
	className = "HandAmmo";
};

function IncendiaryMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
	
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mIncendiaryMine");
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


MineData mIncendiaryMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = FlashExpLarge;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $FireDamageType;
	kickBackStrength = 100.0;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mIncendiaryMine::onAdd(%this)
{
	%this.damage = 0;
	mIncendiaryMine::deployCheck(%this);
}

function mIncendiaryMine::onCollision(%this,%object)
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

function mIncendiaryMine::deployCheck(%this)
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
		schedule("mIncendiaryMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mIncendiaryMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mIncendiaryMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
