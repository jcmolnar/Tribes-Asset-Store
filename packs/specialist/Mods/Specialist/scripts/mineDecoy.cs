$InvList[DecoyMine] = 1;
$RemoteInvList[DecoyMine] = 1;
$AutoUse[DecoyMine] = 0;
$CoreType[DecoyMine] = "Mine";
$Core[Mine, $MineInitCounter++] = DecoyMine;

$SellAmmo[DecoyMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, DecoyMine] = 3;
$ItemMax[reconfemalearmor, DecoyMine] = 3;
$ItemMax[espionagearmor, DecoyMine] = 3;
$ItemMax[espionagefemalearmor, DecoyMine] = 3;
$ItemMax[engineerarmor, DecoyMine] = 3;
$ItemMax[engineerfemalearmor, DecoyMine] = 3;
$ItemMax[infantryarmor, DecoyMine] = 3;
$ItemMax[infantryfemalearmor, DecoyMine] = 3;
$ItemMax[falloutarmor, DecoyMine] = 3;
$ItemMax[falloutfemalearmor, DecoyMine] = 3;
$ItemMax[demolitionsarmor, DecoyMine] = 5;
$ItemMax[assaultarmor, DecoyMine] = 3;
$ItemMax[artilleryarmor, DecoyMine] = 3;
$ItemMax[commanderarmor, DecoyMine] = 3;

ItemData DecoyMine
{
	description = "+ Decoy Core";
	shapeFile = "harmor";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 20;
	className = "HandAmmo";
};

function DecoyMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
	
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mDecoyMine");
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


MineData mDecoyMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "larmor";
	shadowDetailMask = 4;
	explosionId = FlashExpLarge;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mDecoyMine::onAdd(%this)
{
	%this.damage = 0;
	mDecoyMine::deployCheck(%this);
}

function mDecoyMine::onCollision(%this,%object)
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

function mDecoyMine::deployCheck(%this)
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
		schedule("mDecoyMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mDecoyMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mDecoyMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
