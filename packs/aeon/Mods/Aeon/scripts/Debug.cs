//---------------------------------------------------------------------------------------------------------------------------------------------------|
//-***NOTE***: This code is NOT meant for any other purpose than to decryptically generate strings using alpha numeric digit conversion increments...|
//- this WILL LAG your game, even by yourself, I guarantee lag, and this IS a SLOW process, don't expect to be greatly impressed by it, it's not...  |
//---------------------------------------------------------------------------------------------------------------------------------------------------|
//-Alpha Numeric Conversions, DO NOT MODIFY--/
//------------------------------------------/
$DebugIntLetter[0] = "a";
$DebugIntLetter[1] = "b";
$DebugIntLetter[2] = "c";
$DebugIntLetter[3] = "d";
$DebugIntLetter[4] = "e";
$DebugIntLetter[5] = "f";
$DebugIntLetter[6] = "g";
$DebugIntLetter[7] = "h";
$DebugIntLetter[8] = "i";
$DebugIntLetter[9] = "j";
$DebugIntLetter[10] = "k";
$DebugIntLetter[11] = "l";
$DebugIntLetter[12] = "m";
$DebugIntLetter[13] = "n";
$DebugIntLetter[14] = "o";
$DebugIntLetter[15] = "p";
$DebugIntLetter[16] = "q";
$DebugIntLetter[17] = "r";
$DebugIntLetter[18] = "s";
$DebugIntLetter[19] = "t";
$DebugIntLetter[20] = "u";
$DebugIntLetter[21] = "v";
$DebugIntLetter[22] = "w";
$DebugIntLetter[23] = "x";
$DebugIntLetter[24] = "y";
$DebugIntLetter[25] = "z";
$DebugIntLetter[26] = "1";
$DebugIntLetter[27] = "2";
$DebugIntLetter[28] = "3";
$DebugIntLetter[29] = "4";
$DebugIntLetter[30] = "5";
$DebugIntLetter[31] = "6";
$DebugIntLetter[32] = "7";
$DebugIntLetter[33] = "8";
$DebugIntLetter[34] = "9";
$DebugIntLetter[35] = "0";
$DebugIntLetter[36] = "_";  //- Shouldn't reach this

//-Default Debugger Settings, I wouldn't recommend changing these-//
$DebugMaxChars    = 9;      //- Leave at 6 unless you want to change the function
$DebugInfoLevel   = 1;      //- Info Display Level; 0: none; 1: only matches; 2+: matches and progress
$DebugLoopSpeed   = 0.0003; //- gets really laggy, even as host, at < 0.0005

//-Strings for the Debugger to check for, works best if you put them in REVERSE alphabetical order-//
$DebugStrCheck[0] = "hi";
$DebugStrCheck[1] = "ice";
$DebugStrCheck[2] = "erm";
$DebugStrCheck[3] = "item";

//-----------------------------------------------------------------------------------------------------------

function Debug::startFind(%this,%start)
{
	if(%this == -1)
		return;
	if($DebugDone[%this] == "false") {
		Debug::End(%this);
		return;
	}
	for(%i = 1; %i <= $DebugMaxChars; %i++)
		$DebugStrNum[%this,%i] = "";
	if(%start) {
		%len = AeonStr::Len(%start);
		for(%i = 0; %i < AeonStr::getWordCount(%start); %i++)
			$DebugStrNum[%this,%i] = getWord(%start,%i);
	}

	%this.aa = "1";
	%this.erm = "1";
	%this.ice = "1";
	
	$DebugDone[%this] = "false";
	Debug::getDebug(%this);
}

function Debug::End(%this)
{
	if(%this == -1)
		return;
	$DebugDone[%this] = "true";
}

function Debug::getDebug(%this)
{
	if(%this == -1)
		return;
	$DebugStrNum[%this,1]++;
	if($DebugStrNum[%this,1] >= 26) {
		$DebugStrNum[%this,2]++;
		if($DebugStrNum[%this,2] >= 36) {
			$DebugStrNum[%this,3]++;
			if($DebugStrNum[%this,3] >= 36) {
				$DebugStrNum[%this,4]++;
				if($DebugStrNum[%this,4] >= 36) {
					$DebugStrNum[%this,5]++;
					if($DebugStrNum[%this,5] >= 36) {
						$DebugStrNum[%this,6]++;
						if($DebugStrNum[%this,6] >= 36) {
							$DebugStrNum[%this,7]++;
							if($DebugStrNum[%this,7] >= 36) {
								$DebugStrNum[%this,8]++;
								if($DebugStrNum[%this,9] >= 36) {
									$DebugStrNum[%this,9]++;
									if($DebugStrNum[%this,9] >= 36) {
										$DebugDone[%this] = "true";
									}
									$DebugStrNum[%this,8] = 0;
								}
								$DebugStrNum[%this,7] = 0;
							}
							$DebugStrNum[%this,6] = 0;
						}
						$DebugStrNum[%this,5] = 0;
					}
					$DebugStrNum[%this,4] = 0;
				}
				$DebugStrNum[%this,3] = 0;
			}
			$DebugStrNum[%this,2] = 0;
		}
		$DebugStrNum[%this,1] = 0;
	}
	Debug::compileStr(%this);
	if($DebugDone[%this] == "false")
		schedule("Debug::getDebug("@%this@");",$DebugLoopSpeed);
}

function Debug::compileStr(%this)
{
	if(%this == -1 || !%this)
		return;
	%debugStr = "";
	for(%i = 1; %i <= $DebugMaxChars; %i++) {
		%char = $DebugIntLetter[$DebugStrNum[%this,%i]];
		if(%char != "" && %char != -1)
			%debugStr = %debugStr@%char;
		else
			break;
	}
	if($DebugInfoLevel >= 1 && $DebugInfoLevel != "") {
		if($DebugInfoLevel > 1)
			echo(%debugStr);
		%debugStr = "."@%debugStr;
		if(eval("Debug::check("@%this@%debugStr@",\""@%debugStr@"\");"))
			echo(%debugStr);
		for(%i = 0; $DebugStrCheck[%i] != ""; %i++) {
			if(%debugStr == $DebugStrCheck[%i]) {
				echo("Debugger String Match: #"@%i@" \""@%debugStr@"\" !!!");
			}
		}
	}
}

function Debug::check(%info,%str)
{
	if(%info != "" && %info != false) {
		echo("Found Info! At "@%str@": "@%info);
		return true;
	}
}