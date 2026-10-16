// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData MineAmmo
{
    description = "Mine";
    shapeFile = "mineammo";
    heading = "eMiscellany";
    shadowDetailMask = 4;
    price = 10;
    className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
    if($matchStarted)
    {
        if(%player.throwTime < getSimTime() )
        {
            Player::decItemCount(%player,%item);
            %obj = newObject("","Mine","antipersonelMine");
            addToSet("MissionCleanup", %obj);
            %client = Player::getClient(%player);
            GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
            %player.throwTime = getSimTime() + 0.5;
        }
    }
}
