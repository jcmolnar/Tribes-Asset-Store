// PORT 2026-10-12: the original TFunc.cs is NOT in the only surviving archive (Talon_2.1.zip).
// Without TFunc::ArtificialOffset the Swarmer, the quad plasma pistol and the plasma mode passed an
// EMPTY transform to Projectile::spawnProjectile; the rocket spawned at a garbage position and froze
// every client that received it. This stub returns the muzzle transform unchanged (no spread).
// The other TFunc:: helpers (Rand, GetRandomOffset, SpawnFX) are effects and stay undefined.
function TFunc::ArtificialOffset(%obj, %trans, %amount)
{
	return %trans;
}
