// This was my attempt at setting up different 'priorities' for bottom and centerprinting,
// Alot of center and bottomprints are used and this would make sure that only the most 
// important bottom or centerprint is shown. Development fell threw... i got lazy..
//
// Level One:
function CenterPrint(%clientId, %msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "CP", %msg, %timeout);
}
function BottomPrint(%clientId, %msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "BP", %msg, %timeout);
}
function TopPrint(%clientId, %msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	remoteEval(%clientId, "TP", %msg, %timeout);
}
function CenterPrintAll(%msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true){ return; }
	if(%timeout == ""){ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "CP", %msg, %timeout); }
}
function BottomPrintAll(%msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true)
	{ return; }
	if(%timeout == "")
	{ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "BP", %msg, %timeout); }
}
function TopPrintAll(%msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true)
	{ return; }
	if(%timeout == "")
	{ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "TP", %msg, %timeout); }
} 

// Level Two:
function XCenterPrint(%clientId, %message, %time){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD){ return; }
	if(%time == ""){ %time = 5; }
	remoteEval(%clientId, "CP", %message, %time);
	%clientId.importantCP = true;
	Schedule(%clientId @".importantCP = false;", %time);
}
function XBottomPrint(%clientId, %message, %time){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	
	if(%time == "")
	{ %time = 5; }
	remoteEval(%clientId, "BP", %message, %time);
	%clientId.importantBP = true;
	Schedule(%clientId @".importantBP = false;", %time);
}
function XBottomPrintAll(%message, %time){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	if(%clientId.importantCP == true || %clientId.importantBP == true)
	{ return; }
	if(%timeout == "")
	{ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		remoteEval(%clientId, "BP", %message, %time);
		%clientId.importantBP = true;
		Schedule(%clientId @".importantBP = false;", %time);
	}
}
function XCenterPrintAll(%msg, %timeout){
	if(%clientId.justConnected && %msg != $Server::JoinMOTD)
	{ return; }
	if(%timeout == "")
	{ %timeout = 5; }
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{ remoteEval(%clientId, "CP", %msg, %timeout); }
}