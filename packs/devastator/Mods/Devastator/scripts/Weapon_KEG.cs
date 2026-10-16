
ExplosionData BeerBurst
{
	shapeName = "dustplume.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

//----------------------------------------------------------------------------

BulletData Beer
{
	bulletShapeName    = "dustplume.dts";
	explosionTag       = BeerBurst;
	mass               = 0.75;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $BeerDamageType;

	aimDeflection      = 0.004;
	muzzleVelocity     = 35.0;
	totalTime          = 0.30;
	inheritedVelocityScale = 0.25;
	isVisible          = true;
};

GrenadeData Puke
{
	bulletShapeName    = "mortartrail.dts";
	explosionTag       = mortartrailExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = -0.1;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.1;

	inheritedVelocityScale = 1.0;
	smokeName              = "mortartrail.dts";
};

//----------------------------------------------------------------------------

ItemImageData HangOverPukeImage
{
	shapeFile = "breath";
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.5 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.0;
	fireTime = 0.1;
	projectileType = Puke;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData HangOverPuke
{
	description = "";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "Mortar";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = HangOverPukeImage;
	price = 375;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData KegImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 1; // Spinning
	reloadTime = 0;
	minEnergy = 2;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.01;
	projectileType = Beer;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundRain;
	sfxActivate = SoundDryFire;
	sfxSpinUp = SoundDiscReload;
	sfxSpinDown = SoundPDAButtonSoft;
};

ItemData Keg
{
	description = "Keg";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = KegImage;
	price = 175;
	showWeaponBar = true;
};

// Voices to use: 
// wTaunt1 (Yehoo), wTaunt3 (Dance), wTaunt11 (I've Had Worse), wCheer2 (Wahoo), wColor2 (Shazbot)
// wColor7 (Ah Crap), wDsgst5 (Sigh), wOops1 (Doh), wOops2 (Oops), wColor3 (Hmph)
function GetDrunk(%this,%object,%vertPos)
{
	echo("getDrunk "@%this.drunk@" "@%this.gettingdrunk);
	if(%this.drunk <= 0 || %this.drunk == "") {
		%this.gettingdrunk++;
		if(%this.gettingdrunk >= 25)
			Staggerin(%this,30); //- %this = victim, 60 = duration time in seconds
	}
}

function Staggerin(%this,%time)
{
	%client = Player::getclient(%this);
	$Reloading[%client] = 1;
	Client::sendMessage(%client,0,"Your drunk!");
	%this.drunk = %time * 2; //- makes Drunk effect last for 2x %time
	GameBase::setEnergy(%this,0);
	GameBase::setRechargeRate(%this,0);
	Player::unMountItem(%this,$WeaponSlot);
	Player::mountItem(%this,HangOverPuke,4);
	Drunk(%this);
	echo(%this@" is now Drunk");
}

function Drunk(%this)
{
	%client = Player::getClient(%this);
	%this.gettingdrunk = "";
	if(%this.drunk <= 25 && Player::isCrouching(%this)) {
		HangOver(%this);
		return;
	}
	if(getRandom() >= 0.05) {
		if(!GameBase::isAtRest(%this)) {
			%rand = getRandom()*$RandDrunk - $RandDrunk/2;
			%rot = Vector::add(GameBase::getRotation(%client),"0 0 "@%rand); // X= not used in players, Y= not used in players, Z= left-right
			GameBase::setRotation(%client,%rot);
			//%vel = Vector::neg(Item::getVelocity(%this));
			%z = getword(Item::getVelocity(%this),2);
			Item::setVelocity(%this,"0 0 "@%z);
			%vec = Vector::getFromRot(GameBase::getRotation(%client),%rand*10);
			Player::applyImpulse(%this,%vec);
		}
		Player::applyImpulse(%this,"0 0 -50");
	}
	Player::setDamageFlash(%this,0.1); //-low flash makes pulse effect
	GameBase::setRotation(%client,%rot);
	%this.drunk--;
	if(%this.drunk > 0)
		schedule("Drunk("@%this@");",0.5,%this);
	else
		HangOver(%this);
}

function HangOver(%this)
{
	echo("Hangover: "@%this);
	%client = Player::getclient(%this);
	Player::setAnimation(%this,$HangOverAnim);
	Player::trigger(%this,4,true);
	schedule("HangOverEnd("@%this@");",0.5,%this);
}

function HangOverEnd(%this)
{
	echo("HangoverEnd: "@%this);
	%client = Player::getclient(%this);
	Player::trigger(%this,4,false);	
	Player::unmountItem(%this,4);
	Client::sendMessage(%client,0,"Your finally sober!");
	//%sound = radnomItems(3,Cheer1,Cheer2,Cheer3);
	playVoice(%client,Taunt11); // this plays the "I've had worse" voice
	GameBase::setRechargeRate(%this,8);
	Player::unMountItem(%this,4);
	$Reloading[%client] = 0;
}

function DrunkStupidity(%this,%object,%type)
{
	echo("DrunkenStupidity Case: "@%this@", "@%type@".");
	%DrunkC = Player::getclient(%this);
	%Client = Player::getclient(%object);
	if(%type == "HG") {
		//GameBase::setRotation(%DrunkC,GameBase::getRotation(%client));
		Player::setAnimation(%DrunkC,50);
		playVoice(%DrunkC,"No");
		%this.DeadManDrunk = 1;
	} else if(%type == "Fall") {
		Player::killOff(%this,%object,$LandingDamageType,"",Drunk);
	} else if(%type == "Wreck") {
		DrunkDriver(%this);
	} else if(%type == "FlyBy") {
		Player::killOff(%this,%object,$ImpactDamageType,33,Drunk);
	} else
		return;
}

function DrunkDriver(%this)
{
	%vehicle = %this.vehicle;
	if(!GameBase::isAtRest(%vehicle)) {
		%rand = 0.375 - getRandom()*0.75;
		%rot = Vector::add(GameBase::getRotation(%vehicle),%rand/2@" "@%rand@" "@%rand/3); // X= not used in players, Y= not used in players, Z= left-right
		echo(GameBase::getRotation(%vehicle));
		GameBase::setRotation(%vehicle,%rot);
		echo(GameBase::getRotation(%vehicle));
		%rand = getRandom();
		%vec = Vector::getFromRot(GameBase::getRotation(%vehicle),50,0-%rand*10);
		Player::applyImpulse(%this,%vec);
		Player::applyImpulse(%vehicle,%vec);
	}
	if(GameBase::getDamageLevel(%vehicle) <= 0.1)
		GameBase::setDamageLevel(%vehicle,GameBase::getDamageLevel(%vehicle)+GameBase::getDataName(%vehicle).maxDamage/10); //-Makes Veh last 5 secs with no damage
	else {
		Player::killOff(%this,%object,$CarWreck,"BlowUp",Drunk);
		GameBase::setDamageLevel(%vehicle,GameBase::getDataName(%vehicle).maxDamage);
	}
	schedule("DrunkDriver("@%this@");",0.5,%this);
}

function DrunkSpeech(%msg,%cl)
{
	%words = "";
	for(%i = 0; %i < 40; %i++) {
		%Word[%i] = TypoCheck(getword(%msg,%i));
		if(%Word[%i] == "wtf" || %Word[%i] == "wtf?") //- I Dunno, it's just fun
			%Word[%i] = "?ftw";
		if(%Word[%i] == -1) {
			%Length = %i;
			break;
		}
		%space = "";
		if(getword(%msg,%i+1) != -1)
			%space = " ";
		%words = %words@%Word[%i]@%space;
	}
	%msg = %words; //- no typos for the drunk! But they do tend to forget the order of their words
	%words = "";
	for(%a = 0; %a < %Length; %a++) {
		DrunkSpeech::Mix(%Length,%a);
		%place = DrunkSpeech::Mix(%length,%a,%cl);//$DrunkTemps[%a];
		%TempWord[%place] = %Word[%place];
		%space = "";
		if(%A < %Length && %Length > 1)
			%space = " ";
		%words = %words@%TempWord[%place]@%space;
	}
	echo(%words);
	for(%i = 0; %i <= %length; %i++)
		$DrunkPlace[%cl,%i] = "";
	return %words;
}

function DrunkSpeech::Mix(%length,%place,%cl)
{
	for(%i = 0; %i <= %length; %i++) {
		$DrunkPlace[%cl,%i] = "";
	}
	%rand = floor(getrandom() * %length);
	if($DrunkPlace[%cl,%rand] != "taken") {
		$DrunkPlace[%cl,%rand] = "taken";
		return %rand;
	}
	else
		DrunkSpeech::Mix(%length,%place,%cl);
}

$HangOverAnim = 43;
$RandDrunk = 2;
$ItemMax[larmor, Keg] = 1;
$ItemMax[qarmor, Keg] = 1;
$ItemMax[srarmor, Keg] = 1;
$ItemMax[sarmor, Keg] = 1;
$ItemMax[marmor, Keg] = 1;
$ItemMax[parmor, Keg] = 1;
$ItemMax[harmor, Keg] = 1;
$ItemMax[tarmor, Keg] = 1;
$ItemMax[psarmor, Keg] = 1;
$ItemMax[psfemale, Keg] = 1;
$ItemMax[IceMor, Keg] = 1;
$ItemMax[lfemale, Keg] = 1;
$ItemMax[qfemale, Keg] = 1;
$ItemMax[srfemale, Keg] = 1;
$ItemMax[sfemale, Keg] = 1;
$ItemMax[mfemale, Keg] = 1;
$ItemMax[pfemale, Keg] = 1;
$InvList[Keg] = 1;
$RemoteInvList[Keg] = 1;
