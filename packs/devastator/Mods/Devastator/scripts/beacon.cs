

StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

function Beacon::onEnabled(%this)
{
	GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
	GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
	GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
	if(Beacon::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function Beacon::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($SinglePlayer) {
		CycleWeapModes::Training(%player);
		return;
	}
	if(GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		echo(GameBase::getDataName($los::object).className@", "@%obj@", "@%player@", "@AreGod(%player));
		if(%obj == "SimTerrain" || %obj == "InteriorShape") {
			if(Vector::dot($los::normal,"0 0 1") > 0.6)
				%rot = "0 0 0";
			else {
				if(Vector::dot($los::normal,"0 0 -1") > 0.6)
					%rot = "3.14159 0 0";
				else
					%rot = Vector::getRotation($los::normal);
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
					addToSet("MissionCleanup", %beacon);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
					Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else if(GameBase::getDataName($los::object).className == "Station" && AreGod(%player) != false && AreGod(%player) != Demi && AreGod(%player) != perfect) {
			%UltraName = Client::getName(%Client);
			Player::setItemCount(%player,UltraPack,1);
			Player::setItemCount(%player,Player::getMountedItem(%player,$BackpackSlot),0);
			Player::mountItem(%player,UltraPack,$BackpackSlot);
			messageAll(0,"Everyone bow before the Super GOD, "@%UltraName@".~explo3.wav");
		}
		else if(GameBase::getDataName($los::object) == "Beacon" && AreGod(%player) != false) {
			%client = Player::getClient(%player);
			%client.pissed = true;
		}
		else if(%obj == "Player" && AreGod(%player) != false && AreGod(%player) != Demi)
			GodPower::BowToGod(%player,$los::object);
		else
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
	}
	else if(GameBase::getLOSInfo(%player,2000)) { // && getObjectType($los::object) == "Player") {
		%obj = getObjectType($los::object);
		if(AreGod(%player) == Perfect &&(IsIce(%client)||$IcePermission[%client] == true)) { //&&(Player::isCrouching(%player)) {
			%player.tempBeam++;
			if(%player.tempBeam >= 2)
				GodPower::SuperBlastBeam(%player,$los::object);
		}
		else
			%player.tempBeam = 0;
	}
	else if(AreGod(%player) == ULTRA || AreGod(%player) == PERFECT) {
		%player.tempWarp++;
		if(%player.tempWarp >= 5) {
			GodPower::WarpBack(%player,"spawn");
			return;
		}
	}
	else
		Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

function GodPower::WarpBack(%this,%where)
{
	%this.tempWarp = 0;
	%client = Player::getClient(%this);
	if(%where == "flag")
		%Pos = $teamFlag[GameBase::getTeam(%client)].originalPosition;
	else if(%where == "spawn")
		%Pos = Game::pickPlayerSpawn(%client,true);
	GameBase::startFadeOut(%client);
	Item::setVelocity(%this,"0 0 0");
	GameBase::setPosition(%client,GameBase::getPosition(%Pos));
	GameBase::startFadeIn(%client);
}

function GodPower::BowToGod(%GOD,%Victim)
{
	%Client = Player::getClient(%GOD);
	%Vlient = Player::getClient(%Victim);
	if(AreGOD(%Vlient) == PERFECT) {
		Player::killOff(%Client,%Vlient,$GODDamageType,"BlowUp");
		return;
	}
	if(IsIce(%Vlient) == true) {
		centerprint(%client,"<jc><f2>Ice Bows to no one!",3);
		return;
	}
	if(%Vlient.Bowing == 1)
		return;
	%rot = GameBase::getRotation(%Client);
	$Reloading[%Vlient] = 1;
	%Vlient.Bowing = 1;
	Client::sendMessage(%Vlient,0,"Bow Before Your God");
	GameBase::setRotation(%Victim,%Rot);
	GameBase::setRotation(%Victim,Vector::getRotAim(GameBase::getPosition(%Victim),GameBase::getPosition(%GOD)));
	Player::setAnimation(%Victim,48);
	Player::setAnimation(%GOD,49);
	playVoice(%Vlient,yes);
	schedule("GodPower::BootEm("@%Victim@","@%GOD@");",2.5,%Victim);
}

function GodPower::BootEm(%this,%object)
{
	%Client = Player::getClient(%object);
	%anim = "BlowUp";
	GameBase::setRotation(%this,GameBase::getRotation(%object));
	playVoice(Player::getClient(%object),bye);
	schedule("GodPower::Punt("@%this@","@%object@");",1.0,%this);
	schedule("Player::killOff("@%this@","@%Client@","@$GodBootDamageType@","@%anim@");",2.5,%this);
}

function GodPower::Punt(%this,%object)
{
	if(AreGod(%object) == False)
		return;
	if((AreGod(Player::getClient(%object)) != Ultra && IsIce(Player::getClient(%object) != true))&& AreGod(Player::getClient(%this)) == Ultra) //-God Ranking Wins
		return;
	if(IsIce(Player::getClient(%this))) {
		centerprint(Player::getClient(%object),"<jc><f2>Ice Bows to no one!",3);
		return;
	}
	Player::getClient(%this).bowing = 0;
	%rot = GameBase::getRotation(Player::getClient(%object));
	%vec = Vector::getFromRot(%rot,500,500);
	if(AreGod(%object) == Ultra)
		%vec = Vector::getFromRot(%rot,1500,1500);
	else if(AreGod(%object) == Perfect)
		%vec = Vector::getFromRot(%rot,3000,3000);
	GameBase::playSound(%obj,SoundThrowItem,4);
	Player::applyImpulse(%this,%vec);
}

LaserData SuperBeamLaser
{
	laserBitmapName   = "wes05.bmp";
	hitName           = "shield.dts";

	damageConversion  = 1.5;
	baseDamageType    = $LPDamageType;

	beamTime          = 20.5;

	lightRange        = 2.0;
	lightColor        = { 0.0, 0.0, 1.25 };

	detachFromShooter = false;
	hitSoundId        = SoundBeam;
};

ItemImageData SLazerImage
{
	shapeFile = "enex";
	mountPoint = 0; 
	weaponType = 0; // Single Shot
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	reloadTime = 0.001;
	fireTime = 0.001;
	projectileType = SuperBeamLaser;
};

ItemData SLazer
{
	description = "SBB";
	className = "Weapon";
	shapeFile = "enex";
	shadowDetailMask = 4;
	imageType = SLazerImage;
	showWeaponBar = false;
};

ItemImageData SLazer1Image
{
	shapeFile = "fusionbolt";
	mountPoint = 0; 
	weaponType = 0; // Single Shot
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	reloadTime = 0.001;
	fireTime = 0.001;
	projectileType = SuperBeamLaser;
};

ItemData SLazer1
{
	description = "SBB1";
	className = "Weapon";
	shapeFile = "fusionbolt";
	shadowDetailMask = 4;
	imageType = SLazer1Image;
	showWeaponBar = false;
};

ItemImageData SLazer2Image
{
	shapeFile = "paint";
	mountPoint = 0; 
	weaponType = 0; // Single Shot
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	reloadTime = 0.001;
	fireTime = 0.001;
	projectileType = SuperBeamLaser;
};

ItemData SLazer2
{
	description = "SBB2";
	className = "Weapon";
	shapeFile = "paint";
	shadowDetailMask = 4;
	imageType = SLazer2Image;
	showWeaponBar = false;
};

ItemImageData SLazer3Image
{
	shapeFile = "Shotgunex";
	mountPoint = 0; 
	weaponType = 0; // Single Shot
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	reloadTime = 0.001;
	fireTime = 0.001;
	projectileType = SuperBeamLaser;
};

ItemData SLazer3
{
	description = "SBB3";
	className = "Weapon";
	shapeFile = "Shotgunex";
	shadowDetailMask = 4;
	imageType = SLazer3Image;
	showWeaponBar = false;
};

function GodPower::SuperBlastBeam(%player,%target)
{
	%player.tempBeam = 0;
	%client = Player::getClient(%player);
	Player::unmountItem(%player,$WeaponSlot);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::mountItem(%player,SLazer,0);
	Player::mountItem(%player,SLazer1,4);
	Player::mountItem(%player,SLazer2,5);
	Player::mountItem(%player,SLazer3,6);
	Player::trigger(%player,0,true);
	Player::trigger(%player,4,true);
	Player::trigger(%player,5,true);
	Player::trigger(%player,6,true);
	schedule("GodPower::SuperBlastBeamEnd("@%player@");",0.5,%player);
}

function GodPower::SuperBlastBeamEnd(%player)
{
	Player::trigger(%player,0,false);
	Player::trigger(%player,4,false);
	Player::trigger(%player,5,false);
	Player::trigger(%player,6,false);
	Player::unmountItem(%player,0);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}

function CycleWeapModes::Training(%this)
{
	%client = Player::getClient(%this);
	if($SinglePlayer) {
		%CurWeap = Player::getMountedItem(%this,$WeaponSlot);
		if($WeapMode[%client,%CurWeap] == "")
			$WeapMode[%client,%CurWeap] = 1;
		if($FireModes[%CurWeap] && %CurWeap != -1 && %CurWeap != "") {
			$WeapMode[%client,%CurWeap]++;
			if($WeapMode[%client,%CurWeap] > $FireModes[%CurWeap])
				$WeapMode[%client,%CurWeap] = 1;
			topprint(%client,"<jc>"@$WeapMountMSG[%CurWeap,$WeapMode[%client,%CurWeap]],3);
		}
	}
	else
		echo("Did not pass second Single Player test");
}

function SetPissed(%this)
{
	if(AreGod(%this) == False || AreGod(%this) == "")
		return;
	else
		%this.pissed++;
	if(%this.pissed >= 3)
		%this.pissedoff = 1;
	echo(%this.pissed@" "@%this.pissedoff);
}
