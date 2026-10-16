$InvList[AmmoPack] = 1;
$RemoteInvList[AmmoPack] = 1;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[FieldMortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[NormalMine] = 5;
$AmmoPackMax[DecoyMine] = 5;
$AmmoPackMax[EMPMine] = 5;
$AmmoPackMax[FlagMine] = 5;
$AmmoPackMax[FlashMine] = 5;
$AmmoPackMax[IncendiaryMine] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[ShrapnelGrenade] = 10;
$AmmoPackMax[AcidGrenade] = 10;
$AmmoPackMax[EMPGrenade] = 10;
$AmmoPackMax[FlashGrenade] = 10;
$AmmoPackMax[IncendiaryGrenade] = 10;
$AmmoPackMax[PoisonGasGrenade] = 10;
$AmmoPackMax[RadiationGrenade] = 10;
$AmmoPackMax[RemoteBomb] = 10;
$AmmoPackMax[SmokeLineGrenade] = 10;
$AmmoPackMax[Beacon] = 5;
$AmmoPackMax[CircuitExplosive] = 5;
$AmmoPackMax[TimedExplosiveGrenade] = 5;
$AmmoPackMax[SniperRifleAmmo] = 10;
$AmmoPackMax[ShotgunAmmo] = 15;
$AmmoPackMax[RadiationCanisterAmmo] = 10;
$AmmoPackMax[GasCanisterAmmo] = 10;
$AmmoPackMax[FlakCannonAmmo] = 50;
$AmmoPackMax[AntiPersonnelCannonAmmo] = 200;
$AmmoPackMax[ExplosiveGatAmmo] = 30;
$AmmoPackMax[EMPCannonAmmo] = 10;
$AmmoPackMax[ArtilleryShellAmmo] = 2;
$AmmoPackMax[AcidSprayerAmmo] = 50;
$AmmoPackMax[RocketLauncherAmmo] = 10;


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = NormalMine;
$AmmoPackItems[9] = ShrapnelGrenade;
$AmmoPackItems[10] = SniperRifleAmmo;
$AmmoPackItems[11] = ShotgunAmmo;
$AmmoPackItems[12] = RadiationCanisterAmmo;
$AmmoPackItems[13] = GasCanisterAmmo;
$AmmoPackItems[14] = FlakCannonAmmo;
$AmmoPackItems[15] = AntiPersonnelCannonAmmo;
$AmmoPackItems[16] = ExplosiveGatAmmo;
$AmmoPackItems[17] = EMPCannonAmmo;
$AmmoPackItems[18] = ArtilleryShellAmmo;
$AmmoPackItems[19] = AcidSprayerAmmo;
$AmmoPackItems[20] = RocketLauncherAmmo;
$AmmoPackList = 21;


ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $AmmoPackList ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MineAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.Beacon = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.NormalMine = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.ShrapnelGrenade = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.SniperRifleAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.ShotgunAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.RadiationCanisterAmmo = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.GasCanisterAmmo = %numPack;
			}
			else if(%i == 14) {
	 	    	%item.FlakCannonAmmo = %numPack;
			}
			else if(%i == 15) {
	 	    	%item.AntiPersonnelCannonAmmo = %numPack;
			}
			else if(%i == 16) {
	 	    	%item.ExplosiveGatAmmo = %numPack;
			}
			else if(%i == 17) {
	 	    	%item.EMPCannonAmmo = %numPack;
			}
			else if(%i == 18) {
	 	    	%item.ArtilleryShellAmmo = %numPack;
			}
			else if(%i == 19) {
	 	    	%item.AcidSprayerAmmo = %numPack;
			}
			else if(%i == 20) {
	 	    	%item.RocketLauncherAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < $AmmoPackList ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MineAmmo;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.Beacon;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.NormalMine;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.ShrapnelGrenade;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.SniperRifleAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.ShotgunAmmo;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.RadiationCanisterAmmo;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.GasCanisterAmmo;
		}
		else if(%i == 14) {
 	    	%numAdd = %item.FlakCannonAmmo;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.AntiPersonnelCannonAmmo;
		}
		else if(%i == 16) {
 	    	%numAdd = %item.ExplosiveGatAmmo;
		}
		else if(%i == 17) {
 	    	%numAdd = %item.EMPCannonAmmo;
		}
		else if(%i == 18) {
 	    	%numAdd = %item.ArtilleryShellAmmo;
		}
		else if(%i == 19) {
 	    	%numAdd = %item.AcidSprayerAmmo;
		}
		else if(%i == 20) {
 	    	%numAdd = %item.RocketLauncherAmmo;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}


function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $AmmoPackList ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

