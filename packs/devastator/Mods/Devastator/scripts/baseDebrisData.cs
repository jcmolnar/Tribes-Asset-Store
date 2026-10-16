DebrisData defaultDebrisSmall
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpSmall;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData defaultDebrisMedium
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpMedium;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData defaultDebrisLarge
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = debrisExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisSmall
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpSmall;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisMedium
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpMedium;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData flashDebrisLarge
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.25;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.3;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.2;

   spawnedExplosionID = flashExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

DebrisData PilotDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = ShieldExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData PantherDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = turretExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData SniperDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = blasterExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData playerDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.3;

	damage          = 1000.0;
	damageThreshold = 100.0;

	spawnedDebrisMask     = 1;
	spawnedDebrisStrength = 90;
	spawnedDebrisRadius   = 0.2;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData BreathDebris
{
	type      = 0;
	imageType = 0;
	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };
	animationSequence = -1;
	minTimeout = 3.0;
	maxTimeout = 6.0;
	explodeOnBounce = 0.3;
	damage          = 0.0;
	damageThreshold = 0.0;
	spawnedDebrisMask     = 1;
	spawnedDebrisStrength = 0;
	spawnedDebrisRadius   = 0;
	p = 1;
	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData plasmaDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.3;

	damage          = 1000.0;
	damageThreshold = 100.0;

	spawnedDebrisMask     = 1;
	spawnedDebrisStrength = 90;
	spawnedDebrisRadius   = 0.2;

	spawnedExplosionID = plasmaExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData HeavyDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = BreathExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData TitanDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = SmokeExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};

DebrisData PsychoDebris
{
	type      = 0;
	imageType = 0;

	mass       = 100.0;
	elasticity = 0.25;
	friction   = 0.5;
	center     = { 0, 0, 0 };

	animationSequence = -1;

	minTimeout = 3.0;
	maxTimeout = 6.0;

	explodeOnBounce = 0.4;

	damage          = 99.0;
	damageThreshold = 99.0;

	spawnedDebrisMask     = 2;
	spawnedDebrisStrength = 99;
	spawnedDebrisRadius   = 0.7;

	spawnedExplosionID = mortartrailExp;

	p = 1;

	explodeOnRest   = True;
	collisionDetail = 0;
};
