StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;
	sfxAmbient = StrikeBeep;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function DefaultBeacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
  schedule("Launchbombs(" @ %this @ ");",15.0,%this);

}

function Launchbombs(%this) //Drop a few bombs!
{
 			%loc = Gamebase::getPosition(%this);
		 	%locZ = getWord(%loc,2);
		 	%locx = getWord(%loc,0);
		 	%locy = getWord(%loc,1);

			Gamebase::setPosition(%this, " " @ %locx @ " " @ %locy @ " " @ %locz + 150 @ " ");
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

		%client = GameBase::getOwnerClient(%this);
		Projectile::spawnProjectile("StrikeShell",%trans,%this,"0 0 0");

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"-2 -2 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"2 2 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"2 -2 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"-2 2 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"-5 -5 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"5 5 0"));
		

		%fired = ( Projectile::spawnProjectile("StrikeShell",%trans,%this,"5 -5 0"));
		

		%fired = (Projectile::spawnProjectile("StrikeShell",%trans,%this,"-5 5 0"));
		
		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.0,false);

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1.0,false);	

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,false);	

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1.0,false);	

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.0,false);

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.0,false);

		%obj = newObject("","Mine","defender");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5.0,false);	


	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}




function DefaultBeacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function DefaultBeacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetBeacon"]--;
}


StaticShapeData StrikeBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	//shapeFile = "sensor_small";
	shapeFile = "bullet";
	maxDamage = 0.1;
	maxEnergy = 200;

	castLOS = true;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function StrikeBeacon::onEnabled(%this)
{
   // GameBase::setIsTarget(%this,true);
		schedule("Launchplane(" @ %this @ ");",5.0,%this);

}

function Launchplane(%this) //Launch some planes
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("StrikeRocket",%trans,%this,%vel);
		// messageall(1, "INCOMING AIRSTRIKE!!!");
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function StrikeBeacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function StrikeBeacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
}



// beacon code

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
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetBeacon"]--;
}