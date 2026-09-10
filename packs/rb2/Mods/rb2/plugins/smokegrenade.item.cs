
$InvList[SmokerGrenade] = 1;
$RemoteInvList[SmokerGrenade] = 1;
$HelpMessage[SmokerGrenade] = "A lot of Smoke to conceal yourself.";

$ItemMax[hlarmor, SmokerGrenade] = 1;
$ItemMax[hlfemale, SmokerGrenade] = 1;
$ItemMax[marmor, SmokerGrenade] = 4;
$ItemMax[mfemale, SmokerGrenade] = 4;
$ItemMax[larmor, SmokerGrenade] = 2;
$ItemMax[lfemale, SmokerGrenade] = 2;
$ItemMax[earmor, SmokerGrenade] = 2;
$ItemMax[efemale, SmokerGrenade] = 2;
$ItemMax[harmor, SmokerGrenade] = 1;
$ItemMax[uharmor, SmokerGrenade] = 1;

MineData Smoker
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "Smoke Grenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $ScramblerDamageType;
	kickBackStrength = 1050;
	triggerRadius = 0.5;
	maxDamage = 500.01; //If smoke grenade can be destroyed, then the game will crash!
};

function Smoker::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",40.0,%this);
	if ($GrenadeIsSmoking != 1)
		{
		schedule("SmokeLikeHell(" @ %this @ ", 270);",3.0,%this); //Make sure only one smoke grenade can go off at a time
		schedule("$GrenadeIsSmoking = 0;",30.0);		  //Or the game may crash, or just get REALLY slow
		}
	
}

function SmokeLikeHell(%this, %steps) //Deadtaco's smoke spew code
{
	if(%steps)
	{
		$GrenadeIsSmoking = 1;
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("SmokeSpew",%trans,%this,%vel);
		schedule("SmokeLikeHell(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function Smoker::onCollision(%this,%obj)
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
}

function Smoker::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function Smoker::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function Smoker::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);


}