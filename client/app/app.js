import angular from 'angular';
import uiRouter from 'angular-ui-router';

import cards from './modules/cards';


let App = angular.module('app', [
  'ui.router'
]);

function config($urlRouterProvider) {
  $urlRouterProvider.otherwise("/");
}

App.config(config);
