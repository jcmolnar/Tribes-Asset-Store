//-----------------------------------------
// Grenade.cs
// Author: Dustin Bruce.
// Started: August 10th, 2003 6:26pm
//-----------------------------------------
createMisc(Grenade, "", 1, 1, 5, 6, 8, 8, "");
AmmoPack::addAmmo(Grenade, 10);

ItemData Grenade {
	description = "Grenade";
	shapeFile = "grenade";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	validateShape = true;
	validateMaterials = true;
};

function Grenade::onUse(%player, %item){
	if(!$matchStarted) return;
	if(%player.throwTime < getSimTime()){
		Player::decItemCount(%player,%item);
		%obj = newObject("","Mine","Handgrenade");
		addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
		%player.throwTime = getSimTime() + 0.5;
	}
}