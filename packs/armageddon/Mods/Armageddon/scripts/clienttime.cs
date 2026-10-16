//clienttime.cs  This is a Script that allows clients to see how long they 
//have been on your server Desgined by |*|w00|*|Grey.

function IncClientSecs(%clientId)
{
	%clientId.secs = %clientId.secs + 1;
      continuetimer2(%clientId);
}
function starttimer2(%clientId)
{
	%clientId.secs = 0;
	%clientId.counting = true;
	continuetimer2(%clientId);
	echo("Starting Time Reference for Client");
}

function continuetimer2(%clientId)
{
	schedule("IncClientSecs("@%clientId@");", 1);
	
}

function addsecs(%clientId)
{
	%clientId.secs = %clientId.secs + 14;
		
}
function showclienttime(%clientId) 
{ 
   %c = Player::GetClient(%clientId);
   %cname = Client::getName(%c);
   %secs = floor(%clientId.secs/60)*60;
   %min = floor(%secs/60); 
   %hour = floor(%min/60); 
   %secs = floor(%clientId.secs - (%min * 60));
   %min = floor(%min - (%hour * 60));
       
   	if(%secs < 10) 
          	%secs = "0"$+%secs; 
   	if(%min < 10) 
         	 %min = "0"$+%min; 
   	
     
   %clientId.playtime = %hour$+" hr "$+%min$+" min "$+%secs$+" secs"; 
   client::sendMessage(%c,3,"You Have been on this server: "@%clientId.playtime);
         
}

