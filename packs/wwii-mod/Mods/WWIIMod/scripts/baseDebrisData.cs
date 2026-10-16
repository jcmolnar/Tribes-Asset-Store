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
   
   mass       = 10.0;
   elasticity = 0.5;
   friction   = 0.9;
   center     = { 0, 0, 0 };

  // collisionMask = 1;    // default is Interior | Terrain, which is what we want
  // knockMask     = 0;

   animationSequence = -1;

   minTimeout = 140.0;
   maxTimeout = 240.0;

   explodeOnBounce = 0.000001;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 200;
   spawnedDebrisRadius   = 3;
	 
   p = 1;
   spawnedExplosionID = noexp;

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

DebrisData playerDebris
{
   type      = 0;
   imageType = 0;
   
   mass       = 10.0;
   elasticity = 0.5;
   friction   = 0.9;
   center     = { 0, 0, 0 };

  // collisionMask = 1;    // default is Interior | Terrain, which is what we want
 //  knockMask     = 0;

   animationSequence = -1;

   minTimeout = 140.0;
   maxTimeout = 240.0;

   explodeOnBounce = 0.000001;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 140;
   spawnedDebrisRadius   = 0.8;
	 
   p = 1;
spawnedExplosionID = BlasterExp;
   explodeOnRest   = true;
   collisionDetail = 0;
};

DebrisData VehicleDebris
{
   type      = 0;
   imageType = 0;
   
   mass       = 10.0;
   elasticity = 0.5;
   friction   = 0.9;
   center     = { 0, 0, 0 };

   //collisionMask = 1;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 140.0;
   maxTimeout = 240.0;

   explodeOnBounce = 0.000001;

   damage          = 1000.0;
   damageThreshold = 100.0;
spawnedExplosionID = flashExpLarge;
   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 140;
   spawnedDebrisRadius   = 0.8;

   p = 1;

   explodeOnRest   = true;
   collisionDetail = 0;
};


