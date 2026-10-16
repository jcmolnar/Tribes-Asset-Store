

$Nappy::NextWeekday[Sun] = Mon;
$Nappy::NextWeekday[Mon] = Tues;
$Nappy::NextWeekday[Tues] = Wed;
$Nappy::NextWeekday[Wed] = Thur;
$Nappy::NextWeekday[Thur] = Fri;
$Nappy::NextWeekday[Fri] = Sat;
$Nappy::NextWeekday[Sat] = Sun;

$Nappy::NextMonth[Dec] = Jan;
$Nappy::NextMonth[Jan] = Feb;
$Nappy::NextMonth[Feb] = Mar;
$Nappy::NextMonth[Mar] = Apr;
$Nappy::NextMonth[Apr] = May;
$Nappy::NextMonth[May] = Jun;
$Nappy::NextMonth[Jun] = Jul;
$Nappy::NextMonth[Jul] = Aug;
$Nappy::NextMonth[Aug] = Sep;
$Nappy::NextMonth[Sep] = Oct;
$Nappy::NextMonth[Oct] = Nov;
$Nappy::NextMonth[Nov] = Dec;

$Nappy::PrevMonth[Dec] = Nov;
$Nappy::PrevMonth[Jan] = Dec;
$Nappy::PrevMonth[Feb] = Jan;
$Nappy::PrevMonth[Mar] = Feb;
$Nappy::PrevMonth[Apr] = Mar;
$Nappy::PrevMonth[May] = Apr;
$Nappy::PrevMonth[Jun] = May;
$Nappy::PrevMonth[Jul] = Jun;
$Nappy::PrevMonth[Aug] = Jul;
$Nappy::PrevMonth[Sep] = Aug;
$Nappy::PrevMonth[Oct] = Sep;
$Nappy::PrevMonth[Nov] = Oct;



function Nappy::Date::FullName(%type, %info)
{
	if(%type == "day"){
		%FullName[day, Sun] = Sunday;
		%FullName[day, Mon] = Monday;
		%FullName[day, Tues] = Tuesday;
		%FullName[day, Wed] = Wednesday;
		%FullName[day, Thur] = Thursday;
		%FullName[day, Fri] = Friday;
		%FullName[day, Sat] = Saturday;
	}
	if(%type == "month"){
		%FullName[month, Dec] = December;
		%FullName[month, Jan] = January;
		%FullName[month, Feb] = February;
		%FullName[month, Mar] = March;
		%FullName[month, Apr] = April;
		%FullName[month, May] = May;
		%FullName[month, Jun] = June;
		%FullName[month, Jul] = July;
		%FullName[month, Aug] = August;
		%FullName[month, Sep] = September;
		%FullName[month, Oct] = October;
		%FullName[month, Nov] = November;
	}
	return %FullName[%type, %info];
}


function Nappy::TimeStart()
{
	$Nappy::Time::On = 1;
	$Nappy::DateAndTime::year = GetWord($Nappy::DateAndTime,0);
	$Nappy::DateAndTime::month = GetWord($Nappy::DateAndTime,1);
	$Nappy::DateAndTime::date = GetWord($Nappy::DateAndTime,2);
	$Nappy::DateAndTime::day = GetWord($Nappy::DateAndTime,3);
	$Nappy::DateAndTime::hour = GetWord($Nappy::DateAndTime,4);
	$Nappy::DateAndTime::min = GetWord($Nappy::DateAndTime,5);
	$Nappy::DateAndTime::sec = GetWord($Nappy::DateAndTime,6);

	schedule("Nappy::TimeCount::Seconds();",1);
	Nappy::DateAndTime::Stamp();
}




function Nappy::DateAndTime::Stamp()
{
	%extension = "AM";
	if($Nappy::DateAndTime::hour > 12){
		%hourDisplay = $Nappy::DateAndTime::hour - 12;
		if($Nappy::DateAndTime::hour != 24)
			%extension = "PM";
	}
	else{
		%hourDisplay = $Nappy::DateAndTime::hour;
		if($Nappy::DateAndTime::hour == 12)
			%extension = "PM";
	}

	%displayMin = $Nappy::DateAndTime::min;
	%minDisplay1 = 0;
	for(%i = 0; %displayMin >= 10; %i++){
		%displayMin = %displayMin - 10;
		%minDisplay1++;
	}
	%minDisplay2 = 0;
	for(%i = 0; %displayMin >= 1; %i++){
		%displayMin--;
		%minDisplay2++;
	}
	
	%displaySec = $Nappy::DateAndTime::sec;
	%secDisplay1 = 0;
	for(%i = 0; %displaySec >= 10; %i++){
		%displaySec = %displaySec - 10;
		%secDisplay1++;
	}
	%secDisplay2 = 0;
	for(%i = 0; %displaySec >= 1; %i++){
		%displaySec--;
		%secDisplay2++;
	}
	
	$Nappy::LogFile::DateStamp = $Nappy::DateAndTime::year @ "_" @ $Nappy::DateAndTime::month @ "_" @ $Nappy::DateAndTime::date;
	$Nappy::Time::Stamp = "(" @ %hourDisplay @ ":" @ %minDisplay1 @ %minDisplay2 @ "::" @ %secDisplay1 @ %secDisplay2 @ %extension @ ")";
	$Nappy::DateAndTime::FullStamp = $Nappy::DateAndTime::day @ " " @ $Nappy::DateAndTime::month @ " " @ $Nappy::DateAndTime::date @ "," @ $Nappy::DateAndTime::year @ " (" @ %hourDisplay @ ":" @ %minDisplay1 @ %minDisplay2 @ "::" @ %secDisplay1 @ %secDisplay2 @ %extension @ ")";
}




function Nappy::Time::Set(%clientId, %message)
{
	if(%clientId.isSuperAdmin){
		%type = GetWord(%message,1);
		if(%type == "full"){
			%info1 = GetWord(%message,2);
			%info2 = GetWord(%message,3);
			%info3 = GetWord(%message,4);
			%info4 = GetWord(%message,5);
			%info5 = GetWord(%message,6);
			%info6 = GetWord(%message,7);
			%info7 = GetWord(%message,8);
			Nappy::DateAndTime::SetTime(%type, %info1, %info2, %info3, %info4, %info5, %info6, %info7);
		
		}
		else{
			%info = GetWord(%message,2);
			Nappy::DateAndTime::SetTime(%type, %info);
		}
	}
}



function Nappy::DateAndTime::SetTime(%type, %info1, %info2, %info3, %info4, %info5, %info6, %info7)
{
	// PORT: #setTime words are chat text; they become log file names and parts of schedule() strings
	if(%type == "full"){
		if($Nappy::NextMonth[%info2] == "" || $Nappy::NextWeekday[%info4] == "")
			return;
		%info1 = floor(%info1); %info3 = floor(%info3); %info5 = floor(%info5); %info6 = floor(%info6); %info7 = floor(%info7);
	}
	else if(%type == "month"){
		if($Nappy::NextMonth[%info1] == "")
			return;
	}
	else if(%type == "day"){
		if($Nappy::NextWeekday[%info1] == "")
			return;
	}
	else
		%info1 = floor(%info1);
	if(%type == "sec")
		$Nappy::DateAndTime::sec = %info1;
	else if(%type == "min")
		$Nappy::DateAndTime::min = %info1;
	else if(%type == "hour")
		$Nappy::DateAndTime::hour = %info1;
	else if(%type == "date")
		$Nappy::DateAndTime::date = %info1;
	else if(%type == "day")
		$Nappy::DateAndTime::day = %info1;
	else if(%type == "month")
		$Nappy::DateAndTime::month = %info1;
	else if(%type == "year")
		$Nappy::DateAndTime::year = %info1;
	else if(%type == "full"){
		
		$Nappy::DateAndTime::sec = %info7;
		$Nappy::DateAndTime::min = %info6;
		$Nappy::DateAndTime::hour = %info5;
		$Nappy::DateAndTime::day = %info4;
		$Nappy::DateAndTime::date = %info3;
		$Nappy::DateAndTime::month = %info2;
		$Nappy::DateAndTime::year = %info1;
		
	}
}


function Nappy::ShowTime()
{
	echo("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
	echo("                         " @ $Nappy::DateAndTime::FullStamp);
	echo("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
}


function Nappy::TimeCount::Seconds()
{
	$Nappy::DateAndTime::sec++;
	if($Nappy::DateAndTime::sec == 60){
		$Nappy::DateAndTime::sec = 0;
		if($Nappy::DateAndTime::month == "Apr" && $Nappy::DateAndTime::day == "Sun" && $Nappy::DateAndTime::date < 8 && ($Nappy::DateAndTime::hour == 1 && $Nappy::DateAndTime::min == 59) && $Nappy::DateAndTime::Adjust != "spring"){
			$Nappy::DateAndTime::Adjust = "spring";
			$Nappy::DateAndTime::hour = 3;
			$Nappy::DateAndTime::min = 0;
		}
		else if($Nappy::DateAndTime::month == "Oct" && $Nappy::DateAndTime::day == "Sun" && $Nappy::DateAndTime::date > 24 && ($Nappy::DateAndTime::hour == 1 && $Nappy::DateAndTime::min == 59) && $Nappy::DateAndTime::Adjust != "fall"){
			$Nappy::DateAndTime::Adjust = "fall";
			$Nappy::DateAndTime::hour = 1;
			$Nappy::DateAndTime::min = 0;
		}
		else
			Nappy::TimeCount();
		Nappy::update::DateAndTimeFile();
	}
	Nappy::DateAndTime::Stamp();
	schedule("Nappy::TimeCount::Seconds();",1);
}



function Nappy::TimeCount()
{
	%timeSeparate = "";
	$Nappy::DateAndTime::min++;
	if($Nappy::DateAndTime::min == 60){
		$Nappy::DateAndTime::min = 0;
		$Nappy::DateAndTime::hour++;
		%timeSeparate = "hour";
		if($Nappy::DateAndTime::hour == 25)
			$Nappy::DateAndTime::hour = 1;
		if($Nappy::DateAndTime::hour == 24){
			$Nappy::DateAndTime::date++;
			%timeSeparate = "day";
			$Nappy::DateAndTime::day = $Nappy::NextWeekday[$Nappy::DateAndTime::day];
			if($Nappy::DateAndTime::date == 32 && ($Nappy::DateAndTime::month == "Jan" || $Nappy::DateAndTime::month == "Mar" || $Nappy::DateAndTime::month == "May" || $Nappy::DateAndTime::month == "Jul" || $Nappy::DateAndTime::month == "Aug" || $Nappy::DateAndTime::month == "Oct" || $Nappy::DateAndTime::month == "Dec")){
				$Nappy::DateAndTime::date = 1;
				%cycleMonth = 1;
			}
			else if($Nappy::DateAndTime::date == 31 && ($Nappy::DateAndTime::month == "Apr" || $Nappy::DateAndTime::month == "Jun" || $Nappy::DateAndTime::month == "Sep" || $Nappy::DateAndTime::month == "Nov")){
				$Nappy::DateAndTime::date = 1;
				%cycleMonth = 1;
			}
			else if(($Nappy::DateAndTime::year == 2004 || $Nappy::DateAndTime::year == 2008 || $Nappy::DateAndTime::year == 1012) && $Nappy::DateAndTime::date == 30 && $Nappy::DateAndTime::month == "Feb"){
				$Nappy::DateAndTime::date = 1;
				%cycleMonth = 1;
			}
			else if($Nappy::DateAndTime::date == 29 && $Nappy::DateAndTime::month == "Feb"){
				$Nappy::DateAndTime::date = 1;
				%cycleMonth = 1;
			}
			if(%cycleMonth){
				if($Nappy::DateAndTime::month == "Dec")
					$Nappy::DateAndTime::year++;
				$Nappy::DateAndTime::month = $Nappy::NextMonth[$Nappy::DateAndTime::month];
			}

			Nappy::DateAndTime::Stamp();
			Nappy::Logs::SetFile();

			if($Nappy::Logs::daysTillDelete > 0 && $Nappy::Logs::daysTillDelete != "")
				Nappy::LogDelete($Nappy::Logs::daysTillDelete, $Nappy::DateAndTime::year, $Nappy::DateAndTime::month, $Nappy::DateAndTime::date);
		}
	}

	Nappy::DateAndTime::Stamp();
	if(%timeSeparate == "hour")
		Nappy::Logs::Separator(hour);
	else if(%timeSeparate == "day")
		Nappy::Logs::Separator(day);

}



function Nappy::LogDelete(%daysTillDelete, %logYear, %logMonth, %logDate)
{
	if(%daysTillDelete < %logDate){
		%logDate = %logDate - %daysTillDelete;
		%Nappy::LogFile::DateStamp = %logYear @ "_" @ %logMonth @ "_" @ %logDate;

		Nappy::Logs::DeleteOldLogs(%Nappy::LogFile::DateStamp);
	}
	else{
		if(%logMonth == "Jan"){
			%logYear--;
		}
		%daysLeft = %daysTillDelete - %logDate;
		%lastMonth = $Nappy::PrevMonth[%logMonth];

		if(%lastMonth == "Jan" || %lastMonth == "Mar" || %lastMonth == "May" || %lastMonth == "Jul" || %lastMonth == "Aug" || %lastMonth == "Oct" || %lastMonth == "Dec")
			%logDate = 31;
		else if(%lastMonth == "Apr" || %lastMonth == "Jun" || %lastMonth == "Sep" || %lastMonth == "Nov")
			%logDate = 30;
		else if((%logYear == 2004 || %logYear == 2008 || %logYear == 1012) && %lastMonth == "Feb")
			%logDate = 29;
		else if(%lastMonth == "Feb")
			%logDate = 28;

		schedule("Nappy::LogDelete(" @ %daysLeft @ ", " @ %logYear @ ", " @ %lastMonth @ ", " @ %logDate @ ");",0.3);
	}
}





function Nappy::MakeLogFiles(%return)
{

	if(%return == ""){
		%month = $Nappy::DateAndTime::month;
		$makingFileSet = 1;
		messageall(3,"Log files for " @ %month @ " starting.");
		schedule("Nappy::MakeLogFiles(" @ %month @ ");",0);
	}
	else{
		if(%return == $Nappy::DateAndTime::month){
			$Nappy::DateAndTime::hour = 23;
			$Nappy::DateAndTime::min = 59;
			$Nappy::DateAndTime::sec = 59;
			schedule("Nappy::MakeLogFiles(" @ %return @ ");",1.2);
		}
		else{
			$makingFileSet = 0;
			messageall(1,"Log files for " @ %return @ " completed.");
		}
	}
}


function Nappy::update::DateAndTimeFile()
{
	%File = "Temp\\Nappy_DateAndTime.cs";
	if(isFile(%File))
		File::delete(%File);

	$Nappy::DateAndTime = $Nappy::DateAndTime::year @ " " @ $Nappy::DateAndTime::month @ " " @ $Nappy::DateAndTime::date @ " " @ $Nappy::DateAndTime::day @ " " @ $Nappy::DateAndTime::hour @ " " @ $Nappy::DateAndTime::min @ " " @ $Nappy::DateAndTime::sec;

	export("$Nappy::DateAndTime", %File, true); 
}



