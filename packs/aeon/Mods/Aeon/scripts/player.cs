$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 200;
//----------------------------------------------------------------------------

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
	Shakeable::addToNetwork(%this);
}

function Player::onRemove(%this)
{
	Shakeable::removeFromNetwork(%this);
}

function Player::enterMissionArea(%this)
{
	%this.outArea = "";
	%client = Player::getClient(%this);
	%client.outArea = "";
	%set = nameToID("MissionCleanup/ObjectivesSet");
	for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
		GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}

function Player::leaveMissionArea(%this)
{
	%this.outArea = 1;
	%client = Player::getClient(%this);
	%client.outArea = 1;
	%newVel = Vector::mult(Item::getVelocity(%this),"-1 -1 1");
	if((Vector::speed(%newVel,true) < 5))
		%newVel = Vector::mult(%newVel,2);
	if((Vector::speed(%newVel,true) < 5))
		%newVel = Vector::mult(%newVel,2);
	Item::setVelocity(%this,%newVel);
	bottomPrint(%client,"<jc><f3>Boing!!",2);
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	Aeon::onKilled(%cl);
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	Player::setDamageFlash(%this,0.75);
	for(%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1) {
			//if(%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
			//	Player::dropItem(%this,%type);
		}
	}
	if(%cl != -1) {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("Item::pop("@%this@");",$CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
	}
}

function Aeon::incItemCount(%player,%item,%delta)
{
	if(!%delta)
		%delta = 1;
	%count = Player::getItemCount(%player,%item);
	Player::setItemCount(%player,%item,%count+%delta);
}

function Player::Slap(%this,%object,%strength,%rot)
{
	%vec = Vector::getFromRot(%rot,%strength);
	GameBase::applyDamage(%this,1,%strength/2000,GameBase::getPosition(%this),%vec,%vec,Player::getClient(%object));
	Player::applyImpulse(%this,%vec);
}

function Player::speedLoop(%player,%go)
{
	if(%go) {
		if($testSpeed[%player])
			$testSpeed[%player] = "";
		else
			$testSpeed[%player] = true;
	}
	if(Player::isJetting(%player)) {
		if(!%player.isJetting) {
			%player.isJetting = true;
			%player.initSpeed = Vector::speed(%player);
			%player.startSpeedTime = getSimTime();
			projectile::spawnprojectile("SuperStart",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
		}
		else {
			if($testRotAim[%player])
				GameBase::setRotation(%player,Vector::splice("0 0 0","0 0 0",Vector::getRotAim(GameBase::getPosition($testRotAim[%player]),GameBase::getPosition(%player),true)));
			%rot = Player::getLookRot(%player);
			%vec = Vector::getFromRot(%rot,1);
			%mult = %player.initSpeed+6*(getSimTime()-%player.startSpeedTime);
			%vel = Vector::mult(%vec,%mult@" "@%mult@" "@%mult);
			Player::setAnimation(%player,14);
			Item::setVelocity(%player,%vel);
			GameBase::setEnergy(%player,5);
		}
	}
	else {
		if(%player.isJetting)
			Item::setVelocity(%player,"0 0 0");
		%player.isJetting = "";
		%player.initSpeed = "";
		%player.startSpeedTime = "";
	}
	if($testSpeed[%player])
		schedule("Player::speedLoop("@%player@");",0.1,%player);
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if(%type < 1 && Player::isJetting(%this) && $testSpeed[%this])
		%value *= -1;
	if(Player::isExposed(%this)) {
		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;
		if(%damagedClient.prisonCell) {
			echo(%type@" : "@%value);
			return;
		}
		Player::applyImpulse(%this,%mom);
		if(!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			if(%vertPos == "head")
				%value += (%value * 0.3);
			if(%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if(%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
  			if(%value) {
				if($DamageScale[%armor,%type])
					%value = $DamageScale[%armor,%type]*%value;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
					if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						Player::blowUp(%this);
					}
					else {
						if((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if(Player::isCrouching(%this)) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos == "head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if(%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if(%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player") {
		%str = 2;
		if(Player::isDead(%this) == true) {
			%vel1 = Item::getVelocity(%this);
			%vel2 = Item::getVelocity(%object);
			Item::setVelocity(%this,Vector::mult(Vector::add(%vel1,%vel2),%str));
		}
		else if(Player::isDead(%object) == true) {
			%vel1 = Item::getVelocity(%this);
			%vel2 = Item::getVelocity(%object);
			Item::setVelocity(%object,Vector::mult(Vector::add(%vel1,%vel2),%str));
		}
		else {
			%vel1 = Item::getVelocity(%this);
			%vel2 = Item::getVelocity(%object);
			//if(Vector::speed(%this) > 0.5) {
			if(Player::isJetting(%this) && $testSpeed[%this]) {
				Item::setVelocity(%object,Vector::mult(%vel1,"2 2 1"));
			}
		}
	}
}

function Player::getHeatFactor(%this)
{
	%client = Player::getClient(%this);
	if(Client::getControlObject(%client) != %this)
		return 1.0;
	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;
	if((%lastTime + 1.5) < %time)
		return 0.0;
	else {
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

function Player::jump(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%vehicle = Player::getMountObject(%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this,%vehicle,0);
		Player::setMountObject(%this,-1,0);
		Player::applyImpulse(%pl,%mom);
		playSound(GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	}
}

//----------------------------------------------------------------------------

function remoteKill(%client,%arg)
{
	if(!$matchStarted || (%client.noSuicide == true && %arg == "") || %client.prisonCell)
		return;
	%player = Client::getOwnedObject(%client);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%client);
		Player::kill(%player);
		//Player::blowUp(%player);
		Client::onKilled(%client,%client);
	}
}

$animNumber = 25;

function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}

function Client::takeControl(%clientId, %objectId)
{
	%pl = Client::getOwnedObject(%clientId);
	if(%objectId == -1 || %pl.driver != "" || %pl.vehicleSlot != "" || GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
		return;
	if(GameBase::getControlClient(%objectId) != -1) {
		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret && !GameBase::isPowered(%objectId))
		return;
	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
		return;
	}
	if(GameBase::getDamageState(%objectId) == "Enabled") {
		Client::setControlObject(%clientId, %objectId);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject) {
		if(%ownedObject == -1 || %ctrlObject == -1)
			return;
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
			return;
		Client::setControlObject(%clientId, %ownedObject);
	}
}