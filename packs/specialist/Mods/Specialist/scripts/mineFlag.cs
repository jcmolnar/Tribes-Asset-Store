$InvList[FlagMine] = 1;
$RemoteInvList[FlagMine] = 1;
$AutoUse[FlagMine] = 0;
$CoreType[FlagMine] = "Mine";
$Core[Mine, $MineInitCounter++] = FlagMine;

$SellAmmo[FlagMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, FlagMine] = 3;
$ItemMax[reconfemalearmor, FlagMine] = 3;
$ItemMax[espionagearmor, FlagMine] = 3;
$ItemMax[espionagefemalearmor, FlagMine] = 3;
$ItemMax[engineerarmor, FlagMine] = 3;
$ItemMax[engineerfemalearmor, FlagMine] = 3;
$ItemMax[infantryarmor, FlagMine] = 3;
$ItemMax[infantryfemalearmor, FlagMine] = 3;
$ItemMax[falloutarmor, FlagMine] = 3;
$ItemMax[falloutfemalearmor, FlagMine] = 3;
$ItemMax[demolitionsarmor, FlagMine] = 5;
$ItemMax[assaultarmor, FlagMine] = 3;
$ItemMax[artilleryarmor, FlagMine] = 3;
$ItemMax[commanderarmor, FlagMine] = 3;

ItemData FlagMine
{
	description = "+ Flag Decoy Core";
	shapeFile = "flag";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 15;
	className = "HandAmmo";
	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

};

function FlagMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
	
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","mFlagMine");
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


MineData mFlagMine
{
	className = "Mine";
	description = "Flag Decoy Mine";
	shapeFile = "flag";
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
	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function mFlagMine::onAdd(%this)
{
	%this.damage = 0;
	mFlagMine::deployCheck(%this);
}

function mFlagMine::onCollision(%this,%object)
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

function mFlagMine::deployCheck(%this)
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
		schedule("mFlagMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function mFlagMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function mFlagMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
