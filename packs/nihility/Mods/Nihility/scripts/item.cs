//================================================================================================================================================================//
//================================================================================================================================================================//
//This mod has been a real pain in the ass to make, but at the same time very rewarding and exciting!!!                                                         ==//   
//If you are a beginner at this kinda stuff like I was,                                                                                                         ==//   
//I would recommend on not looking at my mod for scripts.                                                                                                       ==//   
//Just because...just because it will confuse you. Go to ppl like the ppl I will list if you read on.                                                           ==//   
//BUT B4 YOU DO, MENTALLY PREPARE YOURSELF FOR HOURS AND HOURS OF WORK!!!                                                                                       ==//   
//Also, accept that fact that answers will not be given to you.                                                                                                 ==//   
//XXXXXXXXXXXXXXXX!THANK YOU!XXXXXXXXXXXXXXXX//                                                                                              ==//
//Special Thanks to: 																		==//
//		    Sevnn (Annihilation MOD) for guidance, and patience with my stupid questions. This guy is the man, he helps everyone!			==//
//		    King Tomato, for being the first and only person to actually look at my MOD!!                                                               ==//
//		    Outlaw for crucial scripts, mainly the Navigator Pack                                                                                       ==//
//		    Plasmatic(SeX MOD) - THE KING!                                                                                                              ==//
//	Here is a list of things that I made from scratch - or almost from scratch - or have some very original part to them.                                   ==//
//		Nihility Pistol                                                                                                                                 ==//
//		Lightning Gun                                                                                                                                   ==//
//		Blastomatic 3000																==//
//		Negatron Beam - ORIGINAL firing function by Plasmatic. However, I have added several features and effects					==//
//		Laser Gattling Gun w/ weapon options - harder than it sounds, this took me a lot of work and can be found in no other mod!			==//
//		Zettawatt Shotung - the image is especially cool - the firing function for the shotgun mode was from Plasmatic					==//
//		Dart Gun - Nematocyst mode - whoever thought of a shotgun dart rifle?										==//
//		Mercury Cannon - kinda resembles the Godhammer (I think) from Shifter - but I made it on my own.						==//
//		Guided Missile Launcher - I gave it a cool new image												==//
//		Wraith Pack - Plasmatic made this pack possible. However, I added the animated image on activation and the drop through floor mode		==//
//		Hyperdrive Pack - warp shockwave effects													==//
//		Molecular Accelerator - I think meltdown has something like this, but I made it with my own brain.						==//
//	If you use these things, give me credit plz...I earned it!!! I have worked long and hard to get where I am today.					==//
// NIHILITY BY = AUTO		EMAIL =	norton@3d-ring.zzn.com		SITE = www.postnuclear.net/orb/nihility		AIM = AtomicAtom666			==//
//================================================================================================================================================================//
//================================================================================================================================================================//

//Free slots :: 4,5,6,7 <<< good to know...

$ItemFavoritesKey = "nihilityV14Rev1"; 
$ItemPopTime = 30; 
$ToolSlot=0; $WeaponSlot=0; 
$BackpackSlot=1; 
$FlagSlot=2; 
$DefaultSlot=3; 








DamageSkinData objectDamageSkins 
{ 
bmpName[0] = "dobj1_object"; 
bmpName[1] = "dobj2_object"; 
bmpName[2] = "dobj3_object"; 
bmpName[3] = "dobj4_object"; 
bmpName[4] = "dobj5_object"; 
bmpName[5] = "dobj6_object"; 
bmpName[6] = "dobj7_object"; 
bmpName[7] = "dobj8_object"; 
bmpName[8] = "dobj9_object"; 
bmpName[9] = "dobj10_object"; 
}; 



$totalNumAlarms[-1] = 0;
$totalNumAlarms[0] = 0;
$totalNumAlarms[1] = 0;
$totalNumAlarms[2] = 0;
$totalNumAlarms[3] = 0;
$totalNumAlarms[4] = 0;
$totalNumAlarms[5] = 0;
$totalNumAlarms[6] = 0;
$totalNumAlarms[7] = 0;






function teamEnergyBuySell(%player,%cost) { 
%client = Player::getClient(%player); 
%team = Client::getTeam(%client); 
%station = %player.Station; 
%stationName = GameBase::getDataName(%station); 
if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
{ 
%station.Energy += %cost; 
if(%station.Energy < 1) %station.Energy = 0;
 }
 else 
if($TeamEnergy[%team] != "Infinite") { 
$TeamEnergy[%team] += %cost; 
%client.teamEnergy += %cost; } 
} 



function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19) 
{ 
%time = getIntegerTime(true) >> 4; 
if(%time <= %client.lastBuyFavTime) return; 
%client.lastBuyFavTime = %time; 
%station = (Client::getOwnedObject(%client)).Station; 
if(%station != "" ) { 
%stationName = GameBase::getDataName(%station); 
if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) %energy = %station.Energy; else 
%energy = $TeamEnergy[Client::getTeam(%client)]; 
if(%energy == "Infinite" || %energy > 0) 
{ %error = 0; 
%bought = 0; 
%max = getNumItems(); 
for (%i = 0; %i < %max; %i = %i + 1) 
{ 
%item = getItemData(%i); 
if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) 
{ 
%count = Player::getItemCount(%client,%item); 
if(%count) 
{ 
if(%item.className != Armor) teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count)); 
Player::setItemCount(%client, %item, 0); } } } 
for (%i = 0; %i < 20; %i++) 
{ 
if(%favItem[%i] != "") 
{ 
%item = getItemData(%favItem[%i]); 
if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) 
{ 
if(!buyItem(%client,%item)) 
%error = 1; 
else %bought++; } } } 
if(%bought) 
{ 
if(%error) Client::sendMessage(%client,0,"~wC_BuySell.wav"); 
else Client::SendMessage(%client,0,"~wbuysellsound.wav"); } updateBuyingList(%client); } } 
} 



function replenishTeamEnergy(%team) 
{ 
$TeamEnergy[%team] += $incTeamEnergy; 
schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy); 
} 




function checkResources(%player,%item,%delta,%noMessage) 
{ 
%client = Player::getClient(%player); 
%team = Client::getTeam(%client); 
%extraAmmo = 0 ; 
if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
{ 
%extraAmmo = $AmmoPackMax[%item]; 
if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
%delta = %delta + %extraAmmo; 
} 
if($TestCheats == 0 && %client.spawn == "") { %energy = $TeamEnergy[%team]; 
%station = %player.Station; 
%sName = GameBase::getDataName(%station); 
if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
{ 
%energy = %station.Energy; 
} 
if(%energy != "Infinite") 
{ 
if (%item.price * %delta > %energy) 
%delta = %energy / %item.price; 
if(%delta < 1 ) { if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left"); 
return 0; } } 
} 
if(%item.className == Weapon) { %armor = Player::getArmor(%client); 
%wcount = Player::getItemClassCount(%client,"Weapon"); 
if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) { 
Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry"); 
return 0; } 
} else 
if(%item == RepairPatch) { %pDamage = GameBase::getDamageLevel(%player); 
if(GameBase::getDamageLevel(%player) > 0) return 1; return 0; 
} else 
if($TeamItemMax[%item] != "" && !$TestCheats) 
{ 
if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) 
{ 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return 0; } 
} 
if(%item.className != Armor && %item.className != Vehicle) 
{ 
%count = Player::getItemCount(%client,%item); 
%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ; 
if(%delta + %count >= %max) %delta = %max - %count; 
} return %delta; 
} 


function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	
		
	if(%armor == "harmor1" || %armor == "harmor2" || %armor == "harmor3")
		return;
	
	
	if ((Client::isItemShoppingOn(%client,%item) || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle)) 
	{
		if (%item.className == Armor) 
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) 
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					Player::setItemCount(%client, $ArmorName[%armor], 0);  
					Player::setItemCount(%client, %item, 1); 
					
					// Auto buy pack
//					if (%buyarmor == "armorTroll")
//						buyItem(%client,"RegenerationPack");
					//if (%buyarmor == "aarmor" || %buyarmor == "earmor")
					//	buyItem(%client,"Laptop");
					if (%buyarmor == "marmor")
					{
						if (%client.GrenadeLauncher == 3)
						%client.GrenadeLauncher = 0;
					}
					if (%buyarmor == "barmor")
					{
						if (%client.Steny == 1)
						%client.Steny = 0;
					}
					if (%buyarmor == "darmor")
					{
						if (%client.Steny == 2)
						%client.Steny = 0;
					}
					if (%buyarmor == "barmor")
					{
						if (%client.GrenadeLauncher == 3)
						%client.GrenadeLauncher = 0;
					}
					if (%buyarmor == "darmor")
					{
						if (%client.GrenadeLauncher == 3)
						%client.GrenadeLauncher = 0;
					}

					if (%buyarmor == "earmor" || %buyarmor == "efemale")
					{
						if (%client.chaingun == 2)
						%client.chaingun = 0;
					}
					if (%buyarmor == "larmor" || %buyarmor == "lfemale")
					{
						if (%client.chaingun == 2)
						%client.chaingun = 0;
					}
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);
					if($Annihilation::ShoppingList && %client.invo)
						setupShoppingList(%client,%client.invo,%client.ListType); // armor based list
						
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) 
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0) 
					{
						Player::setItemCount(%client, LaserRifle , 0);
						Client::sendMessage(%client,0,"Sold Energy Pack - Laser Rifle non-functional");
						//remoteSellItem(%client,22);						
					}
				}
				//
				else if(%pack == Gamma) 
				{
					if(Player::getItemCount(%client,"Nukes") > 0) 
					{
						Player::setItemCount(%client, Nukes , 0);
						Client::sendMessage(%client,0,"Sold Deut. Battery - Nuke Launcher disabled");
						//remoteSellItem(%client,23);						
					}
				}
				//===
				else if(%pack == IonPack) 
				{
					if(Player::getItemCount(%client,"Titan") > 0) 
					{
						Player::setItemCount(%client, Titan , 0);
						Client::sendMessage(%client,0,"Sold Ion Gen - Negatron Beam disabled");
						//remoteSellItem(%client,24);						
					}
				}
				//
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}				
			if (checkResources(%player,%item,1) || $testCheats) 
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) 
		{
			if(checkResources(%player,%item,1)) 
			{
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) 
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				//
				if(%item == Titan && Player::getItemCount(%client,"IonPack") == 0) 
				{
					buyItem(%client,"IonPack");
					Client::sendMessage(%client,0,"Bought Negatron Beam - Auto buying Ion Gen");
				}
				//===
				if(%item == Nukes && Player::getItemCount(%client,"Gamma") == 0) 
				{
					buyItem(%client,"Gamma");
					Client::sendMessage(%client,0,"Bought Nuke Launcher - Auto buying Deut. Battery");
				}
				//
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") 
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) 
					{
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			 %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}


function armorChange(%client) { %player = Client::getOwnedObject(%client); if(%client.respawn == "" && %player.Station != "") { %sPos = GameBase::getPosition(%player.Station); %pPos = GameBase::getPosition(%client); %posX = getWord(%sPos,0); %posY = getWord(%sPos,1); %posZ = getWord(%pPos,2); %vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1); %newPosX = (getWord(%vec,0) * 1) + %posX; %newPosY = (getWord(%vec,1) * 1) + %posY; GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ); } } 



function remoteBuyItem(%client,%type) { %item = getItemData(%type); if(buyItem(%client,%item)) { Client::sendMessage(%client,0,"~wbuysellsound.wav"); updateBuyingList(%client); } else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav"); } 



function remoteSellItem(%client,%type) { %item = getItemData(%type); %player = Client::getOwnedObject(%client); if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) { if(Player::getItemCount(%client,%item) && %item.className != Armor) { %numsell = 1; if(%item.className == Ammo || %item.className == HandAmmo) { %count = Player::getItemCount(%client, %item); if(%count < $SellAmmo[%item]) %numsell = %count; else %numsell = $SellAmmo[%item]; } else if (%item == ammopack) checkMax(%client,Player::getArmor(%client)); else if($TeamItemMax[%item] != "") { if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--; } else if(%item == EnergyPack) { if(Player::getItemCount(%client,"LaserRifle") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); remoteSellItem(%client,22); } } teamEnergyBuySell(%player,%item.price * %numsell); Player::setItemCount(%player,%item,(%count-%numsell)); updateBuyingList(%client); Client::SendMessage(%client,0,"~wbuysellsound.wav"); return 1; } } Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav"); } 




function remoteUseItem(%client,%type) { %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) %item = Player::getMountedItem(%client,$BackpackSlot); else { if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot); } Player::useItem(%client,%item); } 



function remoteThrowItem(%client,%type,%strength) { %item = getItemData(%type); if (%item == Grenade || %item == MineAmmo) { if (%strength < 0) %strength = 0; else if (%strength > 100) %strength = 100; %client.throwStrength = 0.3 + 0.7 * (%strength / 100); Player::useItem(%client,%item); } } 



function remoteDropItem(%client,%type) { if((Client::getOwnedObject(%client)).driver != 1) { %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) { %item = Player::getMountedItem(%client,$BackpackSlot); Player::dropItem(%client,%item); } else if (%item == Weapon) { %item = Player::getMountedItem(%client,$WeaponSlot); Player::dropItem(%client,%item); } else if (%item == Ammo) { %item = Player::getMountedItem(%client,$WeaponSlot); if(%item.className == Weapon) { %item = %item.imageType.ammoType; Player::dropItem(%client,%item); } } else Player::dropItem(%client,%item); } } 


function remoteDeployItem(%client,%type) { %item = getItemData(%type); Player::deployItem(%client,%item); } 

//=================
//  WEAPON ORDER
//=================
$NextWeapon[Nihility] = DiscLauncher; 
$NextWeapon[DiscLauncher] = Chaingun; 
$NextWeapon[Chaingun] = KShredder; 
$NextWeapon[KShredder] = TranqGun; 
$NextWeapon[TranqGun] = Railgun; 
$NextWeapon[Railgun] = LaserRifle; 
$NextWeapon[LaserRifle] = Gatling; 
$NextWeapon[Gatling] = Titan; 
$NextWeapon[Titan] = Steny; 
$NextWeapon[Steny] = Sten; 
$NextWeapon[Sten] = GrenadeLauncher; 
$NextWeapon[GrenadeLauncher] = Mortarr; 
$NextWeapon[Mortarr] = Mortar; 
$NextWeapon[Mortar] = Diablo; 
$NextWeapon[Diablo] = Nukes; 
$NextWeapon[Nukes] = Rocket; 
$NextWeapon[Rocket] = Guided; 
$NextWeapon[Guided] = Blaster; 
$NextWeapon[Blaster] = EnergyRifle; 
$NextWeapon[EnergyRifle] = WaveGun; 
$NextWeapon[WaveGun] = PlasmaGun; 
$NextWeapon[PlasmaGun] = Plasmaii; 
$NextWeapon[Plasmaii] = XHChaingun; 
$NextWeapon[XHChaingun] = Fixit; 
$NextWeapon[Fixit] = Hack; 
$NextWeapon[Hack] = Tract; 
$NextWeapon[Tract] = ReTract; 
$NextWeapon[ReTract] = Grap; 
$NextWeapon[Grap] = Riot; 
$NextWeapon[Riot] = BeaconGun; 
$NextWeapon[BeaconGun] = Smokey; 
$NextWeapon[Smokey] = JailGun;
$NextWeapon[JailGun] = Nihility;

$PrevWeapon[DiscLauncher] = Nihility; 
$PrevWeapon[Chaingun] = DiscLauncher; 
$PrevWeapon[KShredder] = Chaingun; 
$PrevWeapon[TranqGun] = KShredder; 
$PrevWeapon[Railgun] = TranqGun; 
$PrevWeapon[LaserRifle] = Railgun; 
$PrevWeapon[Gatling] = LaserRifle; 
$PrevWeapon[Titan] = Gatling; 
$PrevWeapon[Steny] = Titan; 
$PrevWeapon[Sten] = Steny; 
$PrevWeapon[GrenadeLauncher] = Sten; 
$PrevWeapon[Mortarr] = GrenadeLauncher; 
$PrevWeapon[Mortar] = Mortarr; 
$PrevWeapon[Diablo] = Mortar; 
$PrevWeapon[Nukes] = Diablo; 
$PrevWeapon[Rocket] = Nukes; 
$PrevWeapon[Guided] = Rocket; 
$PrevWeapon[Blaster] = Guided; 
$PrevWeapon[EnergyRifle] = Blaster; 
$PrevWeapon[WaveGun] = EnergyRifle; 
$PrevWeapon[PlasmaGun] = WaveGun; 
$PrevWeapon[Plasmaii] = PlasmaGun; 
$PrevWeapon[XHChaingun] = Plasmaii; 
$PrevWeapon[Fixit] = XHChaingun; 
$PrevWeapon[Hack] = Fixit; 
$PrevWeapon[Tract] = Hack; 
$PrevWeapon[ReTract] = Tract; 
$PrevWeapon[Grap] = ReTract; 
$PrevWeapon[Riot] = Grap; 
$PrevWeapon[BeaconGun] = Riot; 
$PrevWeapon[Smokey] = BeaconGun;
$PrevWeapon[JailGun] = Smokey;
$PrevWeapon[Nihility] = JailGun; 

//=================
//END WEAPON ORDER
//=================

function remoteNextWeapon(%client) { %item = Player::getMountedItem(%client,$WeaponSlot); if (%item == -1 || $NextWeapon[%item] == "") selectValidWeapon(%client); else { for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break; } } } } 



function remotePrevWeapon(%client) { %item = Player::getMountedItem(%client,$WeaponSlot); if (%item == -1 || $PrevWeapon[%item] == "") selectValidWeapon(%client); else { for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break; } } } } 



function selectValidWeapon(%client) { %item = EnergyRifle; for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); break; } } } 



function isSelectableWeapon(%client,%weapon) { if (Player::getItemCount(%client,%weapon)) { %ammo = $WeaponAmmo[%weapon]; if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true; } return false; } 


//$AmmoCount = 0;
//
//function addAmmo(%weapon, %ammo, %count)
//{
//	$Ammo_Weapon[$AmmoCount] = %weapon;
//	$Ammo_Ammo[$AmmoCount] = %ammo;
//	$Ammo_Count[$AmmoCount] = %count;	
//	$AmmoCount++;
//}

//$FirstWeapon = "";
//$LastWeapon = "";
//
//function addWeapon(%weap)
//{
//	if ($FirstWeapon == "")
//		$FirstWeapon = %weap;
//	if ($LastWeapon == "") 
//		$LastWeapon = %weap;
//
//	$PrevWeapon[%weap] = $LastWeapon;
//	$NextWeapon[%weap] = $FirstWeapon;
//	$PrevWeapon[$FirstWeapon] = %weap;
//	$NextWeapon[$LastWeapon] = %weap;
//
//	$LastWeapon = %weap;
//	//$FirstWeapon = %weap;
//}
//
//
//function remoteNextWeapon(%client)
//{
//	%item = Player::getMountedItem(%client,$WeaponSlot);
//	if (%item == -1 || %item == "" || $NextWeapon[%item] == "")
//		selectValidWeapon(%client);
//	else {
//		for (%weapon = $NextWeapon[%item]; %weapon != %item;
//				%weapon = $NextWeapon[%weapon]) {
//			if (isSelectableWeapon(%client,%weapon)) {
//				Player::useItem(%client,%weapon);
//				// Make sure it mounted (laser may not), or at least
//				// next in line to be mounted.
//				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
//						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
//					break;
//			}
//		}
//	}
//
//}
//
//function remotePrevWeapon(%client)
//{
//	%item = Player::getMountedItem(%client,$WeaponSlot);
//	if (%item == -1 || $PrevWeapon[%item] == "")
//		selectValidWeapon(%client);
//	else {
//		for (%weapon = $PrevWeapon[%item]; %weapon != %item;
//				%weapon = $PrevWeapon[%weapon]) {
//			if (isSelectableWeapon(%client,%weapon)) {
//				Player::useItem(%client,%weapon);
//				// Make sure it mounted (laser may not), or at least
//				// next in line to be mounted.
//				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
//						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
//					break;
//			}
//		}
//	}
//}
//
//
//function selectValidWeapon(%client)
//{
//%player = Client::getOwnedObject(%client);
//	//%item = EnergyRifle;
//	%item = $FirstWeapon;
//if (%player.prevweapon != "" && %player.prevweapon != -1 ) 
//	%item = $prevWeapon[%player.prevweapon];
//	for (%weapon = $nextWeapon[%item]; %weapon != %item;
//			%weapon = $nextWeapon[%weapon]) {
//		if (isSelectableWeapon(%client,%weapon)) {
//			Player::useItem(%client,%weapon);
//			break;
//		}
//	}
//	if (isSelectableWeapon(%client,$FirstWeapon)) {
//			Player::useItem(%client,$FirstWeapon);
//			break;
//	}
//
//}
//
//function isSelectableWeapon(%client,%weapon)
//{
//	if (Player::getItemCount(%client,%weapon)) {
//		%ammo = $WeaponAmmo[%weapon];
//		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
//			return true;
//	}
//	return false;
//}



function Item::giveItem(%player,%item,%delta) { %armor = Player::getArmor(%player); if($ItemMax[%armor, %item]) { %client = Player::getClient(%player); if (%item.className == Backpack) { if (Player::getMountedItem(%player,$BackpackSlot) == -1) { Player::incItemCount(%player,%item); Player::useItem(%player,%item); Client::sendMessage(%client,0,"You received a " @ %item @ " backpack"); return 1; } } else { if (%item.className == Weapon) { if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) return 0; } %extraAmmo = 0 ; if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") %extraAmmo = $AmmoPackMax[%item]; %count = Player::getItemCount(%player,%item); if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count; if (%delta > 0) { Player::incItemCount(%player,%item,%delta); if (%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item); Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description); return %delta; } } } return 0; } $PickupSound[Ammo] = "SoundPickupAmmo"; $PickupSound[Weapon] = "SoundPickupWeapon"; $PickupSound[Backpack] = "SoundPickupBackpack"; $PickupSound[Repair] = "SoundPickupHealth"; 



function Item::playPickupSound(%this) { %item = Item::getItemData(%this); %sound = $PickupSound[%item.className]; if (%sound != "") playSound(%sound,GameBase::getPosition(%this)); else { playSound(SoundPickupItem,GameBase::getPosition(%this)); } } 


function Item::respawn(%this) { if (Item::isRotating(%this)) { Item::hide(%this,True); schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this); } else { deleteObject(%this); } } 



function Item::onAdd(%this) { } 


function Item::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); Item::respawn(%this); } } } 


function Item::onMount(%player,%item) { } 


function Item::onUnmount(%player,%item) { } 

function Item::onUse(%player,%item) { Player::mountItem(%player,%item,$DefaultSlot); } function Item::pop(%item) { GameBase::startFadeOut(%item); schedule("deleteObject(" @ %item @ ");",2.5, %item); } function Item::onDrop(%player,%item) { if($matchStarted) { if(%item.className != Armor) { %obj = newObject("","Item",%item,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); if (Player::isDead(%player)) GameBase::throw(%obj,%player,10,true); else { GameBase::throw(%obj,%player,15,false); Item::playPickupSound(%obj); } Player::decItemCount(%player,%item,1); return %obj; } } } function Item::onDeploy(%player,%item,%pos) { } function Flag::onUse(%player,%item) { Player::mountItem(%player,%item,$FlagSlot); } 






ItemImageData FlagImage 
{ 
shapeFile = "flag"; 
mountPoint = 2; 
mountOffset = { 0, 0, -0.35 }; 
mountRotation = { 0, 0, 0 }; 
lightType = 2; 
lightRadius = 4; 
lightTime = 1.5; 
lightColor = { 1, 1, 1}; 
}; 

ItemData Flag 
{ 
description = "Flag"; 
shapeFile = "flag"; 
imageType = FlagImage; 
showInventory = false; 
shadowDetailMask = 4; 
lightType = 2; 
lightRadius = 4; 
lightTime = 1.5; 
lightColor = { 1, 1, 1 }; 
}; 

ItemData RaceFlag 
{ 
description = "Race Flag"; 
shapeFile = "flag"; 
imageType = FlagImage; 
showInventory = false; 
shadowDetailMask = 4; 
lightType = 2; 
lightRadius = 4; 
lightTime = 1.5; 
lightColor = { 1, 1, 1 }; 
}; 



//========================================ARMORS

ItemData LightArmor 
{ 
heading = "aArmor"; 
description = "Wraith"; 
className = "Armor"; 
price = 100; 
}; 
ItemData EngArmor 
{ 
heading = "aArmor"; 
description = "Slave"; 
className = "Armor"; 
price = 200; 
}; 

ItemData MediumArmor 
{ 
heading = "aArmor"; 
description = "Pawn"; 
className = "Armor"; 
price = 300; 
}; 
ItemData AlArmor 
{ 
heading = "aArmor"; 
description = "Navigator"; 
className = "Armor"; 
price = 666; 
}; 

ItemData DragArmor 
{ 
heading = "aArmor"; 
description = "Atomizer"; 
className = "Armor"; 
price = 800;
}; 

ItemData BursterArmor 
{ 
heading = "aArmor"; 
description = "Paladin"; 
className = "Armor"; 
price = 1000; }; 


//========================================VEHICLES

$VehicleInvList[ScoutVehicle] = 1; 
$VehicleInvList[WraithVehicle] = 1; 
$VehicleInvList[JetVehicle] = 1; 
$VehicleInvList[LAPCVehicle] = 1; 
$VehicleInvList[HAPCVehicle] = 1; 
$DataBlockName[ScoutVehicle] = Scout; 
$DataBlockName[WraithVehicle] = Wraith; 
$DataBlockName[JetVehicle] = Jet; 
$DataBlockName[LAPCVehicle] = LAPC; 
$DataBlockName[HAPCVehicle] = HAPC; 
$VehicleToItem[Scout] = ScoutVehicle; 
$VehicleToItem[Wraith] = WraithVehicle; 
$VehicleToItem[Jet] = JetVehicle; 
$VehicleToItem[LAPC] = LAPCVehicle; 
$VehicleToItem[HAPC] = HAPCVehicle; 

$TeamItemMax[ScoutVehicle] = 5;
$TeamItemMax[WraithVehicle] = 5;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 2;

$ItemMax[larmor, ScoutVehicle] = 1;	//Seraph
$ItemMax[lfemale, ScoutVehicle] = 1;	//Seraph
$ItemMax[earmor, ScoutVehicle] = 1;	//Slave
$ItemMax[efemale, ScoutVehicle] = 1;	//Slave
$ItemMax[marmor, ScoutVehicle] = 1;	//Pawn
$ItemMax[aarmor, ScoutVehicle] = 1;	//Navigator
$ItemMax[darmor, ScoutVehicle] = 1;	//Atomizer
$ItemMax[barmor, ScoutVehicle] = 1;	//Paladin

$ItemMax[larmor, WraithVehicle] = 1;	//Seraph
$ItemMax[lfemale, WraithVehicle] = 1;	//Seraph
$ItemMax[earmor, WraithVehicle] = 1;	//Slave
$ItemMax[efemale, WraithVehicle] = 1;	//Slave
$ItemMax[marmor, WraithVehicle] = 1;	//Pawn
$ItemMax[aarmor, WraithVehicle] = 1;	//Navigator
$ItemMax[darmor, WraithVehicle] = 1;	//Atomizer
$ItemMax[barmor, WraithVehicle] = 1;	//Paladin

$ItemMax[larmor, JetVehicle] = 1;	//Seraph
$ItemMax[lfemale, JetVehicle] = 1;	//Seraph
$ItemMax[earmor, JetVehicle] = 1;	//Slave
$ItemMax[efemale, JetVehicle] = 1;	//Slave
$ItemMax[marmor, JetVehicle] = 1;	//Pawn
$ItemMax[aarmor, JetVehicle] = 1;	//Navigator
$ItemMax[darmor, JetVehicle] = 1;	//Atomizer
$ItemMax[barmor, JetVehicle] = 1;	//Paladin

$ItemMax[larmor, LAPCVehicle] = 1;	//Seraph
$ItemMax[lfemale, LAPCVehicle] = 1;	//Seraph
$ItemMax[earmor, LAPCVehicle] = 1;	//Slave
$ItemMax[efemale, LAPCVehicle] = 1;	//Slave
$ItemMax[marmor, LAPCVehicle] = 1;	//Pawn
$ItemMax[aarmor, LAPCVehicle] = 1;	//Navigator
$ItemMax[darmor, LAPCVehicle] = 1;	//Atomizer
$ItemMax[barmor, LAPCVehicle] = 1;	//Paladin

$ItemMax[larmor, HAPCVehicle] = 1;	//Seraph
$ItemMax[lfemale, HAPCVehicle] = 1;	//Seraph
$ItemMax[earmor, HAPCVehicle] = 1;	//Slave
$ItemMax[efemale, HAPCVehicle] = 1;	//Slave
$ItemMax[marmor, HAPCVehicle] = 1;	//Pawn
$ItemMax[aarmor, HAPCVehicle] = 1;	//Navigator
$ItemMax[darmor, HAPCVehicle] = 1;	//Atomizer
$ItemMax[barmor, HAPCVehicle] = 1;	//Paladin



ItemData ScoutVehicle 
{ 
description = "Scout"; 
className = "Vehicle"; 
heading = "aVehicle"; 
price = 600;
}; 

ItemData WraithVehicle 
{ 
description = "Specter"; 
className = "Vehicle"; 
heading = "aVehicle"; 
price = 600; 
}; 

ItemData JetVehicle 
{ 
description = "Interceptor"; 
className = "Vehicle"; 
heading = "aVehicle"; 
price = 600; 
}; 

ItemData LAPCVehicle 
{ 
description = "Bomber LPC"; 
className = "Vehicle"; 
heading = "aVehicle"; 
price = 700; 
}; 

ItemData HAPCVehicle 
{ 
description = "Stealth HPC"; 
className = "Vehicle"; 
heading = "aVehicle"; 
price = 800; 
}; 


//======================================================
//======================ITEM MAX========================
//======================================================

//function PopulateItemMax(%item, %mSP, %fSP, %mSV, %fSV, %PW, %NV, %AZ, %PN)
////, %h1, %h2, %h3)
//{
//  $ItemMax[larmor, %item] = %mSP; 	//Seraph
//  $ItemMax[lfemale, %item] = %fSP;	//Seraph
//  $ItemMax[earmor, %item] = %mSV;	//Slave
//  $ItemMax[efemale, %item] = %fSV;	//Slave
//  $ItemMax[marmor, %item] = %PW;	//Pawn
//  $ItemMax[aarmor, %item] = %NV;	//Navigator
//  $ItemMax[darmor, %item] = %AZ;	//Atomizer
//  $ItemMax[barmor, %item] = %PN;	//Paladin
//
//}
//
//
// //                                            mSP, fSP, mSV, fSV,  PW, NV,  AZ,  PN, 
// //                                            ---  ---  ---  ---  ---  ---  ---  ---  
//
//	//PACKS
//
//PopulateItemMax(AmmoPack,                      1,   1,   1,   1,   1,   1,   1,   1,);
//PopulateItemMax(ChameleonPack,                 1,   1,   0,   0,   0,   0,   0,   0,);
//PopulateItemMax(CloakingDevice,                1,   1,   0,   0,   0,   1,   0,   0,);
//PopulateItemMax(EnergyPack,                    1,   1,   1,   1,   1,   1,   1,   1,);
//PopulateItemMax(PhaseShifterPack,              1,   1,   0,   0,   0,   1,   0,   0,);
//PopulateItemMax(Laptop,                        0,   0,   1,   1,   0,   1,   0,   0,);
//PopulateItemMax(Slipstream,                    0,   0,   0,   0,   0,   1,   0,   0,);
//PopulateItemMax(RepairPack,                    1,   1,   1,   1,   1,   1,   0,   0,);
//PopulateItemMax(ShieldPack,                    0,   0,   0,   0,   0,   0,   1,   1,);
//PopulateItemMax(SuicidePack,                   0,   0,   0,   0,   0,   1,   0,   0,);
//
//	//WEAPONS
//
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////
////	//TOOLS
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////
////	//MISC
////
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);
////PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,);


//======================================================
//=================END ITEM MAX=========================
//======================================================


ItemData Weapon 
{ 
description = "Weapon"; showInventory = false; }; 

function Weapon::onUse(%player,%item) { %ammo = %item.imageType.ammoType; 
if (%ammo == "") 
{ Player::mountItem(%player,%item,$WeaponSlot); 
} else 
{ 
if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot); else { Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo")); } } } ItemData Tool { description = "Tool"; showInventory = false; }; function Tool::onUse(%player,%item) { Player::mountItem(%player,%item,$ToolSlot); } ItemData Ammo { description = "Ammo"; showInventory = false; }; function Ammo::onDrop(%player,%item) { if($matchStarted) { %count = Player::getItemCount(%player,%item); %delta = $SellAmmo[%item]; if(%count <= %delta) { if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count; else %delta = %count - 1; } if(%delta > 0) { %obj = newObject("","Item",%item,%delta,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,20,false); Item::playPickupSound(%obj); Player::decItemCount(%player,%item,%delta); } } } 



ItemImageData DeployableInvPackImage 
{ shapeFile = "invent_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

//ItemData DeployableInvPack 
//{ 
//description = "Inventory Station"; 
//shapeFile = "invent_remote"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//shadowDetailMask = 4 ; 
//imageType = DeployableInvPackImage; 
//mass = 2.0; 
//elasticity = 0.2; 
//price = 5000; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function DeployableInvPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function DeployableInvPack::onDeploy(%player,%item,%pos) { if (DeployableInvPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function DeployableInvPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7)  { %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Inventory Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; echo("MSG: ",%client," deployed an Inventory Station"); return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DeployableAmmoPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; }; 

//ItemData DeployableAmmoPack 
//{ description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "hDeployable Base Objects"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteAmmoEnergy; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableAmmoPack::onDeploy(%player,%item,%pos) { if (DeployableAmmoPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableAmmoPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Ammo Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; echo("MSG: ",%client," deployed an Ammo Station"); return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DeployableComPackImage 
{ shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 4.5; firstPerson = false; }; 

//ItemData DeployableComPack 
//{ description = "Command Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "hDeployable Base Objects"; shadowDetailMask = 4 ; imageType = DeployableComPackImage; mass = 4.0; elasticity = 0.2; price = 2000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableComPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableComPack::onDeploy(%player,%item,%pos) { if (DeployableComPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableComPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Command Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;echo("MSG: ",%client," deployed a Command Station");  return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }


ItemImageData DeployablevhclPackImage 
{ 
shapeFile = "invent_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.12, -0.3 }; 
mountRotation = { 0, 0, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

//ItemData DeployablevhclPack 
//{ 
//description = "Vehicle Station"; 
//shapeFile = "invent_remote"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//shadowDetailMask = 4 ; 
//imageType = DeployableInvPackImage; 
//mass = 2.0; 
//elasticity = 0.2; 
//price = 5000; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function DeployablevhclPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function DeployablevhclPack::onDeploy(%player,%item,%pos) { if (DeployablevhclPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function DeployablevhclPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7)  { %inv = newObject("ammounit_remote","StaticShape","DeployablevhclStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Vehicle Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployablevhclPack"]++; echo("MSG: ",%client," deployed a Vehicle Station"); return true;  } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 
 









ItemImageData MotionSensorPackImage 
{ 
shapeFile = "sensor_small"; 
mountPoint = 2; 
mountOffset = { 0, 0, 0.1 }; 
mountRotation = { 1.57, 0, 0 }; 
firstPerson = false; 
}; 

//ItemData MotionSensorPack 
//{ 
//description = "Motion Sensor"; 
//shapeFile = "sensor_small"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//imageType = MotionSensorPackImage; 
//shadowDetailMask = 4; 
//mass = 2.0; 
//elasticity = 0.2; 
//price = 125; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function MotionSensorPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} else 
{ 
Player::deployItem(%player,%item); } 
} 

function MotionSensorPack::onDeploy(%player,%item,%pos) 
{ 
if (MotionSensorPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;echo("MSG: ",%client," deployed a Motion Sensor");  } 
} 

function MotionSensorPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain" ; 
if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; 
} else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} else 
{ 
%rot = Vector::getRotation($los::normal); } 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%mSensor = newObject
("","Sensor",DeployableMotionSensor,true); 
addToSet("MissionCleanup", %mSensor); 
GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); GameBase::setRotation(%mSensor,%rot); 
GameBase::setPosition(%mSensor,$los::position); 
Gamebase::setMapName(%mSensor,"Motion Sensor"); 
Client::sendMessage(%client,0,"Motion Sensor deployed"); 
playSound(SoundPickupBackpack,$los::position); 
echo("MSG: ",%client," deployed a Motion Sensor"); 
return true; } 
} else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } 
} else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); } 
} else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 






ItemImageData PulseSensorPackImage 
{ 
shapeFile = "radar_small"; 
mountPoint = 2; 
mountOffset = { 0, 0, 0.1 }; 
mountRotation = { 1.57, 0, 0 }; 
firstPerson = false; 
}; 

//ItemData PulseSensorPack 
//{ 
//description = "Pulse Sensor"; 
//shapeFile = "radar_small"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//imageType = PulseSensorPackImage; 
//shadowDetailMask = 4; 
//mass = 2.0; 
//elasticity = 0.2; 
//price = 125; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function PulseSensorPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} else 
{ 
Player::deployItem(%player,%item); } 
} 

function PulseSensorPack::onDeploy(%player,%item,%pos) 
{ 
if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
{ 
Player::decItemCount(%player,%item); 
$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;echo("MSG: ",%client," deployed a Pulse Sensor");  } 
}









ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

//ItemData DeployableSensorJammerPack
//{
//	description = "Sensor Jammer";
//  	shapeFile = "sensor_jammer";
//  	className = "Backpack";
//   heading = "hDeployable Base Objects";
//	imageType = DeployableSensorJamPackImage;
//  	shadowDetailMask = 4;
//	mass = 2.0;
//	elasticity = 0.2;
//  	price = 225;
//	hudIcon = "deployable";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;echo("MSG: ",%client," deployed a Sensor Jammer"); 
	}
}

ItemImageData BaseAlarmImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

//ItemData BaseAlarm
//{
//   description = "Base Alarm";
//   shapeFile = "sensor_small";
//   className = "Backpack";
//   heading = "hDeployable Base Objects";
//   shadowDetailMask = 4;
//   imageType = BaseAlarmImage;
//   mass = 2.0;
//   elasticity = 0.2;
//   price = 50;
//   hudIcon = "deployable";
//   showWeaponBar = true;
//   hiliteOnActive = true;
//};

function BaseAlarm::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BaseAlarm::onDeploy(%player,%item,%pos)
{
	if (BaseAlarm::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BaseAlarm::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if (GameBase::getLOSInfo(%player,10)) {
		%obj = getObjectType($los::object);
		if (%obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position)) {
				%alarm = newObject("","StaticShape", "AlarmKit",true);
 	 			addToSet("MissionCleanup", %alarm);
				GameBase::setTeam(%alarm,GameBase::getTeam(%player));
				GameBase::setRotation(%alarm,%rot);
				GameBase::setPosition(%alarm,$los::position);
				Gamebase::setMapName(%alarm,%name);
				Gamebase::setMapName(%alarm,"Base Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++);
				Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
				$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;echo("MSG: ",%client," deployed a Base Alarm"); 
				return true;
			}
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}

	return false;
}




ItemImageData CameraPackImage 
{ 
shapeFile = "camera"; 
mountPoint = 2; 
mountOffset = { 0, -0.1, -0.06 }; 
mountRotation = { 0, 0, 0 }; 
firstPerson = false; 
}; 

//ItemData CameraPack 
//{ 
//description = "Camera"; 
//shapeFile = "camera"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//imageType = CameraPackImage; 
//shadowDetailMask = 4; 
//mass = 2.0; 
//elasticity = 0.2; 
//price = 100; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 

function CameraPack::onDeploy(%player,%item,%pos) { if (CameraPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 

function CameraPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 

{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} 
else 
{ 
%rot = Vector::getRotation($los::normal); 
} 
} 
%camera = newObject("Camera","Turret",CameraTurret,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
Client::sendMessage(%client,0,"Camera deployed"); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; 
echo("MSG: ",%client," deployed a Camera"); 
return true; 
 
} else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

//================ 
//================
//BUNKER

$InvList[BunkerPack] = 1;

//-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployBunkerPack::Initialize()
{	$TeamItemCount[0 @ BunkerPack] = 0;
	$TeamItemCount[1 @ BunkerPack] = 0;
	$TeamItemCount[2 @ BunkerPack] = 0;
	$TeamItemCount[3 @ BunkerPack] = 0;
	$TeamItemCount[4 @ BunkerPack] = 0;
	$TeamItemCount[5 @ BunkerPack] = 0;
	$TeamItemCount[6 @ BunkerPack] = 0;
	$TeamItemCount[7 @ BunkerPack] = 0;
}

ItemImageData BunkerPackImage
{	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

//ItemData BunkerPack
//{	description = "Bunker";
//	shapeFile = "ammopack";
//	className = "Backpack";
//	heading = "hDeployable Base Objects";
//	imageType = BunkerPackImage;
//	shadowDetailMask = 4;
//	mass = 2.0;
//	price = 1000;
//	hudIcon = "deployable";
//	showWeaponBar = false;
//	hiliteOnActive = false;
//};
function BunkerPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function BunkerPack::onDeploy(%player,%item,%pos)
{	if (BunkerPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{	%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function BunkerPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
				%num = CountObjects(%set,"eround1",%num);
				deleteObject(%set);
				if(20 > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
					%num = CountObjects(%set,"eround1",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) { //"0 0 1"
									if(BnkrDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%vctr = "0 0 0"; //"0 0 3.3"
								%rot = Vector::add(%rot,%vctr);
								%bunker = newObject("eround1",InteriorShape,"bunker4.dis",false);//eround.dis//
				                     addToSet("MissionCleanup", %bunker);
								GameBase::setTeam(%bunker,GameBase::getTeam(%player));
								GameBase::setPosition(%bunker,$los::position);
								GameBase::setRotation(%bunker,%rot);
								Client::sendMessage(%client,0,"Bunker Deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
								echo("MSG: ",%client," deployed a bunker.");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Too close to other objects.");
				}
			   else 
					Client::sendMessage(%client,0,"Too close to other objects.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function BnkrDeployArea(%client,%pos)
{  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

//END BUNKER
//================
//================

//==========================================
//=============== Builder Pole =============
//==========================================

ItemImageData BuilderPoleImage 
{ 
shapeFile = "ammopack";
mountPoint = 2;
mountOffset = { 0, 0, 0 };
mountRotation = { 90, 0, 0 };
firstPerson = false;
}; 

//ItemData BuilderPole 
//{ 
//description = "Scaffolding"; 
//shapeFile = "ammopack"; 
//className = "Backpack"; 
//heading = "hDeployable Base Objects"; 
//imageType = BuilderPoleImage; 
//shadowDetailMask = 4; 
//mass = 1.5; 
//elasticity = 0.2; 
//price = 50; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function BuilderPole::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); } 
} 

function BuilderPole::onDeploy(%player,%item,%pos) 
{ 
if (BuilderPole::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
$TeamItemCount[GameBase::getTeam(%player) @ "BuilderPole"]++;
echo("MSG: ",%client," deployed a Builder Pole");  
} 
} 

function BuilderPole::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain" ; 
if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} 
else 
{ 
%rot = Vector::getRotation($los::normal); } 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%mSensor = newObject("pole","StaticShape",LargeAntenna,true); 
addToSet("MissionCleanup", %mSensor); 
GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
GameBase::setRotation(%mSensor,%rot); 
GameBase::setPosition(%mSensor,$los::position); 
Gamebase::setMapName(%mSensor,"Builder Pole"); 
Client::sendMessage(%client,0,"Builder Pole deployed"); 
playSound(SoundPickupBackpack,$los::position); 
echo("MSG: ",%client," deployed a Builder Pole"); 
return true; 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); } 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 

//==========================================
//=============END Builder Pole ============
//==========================================

//================ 
//================
//TOWER

$InvList[TowerPack] = 1;

//-=-=-=-=-=-=-=- Initialize =-=-=-=-=-=-=-

function deployTowerPack::Initialize()
{	$TeamItemCount[0 @ TowerPack] = 0;
	$TeamItemCount[1 @ TowerPack] = 0;
	$TeamItemCount[2 @ TowerPack] = 0;
	$TeamItemCount[3 @ TowerPack] = 0;
	$TeamItemCount[4 @ TowerPack] = 0;
	$TeamItemCount[5 @ TowerPack] = 0;
	$TeamItemCount[6 @ TowerPack] = 0;
	$TeamItemCount[7 @ TowerPack] = 0;
}

ItemImageData TowerPackImage
{	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

//ItemData TowerPack
//{	description = "Tower";
//	shapeFile = "ammopack";
//	className = "Backpack";
//	heading = "hDeployable Base Objects";
//	imageType = TowerPackImage;
//	shadowDetailMask = 4;
//	mass = 2.0;
//	price = 1500;
//	hudIcon = "deployable";
//	showWeaponBar = false;
//	hiliteOnActive = false;
//};
function TowerPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function TowerPack::onDeploy(%player,%item,%pos)
{	if (TowerPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{	%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TowerPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
				%num = CountObjects(%set,"BETower2",%num);
				deleteObject(%set);
				if(20 > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
					%num = CountObjects(%set,"BETower2",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) { //"0 0 1"
									if(TwrDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%vctr = "0 0 0"; //"0 0 3.3"
								%rot = Vector::add(%rot,%vctr);
								%tower = newObject("BETower2",InteriorShape,"BETower2.dis",false);//eround.dis
				                     addToSet("MissionCleanup", %tower);
								GameBase::setTeam(%tower,GameBase::getTeam(%player));
								GameBase::setPosition(%tower,$los::position);
								GameBase::setRotation(%tower,%rot);
								Client::sendMessage(%client,0,"Tower Deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TowerPack"]++;
								echo("MSG: ",%client," deployed a Tower.");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Too close to other objects.");
				}
			   else 
					Client::sendMessage(%client,0,"Too close to other objects.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function TwrDeployArea(%client,%pos)
{  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

//END TOWER
//================
//================


function checkDeployArea(%client,%pos) 
{ 
return 1;
} 




ItemImageData ForceFieldPackImage 
{ shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

//ItemData ForceFieldPack 
//{ description = "Small FF Wall"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ForceFieldPack::onDeploy(%player,%item,%pos) { if (ForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field"); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;echo("MSG: ",%client," deployed a Force Field");  return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData LargeForceFieldPackImage 
{ shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

//ItemData LargeForceFieldPack { description = "Wide FF Wall"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = LargeForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LargeForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LargeForceFieldPack::onDeploy(%player,%item,%pos) { if (LargeForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LargeForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",LargeForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field"); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;echo("MSG: ",%client," deployed a Large Force Field");  return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TripwirePackImage 
{ 
shapeFile = "AmmoPack"; 
mountPoint = 2; 
mountOffset = { 0, -0.1, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 
//ItemData TripwirePack 
//{ 
//description = "Blast Wall"; 
//shapeFile = "AmmoPack"; 
//className = "Backpack"; 
//heading = "nDoors - Walls - Platforms"; 
//imageType = TripwirePackImage; 
//shadowDetailMask = 4; 
//mass = 1.5; 
//elasticity = 0.2; 
//price = 600; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function TripwirePack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ Player::deployItem(%player,%item); 
} 
} 

function TripwirePack::onDeploy(%player,%item,%pos) 
{ 
if (TripwirePack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function TripwirePack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain"; 
if (%obj == "SimTerrain") 
{ 
%set = newObject("set",SimSet); 
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); 
%num = CountObjects(%set,"BlastWall",%num); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(checkDeployArea(%client,$los::position)) 
{ 
%rot = GameBase::getRotation(%player); 
%phase = newObject("","StaticShape",BlastWall,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Blast Wall"); Client::sendMessage(%client,0,"Blast Wall Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 



ItemImageData BlastDoorPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData BlastDoorPack
//{
//        description = "Blast Door";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = BlastDoorPackImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function BlastDoorPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function BlastDoorPack::onDeploy(%player,%item,%pos)
{
        if (BlastDoorPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastDoorPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastDoorPack","StaticShape",BlastDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Blast Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorPack"]++;
                                        echo("MSG: ",%client," deployed a Blast Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}





ItemImageData doorfivebyfiveForceFieldPackImage
{
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData doorfivebyfiveForceFieldPack
//{
//        description = "Small FF Door";
//        //shapeFile = "forcefield_5x5";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = doorfivebyfiveForceFieldPackImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"5x5 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"5x5 Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 5x5 Force Field Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

ItemImageData doorfourbyseventeenForceFieldPackImage
{
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData doorfourbyseventeenForceFieldPack
//{
//        description = "Wide FF Door";
//        //shapeFile = "forcefield_4x17";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//         heading = "nDoors - Walls - Platforms";
//        imageType = doorfourbyseventeenForceFieldPackImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function doorfourbyseventeenForceFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function doorfourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyseventeenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyseventeenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("doorfourbyseventeenForceFieldPack","StaticShape",doorfourbyseventeenForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x17 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"4x17 Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyseventeenForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a 4x17 Force Field Door ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
//==============================================================
//==============================================================
//===============================================================









ItemImageData newdooroneImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData newdoorone
//{
//        description = "Panel One";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = newdooroneImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function newdoorone::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function newdoorone::onDeploy(%player,%item,%pos)
{
        if (newdoorone::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorone::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorone","StaticShape",newdooroneShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall1 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorone"]++;
                                        echo("MSG: ",%client," deployed a Panel One Wall");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

















ItemImageData newdoortwoImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData newdoortwo
//{
//        description = "Panel Two";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = newdoortwoImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function newdoortwo::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function newdoortwo::onDeploy(%player,%item,%pos)
{
        if (newdoortwo::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoortwo::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoortwo","StaticShape",newdoortwoShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall2 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoortwo"]++;
                                        echo("MSG: ",%client," deployed a Panel Two Wall");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
















ItemImageData newdoorthreeImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData newdoorthree
//{
//        description = "Panel Three";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = newdoorthreeImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function newdoorthree::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function newdoorthree::onDeploy(%player,%item,%pos)
{
        if (newdoorthree::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorthree::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorthree","StaticShape",newdoorthreeShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall3 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorthree"]++;
                                        echo("MSG: ",%client," deployed a Panel Three Wall");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}















ItemImageData newdoorfourImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData newdoorfour
//{
//        description = "Panel Four";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = newdoorfourImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function newdoorfour::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function newdoorfour::onDeploy(%player,%item,%pos)
{
        if (newdoorfour::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function newdoorfour::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("newdoorfour","StaticShape",newdoorfourShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera," Panel Wall 4 #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorfour"]++;
                                        echo("MSG: ",%client," deployed a Panel Four Wall");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}





























ItemImageData PlatformPackImage 
{ shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 
//
//ItemData PlatformPack 
//{ description = "Small Platform"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "nDoors - Walls - Platforms"; imageType = PlatformPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PlatformPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PlatformPack::onDeploy(%player,%item,%pos) { if (PlatformPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function PlatformPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlatform",%num); deleteObject(%set); %rot = GameBase::getRotation(%player); %phase = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Deployable Platform"); Client::sendMessage(%client,0,"Platform Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;echo("MSG: ",%client," deployed a Platform");  return true; } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 




ItemImageData LrgPltPackImage 
{ 
shapeFile = "AmmoPack"; 
mountPoint = 2; 
mountOffset = { 0, -0.1, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

//ItemData LrgPltPack 
//{ 
//description = "Large Platform"; 
//shapeFile = "AmmoPack"; 
//className = "Backpack"; 
//heading = "nDoors - Walls - Platforms"; 
//imageType = LrgPltPackImage; 
//shadowDetailMask = 4; 
//mass = 1.5; 
//elasticity = 0.2; 
//price = 600; 
//hudIcon = "deployable"; 
//showWeaponBar = true; 
//hiliteOnActive = true; 
//}; 

function LrgPltPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function LrgPltPack::onDeploy(%player,%item,%pos) { if (LrgPltPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } 

function LrgPltPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %obj == "StaticShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"LargePlatform",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",LargePlatform,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"LargePlatform"); Client::sendMessage(%client,0,"LargePlatform Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LrgPltPack"]++; echo("MSG: ",%client," deployed a Large Platform");   return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 



//==============================================


ItemImageData PlatformDoorImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData PlatformDoor
//{
//        description = "Small Platform Door";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = PlatformDoorImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function PlatformDoor::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function PlatformDoor::onDeploy(%player,%item,%pos)
{
        if (PlatformDoor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function PlatformDoor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("PlatformDoor","StaticShape",PlatformDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Platform Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"LPlatform Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "PlatformDoor"]++;
                                        echo("MSG: ",%client," deployed a PlatformDoor ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}



//===========================================================

ItemImageData LargePlatDoorImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

//ItemData LargePlatDoor
//{
//        description = "Large Platform Door";
//        shapeFile = "AmmoPack";
//        className = "Backpack";
//        heading = "nDoors - Walls - Platforms";
//        imageType = LargePlatDoorImage;
//        shadowDetailMask = 4;
//        mass = 2.5;
//        elasticity = 0.2;
//        price = 500;
//        hudIcon = "deployable";
//        showWeaponBar = true;
//        hiliteOnActive = true;
//};

function LargePlatDoor::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function LargePlatDoor::onDeploy(%player,%item,%pos)
{
        if (LargePlatDoor::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function LargePlatDoor::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,10)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("LargePlatDoor","StaticShape",LargePlatDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"LargePlatform Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "LargePlatDoor"]++;
                                        echo("MSG: ",%client," deployed a LargePlatDoor ");
                                        return true;

                        }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}



ItemImageData SpringPackImage 
{ shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

//ItemData SpringPack 
//{ description = "Springboard"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "hDeployable Base Objects"; imageType = SpringPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function SpringPack::onUse
(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } 
} 
function SpringPack::onDeploy
(%player,%item,%pos) { if (SpringPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } 
} 
function SpringPack::deployShape
(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableCactus",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableSpring,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Springboard"); Client::sendMessage(%client,0,"Springboard Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;echo("MSG: ",%client," deployed a Spring Board");  return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

//===ACCELPAD

ItemImageData AccelPPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	firstPerson = false;
};

//ItemData AccelPPack
//{
//	description = "Accelerator Pad";
//	shapeFile = "elevator_6x6_octagon";
//	className = "Backpack";
//	heading = "hDeployable Base Objects";
//	imageType = AccelPPackImage;
//	shadowDetailMask = 4;
//	mass = 2.0;
//	elasticity = 0.2;
//	price = 950;
//	hudIcon = "deployable";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};

function AccelPPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function AccelPPack::onDeploy(%player,%item,%pos)
{
	if (AccelPPack::deployShape(%player,"AccelPad",AccelPadPack,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
	}
}

function CreateAccelPadSimSet()
{
	%teleset = nameToID("MissionCleanup/AccelPadPack");
	if(%teleset == -1)
	{
		newObject("AccelPadPack",SimSet);
		addToSet("MissionCleanup","AccelPadPack");
	}
}

function AccelPPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"] < $TeamItemMax[AccelPPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				%sensor = newObject("AccelPadPack","StaticShape",%shape,true);
				CreateAccelPadSimSet();
				addToSet("MissionCleanup/AccelPadPack", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,GameBase::getTeam(%player));
				%pos = Vector::add($los::position,"0 0 -0.25");
				GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
				GameBase::setPosition(%sensor,%pos);
				%Rot=GameBase::getRotation(%player);
				%Rot=Vector::add(%Rot,"0 0 3.14159");
				GameBase::setRotation(%sensor,%rot);
				GameBase::setPosition(%sensor,%pos);
				Gamebase::setMapName(%sensor,"Accel Pad");
				Client::sendMessage(%client,0,%item.description @ " deployed");
				echo("MSG: ",%client," deployed an Accelerator Pad ");
				%sensor.disabled = false;
				%sensor.activated=false;
				GameBase::startFadeIn(%sensor);
				playSound(SoundPickupBackpack,$los::position);
				GameBase::startfadein(%sensor);
				return true;
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//=END ACCELPAD


//ItemImageData TeleportPackImage 
//{ shapeFile = "flagstand"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData TeleportPack { description = "Teleport Pad"; shapeFile = "flagstand"; className = "Backpack"; heading = "hDeployable Base Objects"; imageType = TeleportPackImage; shadowDetailMask = 4; mass = 5.0; elasticity = 0.2; price = 3200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TeleportPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TeleportPack::onDeploy(%player,%item,%pos) { if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; } } function CreateteleportSimSet() { %teleset = nameToID("MissionCleanup/Teleports"); if(%teleset == -1) { newObject("Teleports",SimSet); addToSet("MissionCleanup","Teleports"); } } function TeleportPack::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) { if (GameBase::getLOSInfo(%player,10)) { %obj = "SimTerrain" ; if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %sensor = newObject("Teleport Pad","StaticShape",%shape,true); CreateteleportSimSet(); addToSet("MissionCleanup/Teleports", %sensor); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); %pos = Vector::add($los::position,"0 0 1"); echo("LOS pos " @ $los::position @ " " @ %pos); GameBase::setPosition(%sensor,%pos); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); %sensor.disabled = false; playSound(SoundPickupBackpack,$los::position); %beam = newObject("","StaticShape",ElectricalBeamBig,true); addToSet("MissionCleanup", %beam); GameBase::setTeam(%beam,GameBase::getTeam(%player)); GameBase::setPosition(%beam,%pos); %sensor.beam1 = %beam; return true;  } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; }


// ------------------------------------------------------

StaticShapeData DeployableFlagStand
{
   	description = "Deployable Flag Stand";
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 3.0;
	shadowDetailMask = 4;
	mapFilter = 4;
	explosionId = debrisExpMedium;
	visibleToSensor = true;
};


function DeployableFlagstand::onDestroyed(%this)
{	
   
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "FlagStandPack"]--;
   %flag = %this.carryflag;
   if(%flag != "")
	{
		%flag.flagstand = "";
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	}
}

ItemImageData FlagstandPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

//ItemData FlagstandPack
//{	
//	description = "Flag Stand";
//	shapefile = "ammopack";
//	classname = "Backpack";
//	heading = "hDeployable Base Objects";
//	imageType = FlagstandPackImage;
//	shadowDetailMask = 4;
//	mass = 2.0;
//	elasticity = 0.1;
//	price = 100;
//	hudIcon = "deployable";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};

function FlagstandPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function FlagStandPack::onDeploy(%player,%item,%pos)
{
	if (FlagstandPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function FlagstandPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,10)) 
		{
			%obj = "InteriorShape";
			if (%obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(%obj == "InteriorShape") 
					{
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = %flag.originalposition;
						if(Vector::getDistance(%flagpos, %playerpos) < 7000)
						{
							%rot = GameBase::getRotation(%player); 
							%sensor = newObject("","Staticshape",DeployableFlagstand,true);
	                    					addToSet("MissionCleanup", %sensor);
							GameBase::setTeam(%sensor,GameBase::getTeam(%player));
							GameBase::setPosition(%sensor,$los::position);
							GameBase::setRotation(%sensor,%rot);
							Gamebase::setMapName(%sensor,"Flagstand #" @ $totalNumFlagstands++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Flag stand deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "FlagstandPack"]++;
							echo("MSG: ",%client," deployed a Flag stand");
							return true;
						}	
						else
						{
							Client::sendMessage(%client,0,"You are too far away from the flags original position.");
							return false;
						}
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}

function DeployableFlagstand::onCollision(%this,%object)
{
   if(%object.enterTime > getSimTime() - 3)
	return;
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);
   %playerClient = Player::getClient(%object);

   if(getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "") // %standteam == -1 ||
      return;

   %flag = %object.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   if(%this.carryflag != "")
	return;

   %this.carryflag = %flag;
   %flag.carrier = -1;
   Item::hide(%flag, false);
   GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
   playSound(SoundPickupBackpack, GameBase::getPosition(%this));

   %flag.flagStand = %this;
   Player::setItemCount(%object, Flag, 0);
   %object.carryFlag = "";
   %playerClient = Player::getClient(%object);
   Flag::clearWaypoint(%playerClient, true);
   if(getTeamName(%flag) == %playerTeam){
   	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " flag has been moved to a new position");
   	Client::sendMessage(%playerClient, 0, "You moved your flag.");
   }
   else {
	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " have set an enemy flag on a flagstand");
   	Client::sendMessage(%playerClient, 0, "You placed the enemy flag down.");
   }	
   %object.enterTime = getSimTime();
}





function checkHackable(%name, %shape)
{ 
	if(%shape == "generator" ||
	%shape == "Generator" ||
	%shape == "generator_p" ||
	%shape == "solar_med" ||
	%shape == "inventory_sta" ||
	%shape == "elevator_4x4" ||
	%shape == "elevator_6x6" ||
	%shape == "elevator_6x6_octagon" ||
	%shape == "elevator_8x4" ||
	%shape == "elevator_8x6" ||
	%shape == "elevator_9x9" ||
	%shape == "elevator16x16_octo" ||
	%shape == "elevator6X4" ||
	%shape == "elevator_6x5" ||
	%shape == "elevator_8x8" ||
	%shape == "elevator6x4thin" ||
	%shape == "elevator6x6thin" ||
	%shape == "elevator_5x5" ||
	%shape == "elevator_4x5" ||
	%shape == "door_top" ||
	%shape == "door_bot" ||
	%shape == "newdoor1_l" ||
	%shape == "newdoor1_r" ||
	%shape == "newdoor2_l" ||
	%shape == "newdoor2_r" ||
	%shape == "newdoor3_l" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" ||
	%shape == "newdoor4_r" ||
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r" ||
	%shape == "door_8x8_l" ||
	%shape == "door_8x8_r" ||
	%shape == "forcefield" ||
	%shape == "forcefield_3x4" ||
	%shape == "forcefield_4x17" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" || 
	%shape == "newdoor4_r" || 
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r"	||
	%shape == "forcefield_4x14" ||
	%shape == "forcefield_4x8" ||
	%shape == "forcefield_5x5" || 
	%shape == "door_4x4_diagonal" ||
	%shape == "tower" ||
	%shape == "camera" ||
	%shape == "hellfiregun" ||
	%shape == "indoorgun" ||
	%shape == "mortar_turret" ||
	%shape == "ammounit" || 
	%shape == "sensor_pulse_med" ||
	%shape == "station_cmdpnl" ||
	%shape == "missileturret" ||
	%shape == "cmdpnl" ||
	%shape == "radar" ||
	%shape == "anten_lava" ||
	%shape == "vehi_pur_poles")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if ($debug) echo  ("Hacking");
	
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{		
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "',\"" @ escapeString(%pName) @ "\",\"" @ escapeString(%tName) @ "\",\"" @ escapeString(%name) @ "\",'" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if ($debug) echo ("PT - " @ %pteam @ "");
		if ($debug) echo ("TT - " @ %team @ "");
		if ($debug) echo ("HK - " @ $hacking[%client] @ "");
		if ($debug) echo ("TG - " @ %target @ "");
		if ($debug) echo ("Tm - " @ %time @ "");
	
		if($hacking[%client] == "true")
		{
			if(%team == %pTeam)
			{
				if ($debug) echo ("infecting");
				%target.infected = "true";
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection, from hacking.");
				return;
			}
			else
			{
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	

					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				
				if(%name == "False" && %shape == "magcargo")
				{

					%rnd = floor(getRandom() * 10);
					if(%rnd == 1)
					{	
					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						Mine::Detonate(" @ %this @ ");
						return;
					}
					else
					{	
					    Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}


				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					
					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
					}


					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}
			}
		}
	}
}


ItemImageData HackitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "HackBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hackit
{
	description   = "Hack Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "eMisc Items";
	shadowDetailMask = 4;
	imageType     = HackitImage;
	price         = 1000;
	showWeaponBar = true;
};





ItemImageData ArbitorBoxPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

//ItemData ArbitorBoxPack
//{
//	description = "Base Cloak";
//	shapeFile = "magcargo";
//	className = "Backpack";
//   heading = "hDeployable Base Objects";
//	imageType = ArbitorBoxPackImage;
//	shadowDetailMask = 4;
//	mass = 2.5;
//	elasticity = 0.2;
//	price = 1350;
//	hudIcon = "deployable";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};


function ArbitorBoxPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBoxPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBoxPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = "InteriorShape";
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Arbitor Device deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
						echo("MSG: ",%client," deployed an Arbitor Box");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");

	return false;
}



ItemImageData bomberPackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData bomberPack
 
{ 
description = "Scout Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "kDeployable Vehicles"; 
imageType = bomberPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function bomberPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); 
} 
} 

function bomberPack::onDeploy(%player,%item,%pos) 
{ 
if (bomberPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function bomberPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 

if($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] < $TeamItemMax[ScoutVehicle]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain";
%set = newObject("set",SimSet); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(%obj == "SimTerrain") 
{
%rot = GameBase::getRotation(%player); 
%phase = newObject("",flier,Scout,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); 
GameBase::setRotation(%phase,%rot); 
Client::sendMessage(%client,0,"Piloting Scout"); 
GameBase::startFadeIn(%phase); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++;echo("MSG: ",%client," deployed a Scout");  
return true; 
} 
} 
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 

else 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; 
} 



ItemImageData cloakjetPackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData cloakjetPack
 
{ 
description = "Specter Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "kDeployable Vehicles"; 
imageType = cloakjetPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function cloakjetPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); 
} 
} 

function cloakjetPack::onDeploy(%player,%item,%pos) 
{ 
if (cloakjetPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function cloakjetPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 

if($TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"] < $TeamItemMax[WraithVehicle]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain";
%set = newObject("set",SimSet); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(%obj == "SimTerrain") 
{
%rot = GameBase::getRotation(%player); 
%phase = newObject("",flier,Wraith,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); 
GameBase::setRotation(%phase,%rot); 
Client::sendMessage(%client,0,"Piloting Specter"); 
GameBase::startFadeIn(%phase); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"]++;echo("MSG: ",%client," deployed a Specter");  
return true; 
} 
} 
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 

else 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; 
} 




ItemImageData MechPackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData MechPack
 
{ 
description = "Interceptor Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "kDeployable Vehicles"; 
imageType = MechPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function MechPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); 
} 
} 

function MechPack::onDeploy(%player,%item,%pos) 
{ 
if (MechPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function MechPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 

if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain";
%set = newObject("set",SimSet); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
%rot = GameBase::getRotation(%player); 
%phase = newObject("",flier,Jet,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); 
GameBase::setRotation(%phase,%rot); 
Client::sendMessage(%client,0,"Piloting Interceptor"); 
GameBase::startFadeIn(%phase); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++;echo("MSG: ",%client," deployed an Interceptor");  
return true; 
} 
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 

else 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; 
} 







ItemImageData BigBomberPackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData BigBomberPack
 
{ 
description = "LAPC Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "kDeployable Vehicles"; 
imageType = BigBomberPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function BigBomberPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); 
} 
} 

function BigBomberPack::onDeploy(%player,%item,%pos) 
{ 
if (BigBomberPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function BigBomberPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 

if($TeamItemCount[GameBase::getTeam(%player) @ "LAPCVehicle"] < $TeamItemMax[LAPCVehicle]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain";
%set = newObject("set",SimSet); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(%obj == "SimTerrain") 
{
%rot = GameBase::getRotation(%player); 
%phase = newObject("",flier,LAPC,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); 
GameBase::setRotation(%phase,%rot); 
Client::sendMessage(%client,0,"Piloting LAPC"); 
GameBase::startFadeIn(%phase); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "LAPCVehicle"]++;echo("MSG: ",%client," deployed a LAPC");  
return true; 
} 
} 
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 

else 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; 
} 





ItemImageData DetPackImage
 
{ 
shapeFile = "ammounit_remote"; 
mountPoint = 2; 
mountOffset = { 0, -0.03, 0 }; 
mass = 2.5; 
firstPerson = false; 
}; 

ItemData DetPack
 
{ 
description = "HAPC Pack"; 
shapeFile = "ammounit_remote"; 
className = "Backpack"; 
heading = "kDeployable Vehicles"; 
imageType = DetPackImage; 
shadowDetailMask = 4; 
mass = 1.5; 
elasticity = 0.2; 
price = 600; 
hudIcon = "deployable"; 
showWeaponBar = true; 
hiliteOnActive = true; 
}; 

function DetPack::onUse(%player,%item) 
{ 
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
{ 
Player::mountItem(%player,%item,$BackpackSlot); 
} 
else 
{ 
Player::deployItem(%player,%item); 
} 
} 

function DetPack::onDeploy(%player,%item,%pos) 
{ 
if (DetPack::deployShape(%player,%item)) 
{ 
Player::decItemCount(%player,%item); 
} 
} 

function DetPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 

if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain";
%set = newObject("set",SimSet); 
deleteObject(%set); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(%obj == "SimTerrain") 
{
%rot = GameBase::getRotation(%player); 
%phase = newObject("",flier,HAPC,true); 
addToSet("MissionCleanup", %phase); 
GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); 
GameBase::setRotation(%phase,%rot); 
Client::sendMessage(%client,0,"Piloting HAPC"); 
GameBase::startFadeIn(%phase); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;echo("MSG: ",%client," deployed a HAPC");  
return true; 
} 
} 
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 

else 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; 
} 




function Item::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,10)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %sensor = newObject("","Sensor",%shape,true); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); GameBase::setPosition(%sensor,$los::position); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); playSound(SoundPickupBackpack,$los::position); echo("MSG: ",%client," deployed a ",%name); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; } 

//$AutoUse[RepairKit] = false; 
//
//ItemData RepairKit 
//{ description = "Repair Kit"; shapeFile = "armorKit"; heading = "eMisc Items"; shadowDetailMask = 4; price = 35; }; function RepairKit::onUse(%player,%item) { Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.2); %c = Player::getClient(%player); $poisonTime[%c] = 0; } 
//
//ItemData MineAmmo 
//{ description = "Mine"; shapeFile = "mineammo"; heading = "eMisc Items"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; }; function MineAmmo::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { Player::decItemCount(%player,%item); %armor = Player::getArmor(%player); %client = Player::getClient(%player); if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine"); else { %obj = newObject("","Mine","antipersonelMine"); GameBase::setTeam (%obj,GameBase::getTeam (%client)); } addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } } 
//
//ItemData Grenade 
//{ description = "Grenade"; shapeFile = "grenade"; heading = "eMisc Items"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; }; function Grenade::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { Player::decItemCount(%player,%item); %armor = Player::getArmor(%player); if (%armor == "larmor" || %armor == "lfemale") { Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds"); %obj = newObject("","Mine","Nukebomb"); } if(%armor == "earmor" || %armor == "efemale") %obj = newObject("","Mine","Shockgrenade"); if (%armor == "sarmor" || %armor == "sfemale") %obj = newObject("","Mine","Firebomb"); if (%armor == "spyarmor" || %armor == "spyfemale") { Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds"); %obj = newObject("","Mine","Nukebomb"); } if (%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","Handgrenade"); if (%armor == "aarmor" || %armor == "afemale") %obj = newObject("","Mine","Tranqgrenade"); if (%armor == "harmor") %obj = newObject("","Mine","Nukebomb"); if (%armor == "barmor" || %armor == "bfemale") %obj = newObject("","Mine","Mortarbomb"); if (%armor == "darmor") %obj = newObject("","Mine","Mortarbomb"); if (%armor == "dmarmor" || %armor == "dmfemale") { %clientId = Player::getClient(%player); if($modeTime[%clientId] == 1) { Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds"); %obj = newObject("","Mine","Nukebomb"); } else if($modeTime[%clientId] == 2) { %obj = newObject("","Mine","Concussion"); } else if($modeTime[%clientId] == 3) { %obj = newObject("","Mine","Shockgrenade"); } else if($modeTime[%clientId] == 4) { %obj = newObject("","Mine","Tranqgrenade"); } else if($modeTime[%clientId] == 5) { %obj = newObject("","Mine","Mortarbomb"); } else if($modeTime[%clientId] == 6) { %obj = newObject("","Mine","Firebomb"); } else %obj = newObject("","Mine","Handgrenade"); } addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam (%obj,GameBase::getTeam (%client));} } } 
//
//ItemData Beacon 
//{ 
//description = "Beacon"; 
//shapeFile = "sensor_small"; 
//heading = "eMisc Items"; 
//shadowDetailMask = 4; 
//price = 5; 
//className = "HandAmmo"; 
//}; 
//
//function Beacon::onUse(%player,%item) 
//{ 
//%armor = Player::getArmor(%player); %clientId = Player::getClient(%player); 
//if (%armor == "larmor" || %armor == "lfemale") 
//{ 
//startCloak(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//} 
//if(%armor == "earmor" || %armor == "efemale") 
//{ 
//startShield(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//}
//if (%armor == "sarmor" || %armor == "sfemale") 
//{ 
//ScoutSensor(%clientId, %player, %item); 
//} 
//if (%armor == "spyarmor" || %armor == "spyfemale") 
//{ 
//startCloak(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//} 
////{ 
////DeploySatchel(%clientId, %player, %item);
////} 
//if (%armor == "marmor" || %armor == "mfemale") 
//{ 
//if($matchStarted) 
//{ 
//if(%player.throwTime < getSimTime() ) 
//{ 
//%obj = newObject("","Mine","Booster"); 
//addToSet("MissionCleanup", %obj); 
//%client = Player::getClient(%player); 
//GameBase::throw(%obj,%player,15 * %client.throwStrength,false); 
//%player.throwTime = getSimTime() + 0.5; 
//Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); 
//Player::decItemCount(%player,%item); 
//} 
//} 
//} 
//if (%armor == "aarmor" || %armor == "afemale") 
//{ 
//Renegades_startCloak(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//} 
//if 
//(%armor == "harmor") %obj = newObject("","Mine","Nukebomb"); 
//if (%armor == "barmor" || %armor == "bfemale") 
//{ 
//startShield(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//}
//if (%armor == "darmor")
//{ 
//Renegades_startShield(%clientId, %player); 
//Player::decItemCount(%player,%item); 
//}
//} 
//
//
//
//
//
//
//
//function Renegades_startStim(%clientId, %player) 
//{ 
//Client::sendMessage(%clientId,0,"OMG YOU CRAZY MOFO, DO YOU NOT KNOW WHAT SPEEEED DOES!!"); 
//%this = "RepairPatch"; 
//Item::playPickupSound(%this); 
//%armor = Player::getArmor(%player); 
//%armor.maxForwardSpeed = %armor.maxForwardSpeed + 75;
//%armor.maxBackwardSpeed = %armor.maxBackwardSpeed + 75;
//Player::setDamageFlash(%player,1.0); 
//GameBase::applyDamage(%player,$LandingDamageType,0.020,GameBase::getPosition(%player),"0 0 0","0 0 0",%player); 
//if($stimTime[%clientId] == 0) 
//{ 
//$stimTime[%clientId] = 20; 
//checkPlayerStim(%clientId, %player); 
//} 
//else $StimTime[%clientId] = 20; 
//} 
//
//
//
//function checkPlayerStim(%clientId, %player) 
//{ 
//if($StimTime[%clientId] > 0) 
//{ 
//$StimTime[%clientId] -= 2; 
//if (!Player::isDead(%player)) 
//{ } 
//else 
//{ 
//$StimTime[%clientId] = 0; 
//%armor.maxForwardSpeed = 9;
//%armor.maxBackwardSpeed = 9;
//
//} 
//schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player); 
//} 
//else 
//{ 
//Client::sendMessage(%clientId,0,"WITH THE UPS come the downs..."); 
//%armor = Player::getArmor(%player); 
//%armor.maxForwardSpeed = 10;
//%armor.maxBackwardSpeed = 10;
//} 
//} 
//
//
////=======================
////BEACON EFF SCRIPTS
////=======================
//
//function Renegades_startShield(%clientId, %player) 
//{ 
//Client::sendMessage(%clientId,0,"Barrier field generated..."); GameBase::playSound(%player,ForceFieldOpen,0); 
//%player.shieldStrength = 0.0162; 
//if($shieldTime[%clientId] == 0) 
//{ 
//$shieldTime[%clientId] = 20; 
//checkPlayerShield(%clientId, %player); 
//} 
//else 
//$shieldTime[%clientId] = 20; 
//} 
//
//function checkPlayerShield(%clientId, %player) 
//{ 
//%armor = Player::getArmor(%player); 
//if($shieldTime[%clientId] > 0) 
//{ 
//$shieldTime[%clientId] -= 2; 
//if ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale") ) 
//{ 
//if (Player::isDead(%player)) 
//{ } 
//} 
//else 
//{ 
//$shieldTime[%clientId] = 0; 
//} 
//schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); 
//} 
//else 
//{ 
//Client::sendMessage(%clientId,0,"Barrier field shut-down..."); 
//%player.shieldStrength = 0; 
//GameBase::playSound(%player,ForceFieldOpen,0); 
//} 
//} 
////EFF 2
//function startShield(%clientId, %player) 
//{	// Taken straight from Annihilation which was from Renegades
//	Client::sendMessage(%clientId,0,"Barrier field generated...");
//	GameBase::playSound(%player,ForceFieldOpen,0);
//	%player.shieldStrength = 0.0162;
//	if($shieldTime[%clientId] == 0) 
//	{	$shieldTime[%clientId] = 20;
//		checkPlayerShield(%clientId, %player);
//	}
//	else $shieldTime[%clientId] = 20;
//}
//
//function checkPlayerShield(%clientId, %player) 
//{	// Taken straight from Annihilation which was from Renegades
//	if ($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
//	{	$shieldTime[%clientId] -= 2;
//		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
//	}
//	else 
//	{	$shieldTime[%clientId] = 0;
//		Client::sendMessage(%clientId,0,"Barrier field shut-down...");
//		%player.shieldStrength = 0;
//		GameBase::playSound(%player,ForceFieldOpen,0);
//	}
//}
////EFF 3
//
////=======================
////END BEACON EFF SCRIPTS
////=======================
//
//
////=======================
////BEACON CLOAKING SCRIPTS
////=======================
//
////CLOAK 1
//
//function Renegades_startCloak(%clientId, %player) 
//{ 
//%armor = Player::getArmor(%player); 
//Client::sendMessage(%clientId,0,"Phasing Out..."); 
//GameBase::playSound(%player,ForceFieldOpen,0); 
//GameBase::startFadeout(%player); 
//%rate = Player::getSensorSupression(%player) + 3; Player::setSensorSupression(%player,%rate); 
//if($cloakTime[%clientId] == 0) 
//{ 
//$cloakTime[%clientId] = 20; 
//checkPlayerCloak(%clientId, %player); 
//} 
//else 
//$cloakTime[%clientId] = 20; 
//} 
//
//
//
//
//function checkPlayerCloak(%clientId, %player) 
//{ 
//%armor = Player::getArmor(%player); 
//if($cloakTime[%clientId] > 0) 
//{ 
//$cloakTime[%clientId] -= 2; 
//if ( (!Player::isDead(%player)) && (%armor == "aarmor" || %armor == "afemale") ) 
//{ } 
//else 
//{ 
//$cloakTime[%clientId] = 0; 
//} 
//schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); 
//} 
//else 
//{ 
//Client::sendMessage(%clientId,0,"Phasing In..."); 
//GameBase::playSound(%player,ForceFieldOpen,0); 
//GameBase::startFadein(%player); 
//%rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,0); 
//} 
//} 
//
////CLOAK 2
//
//function startCloak(%clientId, %player) 
//{
//	// Taken straight from Annihilation which was from Renegades
//	%armor = Player::getArmor(%player);
//	Client::sendMessage(%clientId,0,"Phasing Out...");
//	GameBase::playSound(%player,ForceFieldOpen,0);
//	GameBase::startFadeout(%player);
//	%rate = Player::getSensorSupression(%player) + 3;
//	Player::setSensorSupression(%player,%rate);
//	if($cloakTime[%clientId] == 0) 
//	{	$cloakTime[%clientId] = 20;
//		checkPlayerCloak(%clientId, %player);
//	}
//	else $cloakTime[%clientId] = 20;
//}
//
//function checkPlayerCloak(%clientId, %player) 
//{	%armor = Player::getArmor(%player);
//	if (!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
//	{	$cloakTime[%clientId] -= 2;
//		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
//	}
//	else 
//	{	$cloakTime[%clientId] = 0;
//		Client::sendMessage(%clientId,0,"Phasing In...");
//		GameBase::playSound(%player,ForceFieldOpen,0);
//		GameBase::startFadein(%player);
//		%rate = Player::getSensorSupression(%player) - 5;
//		Player::setSensorSupression(%player,0);
//	}
//}
//
////=======================
////END OF BEACON CLOAKING SCRIPTS
////=======================

function DeploySatchel( %clientId, %player, %bec) 
{ 
%item = "SatchelPack"; 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = getObjectType($los::object); 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; 
} 
else { %rot = Vector::getRotation($los::normal); 
} 
} 

%camera = newObject("Camera","Turret",DeployableSatchel,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen."); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++; 
echo("MSG: ",%client," deployed a Satchel Charge."); Player::decItemCount(%player,%bec); 
return true; 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges"); 
return false; 
} 





function EngCamera(%clientId, %player, %bec) 
{ 
%item = "CameraPack"; 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain"; 
if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; 
} 
else { %rot = Vector::getRotation($los::normal); 
} 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%camera = newObject("Camera","Turret",CameraTurret,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
Client::sendMessage(%client,0,"Camera deployed"); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; 
echo("MSG: ",%client," deployed a Camera"); 
Player::decItemCount(%player,%bec); return true; 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
} 
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 




function SniperJammer(%clientId, %player, %bec) 
{ 
%item = "DeployableSensorJammerPack"; 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain"; 
if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} 
else 
{ 
%rot = Vector::getRotation($los::normal); 
} 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true); 
addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"SensorJammer"); 
Client::sendMessage(%client,0,"SensorJammer deployed"); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++; 
echo("MSG: ",%client," deployed a Sensor Jammer"); 
Player::decItemCount(%player,%bec); 
return true; 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
} 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 
function ScoutSensor(%clientId, %player, %bec) 
{ 
%item = "PulseSensorPack"; 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
{ 
if (GameBase::getLOSInfo(%player,10)) 
{ 
%obj = "SimTerrain"; 
if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
{ 
%prot = GameBase::getRotation(%player); 
%zRot = getWord(%prot,2); 
if (Vector::dot($los::normal,"0 0 1") > 0.6) 
{ 
%rot = "0 0 " @ %zRot; 
} 
else 
{ 
if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ 
%rot = "3.14159 0 " @ %zRot; 
} 
else 
{ 
%rot = Vector::getRotation($los::normal); 
} 
} 
if(checkDeployArea(%client,$los::position)) 
{ 
%camera = newObject("radar_small","Sensor",DeployablePulseSensor,true); addToSet("MissionCleanup", %camera); 
GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); 
GameBase::setPosition(%camera,$los::position); 
Gamebase::setMapName(%camera,"Pulse Sensor"); 
Client::sendMessage(%client,0,"Pulse Sensor deployed"); 
playSound(SoundPickupBackpack,$los::position); 
$TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++; 
echo("MSG: ",%client," deployed a Pulse Sensor"); 
Player::decItemCount(%player,%bec); 
return true; 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
} 
} 
else 
{ 
Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
} 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 

ItemData Boost 
{ description = "Bot"; shapeFile = "sensor_small"; heading = "eMisc Items"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; }; function Boost::onUse(%player,%item) { %client = Player::getClient(%player); Training::setupAI(%client); } 

ItemData Plastique 
{ description = "Grenade Mode"; shapeFile = "sensor_small"; heading = "eMisc Items"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; }; function Plastique::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { %player.throwTime = getSimTime() + 0.5; %clientId = Player::getClient(%player); if( ($modeTime[%clientId] != 1) && ($modeTime[%clientId] != 2) && ($modeTime[%clientId] != 3) && ($modeTime[%clientId] != 4) && ($modeTime[%clientId] != 5) && ($modeTime[%clientId] != 6) ) { $modeTime[%clientId] = 0; } if($modeTime[%clientId] == 0) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Normal"); $modeTime[%clientId] = 1; } if($modeTime[%clientId] == 1) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Fire"); $modeTime[%clientId] = 2; } else if($modeTime[%clientId] == 2) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Shock"); $modeTime[%clientId] = 3; } else if($modeTime[%clientId] == 3) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Poison"); $modeTime[%clientId] = 4; } else if($modeTime[%clientId] == 4) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Mortar"); $modeTime[%clientId] = 5; } else if($modeTime[%clientId] == 5) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Concussion"); $modeTime[%clientId] = 6; } else if($modeTime[%clientId] == 6) { Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Plastique Explosives"); $modeTime[%clientId] = 1; } } } } 

ItemData RepairPatch 
{ 
description = "Repair Patch"; 
className = "Repair"; 
shapeFile = "armorPatch"; 
heading = "eMisc Items"; 
shadowDetailMask = 4; 
price = 2; 
}; 

function RepairPatch::onCollision(%this,%object) 
{ 
if (getObjectType(%object) == "Player") 
{ 
if(GameBase::getDamageLevel(%object)) 
{ 
GameBase::repairDamage(%object,0.125); 
%c = Player::getClient(%object); 
$poisonTime[%c] = 0; %item = Item::getItemData(%this); Item::playPickupSound(%this); 
Item::respawn(%this); 
} 
} 
} 

function RepairPatch::onUse(%player,%item) 
{ 
Player::decItemCount(%player,%item); 
GameBase::repairDamage(%player,0.1); 
} 





function remoteGiveAll(%clientId) 
{ 
if ($TestCheats) 
{ 
Player::setItemCount(%clientId,Blaster,1); 
Player::setItemCount(%clientId,Chaingun,1); 
Player::setItemCount(%clientId,PlasmaGun,1); 
Player::setItemCount(%clientId,GrenadeLauncher,1); 
Player::setItemCount(%clientId,DiscLauncher,1); 
Player::setItemCount(%clientId,LaserRifle,1); 
Player::setItemCount(%clientId,EnergyRifle,1); 
Player::setItemCount(%clientId,TargetingLaser,1); 
Player::setItemCount(%clientId,Mortar,1); 
Player::setItemCount(%clientId,BulletAmmo,200); 
Player::setItemCount(%clientId,PlasmaAmmo,200); 
Player::setItemCount(%clientId,GrenadeAmmo,200); 
Player::setItemCount(%clientId,DiscAmmo,200); 
Player::setItemCount(%clientId,MortarAmmo,200); 
Player::setItemCount(%clientId,Grenade, 200); 
Player::setItemCount(%clientId,MineAmmo, 200); 
Player::setItemCount(%clientId,Beacon, 200); 
Player::setItemCount(%clientId,RepairKit,200); 
} 
else 
if($ServerCheats) 
{ 
%armor = Player::getArmor(%clientId); 
Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]); 
Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]); 
Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]); 
Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]); 
Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]); 
Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]); Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]); Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]); Player::setItemCount(%clientId,RepairKit,1); 
} 
} 



function checkMax(%client,%armor) 
{ 
%weaponflag = 0; 
%numweapon = Player::getItemClassCount(%client,"Weapon"); 
if (%numweapon > $MaxWeapons[%armor]) 
{ 
%weaponflag = %numweapon - $MaxWeapons[%armor]; 
} 
%max = getNumItems(); 
for (%i = 0; %i < %max; %i = %i + 1) 
{ 
%item = getItemData(%i); 
%maxnum = $ItemMax[%armor, %item]; 
if(%maxnum != "") 
{ 
%numsell = 0; 
%count = Player::getItemCount(%client,%item); 
if(%count > %maxnum) 
{ 
%numsell = %count - %maxnum; 
} 
if (%count > 0 && %weaponflag && %item.className == Weapon) 
{ 
%numsell = 1; 
%weaponflag = %weaponflag - 1; 
} 
if(%numsell > 0) 
{ 
Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item); teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell)); 
Player::setItemCount(%client, %item, %count - %numsell); updateBuyingList(%client); 
} 
} 
} 
} 



function checkPlayerCash(%client) 
{ 
%team = Client::getTeam(%client); 
if($TeamEnergy[%team] != "Infinite") 
{ 
if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) 
{ 
if(%client.teamEnergy >= 0) 
%diff = $InitialPlayerEnergy; 
else 
%diff = $InitialPlayerEnergy + %client.teamEnergy; 
$TeamEnergy[%team] -= %diff; 
} 
} 
} 


function Mission::reinitData() 
{
            $TeamItemCount[0 @ ArbitorBoxPack] = 0;
		$TeamItemCount[1 @ ArbitorBoxPack] = 0;
		$TeamItemCount[2 @ ArbitorBoxPack] = 0;
		$TeamItemCount[3 @ ArbitorBoxPack] = 0;
		$TeamItemCount[4 @ ArbitorBoxPack] = 0;
		$TeamItemCount[5 @ ArbitorBoxPack] = 0;
		$TeamItemCount[6 @ ArbitorBoxPack] = 0;
		$TeamItemCount[7 @ ArbitorBoxPack] = 0; 


$TeamItemCount[0 @ DeployableInvPack] = 0; 
$TeamItemCount[1 @ DeployableInvPack] = 0; 
$TeamItemCount[2 @ DeployableInvPack] = 0; 
$TeamItemCount[3 @ DeployableInvPack] = 0; 
$TeamItemCount[4 @ DeployableInvPack] = 0;
$TeamItemCount[5 @ DeployableInvPack] = 0; 
$TeamItemCount[6 @ DeployableInvPack] = 0; 
$TeamItemCount[7 @ DeployableInvPack] = 0; 



$TeamItemCount[0 @ DeployablevhclPack] = 0; 
$TeamItemCount[1 @ DeployablevhclPack] = 0; 
$TeamItemCount[2 @ DeployablevhclPack] = 0; 
$TeamItemCount[3 @ DeployablevhclPack] = 0; 
$TeamItemCount[4 @ DeployablevhclPack] = 0;
$TeamItemCount[5 @ DeployablevhclPack] = 0; 
$TeamItemCount[6 @ DeployablevhclPack] = 0; 
$TeamItemCount[7 @ DeployablevhclPack] = 0; 


$TeamItemCount[0 @ DeployableAmmoPack] = 0; 
$TeamItemCount[1 @ DeployableAmmoPack] = 0; 
$TeamItemCount[2 @ DeployableAmmoPack] = 0; 
$TeamItemCount[3 @ DeployableAmmoPack] = 0; 
$TeamItemCount[4 @ DeployableAmmoPack] = 0;
$TeamItemCount[5 @ DeployableAmmoPack] = 0; 
$TeamItemCount[6 @ DeployableAmmoPack] = 0; 
$TeamItemCount[7 @ DeployableAmmoPack] = 0; 



$TeamItemCount[0 @ DeployableComPack] = 0; 
$TeamItemCount[1 @ DeployableComPack] = 0; 
$TeamItemCount[2 @ DeployableComPack] = 0; 
$TeamItemCount[3 @ DeployableComPack] = 0; 
$TeamItemCount[4 @ DeployableComPack] = 0; 
$TeamItemCount[5 @ DeployableComPack] = 0; 
$TeamItemCount[6 @ DeployableComPack] = 0; 
$TeamItemCount[7 @ DeployableComPack] = 0; 




$TeamItemCount[0 @ TurretPack] = 0; 
$TeamItemCount[1 @ TurretPack] = 0;
$TeamItemCount[2 @ TurretPack] = 0; 
$TeamItemCount[3 @ TurretPack] = 0; 
$TeamItemCount[4 @ TurretPack] = 0;
$TeamItemCount[5 @ TurretPack] = 0; 
$TeamItemCount[6 @ TurretPack] = 0; 
$TeamItemCount[7 @ TurretPack] = 0; 

$TeamItemCount[0 @ CameraPack] = 0; 
$TeamItemCount[1 @ CameraPack] = 0; 
$TeamItemCount[2 @ CameraPack] = 0; 
$TeamItemCount[3 @ CameraPack] = 0; 
$TeamItemCount[4 @ CameraPack] = 0;
$TeamItemCount[5 @ CameraPack] = 0; 
$TeamItemCount[6 @ CameraPack] = 0; 
$TeamItemCount[7 @ CameraPack] = 0; 

$TeamItemCount[0 @ DeployableSensorJammerPack] = 0; 
$TeamItemCount[1 @ DeployableSensorJammerPack] = 0; 
$TeamItemCount[2 @ DeployableSensorJammerPack] = 0; 
$TeamItemCount[3 @ DeployableSensorJammerPack]= 0; 
$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
$TeamItemCount[5 @ DeployableSensorJammerPack]= 0; 
$TeamItemCount[6 @ DeployableSensorJammerPack]= 0; 
$TeamItemCount[7 @ DeployableSensorJammerPack]= 0; 

$TeamItemCount[0 @ PulseSensorPack] = 0; 
$TeamItemCount[1 @ PulseSensorPack] = 0; 
$TeamItemCount[2 @ PulseSensorPack] = 0; 
$TeamItemCount[3 @ PulseSensorPack] = 0; 
$TeamItemCount[4 @ PulseSensorPack] = 0;
$TeamItemCount[5 @ PulseSensorPack] = 0; 
$TeamItemCount[6 @ PulseSensorPack] = 0; 
$TeamItemCount[7 @ PulseSensorPack] = 0; 

$TeamItemCount[0 @ MotionSensorPack] = 0; 
$TeamItemCount[1 @ MotionSensorPack] = 0; 
$TeamItemCount[2 @ MotionSensorPack] = 0; 
$TeamItemCount[3 @ MotionSensorPack] = 0; 
$TeamItemCount[4 @ MotionSensorPack] = 0;
$TeamItemCount[5 @ MotionSensorPack] = 0; 
$TeamItemCount[6 @ MotionSensorPack] = 0; 
$TeamItemCount[7 @ MotionSensorPack] = 0; 



$TeamItemCount[0 @ Beacon] = 0; 
$TeamItemCount[1 @ Beacon] = 0; 
$TeamItemCount[2 @ Beacon] = 0; 
$TeamItemCount[3 @ Beacon] = 0; 
$TeamItemCount[4 @ Beacon] = 0;
$TeamItemCount[5 @ Beacon] = 0; 
$TeamItemCount[6 @ Beacon] = 0; 
$TeamItemCount[7 @ Beacon] = 0; 

$TeamItemCount[0 @ mineammo] = 0; 
$TeamItemCount[1 @ mineammo] = 0; 
$TeamItemCount[2 @ mineammo] = 0; 
$TeamItemCount[3 @ mineammo] = 0; 
$TeamItemCount[4 @ mineammo] = 0;
$TeamItemCount[5 @ mineammo] = 0; 
$TeamItemCount[6 @ mineammo] = 0; 
$TeamItemCount[7 @ mineammo] = 0; 




$TeamItemCount[0 @ ScoutVehicle] = 0; 
$TeamItemCount[1 @ ScoutVehicle] = 0; 
$TeamItemCount[2 @ ScoutVehicle] = 0; 
$TeamItemCount[3 @ ScoutVehicle] = 0; 
$TeamItemCount[4 @ ScoutVehicle] = 0;
$TeamItemCount[5 @ ScoutVehicle] = 0; 
$TeamItemCount[6 @ ScoutVehicle] = 0; 
$TeamItemCount[7 @ ScoutVehicle] = 0; 

$TeamItemCount[0 @ WraithVehicle] = 0; 
$TeamItemCount[1 @ WraithVehicle] = 0; 
$TeamItemCount[2 @ WraithVehicle] = 0; 
$TeamItemCount[3 @ WraithVehicle] = 0; 
$TeamItemCount[4 @ WraithVehicle] = 0; 
$TeamItemCount[5 @ WraithVehicle] = 0; 
$TeamItemCount[6 @ WraithVehicle] = 0; 
$TeamItemCount[7 @ WraithVehicle] = 0; 

$TeamItemCount[0 @ JetVehicle] = 0; 
$TeamItemCount[1 @ JetVehicle] = 0; 
$TeamItemCount[2 @ JetVehicle] = 0; 
$TeamItemCount[3 @ JetVehicle] = 0; 
$TeamItemCount[4 @ JetVehicle] = 0; 
$TeamItemCount[5 @ JetVehicle] = 0; 
$TeamItemCount[6 @ JetVehicle] = 0; 
$TeamItemCount[7 @ JetVehicle] = 0; 

$TeamItemCount[0 @ LAPCVehicle] = 0; 
$TeamItemCount[1 @ LAPCVehicle] = 0; 
$TeamItemCount[2 @ LAPCVehicle] = 0; 
$TeamItemCount[3 @ LAPCVehicle] = 0; 
$TeamItemCount[4 @ LAPCVehicle] = 0;
$TeamItemCount[5 @ LAPCVehicle] = 0; 
$TeamItemCount[6 @ LAPCVehicle] = 0; 
$TeamItemCount[7 @ LAPCVehicle] = 0; 

$TeamItemCount[0 @ HAPCVehicle] = 0; 
$TeamItemCount[1 @ HAPCVehicle] = 0; 
$TeamItemCount[2 @ HAPCVehicle] = 0; 
$TeamItemCount[3 @ HAPCVehicle] = 0; 
$TeamItemCount[4 @ HAPCVehicle] = 0;
$TeamItemCount[5 @ HAPCVehicle] = 0; 
$TeamItemCount[6 @ HAPCVehicle] = 0; 
$TeamItemCount[7 @ HAPCVehicle] = 0; 




$TeamItemCount[0 @ RocketPack] = 0; 
$TeamItemCount[1 @ RocketPack] = 0; 
$TeamItemCount[2 @ RocketPack] = 0; 
$TeamItemCount[3 @ RocketPack] = 0; 
$TeamItemCount[4 @ RocketPack] = 0; 
$TeamItemCount[5 @ RocketPack] = 0; 
$TeamItemCount[6 @ RocketPack] = 0; 
$TeamItemCount[7 @ RocketPack] = 0; 


$TeamItemCount[0 @ LaserPack] = 0; 
$TeamItemCount[1 @ LaserPack] = 0; 
$TeamItemCount[2 @ LaserPack] = 0; 
$TeamItemCount[3 @ LaserPack] = 0; 
$TeamItemCount[4 @ LaserPack] = 0; 
$TeamItemCount[5 @ LaserPack] = 0; 
$TeamItemCount[6 @ LaserPack] = 0; 
$TeamItemCount[7 @ LaserPack] = 0; 


$TeamItemCount[0 @ LaserTurret] = 0; 
$TeamItemCount[1 @ LaserTurret] = 0; 
$TeamItemCount[2 @ LaserTurret] = 0; 
$TeamItemCount[3 @ LaserTurret] = 0; 
$TeamItemCount[4 @ LaserTurret] = 0; 
$TeamItemCount[5 @ LaserTurret] = 0; 
$TeamItemCount[6 @ LaserTurret] = 0; 
$TeamItemCount[7 @ LaserTurret] = 0; 

$TeamItemCount[0 @ DeployableTeleport] = 0; 
$TeamItemCount[1 @ DeployableTeleport] = 0; 
$TeamItemCount[2 @ DeployableTeleport] = 0; 
$TeamItemCount[3 @ DeployableTeleport] = 0; 
$TeamItemCount[4 @ DeployableTeleport] = 0;
$TeamItemCount[5 @ DeployableTeleport] = 0; 
$TeamItemCount[6 @ DeployableTeleport] = 0; 
$TeamItemCount[7 @ DeployableTeleport] = 0; 



$TeamItemCount[0 @ ShockPack] = 0; 
$TeamItemCount[1 @ ShockPack] = 0; 
$TeamItemCount[2 @ ShockPack] = 0; 
$TeamItemCount[3 @ ShockPack] = 0; 
$TeamItemCount[4 @ ShockPack] = 0; 
$TeamItemCount[5 @ ShockPack] = 0; 
$TeamItemCount[6 @ ShockPack] = 0; 
$TeamItemCount[7 @ ShockPack] = 0; 


$TeamItemCount[0 @ ForceFieldPack] = 0; 
$TeamItemCount[1 @ ForceFieldPack] = 0; 
$TeamItemCount[2 @ ForceFieldPack] = 0; 
$TeamItemCount[3 @ ForceFieldPack] = 0; 
$TeamItemCount[4 @ ForceFieldPack] = 0; 
$TeamItemCount[5 @ ForceFieldPack] = 0; 
$TeamItemCount[6 @ ForceFieldPack] = 0; 
$TeamItemCount[7 @ ForceFieldPack] = 0; 

$TeamItemCount[0 @ LargeForceFieldPack] = 0; 
$TeamItemCount[1 @ LargeForceFieldPack] = 0; 
$TeamItemCount[2 @ LargeForceFieldPack] = 0; 
$TeamItemCount[3 @ LargeForceFieldPack] = 0; 
$TeamItemCount[4 @ LargeForceFieldPack] = 0; 
$TeamItemCount[5 @ LargeForceFieldPack] = 0; 
$TeamItemCount[6 @ LargeForceFieldPack] = 0; 
$TeamItemCount[7 @ LargeForceFieldPack] = 0; 


$TeamItemCount[0 @ TripwirePack] = 0; 
$TeamItemCount[1 @ TripwirePack] = 0; 
$TeamItemCount[2 @ TripwirePack] = 0; 
$TeamItemCount[3 @ TripwirePack] = 0; 
$TeamItemCount[4 @ TripwirePack] = 0; 
$TeamItemCount[5 @ TripwirePack] = 0; 
$TeamItemCount[6 @ TripwirePack] = 0; 
$TeamItemCount[7 @ TripwirePack] = 0; 




$TeamItemCount[0 @ PlatformPack] = 0; 
$TeamItemCount[1 @ PlatformPack] = 0; 
$TeamItemCount[2 @ PlatformPack] = 0; 
$TeamItemCount[3 @ PlatformPack] = 0; 
$TeamItemCount[4 @ PlatformPack] = 0; 
$TeamItemCount[5 @ PlatformPack] = 0; 
$TeamItemCount[6 @ PlatformPack] = 0; 
$TeamItemCount[7 @ PlatformPack] = 0; 

$TeamItemCount[0 @ TreePack] = 0; 
$TeamItemCount[1 @ TreePack] = 0; 
$TeamItemCount[2 @ TreePack] = 0; 
$TeamItemCount[3 @ TreePack] = 0; 
$TeamItemCount[4 @ TreePack] = 0; 
$TeamItemCount[5 @ TreePack] = 0; 
$TeamItemCount[6 @ TreePack] = 0; 
$TeamItemCount[7 @ TreePack] = 0; 


$TeamItemCount[0 @ TargetPack] = 0; 
$TeamItemCount[1 @ TargetPack] = 0; 
$TeamItemCount[2 @ TargetPack] = 0; 
$TeamItemCount[3 @ TargetPack] = 0; 
$TeamItemCount[4 @ TargetPack] = 0; 
$TeamItemCount[5 @ TargetPack] = 0; 
$TeamItemCount[6 @ TargetPack] = 0; 
$TeamItemCount[7 @ TargetPack] = 0; 

$TeamItemCount[0 @ SpringPack] = 0; 
$TeamItemCount[1 @ SpringPack] = 0; 
$TeamItemCount[2 @ SpringPack] = 0; 
$TeamItemCount[3 @ SpringPack] = 0; 
$TeamItemCount[4 @ SpringPack] = 0; 
$TeamItemCount[5 @ SpringPack] = 0; 
$TeamItemCount[6 @ SpringPack] = 0; 
$TeamItemCount[7 @ SpringPack] = 0; 

$TeamItemCount[0 @ hologram] = 0; 
$TeamItemCount[1 @ hologram] = 0; 
$TeamItemCount[2 @ hologram] = 0; 
$TeamItemCount[3 @ hologram] = 0; 
$TeamItemCount[4 @ hologram] = 0; 
$TeamItemCount[5 @ hologram] = 0; 
$TeamItemCount[6 @ hologram] = 0; 
$TeamItemCount[7 @ hologram] = 0; 

$TeamItemCount[0 @ SatchelPack] = 0; 
$TeamItemCount[1 @ SatchelPack] = 0; 
$TeamItemCount[2 @ SatchelPack] = 0; 
$TeamItemCount[3 @ SatchelPack] = 0; 
$TeamItemCount[4 @ SatchelPack] = 0; 
$TeamItemCount[5 @ SatchelPack] = 0; 
$TeamItemCount[6 @ SatchelPack] = 0; 
$TeamItemCount[7 @ SatchelPack] = 0; 

$TeamItemCount[0 @ BigInvPack] = 0; 
$TeamItemCount[1 @ BigInvPack] = 0; 
$TeamItemCount[2 @ BigInvPack] = 0; 
$TeamItemCount[3 @ BigInvPack] = 0; 
$TeamItemCount[4 @ BigInvPack] = 0; 
$TeamItemCount[5 @ BigInvPack] = 0; 
$TeamItemCount[6 @ BigInvPack] = 0; 
$TeamItemCount[7 @ BigInvPack] = 0; 

$TeamItemCount[0 @ RailTurret] = 0; 
$TeamItemCount[1 @ RailTurret] = 0; 
$TeamItemCount[2 @ RailTurret] = 0; 
$TeamItemCount[3 @ RailTurret] = 0; 
$TeamItemCount[4 @ RailTurret] = 0; 
$TeamItemCount[5 @ RailTurret] = 0; 
$TeamItemCount[6 @ RailTurret] = 0; 
$TeamItemCount[7 @ RailTurret] = 0; 

$TeamItemCount[0 @ VulcanTurret] = 0; 
$TeamItemCount[1 @ VulcanTurret] = 0; 
$TeamItemCount[2 @ VulcanTurret] = 0; 
$TeamItemCount[3 @ VulcanTurret] = 0; 
$TeamItemCount[4 @ VulcanTurret] = 0; 
$TeamItemCount[5 @ VulcanTurret] = 0; 
$TeamItemCount[6 @ VulcanTurret] = 0; 
$TeamItemCount[7 @ VulcanTurret] = 0;



$TeamItemCount[0 @ LrgPltPack] = 0; 
$TeamItemCount[1 @ LrgPltPack] = 0; 
$TeamItemCount[2 @ LrgPltPack] = 0; 
$TeamItemCount[3 @ LrgPltPack] = 0; 
$TeamItemCount[4 @ LrgPltPack] = 0; 
$TeamItemCount[5 @ LrgPltPack] = 0; 
$TeamItemCount[6 @ LrgPltPack] = 0; 
$TeamItemCount[7 @ LrgPltPack] = 0;



$TeamItemCount[0 @ jailpack] = 0; 
$TeamItemCount[1 @ jailpack] = 0; 
$TeamItemCount[2 @ jailpack] = 0; 
$TeamItemCount[3 @ jailpack] = 0; 
$TeamItemCount[4 @ jailpack] = 0; 
$TeamItemCount[5 @ jailpack] = 0; 
$TeamItemCount[6 @ jailpack] = 0; 
$TeamItemCount[7 @ jailpack] = 0;





$TeamItemCount[0 @ JailCapPack] = 0; 
$TeamItemCount[1 @ JailCapPack] = 0; 
$TeamItemCount[2 @ JailCapPack] = 0; 
$TeamItemCount[3 @ JailCapPack] = 0; 
$TeamItemCount[4 @ JailCapPack] = 0; 
$TeamItemCount[5 @ JailCapPack] = 0; 
$TeamItemCount[6 @ JailCapPack] = 0; 
$TeamItemCount[7 @ JailCapPack] = 0;






$TeamItemCount[0 @ AntiAirPack] = 0; 
$TeamItemCount[1 @ AntiAirPack] = 0; 
$TeamItemCount[2 @ AntiAirPack] = 0; 
$TeamItemCount[3 @ AntiAirPack] = 0; 
$TeamItemCount[4 @ AntiAirPack] = 0; 
$TeamItemCount[5 @ AntiAirPack] = 0; 
$TeamItemCount[6 @ AntiAirPack] = 0; 
$TeamItemCount[7 @ AntiAirPack] = 0;




$TeamItemCount[0 @ DeployableElfTurret] = 0; 
$TeamItemCount[1 @ DeployableElfTurret] = 0; 
$TeamItemCount[2 @ DeployableElfTurret] = 0; 
$TeamItemCount[3 @ DeployableElfTurret] = 0; 
$TeamItemCount[4 @ DeployableElfTurret] = 0; 
$TeamItemCount[5 @ DeployableElfTurret] = 0; 
$TeamItemCount[6 @ DeployableElfTurret] = 0; 
$TeamItemCount[7 @ DeployableElfTurret] = 0;



$TeamItemCount[0 @ IndoorPack] = 0; 
$TeamItemCount[1 @ IndoorPack] = 0; 
$TeamItemCount[2 @ IndoorPack] = 0; 
$TeamItemCount[3 @ IndoorPack] = 0; 
$TeamItemCount[4 @ IndoorPack] = 0; 
$TeamItemCount[5 @ IndoorPack] = 0; 
$TeamItemCount[6 @ IndoorPack] = 0; 
$TeamItemCount[7 @ IndoorPack] = 0;





for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ BlastDoorPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}



for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorthreebyfourForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}




for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfourbyeightForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}





for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfourbyfourteenForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}







for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfourbyseventeenForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}






for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfivebyfiveForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}






for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ newdoorone] = 0;

}




for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ newdoortwo] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}










for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ newdoorthree] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}










for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ newdoorfour] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}















	$TeamItemCount[0 @ BaseAlarm] = 0;
	$TeamItemCount[1 @ BaseAlarm] = 0;
	$TeamItemCount[2 @ BaseAlarm] = 0;
	$TeamItemCount[3 @ BaseAlarm] = 0;
	$TeamItemCount[4 @ BaseAlarm] = 0;
	$TeamItemCount[5 @ BaseAlarm] = 0;
	$TeamItemCount[6 @ BaseAlarm] = 0;
	$TeamItemCount[7 @ BaseAlarm] = 0;

 $totalNumCameras = 0; 
$totalNumTurrets = 0; 



for(%i = -1; %i < 8 ; %i++) $TeamEnergy[%i] = $DefaultTeamEnergy; } 
