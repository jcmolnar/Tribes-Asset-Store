
function aarmor::onGrenade(%player)
{
	%obj = newObject("","Mine","empgrenade");
	Armor::ThrowGrenade(%player, %obj);
}

function aarmor::onBeacon(%player, %item)
{
	startCloak(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
function afemale::onGrenade(%player)
{
	%obj = newObject("","Mine","grenade");
	Armor::ThrowGrenade(%player, %obj);

}

function afemale::onBeacon(%player, %item)
{
	startCloak(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
//-------------------------------------------------------------------
function barmor::onGrenade(%player)
{
	%obj = newObject("","Mine","Incgrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function barmor::onBeacon(%player, %item)
{
	BuilderBeacon(Player::getClient(%player), %player, %item);
}
function bfemale::onGrenade(%player)
{
	%obj = newObject("","Mine","Incgrenade");
	Armor::ThrowGrenade(%player, %obj);

}
function bfemale::onBeacon(%player, %item)
{
	BuilderBeacon(Player::getClient(%player), %player, %item);
}
//--------------------------------------------------------------------
function narmor::onGrenade(%player)
{
	%obj = newObject("","Mine","psygrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function narmor::onBeacon(%player, %item)
{
	startCloak(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
function nfemale::onGrenade(%player)
{
	%obj = newObject("","Mine","psygrenade");
	Armor::ThrowGrenade(%player, %obj);

}
function nfemale::onBeacon(%player, %item)
{
	startCloak(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
//--------------------------------------------------------------------
function warmor::onGrenade(%player)
{
	%obj = newObject("","Mine","Handgrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function warmor::onBeacon(%player, %item)
{
	if(%player.usedbeacon)
		Client::sendMessage(Player::getClient(%player),0, "Your jets must cool down!");
	else
	{
		Armor::SpeedBooster(%player, %item, 300);
		%player.usedbeacon = true;
		schedule("JetAgain(" @ %player @ ");",2.5);
	}
}
function wfemale::onGrenade(%player)
{
	%obj = newObject("","Mine","Handgrenade");
	Armor::ThrowGrenade(%player, %obj);

}
function wfemale::onBeacon(%player, %item)
{
	if(%player.usedbeacon)
		Client::sendMessage(Player::getClient(%player),0, "Your jets must cool down!");
	else
	{
		Armor::SpeedBooster(%player, %item, 300);
		%player.usedbeacon = true;
		schedule("JetAgain(" @ %player @ ");",2.5);
	}
}
//--------------------------------------------------------------------
function avarmor::onGrenade(%player)
{
	%obj = newObject("","Mine","bombgrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function avarmor::onBeacon(%player, %item)
{
	startShield(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
//--------------------------------------------------------------------
function darmor::onGrenade(%player)
{
	%obj = newObject("","Mine","Mechgrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function darmor::onBeacon(%player, %item)
{
	startShield(Player::getClient(%player), %player);
	if(!$build)Player::decItemCount(%player, %item);
}
//--------------------------------------------------------------------
function sarmor::onGrenade(%player)
{
	%obj = newObject("","Mine","Mechgrenade");
	Armor::ThrowGrenade(%player, %obj);
}
function sarmor::onBeacon(%player, %item)
{
	if(%player.usedbeacon)
		Client::sendMessage(Player::getClient(%player),0, "Your jets must cool down!");
	else
	{
		Armor::SpeedBooster(%player, %item, 300);
		%player.usedbeacon = true;
		schedule("JetAgain(" @ %player @ ");",2.5);
	}
}
//--------------------------------------------------------------------
function JetAgain(%player)
{
	%player.usedbeacon = false;
}