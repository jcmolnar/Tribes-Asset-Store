//------------------------------------------
//flashIcon()
//------------------------------------------
function flashIcon(%icon, %time, %increment)
{
	if(%time < 100 && %increment > 0.01){
		if($Nappy::Flash1 == 0){
			schedule("flashCheck();",%time);
			%off = "true";
			for(%i = 0; %i <= %time; %i = %i + %increment){
				$Nappy::Flash1 = 1;
				if(%off){   
					schedule("control::setVisible(" @ %icon @ ", " @ %off @ ");", %i);
					%off = "false";
				}
				else{
					schedule("control::setVisible(" @ %icon @ ", " @ %off @ ");", %i);
					%off = "true";
				}
			}
		}
	}
}








function flashCheck()
{
$Nappy::Flash1 = 0;
}






