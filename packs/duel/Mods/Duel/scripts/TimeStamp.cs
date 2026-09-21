// TIMESTAMPING

function zadmin::ZeroPad(%s)
{
	if (String::Len(%s)<2)
		%s = "0" @ %s;
	return %s;
}
function CutTheZero(%string)
{
	if(String::getSubStr(%string, 0, 1) == "0" && String::getSubStr(%string, 1, 1) != "0")
	{
		%string = String::getSubStr(%string, 1, 1);
	}
}
function zadmin::getTimeStamp()
{
	Time::Array();

	%cuttime = zadmin::ZeroPad($Time[hr]);

	%flag = "AM";

	if(%cuttime == "00")
	{
		%cuttime = "12";
	}
	if(%cuttime > 12)
	{
		%cuttime = %cuttime - 12 ;

		%flag = "PM";
		if(%cuttime == "12")
		{
			%flag = "AM";
		}
	}
	if(%cuttime < 10)
	{
		%cuttime = CutTheZero(%cuttime);
	}

	%logtime = %cuttime @ ":" @ zadmin::ZeroPad($Time[mn])@" "@%flag ;
	%logdate = CutTheZero(zadmin::ZeroPad($Time[dy])) @ "-" @ CutTheZero(zadmin::ZeroPad($Time[mo])) @ "-" @ String::getSubStr($Time[yr], 2, 1)@""@String::getSubStr($Time[yr], 3, 1) ;

	return %logdate @ " " @ %logtime;
}


function Time::Array()
{
	%str = timestamp();

	$Time[yr] = String::GetSubStr(%str, 00, 04);
	$Time[mo] = String::GetSubStr(%str, 05, 02);
	$Time[dy] = String::GetSubStr(%str, 08, 02);
	$Time[hr] = String::GetSubStr(%str, 11, 02);
	$Time[mn] = String::GetSubStr(%str, 14, 02);
	$Time[sc] = String::GetSubStr(%str, 17, 02);
	$Time[ms] = String::GetSubStr(%str, 20, 03);
}





// IP LOGGING
//
//

function String::len(%string)
{
    for(%length=0; String::getSubStr(%string, %length, 1) != ""; %length++)
    {} // it's all done above!
    return %length;
}


function IPLog::setupLogFile()
{
	// Eric's code :)
	%serverName = "";
	for (%i = 0; %i < String::Len($Server::HostName); %i++)
	{
		%char = String::getSubStr($Server::hostName, %i, 1);
		%result = String::iCompare(%char, "z");

		if((%result >= -42 && %result <= -33) || (%result >= -25 && %result <= 0))
			%serverName = %serverName @ %char;
		else
			%serverName = %serverName @ "_";
	}

	%serverName = $Server::HostName;

	return "config\\IPLog_" @ %serverName @ ".cs";
}

function IPLog::setw(%text, %width, %trim)
{
   %length = String::Len(%text);

   if( %trim && %length > %width ) // truncate if too long
   {
      %text = string::getSubStr( %text, 0, %width - 1 );
      %length = %width - 1;
   }

   for( %i = %length; %i < %width; %i++ )
      %text = %text @ " ";

   return %text;
}

function IPLog::createEntry(%client, %pwattempt)
{
   if( %client != "" && %client > 0 ) // prevent fuckupsssssss
   {
     // %date = zadmin::getTimeStamp();
      IPLog::logAddress(%client, %pwattempt);
   }
}
function ParseTimestamp()
{
	%str = timestamp();

	$TimeStamp::Year = String::GetSubStr(%str, 0, 4);
	$TimeStamp::Month = String::GetSubStr(%str, 5, 2);
	$TimeStamp::Day = String::GetSubStr(%str, 8, 2);

	$TimeStamp::Hour = String::GetSubStr(%str, 11, 2);
	$TimeStamp::Minute = String::GetSubStr(%str, 14, 2);
	$TimeStamp::Second = String::GetSubStr(%str, 17, 2);
	$TimeStamp::Millisecond = String::GetSubStr(%str, 20, 3);
}
function IPLog::logAddress(%client, %pwattempt)
{
	ParseTimestamp();
	%date = $TimeStamp::Month@"/"@$TimeStamp::Day@"/"@$TimeStamp::Year@"  "@$TimeStamp::Hour@":"@$TimeStamp::Minute@":"@$TimeStamp::Second ;
   %date    =  IPLog::setw( %date, 22, 0);
   %name    =  IPLog::setw( Client::getName(%client), 22, 1 ); // names are 16 character max, I believe.  truncate if they don't fit
   %ip      =  IPLog::setw( Client::getTransportAddress(%client), 30, 0 ); // IP:xxx.xxx.xxx.xxx:xxxxx. do NOT truncate IPs

   $IPLogEntry = %date  @ "     "@%name @ %ip @" "@%pwattempt;

	if(%pwattempt!="")
	{
		%dir = "config\\AdminAttempts.cs";
	}
	else {
		%dir = $IPLogFile;
	}

   export("$IPLogEntry", %dir, true); // append the entries

}


$IPLogFile = IPLog::setupLogFile();


