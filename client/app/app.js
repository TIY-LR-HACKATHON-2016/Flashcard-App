import angular from 'angular';
import uiRouter from 'angular-ui-router';

import cards from './modules/cards';
import subject from './modules/subjects';
import set from './modules/sets';

let App = angular.module('app', [
  'ui.router',
  'card',
  'subject',
  'set'
]);

function config($urlRouterProvider, $httpProvider) {
  $urlRouterProvider.otherwise("/");
}

App.config(config);
