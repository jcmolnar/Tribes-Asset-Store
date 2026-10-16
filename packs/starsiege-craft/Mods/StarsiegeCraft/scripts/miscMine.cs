$SellAmmo[MineAmmo] = 5;
$TeamItemMax[mineammo] = 35;
$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;
$VehicleInvList[MineAmmo] = 1;
addAmmo("", MineAmmo, 1);

function miscMine::Initialize()
{
 $TeamItemCount[0 @ mineammo] = 0;
 $TeamItemCount[1 @ mineammo] = 0;
 $TeamItemCount[2 @ mineammo] = 0;
 $TeamItemCount[3 @ mineammo] = 0;
 $TeamItemCount[4 @ mineammo] = 0;
 $TeamItemCount[5 @ mineammo] = 0;
 $TeamItemCount[6 @ mineammo] = 0;
 $TeamItemCount[7 @ mineammo] = 0;
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %damageLevel = GameBase::getDamageLevel(%this);
  GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this) 
{
  %data = GameBase::getDataName(%this);
  GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData XNLight 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.0;
  friction = 99.0;
  className = "Handgrenade";
  description = "Electronicator";
  shapeFile = "mine";
  shadowDetailMask = 4;
  explosionId = TurretExp;
  explosionRadius = 15.0;
  damageValue = 0.5;
  damageType = $DeathDamageType;
  kickBackStrength = -50;
  triggerRadius = 0.5;
  maxDamage = 1;
};

function XNLight::onAdd(%this) 
{
  %this.damage = 0;
  XNLight::deployCheck(%this);
//  schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
//  schedule("XNLight::Lightning(" @ %this @ ");",2.0,%this);
}

function XNLight::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    %data = GameBase::getDataName(%this);
    schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
    %client = %this.deployer;
    XNLight::Lightning(%this, %client);
  }
  else schedule("XNLight::deployCheck(" @ %this @ ");", 1, %this);
}

function XNLight::Lightning(%this, %client)
{
  %lightpos = GameBase::getPosition(%this);
  %light = newObject("","Mine","XNLightning"); 
  addToSet("MissionCleanup", %light); 
  %locale = Vector::add(%lightpos, "0 0 100");
  %light.deployer = %client;
  GameBase::setPosition(%light, %locale);
}

MineData XNLightning
{ 
	mass = 0.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.0; 
	friction = 99.0; 
	className = "Handgrenade"; 
	description = "Man"; 
	shapeFile = "zap"; 
	shadowDetailMask = 4; 
	explosionId = LargeShockwave; 
	explosionRadius = 25.0; 
	damageValue = 2.0;
	damageType = $DeathDamageType;
	kickBackStrength = -200;
	triggerRadius = 15;
	maxDamage = 0.1;
};

function XNLightning::onAdd(%this) 
{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",3.22,%this); 
}

 //-=-=-=-
//}APK{Ecliptici's firebatgren 2 when you have the fuel pack on
//also his new dragoon grenade, which is complete awesomeness :)

MineData Electro
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "discb";
  shadowDetailMask = 4;
  explosionId = turretExp;
  explosionRadius = 10.0;
  damageValue = 0.3;
  damageType = $FlashDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Electro::onAdd(%this)
{
	schedule("DeployElectro(" @ %this @ ");",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",4.5,%this);
}

function DeployElectro(%this, %count) 
{
	if(%this)
	{
		%obj = newObject("","Mine","ElectroL1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10,false);
		
		%obj = newObject("","Mine","ElectroL1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10,false);
	}
}

function DeployElectro2(%this, %count) 
{
	if(%this)
	{
		%obj = newObject("","Mine","ElectroL2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10,false);
		
		%obj = newObject("","Mine","ElectroL2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10,false);
	}
}

MineData ElectroL1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "disc";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = TurretExp;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $FlashDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

MineData ElectroL2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "disc";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $FlashDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function ElectroL1::onAdd(%this)
{
	schedule("DeployElectro2(" @ %this @ ");",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}

function ElectroL2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

function FirebatGren(%this, %count) 
{
	if(%this)
	{
		%obj = newObject("","Mine","Handgrenade21");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.1,false);
		
		%obj = newObject("","Mine","Handgrenade21");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.1,false);
	}
}

function FirebatGren2(%this, %count) 
{
	if(%this)
	{
		%obj = newObject("","Mine","Handgrenade22");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.1,false);
	}
}

MineData Handgrenade2
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 15.0;
  damageValue = 0.5;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 200;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

MineData Handgrenade21
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 10.0;
  damageValue = 0.3;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 200;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

MineData Handgrenade22
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 10.0;
  damageValue = 0.4;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 200;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Handgrenade2::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("FirebatGren(" @ %this @ " , 5);",1.0,%this);
  schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

function Handgrenade21::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("FirebatGren2(" @ %this @ " , 5);",1.0,%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Handgrenade22::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}

//End of clippy's cool stuff

MineData MineSpawn
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "bullet";
  shadowDetailMask = 4;
  explosionId = bulletExp0;
  explosionRadius = 10.0;
  damageValue = 0.0;
  damageType = $MortarDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function MineSpawn::onAdd(%this)
{
	schedule("DeployBrood(" @ %this @ " , 5);",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

function DeployBrood(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","AntipersonelMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,false);
		
		%obj = newObject("","Mine","AntipersonelMine");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,false);
	}
}

MineData ManyDiscs
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 10.0;
  damageValue = 0.4;
  damageType = $MortarDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function ManyDiscs::onAdd(%this)
{
	schedule("DeployDisc(" @ %this @ " , 5);",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function DeployDisc(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","LDisc");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);
		
		%obj = newObject("","Mine","LDisc");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
		%count -= 1;
		schedule("DeployDisc(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

MineData LDisc
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "disc";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = DebrisExpSmall;
	explosionRadius = 10.0;
	damageValue = 0.35;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function LDisc::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.7,%this);
}

MineData VultureGren
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "mortar";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 10.0;
  damageValue = 0.4;
  damageType = $MortarDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function VultureGren::onAdd(%this)
{
	schedule("DeployVult(" @ %this @ " , 5);",0.5,%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

function DeployVult(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","VGren");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);
		
		%obj = newObject("","Mine","VGren");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
		//%count -= 1;
		//schedule("DeployDisc(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

MineData VGren
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "disc";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = DebrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.35;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function VGren::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.9,%this);
}

MineData HealGren
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "mine";
  shadowDetailMask = 4;
  explosionId = clawExp;
  explosionRadius = 10.0;
  damageValue = 0;
  damageType = $MineDamageType;
  kickBackStrength = -50;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function HealGren::onAdd(%this)
{
	schedule("DeployLifeGrens(" @ %this @ " , 5);",0.2,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.6,%this);
}

function DeployLifeGrens(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","LifeGren");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,false);
		%obj = newObject("","Mine","LifeGren");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);
		%obj = newObject("","Mine","LifeGren");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,false);
	}
}

MineData LifeGren
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "healgrenade";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = clawExp;
	explosionRadius = 30.0;
	damageValue = -0.35;
	damageType = $MineDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 0.1;
};

function LifeGren::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this);
}

MineData Medicgrenade 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = clawExp;
  explosionRadius = 17.0;
  damageValue = 0.5;
  damageType = $EnergyDamageType;
  kickBackStrength = 200;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Medicgrenade::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

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
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 10.0;
  damageValue = 0.5;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 200;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Handgrenade::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=- MineAmmo

ItemData MineAmmo 
{
  description = "Mine";
  shapeFile = "mineammo";
  heading = $InvHead[ihMis];
  shadowDetailMask = 4;
  price = 10;
  className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item) 
{
  if($matchStarted) 
  {
    if(%player.throwTime < getSimTime() ) 
    {
      Player::decItemCount(%player,%item);
      %armor = Player::getArmor(%player);
      %client = Player::getClient(%player);
      if ($Deathmatch)
        %obj = newObject("","Mine","DMMine");
      else if (%armor == "armormMedik" || %armor == "armorfMedik")
      {
        %obj = newObject("","Mine","MedicMine");
        GameBase::setTeam (%obj,GameBase::getTeam (%client));
      }
      else
      {
        %obj = newObject("","Mine","antipersonelMine");
        GameBase::setTeam (%obj,GameBase::getTeam (%client));
      }
      addToSet("MissionCleanup", %obj);
      GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
      %player.throwTime = getSimTime() + 0.5;
    }
  }
}

 //-=-=-=- 

MineData AntipersonelMine 
{
  className = "Mine";
  description = "Antipersonel Mine";
  shapeFile = "mine";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 10.0;
  damageValue = 2.0;
  damageType = $MineDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
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
  if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}

function AntipersonelMine::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

MineData MedicMine 
{
  className = "Mine";
  description = "Antipersonel Mine";
  shapeFile = "armorKit";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 10.0;
  damageValue = 2.0;
  damageType = $MineDamageType;
  kickBackStrength = 250;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function MedicMine::onAdd(%this) 
{
  %this.damage = 0;
  MedicMine::deployCheck(%this);
}

function MedicMine::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MedicMine::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("MedicMine::deployCheck(" @ %this @ ");", 3, %this);
}

function MedicMine::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MedicMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

 //-=-=-=-

MineData MinerMine 
{
  className = "Mine";
  description = "Miner Mine";
  shapeFile = "mine";
  shadowDetailMask = 4;
  explosionId = DebrisExpMedium;
  explosionRadius = 15.0;
  damageValue = 1.5;
  damageType = $MineDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.0;
  maxDamage = 10.0;
  shadowDetailMask = 0;
  destroyDamage = 1.5;
  damageLevel = {1.0, 1.0};
};

function MinerMine::onAdd(%this) 
{
  %this.damage = 0;
  MinerMine::deployCheck(%this);
}

function MinerMine::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MinerMine::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("MinerMine::deployCheck(" @ %this @ ");", 3, %this);
}

function MinerMine::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MinerMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

 //-=-=-=-

MineData canister
{
  className = "Mine";
  description = "Antipersonel Mine";
  shapeFile = "liqcyl";
  shadowDetailMask = 4;
  explosionId = mortarExp;
  explosionRadius = 26.0;
  damageValue = 3;
  damageType = $MineDamageType;
  kickBackStrength = 500;
  triggerRadius = 15;
  maxDamage = 2.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function canister::onAdd(%this) 
{
  %this.damage = 0;
  canister::deployCheck(%this);
}

function canister::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function canister::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("canister::deployCheck(" @ %this @ ");", 3, %this);
}

function canister::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function canister::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

 //-=-=-=-

MineData DMMine 
{
  className = "Mine";
  description = "Antipersonel Mine";
  shapeFile = "mine";
  shadowDetailMask = 4;
  explosionId = mineExp;
  explosionRadius = 10.0;
  damageValue = 0.65;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 250;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function DMMine::onAdd(%this) 
{
  %this.damage = 0;
  DMMine::deployCheck(%this);
}

function DMMine::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DMMine::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::playSequence(%this,1,"deploy");
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("DMMine::deployCheck(" @ %this @ ");", 3, %this);
}

function DMMine::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

 //-=-=-=-

MineData HoloMine 
{
  className = "Mine";
  description = "Hologram";
  shapeFile = "larmor";
  shadowDetailMask = 4;
  explosionId = mineExp;
  explosionRadius = 15.0;
  damageValue = 0.75;
  damageType = $MineDamageType;
  kickBackStrength = 350;
  triggerRadius = 2.5;
  maxDamage = 2.00;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this) 
{
  %this.damage = 0;
  HoloMine::deployCheck(%this);
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function HoloMine::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}

function HoloMine::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}

 //-=-=-=-

MineData Hologram 
{
  className = "Mine";
  description = "Antipersonel Mine";
  shapeFile = "flag";
  shadowDetailMask = 4;
  explosionId = mineExp;
  explosionRadius = 5.0;
  damageValue = 0.75;
  damageType = $MineDamageType;
  kickBackStrength = 150;
  triggerRadius = 0.0;
  maxDamage = 3.00;
  shadowDetailMask = 0;
  destroyDamage = 2.0;
  damageLevel = {1.0, 1.0};
  lightType = 2;
  lightRadius = 4;
  lightTime = 1.5;
  lightColor = {1, 1, 1 };
};

function Hologram::onAdd(%this) 
{
  %this.damage = 0;
  Hologram::deployCheck(%this);
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function Hologram::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == Hologram|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this) 
{
  if (GameBase::isAtRest(%this)) 
  {
    GameBase::setActive(%this,true);
    %set = newObject("set",SimSet);
    if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
    {
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
    }
    deleteObject(%set);
  }
  else schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}

function Hologram::onDestroyed(%this) 
{
  $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %data = GameBase::getDataName(%this);
  if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
  else %this.damage += %value;
}


 //-=-=-=-

MineData Tranqgrenade 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = Shockwave;
  explosionRadius = 10.0;
  damageValue = 0.25;
  damageType = $EnergyDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Tranqgrenade::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Shockgrenade 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = Shockwave;
  explosionRadius = 20.0;
  damageValue = 0.2;
  damageType = $FlashDamageType;
  kickBackStrength = 50;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Shockgrenade::onAdd(%this) 
{
//  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Concussion 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = grenadeExp;
  explosionRadius = 15.0;
  damageValue = 0.50;
  damageType = $PlasmaDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Concussion::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Nukebomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.0;
  friction = 99.0;
  className = "Handgrenade";
  description = "Yamato";
  shapeFile = "plasammo";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 30.0;
  damageValue = 2.0;
  damageType = $MortarDamageType;
  kickBackStrength = 800;
  triggerRadius = 0.5;
  maxDamage = 0.01;
};

function Nukebomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",6.0,%this);
}

function Nukebomb::onCollision(%this,%obj) 
{
  if(getObjectType(%obj) != "Player") 
  {
    return;
  }
  if(Player::isDead(%obj)) 
  {
    return;
  }
  %c = Player::getClient(%obj);
  %playerTeam = GameBase::getTeam(%obj);
  %teleTeam = GameBase::getTeam(%this);
  %armor = Player::getArmor(%obj);
  if (%armor == "armormEngineer" || %armor == "armormMercenary" || %armor == "armorfMercenary") 
  {
    %rnd = floor(getRandom() * 10);
    if(%rnd > 8) 
    {
      Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
      Mine::Detonate(" @ %this @ ");
      return;
    }
    else 
    {
      deleteObject(%this);
      Client::sendMessage(%c,1,"You disarm the Bomb.");
    }
  }
}

 //-=-=-=-

MineData Suicidebomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "magcargo";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 50.0;
  damageValue = 4.0;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $MineDamageType) %value = %value * 0.25;
  %damageLevel = GameBase::getDamageLevel(%this);
  GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this) 
{
  %data = GameBase::getDataName(%this);
  GameBase::setDamageLevel(%this, %data.maxDamage);
}

 //-=-=-=-

MineData Suicidebomb2 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "magcargo";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 70.0;
  damageValue = 4.0;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Suicidebomb2::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",5,%this);
}

function Suicidebomb2::onCollision(%this,%obj) 
{
  if(getObjectType(%obj) != "Player") 
  {
    return;
  }
  if(Player::isDead(%obj)) 
  {
    return;
  }
  %c = Player::getClient(%obj);
  %playerTeam = GameBase::getTeam(%obj);
  %teleTeam = GameBase::getTeam(%this);
  %armor = Player::getArmor(%obj);
  if (%armor == "earmor" || %armor == "efemale") 
  {
    %rnd = floor(getRandom() * 10);
    if(%rnd > 7) 
    {
      Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
      Mine::Detonate(" @ %this @ ");
      return;
    }
    else 
    {
      deleteObject(%this);
      Client::sendMessage(%c,1,"You disarm the DetPack.");
    }
  }
}

 //-=-=-=-

MineData Mortarbomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "mortar"; //"grenade";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 20.0;
  damageValue = 1.0;
  damageType = $MortarDamageType;
  kickBackStrength = 250;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Ultrabomb
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 99.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "mrtwig"; //"funny looking thingy";
  shadowDetailMask = 4;
  explosionId = Shockwave;
  explosionRadius = 20.0;
  damageValue = 1.3;
  damageType = $PsiDamageType;
  kickBackStrength = 250;
  triggerRadius = 5.0;
  maxDamage = 2.0;
};

function Ultrabomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",4.0,%this);
}

 //-=-=-=-

MineData Firebomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = flashExpLarge;
  explosionRadius = 30.0;
  damageValue = 0.1;
  damageType = $ExplosionDamageType;
  kickBackStrength = 350;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Firebomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Plasgren 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Plasma Grenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = plasmaExp;
  explosionRadius = 15.0;
  damageValue = 0.47;
  damageType = $PlasmaDamageType;
  kickBackStrength = 10;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Plasgren::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Krakgren 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Krak Grenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = bulletExp0;
  explosionRadius = 5.0;
  damageValue = 2.47;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 10;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Krakgren::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}


function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData Forcegrenade 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "grenade";
  shadowDetailMask = 4;
  explosionId = Shockwave;
  explosionRadius = 20.0;
  damageValue = 0.25;
  damageType = $FlashDamageType;
  kickBackStrength = 400;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Forcegrenade::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Psibomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Scrambler Bomb";
  shapeFile = "camera";
  shadowDetailMask = 4;
  explosionId = shockwave;
  explosionRadius = 40.0;
  damageValue = 0.4;
  damageType = $FlashDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 0.5;
};

function Psibomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function Psibomb::onCollision(%this,%obj) 
{
  if(getObjectType(%obj) != "Player") 
  {
    return;
  }
  if(Player::isDead(%obj)) 
  {
    return;
  }
  %c = Player::getClient(%obj);
  %playerTeam = GameBase::getTeam(%obj);
  %teleTeam = GameBase::getTeam(%this);
  %armor = Player::getArmor(%obj);
  if (%armor == "earmor" || %armor == "efemale") 
  {
    %rnd = floor(getRandom() * 10);
    if(%rnd > 8) 
    {
      Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
      Mine::Detonate(" @ %this @ ");
      return;
    }
    else 
    {
      deleteObject(%this);
      Client::sendMessage(%c,1,"You disarm the bomb.");
    }
  }
}

MineData Virusbomb 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Arclite Cylinder";
  shapeFile = "liqcyl";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 70.0;
  damageValue = 1.5;
  damageType = $EnergyDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 0.2;
};

function Virusbomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",8.0,%this);
}

function Virusbomb::onCollision(%this,%obj) 
{
  if(getObjectType(%obj) != "Player") 
  {
    return;
  }
  if(Player::isDead(%obj)) 
  {
    return;
  }
  %c = Player::getClient(%obj);
  %playerTeam = GameBase::getTeam(%obj);
  %teleTeam = GameBase::getTeam(%this);
  %armor = Player::getArmor(%obj);
  if (%armor == "earmor" || %armor == "efemale") 
  {
    %rnd = floor(getRandom() * 10);
    if(%rnd > 8) 
    {
      Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
      Mine::Detonate(" @ %this @ ");
      return;
    }
    else 
    {
      deleteObject(%this);
      Client::sendMessage(%c,1,"You disarm the Arclite Bomb.");
    }
  }
}
