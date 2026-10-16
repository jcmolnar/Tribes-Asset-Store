ExplosionData MissileExp
{
   shapeName = "bluex.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Plasmabolt4Exp
{
   shapeName = "fiery.dts";
   soundId   = SoundJetTemp;

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

ExplosionData FDExp
{
   shapeName = "fiery.dts";
   soundId   = SoundJetTemp;

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

ExplosionData ShriekExp
{
	shapeName = "tumult_medium.dts";
	soundId   = bigexplosion4;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 5.0;
	timeScale = 1.5;
	timeZero = 0.150;
	timeOne  = 0.500;

	colors[0]  = { 0.0, 5.0, 5.0 };
	colors[1]  = { 0.0, 5.0, 5.0 };
	colors[2]  = { 0.0, 5.0, 5.0 };
	radFactors = { 0.0, 5.0, 5.0 };
};

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
	timeOne  = 0.300;
	colors[0]  = { 1.0, 1.0, 1.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData LargeShockwave3
{
	shapeName = "shockwave_large.dts";
	soundId   = shockExplosion;
	faceCamera = false;
	randomSpin = true;
	hasLight   = true;
	lightRange = 10.0;
	timeZero = 0;
	timeOne  = 500;
	colors[0]  = { 1.0, 1.0, 1.0 };
	colors[1]  = { 1.0, 1.0, 1.0 };
	colors[2]  = { 0.0, 0.0, 0.0 };
	radFactors = { 1.5, 1.5, 1.5 };
};

ExplosionData BoosterExp 
{ 
	shapeName = "plastrail.dts"; 
	faceCamera = true; 
	randomSpin = true; 
	hasLight = true; 
	lightRange = 4.0; 
	timeScale = 0.6; 
	colors[0] = { 1.0, 1.0, 0.0 }; 
	colors[1] = { 1.0, 1.0, 0.75 }; 
	colors[2] = { 1.0, 1.0, 0.75 }; 
	radFactors = { 0.375, 1.0, 0.9 }; 
};

ExplosionData PoisonExp
{
   shapeName = "mortartrail.dts";
   soundId   = SoundPlayerDeath;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 0.3, 1.0, 0.3 };
   colors[2]  = { 0.0, 0.7, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData flareExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 6.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 2.0, 0.0 };
   colors[1]  = { 0.0, 2.0, 0.0 };
   colors[2]  = { 0.0, 2.0, 0.0 };
   radFactors = { 0.0, 2.0, 0.0 };
};

ExplosionData SniperExp
{
   shapeName = "breath.dts";
   soundId   = ricochet2;

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

ExplosionData AssaultChaingunExp
{
   shapeName = "plastrail.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData ArmaSniperExp
{
   shapeName = "plastrail.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData MultiBoom
{
	shapeName = "tumult_medium.dts";
	soundId   = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 5.0;
	timeScale = 1.5;
	timeZero = 0.150;
	timeOne  = 0.500;

	colors[0]  = { 1.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 0.0, 0.0 };
	colors[2]  = { 1.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.0, 0.0 };
};

ExplosionData napalmExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.125;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 0.3, 0.3, 0.7 };
   colors[2]  = { 0.4, 0.2, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData DiscLauncherExp
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

   colors[0]  = { 0, 0, 5.0 };
   colors[1]  = { 0, 0, 5.0 };
   colors[2]  = { 0, 0, 5.0 };
   radFactors = { 0, 0, 5.0 };
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
   
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   
   radFactors = { 0.0, 1.0, 0.85};
};

ExplosionData FlakWZExp
{
   shapeName = "dustplume.dts";
   soundId   = explosion3;

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

ExplosionData plasmaExp
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

ExplosionData flameExp2
{
   shapeName = "plasmaex.dts";
   soundId   = SoundJetHeavy;

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

ExplosionData flameExp
{
   shapeName = "fiery.dts";
   soundId   = SoundJetHeavy;

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

ExplosionData grenadeExp
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

ExplosionData ImpExp
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

ExplosionData nukeExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 40.0;

   timeScale = 2.00;

   timeZero = 0.200;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 0.0, 0.0, 1.0 };
   colors[2]  = { 0.2, 1.0, 0.3 };
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

ExplosionData FakeExp
{
   shapeName = "breath.dts";
   soundId   = SoundLFootLSoft;

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

ExplosionData sniperbulletExp
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = False;
};

