//watch.cs  This is a clock and server Up-Time Checker Desgined by |*|w00|*|Grey.
//Thanks to ThE eViL iDiOt for concept and [GL]VRWARPER for showserveruptime();

$CurrentDate[month] = "June";
$CurrentDate[day] = "12";
$CurrentDate[year] = "2002";	
$CurrentTime[hour] = "1";
$CurrentTime[colon] = ":";
$CurrentTime[min] = "26";
$CurrentTime[ampm] = "AM";

echo("TIME IS THE 4TH DIMENSION");
function IncTicks()
{
	$ticks = $ticks + 1;
	$CurrentTime[sec] = $CurrentTime[sec] + 1;
	clock();
      continuetimer();
}
function Clock()
{
	%month = $CurrentDate[month];
	if($CurrentTime[sec] == "60")
	{
		savedatetime();
		$CurrentTime[min]++;
		$CurrentTime[sec] = 1;
	}
	if($CurrentTime[sec] == "120")
	{
		savedatetime();
		$CurrentTime[min] = $CurrentTime[min] + 2;
		$CurrentTime[sec] = 1;
	}
	else if($CurrentTime[sec] > 120)
	{
		savedatetime();
		$CurrentTime[min] = floor($CurrentTime[sec]/60);
		$CurrentTime[sec] = 1;
	}
	if($CurrentTime[min] == "60")
	{
		$CurrentTime[hour]++;
		$CurrentTime[min] = 0;
		$CurrentTime[sec] = 1;
		echo("Increasin' Hours");
	}	
	if($CurrentTime[hour] >= "24")
	{
		$CurrentTime[hour] = $CurrentTime[hour] - 24;
		$CurrentTime[ampm] = "AM";
		IncDay(%month);
	}
	if($CurrentTime[hour] >= "12" && $CurrentTime[hour] <= "24")
	{
		$CurrentTime[ampm] = "PM";
	}
	     
}

function starttimer()
{
	echo("SERVER TIME RESET");
	$ticks = 0;
	$CurrentTime[sec] = 0;
	continuetimer();
}
function showcurrenttime()
{
	$CurrentDate = $CurrentDate[month]$+" "$+$CurrentDate[day]$+", "$+$CurrentDate[year];
	if($CurrentTime[hour] < 10 && $CurrentTime[min] < 10)
	{
		$CurrentTime = "0"$+$CurrentTime[hour]$+""$+$CurrentTime[colon]$+"0"$+$CurrentTime[min]$+" "$+$CurrentTime[ampm];
	}
	else if($CurrentTime[hour] < 10 && $CurrentTime[min] > 10)
	{
		$CurrentTime = "0"$+$CurrentTime[hour]$+""$+$CurrentTime[colon]$+""$+$CurrentTime[min]$+" "$+$CurrentTime[ampm];
	}
	else if($CurrentTime[min] < 10 && $CurrentTime[hour] > 10)
	{
		$CurrentTime = $CurrentTime[hour]$+""$+$CurrentTime[colon]$+"0"$+$CurrentTime[min]$+" "$+$CurrentTime[ampm];
	}
	else
	{
		$CurrentTime = $CurrentTime[hour]$+""$+$CurrentTime[colon]$+""$+$CurrentTime[min]$+" "$+$CurrentTime[ampm];
	}
	
	
}
function showtime()
{
	echo($CurrentTime);
	echo($CurrentDate);
}	
function continuetimer()
{
	schedule("IncTicks();", 1.01);
	
}

function addticks()
{
	echo("COMPENSATING FOR LOSS OF TIME FROM MISSION CHANGE");
	$ticks = $ticks + 14;
	$CurrentTime[sec] = $CurrentTime[sec] + 10;
	
}
function showserveruptime() 
{ 
   echo("Calculating Time");
	
   %secs = floor($ticks/60)*60;
   %min = floor(%secs/60); 
   %hour = floor(%min/60); 
   %secs = floor($ticks - (%min * 60));
   %min = floor(%min - (%hour * 60));
       
   	if(%secs < 10) 
          	%secs = "0"$+%secs; 
   	if(%min < 10) 
         	 %min = "0"$+%min; 
   	
     
          $uptime = %hour$+" hr "$+%min$+" min "$+%secs$+" secs"; 
	    
        
   echo($adminbotname@": Server UpTime : "@$uptime);
   
}
function IncDay(%month)
{
	echo("------------***New Day/New Fun***-------------");
	%limit = GetMonthDays(%month);
	if(($CurrentDate[day] + 1) <= %limit)
	{
		$CurrentDate[day] = $CurrentDate[day] + 1;
	}
	else
	{
		$CurrentDate[day] = 1;
		IncMonth();
	}
}
function IncMonth()
{
	if($CurrentDate[month] == "January")
	{
		$CurrentDate[month] = "February";
	}
	else if($CurrentDate[month] == "February")
	{
		$CurrentDate[month] = "March";
	}
	else if($CurrentDate[month] == "March")
	{
		$CurrentDate[month] = "April";
	}
	else if($CurrentDate[month] == "April")
	{
		$CurrentDate[month] = "May";
	}
	else if($CurrentDate[month] == "May")
	{
		$CurrentDate[month] = "June";
	}
	else if($CurrentDate[month] == "June")
	{
		$CurrentDate[month] = "July";
	}
	else if($CurrentDate[month] == "July")
	{
		$CurrentDate[month] = "August";
	}
	else if($CurrentDate[month] == "August")
	{
		$CurrentDate[month] = "September";
	}
	else if($CurrentDate[month] == "September")
	{
		$CurrentDate[month] = "October";
	}
	else if($CurrentDate[month] == "October")
	{
		$CurrentDate[month] = "November";
	}
	else if($CurrentDate[month] == "November")
	{
		$CurrentDate[month] = "December";
	}
	else if($CurrentDate[month] == "December")
	{
		$CurrentDate[month] = "January";
		IncYear();
	}
}
function IncYear()
{
	$CurrentDate[year]++;
}
function GetMonthDays(%month)
{
  if($CurrentDate[year] != "2004" || $CurrentDate[year] != "2008" || $CurrentDate[year] != "2012")
  {	
	if(%month == "January")
	{
		%limit = "31";
	}
	else if(%month == "February")
	{
		%limit = "28";
	}
	else if(%month == "March")
	{
		%limit = "31";
	}
	else if(%month == "April")
	{
		%limit  = "30";
	}
	else if(%month == "May")
	{
		%limit = "31";
	}
	else if(%month == "June")
	{
		%limit  = "30";
	}
	else if(%month == "July")
	{
		%limit = "31";
	}
	else if(%month == "August")
	{
		%limit = "31";
	}
	else if(%month == "September")
	{
		%limit = "30";
	}
	else if(%month == "October")
	{
		%limit = "31";
	}
	else if(%month == "November")
	{
		%limit = "31";
	}
	else if(%month == "December")
	{
		%limit = "31";
	}
   }
   else
   {
	if(%month == "January")
	{
		%limit = "31";
	}
	else if(%month == "February")
	{
		%limit = "29";
	}
	else if(%month == "March")
	{
		%limit = "31";
	}
	else if(%month == "April")
	{
		%limit  = "30";
	}
	else if(%month == "May")
	{
		%limit = "31";
	}
	else if(%month == "June")
	{
		%limit  = "30";
	}
	else if(%month == "July")
	{
		%limit = "31";
	}
	else if(%month == "August")
	{
		%limit = "31";
	}
	else if(%month == "September")
	{
		%limit = "30";
	}
	else if(%month == "October")
	{
		%limit = "31";
	}
	else if(%month == "November")
	{
		%limit = "31";
	}
	else if(%month == "December")
	{
		%limit = "31";
	}
   }
	return(%limit);
}

function savedatetime()
{
	updatetime();
	File::delete("config\\timelog.cs");
	export("$CurrentTime*", "config\\timelog.cs", false);
	datesave();
	
}
function datesave()
{
	updatetime();
	File::delete("config\\datelog.cs");
	export("$CurrentDate*", "config\\datelog.cs", false);
	
}

exec("timelog.cs");
exec("clienttime.cs");
exec("shbanstuff.cs");
exec("connectioncheck.cs");