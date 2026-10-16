echo("Loading Screaming Fist Version");
$DeathFallDamageType = 31;
$TeleFragDamageType = 32;

$DamageScale[dmale, $DeathFallDamageType] = 1.0;
$DamageScale[dmale, $TeleFragDamageType] = 1.0;

$DamageScale[dfmale, $DeathFallDamageType] = 1.0;
$DamageScale[dfmale, $TeleFragDamageType] = 1.0;

// =================================TELEPORTER=================================
function GroupTrigger::onEnter(%this, %object)
{
	if( %this.kill == "true" )
	{
		killBitches(%object, %object, $DeathFallDamageType);
	}
	else if( %this.teleport == "true" )
	{
		teleport(%this, %object);
	}
	else if( %this.scream == "true" )
	{
		scream(%object);
	}
	else if( %this.machine == "true" )
	{
		$KillStartTime[%object] = getSimTime();
		machFunc(%object);
	}
}

function GroupTrigger::onContact(%this, %object)
{
	if( %this.machine == "true" )
	{
		%time = %this.timeTillKill;
		%value = %this.applyDamage;
		//echo("time ",%time);
		//echo("value ",%value);
		machKillFunc(%object, %time, %value);
	}
}

function teleport(%this, %object)
{
      %positionIn = %this.destination;
	%destinationRot = %this.destRot;
	//echo("%positionIn ",%positionIn);
      %positionOut = GameBase::getPosition(%this);
	//echo("%positionOut ",%positionOut);
	%client = Player::getClient(%object);
      if(%this.in)
      {
		//Telefrag Check
		%fragCheck = GameBase::testPosition(%object, %positionIn);
		if( %fragCheck == "false" )
		{
			//stuff
			%set=newObject("telefragSet",SimSet);
			%num = containerBoxFillSet(%set, $SimPlayerObjectType, %positionIn, 1.0, 1.0, 1.5, getWord(%positionIn, 2));
			if( %num > 0 )
			{
				//stuff
				%count = %num;
				//echo("count ",%count);
				for( %i = 0; %i < %count; %i++)
				{
					%playerToKill = Group::getObject(%set, %i);
					killBitches(%playerToKill, %object, $TeleFragDamageType);
				}
			}
			deleteObject(%set);
		}
	   	GameBase::setPosition(%object, %positionIn);
	   	GameBase::setRotation(%object, %destinationRot);
		playSound(SoundTeleIn, %positionIn);
		playSound(SoundTeleOut, %positionOut);
		Client::SendMessage(%client,0,"~wtelein.wav");
		Client::sendMessage(%client,1,"Teleportation Successful.");  // sends in red in the chat menu
		// centerprint(%client, "<f1><jc>Teleportation Successful!");
      }
      else
      {
		GameBase::setPosition(%object, %positionOut);
		Client::SendMessage(%client,0,"~wshieldhit.wav");
		Client::sendMessage(%client,1,"Teleportation Failed.");  // sends in red in the chat menu
      }
}

// =================================GIB THE FUGGERS=================================

function killBitches(%this, %killer, %type)
{
	%client = Player::getClient(%this);
	%killerClient = Player::getClient(%killer);
	%pos = GameBase::getPosition(%this);
	%test = GameBase::setDamageLevel(%this, 1.0);
	//echo(%test);
	playSound(SoundGibDeath, %pos);
	Client::sendMessage(%client,1,"~wBlowupDeath.wav");
	Player::blowUp(%this);
	Client::onKilled(%client, %killerClient, %type);
}

// =================================MAKE EM SCREAM=================================
function scream(%this)
{
	%client = Player::getClient(%this);
	%rand = getRandom();
	if( %rand >= 0.4)
	{
		Client::sendMessage(%client,1,"~wDMJumpDeathCheer.wav");
	}
	else
	{
		Client::sendMessage(%client,1,"~wDMJumpDeathArg1.wav");
	}
}

// =================================MACHINE EASTER EGG=================================
function machFunc(%this)
{
	%client = Player::getClient(%this);
	Client::sendMessage(%client,1,"~wmach1.wav");
	Client::sendMessage(%client,1,"Welcome, you found Machine's Easter egg. Get back into the game by the teleport in front of you, or you will slowly die!");
}	

function machKillFunc(%this, %time, %value)
{
	echo( getSimTime() - $KillStartTime[%this] );
	if( %time <= getSimTime() - $KillStartTime[%this] )
	{
		%client = Player::getClient(%this);
		%data = GameBase::getDataName(%this);
		%health = GameBase::getDamageLevel(%this);
		%maxHealth = %data.maxDamage;
		echo("health ",%health);
		echo("maxHealth ",%maxHealth);
		if( %health >= %maxHealth - %value )
			killBitches(%this, %this, $TeleFragDamageType);
		else
			GameBase::setDamageLevel(%this,%health + %value);
	}
}
