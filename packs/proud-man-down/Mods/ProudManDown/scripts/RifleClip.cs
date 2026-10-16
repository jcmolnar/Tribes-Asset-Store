//-----------------------------------------------------------\\
//                        Made By:Ice                        \\
//                        Fixed By: |K0RN|                   \\
//-----------------------------------------------------------\\


$Clip[DiscLauncher] = RifleClip;//Defines the clip

$ClipSize[DiscLauncher] = 8;//Clip Size

$ClipTime[DiscLauncher] = 3.0;//Reload Time

ItemData Clip
{
	description = "Clip";
	showInventory = false;
};

function Clip::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		if(%count > 0) {
			%obj = newObject("","Item",%item,1,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Clip::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	%clip = $Clip[%weapon];
	if(%weapon != "") {
		if(Player::getItemCount(%player,%weapon) != 0) {
			if(%Clip != "") {
				if(Player::getItemCount(%player, %Clip) > 0)
					schedule("Reload("@%player@","@%weapon@",$ClipTime["@%weapon@"]);",0.5,%player);
				else
					bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
			}
		}
	}
}

function Reload(%player,%weapon,%RDPer)
{
	%client = Player::getclient(%player);
	$Reloading[%client] = 1;
	//Player::unMountItem(%player, %weapon);//Makes the gun dissapear when reloading:X
	if(%weapon == DiscLauncher) 
        {
		schedule("GameBase::playSound("@%player@",SoundPickupItem,"@0@");",%RDPer*2/3,%player);
		schedule("GameBase::playSound("@%player@",SoundPickupBackpack,"@0@");",%RDPer*1/3,%player);
	}
	schedule("Player::setAnimation("@%player@"," @21@");", %RDPer-1.13);
	schedule("Player::setItemCount("@%player@"," @%weapon.imageType.ammoType@"," @$ClipSize[%weapon]@");",%RDPer);
	//schedule("Player::MountItem("@%player@ "," @%weapon@ "," @$WeaponSlot@ ");",%RDPer);
	ReloadProgress(%client,%RDPer,-10);
	Player::decItemCount(%player, $Clip[%weapon]);
	schedule("$Reloading["@%client@"] = 0;",%RDPer++);
}

function ReloadProgress(%client,%time,%prog)
{
	if(%prog < 100) {
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%"@%prog+=10,%time/5);
		schedule("ReloadProgress("@%client@","@%time@","@%prog@");",%time/10);
//Addin
			Player::setAnimation(%player, 21);
//End Addin
	}
	else
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%100",1);
}

function Weapon::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	if(%player.Station == "") {
		%ammo = %item.imageType.ammoType;
		Player::mountItem(%player,%item,$WeaponSlot);
		//PORT-OFF: Weapon::descriptionMSG(%client,%item);
		if(%ammo < 0 && $Clip[%item] < 0)
			bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
		if(%ammo < 0 && $Clip[%item] > 0)
			Player::useItem(%player,$Clip[%item]);
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	%clip = $Clip[%itemType];
	if(%clip != "") {
		%clipCount = Player::getItemCount(%player,%clip);
		if(%clipCount > 0)
			Player::useItem(%player,%clip);
		else
			bottomprint(Player::getClient(%player), "<jc><f0>Out of Clips!!!", 2);
	}
}

//-Clip Image

ItemData RifleClip
{
        description = "Rifle Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 30;
};

//-Just the Inventory Stuff
$ItemMax[larmor, RifleClip] = 4;
$ItemMax[lfemale, RifleClip] = 4;
$ItemMax[marmor, RifleClip] = 4;
$ItemMax[mfemale, RifleClip] = 4;
$ItemMax[harmor, RifleClip] = 4;
$InvList[RifleClip] = 1;