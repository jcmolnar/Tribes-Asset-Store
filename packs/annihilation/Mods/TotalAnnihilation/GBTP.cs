function GroupTrigger::onEnter(%this, %object)
{
%client = Player::getClient(%object);
	if(%this.num == "Main1"){
      %positionIn = "-531.284 -163.498 226.613";
      %positionOut = "-531.161 -71.6097 226.568";
   }
      else if(%this.num == "Main2"){
      %positionIn = "-531.939 -83.1196 250.11";
      %positionOut = "-552.465 -152.059 250.428";
   }
      else if(%this.num == "Main3"){
      %positionIn = "220.004 -163.519 226.683";
      %positionOut = "219.9 -71.5959 226.742";
   }
      else if(%this.num == "Main4"){
      %positionIn = "240.155 -83.0672 250.153";
      %positionOut = "220.777 -152.056 250.4";
   }
%client = Player::getClient(%object);
	if(%this.num == "Main5"){
      %positionIn = "-161.41 -117.347 264.028";
      %positionOut = "-542.641 -103.731 246.272";
   }
%client = Player::getClient(%object);
	if(%this.num == "Main6"){
      %positionIn = "-541.638 -131.783 246.37";
      %positionOut = "229.961 -103.437 246.489";
   }
%client = Player::getClient(%object);
	if(%this.num == "Main7"){
      %positionIn = "229.952 -131.409 246.613";
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


