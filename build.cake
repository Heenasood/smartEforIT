
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Test")
.Does(() => {
   Information("******TEST EXECUTION START********");
   MSTest("./BasicUnitTest.dll");
   Information("******TEST EXECUTION COMPLETE********");
    
});

Task("Build")
.Does(() => {
   Information("******BUILD PROJECT EXECUTION START********");
   MSBuild("./SmartE.sln");
    Information("******BUILD PROJECT EXECUTION Complete********");
});


Task("Default")

.Does(() => {
   Information("BUILD");
});


RunTarget(target);
