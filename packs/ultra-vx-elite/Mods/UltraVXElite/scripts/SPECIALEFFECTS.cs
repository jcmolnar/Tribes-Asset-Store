
function Snipers::FlagFireworks(%object)
{
	%pos = GameBase::GetPosition(%object);
	%pos = Snipers::FlagFireworksFindPos(%pos);
	Snipers::Fireworks(%object, 5, %pos);
}

function Snipers::FlagFireworksFindPos(%pos)
{
	%set = NewObject("FireWorksSet", SimSet);
	%num = ContainerBoxFillSet(%set, $SimInteriorObjectType, %pos, 1, 1, 35, 0);
	if(%num > 0)
	{
		%newpos = Vector::Add(%pos, "0 0 5");
		%pos = Snipers::FlagFireworksFindPos(%newpos);
	}
	deleteobject(%set);
	return %pos;
}

function Snipers::Fireworks(%object, %time, %position)
{
	if(%time == "")
		%time = 5;
	if(%time > 0)
	{
		%type = (floor(%time * 100) % 3) + 1;
		%bomb = NewObject("Fireworks", "Mine", "FireworkEffect" @ %type);
		if(%type == 3)
			%add = 60;
		else
			%add = 80;
		AddToSet($SFXMainSet, %bomb);
		GameBase::Throw(%bomb, %object, floor(GetRandom() * 30) + %add, true);
		if(%position != "")
			GameBase::SetPosition(%bomb, %position);
		%rand = GetRandom()/12;
		%time = %time - %rand;
		if(%position == "")
			schedule("Snipers::Fireworks(" @ %object @ ", " @ %time @ ");", %rand);
		else
			schedule("Snipers::Fireworks(" @ %object @ ", " @ %time @ ", \"" @ %position @ "\");", %rand);
	}
}

function RandomPositionXY(%minrad, %maxrad)
{
	%maxrad *= 100;
	%minrad *= 100;
	%diff = %maxrad - %minrad;

	%tmpX = floor(getRandom() * (%diff*2)) - %diff;
	if(%tmpX < 0)
		%tmpX -= %minrad;
	else
		%tmpX += %minrad;

	%tmpY = floor(getRandom() * (%diff*2)) - %diff;
	if(%tmpY < 0)
		%tmpY -= %minrad;
	else
		%tmpY += %minrad;
	%tmpx *= 0.01;
	%tmpy *= 0.01;
	return %tmpX @ " " @ %tmpY @ " ";
}