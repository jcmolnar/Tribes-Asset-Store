//The banlist only gives you the ability to ban clients based on their
//IP address.  This list gives you the ability to ban a client based on
//their name.  You have the ability to do an "exact match", or a none case
//sensitive "substring match".

//Example of a strict match:
//   BanByName::add("MoRoN",0);
//This will auto-ban anyone with the "exact" name    MoRoN
//This is case sensitive, so it would NOT ban these names, (moron,Moron,MORON)

//Example of a substring match:
//   BanByName::add("XSZ",1);
//This will ban any name that contains XSZ.  This is useful for banning names
//that "contain" foul language, should you wish to prevent that.  If you used
//BanByName("ice",1); that would ban the words (nice,price,Iceman....etc).  Be
//careful with this, as it can backfire on you.

//To enable this feature, set your $BanByName::IsOn = 1; switch in your renegades.cs

//Here is a good loadout for people wishing to prevent foul names from 
//connecting to the server.

BanByName::add("fuck",1);
BanByName::add("dick",1);
BanByName::add("cunt",1);
BanByName::add("nigger",1);
BanByName::add("bitch",1);
BanByName::add("shit",1);
BanByName::add("pussy",1);
BanByName::add(".2",1);