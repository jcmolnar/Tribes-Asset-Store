function trailLoop(%this, %newProj, %repeat, %adv, %speed)
{

	if(%repeat > 0 && %repeat < 99){
		%repeat--;
			if(%adv == 0)	{	schedule(	"boom(" @ %this @ "," @ %newProj @ ");",	0.01,	%this);	}
			else			{	schedule("boomAdv(" @ %this @ "," @ %newProj @ ");",	0.01,	%this);	}
			schedule("trailLoop(" @ %this @ "," @ %newProj @ "," @ %repeat @ "," @ %adv @ "," @ %speed @ ");",%speed,%this);	}
	if(%repeat > 99){
			if(%adv == 0)	{	schedule(	"boom(" @ %this @ "," @ %newProj @ ");",	0.01,	%this);	}
			else			{	schedule("boomAdv(" @ %this @ "," @ %newProj @ ");",	0.01,	%this);	}
			schedule("trailLoop(" @ %this @ "," @ %newProj @ "," @ %repeat @ "," @ %adv @ "," @ %speed @ ");",%speed,%this);
	}

	else	{}
}

function trailEndlessLoop(%this,%newProj,%speed)
{
	if(%this)	{
		if(Player::getArmor(%this) == armorfInfest)	{
				if(Player::isJetting(%this))	{
				schedule(	"boomQuick(" @ %this @ "," @ %newProj @ "0);",	0.01,	%this);
				schedule("trailEndlessLoop(" @ %this @ "," @ %newProj @ "," @ %speed @ ");",%speed,%this);
									}
				else					{
					if(item::getVelocity(%this) == "0 0 0")	{
					schedule(	"boomQuick(" @ %this @ "," @ %newProj @ "2);",	0.01,	%this);
					schedule("trailEndlessLoop(" @ %this @ "," @ %newProj @ "," @ %speed @ ");",%speed,%this);
												}
					else							{
					schedule(	"boomQuick(" @ %this @ "," @ %newProj @ "1);",	0.01,	%this);
					schedule("trailEndlessLoop(" @ %this @ "," @ %newProj @ "," @ %speed @ ");",%speed,%this);
												}
									}
										}
		else								{
			GameBase::startFadein(%this);
										}
			}
	else	{}
}

function boom(%this, %newProj)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	
	if (!%player)
		return;
	
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));	
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);

	%pos = %pos1;
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(\"" @ %newProj @ "\", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
}

function boomQuick(%this, %newProj)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	
	if (!%player)
		return;
	
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot,-5));	
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);

	%pos = getWord(%pos1,0) @ " " @ getWord(%pos1,1) @ " " @ getWord(%pos1,2)+1.5;
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(\"" @ %newProj @ "\", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.01);
}

function boomAdv(%this, %newProj)
{
	%cl		= %this.deployer;
	%inc		= %this.inc;
	%dec		= %this.dec;
	%player	= client::getownedobject(%cl);
	%vel		= Item::getVelocity(%this);
	
	if (!%player)
		return;
	
	%pos1		=	gamebase::getposition(%this);
	%bRot		=	(gamebase::getrotation(%this));
	%rot0		=	(getWord(%bRot,0) @ " " @ getWord(%bRot,1) @ " " @ getWord(%bRot,2) + %inc);
	%rot1		=	(getWord(%bRot,0) @ " " @ getWord(%bRot,1) @ " " @ getWord(%bRot,2) + %dec);

	%dir0		=	(Vector::getfromrot(%rot0));
	%dir1		=	(Vector::getfromrot(%rot1));

	%pos = %pos1;

	%trans0	=	(%rot0 @ " " @ %dir0 @ " " @ %rot0 @ " " @ %pos);
	%trans1	=	(%rot1 @ " " @ %dir1 @ " " @ %rot1 @ " " @ %pos);

	schedule ("Projectile::spawnProjectile(\"" @ %newProj @ "\", \"" @ %trans0 @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
	schedule ("Projectile::spawnProjectile(\"" @ %newProj @ "\", \"" @ %trans1 @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
}

function boomTurn1(%this, %newProj)
{
	%cl		= %this.deployer;
	%player	= client::getownedobject(%cl);
	%vel		= Item::getVelocity(%this);
	
	if (!%player)
		return;
	
	%pos		=	gamebase::getposition(%this);
	%bRot		=	(gamebase::getrotation(%this));
	%rot0		=	(getWord(%bRot,0) + 0.56 @ " " @ getWord(%bRot,1) @ " " @ getWord(%bRot,2));

	%dir0		=	(Vector::getfromrot(%rot0));

	%trans0	=	(%rot0 @ " " @ %dir0 @ " " @ %rot0 @ " " @ %pos);

	schedule ("fireAnother(\"" @ %newProj @ "\", \"" @ %trans0 @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.01);
}

function boomTurn2(%this, %newProj)
{
	%cl		= %this.deployer;
	%player	= client::getownedobject(%cl);
	%vel		= Item::getVelocity(%this);
	
	if (!%player)
		return;
	
	%pos		=	gamebase::getposition(%this);
	%bRot		=	(gamebase::getrotation(%this));
	%rot0		=	(getWord(%bRot,0) - 0.56 @ " " @ getWord(%bRot,1) @ " " @ getWord(%bRot,2));

	%dir0		=	(Vector::getfromrot(%rot0));

	%trans0	=	(%rot0 @ " " @ %dir0 @ " " @ %rot0 @ " " @ %pos);

	schedule ("fireAnother(\"" @ %newProj @ "\", \"" @ %trans0 @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.01);
}

function fireAnother(%proj, %trans, %player, %vel)
{
	%fired = (Projectile::spawnProjectile(%proj,%trans,%player,%vel));	%fired.deployer = Gamebase::getOwnerClient(%player);
}

function boomTurn3(%this, %newProj)
{
	%cl		= %this.deployer;
	%player	= client::getownedobject(%cl);
	%vel		= Item::getVelocity(%this);
	
	if (!%player)
		return;
	
	%pos		=	gamebase::getposition(%this);
	%bRot		=	(gamebase::getrotation(%this));
	%rot0		=	(getWord(%bRot,0) - 0.56 @ " " @ getWord(%bRot,1) @ " " @ getWord(%bRot,2));

	%dir0		=	(Vector::getfromrot(%rot0));

	%trans0	=	(%rot0 @ " " @ %dir0 @ " " @ %rot0 @ " " @ %pos);

	schedule ("Projectile::spawnProjectile(\"" @ %newProj @ "\", \"" @ %trans0 @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.01);
}

