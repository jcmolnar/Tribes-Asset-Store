// - = - = - = - = - = - = - = - = - = - = - = - \\
//      U l t r a  R e n e g a d e s  V X E      \\
// - = - = - = - = - = - = - = - = - = - = - = - \\
//Mine.cs


//$BrakeSpeed[larmor] = -0.1;
//$BrakeSpeed[lfemale] = -0.1;
//$BrakeSpeed[marmor] = -0.1;
//$BrakeSpeed[mfemale] = -0.1;
//$BrakeSpeed[harmor] = -0.1;

//$BoostSpeed[larmor] = 3.15;
//$BoostSpeed[lfemale] = 3.15;
//$BoostSpeed[mfemale] = 2.2;
//$BoostSpeed[marmor] = 2.2;
//$BoostSpeed[harmor] = 1.7;

$SpeedMax[larmor] = 300;
$SpeedMax[lfemale] = 300;
$SpeedMax[mfemale] = 220;
$SpeedMax[marmor] = 220;
$SpeedMax[harmor] = 195;


//Settings for the VXU Boost/Brake speeds
  $VXU::BrakeSpeed = -0.1;
  $VXU::BrakeSpeed[larmor] = $VXU::BrakeSpeed;
  $VXU::BrakeSpeed[lfemale] = $VXU::BrakeSpeed;
  $VXU::BrakeSpeed[marmor] = $VXU::BrakeSpeed;
  $VXU::BrakeSpeed[mfemale] = $VXU::BrakeSpeed;
  $VXU::BrakeSpeed[harmor] = $VXU::BrakeSpeed;

  $VXU::BoostSpeed[larmor] = 3.15;
  $VXU::BoostSpeed[lfemale] = 3.15;
  $VXU::BoostSpeed[mfemale] = 2.2;
  $VXU::BoostSpeed[marmor] = 2.2;
  $VXU::BoostSpeed[harmor] = 1.7;


//Settings for the VX5 Boost/Brake speeds
  $VX5::BrakeSpeed[larmor] = (1 / 6);
  $VX5::BrakeSpeed[lfemale] = (1 / 6);
  $VX5::BrakeSpeed[marmor] = (1 / 4.4);
  $VX5::BrakeSpeed[mfemale] = (1 / 4.4);
  $VX5::BrakeSpeed[harmor] = (1 / 3.4);


//Settings for the VXO Boost/Brake speeds
  $VXO::BrakeSpeed = 0;
  $VXO::BrakeSpeed[larmor] = $VXO::BrakeSpeed;
  $VXO::BrakeSpeed[lfemale] = $VXO::BrakeSpeed;
  $VXO::BrakeSpeed[marmor] = $VXO::BrakeSpeed;
  $VXO::BrakeSpeed[mfemale] = $VXO::BrakeSpeed;
  $VXO::BrakeSpeed[harmor] = $VXO::BrakeSpeed;

  //Uses the VXU settings
//  $VXO::BoostSpeed[larmor] = 3.00;
//  $VXO::BoostSpeed[lfemale] = 3.00;
//  $VXO::BoostSpeed[mfemale] = 2.2;
//  $VXO::BoostSpeed[marmor] = 2.2;
//  $VXO::BoostSpeed[harmor] = 1.7;


MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 3;
	damageValue = 0.9;
	damageType = $EMPDamageType;
	kickBackStrength = 350;
	triggerRadius = 2;
	maxDamage = 2;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
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
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//----------------------------------------------------------------------------
//           VXU//VXO//VX5 Boost/Brake code

MineData VX5Boost
{
	className = "Handgrenade";
   description = "Beacon";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 900; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	//shadowDetailMask = 0;
	//destroyDamage = 1.0;
	//damageLevel = {1.0, 1.0};
};

function VX5Boost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
  GameBase::setDamageLevel(%this,2);
}

MineData Boost
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 0; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

//-------------------

function SpeedCompare(%var1,%var2) {
  if(%var1 < 0) { if(%var1 > %var2) { return 2; } else { return 1; }
  } else { if(%var1 < %var2) { return 2; } else { return 1; } }
}

//-------------------

function Boost::UpdateVel(%player,%BPercentage,%msg) {

  %client = Player::getClient(%player);
  %obj = newObject("","Mine","Boost");
  addToSet("MissionCleanup", %obj);
  GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
  %player.throwTime = getSimTime() + 0.2;

  %armor = Player::getArmor(%player);

  %dir = Item::getVelocity(%player);
  %X = getWord(%dir,0);
  %Y = getWord(%dir,1);
  %Z = getWord(%dir,2);

  %var = %X;
  %MSpeed = $SpeedMax[%armor];
  if (%var < 0) { %var *= -1; } else { %var *= 1; }
  %num = (%MSpeed - %var);
  %VelRatio = %num/%MSpeed;

  %this = (%BPercentage * %VelRatio);

  //Fix: Prevent the "Boost Lag" many people complain about in the VXU/VXO mod(s)
  if ( SpeedCompare(%X, (%X * %this)) == 1 && %X != 0 ) {
    %Xset = %X;
    %Yset = %Y;
    %Zset = %Z;
  } else {
    %Xset = %X * %this;
    %Yset = %Y * %this;
    %Zset = %Z * %this;
  }

  %force = "" @ %Xset @ " " @ %Yset @ " " @ %Zset @ "";

  Item::setVelocity(%player, %force); 
  Client::sendMessage(Player::getClient(%player),0, %msg);
}

function Brake::UpdateVel(%player,%BPercentage,%msg) {

  %client = Player::getClient(%player);
  %obj = newObject("","Mine","Boost");
  addToSet("MissionCleanup", %obj);
  GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
  %player.throwTime = getSimTime() + 0.2;

  %armor = Player::getArmor(%player);

  %dir = Item::getVelocity(%player);
  %X = getWord(%dir,0);
  %Y = getWord(%dir,1);
  %Z = getWord(%dir,2);

  %this = (%BPercentage);

  %Xset = %X * %this;
  %Yset = %Y * %this;
  %Zset = %Z * %this;

  %force = "" @ %Xset @ " " @ %Yset @ " " @ %Zset @ "";

  Item::setVelocity(%player, %force); 
  Client::sendMessage(Player::getClient(%player),0, %msg);
}

//-------------------

function Boost::VXU::UpdateVel(%player,%BPercentage,%msg) {
  Boost::UpdateVel(%player,%BPercentage,%msg);
}

function Brake::VXU::UpdateVel(%player,%BPercentage,%msg) {
  Brake::UpdateVel(%player,%BPercentage,%msg);
}

//-------------------

function Boost::VXO::UpdateVel(%player,%BPercentage,%msg) {
  Boost::UpdateVel(%player,%BPercentage,%msg);
}

function Brake::VXO::UpdateVel(%player,%BPercentage,%msg) {
  Brake::UpdateVel(%player,%BPercentage,%msg);
}

//-------------------

function Boost::VX5(%player,%msg) {
  %obj = newObject("","Mine","VX5Boost");
  addToSet("MissionCleanup", %obj);
  %client = Player::getClient(%player);
  GameBase::throw(%obj,%player,0,false);
  %player.throwTime = getSimTime() + 0.2;
  Client::sendMessage(Player::getClient(%player),0,%msg);
}

function Brake::VX5::UpdateVel(%player,%BPercentage,%msg) {
//  Boost::VXU::UpdateVel(%player,%BPercentage,%msg,true);
//  %client = Player::getClient(%player);
//  %velocity = Item::getVelocity(%player);
//  %velX = getWord(%velocity, 0);
//  %velY = getWord(%velocity, 1);
//  %velZ = getWord(%velocity, 2);
//  %velXa = %velX * %BPercentage;
//  %velYa = %velY * %BPercentage;
//  %velZa = %velZ * %BPercentage;
//  Item::setVelocity(%player, %velXa @ " " @ %velYa @ " " @ %velZa);
//  Client::sendMessage(%client,0,%msg);
  Brake::UpdateVel(%player,%BPercentage,%msg);
}

//-------------------

function Beacon::onUse(%player,%item) {
  if($matchStarted) {
    if(%player.throwTime < getSimTime() ) {
      //Player::decItemCount(%player,%item);  // Commented for unlimited boosts
      %armor = Player::getArmor(%player);
//      Boost::VXU::UpdateVel(%player,$VXU::BoostSpeed[%armor],"You use a Speed Booster.");

      %clientId = Player::getClient(%player);
      if ( %clientId.selBoost == "vxo" ) {
        Boost::VXO::UpdateVel(%player,$VXU::BoostSpeed[%armor],"You used a Speed Booster.");
      } else if ( %clientId.selBoost == "vx5" ) {
        Boost::VX5(%player,"You used a Speed Booster.");
      } else {
        Boost::VXU::UpdateVel(%player,$VXU::BoostSpeed[%armor],"You used a Speed Booster.");
      }
    }
  }
}

function Grenade::onUse(%player,%item)
{
  if($matchStarted) {
    if(%player.throwTime < getSimTime() ) {
      //Player::decItemCount(%player,%item); // Commented for unlimited brakes
      %armor = Player::getArmor(%player);
//      Brake::VXU::UpdateVel(%player,$VXU::BrakeSpeed[%armor],"Impulse Brake Activated.");

      %clientId = Player::getClient(%player);
      if ( %clientId.selBrake == "vxo" ) {
        Brake::VXO::UpdateVel(%player,$VXO::BrakeSpeed[%armor],"Impulse Brake Activated.");
      } else if ( %clientId.selBrake == "vx5" ) {
        Brake::VX5::UpdateVel(%player,$VX5::BrakeSpeed[%armor],"You used an AirBrake.");
      } else {
        Brake::VXU::UpdateVel(%player,$VXU::BrakeSpeed[%armor],"Impulse Brake Activated.");
      }
    }
  }
}






//-----------------------------------------------------------------------------------------
MineData RadiusMine
{
	className = "Mine";
   description = "Radius Mine";
   shapeFile = "flag";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = radiusmineexp;
	explosionRadius = 20;
	damageValue = 1;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 10;
	maxDamage = 1;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function RadiusMine::onAdd(%this)
{
	%this.damage = 0;
	RadiusMine::deployCheck(%this);
}

function RadiusMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == RadiusMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function RadiusMine::deployCheck(%this)
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
		schedule("RadiusMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function RadiusMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "radiusmineammo"]--;
}

function RadiusMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//-----------------------------------------------------------
MineData VXGasAttack
{
	className = "Mine";
   description = "VX Gas Attack";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = VXGasAttackExp;
	explosionRadius = 8;
	damageValue = 0.9;
	damageType = $SmokeDamageType;
	kickBackStrength = 0;
	triggerRadius = 4;
	maxDamage = 2;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function VXGasAttack::onAdd(%this)
{
	%this.damage = 0;
	VXGasAttack::deployCheck(%this);
}

function VXGasAttack::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == VXGasAttack || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function VXGasAttack::deployCheck(%this)
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
		schedule("VXGasAttack::deployCheck(" @ %this @ ");", 3, %this);
}	

function VXGasAttack::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "VXGasAttackammo"]--;
}

function VXGasAttack::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $SmokeDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//-----------------------------------------------------------------------