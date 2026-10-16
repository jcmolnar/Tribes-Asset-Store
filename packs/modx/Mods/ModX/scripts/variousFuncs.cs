// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
function String::MakeCaps(%string)
{
   %norm = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
   %capp = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";
   for(%i = 0; %i < 52; %i++)
   {
      %rem = String::getSubStr(%norm, %i, 1);
      %new = String::getSubStr(%capp, %i, 1);
      %string = String::Replace(%string, %rem, %new);
   }
   return %string;
}

function String::Len(%string)
{
	while(String::getSubStr(%string,%len,1) != "")
		%len++;
	return %len;
}

function String::Replace(%string, %search, %replace)
{
	%len = String::Len(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s")
			%string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}

function String::Replace2(%string, %search, %replace)
{
	%len = String::Len(%search);
    %tmpstring = "";
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
         if (%char @ "s" == %search @ "s")
			%tmpstring = %replace @ %tmpstring;
         else
            %tmpstring = %char @ %tmpstring;
	}
	return %tmpstring;
}

function String::Contains(%string, %search)
{
	%len = String::Len(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s")
			return true;
	}
	return false;
}

function String::Left(%string, %start)
{
	%len = 1;
    %stringFinal = "";
	for (%i = 0 + %start; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
        %stringTemp = %stringFinal;
        %stringFinal = %stringTemp @ %char;
    }
    
    if(%stringFinal != "")
	    return %stringFinal;
    return -1;
}

function String::Right(%string, %start)
{
	%len = 1;
    %stringFinal = "";
	for (%i = 0 + %start; (%char = String::getSubStr(%string, %i, %len)) != ""; %i--)
	{
        %stringTemp = %stringFinal;
        %stringFinal = %char @ %stringTemp;
    }

    if(%stringFinal != "")
	    return %stringFinal;
    return -1;
}

$OmitList[0] = "a";
$OmitList[1] = "b";
$OmitList[2] = "c";
$OmitList[3] = "d";
$OmitList[4] = "e";
$OmitList[5] = "f";
$OmitList[6] = "g";
$OmitList[7] = "h";
$OmitList[8] = "i";
$OmitList[9] = "j";
$OmitList[10] = "k";
$OmitList[11] = "l";
$OmitList[12] = "m";
$OmitList[13] = "n";
$OmitList[14] = "o";
$OmitList[15] = "p";
$OmitList[16] = "q";
$OmitList[17] = "r";
$OmitList[18] = "s";
$OmitList[19] = "t";
$OmitList[20] = "u";
$OmitList[21] = "v";
$OmitList[22] = "w";
$OmitList[23] = "x";
$OmitList[24] = "y";
$OmitList[25] = "z";

$OmitList[26] = "A";
$OmitList[27] = "B";
$OmitList[28] = "C";
$OmitList[29] = "D";
$OmitList[30] = "E";
$OmitList[31] = "F";
$OmitList[32] = "G";
$OmitList[33] = "H";
$OmitList[34] = "I";
$OmitList[35] = "J";
$OmitList[36] = "K";
$OmitList[37] = "L";
$OmitList[38] = "M";
$OmitList[39] = "N";
$OmitList[40] = "O";
$OmitList[41] = "P";
$OmitList[42] = "Q";
$OmitList[43] = "R";
$OmitList[44] = "S";
$OmitList[45] = "T";
$OmitList[46] = "U";
$OmitList[47] = "V";
$OmitList[48] = "W";
$OmitList[49] = "X";
$OmitList[50] = "Y";
$OmitList[51] = "Z";

$OmitList[52] = "~";
$OmitList[53] = "`";
$OmitList[54] = "!";
$OmitList[55] = "@";
$OmitList[56] = "#";
$OmitList[57] = "$";
$OmitList[58] = "%";
$OmitList[59] = "^";
$OmitList[60] = "&";
$OmitList[61] = "*";
$OmitList[62] = "(";
$OmitList[63] = ")";
$OmitList[64] = " "; // -
$OmitList[65] = "_";
$OmitList[66] = "=";
$OmitList[67] = "+";
$OmitList[68] = "[";
$OmitList[69] = "{";
$OmitList[70] = "]";
$OmitList[71] = "}";
$OmitList[72] = "\\";
$OmitList[73] = "|";
$OmitList[74] = "/";
$OmitList[75] = "?";
$OmitList[76] = " "; // .
$OmitList[77] = ">";
$OmitList[78] = ",";
$OmitList[79] = "<";
$OmitList[80] = " ";

function String::omitParse(%string)
{
    %replace = "";
    %len = 1;
    for (%j = 0; (%search = $OmitList[%j]) != "" && %j < 100; %j++)
	{
    	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != "" && %i < 300; %i++)
    	{
    		if (%search @ "s" == %char @ "s")
    			%string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
        }
    }
    return %string;
}

function ModX::IPCut(%address)
{
	// Simplify transports -plasmatic
	if(String::getSubStr(%address,0,8) == "LOOPBACK")
		return "LOOPBACK";

	%ipCut = String::getSubStr(%address,3,20);
	while(String::getSubStr(%ipCut,%len,1) != ":" && %len < 20)
		%len++;
	%sub = String::getSubStr(%ipCut,0,%len);
	return %sub;
}

$ChatBlackList[0] = "\x00";
$ChatBlackList[1] = "\x01";
$ChatBlackList[2] = "\x02";
$ChatBlackList[3] = "\x03";
$ChatBlackList[4] = "\x04";
$ChatBlackList[5] = "\x05";
$ChatBlackList[6] = "\x06";
$ChatBlackList[7] = "\x07";
$ChatBlackList[8] = "\x08";
$ChatBlackList[9] = "\x09";
$ChatBlackList[10] = "\x10";
$ChatBlackList[11] = "\x11";
$ChatBlackList[12] = "\x12";
$ChatBlackList[13] = "\x13";
$ChatBlackList[14] = "\x14";
$ChatBlackList[15] = "\x15";
$ChatBlackList[16] = "\x16";
$ChatBlackList[17] = "\x17";
$ChatBlackList[18] = "\x18";
//Ususal Chat Chars are in this range, omitted.
$ChatBlackList[19] = "\x80";
$ChatBlackList[20] = "\x81";
$ChatBlackList[21] = "\x82";
$ChatBlackList[22] = "\x83";
$ChatBlackList[23] = "\x84";
$ChatBlackList[24] = "\x85";
$ChatBlackList[25] = "\x86";
$ChatBlackList[26] = "\x87";
$ChatBlackList[27] = "\x88";
$ChatBlackList[28] = "\x89";
$ChatBlackList[29] = "\x90";
$ChatBlackList[30] = "\x91";
$ChatBlackList[31] = "\x92";
$ChatBlackList[32] = "\x93";
$ChatBlackList[33] = "\x94";
$ChatBlackList[34] = "\x95";
$ChatBlackList[35] = "\x96";
$ChatBlackList[36] = "\x97";
$ChatBlackList[37] = "\x98";
$ChatBlackList[38] = "\x99";
$ChatBlackList[39] = "\t";
$ChatBlackList[40] = "\n";
$ChatBlackList[41] = "END";

function String::ChatBlackList(%string)
{
    %replace = "";
    %len = 0;
        
    for (%j = 0; (%search = $ChatBlackList[%j]) != "END"; %j++)
	{
        %len = String::Len(%search);
        for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != "" && %i < 300; %i++)
    	{
            if (%search @ "s" == %char @ "s")
    			return "I'm such a dumb n00b for trying to crash the server, sorry! I'm going to go back in my corner now..."; //%string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
        }
    }
    return %string;
}

function BoolToNum(%bool) //Zero = False
{
    if(%bool == true)
        return 1;
    return 0;
}

function NumToBool(%num) //Non-Zero = True
{
    if(%num != 0)
        return true;
    return false;
}

function BoolToStr(%bool)
{
    if(%bool == true)
        return "TRUE";
    return "FALSE";
}

function StrToBool(%str)
{
    if(String::MakeCaps(%str) == "TRUE")
        return true;
    return false;
}

function kickback(%object, %kickback) // Kickback
{
	%rot = GameBase::getRotation(%object);
	%kick = Vector::getFromRot(%rot,"-"@%kickback,0);
	Player::applyImpulse(%object,%kick);
}

function station::kickback(%station, %object, %kickback, %kickback2)
{
	%rot = GameBase::getRotation(%station);
	%kick = Vector::getFromRot(%rot,"-"@%kickback,%kickback2);
	Player::applyImpulse(%object,%kick);
}

function Time::getServerUptime()
{
	%time = getintegertime(true)>>5;
	%minutes = floor(%time / 60);
	%seconds = %Time % 60;
	while(%minutes > 60)
	{
		%minutes = %minutes - 60;
		%hours++;
		if(%hours > 2400)
			break;
	}
	while(%hours > 24)
	{
		%hours = %hours - 24;
		%days++;
		if(%days > 100)
			break;
	}
    if (%days == "")
        %days = 0;
    if (%hours == "")
        %hours = 0;
	return %days@" "@%hours@" "@%minutes@" "@%seconds;
}

function Time::getDays(%simTime)
{
    %minutes = floor(%simTime / 60);
	while(%minutes > 60)
	{
		%minutes = %minutes - 60;
		%hours++;
		if(%hours > 2400)
			break;
	}
	while(%hours > 24)
	{
		%hours = %hours - 24;
		%days++;
		if(%days > 100)
			break;
	}
    return %days;
}

function Time::getHours(%simTime)
{
    %minutes = floor(%simTime / 60);
	while(%minutes > 60)
	{
		%minutes = %minutes - 60;
		%hours++;
		if(%hours > 2400)
			break;
	}
    return %hours;
}

function Time::getMinutes(%simTime)
{
	return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
	return %simTime % 60;
}

function GameBase::getMass(%obj)
{
    %mass = (GameBase::getDataName(%obj).Mass);
    if (getObjectType(%obj) == "Flyer")
        %mass += %obj.PassengerMass;
    return %mass;
}
