
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

def publishTestResults(ResultsFolder) {
    step([
            $class: 'BasicUnitTest',
            thresholdMode: 1,
            thresholds: [[$class: 'FailedThreshold', failureThreshold: '1']],
            tools: [[
                $class: 'UnitTest1',
                deleteOutputFiles: true,
                failIfNotNew: true,
                pattern: ResultsFolder,
                skipNoTestFiles: false,
                stopProcessingIfError: true
            ]]
        ])
}

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
   publishTestResults('FunctionalTests\\TestResults\\**\\*')   
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