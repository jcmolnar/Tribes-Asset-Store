$Aeon::invStyle[Armor0] = "held";
$Aeon::invStyle[Armor1] = "held";
$Aeon::invStyle[Armor2] = "held";
$Aeon::invStyle[Armor3] = "held";

$Aeon::Armor[Armor0,Male]	= larmor;
$Aeon::Armor[Armor0,Female]	= lfemale;
$Aeon::Armor[Armor1,Male]	= larmor1;
$Aeon::Armor[Armor1,Female]	= lfemale1;
$Aeon::Armor[Armor2,Male]	= larmor2;
$Aeon::Armor[Armor2,Female]	= lfemale2;
$Aeon::Armor[Armor3,Male]	= larmor3;
$Aeon::Armor[Armor3,Female]	= lfemale3;

function Aeon::getArmor(%player)
{
	%clientId = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	%gend = Client::getGender(%clientId);
	for(%i = 0; $Aeon::Armor["Armor"@%i,%gend] != ""; %i++) {
		if($Aeon::Armor["Armor"@%i,%gend] == %armor)
			return "Armor"@%i;
	}
}

function Aeon::convertArmor(%armor)
{
	%gend = "Male";
	if(String::findSubStr(%armor,"female") >= 0)
		%gend = "Female";
	for(%i = 0; $Aeon::Armor["Armor"@%i,%gend] != ""; %i++) {
		if($Aeon::Armor["Armor"@%i,%gend] == %armor)
			return "Armor"@%i;
	}
}

function Aeon::setArmor(%player,%data)
{
	if(!%player)
		return;
	%clientId = Player::getClient(%player);
	%gend = Client::getGender(%clientId);
	%armor = $Aeon::Armor[%data,%gend];
	Player::setArmor(%clientId,%armor);
}

function Soul::onAdd(%this)
{
	
}

function Soul::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(getSimTime() - %clientId.lastSoulTime < 10.0)
		return;
	%clientId.lastSoulTime = getSimTime();
	%pos = GameBase::getPosition(%player);
	%rot = GameBase::getRotation(%player);
	%pos = Vector::add(%pos,Vector::getFromRot(%rot,2));
	%obj = AI::spawn("Drone3",Aeon::getArmor(%player),%pos,%rot,"Bob","male2");
	%count = Player::getItemCount(%clientId,%item);
	Player::setItemCount(%player,%item,%count-1);
	Item::playPickupSound(%obj);
	Aeon::ExportInfo(%clientId);
}