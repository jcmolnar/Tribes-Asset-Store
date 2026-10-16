//----------------------------------------------------------------------------

addToInv(ConverterPack,1,1);

setArmorItemMax(ConverterPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

//----------------------------------------------------------------------------

ItemImageData ConverterPackImage
{
        shapeFile = "shieldPack";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        minEnergy = -1;  // Energy used/sec for sustained weapons
        maxEnergy = 1;  // Energy used/sec for sustained weapons
        firstPerson = false;
};

ItemData ConverterPack
{
        description = "Damage Converter";
        shapeFile = "shieldPack";
        className = "Backpack";
   heading = $InvCatPacks;
        shadowDetailMask = 4;
        imageType = ConverterPackImage;
        price = 200;
        hudIcon = "ammopack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

$MountMSG[ConverterPack] = "<JC><F2>Damage Converter <F0>- <F1>Converts damage you take into something else.";

function ConverterPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function ConverterPack::onMount(%player, %item)
{
        Player::trigger(%player,$BackpackSlot,true);
}

function ConverterPack::onUnmount(%player,%item)
{
        if (Player::getMountedItem(%player,$WeaponSlot) == ShockGun)
                Player::unmountItem(%player,$WeaponSlot);
}
//--------------------------------------
//damage conversion and conversion functions by ProtoManX
//Types of effects Damage Converter gives
$UltimaType = -1;
$CloakType = 0;
$ShieldType = 1;
$JammerType = 2;
//Armors for the effect
$DCArmor[$CloakType] = QuicksilverArmor;
$DCArmor[$ShieldType] = ApocalypseArmor;
$DCArmor[$JammerType] = LightArmor;
//conversion
function DamageConversion(%this,%object,%value,%armor,%type)
{
        %damagedClient = Player::getClient(%this);
        %shooterClient = %object;
        %pack = Player::getMountedItem(%this,$BackpackSlot);
        if((%pack == ConverterPack || %pack == UltimaPack) && %shooterClient != %damagedClient && Client::getTeam(%shooterClient) != Client::getTeam(%damagedClient)) {
                %Tvalue = %value;
                if($DamageScale[%armor,%type] != "")
                        %Tvalue = $DamageScale[%armor,%type] * %value;
                //Shock code by Ice slightly modified by ProtoManX
                        //damage accumulation part:
                if(%Tvalue == 0)
                        return;
                if(Player::getItemCount(%this,"ShockGun") == 1) {        //- sees if player has a shockgun
                        %delta = %Tvalue * 100;
                        Player::incItemCount(%this,"ShockAmmo",%delta);
                        if(Player::getItemCount(%this,"ShockAmmo") >= 100) {
                                Player::setItemCount(%this,ShockAmmo,100);
                                Client::sendMessage(%damagedClient,0,"Shock ammo maxed out!");
                        }
                }
                else if($ArmorName[%armor] == QuicksilverArmor){
                        if(%this.cltime > 0)
                                %this.cltime += %Tvalue * 100;
                        else {
                                %this.cltime = %Tvalue * 100;
                                $DCGiven[%this,$CloakType] = true;
                                Cloak(%this);
                        }
                        if(%this.cltime >= 60){
                                %this.cltime = 60;
                                Client::sendMessage(%damagedClient,0,"You now have the max temporary cloak time of " @ %this.cltime @ " seconds!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have a temporary cloak time of " @ %this.cltime @ " seconds.");
                }
                else if($ArmorName[%armor] == LightArmor){
                        if(%this.sjtime > 0)
                                %this.sjtime += %Tvalue * 100;
                        else {
                                %this.sjtime = %Tvalue * 100;
                                $DCGiven[%this,$JammerType] = true;
                                Supression(%this);
                        }
                        if(%this.sjtime >= 60){
                                %this.sjtime = 60;
                                Client::sendMessage(%damagedClient,0,"You now have the max temporary sensor jammer time of " @ %this.sjtime @ " seconds!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have a temporary sensor jammer time of " @ %this.sjtime @ " seconds.");
                }
                else if(%Tvalue >= 0.2 && $ArmorName[%armor] == CenturionArmor){
                        %delta = %Tvalue/0.2;
                        Player::incItemCount(%this,"RepairKit",%delta);
                        if(Player::getItemCount(%this,"RepairKit") >= 5) {
                                Player::setItemCount(%this,RepairKit,5);
                                Client::sendMessage(%damagedClient,0,"You now have the max of " @ Player::getItemCount(%this,"RepairKit") @ " repair kits!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have " @ Player::getItemCount(%this,"RepairKit") @ " repair kits!");
                }
                else if(%Tvalue >= 0.15 && $ArmorName[%armor] == MediumArmor){
                        %delta = %Tvalue/0.15;
                        Player::incItemCount(%this,"MineAmmo",%delta);
                        if(Player::getItemCount(%this,"MineAmmo") >= 6) {
                                Player::setItemCount(%this,MineAmmo,6);
                                Client::sendMessage(%damagedClient,0,"You now have the max of " @ Player::getItemCount(%this,"MineAmmo") @ " mines!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have " @ Player::getItemCount(%this,"MineAmmo") @ " mines!");
                }
                else if(%Tvalue >= 0.2 && $ArmorName[%armor] == GuardianArmor) {
                        %delta = %Tvalue/0.2;
                        Player::incItemCount(%this,"Beacon",%delta);
                        if(Player::getItemCount(%this,"Beacon") >= 2) {
                                Player::setItemCount(%this,Beacon,2);
                                Client::sendMessage(%damagedClient,0,"You now have the max of " @ Player::getItemCount(%this,"Beacon") @ " beacons!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have " @ Player::getItemCount(%this,"Beacon") @ " beacons!");
                }
                else if(%Tvalue >= 0.2 && $ArmorName[%armor] == HeavyArmor){
                        %delta = %Tvalue/0.2;
                        Player::incItemCount(%this,"Grenade",%delta);
                        if(Player::getItemCount(%this,"Grenade") >= 5) {
                                Player::setItemCount(%this,Grenade,5);
                                Client::sendMessage(%damagedClient,0,"You now have the max of " @ Player::getItemCount(%this,"Grenade") @ " grenades!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have " @ Player::getItemCount(%this,"Grenade") @ " grenades!");
                }
                else if($ArmorName[%armor] == ApocalypseArmor){
                        if(%this.shtime > 0)
                                %this.shtime += %Tvalue * 100;
                        else {
                                %this.shtime = %Tvalue * 100;
                                $DCGiven[%this,$ShieldType] = true;
                                TempShield(%this);
                        }
                        if(%this.shtime >= 60){
                                %this.shtime = 60;
                                Client::sendMessage(%damagedClient,0,"You now have the max temporary shield time of " @ %this.shtime @ " seconds!");
                        }
                        else
                                Client::sendMessage(%damagedClient,0,"You now have a temporary shield time of " @ %this.shtime @ " seconds.");
                }
        }
}
