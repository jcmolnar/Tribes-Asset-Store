

function Nappy::Logs::SetFile()
{
	if($Nappy::MakeNewLogFileEachDay[1])
		$messageLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_MessageLog.cs";
	else
		$messageLogFile = "Temp\\Nappy_MessageLog.cs";

	if($Nappy::MakeNewLogFileEachDay[2])
		$badMessageLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_BadMessageLog.cs";
	else
		$badMessageLogFile = "Temp\\Nappy_BadMessageLog.cs";

	if($Nappy::MakeNewLogFileEachDay[3])
		$ipLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_IP_Logs.cs";
	else
		$ipLogFile = "Temp\\Nappy_IP_Logs.cs";

	if($Nappy::MakeNewLogFileEachDay[4])
		$adminLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_AdminLog.cs";
	else
		$adminLogFile = "Temp\\Nappy_AdminLog.cs";

	if($Nappy::MakeNewLogFileEachDay[5])
		$autoKickLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_AutoKickLog.cs";
	else
		$autoKickLogFile = "Temp\\Nappy_AutoKickLog.cs";

	if($Nappy::MakeNewLogFileEachDay[6])
		$duelOptionsLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_DuelOptionsLog.cs";
	else
		$duelOptionsLogFile = "Temp\\Nappy_DuelOptionsLog.cs";

	if($Nappy::MakeNewLogFileEachDay[7])
		$remoteLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_RemoteLog.cs";
	else
		$remoteLogFile = "Temp\\Nappy_remoteLog.cs";

	if($Nappy::MakeNewLogFileEachDay[8])
		$remoteIgnoreLogFile = "Temp\\" @ $Nappy::LogFile::DateStamp @ "_Nappy_RemoteIgnoreLog.cs";
	else
		$remoteIgnoreLogFile = "Temp\\Nappy_RemoteIgnoreLog.cs";
}



function Nappy::Log(%type, %message)
{
	if($Nappy::Time)
		if($Nappy::LogTime::FullNames)
			$Nappy::DateAndTime::LogStamp = Nappy::Date::FullName("day", $Nappy::DateAndTime::day) @ " " @ Nappy::Date::FullName("month", $Nappy::DateAndTime::month) @ " " @ $Nappy::DateAndTime::date @ "," @ $Nappy::DateAndTime::year @ $Nappy::Time::Stamp;
		else
			$Nappy::DateAndTime::LogStamp = $Nappy::DateAndTime::FullStamp;
	else
		$Nappy::DateAndTime::LogStamp = "";

	%message = $Nappy::DateAndTime::LogStamp @ %message;

	if(%type == "IP" && $Nappy::LogIP){
		$IPL = %message;
		export("$IPL", $ipLogFile, true); 
	}
	else if(%type == "BadMessage" && $Nappy::LogBadMessages){
		$BML = %message;
		export("$BML", $badMessageLogFile, true); 
	}
	else if(%type == "Message" && $Nappy::LogMessages){
		$ML = %message;
		export("$ML", $messageLogFile, true); 
	}
	else if(%type == "Admin" && $Nappy::LogAdmin){
		$AL = %message;
		export("$AL", $adminLogFile, true); 
	}
	else if(%type == "AutoKick" && $Nappy::LogAutoKick){
		$AKL = %message;
		export("$AKL", $autoKickLogFile, true); 
	}
	else if(%type == "DuelOption" && $Nappy::LogDuelOptions){
		$DCL = %message;
		export("$DCL", $duelOptionsLogFile, true); 
	}
	else if(%type == "Remote" && $Nappy::LogRemote){
		$RL = %message;
		export("$RL", $remoteLogFile, true); 
	}
	else if(%type == "RemoteIgnore" && $Nappy::LogRemoteIgnore){
		$RIL = %message;
		export("$RIL", $remoteIgnoreLogFile, true); 
	}
		
}




function Nappy::Logs::DeleteOldLogs(%logDate)
{
	if(isFile("Temp\\" @ %logDate @ "_Nappy_IP_Logs.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_IP_Logs.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_BadMessageLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_BadMessageLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_MessageLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_MessageLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_AdminLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_AdminLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_AutoKickLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_AutoKickLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_DuelOptionsLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_DuelOptionsLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_RemoteLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_RemoteLog.cs");

	if(isFile("Temp\\" @ %logDate @ "_Nappy_RemoteIgnoreLog.cs"))
			File::delete("Temp\\" @ %logDate @ "_Nappy_RemoteIgnoreLog.cs");
}

		



function Nappy::Logs::Separator(%type, %return)
{
	if(%return){
		%return--;
		if(%return == 7)
			%logFile = $remoteLogFile;
		else if(%return == 6)
			%logFile = $duelOptionsLogFile;
		else if(%return == 5)
			%logFile = $autoKickLogFile;
		else if(%return == 4)
			%logFile = $adminLogFile;
		else if(%return == 3)
			%logFile = $ipLogFile;
		else if(%return == 2)
			%logFile = $badMessageLogFile;
		else if(%return == 1)
			%logFile = $messageLogFile;
	}
	else{
		%logFile = $remoteIgnoreLogFile;
		%return = 8;
	}

	%logging[1] = $Nappy::LogMessages;
	%logging[2] = $Nappy::LogBadMessages;
	%logging[3] = $Nappy::LogIP;
	%logging[4] = $Nappy::LogAdmin;
	%logging[5] = $Nappy::LogAutoKick;
	%logging[6] = $Nappy::LogDuelOptions;
	%logging[7] = $Nappy::LogRemote;
	%logging[8] = $Nappy::LogRemoteIgnore;

	if(%logging[%return]){
		if(%type == "hour" && $Nappy::LogSeparator::hour[%return]){
			$HourChange = "_______________________________________________________________________";
			export("$HourChange", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$Hour = "                                 " @ $Nappy::Time::Stamp;
			export("$Hour", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$HourChange = " ";
			export("$HourChange", %logFile, true); 
			$HourChange = "_______________________________________________________________________";
			export("$HourChange", %logFile, true); 
		}
		else if(%type == "day" && $makingFileSet){
			$NewLog = "New Log File";
			export("$NewLog", %logFile, true); 
		}
		else if(%type == "day" && !$makingFileSet && $Nappy::LogSeparator::day[%return]){
			$DayChange = "==========================================================================";
			export("$DayChange", %logFile, true); 
			$DayChange = "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>";
			export("$DayChange", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$Hour = "                                 " @ $Nappy::DateAndTime::FullStamp;
			export("$Hour", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$DayChange = " ";
			export("$DayChange", %logFile, true); 
			$DayChange = "<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>";
			export("$DayChange", %logFile, true); 
			$DayChange = "==========================================================================";
			export("$DayChange", %logFile, true); 
		}
		else if(%type == "ServerRestart" && $Nappy::LogSeparator::restart[%return]){
			$ServerRestart = "V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^";
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = "[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[";
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = " ";
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = "                          SERVER STARTED AT " @ $Nappy::DateAndTime::FullStamp;
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = " ";
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = "]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]";
			export("$ServerRestart", %logFile, true); 
			$ServerRestart = "V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^V^";
			export("$ServerRestart", %logFile, true); 
			}
		else if(%type == "MapChange" && $Nappy::LogSeparator::MapChange[%return]){
			$MapChange = "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
			export("$MapChange", %logFile, true); 
			$MapChange = "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
			export("$MapChange", %logFile, true); 
			$MapChange = "                  MAP CHANGED TO " @ $missionName @ " AT " @ $Nappy::DateAndTime::FullStamp;
			export("$MapChange", %logFile, true); 
			$MapChange = "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
			export("$MapChange", %logFile, true); 
			$MapChange = "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||";
			export("$MapChange", %logFile, true); 
	
		}
	}
	if(%return != 1)
		schedule("Nappy::Logs::Separator(" @ %type @ ", " @ %return @ ");",0.1);
}



