// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

	if(Player::getItemCount($resupply, C4Ammo))
		%cnt = %cnt + AmmoStation::resupply($resupply,"",C4Ammo,2);
	else if(Player::getItemCount($resupply, FlashgrenadeAmmo))
		%cnt = %cnt + AmmoStation::resupply($resupply,"",FlashgrenadeAmmo,5);
	else if(Player::getItemCount($resupply, StungrenadeAmmo))
		%cnt = %cnt + AmmoStation::resupply($resupply,"",StungrenadeAmmo,2);
	else if(Player::getItemCount($resupply, SuicideAmmo))
	{
		 //max 1
	}
	else
		%cnt = %cnt + AmmoStation::resupply($resupply,"",HandgrenadeAmmo,2);

	if (Player::getItemCount($resupply, FlagMine) || Player::getItemCount($resupply, ReplicatingMine))
	{
		// Max 1
	}
	else
		%cnt = %cnt + AmmoStation::resupply($resupply, "", OriginalMine, 3);

	%cnt = %cnt + AmmoStation::resupply($resupply,Concuss,ConcussAmmo,5);
	%cnt = %cnt + AmmoStation::resupply($resupply,SlowGun,SlowGunAmmo,2);
	%cnt = %cnt + AmmoStation::resupply($resupply,Marlin,MarlinAmmo,2);

	if(Player::getItemCount($resupply, PlasmaGun) && %client.plasmaType == "FlamePlasma")
	{
		%max = 5 * $ItemMax[Player::getArmor($resupply), PlasmaAmmo];
		%delta = %max - Player::getItemCount($resupply, PlasmaAmmo);
		Player::setItemCount($resupply, PlasmaAmmo, %max);
		%cnt = %cnt + %delta;
		teamEnergyBuySell($resupply, PlasmaAmmo.price * %delta * -1);
	}
	if(Player::getItemCount($resupply, DiscLauncher) && %client.discType == "Homing")
	{
		%max = floor($ItemMax[Player::getArmor($resupply), DiscAmmo]/3);
		%delta = %max - Player::getItemCount($resupply, DiscAmmo);
		Player::setItemCount($resupply, DiscAmmo, %max);
		%cnt = %cnt + %delta;
		teamEnergyBuySell($resupply, DiscAmmo.price * %delta * -1);
	}
