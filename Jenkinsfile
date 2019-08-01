pipeline {
  agent any
  stages {
    stage('Enter') {
      steps {
        echo '************We are enetering GITHUB for building************'
      }
    }
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            powershell(script: './build.ps1 -script "./build.cake" -target "Build" -verbosity normal ', returnStatus: true)
          }
        }
        stage('Stashing') {
          steps {
            powershell(script: 'stash includes: \'/dist/**/*\', name: \'builtSources\'', label: 'Stashed', returnStatus: true)
          }
        }
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
      }
    }
    stage('StashUsingDefaultLink') {
      steps {
        stash(name: 'builtSourcesthroughinbuild', allowEmpty: true, useDefaultExcludes: true)
      }
    }
    stage('unstash') {
      steps {
        unstash 'builtSourcesthroughinbuild'
      }
    }
  }
}