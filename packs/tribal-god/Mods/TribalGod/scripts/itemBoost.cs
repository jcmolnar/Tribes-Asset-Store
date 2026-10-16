AddToInv(Beacon, 1, 0);
ItemMax(Beacon, 100, 100, 175, 175, 250, 150);

ItemData Beacon {
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Beacon::onUse(%player, %item) {
	if($matchStarted && %player.throwTime < getSimTime()){
		if(Player::getArmor(%player) != "Earmor"){
			%player.throwTime = getSimTime() + 0.2;
			%obj = newObject("", "Mine", "Boost");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj, %player, 0, false);
			Client::sendMessage(Player::getClient(%player), 0, "Speed Boost Used.");
		}else{
			%player.throwTime = getSimTime() + 0.2;
			%obj = newObject("", "Mine", "EngineerBoost");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj, %player, 0, false);
			Client::sendMessage(Player::getClient(%player), 0, "Speed Boost Used*");
		}
		if($TG::InfiniteAmmo:Boosts != true)
		{ Player::decItemCount(%player,%item); }
	}
}