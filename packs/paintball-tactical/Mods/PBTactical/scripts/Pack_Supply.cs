
//----------
ItemImageData SuPackImage 
{
	shapeFile = "mortarpack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	minEnergy = 4;
	maxEnergy = 9;
	firstPerson = false;
};

ItemData SuPack 
{
  description = "Supply Pack";
  shapeFile = "mortarpack";
  className = "Backpack";
  heading = $InvHead[ihGad];
  shadowDetailMask = 4;
  imageType = SuPackImage;
  price = 0;
  hudIcon = "fear";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function SuPackImage::onActivate(%player, %imageSlot)
{
	SuPack::onUse(%player, %item);
	SuPackImage::onDeactivate(%player, %imageSlot);
}
function SuPackImage::onDeactivate(%player, %imageSlot)
{
}
function SuPack::onUse(%player,%item) 
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%clientId = player::getClient(%player);
		Client::sendMessage(%clientId,3,"SupplyPack: Re-Filling...");
		schedule("RefilMsg("@%clientId@");", 0.4);
		schedule("Player::decItemCount("@%player@","@%item@");", 0.4);
		%cnt = 0;
		%cnt = %cnt + AmmoStation::resupply(%player,Mine,mineammo,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Angel,AngelAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Dragun,DragunAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,AutoCocker,AutoCockerAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Spyder,SpyderAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,TipmannS,TipmannSAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Mongoose,MongooseAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Inferno,InfernoAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Psycho,PsychoAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,SmartParts,SmartPartsAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,WMAssault,WMAssaultAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Delta,DeltaAmmo,250);
		%cnt = %cnt + AmmoStation::resupply(%player,Spyder,SpyderClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Angel,AngelClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,AutoCocker,AutoCockerClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Dragun,DragunClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Mongoose,MongooseClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Psycho,PsychoClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Inferno,InfernoClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,SmartParts,SmartPartsClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,WMAssault,WMAssaultClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,Delta,DeltaClip,1);
		%cnt = %cnt + AmmoStation::resupply(%player,M79,M79Ammo,10);
		%cnt = %cnt + AmmoStation::resupply(%player,Bunker,BunkerAmmo,6);
		%cnt = %cnt + AmmoStation::resupply(%player,AWPTShotgun,AWPTShotgunAmmo,24);
		return %cnt;	
	}
}
function RefilMsg(%clientId)
{
	client::sendMessage(%clientId, 3, "SupplyPack: Re-Filling Complete");
}

//Invo Stuff
$ItemMax[larmor, SuPack] = 1;
$ItemMax[lfemale, SuPACK] = 1;
$InvList[SuPACK] = 1;