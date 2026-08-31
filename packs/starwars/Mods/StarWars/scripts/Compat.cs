//-----------------------------------------------------------------------------
// Compat.cs -- console commands this mod expects from the old 1.40 plugin
// DLLs (StringPlugin and friends), reimplemented in script. Same file as
// Annihilation's Compat.cs; loaded from starwars.cs (common.cs is deliberately
// NOT exec'd -- see the Presto stack-overflow note there).
//
// Without these, every server log line, admin list column and stats identifier
// silently blanked ("string::rpad: Unknown command").
//-----------------------------------------------------------------------------

// Pad %str on the RIGHT with spaces until it is %width long. Never crops --
// matches the documented plugin behaviour (see plugins\StringPlugin.txt).
function String::rpad( %str, %width )
{
   for ( %len = String::len( %str ); %len < %width; %len++ )
      %str = %str @ " ";

   return %str;
}

// Per-player identity, used only to tag stats rows. The plugin returned a
// WON/IA GUID; nothing here persists stats off-box, so the client id is a
// stable enough identifier for a single session.
function Client::getGuid( %cl )
{
   return %cl;
}

// Stats event sink. The plugin streamed these to an external collector that
// this build has no counterpart for, so swallow them -- the callers only ever
// push, they never read anything back.
function StatLog::Push( %type, %ident, %a1, %a2, %a3 )
{
}

// Tag-based one-shot scheduler, copied VERBATIM from this mod's own scripts\Schedule.cs.
// The file itself cannot be exec'd by bare name: config\Presto also ships a Schedule.cs,
// and pulling in Presto's tree is the measured stack overflow documented in starwars.cs.
// Callers: server\game\playerscores.cs (the 1s scoreboard refresh loop) and
// server\game\stats.cs (statposthread cancel).
function Schedule::Add( %eval, %time, %tag ) {
	if ( %tag == "" )
		%tag = %eval;
	$Schedule::id[%tag]++;
	$Schedule::eval[%tag] = %eval;

	schedule( "Schedule::Exec(\""@String::Escape(%tag)@"\", "@$Schedule::ID[%tag]@");", %time );
}

function Schedule::Exec( %tag, %id ) {
	if ( $Schedule::ID[%tag] != %id )
		return;

	%eval = $Schedule::eval[%tag];
	Schedule::Cancel(%tag);
	eval(%eval);
}

function Schedule::Cancel( %tag ) {
	$Schedule::ID[%tag]++;
	$Schedule::eval[%tag] = "";
}

function Schedule::Check( %tag ) {
	return ( $Schedule::eval[%tag] != "" ) ? true : false;
}

// 1.1 Bootstrap mod-loader parity: Server::storeData (server\server.cs) calls this after
// exporting server data so a changed $modList took effect next mission. In this build the
// mod list is FIXED for the process (the mod selector restarts the game), and the nearest
// base equivalent, EvalSearchPath (console.cs), also deletes and reloads every skin and
// voice volume -- churn with no benefit mid-session. A no-op is the faithful equivalent.
function Bootstrap::evalSearchPath()
{
}
