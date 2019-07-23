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
    stage('exit') {
      steps {
        writeFile(file: 'tesrfilebyheena', text: 'tesrfilebyheena.txt')
        archiveArtifacts(allowEmptyArchive: true, artifacts: '**/test-results/test/*.xml')
      }
    }
  }
}