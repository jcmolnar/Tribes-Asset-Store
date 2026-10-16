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

   colors[0]  = { 0.2, 0.2,  1.0 };
   colors[1]  = { 0.8, 0.8,  1.0 };
   colors[2]  = { 1.0, 0.8, 1.0 };
   radFactors = { 0.65, 1.0, 1.0 };
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

ExplosionData napExp
{
   shapeName = "fiery.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 40.0;

   timeScale = 9.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.4, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 0.4, 0.7, 1.0 };
};
ExplosionData ggrocketExp
{
   shapeName = "bluex.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 3.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.2, 0.2,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.2, 0.2 };
   radFactors = { 0.65, 1.0, 0.65 };
};

ExplosionData nappyExp
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExp1osion;

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

ExplosionData SockExp
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 23.0;

   timeScale = 5.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.3, 0.3, 1.0 };
   colors[1]  = { 0.5, 0.5,  1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.5, 1.0, 0.8 };
};

ExplosionData energyExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};
ExplosionData EMPPulseExp { shapeName = "shockwave_large.dts"; soundId = shockExplosion; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 40.0; timeScale = 0.5; colors[0] = { 0.0, 0.0, 1.0 }; colors[1] = { 0.0, 0.0, 1.0 }; colors[2] = { 0.0, 0.0, 1.0 }; radFactors = { 0.2, 0.6, 1.0 }; };

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
   lightRange = 5.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData plasmafExp
{
   shapeName = "plasmaex.dts";

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 5.0;

   timeScale = 1.5;
   
   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData plasmadfExp
{
   shapeName = "plasmaex.dts";

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 5.0;

   timeScale = 3;
   
   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData plasmatdfExp
{
   shapeName = "plasmaex.dts";
   soundId   = shaboo;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 14.0;

   timeScale = 3.4;
   
   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.0 };
   colors[2]  = { 1.0, 0.5, 0.0 };
   radFactors = { 1.0, 0.2, 0.8 };
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

   colors[0]  = { 1.0, 0.6,  0.0 };
   colors[1]  = { 1.0, 0.4, 0.0 };
   colors[2]  = { 1.0, 0.2, 0.0 };
   radFactors = { 1.0, 1.0, 0.9 };
};

ExplosionData grenladeExp
{
   shapeName = "fiery.dts";
   soundId   = shaboo;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 0.43,  0.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 1.0, 1.0, 0.9 };
};

ExplosionData mineExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 2.15;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.5, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData mortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;


   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.5, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};


ExplosionData puffExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 20.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 0.2 };
   colors[2]  = { 1.0, 1.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData puffQExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 13.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 0.2 };
   colors[2]  = { 1.0, 1.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData turretExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData turret1Exp
{
   shapeName = "breath.dts";
   soundId   = SoundFireFlierRocket;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.0,  1.0,  0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};


ExplosionData l1ll1Exp
{
   shapeName = "shockwave.dts";
   soundId   = debrisLargeExp1osion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 0.3;
   
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

 ExplosionData ShotExp { shapeName = "smoke.dts"; soundId = ricochet3; faceCamera = true; randomSpin = true; hasLight = false; timeScale = 0.5; timeZero = 0.100; timeOne = 0.900; shiftPosition = false; }; 

ExplosionData ShotExp1 { shapeName = "rsmoke.dts"; soundId = ricochet2; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 1.0; timeZero = 0.100; timeOne = 0.900; colors[0] = { 0.0, 0.0, 0.0 }; colors[1] = { 1.0, 1.0, 0.5 }; colors[2] = { 1.0, 1.0, 0.5 }; radFactors = { 0.0, 1.0, 0.0 }; shiftPosition = True; }; 

ExplosionData ShotExp2 { shapeName = "smoke.dts"; soundId = SoundHFootLHard; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 1.0; timeZero = 0.100; timeOne = 0.900; colors[0] = { 0.0, 0.0, 0.0 }; colors[1] = { 0.75, 1.0, 1.0 }; colors[2] = { 0.75, 1.0, 1.0 }; radFactors = { 0.0, 1.0, 0.0 }; shiftPosition = True; };

ExplosionData puffEx
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 7;

   timeScale = 26.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 0.0 };
   colors[2]  = { 1.0, 1.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};


ExplosionData RailExp
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 7.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};


ExplosionData bulletExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.5;

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
   lightRange = 0.8;

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

ExplosionData telExp 
{ 
shapeName = "rsmoke.dts"; 
faceCamera = true; 
randomSpin = true; 
hasLight = true; 
lightRange = 20.0; 
timeScale = 0.5; 
colors[0] = { 0.25, 0.25, 1.0 }; 
colors[1] = { 0.25, 0.25, 1.0 }; 
colors[2] = { 0.0, 0.0, 1.0 }; 
radFactors = { 0.8, 0.4, 1.0 }; 
};

ExplosionData nullExp 
{ 
shapeName = "fusionex.dts"; 
faceCamera = true; 
randomSpin = true; 
hasLight = true; 
lightRange = 5.0; 
timeScale = 0.3; 
colors[0] = { 0.25, 0.25, 1.0 }; 
colors[1] = { 0.25, 0.25, 1.0 }; 
colors[2] = { 0.0, 0.0, 1.0 }; 
radFactors = { 1.0, 1.0, 1.0 }; };

ExplosionData armChanExp { shapeName = "rsmoke.dts"; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 4.0; timeScale = 0.3; colors[0] = { 1.0, 1.0, 1.0 }; colors[1] = { 1.0, 1.0, 1.0 }; colors[2] = { 1.0, 1.0, 1.0 }; radFactors = { 1.0, 1.0, 1.0 }; };

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

ExplosionData debrisEoxpMedium
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisLargeExplosion;

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

ExplosionData nul11Exp { shapeName = "plasmaex.dts"; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 7.0; timeScale = 0.3; colors[0] = { 1.0, 0.7, 0.0 }; colors[1] = { 1.0, 0.5, 0.0 }; colors[2] = { 1.0, 0.25, 0.0 }; radFactors = { 1.0, 1.0, 1.0 }; };

ExplosionData nu11Exp { shapeName = "shockwave.dts"; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 5.0; timeScale = 0.3; colors[0] = { 0.25, 0.25, 1.0 }; colors[1] = { 0.25, 0.25, 1.0 }; colors[2] = { 0.0, 0.0, 1.0 }; radFactors = { 1.0, 1.0, 1.0 }; };

ExplosionData LargeShockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 20.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.5 };
   radFactors = { 1.0, 0.5, 0.5 };
};


ExplosionData sniperbulletExp
{
   shapeName = "rsmoke.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.5;

   timeZero = 0.100;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 1.0 };

   shiftPosition = False;
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

ExplosionData kakeExp
{
   shapeName = "rsmoke.dts";

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

ExplosionData bullExp 
{ 
	shapeName = "fusionex.dts"; 
	faceCamera = true; 
	randomSpin = true; 
	hasLight = false; 
	lightRange = 4.0; 
	timeScale = 4.0; 
	colors[0] = { 0.12, 0.12, 1.0 }; 
	colors[1] = { 0.12, 0.12, 1.0 }; 
	colors[2] = { 0.0, 0.0, 1.0 }; 
	radFactors = { 1.0, 1.0, 1.0 }; 
}; 

ExplosionData nu1lExp { shapeName = "paint.dts"; faceCamera = true; randomSpin = true; hasLight = true; lightRange = 3.0; timeScale = 0.65; colors[0] = { 1, 0, 0 }; colors[1] = { 1, 0, 0 }; colors[2] = { 1, 0, 0 }; radFactors = { 1.0, 0, 0 }; };

ExplosionData minelExp
{
   shapeName = "breath.dts";

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.100;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = False;
};

ExplosionData scssssbo
{
   shapeName = "breath.dts";
   soundId   = kapsshh;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.100;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = False;
};

ExplosionData LargeSockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = debrisLargeExposion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;

   timeZero = 0.100;
   timeOne  = 1.300;

   timeScale = 3;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.9, 0.75 };
};

ExplosionData LargeDockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 35.0;

   timeScale = 4.5;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 0.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 0.2, 1.0 };
};

ExplosionData bebrisExpMedium
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExpllosion;

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

ExplosionData ionExp_4
{
   shapeName = "smoke.dts";
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

ExplosionData AnnihExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 50.0;

   timeScale = 0.75;

   timeZero = 0;
   timeOne  = 2;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 0.4, 0.0 };
   colors[2]  = { 1.0, 0.0, 0.0 };
   radFactors = { 0.8, 0.9, 0.5 };
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

ExplosionData AODStingerExp
{	shapeName = "shockwave.DTS";
	soundId=  RocketExplosion;	
	faceCamera=true;			
	randomSpin = true;			
	hasLight=true;				
	lightRange=8.0;				
	timeZero=0.100;				
	timeOne=0.900;				
	colors[0]={0.0,0.0,0.0};	
	colors[1]={1.0,1.0,0.5};	
	colors[2]={0.0,1.0,0.0};	
	radFactors={0.0,1.0,0.0};	
	shiftPosition=False;		
};

//=============random events explosion's============================

ExplosionData PlasmaCannonExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData LightningExp 
{ 
	shapeName = "flash_medium.dts";
	soundId = Explosion4;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 40.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};
