
import angular from 'angular';
import config from './config';
import controller from './controller';

let cards = angular.module('card', []);

events.config(config);
events.controller('FlashController', controller);

export default card;
