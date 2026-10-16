$InvList[NormalMine] = 1;
$RemoteInvList[NormalMine] = 1;
$AutoUse[NormalMine] = 0;
$CoreType[NormalMine] = "Mine";
$Core[Mine, $MineInitCounter++] = NormalMine;

$SellAmmo[NormalMine] = 10;

// Who can use this mine and how much they can carry
$ItemMax[reconarmor, NormalMine] = 3;
$ItemMax[reconfemalearmor, NormalMine] = 3;
$ItemMax[espionagearmor, NormalMine] = 3;
$ItemMax[espionagefemalearmor, NormalMine] = 3;
$ItemMax[engineerarmor, NormalMine] = 3;
$ItemMax[engineerfemalearmor, NormalMine] = 3;
$ItemMax[infantryarmor, NormalMine] = 3;
$ItemMax[infantryfemalearmor, NormalMine] = 3;
$ItemMax[falloutarmor, NormalMine] = 3;
$ItemMax[falloutfemalearmor, NormalMine] = 3;
$ItemMax[demolitionsarmor, NormalMine] = 5;
$ItemMax[assaultarmor, NormalMine] = 3;
$ItemMax[artilleryarmor, NormalMine] = 3;
$ItemMax[commanderarmor, NormalMine] = 3;

ItemData NormalMine
{
	description = "+ Normal Core";
	shapeFile = "mineammo";
	heading = "hMines";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function NormalMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a mine to put this core into
			if (Player::incItemCount(%player, MineAmmo, 0) > 0) {
				Player::decItemCount(%player,MineAmmo);

				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","AntipersonelMine");
			 	addToSet("MissionCleanup", %obj);

				// If smart mines, set this mine's team
				if ($Specialist::SmartMines) {
					%playerteam = GameBase::getTeam(%player);
					GameBase::setTeam(%obj, %playerteam);
				}

				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
			}
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a mine.");
			}
		}
	}
}


