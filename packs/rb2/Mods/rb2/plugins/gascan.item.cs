
$InvList[GasCanGrenade] = 1;
$RemoteInvList[GasCanGrenade] = 1;
$HelpMessage[GasCanGrenade] = "A large can of highly explosive fuel.  Shoot it for some fun!";

$ItemMax[hlarmor, GasCanGrenade] = 0;
$ItemMax[hlfemale, GasCanGrenade] = 0;
$ItemMax[marmor, GasCanGrenade] = 2;
$ItemMax[mfemale, GasCanGrenade] = 2;
$ItemMax[larmor, GasCanGrenade] = 1;
$ItemMax[lfemale, GasCanGrenade] = 1;
$ItemMax[earmor, GasCanGrenade] = 1;
$ItemMax[efemale, GasCanGrenade] = 1;
$ItemMax[harmor, GasCanGrenade] = 1;
$ItemMax[uharmor, GasCanGrenade] = 1;

MineData GasCan
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "Gas Can";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 50.0;
	damageValue = 1.0;
	damageType = $ScramblerDamageType;
	kickBackStrength = 450;
	triggerRadius = 0.5;
	maxDamage = 0.01;
};

function GasCan::onAdd(%this)
{	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	
}

function GasCan::onCollision(%this,%obj)
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
			Client::sendMessage(%c,1,"You made a spark and lit the fuel...");
			// MODERN-PORT (2026-09-04): was Mine::Detonate(" @ %this @ "); -- a string literal
			// pasted from a schedule() call, so the "spark" branch detonated a nonexistent
			// object and the can just sat there after the message.
			Mine::Detonate(%this);
			return;
		}
		else
		{	
			deleteObject(%this);
			Client::sendMessage(%c,1,"You safely emptied the gas can.");
		}
	}
}

function GasCan::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	

	// if (%type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $BombDamageType)
	if ($CanExploding == 0)
	{ 

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
	}

}

function GasCan::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);


}

function GasCan::onDestroyed(%this)
{
	// MODERN-PORT (2026-09-04): the author's one-barrage-at-a-time rule was enforced only in
	// GasCan::onDamage (cans ignore damage while $CanExploding is set). The spark path in
	// onCollision reaches onDestroyed through Mine::Detonate without passing onDamage -- it
	// never worked before the fix above, so it never got the chance -- so apply the same
	// rule here: a can destroyed inside another can's window explodes without the 30-fireball
	// barrage. ($CanExploding starts unset; "" == 0 is true in this dialect, eval.cpp
	// compare(): an int operand forces a float compare and atof("") is 0.)
	if ($CanExploding)
		return;
		 $CanExploding = 1;  		      // make sure only one gas can will explode at a time.  Server will crash otherwise.
		 schedule("$CanExploding = 0;", 10.0); // wait 10 seconds until another gas can may be exploded
			
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,8.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6.5,true);
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,10.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,9.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,8.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1.0,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.5,true);	
		%obj = newObject("","Mine","DecloakGrenade");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,6.5,true);	
}