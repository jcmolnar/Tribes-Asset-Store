$Aeon::InteractFuncs[""] = "";
$Aeon::InteractFuncs[Player] = true;
//----------------------------------------------------------------------------
function Interact::onUse(%player)
{
	%clientId = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,4)) {
		%obj = $los::object;
		%lPs = $los::position;
		$los::object = "";
		$los::position = "";
		%type = getObjectType(%obj);
		%func = $Aeon::InteractFunc[%obj];
		%name = "False";
		if(%type == "InteriorShape")
			%name = Object::getName(%obj);
		if((%name == "False" || %name == "") && %func != "")
			%name = %func;
		if((%name == "False" || %name == "") && %type == "StaticShape")
			%name = GameBase::getDataName(%obj);
		if((%name == "False" || %name == "") && $Aeon::InteractFuncs[%type] != "") {
			%name = %type;
			%func = $Aeon::InteractFuncs[%type];
		}
		//echo(%type@" : "@%name@" : "@%func);
		if(%func != "" && %name != "False")
			Eval(%name@"::onInteract("@%obj@",\""@%player@"\");");
	}
}

function Player::onInteract(%this,%player)
{
	if(Player::isAiControlled(%this)) {
		AI::onInteract(%this,%player);
		return;
	}
}