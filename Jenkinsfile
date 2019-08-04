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
      environment {
        CI = 'true'
      }
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
      environment {
        TESTER = 'HEENA'
        BUILD_ID = 'CI_FO_PROJECTS'
      }
      parallel {
        stage('Exit/Artifact') {
          steps {
            echo '****Exiting SmartElector pipeline****'
          }
        }
        stage('Testing Jenkins') {
          steps {
            echo "The Tester is ${TESTER}"
            sleep 10
          }
        }
        stage('Print Build Number') {
          post {
            always {
              junit 'test-results.xml'

            }

          }
          steps {
            echo "This is build number ${BUILD_ID}"
            sleep 20
          }
        }
      }
    }
  }
}