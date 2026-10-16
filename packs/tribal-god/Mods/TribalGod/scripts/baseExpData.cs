ExplosionData Shockwave {
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;
   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.250;
   timeOne  = 0.650;
   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData grenadeExp {
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeScale = 1.5;
   timeZero = 0.150;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData ShockwaveTwo {
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

ExplosionData ShockwaveThree {
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

ExplosionData ShockwaveFour {
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

ExplosionData LargeShockwave {
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;
   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.100;
   timeOne  = 0.300;
   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData NukeShockwave {
	shapeName = "shockwave_large.dts";
	soundId   = shockExplosion;
	faceCamera = false;
	randomSpin = true;
	hasLight   = true;
	lightRange = 50.0;
	timeZero = 0.100;
	timeOne  = 0.300;
	colors[0]  = { 1.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 4.0, 0.0 };
	colors[2]  = { 4.0, 2.0, 0.0 };
	radFactors = { 1.0, 1.5, 0.0 };
};

ExplosionData FireScreenExp {
   shapeName = "fiery.dts";
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

ExplosionData ExSmScreenExp {
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

ExplosionData SmScreenExp {
   shapeName = "bluex.dts";
   soundId   = soundwindgust;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;
   timeScale = 21;
   timeZero = 0.150;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 31, 31, 31 };
};

ExplosionData MiniSmokeExp {
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


ExplosionData fireballExp {
   shapeName = "fiery.dts";
   soundId   = SoundPlayerDeath;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;
   timeScale = 1;
   timeZero = 0.150;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData rocketExp {
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;
   timeScale = 1.5;
   timeZero = 0.250;
   timeOne  = 0.850;
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData energyExp {
   shapeName = "enex.dts";
   soundId   = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;
   timeZero = 0.450;
   timeOne  = 0.750;
   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };
   shiftPosition = True;
};

ExplosionData blasterExp {
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;
   timeZero = 0.450;
   timeOne  = 0.750;
   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };
   shiftPosition = True;
};

ExplosionData plasmaExp {
   shapeName = "plasmaex.dts";
   soundId   = explosion4;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.200;
   timeOne  = 0.950;
   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData flashgrenadeExp {
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


ExplosionData MiniFlakExp {
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0;
   timeScale = 3;
   timeZero = 0.0;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData armChanExp { 
	shapeName = "rsmoke.dts"; 
	faceCamera = true; 
	randomSpin = true; 
	hasLight = true; 
	lightRange = 4.0; 
	timeScale = 0.3; 
	colors[0] = { 1.0, 1.0, 1.0 }; 
	colors[1] = { 1.0, 1.0, 1.0 }; 
	colors[2] = { 1.0, 1.0, 1.0 }; 
	radFactors = { 1.0, 1.0, 1.0 }; 
};

ExplosionData mortarExp {
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0;
   timeScale = 1.5;
   timeZero = 0.0;
   timeOne  = 0.500;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData LiLFFBExp {
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = false;
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

ExplosionData MiniSAMExp {
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeScale = 1.5;
   timeZero = 0.250;
   timeOne  = 0.850;
   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData turretExp {
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.450;
   timeOne  = 0.750;
   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData LiLRocketEMPExp {
   shapeName = "fusionex.dts";
   soundId   = SoundEMPBlast;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.450;
   timeOne  = 0.750;
   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData bulletExp0 {
   shapeName = "chainspk.dts";
   soundId   = ricochet3;
   validateShape = true;
   validateMaterials = false;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.100;
   timeOne  = 0.900;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };
   shiftPosition = True;
};

ExplosionData bulletExp1 {
   shapeName = "chainspk.dts";
   soundId   = ricochet2;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.100;
   timeOne  = 0.900;
   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };
   shiftPosition = True;
};

ExplosionData RatPoisonExp {
	shapeName = "chainspk.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne = 0.750;
	colors[0] = { 1.0, 0.25, 0.25 };
	colors[1] = { 1.0, 0.25, 0.25 };
	colors[2] = { 1.0, 0.25, 0.25 };
	radFactors = { 1.0, 1.0, 1.0 };
	shiftPosition = True;
};

ExplosionData bulletExp2 {
   shapeName = "chainspk.dts";
   soundId   = ricochet3;
   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;
   timeZero = 0.100;
   timeOne  = 0.900;
   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };
   shiftPosition = True;
};

ExplosionData debrisExpSmall {
   shapeName = "tumult_small.dts";
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

ExplosionData debrisExpMedium {
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExplosion;
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

ExplosionData debrisExpLarge {
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;
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

ExplosionData flashExpSmall {
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

ExplosionData flashExpMedium {
   shapeName = "flash_medium.dts";
   soundId   = debrisMediumExplosion;
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

ExplosionData flashExpLarge {
   shapeName = "flash_large.dts";
   soundId   = debrisLargeExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0;
   timeZero = 0.250;
   timeOne  = 0.650;
   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData fireExp {
   shapeName = "plasmaex.dts";
   soundId   = bigExplosion2;
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

ExplosionData WickedBadExp {
	shapeName = "shield_large.dts";
	shapeName = "shockwave_large.dts";
	soundId   = rocketExplosion;
	faceCamera = true;				
	randomSpin = true;		
	hasLight = true;			
	lightRange = 9.0;			
	timeZero = 0.300;			
	timeOne = 0.900;			
	colors[0] = { 0.5,0.4,0.2 };
	colors[1] = { 1.0,1.0,0.5 };
	colors[2] = { 0.0,1.0,0.0 };
	radFactors = { 0.5,1.0,0.0 };
	shiftPosition = False;
};

ExplosionData AgedonSplitExp {
   shapeName = "plasmaex.dts";
   soundId   = shockExplosion;
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