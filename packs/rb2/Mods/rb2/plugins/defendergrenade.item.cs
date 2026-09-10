// DeadTaco's orbiter grenade -  An idea created just for entertainment purposes
// and to see how well it would work in a tribes environment.
// Update -- Turned it into a sticky bomb since that's what it ended up becoming


$InvList[defenderGrenade] = 1;
$RemoteInvList[defenderGrenade] = 1;
$HelpMessage[defenderGrenade] = "Sticks to whoever it touches.  Great to toss at people.";

$ItemMax[hlarmor, defenderGrenade] = 2;
$ItemMax[hlfemale, defenderGrenade] = 2;
$ItemMax[marmor, defenderGrenade] = 6;
$ItemMax[mfemale, defenderGrenade] = 6;
$ItemMax[larmor, defenderGrenade] = 2;
$ItemMax[lfemale, defenderGrenade] = 2;
$ItemMax[earmor, defenderGrenade] = 4;
$ItemMax[efemale, defenderGrenade] = 4;
$ItemMax[harmor, defenderGrenade] = 3;
$ItemMax[uharmor, defenderGrenade] = 3;

MineData defender
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 100.0;
	className = "grenade";
	description = "Sticky Bomb";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 2.0;
	damageType = $BulletDmgType19;
	kickBackStrength = 600;
	triggerRadius = 3.0;
	maxDamage = 0.1;
};

function defender::onAdd(%this)
{	
	%this.HasATarget = 0;
	%this.Ripoff = 0;
	%this.Victim = 0;
	schedule("BlowMeUp(" @ %this @ ");",10.0,%this);
}

function OrbitPlayer(%this, %steps, %ClientId) //Make the grenade stick to its victim permanently
{
		if (%this.Ripoff >= 100)
		{
			%steps = -100;
			%clientId.stickyStuck = 1;
		}

	if(%steps)
	{

		if(%steps <= 20) 
		{
		%this.HasATarget = 0;
		%clientId.stickyStuck = 0;
		schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);  //Blow the sucker up after the fuse goes off
		}
		else
		{
		Gamebase::setPosition(%this, Gamebase::getPosition(%ClientId));

			//make sure a sticky bomb doesn't stick back on a player after he respawns
			if (Player::isDead(%ClientId)) 
			%steps = -100;
			%clientId.stickyStuck = 1;
		// MODERN-PORT (2026-09-04): bind the orbit loop to the grenade. The 2-arg schedule kept
		// OrbitPlayer ticking every 50 ms after the grenade detonated (defender::Detonate
		// comments out its own guard: "if grenade blows up while running its routine, it will
		// crash the game"). Bound to %this, the engine drops the pending tick when the
		// grenade is unregistered, so nothing runs against a dead object.
		schedule("OrbitPlayer(" @ %this @ ", " @ %steps - 1 @ ", " @ %ClientId @ ");", 0.05, %this);
		GetMySpeed(%this, %ClientId);
		}
	}
}

function GetMySpeed(%this, %ClientId)
{

		%vel = Item::getVelocity(%ClientId);
		%velZ = getWord(%vel,2);
		%velx = getWord(%vel,0);
		%vely = getWord(%vel,1);

		// Check if the player is moving or not.

		if (%velz >= 3 || %velz <= -3 || %vely >= 3 || %vely <= -3 || %velx >= 3 || %velx <= -3)
		{

		// Player is travelling faster than 5 mph so dont rip it off
				
		}
		else
		{

		
		%this.Ripoff = %this.Ripoff + 1;
		bottomprint(%this.Victim, "<jc><f1>\n\nYou are ripping off the sticky bomb! \n<f2>Hold still to rip it off!<f1>\n\n", 0.5);
		Player::setAnimation(%this.victim, 45);


			if (%this.Ripoff >= 100)
			{

			%this.HasATarget = 0;
			Gamebase::setPosition(%this, "0 0 10000");
			bottomprint(%this.Victim, "<jc><f1>\n\nYou ripped off the sticky bomb!<f1>\n\n", 2.0);

			%boomrock = newObject("","Mine","defender");
			addToSet("MissionCleanup", %boomrock);
			GameBase::throw(%boomrock,%this.victim,10.0,false);	

			Player::setAnimation(%this.victim, 45);
				
			}	

		
		

		}

}


function BlowMeUp(%this) //Make the grenade detonate after a certain amount of time if it isn't stuck to anyone
{
	if(%this.HasATarget == 0)
	{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
	}
}


function defender::onCollision(%this,%obj)
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
	%ClientId = %obj;
	if(%this.HasATarget != 1) // Make sure the sticky bomb doesn't try and stick to other things
	{
		Client::sendMessage(%c,1,"You have a sticky bomb stuck to your ass! ~wfemale1.wdoh.wav");
		schedule("OrbitPlayer(" @ %this @ ", 300, " @ %ClientId @ ");",0.05,%this);
		%this.HasATarget = 1;
		%this.Victim = Player::getClient(%obj);

	}
	

}

function defender::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);

}

function defender::Detonate(%this)
{

	// if(%this.HasATarget = 0) //if grenade blows up while running its routine, it will crash the game
	// {
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
	%this.HasATarget = 0;
	%this.Ripoff = 0;
	%this.Victim = 0;
	// }
}

function defender::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}