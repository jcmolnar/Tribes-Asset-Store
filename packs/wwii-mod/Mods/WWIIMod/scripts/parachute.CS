ItemData TargetingLaser
{
   description = "Targeting Laser";
   shapeFile = "force";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	showinventory = false;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function TargetingLaser::onUse(%player,%item)
{
%client = player::getclient(%player);
if(%client.isreloading || !%client.canchangeweapon || %player.parachute) return;
parachute(%client);
}

ItemImageData ParachuteImage1 {
	shapeFile = "elevator_5x5";
	mountPoint = 4;
	mountOffset = { 0, 0, 14 };
};

ItemData Parachute1 {
	shapeFile = "breath";
	imageType = ParachuteImage1;
};

ItemImageData ParachuteImage2 {
	shapeFile = "elevator_5x5";
	mountPoint = 4;
	mountOffset = { 0, 2.9, 13 };
	mountrotation = { -1, 0, 0 };
};

ItemData Parachute2 {
	shapeFile = "breath";
	imageType = ParachuteImage2;
};

ItemImageData ParachuteImage3 {
	shapeFile = "elevator_5x5";
	mountPoint = 4;
	mountOffset = { 0, -2.9, 13 };
	mountrotation = { 1, 0, 0 };
};

ItemData Parachute3 {
	shapeFile = "breath";
	imageType = ParachuteImage3;
};

ItemImageData ParachuteImage4 {
	shapeFile = "elevator_5x5";
	mountPoint = 4;
	mountOffset = { 2.9, 0, 13 };
	mountrotation = { 0, 1, 0 };
};

ItemData Parachute4 {
	shapeFile = "breath";
	imageType = ParachuteImage4;
};

ItemImageData ParachuteImage5 {
	shapeFile = "elevator_5x5";
	mountPoint = 4;
	mountOffset = { -2.9, 0, 13 };
	mountrotation = { 0, -1, 0 };
};

ItemData Parachute5 {
	shapeFile = "breath";
	imageType = ParachuteImage5;
};



function parachute(%cl)
{
%pl = client::getownedobject(%cl);
%vel = Item::GetVelocity(%pl);
%vel_X = getword(%vel, 0);
%vel_Y = getword(%vel, 1);
%Vel_Z = getword(%vel, 2);

if(%Vel_Z < -20)
	{
	%pl.parachute = true;
	player::unmountitem(%pl, $WeaponSlot);
	player::mountItem(%pl, Parachute1, 4);
	player::mountItem(%pl, Parachute2, 5);
	player::mountItem(%pl, Parachute3, 6);
	player::mountItem(%pl, Parachute4, 3);
	player::mountItem(%pl, Parachute5, 0);
	%Vel_Z = -10;
	if(%Vel_X > 15) %Vel_X = 15;
	if(%Vel_X < -15) %Vel_X = -15;
	if(%Vel_Y > 15) %Vel_Y = 15;
	if(%Vel_Y < -15) %Vel_Y = -15;
	%newVelocity = %Vel_X @ " " @ %Vel_Y @ " " @ %Vel_Z;
	Item::SetVelocity(%pl, %newVelocity);
	schedule("Parachute_Process(" @ %pl @ ", \"" @ %newVelocity @ "\");", 0.5);
	bottomprint(%cl, "<jc><f2>PARACHUTE OPEN!", 1,PARACHUTE);
	}
}

function Parachute_Process(%pl, %vel)
{
%velocity = Item::GetVelocity(%pl);

%vel_Z = getword(%velocity, 2);

if(floor(%vel_Z) > -3)
	{
	%pl.parachute = false;
	player::unmountitem(%pl, 3);
	player::unmountitem(%pl, 4);
	player::unmountitem(%pl, 5);
	player::unmountitem(%pl, 6);
	player::unmountitem(%pl, 0);
	if(Player::isDead(%pl)) schedule("GameBase::StartFadeOut(" @ %pl @ ");", 30);
	else Parachute::Off(%pl);
	return;
	}
Item::setvelocity(%pl, %vel);
schedule("Parachute_Process(" @ %pl @ ", \"" @ %vel @ "\");", 0.4);
}

function Parachute::Off(%pl) { }