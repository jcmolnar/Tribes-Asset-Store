// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData Grenade
{
    description = "Grenade";
    shapeFile = "grenade";
    heading = "eMiscellany";
    shadowDetailMask = 4;
    price = 5;
    className = "HandAmmo";
    validateShape = true;
    validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
    if($matchStarted)
    {
        if(%player.throwTime < getSimTime() )
        {
            Player::decItemCount(%player,%item);
            %obj = newObject("","Mine","Handgrenade");
            addToSet("MissionCleanup", %obj);
            %client = Player::getClient(%player);
            GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
            %player.throwTime = getSimTime() + 0.5;
        }
    }
}

