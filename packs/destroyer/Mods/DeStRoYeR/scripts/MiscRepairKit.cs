//--------------------------------------

$InvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;

//--------------------------------------



//--------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	if(!$build)Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

//--------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "gMiscellany";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = true;
   validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	if(!$build)Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}

//--------------------------------------