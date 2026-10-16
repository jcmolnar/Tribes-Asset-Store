//-----Spell Explosions and FX
ExplosionData DivineExp
{
   shapeName = "shockwave_large.dts";
   soundId   = SoundTankCrash;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 30;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.5, 0, 1.0  };
   colors[1]  = { 0.5, 0, 1.0 };
   colors[2]  = { 0.5, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData playerfire
{
   shapeName = "smoke.dts";

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 0  };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData IceExp
{
   shapeName = "fusionex.dts";
   soundId   = SoundTankCrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 100.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1.0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData Ripple
{
   shapeName = "shockwave_large.dts";
   soundId   = SoundShockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1.0, 1.0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

//----Base Explosion and FX
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

   colors[0]  = { 1.0, 0, 0 };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
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
   shapeName = "shield_large.dts";
   soundId   = bigExplosion1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 1.0, 0.0 };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData mortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
//   faceCamera = true;
//   randomSpin = true;
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
   validateShape = true;
   validateMaterials = true;

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
   shapeName = "laserhit.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0, 1, 0 };
   colors[1]  = { 0, 1, 0 };
   colors[2]  = { 0, 1, 0 };
   radFactors = { 1.0, 1.0, 1.0 };

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

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 30.0;
 
   timeZero = 0.100;              
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};
//-----My explosions and FX :P
ExplosionData HLaserExp
{
   shapeName = "tumult_small.dts";
   soundId   = DebrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.3, 0, 1.0  };
   colors[1]  = { 0.3, 0, 1.0 };
   colors[2]  = { 0.3, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData HunterExp
{
   shapeName = "shotgunex.dts";
   soundId   = SoundFlagPickup;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData SpikeStick
{
   shapeName = "mine.dts";
   soundId   = SoundTankCrash;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 100.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData C4BlastExp
{
   shapeName = "tumult_large.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0.25, 0  };
   colors[1]  = { 1.0, 0.25, 0 };
   colors[2]  = { 1.0, 0.25, 0 };
   radFactors = { 1.0, 0.25, 1 };
};

ExplosionData C4Exp
{
   shapeName = "shockwave_large.dts";
   soundId   = ShockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 40;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0.25, 0  };
   colors[1]  = { 1.0, 0.25, 0 };
   colors[2]  = { 1.0, 0.25, 0 };
   radFactors = { 1.0, 0.25, 1 };
};

ExplosionData RailExp
{
   shapeName = "rsmoke.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1, 1, 1 };
};


ExplosionData SmokeExp
{
   shapeName = "mortarex.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 40.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData RPGExp
{
   shapeName = "fiery.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15;

   timeScale = 12.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0.25, 0  };
   colors[1]  = { 1.0, 0.25, 0 };
   colors[2]  = { 1.0, 0.25, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData HealthExp
{
   shapeName = "shield_large.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 2.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 1.0  };
   colors[1]  = { 0, 1.0, 1.0 };
   colors[2]  = { 0, 1.0, 1.0 };
   radFactors = { 1.0, 0, 1 };
};

ExplosionData PaintBallExp
{
   shapeName = "breath.dts";
   soundId   = 0;

   faceCamera = false;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1;

   timeScale = 200.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1.0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData bioPlasmaExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0, 1.0,  0.0 };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData dustPlasmaExp
{
   shapeName = "tumult_small.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeScale = 3.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1, 0,  0.0 };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData DiscExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 3.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 1, 1, 0 };
   colors[1]  = { 1, 1, 0 };
   colors[2]  = { 1, 1, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData blasterSmokeExp
{
   shapeName = "plastrail.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeScale = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0, 0, 1 };
   colors[1]  = { 0, 0, 1 };
   colors[2]  = { 0, 0, 1 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData GammaExp
{
   shapeName = "flash_small.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.0;

   timeScale = 2.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0, 0.5, 1 };
   colors[1]  = { 0, 0.5, 1 };
   colors[2]  = { 0, 0.5, 1 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData PLExp
{
   shapeName = "plasmaex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1, 0, 0 };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData CBulletExp       
{
   shapeName = "plasmatrail.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeScale = 1.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1, 1, 0 };
   colors[1]  = { 1, 1, 0 };
   colors[2]  = { 1, 1, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData SBulletExp       
{
   shapeName = "mortartrail.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeScale = 1.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 0, 0, 1 };
   colors[1]  = { 0, 0, 1 };
   colors[2]  = { 0, 0, 1 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData DevExp
{
   shapeName = "tumult_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.5, 0.5, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.0 };
   colors[2]  = { 1.0, 0.5, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData IonExp
{
   shapeName = "shield_large.dts";
   soundId   = shockExplosion;

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


ExplosionData flakExp2
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1, 0  };
   colors[1]  = { 0, 1, 0 };
   colors[2]  = { 0, 1, 0 };
   radFactors = { 1, 1, 1 };
};

ExplosionData flakExp
{
   shapeName = "dustplume.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 0  };
   colors[1]  = { 0, 0, 1 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 1, 1, 1 };
};

ExplosionData methaneExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 3.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1, 0,  0.0 };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData MRExp2
{
   shapeName = "tumult_large.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.5;

   timeScale = 3.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0.25, 0  };
   colors[1]  = { 1, 0.25, 0 };
   colors[2]  = { 1, 0.25, 0 };
   radFactors = { 1, 1, 1 };
};

ExplosionData MRExp
{
   shapeName = "fiery.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0.25, 0  };
   colors[1]  = { 0, 0, 0 };
   colors[2]  = { 0.25, 0, 0 };
   radFactors = { 1, 1, 1 };
};

ExplosionData BloodExp
{
   shapeName = "shotgunex.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3;

   timeScale = 100.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 0  };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0, 0 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData BloodExp2
{
   shapeName = "laserhit.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3;

   timeScale = 100.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 0  };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData BursterExp
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 30.0;

   timeScale = 10.0;
 
   timeZero = 0.100;              
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData MyDebrisExp
{
   shapeName = "plasmaex.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3;

   timeScale = 100.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0.5, 0  };
   colors[1]  = { 1.0, 0.5, 0 };
   colors[2]  = { 1.0, 0.5, 0 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData HawkExp
{
   shapeName = "tumult_large.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15.25;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0.5, 0  };
   colors[1]  = { 1.0, 0.5, 0 };
   colors[2]  = { 1.0, 0.5, 0 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData HawkExp2
{
   shapeName = "shield_large.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.25;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1  };
   colors[1]  = { 0, 0, 1 };
   colors[2]  = { 0, 0, 1 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData ThumperExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.25;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1  };
   colors[1]  = { 1, 0, 1 };
   colors[2]  = { 0.5, 1, 0 };
   radFactors = { 1, 1, 1 };
};


//------Power Blast Shots Explosions--///// :) 

ExplosionData PBExp1
{
   shapeName = "laserhit.dts";
   soundId   = 0;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1  };
   colors[1]  = { 0, 0, 1 };
   colors[2]  = { 0, 0, 1 };
   radFactors = { 0.25, 0.5, 1 };
};

ExplosionData PBExp2
{
   shapeName = "tumult_small.dts";
   soundId   =  debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 0  };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp3
{
   shapeName = "fusionex.dts";
   soundId   = bigExplosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1, 0, 1.0  };
   colors[1]  = { 1.0, 0, 1.0 };
   colors[2]  = { 1.0, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp4
{
   shapeName = "plasmaex.dts";
   soundId   = explosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp5
{
   shapeName = "flash_large.dts";
   soundId   = bigExplosion2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp6
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp7
{
   shapeName = "bluex.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp8
{
   shapeName = "fiery.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};


ExplosionData PBExp9
{
   shapeName = "mortarex.dts";
   soundId   = bigExplosion1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0, 1.0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 0, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};

ExplosionData PBExp10
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 20;

   timeScale = 10.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 1.0, 0  };
   colors[1]  = { 0, 1.0, 0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 0.75, 0.25 };
};
//-----Random OBC Explosion Set :)
ExplosionData OhmExp
{
   shapeName = "tumult_small.dts";
   soundId   = DebrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0.5, 1.0  };
   colors[1]  = { 0, 0.5, 1.0 };
   colors[2]  = { 0, 0.5, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};
ExplosionData OhmExp2
{
   shapeName = "tumult_medium.dts";
   soundId   = DebrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.3, 0, 1.0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};
ExplosionData OhmExp3
{
   shapeName = "plasmaex.dts";
   soundId   = DebrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 0, 0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

///___...::::[- Napalm Explosion Set -]::::...__
ExplosionData SmearyNapalmExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0, 0.5, 1.0  };
   colors[1]  = { 0, 0.5, 1.0 };
   colors[2]  = { 0, 0.5, 1.0 };
   radFactors = { 1.0, 1.0, 1 };
};
ExplosionData SmearyNapalmExp2
{
   shapeName = "tumult_large.dts";
   soundId   = DebrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.3, 0, 1.0  };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 1.0, 0 };
   radFactors = { 1.0, 1.0, 1 };
};
ExplosionData SmearyNapalmExp3
{
   shapeName = "fiery.dts";
   soundId   = BigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 1.0, 0, 0  };
   colors[1]  = { 1, 0, 0 };
   colors[2]  = { 1, 0.3, 0 };
   radFactors = { 1.0, 1.0, 1 };
};

