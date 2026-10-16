//========================= Explosion Data
ExplosionData FireworkExp1
{
   shapeName = "plasmaex.dts";
   soundId   = shockExplosion;

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = TRUE;
   lightRange = 5.0;
	 timeScale = 2.5;
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };

   shiftPosition = TRUE;
};

ExplosionData FireworkExp2
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = TRUE;
   lightRange = 5.0;
	 timeScale = 3.5;
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};


ExplosionData FireworkExp3
{
   shapeName = "shotgunex.dts";

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = TRUE;
   lightRange = 5.0;
	 timeScale = 2.5;
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData FLFX1
{
   shapeName = "enex.dts";
   //soundId   = NoSound;

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = False;
   lightRange = 3.0;
   
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = TRUE;
};