$InvList[Parachute] = 1;
$RemoteInvList[Parachute] = 1;
$VehicleInvList[Parachute] = 1;

$ItemMax[larmor, Parachute] = 1;
$ItemMax[harmor, Parachute] = 1;
$ItemMax[lfemale, Parachute] = 1;

//Credit for this code goes to Nick Musurca and his awsome Mod: Delta Force. Thanks!
ItemImageData ParachuteImage
	{ 
	shapeFile = "shieldPack";
	 mountPoint = 2;
	 weaponType = 2; // Sustained 
	maxEnergy = 0; // Energy used/sec for sustained weapons 
	minEnergy = 0; 
	sfxFire = SoundJammerOn; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = False;
};
ItemData Parachute
	{ 
	description = "Parachute"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = "cBackpacks"; 
	shadowDetailMask = 4; 
	imageType = ParachuteImage;
	price = 100; 
	hudIcon = "sensorjamerpack"; 
	showWeaponBar = true; 
	hiliteOnActive = true;
};
function doPara(%player)
{ 
Player::applyImpulse(%player, "0 0 75");
 if ($ParaActivated[%player] == 1) {
 if (Player::getLastContactCount(%player) > 5) {
 schedule("doPara("@%player@");", 0.45);
 } 
else hitGround(%player);
 }
}
function ParachuteImage::onActivate(%player,%imageSlot)
{ 
if($ParaActivated[%player] == 0) 
{ %contact = Player::getLastContactCount(%player);
 if(%contact > 11 ) { remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Deployed",4);
 $ParaActivated[%player] = 1;
 doPara(%player);
 } 
else 
{ 
Player::trigger(%player, $BackpackSlot, false);
 remoteEval(Player::getClient(%player), BP, "<f0><jc>You must be falling to deploy the Parachute", 4);
 	} 
}
}
function hitGround(%player) {
 $ParaActivated[%player] = 0;
 remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Ready", 4);
}
