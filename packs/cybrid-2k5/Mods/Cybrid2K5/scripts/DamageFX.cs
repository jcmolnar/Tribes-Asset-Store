//$NuclearDamageType     = 13;
//$ThermalDamageType     = 14;
//====================================------------------
// Energy Damage FX
//====================================------------------
function Armor::onEnergy(%client, %player)
{	
	
	if (!%player.onEnergy) 
	{
		EnergyShock(%player);	
	}
	%player.onEnergy = 200;
}



function EnergyShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onEnergy = %player.onEnergy -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onEnergy > 70 )
		Projectile::spawnProjectile("EnergyFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("EnergyFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onEnergy)
		schedule("EnergyShock("@%player@");",0.1);
	
}
//====================================------------------
// Fusion Damage FX
//====================================------------------
function Armor::onFusion(%client, %player)
{	
	
	if (!%player.onFusion) 
	{
		FusionShock(%player);	
	}
	%player.onFusion = 200;
}



function FusionShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onFusion = %player.onFusion -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onFusion > 70 )
		Projectile::spawnProjectile("FusionFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("FusionFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onFusion)
		schedule("FusionShock("@%player@");",0.1);
	
}
//====================================------------------
// Pulse Damage FX
//====================================------------------
function Armor::onPulse(%client, %player)
{	
	
	if (!%player.onPulse) 
	{
		PulseShock(%player);	
	}
	%player.onPulse = 200;
}



function PulseShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onPulse = %player.onPulse -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onPulse > 70 )
		Projectile::spawnProjectile("PulseFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("PulseFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onPulse)
		schedule("PulseShock("@%player@");",0.1);
	
}
//====================================------------------
// Radiation Damage FX
//====================================------------------
function Armor::onRadiation(%client, %player)
{	
	
	if (!%player.onRadiation) 
	{
		RadiationShock(%player);	
	}
	%player.onRadiation = 200;
}



function RadiationShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onRadiation = %player.onRadiation -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onRadiation > 70 )
		Projectile::spawnProjectile("RadiationFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("RadiationFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onRadiation)
		schedule("RadiationShock("@%player@");",0.1);
	
}
//====================================------------------
// AntiMatter Damage FX
//====================================------------------
function Armor::onAntiMatter(%client, %player)
{	
	
	if (!%player.onAntiMatter) 
	{
		AntiMatterShock(%player);	
	}
	%player.onAntiMatter = 200;
}



function AntiMatterShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onAntiMatter = %player.onAntiMatter -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onAntiMatter > 70 )
		Projectile::spawnProjectile("AntiMatterFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("AntiMatterFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onAntiMatter)
		schedule("AntiMatterShock("@%player@");",0.1);
	
}
//====================================------------------
// ION Damage FX
//====================================------------------
function Armor::onION(%client, %player)
{	
	
	if (!%player.onION) 
	{
		IONShock(%player);	
	}
	%player.onION = 200;
}



function IONShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onION = %player.onION -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onION > 70 )
		Projectile::spawnProjectile("IONFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("IONFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onION)
		schedule("IONShock("@%player@");",0.1);
	
}
//====================================------------------
// Bullet Damage FX
//====================================------------------
function Armor::onBullet(%client, %player)
{	
	
	if (!%player.onBullet) 
	{
		BulletShock(%player);	
	}
	%player.onBullet = 200;
}



function BulletShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onBullet = %player.onBullet -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onBullet > 70 )
		Projectile::spawnProjectile("BulletFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("BulletFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onBullet)
		schedule("BulletShock("@%player@");",0.1);
	
}
//====================================------------------
// Fire Damage FX
//====================================------------------
function Armor::onFire(%client, %player)
{	
	
	if (!%player.onFire) 
	{
		FireShock(%player);	
	}
	%player.onFire = 200;
}



function FireShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onFire = %player.onFire -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onFire > 70 )
		Projectile::spawnProjectile("FireFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("FireFX2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onFire)
		schedule("FireShock("@%player@");",0.1);
	
}
//====================================------------------
// EMP Damage FX
//====================================------------------
function Armor::onEMP(%client, %player)
{	
	
	if (!%player.onEMP) 
	{
		EMPShock(%player);	
	}
	%player.onEMP = 200;
}



function EMPShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onEMP = %player.onEMP -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onEMP > 70 )
		Projectile::spawnProjectile("EMPFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("EMPFX1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onEMP)
		schedule("EMPShock("@%player@");",0.1);
	
}