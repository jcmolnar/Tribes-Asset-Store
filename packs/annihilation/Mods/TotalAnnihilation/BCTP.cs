function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "Main1"){
      %positionIn = "3.79123 -97.5421 325.976";
      %positionOut = "58.9343 -289.636 330.244";
   }
      else if(%this.num == "Main2"){
      %positionIn = "-3.06741 -97.4363 325.974";
      %positionOut = "3.02512 -283.994 330.176";
   }
      else if(%this.num == "Main3"){
      %positionIn = "3.89695 71.2578 330.15";
      %positionOut = "47.5431 -291.178 354.055";
   }
      else if(%this.num == "Main4"){
      %positionIn = "-2.94388 71.1876 330.075";
      %positionOut = "1.42063 -291.033 354.052";
   }
%client = Player::getClient(%object);
	if(%this.num == "Main5"){
      %positionIn = "-2.61209 261.345 326.054";
      %positionOut = "-36.0955 450.548 330.079";
   }
      else if(%this.num == "Main6"){
      %positionIn = "3.96673 261.269 326";
      %positionOut = "19.8759 445.157 330.065";
   }
   else if(%this.num == "Main7"){
      %positionIn = "-2.94467 92.6328 330.041";
      %positionOut = "-25.074 452.096 354.019";
   }
   else if(%this.num == "Main8"){
      %positionIn = "3.88525 92.6927 330.057";
      %positionOut = "21.6885 451.996 354.056";
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


