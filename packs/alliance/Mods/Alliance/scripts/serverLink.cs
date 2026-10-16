// Alliance -- rule-set selector (added by the Modern Tribes port).
//
// The engine's server.cs execs serverLink.cs and then calls serverLink::Start() and, at every
// mission load, serverLink::InitializeMission(). In the original each rule-set mod folder
// brought its own serverLink.cs; the three originals are shipped unchanged as
// serverLink_base.cs, serverLink_pure.cs and serverLink_renegades.cs and this file loads the
// one AllianceSettings.cs asks for.
exec("AllianceSettings.cs");
$Alliance::RuleFile = "pure";
if(String::ICompare($Alliance::RuleSet, "base") == 0)
   $Alliance::RuleFile = "base";
if(String::ICompare($Alliance::RuleSet, "renegades") == 0)
   $Alliance::RuleFile = "renegades";
echo(">> Alliance rule set: " @ $Alliance::RuleFile);
exec("serverLink_" @ $Alliance::RuleFile @ ".cs");
