
import angular from 'angular';
import config from './config';
import controller from './controller';

let cards = angular.module('card', 'subject', []);

cards.config(config);
cards.controller('FlashController', controller);

export default cards;
