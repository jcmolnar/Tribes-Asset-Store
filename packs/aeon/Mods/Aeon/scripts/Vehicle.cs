//----------------------------------------------------------------------------
$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;

$DamageScale[Razor, $ImpactDamageType] = 1.0;
$DamageScale[Razor, $BulletDamageType] = 1.0;
$DamageScale[Razor, $PlasmaDamageType] = 1.0;
$DamageScale[Razor, $EnergyDamageType] = 1.0;
$DamageScale[Razor, $ExplosionDamageType] = 1.0;
$DamageScale[Razor, $ShrapnelDamageType] = 1.0;
$DamageScale[Razor, $DebrisDamageType] = 1.0;
$DamageScale[Razor, $MissileDamageType] = 1.0;
$DamageScale[Razor, $LaserDamageType] = 1.0;
$DamageScale[Razor, $MortarDamageType] = 1.0;
$DamageScale[Razor, $BlasterDamageType] = 0.5;
$DamageScale[Razor, $ElectricityDamageType] = 1.0;
$DamageScale[Razor, $MineDamageType]        = 1.0;

//----------------------------------------------------------------------------

$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;
$DataBlockName[RazorVehicle] = Razor;

$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;
$VehicleToItem[Razor] = RazorVehicle;

$VehicleSeats[Scout] = 1;
$VehicleSeats[LAPC] = 3;
$VehicleSeats[HAPC] = 5;
$VehicleSeats[Razor] = 1;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate(%this,10);
	GameBase::setTeam(%this,0);
	if(GameBase::getMapName(%this) == "" || GameBase::getMapName(%this) == -1 || GameBase::getMapName(%this) == false)
		GameBase::setMapName(%this,$CatalogName[$VehicleToItem[GameBase::getDataName(%this)]]);
	schedule("Vehicle::checkOwner("@%this@");",2,%this);
}

function Vehicle::checkOwner(%this)
{
	%owner = %this.owner;
	%ownId = %this.ownId;
	%owNum = %this.owndNum;
	if((GameBase::getTeam(%owner) != 0 && %owner.observerMode != "observe") || Aeon::getAeonID(%owner) != %ownId) {
		Vehicle::Dismount(%this,"0 0 0");
		Item::setVelocity(%this,"0 0 0");
		deleteObject(%this);
		return;
	}
	%item = $VehicleToItem[GameBase::getDataName(%this)];
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"pos"] = GameBase::getPosition(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"rot"] = GameBase::getRotation(%this);
	$Aeon::ClientInfo[%ownId,"Ownd",%item@" "@%owNum,"dmg"] = GameBase::getDamageLevel(%this);
	Aeon::ownedInv(%owner,%item,%owNum);
	%next = 10;
	if(Item::getVelocity(%owner) == "0 0 0")
		%next = 5;
	schedule("Vehicle::checkOwner("@%this@");",%next,%this);
}

function Vehicle::onCollision(%this,%object)
{
	if(%this == -1 || %object == -1)
		return;
	%data = GameBase::getDataName(%this);
	if(GameBase::getDamageLevel(%this) < %data.maxDamage) {
		if(getObjectType(%object) == "Player" && %object.vehicle == "") {
			%client = Player::getClient(%object);
			if(Player::isAiControlled(%object))
				return;
			if(%this.hotWiring != %object && %this.hotWiring != "")
				return;
			if(%object.lastMount == %this && getSimTime() < %object.newMountTime)
				return;
			if(Vehicle::hasKey(%client,%this)) {
				if(Vehicle::canMount(%this,%object)) {
					%weapon = Player::getMountedItem(%object,$WeaponSlot);
					if(%weapon != -1) {
						%object.lastWeapon = %weapon;
						Player::unMountItem(%object,$WeaponSlot);
					}
					Player::setMountObject(%object,%this,1);
					Client::setControlObject(%client,%this);
					playSound(%data.mountSound,GameBase::getPosition(%this));
					%object.driver = 1;
					%object.vehicle = %this;
					%this.clLastMount = %client;
				}
			}
			else if($VehicleSeats[GameBase::getDataName(%this)] > 1) {
				%mountSlot= Vehicle::findEmptySeat(%this,%client);
				if(%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object,%this,%mountSlot);
					playSound(%data.mountSound,GameBase::getPosition(%this));
				}
			}
		}
	}
}

function Vehicle::hasKey(%clientId,%veh)
{
	if(%clientId.hasKey[%veh])
		return true;
	return false;
}

function Vehicle::findEmptySeat(%this,%client)
{
	%data = GameBase::getDataName(%this);
	%numSlots = $VehicleSeats[%data];
	if(%numSlots < 1)
		%numSlots = $VehicleSeats[%data] = 1;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if(%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	%posZ = getWord(%pos,2);
	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player") {
			if(!GameBase::getLOSInfo(%this,3,$Pi/2@" 0 0")) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 		Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 		Client::setControlObject(%cl, %pl);
				playSound(GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
				}
				%pl.driver = "";
				%pl.vehicle = "";
				//Aeon::ExportInfo(%cl);
				Aeon::ownedInv(%obj.ownId,$VehicleToItem[GameBase::getDataName(%this)],true);
				//Aeon::getInventory(%obj.owner,true);
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}

function Vehicle::onDestroyed(%this,%mom)
{
	%data = GameBase::getDataName(%this);
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
		Player::setMountObject(%pl, -1, 0);
   		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle= "";
	}
	for(%i = 0; %i < 4; %i++) {
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
			Player::setMountObject(%pl, -1, 0);
			Client::setControlObject(%this.Seat[%i],%pl);
			%pl.vehicleSlot = "";
			%pl.vehicle = "";
		}
	}
	calcRadiusDamage(%this,$DebrisDamageType,2.5,0.05,25,13,2,0.55,0.1,225,100); 
	%killer = %this.lastDamageObject;
	%owner = %this.owner;
	if(%killer != %owner) {
		%killerId = Aeon::getAeonId(%killer);
		Karma::result(%killerId,"kill "@%data);
		Aeon::ExportInfo(%killer);
	}
	%id = Aeon::getAeonID(%owner);
	%owndNum = %this.owndNum;
	%item = $VehicleToItem[%data];
	%title = %item@" "@%owndNum;
	$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"pos\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"pos"] = "";
	$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"rot\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"rot"] = "";
	$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"nam\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"nam"] = "";
	$Aeon::ClientInfo["[\""@%id@"\",\"Ownd\",\""@%title@"\",\"dmg\"]"] = $Aeon::ClientInfo[%id,"Ownd",%title,"dmg"] = "";
	$Aeon::ClientInfo[%id,ownd,%title] = "";
	Aeon::ExportInfo(%owner);
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	if($damageScale[%data,%type])
		%value *= $damageScale[%data,%type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	return 1.0;
}

function Razor::onAdd(%this)
{
	Razor::loop(%this);
	Vehicle::onAdd(%this);
}

function Razor::onFire(%this)
{
	//if(%this.lastFireTime + 0.25 > getSimTime())
		return;
	%weap = $Razor[%this,FX1];
	%weapData = GameBase::getDataName(%weap);
	%pos = GameBase::getPosition(%weap);
	%rot = GameBase::getRotation(%weap);
	%vec = Vector::getFromRot(%rot,5000);
	%vel = Item::getVelocity(%this);
	Item::setVelocity(%this,Vector::add(%vel,%vel));
	playSound(SoundSpinUpDisc,GameBase::getPosition(%this));
	%this.lastFireTime = getSimTime();
}

function Razor::WeaponNext(%client,%veh)
{
}

function Razor::WeaponPrev(%client,%veh)
{
}

$RazorUpdateRate = 0.01;
$RazorGroundFloat = 2.1;
$RazorFallRate = -0.003;
$RazorDimWidth = 1;
$RazorDimLength = 6;
$FX1Rad = 7;

function Razor::loop(%this,%int)
{
	Razor::Update(%this);
	schedule("Razor::loop("@%this@");",$RazorUpdateRate,%this);
}

function Razor::Update(%this)
{
	%rot = GameBase::getRotation(%this);
	%cntr = getBoxCenter(%this);
	%pntFM = Vector::add(%cntr,Vector::getFromRot(%rot,$RazorDimLength/2));
	%pntBM = Vector::add(%cntr,Vector::getFromRot(%rot,$RazorDimLength/-2));
	%down = Vector::sub(%cntr,"0 0 "@$RazorGroundFloat+1.0);
	%down1 = Vector::sub(%pntFM,"0 0 "@$RazorGroundFloat+1.0);
	%down2 = Vector::sub(%pntBM,"0 0 "@$RazorGroundFloat+1.0);
	
	%GrndFM = "";
	%GrndBM = "";
	$LOS::Position = "";
	if(getLOSInfo(%pntFM,%down1,1))
		%GrndFM = $LOS::Position;
	$LOS::Position = "";
	if(getLOSInfo(%pntBM,%down2,1))
		%GrndBM = $LOS::Position;
	$LOS::Position = "";
	if(getLOSInfo(%cntr,%down,1))
		%Grnd = $LOS::Position;
	if(%GrndFM != "" && %GrndBM != "") {
		%newNorm = Vector::getRotAim(%GrndBM,%GrndFM);
		%rot = GameBase::getRotation(%this);
		%newRot = getWord(%newNorm,0)@" "@getWord(%rot,1)@" "@getWord(%rot,2);
		GameBase::setRotation(%this,%newRot);
	}
	%pos = GameBase::getPosition(%this);
	if((getWord(%pos,2) - getWord(%Grnd,2)) > $RazorGroundFloat+1.0) {
		$Razor[%this,fallRate] += $RazorFallRate;
		%newPos = getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%pos,2)+$Razor[%this,fallRate];
		GameBase::setPosition(%this,%newPos);		
		//%vel = Item::getVelocity(%this);
		//%newVel = Vector::add(%vel,"0 0 "@$RazorFallRate);
		//Item::setVelocity(%this,%newVel);
	}
	else {
		$Razor[%this,fallRate] = 0;
		%newPos = getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%Grnd,2)+$RazorGroundFloat;
		GameBase::setPosition(%this,%newPos);
	}
}

function Razor::getHeatFactor(%this)
{
	return 0.0;
}

function Razor::onSell(%this)
{
	echo(%this);
}