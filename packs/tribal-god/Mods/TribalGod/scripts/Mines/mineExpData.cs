ExplosionData EngineerBoostExp {
   shapeName = "bluex.dts";
   soundId   = soundwindgust;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;
   timeScale = 2.5;
   timeZero = 0.150;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 31, 31, 31 };
};

ExplosionData mineExp {
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1;
   timeScale = 1.0;
   timeZero = 0.0;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashMineExpSmall {
   shapeName = "flash_small.dts";
   soundId   = debrisSmallExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.250;
   timeOne  = 0.650;
   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashgrenadeaExp {
   shapeName = "flash_large.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 20;
   timeZero = 0.250;
   timeOne  = 0.650;
   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData radiusmineexp {
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;
   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 1;
   timeZero = 0.100;
   timeOne  = 0.300;
   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};