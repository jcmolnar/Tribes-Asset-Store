$InvList[SuicidePack] = 1;
$MobileInvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;
AddItem(SuicidePack);

ItemImageData SuicidePackImage 
{	
	shapeFile = "ammopack";
	mountPoint = 2;
	mass = 0.5;
	firstPerson = false;
};

ItemData SuicidePack 
{	
	description = "Drone Selector";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
	{
		%client = Player::getClient(%player);
		if(!%client.dronemode)
			%client.dronemode = 0;
		%numberon = %client.dronemode;
		%numberon++;
		if(%numberon == 7)
				%numberon = 0;
		if(%numberon == 0)
			Bottomprint(%client, "<jc>Laser Drone:<f2> Fires weak, pulse lasers. Good for long range sniping from a safe location.");
		if(%numberon == 1)
			Bottomprint(%client, "<jc>Chaingun Drone:<f2> Machinegun drone. Mainly shorter ranged.");
		if(%numberon == 2)
			Bottomprint(%client, "<jc>Aireal Drone:<f2> The only drone that can deploy in air.  Very similar to the chaingun drone, except that it is very fragile.");
		if(%numberon == 3)
			Bottomprint(%client, "<jc>Grenade Drone:<f2> Acidcloud grenade launcher. Good at getting those hard to reach areas in bases.");
		if(%numberon == 4)
			Bottomprint(%client, "<jc>Turret Eliminator:<f2> Fires a very slow shot that specifically hurts turrets. Short range.");
		if(%numberon == 5)
			Bottomprint(%client, "<jc>Guardian:<f2> AUTOMATED DRONE.  Short ranged and only lasts 30 seconds before falling apart, but useful to help in close combat.");
		if(%numberon == 6)
			Bottomprint(%client, "<jc>Hunter Drone:<f2> AUTOMATED DRONE.  It fires itself at the target and locks on, but is rather slow.  It must fire itself within 3 seconds of activation.");

		%client.dronemode = %numberon;
	}
}
