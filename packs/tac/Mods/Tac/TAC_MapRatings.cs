//----------------------------------------------------------------------------------
//-----------------------      TAC Map Ratings      ----------------------------
//----------------------------------------------------------------------------------
//
//	Put a value of "false" here to ignore this feature of TAC.
//	Put a value of "true" here to use this feature
$TAC::MRenabled = "true";


//----------------------------------------------------------------------------------
// 	$MR::ratioString allows you to choose what map rating will be played when
//	eg.
//		$MR::ratioString="1 1 2 4";
//		This will play two verypopular maps, then one popular map, then one
//		unpopular map.  It will then start again.
//
//	the default setup is:
//  	verypopular=	4 or 40%
//  	popular=		3 or 30%
//  	average=		2 or 20%
//  	unpopular=		1 or 10%
//
//	change them to whatever you please
//
$TAC::MRratioString="1 2 1 3 2 4 1 2 3 1";


//----------------------------------------------------------------------------------
//	To change the rating of a map, just change the field after the maps name.
//	To enter a new map, simply copy insert a new call to MR::setRating ("newMap", "rating");
//	Possible ratings are:
//			verypopular
//			popular
//			average
//			unpopular
//			neverplay
//
//	Any map that isn't given a rating is automatically assigned "average"
//
//	This mapratings file was produced from a survey.

TAC::MRsetRating ("Air_Coaster_CTF",			"verypopular");
TAC::MRsetRating ("BigSkies_CTF",				"verypopular");
TAC::MRsetRating ("Gorillas_in_the_mist_CTF",	"verypopular");
TAC::MRsetRating ("Ice_Fusion_CTF",				"verypopular");
TAC::MRsetRating ("SkiJump_CTF",				"verypopular");

TAC::MRsetRating ("Close_C&H", 					"popular");
TAC::MRsetRating ("Flight_to_Death_CTF",		"popular");
TAC::MRsetRating ("HALO_CTF", 					"popular");
TAC::MRsetRating ("HawkEye_CTF", 				"popular");
TAC::MRsetRating ("Oupost_D&D", 				"popular");
TAC::MRsetRating ("ParsonsSkys_CTF", 			"popular");
TAC::MRsetRating ("Plateaus_CTF", 				"popular");
TAC::MRsetRating ("PotHole_CTF", 				"popular");
TAC::MRsetRating ("PowerPlay_CTF", 				"popular");
TAC::MRsetRating ("Sarkanus-3_C&H", 			"popular");
TAC::MRsetRating ("Sunny_Days_CTF", 			"popular");
TAC::MRsetRating ("TheNoFlyZone_CTF", 			"popular");
TAC::MRsetRating ("Winter_C&H", 				"popular");
TAC::MRsetRating ("GraveYard_C&H", 				"popular");
TAC::MRsetRating ("Chute_to_Thrill_CTF", 		"popular");

TAC::MRsetRating ("A_HighRise_Hell_D&D", 		"average");
TAC::MRsetRating ("Altitude_F&R", 				"average");
TAC::MRsetRating ("BadLands_C&H", 				"average");
TAC::MRsetRating ("Dead_Landing_CTF", 			"average");
TAC::MRsetRating ("FogHorn_F&R", 				"average");
TAC::MRsetRating ("JustHoldIt_C&H", 			"average");
TAC::MRsetRating ("NightFlyers_CTF", 			"average");
TAC::MRsetRating ("PeltastDelight_F&R", 		"average");
TAC::MRsetRating ("RuleTheSkies_TDM", 			"average");
TAC::MRsetRating ("Smear-the-Queer_CTF", 		"average");
TAC::MRsetRating ("Planted_C&H", 				"average");
TAC::MRsetRating ("House of Terror_CTF", 		"average");
TAC::MRsetRating ("Gravitron_CTF", 				"average");
TAC::MRsetRating ("F.U.B.A.R._D&D", 			"average");
TAC::MRsetRating ("VertRamp_CTF", 				"average");

TAC::MRsetRating ("Spire_C&H", 					"unpopular");
TAC::MRsetRating ("A_Dark_Night_TDM", 			"unpopular");
TAC::MRsetRating ("Hairball_TDM", 				"unpopular");
TAC::MRsetRating ("DeathValley_CTF", 			"unpopular");
TAC::MRsetRating ("Meat_Grinder_F&R", 			"unpopular");
TAC::MRsetRating ("Skod_CTF", 					"unpopular");
TAC::MRsetRating ("Absoraka_F&R", 				"unpopular");
