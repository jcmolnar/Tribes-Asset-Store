$SellAmmo[MineAmmo] = 5;
$TeamItemMax[mineammo] = 35;
$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;

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

 //-=-=-=-

//----------------------------
// Kamikaze Bomb
//----------------------------
MineData KamikazeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Kamikaze Bomb";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = KamikazeExp;
	explosionRadius = 15.0;
    damageValue = 5.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
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
  explosionId = mineExp;
  explosionRadius = 10.0;
  damageValue = 0.75;
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
  Boost::deployCheck(%this);
}

function Hologram::onCollision(%this,%object) 
{
  %type = getObjectType(%object);
  %data = GameBase::getDataName(%this);
  if ((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this) 
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
  else schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}

function Hologram::onDestroyed(%this) { }

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  if (%type == $ShrapnelDamageType) %value = %value * 0.25;
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
  damageValue = 0.15;
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
  description = "Plastique";
  shapeFile = "sensor_small";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 10.0;
  damageValue = 2.0;
  damageType = $MortarDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Nukebomb::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
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
      Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
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
//-------------------------------Deploy Item Shape Wiener pack by King Shit--

MineData Wiener 
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "Cactus1";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 50.0;
  damageValue = 4.0;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

//-------------------------------

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
  shapeFile = "generator_p";
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

MineData Suicidebomb3
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "mortarpack";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 70.0;
  damageValue = 4.0;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function Suicidebomb3::onAdd(%this) 
{
  %data = GameBase::getDataName(%this);
  schedule("Mine::Detonate(" @ %this @ ");",5,%this);
}

function Suicidebomb3::onCollision(%this,%obj) 
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
      Client::sendMessage(%c,1,"You disarm the Kamikaze Pack.");
    }
  }
}

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
  explosionId = mortarExp;
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
//-=-=-=-

