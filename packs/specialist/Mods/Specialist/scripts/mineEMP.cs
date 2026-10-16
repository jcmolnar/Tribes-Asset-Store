$InvList[EMPMine] = 1;
$RemoteInvList[EMPMine] = 1;
$AutoUse[EMPMine] = 0;
$CoreType[EMPMine] = "Mine";
$Core[Mine, $MineInitCounter++] = EMPMine;

$SellAmmo[EMPMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, EMPMine] = 3;
$ItemMax[reconfemalearmor, EMPMine] = 3;
$ItemMax[espionagearmor, EMPMine] = 3;
$ItemMax[espionagefemalearmor, EMPMine] = 3;
$ItemMax[engineerarmor, EMPMine] = 3;
$ItemMax[engineerfemalearmor, EMPMine] = 3;
$ItemMax[infantryarmor, EMPMine] = 3;
$ItemMax[infantryfemalearmor, EMPMine] = 3;
$ItemMax[falloutarmor, EMPMine] = 3;
$ItemMax[falloutfemalearmor, EMPMine] = 3;
$ItemMax[demolitionsarmor, EMPMine] = 5;
$ItemMax[assaultarmor, EMPMine] = 3;
$ItemMax[artilleryarmor, EMPMine] = 3;
$ItemMax[commanderarmor, EMPMine] = 3;

ItemData EMPMine
{
	description = "+ EMP Core";
	shapeFile = "mineammo";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function EMPMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
	
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mEMPMine");
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


MineData mEMPMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = EMPPulseExpSmall;
	explosionRadius = 10.0;
	damageValue = 0.01;
	damageType = $EMPDamageType;
	kickBackStrength = 5;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function mEMPMine::onAdd(%this)
{
	%this.damage = 0;
	mEMPMine::deployCheck(%this);
}

function mEMPMine::onCollision(%this,%object)
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

function mEMPMine::deployCheck(%this)
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
		schedule("mEMPMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mEMPMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mEMPMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
