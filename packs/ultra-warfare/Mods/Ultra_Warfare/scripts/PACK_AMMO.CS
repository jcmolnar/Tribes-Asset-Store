//================================================================
//Ammo Pack
//================================================================
$InvList[AmmoPack] = 1;
$RemoteInvList[AmmoPack] = 1;
//=================================================
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[marmor, AmmoPack] = 1;
$ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[harmor, AmmoPack] = 1;
//================================================================
// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[FEBAmmo] = 150;
$AmmoPackMax[ChaingunAmmo] = 150;
$AmmoPackMax[PulseAmmo] = 100;
$AmmoPackMax[MinigunAmmo] = 0;
$AmmoPackMax[DiscAmmo] = 50;
$AmmoPackMax[RailAmmo] = 25;
$AmmoPackMax[ReaperAmmo] = 350;
$AmmoPackMax[FireAmmo] = 250;
$AmmoPackMax[FlamerAmmo] = 0;
$AmmoPackMax[InfernoAmmo] = 0;
$AmmoPackMax[FusionAmmo] = 75;
$AmmoPackMax[PlasmaAmmo] = 50;
$AmmoPackMax[MinerAmmo] = 3;
$AmmoPackMax[GrenadeAmmo] = 50;
$AmmoPackMax[FGLAmmo] = 16;
$AmmoPackMax[MortarAmmo] = 25;
$AmmoPackMax[MissileAmmo] = 3;
$AmmoPackMax[TrojaxAmmo] = 15;
$AmmoPackMax[ShockAmmo] = 5;
//================================================================
// Items in the AmmoPack
$AmmoPackItems[0] = FEBAmmo;
$AmmoPackItems[1] = ChaingunAmmo;
$AmmoPackItems[2] = PulseAmmo;
$AmmoPackItems[3] = DiscAmmo;
$AmmoPackItems[4] = RailAmmo;
$AmmoPackItems[5] = ReaperAmmo;
$AmmoPackItems[6] = FireAmmo;
$AmmoPackItems[7] = FlamerAmmo;
$AmmoPackItems[8] = InfernoAmmo;
$AmmoPackItems[9] = FusionAmmo;
$AmmoPackItems[10] = PlasmaAmmo;
$AmmoPackItems[11] = MinerAmmo;
$AmmoPackItems[12] = GrenadeAmmo;
$AmmoPackItems[13] = FGLAmmo;
$AmmoPackItems[14] = MortarAmmo;
$AmmoPackItems[15] = MissileAmmo;
$AmmoPackItems[16] = TrojaxAmmo;
$AmmoPackItems[17] = ShockAmmo;
//================================================================
ItemImageData AmmoPackImage
{
	shapeFile = "pack_ammo";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "pack_ammo";
	className = "Backpack";
   heading = "gUtility Packs";
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
		for(%i = 0; %i < 20 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.FEBAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.ChaingunAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.PulseAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.RailAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.ReaperAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.FireAmmo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.FlamerAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.InfernoAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.FusionAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.MinerAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.FGLAmmo = %numPack;
			}
			else if(%i == 14) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 15) {
	 	    	%item.MissileAmmo = %numPack;
			}
			else if(%i == 16) {
	 	    	%item.TrojaxAmmo = %numPack;
			}
			else if(%i == 17) {
	 	    	%item.ShockAmmo = %numPack;
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
	for(%i = 0; %i < 18 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.FEBAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.ChaingunAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.PulseAmmo;
		}
		else if(%i == 3) {
 	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 4) {
 	    	%numAdd = %item.RailAmmo;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.ReaperAmmo;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.FireAmmo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.FlamerAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.InfernoAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.FusionAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.MinerAmmo;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.FGLAmmo;
		}
		else if(%i == 14) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.MissileAmmo;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.TrojaxAmmo;
		}
		else {
		%numAdd = %item.ShockAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 18 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}
//================================================================