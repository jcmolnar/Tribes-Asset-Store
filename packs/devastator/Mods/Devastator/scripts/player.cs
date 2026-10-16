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
$PlayerAnim::Funk = 44;
//----------------------------------------------------------------------------
//ICE'S LASER RECOGNITION MODULE, DAMAGE TO PERFECTION
//----------------------------------------------------------------------------
//$DamageToLaser[(Weapon ImageType Here)]          = (DamageType Goes here);
$DamageToLaser[LP]          = $LPDamageType;
$DamageToLaser[Beam]        = $BeamDamageType;
$DamageToLaser[FL]          = $FlashDamageType;
$DamageToLaser[SLazer]      = $GODDamageType;
//----------------------------------------------------------------------------
//ICE'S LASER DETERIORATION MODULE, DAMAGE BY DISTANCE
//----------------------------------------------------------------------------
//$LaserFullPwrRange[(Weapon ImageType Here)]          = (How far the laser reaches while applying full damage);
$LaserFullPwrRange[LP] = 100;

//$LaserDeterioRate[(Weapon ImageType Here)]          = (The rate of how fast the laser loses strength past its $LaserFullPwrRange);
$LaserDeterioRate[LP] = 0.01;
//----------------------------------------------------------------------------
$IP1 = marmor.maxJetForwardVelocity@$ItemMax[tarmor, Shotgun1Ammo];
$IP2 = qfemale.maxSideSpeed@$MaxWeapons[marmor];
$IP3 = LP.price-109;
$IP4 = $ItemMax[marmor, RLAmmo]*(Repairgun.Imagetype.maxEnergy);
//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------
$FlameBurnElevation = 2;

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	for(%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1) {
			%item = newObject("","Item",%type,1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if(%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
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
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
	}
}

function ApplyKickback(%player,%strength,%lift)
{
	%vec = Vector::getFromRot(GameBase::getRotation(%player),Vector::neg(%strength),%lift);
	Player::applyImpulse(%player,%vec);
}

function LOSCheck(%player, %Dist, %rot)
{
	if(GameBase::getLOSInfo(%player,%Dist,%rot)) {
		if($los::object)
			return TRUE;
		else
			return FALSE;
	}
	else
		return FALSE;
}
function EMPsystem(%this,%time)
{
	if(GameBase::getRechargeRate(%this) >= 8) {
		EMPon(%this);
		schedule("EMPoff("@%this@");",%time);
	}
	else if(%this.DeadWeight != true) {
		%this.DeadWeight = true;
		Player::mountItem(%this,DeadWeight, 20);
		Player::setDamageFlash(%this,0.5);
		schedule("Player::decItemCount("@%this@","@DeadWeight@");",5);
		schedule(%this@".DeadWeight = false;",5);
	}
}

function EMPon(%this)
{
	%client = Player::getClient(%this);
	if(GameBase::getRechargeRate(%this) >= 8)
		Client::sendMessage(%client,0,"Energy systems offline...");
	GameBase::setRechargeRate(%this,0);
	GameBase::setEnergy(%this,0);
}

function EMPoff(%this)
{
	%client = Player::getClient(%this);
	GameBase::setRechargeRate(%this,8);
	Client::sendMessage(%client,0,"Energy systems online...");
}

function TazeEm(%this,%time)
{
	Client::sendMessage(Player::getClient(%this),0,"You've been Tazered!");
	%this.tazered = %time; //- 25 makes Tazer effect last for 5.99999 secs, or rounded to 6 =)
	Tazer(%this);
}

function Tazer(%this)
{
	%client = Player::getClient(%this);
	%rand = getRandom()*10 - 5;
	GameBase::setEnergy(%this,GameBase::getEnergy(%this)+%rand*5);
	%rot = Vector::add(GameBase::getRotation(%client),"0 0 "@%rand); // X= not used in players, Y= not used in players, Z= left-right
	GameBase::setRotation(%client,%rot);
	%vec = Vector::getFromRot(GameBase::getRotation(%client),%rand*20);
	Player::applyImpulse(%client,%vec);
	%this.tazered--;
	if(%this.tazered > 0)
		schedule("Tazer("@%this@");",0.25,%this);
	else
		Client::sendMessage(%client,0,"The Tazer effects wore off!");
}

function TempBlind(%this,%type)
{
	%sentance = "";
	if(Player::getDamageFlash(%this) < 0.7) { //- This avoids ultra spam caused by an overdose of confetti, this way we have SOME balance
		Player::setDamageFlash(%this,1.0);
		if(%type != "")
			%sentance = " through the ";
		Client::sendMessage(Player::getClient(%this), 0, "You can't see"@%sentance@%type@"!");
	}
}

function FunkRot(%client)
{
// player rot = up/down , roll , left/right
// 5.4977871445 : 7/8
// 4.712388981  : 6/8
// 3.9269908175 : 5/8
// 3.141592654  : 4/8
// 2.3561944905 : 3/8
// 1.570796327  : 2/8
// 0.7853981635 : 1/8
}

function GetFunky(%this)
{
	if(%this.funkified == 1)
		return;
	%this.funkified = 1;
	Player::unMountItem(%this,$WeaponSlot);
	Player::incItemCount(%this,DeadWeight);
	Player::mountItem(%this,DeadWeight, 4);
	Client::sendMessage(Player::getClient(%this), 0, "\"Party!\"");
	Player::setAnimation(%this,44);
	%sound = radnomItems(3,Cheer1,Cheer2,Cheer3);
	playVoice(Player::getClient(%this),%sound);
	schedule("Player::decItemCount(" @ Player::getClient(%this) @ ",DeadWeight);", 2);
	schedule(%this@".funkified = 0;",5);
}

function SetOnFire(%this,%object,%time)
{
	Client::sendMessage(Player::getClient(%this),0,"Your on fire!");
	%this.burning = %time * 0.5;
	Burn(%this,%object);
}

function Burn(%this,%object)
{
	if(%this.burning > 0) {
		%value = 0.05;
		if(GameBase::getDamageLevel(%this)+%value < Player::getArmor(%this).maxDamage) {       	
			Player::setDamageFlash(%this,%this.burning/10);
			%pos = Vector::add(GameBase::getPosition(%this),"0 0 "@$FlameBurnElevation);
			%trans = "0 0 0 0 0 0 0 0 0 "@%pos;
			%Xvel = getword(Item::getVelocity(%this),0);
			%Yvel = getword(Item::getVelocity(%this),1);
			%Vel = %Xvel@" "@%Yvel@" 25";
			%fire = Projectile::spawnProjectile("Burning",%trans,%this,%Vel,%this);
			%fire.victim = %this;
			GameBase::setDamageLevel(%this,GameBase::getDamageLevel(%this) + %value);
			if(Player::isCrouching(%this) && %this.burning >= 1)
				%this.burning--; // crouching makes the fire go out in 5 secs if you move around and 10 if you only crouch.
			if(GameBase::isAtRest(%this))
				%this.burning -= 0.5; // takes 20 secs if you don't move or crouch.
			else
				%this.burning--; // the fire will go out in 10 secs as long as you don't stop moving.
			schedule("Burn("@%this@","@%object@");",0.5,%this);
		}
		else {
			Player::killOff(%this,%object,$FlameDamageType);
			return;
		}
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"The fire went out!");
}

function Freeze(%this)
{
	Player::incItemCount(%this,DeadWeight);
	Player::mountItem(%this,DeadWeight, 4);
	Client::sendMessage(Player::getClient(%this), 0, "You Are Frozen!");
	schedule("Player::decItemCount("@ %this @","@ DeadWeight@ ");", 15);
}

function ChangeProjVel(%proj,%type)
{
	echo("Changing Proj: "@%proj@", to: "@%type);
	if(%type == "Back")
		%projVec = Vector::neg(Item::getVelocity(%proj));
	else if(%type != "")
		%projVec = Vector::add(Item::getVelocity(%proj),%type);
	else
		%projVec = Item::getVelocity(%proj);		
	Item::setVelocity(%proj,%projVec);
}

function ZigZag(%proj)
{
	%z = getword(Item::getVelocity(%proj),2);
	Item::setVelocity(%proj,Vector::add(Item::getVelocity(%proj),"0 0 "@-%z));
	schedule("ZigZag("@%proj@");",0.25,%proj);
}

function GetTeam(%this,%object)
{
	if(getObjectType(%this) == "Player" && getObjectType(%object) == "Player") {
		if($teamplay && Player::getClient(%this) != Player::getClient(%object) && GameBase::getTeam(Player::getClient(%this)) == GameBase::getTeam(Player::getClient(%object)))
			return Same;
		else if($teamplay && Player::getClient(%this) != Player::getClient(%object) && GameBase::getTeam(Player::getClient(%this)) != GameBase::getTeam(Player::getClient(%object)))
			return Dif;
		else if(!$teamplay && Player::getClient(%this) != Player::getClient(%object))
			return Enemies;
		else
			return You;
	}
	else {
		if($teamplay && %this != %object && GameBase::getTeam(%this) == GameBase::getTeam(%object))
			return Same;
		else if($teamplay && %this != %object && GameBase::getTeam(%this) != GameBase::getTeam(%object))
			return Dif;
		else if(!$teamplay && %this != %object)
			return Enemies;
		else
			return You;
	}
}

function IsIce(%client)
{
	// PORT: this returned TRUE for any player NAMED "Ice" (the author). 20 call sites gave that name
	// immunity to kick / ban / kill, a private loadout and the kill / manipulate commands on every server.
	return FALSE;
}

function AreGod(%this)
{
	%Pack = Player::getMountedItem(%this,$BackpackSlot);
	if(%Pack.className == GOD && Player::isTriggered(%this,$BackpackSlot) == True) {
		if(%Pack == DemiPack)
			return DEMI;
		else if(%Pack == Perfect)
			return PERFECT;
		else if(%Pack == UltraPack)
			return ULTRA;
		else
			return TRUE;
	}
	else
		return FALSE;
}

function AreSniper(%this)
{
	%armor = Player::getArmor(%this);
	%weap = Player::getMountedItem(%this,$WeaponSlot);
	if($ArmorName[%armor] == SniperArmor) {
		if(%weap == SR)
			return TRUE;
	}
	else
		return FALSE;
}

function EvilStuff(%object,%radius,%strength,%type)
{
	Client::sendMessage(%object,0,"That was stupid!"); 
	Player::unMountItem(%object,$WeaponSlot);
	%ObjPos = GameBase::getPosition(%object);
	GameBase::applyRadiusDamage(%type, %ObjPos, %radius, %strength, %strength, %object);
	%MINE = newObject("","Mine","AntipersonelMine");
	addToSet("MissionCleanup",%MINE);
	GameBase::setRotation(%MINE,"0 0 0");
	GameBase::setPosition(%MINE,%ObjPos);
	return;
}

$WeapProjectile[SR] = SniperRocket;
$WeapProjectile[AR] = AssaultBullet;
$WeapProjectile[MG] = ChaingunBullet2;
$WeapProjectile[RL] = FireRocket;

//-Engine onFire replicant by Ice
//-Usage: "Weapon::onFire(%player,(ProjectileTypeHere),(UseAmmo,DefaultTrue),(ProjectileSpeedMultiplier,Default1)
function Weapon::onFire(%player,%special,%Eat,%speed)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%player);
	%armor = Player::getArmor(%player);
	%weap = Player::getMountedItem(%player,$WeaponSlot);
	%ammo = $WeaponAmmo[%weap];
	if(%ammo != "") {
		if(Player::getItemCount(%player,%ammo) < 1)
			return;
	}
	GameBase::getLOSInfo(%player,3000);
	%rot = GameBase::getRotation(%player);
	%targetPos = $los::position;
	%trans = GameBase::getMuzzleTransform(%player);
	%vec0 = getWord(%trans,0);
	%vec1 = getWord(%trans,1);
	%vec2 = getWord(%trans,2);
	%vec3 = getWord(%trans,6);
	%vec4 = getWord(%trans,7);
	%vec5 = getWord(%trans,8);
	%vec6 = getWord(%trans,9);
	%vec7 = getWord(%trans,10);
	%vec8 = getWord(%trans,11);
	%vecX = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
	%rot1 = %vec0@" "@%vec1@" "@%vec2;
	%rot2 = %vec3@" "@%vec4@" "@%vec5;
	%pos1 = %vec6@" "@%vec7@" "@%vec8;
	%rot0 = Vector::getRotAim(%Pos1,%targetPos);
	if(%speed == "")
		%speed = 1;
	%vec = Vector::getFromRot(%rot0,%speed);
	if(%targetPos)
		%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot0@" "@%pos1;
	%type = $WeapProjectile[%weap];
	if(%special != "" && %special != "0")
		%type = %special;
	%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);
	if(getObjectType(%proj) == LaserProjectile && $los::object) {
		%dmgType = $LaserDamageType;
		%value = %type.damageConversion;
		if(GameBase::getEnergy(%player) > %weap.imageType.minEnergy)
			%value *= %weap.imageType.maxEnergy;
		%pos = GameBase::getPosition($los::object);
		%vecI = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
		%mom = "0 0 0";
		GameBase::applyDamage($los::object,%dmgType,%value,%pos,%vecI,%mom,%client);
	}
	if(%ammo != "" && %Eat != False)
		Player::DecItemCount(%player,%ammo);
	else if(%weap.imageType.maxEnergy != "")
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-%weap.imageType.maxEnergy);
	if($FifthElementGuns != 1)
		$los::position = "";
	$los::object = "";
	return %proj;
}

function Player::killOff(%this,%object,%type,%anim,%special)
{
	echo(%this.observerMode);
	if(%this.observerMode == "dead")
		return false;
	echo("Killing: "@%this@", by: "@%type@", with anim: "@%anim@" "@%special);
	if(%this.owner)
		%this.owner.owns = "";
		if(Player::isDead(%this))
		return;
	if(%object == Server)
		Client::onKilled(Player::getClient(%this),"Server",%type,%special);
	else
		Client::onKilled(Player::getClient(%this),%object,%type,%special);
	if(%anim == "BlowUp")
		Player::blowUp(%this);
	else if(!%anim)
		playNextAnim(Player::getClient(%this));
	else
		Player::setAnimation(%this,%anim);
	Player::kill(%this);
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if(AreGOD(Player::getClient(%this)) == "PERFECT" && %object != Player::getClient(%this) && getObjectType(%object) == "Player")
		Player::killOff(%object,Player::getClient(%this),$GODDamageType,"BlowUp");
	if(getObjectType(%object) == "Flier")
		%object = %object.clLastMount;
	if(%this.driver == 1 && %this.vehicle.superShield == 1)
		return;
	if(%type == $LaserDamageType) {
		%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(Player::getClient(%this),%object) == "Same")
			%value = 0;
	}
	//-Laser Range Damage Multiplier
	if(%type == $LPDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			%value -= %rate;
		}
		if(%Dist <= 1.75) //- Instant kill at point blank if its a laser
			%value = 1.5;
		if(%value <= 0.0005)
			%value = 0;
	}
	else if(Player::getMountedItem(%this,$WeaponSlot) == PAttack && %type != $BoomDamageType) {
		%Tvalue = %value;
		if($DamageScale[Player::getArmor(%this),%type] != "")
			%Tvalue = $DamageScale[Player::getArmor(%this),%type] * %value;
		if(GetTeam(Player::getClient(%this),%object) == "Same")
			%Tvalue = Tvalue * $Server::TeamDamageScale;
		%delta = %Tvalue * 100;
		if(%delta + Player::getItemCount(%this,RageAmmo) > 100)
			%delta = 100 - Player::getItemCount(%this,RageAmmo);
		echo("Adding Rage Ammo: "@%delta@", Ammo: "@Player::getItemCount(%this,RageAmmo));
		Player::incItemCount(%this,RageAmmo,%delta);
		%Ammo = Player::getItemCount(%this,RageAmmo);
		bottomprint(Player::getClient(%this),"<f1><jc>Your Anger is at <f5>%"@%Ammo@"<f1>!",5);
	}
	else if(%type == $BoomDamageType) {
		%DamagedClient = Player::getClient(%this);
		if(%object == %DamagedClient &&($WeapMode[%object,PAttack] == 1||$WeapMode[%object,PAttack] == ""))
			%value = 0;
		else {
			%delta = %object.tempRageCount / 100;
			%value *= %delta;
			%object.tempRageCount = "";
		}	
	}
	else if(%type == $ProtonDamageType)
		EMPsystem(%this,5);
	else if(%type == $TazerDamageType &&(%this.tazered <= 0 || %this.tazered == ""))
		TazeEm(%this,25);
	else if(%type == $BeerDamageType &&(%this.drunk == 0 || !%this.drunk))
		GetDrunk(%this,%object,%vertPos);
	else if(%type == $ImpactDamageType && %this.drunk > 0 && %this.drunk != "")
		DrunkStupidity(%this,%object,"FlyBy");
	else if(%type == $LandingDamageType && %this.drunk > 0 && %this.drunk != "" && %Value >= 0.05)
		DrunkStupidity(%this,%object,"Fall");
	else if(%type == $FlameDamageType) {
		if(Player::getMountedItem(%this,$BackpackSlot) == BeamPack && %this.trytoburn != 1) {
			Client::sendMessage(%object, 0, %VName@" has on a Coolant Pack!");
			%this.trytoburn = 1;
			schedule(%this@".trytoburn = 0;",3);
			return;
		}
		else if(%this.trytoburn != 1 && AreGOD(Player::getClient(%this)) != false) {
			Client::sendMessage(%object, 0, "You can't burn GODs like "@%VName@"!");
			%this.trytoburn = 1;
			schedule(%this@".trytoburn = 0;",3);
			return;
		}
		else {
			if(%this.burning <= 0 && %this.trytoburn == 0)
				SetOnFire(%this,%object,20); //- %this = victim, %object = burner, 20 = time in seconds to burn if not tended to
		}
		if(%this.burning > 0)
			%Value *= %this.burning/5;			
	}
	else if(%type == $FreezeDamageType)
		Freeze(%this);
	else if(%type == $ConfettiDamageType)
		TempBlind(%this,"confetti");
	else if(%type == $SmokeDamageType)
		TempBlind(%this,"smoke");
	else if(%type == $FlashDamageType) {	
		echo(%object@" blinded "@%this@"!");
		%KName = Client::getName(%object);
		if(Player::getDamageFlash(%this) < 0.35)
			Client::sendMessage(Player::getClient(%this), 0, "You've been blinded by "@%KName@"'s Flashlight!");
		Player::setDamageFlash(%this,1.0);
	}
	else if(%type == $TargetDamageType) {
		%client = Player::getClient(%this); 
		if(Player::getArmor(%this) == sarmor || Player::getArmor(%this) == sfemale || Player::getMountedItem(%this,$BackpackSlot) == CSDPack) 
			GameBase::startFadeIn(%this); 
		GameBase::setIsTarget(%client,true);
		Client::sendMessage(%client, 0, "You've been Targeted!");
		schedule("GameBase::setIsTarget(" @%client@ ","@false@");", 20);
		return;
	}
	else if(%type == $FunkDamageType)
		GetFunky(%this);
	else if(%type == $EvilPongDamageType && AreGod(%this) != ultra && AreGod(%this) != PERFECT) {
		Player::killOff(%this,%object,%type,33);
		return;
	}
      	else if(%type == $SniperDamageType) {						
		%Name = Client::getName(Player::getClient(%this));
		if(%vertPos == "head") {
			if(AreGod(%this) == true || AreGod(%this) == ultra || AreGod(%this) == perfect) {
				EvilStuff(%object,1,0.2,$SniperDamageType);
				schedule(%object.triedtokill@" = "@0@");",5);
				return;
			}
			%sound = radnomItems(3,Cheer1,Cheer2,Cheer3);
			playVoice(%object, %sound);	
			bottomprint(%object, "<f1><jc>You nailed <f5>"@%Name@"<f1> in the head!", 5);
			if(Client::getTeam(Player::getClient(%this)) == Client::getTeam(%object))
				%object.score-=2;
			else
				%object.score+=2;
			Player::killOff(%this,%object,%type,27,HS);
			Game::refreshClientScore(%object);
		}
	}
	else if(%type == $PsychoDamageType) {
		%ThisArmor = Player::getArmor(%this);
		%ThatArmor = Player::getArmor(%object);
		if($ArmorName[%ThisArmor] == PsychoArmor && $ArmorName[%ThatArmor] != PsychoArmor) {
			%value = 0.1;
			bottomprint(Player::getClient(%this),"<f1><jc>Your too close too a ¡Psycho!", 2);
		}
		else if($ArmorName[%ThisArmor] == PsychoArmor && $ArmorName[%ThatArmor] == PsychoArmor) {
			%value = -0.1;
			bottomprint(Player::getClient(%this),"<f1><jc>¡Psycho!'s rule!", 2);
		}
	}
	%armor = Player::getArmor(%this);
	if(GetTeam(Player::getClient(%this),%object) == "Same")
		%value = 0;
	if(Player::isExposed(%this)) {
		%damagedClient = Player::getClient(%this);
      		%shooterClient = Player::getClient(%object);
		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient)) {
			if(%shooterClient != -1) {
				%curTime = getSimTime();
				if((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	
		if(!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor" || %armor == "tarmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						%value += (%value * 0.3);
				}
				else
					%value += (%value * 0.3);
			}
			//If Shield Pack is on
			if(%type != -1 && %this.shieldStrength && %type != $BeamDamageType) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
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
			//If your are Enraged (GOD)
			if(AreGod(%this) != false) {
				%VName = Client::getName(Player::getClient(%this));
				%KName = Client::getName(%object);
				%value = -0.1;
				if(AreGod(%this) == PERFECT)
					%value = -1.0;
				if(%type == $MiniDamageType || %type == $SBulletDamageType || %type == $BulletDamageType || %type == $SBulletDamageType || %type == $PBulletDamageType || %type == $SniperDamageType || %type == $BulletTDamageType || %type == $BulletVDamageType)
					Weapon::onFire(%player,Ricochet,False);
				else if(%type == $RicochetDamageType || %type == $EvilPongDamageType) {
					Bottomprint(Player::getClient(%this),"<jc><f4>GOD PONG!");
					Bottomprint(Player::getClient(%object),"<jc><f4>GOD PONG!");
					//if(AreGod(%this) == ultra)
						//Projectile::spawnProjectile("EvilPong",GameBase::getMuzzleTransform(%this),%this,Item::getVelocity(%this),%object);
					//else
					%NewPong = Weapon::onFire(%player,Pong,False);
					%NewPong.target = %object;
				} else {
					%Vpos = GameBase::getPosition(%this);
					%Kpos = GameBase::getPosition(%object);
					%Dist = Vector::getDistance(%Vpos,%Kpos);
					if((%KName != "")&&(%VName != %KName)&&(%Dist != 0)&&(%type != $LandingDamageType))
						bottomprint(Player::getClient(%this),"<f1><jc>You were hit by <f5>"@%KName@"<f1> from <f5>"@%Dist@"<f1> ticks away!", 5);
				}
				GameBase::activateShield(%this,%vec,((getWord(%pos,2))-(getWord(getBoxCenter(%this),2))));
			}
  			if(%value) {
				if($DamageScale[All, %type] != "")
					%value = $DamageScale[All, %type] * %value * %friendFire;
				else if($DamageScale[%armor, %type] != "")
					%value = $DamageScale[%armor, %type] * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
            			%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
					if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType|| %type == $NukeDamageType|| %type == $MultiDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                				Player::blowUp(%this);
					}
					else {
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if(Player::isCrouching(%this))
							%curDie = $PlayerAnim::Crouching;						
						else if(%vertPos=="head") {
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
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient,%type,%special);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function GiveItems(%this,%object)
{
	%sound = false;
	%max = getNumItems();
	for(%i = 0;%i < %max; %i = %i + 1) {
		%count = Player::getItemCount(%this,%i);
		if(%count) {
			%delta = Item::giveItem(%object,getItemData(%i),%count);
			if(%delta > 0) {
				Player::decItemCount(%this,%i,%delta);
				%sound = true;
			}
		}
	}
	if(%sound)
		playSound(SoundPickupItem,GameBase::getPosition(%this));
}

function Player::onCollision(%this,%object)
{
	%ThisArmor = Player::getArmor(%this);
	%ThatArmor = Player::getArmor(%object);
	if(Player::isDead(%this) && getObjectType(%object) == "Player")
		GiveItems(%this,%object);
	if($ArmorName[%ThisArmor] == PsychoArmor || $ArmorName[%ThatArmor] == PsychoArmor) {
		if($ArmorName[%ThisArmor] == PsychoArmor && $ArmorName[%ThatArmor] != PsychoArmor)
			GameBase::applyDamage(%object,$PsychoDamageType,0.1, GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
		else if($ArmorName[%ThisArmor] == PsychoArmor && $ArmorName[%ThatArmor] == PsychoArmor)
			GameBase::applyDamage(%object,$PsychoDamageType,-0.1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
	if(getObjectType(%object) == "Player" && getObjectType(%this) == "Player") {
		if(Player::isDead(%this) || Player::isDead(%object))
			return;
		if(AreGOD(%this) == perfect)
			Player::killOff(Player::getClient(%object),Player::getClient(%this),$GODDamageType,"BlowUp");
		else if(AreGOD(%object) == perfect) 
			Player::killOff(Player::getClient(%this),Player::getClient(%object),$GODDamageType,"BlowUp");
	}
	if(getObjectType(%this) == "Player" && Player::getMountedItem(%object,$WeaponSlot) == HG && !Player::isDead(%this)) {
		if(Client::getTeam(Player::getClient(%object)) != Client::getTeam(Player::getClient(%this))) {
			if(GameBase::isAtRest(%this)) {
				if(%this.drunk > 0 && %this.drunk != "")
					DrunkStupidity(%this,%object,"HG");
				%obj = Player::getClient(%this);
				Player::trigger(%this,$WeaponSlot,false);
				Player::trigger(%this,$BackpackSlot,false);
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				%packType = Player::getMountedItem(%this,$BackpackSlot);
				if(%weaponType != -1)
					Player::dropItem(%this,%weaponType);
				if(AreGod(%player) != false && AreGod(%player) != demi && getObjectType(%obj) == "Player")
					Player::setItemCount(%player,Ultra,1);
				if(%packType != -1)
					Player::dropItem(%this,%packType);
				GiveItems(%this,%object);
				%sound = radnomItems(2,Oops1,Oops2);	
				GameBase::setRotation(%obj,GameBase::getRotation(Player::getClient(%object)));
				Player::setAnimation(%obj, 38);
				playVoice(%obj,%sound);
				GameBase::setIsTarget(%obj,true);
				$Reloading[%obj] = 1;
				%Name = Client::getName(Player::getClient(%object));
				%Tame = Client::getName(%obj);
				Client::sendMessage(Player::getClient(%object),0,"You took "@%Tame@" Hostage!");
				Client::sendMessage(%obj,0,"You have been taken Hostage by "@%Name@"!");
				%vec = Vector::getFromRot(GameBase::getRotation(Player::getClient(%object)),225);
				Player::applyImpulse(%obj,%vec);
				schedule("GameBase::setIsTarget(" @%obj@ "," @FALSE@ ");",5,%obj);
				schedule($Reloading[%obj] = 0,5);
				if(%this.DeadManDrunk == 1)
					Player::killOff(%this,%object,$HGDamageType,"",Drunk);
			}
			else
				Client::sendMessage(Player::getClient(%object),0,"You can only take some one by surprise");
		}
	}
}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	if(Client::getControlObject(%client) != %this)
		return 1.0;
	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;
	if((%lastTime + 1.5) < %time) {
		return 0.0;
	} else {
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

function Player::jump(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound(GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	}
}

//----------------------------------------------------------------------------

function remoteKill(%client)
{
	if(!$matchStarted)
		return;
	%player = Client::getOwnedObject(%client);
	if(IsIce(%client)) {
		%pos = GameBase::getPosition(%player);
		%obj = newObject("","Item","TeleZap",1,false);
		addToSet("MissionCleanup",%obj); Gamebase::setposition(%obj,%pos);
		%client.score += 2;
	}
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		if(Player::getMountedItem(%player, $WeaponSlot) == sword) {
			Player::killOff(%player,%player,"",42);
			return;
		} else if(IsIce(%client)) {
			Player::setAnimation(%client,45);
			schedule("GameBase::startFadeOut("@%client@");",1.0);
			Player::kill(%client);
		} else {
			playNextAnim(%client);
			Player::kill(%client);
		}
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
   // remote control
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableCTurret && %name != DeployablePTurret && %name != DeployableDTurret)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
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
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}