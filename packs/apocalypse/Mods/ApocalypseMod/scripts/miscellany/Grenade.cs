//--------------------------------------

$SellAmmo[Grenade] = 5;
addAPack(Grenade,1);

addToInv(Grenade,1,1);

setArmorItemMax(Grenade,5,5,5,1,1,5,5, 9, 1,1,1,1);

//--------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = $InvCatMisc;
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   //validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime() && !$Apocalypse::SlugFest) {
		%armor = $ArmorName[Player::getArmor(%player)];
		eval(%armor @ "::onGrenade(" @ %player @ ", " @ %item @ ");");
	}
}

//Quicksilver Flash Bang Nade-----------

MineData BlindNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Flash Bang";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = flashExpLarge;
	explosionRadius = 35.0;
	damageValue = 0.11;
	damageType = $FlashDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function BlindNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}

//Peltast Venom Nade--------------------

MineData VenomNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Posion Gas Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $PoisonDamageType;
	kickBackStrength = 175;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function VenomNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

//Centurion Normal Nade-----------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Hand Grenade";
   shapeFile = "grenade";
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

//Centurion EMP Nade--------------------

MineData EMPNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "EMP Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = LargeShockwave2;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $EmpDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function EMPNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

//Centurion Fire Nade-------------------

MineData FireNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Napalm Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $FireDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function FireNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

//Hoplite Kamikaze Nade-----------------

MineData KamikazeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Kamikaze Bomb";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = plasmaExp0;
	explosionRadius = 50.0;
	damageValue = 2.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 175;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//Guardian Mini Det Bomb----------------

MineData MiniDetBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Mini Det Bomb";
   shapeFile = "plasammo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 35.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function MiniDetBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

//Myrmidon Mortar Nade------------------

MineData MortarNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Hand Mortar";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 175;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function MortarNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//Myrmidon Implosion Nade---------------

MineData ImplodeNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Implosion Hand Mortar";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $GravityDamageType;
	kickBackStrength = -175;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ImplodeNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//Apocalypse Repulsion Nade-------------

MineData RepulseNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Repulsion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 0.25;
	damageType = $StormDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function RepulseNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//Ultima Nade-----------------

MineData UltimaNade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.45;
	friction = 1.0;
	className = "Handgrenade";
   description = "Apocalypse Grenade";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = LargeShockwave2;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $ApocalypseDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function UltimaNade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//ProtoManX Nade------------------------

MineData GigaBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Giga";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = plasmaExp0;
	explosionRadius = 10.0;
	damageValue = 5.0;
	damageType = $GigaDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 2;
};

function GigaBomb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1);
}

//Discer Nade---------------------------
//Disc nade is really a bullet
BulletData ThrowingDisc
{
   bulletShapeName    = "discb.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass 	      = 0.15;
   bulletHoleIndex    = 0;

   damageClass	      = 0;	 // 0 impact, 1, radius
   damageValue	      = 0.5;
   damageType	      = $ExplosionDamageType;

   muzzleVelocity     = 80.0;
   totalTime	      = 1.5;
   inheritedVelocityScale = 0.5;
   isVisible	      = True;
};

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

//Detonation bomb-----------------------
MineData DetPackBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Detonation Bomb";
   shapeFile = "magcargo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 70.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function DetPackBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
}
