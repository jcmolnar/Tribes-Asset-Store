//***Dance steps and durations***
$DanceStepDur[6]  = 0.60; //-Jump
$DanceStepDur[7]  = 0.35; //-Crouch
//$DanceStepDur[14] = 0.40; //-Fall
//$DanceStepDur[15] = 0.90; //-HitGround
//$DanceStepDur[19] = 0.40; //-Jetpack
$DanceStepDur[20] = 0.65; //-Inventory
$DanceStepDur[21] = 1.25; //-Throw
//$DanceStepDur[36] = 3.75; //-KneelDeath
$DanceStepDur[38] = 1.65; //-OverHere
$DanceStepDur[39] = 0.60; //-Point
$DanceStepDur[40] = 2.40; //-Retreat
$DanceStepDur[41] = 0.77; //-Stop
$DanceStepDur[42] = 0.65; //-Salute
$DanceStepDur[43] = 1.70; //-Bow
$DanceStepDur[44] = 1.35; //-Spin
$DanceStepDur[45] = 1.80; //-JumpYeah
$DanceStepDur[46] = 1.35; //-TheBird
$DanceStepDur[47] = 1.80; //-NoNo
$DanceStepDur[49] = 1.20; //-StandPose
$DanceStepDur[50] = 0.53; //-Wave

$DanceStepName[6]  = "Jump";
$DanceStepName[7]  = "Crouch";
$DanceStepName[14] = "Fall";
$DanceStepName[15] = "HitGround";
$DanceStepName[19] = "Jetpack";
$DanceStepName[20] = "Inventory";
$DanceStepName[21] = "Throw";
$DanceStepName[36] = "Done";
$DanceStepName[38] = "OverHere";
$DanceStepName[39] = "Point";
$DanceStepName[40] = "Retreat";
$DanceStepName[41] = "Stop";
$DanceStepName[42] = "Salute";
$DanceStepName[43] = "Bow";
$DanceStepName[44] = "Spin";
$DanceStepName[45] = "JumpYeah";
$DanceStepName[46] = "TheBird";
$DanceStepName[47] = "NoNo";
$DanceStepName[49] = "StandPose";
$DanceStepName[50] = "Wave";

$SkinName["base"]   = "Silver";
$SkinName["beagle"] = "Blood";
$SkinName["blue"]   = "Blue";
$SkinName["green"]  = "Green";
$SkinName["orange"] = "Gold";
$SkinName["purple"] = "Purple";

function SayCMD::dance(%clientId,%msg)
{
	if(getSimTime() > %clientId.lastDancetime + 5) {
		if(%clientId.isDancing)
			%clientId.isDancing = "";
		else {
			if(%msg == "new") {
				//processMenuDanceNew(%clientId);
			}
			else {
				%player = Client::getOwnedObject(%clientId);
				%clientId.isDancing = true;
				Dance::Loop(%player);
			}
		}
		%clientId.lastDancetime = getSimTime();
	}
}

function processMenuDanceNew(%clientId,%opt)
{
	%op1 = getWord(%opt,0);
	%op2 = getWord(%opt,1);
	%op3 = getWord(%opt,2);
	if(%op1 == "addStep") {
		if(%op2 > 0) {
			
		}
	}
	else if(%op1 == "done") {
		
	}
	%curItem = 0;
	%step = 1;
	Client::buildMenu(%clientId,"New Dance: Step "@%step,"DanceNew",true);
	%num = 0;
	Client::addMenuItem(%clientId,%curItem++@$DanceStepName[%num],"addStep "@%num);
	return;
}

function Dance::loop(%player)
{
	%clientId = Player::getClient(%player);
	if(%clientId.isDancing) {
		if(Vector::speed(%player) < 0.5) {
			%rand = Dance::randStep();
			Player::setAnimation(%player,%rand);
			//bottomPrint(%clientId,"<jc><f2>"@$DanceStepName[%rand],4);
			schedule("Dance::loop("@%player@");",$DanceStepDur[%rand],%player);
		}
		else
			%clientId.isDancing = "";
	}
}

function Dance::randStep()
{
	%count = -1;
	for(%i = 0; %i <= 50; %i++) {
		if($DanceStepDur[%i] != "") {
			%step[%count++] = %i;
		}
	}
	%rand = floor(getRandom()*(%count-0.01));
	return %step[%rand];
}

function SayCMD::starMode(%clientId,%msg)
{
	if(!%clientId.isFlashing) {
		%player = Client::getOwnedObject(%clientId);
		%clientId.isFlashing = true;
		Skin::flashLoop(%player);
	}
	else if(%msg == "hold") {
		%clientId.isFlashing = "";
		%skin = Client::getSkinBase(%clientId);
		bottomPrint(%clientId,"<jc><f1>Your new skin is <f2>"@$SkinName[%skin]@"<f1> !",3);
	}
	else {
		%clientId.isFlashing = "";
		Client::setSkin(%clientId,$Client::info[%clientId,0]);
	}
}

function Skin::flashLoop(%player)
{
	%clientId = Player::getClient(%player);
	if(%clientId.isFlashing) {
		%rand = radnomItems(6,"base","beagle","blue","green","orange","purple");
		Client::setSkin(%clientId,%rand);
		schedule("Skin::flashLoop("@%player@");",0.05,%player);
	}
}
