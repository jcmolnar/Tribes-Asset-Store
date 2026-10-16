//-----------------------------------------
// MineAmmo.cs
// Dustin G Bruce
// August 10th, 2003 6:06pm
//-----------------------------------------
createMisc(MineAmmo, false, 1, 1, 3, 3, 3, 1, 35);
AmmoPack::addAmmo(MineAmmo, 5);

ItemData MineAmmo {
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item){
	if(!$matchStarted) return;
	if(%player.throwTime < getSimTime()){
		Player::decItemCount(%player,%item);
		%obj = newObject("", "Mine", "antipersonelMine");
	 	addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		GameBase::throw(%obj, %player, 15 * %client.throwStrength, false);
		%player.throwTime = getSimTime() + 0.5;
	}
}