ItemImageData AirStrikeImage {
	shapeFile = "ammo1";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;
	lightType = 3;
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AirStrike {
	heading = $InvHeading[BulletWeapons];
	description = "AirStrike";
	className = "Weapon";
	shapeFile  = "ammo1";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = AirStrikeImage;
	price = 85;
	showWeaponBar = true;
};

function AirStrikeImage::onFire(%player, %slot){
	%count = 0;
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	if(GameBase::getLOSInfo(%player,300)){
		%pos = $los::position;
		playsound(bigExplosion1, %pos);
		playsound(bigExplosion1, GameBase::getPosition(%player));
		%Xpos = getword(%pos, 0);
		%Ypos = getword(%pos, 1);
		%Zpos = getword(%pos, 2);
		%Zpos += floor(getRandom() * 1000);
		if(%Zpos < 50) %Zpos = 50;
		AirStrike::DropBombs(%player,%count, %Xpos, %Ypos, %Zpos, %pos);
		$TeamItemCount[%team @"AirStrike"]++;
		Client::sendMessage(%client, 0, "Target Lock Aquired.~wmale5.wtgtacq.wav");
		BottomPrint(%client, "<jc><f0>Military HQ:\n<f1>Lockon Aquired, Set back and watch the fireworks son.", 5);
	}else Client::SendMessage(%client,1,"Out of range for an AirStrike.~wmale5.tgtout.wav");
}

//== AirStrike -- Based on chivalry's Brimstone: drop bomb:: So all credits to the CHIVALRY Dev. Group
function AirStrike::DropBombs(%player, %count, %Xpos, %Ypos, %Zpos, %pos){
	%client = Player::getClient(%player);
	%time = 0.5;
	if($TeamItemCount[GameBase::getTeam(%player) @ "AirStrike"] <= $TeamItemMax[AirStrike]){
		Player::setItemCount(%player, "AirStrike", 0);
		if(%count < 40){
			if($debug) echo("BOMBS AWAY!!!!");
			%count++;
			for(%cnt = 0; %cnt < 2; %cnt++){
				%posneg = floor(getRandom() * 10);
				if($debug) echo("%posneg = "@ %posneg);
				if(%posneg  > 5.5555){
					%coord = floor(getRandom() * (100 - 0.01));
					if(%cnt == 0) %newXpos = %Xpos + %coord + 10;
					else %newYpos = %Ypos + %coord0;
				}else{
					%coord = floor(getRandom() * (100 - 0.01));
					if(%cnt == 0) %newXpos = %Xpos - %coord  + 10;
					else %newYpos = %Ypos - %coord;
				}
			}
			for(%counts = -16; %counts < 16; %counts = %counts + 8){
				//== Make it 1 row of drops per hit...
				%newXpos = %newXpos + %counts;
				%obj = newObject("","Mine","AirStrikeShell");
				addToSet("MissionCleanup", %obj);
				GameBase::throw(%obj,%player,-7.5,true);
				%newPos = %newXpos@" "@%newYpos@" "@%Zpos;
				GameBase::setPosition(%obj, %newPos);
			}
		}
		Schedule("AirStrike::DropBombs("@ %player @","@ %count @","@ %Xpos @","@ %Ypos @","@ %Zpos @");", %time);
	}
	else Client::sendMessage(%client,1,"You've used the limit airstrike's for this mission, "@ $TeamItemCount[GameBase::getTeam(%player) @ "AirStrike"] @".~waccess_denied.wav");
}

function CreateCircleVectors(%r){
	%y = 0;
	%CompString = (%r * %r);
	for(%x = (-1 * %r); (%CompString > (-1 * %r) && %r >= %x); %x = %x +8){
		%y = sqrt(%r * %r - %x * %x);
		%OutPut = %OutPut @" "@ %x @" "@ %y;
		%CompString = (%r * %r - (%x * %x + %y * %y));
	}
	return %OutPut;
}

function AirStrike::Formation3(%player, %pos){
	%client = Player::getClient(%player); 
	%goPos = %pos;
	%obj = newObject("BasicDropShip1","InteriorShape", "cotpdrop.dis"); 
	%pos = Vector::add(%pos, MoveForward::rotVector( "0 500 0", GameBase::getRotation(%player)));
	%pos = Vector::add(%pos, "0 0 500");
	addToSet("MissionCleanup", %obj); 
	GameBase::setTeam(%objShip1,GameBase::getTeam(%player)); 
	GameBase::setPosition(%obj,%pos); 
	GameBase::setRotation(%obj,GameBase::getRotation(%player)); 
	Gamebase::setMapName(%obj,"BomberShip"); 
	GameBase::startFadeIn(%obj); 
	AirStrike::MoveShip(%player, %obj, Vector::add(%goPos,"0 0 200"), false);
	return true; 
} 

function Vector::AddAllVar(%vec){
	%x = getWord(%vec,0)*100;
	%y = getWord(%vec,1)*10;
	%z = getWord(%vec,2);
	// new vector with z axis removed
	%basevec = %x + %y + %z;
	return %basevec;
}
function AirStrike::MoveShip(%player, %ship, %pos, %go, %fall){
	%curPos = Gamebase::getPosition(%ship);
	if(!%go){
		%dest = Vector::add(%curPos, MoveForward::rotVector( "0 -2 0", GameBase::getRotation(%ship)));
		%dest = Vector::add(%dest, "0 0 -2");
		GameBase::setPosition(%ship,%dest); 
		%allA = Vector::AddAllVar(%dest);
		%allB = Vector::AddAllVar(%pos);
		%check = %allA-%allB;
		if(%check > -100 && %check < 100){
			%go = true;
			schedule("deleteObject("@%ship@");",20,%ship);
			schedule("$SuperStrike--;",20);
		}
	}else{
		%rot = 0.01*getRandom();
		%newRot = Vector::add(GameBase::getRotation(%ship), "0 0 "@%rot);
		GameBase::setRotation(%ship,%newRot); 
		%dest = Vector::add(%curPos, MoveForward::rotVector( "0 -4 0", %newRot));
		%dest = Vector::add(%dest, "0 0 2");
		GameBase::setPosition(%ship,%dest); 
		%allA = Vector::AddAllVar(%dest);
		%allB = Vector::AddAllVar(%pos);
		%check = %allA-%allB;
		if(%check > 400 && %check < 600) %go = true;
	}
	if(%fall == 1){
		%objRot = GameBase::getRotation(%ship);
		%objPos = Vector::add(%dest , "20 -10 -10");
		%dir = Vector::getfromrot(%objRot);
		%trans = %objRot @ " " @ %dir @ " " @ %dir @ " " @ %objPos;
		Projectile::spawnProjectile("AirStrikeMortarShell", %trans, %player, %objRot, %player);

		%fall++;
	}
	else if(%fall == 4){
		%objRot = GameBase::getRotation(%ship);
		%objPos = Vector::add(%dest , "-20 10 -10");
		%dir = Vector::getfromrot(%objRot);
		%trans = %objRot @ " " @ %dir @ " " @ %dir @ " " @ %objPos;
		Projectile::spawnProjectile("AirStrikeMortarShell", %trans, %player, %objRot, %player);
		%fall = 0;
	}
	else %fall++;
	Schedule("AirStrike::MoveShip("@ %player @",'"@ %ship @"','"@ %pos @"','"@ %go @"','"@ %fall@"');",0.1,%ship);
}

//== Function found in MD, unsure of who wrote it
function MoveForward::rotVector(%vec, %rot){
	// this function rotates a vector about the z axis
	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);
	// new vector with z axis removed
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	// change vector to distance and rotation
	%basedis = Vector::getDistance("0 0 0", %basevec);
	%normvec = Vector::normalize(%basevec);
	%baserot = Vector::add( Vector::getRotation(%normvec), "1.571 0 0" );
	// modify rotation and change back to vector (put z axis offset back)
	%newrot = Vector::add(%baserot, %rot);
	%newvec = Vector::getFromRot(%newrot, %basedis, %vec_z);
	return %newvec;
}