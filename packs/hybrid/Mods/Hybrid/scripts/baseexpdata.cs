ExplosionData RaidmortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 20.0;

   timeScale = 1.500;

   timeZero = 0.250;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  50.0 };
   colors[1]  = { 0.0, 0.0, 50.0 };
   colors[2]  = { 0.0, 0.0, 50.0 };
   radFactors = { 0.0, 0.0, 1.0 };
};

ExplosionData FiremortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 20.0;

   timeScale = 1.500;

   timeZero = 0.250;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData MiniParticleExp
{
   shapeName = "shield.dts";
   soundId   = bigexplosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.9;
   timeScale = 1.6;
   timeZero = 0.200;
   timeOne  = 0.800;
   
   colors[0]  = { 1.0, 0.0, 1.0 };
   colors[1]  = { 1.0, 0.0, 1.0 };
   colors[2]  = { 1.0, 0.0, 1.0 };
   
   radFactors = { 0.0, 1.0, 0.85};
};

ExplosionData ParticleExp
{
   shapeName = "shield_large.dts";
   soundId   = bigexplosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.9;
   timeScale = 1.6;
   timeZero = 0.200;
   timeOne  = 0.800;
   
   colors[0]  = { 1.0, 0.0, 1.0 };
   colors[1]  = { 1.0, 0.0, 1.0 };
   colors[2]  = { 1.0, 0.0, 1.0 };
   
   radFactors = { 0.0, 1.0, 0.85};
};

ExplosionData plasmaBBExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.9;
   timeScale = 1.6;
   timeZero = 0.200;
   timeOne  = 0.800;
   
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   
   radFactors = { 0.0, 1.0, 0.85};
};

ExplosionData StormhammerExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0, 0, 50.0 };
   colors[1]  = { 0, 0, 50.0 };
   colors[2]  = { 0, 0, 50.0 };
   radFactors = { 0, 0, 5.0 };
};

ExplosionData NitroExp
{
   shapeName = "bluex.dts";
   soundId   = bigexplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 50, 0, 0.0 };
   colors[1]  = { 50, 0, 0.0 };
   colors[2]  = { 50, 0, 0.0 };
   radFactors = { 5.0, 0.0, 0.0 };
};

ExplosionData PartRedExp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 50.0, 0.0, 0.0 };
   colors[1]  = { 50.0, 0.0, 0.0 };
   colors[2]  = { 50.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.0, 0.0 };

   shiftPosition = True;
};

ExplosionData PartBlueExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.0, 50.0 };
   colors[1]  = { 0.0, 0.0, 50.0 };
   colors[2]  = { 0.0, 0.0, 50.0 };
   radFactors = { 0.0, 0.0,  1.0 };

   shiftPosition = True;
};

ExplosionData PartGreenExp
{	shapeName = "paint.dts";
	soundId = energyExplosion;
	faceCamera = true;
	randomSpin = false;
	hasLight = true;
	lightRange = 1.5;
	
	timeZero = 0.450;
	timeOne = 0.750;
	colors[0] = { 0.0, 50.0, 0.0 };
	colors[1] = { 0.0, 50.0, 0.0 };
	colors[2] = { 0.0, 50.0, 0.0 };
	radFactors = { 0.0, 1.0, 0.0 };
};

ExplosionData ClashExp
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData ShockJetExp
{
   shapeName = "enex.dts";	
   soundId = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;
   timeScale = 10;
   timeZero = 0.100;	//0.450;
   timeOne  = 0.150;	//0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

ExplosionData ShockedDamageExp
{
   shapeName = "fusionex.dts";	
   //soundId = shockExplosion;	
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.00;
   timeOne  = 0.100;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData RipperbulletExp
{
   shapeName = "plasmatrail.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
ExplosionData RipperbulletExp2
{
   shapeName = "plasmatrail.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
ExplosionData RipperbulletExp3
{
   shapeName = "plasmatrail.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData Blaze1Exp
{
   shapeName = "plasmabolt.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1;

   timeScale = 0.3;


   colors[0]  = { 0.4, 0.4,  0.2 };
   colors[1]  = { 1.0, 0.0,  0.0 };
   colors[2]  = { 0.8, 0.2, 0.2 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData Blaze2Exp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1;

   timeScale = 0.7;


   colors[0]  = { 0.4, 0.4,  0.2 };
   colors[1]  = { 1.0, 0.0,  0.0 };
   colors[2]  = { 0.8, 0.2, 0.2 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData TacticalExhaustExp
{
   shapeName = "rsmoke.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 50.0, 0.0 };
   colors[1]  = { 0.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 5.0, 5.0 };

   shiftPosition = true;
};

ExplosionData ToxicShock1Exp
{
   shapeName = "plastrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 50.0, 0.0 };
   colors[1]  = { 0.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 5.0, 5.0 };

   shiftPosition = true;
};

ExplosionData ToxicShock2Exp
{
   shapeName = "mortartrail.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 50.0 };
   colors[1]  = { 0.0, 0.0, 50.0 };
   colors[2]  = { 0.0, 0.0, 50.0 };
   radFactors = { 0.0, 0.0, 2.0 };

   shiftPosition = True;
};

ExplosionData SalvorocketExp
{
   shapeName = "fiery.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  0.2 };
   colors[1]  = { 1.0, 0.0,  0.0 };
   colors[2]  = { 0.8, 0.2, 0.2 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData InvulExp 
{ 
	shapeName = "shotgunex.dts"; 
	faceCamera = true; 
	randomSpin = true; 
	hasLight = true; 
	lightRange = 4.0; 
	timeScale = 0.3; 
	colors[0] = { 50.0, 0.0, 0.0 }; 
	colors[1] = { 50.0, 0.0, 0.0 }; 
	colors[2] = { 50.0, 0.0, 0.0 }; 
	radFactors = { 4.0, 0.0, 0.0 }; 
};

ExplosionData HybridGExp
{
   shapeName = "fiery.dts";
   soundId   = SoundJetidle;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 4.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData Shot3Exp 
{
	shapeName = "rsmoke.dts";
	soundId = ricochet2;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};

ExplosionData MrocketExp
{
   shapeName = "fiery.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  0.2 };
   colors[1]  = { 1.0, 0.0,  0.0 };
   colors[2]  = { 0.8, 0.2, 0.2 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData beaconExp
{
   shapeName = "breath.dts";
   //soundId   = SoundBeaconUse;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0.0, 2.0  };
   colors[1]  = { 0, 0.0, 2.0 };
   colors[2]  = { 0, 0.0, 2.0 };
   radFactors = { 2.0, 1.0, 1.0 };
};

ExplosionData WebExp
{
   shapeName = "fusionex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 5.25, 0.0 };
   colors[1]  = { 0.0, 5.25, 0.0 };
   colors[2]  = { 0.0, 5.25, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData FusionTurretXExp
{
   shapeName = "paint.dts";
   soundId   = SoundBeaconUse;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0.0, 2.0  };
   colors[1]  = { 0, 0.0, 2.0 };
   colors[2]  = { 0, 0.0, 2.0 };
   radFactors = { 2.0, 1.0, 1.0 };
};

ExplosionData MitziExpL
{
   shapeName = "flash_large.dts";
   soundId   = SoundFliercrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData FuzionRifleExp
{
   shapeName = "shotgunex.dts";
   soundId   = SoundBeaconUse;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 5.0  };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.0, 0.0, 5.0 };
   radFactors = { 0.0, 0.0, 3.0 };
};

ExplosionData AnarchyRifleExp
{
   shapeName = "fusionex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 5.0  };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.0, 0.0, 5.0 };
   radFactors = { 0.0, 0.0, 4.0 };
};

ExplosionData BlasterXExp
{
   shapeName = "shotgunex.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 50.0, 0.0, 0.0  };
   colors[1]  = { 50.0, 0.0, 0.0 };
   colors[2]  = { 50.0, 0.0, 0.0 };
   radFactors = { 2.0, 0.0, 0.0 };
};

ExplosionData VulcanrocketExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.0, 0.0,  100.0 };
   colors[1]  = { 0.0, 0.0,  100.0 };
   colors[2]  = { 0.0, 0.0, 100.0 };
   radFactors = { 0.0, 0.0, 2.0 };
};

ExplosionData rocketExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData smokerExp
{
   shapeName = "smoke.dts";
   soundId   = SoundFlierCrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0.1;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};


ExplosionData M102Exp
{
   shapeName = "shockwave.dts";
   soundId   = SoundFlierCrash;

   faceCamera = true;
   randomSpin = true;
   //hasLight   = true;
   lightRange = 0.1;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};
//--------------------------------------
ExplosionData ExSmScreenExp
{
   shapeName = "bluex.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeScale = 2;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

//--------------------------------------
ExplosionData SmScreenExp
{
   shapeName = "bluex.dts";
   soundId   = soundwindgust;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeScale = 31;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 31, 31, 31 };
};
//--------------------------------------
ExplosionData TimeBombExp1
{
   shapeName = "mortarex.dts";
   soundId   = BigExplosion1;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData TimeBombExp2
{
   shapeName = "shockwave_large.dts";
   soundId   = BigExplosion1;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};
//--------------------------------------
ExplosionData VXGasAttackExp
{
   shapeName = "bluex.dts";
   soundId   = soundwindgust;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeScale = 31;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 31, 31, 31 };
};
//--------------------------------------
ExplosionData MiniSmokeExp
{
   shapeName = "bluex.dts";
   soundId   = soundwindgust;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 1;

   timeScale = 11;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

//--------------------------------------
ExplosionData LiLFFBExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
//   faceCamera = true;
//   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 0.0 };
   colors[1]  = { 1.0, 0.0, 1.0 };
   colors[2]  = { 1.0, 0.75, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData armExp
{
   shapeName = "plasmatrail.dts";
   soundId   = SoundSwordExplo;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

ExplosionData energyExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

ExplosionData blasterExp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData plasmaExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData plasmaCExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData PhaserRifleExplosion
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData BioExp
{
   shapeName = "mortartrail.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 50.0, 0.0 };
   colors[1]  = { 0.0, 50.0, 0.0 };
   colors[2]  = { 0.0, 50.0, 0.0 };
   radFactors = { 0.0, 5.0, 0.0 };
};

ExplosionData BioExp2
{
   shapeName = "tumult_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 50.0, 0.0 };
   colors[1]  = { 0.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 5.0, 5.0 };
};

ExplosionData grenadeExp
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeScale = 3.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData mineExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData SludgeExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
//   faceCamera = true;
//   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 50.0, 0.0 };
   colors[1]  = { 0.0, 50.0, 0.0 };
   colors[2]  = { 0.0, 50.0, 0.0 };
   radFactors = { 0.0, 5.0, 0.0 };
};

ExplosionData mortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 15.0;

   timeScale = 1.500;

   timeZero = 0.250;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 0.3, 1.0, 0.3 };
   colors[2]  = { 0.0, 0.7, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData turretExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData MortSplitExp
{
   shapeName = "mortartrail.dts";
   //soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData ShardExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.0, 5.0 };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.0,  0.0,  5.0 };
   radFactors = { 0.0, 0.0, 1.0 };
};

ExplosionData bulletExp7
{
   shapeName = "laserhit.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp1
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp2
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData HybridExp
{
   shapeName = "plasmatrail.dts";
   soundId   = explosion5;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0.5;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 2.0, 1.2,  0.0 };
   colors[1]  = { 2.0, 1.2, 0.0 };
   colors[2]  = { 2.0, 1.2, 0.0 };
   radFactors = { 2.0, 1.2, 0.0 };
};

ExplosionData HybridCExp
{
   shapeName = "plasmabolt.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0.5;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 2.0, 1.2,  0.0 };
   colors[1]  = { 2.0, 1.2, 0.0 };
   colors[2]  = { 2.0, 1.2, 0.0 };
   radFactors = { 2.0, 1.2, 0.0 };
};

ExplosionData PopcornExp
{
   shapeName = "flash_large.dts";
   soundId   = bigexplosion1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

///////////////////////////////////////////
ExplosionData debrisExpSmall
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpMedium
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpLarge
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisEoxpmedium
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpSmall
{
   shapeName = "flash_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpMedium
{
   shapeName = "flash_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.75;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpLarge
{
   shapeName = "flash_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Shockwave
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData LargeShockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData FusionCannonExplosion
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;

   timeZero = 0.100;
   timeOne  = 0.800;

   colors[0]  = { 1.0, 0.3, 0.0 };
   colors[1]  = { 1.0, 0.3, 0.0 };
   colors[2]  = { 0.0, 0.3, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData ShotExp 
{	shapeName = "smoke.dts";
	soundId = ricochet3;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};

ExplosionData SXHShotExp1 
{	shapeName = "rsmoke.dts";
	soundId = ricochet1;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};

ExplosionData SXHShotExp2 
{	shapeName = "rsmoke.dts";
	soundId = ricochet2;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};

ExplosionData SXHShotExp3 
{	shapeName = "rsmoke.dts";
	soundId = ricochet3;
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	shiftPosition = false;
};

ExplosionData PhaseDisrupterExp
{	shapeName = "shockwave_large.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 10.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0] = { 5.0, 6.0, 6.0 };
	colors[1] = { 1.0, 1.0, 9.0 };
	colors[2] = { 4.0, 6.0, 3.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData FlameExp
{	shapeName = "fiery.dts";
	soundId = bigExplosion3;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 10.0;
	timeScale = 1.0;
	timeZero = 0.150;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0,  0.0 };
	colors[1] = { 1.0, 0.63, 0.0 };
	colors[2] = { 1.0, 0.63, 0.0 };
	radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SmokeFade
{	shapeName = "breath.dts";
	faceCamera = false;
	randomSpin = false;
	hasLight = true;
	lightRange = 0.0;
	timeScale = 1.5;
	timeZero = 0;
	timeOne = 1;
	colors[0] = { 0.4, 0.4,  1.0 };
	colors[1] = { 1.0, 1.0,  1.0 };
	colors[2] = { 1.0, 0.95, 1.0 };
	radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData BlastExp0
{
	shapeName = "tumult_medium.dts";
	soundId = debrisMediumExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 1.5;
	timeZero = 0.250;
	timeOne = 0.850;
	colors[0]  = { 0.0, 0.0,  0.0 };
   	colors[1]  = { 1.0, 0.63, 0.0 };
   	colors[2]  = { 1.0, 0.63, 0.0 };
   	radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData disexp
{	shapeName = "paint.dts";
	soundId = energyExplosion;
	faceCamera = true;
	randomSpin = false;
	hasLight = true;
	lightRange = 5.0;
	timeScale = 2.5;
	timeZero = 0;
	timeOne = 2.5;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData fireExp
{	shapeName = "plasmaex.dts";
	soundId = bigExplosion2;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeZero = 0.200;
	timeOne = 0.950;
	colors[0] = { 1.0, 1.0,  0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};


ExplosionData FDExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData FlierExplosion
{
   shapeName = "shockwave_large.dts";
   soundId   = SoundTankCrash;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.3;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

//-----------------------------------
// EMP Pulse Explosion 
//-----------------------------------

ExplosionData EMPPulseExp
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 40.0;

   timeScale = 0.3;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 50.0 };
   colors[1]  = { 0.0, 0.0, 50.0 };
   colors[2]  = { 0.0, 0.0, 50.0 };
   radFactors = { 1.0, 1.5, 2.0 };
};

ExplosionData PulseExp
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 40.0;

   timeScale = 0.3;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};



ExplosionData ionExp
{
   shapeName = "fiery.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData ionExp_2
{
   shapeName = "shockwave_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData ionExp_3
{
   shapeName = "shockwave.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData HavocExp
{
   shapeName = "plastrail.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 1.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.3 };
};

ExplosionData ionExp_5
{
   shapeName = "tumult_small.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};


ExplosionData BExp
{
   shapeName = "breath.dts";
   soundId   = sounddiscspin;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData Boltexp1
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData boltexp2
{
   shapeName = "flash_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData boltexp3
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData boltexp4
{
   shapeName = "flash_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.75;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData boltexp5
{
   shapeName = "tumult_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData boltexp6
{
   shapeName = "flash_large.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Exp0
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData Exp1
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Exp2
{
   shapeName = "flash_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;

   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData BulletExp3
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData LameflameExp
{
   shapeName = "tumult_large.dts";
   soundId   = "soundjetidle";

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData fliceExp
{
   shapeName = "rsmoke.dts";
//   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 7;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData SniperXExp
{	shapeName		= "shockwave.DTS";
	soundId			=  bigexplosion1;
	faceCamera		= true;
	randomSpin		= true;
	hasLight		= true;
	lightRange		= 5.0;
	timeZero		= 0.100;
	timeOne			= 0.900;
	colors[0]		= {0.0,0.0,0.0};
	colors[1]		= {1.0,1.0,0.5};
	colors[2]		= {0.0,1.0,0.0};
	radFactors		= {0.0,1.0,0.0};
	shiftPosition	= False;
};

ExplosionData smokegrenadeExp
{
   shapeName = "dustplume.dts";
   soundId   = SoundFlierCrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 10.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData M10Exp
{
   shapeName = "tumult_small.dts";
   soundId   = SoundFlierCrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 10.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData fireExp78
{
   shapeName = "plasmaex.dts";
   soundId   = SoundJetidle;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 4.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData fire1Exp
{
   shapeName = "plastrail.dts";
   soundId   = SoundJetidle;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 4.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData fire2Exp
{
   shapeName = "plasmabolt.dts";
   soundId   = SoundJetidle;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 4.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData fire3Exp
{
   shapeName = "fiery.dts";
   soundId   = SoundPlayerDeath;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 4.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData napExp 
{    
	shapeName = "fiery.dts";
	soundId   = explosion4;
	faceCamera = true;  
	randomSpin = true;   
	hasLight   = true;   
	lightRange = 35.0; 
	timeScale = 8.0;  
	timeZero = 0.200;  
	timeOne  = 0.950;  
	colors[0]  = { 1.0, 1.0,  0.0 };
	colors[1]  = { 1.0, 0.4, 0.0 };
	colors[2]  = { 1.0, 0.0, 0.0 };
	radFactors = { 0.8, 0.9, 1.0 };
};

ExplosionData fakeExp 
{  
	shapeName = "breath.dts"; 
	faceCamera = true;  
	randomSpin = true;  
	hasLight   = false;  
	lightRange = 0;    
	timeZero = 0.100;   
	timeOne  = 0.500;  
	colors[0]  = { 0.0, 0.0, 0.0 }; 
	colors[1]  = { 1.0, 1.0, 0.5 }; 
	colors[2]  = { 1.0, 1.0, 0.5 };  
	radFactors = { 0.0, 1.0, 0.0 };  
	shiftPosition = False;
}; 

ExplosionData puffEx
{   
	shapeName = "mortarex.dts"; 
	soundId   = shockExplosion; 
	faceCamera = true;  
	randomSpin = true;  
	hasLight   = false;  
	lightRange = 0;  
	timeScale = 15.0;   
	timeZero = 0.0;   
	timeOne  = 0.500; 
	colors[0]  = { 1.0, 1.0, 1.0 }; 
	colors[1]  = { 1.0, 1.0, 0.2 };
	colors[2]  = { 1.0, 1.0, 0.0 }; 
	radFactors = { 1.0, 1.0, 1.0 };
};
ExplosionData ShockwaveTwo
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;
   timeScale = 5.0;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 5.0, 4.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 1.0, 1.0, 3.0 };
};

ExplosionData ShockwaveThree
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 25.0;
   timeScale = 1.0;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 5.0, 4.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 0.1, 0.1, 3.0 };
};

ExplosionData ShockwaveFour
{
   shapeName = "shield_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;
   timeScale = 0.5;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 0.0, 0.0, 3.0 };
};

ExplosionData TeleportExp
{
   shapeName = "fusionex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 1;

   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData nappyExp
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 35.0;

   timeScale = 4.5;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.4, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 0.8, 0.9, 0.5 };
};

ExplosionData HYblastExp
{
   shapeName = "plasmabolt.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 16.0;

   timeZero = 0;
   timeOne  = 1;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

$NMABD = 10;

function NuclearExplosion(%pos)
{
	%obj = newObject("","Mine","NRad");
	addToSet("MissionCleanup", %obj); //-Core
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing1");
	addToSet("MissionCleanup", %obj); //-Horiz Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing2");
	addToSet("MissionCleanup", %obj); //-Vert Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing3");
	addToSet("MissionCleanup", %obj); //-Final Ring
	GameBase::setPosition(%obj,%pos);

	for(%i = 0; %i < 6.28; %i += 1.256) {
		%NewPos1 = Vector::add(%pos, Vector::getFromRot(%i@" 0 0",$NMABD, 0.0));  // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos2 = Vector::add(%pos, Vector::getFromRot("0 "@%i@" 0",0.0,$NMABD)); // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos3 = Vector::add(%pos, Vector::getFromRot("0 0 "@%i,0.0,$NMABD));   // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%obj1 = newObject("","Mine","NAfter");
		%obj2 = newObject("","Mine","NAfter");
		%obj3 = newObject("","Mine","NAfter");
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		addToSet("MissionCleanup",%obj3);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
		GameBase::setPosition(%obj3,%NewPos3);
	}
}

function PowerExplosion(%pos)
{
	%obj = newObject("","Mine","GRad");
	addToSet("MissionCleanup", %obj); //-Core
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing1");
	addToSet("MissionCleanup", %obj); //-Horiz Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing2");
	addToSet("MissionCleanup", %obj); //-Vert Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing3");
	addToSet("MissionCleanup", %obj); //-Final Ring
	GameBase::setPosition(%obj,%pos);

	for(%i = 0; %i < 6.28; %i += 1.256) {
		%NewPos1 = Vector::add(%pos, Vector::getFromRot(%i@" 0 0",$NMABD, 0.0));  // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos2 = Vector::add(%pos, Vector::getFromRot("0 "@%i@" 0",0.0,$NMABD)); // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos3 = Vector::add(%pos, Vector::getFromRot("0 0 "@%i,0.0,$NMABD));   // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%obj1 = newObject("","Mine","GRad");
		%obj2 = newObject("","Mine","GRad");
		%obj3 = newObject("","Mine","GRad");
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		addToSet("MissionCleanup",%obj3);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
		GameBase::setPosition(%obj3,%NewPos3);
	}
}

//==================================================================================================== Nuclear Explosion

ExplosionData NAfterExp
{
	shapeName = "plasmaex.dts";
	//soundId   = SoundLaserHit;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne  = 0.750;
	colors[0]  = { 0.25, 0.25, 1.0 };
	colors[1]  = { 0.25, 0.25, 1.0 };
	colors[2]  = { 1.0,  1.0,  1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData LargeShockwave2
{
	shapeName = "shockwave_large.dts";
	soundId   = shockExplosion;
	faceCamera = true;
	randomSpin = false;
	hasLight   = true;
	lightRange = 10.0;
	timeZero = 0.100;
	timeOne  = 0.400;
	colors[0]  = { 1.0, 1.0, 1.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData LargeShockwave3
{
	shapeName = "shockwave_large.dts";
	//soundId   = shockExplosion; //- Silent AfterWave
	faceCamera = false;
	randomSpin = true;
	hasLight   = true;
	lightRange = 10.0;
	timeZero = 0.0;
	timeOne  = 0.500;
	colors[0]  = { 1.0, 1.0, 1.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 0.0, 0.0, 0.0 };
	radFactors = { 0.0, 1.0, 1.0 };
};

//==================================================================================================== Nuclear Explosion

MineData NRad
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = plasmaExp;
        explosionRadius = 25;
        damageValue = 1.0;
	damageType = $NukeDamageType;
        kickBackStrength = 100;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 50.0;
        damageValue = 1.0;
	damageType = $NukeDamageType;
        kickBackStrength = 450;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave2;
        explosionRadius = 15.0;
        damageValue = 1.0;
	damageType = $NukeDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
	explosionId = LargeShockwave3;
	explosionRadius = 15.0;
        damageValue = 0.65;
	damageType = $NukeDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.01;
	maxDamage = 20.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NAfter
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = NAfterExp;
        explosionRadius = 5.0;
        damageValue = 0.65;
	damageType = $NukeDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

//- so far 0.08 is the earliest able to detonate a spawned mine
//- NRad should detonate all other mines in the center except NRing3, intentionally
function NRad::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.08,%this);
}
//- NRing3 is a final ring effect so call it last
function NRing3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}
function NAfter::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

MineData GRad
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
	explosionId = turretExp;
	//explosionId = blasterExp;
	//explosionId = ShieldExp;
	//explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $UltraGodDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing1
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $UltraGodDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing2
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave2;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $UltraGodDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing3
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave3;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $UltraGodDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function GRad::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function GRing1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function GRing2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}
function GRing3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

//==================================================================================================== Suicide Pack 2 On Deploy

MineData MBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 100.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function MBomb::onAdd(%this)
{
	schedule("NuclearExplosion("@%this@");",20,%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate("@%this@");",30,%this);
}

function MBomb::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player"||Player::isDead(%obj))
		return;
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%armor == "sarmor" || %armor == "sfemale") {
		%rnd = floor(getRandom() * 10);
		if(%rnd > 7) {	
			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(%this);
			return;
		}
		else {
			deleteObject(%this);
			Client::sendMessage(%c,1,"You disarm the DetPack.");
		}
	}
	else {
		Client::sendMessage(%c,1,"Only Specialist can disarm Bombs!");
		%rnd = floor(getRandom() * 10);
		if(%rnd > 5) {			
			Client::sendMessage(%c,1,"You triggered the Bomb!");
			Mine::Detonate(" @ %this @ ");
		}
		else
			Client::sendMessage(%c,1,"You didn't trigger the Bomb!");

	}
}