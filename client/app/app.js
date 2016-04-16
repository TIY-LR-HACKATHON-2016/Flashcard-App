import angular from 'angular';
import uiRouter from 'angular-ui-router';

import cards from './modules/cards';
import subject from './modules/subjects'

let App = angular.module('app', [
  'ui.router',
  'card',
  'subject'
]);

function config($urlRouterProvider) {
  $urlRouterProvider.otherwise("/");
}

App.config(config);
