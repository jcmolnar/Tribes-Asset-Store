
$InvList[StoneThrowGrenade] = 1;
$RemoteInvList[StoneThrowGrenade] = 1;
$HelpMessage[StoneThrowGrenade] = "Me Og!  Me like rock!  Me beat you with rock!.";

$ItemMax[hlarmor, StoneThrowGrenade] = 30;
$ItemMax[hlfemale, StoneThrowGrenade] = 30;
$ItemMax[marmor, StoneThrowGrenade] = 70;
$ItemMax[mfemale, StoneThrowGrenade] = 70;
$ItemMax[larmor, StoneThrowGrenade] = 40;
$ItemMax[lfemale, StoneThrowGrenade] = 40;
$ItemMax[earmor, StoneThrowGrenade] = 60;
$ItemMax[efemale, StoneThrowGrenade] = 60;
$ItemMax[harmor, StoneThrowGrenade] = 60;
$ItemMax[uharmor, StoneThrowGrenade] = 60;

MineData StoneThrow
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.1;
	friction = 1.0;
	className = "grenade";
	description = "Rock";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = StonedExp;
	explosionRadius = 3.0;
	damageValue = 0.5;
	damageType = $BulletDmgType20;
	kickBackStrength = 200;
	triggerRadius = 2.0;
	maxDamage = 500.01; //
};

function StoneThrow::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
	// schedule("CheckMySpeed(" @ %this @ ", 150);",0.2,%this);
	
}

function CheckMySpeed(%this, %steps)
{

	if(%steps)
	{
		%vel = Item::getVelocity(%this);
		%velZ = getWord(%vel,2);
		%velx = getWord(%vel,0);
		%vely = getWord(%vel,1);

		// Make sure the rock isn't at a standstill.  If it is, make it a dud.

		if (%velz >= 5 || %velz <= -5 || %vely >= 5 || %vely <= -5 || %velx >= 5 || %velx <= -5)
		{

		 // Rock is travelling faster than 5 mph, so dont do anything
				
		}
		else
		{

		// Rock is too slow to cause damage, so make it harmless.
		schedule("Mine::Detonate(" @ %this @ ");",0.0,%this);

		}

		schedule("CheckMySpeed(" @ %this @ ", " @ %steps - 1 @ ");", 0.05);
	}

}



function StoneThrow::onCollision(%this,%obj)
{


	%vel = Item::getVelocity(%this);
	%velZ = getWord(%vel,2);
	%velx = getWord(%vel,0);
	%vely = getWord(%vel,1);

	// A slow rock does no damage

	if (%velz >= 5 || %velz <= -5 || %vely >= 5 || %vely <= -5 || %velx >= 5 || %velx <= -5)
	{

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	schedule("Mine::Detonate(" @ %this @ ");",0.0,%this);
	}
	else
	{

	}

}

function StoneThrow::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function StoneThrow::Detonate(%this)
{


	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function StoneThrow::onDestroyed(%this)
{
	%obj = newObject("","Mine","DeadRock");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,2.0,true);	
}


MineData DeadRock  // A rock when thrown
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.5;
	friction = 1.0;
	className = "grenade";
	description = "Dead Rock";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = BigBulletExp2;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $BulletDmgType20;
	kickBackStrength = 200;
	triggerRadius = 0.0;
	maxDamage = 500.01; //
};

function DeadRock::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20.0,%this);
	
}

function DeadRock::onCollision(%this,%obj)
{

}

function DeadRock::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function DeadRock::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);

}

function DeadRock::onDestroyed(%this)
{

}