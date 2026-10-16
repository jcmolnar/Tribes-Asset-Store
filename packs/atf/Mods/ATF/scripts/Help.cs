// This is just a simple way to explain stuff when you buy it..all the stufff i don't have bottom print for is here :) 

//Change this to false to disable help...but you will still get bottom print for guns :)


// Strings to display

$helpstr[TurretPack6] = "Beam Turret, fly up and place these... they shoot in Line of Sight when enemies get near them so use them as laser doors or a nice laser flag guard :)";	
$helpstr[mineammo2] = "Enemy Displacer mines, once stepped on the 'Victim' is knocked back a few feet...might be good flag defense huh :)";
$helpstr[BF] = "The Big One, A very large, very powerful bomb. 25 second det. time )";
$helpstr[BF2] = "Enemy Displacer Bomb, A Very Big, Very Strong bomb :) it does no damage but on explosion any one within 300 meters of it will be blasted a few hundred feet away, 20 second Det. Time)";
$helpstr[Bf3] = "Plastique Bombs, These bombs can only hurt things within a 6 meter distance...but anything in that 6 meter distance is dead once it blows :) 10 Second Det. Time )";
$helpstr[Bf4] = "Self Destruct Mechanism, Do I really have to explain this....kills you and anything within 100 meters of you...Instant Det. Time)";
$helpstr[Bf5] = "The Death Tree...Just your normal everyday explosive tree....nothing strange about that right....20 second Det. Time)";
$helpstr[MineAmmo4] = "Inviso-Mines, Just regulare invisble mines :)...but don't worry cause you can still see that little light blinking inside.)";
$helpstr[MineAmmo3] = "Proxy Decoys, Now here is a useful mine....set these guys out in front of your base for a strong protection...or set them in an enemy base to run-a-muck,If you touch them they will explode)";



function giveHelp(%client,%item)
{ 	
	bottomprint(%client, $helpstr[%item], 10);
}