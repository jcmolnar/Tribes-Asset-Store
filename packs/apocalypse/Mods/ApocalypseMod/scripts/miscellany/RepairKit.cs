//--------------------------------------
addToInv(RepairKit,1,1);

setArmorItemMax(RepairKit,1,1,1,1,1,1,1, 9, 3,4,1,1);

//--------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = $InvCatMisc;
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%armor = $ArmorName[Player::getArmor(%object)];
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
		else if(%armor == ProtoArmor)
			FillTank(%this,%object);
	}
}

function RepairKit::onUse(%player,%item)
{
	%armor = $ArmorName[Player::getArmor(%player)];
	eval(%armor @ "::onRepair(" @ %player @ ", " @ %item @ ");");
//	  if(GameBase::getDamageLevel(%player)) {
//		  if(%armor == ProtoArmor)
//			  TankCheck(%player,%item);
//		  else if(%armor == SaiyanArmor || %armor == SSaiyanArmor)
//			  schedule("Heal("@%player@","@%player@","@%item@");",1.0);
//		  else {
//			  Player::decItemCount(%player,%item);
//			  GameBase::repairDamage(%player,0.2);
//		  }
//	  }
//	  else if(%armor == SaiyanArmor || %armor == SSaiyanArmor)
//		  HealCheck(%player,%item);
}

//--------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = $InvCatMisc;
	shadowDetailMask = 4;
	price = 2;
   validateShape = true;
   validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%armor = $ArmorName[Player::getArmor(%object)];
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			Repair::checkStatus(%object,3);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
		else if(%armor == ProtoArmor)
			FillTank(%this,%object);
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}

//--------------------------------------

ItemData PCapsule
{
	description = "Power Capsule";
	className = "Repair";
	shapeFile = "plasmatrail";
   heading = "nTank Contents";
	shadowDetailMask = 4;
	price = 0;
};

//--------------------------------------

ItemData WCapsule
{
	description = "Weapon Capsule";
	className = "Repair";
	shapeFile = "enbolt";
   heading = "nTank Contents";
	shadowDetailMask = 4;
	price = 0;
};
