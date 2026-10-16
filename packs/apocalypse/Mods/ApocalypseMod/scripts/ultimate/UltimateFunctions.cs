function MakeTester(%player)
{
        %newarmor = $ArmorType[Client::getGender(%player), UltimaArmor];
        %oldarmor = Player::getArmor(%player);
        Player::setArmor(%player, %newarmor);
        Player::setItemCount(%player, $ArmorName[%oldarmor], 0);
        Player::setItemCount(%player, UltimaArmor, 1);

        %pack = Player::getMountedItem(%player,$BackpackSlot);
        Player::setItemCount(%player, %pack, 0);
        Player::setItemCount(%player, UltimaPack, 1);
        Player::mountItem(%player,UltimaPack,$BackpackSlot);
        giveArmorWeps(%player);
        giveArmorItems(%player);
}

//random armor list
$randomArmor[0] = QuicksilverArmor;
$randomArmor[1] = LightArmor;
$randomArmor[2] = CenturionArmor;
$randomArmor[3] = MediumArmor;
$randomArmor[4] = GuardianArmor;
$randomArmor[5] = HeavyArmor;
$randomArmor[6] = ApocalypseArmor;

function StripArmor(%player)
{
        if(Player::getMountedItem(%player,$FlagSlot) == Flag)
                Player::dropItem(%client,Flag);
        %client = Player::getClient(%player);
        $WeapMode[%client,GrenadeLauncher] = 1;
        $WeapMode[%client,Mortar] = 1;
        $WeapMode[%client,RangerMortar] = 1;
        $WeapMode[%client,Shotgun] = 1;
        $WeapMode[%client,ApocGun] = 1;
        $WeapMode[%client,RepulseGun] = 1;
        stripItems(%player);
        %rnd = floor(getRandom() * 7);
        %armor = $ArmorType[Client::getGender(%player), $randomArmor[%rnd]];
        Player::setArmor(%player, %armor);
        Player::setItemCount(%player, $ArmorName[%armor], 1);
        choosePack(%player,%armor);
        chooseWeapons(%player,%armor);
}

//--------------------------------------

function stripItems(%player)
{
        %max = getNumItems();
        for (%i = 0; %i < %max; %i++)
                Player::setItemCount(%player,getItemData(%i),0);
        return;

        //hope this shit aint needed
        for (%i = 0; %i < $NWeapons; %i++) {
                Player::setItemCount(%player,$Weap[%i],0);
                if($WeaponAmmo[$Weap[%i]] != "")
                        Player::setItemCount(%player,$WeaponAmmo[$Weap[%i]],0);
        }
        Player::setItemCount(%player,TargetingLaser,0);
        Player::setItemCount(%player,UltimaPack,0);
        Player::setItemCount(%player,Beacon,0);
        Player::setItemCount(%player,Grenade,0);
        Player::setItemCount(%player,MineAmmo,0);
        Player::setItemCount(%player,RepairKit,0);
}

function giveArmorWeps(%player)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %pack = Player::getMountedItem(%client,$BackpackSlot);
        for (%i = 0; %i <= $NWeapons; %i++)
        {
                %item = $Weap[%i];
                Player::setItemCount(%player, %item, $ItemMax[%armor, %item]);
                if($WeaponAmmo[%item] != "") {
                        if(%pack == ammopack || %pack == ultimapack) {
                                %extraammo = $AmmoPackMax[%item];
                        }
                        Player::setItemCount(%player, $WeaponAmmo[%item], $ItemMax[%armor, $WeaponAmmo[%item]]);
                }
        }
        Player::setItemCount(%player, TargetingLaser, $ItemMax[%armor, TargetingLaser]);
}

function giveArmorItems(%player)
{
        %client = Player::getClient(%player);
        %armor = Player::getArmor(%player);
        %pack = Player::getMountedItem(%client,$BackpackSlot);
        if(%pack == ammopack || %pack == ultimapack) {
                %Beacon = $APBeaconMax[%armor];
                %Grenade = $APGrenadeMax[%armor];
                %Mine = $AmmoPackMax[MineAmmo];
        }
        Player::setItemCount(%player, Beacon, $ItemMax[%armor, Beacon] + %Beacon);
        Player::setItemCount(%player, Grenade, $ItemMax[%armor, Grenade] + %Grenade);
        Player::setItemCount(%player, MineAmmo, $ItemMax[%armor, MineAmmo] + %Mine);
        Player::setItemCount(%player, RepairKit, $ItemMax[%armor, RepairKit]);
}
