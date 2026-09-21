//make sure .owns is assigned for CorpseMA Stuff

$ScoreWeapon[DiscLauncher] = 4;
$ScoreWeapon[PlasmaGun] = 3;
$ScoreWeapon[GrenadeLauncher] = 5;
$ScoreWeapon[Blaster] = 8;
$ScoreWeapon[Chaingun] = 1;
$ScoreWeapon[LaserRifle] = 6;
$ScoreWeapon[HandGrenade] = 14;
$ScoreWeapon[Mortar] = 7;

$ScoreWeapon[DiscLauncherPurple] = 4;
$ScoreWeapon[DiscLauncherBlack] = 4;
$ScoreWeapon[DiscLauncherGreen] = 4;
$ScoreWeapon[DiscLauncherPink] = 4;
$ScoreWeapon[DiscLauncherBlue] = 4;
$ScoreWeapon[DiscLauncherYellow] = 4;
$ScoreWeapon[DiscLauncherKing] = 4;

$ScoreWeapon["NULL"] = "N\\A";
$ScoreWeapon[0] = "Gaia";
$ScoreWeapon[1] = "Chaingun";
$ScoreWeapon[3] = "PlasmaGun";
$ScoreWeapon[4] = "DiscLauncher";
$ScoreWeapon[5] = "GrenadeLauncher";
$ScoreWeapon[6] = "LaserRifle";
$ScoreWeapon[7] = "Mortar";
$ScoreWeapon[8] = "Blaster";
$ScoreWeapon[9] = "ELFGun";
$ScoreWeapon[14] = "HandGrenade";


function remoteSup(%clientId,%amt)
{
	%pl = Client::getOwnedObject(%clientId);
	GameBase::getLOSInfo(%pl, "9000");
	%offset = floor(%amt/2);
	%offset = %offset@" "@%offset@" 0";
	%pos = vector::add($los::position,"0 0 1");
	for(%a = 0; %a < %amt; %a++)
	{
		for(%b = 0; %b < %amt; %b++)
		{
			for(%c = 0; %c < %amt; %c++)
			{
				makebeaconthere(%clientId,vector::add(vector::add(%pos, %a@" "@%b@" "@%c), %offset));
			}
		}
	}
}

	//%obj = newObject("","Mine","Handgrenade");
	//addToSet("MissionCleanup", %obj);
		//%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);

// 1.50 PORT: was DefaultBeaconitem::setvelocity(...) -- no such command exists in the
// engine or anywhere in this mod, so the beacon never got its upward kick. Item::setVelocity
// is the real command and is what every other site in this mod uses.
Item::setVelocity(%beacon, "0 0 20");
function Client::LastActionUpdate(%client, %action)
{
	%time = Time::getMinutes((getSimTime() - %client.LastAction));
	if(%time > 0.9)
	{
		%client.LastAction = getSimTime();
		Game::refreshClientScore(%client);
	}
	else
	{
		%client.LastAction = getSimTime();
	}
}
function Global::onAdd(%weapon, %this)
{
	// Plasmatic 11/7/2007 5:11AM
	// This may be overkill, but it's very accurate.
	//both("GLOBAL ON ADD... WEAPON: "@%weapon@" SW1"@$ScoreWeapon[%weapon]@" SW2"@$ScoreWeapon[$ScoreWeapon[%weapon]]);

	if($ScoreWeapon[$ScoreWeapon[%weapon]] != "")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(isPlayerBusy(%cl))
			{
				if(Player::getMountedItem(%cl,$WeaponSlot) == %weapon)
				{
					%player = Client::getOwnedObject(%cl);
					%trans = GameBase::getMuzzleTransform(%player);   //position of tip
					%posX = getWord(%trans,9);      //x
					%posY = getWord(%trans,10);      //y
					%posZ = getWord(%trans,11);       //z
					%GunTipPos = %posX@" "@%posY@" "@%posZ;
					if(vector::getdistance(%GunTipPos, gamebase::getposition(%this)) < 0.015)
					{
						%this.origin = gamebase::getposition(%this);
						%this.DamageType = $ScoreWeapon[%weapon];

						//%cl.score[GetPlayType(%cl), "shotsFired", $ScoreWeapon[%weapon]]++;
						%cl.ThisRoundTotalShotsFired++;
						Score::IncreaseStat(%cl, "shotsFired", 1, GetPlayType(%cl), $ScoreWeapon[%weapon]);
						//echo("playtype "@%playtype@" shot fired... "@%weapon@" "@$ScoreWeapon[%weapon]@" total: "@%cl.score[%playtype, "shotsFired", $ScoreWeapon[%weapon]]);
						Client::LastActionUpdate(%cl, "ShotFired");
						ProjectileFollow(%cl,%this);
						//schedule("k("@%this@");",0.0000001);
					}
				}
			}
		}
	}
}
function k(%this)
{
	$GlobalOriginVelocity[%this] = item::getvelocity(%this);
	$GlobalOrigin[%this] = gamebase::getposition(%this);
	$GlobalOriginTime[%this] = getSimTime();
	%speed = Vector::GetDistance("0 0 0", $GlobalOriginVelocity[%this]);
	//both(%this@": Time Created: "@$GlobalOriginTime[%this]@" SPEED: "@%speed@" velocity: "@item::getvelocity(%this)@" pos: "@gamebase::Getposition(%this));
	//schedule("k("@%this@");",0.5,%this);
}
function ChaingunBullet::onAdd(%this){	Global::onAdd(Chaingun, %this); }
function ChaingunBullet::onRemove(%this) { Global::onRemove(%this); }
function BlasterBolt::onAdd(%this) { Global::onAdd(Blaster, %this); }
function BlasterBolt::onRemove(%this) { Global::onRemove(%this); }
function PlasmaBolt::onAdd(%this) { Global::onAdd(PlasmaGun, %this); }
function PlasmaBolt::onRemove(%this) { Global::onRemove(%this); }
function GrenadeShell::onAdd(%this) { Global::onAdd(GrenadeLauncher, %this); }
function GrenadeShell::onRemove(%this) { Global::onRemove(%this); }
function DiscShell::onAdd(%this) { Global::onAdd(DiscLauncher, %this); }
function DiscShell::onRemove(%this) { Global::onRemove(%this); }
function KingShell::onAdd(%this) { Global::onAdd(DiscLauncherKing, %this); }
function KingShell::onRemove(%this) { Global::onRemove(%this); }
function DiscShell::onAdd(%this) { Global::onAdd(DiscLauncher, %this); }
function DiscShell::onRemove(%this) { Global::onRemove(%this); }
function BlueShell::onAdd(%this) { Global::onAdd(DiscLauncherBlue, %this); }
function BlueShell::onRemove(%this) { Global::onRemove(%this); }
function GreenShell::onAdd(%this) { Global::onAdd(DiscLauncherGreen, %this); }
function GreenShell::onRemove(%this) { Global::onRemove(%this); }
function YellowShell::onAdd(%this) { Global::onAdd(DiscLauncherYellow, %this); }
function YellowShell::onRemove(%this) { Global::onRemove(%this); }
function PinkShell::onAdd(%this) { Global::onAdd(DiscLauncherPink, %this); }
function PinkShell::onRemove(%this) { Global::onRemove(%this); }
function BlackShell::onAdd(%this) { Global::onAdd(DiscLauncherBlack, %this); }
function BlackShell::onRemove(%this) { Global::onRemove(%this); }
function PurpleShell::onAdd(%this) { Global::onAdd(DiscLauncherPurple, %this); }
function PurpleShell::onRemove(%this) { Global::onRemove(%this); }

function MortarShell::onAdd(%this) { Global::onAdd(Mortar, %this); }
function MortarShell::onRemove(%this) { Global::onRemove(%this); }
function SniperLaser::onAdd(%this) { Global::onAdd(LaserRifle, %this); }
function SniperLaser::onRemove(%this) { Global::onRemove(LaserRifle, %this); }

function Global::onRemove(%this)
{
	if($followed[%this])
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.follow[0] == %this)
			{
				ProjectileUnFollow(%cl);
			}
		}
		$followed[%this] = "";
	}
}
//if(%value+0.000001 >= $Score::MaxDamage[%type] && $Score::MidAirTracking[%type])// && Client::getOwnedObject(%object) != %this)
function Score::MidAirHit(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %damageType, %distance)
{
	//both("Score::MidAirHit("@%damagedClient@", "@%shooterClient@", "@%damagedPlayer@", "@%shooterPlayer@", "@%damageType@", "@%distance);
	%wav = "~wC_BuySell.wav";
	%extramsg = "";
	%corpsemsg = "";
	%PlayType = GetPlayType(%shooterClient);

	Score::IncreaseStat(%killerId, "scoreKills", 1, %PlayType, %damageType);

	Score::CompareStat(%shooterClient, "FurthestMidAir", %distance, %playType, %damageType);

	Score::IncreaseStat(%shooterClient, "MidAirs", 1, %PlayType, %damageType);
	Score::IncreaseStat(%damagedClient, "MidAirsCaught", 1, %PlayType, %damageType);

	if(Player::isDead(%shooterClient.owns) && (getSimTime()-%shooterClient.dieTime) > 0.5)
	{
		Score::IncreaseStat(%shooterClient, "CorpseMa", 1, %PlayType, %damageType);
		Score::IncreaseStat(%damagedClient, "CorpseMaTaken", 1, %PlayType, %damageType);
		%corpsemsg = " as a corpse";
	}
	if(Client::getTeam(%shooterClient) == Client::getTeam(%damagedClient) && %shooterClient.Team != "" && %damagedClient.Team != "" && !%damagedClient.DM && !%shooterClient.DM)
	{
		%extramsg = "teammate ";
	}
	client::sendmessage(%shooterClient, 0, %wav);
	%message = Client::GetName(%shooterClient) @ " mid-aired "@%extramsg@""@ Client::GetName(%damagedClient) @ " from " @ floor(%distance) @ " meters away with "@GetMidairWeap(%damageType) @ %corpsemsg @"!";
	if(%distance < 100)
	{
		if(%shooterClient.Team != "" && damagedClient.Team != "" && !%damagedClient.DM && !%shooterClient.DM)
		{
			TMessage(%shooterClient.Team, %damagedClient.Team, $White, %message);
		}
		else if(%shooterClient.DM && %damagedClient.DM)
		{
			DeathMatch::Message($White, %message);
		}
		else if($Dueling[%shooterClient] != "" && $Dueling[%damagedClient] != "")
		{
			bottomprint(%shooterClient, "<jc><f1>You mid-aired " @ Client::GetName(%damagedClient) @ " from<f2> " @ floor(%distance) @ " <f1>meters away! ", 5);
		}
	}
	else
	{
		messageall(0, %message);
		//remoteKingMe(%shooterClient,true);
	}
	%shooterClient.ThisRoundMidAirs[%damageType]++;
	%shooterClient.ThisRoundTotalMidAirs++;
	Score::CompareStat(%shooterClient, "MostMAsPerRound", %shooterClient.ThisRoundTotalMidAirs, %playType);
}
function remoteMAC(%cl)
{
	%player = Client::getOwnedObject(%cl);
	if(Player::getLastContactCount(%player) > 0)
	{
		both(gamebase::getlosinfo(%player,4,"-1.57 0 0"));
	}
}
function Score::MidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %damageType, %distance)
{
	echo("MidAir Check "@%damagedClient@", "@ %shooterClient@", "@ %damagedPlayer@", "@ %shooterPlayer@", "@ %damageType@", "@ %distance);
	if(Player::getLastContactCount(%damagedPlayer) > 0)
	{
		%ZDistance = 4;
		if(%damageType == 14 || %damageType == 5 || %damageType == 7)
			%ZDistance = 8;

		if(gamebase::getlosinfo(%damagedPlayer,%ZDistance,"-1.57 0 0") || gamebase::getlosinfo(%damagedPlayer,%ZDistance,"1.57 0 0"))
		{
			%type = getObjectType($los::object);
			if(%type == "SimTerrain" || %type == "InteriorShape" || %type == "StaticShape")
			{
				return false;
			}
		}
		else
		{
			return Score::MidAirHit(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %damageType, %distance);
		}
	}
	else
	{
		return false;
	}
	return Score::MidAirHit(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %damageType, %distance);
}
function Score::PreMidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %type, %value, %vertpos, %quadrant, %rawValue)
{
	//both("Val: "@%value@", RawValue: "@%rawvalue);
	%PlayType = GetPlayType(%shooterClient);
	%dif = gw(GameBase::getRotation(%damagedClient),2) - gw(GameBase::getRotation(%shooterClient),2);

	if((%quadrant == "back_left" || %quadrant == "back_right") && (%dif >= -1.5 && %dif <= 1.5 || %dif > 5.3))
	{
		Score::IncreaseStat(%shooterClient, "BackStab", 1, %PlayType, %type);
		Score::IncreaseStat(%damagedClient, "BackStabbed", 1, %PlayType, %type);
	}

	if(%type == $ScoreWeapon[PlasmaGun] || %type == $ScoreWeapon[GrenadeLauncher] || %type == $ScoreWeapon[HandGrenade] || %type == $ScoreWeapon[MortarGun])
	{
		if(%value+0.000001 >= $Score::MaxDamage[%type] || %rawValue+0.000001 >= $Score::MaxDamage[%type])
		{

			if(%type == $ScoreWeapon[HandGrenade])
			{
				//%distance = vector::getdistance(gamebase::Getposition(%this), %this.originPos);
				if(%shooterClient.HandNadeLog[getsimtime()] != "")
				{
					//both("HN Full dmg and has a log, checking for midair");
					if(!Score::MidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %type, %shooterClient.HandNadeLog[getsimtime()]))
					{
						Score::IncreaseStat(%shooterClient, "DirectHits", 1, %PlayType, %type);
						Score::IncreaseStat(%damagedClient, "DirectHitsTaken", 1, %PlayType, %type);
					}
				}

				//%distance = %shooterClient.HandNadeLog[getsimtime()];
				//both(getsimtime()@" "@%shooterClient@" found hn, setting distance "@%shooterClient.HandNadeLog[getsimtime()]);
			}
			else
			{
				//both("midairCheck for splash");
				%distance = vector::getdistance(gamebase::getposition(%shooterPlayer), gamebase::Getposition(%damagedPlayer));
				if(!Score::MidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %type, %distance))
				{
					Score::IncreaseStat(%shooterClient, "DirectHits", 1, %PlayType, %type);
					Score::IncreaseStat(%damagedClient, "DirectHitsTaken", 1, %PlayType, %type);
				}
			}
		}
	}
	if(%type == $ScoreWeapon[Chaingun] || %type == $ScoreWeapon[Blaster] || %type == $ScoreWeapon[LaserRifle])
	{
		//both("midairCheck for direct");
		%distance = vector::getdistance(gamebase::getposition(%shooterPlayer), gamebase::Getposition(%damagedPlayer));
		Score::MidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %type, %distance);
	}
}
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	//both("DAMAGE TIME: "@getsimtime());
	//quadrantlist(%vertPos,%quadrant);
	//BOTH("dmg "@%value@" this: "@%this@" obj: "@%object@" "@getObjectType(%object)@" type "@%type@" pos: "@%pos@" q "@%quadrant@" obj: "@%object);

	//resetlos();
	//gamebase::getlosinfo(%this,10,"-1.57 0 0");
	//both(getObjectType($los::object));

  %rawValue = %value;
  %damagedClient = Player::getClient(%this);
  %shooterClient = %object;
  %damagedPlayer = %this;
  %shooterPlayer = Client::getOwnedObject(%object);
  if(%this.isduck)	{	return BCPlayer::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object);	}


//echo(%value);

	%dmg = floor(100 - (gamebase::getdamagelevel(%this) / 0.66) * 100) ;
	%dmg2 = 100 - floor(100 - (%value / 0.66) * 100) ;

	if(%type == "0" && %dmg2 < 17 && %dmg < 17 && %dmg2*1.5 > %dmg)
	{
		%value = %value/2;
		return;
	}

	if(CanDamage(%shooterClient, %damagedClient, %this, %type))
	{
		//Score::MidAirCheck(%damagedClient, %shooterClient, %damageType, %value, %damagedPlayer, %shooterPlayer);
		//Score::MidAirHit(%owner, %clOwner, %target, %clTarget, %this.DamageType, %distance);
		//Score::Update::OnDamageStats(%damagedClient, %shooterClient, %damageType, %value, %damagedPlayer, %shooterPlayer, %vertPos);

		Player::applyImpulse(%this,%mom);
		if(%damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) && %shooterClient.team != "" && %damagedClient.team != "" && %damagedClient.dm != "true" && %shooterClient.dm != "true" || $DeathMatch::Teams && shooterClient.dm && %damagedClient.dm && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient)) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient) {
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

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor") {
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $HandGrenadeDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%absorbed = %value;
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
					%absorbed = %absorb;
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;

				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,(%flash/%damagedClient.prefs["flash"]));

//was here
				if(%type > 0 && %damagedPlayer != %shooterPlayer)
				{
					Score::PreMidAirCheck(%damagedClient, %shooterClient, %damagedPlayer, %shooterClient.owns, %type, %value, %vertpos, %quadrant, %rawValue);
				}

				if(%spillOver > 0)
				{
					%newvalue = %value-%spillover ;
				}
				else {
					%newvalue = %value;
				}



				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) {
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type == $HandGrenadeDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{

						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $HandGrenadeDamageType)) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) )
							%curDie = $PlayerAnim::Crouching;
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	)
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
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
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
		//else both(here2);
		Score::Update::OnDamageStats(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %type, %value, %newvalue, %vertPos, %spillOver, %absorbed);
	}
	//else both(here3);
}




function remoteLOS(%cl)
{
	%player = Client::getOwnedObject(%cl);
	both("LOS: "@gamebase::getlosinfo(%player,4,"-1.57 0 0"));
}

//this = projectile
function RocketDumb::onCollision(%this, %owner, %clOwner, %target, %time)
{
	%clTarget = Player::getClient(%target);
	if(CanDamage(%clOwner, %clTarget))
	{
		%objType = GetObjectType(%target);

		//both("target obj type: "@getobjectType(%target)@" getname: "@object::getname(%target)@" dataName: "@GameBase::getDataName(%target)@" LeCustom Type: "@%this.DamageType);
		//both("target: "@%target@" target owner: "@Player::getClient(%target));
		//both("owner: "@%owner@" owner owner: "@Player::getClient(%owner));

		if(%objType == "Player" && %this.DamageType == 4)
		{
			//definitely a midair
			%speed = vector::getdistance("0 0 0", item::getvelocity(%this))/1000;
			%distance = %time * %speed;
			%distance = %distance + (%distance * 0.01);

			%playType = GetPlayType(%clOwner);

			Score::IncreaseStat(%clOwner, "DirectHits", 1, %PlayType, %this.DamageType);
			Score::IncreaseStat(%clTarget, "DirectHitsTaken", 1, %PlayType, %this.DamageType);
			if(Player::getLastContactCount(%target) > 0 && !gamebase::getlosinfo(%target,4,"-1.57 0 0"))
			{
				Score::MidAirHit(%clTarget, %clOwner, %target, %owner, %this.DamageType, %distance);
			}
			//Score::MidAirHit(%damagedClient, %shooterClient, %damagedPlayer, %shooterPlayer, %this.damageType, %distance)
		}
		else if (GetObjectType(%target) == "Mine")
		{
			if (!Player::ObstructionsBelow(%owner, $Game::Midair::Height))
			{
				// Determine if it is a NJ after OnDamage by comparing getSimTime()
				// The impulse has been applied and we get player speed accurately.
				%clOwner.lastNadeCollisionTime = getSimTime();
				//MessageAll(0, "rocketdumb set lnct == " @ %clOwner.lastNadeCollisionTime);
			}
		}
	}
}
// 1.50 PORT: was Attachment::AddBefore("Mine::Detonate", "Before::Detonate").
// Native equivalent -- see the note in TDNewScores.cs.
function Before::Detonate(%this) before Mine::Detonate
{
	//%this.Detonated = true;
	if(GameBase::getDataName(%this) == "Handgrenade")
	{
		%distance = vector::getdistance(gamebase::Getposition(%this), %this.originPos);
		%this.owner.HandNadeLog[getsimtime()] = %distance;
	}
	//both("this obj type: "@getobjectType(%this)@" getname: "@object::getname(%this)@" dataName: "@GameBase::getDataName(%this));
	//both("BEFORE DET "@GameBase::getDataName(%this)@" "@getsimtime()@" distance: "@%distance);
}
function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Handgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//BOTH("XXX "@%value@" this: "@%this@" obj: "@%object@" "@getObjectType(%object)@" type "@%type@" pos: "@%pos@" q "@%quadrant@" obj: "@%object);
	//echo("HG!! "@%this@", "@%type@" "@%value@" OBJECT: "@%object);
	//both(gamebase::Getposition(%this)@" origin... "@%this.originPos);
	//both("time.. "@getSimTime());
	//%distance = vector::getdistance(gamebase::Getposition(%this), %this.originPos);
	//%this.owner.HandNadeLog[getsimtime()] = %distance;
	//both("det? "@%this.Detonated);


	//if(%this.owner.HandNadeLog[getsimtime()] && %this.Detonated)
	//{
	//	%distance = vector::getdistance(gamebase::Getposition(%this), %this.originPos);
	//	%this.owner.HandNadeLogDistance[getsimtime()] = %distance;
	//	Score::MidAirCheck(%damagedClient, %this.owner, %damagedPlayer, %shooterPlayer, %type, %distance);
	//	both("Uhhh "@getsimtime()@" "@%this.owner@" "@%distance@" "@%this.owner.HandNadeLog[getsimtime()]);
	//}
}

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			//Player::setAnimation(%player,21);
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			%playtype = GetPlayType(%client);
			%obj.owner = %client;
			//%client.score[%playtype, "shotsFired", 7]++;
			Score::IncreaseStat(%client, "shotsFired", 1, %playtype, $HandGrenadeDamageType);
			%client.ThisRoundTotalShotsFired++;
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			%obj.originPos = gamebase::getposition(%obj);
		}
	}
}




function UpDateObservers(%client,%value, %distance)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerTarget == %client && !%cl.dm && %cl.isAlive != "True")
		{
			//both("updating "@client::Getname(%cl)@" "@%msg);
			%extramsg = "";
			if(%cl.Team != "" && %client.Team != "" && %cl.Team == %client.Team)
			{
				%extramsg = "<F1>";
			}
			if(%cl.Team != "" && %client.Team != "" && %cl.Team != %client.Team  && $TeamDuel::Challenging[%cl.Team] == %client.Team)
			{
				%extramsg = "<F0>";
			}
			%msg = "";
			//	both("msg... "@%msg);
			if(%client.team != "" && %client.isalive == "True")
			{
				//both("msg... "@%msg@" hits... "@%client.ThisRoundTotalHitsDone);
				if(%client.ThisRoundTotalHitsDone > 0)
				{
					%msg = " \n<F2>Hits:<F3> "@%client.ThisRoundTotalHitsDone@" <F2>Damage: <F3>"@MyRound(%client.ThisRoundTotalDamageDone, 3)@"<F1> (+"@MyRound(%value, 2)@" Distance: "@%distance@")";
					//both("msg... "@%msg);
					if(%client.ThisRoundTotalMidAirs > 0)
					{
						%msg = %msg@" <F3>Midairs: <F1>"@%client.ThisRoundTotalMidAirs;
					}
				}
			}
			bottomprint(%cl, "<jc><F2>Observing "@%extramsg@"" @ Client::getName(%client) @ "."@%msg, 5);
		}
	}
}
function ProjectileFollow(%shooterclient, %this)
{
	//echo("follow");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observertarget == %shooterclient && %cl.prefs["SuperCam"])
		{
			$followed[%this] = true;
			if(%cl.follow[0] != "")
			{
				for(%x = 0; %x < 10; %x++)
				{
					if(%cl.follow[%x] == "")
					{
						%cl.follow[%x] = %this;
						echo("Added projectile "@%this@" to queue: "@%x);
						break;
					}
				}
			}
			else
			{
				%cl.follow[0] = %this;
				%camera = Client::getObserverCamera(%cl);
				Client::setControlObject(%cl, %camera);
				Observer::setOrbitObject(%cl, %this,10,-1,50,true);
				//schedule("Client::setControlObject("@%cl@", "@%cl.observertarget@");",7,isobject(%this));
			}
		}
	}
}
function ProjectileUnFollow(%cl)
{
	if(%cl.follow[1] != "")
	{
		for(%x = 0; %cl.follow[%x] != ""; %x++)
		{
			%cl.follow[%x] = %cl.follow[%x+1];
		}
		%camera = Client::getObserverCamera(%cl);
		Client::setControlObject(%cl, %camera);
		Observer::setOrbitObject(%cl, %cl.follow[0],10,-1,50,true);
		echo("unfollowing... "@%x@" obj total next one set");
	}
	else
	{
		%cl.follow[0] = "";
		setObsOrbit(%cl, %cl.observertarget);
		echo("unfollowing... only one projectile");
	}
		//Client::setControlObject("@%source@", "@%source.ownt@");

}