// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
ItemData RepairKit
{
description = "Repair Kit";
shapeFile = "armorKit";
heading = "eMiscellany";
shadowDetailMask = 4;
price = 35;
validateShape = true;
validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
Player::decItemCount(%player,%item);
GameBase::repairDamage(%player,0.2);
}
