# Damage Types
#
//other damage tyes
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$healing               = 1;
$TreeDamageType 	= 2;

$Electricity              = 4;
$Cactus 		 = 5;
$TankCrush		 = 6;


//Bullet damage
$mp40              = 15;
$bren              = 16;
$k98              = 17;
$MP18              = 18;
$Fallschirmj              = 19;
$STG              = 20;
$springfield             = 21;
$ppsh              = 22;
$bar              = 23;
$thompson              = 24;
$m1carbine              = 25;
$mosinnagant              = 26;
$garand             = 27;
$sten            = 28;
$P38           = 29;
$M1911            = 30;
$MG42        = 31;
$Browning        = 32;
$AlliedFighterGun = 33;
$AxisFighterGun = 34;
$DP           = 35;
$M3           = 36;
$Lanchester           = 37;
$type99              = 38;
$type100             = 39;
$Type98            = 40;
$type38               = 41;
$nambu             = 42;
$type96               = 43;
$grenadex            =  44;
$AlliedBomberGun     = 45;
$AxisBomberGun               = 46;
$Shotgun              = 47;


//EXPLOSIVE DAMAGE
$bazooka              = 70;
$panzershreck              = 71;
$grenade              = 72;
$AIMine           = 73;
$AlliedFighterBomb = 74;
$AxisFighterBomb = 75;
$Howitzer    = 76;
$Pak            = 77;
$Airstrike       = 78;
$exppack        = 79;
$PTRD        = 80;
$Bofors            = 81;
$Flak            = 82;
$PIAT            = 83;
$Boforsx            = 84;
$Flakx            = 85;
$Type4              = 86;
$Type97        = 87;
$ShermanTank =        88;
$AlliedBomberBomb = 89;
$AxisBomberBomb = 90;
$explosion = 		91;
$PanzerTank 		= 92;
function getdamagetype(%type) { if(%type > 69) return exp; else if(%type > 14) return bullet; return other; }