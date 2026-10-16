// This is just a simple way to explain stuff when you buy it..all the stufff i don't have bottom print for is here :) 

//Change this to false to disable help...but you will still get bottom print for guns :)
$GiveHelp = true;

// Strings to display
$helpstr[Larmor]="Light Armor, Weak Armor and a fast run speed, back in base this was the snipers choice, and it still is in most other mods. Light Armor + Teleport Pack = A ten second flag cap >:)";

$helpstr[Warmor] = "Speedy Armor, When speed is needed choose Speedy, Though it is pretty weak it runs faster then all the other armors, it also uses its jet energy differently...Jets for Mach 5 are Jump Boosts, Speedy Armor + D-Cell Pack = A jet Booster Upgrade";
$helpstr[Barmor] = "Mechanic Armor, Can hold 10 of each deployable and can hold a Builders Gun, It also is pretty hard to kill, Mechanic Armor + Builders Gun = The Ability To heal things 1000 meters away";
$helpstr[Marmor] = "Your normal average amount of armor...no more... no less, Medium Armor + Booster Pack = The speed of Light and the armor of Medium :)";
$helpstr[Garmor] = "DBZ Armor, All saiyan attacks have enough ammo to last you a while, and each of the attacks have a certain charge time. and Saiyan Armor + Shield Pack = Flaming Shield";
$helpstr[Harmor] = "Heavy Armor, Heavies always get the big guns and lots of ammo...but they are a little slow... Heavy Armor + Energizer Pack = Neverending Energy";

$helpstr[StrikeXAmmo] = "Alien Armor testing area words will go here";
$helpstr[TurretPack6] = "Test to see if this fixes the glitch";	
$helpstr[mineammo2] = "Enemy Displacer mines, once stepped on the 'Victim' is knocked back a few feet...might be good flag defense huh :)";
$helpstr[BF] = "The Big One, A very large, very powerful bomb. 25 second det. time";

$helpstr[BF2] = "Enemy Displacer Bomb, A Very Big, Very Strong bomb :) it does no damage but on explosion any one within 300 meters of it will be blasted a few hundred feet away, 20 second Det. Time";
$helpstr[Bf3] = "Plastique Bombs, These bombs can only hurt things within a 6 meter distance...but anything in that 6 meter distance is dead once it blows :) 10 Second Det. Time ";
$helpstr[Bf4] = "Self Destruct Mechanism, Do I really have to explain this....kills you and anything within 100 meters of you...Instant Det. Time";

$helpstr[Bf5] = "The Death Tree...Just your normal everyday explosive tree....nothing strange about that right....20 second Det. Time";
$helpstr[MineAmmo4] = "Inviso-Mines, Just regulare invisble mines :)...but don't worry cause you can still see that little light blinking inside.";
$helpstr[MineAmmo3] = "Proxy Decoys, Now here is a useful mine....set these guys out in front of your base for a strong protection...or set them in an enemy base to run-a-muck,If you touch them they will explode";



function giveHelp(%client,%item)
{ 
	if(!$GiveHelp)
		return;	
	bottomprint(%client, $helpstr[%item], 10);
}