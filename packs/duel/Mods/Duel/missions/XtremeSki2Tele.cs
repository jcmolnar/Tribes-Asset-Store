function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "Main1"){
      %positionIn = "-2640.01 521.82 267.903";
      %positionOut = "";
   }
      else if(%this.num == "Main2"){
      %positionIn = "-2640.01 521.82 267.903";
      %positionOut = "";
   }
   else if(%this.num == "Main3"){
      %positionIn = "-2640.01 521.82 267.903";
      %positionOut = "";
   }
   else if(%this.num == "Main4"){
      %positionIn = "-2499.65 -1671.19 145.59";
      %positionOut = "";
   }

  	if(%this.in){ 
         GameBase::setPosition(%client, %positionIn);
         //messageAll(0, "~wshieldhit.wav");
	   Client::SendMessage(%client,0,"~wshieldhit.wav");
      }
      	else if(%this.out){
         GameBase::setPosition(%client, %positionOut);
         //messageAll(0, "~wshieldhit.wav");
         Client::SendMessage(%client,0,"~wshieldhit.wav");
	}
 
} 


