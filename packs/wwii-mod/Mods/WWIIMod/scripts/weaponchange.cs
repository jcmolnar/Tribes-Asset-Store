
//================================initialize array of weapons

$numtoweapon[0] = ySniperRifle;
$numtoweapon[1] = ySubmgun;
$numtoweapon[2] = xSTG;
$numtoweapon[3] = xar;
$numtoweapon[4] = xpanzergun;
$numtoweapon[5] = ybren;
$numtoweapon[6] = xmp40;
$numtoweapon[7] = ybazooka;
$numtoweapon[8] = yPPSH;
$numtoweapon[9] = MedicalKit;
$numtoweapon[10] = ybar;
$numtoweapon[11] = nade; 
$numtoweapon[12] = xrifle;
$numtoweapon[13] = ycarbine;
$numtoweapon[14] = ymosinnagant;
$numtoweapon[15] = ysten;
$numtoweapon[16] = ygarand;
$numtoweapon[17] = ypistol;
$numtoweapon[18] = ythompson;
$numtoweapon[19] = binoculars;
$numtoweapon[20] = exppack;
$numtoweapon[21] = xpistol;
$numtoweapon[22] = DeployMine;
$numtoweapon[23] = xgrifle;
$numtoweapon[24] = yDP;
$numtoweapon[25] = yM3;
$numtoweapon[26] = ylanchester;
$numtoweapon[27] = yPTRD;
$numtoweapon[28] = yPIAT;
$numtoweapon[29] = xRifleJ; //scout
$numtoweapon[30] = xType100; //assault2
$numtoweapon[31] = xtype96; //assault
$numtoweapon[32] = xRocket; //anti-tank
$numtoweapon[33] = xtype97; //anti-tank2
$numtoweapon[34] = xrifleJE; //engineer
$numtoweapon[35] = xnambu;
$numtoweapon[36] = DeployBox;
$numtoweapon[37] = xShotgun;
$numtoweapon[38] = ySniperRifle;

for(%x = 0; $numtoweapon[%x] != ""; %x++) 
	{
	%buffer = $numtoweapon[%x];
	$weapontonum[%buffer] = %x;
	}

function WWII::WeaponChange(%cl)
{
%pl = client::getownedobject(%cl);
if(!%pl || %pl.parachute || Player::isDead(%pl)) return;
%item = Player::GetMountedItem(%pl, $Weaponslot);
if(%item == detonator) %item = exppack;
if(%item < 0) for(%x = 0; $numtoweapon[%x] != ""; %x++)
	{
	if((Player::GetItemCount(%pl, $numtoweapon[%x]) > 0 && $numtoweapon[%x] != "nade") || ($numtoweapon[%x] == "nade" && Player::GetItemCount(%pl, nadeammo) > 0)) 
		{
		if(%curweapon == "exppack" && !Player::GetItemCount(%pl, exppackammo)) player::useitem(%pl, "detonator");
		else Player::MountItem(%pl, $numtoweapon[%x], $weaponslot);
		break;
		return;
		}
	}
	
for(%x = $weapontonum[%item] + 1; %x < 40; %x++)
	{
	%curweapon = $numtoweapon[%x];
	if((Player::GetItemCount(%pl, $numtoweapon[%x]) && $numtoweapon[%x] != "nade") || ($numtoweapon[%x] == "nade" && Player::GetItemCount(%pl, nadeammo))) 
		{
		if(%curweapon == "exppack" && !Player::GetItemCount(%pl, exppackammo)) player::useitem(%pl, "detonator");
		else { Player::unmountItem(%pl, $weaponslot); Player::UseItem(%pl, %curweapon); }
		break;
		}
	if($numtoweapon[%x + 1] == "") 
		{
		%x = 0;
		}
	
	%buf++;
	if(%buf > 160) {  break; }
	}
}
	







