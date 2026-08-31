function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "Main1"){
      %positionIn = "-415.342 -468.709 542.844";
      %positionOut = "-464.811 0.960023 542.711";
   }
      else if(%this.num == "Main2"){
      %positionIn = "-518.17 -465.591 597.941";
      %positionOut = "-518.169 -465.59 597.94";
   }
   else if(%this.num == "Main3"){
      %positionIn = "-415.341 -468.708 542.843";
      %positionOut = "";
   }
%client = Player::getClient(%object);
	if(%this.num == "Main4"){
      %positionIn = "-464.809 0.960021 542.709";
      %positionOut = "-415.339 -468.706 542.841";
   }
      else if(%this.num == "Main5"){
      %positionIn = "-362.038 -2.01909 598.243";
      %positionOut = "-362.037 -2.01908 598.242";
   }
   else if(%this.num == "Main6"){
      %positionIn = "-464.809 0.960021 542.709";
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


