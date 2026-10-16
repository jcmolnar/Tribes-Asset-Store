

function PhaseShip(%target, %item, %player)
{
	%loc = %target;
	%vertical = "0 0 700";
	%loc = vector::add(%loc,%vertical);
	echo("Phasing AirStrike Ship In");
      %obj = DropShip::CreateShip("GunShip","gswdrop.dis",%loc);
      GameBase::setTeam(%obj,GameBase::getTeam(%player));
      GameBase::setRotation(%obj ,"0 0 0");
      GameBase::setPosition(%obj ,%loc);
      GameBase::StartFadeIn(%obj);
	DropShip::MoveShip(%obj,4500,"GunShip",%item);
      %obj.inmotion = true;
	%bomber.inmotion = true;
	%bomber2.inmotion = true;
	echo("Fading In");
	schedule("RemovePhaseShip("@%obj@");",240);
}
function DropShip::CreateShip(%name,%shape,%pos)
{
	%obj = newObject(%name,InteriorShape,%shape);
	echo("Created Dropship name: "@ %name @ " object#: " @ %obj);
	addToSet("MissionCleanup/"@%name, %obj);
	return(%obj);
}

function DropShip::MoveShip(%this,%steps,%name,%item)
{	
	//echo(moveship);
	%movement = 0.100000;
	%rotation = 0.000698131;
	%rot = GameBase::GetRotation(%this);
	%rot = Vector::Add(%rot,"0 0 "@%rotation);
	%pos = GameBase::GetPosition(%this);
	%pos = Vector::add(%pos,"0 0 -" @ %movement);
	GameBase::SetPosition(%this,%pos);
	GameBase::SetRotation(%this,%rot);
	%steps--;
	if(%steps > 0)
		schedule("DropShip::MoveShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if(%steps == 0){
		%this.inmotion = "";
		deploybomb(%target, %this);
		}
}

function DropShip::RotateShip(%this,%steps,%name)
{	
	//echo(moveship);
	%rotation = 0.000402768;
	%dip = 0.000202768;
	%rot = GameBase::GetRotation(%this);
	%rot = Vector::Add(%rot,"-"@%dip@" 0 "@%rotation);
	GameBase::SetRotation(%this,%rot);
	%steps--;
	if(%steps > 0)
		schedule("DropShip::RotateShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if(%steps == 0){
		%this.inmotion = "";
		DropShip::ReturnShip(%this, 3900, "GunShip");


		}
}
function DropShip::ReturnShip(%this,%steps,%name)
{	
	$Airstrike = "false";

	//echo(moveship);
	%movement = 0.100000;
      %rotation = 0.000552768;
	%rot = GameBase::GetRotation(%this);
	%rot = Vector::Add(%rot,"0 0 "@%rotation);
	GameBase::SetRotation(%this,%rot);
	%pos = GameBase::GetPosition(%this);
	%pos = Vector::add(%pos,"0 -"@%movement@"+" @ %movement);
	GameBase::SetPosition(%this,%pos);
	%steps--;
	if(%steps > 0)
		schedule("DropShip::ReturnShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if(%steps == 0){
		%this.inmotion = "";
		RemovePhaseShip(%this);

		}
}

function DeathFromAbove(%item,%target)
{
	
	for(%i = 0; %i < 50; %i++)
	{
		%loc = GameBase::getPosition(%item);
		%player = Client::getOwnedObject(%clientId);
		%player = "2048";
		%vel = "0 0 0";
		%vertical = "0 0 600";
		%loc = vector::add(%loc,%vertical);
		%trans = "1.000000 0.000000 0.000000 0.000000 0.000345 -0.999999 0.000000 0.999999 0.000345";
		%trans = %trans @ " " @ %loc;
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("Bshell2",%trans,%target,%vel);
		
	}
}	
function DeathFromAbove2(%target, %item, %player)
{
	
	PhaseShip(%target, %item, %player);

}
function deploybomb(%target, %this)
{
	%loc = GameBase::getPosition(%this);
	%player = Client::getOwnedObject(%clientId);
	%player = "2048";
	%vel = "0 0 0";
	%vertical = "0 0 -2";
	%loc = vector::add(%loc,%vertical);
	%trans = "1.000000 0.000000 0.000000 0.000000 0.000345 -0.999999 0.000000 0.999999 0.000345";
	%trans = %trans @ " " @ %loc;
	%vel = Item::getVelocity(%player);
	

	for(%i = 0; %i < 10; %i++)
	{
		
		Projectile::spawnProjectile("Bshell2",%trans,%target,%vel);
		
	}
	Bomb(%target, %this);


}	
function Bomb(%target, %this)
{
	%loc = GameBase::getPosition(%this);
	%player = Client::getOwnedObject(%clientId);
	%player = "2048";
	%vel = "0 0 0";
	%vertical = "0 0 -2";
	%loc = vector::add(%loc,%vertical);
	%trans = "1.000000 0.000000 0.000000 0.000000 0.000345 -0.999999 0.000000 0.999999 0.000345";
	%trans = %trans @ " " @ %loc;
	%vel = Item::getVelocity(%player);
	

	for(%i = 0; %i < 5; %i++)
	{
		
		Projectile::spawnProjectile("Bshell3",%trans,%target,%vel);
		Projectile::spawnProjectile("Bshell4",%trans,%target,%vel);
		Projectile::spawnProjectile("AirBomb",%trans,%target,%vel);
	}
	DropShip::RotateShip(%this, 3900, "GunShip");
	
}	

exec("watch.cs");