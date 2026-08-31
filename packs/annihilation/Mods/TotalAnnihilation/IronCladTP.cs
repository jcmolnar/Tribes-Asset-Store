function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "T1"){
      %positionIn = "510.169 4854.03 132.639";
      %positionOut = "493.129 4854.04 132.491";
   }
      else if(%this.num == "T2"){
      %positionIn = "163.845 4857.08 132.343";
      %positionOut = "146.846 4857.05 132.513";
   }
%client = Player::getClient(%object);
	if(%this.num == "T3"){
      %positionIn = "499.6 4689.81 145.329";
      %positionOut = "157.356 4692.86 144.913";
   }
      else if(%this.num == "B2"){
      %positionIn = "-186.953 230.78 872.832";
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


