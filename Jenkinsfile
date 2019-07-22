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

pipeline {
  agent any
  stages {
    stage('Enter') {
      steps {
        echo '************We are enetering GITHUB for building************'
      }
    }
    stage('Build') {
      steps {
        powershell(script: './build.ps1 -script "./build.cake" -target "Build" -verbosity normal', returnStatus: true)
      }
    }
    stage('BClear') {
      parallel {
        stage('BClear') {
          steps {
            echo 'BuildHasBeenCleared'
          }
        }
        stage('Test') {
          steps {
            powershell(script: './build.ps1 -script "./build.cake" -target "Test" -verbosity normal', returnStatus: true)
          }
        }
      }
    }
    stage('Exit/Artifact') {
      steps {
        echo '****Exiting SmartElector pipeline****'
        publishTestResults('test-results\\**\\*')
      }
    }
  }
    post {
        always {
            archiveArtifacts artifacts: 'generatedFile.txt', onlyIfSuccessful: true
        }
    }
}
