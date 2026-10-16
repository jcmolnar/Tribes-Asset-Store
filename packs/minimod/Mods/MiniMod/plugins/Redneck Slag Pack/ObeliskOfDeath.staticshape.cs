// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Death" (Anti-matter Turret) from
// the Redneck Slag Pack mod. Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ObeliskOfDeath.ArmorData.cs
//    ObeliskOfDeath.baseProjData.cs
//    ObeliskOfDeath.item.cs
//    ObeliskOfDeath.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    ObeliskOfDeath.station.cs
//    ObeliskOfDeath.turret.cs
//
// to your MiniMod/plugins directory.

StaticShapeData AntiMatterStand
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 10.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Obelisk of Death";
};

function AntiMatterStand::onDestroyed(%this) {}

function AntiMatterStand::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($RSP::AntiMatterTurretID[%this])
		Turret::onDamage($RSP::AntiMatterTurretID[%this],%type,%value * 0.75,%pos,%vec,%mom,%object);

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}
