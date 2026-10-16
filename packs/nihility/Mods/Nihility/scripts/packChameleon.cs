//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
//$InvList[ChameleonPack] = 1;

$ItemMax[larmor, ChameleonPack] = 1;	//Seraph
$ItemMax[lfemale, ChameleonPack] = 1;	//Seraph
$ItemMax[earmor, ChameleonPack] = 0;	//Slave
$ItemMax[efemale, ChameleonPack] = 0;	//Slave
$ItemMax[marmor, ChameleonPack] = 0;	//Pawn
$ItemMax[aarmor, ChameleonPack] = 0;	//Navigator
$ItemMax[darmor, ChameleonPack] = 0;	//Atomizer
$ItemMax[barmor, ChameleonPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData ChameleonPackImage 
{	shapeFile = "ammoPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 5;
	maxEnergy = 12;
	sfxFire = SoundShieldOn; 
	firstPerson = false;
};

ItemData ChameleonPack 
{	description = "Chameleon Pack";
	shapeFile = "ammoPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ChameleonPackImage;
	price = 33;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
};

function ChameleonPackImage::onActivate(%player,%imageSlot) 
{	%clientId = Player::getClient(%player);
	if(getNumTeams() > 2 || $UnCvrA || $UnCvrB) 
	{	if(getNumTeams() > 2) 
		{	Client::sendMessage(%clientId,0,"Can't go use your chameleon powers with more then 2 teams~waccess_denied.wav");
			Player::decItemCount(%clientId, Player::getMountedItem(%clientId,$BackpackSlot));
			return;
		} 
		else 
			if(GameBase::getTeam($UnCvrA) == GameBase::getTeam(%clientId)) 
		 	{	Client::sendMessage(%clientId,0,Client::getName($UnCvrA) @ " already summoned the chameleon power, one at a time only~waccess_denied.wav");
				Player::trigger(%player, $BackpackSlot, false);
				return;
	 		} 
		else 
 			if(GameBase::getTeam($UnCvrB) == GameBase::getTeam(%clientId)) 
			{	Client::sendMessage(%clientId,0,Client::getName($UnCvrB) @ " already summoned the chameleon power, one at a time only~waccess_denied.wav");
				Player::trigger(%player, $BackpackSlot, false);
 				return;
			}
	}
	Player::dropItem(%clientId, Flag);
	%clientId.isSpy = true;
	if (Client::getTeam(%clientId) == 0) 
	{	$UnCvrA = %clientId;
		%clientId.OrigTeam = 5;
		teamMessages(1, 0, Client::getName(%clientId) @ " summons chameleon powers", -2, "", "");
		Client::setinitialTeam(%clientId, 1);
		GameBase::setTeam(%clientId, 1);
		Client::setinitialTeam(%clientId, 0);
		Client::setSkin(%clientId, $Server::teamSkin[1]);
	} 
	else 
	{	$UnCvrB = %clientId;
		%clientId.OrigTeam = 6;
		teamMessages(1, 1, Client::getName(%clientId) @ " summons chameleon powers", -2, "", "");
		Client::setinitialTeam(%clientId, 0);
		GameBase::setTeam(%clientId, 0);
		Client::setinitialTeam(%clientId, 1);
		Client::setSkin(%clientId, $Server::teamSkin[0]);
	} 
} 

function ChameleonPackImage::onDeactivate(%player,%imageSlot) 
{	%cl = Player::getClient(%player);
	if(%cl.OrigTeam != 5 && %cl.OrigTeam != 6) 
		return;
	if(%cl.OrigTeam == 5) 
	{	$UnCvrA = "";
		GameBase::setTeam(%cl,0);
	} 
	else 
		if(%cl.OrigTeam == 6) 
		{	$UnCvrB = "";
			GameBase::setTeam(%cl,1);
		}
	if(%cl.custom) 
		Client::setSkin(%cl, $Client::info[%cl, 0]);
	else 
		Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]);
	%pack = Player::getMountedItem(%cl,$BackpackSlot);
	//Player::decItemCount(%player, %pack);
	%cl.isSpy = false;
	%cl.OrigTeam = "";
	Client::sendMessage(%cl,0,"Your Chameleon powers wear Off~waccess_denied.wav");
}