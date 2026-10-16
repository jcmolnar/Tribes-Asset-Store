ExplosionData SalvoRocketExp
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

ExplosionData VermExp
{
   shapeName = "plasmabolt.dts";
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

ExplosionData VermExp2
{
   shapeName = "plasmabolt.dts";
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

ExplosionData VermExp3
{
   shapeName = "plasmabolt.dts";
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

ExplosionData FFBExp
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

ExplosionData BoosterExp
{
   shapeName = "bluex.dts";
   soundId   = SoundThrowItem;

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

ExplosionData fireballExp
{
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

ExplosionData GrblasterExp
{
   shapeName = "paint.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 50.25, 0.0 };
   colors[1]  = { 0.0, 50.25, 0.0 };
   colors[2]  = { 0.0, 50.25, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData ShockwaveArm
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

ExplosionData acidsmExp
{
   shapeName = "plastrail.dts";
   faceCamera = true;
   randomSpin = true;
   //hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData AcidExp
{
   shapeName = "dustplume.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

ExplosionData fire2Exp
{
   shapeName = "fiery.dts";
   soundId   = SoundJetLight;

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

ExplosionData MkiiExp
{
	shapeName = "rsmoke.dts";
	soundId = ricochet2;
	validateShape = true;
	validateMaterials = true;
	faceCamera = true;
	randomSpin = true;
	
	timeZero = 0.100;
	timeOne = 0.900;

	shiftPosition = True;
};

ExplosionData FEBBulletExp
{
	shapeName = "mortartrail.dts";
	soundId = ricochet3;
	validateShape = true;
	validateMaterials = true;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 0.5;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]  = { 0.0, 50.0,  0.0 };
   	colors[1]  = { 0.0, 50.0, 0.0 };
   	colors[2]  = { 0.0, 50.0, 0.0 };
   	radFactors = { 0.0, 5.0, 0.0 };
	shiftPosition = True;
};

ExplosionData HeavensfuryExp
{
	shapeName = "plasmatrail.dts";
	soundId = energyExplosion;
	validateShape = true;
	validateMaterials = true;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 1.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]  = { 0.0, 0.0,  0.0 };
   	colors[1]  = { 1.0, 0.63, 0.0 };
   	colors[2]  = { 1.0, 0.63, 0.0 };
   	radFactors = { 0.0, 1.0, 0.9 };
	shiftPosition = True;
};


ExplosionData ShredderBulletExp
{
	shapeName = "chainspk.dts";
	soundId = ricochet1;
	validateShape = true;
	validateMaterials = true;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 1.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]  = { 0.0, 0.0,  0.0 };
   	colors[1]  = { 1.0, 0.63, 0.0 };
   	colors[2]  = { 1.0, 0.63, 0.0 };
   	radFactors = { 0.0, 1.0, 0.9 };
	shiftPosition = True;
};

ExplosionData TankRocketExp
{
	shapeName = "bluex.dts";
	soundId = rocketExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 5.0;
	timeScale = 1.5;
	timeZero = 0.250;
	timeOne = 0.850;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.63, 0.0 };
	colors[2] = { 1.0, 0.63, 0.0 };
	radFactors = { 0.0, 1.0, 0.9 };
};


ExplosionData rocketExp
{
	shapeName = "bluex.dts";
	soundId = rocketExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 8.0;
	timeScale = 1.5;
	timeZero = 0.250;
	timeOne = 0.850;
	colors[0] = { 0.4, 0.4, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 0.95, 1.0 };
	radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData WickedBadExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = rocketExplosion;


	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=9.0;			
	timeZero=0.300;			
	timeOne=0.900;			
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};


ExplosionData energyExp
{
	shapeName = "enex.dts";
	soundId = energyExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne = 0.750;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
	shiftPosition = True;
};

ExplosionData VulcanExp
{
   shapeName = "plastrail.dts";	
   soundId   = ricochet1;	

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   //colors[0]  = { 1.0, 0.25, 0.25 };
   //colors[1]  = { 1.0, 0.25, 0.25 };
   //colors[2]  = { 1.0, 0.25, 0.25 };
   //radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData Vulcan2Exp
{
   shapeName = "plastrail.dts";	
   soundId   = ricochet2;	

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   //colors[0]  = { 1.0, 0.25, 0.25 };
   //colors[1]  = { 1.0, 0.25, 0.25 };
   //colors[2]  = { 1.0, 0.25, 0.25 };
   //radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData Vulcan3Exp
{
   shapeName = "plastrail.dts";	
   soundId   = ricochet3;	

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   //colors[0]  = { 1.0, 0.25, 0.25 };
   //colors[1]  = { 1.0, 0.25, 0.25 };
   //colors[2]  = { 1.0, 0.25, 0.25 };
   //radFactors = { 1.0, 1.0, 1.0 };

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
	soundId = explosion4;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeZero = 0.200;
	timeOne = 0.950;
	colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData grenadeExp
{
	shapeName = "fiery.dts";
	soundId = bigExplosion3;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 10.0;
	timeScale = 1.5;
	timeZero = 0.150;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.63, 0.0 };
	colors[2] = { 1.0, 0.63, 0.0 };
	radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData mineExp
{
	shapeName = "shockwave.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 8.0;
	timeScale = 1.5;
	timeZero = 0.0;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData mortarExp
{
	shapeName = "mortarex.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = false;
//	faceCamera = true;
//	randomSpin = true;
	hasLight = true;
	lightRange = 8.0;
	timeScale = 1.5;
	timeZero = 0.0;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData TankMortarExp
{
	shapeName = "tumult_large.dts";
	soundId = bigexplosion1;
	faceCamera = true;
	randomSpin = false;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 8.0;
	timeScale = 1.5;
	timeZero = 0.0;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.63, 0.0 };
	colors[2] = { 1.0, 0.63, 0.0 };
	radFactors = { 0.0, 1.0, 0.9 };
};


ExplosionData AgedonSplitExp
{
//
   shapeName = "plasmaex.dts";
   soundId   = shockExplosion;//explosion4;//SoundFlakDet;//explosion4;//

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

ExplosionData turretExp
{
	shapeName = "fusionex.dts";
	soundId = turretExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne = 0.750;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData burnExp
{
// admin
	shapeName = "plasmaex.dts";
	soundId = explosion4;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeZero = 0.9;
	timeOne = 0.250;
	colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};
ExplosionData RatPoisonExp
{
// admin
	shapeName = "chainspk.dts";
	//soundId = energyExplosion;
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

ExplosionData ParticleBeamShellExp
{
// 
	shapeName = "fusionex.dts";	//chainspk.dts";
	soundId = SoundFlierCrash;	//energyExplosion;
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


ExplosionData bulletExp0
{
	shapeName = "chainspk.dts";
	soundId = ricochet1;
	validateShape = true;
	validateMaterials = true;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 1.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

ExplosionData bulletExp1
{
	shapeName = "chainspk.dts";
	soundId = ricochet2;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 1.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.5 };
	colors[2] = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

ExplosionData bulletExp2
{
	shapeName = "chainspk.dts";
	soundId = ricochet3;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 1.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 0.75, 1.0, 1.0 };
	colors[2] = { 0.75, 1.0, 1.0 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

ExplosionData debrisExpSmall
{
	shapeName = "tumult_small.dts";
	soundId = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpMedium
{
	shapeName = "tumult_medium.dts";
	soundId = debrisMediumExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpLarge
{
	shapeName = "tumult_large.dts";
	soundId = debrisLargeExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 5.0;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpSmall
{
	shapeName = "flash_small.dts";
	soundId = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpMedium
{
	shapeName = "flash_medium.dts";
	soundId = debrisMediumExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.75;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpLarge
{
	shapeName = "flash_large.dts";
	soundId = debrisLargeExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 6.0;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Shockwave
{
	shapeName = "shockwave.dts";
	soundId = shockExplosion;
	faceCamera = false;
	randomSpin = false;
	hasLight = true;
	lightRange = 6.0;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData LargeShockwave
{
	shapeName = "shockwave_large.dts";
	soundId = shockExplosion;
	faceCamera = false;
	randomSpin = false;
	hasLight = true;
	lightRange = 10.0;
	timeZero = 0.100;
	timeOne = 0.300;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 0.0, 0.0, 0.0 };
	radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData ShotExp 
{
	shapeName = "snowplume.dts";
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
{
	shapeName = "shockwave_large.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]  = { 0.0, 10.0, 50.0 };
   	colors[1]  = { 0.0, 10.0, 50.0 };
   	colors[2]  = { 0.0, 10.0, 50.0 };
   	radFactors = { 0.0, 1.0, 5.0 };
};

ExplosionData PhaseDisrupterNullExp
{
	shapeName = "fusionex.dts";
	soundId = shockExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 5.0;
	timeZero = 0.100;
	timeOne = 0.900;
	colors[0]  = { 0.0, 0.0, 50.0 };
   	colors[1]  = { 0.0, 0.0, 50.0 };
   	colors[2]  = { 0.0, 0.0, 50.0 };
   	radFactors = { 0.0, 0.0, 5.0 };
};

ExplosionData FlameExp
{
	shapeName = "fiery.dts";
	//soundId = SoundJetHeavy;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 10.0;
	timeScale = 1.5;
	timeZero = 0.150;
	timeOne = 0.500;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.63, 0.0 };
	colors[2] = { 1.0, 0.63, 0.0 };
	radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SmokeFade
{
	shapeName = "breath.dts";
	//soundId = vertigo;
	faceCamera = false;
	randomSpin = false;
	hasLight = true;
	lightRange = 0.0;
	timeScale = 1.5;
	timeZero = 0;
	timeOne = 1;
	colors[0] = { 0.4, 0.4, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
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
{
	shapeName = "paint.dts";
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
{
	shapeName = "plasmaex.dts";
	soundId = bigExplosion2;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeZero = 0.200;
	timeOne = 0.950;
	colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData bloodExp
{
   shapeName = "shotgunex.dts";
//   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 0.5;	//3.0
   
   
  	lightTime = 2; 
	timeScale = 2.5;
	
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 50.0, 0, 0 };
   colors[1]  = { 50.0, 0, 0 };
   colors[2]  = { 50.0, 0, 0 };
   radFactors = { 1.0, 1.0, 1.0 };


//
//	lightType = 3;
//	lightRadius = 6;
//	lightTime = 2;
//	lightColor = { 1.0, 0, 0 };
//
   shiftPosition = True;
};