$InvList[GhostPack] = 1;
$MobileInvList[GhostPack] = 1;
$RemoteInvList[GhostPack] = 1;
additem(GhostPack);

ItemImageData GhostPackImage
{
	shapeFile = "shieldpack"; //grenadeL
	mountPoint = 2;
	mass = 2.0;
	firstPerson = false;
	lightType = 1; // Pulsing 2 pulsing, 3 fire, 1 continuous
	lightRadius = 2;
	lightColor = { 0.3, 0.4, 0.5};
};

ItemData GhostPack
{
	description = "EMP Pack";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	imageType = GhostPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "energyrifle";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GhostPack::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	bottomprint(Player::getClient(%player), "<jc>EMP Pack: <f2>Creates a massive emp around the user. The user is NOT immune.", 10);
}

function GhostPack::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);

	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		gamebase::setautorepairrate(%player, 0.001);
	bottomprint(Player::getClient(%player), "<jc>EMP Pack: <f2>Creates a massive emp around the user. The user is NOT immune.", 10);
	}
	else{
		%trans = Gamebase::getmuzzletransform(%player);
		%vel = "0 0 0";
		Projectile::spawnProjectile("EMPackBlast",%trans,%player,%vel);
		gamebase::playsound(%player, SoundFireLaser, 0.5);
	}
}