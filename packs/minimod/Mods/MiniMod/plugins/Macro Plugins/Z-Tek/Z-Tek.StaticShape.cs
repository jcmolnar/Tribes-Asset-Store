// This is a MiniMod plugin.
// This is the PhaseLok+SheildGens Pack from the Z-Tek mod. Ported by Dewy.

StaticShapeData PhaseLokStand
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "PhaseLok Turret";
};

function AntiMatterStand::onDestroyed(%this) {}

function AntiMatterStand::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($MM::PhaseLokTurretID[%this])
		Turret::onDamage($MM::PhaseLokTurretID[%this],%type,%value * 0.75,%pos,%vec,%mom,%object);

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

